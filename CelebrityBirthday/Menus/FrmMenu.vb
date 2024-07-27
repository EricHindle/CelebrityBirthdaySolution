' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmMenu
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub BtnImages_Click(sender As Object, e As EventArgs) Handles BtnImages.Click
        Hide()
        Using imgForm As New FrmImageMenu
            LogUtil.Info("Opening Images menu", MyBase.Name)
            imgForm.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnDatabase_Click(sender As Object, e As EventArgs) Handles BtnDatabase.Click
        Hide()
        Using _database As New FrmUpdateDatabase
            LogUtil.Info("Opening update form", MyBase.Name)
            _database.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnOptions_Click(sender As Object, e As EventArgs)
        Hide()
        Using _options As New FrmOptions
            LogUtil.Info("Opening Options", MyBase.Name)
            _options.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Hide()
        Using _search As New FrmSearch
            LogUtil.Info("Opening Search", MyBase.Name)
            _search.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnWordPress.Click
        Hide()
        Using _wordPress As New FrmWordPress
            LogUtil.Info("Opening WordPress", MyBase.Name)
            _wordPress.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnTweet_Click(sender As Object, e As EventArgs) Handles BtnTweet.Click
        Hide()
        Using _tweetMenu As New FrmTwitterMenu
            LogUtil.Info("Opening Twitter Menu", MyBase.Name)
            _tweetMenu.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        InitialiseApplication()
    End Sub
    Private Sub BtnMore_Click(sender As Object, e As EventArgs) Handles BtnMore.Click
        Hide()
        Using _menu2 As New FrmMenu2
            LogUtil.Info("Opening menu2", MyBase.Name)
            _menu2.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnBotsdWP_Click(sender As Object, e As EventArgs) Handles BtnBotsdWP.Click
        Hide()
        Using _botsd As New FrmBotsd
            LogUtil.Info("Opening Born on the Same Day form", MyBase.Name)
            _botsd.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub FrmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        If oReminders IsNot Nothing AndAlso Not oReminders.IsDisposed Then
            oReminders.Close()
        End If
    End Sub
    Private Sub FrmMenu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Refresh()
        LogUtil.Info("Checking arguments", MyBase.Name)
        Dim args As String() = Environment.GetCommandLineArgs()
        Dim isRunDeathCheck As Boolean = False
        Dim isLeaveOpen As Boolean = False
        If args.Length > 1 Then
            For Each arg As String In args
                Select Case arg
                    Case "/d"
                        LogUtil.Info("Death Check", MyBase.Name)
                        isRunDeathCheck = True
                    Case "/o"
                        LogUtil.Info("Leave program open", MyBase.Name)
                        isLeaveOpen = True
                End Select
            Next
            If isRunDeathCheck Then
                LogUtil.Info("Autorun Death Check", MyBase.Name)
                Using _warning As New FrmDeathCheck
                    _warning.Autorun = True
                    _warning.LeaveOpen = isLeaveOpen
                    _warning.ShowDialog()
                End Using
            End If
            If Not isLeaveOpen Then
                LogUtil.Info("Autorun complete. Closing program.", MyBase.Name)
                Close()
            End If
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub InitialiseApplication()
        If My.Settings.callUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.callUpgrade = 1
            My.Settings.Save()
        End If
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
        Dim sConnection As String() = Split(My.Settings.CelebrityBirthdayConnectionString, ";")
        Dim serverName As String = ""
        Dim dbName As String = ""
        For Each oConn As String In sConnection
            Dim nvp As String() = Split(oConn, "=")
            If nvp.GetUpperBound(0) = 1 Then
                Select Case nvp(0)
                    Case "Data Source"
                        serverName = nvp(1)
                    Case "Initial Catalog"
                        dbName = nvp(1)
                End Select
            End If
        Next
        Dim _runtime As List(Of String) = {My.Application.Info.Title & " version " & My.Application.Info.Version.ToString,
                                            "Computer name : " & My.Computer.Name,
                                            "Data connection: ",
                                            "   server=" & serverName,
                                            "   database=" & dbName,
                                            "Application path is " & My.Application.Info.DirectoryPath}.ToList
        For Each _rt As String In _runtime
            LogUtil.Info(_rt, MyBase.Name)
        Next
        Dim celebCount As Integer = CountPeople()
        If celebCount >= 0 Then
            LblCelebrities.Text = System.String.Format(myStringFormatProvider, LblCelebrities.Text, CStr(celebCount))
        Else
            LogUtil.Fatal("Database not available", MyBase.Name)
            Close()
        End If

        If oReminders Is Nothing OrElse oReminders.IsDisposed Then
            oReminders = New FrmReminders
        End If
        If oReminders.LoadReminders > 0 Then
            LogUtil.Info("Reminders", MyBase.Name)
            oReminders.TopMost = True
            oReminders.Show()
        End If
    End Sub

    Private Sub BtnDeadList_Click(sender As Object, e As EventArgs) Handles BtnDeadList.Click
        LogUtil.Info("Showing list of deaths", MyBase.Name)
        Hide()
        Using _list As New FrmDeathList
            _list.Year = Today.Year
            _list.ShowDialog()
        End Using
        Show()
    End Sub

#End Region
End Class
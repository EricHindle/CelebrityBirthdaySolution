﻿Public Class FrmMenu
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnImages_Click(sender As Object, e As EventArgs) Handles BtnImages.Click
        Me.Hide()
        Using imgForm As New FrmImages
            LogUtil.Info("Images", MyBase.Name)
            imgForm.ShowDialog()
        End Using
        Me.Show()
    End Sub

    Private Sub BtnDatabase_Click(sender As Object, e As EventArgs) Handles BtnDatabase.Click
        Me.Hide()
        Using _database As New FrmUpdateDatabase
            LogUtil.Info("Database", MyBase.Name)
            _database.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnOptions_Click(sender As Object, e As EventArgs) Handles BtnOptions.Click
        Me.Hide()
        Using _options As New FrmOptions
            LogUtil.Info("Options", MyBase.Name)
            _options.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnPictures_Click(sender As Object, e As EventArgs) Handles BtnPictures.Click
        Me.Hide()
        Using _pictures As New FrmImageStore
            LogUtil.Info("Pictures", MyBase.Name)
            _pictures.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Me.Hide()
        Using _search As New FrmSearch
            LogUtil.Info("Search", MyBase.Name)
            _search.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnWordPress.Click
        Me.Hide()
        Using _wordPress As New FrmWordPress
            LogUtil.Info("WordPress", MyBase.Name)
            _wordPress.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnTweet_Click(sender As Object, e As EventArgs) Handles BtnTweet.Click
        Me.Hide()
        Using _tweet As New FrmTweet
            LogUtil.Info("Tweet", MyBase.Name)
            _tweet.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
        InitialiseApplication()
    End Sub
    Private Sub InitialiseApplication()
        If My.Settings.callUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.callUpgrade = 1
            My.Settings.Save()
        End If
        LblCelebrities.Text = System.String.Format(myStringFormatProvider, LblCelebrities.Text, CStr(CountPeople()))
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.StartLogging()
    End Sub

    Private Sub BtnMore_Click(sender As Object, e As EventArgs) Handles BtnMore.Click
        Me.Hide()
        Using _menu2 As New FrmMenu2
            _menu2.ShowDialog()
        End Using
        Me.Show()
    End Sub

    Private Sub BtnBotsdWP_Click(sender As Object, e As EventArgs) Handles BtnBotsdWP.Click
        Me.Hide()
        Using _botsd As New FrmBotsd
            LogUtil.Info("Born on the Same Day", MyBase.Name)
            _botsd.ShowDialog()
        End Using
        Me.Show()
    End Sub

    Private Sub FrmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Debug("Closing", MyBase.Name)
    End Sub
End Class
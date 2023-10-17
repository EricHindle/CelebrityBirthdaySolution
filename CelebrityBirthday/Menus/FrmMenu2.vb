' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmMenu2
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        LogUtil.Info("Closing", MyBase.Name)
        Close()
    End Sub
    Private Sub BtnSendTweet_Click(sender As Object, e As EventArgs)
        Hide()
        LogUtil.Info("Single Tweet", MyBase.Name)
        Using _sendTwitter As New FrmSingleTweet
            _sendTwitter.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnBrownBread_Click(sender As Object, e As EventArgs) Handles BtnBrownBread.Click
        LogUtil.Info("Check deaths", MyBase.Name)
        Hide()
        Using _warning As New FrmDeathCheck
            _warning.Autorun = False
            _warning.LeaveOpen = False
            _warning.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnTwitter_Click(sender As Object, e As EventArgs)
        LogUtil.Info("Twitter", MyBase.Name)
        Hide()
        Using _twitterForm As New FrmTwitterOutput
            _twitterForm.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub TxtBirthdateCheck_Click(sender As Object, e As EventArgs) Handles TxtBirthdateCheck.Click
        LogUtil.Info("Birth date check", MyBase.Name)
        Hide()
        Using _check As New FrmDateCheck
            _check.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnWikiIds_Click(sender As Object, e As EventArgs) Handles BtnWikiIds.Click
        LogUtil.Info("Wiki Ids", MyBase.Name)
        Hide()
        Using _check As New FrmAddWikiIds
            _check.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnViewLog_Click(sender As Object, e As EventArgs) Handles BtnViewLog.Click
        Hide()
        Using _logView As New FrmLogViewer
            _logView.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnDeadList_Click(sender As Object, e As EventArgs) Handles BtnDeadList.Click
        LogUtil.Info("List of deaths", MyBase.Name)
        Hide()
        Using _list As New FrmDeathList
            _list.Year = Today.Year
            _list.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnOptions_Click(sender As Object, e As EventArgs) Handles BtnOptions.Click
        Hide()
        Using _options As New FrmOptions
            LogUtil.Info("Options", MyBase.Name)
            _options.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnReminders_Click(sender As Object, e As EventArgs) Handles BtnReminders.Click
        Hide()
        Using _rems As New FrmReminders
            LogUtil.Info("Reminders", MyBase.Name)
            _rems.ShowDialog()
        End Using
        Show()
    End Sub
#End Region
End Class
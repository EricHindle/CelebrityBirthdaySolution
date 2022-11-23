' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
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
    Private Sub BtnSendTweet_Click(sender As Object, e As EventArgs) Handles BtnSendTweet.Click
        Hide()
        LogUtil.Info("Single Tweet", MyBase.Name)
        Using _sendTwitter As New FrmSendTwitter
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
    Private Sub BtnTwitter_Click(sender As Object, e As EventArgs) Handles BtnTwitter.Click
        LogUtil.Info("Twitter", MyBase.Name)
        Hide()
        Using _twitterForm As New frmTwitterOutput
            _twitterForm.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnTapestry_Click(sender As Object, e As EventArgs) Handles BtnMosaic.Click
        LogUtil.Info("Photo tapestry", MyBase.Name)
        Hide()
        Using _tapestryForm As New FrmMosaic
            _tapestryForm.ShowDialog()
        End Using
        Show()
    End Sub
    Private Sub BtnImageEditing_Click(sender As Object, e As EventArgs) Handles BtnImageEditing.Click
        LogUtil.Info("Image editing", MyBase.Name)
        Hide()
        Using _imgEditForm As New FrmImageCapture
            _imgEditForm.ShowDialog()
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
    Private Sub BtnTest_Click_1(sender As Object, e As EventArgs) Handles BtnTest.Click
        LogUtil.Info("Testing", MyBase.Name)
        Hide()
        Using _imgCheck As New FrmImageCheck
            _imgCheck.showdialog
        End Using
        'Using _fbtest As New FrmFacebookTest
        '    _fbtest.ShowDialog()
        'End Using
        Show()
    End Sub
#End Region
End Class
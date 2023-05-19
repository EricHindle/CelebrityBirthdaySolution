' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmTwitterMenu
    Private Sub BtnTweet_Click(sender As Object, e As EventArgs) Handles BtnTweet.Click
        Hide()
        Using _tweet As New FrmDailyTweets
            LogUtil.Info("Tweet", MyBase.Name)
            _tweet.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnTwitter_Click(sender As Object, e As EventArgs) Handles BtnTwitter.Click
        LogUtil.Info("Twitter", MyBase.Name)
        Hide()
        Using _twitterForm As New FrmTwitterOutput
            _twitterForm.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnSendTweet_Click(sender As Object, e As EventArgs) Handles BtnSendTweet.Click
        Hide()
        LogUtil.Info("Single Tweet", MyBase.Name)
        Using _sendTwitter As New FrmSingleTweet
            _sendTwitter.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        LogUtil.Info("Closing", MyBase.Name)
        Close()
    End Sub

    Private Sub BtnTwitterMosaic_Click(sender As Object, e As EventArgs) Handles BtnTwitterMosaic.Click
        LogUtil.Info("Twitter mosaic", MyBase.Name)
        Hide()
        Using _twitterForm As New FrmTwitterMosaic
            _twitterForm.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnAuthenticateTwitter_Click(sender As Object, e As EventArgs) Handles BtnAuthenticateTwitter.Click
        LogUtil.Info("Authenticate Twitter", MyBase.Name)
        Hide()
        Using _twitterForm As New FrmTwitterAuth
            _twitterForm.ShowDialog()
        End Using
        Show()
    End Sub
End Class
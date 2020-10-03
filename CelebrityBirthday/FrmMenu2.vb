Public Class FrmMenu2
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnSendTweet.Click
        Me.Hide()
        Using _sendTwitter As New FrmSendTwitter
            _sendTwitter.ShowDialog()

        End Using
        Me.Show()
    End Sub
    Private Sub BtnBrownBread_Click(sender As Object, e As EventArgs) Handles BtnBrownBread.Click
        Me.Hide()
        Using _warning As New FrmDeathCheck
            _warning.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnTwitter_Click(sender As Object, e As EventArgs) Handles BtnTwitter.Click
        Me.Hide()
        Using _twitterForm As New frmTwitterOutput
            _twitterForm.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnTapestry_Click(sender As Object, e As EventArgs) Handles BtnTapestry.Click
        Me.Hide()
        Using _tapestryForm As New FrmMosaic
            _tapestryForm.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnImageEditing_Click(sender As Object, e As EventArgs) Handles BtnImageEditing.Click
        Me.Hide()
        Using _imgEditForm As New frmImageCapture
            _imgEditForm.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub TxtBirthdateCheck_Click(sender As Object, e As EventArgs) Handles TxtBirthdateCheck.Click
        Me.Hide()
        Using _check As New FrmDateCheck
            _check.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnWikiIds_Click(sender As Object, e As EventArgs) Handles BtnWikiIds.Click
        Me.Hide()
        Using _check As New FrmAddWikiIds
            _check.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnViewLog_Click(sender As Object, e As EventArgs) Handles BtnViewLog.Click
        Using _logView As New frmLogViewer
            _logView.ShowDialog()
        End Using
    End Sub
End Class
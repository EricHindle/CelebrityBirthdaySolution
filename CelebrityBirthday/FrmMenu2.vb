Public Class FrmMenu2
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest.Click
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
End Class
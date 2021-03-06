﻿Public Class FrmAlterPostNo

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not String.IsNullOrEmpty(TxtExistingNo.Text) AndAlso Not String.IsNullOrEmpty(TxtNewNo.Text) _
            AndAlso IsNumeric(TxtExistingNo.Text) AndAlso IsNumeric(TxtNewNo.Text) Then
            If UpdateBotsd(CInt(TxtExistingNo.Text), CInt(TxtNewNo.Text)) > 0 Then
                If chkAlterNextPostNo.Checked Then
                    Dim recordId As String = "Next WP number"
                    GlobalSettings.SetSetting(recordId, "integer", TxtExistingNo.Text, "")
                End If
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("Must supply existing and new numbers", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmAlterPostNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
    End Sub

    Private Sub FrmAlterPostNo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
End Class

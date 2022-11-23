' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmAlterPostNo
#Region "form control handlers"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Not String.IsNullOrEmpty(TxtExistingNo.Text) AndAlso Not String.IsNullOrEmpty(TxtNewNo.Text) _
            AndAlso IsNumeric(TxtExistingNo.Text) AndAlso IsNumeric(TxtNewNo.Text) Then
            LogUtil.Info("Updating BotSD post number", MyBase.Name)
            If UpdateBotsd(TxtExistingNo.Text, TxtNewNo.Text) > 0 Then
                If chkAlterNextPostNo.Checked Then
                    LogUtil.Info("Updating next WordPress post number", MyBase.Name)
                    Dim recordId As String = "Next WP number"
                    GlobalSettings.SetSetting(recordId, "integer", TxtExistingNo.Text, "")
                End If
            End If
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
        Else
            MsgBox("Must supply existing and new numbers", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = System.Windows.Forms.DialogResult.Cancel
        Close()
    End Sub
    Private Sub FrmAlterPostNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
    End Sub
    Private Sub FrmAlterPostNo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
#End Region
End Class

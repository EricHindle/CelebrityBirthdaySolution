'
' Copyright (c) 2020, Eric Hindle
' All rights reserved.
'
' Author E Hindle
' Created June 2020

Imports System.Windows.Forms
Imports System.IO

Public Class frmLogViewer
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub LogViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        Me.Text = "Log: " & LogUtil.GetLogfileName
        rtbLog.Text = LogUtil.GetLogContents()
    End Sub
    Private Sub ClearLog()
        LogUtil.ClearLogFile()
        rtbLog.Text = ""
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoZoom.Click
        TrackBar1.Value = 10
    End Sub
    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        rtbLog.ZoomFactor = TrackBar1.Value / 10
        btnNoZoom.Text = rtbLog.ZoomFactor
    End Sub
    Private Sub WrapTextToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrapTextToolStripMenuItem.Click
        rtbLog.WordWrap = WrapTextToolStripMenuItem.Checked
    End Sub
    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        TrackBar1.Visible = ZoomToolStripMenuItem.Checked
        btnNoZoom.Visible = ZoomToolStripMenuItem.Checked
        If ZoomToolStripMenuItem.Checked = False Then
            TrackBar1.Value = 10
        End If
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        rtbLog.Copy()
    End Sub
    Private Sub CopyAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyAllToolStripMenuItem.Click
        rtbLog.SelectAll()
        rtbLog.Copy()
        rtbLog.Select(0, 0)
    End Sub
    Private Sub BtnClearLog_Click(sender As Object, e As EventArgs) Handles BtnClearLog.Click
        ClearLog()
        rtbLog.Text = LogUtil.GetLogContents()
    End Sub

    Private Sub FrmLogViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
End Class

﻿Imports System.ComponentModel

Public NotInheritable Class FrmShowImage
    Private _imageLocation As String
    Public Property ImageLocation() As String
        Get
            Return _imageLocation
        End Get
        Set(ByVal value As String)
            _imageLocation = value
        End Set
    End Property

    Private Sub FrmShowImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox2.ImageLocation = _imageLocation
    End Sub

    Private Sub FrmShowImage_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        PictureBox2.ImageLocation = Nothing
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.DoubleClick
        Me.Close()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class

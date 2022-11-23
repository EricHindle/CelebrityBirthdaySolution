' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.ComponentModel
Public NotInheritable Class FrmShowImage
#Region "variables"
    Private _imageLocation As String
#End Region
#Region "form control handlers"
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
        Close()
    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub
#End Region
End Class

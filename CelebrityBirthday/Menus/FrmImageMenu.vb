' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmImageMenu
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        LogUtil.Info("Closing", MyBase.Name)
        Close()
    End Sub

    Private Sub BtnMosaic_Click(sender As Object, e As EventArgs) Handles BtnMosaic.Click
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
        Using _imgEditForm As New FrmImageEdit
            _imgEditForm.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnPictures_Click(sender As Object, e As EventArgs) Handles BtnPictures.Click
        Hide()
        Using _pictures As New FrmImageStore
            LogUtil.Info("Pictures", MyBase.Name)
            _pictures.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnImages_Click(sender As Object, e As EventArgs) Handles BtnImages.Click
        Hide()
        Using imgForm As New FrmDatabaseImages
            LogUtil.Info("Images", MyBase.Name)
            imgForm.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub FrmImageMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnImageCheck_Click(sender As Object, e As EventArgs) Handles BtnImageCheck.Click
        Hide()
        Using imgForm As New FrmImageCheck
            LogUtil.Info("Images", MyBase.Name)
            imgForm.ShowDialog()
        End Using
        Show()
    End Sub
End Class
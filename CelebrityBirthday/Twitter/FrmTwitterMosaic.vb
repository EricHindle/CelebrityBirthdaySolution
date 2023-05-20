' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO

Public Class FrmTwitterMosaic
    Dim isChangingSize As Boolean = False
    Private _imageList As New List(Of Person)
    Private Const MOSAIC_WIDTH As Integer = 45
    Private Const MOSAIC_HEIGHT As Integer = 15

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmTwitterMosaic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShowStatus("Closing", MyBase.Name, Nothing)
        For Each _person As Person In _imageList
            _person.Dispose()
        Next
        My.Settings.twitterMosaicFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub FrmTwitterMosaic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowStatus("Loading", MyBase.Name, Nothing)
        GetFormPos(Me, My.Settings.twitterMosaicFormPos)

    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        ShowStatus("Saving File", lblStatus, True, MyBase.Name)
        Dim _path As String = My.Settings.MosaicImagePath
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _fileName As String = GetUniqueFname(cboMonth.SelectedItem & "_twitter_mosaic.jpg", _path)
        ImageUtil.SaveImageFromPictureBox(PictureBox1, MOSAIC_WIDTH * 60, MOSAIC_HEIGHT * 60, _fileName)
        ShowStatus("File saved : " & _fileName, lblStatus, True, MyBase.Name)
    End Sub
    Private Sub GenerateImage(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer, _height As Integer)
        ShowStatus("Generating Image", lblStatus, True, MyBase.Name)
        Dim _mosaic As Image = New Bitmap(My.Resources.blank, 60 * _width, 60 * _height)
        Dim oGraphics As Graphics = Graphics.FromImage(_mosaic)
        oGraphics.DrawImage(My.Resources.id, New Point(_mosaic.Width - 60, _mosaic.Height - 60))
        Dim _imgHPos As Integer = -1
        Dim _imgVPos As Integer = 0
        Dim _skip As Integer = nudSkip.Value * _width
        For Each _person As Person In _imageTable
            If _skip = 0 Then
                If _person.Image IsNot Nothing AndAlso _person.Image.Photo IsNot Nothing Then
                    Dim _image As Image = _person.Image.Photo
                    _imgHPos += 1
                    If _imgHPos = _width Then
                        _imgVPos += 1
                        _imgHPos = 0
                    End If
                    Dim oBitMap As Bitmap = ImageUtil.ResizeImageToBitmap(_image, 60, 60)
                    oGraphics.DrawImage(oBitMap.Clone, New Point(60 * _imgHPos, 60 * _imgVPos))
                    oBitMap.Dispose()
                End If
            Else
                _skip -= 1
            End If
        Next
        _pictureBox.Image = _mosaic
        ShowStatus("Image complete", lblStatus, True, MyBase.Name)
    End Sub
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        SelectImages(-1)
    End Sub

    Private Sub SelectImages(pSkipValue As Integer)
        ShowStatus("Selecting Images", lblStatus, True, MyBase.Name)
        _imageList = New List(Of Person)
        Dim _PersonTa As New CelebrityBirthdayDataSetTableAdapters.FullPersonTableAdapter
        Dim _PersonTable As New CelebrityBirthdayDataSet.FullPersonDataTable

        If cboMonth.SelectedIndex >= 0 Then
            _PersonTa.FillByMonth(_PersonTable, cboMonth.SelectedIndex + 1)
        Else
            ShowStatus("No month selected", lblStatus, False, True)
        End If
        For Each _personRow As CelebrityBirthdayDataSet.FullPersonRow In _PersonTable
            _imageList.Add(New Person(_personRow))
        Next
        Dim _rowct As Integer = CInt(_imageList.Count / MOSAIC_WIDTH)
        If _rowct > MOSAIC_HEIGHT Then
            If pSkipValue >= 0 Then
                If pSkipValue > _rowct - MOSAIC_HEIGHT Then
                    nudSkip.Value = _rowct - MOSAIC_HEIGHT
                End If
            Else
                Randomize()
                Dim value As Integer = CInt(Int((_rowct - MOSAIC_HEIGHT) * Rnd()))
                nudSkip.Value = value
            End If

        End If
        GenerateImage(PictureBox1, _imageList, MOSAIC_WIDTH, MOSAIC_HEIGHT)
        _PersonTable.Dispose()
        _PersonTa.Dispose()
    End Sub

    Private Sub NudSkip_ValueChanged(sender As Object, e As EventArgs) Handles nudSkip.ValueChanged
        SelectImages(nudSkip.Value)
    End Sub
End Class
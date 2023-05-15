' Hindleware
' Copyright (c) 2020-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Friend Module ImageUtil
    Public Enum ImageType
        JPEG
        GIF
        BMP
        TIFF
        PNG
        ALL
    End Enum
    Public Enum OpenOrSave
        Open
        Save
    End Enum

    Public Enum AlignType
        Right
        Left
        Centre
    End Enum
    Private ReadOnly imageFilter As String() = {"jpeg files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif",
                                             "gif files (*.gif)|*.gif",
                                             "bmp files (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle",
                                             "tiff files (*.tif*.tiff)|*.tif;*.tiff",
                                             "png files (*.png)|*.png",
                                             "all files (*.*)|*.*"}
    Private ReadOnly sImageCacheFolder As String

    Public Function ConvertImageTypeToFormat(ByVal imgType As ImageType) As Imaging.ImageFormat
        Dim iFormat As Imaging.ImageFormat = Imaging.ImageFormat.Jpeg
        Select Case imgType
            Case ImageType.JPEG
                iFormat = Imaging.ImageFormat.Jpeg
            Case ImageType.GIF
                iFormat = Imaging.ImageFormat.Gif
            Case ImageType.BMP
                iFormat = Imaging.ImageFormat.Bmp
            Case ImageType.PNG
                iFormat = Imaging.ImageFormat.Png
            Case ImageType.TIFF
                iFormat = Imaging.ImageFormat.Tiff
        End Select
        Return iFormat
    End Function

    Public Function ResizeImageToBitmap(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Const Psub As String = "ResizeImageToBitmap"
        Dim targetBitmap As New System.Drawing.Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)

        Dim oGraphics As Graphics = InitialiseGraphics(targetBitmap)
        Try
            If sourceImage IsNot Nothing Then
                Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                    oGraphics.DrawImage(oBitMap, targetRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel)
                End Using
            End If
        Catch ex As ArgumentException
            LogUtil.Exception("Save image ArgumentException", ex, Psub)
            MsgBox("resizeImageToBitmap:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
        Return targetBitmap
    End Function
    Public Function ExtractCroppedAreaFromImage(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Const Psub As String = "ExtractCroppedAreaFromImage"
        Dim targetBitmap As New Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)

        Dim oGraphics As Graphics = InitialiseGraphics(targetBitmap)
        Try
            If sourceImage IsNot Nothing Then
                Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                    oGraphics.DrawImage(oBitMap, 0, 0, targetRectangle, GraphicsUnit.Pixel)
                End Using
            End If
        Catch ex As ArgumentNullException
            LogUtil.Exception("Save image ArgumentNullException", ex, Psub)
            MsgBox("extractCroppedAreaFromImage:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

        Return targetBitmap
    End Function
    Public Function InitialiseGraphics(ByVal oImage As Image) As Graphics
        Dim oGraphics As Graphics = Graphics.FromImage(oImage)
        oGraphics.SmoothingMode = SmoothingMode.HighQuality
        oGraphics.CompositingQuality = CompositingQuality.HighQuality
        oGraphics.InterpolationMode = InterpolationMode.High
        oGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        Return oGraphics
    End Function
    Private Function GetCodecInfo(ByVal imgType As ImageType) As System.Drawing.Imaging.ImageCodecInfo
        Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim thisICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
        For x As Integer = 0 To arrayICI.Length - 1
            If arrayICI(x).FormatDescription = imgType.ToString Then
                thisICI = arrayICI(x)
                Exit For
            End If
        Next
        Return thisICI
    End Function
    Private Function GetEncoderParameters() As System.Drawing.Imaging.EncoderParameters
        Dim oEncoder As System.Drawing.Imaging.Encoder
        Dim oEncoderParameter As System.Drawing.Imaging.EncoderParameter
        Dim oEncoderParameters As System.Drawing.Imaging.EncoderParameters
        oEncoder = System.Drawing.Imaging.Encoder.Quality
        oEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        oEncoderParameter = New System.Drawing.Imaging.EncoderParameter(oEncoder, 100L)
        oEncoderParameters.Param(0) = oEncoderParameter
        Return oEncoderParameters
    End Function

    Public Function GenerateImage(imageTable As List(Of Person), widthImageCount As Integer, pHeight As Integer, pAlignType As AlignType, _tweetType As BirthdayTweets.TweetType) As Image
        Const Psub As String = "GenerateImage"
        Dim mosaic As Image = New Bitmap(My.Resources.blank, Math.Max(60 * widthImageCount, 300), Math.Max((60 * pHeight) + 18, 80))
        Dim oGraphics As Graphics = Graphics.FromImage(mosaic)
        Dim _idImage As Bitmap = If(_tweetType = BirthdayTweets.TweetType.ForNow, My.Resources.idtb, My.Resources.id)
        oGraphics.DrawImage(_idImage, New Point(mosaic.Width - 125, mosaic.Height - 18))
        If imageTable IsNot Nothing Then
            Dim lastWidth As Integer = imageTable.Count Mod widthImageCount
            Dim _imgHPos As Integer = -1
            Dim _imgVPos As Integer = 0
            For Each _person As Person In imageTable
                Dim rowStartPos As Integer = 0
                Dim rowImageWidth As Integer = widthImageCount
                Dim _image As Image = _person.Image.Photo
                If _image Is Nothing Then
                    LogUtil.ShowProgress("Image missing", Psub)
                End If
                _imgHPos += 1
                If _imgHPos = widthImageCount Then
                    _imgVPos += 1
                    _imgHPos = 0
                End If
                If _imgVPos = pHeight - 1 Then
                    If lastWidth > 0 Then
                        rowImageWidth = lastWidth
                    End If
                End If
                Select Case pAlignType
                    Case AlignType.Right
                        rowStartPos = mosaic.Width - (rowImageWidth * 60)
                    Case AlignType.Left
                        rowStartPos = 0
                    Case AlignType.Centre
                        rowStartPos = (mosaic.Width - (rowImageWidth * 60)) / 2
                End Select

                Dim oBitMap As Bitmap = ImageUtil.ResizeImageToBitmap(_image, 60, 60)
                oGraphics.DrawImage(oBitMap.Clone, New Point((60 * _imgHPos) + rowStartPos, 60 * _imgVPos))
                oBitMap.Dispose()
            Next
        End If
        Dim _imageClone As Image = mosaic.Clone
        mosaic.Dispose()
        Return _imageClone
    End Function
    Public Function SaveImage(_image As Image, ByVal targetFile As String) As Boolean
        Const Psub As String = "SaveImage"
        Dim isSavedOk As Boolean = True
        Dim targetBitmap As New Bitmap(_image)
        Try
            Dim _encoderParameters As EncoderParameters = GetEncoderParameters()
            targetBitmap.Save(targetFile, GetCodecInfo(ImageType.JPEG), _encoderParameters)
            _encoderParameters.Dispose()
        Catch ex As ArgumentException
            isSavedOk = False
            LogUtil.Exception("Save image ArgumentException", ex, Psub)
        Catch ex As Runtime.InteropServices.ExternalException
            isSavedOk = False
            LogUtil.Exception("Save image ExternalException", ex, Psub)
        End Try
        Return isSavedOk
    End Function

End Module

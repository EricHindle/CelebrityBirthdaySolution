Imports System.IO
Imports System.Drawing.Drawing2D

Public Class ImageUtil
    Public Enum ImageType
        JPEG
        GIF
        BMP
        TIFF
        PNG
    End Enum
    Public Enum OpenOrSave
        Open
        Save
    End Enum
    Public Shared imageFilter As String() = {"jpeg files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif", _
                                             "gif files (*.gif)|*.gif", _
                                             "bmp files (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle", _
                                             "tiff files (*.tif*.tiff)|*.tif;*.tiff", _
                                             "png files (*.png)|*.png"}

    Public Shared Function convertImageTypeToFormat(ByVal imgType As ImageType) As Imaging.ImageFormat
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
    Public Shared Function saveImageFromPictureBox(ByVal oPicture As PictureBox, ByVal sourceWidth As Integer, ByVal sourceHeight As Integer, ByVal targetFile As String, Optional ByVal imgType As ImageType = ImageType.JPEG) As String
        Dim targetBitmap As System.Drawing.Bitmap = resizeImageToBitmap(oPicture.Image, oPicture.Width, oPicture.Height)

        If Not String.IsNullOrEmpty(targetFile) Then
            Try
                targetBitmap.Save(targetFile, getCodecInfo(imgType), getEncoderParameters)
            Catch ex As Exception
                MsgBox(targetFile & ":" & ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        targetBitmap.Dispose()
        Return targetFile
    End Function
    Public Shared Function resizeImageToBitmap(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)
        Dim oBitMap As Bitmap = New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
        Dim oGraphics As Graphics = initialiseGraphics(targetBitmap)
        Try
            oGraphics.DrawImage(oBitMap, targetRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel)
        Catch ex As Exception
            MsgBox("resizeImageToBitmap:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

        Return targetBitmap
    End Function
    Public Shared Function extractCroppedAreaFromImage(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)
        Dim oBitMap As Bitmap = New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
        Dim oGraphics As Graphics = initialiseGraphics(targetBitmap)
        Try
            oGraphics.DrawImage(oBitMap, 0, 0, targetRectangle, GraphicsUnit.Pixel)
        Catch ex As Exception
            MsgBox("extractCroppedAreaFromImage:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

        Return targetBitmap
    End Function
    Private Shared Function initialiseGraphics(ByVal oImage As Image) As Graphics
        Dim oGraphics As Graphics = Graphics.FromImage(oImage)
        oGraphics.SmoothingMode = SmoothingMode.HighQuality
        oGraphics.CompositingQuality = CompositingQuality.HighQuality
        oGraphics.InterpolationMode = InterpolationMode.High
        oGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        Return oGraphics
    End Function
    Private Shared Function getCodecInfo(ByVal imgType As ImageType) As System.Drawing.Imaging.ImageCodecInfo
        Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim thisICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
        Dim x As Integer = 0
        For x = 0 To arrayICI.Length - 1
            If (arrayICI(x).FormatDescription.Equals(imgType.ToString)) Then
                thisICI = arrayICI(x)
                Exit For
            End If
        Next
        Return thisICI
    End Function
    Private Shared Function getEncoderParameters() As System.Drawing.Imaging.EncoderParameters
        Dim oEncoder As System.Drawing.Imaging.Encoder
        Dim oEncoderParameter As System.Drawing.Imaging.EncoderParameter
        Dim oEncoderParameters As System.Drawing.Imaging.EncoderParameters
        oEncoder = System.Drawing.Imaging.Encoder.Quality
        oEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        oEncoderParameter = New System.Drawing.Imaging.EncoderParameter(oEncoder, 60L)
        oEncoderParameters.Param(0) = oEncoderParameter
        Return oEncoderParameters
    End Function
    Public Shared Sub GenerateImage(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer, _height As Integer)
        Dim _mosaic As Image = New Bitmap(My.Resources.blank, 60 * _width, 60 * _height)
        Dim oGraphics As Graphics = Graphics.FromImage(_mosaic)
        oGraphics.DrawImage(My.Resources.id, New Point(_mosaic.Width - 60, _mosaic.Height - 60))
        Dim _imgHPos As Integer = -1
        Dim _imgVPos As Integer = 0
        For Each _person As Person In _imageTable
            Dim _image As Image = _person.Image.Photo
            _imgHPos += 1
            If _imgHPos = _width Then
                _imgVPos += 1
                _imgHPos = 0
            End If
            Dim oBitMap As Bitmap = ImageUtil.resizeImageToBitmap(_image, 60, 60)
            oGraphics.DrawImage(oBitMap, New Point(60 * _imgHPos, 60 * _imgVPos))
        Next
        _pictureBox.Image = _mosaic

    End Sub
End Class

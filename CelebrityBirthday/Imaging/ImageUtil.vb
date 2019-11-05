Imports System.IO
Imports System.Drawing.Drawing2D

Public Class ImageUtil
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
    Public Shared imageFilter As String() = {"jpeg files (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif",
                                             "gif files (*.gif)|*.gif",
                                             "bmp files (*.bmp;*.dib;*.rle)|*.bmp;*.dib;*.rle",
                                             "tiff files (*.tif*.tiff)|*.tif;*.tiff",
                                             "png files (*.png)|*.png",
                                             "all files (*.*)|*.*"}
    Private Shared sImageCacheFolder As String

    Public Shared Function ConvertImageTypeToFormat(ByVal imgType As ImageType) As Imaging.ImageFormat
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
    Public Shared Function SaveImageFromPictureBox(ByVal oPicture As PictureBox, ByVal targetWidth As Integer, ByVal targetHeight As Integer, ByVal targetFile As String, Optional ByVal imgType As ImageType = ImageType.JPEG) As String
        Dim targetBitmap As System.Drawing.Bitmap
        If oPicture.Image.Width = targetWidth And oPicture.Image.Height = targetHeight Then
            targetBitmap = New Bitmap(oPicture.Image)
        Else
            targetBitmap = ResizeImageToBitmap(oPicture.Image, targetWidth, targetHeight)
        End If
        If Not String.IsNullOrEmpty(targetFile) Then
            Try
                targetBitmap.Save(targetFile, GetCodecInfo(imgType), GetEncoderParameters)
            Catch ex As Exception
                MsgBox(targetFile & " : " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        targetBitmap.Dispose()
        Return targetFile
    End Function
    Public Shared Function GetImageFileName(ByVal pDialogType As OpenOrSave, Optional ByVal pImgType As Integer = 0, Optional ByVal pFolder As String = Nothing, Optional ByVal pFilename As String = Nothing) As String
        Dim sFilename As String = ""

        If pDialogType = OpenOrSave.Open Then
            Using fbd As New OpenFileDialog
                If Not String.IsNullOrEmpty(pFolder) Then
                    fbd.InitialDirectory = pFolder
                End If
                If Not String.IsNullOrEmpty(pFilename) Then
                    fbd.FileName = pFilename
                End If
                sFilename = ShowFileDialog(fbd, pImgType, sImageCacheFolder)
            End Using
        Else
            Using fbd As New SaveFileDialog
                If Not String.IsNullOrEmpty(pFolder) Then
                    fbd.InitialDirectory = pFolder
                End If
                If Not String.IsNullOrEmpty(pFilename) Then
                    fbd.FileName = pFilename
                End If
                sFilename = ShowFileDialog(fbd, pImgType, sImageCacheFolder)
            End Using
        End If
        Return sFilename
    End Function

    Public Shared Function ShowFileDialog(ByVal fbd As FileDialog, Optional ByVal imgType As Integer = 0, Optional ByVal initialDirectory As String = Nothing) As String
        Dim sFilename As String = ""
        fbd.Filter = imageFilter(imgType)
        fbd.FilterIndex = 0
        fbd.RestoreDirectory = False
        fbd.CheckFileExists = False
        If String.IsNullOrEmpty(initialDirectory) Then
            '          fbd.InitialDirectory = sSharedFolder
        Else
            fbd.InitialDirectory = initialDirectory
        End If

        If fbd.ShowDialog() = DialogResult.OK Then
            sFilename = fbd.FileName
        End If

        Return sFilename
    End Function

    Public Shared Function ResizeImageToBitmap(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)

        Dim oGraphics As Graphics = initialiseGraphics(targetBitmap)
            Try
            Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                oGraphics.DrawImage(oBitMap, targetRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel)
            End Using
        Catch ex As Exception
                MsgBox("resizeImageToBitmap:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try
        Return targetBitmap
    End Function
    Public Shared Function ExtractCroppedAreaFromImage(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)

        Dim oGraphics As Graphics = initialiseGraphics(targetBitmap)
        Try
            Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                oGraphics.DrawImage(oBitMap, 0, 0, targetRectangle, GraphicsUnit.Pixel)
            End Using
        Catch ex As Exception
            MsgBox("extractCroppedAreaFromImage:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try

        Return targetBitmap
    End Function
    Public Shared Function InitialiseGraphics(ByVal oImage As Image) As Graphics
        Dim oGraphics As Graphics = Graphics.FromImage(oImage)
        oGraphics.SmoothingMode = SmoothingMode.HighQuality
        oGraphics.CompositingQuality = CompositingQuality.HighQuality
        oGraphics.InterpolationMode = InterpolationMode.High
        oGraphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        Return oGraphics
    End Function
    Private Shared Function GetCodecInfo(ByVal imgType As ImageType) As System.Drawing.Imaging.ImageCodecInfo
        Dim arrayICI() As System.Drawing.Imaging.ImageCodecInfo = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
        Dim thisICI As System.Drawing.Imaging.ImageCodecInfo = Nothing
        For x As Integer = 0 To arrayICI.Length - 1
            If (arrayICI(x).FormatDescription.Equals(imgType.ToString)) Then
                thisICI = arrayICI(x)
                Exit For
            End If
        Next
        Return thisICI
    End Function
    Private Shared Function GetEncoderParameters() As System.Drawing.Imaging.EncoderParameters
        Dim oEncoder As System.Drawing.Imaging.Encoder
        Dim oEncoderParameter As System.Drawing.Imaging.EncoderParameter
        Dim oEncoderParameters As System.Drawing.Imaging.EncoderParameters
        oEncoder = System.Drawing.Imaging.Encoder.Quality
        oEncoderParameters = New System.Drawing.Imaging.EncoderParameters(1)
        oEncoderParameter = New System.Drawing.Imaging.EncoderParameter(oEncoder, 100L)
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

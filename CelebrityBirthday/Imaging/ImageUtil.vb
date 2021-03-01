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
    Public Function SaveImageFromPictureBox(ByVal oPicture As PictureBox, ByVal targetWidth As Integer, ByVal targetHeight As Integer, ByVal targetFile As String, Optional ByVal imgType As ImageType = ImageType.JPEG) As String
        Dim targetBitmap As System.Drawing.Bitmap = Nothing
        If oPicture IsNot Nothing Then
            If oPicture.Image.Width = targetWidth And oPicture.Image.Height = targetHeight Then
                targetBitmap = New Bitmap(oPicture.Image)
            Else
                targetBitmap = ResizeImageToBitmap(oPicture.Image, targetWidth, targetHeight)
            End If
        End If

        If targetFile IsNot Nothing Then
            Try
                Dim _encoderParameters As EncoderParameters = GetEncoderParameters()
                targetBitmap.Save(targetFile, GetCodecInfo(imgType), _encoderParameters)
                _encoderParameters.Dispose()
            Catch ex As ArgumentException
                LogUtil.Exception("Save image error", ex, "SaveImageFromPictureBox")
                MsgBox(targetFile & " : " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            Catch ex As Runtime.InteropServices.ExternalException
                LogUtil.Exception("Save image error", ex, "SaveImageFromPictureBox")
                MsgBox(targetFile & " : " & ex.Message, MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
        targetBitmap.Dispose()
        Return targetFile
    End Function
    Public Function GetImageFileName(ByVal pDialogType As OpenOrSave, Optional ByVal pImgType As Integer = 0, Optional ByVal pFolder As String = Nothing, Optional ByVal pFilename As String = Nothing) As String
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
    Public Function ShowFileDialog(ByVal fbd As FileDialog, Optional ByVal imgType As Integer = 0, Optional ByVal initialDirectory As String = Nothing) As String
        Dim sFilename As String = ""
        If fbd IsNot Nothing Then
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
        End If
        Return sFilename
    End Function
    Public Function ResizeImageToBitmap(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New System.Drawing.Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)

        Dim oGraphics As Graphics = InitialiseGraphics(targetBitmap)
        Try
            If sourceImage IsNot Nothing Then
                Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                    oGraphics.DrawImage(oBitMap, targetRectangle, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel)
                End Using
            End If
        Catch ex As ArgumentException
            LogUtil.Exception("Save image error", ex, "ResizeImageToBitmap")
            MsgBox("resizeImageToBitmap:" & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
        Return targetBitmap
    End Function
    Public Function ExtractCroppedAreaFromImage(ByVal sourceImage As System.Drawing.Image, ByVal targetWidth As Integer, targetHeight As Integer, Optional ByVal sourceOriginX As Integer = 0, Optional ByVal sourceOriginY As Integer = 0) As Bitmap
        Dim targetBitmap As System.Drawing.Bitmap = New Bitmap(targetWidth, targetHeight)
        Dim targetRectangle As New Rectangle(sourceOriginX, sourceOriginY, targetWidth, targetHeight)

        Dim oGraphics As Graphics = InitialiseGraphics(targetBitmap)
        Try
            If sourceImage IsNot Nothing Then
                Using oBitMap As New Bitmap(sourceImage, sourceImage.Width, sourceImage.Height)
                    oGraphics.DrawImage(oBitMap, 0, 0, targetRectangle, GraphicsUnit.Pixel)
                End Using
            End If
        Catch ex As ArgumentNullException
            LogUtil.Exception("Save image error", ex, "ExtractCroppedAreaFromImage")
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

    Public Sub GenerateImage(oPictureBox As PictureBox, imageTable As List(Of Person), widthImageCount As Integer, pHeight As Integer, pAlignType As AlignType)
        Dim mosaic As Image = New Bitmap(My.Resources.blank, Math.Max(60 * widthImageCount, 300), Math.Max((60 * pHeight) + 18, 80))
        Dim oGraphics As Graphics = Graphics.FromImage(mosaic)
        oGraphics.DrawImage(My.Resources.id, New Point(mosaic.Width - 125, mosaic.Height - 18))
        If imageTable IsNot Nothing Then
            Dim lastWidth As Integer = imageTable.Count Mod widthImageCount
            Dim _imgHPos As Integer = -1
            Dim _imgVPos As Integer = 0
            For Each _person As Person In imageTable
                Dim rowStartPos As Integer = 0
                Dim rowImageWidth As Integer = widthImageCount
                Dim _image As Image = _person.Image.Photo
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
        If oPictureBox IsNot Nothing Then oPictureBox.Image = mosaic.Clone
        mosaic.Dispose()
    End Sub

End Module

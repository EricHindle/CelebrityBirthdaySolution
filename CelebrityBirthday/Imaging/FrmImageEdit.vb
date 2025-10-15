' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports HindlewareLib
Public NotInheritable Class FrmImageEdit
#Region "Constants"

    Private Const SAVED_MESSAGE As String = "Image saved to "
    Private Const NOT_SAVED_MESSAGE As String = "Image not saved"
    Private Const STD_CAP_WIDTH As Integer = 500
    Private Const STD_CAP_HEIGHT As Integer = 400
    Private Const MAX_IMG_WIDTH As Integer = 1450
    Private Const MAX_IMG_HEIGHT As Integer = 850
    Private Const IMG_AREA_SEL As String = "Image area selected"
    Private Const IMG_SHRUNK As String = "Image shrunk to "

#End Region
#Region "Variables"
    Private cropX As Integer
    Private cropY As Integer
    Private cropWidth As Integer
    Private cropHeight As Integer
    Private cropBitmap As Bitmap
    Private cropPen As Pen
    Private cropPenSize As Integer = 1
    Private cropPenColor As Color = Color.Yellow
    Private iStartWidth As Integer
    Private iStartHeight As Integer
    Private imageShrinkRatio As Decimal = 1
    Private originalImage As Image
    Private oImageUtil As New Imaging.ImageUtil
#End Region
#Region "properties"
    Private _imageFile As String
    Private _forename As String
    Private _surname As String
    Private _savedImage As String
    Public Property SavedImage() As String
        Get
            Return _savedImage
        End Get
        Set(ByVal value As String)
            _savedImage = value
        End Set
    End Property
    Public Property Surname() As String
        Get
            Return _surname
        End Get
        Set(ByVal value As String)
            _surname = value
        End Set
    End Property
    Public Property Forename() As String
        Get
            Return _forename
        End Get
        Set(ByVal value As String)
            _forename = value
        End Set
    End Property
    Public Property ImageFile() As String
        Get
            Return _imageFile
        End Get
        Set(ByVal value As String)
            _imageFile = value
        End Set
    End Property
#End Region
#Region "Form control handlers"
    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        iStartHeight = Size.Height
        iStartWidth = Size.Width
        cropBitmap = Nothing
        lblFilename.Text = _imageFile
        TxtForename.Text = _forename
        TxtSurname.Text = _surname
        If Not String.IsNullOrEmpty(_forename & _surname) Then
            LogUtil.Info("Preset name: " & Trim(_forename & " " & _surname), MyBase.Name)
        End If
        Try
            Dim sizeMessage As String = ""
            imageShrinkRatio = 1
            If Not String.IsNullOrEmpty(_imageFile) Then
                LogUtil.Info("Preset image: " & _imageFile, MyBase.Name)
                Dim oImage As Image = Image.FromFile(_imageFile)
                originalImage = oImage.Clone
                If oImage IsNot Nothing Then
                    DisplayRawImage(oImage)
                End If
                oImage.Dispose()
            End If
        Catch ex As OutOfMemoryException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Out of Memory")
            GC.Collect()
        Catch ex As FileNotFoundException
            DisplayException(MethodBase.GetCurrentMethod, ex, "File Not Found")
        Catch ex As ArgumentException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Argument")
        End Try
    End Sub
    Private Sub ResetWindow()
        PicCapture.Width = STD_CAP_WIDTH
        PicCapture.Height = STD_CAP_HEIGHT
        Width = iStartWidth
        Height = iStartHeight
    End Sub
    ''' <summary>
    ''' Load an image from a file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' Get an image file name and read the image in
    ''' Save the original image so that cropping can be performed on the original
    ''' Shrink the image if necessary so that it can be displayed
    ''' Clear the crop selection
    ''' Display the image</remarks>
    Private Sub BtnLoadImage_Click(sender As Object, e As EventArgs) Handles BtnLoadImage.Click
        Try
            Dim oImageFilename As String = HindlewareLib.Imaging.ImageUtil.GetImageFileName(HindlewareLib.Imaging.ImageUtil.OpenOrSave.Open, HindlewareLib.Imaging.ImageUtil.ImageType.ALL)
            lblFilename.Text = Path.GetFileName(oImageFilename)
            Dim sizeMessage As String = ""
            imageShrinkRatio = 1
            If Not String.IsNullOrEmpty(oImageFilename) Then
                LogUtil.Info("Loading image", MyBase.Name)
                Dim oImage As Image = Image.FromFile(oImageFilename)
                originalImage = oImage.Clone
                If oImage IsNot Nothing Then
                    DisplayRawImage(oImage)
                End If
                oImage.Dispose()
            End If
        Catch ex As OutOfMemoryException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Out of Memory")
            GC.Collect()
        Catch ex As FileNotFoundException
            DisplayException(MethodBase.GetCurrentMethod, ex, "File Not Found")
        Catch ex As ArgumentException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Argument")
        End Try
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    ''' <summary>
    ''' Reset the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ShowStatus("Clearing image", lblStatus, True, MyBase.Name)
        ResetWindow()
        If PicCapture.Image IsNot Nothing Then
            PicCapture.Image.Dispose()
            PicCapture.Image = Nothing
        End If
        ClearCropSelection()
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not String.IsNullOrWhiteSpace(TxtForename.Text) Or Not String.IsNullOrWhiteSpace(TxtSurname.Text) Then
            ShowStatus("Saving picture", lblStatus, True, MyBase.Name)
            SaveImagePlain(PicCapture, PicCapture.Width, PicCapture.Height, False)
        Else
            ShowStatus("No name supplied", lblStatus, False, True)
        End If
    End Sub
    Private Sub BtnSaveCroppedImage_Click(sender As Object, e As EventArgs) Handles BtnSaveCroppedImage.Click
        If Not String.IsNullOrWhiteSpace(TxtForename.Text) Or Not String.IsNullOrWhiteSpace(TxtSurname.Text) Then
            ShowStatus("Saving cropped image", lblStatus, True, MyBase.Name)
            _savedImage = SaveImagePlain(PreviewPictureBox, NudSaveSize.Value, NudSaveSize.Value, True)
        Else
            ShowStatus("No name supplied", lblStatus, False, True)
        End If
    End Sub
    Private Sub BtnRotate_Click(sender As Object, e As EventArgs) Handles BtnRotate.Click
        If originalImage IsNot Nothing Then
            originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            DisplayRawImage(originalImage.Clone)
        End If
    End Sub
    ''' <summary>
    ''' Reset the contrast and brightness to their default values
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BtnResetAdjustments_Click(sender As Object, e As EventArgs) Handles BtnResetAdjustments.Click
        TbBrightness.Value = 20
        TbContrast.Value = 10
        AdjustImage()
    End Sub
    Private Sub RbRed_CheckedChanged(sender As Object, e As EventArgs) Handles rbRed.CheckedChanged
        cropPenColor = Color.Red
        cropPen = New Pen(cropPenColor, cropPenSize) With {
            .DashStyle = DashStyle.DashDot
        }
    End Sub
    Private Sub RbBlack_CheckedChanged(sender As Object, e As EventArgs) Handles rbBlack.CheckedChanged
        cropPenColor = Color.Black
        cropPen = New Pen(cropPenColor, cropPenSize) With {
            .DashStyle = DashStyle.DashDot
        }
    End Sub
    Private Sub RbWhite_CheckedChanged(sender As Object, e As EventArgs) Handles rbWhite.CheckedChanged
        cropPenColor = Color.White
        cropPen = New Pen(cropPenColor, cropPenSize) With {
            .DashStyle = DashStyle.DashDot
        }
    End Sub
    Private Sub RbYellow_CheckedChanged(sender As Object, e As EventArgs) Handles rbYellow.CheckedChanged
        cropPenColor = Color.Yellow
        cropPen = New Pen(cropPenColor, cropPenSize) With {
            .DashStyle = DashStyle.DashDot
        }
    End Sub
    Private Sub FrmImageCapture_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

#End Region
#Region "Subroutines"
    Private Function SaveImagePlain(ByRef _pictureBox As PictureBox, _width As Integer, _height As Integer, Optional isCropped As Boolean = True) As String
        Dim imageFile As String = Nothing
        Try
            Dim _path As String = If(isCropped, My.Settings.ImgPath, My.Settings.NewImagePath)
            Dim _filename As String = MakeImageName(TxtForename.Text, TxtSurname.Text)
            Dim imageFileName As String = HindlewareLib.Imaging.ImageUtil.GetImageFileName(HindlewareLib.Imaging.ImageUtil.OpenOrSave.Save, HindlewareLib.Imaging.ImageUtil.ImageType.JPEG, _path, _filename)
            If Not String.IsNullOrEmpty(imageFileName) Then
                ShowStatus("Saving image from picture box", lblStatus, True, MyBase.Name)
                oImageUtil.SaveImageFromPictureBox(_pictureBox, _width, _height, imageFileName, HindlewareLib.Imaging.ImageUtil.ImageType.JPEG)
                imageFile = imageFileName
                ShowStatus(SAVED_MESSAGE & imageFileName, lblStatus, True, MyBase.Name)
            Else
                ShowStatus(NOT_SAVED_MESSAGE, lblStatus, True, MyBase.Name)
            End If
        Catch ex As ArgumentException
            ShowStatus(NOT_SAVED_MESSAGE, lblStatus, True, MyBase.Name, ex)
        End Try
        Return imageFile
    End Function
    Private Sub DisplayRawImage(ByRef oImage As Image)
        LogUtil.Info("Loading raw image", MyBase.Name)
        Dim sizeMessage As String = ""
        If oImage.Size.Height > MAX_IMG_HEIGHT Or oImage.Size.Width > MAX_IMG_WIDTH Then
            oImage = ShrinkImage(oImage)
            sizeMessage = IMG_SHRUNK
        End If
        sizeMessage += oImage.Size.Width & " x " & oImage.Size.Height
        If oImage.Size.Height > STD_CAP_HEIGHT Or oImage.Size.Width > STD_CAP_WIDTH Then
            Dim _newLocation As New Point(10, 10)
            Location = _newLocation
            Dim newHeight As Integer = iStartHeight + oImage.Size.Height - STD_CAP_HEIGHT
            Dim newWidth As Integer = iStartWidth + oImage.Size.Width - STD_CAP_WIDTH
            Height = Math.Min(MaximumSize.Height, newHeight)
            Width = Math.Min(MaximumSize.Width, newWidth)
        End If
        PicCapture.Image = oImage.Clone
        ClearCropSelection()
        If PicCapture.Image IsNot Nothing Then
            DisplayAndLog("Image file loaded, " & sizeMessage)
        End If
    End Sub
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, lblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, lblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
#End Region
#Region "Image Cropping"
    Private Sub PicCapture_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCapture.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ClearCropSelection()
            cropX = e.X
            cropY = e.Y
            Cursor = Cursors.Cross
        End If
        PicCapture.Refresh()
    End Sub
    Private Sub PicCapture_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCapture.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                PicCapture.Refresh()
                cropWidth = e.X - cropX
                cropHeight = cropWidth  ' square selection
                PicCapture.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
            End If
        Catch exc As ArgumentNullException
            ShowStatus("MouseMove exception", lblStatus,, MyBase.Name, exc)
        End Try
    End Sub
    Private Sub PicCapture_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PicCapture.MouseUp
        Try
            Cursor = Cursors.Default
            CaptureCroppedArea()
            ShowProgress(IMG_AREA_SEL, lblStatus, False)
        Catch exc As ArgumentException
            ShowStatus("MouseUp exception", lblStatus,, MyBase.Name, exc)
        End Try
    End Sub
    Private Sub ClearCropSelection()
        cropWidth = 0
        cropHeight = 0
        cropBitmap = Nothing
        cropPen = New Pen(cropPenColor, cropPenSize) With {
            .DashStyle = DashStyle.DashDot
        }
        PreviewPictureBox.Image = My.Resources.NoImage
        pnlAdjustImage.Enabled = False
    End Sub
    Private Sub CaptureCroppedArea()
        Try
            ' Extract cropped area from original picture into cropBitmap
            cropBitmap = oImageUtil.ExtractCroppedAreaFromImage(originalImage, cropWidth * imageShrinkRatio, cropHeight * imageShrinkRatio, cropX * imageShrinkRatio, cropY * imageShrinkRatio)
            ' Resize cropBitmap to fit preview picture box
            PreviewPictureBox.Image = HindlewareLib.Imaging.ImageUtil.ResizeImageToBitmap(cropBitmap, PreviewPictureBox.Width, PreviewPictureBox.Height)
            pnlAdjustImage.Enabled = True
        Catch exc As ArgumentException
            ShowStatus("CaptureCroppedArea exception", lblStatus,, MyBase.Name, exc)
        End Try
    End Sub
    Private Function ShrinkImage(ByVal sourceImage As Image) As Bitmap
        LogUtil.Info("Shrinking image", MyBase.Name)
        Dim _newBitmap As New Bitmap(10, 10)
        Try
            Dim hratio As Decimal = sourceImage.Height / MAX_IMG_HEIGHT
            Dim wratio As Decimal = sourceImage.Width / MAX_IMG_WIDTH
            Dim targetHeight As Integer
            Dim targetWidth As Integer
            If hratio > wratio Then
                targetWidth = Int(sourceImage.Width / hratio)
                targetHeight = Int(sourceImage.Height / hratio)
                imageShrinkRatio = hratio
            Else
                targetWidth = Int(sourceImage.Width / wratio)
                targetHeight = Int(sourceImage.Height / wratio)
                imageShrinkRatio = wratio
            End If
            LogUtil.Info("Shrinking ratio = " & imageShrinkRatio, MyBase.Name)
            _newBitmap = HindlewareLib.Imaging.ImageUtil.ResizeImageToBitmap(sourceImage, targetWidth, targetHeight)
        Catch exc As ArithmeticException
            ShowStatus("ShrinkImage exception", lblStatus,, MyBase.Name, exc,, True)
        End Try
        Return _newBitmap
    End Function
#End Region
#Region "Picture adjustment"
    ''' <summary>
    ''' Adjust the contrast of the cropped image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbContrast_Scroll(sender As Object, e As EventArgs) Handles TbContrast.Scroll
        AdjustImage()
    End Sub
    ''' <summary>
    ''' Adjust the brightness of the cropped image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TbBrightness_Scroll(sender As Object, e As EventArgs) Handles TbBrightness.Scroll
        AdjustImage()
    End Sub
    ''' <summary>
    ''' Gets a 5 x 5 matrix that contains the coordinates for the RGBAW space, based on the trackbar settings.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetColourMatrix() As Single()()
        Dim oContrastSetting As Single = TbContrast.Value / 10
        Dim oBrightnessSetting As Single = (TbBrightness.Value / 20) - 1
        Return {
                         New Single() {oContrastSetting, 0, 0, 0, 0},
                         New Single() {0, oContrastSetting, 0, 0, 0},
                         New Single() {0, 0, oContrastSetting, 0, 0},
                         New Single() {0, 0, 0, 1, 0},
                         New Single() {oBrightnessSetting, oBrightnessSetting, oBrightnessSetting, 0, 1}}
    End Function
    ''' <summary>
    ''' Adjust the contrast and brightness of the cropped image
    ''' </summary>
    ''' <remarks>
    ''' Create a bitmap from the cropped image
    ''' Redraw the bitmap with the new  contrast and brightness settings into a target bitmap
    ''' Store the target bitmap in the image on screen
    ''' </remarks>
    Private Sub AdjustImage()
        If PreviewPictureBox.Image IsNot Nothing Then
            Dim oPoints() As Point = {
            New Point(0, 0),
            New Point(PreviewPictureBox.Image.Width, 0),
            New Point(0, PreviewPictureBox.Image.Height)
            }
            Dim oRectangle As New Rectangle(0, 0, PreviewPictureBox.Image.Width, PreviewPictureBox.Image.Height)
            Dim oImageAttributes As New ImageAttributes
            Dim oColourMatrix As New ColorMatrix(GetColourMatrix)
            oImageAttributes.SetColorMatrix(oColourMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)
            Dim oSourceBitMap As Bitmap = HindlewareLib.Imaging.ImageUtil.ResizeImageToBitmap(cropBitmap, PreviewPictureBox.Width, PreviewPictureBox.Height)
            Dim oTargetBitmap As New Bitmap(PreviewPictureBox.Image.Width, PreviewPictureBox.Image.Height)
            Dim oGraphics As Graphics = HindlewareLib.Imaging.ImageUtil.InitialiseGraphics(oTargetBitmap)
            oGraphics.DrawImage(oSourceBitMap, oPoints, oRectangle, GraphicsUnit.Pixel, oImageAttributes)
            PreviewPictureBox.Image = oTargetBitmap
            oImageAttributes.Dispose()
            oSourceBitMap.Dispose()
        End If
    End Sub
    Private Sub NudPenSize_ValueChanged(sender As Object, e As EventArgs) Handles nudPenSize.ValueChanged
        cropPenSize = nudPenSize.Value
        cropPen = New Pen(cropPenColor, cropPenSize) With {
           .DashStyle = DashStyle.DashDot
       }
    End Sub
    Private Sub NudSaveSize_ValueChanged(sender As Object, e As EventArgs) Handles NudSaveSize.ValueChanged
        ResizeCroppedImage()
    End Sub
    Private Sub ResizeCroppedImage()
        Try
            PreviewPictureBox.Size = New Size(NudSaveSize.Value, NudSaveSize.Value)
            PreviewPictureBox.Location = New Point(lblCroppedImage.Location.X + ((lblCroppedImage.Size.Width - PreviewPictureBox.Size.Width) / 2), PreviewPictureBox.Location.Y)
            If cropWidth > 0 And cropHeight > 0 Then
                CaptureCroppedArea()
            End If
        Catch ex As ArgumentException
            ShowStatus("Error resizing cropped image", lblStatus,, MyBase.Name, ex)
        End Try

    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing Then
                If originalImage IsNot Nothing Then originalImage.Dispose()
                If cropBitmap IsNot Nothing Then cropBitmap.Dispose()
                If cropPen IsNot Nothing Then cropPen.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub BtnResize_Click(sender As Object, e As EventArgs) Handles BtnResize.Click
        PreviewPictureBox.Width = NudSaveSize.Value
        PreviewPictureBox.Height = NudSaveSize.Value
    End Sub

#End Region
End Class
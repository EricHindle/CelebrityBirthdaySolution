'
' Copyright (c) 2015, William Hill plc
' St. John’s Centre, 31 Merrion Street, Leeds, LS2 8LQ
' All rights reserved.
'
' Author Eric Hindle
' Created Aug 2015

Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing.Imaging

Public Class frmImageCapture
#Region "user32 functions"
    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WM_CAP_GET_STATUS As Integer = WM_CAP + 54
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0 ' Current device ID
    Dim hHwnd As Integer ' Handle to preview window

    Private Class NativeMethods
        Declare Function GetTickCount Lib "kernel32" () As Long
        Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

        Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
            ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
            ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

        Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

        Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
            (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
            ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
            ByVal nHeight As Short, ByVal hWndParent As Integer, _
            ByVal nID As Integer) As Integer

        Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
            ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
            ByVal cbVer As Integer) As Boolean
    End Class
#End Region

#Region "Constants"

    Private Const SAVED_MESSAGE As String = "Image saved to "
    Private Const NOT_SAVED_MESSAGE As String = "Image not saved"
    Private Const STD_CAP_WIDTH As Integer = 500
    Private Const STD_CAP_HEIGHT As Integer = 400
    Private Const MAX_IMG_WIDTH As Integer = 1000
    Private Const MAX_IMG_HEIGHT As Integer = 700

#End Region

#Region "Variables"
    Private cropX As Integer
    Private cropY As Integer
    Private cropWidth As Integer
    Private cropHeight As Integer
    Private oCropX As Integer
    Private oCropY As Integer
    Private cropBitmap As Bitmap
    Private cropPen As Pen
    Private cropPenSize As Integer = 1
    Private cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Private cropPenColor As Color = Color.Yellow

    Private tmppoint As Point
    Private iStartWidth As Integer
    Private iStartHeight As Integer

    Private imageShrinkRatio As Decimal = 1
    Private originalImage As Image = Nothing
    Private rotateAngle As Integer = 0
#End Region
#Region "properties"
    Private _imageFile As String
    Public Property ImageFile() As String
        Get
            Return _imageFile
        End Get
        Set(ByVal value As String)
            _imageFile = value
        End Set
    End Property
#End Region

#Region "Form"
    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        iStartHeight = Me.Size.Height
        iStartWidth = Me.Size.Width
        cropBitmap = Nothing
        lblFilename.Text = _imageFile
        Try
            Dim sizeMessage As String = ""
            imageShrinkRatio = 1
            If Not String.IsNullOrEmpty(_imageFile) Then
                Dim oImage As Image = Image.FromFile(_imageFile)
                originalImage = oImage.Clone

                If oImage IsNot Nothing Then
                    displayRawImage(oImage)
                End If
                oImage.Dispose()
            End If
        Catch ex As Exception
            MsgBox("Exception when loading an image" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
            GC.Collect()
        End Try
    End Sub

    Private Sub ResetWindow()
        picCapture.Width = STD_CAP_WIDTH
        picCapture.Height = STD_CAP_HEIGHT
        Me.Width = iStartWidth
        Me.Height = iStartHeight
    End Sub

    Private Sub Form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        disposeImages()
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
    Private Sub btnLoadImage_Click(sender As Object, e As EventArgs) Handles BtnLoadImage.Click
        Try
            Dim oImageFilename As String = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open, ImageUtil.ImageType.ALL)
            lblFilename.Text = Path.GetFileName(oImageFilename)
            Dim sizeMessage As String = ""
            imageShrinkRatio = 1
            If Not String.IsNullOrEmpty(oImageFilename) Then
                Dim oImage As Image = Image.FromFile(oImageFilename)
                originalImage = oImage.Clone

                If oImage IsNot Nothing Then
                    displayRawImage(oImage)
                End If
                oImage.Dispose()
            End If
        Catch ex As Exception
            GC.Collect()
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Reset the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ResetWindow()
        picCapture.Image = Nothing
        clearCropSelection()
        disposeImages()
    End Sub

    Private Sub btnCroppedSave_Click(sender As Object, e As EventArgs)

        saveImagePlain()

    End Sub

    Private Sub BtnSaveCroppedImage_Click(sender As Object, e As EventArgs) Handles BtnSaveCroppedImage.Click

        Dim imageFileName As String = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Save, ImageUtil.ImageType.JPEG)
        Dim w As Integer = nudSaveSize.Value
        Dim h As Integer = nudSaveSize.Value
        ImageUtil.SaveImageFromPictureBox(previewPictureBox, w, h, imageFileName, ImageUtil.ImageType.JPEG)
    End Sub

#End Region

#Region "Subroutines"
    Private Sub saveImagePlain()
        Try
            Dim w As Integer = previewPictureBox.Image.Width
            Dim h As Integer = previewPictureBox.Image.Height
            ImageUtil.SaveImageFromPictureBox(previewPictureBox, w, h, ImageUtil.ImageType.JPEG)

        Catch ex As Exception
            ' LogUtil.Exception("Exception when saving cropped image", ex, FORM_NAME, getErrorCode(SystemModule.IMAGES, ErrorType.FILESYSTEM, FailedAction.ERROR_SAVING_FILE))
        End Try

    End Sub

    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        '       If islogged Then LogUtil.addLog(sText, level, FORM_NAME)
    End Sub



#End Region

#Region "Image Cropping"
    Private Sub picCapture_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCapture.MouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                clearCropSelection()
                cropX = e.X
                cropY = e.Y
                Cursor = Cursors.Cross
            End If
            picCapture.Refresh()
        Catch exc As Exception
            ' LogUtil.Exception("MouseDown exception", exc, FORM_NAME, getErrorCode(SystemModule.IMAGES, ErrorType.APPLICATION, FailedAction.MOUSE_ERROR))
        End Try

    End Sub
    Private Sub picCapture_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCapture.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                picCapture.Refresh()
                cropWidth = e.X - cropX
                cropHeight = cropWidth
                picCapture.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
            End If
        Catch exc As Exception
            ' LogUtil.Exception("MouseMove exception", exc, FORM_NAME, getErrorCode(SystemModule.IMAGES, ErrorType.APPLICATION, FailedAction.MOUSE_ERROR))
            If Err.Number = 5 Then Exit Sub
            End Try

    End Sub
    Private Sub picCapture_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCapture.MouseUp


        Try
                Cursor = Cursors.Default
                captureCroppedArea()
                logStatus("Image area selected")
            Catch exc As Exception
                ' LogUtil.Exception("MouseUp exception", exc, FORM_NAME, getErrorCode(SystemModule.IMAGES, ErrorType.APPLICATION, FailedAction.MOUSE_ERROR))
            End Try


    End Sub
    Private Sub clearCropSelection()
        cropWidth = 0
        cropHeight = 0
        cropBitmap = Nothing
        cropPen = New Pen(cropPenColor, cropPenSize)
        cropPen.DashStyle = DashStyle.DashDot
        '     previewPictureBox.Image = My.Resources.NoImage
        pnlAdjustImage.Enabled = False
    End Sub
    Private Sub captureCroppedArea()
        Try
            ' Extract cropped area from original picture into cropBitmap

            cropBitmap = ImageUtil.extractCroppedAreaFromImage(originalImage, cropWidth * imageShrinkRatio, cropHeight * imageShrinkRatio, cropX * imageShrinkRatio, cropY * imageShrinkRatio)

            ' Resize cropBitmap to fit preview picture box
            previewPictureBox.Image = ImageUtil.resizeImageToBitmap(cropBitmap, previewPictureBox.Width, previewPictureBox.Height)
            pnlAdjustImage.Enabled = True

        Catch exc As Exception
            ' LogUtil.Exception("captureCroppedArea exception", exc, FORM_NAME, getErrorCode(SystemModule.IMAGES, ErrorType.APPLICATION, FailedAction.IMAGE_PROCESSING_ERROR))
        End Try
    End Sub

    Private Function shrinkImage(ByVal sourceImage As Image) As Bitmap

        Dim hratio As Decimal = sourceImage.Height / MAX_IMG_HEIGHT
        Dim wratio As Decimal = sourceImage.Width / MAX_IMG_WIDTH
        Dim targetHeight As Integer = 0
        Dim targetWidth As Integer = 0
        If hratio > wratio Then
            targetWidth = Int(sourceImage.Width / hratio)
            targetHeight = Int(sourceImage.Height / hratio)
            imageShrinkRatio = hratio
        Else
            targetWidth = Int(sourceImage.Width / wratio)
            targetHeight = Int(sourceImage.Height / wratio)
            imageShrinkRatio = wratio
        End If
        Return ImageUtil.resizeImageToBitmap(sourceImage, targetWidth, targetHeight)

    End Function


#End Region
#Region "Picture adjustment"
    ''' <summary>
    ''' Adjust the contrast of the cropped image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbContrast_Scroll(sender As Object, e As EventArgs) Handles tbContrast.Scroll
        adjustImage()
    End Sub

    ''' <summary>
    ''' Adjust the brightness of the cropped image
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tbBrightness_Scroll(sender As Object, e As EventArgs) Handles tbBrightness.Scroll
        adjustImage()
    End Sub

    ''' <summary>
    ''' Gets a 5 x 5 matrix that contains the coordinates for the RGBAW space, based on the trackbar settings.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getColourMatrix() As Single()()
        Dim oContrastSetting As Single = tbContrast.Value / 10
        Dim oBrightnessSetting As Single = (tbBrightness.Value / 20) - 1
        Return { _
                         New Single() {oContrastSetting, 0, 0, 0, 0}, _
                         New Single() {0, oContrastSetting, 0, 0, 0}, _
                         New Single() {0, 0, oContrastSetting, 0, 0}, _
                         New Single() {0, 0, 0, 1, 0}, _
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
    Private Sub adjustImage()
        Dim oPoints() As Point = { _
            New Point(0, 0), _
            New Point(previewPictureBox.Image.Width, 0), _
            New Point(0, previewPictureBox.Image.Height) _
        }
        Dim oRectangle As New Rectangle(0, 0, previewPictureBox.Image.Width, previewPictureBox.Image.Height)
        Dim oImageAttributes As New ImageAttributes
        Dim oColourMatrix As New ColorMatrix(getColourMatrix)
        oImageAttributes.SetColorMatrix(oColourMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap)
        Dim oSourceBitMap As Bitmap = ImageUtil.resizeImageToBitmap(cropBitmap, previewPictureBox.Width, previewPictureBox.Height)
        Dim oTargetBitmap As System.Drawing.Bitmap = New Bitmap(previewPictureBox.Image.Width, previewPictureBox.Image.Height)
        Dim oGraphics As Graphics = ImageUtil.initialiseGraphics(oTargetBitmap)
        oGraphics.DrawImage(oSourceBitMap, oPoints, oRectangle, GraphicsUnit.Pixel, oImageAttributes)
        previewPictureBox.Image = oTargetBitmap
    End Sub

    ''' <summary>
    ''' Reset the contrast and brightness to their default values
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnResetAdjustments_Click(sender As Object, e As EventArgs) Handles BtnResetAdjustments.Click
        tbBrightness.Value = 20
        tbContrast.Value = 10
        adjustImage()
    End Sub

    Private Sub disposeImages()
        If originalImage IsNot Nothing Then originalImage.Dispose()
        If cropBitmap IsNot Nothing Then cropBitmap.Dispose()
        GC.Collect()
    End Sub
#End Region

    Private Sub btnRotate_Click(sender As Object, e As EventArgs) Handles BtnRotate.Click
        If originalImage IsNot Nothing Then
            originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            displayRawImage(originalImage.Clone)
        End If

    End Sub

    Private Sub displayRawImage(ByRef oImage As Image)
        Dim sizeMessage As String = ""
        If oImage.Size.Height > MAX_IMG_HEIGHT Or oImage.Size.Width > MAX_IMG_WIDTH Then
            oImage = shrinkImage(oImage)
            sizeMessage = "Image shrunk to "
        End If
        sizeMessage += CStr(oImage.Size.Width) & "x" & CStr(oImage.Size.Height)
        If oImage.Size.Height > STD_CAP_HEIGHT Or oImage.Size.Width > STD_CAP_WIDTH Then
            Me.Height = iStartHeight + oImage.Size.Height - STD_CAP_HEIGHT
            Me.Width = iStartWidth + oImage.Size.Width - STD_CAP_WIDTH
        End If
        picCapture.Image = oImage.Clone
        clearCropSelection()
        If picCapture.Image IsNot Nothing Then
            logStatus("Image file loaded, " & sizeMessage, True)

        End If
    End Sub

End Class
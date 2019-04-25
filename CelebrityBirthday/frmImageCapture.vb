Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

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
    Private Const FORM_NAME As String = "image capture"
    Private Const START_MESSAGE As String = "Start Capture or Load File"
    Private Const STARTED_MESSAGE As String = "Stop Capture when image is as desired"
    Private Const SAVED_MESSAGE As String = "Image saved to "
    Private Const NOT_SAVED_MESSAGE As String = "Image not saved"
    Private Const SELECT_MESSAGE As String = "Select a capture device"
    Private Const NO_DEVICE_MESSAGE As String = "No capture device available"
    Private Const CONNECTION_ERROR_MESSAGE As String = "Error connecting to device"
    Private Const STD_CAP_WIDTH As Integer = 320
    Private Const STD_CAP_HEIGHT As Integer = 240
    Private Const MAX_IMG_WIDTH As Integer = 1044
    Private Const MAX_IMG_HEIGHT As Integer = 744


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
#End Region
#Region "State"
    Enum captureState
        nodevice
        open
        frozen
        selected
        closed
    End Enum
    Dim currentState As captureState = captureState.closed
#End Region
#Region "Form"
    Private Sub form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Debug("Starting image capture", FORM_NAME)
        lblFormName.Text = FORM_NAME
        iStartHeight = Me.Size.Height
        iStartWidth = Me.Size.Width
        cropBitmap = Nothing
        LoadDeviceList()
        currentState = captureState.closed
        If lstDevices.Items.Count > 0 Then
            If lstDevices.Items.Count > 1 Then
                logStatus(SELECT_MESSAGE)
            Else
                logStatus(START_MESSAGE)
            End If
            lstDevices.SelectedIndex = 0
        Else
            logStatus(NO_DEVICE_MESSAGE, True, TraceEventType.Warning)
            lstDevices.Items.Add(NO_DEVICE_MESSAGE)
            currentState = captureState.nodevice
        End If
        EnableButtons()
    End Sub
    Private Sub resetWindow()
        picCapture.Width = STD_CAP_WIDTH
        picCapture.Height = STD_CAP_HEIGHT
        Me.Width = iStartWidth
        Me.Height = iStartHeight
    End Sub
    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If currentState <> captureState.closed Then
            disconnectDevice()
        End If
        LogUtil.Debug("Stopping image capture", FORM_NAME)
    End Sub
    Private Sub enableButtons()
        btnStart.Enabled = False
        btnStop.Enabled = False
        btnCameraSave.Enabled = False
        btnCroppedSave.Enabled = False
        btnLoadImage.Enabled = False
        Select Case currentState
            Case captureState.nodevice
                btnLoadImage.Enabled = True
            Case captureState.open
                btnStop.Enabled = True
            Case captureState.frozen
                btnCameraSave.Enabled = True
                btnStart.Enabled = True
                btnLoadImage.Enabled = True
            Case captureState.closed
                btnStart.Enabled = True
                btnLoadImage.Enabled = True
            Case captureState.selected
                btnCameraSave.Enabled = True
                btnCroppedSave.Enabled = True
                btnStart.Enabled = True
                btnLoadImage.Enabled = True
        End Select
    End Sub
    Private Sub btnLoadImage_Click(sender As Object, e As EventArgs) Handles btnLoadImage.Click
        disconnectDevice()
        Dim oImageFilename As String = ImageUtil.getImageFileName(ImageUtil.OpenOrSave.Open)
        Dim oImage As ImageIdentity = ImageIdentity.FromFile(oImageFilename)
        If oImage IsNot Nothing Then
            If oImage.Size.Height > MAX_IMG_HEIGHT Or oImage.Size.Width > MAX_IMG_WIDTH Then
                MsgBox("Image is too large", MsgBoxStyle.Exclamation, "Load error")
            Else
                If oImage.Size.Height > STD_CAP_HEIGHT Or oImage.Size.Width > STD_CAP_WIDTH Then
                    Me.Height = iStartHeight + oImage.Size.Height - STD_CAP_HEIGHT
                    Me.Width = iStartWidth + oImage.Size.Width - STD_CAP_WIDTH
                End If
                picCapture.Image = oImage
                clearCropSelection()
                If picCapture.Image IsNot Nothing Then
                    logStatus("Image file loaded", True)
                    currentState = captureState.frozen
                End If
                enableButtons()
                btnStart.Enabled = False
            End If
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        disconnectDevice()
        resetWindow()
        picCapture.Image = Nothing
        clearCropSelection()
        currentState = captureState.closed
        enableButtons()
        logStatus(START_MESSAGE)
    End Sub
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If currentState = captureState.closed Or currentState = captureState.frozen Or currentState = captureState.selected Then
            resetWindow()
            clearCropSelection()
            iDevice = lstDevices.SelectedIndex
            Dim isOpenOK As Boolean = openPreviewWindow()
            If isOpenOK Then
                logStatus(STARTED_MESSAGE)
                currentState = captureState.open
            Else
                ' Error connecting to device close window
                NativeMethods.DestroyWindow(hHwnd)
                picCapture.Image = Nothing
                clearCropSelection()
                logStatus(CONNECTION_ERROR_MESSAGE, True, TraceEventType.Warning)
                currentState = captureState.nodevice
                MsgBox("Connection to capture device failed", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Connection error")
            End If
        End If
        enableButtons()

    End Sub
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Dim data As IDataObject
        Dim oImage As ImageIdentity = Nothing
        ' Copy image to clipboard
        NativeMethods.SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        disconnectDevice()
        picCapture.Image = Nothing
        ' Get image from clipboard and convert it to a bitmap
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            oImage = CType(data.GetData(GetType(System.Drawing.Bitmap)), ImageIdentity)
            picCapture.Image = oImage
        End If
        clearCropSelection()
        currentState = captureState.frozen
        EnableButtons()
    End Sub
    Private Sub btnCroppedSave_Click(sender As Object, e As EventArgs) Handles btnCroppedSave.Click
        If currentState = captureState.selected Then
            Try
                Dim w As Integer = previewPictureBox.Image.Width
                Dim h As Integer = previewPictureBox.Image.Height
                Dim sFilename As String = ImageUtil.saveImageFromPictureBox(previewPictureBox, w, h, ImageUtil.ImageType.JPEG)
                If String.IsNullOrEmpty(sFilename) Then
                    logStatus("File save cancelled", True)
                Else
                    logStatus("File saved to " & sFilename, True)
                End If
            Catch ex As Exception
                LogUtil.Exception("Exception when saving cropped image", ex, FORM_NAME)
            End Try
        End If
    End Sub
    Private Sub btnCameraSave_Click(sender As Object, e As EventArgs) Handles btnCameraSave.Click
        Try
            Dim imageFileName As String = ImageUtil.saveImage(picCapture.Image)
            If Not String.IsNullOrEmpty(imageFileName) Then
                logStatus(SAVED_MESSAGE & imageFileName, True)
            Else
                logStatus(NOT_SAVED_MESSAGE, True)
            End If
        Catch exc As Exception
            MsgBox("Error on Saving: " & exc.Message)
        End Try

    End Sub
#End Region
#Region "Subroutines"
    Private Sub loadDeviceList()
        logStatus("Loading image capture device list")
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        lstDevices.Items.Clear()
        ' Load names of all available devices into the lstDevices
        Do
            '   Get Driver name and version
            bReturn = NativeMethods.capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            ' If there was a device add device name to the list
            If bReturn Then
                lstDevices.Items.Add(strName.Trim)
            End If
            x += 1
        Loop Until bReturn = False
    End Sub
    Private Function openPreviewWindow() As Boolean
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width
        Dim rtnval As Boolean = False
        logStatus("Starting capture", True)
        hHwnd = NativeMethods.capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
            480, picCapture.Handle.ToInt32, 0)
        ' Connect to device
        If NativeMethods.SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            'Set the preview scale
            NativeMethods.SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)               'Set the preview rate in milliseconds
            NativeMethods.SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)           'Start previewing the image from the camera
            NativeMethods.SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)             ' Resize window to fit in picturebox
            NativeMethods.SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, iWidth, iHeight, SWP_NOMOVE Or SWP_NOZORDER)
            rtnval = True
        Else
            rtnval = False
        End If
        Return rtnval
    End Function
    Private Sub disconnectDevice()
        LogUtil.Debug("Disconnecting device", FORM_NAME)
        ' Disconnect from device
        If NativeMethods.SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0) Then
            LogUtil.Debug("Closing internal capture window", FORM_NAME)
            ' close window
            NativeMethods.DestroyWindow(hHwnd)
        End If
    End Sub
    Private Sub logStatus(ByVal sText As String, Optional ByVal islogged As Boolean = False, Optional ByVal level As TraceEventType = TraceEventType.Information)
        lblStatus.Text = sText
        If islogged Then LogUtil.addLog(sText, level, FORM_NAME)
    End Sub
#End Region
#Region "Image Cropping"
    Private Sub picCapture_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCapture.MouseDown
        If currentState = captureState.frozen Or currentState = captureState.selected Then
            Try
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    clearCropSelection()
                    currentState = captureState.frozen
                    enableButtons()
                    cropX = e.X
                    cropY = e.Y
                    Cursor = Cursors.Cross
                End If
                picCapture.Refresh()
            Catch exc As Exception
                LogUtil.Exception("MouseDown exception", exc, FORM_NAME)
            End Try
        End If
    End Sub
    Private Sub picCapture_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCapture.MouseMove
        If picCapture.Image IsNot Nothing AndAlso (currentState = captureState.frozen Or currentState = captureState.selected) Then
            Try
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    picCapture.Refresh()
                    cropWidth = e.X - cropX
                    cropHeight = cropWidth * 9 / 7
                    picCapture.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
                End If
            Catch exc As Exception
                LogUtil.Exception("MouseMove exception", exc, FORM_NAME)
                If Err.Number = 5 Then Exit Sub
            End Try
        End If
    End Sub
    Private Sub picCapture_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picCapture.MouseUp

        If currentState = captureState.frozen Or currentState = captureState.selected Then
            Try
                Cursor = Cursors.Default
                captureCroppedArea()
                logStatus("Image area selected")
            Catch exc As Exception
                LogUtil.Exception("MouseUp exception", exc, FORM_NAME)
            End Try
        End If
    End Sub
    Private Sub clearCropSelection()
        cropWidth = 0
        cropHeight = 0
        cropBitmap = Nothing
        cropPen = New Pen(cropPenColor, cropPenSize)
        cropPen.DashStyle = DashStyle.DashDot
        previewPictureBox.Image = Nothing
    End Sub
    Private Sub captureCroppedArea()
        Try
            ' Extract cropped area from main picture into cropBitmap
            cropBitmap = ImageUtil.extractCroppedAreaFromImage(picCapture.Image, cropWidth, cropHeight, cropX, cropY)
            ' Resize cropBitmap to fit preview picture box
            previewPictureBox.Image = ImageUtil.resizeImageToBitmap(cropBitmap, previewPictureBox.Width, previewPictureBox.Height)
            currentState = captureState.selected
            enableButtons()
        Catch exc As Exception
            LogUtil.Exception("captureCroppedArea exception", exc, FORM_NAME)
        End Try
    End Sub

#End Region

End Class
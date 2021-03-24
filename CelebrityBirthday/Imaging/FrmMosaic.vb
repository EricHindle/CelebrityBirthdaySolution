Imports System.IO

Public Class FrmMosaic
    Dim _width As Integer
    Dim _height As Integer
    Dim isChangingSize As Boolean = False
    Private _imageList As New List(Of Person)
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()

    End Sub

    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.MosaicImagePath
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _fileName As String = Path.Combine(_path, cboMonth.SelectedItem & If(CboDay.SelectedIndex > 0, CboDay.SelectedItem, "") & "_mosaic_" & If(chkBotSD.Checked, "botsd_", "") & CStr(nudSkip.Value + 1) & "-" & CStr(nudSkip.Value + NudHeight.Value) & ".jpg")
        ImageUtil.SaveImageFromPictureBox(PictureBox1, (_width * 60), (_height * 60), _fileName)
        DisplayStatus("File saved : " & _fileName)
    End Sub

    Private Sub DisplayStatus(_text As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = True)
        If isAppend Then
            lblStatus.Text &= _text
        Else
            lblStatus.Text = _text
        End If
        If isLogged Then
            LogUtil.Info(_text, "FrmMosaic")
        End If
        StatusStrip1.Refresh()
    End Sub

    Private Sub GenerateImage(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer, _height As Integer)
        DisplayStatus("Generating Image")
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
        LblImgShown.Text = CStr(_width * _height)
        LblImgShown.Refresh()
        DisplayStatus("Image complete")
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim ct As Integer = 0
        DisplayStatus("Selecting Images")
        _imageList = New List(Of Person)
        Dim _PersonTa As New CelebrityBirthdayDataSetTableAdapters.FullPersonTableAdapter
        Dim _PersonTable As New CelebrityBirthdayDataSet.FullPersonDataTable
        If chkBotSD.Checked Then
            _PersonTa.FillByBotsd(_PersonTable, cboMonth.SelectedIndex + 1)
        Else
            If cboMonth.SelectedIndex >= 0 Then
                If CboDay.SelectedIndex > 0 Then
                    _PersonTa.FillByDayAndMonth(_PersonTable, CboDay.SelectedIndex, cboMonth.SelectedIndex + 1)
                Else
                    _PersonTa.FillByMonth(_PersonTable, cboMonth.SelectedIndex + 1)
                End If
            Else
                DisplayStatus("No month selected")
            End If
        End If
        For Each _personRow As CelebrityBirthdayDataSet.FullPersonRow In _PersonTable
            ct += 1
            'If ct > 850 Then
            '    logutil.debug(_person.Name & " " & Format(_person.DateOfBirth, "dd MMM yyyy"))
            'End If
            _imageList.Add(New Person(_personRow))
        Next
        _height = Int(Math.Sqrt(_imageList.Count))
        isChangingSize = True
        NudHeight.Value = _height
        _width = Int(_imageList.Count / NudHeight.Value) + If(_imageList.Count > (_height ^ 2), 1, 0)
        NudWidth.Value = _width
        isChangingSize = False
        lblImgCount.Text = CStr(_imageList.Count)
        lblImgCount.Refresh()
        GenerateImage(PictureBox1, _imageList, _width, _height)
        _PersonTable.Dispose()
        _PersonTa.Dispose()

    End Sub

    Private Sub NudWidth_ValueChanged(sender As Object, e As EventArgs) Handles NudWidth.ValueChanged
        If Not isChangingSize Then
            isChangingSize = True
            If _imageList.Count > 0 And NudWidth.Value > 0 Then
                Try
                    _width = NudWidth.Value
                    Dim _possibleNewHeight As Integer = Int(_imageList.Count / _width)
                    _height = Int(_imageList.Count / _width) + If(_imageList.Count > (_possibleNewHeight * _width), 1, 0)
                    NudHeight.Value = _height
                    GenerateImage(PictureBox1, _imageList, _width, _height)
                Catch ex As ArithmeticException
                    DisplayStatus("Exception occurred")
                    LogUtil.Exception("Error", ex, "FrmMosaic")
                End Try
            End If
            isChangingSize = False
        End If
    End Sub
    Private Sub NudHeight_ValueChanged(sender As Object, e As EventArgs) Handles NudHeight.ValueChanged
        If Not isChangingSize Then
            isChangingSize = True
            If _imageList.Count > 0 And NudHeight.Value > 0 Then
                Try
                    _height = NudHeight.Value
                    Dim _possibleNewWidth As Integer = Int(_imageList.Count / _height)
                    _width = Int(_imageList.Count / _height) + If(_imageList.Count > (_possibleNewWidth * _height), 1, 0)
                    NudWidth.Value = _width
                    GenerateImage(PictureBox1, _imageList, _width, _height)
                Catch ex As ArithmeticException
                    DisplayStatus("Exception occurred")
                    LogUtil.Exception("Error", ex, "FrmMosaic")
                End Try
            End If
            isChangingSize = False
        End If
    End Sub
    Private Sub BtnRegen_Click(sender As Object, e As EventArgs) Handles BtnRegen.Click
        If _imageList.Count > 0 And NudWidth.Value > 0 Then
            _width = NudWidth.Value
            _height = NudHeight.Value
            GenerateImage(PictureBox1, _imageList, _width, _height)
        End If
    End Sub

    Private Sub FrmMosaic_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        For Each _person As Person In _imageList
            _person.Dispose()
        Next
    End Sub

    Private Sub FrmMosaic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
    End Sub

    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        CboDay.SelectedIndex = Today.Day
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub
End Class
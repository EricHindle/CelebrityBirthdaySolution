Imports System.IO

Public Class FrmMosaic

    Private _imageList As New List(Of Person)
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()

    End Sub

    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _fileName As String = Path.Combine(_path, cboMonth.SelectedItem & "_mosaic_" & CStr(nudSkip.Value + 1) & "-" & CStr(nudSkip.Value + NudHeight.Value) & ".jpg")
        ImageUtil.SaveImageFromPictureBox(PictureBox1, (NudWidth.Value * 60), (NudHeight.Value * 60), _fileName)
        DisplayStatus("File saved")
    End Sub

    Private Sub DisplayStatus(_text As String, Optional _isAppend As Boolean = False)
        If _isAppend Then
            lblStatus.Text &= _text
        Else
            lblStatus.Text = _text
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
        Dim _skip As Integer = nudSkip.Value * NudWidth.Value
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
                    oGraphics.DrawImage(oBitMap, New Point(60 * _imgHPos, 60 * _imgVPos))
                End If
            Else
                _skip -= 1
            End If
        Next
        _pictureBox.Image = _mosaic
        LblImgShown.Text = CStr(NudWidth.Value * NudHeight.Value)
        LblImgShown.Refresh()
        DisplayStatus("Image complete")
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim ct As Integer = 0
        DisplayStatus("Selecting Images")
        _imageList = New List(Of Person)
        If cboMonth.SelectedIndex >= 0 Then
            Dim _PersonTa As New CelebrityBirthdayDataSetTableAdapters.FullPersonTableAdapter
            Dim _PersonTable As New CelebrityBirthdayDataSet.FullPersonDataTable
            _PersonTa.FillByMonth(_PersonTable, cboMonth.SelectedIndex + 1)
            For Each _personRow As CelebrityBirthdayDataSet.FullPersonRow In _PersonTable
                ct += 1
                'If ct > 850 Then
                '    logutil.debug(_person.Name & " " & Format(_person.DateOfBirth, "dd MMM yyyy"))
                'End If
                _imageList.Add(New Person(_personRow))
            Next
            lblImgCount.Text = CStr(_imageList.Count)
            lblImgCount.Refresh()
            GenerateImage(PictureBox1, _imageList, NudWidth.Value, NudHeight.Value)
            _PersonTable.Dispose()
            _PersonTa.Dispose()
        Else
            DisplayStatus("No month selected")
        End If
    End Sub

    Private Sub NudWidth_ValueChanged(sender As Object, e As EventArgs) Handles NudWidth.ValueChanged
        If _imageList.Count > 0 And NudWidth.Value > 0 Then
            Try
                NudHeight.Value = Int(_imageList.Count / NudWidth.Value)
            Catch ex As ArithmeticException
                NudHeight.Value = NudHeight.Maximum
            End Try
            GenerateImage(PictureBox1, _imageList, NudWidth.Value, NudHeight.Value)
        End If
    End Sub

    Private Sub BtnRegen_Click(sender As Object, e As EventArgs) Handles BtnRegen.Click
        If _imageList.Count > 0 And NudWidth.Value > 0 Then
            GenerateImage(PictureBox1, _imageList, NudWidth.Value, NudHeight.Value)
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
End Class
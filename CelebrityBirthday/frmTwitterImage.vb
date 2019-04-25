Imports System.Drawing
Imports System.IO

Public Class FrmTwitterImage
    Private personTable As New List(Of Person)

    Private oBirthdayList As New List(Of Person)
    Private oAnniversaryList As New List(Of Person)

    Private IsNoGenerate As Boolean
    Private Sub CboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged,
                                                                                    cboMonth.SelectedIndexChanged
        LblStatus.Text = ""
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            LblStatus.Text = "Loading People From Database"
            Me.Refresh()
            personTable.Clear()
            personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            oBirthdayList = FindBirthdays(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            oAnniversaryList = FindAnniversaries(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            For iCt As Integer = personTable.Count - 1 To 0 Step -1

                Dim _person As Person = personTable(iCt)
                If _person.Social.IsNoTweet Then
                    personTable.Remove(_person)
                End If
            Next

            For iCt As Integer = oBirthdayList.Count - 1 To 0 Step -1

                Dim _person As Person = oBirthdayList(iCt)
                If _person.Social.IsNoTweet Then
                    oBirthdayList.Remove(_person)
                End If
            Next

            For iCt As Integer = oAnniversaryList.Count - 1 To 0 Step -1

                Dim _person As Person = oAnniversaryList(iCt)
                If _person.Social.IsNoTweet Then
                    oAnniversaryList.Remove(_person)
                End If
            Next

            LblImageCount.Text = CStr(personTable.Count) + " people selected"

            If personTable.Count > 0 Then
                LblStatus.Text += " - Complete"
            Else
                LblStatus.Text += "- No Images"

            End If
        End If
    End Sub

    Private Function BuildImageList(_people As List(Of Person)) As List(Of Image)
        Dim _imageTable As New List(Of Image)
        If _people.Count > 0 Then
            For Each oPerson As Person In _people
                Dim _imageFilename As String = Path.Combine(My.Settings.ImgFolder, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
                If My.Computer.FileSystem.FileExists(_imageFilename) Then
                    Dim _image As Image = Image.FromFile(_imageFilename)
                    _imageTable.Add(_image)
                End If
            Next
        End If
        Return _imageTable
    End Function

    Private Function BuildImageLists(_people As List(Of List(Of Person))) As List(Of List(Of Image))
        Dim _imageTables As New List(Of List(Of Image))
        For Each _personList As List(Of Person) In _people
            Dim _imageTable As New List(Of Image)
            If _people.Count > 0 Then
                For Each oPerson As Person In _personList
                    Dim _imageFilename As String = Path.Combine(My.Settings.ImgFolder, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
                    If My.Computer.FileSystem.FileExists(_imageFilename) Then
                        Dim _image As Image = Image.FromFile(_imageFilename)
                        _imageTable.Add(_image)
                    End If
                Next
            End If
            _imageTables.Add(_imageTable)
        Next
        Return _imageTables
    End Function
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnGenImage_Click(sender As Object, e As EventArgs) Handles BtnGenImage.Click
        LblStatus.Text = ""
        If RbSingleImage.Checked Then
            GeneratePicture(PictureBox1, BuildImageList(personTable), NudPic1Horizontal)
        Else
            GeneratePictures(PictureBox1, BuildImageLists(SplitIntoTweets(oBirthdayList)), NudPic1Horizontal)
            GeneratePictures(PictureBox2, BuildImageLists(SplitIntoTweets(oAnniversaryList)), NudPic2Horizontal)
        End If

    End Sub

    Private Sub GeneratePictures(_pictureBox As PictureBox, _imageLists As List(Of List(Of Image)), _nud As NumericUpDown)
        Dim imageCount As Integer = 0
        For Each _imageList As List(Of Image) In _imageLists
            TabControl1.TabPages.Add(CreateNewTabPage("", imageCount))
            GeneratePicture(_pictureBox, _imageList, _nud)
            imageCount += 1
        Next
    End Sub
    Private Function CreateNewTabPage(_text As String, _index As Integer) As TabPage
        Dim newTabpage As New TabPage
        With newTabpage
            .Text = _text
            .TabIndex = _index
            .Location = New System.Drawing.Point(4, 22)
            .Name = "TabPage_" & CStr(_index)
            .Padding = New System.Windows.Forms.Padding(3)
            .Size = New System.Drawing.Size(412, 426)
            .Controls.Add(NewPictureBox(GetTabNumber(newTabpage)))
            .Controls.Add(NewLabel(GetTabNumber(newTabpage)))
            .Controls.Add(NewNumericUpDown(GetTabNumber(newTabpage)))
        End With
        Return newTabpage
    End Function
    Private Function NewLabel(_index As String) As Label
        Dim _label As New Label
        With _label
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            .AutoSize = True
            .Location = New System.Drawing.Point(5, 338)
            .Name = "Label" & _index
            .Size = New System.Drawing.Size(40, 14)
            .Text = "Width"
        End With
        Return _label
    End Function
    Private Function NewPictureBox(_index As String) As PictureBox
        Dim _picBox As New PictureBox
        With _picBox
            .BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            .Location = New System.Drawing.Point(3, 6)
            .Name = "PictureBox" & _index
            .Size = New System.Drawing.Size(240, 240)
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        End With
        Return _picBox
    End Function
    Private Function NewNumericUpDown(_index As String) As NumericUpDown
        Dim _nud As New NumericUpDown
        With _nud
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            .Location = New System.Drawing.Point(51, 336)
            .Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            .Name = "NudPic1Horizontal" & _index
            .Size = New System.Drawing.Size(53, 22)
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            .Value = New Decimal(New Integer() {1, 0, 0, 0})
        End With
        Return _nud
    End Function
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Image), _nud As NumericUpDown)

        If _imageTable.Count > 0 Then
            Dim _width As Integer = CInt(Math.Sqrt(CDbl(_imageTable.Count)))
            If _width < 1 Then _width = 1
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            IsNoGenerate = True
            _nud.Value = _width
            IsNoGenerate = False
            GenerateImage(_pictureBox, _imageTable, _width, _height)
        Else
            _pictureBox.Image = Nothing
        End If
    End Sub
    Private Sub GenerateImage(_pictureBox As PictureBox, _imageTable As List(Of Image), _width As Integer, _height As Integer)
        Dim _mosaic As Image = New Bitmap(My.Resources.blank, 60 * _width, 60 * _height)
        Dim oGraphics As Graphics = Graphics.FromImage(_mosaic)
        oGraphics.DrawImage(My.Resources.id, New Point(_mosaic.Width - 60, _mosaic.Height - 60))
        Dim _imgHPos As Integer = -1
        Dim _imgVPos As Integer = 0
        For Each _image As Image In _imageTable
            _imgHPos += 1
            If _imgHPos = _width Then
                _imgVPos += 1
                _imgHPos = 0
            End If
            Dim oBitMap As Bitmap = ImageUtil.resizeImageToBitmap(_image, 60, 60)
            oGraphics.DrawImage(oBitMap, New Point(60 * _imgHPos, 60 * _imgVPos))
        Next
        _pictureBox.Image = _mosaic
        LblStatus.Text = "Image complete"
    End Sub


    Private Sub NudPic1Horizontal_ValueChanged(sender As Object, e As EventArgs) Handles NudPic1Horizontal.ValueChanged
        Dim _imageList As New List(Of Image)
        If RbSingleImage.Checked Then
            _imageList = BuildImageList(personTable)
        Else
            _imageList = BuildImageList(oBirthdayList)
        End If
        If Not IsNoGenerate AndAlso _imageList.Count > 0 Then
            Dim _width As Integer = NudPic1Horizontal.Value
            Dim _height As Integer = Math.Ceiling(_imageList.Count / _width)
            IsNoGenerate = True
            IsNoGenerate = False
            GenerateImage(PictureBox1, _imageList, _width, _height)
        Else
        End If
    End Sub
    Private Sub NudPic2Horizontal_ValueChanged(sender As Object, e As EventArgs) Handles NudPic2Horizontal.ValueChanged
        Dim _imageList As List(Of Image) = BuildImageList(oAnniversaryList)
        If Not IsNoGenerate AndAlso _imageList.Count > 0 Then
            Dim _width As Integer = NudPic2Horizontal.Value
            Dim _height As Integer = Math.Ceiling(_imageList.Count / _width)
            IsNoGenerate = True
            LblPic2Height.Text = CStr(_height)
            IsNoGenerate = False
            GenerateImage(PictureBox2, _imageList, _width, _height)
        Else
        End If
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        Dim _path As String = Path.Combine(My.Settings.ImgFolder, "mosaics")
        Dim _add As String = ""
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        If RbSplitImages.Checked Then
            _add = "_Birthdays"
        End If
        LblStatus.Text = ""
        Dim _fileName As String = cboDay.SelectedItem & "_" & cboMonth.SelectedItem & "_mosaic" & _add & ".jpg"
        LblStatus.Text &= ImageUtil.saveImageFromPictureBox(PictureBox1, PictureBox1.Width, PictureBox1.Height, Path.Combine(_path, _fileName))
        If RbSplitImages.Checked Then
            _add = "_Anniversaries"
            _fileName = cboDay.SelectedItem & "_" & cboMonth.SelectedItem & "_mosaic" & _add & ".jpg"
            LblStatus.Text &= " " & ImageUtil.saveImageFromPictureBox(PictureBox2, PictureBox2.Width, PictureBox2.Height, Path.Combine(_path, _fileName))
        End If
    End Sub

End Class
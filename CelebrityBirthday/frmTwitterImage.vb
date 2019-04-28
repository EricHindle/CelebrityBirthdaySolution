﻿Imports System.Drawing
Imports System.IO

Public Class FrmTwitterImage
#Region "constants"
    Private Const DEFAULT_WIDTH As Integer = 6
    Private Const NUD_BASENAME As String = "NudHorizontal"
    Private Const PICBOX_BASENAME As String = "pictureBox"
#End Region
#Region "variables"
    Private personTable As New List(Of Person)
    Private oBirthdayList As New List(Of Person)
    Private oAnniversaryList As New List(Of Person)
    Private oImageLists As New List(Of List(Of Image))
    Private IsNoGenerate As Boolean
#End Region
#Region "form control handlers"
    Private Sub CboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged,
                                                                                    cboMonth.SelectedIndexChanged
        DisplayStatus("")
        PictureBox1.Image = Nothing
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            DisplayStatus("Loading People From Database")
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
                DisplayStatus(" - Complete", True)
            Else
                DisplayStatus("- No Images", True)
            End If
        End If
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnGenImage_Click(sender As Object, e As EventArgs) Handles BtnGenImage.Click
        DisplayStatus("Generating images")
        TabControl1.TabPages.Clear()
        Dim tabTitle As String
        Dim _imageStart As Integer = 0
        oImageLists = New List(Of List(Of Image))
        If RbSingleImage.Checked Then
            oImageLists.Add(BuildImageList(personTable))
            tabTitle = "Full_"
            GeneratePictures(oImageLists, tabTitle, _imageStart)
        Else
            oImageLists.AddRange(BuildImageLists(SplitIntoTweets(oBirthdayList)))
            tabTitle = "Birthdays_"
            _imageStart = GeneratePictures(oImageLists, tabTitle, _imageStart)
            oImageLists.AddRange(BuildImageLists(SplitIntoTweets(oAnniversaryList)))
            tabTitle = "Anniv_"
            GeneratePictures(oImageLists, tabTitle, _imageStart)
        End If
        DisplayStatus("Images Complete")
    End Sub
    Private Sub Horizontal_ValueChanged(sender As Object, e As System.EventArgs)
        If Not IsNoGenerate Then
            Dim _nud As NumericUpDown = TryCast(sender, NumericUpDown)
            Dim _tabpage As TabPage = TryCast(_nud.Parent, TabPage)
            Dim _index As Integer = _tabpage.TabIndex
            Dim pbControl As PictureBox = GetPictureBoxFromPage(_tabpage)
            GeneratePicture(pbControl, oImageLists(_index), _nud.Value)
        End If
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        DisplayStatus("Saving Files")
        Dim _path As String = Path.Combine(My.Settings.ImgFolder, "mosaics")
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        For Each _page As TabPage In TabControl1.TabPages
            Dim _add As String = _page.Text
            Dim _fileName As String = _add.Replace("_", "_" & cboDay.SelectedItem & "_" & cboMonth.SelectedItem & "_") & "_mosaic_" & ".jpg"
            Dim _pictureBox As PictureBox = GetPictureBoxFromPage(_page)
            ImageUtil.saveImageFromPictureBox(_pictureBox, _pictureBox.Width, _pictureBox.Height, Path.Combine(_path, _fileName))
        Next
        DisplayStatus("Files saved")
    End Sub
#End Region
#Region "subroutines"
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
    Private Function GeneratePictures(_imageLists As List(Of List(Of Image)), _tabTitle As String, _imageStart As Integer) As Integer
        Dim imageCount As Integer = _imageStart
        For _imageIndex As Integer = _imageStart To _imageLists.Count - 1
            Dim _imageList As List(Of Image) = _imageLists(_imageIndex)
            DisplayStatus(">" & CStr(imageCount), True)
            Dim newTabPage As TabPage = CreateNewTabPage(imageCount, _tabTitle)
            Dim pbControl As PictureBox = GetPictureBoxFromPage(newTabPage)
            IsNoGenerate = True
            GetNudFromPage(newTabPage).Value = DEFAULT_WIDTH
            IsNoGenerate = False
            TabControl1.TabPages.Add(newTabPage)
            Dim _width As Integer = DEFAULT_WIDTH
            GeneratePicture(pbControl, _imageList, _width)
            imageCount += 1
        Next
        Return imageCount
    End Function
    Private Function CreateNewTabPage(_index As Integer, _tabTitle As String) As TabPage
        Dim newTabpage As New TabPage
        Dim tabTitle As String = _tabTitle & CStr(_index)
        With newTabpage
            .Text = tabTitle
            .TabIndex = _index
            .Location = New System.Drawing.Point(4, 22)
            .Name = "TabPage_" & CStr(_index)
            .Padding = New System.Windows.Forms.Padding(3)
            .Size = New System.Drawing.Size(412, 426)
            .Controls.Add(NewPictureBox(newTabpage.TabIndex))
            .Controls.Add(NewLabel(newTabpage.TabIndex, 6, 367, "Width", "Label1"))
            .Controls.Add(NewNumericUpDown(newTabpage.TabIndex))
        End With
        Return newTabpage
    End Function
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Image), _width As Integer)

        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
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
        DisplayStatus("Image complete", True)
    End Sub
    Private Function NewLabel(_index As String, _locationX As Integer, _locationY As Integer, _text As String, _labelNameBase As String) As Label
        Dim _label1 As New Label
        With _label1
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            .AutoSize = True
            .Location = New System.Drawing.Point(_locationX, _locationY)
            .Name = _labelNameBase & _index
            .Size = New System.Drawing.Size(40, 14)
            .Text = _text
        End With
        Return _label1
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
            .Location = New System.Drawing.Point(51, 364)
            .Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            .Name = NUD_BASENAME & _index
            .Size = New System.Drawing.Size(53, 22)
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            .Value = New Decimal(New Integer() {1, 0, 0, 0})
        End With
        AddHandler _nud.ValueChanged, AddressOf Horizontal_ValueChanged
        Return _nud
    End Function
    Private Function GetPictureBoxFromPage(_tabpage As TabPage) As PictureBox
        Dim _index As Integer = _tabpage.TabIndex
        Dim _controls As Control() = _tabpage.Controls.Find(PICBOX_BASENAME & CStr(_index), False)
        Dim pbControl As New PictureBox
        If _controls.Count > 0 Then
            pbControl = TryCast(_controls(0), PictureBox)
        End If
        Return pbControl
    End Function
    Private Function GetNudFromPage(_tabpage As TabPage) As NumericUpDown
        Dim _index As Integer = _tabpage.TabIndex
        Dim _controls As Control() = _tabpage.Controls.Find(NUD_BASENAME & CStr(_index), False)
        Dim _control As New NumericUpDown
        If _controls.Count > 0 Then
            _control = TryCast(_controls(0), NumericUpDown)
        End If
        Return _control
    End Function
    Private Sub DisplayStatus(_text As String, Optional _isAppend As Boolean = False)
        If _isAppend Then
            LblStatus.Text &= _text
        Else
            LblStatus.Text = _text
        End If
        StatusStrip1.Refresh()
    End Sub

    Private Sub FrmTwitterImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.twitterimagepos)
    End Sub

    Private Sub FrmTwitterImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.twitterimagepos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
#End Region

End Class
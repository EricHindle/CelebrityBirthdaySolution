Imports System.Drawing
Imports System.IO
Imports System.Text

Public Class FrmTwitterImage
#Region "constants"
    Private Const DEFAULT_WIDTH As Integer = 6
    Private Const NUD_BASENAME As String = "NudHorizontal"
    Private Const PICBOX_BASENAME As String = "pictureBox"
    Private Const SC_BASENAME As String = "SplitContainer"
#End Region
#Region "variables"
    Private personTable As New List(Of Person)
    Private oBirthdayList As New List(Of Person)
    Private oAnniversaryList As New List(Of Person)
    Private oTweetLists As New List(Of List(Of Person))
    Private IsNoGenerate As Boolean
#End Region
#Region "form control handlers"
    Private Sub CboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged,
                                                                                    cboMonth.SelectedIndexChanged
        DisplayStatus("")
        NudPersonsPerTweet.Value = 0
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
        lblError.Visible = False
        TxtStats.Text = ""
        TxtStats.Visible = False
        If cboDay.SelectedIndex > -1 AndAlso cboMonth.SelectedIndex > -1 Then
            TabControl1.TabPages.Clear()
            Dim tabTitle As String
            Dim _imageStart As Integer = 0
            Dim _dateLength As Integer = cboDay.SelectedItem.length + cboMonth.SelectedItem.length + 4
            oTweetLists = New List(Of List(Of Person))
            If RbSingleImage.Checked Then
                oTweetLists.Add(personTable)
                tabTitle = "Full_"
                GeneratePictures(oTweetLists, tabTitle, _imageStart)
            Else
                Dim _birthdayImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oBirthdayList, _dateLength + BIRTHDAY_HDR.Length)
                oTweetLists.AddRange(_birthdayImageTweets)
                tabTitle = "Birthdays_"
                GeneratePictures(oTweetLists, tabTitle, _imageStart)
                _imageStart = oTweetLists.Count
                Dim _annivImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oAnniversaryList, _dateLength + ANNIV_HDR.Length)
                oTweetLists.AddRange(_annivImageTweets)
                tabTitle = "Anniv_"
                GeneratePictures(oTweetLists, tabTitle, _imageStart)
            End If
            DisplayStatus("Images Complete")
        End If
    End Sub
    Private Sub Horizontal_ValueChanged(sender As Object, e As System.EventArgs)
        If Not IsNoGenerate Then
            Dim _nud As NumericUpDown = TryCast(sender, NumericUpDown)
            Dim _sp As SplitterPanel = TryCast(_nud.Parent, SplitterPanel)
            If _sp IsNot Nothing Then
                Dim _sc As SplitContainer = TryCast(_sp.Parent, SplitContainer)
                If _sc IsNot Nothing Then
                    Dim _tabpage As TabPage = TryCast(_sc.Parent, TabPage)
                    If _tabpage IsNot Nothing Then
                        Dim _index As Integer = _tabpage.TabIndex
                        Dim pbControl As PictureBox = GetPictureBoxFromPage(_tabpage)
                        GeneratePicture(pbControl, oTweetLists(_index), _nud.Value)
                    End If
                End If
            End If
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
    Private Sub GeneratePictures(_tweetLists As List(Of List(Of Person)), _tabTitle As String, _imageStart As Integer)
        For _imageIndex As Integer = _imageStart To _tweetLists.Count - 1
            Dim _imageList As List(Of Person) = _tweetLists(_imageIndex)
            DisplayStatus(">" & CStr(_imageIndex), True)
            Dim newImageTabPage As TabPage = CreateNewImageTabPage(_imageIndex, _tabTitle)
            Dim pbControl As PictureBox = GetPictureBoxFromPage(newImageTabPage)
            Dim rtbControl As RichTextBox = GetRichTextBoxFromPage(newImageTabPage)
            IsNoGenerate = True
            TabControl1.TabPages.Add(newImageTabPage)
            GetNudFromPage(newImageTabPage).Value = DEFAULT_WIDTH
            Dim _width As Integer = DEFAULT_WIDTH
            GeneratePicture(pbControl, _imageList, _width)
            GenerateText(rtbControl, _imageList, _tabTitle.Substring(0, 1), _imageIndex - _imageStart + 1, _tweetLists.Count - _imageStart)
            IsNoGenerate = False
        Next
    End Sub
    Private Function CreateNewImageTabPage(_index As Integer, _tabTitle As String) As TabPage
        Dim newTabpage As New TabPage
        Dim tabTitle As String = _tabTitle & CStr(_index)
        With newTabpage
            .Text = tabTitle
            .TabIndex = _index
            '   .Location = New System.Drawing.Point(4, 22)
            .Name = "ImageTabPage_" & CStr(_index)
            .Padding = New System.Windows.Forms.Padding(3)
            .Size = New System.Drawing.Size(412, 426)
            .Controls.Add(newSplitContainer(newTabpage.TabIndex))

        End With
        Return newTabpage
    End Function

    Private Function NewSplitContainer(_index As Integer) As SplitContainer
        Dim _splitContainer As New SplitContainer With {
        .Location = New System.Drawing.Point(9, 6),
            .Size = New System.Drawing.Size(817, 471),
            .SplitterDistance = 384
        }
        _splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        _splitContainer.Location = New System.Drawing.Point(9, 6)
        _splitContainer.Name = "SplitContainer" & CStr(_index)

        _splitContainer.Panel1.Controls.Add(NewNumericUpDown(_index))
        _splitContainer.Panel1.Controls.Add(NewLabel(_index, 3, 430, "Width", "Label1"))
        _splitContainer.Panel1.Controls.Add(NewPictureBox(_index))

        _splitContainer.Panel2.Controls.Add(NewRichTextBox(_index))
        Return _splitContainer
    End Function


    Private Sub GenerateText(_textBox As RichTextBox, _imageTable As List(Of Person), _type As String, _index As Integer, _numberOfLists As Integer)
        Dim _outString As New StringBuilder
        _outString.Append(cboMonth.SelectedItem).Append(" ").Append(cboDay.SelectedItem).Append(vbCrLf).Append(vbCrLf)
        _outString.Append(GetHeading(_type)).Append(vbCrLf)

        Dim _footer As String = If(_numberOfLists > 1, CStr(_index) & "/" & CStr(_numberOfLists), "")

        For Each _person As Person In _imageTable
            _outString.Append(_person.ForeName).Append(" ").Append(_person.Surname)
            If _person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle) Then
                _outString.Append(" @").Append(_person.Social.TwitterHandle)
            End If
            _outString.Append(vbCrLf)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(vbCrLf).Append(_footer).Append(vbCrLf)
        End If
        _textBox.Text = _outString.ToString
    End Sub
    Private Function GetHeading(_typeNode As String) As String
        Dim _header As String = ""
        If _typeNode.StartsWith("A") Then
            _header = ANNIV_HDR
        End If
        If _typeNode.StartsWith("B") Then
            _header = BIRTHDAY_HDR
        End If
        Return _header
    End Function
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer)

        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            GenerateImage(_pictureBox, _imageTable, _width, _height)
        Else
            _pictureBox.Image = Nothing
        End If
    End Sub
    Private Sub GenerateImage(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer, _height As Integer)
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
            .Location = New System.Drawing.Point(3, 3)
            .Name = "PictureBox" & _index
            .Size = New System.Drawing.Size(360, 360)
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        End With
        Return _picBox
    End Function
    Private Function NewNumericUpDown(_index As String) As NumericUpDown
        Dim _nud As New NumericUpDown
        With _nud
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            .Location = New System.Drawing.Point(49, 428)
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
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabpage)
        Dim _controls As Control() = _sc.Panel1.Controls.Find(PICBOX_BASENAME & CStr(_index), False)
        Dim pbControl As New PictureBox
        If _controls.Count > 0 Then
            pbControl = TryCast(_controls(0), PictureBox)
        End If
        Return pbControl
    End Function
    Private Function GetNudFromPage(_tabpage As TabPage) As NumericUpDown
        Dim _index As Integer = _tabpage.TabIndex
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabpage)
        Dim _controls As Control() = _sc.Panel1.Controls.Find(NUD_BASENAME & CStr(_index), False)
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
    Private Sub BtnCopyselected_Click(sender As Object, e As EventArgs) Handles BtnCopyselected.Click, CopyToolStripMenuItem.Click
        Dim _rtb As RichTextBox = GetRichTextBoxFromPage(TabControl1.SelectedTab)
        My.Computer.Clipboard.Clear()
        If _rtb IsNot Nothing AndAlso Not String.IsNullOrEmpty(_rtb.SelectedText) Then
            My.Computer.Clipboard.SetText(_rtb.SelectedText)
        End If
    End Sub

    Private Function NewRichTextBox(_index As String) As RichTextBox
        Dim _newRtb As New System.Windows.Forms.RichTextBox()
        With _newRtb
            .Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
           Or System.Windows.Forms.AnchorStyles.Left) _
           Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            .Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .Location = New System.Drawing.Point(3, 3)
            .Name = RTB_CONTROL_NAME & _index
            .Size = New System.Drawing.Size(415, 447)
            .Text = ""
            .ContextMenuStrip = ContextMenuStrip1
        End With
        Return _newRtb
    End Function

    Public Function GetRichTextBoxFromPage(_tabPage As TabPage) As RichTextBox
        Dim _rtb As New RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & CStr(_tabPage.TabIndex)
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabPage)
        Dim _controls As Control() = _sc.Panel2.Controls.Find(_tabName, False)
        If _controls.Count > 0 Then
            _rtb = TryCast(_controls(0), RichTextBox)
        End If
        Return _rtb
    End Function

    Public Function GetSplitContainerFromPage(_tabPage As TabPage) As SplitContainer
        Dim _sc As New SplitContainer
        Dim _tabName As String = SC_BASENAME & CStr(_tabPage.TabIndex)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Count > 0 Then
            _sc = TryCast(_controls(0), SplitContainer)
        End If
        Return _sc
    End Function

    Private Sub BtnCopyAll_Click(sender As Object, e As EventArgs) Handles BtnCopyAll.Click
        Dim _rtb As RichTextBox = GetRichTextBoxFromPage(TabControl1.SelectedTab)
        My.Computer.Clipboard.Clear()
        If _rtb IsNot Nothing Then
            My.Computer.Clipboard.SetText(_rtb.Text)
        End If
    End Sub

    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        Dim _rtb As RichTextBox = GetRichTextBoxFromPage(TabControl1.SelectedTab)
        My.Computer.Clipboard.Clear()
        If _rtb IsNot Nothing Then
            My.Computer.Clipboard.SetText(_rtb.Text)
        End If
    End Sub
    Private Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer) As List(Of List(Of Person))
        Dim _totalLength As Integer = 0
        Dim availableLength As Integer = TWEET_SIZE - _headerLength
        Debug.Print(availableLength)
        For Each _person As Person In oPersonlist
            Dim _tweetLineLength As Integer = GetTweetLineLength(_person)
            _totalLength += _tweetLineLength
            Debug.Print(CStr(_person.Name & " " & (_person.Social.TwitterHandle) & CStr(_totalLength)))
        Next
        Dim _numberOfTweets As Integer = Math.Ceiling(_totalLength / availableLength)
        Debug.Print("Number of tweets " & CStr(_numberOfTweets))
        Dim _numberOfNamesPerTweet As Integer = If(NudPersonsPerTweet.Value > 0, NudPersonsPerTweet.Value, Math.Ceiling(oPersonlist.Count / _numberOfTweets))
        Dim ListOfLists As List(Of List(Of Person)) = BuildLists(oPersonlist, availableLength, _numberOfNamesPerTweet)
        Return ListOfLists
    End Function

    Private Function GetTweetLineLength(_person As Person) As Integer
        Return _person.Name.Length + _person.Social.TwitterHandle.Length + If(_person.Social.TwitterHandle.Length > 0, 3, 1)
    End Function

    Private Function BuildLists(oPersonlist As List(Of Person), availableLength As Integer, _numberOfNamesPerTweet As Integer) As List(Of List(Of Person))
        Dim ListOfLists As New List(Of List(Of Person))
        Dim _ct As Integer = 0
        Dim _tweetSize As Integer = 0
        Debug.Print("-------------------------------")
        Do Until _ct = oPersonlist.Count
            Dim _tweetList As New List(Of Person)
            Dim _tweetCt As Integer = 0
            Do Until _ct = oPersonlist.Count OrElse _tweetCt = _numberOfNamesPerTweet
                Dim _person As Person = oPersonlist(_ct)
                _tweetSize += GetTweetLineLength(_person)
                _tweetList.Add(_person)
                Debug.Print(_person.Name & " " & CStr(_tweetSize))
                _tweetCt += 1
                _ct += 1
            Loop
            ListOfLists.Add(_tweetList)
            TxtStats.Text &= CStr(_tweetSize) & vbCrLf
            If _tweetSize > availableLength Then
                lblError.Visible = True
                TxtStats.Visible = True
            End If
            Debug.Print("-------------------------------" & CStr(_tweetSize))
            _tweetSize = 0
        Loop
        Return ListOfLists
    End Function

#End Region

End Class
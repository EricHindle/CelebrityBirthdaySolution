Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text
Imports TweetSharp

Public Class FrmTweet
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
    Private ReadOnly tw As New TwitterOAuth
#End Region
#Region "form control handlers"

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub GenerateImages()
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
                Dim _birthdayImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oBirthdayList, _dateLength + BIRTHDAY_HDR.Length, "B")
                oTweetLists.AddRange(_birthdayImageTweets)
                tabTitle = "Birthdays_"
                GeneratePictures(oTweetLists, tabTitle, _imageStart)
                _imageStart = oTweetLists.Count
                Dim _annivImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oAnniversaryList, _dateLength + ANNIV_HDR.Length, "A")
                oTweetLists.AddRange(_annivImageTweets)
                tabTitle = "Anniv_"
                GeneratePictures(oTweetLists, tabTitle, _imageStart)
            End If
            DisplayStatus("Images Complete")
        Else
            MsgBox("Select some people", MsgBoxStyle.Exclamation, "Error")
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
        For Each _page As TabPage In TabControl1.TabPages
            SaveImage(_page)
        Next
    End Sub
    Private Function SaveImage(_page As TabPage) As String
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _add As String = _page.Text
        Dim _fileName As String = Path.Combine(_path, _add.Replace("_", "_" & cboDay.SelectedItem & "_" & cboMonth.SelectedItem & "_mosaic_") & ".jpg")
        Dim _pictureBox As PictureBox = GetPictureBoxFromPage(_page)
        ImageUtil.saveImageFromPictureBox(_pictureBox, _pictureBox.Width, _pictureBox.Height, _fileName)
        DisplayStatus("File saved")
        Return _fileName
    End Function
    Private Sub FrmTwitterImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.twitterimagepos)
        GetAuthData()
        FillTwitterUserList()
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
#End Region
#Region "subroutines"
    Private Sub GeneratePictures(_tweetLists As List(Of List(Of Person)), _tabTitle As String, _imageStart As Integer)
        For _imageIndex As Integer = _imageStart To _tweetLists.Count - 1
            Dim _imageList As List(Of Person) = _tweetLists(_imageIndex)
            DisplayStatus(">" & CStr(_imageIndex), True)
            Dim newImageTabPage As TabPage = CreateNewImageTabPage(_imageIndex, _tabTitle & CStr(_imageIndex - _imageStart + 1))
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
    Private Sub GenerateText(_textBox As RichTextBox, _imageTable As List(Of Person), _type As String, _index As Integer, _numberOfLists As Integer)
        Dim _outString As New StringBuilder
        _outString.Append(cboMonth.SelectedItem).Append(" ").Append(cboDay.SelectedItem).Append(vbCrLf).Append(vbCrLf)
        _outString.Append(GetHeading(_type)).Append(vbCrLf)

        Dim _footer As String = If(_numberOfLists > 1, CStr(_index) & "/" & CStr(_numberOfLists), "")

        For Each _person As Person In _imageTable
            _outString.Append(_person.Name)
            If rbAges.Checked Then
                If _type.StartsWith("B") Then
                    _outString.Append(" (" & CStr(CalculateAgeNextBirthday(_person)) & ")")
                Else
                    _outString.Append(" (" & _person.BirthYear & ")")
                End If
            End If
            If rbHandles.Checked Then
                If _person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle) Then
                    _outString.Append(" @").Append(_person.Social.TwitterHandle)
                End If
            End If
            _outString.Append(vbCrLf)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(vbCrLf).Append(_footer).Append(vbCrLf)
        End If
        _textBox.Text = _outString.ToString
    End Sub
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
    Private Sub DisplayStatus(_text As String, Optional _isAppend As Boolean = False)
        If _isAppend Then
            LblStatus.Text &= _text
        Else
            LblStatus.Text = _text
        End If
        StatusStrip1.Refresh()
    End Sub
#End Region
#Region "functions"
    Private Function BuildLists(oPersonlist As List(Of Person), availableLength As Integer, _numberOfNamesPerTweet As Integer, _type As String) As List(Of List(Of Person))
        Dim ListOfLists As New List(Of List(Of Person))
        Dim _ct As Integer = 0
        Dim _tweetSize As Integer = 0
        Do Until _ct = oPersonlist.Count
            Dim _tweetList As New List(Of Person)
            Dim _tweetCt As Integer = 0
            Do Until _ct = oPersonlist.Count OrElse _tweetCt = _numberOfNamesPerTweet
                Dim _person As Person = oPersonlist(_ct)
                _tweetSize += GetTweetLineLength(_person, _type)
                _tweetList.Add(_person)
                _tweetCt += 1
                _ct += 1
            Loop
            ListOfLists.Add(_tweetList)
            TxtStats.Text &= CStr(_tweetSize) & vbCrLf
            If _tweetSize > availableLength Then
                lblError.Visible = True
                TxtStats.Visible = True
            End If
            _tweetSize = 0
        Loop
        Return ListOfLists
    End Function
    Private Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer, _type As String) As List(Of List(Of Person))
        Dim _totalLength As Integer = 0
        Dim availableLength As Integer = TWEET_SIZE - _headerLength
        For Each _person As Person In oPersonlist
            Dim _tweetLineLength As Integer = GetTweetLineLength(_person, _type)
            _totalLength += _tweetLineLength
        Next
        Dim _numberOfTweets As Integer = Math.Ceiling(_totalLength / availableLength)
        Dim _numberOfNamesPerTweet As Integer = If(NudPersonsPerTweet.Value > 0, NudPersonsPerTweet.Value, Math.Ceiling(oPersonlist.Count / _numberOfTweets))
        Dim ListOfLists As List(Of List(Of Person)) = BuildLists(oPersonlist, availableLength, _numberOfNamesPerTweet, _type)
        Return ListOfLists
    End Function
    Private Function GetTweetLineLength(_person As Person, _type As String) As Integer
        Return _person.Name.Length _
            + If(rbHandles.Checked, _person.Social.TwitterHandle.Length + If(_person.Social.TwitterHandle.Length > 0, 3, 1), 0) _
            + If(_type = "B" And rbAges.Checked, 5, 0) _
            + If(_type = "A" And rbAges.Checked, 7, 0)
    End Function
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
    Private Function CreateNewImageTabPage(_index As Integer, _tabTitle As String) As TabPage
        Dim newTabpage As New TabPage
        Dim tabTitle As String = _tabTitle
        With newTabpage
            .Text = tabTitle
            .TabIndex = _index
            '   .Location = New System.Drawing.Point(4, 22)
            .Name = "ImageTabPage_" & CStr(_index)
            .Padding = New System.Windows.Forms.Padding(3)
            .Size = New System.Drawing.Size(698, 574)
            .BackColor = Color.AliceBlue
            .Controls.Add(NewSplitContainer(newTabpage.TabIndex, newTabpage.Size.Width - 10, newTabpage.Size.Height - 10))

        End With
        Return newTabpage
    End Function
    Private Function NewSplitContainer(_index As Integer, _width As Integer, _height As Integer) As SplitContainer
        Dim _splitContainer As New SplitContainer With {
        .Location = New System.Drawing.Point(9, 6),
            .Size = New System.Drawing.Size(_width, _height),
            .SplitterDistance = 384
        }
        With _splitContainer
            .BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            .Location = New System.Drawing.Point(9, 6)
            .Name = "SplitContainer" & CStr(_index)
            .Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            .Panel1.BackColor = Color.AliceBlue
            .Panel1.Controls.Add(NewNumericUpDown(_index, 47, 521))
            .Panel1.Controls.Add(NewLabel(_index, 3, 522, "Width", "Label1"))
            .Panel1.Controls.Add(NewPictureBox(_index))
            Dim _newSendButton As Button = NewButton(_index, 213, 518, "Send", "BtnSend")
            .Panel1.Controls.Add(_newSendButton)
            AddHandler _newSendButton.Click, AddressOf BtnSendClick
            .Panel2.BackColor = Color.AliceBlue
            .Panel2.Controls.Add(NewRichTextBox(_index, _splitContainer.Panel2.Size.Width - 6, _splitContainer.Panel2.Size.Height - 6))
        End With
        Return _splitContainer
    End Function
    Private Function NewButton(_index As String, _locationX As Integer, _locationY As Integer, _text As String, _buttonNameBase As String) As Button
        Dim _button As New Button
        With _button
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            .Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .ForeColor = System.Drawing.Color.RoyalBlue
            .Location = New System.Drawing.Point(_locationX, _locationY)
            .Name = _buttonNameBase & _index
            .Size = New System.Drawing.Size(139, 33)
            .Text = _text
            .UseVisualStyleBackColor = True
        End With
        Return _button
    End Function
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
    Private Function NewNumericUpDown(_index As String, _locationX As Integer, _locationY As Integer) As NumericUpDown
        Dim _nud As New NumericUpDown
        With _nud
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            .Location = New System.Drawing.Point(_locationX, _locationY)
            .Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            .Name = NUD_BASENAME & _index
            .Size = New System.Drawing.Size(53, 22)
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            .Value = New Decimal(New Integer() {1, 0, 0, 0})
        End With
        AddHandler _nud.ValueChanged, AddressOf Horizontal_ValueChanged
        Return _nud
    End Function
    Private Function NewRichTextBox(_index As String, _width As Integer, _height As Integer) As RichTextBox
        Dim _newRtb As New System.Windows.Forms.RichTextBox()
        With _newRtb
            .Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
           Or System.Windows.Forms.AnchorStyles.Left) _
           Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            .Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .Location = New System.Drawing.Point(3, 3)
            .Name = RTB_CONTROL_NAME & _index
            .Size = New System.Drawing.Size(_width, _height)
            .Text = ""
            .ContextMenuStrip = ContextMenuStrip1
        End With
        Return _newRtb
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
    Private Function GetRichTextBoxFromPage(_tabPage As TabPage) As RichTextBox
        Dim _rtb As New RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & CStr(_tabPage.TabIndex)
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabPage)
        Dim _controls As Control() = _sc.Panel2.Controls.Find(_tabName, False)
        If _controls.Count > 0 Then
            _rtb = TryCast(_controls(0), RichTextBox)
        End If
        Return _rtb
    End Function
    Private Function GetSplitContainerFromPage(_tabPage As TabPage) As SplitContainer
        Dim _sc As New SplitContainer
        Dim _tabName As String = SC_BASENAME & CStr(_tabPage.TabIndex)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Count > 0 Then
            _sc = TryCast(_controls(0), SplitContainer)
        End If
        Return _sc
    End Function

    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        cboDay.SelectedIndex = Today.Day - 1
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        BuildTrees()
        GenerateImages()
    End Sub
    Private Sub BuildTrees()
        DisplayStatus("Selecting...")
        tvBirthday.Nodes.Clear()
        personTable.Clear()
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            Dim _day As Integer = cboDay.SelectedIndex + 1
            Dim _mth As Integer = cboMonth.SelectedIndex + 1
            Dim testDate As Date = New Date(2000, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1)
            personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, True)
            oBirthdayList = FindBirthdays(_day, _mth, True)
            oAnniversaryList = FindAnniversaries(_day, _mth, True)
            LblImageCount.Text = CStr(personTable.Count) + " people selected"
            AddTypeNode(oAnniversaryList, testDate, tvBirthday, "Anniversary")
            AddTypeNode(oBirthdayList, testDate, tvBirthday, "Birthday")
            DisplayStatus("Selection Complete")
        Else
            MsgBox("Select a date", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Function AddTypeNode(oBirthdayTable As List(Of Person), testDate As Date, _treeView As TreeView, _type As String) As TreeNode
        Dim newBirthdayNode As TreeNode = _treeView.Nodes.Add(Format(testDate, "MMMM dd") & _type, _type)
        newBirthdayNode.Checked = True
        For Each oPerson As Person In oBirthdayTable
            AddNameNode(newBirthdayNode, oPerson, _type)
        Next
        newBirthdayNode.Expand()
        Return newBirthdayNode
    End Function
    Private Function AddNameNode(newBirthdayNode As TreeNode, oPerson As Person, _type As String) As TreeNode
        Dim newNameNode As TreeNode = newBirthdayNode.Nodes.Add(oPerson.Name)
        If oPerson.Social IsNot Nothing Then
            If Not String.IsNullOrEmpty(oPerson.Social.TwitterHandle) Then
                Dim _twitterNode As TreeNode = newNameNode.Nodes.Add("twitter", oPerson.Social.TwitterHandle)
                _twitterNode.Checked = True
            End If
            newNameNode.Checked = True
            If oPerson.Social.IsNoTweet = True Then
                newNameNode.Checked = False
            End If
        End If
        newNameNode.Nodes.Add("id", oPerson.Id)
        newNameNode.Nodes.Add("desc", oPerson.ShortDesc)
        newNameNode.Nodes.Add("length", oPerson.Name.Length)
        newNameNode.Nodes.Add("year", oPerson.BirthYear)
        Dim _age As Integer = CalculateAgeNextBirthday(oPerson)
        Dim _ageNode As TreeNode = newNameNode.Nodes.Add("age", CStr(_age))
        _ageNode.Checked = (_type = "Birthday")
        Return newNameNode
    End Function
    Private Function CalculateAgeNextBirthday(oPerson As Person) As Integer
        Dim _dob As Date = New Date(oPerson.BirthYear, oPerson.BirthMonth, oPerson.BirthDay)
        Dim _thisMonth As Integer = Today.Month
        Dim _thisDay As Integer = Today.Day
        Dim _years As Integer = DateDiff(DateInterval.Year, _dob, Today)
        If _thisMonth > oPerson.BirthMonth OrElse (_thisMonth = oPerson.BirthMonth And _thisDay > oPerson.BirthDay) Then
            _years += 1
        End If
        Return _years
    End Function

    Private Sub BtnSendClick(sender As Object, e As EventArgs)
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            SendTweet(SaveImage(TabControl1.SelectedTab))
        Else
            Using _sendTweet As New FrmSendTwitter
                _sendTweet.TweetText = GetRichTextBoxFromPage(TabControl1.SelectedTab).Text
                _sendTweet.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub FillTwitterUserList()
        cmbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            cmbTwitterUsers.Items.Add(_user)
        Next
    End Sub

    Private Sub SendTweet(_filename As String)
        Dim isOkToSend As Boolean = True
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            Try
                Dim _auth As TwitterOAuth = GetAuthById(cmbTwitterUsers.SelectedItem)
                If _auth IsNot Nothing Then
                    If String.IsNullOrEmpty(_auth.Verifier) Then
                        isOkToSend = False
                    Else
                        tw.Verifier = _auth.Verifier
                    End If
                    If String.IsNullOrEmpty(_auth.Token) Then
                        isOkToSend = False
                    Else
                        tw.Token = _auth.Token
                    End If
                    If String.IsNullOrEmpty(_auth.TokenSecret) Then
                        isOkToSend = False
                    Else
                        tw.TokenSecret = _auth.TokenSecret
                    End If
                Else
                    isOkToSend = False
                End If
            Catch ex As Exception
                WriteTrace(ex.Message)
                isOkToSend = False
            End Try
        End If
        WriteTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
        If isOkToSend Then
            SendTheTweet(GetRichTextBoxFromPage(TabControl1.SelectedTab).Text, _filename)
        End If
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))

    End Sub

    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweet.Text &= vbCrLf & sText
        If isStatus Then DisplayStatus(sText)
    End Sub

    Private Sub SendTheTweet(_tweetText As String, Optional _filename As String = Nothing)
        DisplayStatus("Sending Tweet")
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = _tweetText
        sto.Status = msg.Substring(0, Math.Min(msg.Length, 280)) ' max tweet length; tweets fail if too long...
        Dim _mediaId As String = Nothing
        If chkImages.Checked Then
            Dim _twitterUplMedia As TwitterUploadedMedia = PostMedia(twitter, _filename)
            If _twitterUplMedia IsNot Nothing Then
                Dim _uploadedSize As Long = _twitterUplMedia.Size
                Dim _uploadedImage As UploadedImage = _twitterUplMedia.Image
                WriteTrace("Image upload size: " & CStr(_uploadedSize), False)
                _mediaId = _twitterUplMedia.Media_Id
            Else
                WriteTrace("No image upload", False)
            End If
        End If
        If Not String.IsNullOrEmpty(_mediaId) Then
            InsertTweet("", cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1, 1, _mediaId, cmbTwitterUsers.SelectedItem, "I")
            sto.MediaIds = {_mediaId}
        End If
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        If _twitterStatus IsNot Nothing Then
            InsertTweet(sto.Status, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
            WriteTrace("OK: " & _twitterStatus.Id, True)
        Else
            ' tweet failed
            WriteTrace("Failed", True)
        End If
    End Sub
    Private Sub GetAuthData()
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
    End Sub

    Private Sub BtnReGen_Click(sender As Object, e As EventArgs) Handles BtnReGen.Click
        GenerateImages()
    End Sub


#End Region
End Class
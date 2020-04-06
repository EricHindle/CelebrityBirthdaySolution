Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports TweetSharp

Public Class FrmTweet
#Region "constants"
    Private Const DEFAULT_WIDTH As Integer = 5
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
    Private isBuildingTrees As Boolean

#End Region
#Region "properties"
    Private _daySelection As Integer
    Private _monthSelection As Integer


    Public Property MonthSelection() As Integer
        Get
            Return _monthSelection
        End Get
        Set(ByVal value As Integer)
            _monthSelection = value
        End Set
    End Property
    Public Property DaySelection() As Integer
        Get
            Return _daySelection
        End Get
        Set(ByVal value As Integer)
            _daySelection = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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
    Private Sub RtbTextChanged(sender As Object, e As EventArgs)
        TxtStats.Text = ""
        For Each _page As TabPage In TabControl1.TabPages
            Dim _rtb As RichTextBox = GetRichTextBoxFromPage(_page)
            TxtStats.Text &= If(_rtb.TextLength >= TWEET_MAX_LEN, "** ", "") & _rtb.TextLength & vbCrLf
        Next
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        For Each _page As TabPage In TabControl1.TabPages
            SaveImage(_page)
        Next
    End Sub
    Private Sub FrmTwitterImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.twitterimagepos)
        GetAuthData()
        FillTwitterUserList()
        If Not String.IsNullOrEmpty(_daySelection) AndAlso Not String.IsNullOrEmpty(_monthSelection) Then
            cboDay.SelectedIndex = _daySelection - 1
            cboMonth.SelectedIndex = _monthSelection - 1
        End If
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
            My.Computer.Clipboard.SetText(_rtb.Text.Trim(vbLf))
        End If
    End Sub
    Private Sub CopyAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllToolStripMenuItem.Click
        Dim _rtb As RichTextBox = GetRichTextBoxFromPage(TabControl1.SelectedTab)
        My.Computer.Clipboard.Clear()
        If _rtb IsNot Nothing Then
            My.Computer.Clipboard.SetText(_rtb.Text)
        End If
    End Sub
    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        cboDay.SelectedIndex = Today.Day - 1
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If BuildTrees() Then
            GenerateAllTweets()
        Else
            DisplayStatus("No people selected")
        End If
    End Sub
    Private Sub BtnReGen_Click(sender As Object, e As EventArgs) Handles BtnReGen.Click
        GenerateAllTweets()
    End Sub
    Private Sub BtnBotsd_Click(sender As Object, e As EventArgs) Handles BtnBotsd.Click
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = cboDay.SelectedIndex + 1
            _botsd.ThisMonth = cboMonth.SelectedIndex + 1
            Dim _fullList As New List(Of Person)
            _fullList.AddRange(oBirthdayList)
            _fullList.AddRange(oAnniversaryList)
            Do Until _fullList.Count = 0
                Dim _sameYearList As New List(Of Person)
                Dim _person1 As Person = _fullList(0)
                _fullList.RemoveAt(0)
                For Each _person2 In _fullList
                    If _person1.DateOfBirth = _person2.DateOfBirth Then
                        _sameYearList.Add(_person2)
                    End If
                Next
                For Each _matchedPerson As Person In _sameYearList
                    _fullList.Remove(_matchedPerson)
                Next
                If _sameYearList.Count > 0 Then
                    _sameYearList.Add(_person1)
                    _botsd.AddList(_sameYearList)
                End If
            Loop
            Select Case True
                Case rbImageRight.Checked
                    _botsd.rbImageRight.Checked = True
                Case rbImageLeft.Checked
                    _botsd.rbImageLeft.Checked = True
                Case rbImageCentre.Checked
                    _botsd.rbImageCentre.Checked = True
            End Select

            _botsd.ShowDialog()
        End Using

    End Sub
    Private Sub BtnTotd_Click(sender As Object, e As EventArgs) Handles BtnTotd.Click
        If CountOfCheckedNames() = 1 Then
            Dim newPageIndex As Integer = TabControl1.TabCount
            Dim newTweetTabPage As TabPage = CreateNewTweetTabPage(newPageIndex, "Tweet of the Day")
            Dim rtbControl As RichTextBox = GetRichTextBoxFromPage(newTweetTabPage)
            Dim pbControl As PictureBox = GetPictureBoxFromPage(newTweetTabPage)
            For Each _topNode As TreeNode In tvBirthday.Nodes
                For Each _personNode As TreeNode In _topNode.Nodes
                    If _personNode.Checked Then
                        For Each _detailNode As TreeNode In _personNode.Nodes
                            If _detailNode.Name = "id" Then
                                Dim _person As Person = GetFullPersonById(CInt(_detailNode.Text))
                                rtbControl.Text = BuildTweetText(_person)
                                Dim _pictureList As New List(Of Person) From {_person}
                                GeneratePicture(pbControl, _pictureList, 1)
                            End If
                        Next
                    End If
                Next
            Next
            TabControl1.TabPages.Add(newTweetTabPage)
            RtbTextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Shared Function BuildTweetText(ByRef _person As Person) As String
        Dim _text As New StringBuilder
        Dim _died As String = " (d. " & CStr(Math.Abs(_person.DeathYear)) & If(_person.DeathYear < 0, " BCE", "") & ")"
        _text.Append("Born on ").Append(Format(_person.DateOfBirth, "d MMMM yyyy")) _
            .Append(vbCrLf) _
            .Append(vbCrLf) _
            .Append(_person.Description)
        If _person.BirthName.Length > 0 Or _person.BirthPlace.Length > 0 Then
            _text.Append(vbCrLf) _
            .Append(vbCrLf) _
            .Append("Born")
            If _person.BirthName.Length > 0 Then
                _text.Append(" ") _
                    .Append(_person.BirthName)
            End If
            If _person.BirthPlace.Length > 0 Then
                _text.Append(" in ") _
                    .Append(_person.BirthPlace)
            End If
            _text.Append(".")
        End If
        If _person.DeathYear <> 0 Then
            _text.Append(_died)
        End If
        Return _text.ToString
    End Function

    Private Sub BtnUncheck_Click(sender As Object, e As EventArgs) Handles BtnUncheck.Click
        For Each _node As TreeNode In tvBirthday.Nodes
            _node.Checked = False
            If _node.Nodes IsNot Nothing Then
                For Each subNode As TreeNode In _node.Nodes
                    subNode.Checked = False
                Next
            End If
        Next
    End Sub
#End Region
#Region "Form subroutines"
    Private Sub DisplayStatus(_text As String, Optional _isAppend As Boolean = False)
        If _isAppend Then
            LblStatus.Text &= _text
        Else
            LblStatus.Text = _text
        End If
        StatusStrip1.Refresh()
    End Sub
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
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweet.Text &= vbCrLf & sText
        If isStatus Then DisplayStatus(sText)
    End Sub
    Private Function SaveImage(_page As TabPage) As String
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _add As String = _page.Text
        Dim _fileName As String = Path.Combine(_path, _add.Replace("_", "_" & cboDay.SelectedItem & "_" & cboMonth.SelectedItem & "_") & ".jpg")
        If My.Computer.FileSystem.FileExists(_fileName) Then
            _fileName = GetUniqueFname(_fileName)
        End If
        Dim _pictureBox As PictureBox = GetPictureBoxFromPage(_page)
        ImageUtil.SaveImageFromPictureBox(_pictureBox, _pictureBox.Width, _pictureBox.Height, _fileName)
        DisplayStatus("File saved")
        Return _fileName
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
    Private Shared Function NewButton(_index As String, _locationX As Integer, _locationY As Integer, _text As String, _buttonNameBase As String) As Button
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
    Private Shared Function NewLabel(_index As String, _locationX As Integer, _locationY As Integer, _text As String, _labelNameBase As String) As Label
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
    Private Shared Function NewPictureBox(_index As String) As PictureBox
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
        AddHandler _newRtb.TextChanged, AddressOf RtbTextChanged
        Return _newRtb
    End Function
    Private Shared Function GetPictureBoxFromPage(_tabpage As TabPage) As PictureBox
        Dim _index As Integer = _tabpage.TabIndex
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabpage)
        Dim _controls As Control() = _sc.Panel1.Controls.Find(PICBOX_BASENAME & CStr(_index), False)
        If _controls.Any() Then
            For _controlIndex = 0 To _controls.GetUpperBound(0)
                If TryCast(_controls(_controlIndex), PictureBox) IsNot Nothing Then
                    Return _controls(_controlIndex)
                    Exit For
                End If
            Next
        End If
        Return Nothing
    End Function
    Private Shared Function GetNudFromPage(_tabpage As TabPage) As NumericUpDown
        Dim _index As Integer = _tabpage.TabIndex
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabpage)
        Dim _controls As Control() = _sc.Panel1.Controls.Find(NUD_BASENAME & CStr(_index), False)
        If _controls.Any() Then
            For _controlIndex = 0 To _controls.GetUpperBound(0)
                If TryCast(_controls(0), NumericUpDown) IsNot Nothing Then
                    Return _controls(_controlIndex)
                    Exit For
                End If
            Next
        End If
        Return Nothing
    End Function
    Private Shared Function GetRichTextBoxFromPage(_tabPage As TabPage) As RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & CStr(_tabPage.TabIndex)
        Dim _sc As SplitContainer = GetSplitContainerFromPage(_tabPage)
        Dim _controls As Control() = _sc.Panel2.Controls.Find(_tabName, False)
        If _controls.Any() Then
            For _controlIndex = 0 To _controls.GetUpperBound(0)
                If TryCast(_controls(_controlIndex), RichTextBox) IsNot Nothing Then
                    Return _controls(_controlIndex)
                    Exit For
                End If
            Next
        End If
        Return Nothing
    End Function
    Private Shared Function GetSplitContainerFromPage(_tabPage As TabPage) As SplitContainer
        Dim _tabName As String = SC_BASENAME & CStr(_tabPage.TabIndex)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Any() Then
            For _controlIndex = 0 To _controls.GetUpperBound(0)
                If TryCast(_controls(_controlIndex), SplitContainer) IsNot Nothing Then
                    Return _controls(_controlIndex)
                    Exit For
                End If
            Next
        End If
        Return Nothing
    End Function
#End Region
#Region "Tree subroutines"
    Private Function BuildTrees() As Boolean
        isBuildingTrees = True
        Dim isBuiltOk As Boolean = False
        DisplayStatus("Selecting...")
        tvBirthday.Nodes.Clear()
        personTable.Clear()
        Try
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
                isBuiltOk = True
            Else
                MsgBox("Select a date", MsgBoxStyle.Exclamation, "Error")
            End If
        Catch ex As ArgumentOutOfRangeException
            MsgBox("Exception" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Error")
            isBuiltOk = False
        End Try
        isBuildingTrees = False
        Return isBuiltOk
    End Function
    Private Shared Function AddTypeNode(oBirthdayTable As List(Of Person), testDate As Date, _treeView As TreeView, _type As String) As TreeNode
        Dim newBirthdayNode As TreeNode = _treeView.Nodes.Add(Format(testDate, "MMMM dd") & _type, _type)
        newBirthdayNode.Checked = True
        For Each oPerson As Person In oBirthdayTable
            AddNameNode(newBirthdayNode, oPerson, _type)
        Next
        newBirthdayNode.Expand()
        Return newBirthdayNode
    End Function
    Private Shared Function AddNameNode(newBirthdayNode As TreeNode, oPerson As Person, _type As String) As TreeNode
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
    Private Shared Function CalculateAgeNextBirthday(oPerson As Person) As Integer
        Dim _years As Integer = 0
        If oPerson.BirthYear > 0 Then
            Dim _dob As Date = New Date(oPerson.BirthYear, oPerson.BirthMonth, oPerson.BirthDay)
            Dim _thisMonth As Integer = Today.Month
            Dim _thisDay As Integer = Today.Day
            _years = DateDiff(DateInterval.Year, _dob, Today)
            If _thisMonth > oPerson.BirthMonth OrElse (_thisMonth = oPerson.BirthMonth And _thisDay > oPerson.BirthDay) Then
                _years += 1
            End If
        End If
        Return _years
    End Function
    Private Function CountOfCheckedNames() As Integer
        Dim _count As Integer = 0
        For Each _node As TreeNode In tvBirthday.Nodes
            If _node IsNot Nothing Then
                For Each subNode As TreeNode In _node.Nodes
                    If subNode.Checked Then _count += 1
                Next
            End If
        Next
        Return _count
    End Function
#End Region
#Region "Tweet subroutines"
    Private Sub GenerateAllTweets()
        DisplayStatus("Generating tweets")
        TxtStats.Text = ""
        If cboDay.SelectedIndex > -1 AndAlso cboMonth.SelectedIndex > -1 Then
            TabControl1.TabPages.Clear()
            TabControl1.Refresh()
            Dim tabTitle As String
            Dim _imageStart As Integer = 0
            Dim _dateLength As Integer = cboDay.SelectedItem.length + cboMonth.SelectedItem.length + 1
            oTweetLists = New List(Of List(Of Person))
            If RbSingleImage.Checked Then
                Dim _selectedPersons As New List(Of Person)
                For Each _node As TreeNode In tvBirthday.Nodes
                    For Each _nameNode As TreeNode In _node.Nodes
                        If _nameNode.Checked Then
                            For Each _dataNode As TreeNode In _nameNode.Nodes
                                If _dataNode.Name = "id" Then
                                    _selectedPersons.Add(GetPersonById(CInt(_dataNode.Text)))
                                End If
                            Next
                        End If
                    Next
                Next
                oTweetLists.Add(_selectedPersons)
                tabTitle = "Full_"
                GenerateTweets(oTweetLists, tabTitle, _imageStart)
            Else
                Dim _birthdayImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oBirthdayList, _dateLength + BIRTHDAY_HDR.Length + 3, "B")
                oTweetLists.AddRange(_birthdayImageTweets)
                tabTitle = "Birthdays_"
                GenerateTweets(oTweetLists, tabTitle, _imageStart)
                _imageStart = oTweetLists.Count
                Dim _annivImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oAnniversaryList, _dateLength + ANNIV_HDR.Length + 3, "A")
                oTweetLists.AddRange(_annivImageTweets)
                tabTitle = "Anniv_"
                GenerateTweets(oTweetLists, tabTitle, _imageStart)
            End If
            DisplayStatus("Images Complete")
        Else
            MsgBox("Select some people", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Sub GenerateTweets(_tweetLists As List(Of List(Of Person)), _tabTitle As String, _listStart As Integer)
        For _personIndex As Integer = _listStart To _tweetLists.Count - 1
            Dim _personList As List(Of Person) = _tweetLists(_personIndex)
            DisplayStatus(">" & CStr(_personIndex), True)
            Dim newTweetTabPage As TabPage = CreateNewTweetTabPage(_personIndex, _tabTitle & CStr(_personIndex - _listStart + 1))
            Dim pbControl As PictureBox = GetPictureBoxFromPage(newTweetTabPage)
            Dim rtbControl As RichTextBox = GetRichTextBoxFromPage(newTweetTabPage)
            IsNoGenerate = True
            TabControl1.TabPages.Add(newTweetTabPage)
            GetNudFromPage(newTweetTabPage).Value = DEFAULT_WIDTH
            Dim _width As Integer = DEFAULT_WIDTH
            GeneratePicture(pbControl, _personList, _width)
            GenerateText(rtbControl, _personList, _tabTitle.Substring(0, 1), _personIndex - _listStart + 1, _tweetLists.Count - _listStart)
            IsNoGenerate = False
        Next
    End Sub
    Private Sub GenerateText(_textBox As RichTextBox, _imageTable As List(Of Person), _type As String, _index As Integer, _numberOfLists As Integer)
        Dim _outString As New StringBuilder
        _outString.Append(cboMonth.SelectedItem).Append(" ").Append(cboDay.SelectedItem).Append(vbLf).Append(vbLf)
        _outString.Append(GetHeading(_type)).Append(vbLf)
        Dim _footer As String = If(_numberOfLists > 1, CStr(_index) & "/" & CStr(_numberOfLists), "")
        For Each _person As Person In _imageTable
            _outString.Append(_person.Name)
            If rbAges.Checked Then
                If _type.StartsWith("B", StringComparison.CurrentCultureIgnoreCase) Then
                    _outString.Append(" (" & CStr(CalculateAgeNextBirthday(_person)) & ")")
                Else
                    Dim _yr As Integer = CInt(_person.BirthYear)
                    Dim _birthyear As String = CStr(Math.Abs(_yr))
                    If _yr < 0 Then
                        _birthyear &= " BCE"
                    End If
                    _outString.Append(" (" & _birthyear & ")")
                End If
            End If
            If rbHandles.Checked Then
                If _person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle) Then
                    _outString.Append(" @").Append(_person.Social.TwitterHandle)
                End If
            End If
            _outString.Append(vbLf)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(vbLf).Append(_footer)
        End If
        _textBox.Text = _outString.ToString.Trim(vbLf)
    End Sub
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer)
        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            GenerateTweetImage(_pictureBox, _imageTable, _width, _height)
        Else
            _pictureBox.Image = Nothing
        End If
    End Sub
    Private Sub GenerateTweetImage(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer, _height As Integer)
        Dim pAlignType As ImageUtil.AlignType
        Select Case True
            Case rbImageRight.Checked
                pAlignType = ImageUtil.AlignType.Right
            Case rbImageLeft.Checked
                pAlignType = ImageUtil.AlignType.Left
            Case rbImageCentre.Checked
                pAlignType = ImageUtil.AlignType.Centre
        End Select
        ImageUtil.GenerateImage(_pictureBox, _imageTable, _width, _height, pAlignType)
        DisplayStatus("Image complete", False)
    End Sub
    Private Sub SendTweet(_filename As String)
        Dim isOkToSend As Boolean = True
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            isOkToSend = SetupOAuth(isOkToSend)
        End If
        WriteTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
        If isOkToSend Then
            SendTheTweet(GetRichTextBoxFromPage(TabControl1.SelectedTab).Text, _filename)
        End If
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))
    End Sub
    Private Function SetupOAuth(isOkToSend As Boolean) As Boolean
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

        Return isOkToSend
    End Function
    Private Sub SendTheTweet(_tweetText As String, Optional _filename As String = Nothing)
        DisplayStatus("Sending Tweet")
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = _tweetText
        sto.Status = msg.Substring(0, Math.Min(msg.Length, TWEET_MAX_LEN)) ' max tweet length; tweets fail if too long...
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
        If _auth IsNot Nothing Then
            tw.ConsumerKey = _auth.Token
            tw.ConsumerSecret = _auth.TokenSecret
        End If
    End Sub
    Private Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer, _type As String) As List(Of List(Of Person))
        Dim availableLength As Integer = TWEET_MAX_LEN - _headerLength
        Dim _totalLengthOfTweet As Integer = 0
        Dim _lengthsText As String = ""
        Dim _numberOfTweets As Integer = GetExpectedNumberOfTweets(oPersonlist, _type, availableLength, _totalLengthOfTweet)
        Dim _startIndex As Integer = 0
        Dim _endIndex As Integer = oPersonlist.Count - 1

        Dim _numberOfNamesPerTweet As Integer = GetNumberOfPersonsPerTweet(oPersonlist.Count, _type, _numberOfTweets)

        Dim ListOfLists As New List(Of List(Of Person))
        Do Until _startIndex > _endIndex
            Dim _rangeCount As Integer = Math.Min(_numberOfNamesPerTweet, _endIndex + 1)
            Dim _range As List(Of Person) = oPersonlist.GetRange(_endIndex - _rangeCount + 1, _rangeCount)
            Dim _numberOfNamesThisTweet As Integer = _numberOfNamesPerTweet
            Do Until GetExpectedNumberOfTweets(_range, _type, availableLength, _totalLengthOfTweet) = 1
                _numberOfNamesThisTweet -= 1
                _rangeCount = Math.Min(_numberOfNamesThisTweet, _endIndex + 1)
                _range = oPersonlist.GetRange(_endIndex - _rangeCount + 1, _rangeCount)
            Loop
            _lengthsText = CStr(_totalLengthOfTweet) & vbCrLf & _lengthsText
            ListOfLists.Add(BuildList(_range))
            _endIndex -= _rangeCount
        Loop
        TxtStats.Text &= _lengthsText
        ListOfLists.Reverse()
        Return ListOfLists
    End Function
    Private Function GetNumberOfPersonsPerTweet(oPersonListCount As Integer, _type As String, oNumberOfTweets As Integer) As Integer
        Dim _nudValue As Integer
        Dim _numberOfPersonsPerTweet As Integer
        Try
            If _type.ToLower(myCultureInfo) = "b" Then
                _nudValue = NudBirthdaysPerTweet.Value
            Else
                _nudValue = NudAnnivsPerTweet.Value
            End If
            If _nudValue > 0 Then
                _numberOfPersonsPerTweet = _nudValue
            Else
                _numberOfPersonsPerTweet = Math.Ceiling(oPersonListCount / oNumberOfTweets)
            End If
        Catch ex As OverflowException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Overflow")
        End Try

        Return _numberOfPersonsPerTweet
    End Function
    Private Shared Function BuildList(oPersonList As List(Of Person)) As List(Of Person)
        Dim _tweetList As New List(Of Person)
        For Each oPerson As Person In oPersonList
            _tweetList.Add(oPerson)
        Next
        Return _tweetList
    End Function
    Private Function GetExpectedNumberOfTweets(oPersonlist As List(Of Person), _type As String, availableLength As Integer, ByRef _totalLength As Integer) As Integer
        _totalLength = GetTotalLengthOfTweet(oPersonlist, _type)
        Return Math.Ceiling(_totalLength / availableLength)
    End Function
    Private Function GetTotalLengthOfTweet(oPersonlist As List(Of Person), _type As String) As Integer
        Dim _totalLength As Integer = 0
        For Each _person As Person In oPersonlist
            Dim _tweetLineLength As Integer = GetTweetLineLength(_person, _type)
            _totalLength += _tweetLineLength
        Next
        Return _totalLength
    End Function
    Private Function GetTweetLineLength(_person As Person, _type As String) As Integer
        Dim _length As Integer = _person.Name.Length _
            + If(rbHandles.Checked, _person.Social.TwitterHandle.Length + If(_person.Social.TwitterHandle.Length > 0, 2, 0), 0) _
            + If(_type = "B" And rbAges.Checked, 5, 0) _
            + If(_type = "A" And rbAges.Checked, 7, 0) _
            + 1
        Return _length
    End Function
    Private Shared Function GetHeading(_typeNode As String) As String
        Dim _header As String = ""
        If _typeNode.StartsWith("A", True, myCultureInfo) Then
            _header = ANNIV_HDR
        End If
        If _typeNode.StartsWith("B", True, myCultureInfo) Then
            _header = BIRTHDAY_HDR
        End If
        Return _header
    End Function
    Private Function CreateNewTweetTabPage(_index As Integer, _tabTitle As String) As TabPage
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

    Private Sub DateSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        NudBirthdaysPerTweet.Value = 0
        NudAnnivsPerTweet.Value = 0
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing Then
                If personTable IsNot Nothing Then
                    For Each oPerson In personTable
                        oPerson.Dispose()
                    Next
                End If
                If oAnniversaryList IsNot Nothing Then
                    For Each oPerson In oAnniversaryList
                        oPerson.Dispose()
                    Next
                End If
                If oBirthdayList IsNot Nothing Then
                    For Each oPerson In oBirthdayList
                        oPerson.Dispose()
                    Next
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Private Sub TvBirthday_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvBirthday.AfterCheck
    '    If Not isBuildingTrees Then
    '        Dim node As TreeNode = e.Node
    '        Dim ischecked As Boolean = node.Checked
    '        Try

    '        Catch sysex As System.StackOverflowException
    '            Debug.Print(sysex.Message)
    '        Catch ex As Exception
    '            Debug.Print(ex.Message)
    '        End Try
    '    End If
    'End Sub
#End Region
End Class
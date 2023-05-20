' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports TweetSharp

Public NotInheritable Class FrmDailyTweets
#Region "enum"
    Private Enum TweetType
        Birthday
        Anniversary
        Full
    End Enum
#End Region
#Region "constants"
    Private Const NUD_BASENAME As String = "NudHorizontal"
    Private Const PICBOX_BASENAME As String = "pictureBox"
    Private Const SC_BASENAME As String = "SplitContainer"
    Private ReadOnly LINE_FEED As Char = Convert.ToChar(vbLf, myStringFormatProvider)
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
        Close()
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        ClearImages(False)
        SaveImages()
    End Sub
    Private Sub FrmTwitterImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.twitterDailyFormPos)
        GetAuthData()
        FillTwitterUserList()
        If Not String.IsNullOrEmpty(_daySelection) AndAlso Not String.IsNullOrEmpty(_monthSelection) Then
            cboDay.SelectedIndex = _daySelection - 1
            cboMonth.SelectedIndex = _monthSelection - 1
        End If
    End Sub
    Private Sub FrmTwitterImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.twitterDailyFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub Btnopyselected_Click(sender As Object, e As EventArgs) Handles BtnCopyselected.Click, CopyToolStripMenuItem.Click
        DisplayAndLog("Copy selected text")
        Dim _rtb As RichTextBox = GetRichTextBoxFromPage(TabControl1.SelectedTab)
        My.Computer.Clipboard.Clear()
        If _rtb IsNot Nothing AndAlso Not String.IsNullOrEmpty(_rtb.SelectedText) Then
            My.Computer.Clipboard.SetText(_rtb.SelectedText)
        End If
    End Sub
    Private Sub BtnCopyAll_Click(sender As Object, e As EventArgs) Handles BtnCopyAll.Click
        DisplayAndLog("Copy text")
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
        DisplayAndLog("Selecting people")
        SelectPeople()
    End Sub
    Private Sub BtnReGen_Click(sender As Object, e As EventArgs) Handles BtnReGen.Click
        GenerateAllTweets()
    End Sub
    Private Sub BtnTotd_Click(sender As Object, e As EventArgs) Handles BtnTotd.Click
        If CountOfCheckedNames() = 1 Then
            Dim newPageIndex As Integer = TabControl1.TabCount
            Dim newTweetTabPage As TabPage = CreateNewTweetTabPage(newPageIndex, My.Resources.TOTD)
            Dim rtbControl As RichTextBox = GetRichTextBoxFromPage(newTweetTabPage)
            Dim pbControl As PictureBox = GetPictureBoxFromPage(newTweetTabPage)
            For Each _topNode As TreeNode In tvBirthday.Nodes
                For Each _personNode As TreeNode In _topNode.Nodes
                    If _personNode.Checked Then
                        For Each _detailNode As TreeNode In _personNode.Nodes
                            If _detailNode.Name = "id" Then
                                Dim _person As Person = GetFullPersonById(_detailNode.Text)
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
    Private Sub DateSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        NudBirthdaysPerTweet.Value = 0
        NudAnnivsPerTweet.Value = 0
    End Sub
    Private Sub BtnDeleteImages_Click(sender As Object, e As EventArgs) Handles BtnDeleteImages.Click
        ClearImages()
    End Sub
    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            SetFormDate(GetDateFromForm().AddDays(1))
            SelectPeople()
            ClearImages(False)
            SaveImages()
        End If
    End Sub
    Private Sub BtnExplorer_Click(sender As Object, e As EventArgs) Handles BtnExplorer.Click
        DisplayAndLog("Opening explorer")
        Dim p As New ProcessStartInfo With {
            .FileName = "explorer.exe",
            .Arguments = My.Settings.twitterImageFolder
        }
        Process.Start(p)
    End Sub
    Private Sub BtnTweetDeck_Click(sender As Object, e As EventArgs) Handles BtnTweetDeck.Click
        DisplayAndLog("Opening tweetdeck")
        Try
            Process.Start(My.Resources.TWEETDECKURL)
        Catch ex As InvalidOperationException
            ShowStatus("Error opening tweetdeck", LblStatus, True, MyBase.Name, ex)
        Catch ex As ComponentModel.Win32Exception
            ShowStatus("Error opening tweetdeck", LblStatus, True, MyBase.Name, ex)
        End Try
    End Sub
#End Region
#Region "Form subroutines"
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
    Private Sub SelectPeople()
        If BuildTrees() Then
            GenerateAllTweets()
        Else
            DisplayAndLog("No people selected")
        End If
    End Sub
    Private Sub SaveImages()
        DisplayAndLog("Saving tweet images")
        For Each _page As TabPage In TabControl1.TabPages
            SaveImage(_page)
        Next
    End Sub
    Private Sub BtnSendClick(sender As Object, e As EventArgs)
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            SendTweet(SaveImage(TabControl1.SelectedTab))
        Else
            Using _sendTweet As New FrmSingleTweet
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
    Private Sub WriteTrace(sText As String, Optional isLogged As Boolean = False)
        rtbTweet.Text &= vbCrLf & sText
        If isLogged Then LogUtil.Info(sText, MyBase.Name)
    End Sub
    Private Function SaveImage(_page As TabPage) As String
        DisplayAndLog("Saving File")
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
        DisplayAndLog("File saved")
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
            .Name = "SplitContainer" & _index
            .Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom _
                Or System.Windows.Forms.AnchorStyles.Left _
                Or System.Windows.Forms.AnchorStyles.Right
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
            .Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right
            .Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
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
            .Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
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
            .Anchor = System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left
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
            .Anchor = System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom _
           Or System.Windows.Forms.AnchorStyles.Left _
           Or System.Windows.Forms.AnchorStyles.Right
            .Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0)
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
        Dim _controls As Control() = _sc.Panel1.Controls.Find(PICBOX_BASENAME & _index, False)
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
        Dim _controls As Control() = _sc.Panel1.Controls.Find(NUD_BASENAME & _index, False)
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
        Dim _tabName As String = RTB_CONTROL_NAME & _tabPage.TabIndex
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
        Dim _tabName As String = SC_BASENAME & _tabPage.TabIndex
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
    Private Sub ClearImages(Optional isConfirm As Boolean = True)
        If Not isConfirm OrElse MsgBox("Confirm delete tweet images", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            DisplayAndLog("Deleting tweet images")
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.twitterImageFolder,
                                                                                              FileIO.SearchOption.SearchTopLevelOnly,
                                                                                              {[Enum].GetName(GetType(TweetType), TweetType.Anniversary) & "*.*", [Enum].GetName(GetType(TweetType), TweetType.Birthday) & "*.*", My.Resources.TOTD & "*.*"})
            For Each _imageFile As String In _imageList
                My.Computer.FileSystem.DeleteFile(_imageFile)
            Next
        End If
    End Sub
    Private Sub SetFormDate(selDate As Date)
        cboDay.SelectedIndex = selDate.Day - 1
        cboMonth.SelectedIndex = selDate.Month - 1
    End Sub
    Private Function GetDateFromForm() As Date
        Return New Date(2000, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1)
    End Function
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
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, LblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, LblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
#End Region
#Region "Tree subroutines"
    Private Function BuildTrees() As Boolean
        DisplayAndLog("Building trees")
        isBuildingTrees = True
        Dim isBuiltOk As Boolean = False
        DisplayAndLog("Selecting...")
        tvBirthday.Nodes.Clear()
        personTable.Clear()
        Try
            If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
                Dim _day As Integer = cboDay.SelectedIndex + 1
                Dim _mth As Integer = cboMonth.SelectedIndex + 1
                Dim testDate As New Date(2000, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1)
                personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, True)
                oBirthdayList = FindBirthdays(_day, _mth, True)
                oAnniversaryList = FindAnniversaries(_day, _mth, True)
                LblImageCount.Text = CStr(personTable.Count) + " people selected"
                AddTypeNode(oAnniversaryList, testDate, tvBirthday, My.Resources.ANNIVERSARY)
                AddTypeNode(oBirthdayList, testDate, tvBirthday, My.Resources.BIRTHDAY)
                DisplayAndLog("Selection Complete")
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
    Private Shared Function BuildTweetText(ByRef _person As Person) As String
        Dim _text As New StringBuilder
        Dim _died As String = " (d. " & Math.Abs(_person.DeathYear) & If(_person.DeathYear < 0, " BCE", "") & ")"
        _text.Append("Born on ").Append(Format(_person.DateOfBirth, "d MMMM yyyy")) _
            .Append(vbCrLf) _
            .Append(vbCrLf) _
            .Append(_person.Description)
        If _person.BirthName.Length > 0 Or _person.BirthPlace.Length > 0 Then
            _text.Append(vbCrLf) _
            .Append(vbCrLf) _
            .Append("Born")
            If _person.BirthName.Length > 0 Then
                _text.Append(" "c) _
                    .Append(_person.BirthName)
            End If
            If _person.BirthPlace.Length > 0 Then
                _text.Append(" in ") _
                    .Append(_person.BirthPlace)
            End If
            _text.Append("."c)
        End If
        If _person.DeathYear <> 0 Then
            _text.Append(_died)
        End If
        Return _text.ToString
    End Function
    Private Sub GenerateAllTweets()
        DisplayAndLog("Generating all tweets")
        TxtStats.Text = ""
        If cboDay.SelectedIndex > -1 AndAlso cboMonth.SelectedIndex > -1 Then
            TabControl1.TabPages.Clear()
            TabControl1.Refresh()
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
                                    _selectedPersons.Add(GetPersonById(_dataNode.Text))
                                End If
                            Next
                        End If
                    Next
                Next
                oTweetLists.Add(_selectedPersons)
                GenerateTweets(oTweetLists, _imageStart, TweetType.FULL)
            Else
                Dim _birthdayImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oBirthdayList, _dateLength + BIRTHDAY_HDR.Length + 3, TweetType.BIRTHDAY)
                oTweetLists.AddRange(_birthdayImageTweets)
                GenerateTweets(oTweetLists, _imageStart, TweetType.BIRTHDAY)
                _imageStart = oTweetLists.Count
                Dim _annivImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oAnniversaryList, _dateLength + ANNIV_HDR.Length + 3, TweetType.ANNIVERSARY)
                oTweetLists.AddRange(_annivImageTweets)
                GenerateTweets(oTweetLists, _imageStart, TweetType.ANNIVERSARY)
            End If
            DisplayAndLog("Images Complete")
        Else
            MsgBox("Select some people", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub
    Private Sub GenerateTweets(_tweetLists As List(Of List(Of Person)), _listStart As Integer, _tweetType As TweetType)
        For _personIndex As Integer = _listStart To _tweetLists.Count - 1

            Dim _personList As List(Of Person) = _tweetLists(_personIndex)
            DisplayAndLog(">" & _personIndex)
            Dim newTweetTabPage As TabPage = CreateNewTweetTabPage(_personIndex, [Enum].GetName(GetType(TweetType), _tweetType) & "_" & (_personIndex - _listStart + 1))
            Dim pbControl As PictureBox = GetPictureBoxFromPage(newTweetTabPage)
            Dim rtbControl As RichTextBox = GetRichTextBoxFromPage(newTweetTabPage)
            IsNoGenerate = True
            TabControl1.TabPages.Add(newTweetTabPage)
            Dim personCt As Integer = _personList.Count
            Dim colCt As Integer
            If personCt <= 12 Then
                colCt = Math.Ceiling(personCt / 2)
            Else
                colCt = 6
                Dim list5 As New List(Of Integer)({13, 14, 15, 18, 19, 20})
                If list5.Contains(personCt) Then
                    colCt = 5
                End If
            End If
            GetNudFromPage(newTweetTabPage).Value = colCt
            Dim _width As Integer = colCt
            GeneratePicture(pbControl, _personList, _width)
            GenerateText(rtbControl, _personList, _tweetType, _personIndex - _listStart + 1, _tweetLists.Count - _listStart)
            IsNoGenerate = False
        Next
    End Sub
    Private Sub GenerateText(_textBox As RichTextBox, _imageTable As List(Of Person), _type As TweetType, _index As Integer, _numberOfLists As Integer)
        DisplayAndLog("Generating text")
        Dim _outString As New StringBuilder
        _outString.Append(cboMonth.SelectedItem).Append(" "c).Append(cboDay.SelectedItem).Append(LINE_FEED).Append(LINE_FEED)
        _outString.Append(GetHeading(_type)).Append(LINE_FEED)
        Dim _footer As String = If(_numberOfLists > 1, _index & "/" & _numberOfLists, "")
        For Each _person As Person In _imageTable
            _outString.Append(_person.Name)
            If rbAges.Checked Then
                If _type = TweetType.BIRTHDAY Then
                    _outString.Append(" (" & CalculateAge(_person, ChkAtNextBirthday.Checked) & ")")
                Else
                    Dim _yr As Integer = _person.BirthYear
                    Dim _birthyear As String = Math.Abs(_yr)
                    If _yr < 0 Then
                        _birthyear &= " BCE"
                    End If
                    _outString.Append(" (" & _birthyear & ")")
                End If
            End If
            If rbHandles.Checked And _type = TweetType.BIRTHDAY Then
                If _person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle) Then
                    _outString.Append(" @").Append(_person.Social.TwitterHandle)
                End If
            End If
            _outString.Append(LINE_FEED)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(LINE_FEED).Append(_footer)
        End If
        _textBox.Text = _outString.ToString.Trim(LINE_FEED)
    End Sub
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer)
        DisplayAndLog("Generating picture")
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
        DisplayAndLog("Image complete")
    End Sub
    Private Sub SendTweet(_filename As String)
        Dim isOkToSend As Boolean = True
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            isOkToSend = SetupOAuth(isOkToSend)
        End If
        WriteTrace("Entering SendTweet " & Format(Now, "hh:mm:ss"), True)
        If isOkToSend Then
            SendTheTweet(GetRichTextBoxFromPage(TabControl1.SelectedTab).Text, _filename)
        End If
        WriteTrace("Back from SendTweet " & Format(Now, "hh:mm:ss"), True)
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
        DisplayAndLog("Sending Tweet as " & cmbTwitterUsers.SelectedItem)
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
                WriteTrace("Image upload size: " & _uploadedSize, True)
                _mediaId = _twitterUplMedia.Media_Id
            Else
                WriteTrace("No image upload", True)
            End If
        End If
        If Not String.IsNullOrEmpty(_mediaId) Then
            InsertTweet(_filename, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1, 1, _mediaId, cmbTwitterUsers.SelectedItem, "I")
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
    Private Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer, _type As TweetType) As List(Of List(Of Person))
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
            _lengthsText = _totalLengthOfTweet & vbCrLf & _lengthsText
            ListOfLists.Add(BuildList(_range))
            _endIndex -= _rangeCount
        Loop
        TxtStats.Text &= _lengthsText
        ListOfLists.Reverse()
        Return ListOfLists
    End Function
    Private Function GetNumberOfPersonsPerTweet(oPersonListCount As Integer, _type As TweetType, oNumberOfTweets As Integer) As Integer
        Dim _nudValue As Integer
        Dim _numberOfPersonsPerTweet As Integer
        Try
            If _type = TweetType.BIRTHDAY Then
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
    Private Function GetExpectedNumberOfTweets(oPersonlist As List(Of Person), _type As TweetType, availableLength As Integer, ByRef _totalLength As Integer) As Integer
        _totalLength = GetTotalLengthOfTweet(oPersonlist, _type)
        Return Math.Ceiling(_totalLength / availableLength)
    End Function
    Private Function GetTotalLengthOfTweet(oPersonlist As List(Of Person), _type As TweetType) As Integer
        Dim _totalLength As Integer = 0
        For Each _person As Person In oPersonlist
            Dim _tweetLineLength As Integer = GetTweetLineLength(_person, _type)
            _totalLength += _tweetLineLength
        Next
        Return _totalLength
    End Function
    Private Function GetTweetLineLength(_person As Person, _type As TweetType) As Integer
        Dim _length As Integer = _person.Name.Length _
            + If(rbHandles.Checked, _person.Social.TwitterHandle.Length + If(_person.Social.TwitterHandle.Length > 0, 2, 0), 0) _
            + If(_type = TweetType.BIRTHDAY And rbAges.Checked, 5, 0) _
            + If(_type = TweetType.ANNIVERSARY And rbAges.Checked, 7, 0) _
            + 1
        Return _length
    End Function
    Private Shared Function GetHeading(_type As TweetType) As String
        Dim _header As String = ""
        If _type = TweetType.ANNIVERSARY Then
            _header = ANNIV_HDR
        End If
        If _type = TweetType.BIRTHDAY Then
            _header = BIRTHDAY_HDR
        End If
        Return _header
    End Function
    Private Function CreateNewTweetTabPage(_index As Integer, _tabTitle As String) As TabPage
        DisplayAndLog("New tab " & _tabTitle)
        Dim newTabpage As New TabPage
        Dim tabTitle As String = _tabTitle
        With newTabpage
            .Text = tabTitle
            .TabIndex = _index
            '   .Location = New System.Drawing.Point(4, 22)
            .Name = "ImageTabPage_" & _index
            .Padding = New System.Windows.Forms.Padding(3)
            .Size = New System.Drawing.Size(698, 574)
            .BackColor = Color.AliceBlue
            .Controls.Add(NewSplitContainer(newTabpage.TabIndex, newTabpage.Size.Width - 10, newTabpage.Size.Height - 10))
        End With
        Return newTabpage
    End Function

#End Region
End Class
Imports System.IO

Public Class frmTwitterOutput
#Region "variables"
    Dim _search As frmSearchDb = Nothing
#End Region
#Region "constants"
    Private Const ANNIV_HDR As String = "Today is the anniversary of the birth of"
    Private Const BIRTHDAY_HDR As String = "Happy birthday today to"
    Private Const TWEET_SIZE As Integer = 279
    Private Const RTB_CONTROL_NAME As String = "RtbFile"
    Private Const BUTTON_CONTROL_NAME As String = "BtnRewrite"
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        BuildTrees()
    End Sub
    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click
        WriteFiles()
    End Sub
    Private Sub FrmTwitterOutput_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _search IsNot Nothing AndAlso Not _search.IsDisposed Then
            _search.Close()
        End If
    End Sub
    Private Sub DtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged, dtpTo.ValueChanged
        tvBirthday.Nodes.Clear()
        tvBirthday.Nodes.Clear()
    End Sub
    Private Sub FrmTwitterOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = DateAdd(DateInterval.Day, 1, Today.Date)
        dtpTo.Value = DateAdd(DateInterval.Day, -1, New Date(Today.Year, DateAdd(DateInterval.Month, 1, Today.Date).Month, 1))
    End Sub
    Private Sub TvBirthday_DoubleClick(sender As Object, e As EventArgs) Handles tvBirthday.DoubleClick
        Dim _thisView As TreeView = TryCast(sender, TreeView)
        Dim _thisNode As TreeNode = _thisView.SelectedNode
        Using _browser As New FrmBrowser
            _browser.SearchName = _thisNode.Text
            _browser.FindinWiki()
            _browser.ShowDialog()
        End Using
    End Sub
    Private Sub BtnRewrite_Click(sender As Object, e As System.EventArgs)
        Dim _button As Button = TryCast(sender, Button)
        Dim _tabpage As TabPage = TryCast(_button.Parent, TabPage)
        Dim _index As String = GetTabNumber(_tabpage)
        Dim _filename As String = _tabpage.Text
        Dim _rtb As RichTextBox = TryCast(_tabpage.Controls.Find(RTB_CONTROL_NAME & _index, False)(0), RichTextBox)
        Using _output As New StreamWriter(Path.Combine(My.Settings.TwitterFilePath, _filename))
            For Each _line As String In _rtb.Lines
                _output.WriteLine(_line)
            Next
        End Using
    End Sub
    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        Dim _rtb As RichTextBox = GetTextBox(TcFileTabs.SelectedTab)
        My.Computer.Clipboard.Clear()

        If _rtb IsNot Nothing Then
            My.Computer.Clipboard.SetText(_rtb.SelectedText)
        End If
    End Sub

#End Region
#Region "tree subroutines"
    Private Sub BuildTrees()
        DisplayMessage("Selecting...")
        Dim oBirthdayList As New List(Of Person)
        Dim oAnniversaryList As New List(Of Person)
        tvBirthday.Nodes.Clear()
        Dim startDate As Date = dtpFrom.Value
        Dim endDate As Date = dtpTo.Value
        Dim testDate As Date = startDate
        Do Until testDate > endDate
            Dim _day As Integer = testDate.Day
            Dim _mth As Integer = testDate.Month
            oBirthdayList = FindBirthdays(_day, _mth)
            oAnniversaryList = FindAnniversaries(_day, _mth)
            Dim newDateNode As TreeNode = tvBirthday.Nodes.Add(Format(testDate, "MMMM dd"))
            newDateNode.Checked = True
            AddTypeNode(oAnniversaryList, testDate, newDateNode, "Anniversary")
            AddTypeNode(oBirthdayList, testDate, newDateNode, "Birthday")
            testDate = DateAdd(DateInterval.Day, 1, testDate)
        Loop
        DisplayMessage("Selection Complete")
    End Sub
    Private Sub AddTypeNode(oBirthdayTable As List(Of Person), testDate As Date, newDateNode As TreeNode, _type As String)
        Dim newBirthdayNode As TreeNode = newDateNode.Nodes.Add(Format(testDate, "MMMM dd") & _type, _type)
        newBirthdayNode.Checked = True
        For Each oPerson As Person In oBirthdayTable
            AddNameNode(newBirthdayNode, oPerson)
        Next
    End Sub
    Private Sub AddNameNode(newBirthdayNode As TreeNode, oPerson As Person)
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
    End Sub
    Private Sub TvAnniv_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvBirthday.AfterCheck
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                CheckAllChildNodes(e.Node, e.Node.Checked)
            End If
        End If
    End Sub
    Private Sub CheckAllChildNodes(ByRef _treeNode As TreeNode, ByRef nodeChecked As Boolean)
        For Each _node As TreeNode In _treeNode.Nodes
            _node.Checked = nodeChecked
            If _node.Nodes.Count > 0 Then
                CheckAllChildNodes(_node, nodeChecked)
            End If
        Next
    End Sub
#End Region
#Region "file subroutines"
    Private Sub WriteFiles()
        DisplayMessage("Writing...")
        Dim TwitterFilenameA As String = Format(dtpFrom.Value, "MMM-dd") & "_" & Format(dtpTo.Value, "MMM-dd") & "_Anniversary.txt"
        Dim TwitterFilenameB As String = Format(dtpFrom.Value, "MMM-dd") & "_" & Format(dtpTo.Value, "MMM-dd") & "_Birthday.txt"
        Dim TwitterFilename As String = TwitterFilenameB
        DeleteExistingFile(TwitterFilenameA, TwitterFilenameB)
        Dim currentDate As String = ""
        WriteDates(TwitterFilenameA, TwitterFilenameB, TwitterFilename, currentDate)
        DisplayMessage("Files complete")
    End Sub
    Private Sub WriteDates(TwitterFilenameA As String, TwitterFilenameB As String, ByRef TwitterFilename As String, ByRef currentDate As String)
        Dim fileCount As Integer = 0
        TcFileTabs.TabPages.Clear()

        For Each _datenode As TreeNode In tvBirthday.Nodes
            If _datenode.Text <> currentDate Then
                currentDate = _datenode.Text
                If _datenode.Checked Then
                    TwitterFilename = SetTwitterFilename(TwitterFilenameA, TwitterFilenameB, currentDate)
                    Dim newTabPage As TabPage = CreateNewTabPage(TwitterFilename, fileCount)
                    Dim _controls As Control() = newTabPage.Controls.Find(RTB_CONTROL_NAME & fileCount, False)
                    Dim rtbControl As New RichTextBox
                    If _controls.Count > 0 Then
                        rtbControl = TryCast(_controls(0), RichTextBox)
                    End If
                    Dim _filename As String = Path.Combine(My.Settings.TwitterFilePath, TwitterFilename)
                    TcFileTabs.TabPages.Add(newTabPage)
                    Using _outfile As New StreamWriter(_filename, True)
                        WriteTypes(_datenode, _outfile)
                    End Using
                    DisplayMessage("Written file " & _filename)
                    LoadRtb(rtbControl, _filename)
                    fileCount += 1
                End If
            End If
        Next
    End Sub
    Private Sub LoadRtb(_rtbControl As RichTextBox, _filename As String)
        Using _input As New StreamReader(_filename)
            _rtbControl.Text = _input.ReadToEnd
        End Using
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
            .Controls.Add(newButton(GetTabNumber(newTabpage)))
            .Controls.Add(newRichTextBox(GetTabNumber(newTabpage)))
        End With
        Return newTabpage
    End Function
    Private Function newButton(_index As String) As Button
        Dim _newButton As New System.Windows.Forms.Button()
        With _newButton
            .Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            .Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .ForeColor = System.Drawing.Color.RoyalBlue
            .Location = New System.Drawing.Point(287, 397)
            .Name = BUTTON_CONTROL_NAME & _index
            .Size = New System.Drawing.Size(119, 23)
            .Text = "Rewrite File"
        End With
        AddHandler _newButton.Click, AddressOf BtnRewrite_Click
        Return _newButton
    End Function
    Private Function newRichTextBox(_index As String) As RichTextBox
        Dim _newRtb As New System.Windows.Forms.RichTextBox()
        With _newRtb
            .Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
           Or System.Windows.Forms.AnchorStyles.Left) _
           Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            .Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .Location = New System.Drawing.Point(6, 3)
            .Name = RTB_CONTROL_NAME & _index
            .Size = New System.Drawing.Size(400, 388)
            .Text = ""
            .ContextMenuStrip = ContextMenuStrip1
        End With
        Return _newRtb
    End Function
    Private Sub WriteTypes(_datenode As TreeNode, _outfile As StreamWriter)
        For Each _typeNode As TreeNode In _datenode.Nodes
            If _typeNode.Checked AndAlso ((rbAnnivOnly.Checked And _typeNode.Text.StartsWith("A")) Or (rbBirthdaysOnly.Checked And _typeNode.Text.StartsWith("B")) Or rbBoth.Checked) Then
                WritePersons(_outfile, _datenode.Text, _typeNode)
            End If
        Next
    End Sub
    Private Function GetHeading(_typeNode As TreeNode) As String
        Dim _header As String = ""
        If _typeNode.Text.StartsWith("A") Then
            _header = ANNIV_HDR
        End If
        If _typeNode.Text.StartsWith("B") Then
            _header = BIRTHDAY_HDR
        End If
        Return _header
    End Function
    Private Sub WritePersons(_outfile As StreamWriter, _date As String, _typeNode As TreeNode)

        Dim _header As String = GetHeading(_typeNode)
        Dim _index As Integer = 0
        Dim _nextLine As String = ""

        Dim tweetCount As Integer = TWEET_SIZE - _header.Length
        Dim _tweetNodes As New List(Of TreeNode)
        Dim _numberOfLists As Integer = 1
        For Each _personNode As TreeNode In _typeNode.Nodes
            If _personNode.Checked Then
                _tweetNodes.Add(_personNode)
                _nextLine = MakeTweetLine(_personNode)
                tweetCount -= _nextLine.Length + 1
                If tweetCount < 0 Then
                    _numberOfLists += 1
                    tweetCount = TWEET_SIZE - 1 - _header.Length - _nextLine.Length
                End If
            End If
        Next
        Dim _tweetsinEachList As Integer = Int(_tweetNodes.Count / _numberOfLists)
        Dim _remainder As Integer = _tweetNodes.Count Mod _numberOfLists
        Dim _startTweet As Integer = 0
        Dim _endTweet As Integer = _tweetsinEachList - 1
        If _remainder > 0 Then
            _endTweet += 1
            _remainder -= 1
        End If
        For x = 1 To _numberOfLists
            Dim _footer As String = If(_numberOfLists > 1, CStr(x) & "/" & CStr(_numberOfLists), "")
            WriteNodesToTweet(_outfile, _date, _header, _tweetNodes, _startTweet, _endTweet, _footer)
            _startTweet = _endTweet + 1
            _endTweet = _startTweet + _tweetsinEachList - 1
            If _remainder > 0 Then
                _endTweet += 1
                _remainder -= 1
            End If
        Next

    End Sub
    Private Sub WriteNodesToTweet(_outfile As StreamWriter, _date As String, _header As String, _tweetNodes As List(Of TreeNode), _firstTweetToWrite As Integer, _lastTweetToWrite As Integer, _footer As String)
        Dim _length As Integer = 0
        _length += WriteHeader(_outfile, _date, _header)
        For _tweetNumber = _firstTweetToWrite To _lastTweetToWrite
            If _tweetNumber < _tweetNodes.Count Then
                _length += WriteTweetLine(_outfile, _tweetNodes(_tweetNumber))
            End If
        Next
        WriteFooter(_outfile, _footer, _length)
    End Sub
    Private Shared Function WriteHeader(_outfile As StreamWriter, _date As String, _header As String) As Integer
        _outfile.WriteLine("")
        _outfile.WriteLine(_date)
        _outfile.WriteLine("")
        _outfile.WriteLine(_header)
        Return _date.Length + _header.Length + 3
    End Function
    Private Shared Sub WriteFooter(_outfile As StreamWriter, _footer As String, _length As Integer)
        _outfile.WriteLine("")
        If Not String.IsNullOrEmpty(_footer) Then
            _outfile.WriteLine(_footer)
        End If
        _length += _footer.Length + 1
        _outfile.WriteLine("----------------------------------- " & CStr(_length))
    End Sub
    Private Function WriteTweetLine(_outfile As StreamWriter, _personNode As TreeNode) As Integer
        Dim _nextLine As String = MakeTweetLine(_personNode)
        _outfile.WriteLine(_nextLine)
        Return _nextLine.Length + 1
    End Function
    Private Function MakeTweetLine(_personNode As TreeNode) As String
        Dim personName As String = _personNode.Text.Trim
        Dim twitterHandle As Char() = ""
        For Each _node As TreeNode In _personNode.Nodes
            If _node.Name = "twitter" Then
                If _node.Checked Then
                    twitterHandle = " @" & RemoveBadCharacters(_node.Text, {8207, 32})
                End If
            End If
        Next
        Return personName & twitterHandle
    End Function
    Private Sub DeleteExistingFile(TwitterFilenameA As String, TwitterFilenameB As String)
        Try
            If rbSingleFile.Checked Then
                If rbAnnivOnly.Checked Then
                    My.Computer.FileSystem.DeleteFile(Path.Combine(My.Settings.TwitterFilePath, TwitterFilenameA))
                Else
                    My.Computer.FileSystem.DeleteFile(Path.Combine(My.Settings.TwitterFilePath, TwitterFilenameB))
                End If
                DisplayMessage("Deleted old file")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function SetTwitterFilename(TwitterFilenameA As String, TwitterFilenameB As String, currentDate As String) As String
        Dim TwitterFilename As String

        If rbSingleFile.Checked Then
            If rbAnnivOnly.Checked Then
                TwitterFilename = TwitterFilenameA
            Else
                TwitterFilename = TwitterFilenameB
            End If
        Else
            If rbAnnivOnly.Checked Then
                TwitterFilename = "" & currentDate & "_Anniversary.txt"
            Else
                TwitterFilename = "" & currentDate & "_Birthday.txt"
            End If
            Try
                My.Computer.FileSystem.DeleteFile(Path.Combine(My.Settings.TwitterFilePath, TwitterFilename))
            Catch ex As Exception
            End Try
        End If

        Return TwitterFilename
    End Function
    Private Function GetTextBox(_tabPage As TabPage) As RichTextBox
        Dim _rtb As New RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & GetTabNumber(_tabPage)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Count > 0 Then
            _rtb = TryCast(_controls(0), RichTextBox)
        End If
        Return _rtb
    End Function
    Private Function GetTabNumber(_tabPage As TabPage) As String
        Dim _tabNumber As String = ""
        Dim tabNamePart As String() = Split(_tabPage.Name, "_")
        Try
            If tabNamePart.Count = 2 Then
                _tabNumber = tabNamePart(1)
            End If
        Catch ex As Exception
            DisplayMessage("Invalid Tab Name " & _tabPage.Name)
        End Try
        Return _tabNumber
    End Function

#End Region
#Region "general subroutines"
    Private Sub DisplayMessage(_text As String)
        lblStatus.Text = _text
        StatusStrip1.Refresh()
    End Sub


#End Region
End Class
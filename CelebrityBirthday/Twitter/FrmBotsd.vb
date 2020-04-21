Imports System.Collections.ObjectModel
Imports System.Data.Common
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports TweetSharp

Public Class FrmBotsd
#Region "variables"
    Private _imageList As New List(Of Person)
    Private IsNoGenerate As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private urlDay As String
    Private urlMonth As String
    Private urlYear As String
    Private imageLoadMonth As String
    Private imageLoadYear As String
    Private WpNumber As Integer

#End Region
#Region "properites"
    Private _day As Integer
    Private _month As Integer
    Public Property ThisMonth() As Integer
        Get
            Return _month
        End Get
        Set(ByVal value As Integer)
            _month = value
        End Set
    End Property
    Public Property ThisDay() As Integer
        Get
            Return _day
        End Get
        Set(ByVal value As Integer)
            _day = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub NudPic1Horizontal_ValueChanged(sender As Object, e As EventArgs) Handles NudPic1Horizontal.ValueChanged
        If Not IsNoGenerate Then
            GeneratePicture(PictureBox1, _imageList, NudPic1Horizontal.Value)
        End If
    End Sub
    Private Sub FrmBotsd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.botsdformpos)
        IsNoGenerate = True
        WpNumber = GlobalSettings.GetSetting(My.Resources.NEXTWPNO)
        Try
            LblMonth.Text = Format(New Date(2000, ThisMonth, 1), "MMMM")
            LblDay.Text = CStr(ThisDay)
            Dim _wpDate As Date? = GetWordPressLoadDate(ThisDay, ThisMonth, "P")
            urlDay = If(_wpDate Is Nothing, "", Format(_wpDate, "dd"))
            urlMonth = If(_wpDate Is Nothing, "", Format(_wpDate, "MM"))
            urlYear = If(_wpDate Is Nothing, "", Format(_wpDate, "yyyy"))
            imageLoadMonth = urlMonth
            imageLoadYear = urlYear
        Catch ex As ArgumentOutOfRangeException
            MsgBox("No date selected", MsgBoxStyle.Exclamation, "Error")
            Me.Close()
        End Try
        GetAuthData()
        FillTwitterUserList()
        IsNoGenerate = False
    End Sub
    Private Sub DgvPairs_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPairs.SelectionChanged
        GeneratePair()
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Dim _imageFilename As String = Nothing
        If chkImages.Checked Then
            If PictureBox1.Image IsNot Nothing Then
                _imageFilename = SaveImage()
            Else
                If MsgBox("No image to send. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "No image") = MsgBoxResult.Yes Then
                    chkImages.Checked = False
                Else
                    DisplayStatus("Tweet not sent - no image")
                    Exit Sub
                End If
            End If
        End If
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            SendTweet(_imageFilename)
        Else
            DisplayStatus("Select Sender")
        End If
    End Sub
    Private Sub BtnSwap_Click(sender As Object, e As EventArgs) Handles BtnSwap.Click
        If DgvPairs.SelectedRows.Count = 1 Then
            Dim _selCount As Integer = CInt(chkSel1.Checked) + CInt(ChkSel2.Checked) + CInt(ChkSel3.Checked) + CInt(ChkSel4.Checked)
            If _selCount <> -2 Then
                MsgBox("Select two persons", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            Dim _row As DataGridViewRow = DgvPairs.SelectedRows(0)
            Dim sel1IdCol As String
            Dim sel2IdCol As String
            Dim sel1NameCol As String
            Dim sel2NameCol As String

            If chkSel1.Checked Then
                sel1IdCol = pairId1.Name
                sel1NameCol = pairPerson1.Name
                If ChkSel2.Checked Then
                    sel2IdCol = pairId2.Name
                    sel2NameCol = pairPerson2.Name
                Else
                    If ChkSel3.Checked Then
                        sel2IdCol = pairId3.Name
                        sel2NameCol = pairPerson3.Name
                    Else
                        sel2IdCol = pairId4.Name
                        sel2NameCol = pairPerson4.Name
                    End If
                End If
            ElseIf ChkSel2.Checked Then
                sel1IdCol = pairId2.Name
                sel1NameCol = pairPerson2.Name
                If ChkSel3.Checked Then
                    sel2IdCol = pairId3.Name
                    sel2NameCol = pairPerson3.Name
                Else
                    sel2IdCol = pairId4.Name
                    sel2NameCol = pairPerson4.Name
                End If
            Else
                sel1IdCol = pairId3.Name
                sel1NameCol = pairPerson3.Name
                sel2IdCol = pairId4.Name
                sel2NameCol = pairPerson4.Name
            End If
            Dim _saveId As Integer = _row.Cells(sel1IdCol).Value
            Dim _saveName As String = _row.Cells(sel1NameCol).Value
            _row.Cells(sel1IdCol).Value = _row.Cells(sel2IdCol).Value
            _row.Cells(sel1NameCol).Value = _row.Cells(sel2NameCol).Value
            _row.Cells(sel2IdCol).Value = _saveId
            _row.Cells(sel2NameCol).Value = _saveName
        End If
        GeneratePair()
    End Sub
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        GeneratePair()
    End Sub
    Private Sub BtnUpdate1_Click(sender As Object, e As EventArgs) Handles BtnUpdate1.Click
        Dim _pickPerson1 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId1.Name).Value)
        _pickPerson1.ShortDesc = TxtShortDesc1.Text
        If UpdateShortDesc(_pickPerson1) = 1 Then
            DisplayStatus("Updated person 1")
        Else
            DisplayStatus("Updated failed")
        End If
        _pickPerson1.Dispose()
    End Sub
    Private Sub BtnUpdate2_Click(sender As Object, e As EventArgs) Handles BtnUpdate2.Click
        Dim _pickPerson2 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId2.Name).Value)
        _pickPerson2.ShortDesc = TxtShortDesc2.Text

        If UpdateShortDesc(_pickPerson2) = 1 Then
            DisplayStatus("Updated person 2")
        Else
            DisplayStatus("Updated failed")
        End If
        _pickPerson2.Dispose()
    End Sub
    Private Sub BtnUpdate3_Click(sender As Object, e As EventArgs) Handles BtnUpdate3.Click
        Dim _pickPerson3 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId3.Name).Value)
        _pickPerson3.ShortDesc = TxtShortDesc3.Text

        If UpdateShortDesc(_pickPerson3) = 1 Then
            DisplayStatus("Updated person 3")
        Else
            DisplayStatus("Updated failed")
        End If
        _pickPerson3.Dispose()
    End Sub
    Private Sub BtnUpdate4_Click(sender As Object, e As EventArgs) Handles BtnUpdate4.Click
        Dim _pickPerson4 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId4.Name).Value)
        _pickPerson4.ShortDesc = TxtShortDesc4.Text

        If UpdateShortDesc(_pickPerson4) = 1 Then
            DisplayStatus("Updated person 4")
        Else
            DisplayStatus("Updated failed")
        End If
        _pickPerson4.Dispose()
    End Sub
    Private Sub FrmBotsd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.botsdformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        GetSourceControl(menuItem).Copy()
    End Sub
    Private Sub CutToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        GetSourceControl(menuItem).Cut()
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(sender)

        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            If _textBox IsNot Nothing Then
                _textBox.SelectAll()
            End If
        End If

    End Sub
    Private Sub PasteToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If

    End Sub
    Private Sub ClearToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Text = ""
        End If
    End Sub
    Private Sub BtnGenWp_Click(sender As Object, e As EventArgs) Handles BtnGenWp.Click
        GenerateWordpress()
    End Sub
    Private Sub BtnClearImages_Click(sender As Object, e As EventArgs) Handles BtnClearImages.Click
        If MsgBox("Confirm delete BOTSD images", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.twitterImageFolder, FileIO.SearchOption.SearchTopLevelOnly, {My.Resources.BOTSD & "*.*"})
            For Each _imageFile As String In _imageList
                My.Computer.FileSystem.DeleteFile(_imageFile)
            Next
        End If
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        Dim _imageFilename As String
        If PictureBox1.Image IsNot Nothing Then
            _imageFilename = SaveImage()
        End If
    End Sub
    Private Sub BtnWpPost_Click(sender As Object, e As EventArgs) Handles BtnWpPost.Click
        GenerateWpPost()
    End Sub
#End Region
#Region "subroutines"
    Private Function SaveImage() As String
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _add As String = My.Resources.BOTSD
        Dim _fileName As String = Path.Combine(_path, _add.Replace("_", "_" & LblDay.Text & "_" & LblMonth.Text) & ".jpg")
        If My.Computer.FileSystem.FileExists(_fileName) Then
            _fileName = GetUniqueFname(_fileName)
        End If
        ImageUtil.SaveImageFromPictureBox(PictureBox1, PictureBox1.Width, PictureBox1.Height, _fileName)
        DisplayStatus("File saved")
        Return _fileName
    End Function
    Private Sub FillTwitterUserList()
        cmbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            cmbTwitterUsers.Items.Add(_user)
        Next
    End Sub
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer)
        Dim pAlignType As ImageUtil.AlignType
        Select Case True
            Case rbImageRight.Checked
                pAlignType = ImageUtil.AlignType.Right
            Case rbImageLeft.Checked
                pAlignType = ImageUtil.AlignType.Left
            Case rbImageCentre.Checked
                pAlignType = ImageUtil.AlignType.Centre
        End Select
        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            ImageUtil.GenerateImage(_pictureBox, _imageTable, _width, _height, pAlignType)
        Else
            _pictureBox.Image = Nothing
        End If
    End Sub
    Private Sub SendTweet(_filename As String)
        Dim isOkToSend As Boolean = True
        If cmbTwitterUsers.SelectedIndex >= 0 Then
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
        End If
        WriteTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
        If isOkToSend Then
            SendTheTweet(rtbFile1.Text, _filename)
        End If
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))

    End Sub
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
            InsertTweet("", _month, ThisDay, 1, _mediaId, cmbTwitterUsers.SelectedItem, "I")
            sto.MediaIds = {_mediaId}
        End If
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        If _twitterStatus IsNot Nothing Then
            InsertTweet(sto.Status, _month, ThisDay, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
            WriteTrace("OK: " & _twitterStatus.Id, True)
        Else
            ' tweet failed
            WriteTrace("Failed", True)
        End If
    End Sub
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweet.Text &= vbCrLf & sText
        If isStatus Then DisplayStatus(sText)
    End Sub
    Private Sub DisplayStatus(_text As String, Optional _isAppend As Boolean = False)
        If _isAppend Then
            LblStatus.Text &= _text
        Else
            LblStatus.Text = _text
        End If
        StatusStrip1.Refresh()
    End Sub
    Private Sub GetAuthData()
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
    End Sub
    Private Shared Function GetBotsdPostNo(botsdId As Integer, ByRef botsdUrl As String) As Integer
        Dim oBotsdPostNo As Integer = -1
        Dim oRow As CelebrityBirthdayDataSet.BotSDRow = GetBotsd(botsdId)
        If oRow IsNot Nothing Then
            oBotsdPostNo = oRow.btsdPostNo
            botsdUrl = oRow.btsdUrl
        End If
        Return oBotsdPostNo
    End Function
    Public Sub AddList(ByRef personsList As List(Of Person))
        Dim _pairRow As DataGridViewRow = DgvPairs.Rows(DgvPairs.Rows.Add())
        If personsList IsNot Nothing Then
            If personsList.Count > 0 Then
                _pairRow.Cells(pairYear.Name).Value = personsList(0).BirthYear
                _pairRow.Cells(pairId1.Name).Value = personsList(0).Id
                _pairRow.Cells(pairPerson1.Name).Value = personsList(0).Name
                Dim postNo As Integer = GetBotsdPostNo(personsList(0).Social.Botsd, "")
                _pairRow.Cells(pairWpNo.Name).Value = If(postNo > -1, CStr(postNo), "")
            End If
            If personsList.Count > 1 Then
                _pairRow.Cells(pairId2.Name).Value = personsList(1).Id
                _pairRow.Cells(pairPerson2.Name).Value = personsList(1).Name
            End If
            If personsList.Count > 2 Then
                _pairRow.Cells(pairId3.Name).Value = personsList(2).Id
                _pairRow.Cells(pairPerson3.Name).Value = personsList(2).Name
            End If
            If personsList.Count > 3 Then
                _pairRow.Cells(pairId4.Name).Value = personsList(3).Id
                _pairRow.Cells(pairPerson4.Name).Value = personsList(3).Name
            End If
        End If

    End Sub
    Private Sub GeneratePair()
        If DgvPairs.SelectedRows.Count = 1 Then
            Try
                Dim _pickPerson1 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId1.Name).Value)
                Dim _pickPerson2 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId2.Name).Value)
                Dim _pickPerson3 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId3.Name).Value)
                Dim _pickPerson4 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId4.Name).Value)
                _imageList = New List(Of Person)
                chkSel1.Checked = False
                ChkSel2.Checked = False
                ChkSel3.Checked = False
                ChkSel4.Checked = False
                If _pickPerson1 IsNot Nothing Then
                    TxtForename1.Text = _pickPerson1.ForeName
                    TxtSurname1.Text = _pickPerson1.Surname
                    DtpDob1.Value = _pickPerson1.DateOfBirth.Value
                    TxtShortDesc1.Text = _pickPerson1.ShortDesc
                    LblId1.Text = CStr(_pickPerson1.Id)
                    _imageList.Add(_pickPerson1)
                    GroupBox1.Enabled = True
                Else
                    TxtForename1.Text = ""
                    TxtSurname1.Text = ""
                    DtpDob1.Value = Today
                    TxtShortDesc1.Text = ""
                    LblId1.Text = ""
                    GroupBox1.Enabled = False
                End If
                If _pickPerson2 IsNot Nothing Then
                    TxtForename2.Text = _pickPerson2.ForeName
                    TxtSurname2.Text = _pickPerson2.Surname
                    DtpDob2.Value = _pickPerson2.DateOfBirth.Value
                    TxtShortDesc2.Text = _pickPerson2.ShortDesc
                    LblId2.Text = CStr(_pickPerson2.Id)
                    _imageList.Add(_pickPerson2)
                    GroupBox2.Enabled = True
                Else
                    TxtForename2.Text = ""
                    TxtSurname2.Text = ""
                    DtpDob2.Value = Today
                    TxtShortDesc2.Text = ""
                    LblId2.Text = ""
                    GroupBox2.Enabled = False
                End If
                If _pickPerson3 IsNot Nothing Then
                    TxtForename3.Text = _pickPerson3.ForeName
                    TxtSurname3.Text = _pickPerson3.Surname
                    DtpDob3.Value = _pickPerson3.DateOfBirth.Value
                    TxtShortDesc3.Text = _pickPerson3.ShortDesc
                    LblId3.Text = CStr(_pickPerson3.Id)
                    _imageList.Add(_pickPerson3)
                    GroupBox3.Enabled = True
                Else
                    TxtForename3.Text = ""
                    TxtSurname3.Text = ""
                    DtpDob3.Value = Today
                    TxtShortDesc3.Text = ""
                    LblId3.Text = ""
                    GroupBox3.Enabled = False
                End If
                If _pickPerson4 IsNot Nothing Then
                    TxtForename4.Text = _pickPerson4.ForeName
                    TxtSurname4.Text = _pickPerson4.Surname
                    DtpDob4.Value = _pickPerson4.DateOfBirth.Value
                    TxtShortDesc4.Text = _pickPerson4.ShortDesc
                    LblId4.Text = CStr(_pickPerson4.Id)
                    _imageList.Add(_pickPerson4)
                    GroupBox4.Enabled = True
                Else
                    TxtForename4.Text = ""
                    TxtSurname4.Text = ""
                    DtpDob4.Value = Today
                    TxtShortDesc4.Text = ""
                    LblId4.Text = ""
                    GroupBox4.Enabled = False
                End If
                GeneratePicture(PictureBox1, _imageList, NudPic1Horizontal.Value)
                GenerateText(_imageList)
            Catch ex As DbException
                DisplayStatus("Person exception")
            End Try
        End If
    End Sub
    Private Sub GenerateText(_imageTable As List(Of Person))
        Dim _outString As New StringBuilder
        Dim _index As Integer = 0
        Dim _dob As String = ""
        For Each _person As Person In _imageTable
            Select Case _index
                Case 0
                    _dob = Format(_person.DateOfBirth, "d MMMM yyyy")
                Case _imageTable.Count - 1
                    _outString.Append(vbCrLf)
                    _outString.Append("and ")
                Case Else
                    _outString.Append(vbCrLf)
            End Select
            _outString.Append(_person.Name)
            _outString.Append(", ")
            _outString.Append(_person.ShortDesc.Trim("."))
            _outString.Append(",")
            _index += 1
        Next
        _outString.Append(vbCrLf)
        _outString.Append("were ")
        If _imageTable.Count = 2 Then
            _outString.Append("both")
        Else
            _outString.Append("all")
        End If
        _outString.Append(" born on ")
        _outString.Append(_dob)
        rtbFile1.Text = _outString.ToString
    End Sub
    Private Sub GenerateWordpress()
        Dim sb As New StringBuilder
        sb.Append("<strong>").Append(CStr(ThisDay))
        Select Case ThisDay
            Case 1, 21, 31
                sb.Append("st")
            Case 2, 22
                sb.Append("nd")
            Case 3, 23
                sb.Append("rd")
            Case Else
                sb.Append("th")
        End Select
        sb.Append("</strong>").Append(vbCrLf)
        For Each oRow As DataGridViewRow In DgvPairs.Rows
            If Not String.IsNullOrEmpty(oRow.Cells(pairYear.Name).Value) Then
                Dim _pickPerson1 As Person = GetFullPersonById(oRow.Cells(pairId1.Name).Value)
                Dim btsdUrl As String = ""
                Dim postNo As Integer = GetBotsdPostNo(_pickPerson1.Social.Botsd, btsdUrl)
                With sb
                    .Append(oRow.Cells(pairYear.Name).Value)
                    .Append("&nbsp;&nbsp;")
                    If Not String.IsNullOrEmpty(oRow.Cells(pairPerson1.Name).Value) Then
                        .Append(oRow.Cells(pairPerson1.Name).Value)
                    End If
                    If Not String.IsNullOrEmpty(oRow.Cells(pairPerson2.Name).Value) Then
                        .Append("&nbsp;/&nbsp;")
                        .Append(oRow.Cells(pairPerson2.Name).Value)
                    End If
                    If Not String.IsNullOrEmpty(oRow.Cells(pairPerson3.Name).Value) Then
                        .Append("&nbsp;/&nbsp;")
                        .Append(oRow.Cells(pairPerson3.Name).Value)
                    End If
                    If Not String.IsNullOrEmpty(oRow.Cells(pairPerson4.Name).Value) Then
                        .Append("&nbsp;/&nbsp;")
                        .Append(oRow.Cells(pairPerson4.Name).Value)
                    End If
                    .Append("&nbsp;&nbsp;")
                    If postNo > -1 Then

                        .Append("<a href=")
                        .Append(My.Resources.DOUBLEQUOTES)
                        .Append(btsdUrl)
                        .Append(My.Resources.DOUBLEQUOTES)
                        .Append(" target=")
                        .Append(My.Resources.DOUBLEQUOTES)
                        .Append("_blank")
                        .Append(My.Resources.DOUBLEQUOTES)
                        .Append(" rel=")
                        .Append(My.Resources.DOUBLEQUOTES)
                        .Append("noopener")
                        .Append(My.Resources.DOUBLEQUOTES)
                        .Append(">#")
                        .Append(CStr(postNo))
                        .Append("</a>")
                    End If
                    sb.Append(vbCrLf)
                End With
                _pickPerson1.Dispose()
            End If
        Next
        Using oTextForm As New FrmText
            oTextForm.rtbText.Text = sb.ToString
            oTextForm.ShowDialog()
        End Using
    End Sub
    Private Function GetImageLink(oPerson As Person) As String
        Dim oImage As ImageIdentity = oPerson.Image
        If oImage IsNot Nothing Then
            If oImage.ImageLoadYear IsNot Nothing AndAlso IsNumeric(oImage.ImageLoadYear) Then
                imageLoadYear = oImage.ImageLoadYear
            End If
            If oImage.ImageLoadMonth IsNot Nothing AndAlso IsNumeric(oImage.ImageLoadMonth) Then
                imageLoadMonth = oImage.ImageLoadMonth
            End If
        End If
        Dim lowername As String = oImage.ImageFileName
        If lowername.Length = 0 Then
            lowername = oPerson.Name.ToLower(myCultureInfo).Replace(" ", "-").Replace(".", "")
        End If
        oImage.Dispose()
        Dim ImageSb As New StringBuilder
        With ImageSb
            .Append("<a href=")
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(My.Resources.WPPAGEURL)
            .Append(urlYear)
            .Append(My.Resources.SLASH)
            .Append(urlMonth)
            .Append(My.Resources.SLASH)
            .Append(urlDay)
            .Append(My.Resources.SLASH)
            .Append(CStr(ThisDay))
            .Append("-")
            .Append(Format(New Date(2000, ThisMonth, 1), "MMMM").ToLower(myCultureInfo))
            .Append(My.Resources.SLASH)
            .Append(lowername)
            .Append(My.Resources.SLASH)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append("><img src=")
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(My.Resources.WPFILESURL)
            .Append(My.Resources.SLASH)
            .Append(imageLoadYear)
            .Append(My.Resources.SLASH)
            .Append(imageLoadMonth)
            .Append(My.Resources.SLASH)
            .Append(lowername)
            .Append(oPerson.Image.ImageFileType)
            .Append("?w=150&amp;h=150"" alt="""">")
            .Append("</a>")
            .Append(vbCrLf)
        End With
        Return ImageSb.ToString
    End Function
    Private Function GetPersonText(oPerson As Person) As String
        Dim oPersonText As New StringBuilder
        Dim sBorn As String = ""
        If oPerson.BirthName.Length > 0 Or oPerson.BirthPlace.Length > 0 Then
            sBorn = " Born" & If(oPerson.BirthName.Length > 0, " " & oPerson.BirthName, "") & If(oPerson.BirthPlace.Length > 0, " in " & oPerson.BirthPlace, "") & "."
        End If
        Dim sDied As String = " (d. " & CStr(Math.Abs(oPerson.DeathYear)) & If(oPerson.DeathYear < 0, " BCE", "") & ")"
        With oPersonText
            .Append("<h1 id=""firstHeading"">")
            .Append(oPerson.Name)
            .Append("</h1>")
            .Append(vbCrLf)
            .Append(GetImageLink(oPerson))
            .Append(vbCrLf)
            .Append(oPerson.Description)
            .Append(sBorn)
            .Append(If(oPerson.DeathYear = 0, "", sDied))
            .Append(vbCrLf)
        End With
        Return oPersonText.ToString
    End Function
    Private Shared Function GetWikiLinkText(oPerson As Person) As String
        Dim oImageText As New StringBuilder
        With oImageText
            .Append("<a href=")
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(My.Resources.WIKIURL)
            .Append(oPerson.Social.WikiId)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(" target=""_blank"" rel=""noopener"">")
            .Append(My.Resources.WIKIURL)
            .Append(oPerson.Social.WikiId)
            .Append("</a>")
            .Append(My.Resources.BREAK)
            .Append(vbCrLf)
        End With
        Return oImageText.ToString
    End Function
    Private Sub GenerateWpPost()
        Dim sb As New StringBuilder
        Dim titleSb As New StringBuilder
        Dim thisWpNumber As String = DgvPairs.SelectedRows(0).Cells(pairWpNo.Name).Value
        If String.IsNullOrEmpty(thisWpNumber) Then
            thisWpNumber = CStr(WpNumber)
        End If
        Try
            titleSb.Append("#").Append(thisWpNumber).Append(" ")
            Dim titleDate As String = ""
            Dim _pickPerson1 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId1.Name).Value)
            Dim _pickPerson2 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId2.Name).Value)
            Dim _pickPerson3 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId3.Name).Value)
            Dim _pickPerson4 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId4.Name).Value)
            Dim _sep As String = ""
            If _pickPerson1 IsNot Nothing Then
                sb.Append(GetPersonText(_pickPerson1))
                titleSb.Append(_pickPerson1.Name)
                _sep = " / "
                titleDate = Format(_pickPerson1.DateOfBirth, "dd MMMM yyyy")
            End If
            If _pickPerson2 IsNot Nothing Then
                sb.Append(GetPersonText(_pickPerson2))
                titleSb.Append(_sep).Append(_pickPerson2.Name)
                _sep = " / "
                titleDate = Format(_pickPerson2.DateOfBirth, "dd MMMM yyyy")
            End If
            If _pickPerson3 IsNot Nothing Then
                sb.Append(GetPersonText(_pickPerson3))
                titleSb.Append(_sep).Append(_pickPerson3.Name)
                _sep = " / "
                titleDate = Format(_pickPerson3.DateOfBirth, "dd MMMM yyyy")
            End If
            If _pickPerson4 IsNot Nothing Then
                sb.Append(GetPersonText(_pickPerson4))
                titleSb.Append(_sep).Append(_pickPerson4.Name)
                titleDate = Format(_pickPerson4.DateOfBirth, "dd MMMM yyyy")
            End If
            titleSb.Append(" - ").Append(titleDate)
            sb.Append(My.Resources.BREAK).Append("Links:").Append(My.Resources.BREAK).Append(vbCrLf)
            If _pickPerson1 IsNot Nothing AndAlso Not String.IsNullOrEmpty(_pickPerson1.Social.WikiId) Then
                sb.Append(GetWikiLinkText(_pickPerson1))
            End If
            If _pickPerson2 IsNot Nothing AndAlso Not String.IsNullOrEmpty(_pickPerson2.Social.WikiId) Then
                sb.Append(GetWikiLinkText(_pickPerson2))
            End If
            If _pickPerson3 IsNot Nothing AndAlso Not String.IsNullOrEmpty(_pickPerson3.Social.WikiId) Then
                sb.Append(GetWikiLinkText(_pickPerson3))
            End If
            If _pickPerson4 IsNot Nothing AndAlso Not String.IsNullOrEmpty(_pickPerson4.Social.WikiId) Then
                sb.Append(GetWikiLinkText(_pickPerson4))
            End If
            sb.Append(vbCrLf).Append("<br><!--more Also born on this day >> --><br>Also born on this day:").Append(vbCrLf)
            Using oTextForm As New FrmBotsdPost
                oTextForm.TxtTitle.Text = titleSb.ToString
                oTextForm.RtbText.Text = sb.ToString
                oTextForm.LblWpPostNo.Text = thisWpNumber
                oTextForm.ShowDialog()
                If oTextForm.DialogResult = DialogResult.OK Then
                    DgvPairs.SelectedRows(0).Cells(pairWpNo.Name).Value = thisWpNumber
                    Dim botsdNo As Integer = UpdateBotsd(ThisDay, ThisMonth, DgvPairs.SelectedRows(0).Cells(pairYear.Name).Value, CInt(thisWpNumber), oTextForm.TxtUrl.Text)
                    If _pickPerson1 IsNot Nothing Then
                        _pickPerson1.Social.Botsd = botsdNo
                        UpdateBotsdId(_pickPerson1.Social)
                    End If
                    If _pickPerson2 IsNot Nothing Then
                        _pickPerson2.Social.Botsd = botsdNo
                        UpdateBotsdId(_pickPerson2.Social)
                    End If
                    If _pickPerson3 IsNot Nothing Then
                        _pickPerson3.Social.Botsd = botsdNo
                        UpdateBotsdId(_pickPerson3.Social)
                    End If
                    If _pickPerson4 IsNot Nothing Then
                        _pickPerson4.Social.Botsd = botsdNo
                        UpdateBotsdId(_pickPerson4.Social)
                    End If
                    If CInt(thisWpNumber) = WpNumber Then
                        WpNumber += 1
                        GlobalSettings.SetSetting(My.Resources.NEXTWPNO, "integer", CStr(WpNumber))
                    End If
                End If
            End Using
            If _pickPerson1 IsNot Nothing Then _pickPerson1.Dispose()
            If _pickPerson2 IsNot Nothing Then _pickPerson2.Dispose()
            If _pickPerson3 IsNot Nothing Then _pickPerson3.Dispose()
            If _pickPerson4 IsNot Nothing Then _pickPerson4.Dispose()
        Catch ex As DbException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Db")
        End Try
    End Sub
#End Region
End Class
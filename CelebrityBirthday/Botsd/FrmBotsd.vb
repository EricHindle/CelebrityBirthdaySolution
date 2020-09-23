Imports System.Collections.ObjectModel
Imports System.ComponentModel
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
    Private isBuildingPairs As Boolean
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
        LblMonth.Text = ""
        LblDay.Text = ""
        GetAuthData()
        FillTwitterUserList()
        IsNoGenerate = False
    End Sub
    Private Sub DgvPairs_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPairs.SelectionChanged
        If Not isBuildingPairs Then GeneratePair()
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
            Dim _selCount As Integer = CInt(chkSel1.Checked) + CInt(ChkSel2.Checked) + CInt(ChkSel3.Checked) + CInt(ChkSel4.Checked) + CInt(ChkSel5.Checked) + CInt(ChkSel6.Checked)
            If _selCount <> -2 Then
                chkSel1.Checked = True
                _selCount = CInt(chkSel1.Checked) + CInt(ChkSel2.Checked) + CInt(ChkSel3.Checked) + CInt(ChkSel4.Checked) + CInt(ChkSel5.Checked) + CInt(ChkSel6.Checked)
                If _selCount <> -2 Then
                    ChkSel2.Checked = True
                End If
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
                        If ChkSel4.Checked Then
                            sel2IdCol = pairId4.Name
                            sel2NameCol = pairPerson4.Name
                        Else
                            If ChkSel5.Checked Then
                                sel2IdCol = pairId5.Name
                                sel2NameCol = pairPerson5.Name
                            Else
                                sel2IdCol = pairId6.Name
                                sel2NameCol = pairPerson6.Name
                            End If
                        End If
                    End If
                End If
            ElseIf ChkSel2.Checked Then
                sel1IdCol = pairId2.Name
                sel1NameCol = pairPerson2.Name
                If ChkSel3.Checked Then
                    sel2IdCol = pairId3.Name
                    sel2NameCol = pairPerson3.Name
                Else
                    If ChkSel4.Checked Then
                        sel2IdCol = pairId4.Name
                        sel2NameCol = pairPerson4.Name
                    Else
                        If ChkSel5.Checked Then
                            sel2IdCol = pairId5.Name
                            sel2NameCol = pairPerson5.Name
                        Else
                            sel2IdCol = pairId6.Name
                            sel2NameCol = pairPerson6.Name
                        End If
                    End If
                End If
            ElseIf ChkSel3.Checked Then
                sel1IdCol = pairId3.Name
                sel1NameCol = pairPerson3.Name
                If ChkSel4.Checked Then
                    sel2IdCol = pairId4.Name
                    sel2NameCol = pairPerson4.Name
                Else
                    If ChkSel5.Checked Then
                        sel2IdCol = pairId5.Name
                        sel2NameCol = pairPerson5.Name
                    Else
                        sel2IdCol = pairId6.Name
                        sel2NameCol = pairPerson6.Name
                    End If
                End If
            ElseIf ChkSel4.Checked Then
                sel1IdCol = pairId4.Name
                sel1NameCol = pairPerson4.Name
                If ChkSel5.Checked Then
                    sel2IdCol = pairId5.Name
                    sel2NameCol = pairPerson5.Name
                Else
                    sel2IdCol = pairId6.Name
                    sel2NameCol = pairPerson6.Name
                End If
            Else
                sel1IdCol = pairId5.Name
                sel1NameCol = pairPerson5.Name
                sel2IdCol = pairId6.Name
                sel2NameCol = pairPerson6.Name
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
    Private Sub BtnUpdate5_Click(sender As Object, e As EventArgs) Handles BtnUpdate5.Click
        Dim _pickPerson5 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId5.Name).Value)
        _pickPerson5.ShortDesc = TxtShortDesc5.Text

        If UpdateShortDesc(_pickPerson5) = 1 Then
            DisplayStatus("Updated person 5")
        Else
            DisplayStatus("Updated failed")
        End If
        _pickPerson5.Dispose()
    End Sub
    Private Sub BtnUpdate6_Click(sender As Object, e As EventArgs) Handles BtnUpdate6.Click
        Dim _pickPerson6 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId6.Name).Value)
        _pickPerson6.ShortDesc = TxtShortDesc6.Text

        If UpdateShortDesc(_pickPerson6) = 1 Then
            DisplayStatus("Updated person 6")
        Else
            DisplayStatus("Updated failed")
        End If
        _pickPerson6.Dispose()
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
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.botsdFilePath, FileIO.SearchOption.SearchTopLevelOnly, {My.Resources.BOTSD & "*.*"})
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
        UpdatePostNumbers()
    End Sub
    Private Sub BtnCopyAll_Click(sender As Object, e As EventArgs) Handles BtnCopyAll.Click
        rtbFile1.SelectAll()
        rtbFile1.Copy()
    End Sub
    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        cboDay.SelectedIndex = Today.Day - 1
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        SelectPairs()
    End Sub
    Private Sub BtnAlterPostNo_Click(sender As Object, e As EventArgs) Handles BtnAlterPostNo.Click
        Using _alterPost As New FrmAlterPostNo
            _alterPost.ShowDialog()
            UpdatePostNumbers()
        End Using
    End Sub
    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If DgvPairs.SelectedRows.Count = 1 Then
            Dim _row As DataGridViewRow = DgvPairs.SelectedRows(0)
            Dim _selCount As Integer = CInt(chkSel1.Checked) + CInt(ChkSel2.Checked) + CInt(ChkSel3.Checked) + CInt(ChkSel4.Checked) + CInt(ChkSel5.Checked) + CInt(ChkSel6.Checked)
            If _selCount < 0 Then
                If ChkSel6.Checked Then
                    _row.Cells(pairId6.Name).Value = Nothing
                    _row.Cells(pairPerson6.Name).Value = ""
                End If
                If ChkSel5.Checked Then
                    _row.Cells(pairId5.Name).Value = _row.Cells(pairId6.Name).Value
                    _row.Cells(pairPerson5.Name).Value = _row.Cells(pairPerson6.Name).Value
                    _row.Cells(pairId6.Name).Value = Nothing
                    _row.Cells(pairPerson6.Name).Value = ""
                End If

                If ChkSel4.Checked Then
                    _row.Cells(pairId4.Name).Value = _row.Cells(pairId5.Name).Value
                    _row.Cells(pairPerson4.Name).Value = _row.Cells(pairPerson5.Name).Value
                    _row.Cells(pairId5.Name).Value = _row.Cells(pairId6.Name).Value
                    _row.Cells(pairPerson5.Name).Value = _row.Cells(pairPerson6.Name).Value
                    _row.Cells(pairId6.Name).Value = Nothing
                    _row.Cells(pairPerson6.Name).Value = ""
                End If
                If ChkSel3.Checked Then
                    _row.Cells(pairId3.Name).Value = _row.Cells(pairId4.Name).Value
                    _row.Cells(pairPerson3.Name).Value = _row.Cells(pairPerson4.Name).Value
                    _row.Cells(pairId4.Name).Value = _row.Cells(pairId5.Name).Value
                    _row.Cells(pairPerson4.Name).Value = _row.Cells(pairPerson5.Name).Value
                    _row.Cells(pairId5.Name).Value = _row.Cells(pairId6.Name).Value
                    _row.Cells(pairPerson5.Name).Value = _row.Cells(pairPerson6.Name).Value
                    _row.Cells(pairId6.Name).Value = Nothing
                    _row.Cells(pairPerson6.Name).Value = ""
                End If
                If ChkSel2.Checked Then
                    _row.Cells(pairId2.Name).Value = _row.Cells(pairId3.Name).Value
                    _row.Cells(pairPerson2.Name).Value = _row.Cells(pairPerson3.Name).Value
                    _row.Cells(pairId3.Name).Value = _row.Cells(pairId4.Name).Value
                    _row.Cells(pairPerson3.Name).Value = _row.Cells(pairPerson4.Name).Value
                    _row.Cells(pairId4.Name).Value = _row.Cells(pairId5.Name).Value
                    _row.Cells(pairPerson4.Name).Value = _row.Cells(pairPerson5.Name).Value
                    _row.Cells(pairId5.Name).Value = _row.Cells(pairId6.Name).Value
                    _row.Cells(pairPerson5.Name).Value = _row.Cells(pairPerson6.Name).Value
                    _row.Cells(pairId6.Name).Value = Nothing
                    _row.Cells(pairPerson6.Name).Value = ""
                End If
                If chkSel1.Checked Then
                    _row.Cells(pairId1.Name).Value = _row.Cells(pairId2.Name).Value
                    _row.Cells(pairPerson1.Name).Value = _row.Cells(pairPerson2.Name).Value
                    _row.Cells(pairId2.Name).Value = _row.Cells(pairId3.Name).Value
                    _row.Cells(pairPerson2.Name).Value = _row.Cells(pairPerson3.Name).Value
                    _row.Cells(pairId3.Name).Value = _row.Cells(pairId4.Name).Value
                    _row.Cells(pairPerson3.Name).Value = _row.Cells(pairPerson4.Name).Value
                    _row.Cells(pairId4.Name).Value = _row.Cells(pairId5.Name).Value
                    _row.Cells(pairPerson4.Name).Value = _row.Cells(pairPerson5.Name).Value
                    _row.Cells(pairId5.Name).Value = _row.Cells(pairId6.Name).Value
                    _row.Cells(pairPerson5.Name).Value = _row.Cells(pairPerson6.Name).Value
                    _row.Cells(pairId6.Name).Value = Nothing
                    _row.Cells(pairPerson6.Name).Value = ""
                End If
                GeneratePair()
                If _row.Cells(pairId2.Name).Value Is Nothing Then
                    DgvPairs.Rows.Remove(_row)
                End If
            Else
                DgvPairs.Rows.Remove(_row)
            End If
        End If
    End Sub
    Private Sub BtnAtoZ_Click(sender As Object, e As EventArgs) Handles BtnAtoZ.Click
        Dim oRows As DataRowCollection = GetBotsdIndex()
        Dim currentLetter As String = String.Empty
        Dim indexText As New StringBuilder
        For Each oRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow In oRows
            Try
                Dim surnameInitial As String = oRow.surname.Substring(0, 1)
                Dim tempBytes As Byte() = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(surnameInitial)
                surnameInitial = System.Text.Encoding.UTF8.GetString(tempBytes).ToLower
                If surnameInitial <> currentLetter Then
                    If Not String.IsNullOrEmpty(currentLetter) Then
                        indexText.Append(GetLetterFoot())
                    End If
                    indexText.Append(GetLetterHead(surnameInitial.ToUpper(myCultureInfo)))
                    currentLetter = surnameInitial
                End If
                indexText.Append(GetIndexEntry(oRow))
            Catch ex1 As DecoderFallbackException
                DisplayException(MethodBase.GetCurrentMethod(), ex1, "Decoder")
            Catch ex2 As EncoderFallbackException
                DisplayException(MethodBase.GetCurrentMethod(), ex2, "Encoder")
            Catch ex3 As ArgumentException
                DisplayException(MethodBase.GetCurrentMethod(), ex3, "Record value")
            End Try
        Next
        Using _text As New FrmText
            _text.rtbText.Text = indexText.ToString
            _text.ShowDialog()
        End Using
    End Sub
    Private Sub BtnRmvPostDetails_Click(sender As Object, e As EventArgs) Handles BtnRmvPostDetails.Click
        Using _rmvPost As New FrmRmvPost
            _rmvPost.ShowDialog()
        End Using
    End Sub
    Private Sub ChkHandles_CheckedChanged(sender As Object, e As EventArgs) Handles ChkHandles.CheckedChanged
        GeneratePair()
    End Sub
#End Region
#Region "subroutines"
    Private Function SaveImage() As String
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.botsdFilePath
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
                Dim postUrl As String = ""
                Dim postNo As Integer = GetBotsdPostNo(personsList(0).Social.Botsd, postUrl)
                _pairRow.Cells(pairWpNo.Name).Value = If(postNo > -1, CStr(postNo), "")
                _pairRow.Cells(pairUrl.Name).Value = postUrl
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
            If personsList.Count > 4 Then
                _pairRow.Cells(pairId5.Name).Value = personsList(4).Id
                _pairRow.Cells(pairPerson5.Name).Value = personsList(4).Name
            End If
            If personsList.Count > 5 Then
                _pairRow.Cells(pairId6.Name).Value = personsList(5).Id
                _pairRow.Cells(pairPerson6.Name).Value = personsList(5).Name
            End If
        End If
        DgvPairs.Sort(DgvPairs.Columns(0), ListSortDirection.Ascending)
    End Sub
    Private Sub GeneratePair()
        ClearPersonDetails()
        If DgvPairs.SelectedRows.Count = 1 Then
            Try
                Dim _pickPerson1 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId1.Name).Value)
                Dim _pickPerson2 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId2.Name).Value)
                Dim _pickPerson3 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId3.Name).Value)
                Dim _pickPerson4 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId4.Name).Value)
                Dim _pickPerson5 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId5.Name).Value)
                Dim _pickPerson6 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId6.Name).Value)
                _imageList = New List(Of Person)
                chkSel1.Checked = False
                ChkSel2.Checked = False
                ChkSel3.Checked = False
                ChkSel4.Checked = False
                ChkSel5.Checked = False
                ChkSel6.Checked = False
                If _pickPerson1 IsNot Nothing Then
                    TxtForename1.Text = _pickPerson1.ForeName
                    TxtSurname1.Text = _pickPerson1.Surname
                    TxtShortDesc1.Text = _pickPerson1.ShortDesc
                    LblId1.Text = CStr(_pickPerson1.Id)
                    _imageList.Add(_pickPerson1)
                    GroupBox1.Enabled = True
                End If
                If _pickPerson2 IsNot Nothing Then
                    TxtForename2.Text = _pickPerson2.ForeName
                    TxtSurname2.Text = _pickPerson2.Surname
                    TxtShortDesc2.Text = _pickPerson2.ShortDesc
                    LblId2.Text = CStr(_pickPerson2.Id)
                    _imageList.Add(_pickPerson2)
                    GroupBox2.Enabled = True
                End If
                If _pickPerson3 IsNot Nothing Then
                    TxtForename3.Text = _pickPerson3.ForeName
                    TxtSurname3.Text = _pickPerson3.Surname
                    TxtShortDesc3.Text = _pickPerson3.ShortDesc
                    LblId3.Text = CStr(_pickPerson3.Id)
                    _imageList.Add(_pickPerson3)
                    GroupBox3.Enabled = True
                End If
                If _pickPerson4 IsNot Nothing Then
                    TxtForename4.Text = _pickPerson4.ForeName
                    TxtSurname4.Text = _pickPerson4.Surname
                    TxtShortDesc4.Text = _pickPerson4.ShortDesc
                    LblId4.Text = CStr(_pickPerson4.Id)
                    _imageList.Add(_pickPerson4)
                    GroupBox4.Enabled = True
                End If
                If _pickPerson5 IsNot Nothing Then
                    TxtForename5.Text = _pickPerson5.ForeName
                    TxtSurname5.Text = _pickPerson5.Surname
                    TxtShortDesc5.Text = _pickPerson5.ShortDesc
                    LblId5.Text = CStr(_pickPerson5.Id)
                    _imageList.Add(_pickPerson5)
                    GroupBox7.Enabled = True
                End If
                If _pickPerson6 IsNot Nothing Then
                    TxtForename6.Text = _pickPerson6.ForeName
                    TxtSurname6.Text = _pickPerson6.Surname
                    TxtShortDesc6.Text = _pickPerson6.ShortDesc
                    LblId6.Text = CStr(_pickPerson6.Id)
                    _imageList.Add(_pickPerson6)
                    GroupBox6.Enabled = True
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
        If ChkHandles.Checked Then
            Dim handleString As New StringBuilder
            For Each _person As Person In _imageTable
                If _person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle) Then
                    handleString.Append(" @").Append(_person.Social.TwitterHandle)
                End If
            Next
            If Not String.IsNullOrEmpty(handleString.ToString.Trim) Then
                _outString.Append(vbCrLf).Append(vbCrLf).Append("[").Append(handleString.ToString).Append(" ]")
            End If
        End If
        rtbFile1.Text = _outString.ToString
    End Sub
    Private Sub GenerateWordpress()
        Dim sb As New StringBuilder
        With sb
            .Append(My.Resources.WP_PARA).Append(vbCrLf)
            .Append("<strong>").Append(CStr(ThisDay))
            Select Case ThisDay
                Case 1, 21, 31
                    .Append("st")
                Case 2, 22
                    .Append("nd")
                Case 3, 23
                    .Append("rd")
                Case Else
                    .Append("th")
            End Select
            .Append("</strong>")
            .Append(My.Resources.BREAK).Append(vbCrLf)
        End With
        With sb
            For Each oRow As DataGridViewRow In DgvPairs.Rows
                If Not String.IsNullOrEmpty(oRow.Cells(pairYear.Name).Value) Then
                    Dim _pickPerson1 As Person = GetFullPersonById(oRow.Cells(pairId1.Name).Value)
                    Dim btsdUrl As String = ""
                    Dim postNo As Integer = GetBotsdPostNo(_pickPerson1.Social.Botsd, btsdUrl)
                    With sb
                        .Append(oRow.Cells(pairYear.Name).Value)
                        .Append(My.Resources.TWO_SPACES)
                        If Not String.IsNullOrEmpty(oRow.Cells(pairPerson1.Name).Value) Then
                            .Append(oRow.Cells(pairPerson1.Name).Value)
                        End If
                        If Not String.IsNullOrEmpty(oRow.Cells(pairPerson2.Name).Value) Then
                            .Append(My.Resources.TWO_SPACES).Append("/").Append(My.Resources.TWO_SPACES)
                            .Append(oRow.Cells(pairPerson2.Name).Value)
                        End If
                        If Not String.IsNullOrEmpty(oRow.Cells(pairPerson3.Name).Value) Then
                            .Append(My.Resources.TWO_SPACES).Append("/").Append(My.Resources.TWO_SPACES)
                            .Append(oRow.Cells(pairPerson3.Name).Value)
                        End If
                        If Not String.IsNullOrEmpty(oRow.Cells(pairPerson4.Name).Value) Then
                            .Append(My.Resources.TWO_SPACES).Append("/").Append(My.Resources.TWO_SPACES)
                            .Append(oRow.Cells(pairPerson4.Name).Value)
                        End If
                        If Not String.IsNullOrEmpty(oRow.Cells(pairPerson5.Name).Value) Then
                            .Append(My.Resources.TWO_SPACES).Append("/").Append(My.Resources.TWO_SPACES)
                            .Append(oRow.Cells(pairPerson5.Name).Value)
                        End If
                        If Not String.IsNullOrEmpty(oRow.Cells(pairPerson6.Name).Value) Then
                            .Append(My.Resources.TWO_SPACES).Append("/").Append(My.Resources.TWO_SPACES)
                            .Append(oRow.Cells(pairPerson6.Name).Value)
                        End If

                        .Append(My.Resources.TWO_SPACES)
                        If postNo > -1 Then

                            .Append(My.Resources.WP_A_HREF)
                            .Append(My.Resources.DOUBLEQUOTES)
                            .Append(btsdUrl)
                            .Append(My.Resources.DOUBLEQUOTES)
                            .Append(" target=")
                            .Append(My.Resources.DOUBLEQUOTES)
                            .Append("_blank")
                            .Append(My.Resources.DOUBLEQUOTES)
                            .Append(" rel=")
                            .Append(My.Resources.DOUBLEQUOTES)
                            .Append("noreferrer noopener")
                            .Append(My.Resources.DOUBLEQUOTES)
                            .Append(">#")
                            .Append(CStr(postNo))
                            .Append(My.Resources.WP_END_A)
                        End If
                        .Append(My.Resources.BREAK)
                        .Append(vbCrLf)

                    End With
                    _pickPerson1.Dispose()
                End If
            Next
            .Append(My.Resources.WP_END_PARA).Append(vbCrLf)
        End With
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
        Dim imagename As String = oImage.ImageFileName
        Dim lowername As String = oPerson.Name.ToLower(myCultureInfo).Replace(" ", "-").Replace(".", "")
        If String.IsNullOrEmpty(imagename) Then
            imagename = lowername
        End If
        oImage.Dispose()
        Dim ImageSb As New StringBuilder
        With ImageSb
            .Append("<!-- wp:image {""linkDestination"":""custom""} -->")
            .Append(vbCrLf)
            .Append("<figure class=""wp-block-image"">")
            .Append(My.Resources.WP_A_HREF)
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
            .Append(imagename)
            .Append(oPerson.Image.ImageFileType)
            .Append("?w=150&amp;h=150"" alt=")
            .Append(My.Resources.DOUBLEQUOTES).Append(imagename).Append(My.Resources.DOUBLEQUOTES)
            .Append(">")
            .Append(My.Resources.WP_END_A)
            .Append("</figure>")
            .Append(vbCrLf)
            .Append("<!-- /wp:image -->")
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
            .Append("<!-- wp:heading {""level"":1} -->").Append(vbCrLf)
            .Append("<h1 id=""firstHeading"">").Append(oPerson.Name)
            .Append("</h1>").Append(vbCrLf)
            .Append("<!-- /wp:heading -->").Append(vbCrLf)
            .Append(vbCrLf)
            .Append(GetImageLink(oPerson)).Append(vbCrLf)
            .Append(My.Resources.WP_PARA).Append(vbCrLf)
            .Append(oPerson.Description).Append(sBorn)
            .Append(If(oPerson.DeathYear = 0, "", sDied)).Append(vbCrLf)
            .Append(My.Resources.WP_END_PARA).Append(vbCrLf).Append(vbCrLf)
        End With
        Return oPersonText.ToString
    End Function
    Private Shared Function GetWikiLinkText(oPerson As Person) As String
        Dim oImageText As New StringBuilder
        With oImageText
            .Append(My.Resources.WP_A_HREF)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(My.Resources.WIKIURL)
            .Append(oPerson.Social.WikiId)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(" target="" _blank"" rel="" noreferrer noopener"">")
            .Append(My.Resources.WIKIURL)
            .Append(oPerson.Social.WikiId)
            .Append(My.Resources.WP_END_A).Append(My.Resources.BREAK)
            .Append(vbCrLf)
        End With
        Return oImageText.ToString
    End Function
    Private Sub GenerateWpPost()
        If DgvPairs.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Dim sb As New StringBuilder
        Dim titleSb As New StringBuilder
        Dim thisWpNumber As String = DgvPairs.SelectedRows(0).Cells(pairWpNo.Name).Value
        Dim thisUrl As String = DgvPairs.SelectedRows(0).Cells(pairUrl.Name).Value
        Dim thisYear As String = DgvPairs.SelectedRows(0).Cells(pairYear.Name).Value
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
            Dim _pickPerson5 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId5.Name).Value)
            Dim _pickPerson6 As Person = GetFullPersonById(DgvPairs.SelectedRows(0).Cells(pairId6.Name).Value)
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
            If _pickPerson5 IsNot Nothing Then
                sb.Append(GetPersonText(_pickPerson5))
                titleSb.Append(_sep).Append(_pickPerson5.Name)
                titleDate = Format(_pickPerson5.DateOfBirth, "dd MMMM yyyy")
            End If
            If _pickPerson6 IsNot Nothing Then
                sb.Append(GetPersonText(_pickPerson6))
                titleSb.Append(_sep).Append(_pickPerson6.Name)
                titleDate = Format(_pickPerson6.DateOfBirth, "dd MMMM yyyy")
            End If

            titleSb.Append(" - ").Append(titleDate)
            sb.Append(My.Resources.WP_PARA).Append(vbCrLf)
            sb.Append("Links:").Append(My.Resources.BREAK)

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
            If _pickPerson5 IsNot Nothing AndAlso Not String.IsNullOrEmpty(_pickPerson5.Social.WikiId) Then
                sb.Append(GetWikiLinkText(_pickPerson5))
            End If
            If _pickPerson6 IsNot Nothing AndAlso Not String.IsNullOrEmpty(_pickPerson6.Social.WikiId) Then
                sb.Append(GetWikiLinkText(_pickPerson6))
            End If
            sb.Append(My.Resources.WP_END_PARA).Append(vbCrLf)
            sb.Append(vbCrLf)
            With sb
                .Append("<!-- wp:more {""customText"":""Also born on this day...""} -->").Append(vbCrLf)
                .Append("<!--more Also born on this day...-->").Append(vbCrLf)
                .Append("<!-- /wp:more -->").Append(vbCrLf)
                .Append(vbCrLf)
                .Append(My.Resources.WP_PARA).Append(vbCrLf)
                .Append("Also born on this day:").Append(vbCrLf)
                .Append(My.Resources.WP_END_PARA).Append(vbCrLf)
            End With
            Using oTextForm As New FrmBotsdPost
                With oTextForm
                    .TxtTitle.Text = titleSb.ToString
                    .PostText = sb.ToString
                    .LblWpPostNo.Text = thisWpNumber
                    .TxtUrl.Text = thisUrl
                    .LblDay.Text = CStr(ThisDay)
                    .LblMonth.Text = Format(New Date(2000, ThisMonth, 1), "MMMM")
                    .LblYear.Text = thisYear
                    .ShowDialog()
                    If .DialogResult = DialogResult.OK Then
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
                        If _pickPerson5 IsNot Nothing Then
                            _pickPerson5.Social.Botsd = botsdNo
                            UpdateBotsdId(_pickPerson5.Social)
                        End If
                        If _pickPerson6 IsNot Nothing Then
                            _pickPerson6.Social.Botsd = botsdNo
                            UpdateBotsdId(_pickPerson6.Social)
                        End If
                        If CInt(thisWpNumber) = WpNumber Then
                            WpNumber += 1
                            GlobalSettings.SetSetting(My.Resources.NEXTWPNO, "integer", CStr(WpNumber))
                        End If
                    End If
                End With
            End Using
            If _pickPerson1 IsNot Nothing Then _pickPerson1.Dispose()
            If _pickPerson2 IsNot Nothing Then _pickPerson2.Dispose()
            If _pickPerson3 IsNot Nothing Then _pickPerson3.Dispose()
            If _pickPerson4 IsNot Nothing Then _pickPerson4.Dispose()
            If _pickPerson5 IsNot Nothing Then _pickPerson5.Dispose()
            If _pickPerson6 IsNot Nothing Then _pickPerson6.Dispose()

        Catch ex As DbException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Db")
        End Try
    End Sub
    Private Shared Function GetIndexEntry(oRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow) As String
        Dim entry As New StringBuilder
        With entry
            .Append(oRow.surname)
            .Append(", ")
            .Append(oRow.forename)
            .Append(" (")
            .Append(CStr(oRow.birthyear))
            .Append(")")
            .Append(My.Resources.TWO_SPACES)
            .Append(My.Resources.WP_A_HREF)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(oRow.btsdUrl)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(">#")
            .Append(CStr(oRow.btsdPostNo))
            .Append(My.Resources.WP_END_A)
            .Append(vbCrLf)
        End With
        Return entry.ToString
    End Function
    Private Shared Function GetLetterHead(surnameInitial As String) As String
        Dim heading As New StringBuilder
        With heading
            .Append("<h1><a name=")
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(surnameInitial)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(">")
            .Append(My.Resources.WP_END_A)
            .Append(surnameInitial)
            .Append("</h1>")
            .Append(vbCrLf)
        End With
        Return heading.ToString
    End Function
    Private Shared Function GetLetterFoot() As String
        Dim footing As New StringBuilder
        With footing
            .Append("<h6>")
            .Append(My.Resources.WP_A_HREF)
            .Append(My.Resources.DOUBLEQUOTES)
            .Append("#Top")
            .Append(My.Resources.DOUBLEQUOTES)
            .Append(">Back to top")
            .Append(My.Resources.WP_END_A)
            .Append("</h6>")
            .Append(vbCrLf)
        End With
        Return footing.ToString
    End Function
    Private Sub ClearPersonDetails()
        LblId1.Text = ""
        LblId2.Text = ""
        LblId3.Text = ""
        LblId4.Text = ""
        LblId5.Text = ""
        LblId6.Text = ""
        GroupBox1.Enabled = False
        GroupBox2.Enabled = False
        GroupBox3.Enabled = False
        GroupBox4.Enabled = False
        GroupBox7.Enabled = False
        GroupBox6.Enabled = False
        TxtForename1.Text = ""
        TxtSurname1.Text = ""
        TxtShortDesc1.Text = ""
        TxtForename2.Text = ""
        TxtSurname2.Text = ""
        TxtShortDesc2.Text = ""
        TxtForename3.Text = ""
        TxtSurname3.Text = ""
        TxtShortDesc3.Text = ""
        TxtForename4.Text = ""
        TxtSurname4.Text = ""
        TxtShortDesc4.Text = ""
        TxtForename5.Text = ""
        TxtSurname5.Text = ""
        TxtShortDesc5.Text = ""
        TxtForename6.Text = ""
        TxtSurname6.Text = ""
        TxtShortDesc6.Text = ""
        rtbFile1.Text = ""
        PictureBox1.Image = Nothing
    End Sub
    Private Sub UpdatePostNumbers()
        For Each oRow As DataGridViewRow In DgvPairs.Rows
            Try
                If oRow.Cells(pairId1.Name).Value IsNot Nothing Then
                    Dim _personId As Integer = CInt(oRow.Cells(pairId1.Name).Value)
                    Dim _firstPerson As Person = GetFullPersonById(_personId)
                    If _firstPerson IsNot Nothing Then
                        Dim botsdUrl As String = ""
                        If _firstPerson.Social IsNot Nothing AndAlso _firstPerson.Social.Botsd > 0 Then
                            Dim postNo As Integer = GetBotsdPostNo(_firstPerson.Social.Botsd, botsdUrl)
                            oRow.Cells(pairWpNo.Name).Value = postNo
                            oRow.Cells(pairUrl.Name).Value = botsdUrl
                        End If
                        _firstPerson.Dispose()
                    End If
                End If
            Catch ex As OverflowException
                DisplayException(MethodBase.GetCurrentMethod(), ex, "Conversion")
            End Try
        Next
    End Sub
    Private Sub SelectPairs()
        rtbFile1.Text = ""
        isBuildingPairs = True
        ClearPersonDetails()

        Try
            ThisDay = cboDay.SelectedIndex + 1
            ThisMonth = cboMonth.SelectedIndex + 1
            LblMonth.Text = Format(New Date(2000, ThisMonth, 1), "MMMM")
            LblDay.Text = CStr(ThisDay)
            Dim _wpDate As Date? = GetWordPressLoadDate(ThisDay, ThisMonth, "P")
            urlDay = If(_wpDate Is Nothing, "", Format(_wpDate, "dd"))
            urlMonth = If(_wpDate Is Nothing, "", Format(_wpDate, "MM"))
            urlYear = If(_wpDate Is Nothing, "", Format(_wpDate, "yyyy"))
            imageLoadMonth = urlMonth
            imageLoadYear = urlYear
            Dim _fullList As List(Of Person) = FindTodays(ThisDay, ThisMonth, False)
            DgvPairs.Rows.Clear()

            Dim lastYear As String = ""
            Dim _sameYearList As New List(Of Person)
            For Each oPerson As Person In _fullList
                If Not oPerson.BirthYear.Equals(lastYear, Global.System.StringComparison.Ordinal) Then
                    If _sameYearList.Count > 1 Then
                        AddList(_sameYearList)
                    End If
                    _sameYearList = New List(Of Person)
                    lastYear = oPerson.BirthYear
                End If
                _sameYearList.Add(oPerson)
            Next
            If _sameYearList.Count > 1 Then
                AddList(_sameYearList)
            End If

            Select Case True
                Case rbImageRight.Checked
                    rbImageRight.Checked = True
                Case rbImageLeft.Checked
                    rbImageLeft.Checked = True
                Case rbImageCentre.Checked
                    rbImageCentre.Checked = True
            End Select
            DgvPairs.ClearSelection()
        Catch ex As ArgumentOutOfRangeException
            MsgBox("No date selected", MsgBoxStyle.Exclamation, "Error")
            Me.Close()
        End Try
        isBuildingPairs = False
    End Sub
#End Region
End Class
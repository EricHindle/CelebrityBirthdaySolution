' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports mshtml
Imports TweetSharp
Public Class FrmSendTwitter
#Region "properties"
    Private _sendAs As String
    Private _tweetText As String
    Public Property TweetText() As String
        Get
            Return _tweetText
        End Get
        Set(ByVal value As String)
            _tweetText = value
        End Set
    End Property
    Public Property SendAs() As String
        Get
            Return _sendAs
        End Get
        Set(ByVal value As String)
            _sendAs = value
        End Set
    End Property
#End Region
#Region "variables"
    Private isDone As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private ReadOnly oTweetTa As New CelebrityBirthdayDataSetTableAdapters.TweetsTableAdapter
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Async Sub BtnAuthenticate_Click(sender As Object, e As EventArgs) Handles BtnAuthenticate.Click
        Label7.Text = "Check Twitter User"
        cmbTwitterUsers.SelectedIndex = -1
        WriteTrace("======= Authenticating ========")
        WriteTrace("GetAuthToken " & Format(Now, "hh:MM:ss"))
        isDone = False
        Await GetAuthToken().ConfigureAwait(True)
        BtnAuthenticate.Enabled = False
        WriteTrace("Authenticate " & Format(Now, "hh:MM:ss"))
        isDone = False
        Authenticate()
        WriteTrace("====== Complete =======")
        BtnAuthenticate.Enabled = True
    End Sub
    Private Sub FrmSendTwitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.sndtwformpos)
        NudSentences.Value = My.Settings.wikiSentences
        RtbTweetText.AllowDrop = True
        WebBrowser1.Navigate(New Uri("about:blank"))
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
        FillTwitterUserList()
        cmbTwitterUsers.SelectedIndex = cmbTwitterUsers.FindStringExact(SendAs)
        RtbTweetText.Text = TweetText
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
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
        isDone = False
        If isOkToSend Then
            SendTheTweet()
        End If
        WriteTrace(isDone)
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))
    End Sub
    Private Sub FrmSendTwitter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        oTweetTa.Dispose()
        My.Settings.sndtwformpos = SetFormPos(Me)
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
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtForename.Text = ""
        TxtSurname.Text = ""
        rtbTweetProgress.Text = ""
        RtbTweetText.Text = ""
        PictureBox1.Image = My.Resources.NoImage
        PictureBox2.Image = Nothing
        LblTweetLength.Text = ""
        LblImageName.Text = ""
        LblImageFile.Text = ""
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _fileName As String = GetUniqueFname(Path.Combine(_path, My.Resources.SINGLE_TWEET) & ".jpg")
        ImageUtil.SaveImageFromPictureBox(PictureBox2, PictureBox2.Width, PictureBox2.Height, _fileName)
    End Sub
    Private Sub BtnClearImages_Click(sender As Object, e As EventArgs) Handles BtnClearImages.Click
        If MsgBox("Confirm delete tweet images", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.twitterImageFolder, FileIO.SearchOption.SearchTopLevelOnly, {My.Resources.SINGLE_TWEET & "*.*"})
            For Each _imageFile As String In _imageList
                My.Computer.FileSystem.DeleteFile(_imageFile)
            Next
        End If
    End Sub
    Private Sub TxtForename_TextChanged(sender As Object, e As EventArgs) Handles TxtSurname.TextChanged, TxtForename.TextChanged
        LblImageName.Text = MakeImageName(TxtForename.Text, TxtSurname.Text)
        Dim thumbnailImage As String = Path.Combine(My.Settings.ImgPath, LblImageName.Text) & ".jpg"
        If My.Computer.FileSystem.FileExists(thumbnailImage) Then
            PictureBox1.ImageLocation = thumbnailImage
            CreateTwitterImage(thumbnailImage)
            RtbTweetText.Text = GetWikiText(NudSentences.Value)
        End If
    End Sub
    Private Sub RtbTweetText_TextChanged(sender As Object, e As EventArgs) Handles RtbTweetText.TextChanged
        Dim _tweetLength As Integer = RtbTweetText.Text.Replace(vbCr, "").Length
        LblTweetLength.Text = If(_tweetLength > 280, "** ", "") & CStr(_tweetLength)
    End Sub
    Private Sub BtnImage_Click(sender As Object, e As EventArgs) Handles BtnImage.Click
        If Not String.IsNullOrEmpty(TxtForename.Text) Or Not String.IsNullOrEmpty(TxtSurname.Text) Then
            LblImageName.Text = MakeImageName(TxtForename.Text, TxtSurname.Text)
            Using _imagestore As New FrmImageStore
                _imagestore.Forename = TxtForename.Text.Trim
                _imagestore.Surname = TxtSurname.Text.Trim
                _imagestore.ShowDialog()
                PictureBox1.ImageLocation = _imagestore.SavedImage
                CreateTwitterImage(_imagestore.SavedImage)
            End Using
        Else
            MsgBox("No name supplied", MsgBoxStyle.Exclamation, "Name missing")
        End If
    End Sub
    Private Sub BtnCreateFullName_Click(sender As Object, e As EventArgs) Handles BtnCreateFullName.Click
        TxtName.Text = If(String.IsNullOrEmpty(TxtForename.Text), "", TxtForename.Text.Trim & " ") & TxtSurname.Text.Trim
    End Sub
    Private Sub BtnSplitName_Click(sender As Object, e As EventArgs) Handles BtnSplitName.Click
        TxtName.Text = TxtName.Text.Trim
        Dim names As String() = Split(TxtName.Text, " ")
        TxtSurname.Text = names(UBound(names))
        If Not String.IsNullOrEmpty(TxtSurname.Text) Then
            TxtForename.Text = TxtName.Text.Replace(TxtSurname.Text, "").Trim
        End If
    End Sub
    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtName.DragDrop,
                                                                                            TxtForename.DragDrop,
                                                                                            TxtSurname.DragDrop

        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            Dim textlen As Integer = oBox.TextLength
            Dim startpos As Integer = oBox.SelectionStart
            If textlen = 0 Then
                oBox.Text = item.Trim
            Else
                If startpos = 0 Then
                    oBox.SelectedText = item.TrimStart
                Else
                    If oBox.Text.Substring(startpos - 1, 1) = "." Then
                        oBox.SelectedText = " " & item.TrimStart
                    Else
                        oBox.SelectedText = item
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TextBox_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtName.DragOver,
                                                                                                                TxtForename.DragOver,
                                                                                                                TxtSurname.DragOver

        Try
            If e.Data.GetDataPresent(DataFormats.StringFormat) Then
                Dim oBox As TextBox = CType(sender, TextBox)
                oBox.Select(TextBoxCursorPos(oBox, e.X, e.Y), 0)
            End If
        Catch ex As InvalidCastException

        End Try
    End Sub
    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtForename.DragEnter,
                                                                                                                TxtSurname.DragEnter,
                                                                                                                TxtName.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            If e.Data.GetDataPresent(DataFormats.Text) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub
    Private Async Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WriteTrace("Browser document complete")
        WriteTrace("Looking for Verifier")
        Try
            Dim webHtml As Windows.Forms.HtmlDocument = WebBrowser1.Document
            Dim _innerHtml As String = webHtml.Body.InnerHtml
            Dim doc As IHTMLDocument2 = WebBrowser1.Document.DomDocument
            Dim allElements As IHTMLElementCollection = doc.all
            Dim allHeads As IHTMLElementCollection = allElements.tags("head")
            For Each element As HTMLHeadElement In allHeads
                Dim allMeta As IHTMLElementCollection = element.getElementsByTagName("meta")
                For Each metaElement As IHTMLElement In allMeta
                    Dim _outerHTML As String = metaElement.outerHTML
                    Dim _index As Integer = _outerHTML.IndexOf("oauth_verifier=", StringComparison.CurrentCultureIgnoreCase)
                    If _index > -1 Then
                        Dim _startIndex As Integer = _index + 15
                        Dim _length As Integer = _outerHTML.Length - _startIndex - 2
                        Dim verifier As String = _outerHTML.Substring(_startIndex, _length)
                        tw.Verifier = verifier
                        Dim _twitterUser As String = GetTwitterName(_innerHtml)
                        GlobalSettings.GetSetting(_twitterUser)
                        GlobalSettings.SetSetting(_twitterUser, "string", verifier, "twitter")
                        WriteTrace("Verifier = " & verifier)
                        TxtOauthVerifier.Text = verifier
                        Await GetAccessToken().ConfigureAwait(True)
                        WriteTrace("Updating database")
                        UpdateAuth(_twitterUser, tw.Token, tw.TokenSecret, tw.Verifier)
                        Label7.Text = _twitterUser & " is authenticated"
                    End If
                Next
            Next
        Catch ex As ArgumentException
            WriteTrace(ex.Message)
        End Try
        WriteTrace("Browser finished")
    End Sub
    Private Sub BtnGetWikiText_Click(sender As Object, e As EventArgs) Handles BtnGetWikiText.Click
        RtbTweetText.Text = GetWikiText(NudSentences.Value)
    End Sub
#End Region
#Region "subroutines"
    Private Sub Authenticate()
        WriteTrace("Navigating")
        WebBrowser1.Navigate(New Uri("https://api.twitter.com/oauth/authorize?oauth_token=" & tw.Token))
    End Sub
    Private Shared Function GetTwitterName(_innerHtml As String) As String
        Dim _pos1 As Integer = _innerHtml.IndexOf("span class=""name""", StringComparison.CurrentCultureIgnoreCase) + 18
        Dim _pos2 As Integer = _innerHtml.IndexOf("/span", _pos1, StringComparison.CurrentCultureIgnoreCase)
        Dim _twitterName As String = "Unknown"
        If _pos1 > 0 AndAlso _pos2 > _pos1 Then
            _twitterName = _innerHtml.Substring(_pos1, _pos2 - _pos1 - 1)
        End If
        Return _twitterName
    End Function
    Private Async Function GetAccessToken() As Threading.Tasks.Task(Of Boolean)
        WriteTrace("Get Verified AccessToken " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_consumer", tw.ConsumerKey},
                {"oauth_token", tw.Token},
                {"oauth_verifier", tw.Verifier}}
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.ACCESSTOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)
            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Using hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))
                WriteTrace("Building Signature " & Format(Now, "hh:MM:ss"))
                _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            End Using
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            WriteTrace("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/access_token", "").ConfigureAwait(True)
            WriteTrace("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(True)
            If responseString.Length > 0 Then
                WriteTrace("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")
                    TxtVerifiedOauthToken.Text = tw.Token
                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")
                    TxtVerifiedOauthTokenSecret.Text = tw.TokenSecret
                End If
                WriteTrace("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            WriteTrace("Verified token : " & tw.Token)
            WriteTrace("Verified secret : " & tw.TokenSecret)
        End Using
        WriteTrace("Finished Verified AccessToken " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function
    Private Async Function GetAuthToken() As Threading.Tasks.Task(Of Boolean)
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            Dim _nonce As String = tw.GenerateNonce()
            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_nonce", _nonce},
                {"oauth_callback", tw.CallbackUrl.ToString},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_timestamp", Convert.ToInt64(timestamp.TotalSeconds)},
                {"oauth_consumer_key", tw.ConsumerKey},
                {"oauth_version", "1.0"}}
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.REQUESTTOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)
            WriteTrace(baseString)
            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Using hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))
                WriteTrace("Building Signature " & Format(Now, "hh:MM:ss"))
                _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            End Using
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            WriteTrace("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/request_token", "").ConfigureAwait(True)
            WriteTrace("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync().ConfigureAwait(True)
            If responseString.Length > 0 Then
                WriteTrace("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")
                    TxtOauthToken.Text = tw.Token
                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")
                    TxtOauthTokenSecret.Text = tw.TokenSecret
                End If
            End If
            WriteTrace("Token: " & tw.Token)
            WriteTrace("Secret: " & tw.TokenSecret)
        End Using
        WriteTrace("Finished GetAuthToken " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function
    Private Sub FillTwitterUserList()
        cmbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            cmbTwitterUsers.Items.Add(_user)
        Next
    End Sub
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweetProgress.Text &= vbCrLf & sText
        If isStatus Then ShowStatus(sText)
        LogUtil.Info(sText, MyBase.Name)
    End Sub
    Private Sub SendTheTweet()
        ShowStatus("Sending Tweet")
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = RtbTweetText.Text
        sto.Status = msg.Substring(0, Math.Min(msg.Length, TWEET_MAX_LEN)) ' max tweet length; tweets fail if too long...
        Dim _mediaId As String = Nothing
        Dim _imageFile As String = Nothing
        If chkImages.Checked Then
            If My.Computer.FileSystem.FileExists(LblImageFile.Text) Then
                WriteTrace("Saving Image")
                Dim _path As String = My.Settings.twitterImageFolder
                If Not My.Computer.FileSystem.DirectoryExists(_path) Then
                    My.Computer.FileSystem.CreateDirectory(_path)
                End If
                Dim _fileName As String = GetUniqueFname(Path.Combine(_path, My.Resources.SINGLE_TWEET) & ".jpg")
                _imageFile = ImageUtil.SaveImageFromPictureBox(PictureBox2, PictureBox2.Width, PictureBox2.Height, _fileName)
                Dim _twitterUplMedia As TwitterUploadedMedia = PostMedia(twitter, _imageFile)
                If _twitterUplMedia IsNot Nothing Then
                    Dim _uploadedSize As Long = _twitterUplMedia.Size
                    Dim _uploadedImage As UploadedImage = _twitterUplMedia.Image
                    WriteTrace("Image upload size: " & CStr(_uploadedSize), False)
                    _mediaId = _twitterUplMedia.Media_Id
                Else
                    WriteTrace("No image upload", False)
                End If
            End If
        End If
        If Not String.IsNullOrEmpty(_mediaId) Then
            InsertTweet(_imageFile, Today.Month + 1, Today.Day + 1, 1, _mediaId, cmbTwitterUsers.SelectedItem, "I")
            sto.MediaIds = {_mediaId}
        End If
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        If _twitterStatus IsNot Nothing Then
            InsertTweet(sto.Status, Today.Month + 1, Today.Day + 1, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
            WriteTrace("OK: " & _twitterStatus.Id, True)
        Else
            ' tweet failed
            WriteTrace("Failed", True)
        End If
    End Sub
    Private Sub ShowStatus(pText As String)
        lblStatus.Text = pText
        StatusStrip1.Refresh()
    End Sub
    Private Shared Function StatusToString(pStatus As TweetSharp.TwitterStatus) As String
        Dim statusText As New StringBuilder()
        statusText _
            .Append("Id=").Append(pStatus.IdStr).Append(vbCrLf) _
            .Append("FullText=").Append(pStatus.FullText).Append(vbCrLf) _
            .Append("Author=").Append(pStatus.Author.ScreenName).Append(vbCrLf) _
            .Append("User=").Append(pStatus.User.ScreenName).Append("("c).Append(pStatus.User.Name).Append(")"c).Append(vbCrLf)
        Return statusText.ToString
    End Function
    Private Sub CreateTwitterImage(_image As String)
        LblImageFile.Text = _image
        Dim _imageidentity As New ImageIdentity(-1, _image, "", "", "")
        Dim _person As New Person(TxtForename.Text, TxtSurname.Text, "", "", 0, 0, 0, 0, 0, 0, "", "", _imageidentity, Nothing)
        Dim _pictureList As New List(Of Person) From {_person}
        ImageUtil.GenerateImage(PictureBox2, _pictureList, 1, 1, ImageUtil.AlignType.Centre)
    End Sub
    Private Function GetWikiText(_sentences As Integer) As String
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(TxtName.Text, _sentences))
        Dim extract As String = GetExtractFromResponse(_response)
        Return extract
    End Function
#End Region
End Class
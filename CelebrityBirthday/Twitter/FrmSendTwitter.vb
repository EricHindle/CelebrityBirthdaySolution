Imports System.Collections.Specialized
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
        cmbTwitterUsers.SelectedIndex = -1
        WriteTrace("Entering GetAuthToken " & Format(Now, "hh:MM:ss"))
        isDone = False
        Await GetAuthToken()
        WriteTrace(isDone)
        WriteTrace("Back from GetAuthToken " & Format(Now, "hh:MM:ss"))
        WriteTrace("Entering Authenticate " & Format(Now, "hh:MM:ss"))
        isDone = False
        Authenticate()
        WriteTrace(isDone)
        WriteTrace("Back from Authenticate " & Format(Now, "hh:MM:ss"))
    End Sub
    Private Sub FrmSendTwitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("about:blank")
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
        FillTwitterUserList()
        cmbTwitterUsers.SelectedIndex = cmbTwitterUsers.FindStringExact(SendAs)
        rtbTweetText.Text = TweetText
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
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
        isDone = False
        If isOkToSend Then
            SendTheTweet()
        End If
        WriteTrace(isDone)
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))
    End Sub
    Private Sub FrmSendTwitter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        oTweetTa.Dispose()
    End Sub
#End Region
#Region "subroutines"
    Private Sub Authenticate()
        WriteTrace("Navigating")
        WebBrowser1.Navigate("https://api.twitter.com/oauth/authorize?oauth_token=" & tw.Token)
    End Sub
    Private Async Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        WriteTrace("Browser document complete")
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
                    Dim _index As Integer = _outerHTML.IndexOf("oauth_verifier=")
                    If _index > -1 Then
                        Dim _startIndex As Integer = _index + 15
                        Dim _length As Integer = _outerHTML.Length - _startIndex - 2
                        Dim verifier As String = _outerHTML.Substring(_startIndex, _length)
                        tw.Verifier = verifier
                        Dim _twitterUser As String = GetTwitterName(_innerHtml)
                        GlobalSettings.GetSetting(_twitterUser)
                        GlobalSettings.SetSetting(_twitterUser, "string", verifier, "twitter")
                        WriteTrace("Verifier = " & verifier)
                        Await GetAccessToken()
                        UpdateAuth(_twitterUser, tw.Token, tw.TokenSecret, tw.Verifier)
                    End If
                Next
            Next
        Catch ex As Exception
            WriteTrace(ex.Message)
        End Try
        WriteTrace("Browser finished")
    End Sub
    Private Function GetTwitterName(_innerHtml As String) As String
        Dim _pos1 As Integer = _innerHtml.IndexOf("span class=""name""") + 18
        Dim _pos2 As Integer = _innerHtml.IndexOf("/span", _pos1)
        Dim _twitterName As String = "Unknown"
        If _pos1 > 0 AndAlso _pos2 > _pos1 Then
            _twitterName = _innerHtml.Substring(_pos1, _pos2 - _pos1 - 1)
        End If
        Return _twitterName
    End Function
    Private Async Function GetAccessToken() As Threading.Tasks.Task(Of Boolean)
        WriteTrace("Beginning GetAccessToken " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_consumer", tw.ConsumerKey},
                {"oauth_token", tw.Token},
                {"oauth_verifier", tw.Verifier}}
            WriteTrace("Building parameters " & Format(Now, "hh:MM:ss"))
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            WriteTrace("Building POST " & Format(Now, "hh:MM:ss"))
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.ACCESS_TOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)
            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Using hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))
                WriteTrace("Building Signature " & Format(Now, "hh:MM:ss"))
                _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            End Using
            WriteTrace("Building header " & Format(Now, "hh:MM:ss"))
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            WriteTrace("Adding header " & Format(Now, "hh:MM:ss"))
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            WriteTrace("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/access_token", "")
            WriteTrace("Back from POST " & Format(Now, "hh:MM:ss"))
            WriteTrace("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync()
            WriteTrace("Back from getting response " & Format(Now, "hh:MM:ss"))
            If responseString.Length > 0 Then
                WriteTrace("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                For Each token As String In qs.Keys
                    WriteTrace(token & " = " & qs(token))
                Next
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")
                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")
                End If
                WriteTrace("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            rtbTweet.Text &= vbCrLf & "================="
            rtbTweet.Text &= vbCrLf & tw.Token
            rtbTweet.Text &= vbCrLf & tw.TokenSecret
        End Using


        WriteTrace("Finished GetAccessToken " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function
    Private Async Function GetAuthToken() As Threading.Tasks.Task(Of Boolean)
        WriteTrace("Beginning GetAuthToken " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            WriteTrace("Getting nonce " & Format(Now, "hh:MM:ss"))
            Dim _nonce As String = tw.GenerateNonce()
            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_nonce", _nonce},
                {"oauth_callback", tw.CallbackUrl},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_timestamp", Convert.ToInt64(timestamp.TotalSeconds)},
                {"oauth_consumer_key", tw.ConsumerKey},
                {"oauth_version", "1.0"}}
            WriteTrace("Building parameters " & Format(Now, "hh:MM:ss"))
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            WriteTrace("Building POST " & Format(Now, "hh:MM:ss"))
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.REQUEST_TOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)
            WriteTrace(baseString)
            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Using hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))
                WriteTrace("Building Signature " & Format(Now, "hh:MM:ss"))
                _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            End Using
            WriteTrace("Building header " & Format(Now, "hh:MM:ss"))
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            WriteTrace("Adding header " & Format(Now, "hh:MM:ss"))
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            WriteTrace("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/request_token", "")
            WriteTrace("Back from POST " & Format(Now, "hh:MM:ss"))
            WriteTrace("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync()
            WriteTrace("Back from getting response " & Format(Now, "hh:MM:ss"))
            If responseString.Length > 0 Then
                WriteTrace("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                For Each token As String In qs.Keys
                    WriteTrace(token & " = " & qs(token))
                Next
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")
                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")
                End If
                WriteTrace("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            rtbTweet.Text &= vbCrLf & tw.Token
            rtbTweet.Text &= vbCrLf & tw.TokenSecret
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
        rtbTweet.Text &= vbCrLf & sText
        If isStatus Then ShowStatus(sText)
    End Sub
    Private Sub SendTheTweet()
        ShowStatus("Sending Tweet")
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = rtbTweetText.Text
        sto.Status = msg.Substring(0, Math.Min(msg.Length, TWEET_MAX_LEN)) ' max tweet length; tweets fail if too long...
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        WriteTrace(StatusToString(_twitterStatus))
        If _twitterStatus IsNot Nothing Then
            oTweetTa.InsertTweet(Now, sto.Status, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
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
    Private Function StatusToString(pStatus As TweetSharp.TwitterStatus) As String
        Dim statusText As New StringBuilder()
        statusText _
            .Append("Id=").Append(pStatus.IdStr).Append(vbCrLf) _
            .Append("FullText=").Append(pStatus.FullText).Append(vbCrLf) _
            .Append("Author=").Append(pStatus.Author.ScreenName).Append(vbCrLf) _
            .Append("User=").Append(pStatus.User.ScreenName).Append("(").Append(pStatus.User.Name).Append(")").Append(vbCrLf)
        Return statusText.ToString
    End Function
#End Region
End Class
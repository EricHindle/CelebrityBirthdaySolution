' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.Specialized
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Imports mshtml

Public Class FrmTwitterAuth
    Private isDone As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private Sub FrmTwitterAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowStatus("Loading", MyBase.Name, Nothing)
        GetFormPos(Me, My.Settings.twitterAuthFormPos)
        WebBrowser1.Navigate(New Uri("about:blank"))
        Dim _auth As TwitterOAuth = GetAuthById("TwDev")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
        FillTwitterUserList()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()

    End Sub

    Private Sub FrmTwitterAuth_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ShowStatus("Closing", MyBase.Name, Nothing)
        My.Settings.twitterAuthFormPos = SetFormPos(Me)
        My.Settings.Save()
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
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweetProgress.Text &= vbCrLf & sText
        ShowStatus(sText, lblStatus, True, MyBase.Name)
    End Sub
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
    Private Sub Authenticate()
        WriteTrace("Navigating")
        WebBrowser1.Navigate(New Uri("https://api.twitter.com/oauth/authorize?oauth_token=" & tw.Token))
    End Sub
    Private Sub FillTwitterUserList()
        cmbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            cmbTwitterUsers.Items.Add(_user)
        Next
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
End Class
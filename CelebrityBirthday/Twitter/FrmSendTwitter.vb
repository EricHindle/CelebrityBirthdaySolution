Imports System.Collections.Specialized
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports System.Web
Imports mshtml
Imports TweetSharp

Public Class FrmSendTwitter
    Private isDone As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private tweetId As String
    Private tweetIdStr As String

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Async Sub BtnAuthenticate_Click(sender As Object, e As EventArgs) Handles BtnAuthenticate.Click
        writeTrace("Entering GetAuthToken " & Format(Now, "hh:MM:ss"))
        isDone = False
        Await GetAuthToken()
        writeTrace(isDone)
        writeTrace("Back from GetAuthToken " & Format(Now, "hh:MM:ss"))
        writeTrace("Entering Authenticate " & Format(Now, "hh:MM:ss"))
        isDone = False
        Authenticate()
        writeTrace(isDone)
        writeTrace("Back from Authenticate " & Format(Now, "hh:MM:ss"))


    End Sub

    Private Sub Authenticate()
        writeTrace("Navigating")
        WebBrowser1.Navigate("https://api.twitter.com/oauth/authorize?oauth_token=" & tw.Token)
    End Sub

    Private Async Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        writeTrace("Browser document complete")
        Try
            Dim webHtml As Windows.Forms.HtmlDocument = WebBrowser1.Document
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
                        writeTrace("Verifier = " & verifier)
                        Await GetAccessToken()
                    End If

                Next
            Next
        Catch ex As Exception
            writeTrace(ex.Message)
        End Try
        writeTrace("Browser finished")
    End Sub

    Private Async Function GetAccessToken() As Threading.Tasks.Task(Of Boolean)
        writeTrace("Beginning GetAccessToken " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)

            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_consumer", tw.ConsumerKey},
                {"oauth_token", tw.Token},
                {"oauth_verifier", tw.Verifier}}
            writeTrace("Building parameters " & Format(Now, "hh:MM:ss"))
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            writeTrace("Building POST " & Format(Now, "hh:MM:ss"))
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.ACCESS_TOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)

            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Dim hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))

            writeTrace("Building Signature " & Format(Now, "hh:MM:ss"))
            _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            writeTrace("Building header " & Format(Now, "hh:MM:ss"))
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            writeTrace("Adding header " & Format(Now, "hh:MM:ss"))
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            writeTrace("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/access_token", "")
            writeTrace("Back from POST " & Format(Now, "hh:MM:ss"))
            writeTrace("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync()
            writeTrace("Back from getting response " & Format(Now, "hh:MM:ss"))
            If responseString.Length > 0 Then
                writeTrace("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                For Each token As String In qs.Keys
                    writeTrace(token & " = " & qs(token))
                Next
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")

                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")

                End If
                writeTrace("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            rtbTweet.Text &= vbCrLf & "================="
            rtbTweet.Text &= vbCrLf & tw.Token
            rtbTweet.Text &= vbCrLf & tw.TokenSecret
        End Using


        writeTrace("Finished GetAccessToken " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function

    Private Async Function GetAuthToken() As Threading.Tasks.Task(Of Boolean)
        writeTrace("Beginning GetAuthToken " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            writeTrace("Getting nonce " & Format(Now, "hh:MM:ss"))
            Dim _nonce As String = tw.GenerateNonce()
            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_nonce", _nonce},
                {"oauth_callback", tw.CallbackUrl},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_timestamp", Convert.ToInt64(timestamp.TotalSeconds)},
                {"oauth_consumer_key", tw.ConsumerKey},
                {"oauth_version", "1.0"}}
            writeTrace("Building parameters " & Format(Now, "hh:MM:ss"))
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            writeTrace("Building POST " & Format(Now, "hh:MM:ss"))
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.REQUEST_TOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)
            writeTrace(baseString)
            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Dim hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))

            writeTrace("Building Signature " & Format(Now, "hh:MM:ss"))
            _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            writeTrace("Building header " & Format(Now, "hh:MM:ss"))
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            writeTrace("Adding header " & Format(Now, "hh:MM:ss"))
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            writeTrace("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/request_token", "")
            writeTrace("Back from POST " & Format(Now, "hh:MM:ss"))
            writeTrace("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync()
            writeTrace("Back from getting response " & Format(Now, "hh:MM:ss"))
            If responseString.Length > 0 Then
                writeTrace("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                For Each token As String In qs.Keys
                    writeTrace(token & " = " & qs(token))
                Next
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")

                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")

                End If
                writeTrace("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            rtbTweet.Text &= vbCrLf & tw.Token
            rtbTweet.Text &= vbCrLf & tw.TokenSecret
        End Using



        writeTrace("Finished GetAuthToken " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function

    Private Sub FrmSendTwitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("about:blank")
        tw.ConsumerKey = GlobalSettings.GetSetting("TwKey")
        tw.ConsumerSecret = GlobalSettings.GetSetting("TwSecret")
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        writeTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
        isDone = False
        '   Await SendTweet()
        Twit()
        writeTrace(isDone)
        writeTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))
    End Sub


    Private Sub writeTrace(sText As String)
        rtbTweet.Text &= vbCrLf & sText
    End Sub


    Private Sub Twit()
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)

        Dim sto = New SendTweetOptions

        Dim msg = rtbTweetText.Text

        sto.Status = msg.Substring(0, Math.Min(msg.Length, 280)) ' max tweet length; tweets fail if too long...

        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)

        If _twitterStatus IsNot Nothing Then
            writeTrace("OK: " & _twitterStatus.ID)
        Else
            ' tweet failed
            writeTrace("Failed")
        End If
    End Sub

End Class
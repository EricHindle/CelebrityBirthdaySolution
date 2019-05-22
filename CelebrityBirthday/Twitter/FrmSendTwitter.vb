Imports System.Collections.Specialized
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports System.Web
Imports mshtml

Public Class FrmSendTwitter
    Private isDone As Boolean
    Private tw As New TwitterOAuth
    Private webDocuments As List(Of String)
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Async Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Debug.Print("Entering GetAuthToken " & Format(Now, "hh:MM:ss"))
        isDone = False
        Await GetAuthToken()
        Debug.Print(isDone)
        Debug.Print("Back from GetAuthToken " & Format(Now, "hh:MM:ss"))
        Debug.Print("Entering Authenticate " & Format(Now, "hh:MM:ss"))
        isDone = False
        Authenticate()
        Debug.Print(isDone)
        Debug.Print("Back from Authenticate " & Format(Now, "hh:MM:ss"))


    End Sub

    Private Sub Authenticate()
        webDocuments = New List(Of String)
        WebBrowser1.Navigate("https://api.twitter.com/oauth/authorize?oauth_token=" & tw.Token)
    End Sub

    Private Async Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
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
                        Await GetAccessToken()
                    End If

                Next
            Next
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Sub

    Private Async Function GetAccessToken() As Threading.Tasks.Task(Of Boolean)
        Debug.Print("Beginning process " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)

            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_consumer", tw.ConsumerKey},
                {"oauth_token", tw.Token},
                {"oauth_verifier", tw.Verifier}}
            Debug.Print("Building parameters " & Format(Now, "hh:MM:ss"))
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            Debug.Print("Building POST " & Format(Now, "hh:MM:ss"))
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.ACCESS_TOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)

            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Dim hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))

            Debug.Print("Building Signature " & Format(Now, "hh:MM:ss"))
            _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            Debug.Print("Building header " & Format(Now, "hh:MM:ss"))
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            Debug.Print("Adding header " & Format(Now, "hh:MM:ss"))
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            Debug.Print("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/access_token", "")
            Debug.Print("Back from POST " & Format(Now, "hh:MM:ss"))
            Debug.Print("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync()
            Debug.Print("Back from getting response " & Format(Now, "hh:MM:ss"))
            If responseString.Length > 0 Then
                Debug.Print("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")

                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")

                End If
                Debug.Print("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            rtbTweet.Text &= vbCrLf & "================="
            rtbTweet.Text &= vbCrLf & tw.Token
            rtbTweet.Text &= vbCrLf & tw.TokenSecret
        End Using


        Debug.Print("Finished process " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function

    Private Async Function GetAuthToken() As Threading.Tasks.Task(Of Boolean)
        Debug.Print("Beginning process " & Format(Now, "hh:MM:ss"))
        Using client As New HttpClient
            client.BaseAddress = New Uri("https://api.twitter.com/")
            client.DefaultRequestHeaders.Accept.Clear()
            client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
            Dim timestamp As TimeSpan = DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
            Debug.Print("Getting nonce " & Format(Now, "hh:MM:ss"))
            Dim _nonce As String = tw.GenerateNonce()
            Dim _oAuth As New Dictionary(Of String, String) From
                {{"oauth_nonce", _nonce},
                {"oauth_callback", tw.CallbackUrl},
                {"oauth_signature_method", "HMAC-SHA1"},
                {"oauth_timestamp", Convert.ToInt64(timestamp.TotalSeconds)},
                {"oauth_consumer_key", tw.ConsumerKey},
                {"oauth_version", "1.0"}}
            Debug.Print("Building parameters " & Format(Now, "hh:MM:ss"))
            Dim parameterCollectionValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).OrderBy(Function(kv) kv).ToArray()
            Dim parameterCollection As String = String.Join("&", parameterCollectionValues)
            Debug.Print("Building POST " & Format(Now, "hh:MM:ss"))
            Dim baseString As String = "POST"
            baseString &= "&"
            baseString &= Uri.EscapeDataString(TwitterOAuth.REQUEST_TOKEN)
            baseString &= "&"
            baseString &= Uri.EscapeDataString(parameterCollection)

            Dim signingKey = Uri.EscapeDataString(tw.ConsumerSecret)
            signingKey += "&"
            Dim hasher As New HMACSHA1(New ASCIIEncoding().GetBytes(signingKey))

            Debug.Print("Building Signature " & Format(Now, "hh:MM:ss"))
            _oAuth("oauth_signature") = Convert.ToBase64String(hasher.ComputeHash(New ASCIIEncoding().GetBytes(baseString)))
            Debug.Print("Building header " & Format(Now, "hh:MM:ss"))
            Dim headerstring As String = "OAuth "
            Dim headerStringValues As String() = _oAuth.[Select](Function(parameter) Uri.EscapeDataString(parameter.Key) & "=" & Uri.EscapeDataString(parameter.Value)).ToArray()
            headerstring += String.Join(", ", headerStringValues)
            Debug.Print("Adding header " & Format(Now, "hh:MM:ss"))
            client.DefaultRequestHeaders.Add("Authorization", headerstring)
            Debug.Print("Posting " & Format(Now, "hh:MM:ss"))
            Dim response As HttpResponseMessage = Await client.PostAsJsonAsync("oauth/request_token", "")
            Debug.Print("Back from POST " & Format(Now, "hh:MM:ss"))
            Debug.Print("Getting response " & Format(Now, "hh:MM:ss"))
            Dim responseString = Await response.Content.ReadAsStringAsync()
            Debug.Print("Back from getting response " & Format(Now, "hh:MM:ss"))
            If responseString.Length > 0 Then
                Debug.Print("Getting tokens " & Format(Now, "hh:MM:ss"))
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(responseString)
                If qs("oauth_token") IsNot Nothing Then
                    tw.Token = qs("oauth_token")

                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    tw.TokenSecret = qs("oauth_token_secret")

                End If
                Debug.Print("Got tokens " & Format(Now, "hh:MM:ss"))
            End If
            rtbTweet.Text &= vbCrLf & tw.Token
            rtbTweet.Text &= vbCrLf & tw.TokenSecret
        End Using



        Debug.Print("Finished process " & Format(Now, "hh:MM:ss"))
        isDone = True
        Return isDone
    End Function

    Private Sub FrmSendTwitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("about:blank")
    End Sub
End Class
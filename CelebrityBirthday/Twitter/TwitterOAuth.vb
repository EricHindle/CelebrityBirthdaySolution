Imports System
Imports System.Security.Cryptography
Imports System.Collections.Specialized
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Net
''' <summary>
''' A class for implementing OAuth authentication via Twitter.
''' </summary>
''' <remarks></remarks>
''' <exclude/>
Public Class TwitterOAuth
        Inherits OAuth

    Public Const REQUESTTOKEN As String = "https://api.twitter.com/oauth/request_token"
    Public Const AUTHORIZE As String = "https://api.twitter.com/oauth/authorize"
    Public Const ACCESSTOKEN As String = "https://api.twitter.com/oauth/access_token"
    Public Const AUTHENTICATE As String = "https://api.twitter.com/oauth/authenticate"
    Public Const XACCESSTOKEN As String = "https://api.twitter.com/oauth/access_token"

    Public ConsumerKey As String
    Public ConsumerSecret As String

    Public Token As String = String.Empty
    Public TokenSecret As String = String.Empty
    Public Verifier As String = String.Empty
    Public CallbackUrl As String = "http://www.netwyrks.co.uk/hattyburpday"
    Public Sub New()
    End Sub
    Public Sub New(ByVal ConsumerKey As String, ByVal ConsumerKeySecret As String)
        Me.ConsumerKey = ConsumerKey
        Me.ConsumerSecret = ConsumerKeySecret
    End Sub
    Public Sub New(ByVal ConsumerKey As String, ByVal ConsumerKeySecret As String, ByVal Token As String, ByVal TokenSecret As String)
        With Me
            .Token = Token
            .TokenSecret = TokenSecret
            .ConsumerKey = ConsumerKey
            .ConsumerSecret = ConsumerKeySecret
        End With
    End Sub
    Public Sub New(ByVal ConsumerKey As String, ByVal ConsumerKeySecret As String, ByVal CallbackUrl As String)
        Me.ConsumerKey = ConsumerKey
        Me.ConsumerSecret = ConsumerKeySecret
        Me.CallbackUrl = CallbackUrl
    End Sub
    Public Function GetAuthorizationLink() As String
        Dim ReturnValue As String = Nothing
        Dim Response As String = OAuthWebRequestCB(Method.POST, REQUESTTOKEN, String.Empty)
        If Response.Length > 0 Then
            Dim qs As NameValueCollection = HttpUtility.ParseQueryString(Response)
            If qs("oauth_token") IsNot Nothing Then
                Me.Token = qs("oauth_token")
                ReturnValue = String.Concat(AUTHORIZE, "?oauth_token=", qs("oauth_token"))
            End If
        End If
        Return ReturnValue
    End Function
    Public Function GetAuthenticationLink() As String
        Dim ReturnValue As String = Nothing
        Dim Response As String = OAuthWebRequest(Method.GET, REQUESTTOKEN, String.Empty)
        If Response.Length > 0 Then
            Dim qs As NameValueCollection = HttpUtility.ParseQueryString(Response)
            If qs("oauth_token") IsNot Nothing Then
                Me.Token = qs("oauth_token")
                ReturnValue = String.Concat(AUTHENTICATE, "?oauth_token=", qs("oauth_token"))
            End If
        End If
        Return ReturnValue
    End Function
    Public Function ValidatePIN(ByVal PIN As String) As Boolean

        Dim ReturnValue As Boolean

        Try
            Dim Response As String = OAuthWebRequest(Method.GET, String.Format(myStringFormatProvider, "{0}?oauth_verifier={1}", ACCESSTOKEN, PIN), String.Empty)
            If Response.Length > 0 Then
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(Response)
                If qs("oauth_token") IsNot Nothing Then
                    Token = qs("oauth_token")
                End If
                If qs("oauth_token_secret") IsNot Nothing Then
                    TokenSecret = qs("oauth_token_secret")
                End If
                ReturnValue = True
            Else
                ReturnValue = False
            End If

        Catch ex As Exception
            ReturnValue = False
        End Try

        Return ReturnValue
    End Function
    Public Sub GetXAccess(ByVal p_strUserName As String, ByVal p_strPassword As String)

        Dim strInformation As String
        strInformation = "?x_auth_username=" & p_strUserName & "&x_auth_password=" & p_strPassword & "&x_auth_mode=client_auth"
        Dim response As String = OAuthWebRequest(Method.POST, XACCESSTOKEN, strInformation)
        If response.Length > 0 Then
            Dim qs As NameValueCollection = HttpUtility.ParseQueryString(response)
            If qs("oauth_token") IsNot Nothing Then
                Token = qs("oauth_token")
            End If
            If qs("oauth_token_secret") IsNot Nothing Then
                TokenSecret = qs("oauth_token_secret")
            End If
        End If
    End Sub
    Public Sub GetAccessToken(ByVal AuthToken As String, ByVal AuthVerifier As String)
        Token = AuthToken
        Verifier = AuthVerifier
        Dim Response As String = OAuthWebRequest(Method.GET, ACCESSTOKEN, String.Empty)
        If Response.Length > 0 Then
            Dim qs As NameValueCollection = HttpUtility.ParseQueryString(Response)
            If qs("oauth_token") IsNot Nothing Then
                Token = qs("oauth_token")
            End If
            If qs("oauth_token_secret") IsNot Nothing Then
                TokenSecret = qs("oauth_token_secret")
            End If
        End If
    End Sub
    Public Function OAuthWebUpload(ByVal RequestMethod As Method, ByVal url As String, ByVal PostData As String, ByVal p_FileName As String, ByVal p_FileFieldName As String) As String
        Dim outURL As String = String.Empty
        Dim QueryString As String = String.Empty

        Dim ReturnValue As String = String.Empty
        ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate)
        If PostData.Length > 0 Then
            Dim qs As NameValueCollection = HttpUtility.ParseQueryString(PostData)
            PostData = String.Empty
            For Each key As String In qs.AllKeys
                If PostData.Length > 0 Then
                    PostData &= "&"
                End If
                qs(key) = HttpUtility.UrlDecode(qs(key))
                qs(key) = OAuthUrlEncode(qs(key))
                PostData &= key & "=" & qs(key)
            Next
        End If
        If url.IndexOf("?") > 0 Then
            url &= "&"
        Else
            url &= "?"

        End If
        Dim requestUri As New Uri(url)
        Dim nonce As String = GenerateNonce()
        Dim TimeStamp As String = GenerateTimeStamp()
        Dim Sig As String = GenerateSignature(requestUri, Me.ConsumerKey, Me.ConsumerSecret, Me.Token, Me.TokenSecret, RequestMethod.ToString, TimeStamp, nonce, outURL, QueryString, CallbackUrl, Verifier)
        QueryString &= "&oauth_signature=" + OAuthUrlEncode(Sig)
        PostData = QueryString
        QueryString = String.Empty
        ReturnValue = WebUpload(RequestMethod, outURL + QueryString, PostData, p_FileName, p_FileFieldName)
        Return ReturnValue

    End Function
    Public Function WebUpload(ByVal RequestMethod As Method, ByVal Url As String, ByVal PostData As String, ByVal p_FileName As String, ByVal p_FileFieldName As String) As String
        Try
            Dim request As HttpWebRequest = TryCast(System.Net.WebRequest.Create(Url), HttpWebRequest)
            Dim p As System.Net.WebProxy = Nothing
            System.Net.ServicePointManager.Expect100Continue = False

            If Globals.Proxy_Username <> String.Empty And Globals.Proxy_Password <> String.Empty Then
                p = New System.Net.WebProxy
                p.Credentials = New NetworkCredential(Globals.Proxy_Username, Globals.Proxy_Password)
                request.Proxy = p
            End If
            PostData = PostData.Replace("&", ",")
            PostData = "OAuth " & PostData

            request.Headers(HttpRequestHeader.Authorization) = PostData


            Dim sbPostData As New StringBuilder
            Dim boundary As String = Guid.NewGuid.ToString
            Dim header As String = String.Format(myStringFormatProvider, "--{0}", boundary)
            Dim footer As String = String.Format(myStringFormatProvider, "--{0}--", boundary)
            request.Method = "POST"
            request.ContentType = String.Format(myStringFormatProvider, "multipart/form-data; boundary={0}", boundary)
            Dim filecontenttype As String
            If p_FileName.ToLower.EndsWith(".jpg") Or p_FileName.ToLower.EndsWith(".jpeg") Then
                filecontenttype = "image/jpg"
            ElseIf p_FileName.ToLower.EndsWith(".gif") Then
                filecontenttype = "image/gif"
            ElseIf p_FileName.ToLower.EndsWith(".png") Then
                filecontenttype = "image/png"
            Else
                Return String.Empty
            End If
            Dim BinaryData() As Byte = System.IO.File.ReadAllBytes(p_FileName)
            p_FileName = p_FileName.Substring(p_FileName.LastIndexOf("\") + 1)
            Dim FileHeader As String = [String].Format("Content-Disposition: file; name=""{0}""; filename=""{1}""", p_FileFieldName, p_FileName)
            Dim FileData As String = Encoding.GetEncoding("iso-8859-1").GetString(BinaryData)
            Dim Contents As New StringBuilder
            With Contents

                .AppendLine(header)
                .AppendLine(FileHeader)
                .AppendLine([String].Format("Content-type: {0}", filecontenttype))
                .AppendLine()
                .AppendLine(FileData)
                .AppendLine(footer)
            End With
            My.Computer.Clipboard.SetText(Url & Contents.ToString())
            Dim Bytes() As Byte = Encoding.GetEncoding("iso-8859-1").GetBytes(Contents.ToString)

            request.ContentLength = Bytes.Length
            request.Headers(HttpRequestHeader.Authorization) = PostData

            'Dim requestSW As New StreamWriter(request.GetRequestStream)
            'requestSW.Write(PostData)

            Dim requestStream As Stream = request.GetRequestStream

            requestStream.Write(Bytes, 0, Bytes.Length)
            Dim wr As HttpWebResponse = DirectCast(request.GetResponse, HttpWebResponse)

            Dim responseStream As New StreamReader(wr.GetResponseStream)
            Return responseStream.ReadToEnd

        Catch ex As Exception
            Dim Message As String = Nothing
            If TypeOf ex Is WebException Then
                Try
                    Dim Doc As New Xml.XmlDocument
                    Doc.LoadXml(New StreamReader(CType(ex, WebException).Response.GetResponseStream, Encoding.UTF8).ReadToEnd)
                    Message = Doc.SelectSingleNode("hash/error").InnerText
                Catch
                End Try
            End If
            Dim tax As New TwitterAPIException(Message, ex)
            With tax
                .Url = Url
                .Method = RequestMethod.ToString
                .AuthType = "OAUTH"
                .Response = Nothing
                .Status = Nothing
            End With
            Throw tax
        End Try


    End Function
    Public Function OAuthWebRequest(ByVal RequestMethod As Method, ByVal url As String, ByVal PostData As String) As String
        Dim OutURL As String = String.Empty
        Dim QueryString As String = String.Empty
        Dim ReturnValue As String = String.Empty
        ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate)
        If RequestMethod = Method.POST Then
            If PostData.Length > 0 Then
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(PostData)
                PostData = String.Empty
                For Each Key As String In qs.AllKeys
                    If PostData.Length > 0 Then
                        PostData &= "&"
                    End If
                    qs(Key) = HttpUtility.UrlDecode(qs(Key))
                    qs(Key) = OAuthUrlEncode(qs(Key))
                    PostData &= Key + "=" + qs(Key)
                Next
                If url.IndexOf("?") > 0 Then
                    url &= "&"
                Else
                    url &= "?"
                End If
                url &= PostData
            End If
        End If

        Dim RequestUri As New Uri(url)
        Dim Nonce As String = GenerateNonce()
        Dim TimeStamp As String = GenerateTimeStamp()
        Dim Sig As String = GenerateSignature(RequestUri, Me.ConsumerKey, Me.ConsumerSecret, Me.Token, Me.TokenSecret, RequestMethod.ToString, TimeStamp, Nonce, OutURL, QueryString, CallbackUrl, Verifier)
        QueryString &= "&oauth_signature=" + OAuthUrlEncode(Sig)
        If RequestMethod = OAuth.Method.POST Then
            PostData = QueryString
            QueryString = String.Empty
        End If

        If QueryString.Length > 0 Then
            OutURL &= "?"
        End If

        ReturnValue = WebRequest(RequestMethod, OutURL + QueryString, PostData)

        Return ReturnValue
    End Function
    Public Function WebRequest(ByVal RequestMethod As Method, ByVal Url As String, ByVal PostData As String) As String

        Try
            Dim Request As HttpWebRequest = TryCast(System.Net.WebRequest.Create(Url), HttpWebRequest)
            Dim p As System.Net.WebProxy = Nothing
            Request.Method = RequestMethod.ToString()
            Request.ServicePoint.Expect100Continue = False
            If Globals.Proxy_Username <> String.Empty And Globals.Proxy_Password <> String.Empty Then
                p = New System.Net.WebProxy
                p.Credentials = New NetworkCredential(Globals.Proxy_Username, Globals.Proxy_Password)
                Request.Proxy = p
            End If

            If RequestMethod = Method.POST Then
                Request.ContentType = "application/x-www-form-urlencoded"
                Using RequestWriter As New StreamWriter(Request.GetRequestStream())
                    RequestWriter.Write(PostData)
                End Using
            End If

            Dim wr As System.Net.WebResponse = Request.GetResponse
            Globals.API_HourlyLimit = wr.Headers("X-RateLimit-Limit")
            Globals.API_RemainingHits = wr.Headers("X-RateLimit-Remaining")
            Globals.API_Reset = wr.Headers("X-RateLimit-Reset")

            Using ResponseReader As New StreamReader(wr.GetResponseStream())
                Return ResponseReader.ReadToEnd
            End Using

        Catch ex As Exception
            Dim Message As String = Nothing
            If TypeOf ex Is WebException Then
                Try
                    Dim Doc As New Xml.XmlDocument
                    Doc.LoadXml(New StreamReader(CType(ex, WebException).Response.GetResponseStream, Encoding.UTF8).ReadToEnd)
                    Message = Doc.SelectSingleNode("hash/error").InnerText
                Catch
                End Try
            End If
            Dim tax As New TwitterAPIException(Message, ex)
            With tax
                .Url = Url
                .Method = RequestMethod.ToString
                .AuthType = "OAUTH"
                .Response = Nothing
                .Status = Nothing
            End With
            Throw tax
        End Try

    End Function
    Private Function ValidateCertificate(ByVal sender As Object, ByVal certificate As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Public Function GetAuthorizationLink_CB() As String
        Dim ReturnValue As String = Nothing
        Dim Response As String = OAuthWebRequestCB(Method.POST, REQUESTTOKEN, String.Empty)
        If Response.Length > 0 Then
            Dim qs As NameValueCollection = HttpUtility.ParseQueryString(Response)
            If qs("oauth_token") IsNot Nothing Then
                Me.Token = qs("oauth_token")
                ReturnValue = String.Concat(AUTHORIZE, "?oauth_token=", qs("oauth_token"))
            End If
        End If
        Return ReturnValue
    End Function
    Public Function WebRequest_CB(ByVal RequestMethod As Method, ByVal Url As String, ByVal PostData As String) As String
        Try
            Dim Request As HttpWebRequest = TryCast(System.Net.WebRequest.Create(Url), HttpWebRequest)
            Dim p As System.Net.WebProxy = Nothing
            Request.Method = RequestMethod.ToString()
            Request.ServicePoint.Expect100Continue = False
            If Globals.Proxy_Username <> String.Empty And Globals.Proxy_Password <> String.Empty Then
                p = New System.Net.WebProxy
                p.Credentials = New NetworkCredential(Globals.Proxy_Username, Globals.Proxy_Password)
                Request.Proxy = p
            End If
            Request.Headers.Add("Authorization", "OAuth " + PostData.Replace("&", ","))
            Dim wr As System.Net.WebResponse = Request.GetResponse
            Globals.API_HourlyLimit = wr.Headers("X-RateLimit-Limit")
            Globals.API_RemainingHits = wr.Headers("X-RateLimit-Remaining")
            Globals.API_Reset = wr.Headers("X-RateLimit-Reset")
            Using ResponseReader As New StreamReader(wr.GetResponseStream())
                Return ResponseReader.ReadToEnd
            End Using
        Catch ex As Exception
            Dim Message As String = Nothing
            If TypeOf ex Is WebException Then
                Try
                    Dim Doc As New Xml.XmlDocument
                    Doc.LoadXml(New StreamReader(CType(ex, WebException).Response.GetResponseStream, Encoding.UTF8).ReadToEnd)
                    Message = Doc.SelectSingleNode("hash/error").InnerText
                Catch
                End Try
            End If
            Dim tax As New TwitterAPIException(Message, ex)
            With tax
                .Url = Url
                .Method = RequestMethod.ToString
                .AuthType = "OAUTH"
                .Response = Nothing
                .Status = Nothing
            End With
            Throw tax
        End Try
    End Function
    Public Function OAuthWebRequestCB(ByVal RequestMethod As Method, ByVal url As String, ByVal PostData As String) As String
        Dim OutURL As String = String.Empty
        Dim QueryString As String = String.Empty
        Dim ReturnValue As String = String.Empty
        ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate)
        If RequestMethod = Method.POST Then
            If PostData.Length > 0 Then
                Dim qs As NameValueCollection = HttpUtility.ParseQueryString(PostData)
                PostData = String.Empty
                For Each Key As String In qs.AllKeys
                    If PostData.Length > 0 Then
                        PostData &= "&"
                    End If
                    qs(Key) = HttpUtility.UrlDecode(qs(Key))
                    qs(Key) = OAuthUrlEncode(qs(Key))
                    PostData &= Key + "=" + qs(Key)
                Next
                If url.IndexOf("?") > 0 Then
                    url &= "&"
                Else
                    url &= "?"
                End If
                url &= PostData
            End If
        End If

        Dim RequestUri As New Uri(url)
        Dim Nonce As String = GenerateNonce()
        Dim TimeStamp As String = GenerateTimeStamp()
        Dim Sig As String = GenerateSignature_CB(RequestUri, Me.ConsumerKey, Me.ConsumerSecret, Me.Token, Me.TokenSecret, RequestMethod.ToString, TimeStamp, Nonce, OutURL, QueryString, CallbackUrl, Verifier)
        QueryString &= "&oauth_signature=" + OAuthUrlEncode(Sig)
        If RequestMethod = OAuth.Method.POST Then
            PostData = QueryString
            QueryString = String.Empty
        End If

        If QueryString.Length > 0 Then
            OutURL &= "?"
        End If

        ReturnValue = WebRequest(RequestMethod, OutURL + QueryString, PostData)

        Return ReturnValue
    End Function

End Class


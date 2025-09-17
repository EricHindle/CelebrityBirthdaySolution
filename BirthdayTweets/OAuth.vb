' Hindleware
' Copyright (c) 2020-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
Public Class OAuth
    Public Enum Method
        [GET]
        POST
    End Enum
    Protected Const OAuthVersion As String = "1.0"
    Protected Const OAuthParameterPrefix As String = "oauth_"
    Protected Const OAuthConsumerKeyKey As String = "oauth_consumer_key"
    Protected Const OAuthCallbackKey As String = "oauth_callback"
    Protected Const OAuthVersionKey As String = "oauth_version"
    Protected Const OAuthSignatureMethodKey As String = "oauth_signature_method"
    Protected Const OAuthSignatureKey As String = "oauth_signature"
    Protected Const OAuthTimestampKey As String = "oauth_timestamp"
    Protected Const OAuthNonceKey As String = "oauth_nonce"
    Protected Const OAuthTokenKey As String = "oauth_token"
    Protected Const OAuthTokenSecretKey As String = "oauth_token_secret"
    Protected Const OAuthVerifier As String = "oauth_verifier"
    Protected Const HMACSHA1SignatureType As String = "HMAC-SHA1"
    Protected Const PlainTextSignatureType As String = "PLAINTEXT"
    Protected Const RSASHA1SignatureType As String = "RSA-SHA1"

    '   Protected _Random As Random = New Random()
    Public Enum SignatureType
        HMACSHA1
        PLAINTEXT
        RSASHA1
    End Enum
    Protected Class QueryParameter
        Dim _name As String
        Dim _value As String

        Public Sub New(ByVal Name As String, ByVal value As String)
            _name = Name
            _value = value
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Value() As String
            Get
                Return _value
            End Get
            Set(ByVal value As String)
                _value = value
            End Set
        End Property
    End Class
    Protected Class QueryParameterComparer
        Implements IComparer(Of QueryParameter)

        Public Function Compare(ByVal x As QueryParameter, ByVal y As QueryParameter) As Integer Implements System.Collections.Generic.IComparer(Of QueryParameter).Compare
            If x Is Nothing Then Throw New ArgumentNullException(NameOf(x))
            If y Is Nothing Then Throw New ArgumentNullException(NameOf(y))
            If x.Name = y.Name Then
                Return String.Compare(x.Value, y.Value, StringComparison.CurrentCultureIgnoreCase)
            Else
                Return String.Compare(x.Name, y.Name, StringComparison.CurrentCultureIgnoreCase)
            End If
        End Function
    End Class
    Private Shared Function ComputeHash(ByVal Algorithm As HashAlgorithm, ByVal Data As String) As String
        If Algorithm IsNot Nothing Then
            If String.IsNullOrEmpty(Data) = False Then
                Dim DataBuffer() As Byte = System.Text.Encoding.ASCII.GetBytes(Data)
                Dim HashBytes() As Byte = Algorithm.ComputeHash(DataBuffer)
                Return Convert.ToBase64String(HashBytes)
            Else
                Throw New ArgumentNullException(NameOf(Data))
            End If
        Else
            Throw New ArgumentNullException(NameOf(Algorithm))
        End If

    End Function
    Private Shared Function GetQueryParameters(ByVal Parameters As String) As List(Of QueryParameter)
        If Parameters.StartsWith("?", StringComparison.CurrentCultureIgnoreCase) Then
            Parameters = Parameters.Remove(0, 1)
        End If

        Dim Result As New List(Of QueryParameter)

        If String.IsNullOrEmpty(Parameters) = False Then
            Dim p() As String = Parameters.Split(Convert.ToChar("&", myStringFormatProvider))
            For Each s As String In p
                If String.IsNullOrEmpty(s) = False Then 'And s.StartsWith(OAuthParameterPrefix) = False Then
                    If s.IndexOf("=", StringComparison.CurrentCultureIgnoreCase) > -1 Then
                        Dim Temp() As String = s.Split(Convert.ToChar("=", myStringFormatProvider))
                        Result.Add(New QueryParameter(Temp(0), Temp(1)))
                    Else
                        Result.Add(New QueryParameter(s, String.Empty))
                    End If
                End If
            Next
        End If
        Return Result
    End Function
    Public Shared Function OAuthUrlEncode(ByVal value As String) As Uri
        Dim result As New StringBuilder()
        Dim unreservedchars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~"
        If value IsNot Nothing Then
            For Each symbol As Char In value
                If unreservedchars.IndexOf(symbol) <> -1 Then
                    result.Append(symbol)
                Else
                    Dim charBytes As Byte()
                    charBytes = Encoding.UTF8.GetBytes(symbol.ToString(myStringFormatProvider))
                    For Each charByte As Byte In charBytes
                        result.AppendFormat(myStringFormatProvider, "%{0:X2}", charByte)
                    Next
                End If
            Next
        End If
        Return New Uri(result.ToString())
    End Function
    Protected Shared Function NormalizeRequestParameters(ByVal Parameters As IList(Of QueryParameter)) As String
        Dim sb As New StringBuilder
        Dim p As QueryParameter
        If Parameters IsNot Nothing Then
            For i As Integer = 0 To Parameters.Count - 1
                p = Parameters(i)
                sb.AppendFormat(myStringFormatProvider, "{0}={1}", p.Name, p.Value)
                If i < Parameters.Count - 1 Then
                    sb.Append("&"c)
                End If
            Next
        End If
        Return sb.ToString
    End Function
    Public Shared Function GenerateSignatureBase(ByVal URL As Uri, ByVal ConsumerKey As String, ByVal Token As String, ByVal TokenSecret As String, ByVal HTTPMethod As String, ByVal TimeStamp As String, ByVal Nonce As String, ByVal SignatureType As String, ByRef pNormalizedURL As Uri, ByRef NormalizedRequestParameters As String, ByVal CallbackUrl As Uri, ByVal Verifier As String) As String
        Dim NormalizedURL As String = If(pNormalizedURL IsNot Nothing, pNormalizedURL.ToString, "")
        If URL Is Nothing Then Throw New ArgumentNullException(NameOf(URL))
        If Token Is Nothing Then
            Token = String.Empty
        End If

        If TokenSecret Is Nothing Then
            TokenSecret = String.Empty
        End If

        If String.IsNullOrEmpty(ConsumerKey) Then
            Throw New ArgumentNullException(NameOf(ConsumerKey))
        End If

        If String.IsNullOrEmpty(HTTPMethod) Then
            Throw New ArgumentNullException(NameOf(HTTPMethod))
        End If

        If String.IsNullOrEmpty(SignatureType) Then
            Throw New ArgumentNullException(NameOf(SignatureType))
        End If

        NormalizedURL = Nothing
        NormalizedRequestParameters = Nothing

        Dim Parameters As List(Of QueryParameter) = GetQueryParameters(URL.Query)
        With Parameters
            Parameters.Add(New QueryParameter(OAuthVersionKey, OAuthVersion))
            Parameters.Add(New QueryParameter(OAuthNonceKey, Nonce))
            Parameters.Add(New QueryParameter(OAuthTimestampKey, TimeStamp))
            Parameters.Add(New QueryParameter(OAuthSignatureMethodKey, SignatureType))
            Parameters.Add(New QueryParameter(OAuthConsumerKeyKey, ConsumerKey))
        End With

        If String.IsNullOrEmpty(Token) = False Then
            Parameters.Add(New QueryParameter(OAuthTokenKey, Token))
        End If

        If Not CallbackUrl Is Nothing = False Then
            Parameters.Add(New QueryParameter(OAuthCallbackKey, OAuthUrlEncode(CallbackUrl.ToString).ToString))
        End If

        If String.IsNullOrEmpty(Verifier) = False Then
            Parameters.Add(New QueryParameter(OAuthVerifier, Verifier))
        End If

        Parameters.Sort(New QueryParameterComparer)

        NormalizedURL = String.Format(myStringFormatProvider, "{0}://{1}", URL.Scheme, URL.Host)
        If Not ((URL.Scheme = "http" And URL.Port = 80) Or (URL.Scheme = "https" And URL.Port = 443)) Then
            NormalizedURL &= ":" + URL.Port.ToString(myCultureInfo)
        End If

        NormalizedURL &= URL.AbsolutePath
        NormalizedRequestParameters = NormalizeRequestParameters(Parameters)
        Dim SignatureBase As New StringBuilder()
        With SignatureBase
            .AppendFormat(myStringFormatProvider, "{0}&", HTTPMethod.ToUpper(myCultureInfo))
            .AppendFormat(myStringFormatProvider, "{0}&", OAuthUrlEncode(NormalizedURL).ToString)
            .AppendFormat(myStringFormatProvider, "{0}", OAuthUrlEncode(NormalizedRequestParameters).ToString)
        End With

        Return SignatureBase.ToString
    End Function
    Public Shared Function GenerateSignatureUsingHash(ByVal SignatureBase As String, ByVal Hash As HashAlgorithm) As String
        Return ComputeHash(Hash, SignatureBase)
    End Function
    Public Shared Function GenerateSignature(ByVal URL As Uri, ByVal ConsumerKey As String, ByVal ConsumerSecret As String, ByVal Token As String, ByVal TokenSecret As String, ByVal HTTPMethod As String, ByVal TimeStamp As String, ByVal Nonce As String, ByRef NormalizedUrl As Uri, ByRef NormalizedRequestParameters As String, ByVal CallbackUrl As Uri, ByVal Verifier As String) As String
        Return GenerateSignature(URL, ConsumerKey, ConsumerSecret, Token, TokenSecret, HTTPMethod, TimeStamp, Nonce, SignatureType.HMACSHA1, NormalizedUrl, NormalizedRequestParameters, CallbackUrl, Verifier)
    End Function
    Public Shared Function GenerateSignature(ByVal url As Uri, ByVal ConsumerKey As String, ByVal ConsumerSecret As String, ByVal Token As String, ByVal TokenSecret As String, ByVal HTTPMethod As String, ByVal TimeStamp As String, ByVal Nonce As String, ByVal SignatureType As SignatureType, ByRef NormalizedUrl As Uri, ByRef NormalizedRequestParameters As String, ByVal CallbackUrl As Uri, ByVal Verifier As String) As String
        NormalizedUrl = Nothing
        NormalizedRequestParameters = Nothing

        Select Case SignatureType
            Case SignatureType.PLAINTEXT
                Return HttpUtility.UrlEncode(String.Format(myStringFormatProvider, "{0}&{1}", ConsumerSecret, TokenSecret))

            Case SignatureType.HMACSHA1
                Dim SignatureBase As String = GenerateSignatureBase(url, ConsumerKey, Token, TokenSecret, HTTPMethod, TimeStamp, Nonce, HMACSHA1SignatureType, NormalizedUrl, NormalizedRequestParameters, CallbackUrl, Verifier)

                Dim hmacsha1 As New HMACSHA1()
                Dim ts As String
                If String.IsNullOrEmpty(TokenSecret) Then
                    ts = String.Empty
                Else
                    ts = OAuthUrlEncode(TokenSecret).ToString
                End If
                hmacsha1.Key = Encoding.ASCII.GetBytes(String.Format(myStringFormatProvider, "{0}&{1}", OAuthUrlEncode(ConsumerSecret).ToString, ts))
                Dim signature As String = GenerateSignatureUsingHash(SignatureBase, hmacsha1)
                hmacsha1.Dispose()
                Return signature

            Case SignatureType.RSASHA1
                Throw New NotImplementedException()

            Case Else
                Throw New ArgumentException(My.Resources.UNKNOWN_SIG, NameOf(SignatureType))
        End Select
    End Function
    Public Overridable Function GenerateTimeStamp() As String
        ' Default implementation of UNIX time of the current UTC time
        Dim ts As TimeSpan = DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return Convert.ToInt64(ts.TotalSeconds).ToString(myStringFormatProvider)
    End Function
    Public Overridable Function GenerateNonce() As String
        Return Guid.NewGuid.ToString.Replace("-", "")
    End Function
    Public Shared Function GenerateSignatureCB(ByVal URL As Uri, ByVal ConsumerKey As String, ByVal ConsumerSecret As String, ByVal Token As String, ByVal TokenSecret As String, ByVal HTTPMethod As String, ByVal TimeStamp As String, ByVal Nonce As String, ByRef NormalizedUrl As Uri, ByRef NormalizedRequestParameters As String, ByVal CallbackUrl As Uri, ByVal Verifier As String) As String
        Return GenerateSignatureCB(URL, ConsumerKey, ConsumerSecret, Token, TokenSecret, HTTPMethod, TimeStamp, Nonce, SignatureType.HMACSHA1, NormalizedUrl, NormalizedRequestParameters, CallbackUrl, Verifier)
    End Function
    Public Shared Function GenerateSignatureCB(ByVal url As Uri, ByVal ConsumerKey As String, ByVal ConsumerSecret As String, ByVal Token As String, ByVal TokenSecret As String, ByVal HTTPMethod As String, ByVal TimeStamp As String, ByVal Nonce As String, ByVal SignatureType As SignatureType, ByRef NormalizedUrl As Uri, ByRef NormalizedRequestParameters As String, ByVal CallbackUrl As Uri, ByVal Verifier As String) As String
        NormalizedUrl = Nothing
        NormalizedRequestParameters = Nothing

        Select Case SignatureType
            Case SignatureType.PLAINTEXT
                Return HttpUtility.UrlEncode(String.Format(myStringFormatProvider, "{0}&{1}", ConsumerSecret, TokenSecret))

            Case SignatureType.HMACSHA1
                Dim SignatureBase As String = GenerateSignatureBaseCB(url, ConsumerKey, Token, TokenSecret, HTTPMethod, TimeStamp, Nonce, HMACSHA1SignatureType, NormalizedUrl, NormalizedRequestParameters, CallbackUrl, Verifier)

                Using hmacsha1 As New HMACSHA1()
                    Dim ts As String = String.Empty
                    If String.IsNullOrEmpty(TokenSecret) Then
                        ts = String.Empty
                    Else
                        ts = OAuthUrlEncode(TokenSecret).ToString
                    End If
                    hmacsha1.Key = Encoding.ASCII.GetBytes(String.Format(myStringFormatProvider, "{0}&{1}", OAuthUrlEncode(ConsumerSecret).ToString, ts))

                    Dim signature As String = GenerateSignatureUsingHash(SignatureBase, hmacsha1)
                    Return signature
                End Using
            Case SignatureType.RSASHA1
                Throw New NotImplementedException()

            Case Else
                Throw New ArgumentException(My.Resources.UNKNOWN_SIG, NameOf(SignatureType))
        End Select
    End Function
    Public Shared Function GenerateSignatureBaseCB(ByVal URL As Uri, ByVal ConsumerKey As String, ByVal Token As String, ByVal TokenSecret As String, ByVal HTTPMethod As String, ByVal TimeStamp As String, ByVal Nonce As String, ByVal SignatureType As String, ByRef pNormalizedURL As Uri, ByRef NormalizedRequestParameters As String, ByVal CallbackUrl As Uri, ByVal Verifier As String) As String
        Dim NormalizedURL As String = If(pNormalizedURL IsNot Nothing, pNormalizedURL.ToString, "")
        If Token Is Nothing Then
            Token = String.Empty
        End If

        If TokenSecret Is Nothing Then
            TokenSecret = String.Empty
        End If

        If String.IsNullOrEmpty(ConsumerKey) Then
            Throw New ArgumentNullException(NameOf(ConsumerKey))
        End If

        If String.IsNullOrEmpty(HTTPMethod) Then
            Throw New ArgumentNullException(NameOf(HTTPMethod))
        End If

        If String.IsNullOrEmpty(SignatureType) Then
            Throw New ArgumentNullException(NameOf(SignatureType))
        End If

        NormalizedURL = Nothing
        NormalizedRequestParameters = Nothing

        Dim Parameters As List(Of QueryParameter) = If(URL IsNot Nothing, GetQueryParameters(URL.Query), New List(Of QueryParameter))
        With Parameters
            Parameters.Add(New QueryParameter(OAuthConsumerKeyKey, ConsumerKey))
            Parameters.Add(New QueryParameter(OAuthNonceKey, Nonce))
            Parameters.Add(New QueryParameter(OAuthSignatureMethodKey, SignatureType))
            Parameters.Add(New QueryParameter(OAuthTimestampKey, TimeStamp))
            Parameters.Add(New QueryParameter(OAuthVersionKey, OAuthVersion))
        End With

        If String.IsNullOrEmpty(Token) = False Then
            Parameters.Add(New QueryParameter(OAuthTokenKey, Token))
        End If

        If CallbackUrl IsNot Nothing Then
            Parameters.Add(New QueryParameter(OAuthCallbackKey, OAuthUrlEncode(CallbackUrl.ToString).ToString))
        End If

        If String.IsNullOrEmpty(Verifier) = False Then
            Parameters.Add(New QueryParameter(OAuthVerifier, Verifier))
        End If

        Parameters.Sort(New QueryParameterComparer)
        If URL IsNot Nothing Then
            NormalizedURL = String.Format(myStringFormatProvider, "{0}://{1}", URL.Scheme, URL.Host)
            If Not ((URL.Scheme = "http" And URL.Port = 80) Or (URL.Scheme = "https" And URL.Port = 443)) Then
                NormalizedURL &= ":" + URL.Port.ToString(myStringFormatProvider)
            End If
            NormalizedURL &= URL.AbsolutePath
        End If
        NormalizedRequestParameters = NormalizeRequestParametersCB(Parameters)
        Dim SignatureBase As New StringBuilder()
        With SignatureBase
            .AppendFormat(myStringFormatProvider, "{0}&", HTTPMethod.ToUpper(myCultureInfo))
            .AppendFormat(myStringFormatProvider, "{0}&", OAuthUrlEncode(NormalizedURL).ToString)
            .AppendFormat(myStringFormatProvider, "{0}", OAuthUrlEncode(NormalizedRequestParameters).ToString)
        End With

        Return SignatureBase.ToString
    End Function
    Protected Shared Function NormalizeRequestParametersCB(ByVal Parameters As IList(Of QueryParameter)) As String
        Dim sb As New StringBuilder
        Dim p As QueryParameter
        If Parameters IsNot Nothing Then
            For i As Integer = 0 To Parameters.Count - 1
                p = Parameters(i)
                sb.AppendFormat(myStringFormatProvider, "{0}={1}", p.Name, """" & p.Value & """")
                If i < Parameters.Count - 1 Then
                    sb.Append("&"c)
                End If
            Next
        End If
        Return sb.ToString
    End Function
End Class


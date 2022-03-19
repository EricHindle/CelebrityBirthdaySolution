Imports System.Text
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Reflection
Imports System.Web.Script.Serialization

Friend Module modCbday
#Region "constants"
    Private Const MODULE_NAME As String = "modCbday"
    Public Const ANNIV_HDR As String = "Today is the anniversary of the birth of"
    Public Const BIRTHDAY_HDR As String = "Happy birthday today to"
    Public Const TWEET_MAX_LEN As Integer = 280
    Public Const RTB_CONTROL_NAME As String = "RtbFile"
    Public Const BUTTON_CONTROL_NAME As String = "BtnRewrite"
    Public Const TABPAGE_BASENAME As String = "TabPage_"
    Private Const EM_CHARFROMPOS As Int32 = &HD7
    Private ReadOnly osTestStringValues As String() = {"os", "OS", "o s", "O S", "o.s.", "O.S.", "o. s.", "O. S."}
    Private ReadOnly bceTestStringValues As String() = {"bc", "bce", "BC", "BCE"}
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
#End Region

#Region "private variables"
    Dim _lookup As Dictionary(Of Char, String)
#End Region
#Region "functions"
    Public Function ToSimpleCharacters(ByVal original As String) As String
        Dim rtnvalue As String = original
        If Not String.IsNullOrEmpty(original) Then
            Dim stFormD As String = original.Normalize(NormalizationForm.FormD)
            Dim sb As New StringBuilder
            For ich As Integer = 0 To stFormD.Length - 1
                Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
                If uc <> UnicodeCategory.NonSpacingMark And uc <> UnicodeCategory.OtherPunctuation Then
                    If Lookup.ContainsKey(stFormD(ich)) Then
                        sb.Append(Lookup(stFormD(ich)))
                    Else
                        sb.Append(stFormD(ich))
                    End If
                End If
            Next
            rtnvalue = sb.ToString().Normalize(NormalizationForm.FormC)
        End If
        Return rtnvalue
    End Function
    Private Function Lookup() As Dictionary(Of Char, String)
        If _lookup Is Nothing Then
            _lookup = New Dictionary(Of Char, String)()
            _lookup(Char.ConvertFromUtf32(230)(0)) = "ae"
            _lookup(Char.ConvertFromUtf32(198)(0)) = "AE"
            _lookup(Char.ConvertFromUtf32(208)(0)) = "D"
            _lookup(Char.ConvertFromUtf32(240)(0)) = "d"
            _lookup(Char.ConvertFromUtf32(222)(0)) = "th"
            _lookup(Char.ConvertFromUtf32(254)(0)) = "TH"
            _lookup(Char.ConvertFromUtf32(223)(0)) = "ss"
        End If

        Return _lookup
    End Function

    Public Function GetWikiExtractString(oText As String, Optional sentences As Integer = 2) As String
        Return My.Settings.wikiExtractSearch.Replace("#", CStr(sentences)) & oText.Replace(" ", "+")
    End Function
    Public Function RemoveSquareBrackets(ByVal _text As String) As String
        Dim newText As String = _text.Trim(vbCrLf)
        Do While newText.Contains("[") And newText.Contains("]")
            Dim parts1 As String() = Split(newText, "[", 2)
            Dim parts2 As String() = Split(parts1(1), "]", 2)
            newText = parts1(0) & parts2(1)
        Loop
        Return newText
    End Function
    Public Function NavigateToUrl(pSearchString As String) As WebResponse
        Dim response As WebResponse = Nothing
        Try
            Dim request As WebRequest
            Dim _uri As New Uri(pSearchString)
            ' Create a request for the URL. 
            request = WebRequest.Create(_uri)
            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials
            response = request.GetResponse()
        Catch ex As UriFormatException
        Catch ex As ArgumentException
        Catch ex As WebException
        End Try
        Return response
    End Function
    Public Function GetExtractFromResponse(pResponse As WebResponse) As String
        Dim _extract As String = ""
        Dim wikipage As String
        Try
            Dim sr As New System.IO.StreamReader(pResponse.GetResponseStream())
            wikipage = sr.ReadToEnd
            Dim jss As New JavaScriptSerializer()
            Dim extractDictionary As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)
            If extractDictionary.ContainsKey("query") Then
                Dim queryDictionary As Dictionary(Of String, Object) = extractDictionary("query")
                If queryDictionary.ContainsKey("pages") Then
                    Dim _pagesList As ArrayList = TryCast(queryDictionary("pages"), ArrayList)
                    If _pagesList IsNot Nothing Then
                        Dim pageDictionary As Dictionary(Of String, Object) = _pagesList(0)
                        If pageDictionary.ContainsKey("extract") Then
                            _extract = TryCast(pageDictionary("extract"), String)
                            _extract = _extract.Replace(vbLf, " ").Replace(".", ". ").Replace("  ", " ")
                        End If
                    End If
                End If
            End If

            sr.Dispose()
        Catch ex As ArgumentException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Argument")
        Catch ex As InvalidOperationException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Invalid Operation")
        Catch ex As OutOfMemoryException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Out Of Memory")
        Catch ex As IOException
            DisplayException(MethodBase.GetCurrentMethod, ex, "IO")
        Catch ex As NullReferenceException
            DisplayException(MethodBase.GetCurrentMethod, ex, "NullReference")
        End Try
        Return _extract
    End Function
    Public Function DisplayException(pMethodBase As MethodBase, pException As Exception, pExceptionType As String, Optional isAsk As Boolean = False) As MsgBoxResult
        LogUtil.Exception(pExceptionType, pException, pMethodBase.Name)
        Return MsgBox(pMethodBase.Name & " : Database exception" & vbCrLf _
            & pException.Message & vbCrLf _
            & If(pException.InnerException Is Nothing, "", pException.InnerException.Message) _
            & If(isAsk, vbCrLf & "OK to continue?", ""),
                   If(isAsk, MsgBoxStyle.YesNo, MsgBoxStyle.OkOnly) Or MsgBoxStyle.Exclamation,
                      pExceptionType)
    End Function
    Public Function GetWikiExtract(_searchName As String, sentences As Integer) As String
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, sentences))
        Dim extract As String = If(_response IsNot Nothing, GetExtractFromResponse(_response), "")
        Return RemoveSquareBrackets(FixQuotesAndHyphens(extract, True))
    End Function
    Public Function ExtractCbdatesFromWikiExtract(wikiExtract As String) As List(Of CbDates)
        Dim cbdates As New List(Of CbDates)
        Dim _blocks As List(Of String) = ParseStringWithBrackets(wikiExtract.Replace("()", ""))
        Dim isBracketsFound As Boolean = True
        Do Until Not isBracketsFound
            If _blocks.Count = 3 Then
                Dim _dateString As String = _blocks(1)
                If Not String.IsNullOrEmpty(_dateString) Then
                    Dim _semiSplit As String() = Split(_dateString, ";")
                    For Each _semi As String In _semiSplit
                        If Not String.IsNullOrEmpty(_semi) Then
                            Dim isInnerBracketsFound As Boolean = True
                            Dim isOs As Boolean = False
                            Do Until Not isInnerBracketsFound
                                Dim testStringParts As List(Of String) = ParseStringWithBrackets(_semi)
                                isInnerBracketsFound = testStringParts.Count = 3
                                If isInnerBracketsFound Then
                                    If IsStringContainsOs(testStringParts(1)) Then
                                        isOs = True
                                    End If
                                    _semi = testStringParts(0) & testStringParts(2)
                                End If
                            Loop
                            Dim splitDates As String() = Split(FixQuotesAndHyphens(_semi, True), " - ", 2)
                            Dim birthString As String = splitDates(0).ToLower.Replace(",", " ").Replace("born", "").Replace("  ", " ").Trim
                            Dim deathString As String = String.Empty
                            If splitDates.Length = 2 Then
                                deathString = splitDates(1).ToLower.Replace(",", " ").Replace("  ", " ").Trim
                            End If
                            Dim _cbDates As CbDates = BuildCbDatesFromStrings(birthString, deathString, isOs)
                            If _cbDates.BirthDate.IsValidDate Then
                                cbdates.Add(_cbDates)
                            End If
                        Else
                        End If
                    Next
                Else
                    LogUtil.Problem("Wiki extract has empty brackets", "ExtractCbdatesFromWikiExtract")
                    LogUtil.Problem(" ..>" & wikiExtract, "ExtractCbdatesFromWikiExtract")
                End If
                _blocks = ParseStringWithBrackets(_blocks(2))
            ElseIf _blocks.Count = 2 Then
                isBracketsFound = False
                LogUtil.Problem("Wiki extract has missing closing bracket", "ExtractCbdatesFromWikiExtract")
                LogUtil.Problem(" ..>" & wikiExtract, "ExtractCbdatesFromWikiExtract")
            ElseIf _blocks.Count = 1 Then
                isBracketsFound = False
            End If
        Loop
        Return cbdates
    End Function
    Private Function BuildCbDatesFromStrings(birthString As String, deathString As String, isOsFound As Boolean) As CbDates
        Dim _cbDates As New CbDates With {
            .BirthDate = FindDateInString(birthString, isOsFound),
            .DeathDate = FindDateInString(deathString, False)
        }
        Return _cbDates
    End Function
    Private Function FindDateInString(possibleDateString As String, isOsFound As Boolean)
        Dim _cbDate As New CbDate
        Dim isOs As Boolean = IsStringContainsOs(possibleDateString) Or isOsFound
        Dim isBc As Boolean = IsStringContainsBc(possibleDateString)
        _cbDate.IsBce = isBc
        _cbDate.IsOldStyle = isOs
        Dim _words As List(Of String) = Split(possibleDateString, " ").ToList
        For index As Integer = _words.Count - 1 To 0 Step -1
            Dim testWord = _words(index).Trim.ToLower
            If String.IsNullOrEmpty(testWord) OrElse testWord = "ad" OrElse testWord = "bc" Then
                _words.RemoveAt(index)
            End If
        Next
        If _words.Count >= 3 Then
            For w As Integer = 0 To _words.Count - 3
                Dim _testDate As String = _words(w) & " " & _words(w + 1) & " " & _words(w + 2).PadLeft(4, "0")
                If IsDate(_testDate) Then
                    _cbDate.DateValue = CDate(_testDate)
                    _cbDate.DateString = _testDate
                    _cbDate.IsValidDate = True
                    Exit For
                End If
            Next
        End If
        Return _cbDate
    End Function
    Private Function IsStringContainsBc(dateString As String) As Boolean
        Dim isBce As Boolean = False
        For Each bceTestString In bceTestStringValues
            If dateString.Contains(bceTestString) Then
                isBce = True
                dateString = dateString.Replace(bceTestString, "")
            End If
        Next
        Return isBce
    End Function
    Private Function IsStringContainsOs(ByRef dateString As String) As Boolean
        Dim isOs As Boolean = False
        For Each osTestString In osTestStringValues
            If dateString.Contains(osTestString) Then
                isOs = True
                dateString = dateString.Replace(osTestString, "")
            End If
        Next
        Return isOs
    End Function
    Public Function FixQuotesAndHyphens(ByVal _text As String, ByVal Optional isSpreadHyphens As Boolean = False) As String
        Dim textWithFixedQuotes As String = _text.Trim(vbCrLf).Replace(Chr(147), """").Replace(Chr(148), """")
        Dim textWithFixedHyphens = textWithFixedQuotes.Replace(Chr(150), "-").Replace("—", "-")
        Dim returnText As String
        If isSpreadHyphens Then
            returnText = textWithFixedHyphens.Replace("-", " - ").Replace("  ", " ")
        Else
            returnText = textWithFixedHyphens.Replace("  ", " ")
        End If
        Return returnText
    End Function
    Public Function ParseStringWithBrackets(ByRef _string As String, Optional ByRef _start As Integer = 0, Optional ByVal _openChar As Char = "("c, Optional ByVal _closeChar As Char = ")"c) As List(Of String)
        Dim _return As New List(Of String) From {_string}
        Dim _firstOpen As Integer = _string.IndexOf(_openChar, _start)
        ' No opening bracket
        If _firstOpen < 0 Then
            Return _return
        End If
        If _string.IndexOf(_closeChar, _firstOpen + 1) < 0 Then
            _return = Split(_string, _openChar, 2).ToList
            Return _return
        End If
        Dim _lastClose As Integer = 0
        Dim _closereq As Integer = 1
        Dim _closefound As Integer = 0
        Dim x As Integer = _firstOpen + 1
        Do Until x >= _string.Length Or _closefound = _closereq
            Select Case _string(x)
                Case _openChar
                    _closereq += 1
                Case _closeChar
                    _closefound += 1
                    _lastClose = x
            End Select
            x += 1
        Loop
        Dim _post As String
        Dim _pre As String
        Dim _inner As String
        Try
            _post = _string.Substring(_lastClose + 1)
            _pre = _string.Substring(0, _firstOpen)
            _inner = _string.Substring(_firstOpen + 1, _lastClose - _firstOpen - 1)
        Catch ex As ArgumentException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Out of Range")
            Return _return
        End Try
        Return {_pre, _inner, _post}.ToList
    End Function
#End Region
End Module
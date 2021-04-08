Imports System.Text
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Reflection

Friend Module modCbday
#Region "constants"
    Private Const MODULE_NAME As String = "modCbday"
#End Region
    Public Const ANNIV_HDR As String = "Today is the anniversary of the birth of"
    Public Const BIRTHDAY_HDR As String = "Happy birthday today to"
    Public Const TWEET_MAX_LEN As Integer = 280
    Public Const RTB_CONTROL_NAME As String = "RtbFile"
    Public Const BUTTON_CONTROL_NAME As String = "BtnRewrite"
    Public Const TABPAGE_BASENAME As String = "TabPage_"
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Private Class NativeMethods
        Public Declare Function SendMessageLong Lib "user32" _
                        Alias "SendMessageA" (ByVal hWnd As IntPtr,
                                              ByVal wMsg As Int32,
                                              ByVal wParam As Int32,
                                              ByVal lParam As Int32) As Long
    End Class
    Private Structure POINTAPI
        Public X As Integer
        Public Y As Integer
    End Structure
    Private Const EM_CHARFROMPOS As Int32 = &HD7
    Dim _lookup As Dictionary(Of Char, String)

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
    Public Function SetFormPos(ByRef oForm As Form) As String
        Dim sPos As String
        If oForm.WindowState = FormWindowState.Maximized Then
            sPos = "max"
        ElseIf oForm.WindowState = FormWindowState.Minimized Then
            sPos = "min"
        Else
            sPos = oForm.Top & "~" & oForm.Left & "~" & oForm.Height & "~" & oForm.Width
        End If
        Return sPos
    End Function
    Public Sub GetFormPos(ByRef oForm As Form, ByVal sPos As String)
        If sPos = "max" Then
            oForm.WindowState = FormWindowState.Maximized
        ElseIf sPos = "min" Then
            oForm.WindowState = FormWindowState.Minimized
        Else
            Dim pos As String() = sPos.Split("~")
            If pos.Length = 4 Then
                oForm.Top = CInt(pos(0))
                oForm.Left = CInt(pos(1))

            End If
        End If
    End Sub
    Public Function RemoveBadCharacters(_text As String, unicode As Integer()) As String
        Dim _text2 As String = _text
        For Each c As Char In _text
            For Each code As Integer In unicode
                If AscW(c) = code Then
                    _text2 = _text2.Replace(c, "")
                End If
            Next
        Next
        Return _text2
    End Function
    ' Return the character position under the mouse.
    Public Function TextBoxCursorPos(ByRef oBox As TextBox,
        ByVal X As Single, ByVal Y As Single) As Long
        ' Convert screen coordinates into control coordinates.
        Dim pt As Point = oBox.PointToClient(New Point(X,
            Y))

        ' Get the character number
        TextBoxCursorPos = NativeMethods.SendMessageLong(oBox.Handle,
            EM_CHARFROMPOS, 0&, CLng(pt.X + pt.Y * &H10000)) _
            And &HFFFF&
    End Function
    Public Function RemoveTags(ByVal sText As String) As String
        Dim outText As New StringBuilder
        Dim inTag As Boolean = False
        For Each c As Char In sText
            If c = "<" Then inTag = True
            If Not inTag Then
                outText.Append(c)
            End If
            If c = ">" Then inTag = False
        Next
        Return outText.ToString
    End Function
    Public Function CheckForChanges(_personTable As List(Of Person)) As Boolean
        Dim isUnsavedChanges As Boolean = False
        If _personTable IsNot Nothing Then
            For Each oPerson As Person In _personTable
                If oPerson.UnsavedChanges Then
                    isUnsavedChanges = True
                End If
            Next
        End If
        Return isUnsavedChanges
    End Function
    Public Function MakeImageName(oForename As String, oSurname As String) As String
        oForename = oForename.ToLower(myCultureInfo).Trim
        oSurname = oSurname.ToLower(myCultureInfo).Trim
        Dim sImgName As String = ToSimpleCharacters(If(String.IsNullOrEmpty(oForename), "", oForename & " ") & oSurname).Replace(" ", "-").Replace("'", "").Replace(".", "-").Replace("--", "-")
        Return sImgName
    End Function

    Public Function GetSourceControl(ByRef menuItem As Object) As Object
        Dim _menuItem As ToolStripMenuItem = CType(menuItem, ToolStripMenuItem)
        Dim menuStrip As ContextMenuStrip = CType(_menuItem.Owner, ContextMenuStrip)
        Return menuStrip.SourceControl
    End Function

    Public Function SaveImage(ByVal pUri As Uri, ByVal strFName As String) As Boolean
        LogUtil.Info("Saving Image from " & pUri.ToString & " to " & strFName, MODULE_NAME)
        Dim rtnval As Boolean = True
        Dim b() As Byte '   Store picture bytes
        ' Create a request for the URL. 
        Dim request As WebRequest = WebRequest.Create(pUri)
        ' If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials
        ' Get the response.
        Dim response As WebResponse = Nothing
        Dim memorystream As New MemoryStream
        Try
            LogUtil.Info("Sending request for image", MODULE_NAME)
            response = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Read the content.
            Dim buffer(4096) As Byte
            Dim bct As Integer = -1
            LogUtil.Info("Reading response", MODULE_NAME)
            Do While (bct <> 0)
                bct = dataStream.Read(buffer, 0, buffer.Length)
                memorystream.Write(buffer, 0, bct)
            Loop
            b = memorystream.ToArray()
            If b.Length > 0 Then
                Dim bw As BinaryWriter = Nothing
                Dim isOkToWrite As Boolean = True
                Try
                    If My.Computer.FileSystem.FileExists(strFName) Then
                        LogUtil.Warn("File already exists")
                        isOkToWrite = MsgBox("File exists. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes
                    End If
                    If isOkToWrite Then
                        LogUtil.Info("Writing image to " & strFName, MODULE_NAME)
                        Dim _fileStream As FileStream = File.Open(strFName, FileMode.Create)
                        bw = New BinaryWriter(_fileStream)
                        bw.Write(b)
                    End If
                Catch ex As IOException
                    LogUtil.Exception("Save image error", ex, "modCbday")
                    MsgBox("IO Error writing file" & vbCrLf & ex.Message)
                    rtnval = False
                Catch ex As ArgumentException
                    LogUtil.Exception("Save image error", ex, "modCbday")
                    MsgBox("Error writing file" & vbCrLf & ex.Message)
                    rtnval = False
                Finally
                    If bw IsNot Nothing Then
                        bw.Close()
                    End If
                    bw = Nothing
                End Try
            End If
        Catch ex As WebException
            LogUtil.Exception("WebException:Failed to get image", ex, "modCbday")
            rtnval = False
        Catch ex As NotSupportedException
            LogUtil.Exception("NotSupportedException:Failed to get image", ex, "modCbday")
            rtnval = False
        Finally
            ' Clean up the streams and the response.
            If response IsNot Nothing Then
                response.Close()
                response.Dispose()
            End If
            memorystream.Close()
            memorystream.Dispose()
        End Try
        If rtnval Then LogUtil.Info("Image save complete", MODULE_NAME)
        Return rtnval
    End Function

    Public Function GetGoogleSearchString(oText As String) As String
        Return My.Settings.googleImageSearch & oText.Replace(" ", "+")
    End Function
    Public Function GetWordPressMonthUrl(oLoadYear As String, oLoadMonth As String, oLoadDay As String, oSelDay As String, oSelMonth As String) As String
        Return My.Settings.WordPressMonthUrl.Replace("#m", oLoadMonth.ToLower(myCultureInfo)).Replace("#y", oLoadYear).Replace("#d", oLoadDay).Replace("#D", oSelDay).Replace("#M", oSelMonth)
    End Function
    Public Function GetTwitterSearchString(oText As String) As String
        Return My.Settings.TwitterSearchUrl & oText.Replace(" ", "+")
    End Function

    Public Function GetWikiSearchString(oText As String) As String
        Return My.Settings.wikiSearchUrl & oText.Replace(" ", "+")
    End Function
    Public Function GetWikiExtractString(oText As String, Optional sentences As Integer = 2) As String
        Return My.Settings.wikiExtractSearch.Replace("#", CStr(sentences)) & oText.Replace(" ", "+")
    End Function
    Public Function GetWikiTitleString(oSearchName As String) As String
        Dim endName As String() = Split(oSearchName, "_(", 2)
        Return My.Settings.wikiTitleSearch.Replace("#f", oSearchName).Replace("#t", endName(0) & "_(zzzzzzzz)")
    End Function
    Public Function GetTextBoxFromPage(_tabPage As TabPage) As RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & CStr(_tabPage.TabIndex)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Any() Then
            For _controlIndex = 0 To _controls.GetUpperBound(0)
                If TryCast(_controls(_controlIndex), RichTextBox) IsNot Nothing Then
                    Return _controls(_controlIndex)
                    Exit For
                End If
            Next
        End If
        Return Nothing
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
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(pResponse.GetResponseStream())
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
    Public Function GetUniqueFname(ByVal filename As String, ByVal Optional pPath As String = Nothing) As String
        Dim newfilename As String = filename
        If pPath Is Nothing Then pPath = Path.GetDirectoryName(filename)
        Try
            For subs As Integer = 0 To 999
                newfilename = Path.Combine(pPath, Path.GetFileNameWithoutExtension(filename) & "_" & CStr(subs) & Path.GetExtension(filename))
                If My.Computer.FileSystem.FileExists(newfilename) = False Then
                    Exit For
                End If
            Next
        Catch ex As ArgumentException
            DisplayException(MethodBase.GetCurrentMethod, ex, "Argument")
        End Try
        Return newfilename
    End Function
    Public Function AddTypeNode(oBirthdayTable As List(Of Person), testDate As Date, _treeView As TreeView, _type As String) As TreeNode
        Dim newBirthdayNode As TreeNode = _treeView.Nodes.Add(Format(testDate, "MMMM dd") & _type, _type)
        newBirthdayNode.Checked = True
        For Each oPerson As Person In oBirthdayTable
            AddNameNode(newBirthdayNode, oPerson, _type)
        Next
        newBirthdayNode.Expand()
        Return newBirthdayNode
    End Function
    Public Function AddNameNode(newBirthdayNode As TreeNode, oPerson As Person, _type As String) As TreeNode
        Dim newNameNode As TreeNode = newBirthdayNode.Nodes.Add(oPerson.Name)
        If oPerson.Social IsNot Nothing Then
            If Not String.IsNullOrEmpty(oPerson.Social.TwitterHandle) Then
                Dim _twitterNode As TreeNode = newNameNode.Nodes.Add("twitter", oPerson.Social.TwitterHandle)
                _twitterNode.Checked = True
            End If
            newNameNode.Checked = True
            If oPerson.Social.IsNoTweet = True Then
                newNameNode.Checked = False
            End If
        End If
        newNameNode.Nodes.Add("id", oPerson.Id)
        newNameNode.Nodes.Add("desc", oPerson.ShortDesc)
        newNameNode.Nodes.Add("length", oPerson.Name.Length)
        newNameNode.Nodes.Add("year", oPerson.BirthYear)
        Dim _age As Integer = CalculateAge(oPerson)
        Dim _ageNode As TreeNode = newNameNode.Nodes.Add("age", CStr(_age))
        _ageNode.Checked = (_type = "Birthday")
        Return newNameNode
    End Function
    Public Function CalculateAge(oPerson As Person, Optional isNextBirthday As Boolean = True) As Integer
        Dim _years As Integer = 0
        If oPerson.BirthYear > 0 Then
            Dim _dob As Date = New Date(oPerson.BirthYear, oPerson.BirthMonth, oPerson.BirthDay)
            Dim _thisMonth As Integer = Today.Month
            Dim _thisDay As Integer = Today.Day
            _years = DateDiff(DateInterval.Year, _dob, Today)
            If (_thisMonth > oPerson.BirthMonth OrElse (_thisMonth = oPerson.BirthMonth And _thisDay > oPerson.BirthDay)) And isNextBirthday Then
                _years += 1
            End If
        End If
        Return _years
    End Function
    Public Function GetWikiText(_sentences As Integer, _forename As String, _surname As String, Optional wikiId As String = "") As String
        Dim fullName As String = If(String.IsNullOrEmpty(_forename), "", _forename.Trim & " ") & _surname.Trim
        Dim _searchName As String = If(String.IsNullOrEmpty(wikiId), fullName, wikiId)
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, _sentences))
        Dim extract As String = GetExtractFromResponse(_response)
        Return extract
    End Function
    Public Function GetWikiExtract(_searchName As String) As String
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, 2))
        Dim extract As String = If(_response IsNot Nothing, GetExtractFromResponse(_response), "")
        Return RemoveSquareBrackets(FixQuotesAndHyphens(extract, True))
    End Function
    Public Function GetWikiDates(_dateString As String) As List(Of String)
        Dim wikiDates As New List(Of String)
        Dim _semiSplit As String() = Split(_dateString, ";")
        Dim _possibleDates As String() = Nothing
        For Each _semi As String In _semiSplit
            Dim _s1 As String() = Split(_semi, "born")
            '  LogUtil.Debug("_s1: " & Join(_s1, "|"))
            Dim _s2 As String() = Split(_s1(Math.Min(_s1.Length - 1, 1)), "c.")
            '  LogUtil.Debug("_s2: " & Join(_s2, "|"))
            Dim _s3 As String() = Split(_s2(Math.Min(_s2.Length - 1, 1)), " on ")
            '  LogUtil.Debug("_s3: " & Join(_s3, "|"))
            Dim _s4 As String() = Split(_s3(Math.Min(_s3.Length - 1, 1)), " in ")
            '  LogUtil.Debug("_s4: " & Join(_s4, "|"))
            Dim _s5 As String = _s4(0)
            _possibleDates = Split(_s5, " - ")
            '  LogUtil.Debug("_possibleDates: " & Join(_possibleDates, "|"))
            If IsDate(_possibleDates(0).Trim) Then
                Exit For
            End If
        Next
        If _possibleDates IsNot Nothing Then
            For Each _possibleDate As String In _possibleDates
                Dim foundDate As String = FindDateInString(_possibleDate.Trim)
                If Not String.IsNullOrEmpty(foundDate) Then
                    '  LogUtil.Debug("foundDate: " & foundDate)
                    wikiDates.Add(foundDate)
                End If
            Next
        End If
        Return wikiDates
    End Function
    Public Function FindDateInString(_possibleDate As String) As String
        Dim _foundDate As String = Nothing
        Dim _words As String() = Split(_possibleDate.Replace(",", "").Replace("  ", " ").Trim, " ")
        If _words.Length >= 3 Then
            For w As Integer = 0 To _words.Length - 3
                Dim _testDate As String = _words(w) & " " & _words(w + 1) & " " & _words(w + 2)
                If IsDate(_testDate) Then
                    _foundDate = _testDate
                    Exit For
                End If
            Next
        End If
        Return _foundDate
    End Function
    Public Function GetPersonDatesFromWiki(searchString As String, ByRef _person As Person) As List(Of String)
        Dim _wikiExtract As String = GetWikiExtract(searchString)
        Dim isDateFound As Boolean = False
        Dim isEndOfExtract As Boolean = String.IsNullOrEmpty(_wikiExtract)
        Dim _dates As New List(Of String)
        Do Until isDateFound Or isEndOfExtract
            Dim _parts As List(Of String) = ParseStringWithBrackets(_wikiExtract)
            If _parts.Count <> 3 Then
                isEndOfExtract = True
            Else
                '  LogUtil.Debug("_parts(1): " & _parts(1))
                _dates = GetWikiDates(_parts(1))
                If _dates.Count > 0 Then
                    isDateFound = True
                    If IsDate(_dates(0)) Then
                        Dim _dob As Date = CDate(_dates(0))
                        '  LogUtil.Debug("_dob: " & _dates(0))
                        If _person.DateOfBirth <> _dob Then
                            isDateFound = False
                            _wikiExtract = _parts(2)
                        End If
                    End If
                Else
                    _wikiExtract = _parts(2)
                End If
            End If
        Loop
        Return _dates
    End Function

End Module



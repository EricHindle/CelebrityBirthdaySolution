Imports System.Text
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Web.Script.Serialization
Imports System.Reflection

Friend Module modCbday
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
    Dim _lookup As Dictionary(Of Char, String) = Nothing

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
            response = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Read the content.
            Dim buffer(4096) As Byte
            Dim bct As Integer = -1
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
                        isOkToWrite = MsgBox("File exists. OK to continue?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.Yes
                    End If
                    If isOkToWrite Then
                        Dim _fileStream As FileStream = File.Open(strFName, FileMode.Create)
                        bw = New BinaryWriter(_fileStream)
                        bw.Write(b)
                    End If
                Catch ex As IOException
                    MsgBox("IO Error writing file" & vbCrLf & ex.Message)
                    rtnval = False
                Catch ex As ArgumentException
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
            rtnval = False
        Catch ex As NotSupportedException
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

    Public Function GetTextBoxFromPage(_tabPage As TabPage) As RichTextBox
        Dim _rtb As New RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & CStr(_tabPage.TabIndex)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Length > 0 Then
            _rtb = TryCast(_controls(0), RichTextBox)
        End If
        Return _rtb
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
    Public Function ParseStringWithBrackets(ByRef _string As String, Optional ByRef _start As Integer = 0, Optional ByVal _openChar As Char = "("c, Optional ByVal _closeChar As Char = ")"c) As List(Of String)
        Dim _return As New List(Of String)
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

        Return MakeList(_pre, _inner, _post)
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
    Public Function DisplayException(pMethodBase As MethodBase, pException As Exception, pExceptionType As String) As MsgBoxResult
        Return MsgBox(pMethodBase.Name & " : Database exception" & vbCrLf _
            & pException.Message & vbCrLf _
            & If(pException.InnerException Is Nothing, "", pException.InnerException.Message) _
            & vbCrLf & "OK to continue?",
                      MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation,
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
End Module



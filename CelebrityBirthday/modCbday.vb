Imports System.Text
Imports System.Globalization
Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D

Module modCbday
    Public Const ANNIV_HDR As String = "Today is the anniversary of the birth of"
    Public Const BIRTHDAY_HDR As String = "Happy birthday today to"
    Public Const TWEET_SIZE As Integer = 279

    Public Const RTB_CONTROL_NAME As String = "RtbFile"
    Public Const BUTTON_CONTROL_NAME As String = "BtnRewrite"
    Public Const TABPAGE_BASENAME As String = "TabPage_"

    Private Declare Function SendMessageLong Lib "user32" Alias _
        "SendMessageA" (ByVal hWnd As IntPtr, ByVal wMsg As _
        Int32, ByVal wParam As Int32, ByVal lParam As Int32) As _
        Long
    Private Structure POINTAPI
        Public X As Integer
        Public Y As Integer
    End Structure
    Private Const EM_CHARFROMPOS As Int32 = &HD7
    Dim _lookup As Dictionary(Of Char, String) = Nothing
    Public Function ToSimpleCharacters(ByVal original As String) As String
        Dim rtnvalue As String = original
        If original <> String.Empty Then
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
            If pos.Count = 4 Then
                oForm.Top = CInt(pos(0))
                oForm.Left = CInt(pos(1))
                oForm.Height = CInt(pos(2))
                oForm.Width = CInt(pos(3))
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
        TextBoxCursorPos = SendMessageLong(oBox.Handle,
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
        oForename = oForename.ToLower.Trim
        oSurname = oSurname.ToLower.Trim
        Dim sImgName As String = ToSimpleCharacters(If(String.IsNullOrEmpty(oForename), "", oForename & " ") & oSurname).Replace(" ", "-").Replace("'", "").Replace(".", "-").Replace("--", "-")
        Return sImgName
    End Function

    Public Function GetSourceControl(ByRef menuItem As Object) As Object
        Dim _menuItem As ToolStripMenuItem = CType(menuItem, ToolStripMenuItem)
        Dim menuStrip As ContextMenuStrip = CType(_menuItem.Owner, ContextMenuStrip)
        Return menuStrip.SourceControl
    End Function

    Public Function SaveImage(ByVal url As String, ByVal strFName As String) As Boolean
        Dim rtnval As Boolean = True
        Dim b() As Byte '   Store picture bytes
        ' Create a request for the URL. 
        Dim request As WebRequest = WebRequest.Create(url)
        ' If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials
        ' Get the response.
        Dim response As WebResponse
        Try
            response = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Read the content.
            Dim buffer(4096) As Byte
            Dim memorystream As New MemoryStream
            Dim bct As Integer = -1
            Do While (bct <> 0)
                bct = dataStream.Read(buffer, 0, buffer.Length)
                memorystream.Write(buffer, 0, bct)
            Loop
            b = memorystream.ToArray()
            If b.Length > 0 Then
                Dim bw As BinaryWriter = Nothing
                Try
                    bw = New BinaryWriter(File.Open(strFName, FileMode.Create))
                    bw.Write(b)
                Catch ex As Exception
                    MsgBox("Error writing file")
                    rtnval = False
                Finally
                    If bw IsNot Nothing Then
                        bw.Close()
                    End If
                    bw = Nothing
                End Try
            End If
            ' Clean up the streams and the response.
            memorystream.Close()
            response.Close()
            memorystream.Dispose()
            response = Nothing
        Catch ex As Exception
            rtnval = False
        End Try
        Return rtnval
    End Function

    Public Function GetGoogleSearchString(oText As String) As String
        Return My.Settings.googleImageSearch & oText.Replace(" ", "+")
    End Function

    Public Function GetTwitterSearchString(oText As String) As String
        Return My.Settings.TwitterSearchUrl & oText.Replace(" ", "+")
    End Function

    Public Function GetWikiSearchString(oText As String) As String
        Return My.Settings.wikiSearchUrl & oText.Replace(" ", "+")
    End Function
    Public Function GetWikiExtractString(oText As String) As String
        Return My.Settings.wikiExtractSearch & oText.Replace(" ", "+")
    End Function

    Public Function GetTextBoxFromPage(_tabPage As TabPage) As RichTextBox
        Dim _rtb As New RichTextBox
        Dim _tabName As String = RTB_CONTROL_NAME & CStr(_tabPage.TabIndex)
        Dim _controls As Control() = _tabPage.Controls.Find(_tabName, False)
        If _controls.Count > 0 Then
            _rtb = TryCast(_controls(0), RichTextBox)
        End If
        Return _rtb
    End Function



End Module

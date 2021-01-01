Imports System.Reflection
Module modText
    Public Function ParseStringWithChar(last As String, _char As Char) As List(Of String)
        Return Split(last.Trim([_char]), _char).ToList()
    End Function
    Public Function ParseStringWithString(source As String, _chars As String) As List(Of String)
        Return Split(source.Trim(_chars), _chars).ToList()
    End Function
    Public Function MakeList(ByVal _string1 As String, ByVal _string2 As String, ByVal _string3 As String) As List(Of String)
        Dim _return As New List(Of String) From {
            _string1,
            _string2,
            _string3
        }
        Return _return
    End Function
    Public Function FixQuotesAndHyphens(ByVal _text As String) As String
        Return _text.Trim(vbCrLf).Replace(Chr(147), """").Replace(Chr(148), """").Replace(Chr(150), "-").Replace("—", "-").Replace("-", " - ").Replace("  ", " ")
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

        Return MakeList(_pre, _inner, _post)
    End Function

End Module

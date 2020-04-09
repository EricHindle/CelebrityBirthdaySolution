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
    Public Function FixQuotes(ByVal _text As String) As String
        Return _text.Trim(vbCrLf).Replace(Chr(147), """").Replace(Chr(148), """").Replace(Chr(150), "-")
    End Function
End Module

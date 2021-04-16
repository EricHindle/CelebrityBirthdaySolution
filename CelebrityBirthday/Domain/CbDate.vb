Public Class CbDate
    Private _date As Date
    Private _isBce As Boolean
    Private _dateString As String
    Private _isOS As Boolean
    Private _isValidDate As Boolean
    Public Property IsValidDate() As Boolean
        Get
            Return _isValidDate
        End Get
        Set(ByVal value As Boolean)
            _isValidDate = value
        End Set
    End Property
    Public Property IsOldStyle() As Boolean
        Get
            Return _isOS
        End Get
        Set(ByVal value As Boolean)
            _isOS = value
        End Set
    End Property
    Public Property DateString() As String
        Get
            Return _dateString
        End Get
        Set(ByVal value As String)
            _dateString = value
        End Set
    End Property
    Public Property DateValue() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
        End Set
    End Property
    Public Property IsBce() As Boolean
        Get
            Return _isBce
        End Get
        Set(ByVal value As Boolean)
            _isBce = value
        End Set
    End Property
    Public Sub New(pDate As Date)
        _date = pDate
        _isBce = False
        _isOS = False
        _dateString = Format(_date, "dd MMMM yyyy")
        _isValidDate = True
    End Sub
    Public Sub New(pDate As Date, pIsBce As Boolean, pIsOs As Boolean)
        _date = pDate
        _isBce = pIsBce
        _isOS = pIsOs
        _dateString = If(_isOS, "O.S. ", "") & Format(_date, "dd MMMM yyyy") & If(_isBce, " BCE", "")
        _isValidDate = True
    End Sub
    Public Sub New(pDate As String)
        _dateString = pDate
        Dim foundDate As Date? = FindDateInString(pDate)
        If foundDate.HasValue Then
            _date = foundDate.Value
            _isValidDate = True
        Else
            _isValidDate = False
        End If
        _isBce = pDate.ToLower.Contains("bc") Or pDate.Contains("bce")
        _isOS = pDate.ToLower.Contains("os") Or pDate.Contains("o.s.")
    End Sub
    Private Shared Function FindDateInString(_possibleDate As String) As Date?
        Dim foundDate As Date?
        Dim _list1 As List(Of String) = ParseStringWithBrackets(_possibleDate)
        Dim _d1 As String = _list1(0)
        If _list1.Count = 3 Then
            _d1 &= _list1(2)
        End If
        Dim _list2 As List(Of String) = ParseStringWithBrackets(_d1, 0, "[", "]")
        Dim _d2 As String = _list2(0)
        If _list2.Count = 3 Then
            _d2 &= _list2(2)
        End If
        Dim _d3 As String = _d2.ToLower _
                                .Replace(",", " ") _
                                .Replace(". ", ".") _
                                .Replace("os", "") _
                                .Replace("o.s.", "") _
                                .Replace("bc", "") _
                                .Replace("b.c.", "") _
                                .Replace("  ", " ") _
                                .Replace(". ", ".") _
                                .Replace("os", "") _
                                .Trim
        Dim _words As String() = Split(_d3, " ")
        If _words.Length >= 3 Then
            For w As Integer = 0 To _words.Length - 3
                Dim _testDate As String = _words(w) & " " & _words(w + 1) & " " & _words(w + 2)
                If IsDate(_testDate) Then
                    foundDate = CDate(_testDate)
                    Exit For
                End If
            Next
        End If
        Return foundDate
    End Function
End Class

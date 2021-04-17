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
    Public Sub New(pDate As Date?)
        If pDate.HasValue Then
            _date = pDate.Value
            _dateString = Format(_date, "dd MMMM yyyy")
            _isValidDate = True
        Else
            _dateString = ""
            _isValidDate = False
        End If
        _isBce = False
        _isOS = False
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
            '    LogUtil.Debug("Invalid")
        End If
        Dim lowerDate As String = pDate.ToLower.Replace(".", "")
        _isBce = lowerDate.Contains("bc") Or lowerDate.Contains("bce")
        _isOS = lowerDate.Contains("os")
    End Sub
    Private Shared Function FindDateInString(_possibleDate As String) As Date?
        Dim foundDate As Date?
        '   Dim stringDate As String = ""
        Dim testString As String = _possibleDate.Replace(")", " ) ").Replace("]", " ] ").ToLower.Replace("  ", " ").Trim
        Dim _words As List(Of String) = Split(testString, " ").ToList
        For index As Integer = _words.Count - 1 To 0 Step -1
            If String.IsNullOrEmpty(_words(index)) Then
                _words.RemoveAt(index)
            End If
        Next
        If _words.Count >= 3 Then
            For w As Integer = 0 To _words.Count - 3
                Dim _testDate As String = _words(w) & " " & _words(w + 1) & " " & _words(w + 2)
                If IsDate(_testDate) Then
                    foundDate = CDate(_testDate)
                    '    stringDate = _testDate
                    Exit For
                End If
            Next
        End If
        '   LogUtil.Debug("found date in " & _possibleDate & " : " & stringDate)
        Return foundDate
    End Function
End Class

' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Text

Public Class CbDate
#Region "properties"
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
            If IsValidDate Then _dateString = FormattedDateString()
        End Set
    End Property
    Public Property IsOldStyle() As Boolean
        Get
            Return _isOS
        End Get
        Set(ByVal value As Boolean)
            _isOS = value
            If IsValidDate Then _dateString = FormattedDateString()
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
            IsValidDate = True
        End Set
    End Property
    Public Property IsBce() As Boolean
        Get
            Return _isBce
        End Get
        Set(ByVal value As Boolean)
            _isBce = value
            If IsValidDate Then _dateString = FormattedDateString()
        End Set
    End Property
#End Region
#Region "constructors"
    Public Sub New()
        _date = Date.MinValue
        _isBce = False
        _isOS = False
        _dateString = ""
        _isValidDate = False
    End Sub
    Public Sub New(pDate As Date)
        _date = pDate
        _isBce = False
        _isOS = False
        _isValidDate = True
        _dateString = FormattedDateString()
    End Sub
    Public Sub New(pDate As Date?)
        _isBce = False
        _isOS = False
        If pDate.HasValue Then
            _date = pDate.Value
            _isValidDate = True
            _dateString = FormattedDateString()
        Else
            _dateString = ""
            _isValidDate = False
        End If

    End Sub
    Public Sub New(pDate As Date, pIsBce As Boolean, pIsOs As Boolean)
        _date = pDate
        _isBce = pIsBce
        _isOS = pIsOs
        _isValidDate = True
        _dateString = FormattedDateString()
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
#End Region
#Region "methods"
    Public Function FormattedDateString() As String
        Return If(_isOS, "O.S. ", "") & Format(_date, "dd MMMM yyyy") & If(_isBce, " BCE", "")
    End Function
    Private Shared Function FindDateInString(_possibleDate As String) As Date?
        Dim foundDate As Date?
        Dim testString As String = _possibleDate.Replace(")", " ) ").Replace("]", " ] ").ToLower.Replace("  ", " ").Trim
        Dim _words As List(Of String) = Split(testString, " ").ToList
        For index As Integer = _words.Count - 1 To 0 Step -1
            If String.IsNullOrEmpty(_words(index)) Then
                _words.RemoveAt(index)
            End If
        Next

        '   LogUtil.Debug("found date in " & _possibleDate & " : " & stringDate)
        Return foundDate
    End Function
    Public Overrides Function ToString() As String
        Dim cbDateString As New StringBuilder
        cbDateString.Append("{DateValue : ")
        If IsValidDate Then
            cbDateString.Append(FormattedDateString())
        Else
            cbDateString.Append("Invalid")
        End If
        cbDateString.Append("}"c)
        cbDateString.Append(", {DateString : ").Append(DateString).Append("}"c)
        cbDateString.Append(", {IsOldStyle : ").Append(IsOldStyle).Append("}"c)
        cbDateString.Append(", {IsBce : ").Append(IsBce).Append("}"c)
        Return cbDateString.ToString
    End Function
#End Region
End Class

' Hindleware
' Copyright (c) 2021-22, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class BornSameDay
    Private _id As Integer
    Private _day As Integer
    Private _month As Integer
    Private _year As Integer
    Private _postNo As Integer
    Public Property WikiName() As String
    Public Property PostNo() As Integer
        Get
            Return _postNo
        End Get
        Set(ByVal value As Integer)
            _postNo = value
        End Set
    End Property
    Public Property Year() As Integer
        Get
            Return _year
        End Get
        Set(ByVal value As Integer)
            _year = value
        End Set
    End Property
    Public Property Month() As Integer
        Get
            Return _month
        End Get
        Set(ByVal value As Integer)
            _month = value
        End Set
    End Property
    Public Property Day() As Integer
        Get
            Return _day
        End Get
        Set(ByVal value As Integer)
            _day = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private Sub Initialise()
        _id = 0
        _day = 0
        _month = 0
        _year = 0
        _postNo = 0
        WikiName = ""
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, pDay As Integer, pMonth As Integer, pyear As Integer, pPostNo As Integer, pWikiName As String)
        _id = pId
        _day = pDay
        _month = pMonth
        _year = pyear
        _postNo = pPostNo
        WikiName = pWikiName
    End Sub
    Public Sub New(pBotsd As BornSameDay)
        Initialise()
        If pBotsd IsNot Nothing Then
            _id = pBotsd.Id
            _day = pBotsd.Day
            _month = pBotsd.Month
            _year = pBotsd.Year
            _postNo = pBotsd.PostNo
            WikiName = pBotsd.WikiName
        End If
    End Sub
    Public Sub New(pBotsd As CelebrityBirthdayDataSet.BornOnTheSameDayRow)
        Initialise()
        If pBotsd IsNot Nothing Then
            _id = pBotsd.btsdId
            _day = pBotsd.btsdDay
            _month = pBotsd.btsdMonth
            _year = pBotsd.btsdYear
            _postNo = pBotsd.btsdPostNo
            WikiName = pBotsd.btsdUrl
        End If
    End Sub
End Class

' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class Reminder
#Region "properties"
    Private _remId As Integer
    Private _note As String
    Private _person As Person
    Public Property Person() As Person
        Get
            Return _person
        End Get
        Set(ByVal value As Person)
            _person = value
        End Set
    End Property
    Public Property Note() As String
        Get
            Return _note
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _remId
        End Get
        Set(ByVal value As Integer)
            _remId = value
        End Set
    End Property
#End Region
#Region "constructors"
    Private Sub Initialise()
        _note = String.Empty
        _remId = -1

    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(ByVal pId As Integer, ByVal pNote As String, ByRef pPerson As Person)
        Initialise()
        _remId = pId
        _note = pNote
        _person = pPerson
    End Sub
#End Region

End Class

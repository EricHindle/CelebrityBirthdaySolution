' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class CbDates
#Region "properties"
    Private _birthdate As CbDate
    Private _deathDate As CbDate
    Public Property DeathDate() As CbDate
        Get
            Return _deathDate
        End Get
        Set(ByVal value As CbDate)
            _deathDate = value
        End Set
    End Property
    Public Property BirthDate() As CbDate
        Get
            Return _birthdate
        End Get
        Set(ByVal value As CbDate)
            _birthdate = value
        End Set
    End Property
#End Region
#Region "constructors"
    Public Sub New()
        _birthdate = New CbDate
        _deathDate = New CbDate
    End Sub
#End Region
#Region "methods"
    Public Overrides Function ToString() As String
        Return "{{Birthdate : " & BirthDate.ToString & "} {Deathdate : " & DeathDate.ToString & "}}"
    End Function
#End Region
End Class

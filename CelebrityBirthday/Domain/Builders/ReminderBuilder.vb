' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class ReminderBuilder
    Private _remId As Integer
    Private _personId As Integer
    Private _person As Person
    Private _note As String
    Public Shared Function AReminder() As ReminderBuilder
        Return New ReminderBuilder
    End Function
    Public Function StartingWithNothing() As ReminderBuilder
        _remId = -1
        _personId = -1
        _person = PersonBuilder.APerson.StartingWithNothing.Build
        _note = ""
        Return Me
    End Function
    Public Function StartingWith(pRow As CelebrityBirthdayDataSet.RemindersRow) As ReminderBuilder
        StartingWithNothing()
        If pRow IsNot Nothing Then
            _remId = pRow.remId
            _personId = pRow.personId
            _person = PersonBuilder.APerson.StartingWith(GetPersonById(_personId)).Build
            _note = pRow.note
        End If
        Return Me
    End Function
    Public Function StartingWith(pRem As Reminder) As ReminderBuilder
        StartingWithNothing()
        If pRem IsNot Nothing Then
            _remId = pRem.Id
            _person = pRem.Person
            _personId = If(pRem.Person Is Nothing, -1, pRem.Person.Id)
            _note = pRem.Note
        End If
        Return Me
    End Function
    Public Function WithReminderId(ByVal pId As Integer) As ReminderBuilder
        _remId = pId
        Return Me
    End Function
    Public Function WithNote(ByVal pNote As String) As ReminderBuilder
        _note = pNote
        Return Me
    End Function
    Public Function WithPersonId(ByVal pId As Integer) As ReminderBuilder
        _personId = pId
        _person = PersonBuilder.APerson.StartingWith(GetPersonById(_personId)).Build
        Return Me
    End Function
    Public Function WithPerson(ByVal pPerson As Person) As ReminderBuilder
        _personId = pPerson.Id
        _person = pPerson
        Return Me
    End Function
    Public Function Build() As Reminder
        Return New Reminder(_remId, _note, _person)
    End Function
End Class

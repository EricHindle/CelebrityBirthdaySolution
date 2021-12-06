' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public NotInheritable Class AuditUtil
    Private Shared ReadOnly auditTa As New CelebrityBirthdayDataSetTableAdapters.AuditTableAdapter
    Private Shared ReadOnly auditTable As New CelebrityBirthdayDataSet.AuditDataTable
    Private Const PERSON_TABLE As String = "person"
    Private Const DOB_COL As String = "dob"
    Public Shared Function AddDobChange(PersonId As Integer, beforeDate As Date?, afterDate As Date?) As Integer
        Dim before As String = If(beforeDate Is Nothing, "New", CStr(beforeDate))
        Dim after As String = If(afterDate Is Nothing, "New", CStr(afterDate))
        Return auditTa.InsertAudit(PERSON_TABLE, PersonId, DOB_COL, before, after, New Date?(Now))
    End Function
    Public Shared Function GetDobChanges(PersonId As Integer) As CelebrityBirthdayDataSet.AuditDataTable
        auditTa.FillByDobChanges(auditTable, PersonId)
        Return auditTable
    End Function
End Class

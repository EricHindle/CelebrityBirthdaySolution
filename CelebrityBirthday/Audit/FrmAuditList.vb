' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmAuditList
#Region "variables"
    Private oTable As CelebrityBirthdayDataSet.AuditDataTable
    Private oPerson As Person
#End Region
#Region "properties"
    Private _personId As Integer
    Private _dataType As String
    Public Property DataType() As String
        Get
            Return _dataType
        End Get
        Set(ByVal value As String)
            _dataType = value
        End Set
    End Property
    Public Property PersonId() As Integer
        Get
            Return _personId
        End Get
        Set(ByVal value As Integer)
            _personId = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private Sub FrmAuditList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.auditformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub FrmAuditList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.auditformpos)
        LblDataType.Text = ""
        LblName.Text = ""
        If DataType = "dob" And PersonId > 0 Then
            LblDataType.Text = "Date of Birth"
            oPerson = GetFullPersonById(PersonId)
            LblName.Text = oPerson.Name
            oTable = AuditUtil.GetDobChanges(PersonId)
        End If
        LoadAuditView()
    End Sub
#End Region
#Region "subroutines"
    Private Sub LoadAuditView()
        DgvAudit.Rows.Clear()
        For Each oAuditRow As CelebrityBirthdayDataSet.AuditRow In oTable.Rows
            Dim oViewRow As DataGridViewRow = DgvAudit.Rows(DgvAudit.Rows.Add)
            oViewRow.Cells(aud_datatype.Name).Value = If(oAuditRow.IsfieldNull, "", oAuditRow.field)
            oViewRow.Cells(aud_before.Name).Value = If(oAuditRow.IsbeforeNull, "", oAuditRow.before)
            oViewRow.Cells(aud_after.Name).Value = If(oAuditRow.IsafterNull, "", oAuditRow.after)
            oViewRow.Cells(aud_date.Name).Value = If(oAuditRow.IschangedateNull, "", CStr(oAuditRow.changedate))
        Next
    End Sub
#End Region
End Class
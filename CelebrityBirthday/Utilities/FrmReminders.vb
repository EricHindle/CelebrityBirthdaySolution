' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Public Class FrmReminders
#Region "properties"
    Private _personId As Integer
    Public Property PersonId() As Integer
        Get
            Return _personId
        End Get
        Set(ByVal value As Integer)
            _personId = value
        End Set
    End Property
#End Region
#Region "variables"
    Private isLoadingPeople As Boolean
    Private isLoadingReminders As Boolean
    Private isSelecting As Boolean
    Private isSplit As Boolean
    Private currentForename As String
    Private currentSurname As String
    Private currentReminder As Integer
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        DialogResult = System.Windows.Forms.DialogResult.OK
        My.Settings.reminderformpos = SetFormPos(Me)
        SaveSplitterDist()
        My.Settings.Save()
        Close()
    End Sub

    Private Sub FrmReminders_Load(sender As Object, e As EventArgs) Handles Me.Load
        LogUtil.Info("Loading Reminders", MyBase.Name)
        GetFormPos(Me, My.Settings.reminderformpos)
        GetSplitterDist()
        LblPersonId.Text = ""
        LoadReminders()
        cbName.DisplayMember = "Name"
        cbName.ValueMember = "Id"
        currentReminder = -1
        If _personId > 0 Then
            LoadSelectedPerson(GetPersonById(_personId))
        End If
    End Sub

    Private Sub FrmReminders_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
    Private Sub TxtPerson_TextChanged(sender As Object, e As EventArgs) Handles TxtPerson.TextChanged
        If Not isSelecting Then
            If Not String.IsNullOrWhiteSpace(TxtPerson.Text) AndAlso (TxtPerson.Text.Trim.Length > 2) Then
                SplitNameText()
                isLoadingPeople = True
                cbName.Items.Clear()
                Dim selectedPersons As List(Of Person) = FindPeopleLikeName(currentForename, currentSurname)
                For Each oPerson As Person In selectedPersons
                    cbName.Items.Add(oPerson)
                Next
                cbName.SelectedIndex = If(cbName.Items.Count > 0, 0, -1)
                isLoadingPeople = False
            End If
        End If
    End Sub

    Private Sub CbName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbName.SelectedIndexChanged
        isSelecting = True
        If Not isLoadingPeople Then
            If cbName.SelectedIndex > -1 Then
                LoadSelectedPerson(CType(cbName.SelectedItem, Person))
            Else
                LblPersonId.Text = ""
            End If
        End If
        isSelecting = False
    End Sub

    Private Sub DgvReminders_SelectionChanged(sender As Object, e As EventArgs) Handles DgvReminders.SelectionChanged
        If DgvReminders.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvReminders.SelectedRows(0)
            Dim _id As Integer = oRow.Cells(remId.Name).Value
            Dim _rem As Reminder = GetReminderById(_id)
            Dim _name As String = _rem.Person.Name
            Dim _note As String = _rem.Note
            Dim _personId As Integer = _rem.Person.Id
            isSelecting = True
            TxtPerson.Text = _name
            LblId.Text = CStr(_id)
            LblPersonId.Text = CStr(_personId)
            RtbNote.Text = _note
            BtnUpdatePerson.Enabled = True
            Dim _person As String = If(_personId < 0, RtbNote.Text, TxtPerson.Text)
            LogUtil.Info("Selected reminder for " & _person, MyBase.Name)
            isSelecting = False
        Else
            ClearForm()
        End If
    End Sub
#End Region
#Region "subroutines"
    Public Function LoadReminders() As Integer
        isLoadingReminders = True
        Dim _reminders As List(Of Reminder) = GetAllReminders()
        DgvReminders.Rows.Clear()
        For Each _rem As Reminder In _reminders
            Dim orow As DataGridViewRow = DgvReminders.Rows(DgvReminders.Rows.Add())
            orow.Cells(remId.Name).Value = _rem.Id
            orow.Cells(remNote.Name).Value = _rem.Note.Substring(0, Math.Min(100, _rem.Note.Length))
            orow.Cells(rempid.Name).Value = _rem.Person.Id
            If _rem.Person.Id >= 0 Then
                orow.Cells(remPersonId.Name).Value = _rem.Person.Id
                orow.Cells(remName.Name).Value = _rem.Person.Name
            Else
                orow.Cells(remPersonId.Name).Value = "**"
                orow.Cells(remName.Name).Value = "Reminder"
            End If
        Next
        DgvReminders.ClearSelection()
        LogUtil.Info("Loaded " & _reminders.Count & " reminders", MyBase.Name)
        isLoadingReminders = False
        Return _reminders.Count
    End Function
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        DgvReminders.ClearSelection()
        ClearForm()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles BtnRemove.Click
        If DgvReminders.SelectedRows.Count = 1 Then
            Dim _name As String = DgvReminders.SelectedRows(0).Cells(remName.Name).Value
            If DgvReminders.SelectedRows(0).Cells(rempid.Name).Value < 0 Then
                _name = DgvReminders.SelectedRows(0).Cells(remNote.Name).Value
            End If
            Dim _id As Integer = DgvReminders.SelectedRows(0).Cells(remId.Name).Value
            DeleteReminder(_id)
            ShowStatus("Removed reminder for " & _name, LblStatus, True, MyBase.Name)
            LoadReminders()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim _id As Integer = If(IsNumeric(LblPersonId.Text), CInt(LblPersonId.Text), -1)
        Dim _rem As Reminder = ReminderBuilder.AReminder.StartingWithNothing().WithNote(RtbNote.Text).WithPersonId(_id).Build
        InsertReminder(_rem)
        ShowStatus("Added reminder for " & TxtPerson.Text, LblStatus, True, MyBase.Name)
        LoadReminders()
    End Sub
    Private Sub ClearForm()
        LblId.Text = ""
        cbName.Items.Clear()
        TxtPerson.Text = ""
        LblPersonId.Text = ""
        RtbNote.Text = ""
        LblStatus.Text = ""
        BtnUpdatePerson.Enabled = False
    End Sub

    Private Sub SplitNameText()
        Dim fullName As String() = Split(TxtPerson.Text)
        currentSurname = fullName.Last
        fullName(fullName.Length - 1) = ""
        currentForename = Join(fullName).Trim
    End Sub
    Private Sub GetSplitterDist()
        SplitContainer1.SplitterDistance = My.Settings.reminderSplitDist1
    End Sub
    Private Sub SaveSplitterDist()
        My.Settings.reminderSplitDist1 = SplitContainer1.SplitterDistance
    End Sub
    Private Sub LoadSelectedPerson(_person As Person)
        LblPersonId.Text = _person.Id
        TxtPerson.Text = _person.Name
        LogUtil.Info("Selected " & TxtPerson.Text & " from List", MyBase.Name)
    End Sub

    Private Sub BtnUpdatePerson_Click(sender As Object, e As EventArgs) Handles BtnUpdatePerson.Click
        If DgvReminders.SelectedRows.Count > 0 Then
            If DgvReminders.SelectedRows(0).Cells(rempid.Name).Value >= 0 Then
                Me.TopMost = False
                Using _update As New FrmUpdateDatabase
                    _update.PersonId = DgvReminders.SelectedRows(0).Cells(rempid.Name).Value
                    _update.ShowDialog()
                End Using
            Else
                ShowStatus("Not linked to a person", LblStatus,, True)
            End If
        End If
    End Sub

    Private Sub DgvReminders_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvReminders.CellDoubleClick
        Dim oName As String = DgvReminders.Rows(e.RowIndex).Cells(remName.Name).Value
        Dim oPid As Integer = DgvReminders.Rows(e.RowIndex).Cells(rempid.Name).Value
        If oPid < 0 Then
            Dim oNote As String = DgvReminders.Rows(e.RowIndex).Cells(remNote.Name).Value
            Dim oNotePart As String() = Split(oNote, ".", 2)
            oName = StrConv(oNotePart(0).Trim, VbStrConv.ProperCase)
            Dim oNamefromNote As String = oName.Replace(" ", "_")
            TxtName.Text = oName
            TxtWiki.Text = oNamefromNote
            If oNotePart.Length > 1 Then
                If IsDate(oNotePart(1).Trim) Then
                    DtpDob.Value = CDate(oNotePart(1).Trim)
                Else
                    DtpDob.Value = DtpDob.MinDate
                End If
            End If
            oName = oNamefromNote
        End If
        ShowProgress("Opening Wikipedia for " & oName, LblStatus, True, MyBase.Name)
        Try
            Process.Start(My.Resources.WIKIURL & oName)
        Catch ex As InvalidOperationException
            ShowStatus("Wikipedia failed", LblStatus, False, True)
            ShowStatus("Wikipedia failed " & oName,,, MyBase.Name, ex)
        Catch ex As ComponentModel.Win32Exception
            ShowStatus("Wikipedia failed", LblStatus, False, True)
            ShowStatus("Wikipedia failed " & oName,,, MyBase.Name, ex)
        End Try
    End Sub

    Private Sub BtnPasteName_Click(sender As Object, e As EventArgs) Handles BtnPasteName.Click
        If Not String.IsNullOrWhiteSpace(RtbNote.SelectedText) Then
            TxtName.Text = RtbNote.SelectedText
        End If
    End Sub

    Private Sub BtnPasteDob_Click(sender As Object, e As EventArgs) Handles BtnPasteDob.Click
        If Not String.IsNullOrWhiteSpace(RtbNote.SelectedText) Then
            If IsDate(RtbNote.SelectedText) Then
                DtpDob.Value = CDate(RtbNote.SelectedText)
            End If
        End If
    End Sub

    Private Sub BtnAddPerson_Click(sender As Object, e As EventArgs) Handles BtnAddPerson.Click
        Hide()
        Using _database As New FrmUpdateDatabase
            LogUtil.Info("Opening update form", MyBase.Name)
            _database.NewPersonName = TxtName.Text
            _database.NewPersonDob = If(DtpDob.Value > DtpDob.MinDate, DtpDob.Value, Date.MinValue)
            _database.NewPersonWiki = TxtWiki.Text
            _database.ShowDialog()
        End Using
        Show()
    End Sub

#End Region
End Class
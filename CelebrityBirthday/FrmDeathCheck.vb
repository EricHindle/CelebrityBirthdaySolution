' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
Imports System.IO
Imports System.Reflection

Public Class FrmDeathCheck
#Region "properties"
    Private isAutorun As Boolean
    Private isLeaveOpen As Boolean
    Public Property LeaveOpen() As Boolean
        Get
            Return isLeaveOpen
        End Get
        Set(ByVal value As Boolean)
            isLeaveOpen = value
        End Set
    End Property
    Public Property Autorun() As Boolean
        Get
            Return isAutorun
        End Get
        Set(ByVal value As Boolean)
            isAutorun = value
        End Set
    End Property
#End Region
#Region "variables"
    Private personTable As List(Of Person)
    Private toAddr As String
    Private fromAddr As String
    Private fromName As String
    Private Const EMAIL_TO_ADDRESS As String = "SendErrorTo"
    Private Const EMAIL_FROM_ADDRESS As String = "SendEmailFrom"
    Private Const EMAIL_FROM_NAME As String = "SendEmailName"
#End Region
#Region "form event handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        RunDeathCheck
    End Sub
    Private Sub DgvWarnings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWarnings.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < dgvWarnings.Rows.Count Then
            Dim tRow As DataGridViewRow = dgvWarnings.Rows(e.RowIndex)
            Dim _index As Integer = tRow.Cells(xId.Name).Value
            DisplayMessage("Showing update form for " & tRow.Cells(xName.Name).Value, True)
            Using _update As New FrmUpdateDatabase
                _update.PersonId = _index
                _update.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        WriteFile()
    End Sub
    Private Sub FrmDeathCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
    Private Sub FrmDeathCheck_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If isAutorun Then
            Refresh()
            LogUtil.Info("Auto run", MyBase.Name)
            RunDeathCheck()
            Dim outputFile As String = WriteFile()
            If dgvWarnings.Rows.Count > 0 Then
                Try
                    Dim deathList As String = My.Computer.FileSystem.ReadAllText(outputFile)
                    Dim message As String = "Deaths found:" & vbCrLf & deathList
                    SendEmail("Deaths found", message)
                Catch ex As IOException
                    LogUtil.Exception("Error retrieving file contents", ex, MyBase.Name)
                End Try
            End If
            isAutorun = False
            If Not isLeaveOpen Then
                Close()
            End If
        End If
    End Sub
    Private Sub FrmDeathCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
    End Sub
    Private Sub BtnDeathList_Click(sender As Object, e As EventArgs) Handles BtnDeathList.Click
        LogUtil.Info("List of deaths", MyBase.Name)
        Hide()
        Using _list As New FrmDeathList
            _list.Year = Today.Year
            _list.ShowDialog()
        End Using
        Show()
    End Sub
#End Region
#Region "subroutines"
    Private Sub RunDeathCheck()
        DisplayMessage("Finding the living", True)
        personTable = FindLivingPeople(False)
        DisplayMessage("Found " & personTable.Count & " people", True)
        Dim countText As String = "{0} of " & personTable.Count
        Dim iCt As Integer = 0
        For Each _person In personTable
            iCt += 1
            lblCount.Text = String.Format(myStringFormatProvider, countText, iCt)
            DisplayMessage(_person.Id & " " & _person.Name)
            Try
                Dim searchString As String = ""
                If _person.Social IsNot Nothing Then
                    searchString = _person.Social.WikiId
                End If
                If String.IsNullOrEmpty(searchString) Then
                    searchString = _person.Name
                End If
                Dim _wikiExtract As String = GetWikiExtract(searchString, 3)
                Dim datesFound As CbDates = Nothing
                Dim cbdates As List(Of CbDates) = ExtractCbdatesFromWikiExtract(_wikiExtract)
                If cbdates.Count = 1 Then
                    datesFound = cbdates(0)
                Else
                    For Each _cbdates As CbDates In cbdates
                        Dim _dob As Date = _cbdates.BirthDate.DateValue
                        If _person.DateOfBirth = _dob Then
                            datesFound = _cbdates
                            Exit For
                        End If
                    Next
                End If
                If datesFound IsNot Nothing Then
                    If datesFound.DeathDate.IsValidDate Then
                        Dim _dateOfDeath As String = datesFound.DeathDate.FormattedDateString
                        LogUtil.Info(_person.Name & " died " & _dateOfDeath)
                        AddXRow(_person, _dateOfDeath, _wikiExtract)
                    End If
                End If

            Catch ex As DbException
                If DisplayException(MethodBase.GetCurrentMethod(), ex, "dB", True) = MsgBoxResult.No Then Exit Sub
            End Try
        Next
    End Sub
    Private Function WriteFile() As String
        Dim _filename As String = Path.Combine(My.Settings.TwitterFilePath, "deadpeople.csv")
        DisplayMessage("Writing " & _filename, True)
        Try
            Using _outfile As New StreamWriter(_filename, False)
                WriteTableToFile(_outfile)
            End Using
        Catch ex As IOException
            LogUtil.Exception("Error opening file", ex, MyBase.Name)
        End Try
        Return _filename
    End Function

    Private Sub WriteTableToFile(_outfile As StreamWriter)
        Try
            For Each _row As DataGridViewRow In dgvWarnings.Rows
                _outfile.WriteLine(_row.Cells(xId.Name).Value & "," & _row.Cells(xName.Name).Value & "," & _row.Cells(xBirth.Name).Value & "," & _row.Cells(xDeath.Name).Value)
            Next
        Catch ex As IOException
            LogUtil.Exception("Error writing file", ex, MyBase.Name)
        End Try
    End Sub

    Private Shared Function GetWikiDeathDate(_parts As List(Of String)) As String
        Dim _deathDate As Date? = Nothing
        Dim _return As String = Nothing
        Dim _displayDesc As String = _parts(0).Substring(0, Math.Min(_parts(0).Length, 180))
        Select Case _parts.Count
            Case 3
                Dim datePart As String = _parts(1)
                Dim _dates As String() = Split(datePart, " - ")
                If _dates.Length >= 2 Then
                    Try
                        If IsDate(_dates(1)) Then
                            _return = _dates(1)
                        Else
                            _return = _displayDesc & " ** Not a date " & _parts(1)
                        End If
                    Catch ex As OverflowException
                        _return = _displayDesc & " ** Exception " & _parts(1)
                    End Try
                Else
                    Try
                        Dim _semisplit As String() = Split(_dates(0), ";")
                        Dim _insplit As String() = Split(_semisplit(_semisplit.Length - 1), "in")
                        Dim _trimmedDate As String = _insplit(0).Replace("born", "").Trim

                        Dim _date1 As String = _trimmedDate
                        If Not IsDate(_date1) Then
                            _return = _displayDesc & " ** Not a date " & _date1
                        End If
                    Catch ex As OverflowException
                        _return = _displayDesc & " ** Exception " & _parts(0)
                    End Try
                End If
            Case 2
                _return = _displayDesc & " " & My.Resources.NO_CLOSE_BRACKET
        End Select
        Return _return
    End Function
    Private Sub DisplayMessage(oText As String, Optional isLogged As Boolean = False)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
        If isLogged Then
            LogUtil.Info(oText, MyBase.Name)
        End If
    End Sub
    Private Function AddXRow(oPerson As Person, oDateOfDeath As String, oDesc As String) As DataGridViewRow
        Dim _newRow As DataGridViewRow = dgvWarnings.Rows(dgvWarnings.Rows.Add())
        _newRow.Height = 65
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xDeath.Name).Value = oDateOfDeath
        _newRow.Cells(xDesc.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        Dim imageCell As DataGridViewImageCell = _newRow.Cells(xImg.Name)
        Dim oImageIdentity = GetImageById(oPerson.Id, True)
        If oImageIdentity IsNot Nothing Then
            imageCell.Value = oImageIdentity.Photo.Clone
            oImageIdentity.Dispose()
        End If
        dgvWarnings.Refresh()
        Return _newRow
    End Function
    Private Sub GetEmailSettings()
        toAddr = GlobalSettings.GetSetting(EMAIL_TO_ADDRESS)
        fromAddr = GlobalSettings.GetSetting(EMAIL_FROM_ADDRESS)
        fromName = GlobalSettings.GetSetting(EMAIL_FROM_NAME)
    End Sub

    Private Sub SendEmail(strSubject As String, strBody As String)
        GetEmailSettings()
        EmailUtil.SendMail(fromAddr, toAddr, Array.Empty(Of String), strSubject, strBody, fromName)
    End Sub
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, lblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, lblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
#End Region
End Class
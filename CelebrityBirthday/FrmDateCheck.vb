Imports System.Data.Common
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Structure WikiBirthInfo
    Private _birthDate As Date?
    Private _errordesc As String
    Sub New(pBirthDate As Date?, pErrorDesc As String)
        _birthDate = pBirthDate
        _errordesc = pErrorDesc
    End Sub
    Public Property ErrorDesc() As String
        Get
            Return _errordesc
        End Get
        Set(ByVal value As String)
            _errordesc = value
        End Set
    End Property
    Public Property BirthDate() As Date?
        Get
            Return _birthDate
        End Get
        Set(ByVal value As Date?)
            _birthDate = value
        End Set
    End Property
End Structure
Public Class FrmDateCheck
#Region "variables"
    Private personTable As List(Of Person)
    Private isLoadingTable As Boolean
    Private isWikiIdChanged As Boolean = False
#End Region
#Region "form event handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        DisplayMessage("Finding everybody")
        ClearPersonDetails()
        isLoadingTable = True
        DgvWarnings.Rows.Clear()
        Me.Refresh()
        Try
            If cboDay.SelectedIndex < 0 Or cboMonth.SelectedIndex < 0 Then
                personTable = FindEverybody()
            Else
                personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, False)
            End If
        Catch ex As DbException
            If MsgBox("Exception during list load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try
        Dim totalPeople As Integer = personTable.Count
        Dim _ct As Integer = 0
        Dim _addedct As Integer = 0
        DisplayMessage("Found " & CStr(totalPeople) & " people")
        For Each _person In personTable
            _ct += 1
            DisplayMessage(CStr(_ct) & " of " & CStr(totalPeople))
            Try
                Dim extract As String = ""
                Dim wikiId As String = ""
                If _person.Social IsNot Nothing Then
                    wikiId = _person.Social.WikiId
                End If
                Dim _wikiBirthInfo As WikiBirthInfo = GetWikiBirthDate(extract, _person.ForeName, _person.Surname, wikiId)
                Dim _dateOfBirth As Date? = _wikiBirthInfo.BirthDate
                Dim _desc As String = extract
                If Not String.IsNullOrEmpty(_wikiBirthInfo.ErrorDesc) Then
                    _desc = _wikiBirthInfo.ErrorDesc
                End If
                If _dateOfBirth IsNot Nothing Then
                    If _dateOfBirth.Value <> _person.DateOfBirth Then
                        AddXRow(_person, Format(_dateOfBirth.Value, "dd MMM yyyy"), _desc, wikiId)
                        _addedct += 1
                        If nudSelectCount.Value > 0 AndAlso _addedct = nudSelectCount.Value Then
                            Exit For
                        End If
                    End If
                    'Else
                    '    AddXRow(_person, "", "Can't find wiki Date of birth")
                End If
            Catch ex As ArgumentException
                If MsgBox(_person.Name & vbCrLf & "Exception during table load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End Try
        Next
        DgvWarnings.ClearSelection()
        DisplayMessage("Selection complete")
        isLoadingTable = False
    End Sub
    Private Sub DgvWarnings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvWarnings.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < DgvWarnings.Rows.Count Then
            Dim tRow As DataGridViewRow = DgvWarnings.Rows(e.RowIndex)
            Dim _index As Integer = tRow.Cells(xId.Name).Value
            Using _update As New FrmUpdateDatabase
                _update.PersonId = _index
                _update.ShowDialog()
            End Using
        End If

    End Sub
    Private Sub DgvWarnings_SelectionChanged(sender As Object, e As EventArgs) Handles DgvWarnings.SelectionChanged
        If Not isLoadingTable Then
            ClearPersonDetails()
            If DgvWarnings.SelectedRows.Count = 1 Then
                Dim oRow As DataGridViewRow = DgvWarnings.SelectedRows(0)
                LblId.Text = oRow.Cells(xId.Name).Value
                TxtFullName.Text = oRow.Cells(xName.Name).Value
                TxtFullDesc.Text = oRow.Cells(xPersonDescription.Name).Value
                TxtWiki.Text = oRow.Cells(xWikiExtract.Name).Value
                Dim FromDt As Date = CDate(oRow.Cells(xBirth.Name).Value)
                Dim ToDt As Date = CDate(oRow.Cells(xWikiBirth.Name).Value)
                TxtToDay.Text = Format(ToDt, "dd")
                TxtToMonth.Text = Format(ToDt, "MM")
                TxtToYear.Text = Format(ToDt, "yyyy")
                TxtFromDay.Text = Format(FromDt, "dd")
                TxtFromMonth.Text = Format(FromDt, "MM")
                TxtFromYear.Text = Format(FromDt, "yyyy")
                TxtWikiId.Text = oRow.Cells(xWikiId.Name).Value
                isWikiIdChanged = False
            End If
        End If
    End Sub
    Private Sub BtnSingleUpdate_Click(sender As Object, e As EventArgs) Handles BtnSingleUpdate.Click
        Dim pPersonId As Integer = CInt(LblId.Text)
        If pPersonId > 0 Then
            If Not String.IsNullOrEmpty(TxtToYear.Text) And
                Not String.IsNullOrEmpty(TxtToMonth.Text) And
                Not String.IsNullOrEmpty(TxtToDay.Text) And
                IsDate(TxtToDay.Text & "/" & TxtToMonth.Text & "/" & TxtToYear.Text) Then
                Dim pYear As Integer = CInt(TxtToYear.Text)
                Dim pMonth As Integer = CInt(TxtToMonth.Text)
                Dim pDay As Integer = CInt(TxtToDay.Text)
                UpdateDateOfBirth(pPersonId, pDay, pMonth, pYear, TxtFullDesc.Text)
                DisplayMessage("Updated " & CStr(pPersonId))
            End If
        End If
    End Sub
    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnFromWordPress.Click
        OpenWordPress(CInt(TxtFromDay.Text), CInt(TxtFromMonth.Text))
    End Sub
    Private Sub BtnToWordPress_Click(sender As Object, e As EventArgs) Handles BtnToWordPress.Click
        OpenWordPress(CInt(TxtToDay.Text), CInt(TxtToMonth.Text))
    End Sub
    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        cboDay.SelectedIndex = Today.Day - 1
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub
    Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
        cboDay.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
    End Sub
    Private Sub BtnCopyText_Click(sender As Object, e As EventArgs) Handles BtnCopyDate.Click
        Dim personStringList As List(Of String) = ParseStringWithBrackets(TxtFullDesc.Text)
        If TxtWiki.SelectionLength > 0 Then
            TxtFullDesc.Text = personStringList(0) & "(" & TxtWiki.SelectedText & ")" & personStringList(2)
        Else
            Dim wikiStringList As List(Of String) = ParseStringWithBrackets(TxtWiki.Text)
            If personStringList.Count = 3 And wikiStringList.Count = 3 Then
                TxtFullDesc.Text = personStringList(0) & "(" & wikiStringList(1) & ")" & personStringList(2)
            End If
        End If
    End Sub
    Private Sub BtnClearDetails_Click(sender As Object, e As EventArgs) Handles BtnClearDetails.Click
        ClearPersonDetails()
    End Sub
    Private Sub TxtWikiId_TextChanged(sender As Object, e As EventArgs) Handles TxtWikiId.TextChanged
        isWikiIdChanged = True
    End Sub
    Private Sub BtnWikiUpdate_Click(sender As Object, e As EventArgs) Handles BtnWikiUpdate.Click
        If isWikiIdChanged Then
            UpdateWikiId(CInt(LblId.Text), TxtWikiId.Text)
            DisplayMessage(LblId.Text & "Wiki Id Updated to " & TxtWikiId.Text)
        End If
    End Sub
    Private Sub Date_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        ClearPersonDetails()
        DisplayMessage("")
    End Sub
#End Region
#Region "subroutines"
    Private Shared Function GetWikiBirthDate(ByRef extract As String, _forename As String, _surname As String, Optional wikiId As String = "") As WikiBirthInfo
        Dim _wikiBirthInfo As New WikiBirthInfo(Nothing, "")
        Dim _birthDate As Date? = Nothing
        Try
            extract = GetWikiText(3, _forename, _surname, wikiId)
            If extract.Contains("may refer to:") = False Then
                Dim _desc As String = RemoveSquareBrackets(FixQuotes(extract))
                Dim _parts As List(Of String) = ParseStringWithBrackets(_desc)
                If _parts.Count = 3 Then
                    Dim datePart As String = _parts(1)
                    Dim _dates As String() = Split(datePart, "-")
                    If _dates.Length > 0 Then
                        Try
                            Dim firstPart As String = _dates(0).Trim
                            firstPart = firstPart.Replace("N.", "").Replace("S.", "").Replace("(", "").Replace(")", "").Replace("O.", "").Replace(";", "").Replace("  ", " ")
                            Dim DateParts As String() = Split(firstPart, " ")
                            Dim DatePartsList As List(Of String) = DateParts.ToList

                            For bitNo As Integer = DatePartsList.Count - 1 To 0 Step -1
                                If IsNumeric(DatePartsList(bitNo)) Then Exit For
                                DatePartsList.RemoveAt(bitNo)
                            Next
                            If DatePartsList.Count = 0 Then
                                _wikiBirthInfo.ErrorDesc = "No date present"
                            Else
                                Dim firstDate As String = If(DatePartsList.Count > 2, DateParts(DatePartsList.Count - 3), 1) & " " & If(DatePartsList.Count > 1, DatePartsList(DatePartsList.Count - 2), "January") & " " & If(DatePartsList.Count > 0, DatePartsList(DatePartsList.Count - 1), "1900")
                                If IsDate(firstDate) Then
                                    _birthDate = CDate(firstDate)
                                Else
                                    _wikiBirthInfo.ErrorDesc = "Not a date: " & firstDate
                                End If
                            End If
                        Catch ex As OverflowException
                            _wikiBirthInfo.ErrorDesc = "Not a date: " & _dates(0)
                        End Try
                    End If
                End If
            Else
                _wikiBirthInfo.ErrorDesc = "may refer to"
            End If

        Catch ex As ArgumentException
            _wikiBirthInfo.ErrorDesc = ex.Message
        Catch ex As System.Security.SecurityException
            _wikiBirthInfo.ErrorDesc = ex.Message
        End Try
        _wikiBirthInfo.BirthDate = _birthDate
        Return _wikiBirthInfo
    End Function
    Private Sub DisplayMessage(oText As String)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
    End Sub
    Private Function AddXRow(oPerson As Person, oDateOfBirth As String, oDesc As String, oWikiId As String) As DataGridViewRow
        Dim _newRow As DataGridViewRow = DgvWarnings.Rows(DgvWarnings.Rows.Add())
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xWikiBirth.Name).Value = oDateOfBirth
        _newRow.Cells(xWikiExtract.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        _newRow.Cells(xPersonDescription.Name).Value = oPerson.Description
        _newRow.Cells(xWikiId.Name).Value = If(String.IsNullOrEmpty(oWikiId), "", oWikiId)
        DgvWarnings.Refresh()
        Return _newRow
    End Function
    Private Sub ClearPersonDetails()
        TxtFullName.Text = ""
        TxtFullDesc.Text = ""
        LblId.Text = -1
        TxtWiki.Text = ""
        TxtToDay.Text = ""
        TxtToMonth.Text = ""
        TxtToYear.Text = ""
        TxtFromDay.Text = ""
        TxtFromMonth.Text = ""
        TxtFromYear.Text = ""
        TxtWikiId.Text = ""
        isWikiIdChanged = False
    End Sub
    Private Sub OpenWordPress(pDay As Integer, pMonth As Integer)
        DisplayMessage("WordPress")
        Using _wordpress As New FrmWordPress
            _wordpress.DaySelection = pDay
            _wordpress.MonthSelection = pMonth
            _wordpress.ShowDialog()
        End Using
        DisplayMessage("")
    End Sub
#End Region
End Class
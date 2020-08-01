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
    Private personTable As List(Of Person)
    Private isLoadingTable As Boolean
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        DisplayMessage("Finding everybody")
        isLoadingTable = True
        dgvWarnings.Rows.Clear()
        Try
            personTable = FindEverybody()
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
                Dim searchString As String = ""
                If _person.Social IsNot Nothing Then
                    searchString = _person.Social.WikiId
                End If
                If String.IsNullOrEmpty(searchString) Then
                    searchString = _person.Name
                End If
                Dim _wikiBirthInfo As WikiBirthInfo = GetWikiBirthDate(searchString, extract)
                Dim _dateOfBirth As Date? = _wikiBirthInfo.BirthDate
                Dim _desc As String = extract
                If Not String.IsNullOrEmpty(_wikiBirthInfo.ErrorDesc) Then
                    _desc = _wikiBirthInfo.ErrorDesc
                End If
                If _dateOfBirth IsNot Nothing Then
                    If _dateOfBirth.Value <> _person.DateOfBirth Then
                        AddXRow(_person, Format(_dateOfBirth.Value, "dd MMM yyyy"), _desc, searchString)
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
        dgvWarnings.ClearSelection()
        DisplayMessage("Selection complete")
        isLoadingTable = False
    End Sub

    Private Shared Function GetWikiBirthDate(_searchName As String, ByRef extract As String) As WikiBirthInfo
        Dim _wikiBirthInfo As New WikiBirthInfo(Nothing, "")
        Dim _birthDate As Date? = Nothing
        Try
            Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, 2))
            extract = GetExtractFromResponse(_response)
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
        Dim _newRow As DataGridViewRow = dgvWarnings.Rows(dgvWarnings.Rows.Add())
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xWikiBirth.Name).Value = oDateOfBirth
        _newRow.Cells(xDesc.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        _newRow.Cells(xWikiId.Name).Value = If(String.IsNullOrEmpty(oWikiId), "", oWikiId)
        dgvWarnings.Refresh()
        Return _newRow
    End Function

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        Dim _filename As String = Path.Combine(My.Settings.TwitterFilePath, "wrongdates.csv")
        Using _outfile As New StreamWriter(_filename, True)
            For Each _row As DataGridViewRow In dgvWarnings.Rows
                _outfile.WriteLine(_row.Cells(xId.Name).Value & "," & _row.Cells(xName.Name).Value & "," & _row.Cells(xBirth.Name).Value & "," & _row.Cells(xWikiBirth.Name).Value)
            Next
        End Using
    End Sub

    Private Sub DgvWarnings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvWarnings.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < dgvWarnings.Rows.Count Then
            Dim tRow As DataGridViewRow = dgvWarnings.Rows(e.RowIndex)
            Dim _index As Integer = tRow.Cells(xId.Name).Value
            Using _update As New FrmUpdateDatabase
                _update.PersonId = _index
                _update.ShowDialog()
            End Using
        End If

    End Sub

    Private Sub dgvWarnings_SelectionChanged(sender As Object, e As EventArgs) Handles dgvWarnings.SelectionChanged
        If Not isLoadingTable Then
            ClearPersonDetails()
            If dgvWarnings.SelectedRows.Count = 1 Then
                Dim oRow As DataGridViewRow = dgvWarnings.SelectedRows(0)
                LblId.Text = oRow.Cells(xId.Name).Value
                TxtFullName.Text = oRow.Cells(xName.Name).Value
                TxtDob.Text = oRow.Cells(xBirth.Name).Value
                TxtShortDesc.Text = oRow.Cells(xDesc.Name).Value
                If oRow.Cells(xWikiId.Name).Value IsNot Nothing Then
                    TxtWiki.Text = GetWikiText(2, "", "", oRow.Cells(xWikiId.Name).Value)
                End If
                Dim dt As Date = CDate(oRow.Cells(xWikiBirth.Name).Value)
                TxtDay.Text = Format(dt, "dd")
                TxtMonth.Text = Format(dt, "MM")
                TxtYear.Text = Format(dt, "yyyy")
            End If
        End If
    End Sub
    Private Sub ClearPersonDetails()
        TxtFullName.Text = ""
        TxtDob.Text = ""
        TxtShortDesc.Text = ""
        LblId.Text = -1
        TxtWiki.Text = ""
        TxtDay.Text = ""
        TxtMonth.Text = ""
        TxtYear.Text = ""
    End Sub

    Private Sub BtnSingleUpdate_Click(sender As Object, e As EventArgs) Handles BtnSingleUpdate.Click
        Dim pPersonId As Integer = CInt(LblId.Text)
        If pPersonId > 0 Then
            If Not String.IsNullOrEmpty(TxtYear.Text) And
                Not String.IsNullOrEmpty(TxtMonth.Text) And
                Not String.IsNullOrEmpty(TxtDay.Text) And
                IsDate(TxtDay.Text & "/" & TxtMonth.Text & "/" & TxtYear.Text) Then
                Dim pYear As Integer = CInt(TxtYear.Text)
                Dim pMonth As Integer = CInt(TxtMonth.Text)
                Dim pDay As Integer = CInt(TxtDay.Text)
                UpdateDateOfBirth(pPersonId, pDay, pMonth, pYear)
                DisplayMessage("Updated " & CStr(pPersonId))
                ClearPersonDetails()
            End If
        End If
    End Sub
End Class
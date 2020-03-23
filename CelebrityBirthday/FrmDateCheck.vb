﻿Imports System.Data.Common
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Structure wikiBirthInfo
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

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        DisplayMessage("Finding everybody")
        Try
            personTable = FindEverybody()
        Catch ex As DbException
            If MsgBox("Exception during list load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try
        Dim totalPeople As Integer = personTable.Count
        Dim _ct As Integer = 0
        DisplayMessage("Found " & CStr(totalPeople) & " people")
        For Each _person In personTable
            _ct += 1
            DisplayMessage(CStr(_ct) & " of " & CStr(totalPeople))
            Try
                Dim _wikiBirthInfo As wikiBirthInfo = GetWikiBirthDate(_person.Name)
                Dim _dateOfBirth As Date? = _wikiBirthInfo.BirthDate
                Dim _desc As String = _wikiBirthInfo.ErrorDesc
                If _dateOfBirth IsNot Nothing Then
                    If _dateOfBirth.Value <> _person.DateOfBirth Then
                        AddXRow(_person, Format(_dateOfBirth.Value, "dd MMM yyyy"), _desc)
                    End If
                    'Else
                    '    AddXRow(_person, "", "Can't find wiki Date of birth")
                End If
            Catch ex As Exception
                If MsgBox(_person.Name & vbCrLf & "Exception during table load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End Try

        Next
    End Sub

    Private Function GetWikiBirthDate(_searchName As String) As wikiBirthInfo
        Dim _wikiBirthInfo As New wikiBirthInfo(Nothing, "")
        Dim _birthDate As Date? = Nothing
        Try
            Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, 2))
            Dim extract As String = GetExtractFromResponse(_response)
            If extract.Contains("may refer to:") = False Then
                Dim _desc As String = RemoveSquareBrackets(FixQuotes(extract))
                Dim _parts As List(Of String) = ParseStringWithBrackets(_desc)
                If _parts.Count = 3 Then
                    Dim datePart As String = _parts(1)
                    Dim _dates As String() = Split(datePart, " - ")
                    If _dates.Length > 0 Then
                        Try
                            Dim firstPart As String = _dates(0)
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

        Catch ex As Exception
            _wikiBirthInfo.ErrorDesc = ex.Message
        End Try
        _wikiBirthInfo.BirthDate = _birthDate
        Return _wikiBirthInfo
    End Function

    Private Sub DisplayMessage(oText As String)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
    End Sub

    Private Function AddXRow(oPerson As Person, oDateOfBirth As String, oDesc As String) As DataGridViewRow
        Dim _newRow As DataGridViewRow = dgvWarnings.Rows(dgvWarnings.Rows.Add())
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xWikiBirth.Name).Value = oDateOfBirth
        _newRow.Cells(xDesc.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
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
End Class
Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization
Public Class FrmDeathCheck
    Private personTable As List(Of Person)



    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmDeathCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        DisplayMessage("Finding the living")
        Try
            personTable = FindLivingPeople()
        Catch ex As Exception
            If MsgBox("Exception during list load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try

        DisplayMessage("Found " & CStr(personTable.Count) & " people")
        For Each _person In personTable
            DisplayMessage(CStr(_person.Id) & " " & _person.Name)
            Try
                AddAllRow(_person)
                Dim _dateOfDeath As String = GetWikiDeathDate(_person.Name)
                If _dateOfDeath IsNot Nothing Then
                    AddXRow(_person, _dateOfDeath, "")
                End If
            Catch ex As Exception
                If MsgBox("Exception during table load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End Try

        Next
    End Sub

    Private Function GetWikiDeathDate(_searchName As String) As String
        Dim _deathDate As Date? = Nothing
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, 2))
        Dim extract As String = GetExtractFromResponse(_response)
        Dim _desc As String = RemoveSquareBrackets(FixQuotes(extract))
        Dim _parts As List(Of String) = ParseStringWithBrackets(_desc)
        If _parts.Count = 3 Then
            Dim datePart As String = _parts(1)
            Dim _dates As String() = Split(datePart, " - ")
            If _dates.Count = 2 Then
                Try
                    If IsDate(_dates(1)) Then
                        _deathDate = CDate(_dates(1))
                    End If
                Catch ex As Exception
                    Debug.Print(_searchName & " Not a date " & _dates(1))
                End Try
            End If
        End If
        Return If(_deathDate Is Nothing, Nothing, Format(_deathDate, "dd MMM yyyy"))
    End Function

    Private Sub DisplayMessage(oText As String)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
    End Sub

    Private Function AddAllRow(oPerson As Person) As DataGridViewRow
        Dim _newRow As DataGridViewRow = dgvAllPersons.Rows(dgvAllPersons.Rows.Add())
        _newRow.Cells(allId.Name).Value = oPerson.Id
        _newRow.Cells(allName.Name).Value = oPerson.Name
        _newRow.Cells(allDob.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth.Value, "dd MMM yyyy"))
        dgvAllPersons.Refresh()
        Return _newRow
    End Function

    Private Function AddXRow(oPerson As Person, oDateOfDeath As String, oDesc As String) As DataGridViewRow
        Dim _newRow As DataGridViewRow = dgvWarnings.Rows(dgvWarnings.Rows.Add())
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xDeath.Name).Value = oDateOfDeath
        _newRow.Cells(xDesc.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        dgvWarnings.Refresh()
        Return _newRow
    End Function

    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        Dim _filename As String = Path.Combine(My.Settings.TwitterFilePath, "deadpeople.csv")
        Using _outfile As New StreamWriter(_filename, True)
            For Each _row As DataGridViewRow In dgvWarnings.Rows
                _outfile.WriteLine(_row.Cells(xId.Name).Value & "," & _row.Cells(xName.Name).Value & "," & _row.Cells(xBirth.Name).Value & "," & _row.Cells(xDeath.Name).Value)
            Next
        End Using
    End Sub
End Class
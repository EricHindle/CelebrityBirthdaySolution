Imports System.Data.Common
Imports System.IO
Imports System.Net
Imports System.Reflection

Public Class FrmDeathCheck
#Region "variables"
    Private personTable As List(Of Person)
#End Region
#Region "form event handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        DisplayMessage("Finding the living", True)
        personTable = FindLivingPeople(False)
        DisplayMessage("Found " & CStr(personTable.Count) & " people", True)
        Dim countText As String = "{0} of " & CStr(personTable.Count)
        Dim iCt As Integer = 0
        For Each _person In personTable
            iCt += 1
            lblCount.Text = String.Format(myStringFormatProvider, countText, iCt)
            DisplayMessage(CStr(_person.Id) & " " & _person.Name)
            Try
                Dim searchString As String = ""
                If _person.Social IsNot Nothing Then
                    searchString = _person.Social.WikiId
                End If
                If String.IsNullOrEmpty(searchString) Then
                    searchString = _person.Name
                End If
                Dim _dateOfDeath As String = GetWikiDeathDate(searchString)
                If _dateOfDeath IsNot Nothing Then
                    If IsDate(_dateOfDeath) Then
                        AddXRow(_person, _dateOfDeath, "")
                    Else
                        AddXRow(_person, "", _dateOfDeath)
                    End If
                End If
            Catch ex As DbException
                If DisplayException(MethodBase.GetCurrentMethod(), ex, "dB", True) = MsgBoxResult.No Then Exit Sub
            End Try
        Next
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
        Dim _filename As String = Path.Combine(My.Settings.TwitterFilePath, "deadpeople.csv")
        DisplayMessage("Writing " & _filename, True)
        Using _outfile As New StreamWriter(_filename, True)
            For Each _row As DataGridViewRow In dgvWarnings.Rows
                _outfile.WriteLine(_row.Cells(xId.Name).Value & "," & _row.Cells(xName.Name).Value & "," & _row.Cells(xBirth.Name).Value & "," & _row.Cells(xDeath.Name).Value)
            Next
        End Using
    End Sub
    Private Sub FrmDeathCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
    End Sub
    Private Sub BtnDeathList_Click(sender As Object, e As EventArgs) Handles BtnDeathList.Click
        LogUtil.Info("List of deaths", MyBase.Name)
        Me.Hide()
        Using _list As New FrmDeathList
            _list.Year = Today.Year
            _list.ShowDialog()
        End Using
        Me.Show()
    End Sub
#End Region
#Region "subroutines"
    Private Shared Function GetWikiDeathDate(_searchName As String) As String
        Dim _deathDate As Date? = Nothing
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, 2))
        Dim extract As String = If(_response IsNot Nothing, GetExtractFromResponse(_response), "")
        Dim _desc As String = RemoveSquareBrackets(FixQuotesAndHyphens(extract, True))
        Dim _parts As List(Of String) = ParseStringWithBrackets(_desc)
        Dim _return As String = Nothing
        Select Case _parts.Count
            Case 3
                Dim datePart As String = _parts(1)
                Dim _dates As String() = Split(datePart, " - ")
                If _dates.Length = 2 Then
                    Try
                        If IsDate(_dates(1)) Then
                            _deathDate = CDate(_dates(1))
                        End If
                    Catch ex As OverflowException
                        _return = _searchName & " Not a date " & _dates(1)
                    End Try
                End If
                _return = If(_deathDate Is Nothing, Nothing, Format(_deathDate, "dd MMM yyyy"))
            Case 2
                _return = _searchName & " " & My.Resources.NO_CLOSE_BRACKET
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

    Private Sub FrmDeathCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

#End Region
End Class
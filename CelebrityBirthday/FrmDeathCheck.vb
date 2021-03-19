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
                Dim _wikiExtract As String = GetWikiExtract(searchString)
                Dim _displayExtract As String = _wikiExtract.Substring(0, Math.Min(180, _wikiExtract.Length))
                Dim isDateFound As Boolean = False
                Dim isEndOfExtract As Boolean = String.IsNullOrEmpty(_wikiExtract)
                Dim _dates As New List(Of String)
                Do Until isDateFound Or isEndOfExtract
                    Dim _parts As List(Of String) = ParseStringWithBrackets(_wikiExtract)
                    If _parts.Count <> 3 Then
                        isEndOfExtract = True
                    Else
                        _dates = GetWikiDates(_parts(1))
                        If _dates.Count > 0 Then
                            isDateFound = True
                            If IsDate(_dates(0)) Then
                                Dim _dob As Date = CDate(_dates(0))
                                If _person.DateOfBirth <> _dob Then
                                    isDateFound = False
                                    _wikiExtract = _parts(2)
                                End If
                            End If
                        Else
                            _wikiExtract = _parts(2)
                        End If
                    End If
                Loop
                'If isDateFound Then
                '    For Each d As String In _dates
                '        If IsDate(d) Then
                '            LogUtil.Info(_person.Name & " >> " & d, "frmDeathCheck")
                '        Else
                '            LogUtil.Info(_person.Name & " ?? " & d, "frmDeathCheck")
                '        End If

                '    Next
                'Else
                '    LogUtil.Info(_person.Name & " ** No date found" & _displayExtract, "frmDeathCheck")
                'End If
                Dim _dateOfDeath As String = Nothing
                If _dates.Count > 1 Then
                    _dateOfDeath = _dates(1)
                End If
                If _dateOfDeath IsNot Nothing Then
                    If IsDate(_dateOfDeath) Then
                        AddXRow(_person, _dateOfDeath, _wikiExtract)
                    Else
                        AddXRow(_person, "", _dateOfDeath)      ' Error
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
    Private Shared Function GetWikiDates(_dateString As String) As List(Of String)
        Dim wikiDates As New List(Of String)
        Dim _semiSplit As String() = Split(_dateString, ";")
        Dim _possibleDates As String() = Nothing
        '       LogUtil.Info(_dateString)
        For Each _semi As String In _semiSplit
            '    LogUtil.Info("[" & _semi & "]")
            Dim _s1 As String() = Split(_semi, "born")
            Dim _s2 As String() = Split(_s1(Math.Min(_s1.Length - 1, 1)), " on ")
            Dim _s3 As String() = Split(_s2(Math.Min(_s2.Length - 1, 1)), " in ")
            Dim _s4 As String = _s3(0)
            _possibleDates = Split(_s4, " - ")
            If IsDate(_possibleDates(0)) Then
                Exit For
            End If
        Next
        If _possibleDates IsNot Nothing Then
            For Each _possibleDate As String In _possibleDates
                Dim foundDate As String = findDateInString(_possibleDate)
                If Not String.IsNullOrEmpty(foundDate) Then
                    wikiDates.Add(foundDate)
                End If
            Next
        End If
        Return wikiDates
    End Function
    Private Shared Function FindDateInString(_possibleDate As String) As String
        Dim _foundDate As String = Nothing
        Dim _words As String() = Split(_possibleDate.Replace(",", "").Replace("  ", " ").Trim, " ")
        If _words.Length >= 3 Then
            For w As Integer = 0 To _words.Length - 3
                Dim _testDate As String = _words(w) & " " & _words(w + 1) & " " & _words(w + 2)
                If IsDate(_testDate) Then
                    _foundDate = _testDate
                    Exit For
                End If
            Next
        End If
        Return _foundDate
    End Function
    Private Shared Function GetWikiExtract(_searchName As String) As String
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, 2))
        Dim extract As String = If(_response IsNot Nothing, GetExtractFromResponse(_response), "")
        Return RemoveSquareBrackets(FixQuotesAndHyphens(extract, True))
    End Function
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

    Private Sub FrmDeathCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

#End Region
End Class
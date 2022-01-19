' Hindleware
' Copyright (c) 2021-22, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public NotInheritable Class FrmDeathList
    Private _year As Integer
    Public Property Year() As Integer
        Get
            Return _year
        End Get
        Set(ByVal value As Integer)
            _year = value
        End Set
    End Property

    Private Sub FrmDeathList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info(My.Resources.LOADING_TABLE, MyBase.Name)
        nudYear.Value = _year
        nudYear.Maximum = _year
        FillGrid(_year)
    End Sub
    Private Sub FillGrid(_year As Integer)
        Dim oTable As CelebrityBirthdayDataSet.PersonDataTable = GetPeopleByDeathYear(_year)
        DgvPeople.Rows.Clear()
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oTable.Rows
            Dim tRow As DataGridViewRow = DgvPeople.Rows(DgvPeople.Rows.Add())
            If ChkShowImage.Checked Then
                tRow.Height = 65
            End If
            tRow.Cells(tId.Name).Value = oRow.id
            tRow.Cells(tForename.Name).Value = oRow.forename
            tRow.Cells(tSurname.Name).Value = oRow.surname
            Dim _deathdate As Date
            Dim _birthDate As Date
            Try
                _birthDate = New Date(oRow.birthyear, oRow.birthmonth, oRow.birthday)
                _deathdate = New Date(oRow.deathyear, If(oRow.IsdeathmonthNull, 0, oRow.deathmonth), If(oRow.IsdeathdayNull, 0, oRow.deathday))
            Catch ex As ArgumentOutOfRangeException
                ColourRow(tRow)
                LogUtil.Exception("Invalid date for " & oRow.forename & " " & oRow.surname, ex, MyBase.Name)
                _deathdate = Today
            End Try
            tRow.Cells(tDeathDay.Name).Value = If(oRow.IsdeathdayNull, 0, oRow.deathday)
            tRow.Cells(tDeathMonth.Name).Value = If(oRow.IsdeathmonthNull, 0, Format(_deathdate, "MMM"))
            tRow.Cells(tDeathYear.Name).Value = oRow.deathyear
            Dim ydiff As Integer = DateDiff(DateInterval.Year, _deathdate, Today)
            If (_deathdate > Today.AddYears(-ydiff)) Then ydiff -= 1
            Dim mdiff As Integer = DateDiff(DateInterval.Month, _deathdate, Today) - (ydiff * 12)
            tRow.Cells(tYearsDead.Name).Value = CStr(ydiff) & "y " & CStr(mdiff) & "m"
            Dim bdiff As Integer = DateDiff(DateInterval.Year, _birthDate, _deathdate)
            If (_birthDate > _deathdate.AddYears(-bdiff)) Then bdiff -= 1
            tRow.Cells(tAge.Name).Value = CStr(bdiff)
            tRow.Cells(tShortDesc.Name).Value = If(oRow.IsshortdescNull, "", oRow.shortdesc)
            tRow.Cells(tBirthDay.Name).Value = oRow.birthday
            tRow.Cells(tBirthMonth.Name).Value = Format(_birthDate, "MMM")
            tRow.Cells(tBirthYear.Name).Value = oRow.birthyear
            tRow.Cells(tBirthName.Name).Value = If(oRow.IsbirthnameNull, "", oRow.birthname)
            tRow.Cells(tBirthPlace.Name).Value = If(oRow.IsbirthplaceNull, "", oRow.birthplace)
            Dim imageCell As DataGridViewImageCell = tRow.Cells(tImg.Name)
            Dim oImageIdentity = GetImageById(oRow.id, True)
            If oImageIdentity IsNot Nothing Then
                imageCell.Value = oImageIdentity.Photo.Clone
                oImageIdentity.Dispose()
            End If
        Next
    End Sub

    Private Shared Sub ColourRow(oRow As DataGridViewRow)
        For Each oCell As DataGridViewCell In oRow.Cells
            oCell.Style.BackColor = Color.LightSteelBlue
        Next
    End Sub

    Private Sub ShowStatus(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        LblStatus.Text = If(isAppend, LblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmDeathList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("...Closing", MyBase.Name)
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        FillGrid(nudYear.Value)
    End Sub

    Private Sub DgvPeople_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPeople.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < DgvPeople.Rows.Count Then
            Dim tRow As DataGridViewRow = DgvPeople.Rows(e.RowIndex)
            Dim _index As Integer = tRow.Cells(tId.Name).Value
            Using _update As New FrmUpdateDatabase
                _update.PersonId = _index
                _update.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ChkShowImage_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowImage.CheckedChanged
        DgvPeople.Columns().Item(tImg.Name).Visible = ChkShowImage.Checked
        For Each tRow As DataGridViewRow In DgvPeople.Rows
            tRow.Height = If(ChkShowImage.Checked, 65, DgvPeople.RowTemplate.Height)
        Next
    End Sub

    Private Sub BtnBBTweet_Click(sender As Object, e As EventArgs) Handles BtnBBTweet.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Dim oPerson As Person = GetPersonById(oRow.Cells(tId.Name).Value)
            Using _sendTwitter As New FrmSendBBTweet
                _sendTwitter.DeadPerson = oPerson
                _sendTwitter.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, LblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, LblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
End Class
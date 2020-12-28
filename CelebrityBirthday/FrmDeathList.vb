﻿Public Class FrmDeathList
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
        dgvPeople.Rows.Clear()
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oTable.Rows
            Dim tRow As DataGridViewRow = dgvPeople.Rows(dgvPeople.Rows.Add())
            tRow.Cells(tForename.Name).Value = oRow.forename
            tRow.Cells(tSurname.Name).Value = oRow.surname
            Dim _deathdate As Date
            Dim _birthDate As Date
            Try
                _birthDate = New Date(oRow.birthyear, oRow.birthmonth, oRow.birthday)
                _deathdate = New Date(oRow.deathyear, If(oRow.IsdeathmonthNull, 0, oRow.deathmonth), If(oRow.IsdeathdayNull, 0, oRow.deathday))
            Catch ex As ArgumentOutOfRangeException
                LogUtil.Exception("Invalid date for " & oRow.forename & " " & oRow.surname, ex, MyBase.Name)
                _deathdate = Today
            End Try
            tRow.Cells(tDeathDay.Name).Value = If(oRow.IsdeathdayNull, 0, oRow.deathday)
            tRow.Cells(tDeathMonth.Name).Value = If(oRow.IsdeathmonthNull, 0, Format(_deathDate, "MMM"))
            tRow.Cells(tDeathYear.Name).Value = oRow.deathyear
            Dim ydiff As Integer = DateDiff(DateInterval.Year, _deathDate, Today)
            If (_deathDate > Today.AddYears(-ydiff)) Then ydiff -= 1
            Dim mdiff As Integer = DateDiff(DateInterval.Month, _deathDate, Today) - (ydiff * 12)
            tRow.Cells(tYearsDead.Name).Value = CStr(ydiff) & "y " & CStr(mdiff) & "m"
            Dim bdiff As Integer = DateDiff(DateInterval.Year, _birthDate, _deathdate)
            If (_birthDate > _deathDate.AddYears(-bdiff)) Then bdiff -= 1
            tRow.Cells(tAge.Name).Value = CStr(bdiff)
            tRow.Cells(tShortDesc.Name).Value = If(oRow.IsshortdescNull, "", oRow.shortdesc)
            tRow.Cells(tBirthDay.Name).Value = oRow.birthday
            tRow.Cells(tBirthMonth.Name).Value = Format(_birthDate, "MMM")
            tRow.Cells(tBirthYear.Name).Value = oRow.birthyear
            tRow.Cells(tBirthName.Name).Value = If(oRow.IsbirthnameNull, "", oRow.birthname)
            tRow.Cells(tBirthPlace.Name).Value = If(oRow.IsbirthplaceNull, "", oRow.birthplace)
        Next
    End Sub
    Private Sub ShowStatus(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        lblStatus.Text = If(isAppend, lblStatus.Text, "") & pText
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
End Class
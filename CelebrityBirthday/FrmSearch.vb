' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class FrmSearch
#Region "variables"
    Private bLoadingPeople As Boolean
#End Region
#Region "form control handlers"
    Private Sub DgvPeople_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPeople.SelectionChanged
        If Not bLoadingPeople Then
            If DgvPeople.SelectedRows.Count = 1 Then
                Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
                txtId.Text = oRow.Cells(SelPersonId.Name).Value
                TxtForename.Text = oRow.Cells(SelPersonForename.Name).Value
                TxtSurname.Text = oRow.Cells(SelPersonSurname.Name).Value
            End If
        End If
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        CloseForm()
    End Sub
    Private Sub BtnSearchByName_Click(sender As Object, e As EventArgs) Handles BtnSearchByName.Click
        If Not String.IsNullOrEmpty(TxtForename.Text) Or Not String.IsNullOrEmpty(TxtSurname.Text) Then
            ShowStatus("Searching for " & TxtForename.Text & " " & TxtSurname.Text, True)
            bLoadingPeople = True
            DgvPeople.Rows.Clear()
            Dim selectedPersons As List(Of Person) = FindPeopleLikeName(TxtForename.Text, TxtSurname.Text)
            For Each oPerson As Person In selectedPersons
                AddTableRow(oPerson)
            Next
            DgvPeople.ClearSelection()
            bLoadingPeople = False
            ShowStatus("Search complete - found " & selectedPersons.Count & " records", True)
        Else
            ShowStatus("No name supplied")
        End If
    End Sub

    Private Sub SplitNameText()
        TxtForename.Text = Trim(TxtForename.Text)
        TxtSurname.Text = Trim(TxtSurname.Text)
        Dim fullName As String() = Split(Trim(TxtForename.Text & " " & TxtSurname.Text))
        If fullName.Length > 1 Then
            TxtSurname.Text = fullName.Last
            fullName(fullName.Length - 1) = ""
            TxtForename.Text = Join(fullName).Trim
        End If
    End Sub

    Private Sub BtnSearchById_Click(sender As Object, e As EventArgs) Handles BtnSearchById.Click
        If Not String.IsNullOrEmpty(txtId.Text) Then
            ShowStatus("Searching for " & txtId.Text, True)
            LoadScreenFromId(txtId.Text)
            ShowStatus("Search complete")
        Else
            ShowStatus("No id supplied")
        End If
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnDbUpdate.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Opening update form", True)
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            OpenUpdateForm(oRow)
        End If
        ShowStatus("")
    End Sub

    Private Sub OpenUpdateForm(oRow As DataGridViewRow)
        Using _update As New FrmUpdateDatabase
            _update.PersonId = oRow.Cells(SelPersonId.Name).Value
            _update.ShowDialog()
        End Using
    End Sub

    Private Sub BtnFindInWiki_Click(sender As Object, e As EventArgs) Handles BtnFindInWiki.Click
        If Not String.IsNullOrEmpty(TxtForename.Text) Or Not String.IsNullOrEmpty(TxtSurname.Text) Then
            ShowStatus("Opening Wikipedia", True)
            Dim wikiUrl As String = GetWikiSearchString(TxtForename.Text & " " & TxtSurname.Text)
            Process.Start(wikiUrl)
        Else
            ShowStatus("No name supplied")
        End If
    End Sub
    Private Sub FrmSearch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.srchformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        DgvPeople.Rows.Clear()
        txtId.Text = ""
        TxtForename.Text = ""
        TxtSurname.Text = ""
        LblStatus.Text = ""
    End Sub
#End Region
#Region "subroutines"
    Private Sub CloseForm()
        Close()
    End Sub
    Private Sub LoadScreenFromId(ByVal oId As Integer)
        Dim oPerson As Person
        oPerson = GetFullPersonById(oId)
        If oPerson IsNot Nothing Then
            DgvPeople.Rows.Clear()
            LoadScreenFromPerson(oPerson)
        Else
            ShowStatus("Id not found")
        End If
        oPerson.Dispose()
        Return
    End Sub
    Private Sub LoadScreenFromPerson(oPerson As Person)
        AddTableRow(oPerson)
        txtId.Text = oPerson.Id
        TxtForename.Text = oPerson.ForeName
        TxtSurname.Text = oPerson.Surname
    End Sub
    Private Sub AddTableRow(oPerson As Person)
        Dim tRow As DataGridViewRow = DgvPeople.Rows(DgvPeople.Rows.Add)
        tRow.Height = If(ChkShowImage.Checked, 65, DgvPeople.RowTemplate.Height)
        tRow.Cells(SelPersonId.Name).Value = oPerson.Id
        tRow.Cells(SelPersonForename.Name).Value = oPerson.ForeName
        tRow.Cells(SelPersonSurname.Name).Value = oPerson.Surname
        tRow.Cells(selPersonDay.Name).Value = oPerson.BirthDay
        tRow.Cells(selPersonMonth.Name).Value = oPerson.BirthMonth
        tRow.Cells(SelPersonYear.Name).Value = oPerson.BirthYear
        tRow.Cells(selDesc.Name).Value = oPerson.ShortDesc
        Dim imageCell As DataGridViewImageCell = tRow.Cells(xImg.Name)
        Dim oImageIdentity = GetImageById(oPerson.Id, True)
        If oImageIdentity IsNot Nothing Then
            imageCell.Value = oImageIdentity.Photo.Clone
            oImageIdentity.Dispose()
        End If

    End Sub
    Private Sub ShowStatus(pText As String, Optional isLogged As Boolean = False)
        LblStatus.Text = pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub

    Private Sub BtnImgUpdate_Click(sender As Object, e As EventArgs) Handles BtnImgUpdate.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Opening images form", True)
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Using _update As New FrmDatabaseImages
                _update.PersonId = oRow.Cells(SelPersonId.Name).Value
                _update.ShowDialog()
            End Using
        End If
        ShowStatus("")
    End Sub

    Private Sub BtnTweet_Click(sender As Object, e As EventArgs) Handles BtnTweet.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Opening Twitter form", True)
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Using _tweet As New FrmDailyTweets
                _tweet.DaySelection = oRow.Cells(selPersonDay.Name).Value
                _tweet.MonthSelection = oRow.Cells(selPersonMonth.Name).Value
                _tweet.ShowDialog()
            End Using
        End If
        ShowStatus("")
    End Sub

    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnWordPress.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Opening WordPress form", True)
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Using _wordpress As New FrmWordPress
                _wordpress.DaySelection = oRow.Cells(selPersonDay.Name).Value
                _wordpress.MonthSelection = oRow.Cells(selPersonMonth.Name).Value
                _wordpress.ShowDialog()
            End Using
        End If
        ShowStatus("")
    End Sub

    Private Sub FrmSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.srchformpos)
    End Sub

    Private Sub Name_DragDrop(sender As Object, e As DragEventArgs) Handles TxtSurname.DragDrop, TxtForename.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            Dim textlen As Integer = oBox.TextLength
            Dim startpos As Integer = oBox.SelectionStart
            If textlen = 0 Then
                oBox.Text = item.Trim
            Else
                If startpos = 0 Then
                    oBox.SelectedText = item.TrimStart
                Else
                    If oBox.Text.Substring(startpos - 1, 1) = "." Then
                        oBox.SelectedText = " " & item.TrimStart
                    Else
                        oBox.SelectedText = item
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Name_DragOver(sender As Object, e As DragEventArgs) Handles TxtSurname.DragOver, TxtForename.DragOver
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            oBox.Select(TextBoxCursorPos(oBox, e.X, e.Y), 0)
        End If
    End Sub

    Private Sub TxtSurname_DragEnter(sender As Object, e As DragEventArgs) Handles TxtSurname.DragEnter, TxtForename.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            If e.Data.GetDataPresent(DataFormats.Text) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub
    Private Sub ChkShowImage_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowImage.CheckedChanged
        DgvPeople.Columns().Item(xImg.Name).Visible = ChkShowImage.Checked
        For Each tRow As DataGridViewRow In DgvPeople.Rows
            tRow.Height = If(ChkShowImage.Checked, 65, DgvPeople.RowTemplate.Height)
        Next
    End Sub
    Private Sub BtnPasteName_Click(sender As Object, e As EventArgs) Handles BtnPasteName.Click
        TxtSurname.Text = Clipboard.GetText
    End Sub

    Private Sub BtnSplitNameText_Click(sender As Object, e As EventArgs) Handles BtnSplitNameText.Click
        SplitNameText()
    End Sub
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, LblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, LblStatus, True, MyBase.Name,, isMessagebox)
    End Sub

    Private Sub DgvPeople_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPeople.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < DgvPeople.Rows.Count Then
            Dim tRow As DataGridViewRow = DgvPeople.Rows(e.RowIndex)
            OpenUpdateForm(tRow)
        End If
    End Sub
#End Region
End Class
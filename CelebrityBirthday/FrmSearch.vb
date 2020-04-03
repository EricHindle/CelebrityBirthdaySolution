Imports CelebrityBirthday

Public Class FrmSearch
#Region "variables"
    Private bLoadingPeople As Boolean
    Private _browser As FrmBrowser
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
            ShowStatus("Searching for " & TxtForename.Text & " " & TxtSurname.Text)
            bLoadingPeople = True
            DgvPeople.Rows.Clear()
            Dim selectedPersons As List(Of Person) = FindPeopleLikeName(TxtForename.Text, TxtSurname.Text)
            For Each oPerson As Person In selectedPersons
                AddTableRow(oPerson)
            Next
            DgvPeople.ClearSelection()
            bLoadingPeople = False
            ShowStatus("Search complete - found " & CStr(selectedPersons.Count) & " records")
        Else
            ShowStatus("No name supplied")
        End If
    End Sub
    Private Sub BtnSearchById_Click(sender As Object, e As EventArgs) Handles BtnSearchById.Click
        If Not String.IsNullOrEmpty(txtId.Text) Then
            ShowStatus("Searching for " & txtId.Text)
            LoadScreenFromId(CInt(txtId.Text))
            ShowStatus("Search complete")
        Else
            ShowStatus("No id supplied")
        End If
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnDbUpdate.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Updating")
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Using _update As New FrmUpdateDatabase
                _update.PersonId = oRow.Cells(SelPersonId.Name).Value
                _update.ShowDialog()
            End Using
        End If
        ShowStatus("")
    End Sub
    Private Sub BtnFindInWiki_Click(sender As Object, e As EventArgs) Handles BtnFindInWiki.Click
        If Not String.IsNullOrEmpty(TxtForename.Text) Or Not String.IsNullOrEmpty(TxtSurname.Text) Then
            ShowStatus("Finding in wiki")
            Using _browser As New FrmBrowser
                _browser.SearchName = TxtForename.Text & " " & TxtSurname.Text
                _browser.FindinWiki()
                _browser.ShowDialog()
            End Using
            ShowStatus("")
        Else
            ShowStatus("No name supplied")
        End If
    End Sub
    Private Sub FrmSearch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If _browser IsNot Nothing AndAlso Not _browser.IsDisposed Then
            _browser.Close()
            _browser.Dispose()
            _browser = Nothing
        End If
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
        Me.Close()
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
        tRow.Cells(SelPersonId.Name).Value = oPerson.Id
        tRow.Cells(SelPersonForename.Name).Value = oPerson.ForeName
        tRow.Cells(SelPersonSurname.Name).Value = oPerson.Surname
        tRow.Cells(selPersonDay.Name).Value = oPerson.BirthDay
        tRow.Cells(selPersonMonth.Name).Value = oPerson.BirthMonth
        tRow.Cells(SelPersonYear.Name).Value = oPerson.BirthYear
        tRow.Cells(selDesc.Name).Value = oPerson.ShortDesc
    End Sub
    Private Sub ShowStatus(pText As String)
        LblStatus.Text = pText
        StatusStrip1.Refresh()
    End Sub

    Private Sub BtnImgUpdate_Click(sender As Object, e As EventArgs) Handles BtnImgUpdate.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Updating")
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Using _update As New FrmImages
                _update.PersonId = oRow.Cells(SelPersonId.Name).Value
                _update.ShowDialog()
            End Using
        End If
        ShowStatus("")
    End Sub

    Private Sub BtnTweet_Click(sender As Object, e As EventArgs) Handles BtnTweet.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("Tweeting")
            Dim oRow As DataGridViewRow = DgvPeople.SelectedRows(0)
            Using _tweet As New FrmTweet
                _tweet.DaySelection = oRow.Cells(selPersonDay.Name).Value
                _tweet.MonthSelection = oRow.Cells(selPersonMonth.Name).Value
                _tweet.ShowDialog()
            End Using
        End If
        ShowStatus("")
    End Sub

    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnWordPress.Click
        If DgvPeople.SelectedRows.Count = 1 Then
            ShowStatus("WordPress")
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
        GetFormPos(Me, My.Settings.srchformpos)
    End Sub
#End Region
End Class
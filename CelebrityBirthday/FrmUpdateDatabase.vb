﻿Imports System.Text
Imports System.IO
Imports System.Net

Public Class FrmUpdateDatabase
#Region "variables"
    Private personTable As List(Of Person)
    Private bLoadingPerson As Boolean = False
    Private _search As FrmBrowser = Nothing
    Private _browser As FrmBrowser
    Private findPersonInList As Integer = -1
#End Region
#Region "properties"
    Private _personId As Integer


    Public Property PersonId() As Integer
        Get
            Return _personId
        End Get
        Set(ByVal value As Integer)
            _personId = value
        End Set
    End Property
#End Region
#Region "control handlers"
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        CloseForm()

    End Sub

    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles txtDesc.DragDrop,
                                                                                            txtDied.DragDrop,
                                                                                            txtName.DragDrop,
                                                                                            txtYear.DragDrop,
                                                                                            txtForename.DragDrop,
                                                                                            txtSurname.DragDrop,
                                                                                            txtBirthName.DragDrop,
                                                                                            txtBirthPlace.DragDrop,
                                                                                            txtShortDesc.DragDrop,
                                                                                            txtTwitter.DragDrop
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
    Private Sub TextBox_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtDesc.DragOver,
                                                                                                                            txtDied.DragOver,
                                                                                                                            txtName.DragOver,
                                                                                                                            txtYear.DragOver,
                                                                                                                            txtForename.DragOver,
                                                                                                                            txtSurname.DragOver,
                                                                                                                            txtBirthName.DragOver,
                                                                                                                            txtBirthPlace.DragOver,
                                                                                                                            txtShortDesc.DragOver,
                                                                                                                            txtTwitter.DragOver

        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            oBox.Select(TextBoxCursorPos(oBox, e.X, e.Y), 0)
        End If
    End Sub
    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtDesc.DragEnter,
                                                                                                                            txtDied.DragEnter,
                                                                                                                            txtName.DragEnter,
                                                                                                                            txtYear.DragEnter,
                                                                                                                            txtForename.DragEnter,
                                                                                                                            txtSurname.DragEnter,
                                                                                                                            txtBirthName.DragEnter,
                                                                                                                            txtBirthPlace.DragEnter,
                                                                                                                            txtShortDesc.DragEnter,
                                                                                                                            txtTwitter.DragEnter

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
    Private Sub BtnClrNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrNew.Click
        ClearDetails()
    End Sub
    Private Sub BtnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        TidyText()
        If txtYear.TextLength = 0 OrElse Not IsNumeric(txtYear.TextLength) Then
            MsgBox("No birth year", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            Try
                Dim newPerson As New Person(txtForename.Text.Trim,
                                            txtSurname.Text.Trim,
                                            txtDesc.Text.Trim,
                                            txtShortDesc.Text.Trim,
                                            cboDay.SelectedIndex + 1,
                                            cboMonth.SelectedIndex + 1,
                                            txtYear.Text.Trim,
                                            CInt("0" & txtDied.Text.Trim),
                                            CInt("0" & txtDthMth.Text.Trim),
                                            CInt("0" & txtDthDay.Text.Trim),
                                            txtBirthName.Text.Trim,
                                            txtBirthPlace.Text.Trim,
                                            New ImageIdentity(),
                                            New SocialMedia(-1, txtTwitter.Text, cbNoTweet.Checked)) With {
                                            .UnsavedChanges = True
                                            }
                Dim bInserted As Boolean = False
                Dim p As Integer = -1
                For ix As Integer = 0 To personTable.Count - 1
                    Dim aPerson As Person = personTable(ix)
                    If aPerson.BirthYear > newPerson.BirthYear Then
                        personTable.Insert(ix, newPerson)
                        bInserted = True
                        p = ix
                        Exit For
                    End If
                Next
                If Not bInserted Then
                    p = personTable.Count
                    personTable.Add(newPerson)
                End If
                DisplayPersonList()
                lbPeople.SelectedIndex = p
            Catch ex As Exception
                MsgBox("Error on insert", MsgBoxStyle.Exclamation, "Insert error")
                lblStatus.Text = ex.Message
            End Try
        Else
            MsgBox("No date selected", MsgBoxStyle.Exclamation, "Insert error")
        End If
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oPerson As Person
        If lbPeople.SelectedIndex >= 0 Then
            oPerson = personTable(lbPeople.SelectedIndex)
            If oPerson.Id > 0 Then
                DeleteTwitterHandle(oPerson.Id)
                DeleteImage(oPerson.Id)
                DeletePerson(oPerson.Id)
            End If
            personTable.RemoveAt(lbPeople.SelectedIndex)
        End If
        DisplayPersonList()
    End Sub
    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim ix As Integer
        If lbPeople.SelectedIndex > 0 Then
            ix = lbPeople.SelectedIndex
            Dim prevPerson As New Person(personTable(ix - 1))
            Dim thisperson As New Person(personTable(ix))
            Dim isseq As Integer = prevPerson.Sortseq
            If prevPerson.IBirthYear >= thisperson.IBirthYear Then
                prevPerson.Sortseq = thisperson.Sortseq
                thisperson.Sortseq = isseq
                prevPerson.UnsavedChanges = True
                thisperson.UnsavedChanges = True
                personTable(ix - 1) = thisperson
                personTable(ix) = prevPerson
                DisplayPersonList()
                lbPeople.SelectedIndex = ix - 1
            End If
        End If
    End Sub
    Private Sub BtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim ix As Integer
        If lbPeople.SelectedIndex >= 0 And lbPeople.SelectedIndex < lbPeople.Items.Count - 1 Then
            ix = lbPeople.SelectedIndex
            Dim nextPerson As New Person(personTable(ix + 1))
            Dim thisperson As New Person(personTable(ix))
            Dim isseq As Integer = nextPerson.Sortseq
            If nextPerson.IBirthYear <= thisperson.IBirthYear Then
                nextPerson.Sortseq = thisperson.Sortseq
                thisperson.Sortseq = isseq
                nextPerson.UnsavedChanges = True
                thisperson.UnsavedChanges = True
                personTable(ix + 1) = thisperson
                personTable(ix) = nextPerson
                DisplayPersonList()
                lbPeople.SelectedIndex = ix + 1
            End If
        End If
    End Sub
    Private Sub BtnUpdateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAll.Click
        UpdateAll()
    End Sub
    Private Sub BtnLoadTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTable.Click, cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        lblStatus.Text = ""
        If CheckForChanges(personTable) Then
            If MsgBox("Save unsaved changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Unsaved Changes") = MsgBoxResult.Yes Then
                UpdateAll()
            End If
        End If
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            lblStatus.Text = "Loading Table From Database"
            StatusStrip1.Refresh()
            personTable = New List(Of Person)
            lbPeople.Items.Clear()
            Dim oDrow As CelebrityBirthdayDataSet.DatesRow = GetDatesRow(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            If oDrow IsNot Nothing Then
                cbDateAmend.Checked = True
                txtLoadYr.Text = If(oDrow.IsuploadyearNull, "", oDrow.uploadyear)
                txtLoadMth.Text = If(oDrow.IsuploadmonthNull, "", oDrow.uploadmonth)
                txtLoadDay.Text = If(oDrow.IsuploaddayNull, "", oDrow.uploadday)
            End If
            Dim selectedIndex As Integer = -1
            personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            For Each operson As Person In personTable
                lbPeople.Items.Add(operson.BirthYear & " " & operson.Name)
                If findPersonInList > -1 AndAlso findPersonInList = operson.Id Then
                    selectedIndex = lbPeople.Items.Count - 1
                End If
            Next
            lbPeople.SelectedIndex = selectedIndex
            findPersonInList = -1
            lblStatus.Text += " - Complete"
        End If
    End Sub
    Private Sub BtnReloadSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReloadSel.Click
        lblStatus.Text = "Loading Item From Database"
        Me.Refresh()
        If lbPeople.SelectedIndex >= 0 And lbPeople.SelectedIndex < lbPeople.Items.Count Then
            If personTable(lbPeople.SelectedIndex) IsNot Nothing Then
                Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
                If oPerson.Id > 0 Then
                    Dim newPerson As Person = GetPersonById(oPerson.Id)
                    If newPerson IsNot Nothing Then
                        personTable(lbPeople.SelectedIndex) = newPerson
                    End If
                    lbPeople.Items(lbPeople.SelectedIndex) = newPerson.BirthYear & " " & newPerson.Name
                End If
            End If
        End If
        lblStatus.Text += " - Complete"
    End Sub
    Private Sub LbPeople_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPeople.SelectedIndexChanged
        lblStatus.Text = ""
        SwapText("Text")
        bLoadingPerson = True
        If lbPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            LoadScreenFromPerson(oPerson)
        Else
            ClearDetails()
        End If
        bLoadingPerson = False
    End Sub
    Private Sub BtnUpdateSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSel.Click
        lblStatus.Text = ""
        If lbPeople.SelectedIndex >= 0 Then
            lblStatus.Text = "Updating Database"
            StatusStrip1.Refresh()
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            If oPerson.Id < 0 Then
                Dim newId As Integer = InsertPerson(oPerson)
            Else
                UpdatePerson(oPerson)
            End If
            If cbDateAmend.Checked Then
                UpdateDate(txtLoadYr.Text, txtLoadMth.Text, cbDateAmend.Checked, txtLoadDay.Text, cboDay.SelectedIndex, cboMonth.SelectedIndex)
            End If
            oPerson.UnsavedChanges = False
            lblStatus.Text += " - Complete"
        End If
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        lblStatus.Text = ""
        TidyText()
        If lblID.Text.Length > 0 Then
            Dim id As Integer = CInt(lblID.Text)
            For Each oPerson As Person In personTable
                If oPerson.Id = id Then
                    oPerson.BirthYear = txtYear.Text
                    oPerson.DeathYear = CInt("0" & txtDied.Text)
                    oPerson.Description = txtDesc.Text.Trim
                    oPerson.ForeName = txtForename.Text.Trim
                    oPerson.Surname = txtSurname.Text.Trim
                    oPerson.ShortDesc = txtShortDesc.Text.Trim
                    oPerson.DeathDay = CInt("0" & txtDthDay.Text.Trim)
                    oPerson.DeathMonth = CInt("0" & txtDthMth.Text.Trim)
                    oPerson.BirthPlace = txtBirthPlace.Text.Trim
                    oPerson.BirthName = txtBirthName.Text.Trim
                    oPerson.UnsavedChanges = True
                    oPerson.Social = New SocialMedia(id, txtTwitter.Text, cbNoTweet.Checked)
                    Dim p As Integer = lbPeople.SelectedIndex
                    DisplayPersonList()
                    lbPeople.SelectedIndex = p
                    lblStatus.Text = "Updated list"

                    Exit For
                End If
            Next

        End If
    End Sub
    Private Sub FrmAddCbdy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If _search IsNot Nothing AndAlso Not _search.IsDisposed Then
            _search.Close()
        End If
        If _browser IsNot Nothing AndAlso Not _browser.IsDisposed Then
            _browser.Close()
        End If
        My.Settings.updformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label11.Text = "Version: " & My.Application.Info.Version.ToString
        GetFormPos(Me, My.Settings.updformpos)
        txtLoadYr.Text = ""
        txtLoadMth.Text = ""
        cbDateAmend.Checked = False
        bLoadingPerson = False
        rtbDesc.AllowDrop = True
        rtbDesc.EnableAutoDragDrop = True
        If _personId > 0 Then
            LoadScreenFromId(_personId)
        End If
    End Sub
    Private Sub BtnCreateShortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateShortDesc.Click
        txtShortDesc.Text = txtDesc.SelectedText
    End Sub
    Private Sub BtnSplitName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplitName.Click
        txtName.Text = txtName.Text.Trim
        Dim names As String() = Split(txtName.Text, " ")
        txtSurname.Text = names(UBound(names))
        txtForename.Text = txtName.Text.Replace(txtSurname.Text, "").Trim
    End Sub
    Private Sub BtnCreateFullName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateFullName.Click
        txtName.Text = MakeFullName(txtForename.Text, txtSurname.Text)
    End Sub
    Private Sub BtnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        If CheckForChanges(personTable) Then
            If MsgBox("Save unsaved changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Unsaved Changes") = MsgBoxResult.Yes Then
                UpdateAll()
            End If
        End If
        personTable = New List(Of Person)
        lbPeople.Items.Clear()
        cboDay.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
    End Sub
    Private Sub AnyTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged, txtDied.TextChanged,
                                                                                                 txtForename.TextChanged, txtSurname.TextChanged,
                                                                                                 txtName.TextChanged,
                                                                                                 txtShortDesc.TextChanged, txtBirthName.TextChanged,
                                                                                                 txtBirthPlace.TextChanged, txtDthDay.TextChanged,
                                                                                                 txtDthMth.TextChanged
        If Not bLoadingPerson Then
            cbDateAmend.Checked = True
        End If
    End Sub
    Private Sub BtnWiki_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWiki.Click
        Dim item As String() = {""}
        If lblID.Text.Length > 0 And lbPeople.SelectedIndex >= 0 Then
            item = Split(lbPeople.SelectedItem, " ")
            item(0) = ""
        ElseIf Not String.IsNullOrEmpty(txtForename.Text) OrElse Not String.IsNullOrEmpty(txtSurname.Text) Then
            txtName.Text = If(String.IsNullOrEmpty(txtForename.Text), "", txtForename.Text.Trim & " ") & txtSurname.Text.Trim
            item = Split(txtName.Text, " ")
        ElseIf txtName.TextLength > 0 Then
            item = Split(txtName.Text, " ")
        End If
        If _browser Is Nothing OrElse _browser.isdisposed Then
            _browser = New FrmBrowser
        End If
        _browser.SearchName = Join(item, " ").Trim
        _browser.FindinWiki()
        _browser.Show()


    End Sub
    Private Sub TxtDthDay_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDthDay.Click, txtDthMth.Click, txtDied.Click
        Dim fld As TextBox = CType(sender, TextBox)
        fld.SelectAll()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        GetSourceControl(menuItem).Copy()
    End Sub
    Private Sub CutToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        GetSourceControl(menuItem).Cut()
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(sender)

        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            If _textBox IsNot Nothing Then
                _textBox.SelectAll()
            End If
        End If

    End Sub
    Private Sub PasteToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If

    End Sub
    Private Sub LowercaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles LowercaseToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToLower
        End If
    End Sub
    Private Sub UpperCaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles UpperCaseToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToUpper
        End If
    End Sub
    Private Sub TitleCaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles TitleCaseToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = StrConv(_textBox.SelectedText, VbStrConv.ProperCase)
        End If
    End Sub
    Private Sub ClearToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Text = ""
        End If
    End Sub
    Private Sub BtnCopyBirthName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyBirthName.Click
        If txtDesc.SelectionLength > 0 Then
            Dim name As String = txtDesc.SelectedText.Trim
            Dim names As String() = Split(name, """")
            If names.Length = 3 Then
                name = names(0).Trim & " " & names(2).Trim
            End If
            txtBirthName.Text = name
        End If
    End Sub
    Private Sub BtnCopyBirthPlace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyBirthPlace.Click
        If txtDesc.SelectionLength > 0 Then
            txtBirthPlace.Text = txtDesc.SelectedText.Trim.TrimEnd(".").TrimEnd(",")
        End If
    End Sub
    Private Sub BtnClearDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDesc.Click
        txtDesc.Text = ""
        rtbDesc.Text = ""
    End Sub
    Private Sub UseNicknameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseNicknameToolStripMenuItem.Click
        If txtDesc.SelectionLength > 0 Then
            txtDesc.SelectedText = GetNickname(txtDesc.SelectedText)
        End If
    End Sub
    Private Sub BtnTidy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTidy.Click
        TidyText()
    End Sub
    Private Sub BtnRTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRTB.Click
        SwapText(btnRTB.Text)
    End Sub
    Private Sub BtnTidyDob_Click(sender As Object, e As EventArgs) Handles btnTidyDob.Click
        TidyAndFix()
    End Sub
    Private Sub BtnTwitter_Click(sender As Object, e As EventArgs) Handles btnTwitter.Click
        If lbPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            If oPerson.DeathYear > 0 Then
                MsgBox("DEAD. Expired and gone to meet their maker. Pushing up the daisies." _
                    & vbCrLf & "Bereft of life, they rest in peace. Shuffled off this mortal coil" _
                    & vbCrLf & "Run down the curtain and joined the choir invisible.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                lblStatus.Text = "Dead"
                Exit Sub
            End If
            If _search Is Nothing OrElse _search.IsDisposed Then
                _search = New FrmBrowser
            End If
            _search.Show()
            _search.searchName = oPerson.ForeName.Trim & " " & oPerson.Surname.Trim
            _search.FindinTwitter()
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub CloseForm()
        Dim resp As MsgBoxResult = MsgBoxResult.No
        If CheckForChanges(personTable) Then
            resp = MsgBox("Save changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Unsaved Changes")
        End If
        Select Case resp
            Case MsgBoxResult.Yes
                UpdateAll()
                Me.Close()
            Case MsgBoxResult.No
                Me.Close()
            Case MsgBoxResult.Cancel
            Case Else
        End Select
        _personId = 0
    End Sub
    Private Sub ClearDetails()
        lblID.Text = ""
        txtDesc.Text = ""
        txtShortDesc.Text = ""
        txtDied.Text = ""
        txtName.Text = ""
        txtForename.Text = ""
        txtSurname.Text = ""
        txtYear.Text = ""
        PictureBox1.ImageLocation = ""
        txtBirthName.Text = ""
        txtBirthPlace.Text = ""
        txtDthDay.Text = ""
        txtDthMth.Text = ""
        txtTwitter.Text = ""
        cbNoTweet.Checked = False
    End Sub
    Private Sub DisplayPersonList()
        lbPeople.Items.Clear()
        For Each oPerson As Person In personTable
            lbPeople.Items.Add(oPerson.BirthYear & " " & oPerson.Name)
        Next
    End Sub
    Private Sub Splitname(ByVal sName As String, ByRef sForename As String, ByRef sSurname As String)
        Dim sWords As List(Of String) = Split(sName, " ").ToList
        If sWords.Count > 0 Then
            sSurname = sWords(sWords.Count - 1)
            sWords.RemoveAt(sWords.Count - 1)
            sForename = String.Join(" ", sWords)
        End If
    End Sub
    Private Sub UpdateAll()
        lblStatus.Text = "Updating Database"
        StatusStrip1.Refresh()
        Dim lastYear As String = ""
        Dim iSeq As Integer = 0
        For Each oPerson As Person In personTable
            If oPerson.BirthYear = lastYear Then
                iSeq += 1
            Else
                iSeq = 0
                lastYear = oPerson.BirthYear
            End If
            If oPerson.Id < 0 Then
                Dim newId As Integer = InsertPerson(oPerson)
                oPerson.Id = newId
            Else
                UpdatePerson(oPerson)
            End If
            oPerson.UnsavedChanges = False
        Next
        If cbDateAmend.Checked Then
            UpdateDate(txtLoadYr.Text, txtLoadMth.Text, cbDateAmend.Checked, txtLoadDay.Text, cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
        End If
        lblStatus.Text += " - Complete"
    End Sub
    Private Sub TidyAndFix()
        Dim _desc As String = RemoveSquareBrackets(FixQuotes(txtDesc.Text))
        Dim _parts As List(Of String) = ParseStringWithBrackets(_desc)
        If _parts.Count = 3 Then
            Dim _datePart As String = RemovePhrases(_parts(1))
            txtDesc.Text = _parts(0) & "(" & _datePart & ")" & _parts(2)
        End If
        _parts = ParseStringWithChar(txtDesc.Text, ".")
        Dim words As List(Of String) = ParseStringWithChar(_parts.Last, " ")
        If ExtractNameandPlace(words) Then
            _parts.RemoveAt(_parts.Count - 1)
            txtDesc.Text = Join(_parts.ToArray, ".") & "."
        End If
        rtbDesc.Text = txtDesc.Text
    End Sub
    Private Sub TidyText()
        Dim newText As String = RemoveSquareBrackets(FixQuotes(txtDesc.Text))
        Dim charsToTrim() As Char = {" "c, ","c, ";"c, "."c, "["c}
        Dim s1 As String() = Split(newText, " - ")
        If s1.Count > 1 Then
            Dim s2 As String() = Split(s1(1), ")")
            If s2.Count > 1 Then
                If IsDate(s2(0)) Then
                    Dim d1 As Date = CDate(s2(0))
                    txtDthDay.Text = Format(d1, "dd")
                    txtDthMth.Text = Format(d1, "MM")
                    txtDied.Text = Format(d1, "yyyy")
                End If
            End If
        End If
        Dim s3 As String() = Split(newText, "(")
        If s3.Count > 1 Then
            If s3(0).IndexOf("""") > 0 Then
                Dim birthName As String = s3(0)
                s3(0) = GetNickname(birthName)
                txtBirthName.Text = birthName
                newText = Join(s3, "(")
            End If
        End If
        Dim trimmedTextBefore As String = ""
        Dim trimmedTextAfter As String = newText
        Do Until trimmedTextBefore = trimmedTextAfter
            trimmedTextBefore = trimmedTextAfter
            trimmedTextAfter = trimmedTextBefore.Trim(charsToTrim)
            trimmedTextAfter = trimmedTextAfter.Trim(vbCrLf)
            trimmedTextAfter = trimmedTextAfter.Trim(vbLf)
        Loop
        txtDesc.Text = trimmedTextAfter & If(trimmedTextAfter.Length > 0, ".", "")
        txtName.Text = txtName.Text.Trim(charsToTrim)
        txtForename.Text = txtForename.Text.Trim(charsToTrim)
        txtSurname.Text = txtSurname.Text.Trim(charsToTrim)
        Dim newShortText = RemoveSquareBrackets(FixQuotes(txtShortDesc.Text)).Trim(charsToTrim)
        txtShortDesc.Text = newShortText & If(newShortText.Length > 0, ".", "")
        txtBirthName.Text = RemoveSquareBrackets(FixQuotes(txtBirthName.Text).Replace(",", "").Replace(".", "").Replace(";", "")).Trim(charsToTrim)
        txtBirthPlace.Text = RemoveSquareBrackets(FixQuotes(txtBirthPlace.Text).Replace(".", "").Replace(";", "")).Trim(charsToTrim)
        txtTwitter.Text = RemoveBadCharacters(txtTwitter.Text, {8207}).Trim
        rtbDesc.Text = txtDesc.Text
    End Sub
    Private Sub SwapText(ByVal currentVal As String)
        If currentVal = "RTB" Then
            rtbDesc.Text = txtDesc.Text
            rtbDesc.Visible = True
            txtDesc.Visible = False
            btnRTB.Text = "Text"
        Else
            txtDesc.Text = rtbDesc.Text
            rtbDesc.Visible = False
            txtDesc.Visible = True
            btnRTB.Text = "RTB"
        End If
    End Sub
    Private Sub LoadScreenFromId(ByVal oId As Integer)
        Try
            Dim oPerson As Person = GetFullPersonById(oId)
            If oPerson IsNot Nothing Then
                findPersonInList = oPerson.Id
                cboDay.SelectedIndex = oPerson.BirthDay - 1
                cboMonth.SelectedIndex = oPerson.BirthMonth - 1
            Else
                lblStatus.Text = "Id not found"
            End If
        Catch ex As Exception
            lblStatus.Text = "Unable to load Person" & vbCrLf & ex.Message
        End Try
    End Sub
    Private Sub LoadScreenFromPerson(oPerson As Person)
        bLoadingPerson = True
        lblID.Text = oPerson.Id
        txtForename.Text = oPerson.ForeName
        txtSurname.Text = oPerson.Surname
        txtDesc.Text = oPerson.Description
        txtShortDesc.Text = oPerson.ShortDesc
        txtYear.Text = CStr(oPerson.BirthYear)
        txtDied.Text = CStr(oPerson.DeathYear)
        txtDthDay.Text = CStr(oPerson.DeathDay)
        txtDthMth.Text = CStr(oPerson.DeathMonth)
        txtBirthName.Text = oPerson.BirthName
        txtBirthPlace.Text = oPerson.BirthPlace
        txtName.Text = MakeFullName(oPerson.ForeName, oPerson.Surname)
        Dim sYear As String = txtLoadYr.Text
            Dim sMth As String = txtLoadMth.Text
        If oPerson.Image IsNot Nothing Then
            PictureBox1.ImageLocation = Path.Combine(My.Settings.ImgFolder, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
        End If
        If oPerson.Social IsNot Nothing Then
            txtTwitter.Text = If(oPerson.Social.TwitterHandle, "")
            cbNoTweet.Checked = oPerson.Social.IsNoTweet
        End If
        bLoadingPerson = False
    End Sub
#End Region
#Region "functions"
    Private Function MakeFullName(pForename As String, pSurname As String) As String
        Return If(String.IsNullOrEmpty(pForename), "", pForename.Trim & " ") & pSurname.Trim
    End Function
    Private Function GetNickname(ByRef sName As String) As String
        Dim names As String() = Split(sName, """")
        Dim sNickName As String = ""
        If names.Length > 2 Then
            sNickName = names(1).Trim & " " & names(2).Trim
            sName = names(0).Trim & " " & names(2).Trim
        End If
        Return sNickName & " "
    End Function


    Private Function RemovePhrases(ByVal _innerText As String) As String
        Dim _dateString As String = ""
        Dim _phrases As String() = Split(_innerText, ";")
        If _phrases.Count = 1 Then
            Return _innerText
            Exit Function
        End If
        For Each _Phrase As String In _phrases
            If MsgBox(_innerText & vbCrLf & vbCrLf & "Remove: " & _Phrase & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Remove phrase") = MsgBoxResult.No Then
                _dateString &= _Phrase & ";"
            End If
        Next
        Return _dateString.Trim(";").Trim()
    End Function
    Private Function ExtractNameandPlace(_words As List(Of String)) As Boolean
        Dim isextracted As Boolean = False
        Dim isNamePart As Boolean = False
        Dim isPlacePart As Boolean = False
        Dim isDatePart As Boolean
        Dim _date As String = ""
        Dim _name As String = ""
        Dim _place As String = ""

        If _words.First.ToLower = "born" Then
            For Each _word As String In _words
                Select Case _word.ToLower
                    Case "born"
                        isNamePart = True
                        isPlacePart = False
                        isDatePart = False
                    Case "in"
                        isNamePart = False
                        isPlacePart = True
                        isDatePart = False
                    Case "at"
                        isNamePart = False
                        isPlacePart = True
                        isDatePart = False
                    Case "on"
                        isNamePart = False
                        isPlacePart = False
                        isDatePart = True
                    Case Else
                        If isNamePart Then
                            _name &= _word & " "
                        End If
                        If isPlacePart Then
                            _place &= _word & " "
                        End If
                End Select
            Next
        End If
        If Not String.IsNullOrEmpty(_name.Trim()) Then
            txtBirthName.Text = _name.Trim()
            isextracted = True
        End If
        If Not String.IsNullOrEmpty(_place.Trim()) Then
            txtBirthPlace.Text = _place.Trim()
            isextracted = True
        End If
        If Not String.IsNullOrEmpty(_date.Trim()) Then
            isextracted = True
        End If
        Return isextracted
    End Function
#End Region
End Class
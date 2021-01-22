Imports System.Text
Imports System.IO
Imports System.Net
Imports CelebrityBirthday
Imports System.Data.Common

Public NotInheritable Class FrmUpdateDatabase
#Region "variables"
    Private personTable As List(Of Person)
    Private bLoadingPerson As Boolean
    Private findPersonInList As Integer = -1
    Private isGotBirthName As Boolean
    Private isGotStageName As Boolean
    Private ReadOnly trimChars As Char() = {".", ",", " "}
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
                                                                                            TxtBirthName.DragDrop,
                                                                                            TxtBirthPlace.DragDrop,
                                                                                            TxtShortDesc.DragDrop,
                                                                                            txtTwitter.DragDrop,
                                                                                            TxtWikiId.DragDrop
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
                                                                                                                            TxtBirthName.DragOver,
                                                                                                                            TxtBirthPlace.DragOver,
                                                                                                                            TxtShortDesc.DragOver,
                                                                                                                            txtTwitter.DragOver,
                                                                                                                            TxtWikiId.DragOver

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
                                                                                                                            TxtBirthName.DragEnter,
                                                                                                                            TxtBirthPlace.DragEnter,
                                                                                                                            TxtShortDesc.DragEnter,
                                                                                                                            txtTwitter.DragEnter,
                                                                                                                            TxtWikiId.DragEnter

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
        ShowStatus("Inserting person in list",, True)
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
                                            TxtShortDesc.Text.Trim,
                                            cboDay.SelectedIndex + 1,
                                            cboMonth.SelectedIndex + 1,
                                            txtYear.Text.Trim,
                                            CInt("0" & txtDied.Text.Trim),
                                            CInt("0" & txtDthMth.Text.Trim),
                                            CInt("0" & txtDthDay.Text.Trim),
                                            TxtBirthName.Text.Trim,
                                            TxtBirthPlace.Text.Trim,
                                            New ImageIdentity(),
                                            New SocialMedia(-1, txtTwitter.Text, cbNoTweet.Checked, TxtWikiId.Text, 0)) With {
                                            .UnsavedChanges = True
                                            }
                Dim bInserted As Boolean = False
                Dim p As Integer = -1
                For ix As Integer = 0 To personTable.Count - 1
                    Dim aPerson As Person = personTable(ix)
                    If aPerson.IBirthYear > newPerson.IBirthYear Then
                        newPerson = UpdateSortSeq(newPerson, ix)
                        personTable.Insert(ix, newPerson)
                        bInserted = True
                        p = ix
                        Exit For
                    End If
                Next

                If Not bInserted Then
                    p = personTable.Count
                    newPerson = UpdateSortSeq(newPerson, p)
                    personTable.Add(newPerson)
                End If
                ShowUpdated(newPerson, "Inserted")
                DisplayPersonList()
                lbPeople.SelectedIndex = p
                LblSortSeq.Text = CStr(newPerson.Sortseq)
                newPerson.Dispose()
            Catch ex As DbException
                MsgBox("Error on insert", MsgBoxStyle.Exclamation, "Insert error")
                ShowStatus(ex.Message,, True)
            Catch ex As ArgumentException
                MsgBox("Error on insert", MsgBoxStyle.Exclamation, "Insert error")
                ShowStatus(ex.Message,, True)
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
                LogUtil.Info("Deleting person " & CStr(oPerson.Id) & " " & oPerson.Name, MyBase.Name)
                DeleteSocialMedia(oPerson.Id)
                DeleteImage(oPerson.Id)
                DeletePerson(oPerson.Id)
            End If
            personTable.RemoveAt(lbPeople.SelectedIndex)
        End If
        DisplayPersonList()
    End Sub
    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim ix As Integer = lbPeople.SelectedIndex
        Dim prevIx As Integer = ix - 1
        If lbPeople.SelectedIndex > 0 Then
            SwapPersons(ix, prevIx)
        End If
    End Sub
    Private Sub BtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim ix As Integer = lbPeople.SelectedIndex
        Dim nextIx As Integer = ix + 1
        If lbPeople.SelectedIndex >= 0 And lbPeople.SelectedIndex < lbPeople.Items.Count - 1 Then
            SwapPersons(ix, nextIx)
        End If
    End Sub
    Private Sub BtnUpdateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAll.Click
        UpdateAll()
    End Sub
    Private Sub BtnLoadTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTable.Click, cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        ClearStatus()
        LblUpdated.Visible = False
        LbUpdateList.Items.Clear()
        LbUpdateList.Visible = False
        If CheckForChanges(personTable) Then
            If MsgBox("Save unsaved changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Unsaved Changes") = MsgBoxResult.Yes Then
                UpdateAll()
            End If
        End If
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            ShowStatus("Loading Table From Database",, True)
            LogUtil.Info(cboDay.SelectedItem & " " & cboMonth.SelectedItem, MyBase.Name)
            StatusStrip1.Refresh()
            personTable = New List(Of Person)
            lbPeople.Items.Clear()
            Dim selectedIndex As Integer = -1
            personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, False, False)
            If personTable.Count > 0 Then
                Dim lastYear As String = ""
                Dim sortSeq As Integer = 0
                For Each operson As Person In personTable
                    If operson.BirthYear.Equals(lastYear, Global.System.StringComparison.Ordinal) Then
                        sortSeq += 1
                    Else
                        sortSeq = 0
                        lastYear = operson.BirthYear
                    End If
                    operson.Sortseq = sortSeq
                    lbPeople.Items.Add(operson.BirthYear & " " & operson.Name)
                    If findPersonInList > -1 AndAlso findPersonInList = operson.Id Then
                        selectedIndex = lbPeople.Items.Count - 1
                    End If
                Next
                Dim oDrow As CelebrityBirthdayDataSet.DatesRow = GetDatesRow(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, "I")
                If oDrow IsNot Nothing Then
                    TxtImageLoadYr.Text = If(oDrow.IsuploadyearNull, "", oDrow.uploadyear)
                    TxtImageLoadMth.Text = If(oDrow.IsuploadmonthNull, "", oDrow.uploadmonth)
                    TxtImageLoadDay.Text = If(oDrow.IsuploaddayNull, "", oDrow.uploadday)
                End If
                oDrow = GetDatesRow(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, "P")
                If oDrow IsNot Nothing Then
                    TxtPageLoadYr.Text = If(oDrow.IsuploadyearNull, "", oDrow.uploadyear)
                    TxtPageLoadMth.Text = If(oDrow.IsuploadmonthNull, "", oDrow.uploadmonth)
                    TxtPageLoadDay.Text = If(oDrow.IsuploaddayNull, "", oDrow.uploadday)
                End If
                AppendStatus(" - Complete")
            Else
                AppendStatus(" - No data", True)
            End If
            lbPeople.SelectedIndex = selectedIndex
            findPersonInList = -1
        End If
    End Sub
    Private Sub BtnReloadSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReloadSel.Click
        ShowStatus("Loading Item From Database",, True)
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
        AppendStatus(" - Complete", True)
    End Sub
    Private Sub LbPeople_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPeople.SelectedIndexChanged
        ClearStatus()
        SwapText("Text")
        bLoadingPerson = True
        If lbPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            LoadScreenFromPerson(oPerson)
            ShowStatus("Selected " & oPerson.Name,, True)
        Else
            ClearDetails()
        End If
        bLoadingPerson = False
    End Sub
    Private Sub BtnUpdateSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSel.Click

        ClearStatus()
        If lbPeople.SelectedIndex >= 0 Then
            ShowStatus("Updating database with selected person", , True)
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            Dim dbAction As String
            If oPerson.Id < 0 Then
                Dim newId As Integer = InsertPerson(oPerson)
                dbAction = "Inserted on dB"
            Else
                UpdatePerson(oPerson)
                dbAction = "Updated on dB"
            End If
            lblID.Text = CStr(oPerson.Id)
            ShowUpdated(oPerson, dbAction)
            oPerson.UnsavedChanges = False
            AppendStatus(" - Complete")
        End If
    End Sub
    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ShowStatus("Updating person in list", , True)
        ClearStatus()
        TidyText()
        If lblID.Text.Length > 0 Then
            If String.IsNullOrEmpty(txtSurname.Text) Then
                ShowStatus("No surname for " & txtForename.Text,, True)
                MsgBox("No surname", MsgBoxStyle.Exclamation, "Warning")
            End If
            Dim id As Integer = CInt(lblID.Text)
                For Each oPerson As Person In personTable
                    If oPerson.Id = id Then
                        Dim CurrentSocialMedia As SocialMedia = oPerson.Social
                        oPerson.BirthYear = txtYear.Text
                        oPerson.DeathYear = 0
                        If Not Integer.TryParse(txtDied.Text, oPerson.DeathYear) Then txtDied.Text = ""
                        oPerson.Description = txtDesc.Text.Trim
                        oPerson.ForeName = txtForename.Text.Trim
                        oPerson.Surname = txtSurname.Text.Trim
                        oPerson.ShortDesc = TxtShortDesc.Text.Trim
                        oPerson.DeathDay = CInt("0" & txtDthDay.Text.Trim)
                        oPerson.DeathMonth = CInt("0" & txtDthMth.Text.Trim)
                        oPerson.BirthPlace = TxtBirthPlace.Text.Trim
                        oPerson.BirthName = TxtBirthName.Text.Trim
                        oPerson.UnsavedChanges = True
                        oPerson.Social = New SocialMedia(id, txtTwitter.Text, cbNoTweet.Checked, TxtWikiId.Text, CurrentSocialMedia.Botsd)
                        ShowUpdated(oPerson, "Updated")
                        Dim p As Integer = lbPeople.SelectedIndex
                        DisplayPersonList()
                        lbPeople.SelectedIndex = p
                        ShowStatus("Updated list",, True)
                        Exit For
                    End If
                Next
                Else
                LogUtil.Problem("ID label is empty", MyBase.Name)
        End If
    End Sub
    Private Sub FrmAddCbdy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.updformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        NudSentences.Value = My.Settings.wikiSentences
        Label11.Text = "Version: " & My.Application.Info.Version.ToString
        GetFormPos(Me, My.Settings.updformpos)
        TxtImageLoadYr.Text = ""
        TxtImageLoadMth.Text = ""
        TxtImageLoadDay.Text = ""
        TxtPageLoadYr.Text = ""
        TxtPageLoadMth.Text = ""
        TxtPageLoadDay.Text = ""
        bLoadingPerson = False
        rtbDesc.AllowDrop = True
        rtbDesc.EnableAutoDragDrop = True
        ResetBackgroundColors()
        If _personId > 0 Then
            LoadScreenFromId(_personId)
        End If
    End Sub
    Private Sub BtnCreateShortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateShortDesc.Click
        If txtDesc.SelectionLength > 0 Then
            TxtShortDesc.Text = txtDesc.SelectedText.Trim(trimChars)
        ElseIf txtWiki.SelectionLength > 0 Then
            TxtShortDesc.Text = txtWiki.SelectedText.Trim(trimChars)
        End If
        TxtShortDesc.Text &= "."
    End Sub
    Private Sub BtnSplitName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplitName.Click
        txtName.Text = txtName.Text.Trim
        Dim names As String() = Split(txtName.Text, " ")
        txtSurname.Text = names(UBound(names))
        If Not String.IsNullOrEmpty(txtSurname.Text) Then
            txtForename.Text = txtName.Text.Replace(txtSurname.Text, "").Trim
        End If

    End Sub
    Private Sub BtnCreateFullName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateFullName.Click
        txtName.Text = MakeFullName(txtForename.Text, txtSurname.Text)
    End Sub
    Private Sub BtnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        LogUtil.Info("Clearing person list", MyBase.Name)
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
    Private Sub BtnWiki_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWiki.Click
        If Not String.IsNullOrEmpty(TxtWikiId.Text) Then
            ShowStatus("Opening Wikipedia", , True)
            Process.Start(My.Resources.WIKIURL & TxtWikiId.Text.Trim)
        End If
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
            _textBox.SelectedText = _textBox.SelectedText.ToLower(myCultureInfo)
        End If
    End Sub
    Private Sub UpperCaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles UpperCaseToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToUpper(myCultureInfo)
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
        Dim name As String = ""
        If txtDesc.SelectionLength > 0 Then
            name = txtDesc.SelectedText.Trim
        ElseIf txtWiki.SelectionLength > 0 Then
            name = txtWiki.SelectedText.Trim
        End If
        Dim names As String() = Split(name, """")
        If names.Length = 3 Then
            name = names(0).Trim & " " & names(2).Trim
        End If
        TxtBirthName.Text = name
    End Sub
    Private Sub BtnCopyBirthPlace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyBirthPlace.Click
        If txtDesc.SelectionLength > 0 Then
            TxtBirthPlace.Text = txtDesc.SelectedText.Trim(trimChars)
        ElseIf txtWiki.SelectionLength > 0 Then
            TxtBirthPlace.Text = txtWiki.SelectedText.Trim(trimChars)
        End If
    End Sub
    Private Sub BtnClearDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearDesc.Click
        txtDesc.Text = ""
        rtbDesc.Text = ""
    End Sub
    Private Sub UseNicknameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseNicknameToolStripMenuItem.Click
        If txtDesc.SelectionLength > 0 Then
            Dim _selStart As Integer = txtDesc.SelectionStart
            Dim _selLength As Integer = txtDesc.SelectionLength
            Dim sNickname As String = GetNickname(txtDesc.SelectedText)
            txtDesc.SelectionStart = _selStart
            txtDesc.SelectionLength = _selLength
            txtDesc.Cut()
            txtDesc.Paste(sNickname)
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
        Dim twitterSearchName As String = ""
        If lblID.Text = "-1" Then
            twitterSearchName = txtName.Text
        ElseIf lbPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            If oPerson.DeathYear > 0 Then
                MsgBox("DEAD. Expired and gone to meet their maker. Pushing up the daisies." _
                    & vbCrLf & "Bereft of life, they rest in peace. Shuffled off this mortal coil" _
                    & vbCrLf & "Run down the curtain and joined the choir invisible.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                ShowStatus("Dead")
                txtTwitter.Text = ""
            Else
                twitterSearchName = oPerson.Name
            End If
        End If
        If Not String.IsNullOrEmpty(twitterSearchName) Then
            ShowStatus("Opening Twitter", , True)
            Dim sUrl As String = My.Settings.TwitterSearchUrl & twitterSearchName.Replace(" ", "+")
            Process.Start(sUrl)
        End If
    End Sub
    Private Sub BtnGetWikiText_Click(sender As Object, e As EventArgs) Handles BtnGetWikiText.Click
        ShowStatus("Getting wiki text", , True)
        txtDesc.Text = GetWikiText(NudSentences.Value, txtForename.Text, txtSurname.Text, TxtWikiId.Text)
    End Sub
    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnWordPress.Click
        ShowStatus("WordPress",, True)
        If CheckForChanges(personTable) Then
            If MsgBox("Save unsaved changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Unsaved Changes") = MsgBoxResult.Yes Then
                UpdateAll()
            End If
        End If
        Using _wordpress As New FrmWordPress
            _wordpress.DaySelection = cboDay.SelectedIndex + 1
            _wordpress.MonthSelection = cboMonth.SelectedIndex + 1
            _wordpress.ShowDialog()
        End Using

        ClearStatus()
    End Sub
    Private Sub BtnImageLoadUpd_Click(sender As Object, e As EventArgs) Handles BtnImageLoadUpd.Click
        LogUtil.Info("Update WP image load date on Dates table", MyBase.Name)
        UpdateImageDate(TxtImageLoadYr.Text, TxtImageLoadMth.Text, True, TxtImageLoadDay.Text, cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
    End Sub
    Private Sub BtnPageLoadUpd_Click(sender As Object, e As EventArgs) Handles BtnPageLoadUpd.Click
        LogUtil.Info("Update WP page load date on Dates table", MyBase.Name)
        UpdatePageDate(TxtPageLoadYr.Text, TxtPageLoadMth.Text, True, TxtPageLoadDay.Text, cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
    End Sub
    Private Sub BtnImages_Click(sender As Object, e As EventArgs) Handles BtnImages.Click
        Try
            Dim _id As Integer = CInt(lblID.Text)
            If lbPeople.SelectedIndex > -1 AndAlso _id > -1 Then
                ShowStatus("Images",, True)
                Using _update As New FrmImages
                    _update.PersonId = CInt(lblID.Text)
                    _update.ShowDialog()
                    PictureBox1.ImageLocation = _update.ImageFile
                    personTable(lbPeople.SelectedIndex).Image = GetImageById(_id, False)
                End Using
                ShowStatus("")
            Else
                ShowStatus("No person selected")
            End If
        Catch ex As InvalidCastException
            ShowStatus("No person selected")
        End Try

    End Sub
    Private Sub BtnTitleName_Click(sender As Object, e As EventArgs) Handles BtnTitleName.Click
        Dim _parts As List(Of String)
        _parts = ParseStringWithBrackets(txtDesc.Text)
        If _parts.Count > 1 Then
            txtDesc.SelectionStart = 0
            txtDesc.SelectionLength = _parts(0).Trim.Length
            UseTitleName()
        End If
    End Sub
    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        cboMonth.SelectedIndex = -1
        cboDay.SelectedIndex = Today.Day - 1
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub
    Private Sub BtnPasteWikiId_Click(sender As Object, e As EventArgs) Handles BtnPasteWikiId.Click
        TxtWikiId.Paste()
    End Sub
    Private Sub BtnPasteName_Click(sender As Object, e As EventArgs) Handles BtnPasteName.Click
        txtName.Paste()
    End Sub
    Private Sub BtnPasteDesc_Click(sender As Object, e As EventArgs) Handles BtnPasteDesc.Click
        txtDesc.Paste()
    End Sub
    Private Sub BtnPasteShort_Click(sender As Object, e As EventArgs) Handles BtnPasteShort.Click
        TxtShortDesc.Paste()
    End Sub
    Private Sub BtnPasteBirthplace_Click(sender As Object, e As EventArgs) Handles BtnPasteBirthplace.Click
        TxtBirthPlace.Paste()
    End Sub
    Private Sub BtnPasteBirthname_Click(sender As Object, e As EventArgs) Handles BtnPasteBirthname.Click
        TxtBirthName.Paste()
    End Sub
    Private Sub UseNameTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UseNameTextToolStripMenuItem.Click
        UseTitleName()
    End Sub
    Private Sub ShortenNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShortenNameToolStripMenuItem.Click
        If txtDesc.SelectionLength > 0 Then
            TxtBirthName.Text = txtDesc.SelectedText
            RemoveMiddleNames()
        End If
    End Sub
    Private Sub BtnWpDesc_Click(sender As Object, e As EventArgs) Handles BtnWpDesc.Click
        Dim wpText As String = ""
        If lbPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            LogUtil.Info("Generating WordPress description for " & oPerson.Name, MyBase.Name)
            Dim sBorn As String = ""
            If oPerson.BirthName.Length > 0 Or oPerson.BirthPlace.Length > 0 Then
                sBorn = " Born" & If(oPerson.BirthName.Length > 0, " " & oPerson.BirthName, "") & If(oPerson.BirthPlace.Length > 0, " in " & oPerson.BirthPlace, "") & "."
            End If
            Dim sDied As String = " (d. " & CStr(Math.Abs(oPerson.DeathYear)) & If(oPerson.DeathYear < 0, " BCE", "") & ")"
            Dim sText As New StringBuilder
            With sText
                .Append(oPerson.Description)
                .Append(sBorn)
                .Append(If(oPerson.DeathYear = 0, "", sDied))
            End With
            wpText = sText.ToString
        End If
        Clipboard.SetText(wpText)
    End Sub
    Private Sub PasteIntoDesc_Click(MenuItem As Object, e As EventArgs) Handles PasteIntoDesc.Click
        GetSourceControl(MenuItem).Copy()
        txtDesc.Paste()
    End Sub
    Private Sub BtnDateCopy_Click(sender As Object, e As EventArgs) Handles BtnDateCopy.Click
        Dim source As List(Of String) = ParseStringWithBrackets(txtWiki.Text)
        Dim target As List(Of String) = ParseStringWithBrackets(txtDesc.Text)
        If source.Count > 2 And target.Count > 2 Then
            If target(2).StartsWith(" is ", StringComparison.CurrentCultureIgnoreCase) Then
                target(2) = " was " & target(2).Substring(4)
            End If
            txtDesc.Text = target(0) & "(" & source(1) & ")" & target(2)
        End If
    End Sub
    Private Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged,
                                                                            txtForename.TextChanged,
                                                                            txtSurname.TextChanged,
                                                                            txtYear.TextChanged,
                                                                            txtDied.TextChanged,
                                                                            txtDthDay.TextChanged,
                                                                            txtDthMth.TextChanged,
                                                                            txtDesc.TextChanged,
                                                                            TxtShortDesc.TextChanged,
                                                                            TxtBirthPlace.TextChanged,
                                                                            TxtBirthName.TextChanged,
                                                                            TxtWikiId.TextChanged
        If Not bLoadingPerson Then
            Dim _control As TextBox = TryCast(sender, TextBox)
            If _control IsNot Nothing Then
                _control.BackColor = Color.LightYellow
            End If
        End If
    End Sub
    Private Sub BTnRmvBotsd_Click(sender As Object, e As EventArgs) Handles BtnRmvBotsd.Click
        If IsNumeric(lblBotsdId.Text) AndAlso CInt(lblBotsdId.Text) > 0 Then
            UpdateBotsdId(CInt(lblID.Text), 0)
            ShowStatus("Removed BotSD Id", False, True)
            lblBotsdId.Text = 0
        End If
    End Sub
    Private Sub BtnUpdBotsd_Click(sender As Object, e As EventArgs) Handles BtnUpdBotsd.Click
        ShowStatus("Born On The Same Day", False, True)
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = cboDay.SelectedIndex + 1
            _botsd.ThisMonth = cboMonth.SelectedIndex + 1
            _botsd.ShowDialog()
        End Using
        ClearStatus()
    End Sub

#End Region
#Region "subroutines"
    'Form overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing AndAlso personTable IsNot Nothing Then
                For Each oPerson In personTable
                    oPerson.Dispose()
                Next
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
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
        txtWiki.Text = ""
        TxtShortDesc.Text = ""
        txtDied.Text = ""
        txtName.Text = ""
        txtForename.Text = ""
        txtSurname.Text = ""
        txtYear.Text = ""
        LblSortSeq.Text = 0
        PictureBox1.ImageLocation = ""
        TxtBirthName.Text = ""
        TxtBirthPlace.Text = ""
        txtDthDay.Text = ""
        txtDthMth.Text = ""
        txtTwitter.Text = ""
        cbNoTweet.Checked = False
        TxtWikiId.Text = ""
    End Sub
    Private Sub DisplayPersonList()
        lbPeople.Items.Clear()
        For Each oPerson As Person In personTable
            lbPeople.Items.Add(oPerson.BirthYear & " " & oPerson.Name)
        Next
    End Sub
    Private Shared Sub Splitname(ByVal sName As String, ByRef sForename As String, ByRef sSurname As String)
        Dim sWords As List(Of String) = Split(sName, " ").ToList
        If sWords.Count > 0 Then
            sSurname = sWords(sWords.Count - 1)
            sWords.RemoveAt(sWords.Count - 1)
            sForename = String.Join(" ", sWords)
        End If
    End Sub
    Private Sub UpdateAll()
        ShowStatus("Updating all changes onto database",, True)
        Dim lastYear As String = ""
        Dim iSeq As Integer = 0
        For Each oPerson As Person In personTable
            If oPerson.BirthYear = lastYear Then
                iSeq += 1
            Else
                iSeq = 0
                lastYear = oPerson.BirthYear
            End If
            Dim dbAction As String = ""
            If oPerson.Id < 0 Then
                Dim newId As Integer = InsertPerson(oPerson)
                dbAction = "Inserted on dB"
                oPerson.Id = newId
            Else
                If oPerson.UnsavedChanges Then
                    dbAction = "Updated on dB"
                End If
                UpdatePerson(oPerson)
            End If
            If Not String.IsNullOrEmpty(dbAction) Then
                ShowUpdated(oPerson, dbAction)
            End If

            oPerson.UnsavedChanges = False
        Next
        AppendStatus(" - Complete")
    End Sub
    Private Sub TidyAndFix()
        isGotBirthName = False
        isGotStageName = False
        Dim _parts As List(Of String) = TidyText()
        If _parts.Count > 0 Then
            If _parts(0).IndexOf("""", StringComparison.CurrentCultureIgnoreCase) > 0 Then
                _parts(0) = GetNickname(_parts(0))
            End If
        End If
        If _parts.Count = 3 Then
            Dim _datePart As String = ExtractAndRemovePhrases(_parts(1))
            Dim _knownAs As List(Of String) = KnownAs(_parts)
            If _knownAs.Count > 0 And Not isGotBirthName Then
                IsUseAsBirthName(_knownAs(0))
            End If
            _datePart = _datePart.Replace("  ", " ")
            If _datePart.ToLower(myCultureInfo).StartsWith("born ", StringComparison.CurrentCultureIgnoreCase) And _datePart.Contains("-") Then
                _datePart = _datePart.Remove(0, 5)
            End If
            txtDesc.Text = Trim(_parts(0)) & " (" & _datePart & ")" & _parts(2)
        End If
        rtbDesc.Text = txtDesc.Text
    End Sub
    Private Sub ExtractDeathDate(_date As String)
        Dim _deathDate As String = _date.Trim.TrimEnd({"E"c})
        Dim isBC As Boolean = False
        If _deathDate.EndsWith("AD", StringComparison.CurrentCultureIgnoreCase) Then
            _deathDate = _date.TrimEnd({" "c, "A"c, "D"c})
        ElseIf _deathDate.EndsWith("BC", StringComparison.CurrentCultureIgnoreCase) Then
            _deathDate = _date.TrimEnd({" "c, "B"c, "C"c})
            isBC = True
        End If
        If IsDate(_deathDate) Then
            Dim d1 As Date = CDate(_deathDate)
            txtDthDay.Text = Format(d1, "dd")
            txtDthMth.Text = Format(d1, "MM")
            Dim _inx = Len(_deathDate) - 1
            Do Until _inx < 0 OrElse Not IsNumeric(_deathDate.Substring(_inx, 1))
                _inx -= 1
            Loop
            txtDied.Text = If(isBC, "-", "") & _deathDate.Substring(_inx + 1)
        End If
    End Sub
    Private Sub SwapText(ByVal currentVal As String)
        If currentVal = "RTB" Then
            rtbDesc.Text = txtDesc.Text
            rtbDesc.Visible = True
            txtDesc.Visible = False
            btnRTB.Text = My.Resources.TEXT
        Else
            txtDesc.Text = rtbDesc.Text
            rtbDesc.Visible = False
            txtDesc.Visible = True
            btnRTB.Text = My.Resources.RTB
        End If
    End Sub
    Private Sub LoadScreenFromId(ByVal oId As Integer)
        Dim oPerson As Person = GetFullPersonById(oId)
        If oPerson IsNot Nothing Then
            findPersonInList = oPerson.Id
            cboDay.SelectedIndex = oPerson.BirthDay - 1
            cboMonth.SelectedIndex = oPerson.BirthMonth - 1
        Else
            ShowStatus("Id not found")
        End If
        oPerson.Dispose()
    End Sub
    Private Sub LoadScreenFromPerson(oPerson As Person)
        bLoadingPerson = True
        ResetBackgroundColors()
        lblID.Text = oPerson.Id
        txtForename.Text = oPerson.ForeName
        txtSurname.Text = oPerson.Surname
        txtDesc.Text = oPerson.Description
        TxtShortDesc.Text = oPerson.ShortDesc
        txtYear.Text = CStr(oPerson.BirthYear)
        LblSortSeq.Text = CStr(oPerson.Sortseq)
        txtDied.Text = CStr(oPerson.DeathYear)
        txtDthDay.Text = CStr(oPerson.DeathDay)
        txtDthMth.Text = CStr(oPerson.DeathMonth)
        TxtBirthName.Text = oPerson.BirthName
        TxtBirthPlace.Text = oPerson.BirthPlace
        txtName.Text = MakeFullName(oPerson.ForeName, oPerson.Surname)
        Dim sYear As String = TxtImageLoadYr.Text
        Dim sMth As String = TxtImageLoadMth.Text
        If oPerson.Image IsNot Nothing Then
            PictureBox1.ImageLocation = Path.Combine(My.Settings.ImgPath, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
        End If
        If oPerson.Social IsNot Nothing Then
            txtTwitter.Text = If(oPerson.Social.TwitterHandle, "")
            cbNoTweet.Checked = oPerson.Social.IsNoTweet
            TxtWikiId.Text = oPerson.Social.WikiId
            lblBotsdId.Text = oPerson.Social.Botsd
        End If
        txtWiki.Text = GetWikiText(NudSentences.Value, oPerson.ForeName, oPerson.Surname, TxtWikiId.Text)
        ResetBackgroundColors()
        bLoadingPerson = False
    End Sub
    Private Sub ShowStatus(pText As String, Optional isAppend As Boolean = False, Optional isLogged As Boolean = False)
        lblStatus.Text = If(isAppend, lblStatus.Text, "") & pText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(pText, MyBase.Name)
    End Sub
    Private Sub AppendStatus(pText As String, Optional isLogged As Boolean = False)
        ShowStatus(pText, True, isLogged)
    End Sub
    Private Sub ClearStatus()
        ShowStatus("", False)
    End Sub
    Private Sub RemoveMiddleWordsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        If txtDesc.SelectionLength > 0 Then
            RemoveMiddleNames()
        End If
    End Sub
    Private Sub RemoveMiddleNames()
        Dim _selStart As Integer = txtDesc.SelectionStart
        Dim _selLength As Integer = txtDesc.SelectionLength
        Dim _words As List(Of String) = Split(txtDesc.SelectedText.Trim(), " ").ToList
        Dim sShortname As String = _words.First & If(_words.Count > 1, " " & _words.Last, "")
        txtDesc.SelectionStart = _selStart
        txtDesc.SelectionLength = _selLength
        txtDesc.Cut()
        txtDesc.Paste(sShortname)
    End Sub
    Private Sub UseTitleName()
        If txtDesc.SelectionLength > 0 Then
            Dim _selStart As Integer = txtDesc.SelectionStart
            Dim _selLength As Integer = txtDesc.SelectionLength
            Dim sShortname As String = txtName.Text
            TxtBirthName.Text = txtDesc.SelectedText
            txtDesc.SelectionStart = _selStart
            txtDesc.SelectionLength = _selLength
            txtDesc.Cut()
            txtDesc.Paste(sShortname)
        End If
    End Sub
    Private Sub ShowUpdated(aPerson As Person, dbAction As String)
        LblUpdated.Visible = True
        Dim iListMatches As Integer = LbUpdateList.FindString(aPerson.Name)
        Dim msgText As String = aPerson.Name & " " & dbAction
        If iListMatches = ListBox.NoMatches Then
            LblUpdated.Visible = True
            LbUpdateList.Visible = True
            LbUpdateList.Items.Add(msgText)
        Else
            LbUpdateList.Items(iListMatches) = msgText
        End If
        LogUtil.Info(msgText, MyBase.Name)
    End Sub

#End Region
#Region "functions"
    Private Shared Function MakeFullName(pForename As String, pSurname As String) As String
        Return If(String.IsNullOrEmpty(pForename), "", pForename.Trim & " ") & pSurname.Trim
    End Function
    Private Function GetNickname(ByRef sName As String) As String
        Dim names As String() = Split(sName, """")
        Dim sReturnName As String = sName
        If names.Length > 2 Then
            Dim sNickName As String = names(1).Trim & names(2)
            Dim sNoNickName As String = Trim(names(0).Trim & names(2))
            If MsgBox("Use " & sNickName.Trim & " as name and " & sNoNickName.Substring(0, Math.Min(40, sNoNickName.Length)) & " as birthname?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Nickname") = MsgBoxResult.Yes Then
                TxtBirthName.Text = sNoNickName
                sReturnName = sNickName
                isGotBirthName = True
            End If
        End If
        Return sReturnName
    End Function
    Private Function ExtractAndRemovePhrases(ByVal _innerText As String) As String
        Dim _dateString As String = ""
        _innerText = _innerText.Trim(New Char() {";", " "})
        Dim _phrases As String() = Split(_innerText, ";")
        If _phrases.Length = 1 Then
            Return _innerText
            Exit Function
        End If
        Dim _phraseNumber As Integer = 0
        For Each _phrase As String In _phrases
            _phraseNumber += 1
            Dim _wordList As List(Of String) = Split(Trim(_phrase), " ").ToList
            Dim isRemove As MsgBoxResult

            If ExtractNameandPlace(_wordList, _phraseNumber) Then
                isRemove = MsgBoxResult.Yes
            Else
                isRemove = MsgBox(_innerText & vbCrLf & vbCrLf & "Remove: " & _phrase & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Remove phrase")
            End If
            If isRemove = MsgBoxResult.No Then
                _dateString &= _phrase & ";"
            Else
                If _wordList.First.ToLower(myCultureInfo) = "born" Then
                    _dateString &= "born "
                End If
            End If
        Next
        Return _dateString.Trim(";").Trim()
    End Function
    Private Function ExtractNameandPlace(_words As List(Of String), _phraseNumber As Integer) As Boolean
        Dim isExtract As Boolean = False
        Dim isNamePart As Boolean = (_phraseNumber = 1)
        Dim isPlacePart As Boolean = (_phraseNumber = 3)
        Dim _name As String = ""
        Dim _place As String = ""
        For Each _word As String In _words
            Select Case _word.ToLower(myCultureInfo)
                Case "born"
                    isNamePart = True
                    isPlacePart = False
                Case "in"
                    isNamePart = False
                    isPlacePart = True
                Case "at"
                    isNamePart = False
                    isPlacePart = True
                Case "on"
                    isNamePart = False
                    isPlacePart = False
                Case "as"
                    isNamePart = True
                    isPlacePart = False
                Case Else
                    If isNamePart Then
                        _name &= _word & " "
                    End If
                    If isPlacePart Then
                        _place &= _word & " "
                    End If
            End Select
        Next
        If IsDate(_name) Or IsDate(_place) Then
            _name = ""
            _place = ""
        End If
        If Not String.IsNullOrEmpty(_name.Trim()) Then
            isExtract = IsUseAsBirthName(_name.Trim())
        End If
        If Not String.IsNullOrEmpty(_place.Trim()) Then
            isExtract = IsUseAsBirthPlace(_place.Trim())
        End If
        Return isExtract
    End Function
    Private Function TidyText() As List(Of String)
        Dim newText As String = RemoveSquareBrackets(FixQuotesAndHyphens(txtDesc.Text))
        Dim _parts As List(Of String) = ParseStringWithBrackets(newText)
        Dim charsToTrim() As Char = {" "c, ","c, ";"c, "."c, "["c}
        Dim charsToTrim2() As Char = {" "c, ","c, ";"c, "["c}
        If _parts.Count = 3 Then
            Dim dateRange As String = _parts(1)
            Dim _dates As String() = Split(dateRange, " - ")
            If _dates.Length = 2 Then
                ExtractDeathDate(_dates(1))
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
        txtForename.Text = txtForename.Text.Trim(charsToTrim2)
        txtSurname.Text = txtSurname.Text.Trim(charsToTrim)
        Dim newShortText = RemoveSquareBrackets(FixQuotesAndHyphens(TxtShortDesc.Text)).Trim(charsToTrim)
        TxtShortDesc.Text = newShortText & If(newShortText.Length > 0, ".", "")
        TxtBirthName.Text = RemoveSquareBrackets(FixQuotesAndHyphens(TxtBirthName.Text, False).Replace(",", "").Replace(".", "").Replace(";", "")).Trim(charsToTrim)
        TxtBirthPlace.Text = RemoveSquareBrackets(FixQuotesAndHyphens(TxtBirthPlace.Text, False).Replace(".", "").Replace(";", "")).Trim(charsToTrim)
        txtTwitter.Text = RemoveBadCharacters(txtTwitter.Text, {8207}).Trim
        rtbDesc.Text = txtDesc.Text
        Return _parts
    End Function
    Private Function IsUseAsBirthName(_birthName As String) As Boolean
        Dim isUsed As Boolean = False
        If MsgBox("Use " & _birthName & " as birthname?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Birth name") = MsgBoxResult.Yes Then
            TxtBirthName.Text = _birthName
            isGotBirthName = True
            isUsed = True
        End If
        Return isUsed
    End Function
    Private Function IsUseAsBirthPlace(_birthPlace As String) As Boolean
        Dim isUsed As Boolean = False
        If MsgBox("Use " & _birthPlace & " as birthplace?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Birth place") = MsgBoxResult.Yes Then
            TxtBirthPlace.Text = _birthPlace
            isUsed = True
        End If
        Return isUsed
    End Function
    Private Shared Function KnownAs(ByRef _parts As List(Of String)) As List(Of String)
        Dim _foundNames As New List(Of String)(2)
        Dim _birthName As String = Trim(_parts(0))
        Dim _stageName As String = ""
        If _parts(2).ToLower(myCultureInfo).Contains("known ") Then
            Dim _knownString As String = _parts(2).Substring(_parts(2).IndexOf("known", StringComparison.CurrentCultureIgnoreCase))
            If _knownString.ToLower(myCultureInfo).Contains(" as ") Then
                Dim _knownParts As List(Of String) = ParseStringWithString(_knownString, " as ")
                Dim _nameParts As List(Of String) = ParseStringWithChar(_knownParts(1), ",")
                _stageName = Trim(_nameParts(0))
            End If
        End If
        If Not String.IsNullOrEmpty(_stageName) Then
            If _stageName.ToLower(myCultureInfo) <> _birthName.ToLower(myCultureInfo) Then
                If MsgBox("Replace " & _birthName & " with " & _stageName & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Known as") = MsgBoxResult.Yes Then
                    _parts(0) = _stageName
                    _parts = RemoveKnownAs(_parts, _stageName)
                    'txtDesc.Text = Join(_parts.ToArray, "(")
                    _foundNames.Add(_birthName)
                    _foundNames.Add(_stageName)
                Else
                    If MsgBox("Remove known as ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Known as") = MsgBoxResult.Yes Then
                        _parts = RemoveKnownAs(_parts, _stageName)
                    End If
                End If
            Else
                _parts = RemoveKnownAs(_parts, _stageName)
            End If
        End If
        Return _foundNames
    End Function
    Private Shared Function RemoveKnownAs(_parts As List(Of String), _stageName As String) As List(Of String)
        _parts(2) = _parts(2).Replace(_stageName & ",", "").Replace("commonly ", "").Replace("professionally ", "").Replace("better ", "").Replace("also ", "").Replace(", known as ", "")
        Return _parts
    End Function
    Private Sub SwapPersons(fromIx As Integer, toIx As Integer)
        Dim thisperson As New Person(personTable(fromIx))
        Dim thatPerson As New Person(personTable(toIx))
        Dim isseq As Integer = thatPerson.Sortseq
        If thatPerson.IBirthYear = thisperson.IBirthYear Then
            thatPerson.Sortseq = thisperson.Sortseq
            thisperson.Sortseq = isseq
            thatPerson.UnsavedChanges = True
            thisperson.UnsavedChanges = True
            personTable(toIx) = thisperson
            personTable(fromIx) = thatPerson
            DisplayPersonList()
            lbPeople.SelectedIndex = toIx
            LblSortSeq.Text = CStr(thisperson.Sortseq)
        End If
        thatPerson.Dispose()
        thisperson.Dispose()
    End Sub
    Private Sub ResetBackgroundColors()
        For Each _control As Control In Me.Controls
            Dim _textbox As TextBox = TryCast(_control, TextBox)
            If _textbox IsNot Nothing Then
                _textbox.BackColor = SystemColors.Window
            End If
        Next
    End Sub
    Private Function UpdateSortSeq(newPerson As Person, p As Integer) As Person
        Dim prevPerson As Person = If(p = 0, Nothing, personTable(p - 1))
        If prevPerson IsNot Nothing AndAlso prevPerson.IBirthYear = newPerson.IBirthYear Then
            newPerson.Sortseq = prevPerson.Sortseq + 1
            prevPerson.Dispose()
        End If
        Return newPerson
    End Function

#End Region
End Class
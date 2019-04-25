Imports System.Text
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Configuration

Public Class frmMain
    Dim oTwta As New CelebrityBirthdayDataSetTableAdapters.SocialMediaTableAdapter
    Dim oTwtable As New CelebrityBirthdayDataSet.SocialMediaDataTable

    Dim aTagStart As String = "<a href=""http://celebritybirthday.files.wordpress.com/"
    Dim aTagEnd As String = """>"
    Dim imgTagStart As String = "<img title="""
    Dim imgTagMiddle As String = """ src=""http://celebritybirthday.files.wordpress.com/"
    Dim imgTagEnd As String = """ alt="""" width=""60"" height=""60"" />"
    Dim strongTagStart As String = "</a> <strong>"
    Dim strongTagEnd As String = "</strong>"
    Dim excerptStart As String = "Today's Birthdays:<br />"
    Dim excerptDiv As String = "<div style=""width:200px;float:left;font-family:arial;font-size:12px;"">"
    Dim excerptDivEnd As String = "</div>"
    Dim urlYear As String = "2013"
    Dim urlMonth As String = "03"
    Dim galleryText As String = ""
    Dim personTable As List(Of Person)
    '   Dim oWebBrowser As frmWebImageSearch = Nothing
    Dim bLoadingPerson As Boolean = False
    Dim _search As frmSearchDb = Nothing
    Dim _twitter As frmTwitterOutput = Nothing
    Dim MouseIsDown As Boolean = False

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        CloseForm()
    End Sub

    Private Sub CloseForm()
        Dim resp As MsgBoxResult = MsgBoxResult.No
        If CheckForChanges(personTable) Then
            resp = MsgBox("Save changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel, "Unsaved Changes")
        End If
        Select Case resp
            Case MsgBoxResult.Yes
                BtnUpdateAll_Click(Nothing, Nothing)
                Me.Close()
            Case MsgBoxResult.No
                Me.Close()
            Case MsgBoxResult.Cancel
            Case Else
        End Select
    End Sub


    Private Sub GetUrlDate(ByRef Id As Integer)

        If txtCurrentText.TextLength > 0 Then
            Dim currParts1 As String() = Split(txtCurrentText.Text, "<h3>")
            If currParts1.Length > 1 Then
                Dim entry1 As String = currParts1(1)
                Dim url1 As String() = Split(entry1, ".com")
                Dim entry11 As String = url1(1)
                Dim url11 As String() = Split(entry11, ".")
                Dim date1 As String() = Split(url11(0), "/")
                urlYear = date1(1)
                urlMonth = date1(2)
            End If
        Else

            urlYear = txtLoadYr.Text
            urlMonth = txtLoadMth.Text

            GetAlternateImageDate(urlYear, urlMonth, Id)
        End If

    End Sub

    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCurrentExcerpt.DragDrop,
                                                                                                                           txtCurrentText.DragDrop,
                                                                                                                           txtDesc.DragDrop,
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
        ' getGalleryText()
    End Sub

    Private Sub TextBox_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCurrentExcerpt.DragOver,
                                                                                                                           txtCurrentText.DragOver,
                                                                                                                           txtDesc.DragOver,
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

    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles txtCurrentExcerpt.DragEnter,
                                                                                                                           txtCurrentText.DragEnter,
                                                                                                                           txtDesc.DragEnter,
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

    'Private Sub TextBox_mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCurrentExcerpt.MouseDown, _
    '                                                                                                                txtCurrentText.MouseDown, _
    '                                                                                                                txtDied.MouseDown, _
    '                                                                                                                txtName.MouseDown, _
    '                                                                                                                txtYear.MouseDown, _
    '                                                                                                                txtForename.MouseDown, _
    '                                                                                                                txtSurname.MouseDown, _
    '                                                                                                                txtBirthName.MouseDown, _
    '                                                                                                                txtBirthPlace.MouseDown
    '    MouseIsDown = True
    'End Sub

    'Private Sub TextBox_mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCurrentExcerpt.MouseMove, _
    '                                                                                                                           txtCurrentText.MouseMove, _
    '                                                                                                                           txtDied.MouseMove, _
    '                                                                                                                           txtName.MouseMove, _
    '                                                                                                                           txtYear.MouseMove, _
    '                                                                                                                           txtForename.MouseMove, _
    '                                                                                                                           txtSurname.MouseMove, _
    '                                                                                                                           txtBirthName.MouseMove, _
    '                                                                                                                           txtBirthPlace.MouseMove
    '    Dim oBox As TextBox = CType(sender, TextBox)
    '    If MouseIsDown Then
    '         Initiate dragging.
    '        oBox.DoDragDrop(oBox.Text, DragDropEffects.Copy)
    '    End If
    '    MouseIsDown = False
    'End Sub

    Private Sub BtnCopyFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyFull.Click
        My.Computer.Clipboard.SetText(txtCurrentText.Text)

    End Sub

    Private Sub BtnCopyExcerpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyExcerpt.Click
        My.Computer.Clipboard.SetText(txtCurrentExcerpt.Text)

    End Sub

    Private Sub BtnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        personTable = New List(Of Person)
        If txtCurrentText.TextLength = 0 Or cboDay.SelectedIndex < 0 Or cboMonth.SelectedIndex < 0 Then
        Else
            GetGalleryText()
            Dim sText As String = txtCurrentText.Text.Trim.Replace(vbCr, "").Replace(vbLf, "")
            Dim currParts As String() = Split(sText, "<h3>")
            For Each currPart As String In currParts
                Dim entries As String() = Split(currPart, "<img")

                Dim sYr As String = entries(0).Split("<")(0)
                If sYr.ToLower.Contains("bc") Then
                    sYr = "-" & sYr.ToLower.Replace("bc", "").Trim
                End If

                For en As Integer = 1 To entries.Length - 1
                    Dim entry As String = entries(en)
                    entry = entry.Replace("<strong>", "|").Replace("</strong>", "|")
                    Dim lines As String() = Split(entry, "|")
                    Dim imgTag As String = lines(0).Trim
                    Dim imgTagParts As String() = Split(imgTag, "/")
                    Dim sImg As String = imgTagParts(imgTagParts.Count - 3)
                    sImg = sImg.Split("?")(0)
                    sImg = sImg.Split("""")(0)
                    Dim sImgType As String = Path.GetExtension(sImg)
                    Dim simgName As String = Path.GetFileNameWithoutExtension(sImg)
                    Dim sName As String = lines(1).Trim
                    Dim sDesc As String = RemoveTags(lines(2).Trim)
                    Dim sDdStart As Int16 = sDesc.IndexOf("(d.")

                    Dim sDd As String = ""
                    If sDdStart >= 0 Then
                        sDd = Split(Split(sDesc, "(d.")(1), ")")(0).Trim
                    End If
                    sDesc = Split(sDesc, "(d.")(0).Trim

                    Dim sForename As String = ""
                    Dim sSurname As String = ""
                    Splitname(sName, sForename, sSurname)
                    Dim sDeathYear As Integer
                    Try
                        sDeathYear = Integer.Parse(sDd)
                    Catch ex As Exception
                        sDeathYear = 0
                    End Try
                    Dim sShortDesc As String = Split(sDesc, ".")(0) & "."
                    Dim oPerson As Person = New Person(sForename, sSurname, sDesc, sShortDesc, cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, sYr, sDeathYear, 0, 0, "", "", Nothing, Nothing)

                    personTable.Add(oPerson)
                Next
            Next
        End If
        DisplayPersonlList()
        btnLoad.Font = New Font(btnLoad.Font, FontStyle.Regular)

    End Sub
    Private Sub Splitname(ByVal sName As String, ByRef sForename As String, ByRef sSurname As String)
        Dim sWords As String() = Split(sName, " ")
        If sWords.Length > 0 Then
            If sWords.Length = 1 Then
                sSurname = sWords(0)
                sForename = ""
            Else
                sSurname = sWords(sWords.Length - 1)
                ReDim Preserve sWords(sWords.Length - 2)
                sForename = Join(sWords, " ")
            End If
        End If
    End Sub
    Private Sub GetGalleryText()
        Dim sText As String = txtCurrentText.Text.Trim
        Dim currParts As String() = Split(sText, "<h3>")
        If currParts(0).StartsWith("[gallery") Then
            galleryText = currParts(0)
        End If
    End Sub
    Private Sub BtnClrExcerpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrExcerpt.Click
        txtCurrentExcerpt.Text = ""
    End Sub

    Private Sub BtnClrCurr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrCurr.Click
        txtCurrentText.Text = ""
    End Sub

    Private Sub BtnClrNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrNew.Click
        ClearDetails()
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
        txtImgName.Text = ""
        cbImgType.SelectedIndex = 0
        PictureBox1.ImageLocation = ""
        PictureBox2.ImageLocation = ""
        txtBirthName.Text = ""
        txtBirthPlace.Text = ""
        txtDthDay.Text = ""
        txtDthMth.Text = ""
        txtTwitter.Text = ""
        cbNoTweet.Checked = False
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
                                            New SocialMedia()) With {
                                                .UnsavedChanges = True
                                            }
                Dim bInserted As Boolean = False
                For ix As Integer = 0 To personTable.Count - 1
                    Dim aPerson As Person = personTable(ix)
                    If aPerson.BirthYear > newPerson.BirthYear Then
                        personTable.Insert(ix, newPerson)
                        bInserted = True
                        Exit For
                    End If
                Next
                Dim p As Integer = -1
                If Not bInserted Then
                    p = personTable.Count
                    personTable.Add(newPerson)
                End If
                DisplayPersonlList()
                lbPeople.SelectedIndex = p
            Catch ex As Exception
                MsgBox("Error on insert", MsgBoxStyle.Exclamation, "Insert error")
                lblStatus.Text = ex.Message
            End Try

        Else
            MsgBox("No date selected", MsgBoxStyle.Exclamation, "Insert error")
        End If
    End Sub
    Private Sub DisplayPersonlList()
        lbPeople.Items.Clear()
        For Each oPerson As Person In personTable
            lbPeople.Items.Add(oPerson.BirthYear & " " & oPerson.Name)
        Next
    End Sub

    Private Sub TxtCurrentText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentText.TextChanged
        btnLoad.Font = New Font(btnLoad.Font, FontStyle.Bold)
        galleryText = ""
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim oPerson As Person = Nothing
        If lbPeople.SelectedIndex >= 0 Then
            oPerson = personTable(lbPeople.SelectedIndex)
            If oPerson.Id > 0 Then
                DeleteTwitterHandle(oPerson.Id)
                DeletePerson(oPerson.Id)
            End If

            personTable.RemoveAt(lbPeople.SelectedIndex)
        End If
        DisplayPersonlList()
    End Sub

    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim ix As Integer = -1
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
                DisplayPersonlList()
                lbPeople.SelectedIndex = ix - 1
            End If

        End If
    End Sub

    Private Sub BtnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim ix As Integer = -1
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
                DisplayPersonlList()
                lbPeople.SelectedIndex = ix + 1
            End If

        End If
    End Sub

    Private Sub BtnGenFullText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenFullText.Click
        Dim bOK As Boolean = True
        If lbPeople.Items.Count = 0 Then
            bOK = False
        End If
        If bOK Then


            Dim lastYear As String = ""
            Dim newText As New StringBuilder(galleryText)
            For Each oPerson As Person In personTable
                GetUrlDate(oPerson.Id)
                If oPerson.BirthYear <> lastYear Then
                    newText.Append("<h3>").Append(oPerson.BirthYear).Append("</h3>").Append(vbCrLf)
                    lastYear = oPerson.BirthYear
                End If
                Dim lowername As String = oPerson.Image.ImageFileName
                If lowername.Length = 0 Then
                    lowername = oPerson.Name.ToLower.Replace(" ", "-").Replace(".", "")
                End If
                Dim sBorn As String = ""
                If oPerson.BirthName.Length > 0 Or oPerson.BirthPlace.Length > 0 Then
                    sBorn = " Born" & If(oPerson.BirthName.Length > 0, " " & oPerson.BirthName, "") & If(oPerson.BirthPlace.Length > 0, " in " & oPerson.BirthPlace, "") & "."
                End If
                Dim sDied As String = " (d. " & CStr(oPerson.DeathYear) & ")"
                With newText
                    .Append(aTagStart)
                    .Append(urlYear)
                    .Append("/")
                    .Append(urlMonth)
                    .Append("/")
                    .Append(lowername)
                    .Append(oPerson.Image.ImageFileType)
                    .Append(aTagEnd)
                    .Append(imgTagStart)
                    .Append(oPerson.Name)
                    .Append(imgTagMiddle)
                    .Append(urlYear)
                    .Append("/")
                    .Append(urlMonth)
                    .Append("/")
                    .Append(lowername)
                    .Append(oPerson.Image.ImageFileType)
                    .Append(imgTagEnd)
                    .Append(strongTagStart)
                    .Append(oPerson.Name)
                    .Append(strongTagEnd)
                    .Append(vbCrLf)
                    .Append(oPerson.Description)
                    .Append(sBorn)
                    .Append(If(oPerson.DeathYear = 0, "", sDied))
                    .Append(vbCrLf)
                End With
            Next
            txtCurrentText.Text = newText.ToString
            GetGalleryText()
        End If
    End Sub

    Private Sub BtnGenExcerpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenExcerpt.Click
        Dim bOK As Boolean = True
        Dim listRem As Integer
        Dim listSize As Integer
        Dim pList As New List(Of Person)
        pList.AddRange(personTable)
        If lbPeople.Items.Count = 0 Then
            bOK = False
        Else
            listRem = lbPeople.Items.Count Mod 3
            listSize = Int(lbPeople.Items.Count / 3)
            If listRem > 0 Then
                If listRem = 1 Then
                    pList.Insert((listSize * 2) + 1, New Person)
                End If
                pList.Add(New Person)
                listSize += 1
            End If
        End If
        If bOK Then
            Dim newText As New StringBuilder(excerptStart)
            newText.Append(vbCrLf)
            Dim iCt As Integer = 0
            For Each oPerson As Person In pList
                If iCt = 0 Then
                    newText.Append(excerptDiv).Append(vbCrLf)
                End If
                With newText
                    .Append(oPerson.Name)
                    .Append("<br />")
                    .Append(vbCrLf)
                End With
                iCt += 1
                If iCt = listSize Then
                    newText.Append(excerptDivEnd).Append(vbCrLf)
                    iCt = 0
                End If
            Next
            txtCurrentExcerpt.Text = newText.ToString
        End If
    End Sub

    Public Sub BtnMakeImgName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeImgName.Click
        txtImgName.Text = MakeImageName(txtForename.Text, txtSurname.Text)
    End Sub

    Private Sub BtnUpdateAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateAll.Click
        lblStatus.Text = "Updating Database"
        Me.Refresh()
        Dim oTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
        Dim oTable As New CelebrityBirthdayDataSet.PersonDataTable
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
                Dim newId As Integer = oTa.InsertPerson(oPerson.ForeName, oPerson.Surname, CInt(oPerson.BirthYear), oPerson.BirthMonth, oPerson.BirthDay, oPerson.DeathYear,
                oPerson.ShortDesc, oPerson.Description, iSeq, Today.Date, oPerson.BirthPlace, oPerson.BirthName, oPerson.DeathMonth, oPerson.DeathDay)
                oPerson.Id = newId
                InsertSocialMedia(newId, oPerson.Social.TwitterHandle, oPerson.Social.IsNoTweet)
            Else
                oTa.UpdatePerson(oPerson.ForeName, oPerson.Surname, CInt(oPerson.BirthYear), oPerson.BirthMonth, oPerson.BirthDay, oPerson.DeathYear,
                 oPerson.ShortDesc, oPerson.Description, iSeq, oPerson.BirthPlace, oPerson.BirthName, oPerson.DeathMonth, oPerson.DeathDay, oPerson.Id)
                UpdateSocialMedia(oPerson.Id, oPerson.Social.TwitterHandle, oPerson.Social.IsNoTweet)
            End If
            oPerson.UnsavedChanges = False
        Next
        If cbDateAmend.Checked Then
            UpdateDate()
        End If
        oTable.Dispose()
        oTa.Dispose()
        oTable = Nothing
        oTa = Nothing
        lblStatus.Text += " - Complete"

    End Sub

    Private Sub BtnLoadTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTable.Click, cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        lblStatus.Text = ""
        Dim resp As MsgBoxResult = MsgBoxResult.No
        If CheckForChanges(personTable) Then
            If MsgBox("Save unsaved changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Unsaved Changes") = MsgBoxResult.Yes Then
                BtnUpdateAll_Click(sender, e)
            End If
        End If

        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            lblStatus.Text = "Loading Table From Database"
            Me.Refresh()
            personTable = New List(Of Person)
            lbPeople.Items.Clear()
            Dim sYear As String = ""
            Dim sMonth As String = ""
            Dim sDay As String = ""

            Dim oDta As New CelebrityBirthdayDataSetTableAdapters.DatesTableAdapter
            Dim oDtable As New CelebrityBirthdayDataSet.DatesDataTable

            Dim iCt As Integer = oDta.FillByDate(oDtable, cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)

            Dim bAmended As Boolean = False
            If iCt = 1 Then
                Dim oDrow As CelebrityBirthdayDataSet.DatesRow = oDtable.Rows(0)
                If oDrow.IsuploadyearNull = False Then
                    sYear = oDrow.uploadyear
                End If
                If oDrow.IsuploadmonthNull = False Then
                    sMonth = oDrow.uploadmonth
                End If
                If oDrow.IsuploaddayNull = False Then
                    sDay = oDrow.uploadday
                End If
                bAmended = oDrow.amended
            End If

            txtLoadMth.Text = sMonth
            txtLoadYr.Text = sYear
            txtLoadDay.Text = sDay
            cbDateAmend.Checked = bAmended
            Dim oTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
            Dim oTable As New CelebrityBirthdayDataSet.PersonDataTable
            oTa.FillByMonthDay(oTable, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In oTable.Rows
                Dim oPerson As Person = New Person(oRow, New SocialMedia(GetSocialMedia(oRow.id)), New ImageIdentity(GetImageById(oRow.id)))
                personTable.Add(oPerson)
                lbPeople.Items.Add(oPerson.BirthYear & " " & oPerson.Name)
            Next

            oDta.Dispose()
            oDtable.Dispose()
            oDta = Nothing
            oDtable = Nothing

            oTable.Dispose()
            oTa.Dispose()
            oTable = Nothing
            oTa = Nothing
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
                    Dim oTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
                    Dim oTable As New CelebrityBirthdayDataSet.PersonDataTable
                    Dim iCt As Integer = oTa.FillById(oTable, oPerson.Id)
                    If iCt = 1 Then
                        Dim oRow As CelebrityBirthdayDataSet.PersonRow = oTable.Rows(0)
                        Dim newPerson As Person = New Person(oRow, New SocialMedia(GetSocialMedia(oRow.id)), New ImageIdentity(GetImageById(oRow.id)))
                        personTable(lbPeople.SelectedIndex) = newPerson
                        lbPeople.Items(lbPeople.SelectedIndex) = newPerson.BirthYear & " " & newPerson.Name
                    End If
                    oTable.Dispose()
                    oTa.Dispose()
                    oTable = Nothing
                    oTa = Nothing
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
            lblID.Text = oPerson.Id
            txtForename.Text = oPerson.ForeName
            txtSurname.Text = oPerson.Surname
            txtDesc.Text = oPerson.Description
            txtShortDesc.Text = oPerson.ShortDesc
            txtYear.Text = CStr(oPerson.BirthYear)
            txtDied.Text = CStr(oPerson.DeathYear)
            txtDthDay.Text = oPerson.DeathDay
            txtDthMth.Text = oPerson.DeathMonth
            txtImgName.Text = oPerson.Image.ImageFileName
            cbImgType.SelectedIndex = cbImgType.FindString(oPerson.Image.ImageFileType)
            txtBirthName.Text = oPerson.BirthName
            txtBirthPlace.Text = oPerson.BirthPlace
            txtTwitter.Text = oPerson.Social.TwitterHandle
            cbNoTweet.Checked = oPerson.Social.IsNoTweet
            txtName.Text = Trim(oPerson.ForeName & " " & oPerson.Surname)
            Dim sYear As String = txtLoadYr.Text
            Dim sMth As String = txtLoadMth.Text
            GetAlternateImageDate(sYear, sMth, oPerson.Id)
            Try
                Dim sSimplename As String = ToSimpleCharacters(Trim(oPerson.ForeName & " " & oPerson.Surname))
                Dim fName1 As String = Path.Combine(My.Settings.ImgFolder, sSimplename & oPerson.Image.ImageFileType)
                Dim fName2 As String = Path.Combine(My.Settings.ImgFolder, oPerson.Image.ImageFileName.Trim & oPerson.Image.ImageFileType)
                PictureBox1.ImageLocation = ""
                PictureBox2.ImageLocation = ""
                If fName1.ToLower <> fName2.ToLower Then
                    If My.Computer.FileSystem.FileExists(fName1) Then
                        If My.Computer.FileSystem.FileExists(fName2) = False Then
                            lblStatus.Text = "Renaming image file"
                            My.Computer.FileSystem.RenameFile(fName1, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
                        Else
                            lblStatus.Text = "Deleting image file"
                            My.Computer.FileSystem.DeleteFile(fName1)
                        End If
                    End If
                End If
                PictureBox1.ImageLocation = "http://celebritybirthday.files.wordpress.com/" & sYear & "/" & sMth & "/" & oPerson.Image.ImageFileName & oPerson.Image.ImageFileType
                If Not My.Computer.FileSystem.FileExists(fName2) Then
                    SavePic()
                End If
                PictureBox2.ImageLocation = fName2
            Catch ex As Exception
                lblStatus.Text = ex.Message
            End Try
        Else
            ClearDetails()
        End If
        bLoadingPerson = False
    End Sub

    Private Sub GetAlternateImageDate(ByRef sYear As String, ByRef sMonth As String, ByVal Id As Integer)

        Dim oIta As New CelebrityBirthdayDataSetTableAdapters.ImageTableAdapter
        Dim oITable As New CelebrityBirthdayDataSet.ImageDataTable

        Dim ict As Integer = oIta.FillById(oITable, Id)
        If ict = 1 Then
            Dim oIRow As CelebrityBirthdayDataSet.ImageRow = oITable.Rows(0)

            If oIRow.IsimgloadyrNull = False Then
                sYear = oIRow.imgloadyr
            End If
            If oIRow.IsimgloadmonthNull = False Then
                sMonth = oIRow.imgloadmonth
            End If

        End If

        oITable.Dispose()
        oIta.Dispose()
    End Sub

    Private Sub BtnUpdateSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSel.Click
        lblStatus.Text = ""
        If lbPeople.SelectedIndex >= 0 Then
            lblStatus.Text = "Updating Database"
            Me.Refresh()
            Dim oTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
            Dim oTable As New CelebrityBirthdayDataSet.PersonDataTable
            Dim iSeq As Integer = 0
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            If oPerson.Id < 0 Then
                Dim newId As Integer = oTa.InsertPerson(oPerson.ForeName, oPerson.Surname, CInt(oPerson.BirthYear), oPerson.BirthMonth, oPerson.BirthDay, oPerson.DeathYear,
                oPerson.ShortDesc, oPerson.Description, iSeq, Today.Date, oPerson.BirthPlace, oPerson.BirthName, oPerson.DeathMonth, oPerson.DeathDay)
                oPerson.Id = newId
                InsertSocialMedia(newId, oPerson.Social.TwitterHandle, oPerson.Social.IsNoTweet)
            Else
                oTa.UpdatePerson(oPerson.ForeName, oPerson.Surname, CInt(oPerson.BirthYear), oPerson.BirthMonth, oPerson.BirthDay, oPerson.DeathYear,
                 oPerson.ShortDesc, oPerson.Description, iSeq, oPerson.BirthPlace, oPerson.BirthName, oPerson.DeathMonth, oPerson.DeathDay, oPerson.Id)
                UpdateSocialMedia(oPerson.Id, oPerson.Social.TwitterHandle, oPerson.Social.IsNoTweet)
            End If
            If cbDateAmend.Checked Then
                UpdateDate()
            End If
            oPerson.UnsavedChanges = False
            oTable.Dispose()
            oTa.Dispose()
            oTable = Nothing
            oTa = Nothing
            lblStatus.Text += " - Complete"
        End If
    End Sub

    Public Function RemoveTags(ByVal sText As String) As String
        Dim outText As New StringBuilder
        Dim inTag As Boolean = False
        For Each c As Char In sText
            If c = "<" Then inTag = True
            If Not inTag Then
                outText.Append(c)
            End If
            If c = ">" Then inTag = False
        Next

        Return outText.ToString

    End Function

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
                    oPerson.Image = New ImageIdentity()
                    oPerson.Surname = txtSurname.Text.Trim
                    oPerson.ShortDesc = txtShortDesc.Text.Trim
                    oPerson.DeathDay = CInt("0" & txtDthDay.Text.Trim)
                    oPerson.DeathMonth = CInt("0" & txtDthMth.Text.Trim)
                    oPerson.BirthPlace = txtBirthPlace.Text.Trim
                    oPerson.BirthName = txtBirthName.Text.Trim
                    oPerson.Social.TwitterHandle = txtTwitter.Text.Trim
                    oPerson.Social.IsNoTweet = cbNoTweet.Checked
                    oPerson.UnsavedChanges = True
                    Dim p As Integer = lbPeople.SelectedIndex
                    DisplayPersonlList()
                    lbPeople.SelectedIndex = p
                    lblStatus.Text = "Updated list"

                    Exit For
                End If
            Next

        End If
    End Sub

    Private Sub BtnPicSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicSave.Click
        SavePic()
    End Sub

    Private Sub SavePic()
        If lbPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(lbPeople.SelectedIndex)
            Dim sYear As String = txtLoadYr.Text
            Dim sMth As String = txtLoadMth.Text
            Dim url As String = "http://celebritybirthday.files.wordpress.com/" & sYear & "/" & sMth & "/" & oPerson.Image.ImageFileName & oPerson.Image.ImageFileType
            Try
                Dim sFname As String = Path.Combine(My.Settings.ImgFolder, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
                If SaveImage(url, sFname) Then
                    PictureBox2.ImageLocation = sFname
                End If
            Catch ex As Exception
                lblStatus.Text = ex.Message
            End Try
        End If
    End Sub

    Private Sub FrmAddCbdy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        oTwta.Dispose()
        oTwtable.Dispose()
        oTwta = Nothing
        oTwtable = Nothing
        If _search IsNot Nothing AndAlso Not _search.IsDisposed Then
            _search.Close()
        End If
        If _twitter IsNot Nothing AndAlso Not _twitter.IsDisposed Then
            _twitter.Close()
        End If
        My.Settings.mainformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub FrmAddCbdy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.callUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.callUpgrade = 1
            My.Settings.Save()
        End If
        Label11.Text = "Version: " & My.Application.Info.Version.ToString
        GetFormPos(Me, My.Settings.mainformpos)
        txtLoadYr.Text = ""
        txtLoadMth.Text = ""
        cbImgType.SelectedIndex = 0
        cbDateAmend.Checked = False
        bLoadingPerson = False
        rtbDesc.AllowDrop = True
        rtbDesc.EnableAutoDragDrop = True
    End Sub

    Private Sub BtnCreateShortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateShortDesc.Click
        txtShortDesc.Text = txtDesc.SelectedText
    End Sub

    Public Sub BtnSplitName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSplitName.Click
        txtName.Text = txtName.Text.Trim
        Dim names As String() = Split(txtName.Text, " ")
        txtSurname.Text = names(UBound(names))
        txtForename.Text = txtName.Text.Replace(txtSurname.Text, "").Trim
    End Sub

    Private Sub BtnCreateFullName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateFullName.Click
        txtName.Text = (txtForename.Text & " " & txtSurname.Text).Trim(" ")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseForm()
    End Sub

    Private Sub FindPeopleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindPeopleToolStripMenuItem.Click
        If _search Is Nothing OrElse _search.IsDisposed Then
            _search = New frmSearchDb
        End If
        _search.Show()

    End Sub

    Private Sub BtnLoadUpd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadUpd.Click
        UpdateDate()
    End Sub
    Private Sub UpdateDate()

        Dim oTa As New CelebrityBirthdayDataSetTableAdapters.DatesTableAdapter
        oTa.UpdateDate(txtLoadYr.Text, txtLoadMth.Text, cbDateAmend.Checked, txtLoadDay.Text, cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
        oTa.Dispose()
    End Sub

    Private Sub BtnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        Dim resp As MsgBoxResult = MsgBoxResult.No
        If CheckForChanges(personTable) Then
            If MsgBox("Save unsaved changes now?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Unsaved Changes") = MsgBoxResult.Yes Then
                BtnUpdateAll_Click(sender, e)
            End If
        End If

        personTable = New List(Of Person)
        lbPeople.Items.Clear()
        cboDay.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
    End Sub

    Private Sub BtnFindImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindImage.Click
        Using _imagestore As New frmImageStore
            _imagestore.Forename = txtForename.Text.Trim
            _imagestore.Surname = txtSurname.Text.Trim
            _imagestore.ShowDialog()
        End Using
    End Sub

    Private Sub FrmMain_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        My.Settings.mainformpos = setFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub ImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagesToolStripMenuItem.Click
        Using imgForm As New FrmImages
            imgForm.ShowDialog()
        End Using
    End Sub

    Private Sub TxtYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYear.TextChanged, txtDied.TextChanged,
                                                                                                txtImgName.TextChanged,
                                                                                                txtForename.TextChanged, txtSurname.TextChanged,
                                                                                                txtName.TextChanged,
                                                                                                txtShortDesc.TextChanged, txtBirthName.TextChanged,
                                                                                                txtBirthPlace.TextChanged, txtDthDay.TextChanged,
                                                                                                txtDthMth.TextChanged
        If Not bLoadingPerson Then
            cbDateAmend.Checked = True
        End If
    End Sub

    Private Sub BtnSaveImgInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveImgInfo.Click
        If txtCurrentText.TextLength > 0 Then

            Dim oIta As New CelebrityBirthdayDataSetTableAdapters.ImageTableAdapter
            Dim oITable As New CelebrityBirthdayDataSet.ImageDataTable
            Dim sText As String = txtCurrentText.Text.Trim.Replace(vbCr, "").Replace(vbLf, "")
            Dim currParts As String() = Split(sText, "<h3>")
            For Each currPart As String In currParts
                Dim entries As String() = Split(currPart, "<img")

                For x = 1 To entries.Count - 1
                    Dim imgsrcstart As Int16 = entries(x).IndexOf("src=") + 5
                    Dim imgsrcend As Int16 = entries(x).IndexOf(" alt") - 1
                    Dim url = entries(x).Substring(imgsrcstart, imgsrcend - imgsrcstart)
                    Dim urlparts As String() = Split(url, "/")

                    Dim filename As String() = Split(urlparts(urlparts.Count - 1), ".")
                    Dim ldmth As String = urlparts(urlparts.Count - 2)
                    Dim ldyr As String = urlparts(urlparts.Count - 3)
                    Debug.Print(filename(0) & " " & filename(1) & " " & ldmth & " " & ldyr)

                    Dim ict As Integer = oIta.FillByFilename(oITable, filename(0), "." & filename(1))
                    If ict = 1 Then
                        Dim oIRow As CelebrityBirthdayDataSet.ImageRow = oITable.Rows(0)
                        oIta.UpdateImage(filename(0), "." & filename(1), ldyr, ldmth, oIRow.id)
                    End If
                Next
            Next
            oITable.Dispose()
            oIta.Dispose()
        End If

    End Sub

    Private Sub BtnWiki_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWiki.Click
        Dim item As String() = {""}
        If lblID.Text.Length > 0 And lbPeople.SelectedIndex >= 0 Then
            item = Split(lbPeople.SelectedItem, " ")
            item(0) = ""
        Else
            If txtName.TextLength > 0 Then
                item = Split(txtName.Text, " ")
            End If
        End If


        If _search Is Nothing OrElse _search.IsDisposed Then
            _search = New frmSearchDb
        End If
        _search.Show()
        _search.searchName = Join(item, " ").Trim
        _search.FindinWiki()

    End Sub

    Private Sub TxtDthDay_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDthDay.Click, txtDthMth.Click, txtDied.Click
        Dim fld As TextBox = CType(sender, TextBox)
        fld.SelectAll()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        getSourceControl(menuItem).Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        getSourceControl(menuItem).Cut()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim sourceControl As Object = getSourceControl(sender)

        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            If _textBox IsNot Nothing Then
                _textBox.SelectAll()
            End If
        End If

    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Dim sourceControl As Object = getSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If

    End Sub

    Private Sub LowercaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles LowercaseToolStripMenuItem.Click
        Dim sourceControl As Object = getSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToLower
        End If
    End Sub

    Private Sub UpperCaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles UpperCaseToolStripMenuItem.Click
        Dim sourceControl As Object = getSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = _textBox.SelectedText.ToUpper
        End If
    End Sub

    Private Sub TitleCaseToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles TitleCaseToolStripMenuItem.Click
        Dim sourceControl As Object = getSourceControl(menuItem)
        If TypeOf (sourceControl) Is TextBox Or TypeOf (sourceControl) Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.SelectedText = StrConv(_textBox.SelectedText, VbStrConv.ProperCase)
        End If
    End Sub


    Private Sub ClearToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim sourceControl As Object = getSourceControl(menuItem)
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
    End Sub

    Private Sub UseNicknameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseNicknameToolStripMenuItem.Click
        If txtDesc.SelectionLength > 0 Then
            txtDesc.SelectedText = getNickname(txtDesc.SelectedText)
        End If
    End Sub

    Private Function GetNickname(ByRef sName As String) As String
        Dim names As String() = Split(sName, """")
        Dim sNickName As String = ""
        If names.Length > 2 Then
            sNickName = names(1).Trim & " " & names(2).Trim
            sName = names(0).Trim & " " & names(2).Trim
        End If
        Return sNickName & " "
    End Function

    Private Sub BtnTidy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTidy.Click
        TidyText()
    End Sub

    Private Function FixQuotes(ByVal _text As String) As String
        Return _text.Trim(vbCrLf).Replace("–", "-").Replace(Chr(147), """").Replace(Chr(148), """")
    End Function

    Private Function RemoveSquareBrackets(ByVal _text As String) As String
        Dim newText As String = _text.Trim(vbCrLf)
        Do While newText.Contains("[") And newText.Contains("]")
            Dim parts1 As String() = Split(newText, "[", 2)
            Dim parts2 As String() = Split(parts1(1), "]", 2)
            newText = parts1(0) & parts2(1)
        Loop
        Return newText
    End Function
    Private Function MakeList(ByVal _string1 As String, ByVal _string2 As String, ByVal _string3 As String) As List(Of String)
        Dim _return As New List(Of String) From {
            _string1,
            _string2,
            _string3
        }
        Return _return
    End Function


    Private Function ParseStringWithBrackets(ByRef _string As String, Optional ByRef _start As Integer = 0, Optional ByVal _openChar As Char = "("c, Optional ByVal _endChar As Char = ")"c) As List(Of String)
        Dim _return As New List(Of String)
        Dim _pre As String = _string
        Dim _inner As String = ""
        Dim _post As String = ""
        Dim x As Integer = 0
        Dim _firstOpen As Integer = _string.IndexOf(_openChar, _start)
        If _firstOpen < 0 Then
            Return _return
        End If
        Do Until x = _firstOpen
            _pre &= _string(x)
            x += 1
        Loop
        Dim _closefound As Boolean = False
        Dim _nextclose As Integer = -1
        Dim _nextopen As Integer = -1

        Do Until x >= _string.Length Or _closefound
            _nextclose = _string.IndexOf(")"c, x + 1)
            If _nextclose < 0 Then
                Exit Do
            End If
            _nextopen = _string.IndexOf("("c, x + 1)
            If _nextopen < 0 Then
                _closefound = True
                Exit Do
            End If
            If _nextopen > _nextclose Then
                _closefound = True
                Exit Do
            End If
            x = _nextclose + 1
        Loop
        If _closefound Then
            _pre = _string.Substring(0, _firstOpen)
            _inner = _string.Substring(_firstOpen + 1, _nextclose - _firstOpen - 1)
            _post = _string.Substring(_nextclose + 1)
        Else
            Return _return
        End If

        Return makeList(_pre, _inner, _post)
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

    Private Sub TidyAndFix()
        Dim _desc As String = removeSquareBrackets(fixQuotes(txtDesc.Text))
        Dim _parts As List(Of String) = parseStringWithBrackets(_desc)
        If _parts.Count = 3 Then
            Dim _datePart As String = removePhrases(_parts(1))
            txtDesc.Text = _parts(0) & "(" & _datePart & ")" & _parts(2)
        End If
        _parts = ParseStringWithChar(txtDesc.Text, ".")
        Dim words As List(Of String) = ParseStringWithChar(_parts.Last, " ")
        If ExtractNameandPlace(words) Then
            _parts.RemoveAt(_parts.Count - 1)
            txtDesc.Text = Join(_parts.ToArray, ".") & "."
        End If
    End Sub

    Private Function ExtractNameandPlace(_words As List(Of String)) As Boolean
        Dim isextracted As Boolean = False
        Dim isNamePart As Boolean = False
        Dim isPlacePart As Boolean = False
        Dim isDatePart As Boolean = False
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

    Private Function ParseStringWithChar(last As String, _char As Char) As List(Of String)
        Return Split(last.Trim([_char]), _char).ToList()
    End Function

    Private Sub TidyText()
        Dim newText As String = removeSquareBrackets(fixQuotes(txtDesc.Text))
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
                s3(0) = getNickname(birthName)
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
        Dim newShortText = removeSquareBrackets(fixQuotes(txtShortDesc.Text)).Trim(charsToTrim)
        txtShortDesc.Text = newShortText & If(newShortText.Length > 0, ".", "")
        txtBirthName.Text = removeSquareBrackets(fixQuotes(txtBirthName.Text).Replace(",", "").Replace(".", "").Replace(";", "")).Trim(charsToTrim)
        txtBirthPlace.Text = removeSquareBrackets(fixQuotes(txtBirthPlace.Text).Replace(".", "").Replace(";", "")).Trim(charsToTrim)
        txtImgName.Text = txtImgName.Text.Replace("'", "").Trim(charsToTrim)
        txtTwitter.Text = RemoveBadCharacters(txtTwitter.Text, {8207}).Trim
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Using _options As New frmOptions
            _options.ShowDialog()
        End Using
    End Sub

    Private Sub BtnRTB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRTB.Click

        SwapText(btnRTB.Text)

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

    Private Sub BtnTidyDob_Click(sender As Object, e As EventArgs) Handles btnTidyDob.Click
        tidyAndFix()
    End Sub

    Private Function GetSocialMedia(ByVal _id As Integer) As CelebrityBirthdayDataSet.SocialMediaRow
        Dim oTwRow As CelebrityBirthdayDataSet.SocialMediaRow = Nothing
        Dim tCt As Integer = oTwta.FillById(oTwtable, _id)
        If tCt = 1 Then
            oTwRow = oTwtable.Rows(0)
        End If
        Return oTwRow
    End Function

    Private Function GetTwitterHandle(otwRow As CelebrityBirthdayDataSet.SocialMediaRow) As String
        Dim _twitterHandle As String = ""
        If otwRow IsNot Nothing Then
            _twitterHandle = If(otwRow.IstwitterHandleNull, "", otwRow.twitterHandle)
        End If
        Return _twitterHandle
    End Function

    Private Function IsNoTweet(otwRow As CelebrityBirthdayDataSet.SocialMediaRow) As String
        Dim _noTweet As Boolean = False
        If otwRow IsNot Nothing Then
            _noTweet = If(otwRow.IsnoTweetNull, False, otwRow.noTweet)
        End If
        Return _noTweet
    End Function

    Private Sub InsertSocialMedia(ByVal _id As Integer, ByVal _twitterHandle As String, ByVal _isNoTweet As Boolean)
        DeleteTwitterHandle(_id)
        If Not String.IsNullOrEmpty(_twitterHandle) OrElse _isNoTweet Then
            oTwta.InsertTwitter(_id, _twitterHandle, _isNoTweet)
        End If
    End Sub

    Private Function DeleteTwitterHandle(ByVal _id As Integer) As Integer
        Return oTwta.DeleteTwitter(_id)
    End Function

    Private Sub UpdateSocialMedia(ByVal _id As Integer, ByVal _twitterHandle As String, ByVal _isNoTweet As Boolean)
        If String.IsNullOrEmpty(_twitterHandle) And Not cbNoTweet.Checked Then
            DeleteTwitterHandle(_id)
        Else
            If getSocialMedia(_id) Is Nothing Then
                oTwta.InsertTwitter(_id, _twitterHandle, _isNoTweet)
            Else
                oTwta.UpdateTwitter(_twitterHandle, _isNoTweet, _id)
            End If
        End If

    End Sub

    Private Sub DeletePerson(ByVal _id As Integer)
        Dim oTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
        Dim oTable As New CelebrityBirthdayDataSet.PersonDataTable
        oTa.DeletePerson(_id)
        oTable.Dispose()
        oTa.Dispose()
        oTable = Nothing
        oTa = Nothing
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
            lblID.Text = oPerson.Id
            txtForename.Text = oPerson.ForeName
            txtSurname.Text = oPerson.Surname
            If _search Is Nothing OrElse _search.IsDisposed Then
                _search = New frmSearchDb
            End If
            _search.Show()
            _search.searchName = oPerson.ForeName.Trim & " " & oPerson.Surname.Trim
            _search.FindinTwitter()
        End If
    End Sub

    Private Sub TwitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TwitterToolStripMenuItem.Click
        If _twitter Is Nothing OrElse _twitter.IsDisposed Then
            _twitter = New frmTwitterOutput
        End If
        _twitter.Show()

    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        CloseForm()
    End Sub

    Private Sub UpdateDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateDatabaseToolStripMenuItem.Click
        Using _update As New FrmUpdateDatabase
            _update.ShowDialog()
        End Using
    End Sub

    Private Sub ImagesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImagesToolStripMenuItem1.Click
        Using _update As New FrmImages
            _update.ShowDialog()
        End Using
    End Sub
End Class

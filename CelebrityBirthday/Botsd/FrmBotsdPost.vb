Imports System.IO
Imports System.Text
Imports TweetSharp

Public NotInheritable Class FrmBotsdPost
#Region "variables"
    Private oAlsoFileName As String
    Private ReadOnly charsToTrim() As Char = {" "c, ","c, ";"c, "."c, "["c, "("c, "."c}
    Private Structure UndoData
        Public undoName As String
        Public undoWikiUrl As String
        Public undoDesc As String
        Public undoList As List(Of DataGridViewRow)
    End Structure

    Private ReadOnly UndoDataList As New List(Of UndoData)
#End Region
#Region "properties"
    Private oNewPostNo As Integer
    Public Property NewPostNo() As Integer
        Get
            Return oNewPostNo
        End Get
        Set(ByVal value As Integer)
            oNewPostNo = value
        End Set
    End Property
    Private oPostText As String
    Public Property PostText() As String
        Get
            Return oPostText
        End Get
        Set(ByVal value As String)
            oPostText = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub FrmText_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.botsdpostpos)
        Dim splitWords As String() = Split(My.Settings.SplitWords, "~")
        CbSplit.Items.Clear()
        For Each splitword As String In splitWords
            CbSplit.Items.Add(splitword)
        Next
        Dim alsosText As String = GenerateAlsos()
        RtbText.Text = oPostText & alsosText
        oAlsoFileName = GenAlsoFileName()
    End Sub
    Private Sub FrmText_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.botsdpostpos = SetFormPos(Me)
        My.Settings.Save()
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
    Private Sub BtnCopyAll_Click(sender As Object, e As EventArgs) Handles BtnCopyText.Click
        RtbText.SelectAll()
        RtbText.Copy()
    End Sub
    Private Sub BtnCopyTitle_Click(sender As Object, e As EventArgs) Handles BtnCopyTitle.Click
        TxtTitle.SelectAll()
        TxtTitle.Copy()
    End Sub
    Private Sub BtnPosted_Click(sender As Object, e As EventArgs) Handles BtnPosted.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
    Private Sub BtnPasteUrl_Click(sender As Object, e As EventArgs) Handles BtnPasteUrl.Click
        TxtUrl.Text = Clipboard.GetText
    End Sub
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim alsosText As String = GenerateAlsos()
        RtbText.Text = oPostText & alsosText
    End Sub
    Private Sub BtnName_Click(sender As Object, e As EventArgs) Handles BtnName.Click
        TxtName.Text = Clipboard.GetText
    End Sub
    Private Sub BtnWiki_Click(sender As Object, e As EventArgs) Handles BtnWiki.Click
        TxtWiki.Text = Clipboard.GetText
    End Sub
    Private Sub BtnDesc_Click(sender As Object, e As EventArgs) Handles BtnDesc.Click
        TxtDesc.Text = TidyDescription(Clipboard.GetText)
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        AddToList()
    End Sub
    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtName.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = TidyDescription(e.Data.GetData(DataFormats.StringFormat))
            DropText(oBox, item)
        End If
    End Sub
    Private Sub DgvAlso_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles DgvAlso.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            AddUndo()
            ClearForm()
            DropText(TxtWiki, item)
            ExtractAlsoValues()
            AddToList()
        End If
    End Sub
    Private Sub TxtWiki_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtWiki.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            DropText(oBox, item)
            ExtractAlsoValues()
        End If
    End Sub
    Private Sub TxtDesc_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtDesc.DragDrop
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = TidyDescription(e.Data.GetData(DataFormats.StringFormat)) & "."
            DropText(oBox, item)
        End If
    End Sub
    Private Sub TextBox_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtDesc.DragOver,
                                                                                                                TxtName.DragOver,
                                                                                                                TxtUrl.DragOver,
                                                                                                                TxtWiki.DragOver
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            oBox.Select(TextBoxCursorPos(oBox, e.X, e.Y), 0)
        End If
    End Sub
    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtDesc.DragEnter,
                                                                                                                TxtName.DragEnter,
                                                                                                                TxtUrl.DragEnter,
                                                                                                                TxtWiki.DragEnter,
                                                                                                                DgvAlso.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) Or e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DgvAlso_SelectionChanged(sender As Object, e As EventArgs) Handles DgvAlso.SelectionChanged
        If DgvAlso.SelectedRows.Count > 0 AndAlso Not String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoName.Name).Value) Then
            TxtName.Text = If(String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoName.Name).Value), "", DgvAlso.SelectedRows(0).Cells(alsoName.Name).Value)
            TxtWiki.Text = If(String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoWiki.Name).Value), "", DgvAlso.SelectedRows(0).Cells(alsoWiki.Name).Value)
            TxtDesc.Text = If(String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoDesc.Name).Value), "", DgvAlso.SelectedRows(0).Cells(alsoDesc.Name).Value)
            If String.IsNullOrEmpty(TxtDesc.Text) And NudSentences.Value > 1 Then
                ExtractNewDescription
            End If
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub
    Private Sub NudSentences_ValueChanged(sender As Object, e As EventArgs) Handles NudSentences.ValueChanged
        ExtractNewDescription()
    End Sub
    Private Sub ExtractNewDescription()
        If DgvAlso.SelectedRows.Count = 1 AndAlso Not String.IsNullOrEmpty(TxtWiki.Text) Then
            ExtractAlsoValues()
            Dim oRow As DataGridViewRow = DgvAlso.SelectedRows(0)
            ReplaceRowValues(oRow)
        End If
    End Sub

    Private Sub BtnSearch1_Click(sender As Object, e As EventArgs) Handles BtnSearch1.Click
        Dim sUrl As String = My.Resources.WIKI_SEARCH.Replace("~date", LblDay.Text & "+" & LblMonth.Text & "+" & LblYear.Text)
        Process.Start(sUrl)
    End Sub
    Private Sub BtnSearch2_Click(sender As Object, e As EventArgs) Handles BtnSearch2.Click
        Dim sUrl As String = My.Resources.WIKI_SEARCH.Replace("~date", LblMonth.Text & "+" & LblDay.Text & "%2C+" & LblYear.Text)
        Process.Start(sUrl)
    End Sub
    Private Sub BtnImportList_Click(sender As Object, e As EventArgs) Handles BtnImportList.Click
        Dim alsoList As String() = Split(Clipboard.GetText, vbCrLf)
        For Each _also As String In alsoList
            Dim parts As String() = Split(_also, My.Resources.DOUBLEQUOTES)
            If parts.Length > 4 Then
                Dim _lastpart As String() = Split(_also, My.Resources.WP_END_A)
                TxtName.Text = ParseStringWithBrackets(parts(1))(0)
                If String.IsNullOrEmpty(TxtName.Text) Then
                    TxtName.Text = Split(_lastpart(0), ">")(1)
                End If
                TxtWiki.Text = FormatUrl(parts(3))
                Dim newDesc As String = If(_lastpart.Length = 2, _lastpart(1), "")
                TxtDesc.Text = TidyDescription(newDesc) & "."
                AddToList()
            End If
        Next
        ClearForm()
    End Sub
    Private Sub BtnReplace_Click(sender As Object, e As EventArgs) Handles BtnReplace.Click
        ReplaceRow()
    End Sub
    Private Sub BtnLoadList_Click(sender As Object, e As EventArgs) Handles BtnLoadList.Click
        If My.Computer.FileSystem.FileExists(oAlsoFileName) Then
            DisplayStatus("Loading List")
            Using _inputFile As New StreamReader(oAlsoFileName)
                Dim _inputline As String = _inputFile.ReadLine
                Do While _inputline IsNot Nothing
                    Dim _parts As String() = Split(_inputline, "|")
                    If _parts.Length = 3 Then
                        Dim oRow As DataGridViewRow = DgvAlso.Rows(DgvAlso.Rows.Add())
                        oRow.Cells(alsoName.Name).Value = _parts(0)
                        oRow.Cells(alsoWiki.Name).Value = _parts(1)
                        oRow.Cells(alsoDesc.Name).Value = _parts(2)
                    End If
                    _inputline = _inputFile.ReadLine
                Loop
            End Using
            DisplayStatus("Loaded List")
        Else
            DisplayStatus(oAlsoFileName & " not found")
        End If
    End Sub
    Private Sub BtnSaveList_Click(sender As Object, e As EventArgs) Handles BtnSaveList.Click
        SaveList()
    End Sub
    Private Sub BtnUndoSplit_Click(sender As Object, e As EventArgs) Handles BtnUndoSplit.Click
        If UndoDataList.Count > 0 Then
            Dim selectedRow As Integer = -1
            If DgvAlso.SelectedRows.Count = 1 Then
                selectedRow = DgvAlso.SelectedRows(0).Index
            End If
            Dim undoSnapshot As UndoData = UndoDataList.Last
            With undoSnapshot
                TxtName.Text = .undoName
                TxtWiki.Text = .undoWikiUrl
                TxtDesc.Text = .undoDesc
                DgvAlso.Rows.Clear()
                For Each oRow As DataGridViewRow In .undoList
                    Dim clonedRow As DataGridViewRow = oRow.Clone()
                    For i = 0 To oRow.Cells.Count - 1
                        clonedRow.Cells(i).Value = oRow.Cells(i).Value
                    Next
                    DgvAlso.Rows.Add(clonedRow)
                Next
            End With
            UndoDataList.Remove(undoSnapshot)
            DgvAlso.ClearSelection()
            If selectedRow >= 0 AndAlso selectedRow < DgvAlso.Rows.Count Then
                DgvAlso.Rows(selectedRow).Selected = True
            End If
        End If
    End Sub
    Private Sub BtnWikiOpen_Click(sender As Object, e As EventArgs) Handles BtnWikiOpen.Click
        If Not String.IsNullOrEmpty(TxtWiki.Text) Then
            Process.Start(TxtWiki.Text)
        End If
    End Sub
    Private Sub BtnRemoveEnd_Click(sender As Object, e As EventArgs) Handles BtnRemoveEnd.Click
        If TxtDesc.SelectedText.Length > 0 Then
            RemoveSelectedText(False)
        Else
            GetSplitPart(0)
            If ChkAnd.Checked And CbSplit.Text.Trim = "and" Then
                MoveAnd()
            End If
        End If
        ChkAnd.Checked = False
    End Sub
    Private Sub BtnClearList_Click(sender As Object, e As EventArgs) Handles BtnClearList.Click
        DgvAlso.Rows.Clear()
    End Sub

#End Region
#Region "subroutines"
    Private Function GenerateAlsos() As String
        Dim sb As New StringBuilder
        sb.Append(vbCrLf).Append(My.Resources.WP_PARA).Append(vbCrLf)
        For Each oRow As DataGridViewRow In DgvAlso.Rows
            If Not String.IsNullOrEmpty(oRow.Cells(alsoName.Name).Value) Then
                Dim oName As String = oRow.Cells(alsoName.Name).Value
                Dim oWiki As String = oRow.Cells(alsoWiki.Name).Value
                Dim oDesc As String = oRow.Cells(alsoDesc.Name).Value
                With sb
                    .Append("<a title=")
                    .Append(My.Resources.DOUBLEQUOTES).Append(oName.Trim).Append(My.Resources.DOUBLEQUOTES)
                    .Append(" href=")
                    .Append(My.Resources.DOUBLEQUOTES).Append(oWiki.Trim).Append(My.Resources.DOUBLEQUOTES)
                    .Append(" target=")
                    .Append(My.Resources.DOUBLEQUOTES).Append(" _blank").Append(My.Resources.DOUBLEQUOTES)
                    .Append(" rel=")
                    .Append(My.Resources.DOUBLEQUOTES).Append("noreferrer noopener").Append(My.Resources.DOUBLEQUOTES)
                    .Append(">"c)
                    .Append(oName.Trim)
                    .Append(My.Resources.WP_END_A).Append(" "c)
                    .Append(oDesc.Trim({" "c, ","c, ";"c, "."c, "["c}))
                    .Append("."c).Append(My.Resources.BREAK)
                    .Append(vbCrLf)
                End With
            End If
        Next
        sb.Append(My.Resources.WP_END_PARA)
        Return sb.ToString
    End Function
    Private Function GenAlsoFileName() As String
        Dim _path As String = My.Settings.botsdFilePath
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _add As String = My.Resources.BOTSD
        Dim _fileName As String = Path.Combine(_path, _add.Replace("_", "_" & LblDay.Text & "_" & LblMonth.Text & "_" & LblYear.Text) & ".txt")
        Return _fileName
    End Function
    Private Sub SaveList()
        DisplayStatus("Saving List")
        Using _outputfile As New StreamWriter(oAlsoFileName, False)
            For Each oRow As DataGridViewRow In DgvAlso.Rows
                If Not String.IsNullOrEmpty(oRow.Cells(alsoName.Name).Value) Then
                    Dim oName As String = oRow.Cells(alsoName.Name).Value
                    Dim oWiki As String = oRow.Cells(alsoWiki.Name).Value
                    Dim oDesc As String = oRow.Cells(alsoDesc.Name).Value
                    Dim oLine As String = oName & "|" & oWiki & "|" & oDesc
                    _outputfile.WriteLine(oLine)
                End If
            Next
        End Using
        DisplayStatus("Saved List")
    End Sub
    Private Sub DisplayStatus(pText As String, Optional isAppend As Boolean = False)
        lblStatus.Text = If(isAppend, lblStatus.Text, "") & pText
        StatusStrip1.Refresh()
    End Sub
    Private Function TidyDescription(_string As String) As String
        Return _string.Replace(My.Resources.BREAK, "").Replace(My.Resources.NON_BREAKING_SPACE, " ").Replace("  ", " ").Trim(charsToTrim)
    End Function
    Private Sub ClearForm()
        TxtName.Text = ""
        TxtWiki.Text = ""
        TxtDesc.Text = ""
        NudSentences.Value = 1
    End Sub
    Private Shared Sub DropText(oBox As TextBox, item As String)
        Dim textlen As Integer = oBox.Text.Length
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
    End Sub
    Private Sub ExtractAlsoValues()
        If TxtWiki.Text.StartsWith("http", True, myCultureInfo) Then
            Dim _uri As Uri = New Uri(TxtWiki.Text)
            Dim wikiId As String = _uri.LocalPath.Split("/").Last
            TxtName.Text = ParseStringWithBrackets(wikiId.Replace("_", " "))(0)
            Dim wikiDesc As String = RetrieveWikiDesc(wikiId, NudSentences.Value)
            Dim descExtract As String() = Split(wikiDesc, ")", 2)
            If descExtract.Length > 1 Then
                Dim textAfterDates As String = descExtract(1)
                Dim relevantText As String = Split(textAfterDates, "who", 2)(0)
                TxtDesc.Text = TidyDescription(relevantText) & "."
            End If
        Else
            MsgBox("Link not selected correctly", MsgBoxStyle.Exclamation, "Link error")
        End If
    End Sub
    Private Sub AddToList()
        Dim selectedRow As Integer = -1
        If DgvAlso.SelectedRows.Count = 1 Then
            selectedRow = DgvAlso.SelectedRows(0).Index
        End If
        If Not String.IsNullOrEmpty(TxtName.Text) Then
            If Not String.IsNullOrEmpty(TxtWiki.Text) Then
                TxtWiki.Text = TxtWiki.Text.Replace("http:", "https:")
                If IsOkToAddAlso(TxtWiki.Text, selectedRow) Then
                    selectedRow = DgvAlso.Rows.Add()
                    Dim oRow As DataGridViewRow = DgvAlso.Rows(selectedRow)
                    ReplaceRowValues(oRow)
                    DgvAlso.ClearSelection()
                    oRow.Selected = True
                    DisplayStatus("Person added")
                Else
                    DgvAlso.ClearSelection()
                    If selectedRow >= 0 AndAlso selectedRow < DgvAlso.Rows.Count Then
                        DgvAlso.Rows(selectedRow).Selected = True
                    End If
                    DisplayStatus("Person not added")
                End If
            End If
        End If
    End Sub
    Private Function IsOkToAddAlso(wikiUri As String, ByRef selectedRow As Integer) As Boolean
        Dim isOK As Boolean = True
        For Each oRow As DataGridViewRow In DgvAlso.Rows
            Dim rowUri As String = If(oRow.Cells(alsoWiki.Name).Value, "")
            If wikiUri = rowUri Then
                selectedRow = oRow.Index
                If CbRejectDuplicates.Checked OrElse MsgBox(wikiUri & vbCrLf & "already in list. OK to add duplicate?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Duplicate") = MsgBoxResult.No Then
                    isOK = False
                End If
            End If
        Next
        Return isOK
    End Function
    Private Function ReplaceRowValues(oRow As DataGridViewRow) As DataGridViewRow
        oRow.Cells(alsoName.Name).Value = TxtName.Text
        oRow.Cells(alsoWiki.Name).Value = TxtWiki.Text
        oRow.Cells(alsoDesc.Name).Value = TxtDesc.Text
        If TxtDesc.TextLength > 160 Then
            oRow.Cells(alsoDesc.Name).Style.ForeColor = Color.Red
            oRow.Cells(alsoDesc.Name).Value = TxtDesc.Text.Substring(0, 160)
        ElseIf TxtDesc.TextLength > 80 Then
            oRow.Cells(alsoDesc.Name).Style.ForeColor = Color.Blue
        Else
            oRow.Cells(alsoDesc.Name).Style.ForeColor = Color.Black
        End If
        SaveList()
        Return oRow
    End Function
    Private Shared Function RetrieveWikiDesc(_searchName As String, _count As Integer) As String
        Dim _response As System.Net.WebResponse = NavigateToUrl(GetWikiExtractString(_searchName, _count))
        Dim extract As String = GetExtractFromResponse(_response)
        Return extract
    End Function
    Private Sub GetSplitPart(partNumber As Integer)
        Dim splitOn As String
        If CbSplit.SelectedIndex > -1 Then
            splitOn = CbSplit.SelectedItem
        Else
            splitOn = CbSplit.Text
        End If
        Dim descParts As String() = Split(TxtDesc.Text, splitOn, 2)
        If descParts.Length > partNumber Then
            TxtDesc.Text = descParts(partNumber).Trim(charsToTrim) & "."
            ReplaceRow()
        End If
    End Sub
    Private Sub RemoveSelectedText(isRemoveStart As Boolean)
        If isRemoveStart Then
            TxtDesc.Text = TxtDesc.SelectedText.Trim(charsToTrim) & "."
        Else
            TxtDesc.Text = TxtDesc.Text.Replace(TxtDesc.SelectedText, "").Trim(charsToTrim) & "."
        End If
        ReplaceRow()
    End Sub
    Private Sub MoveAnd()
        Dim commaPos As Integer = TxtDesc.Text.LastIndexOf(",", System.StringComparison.CurrentCultureIgnoreCase)
        If commaPos > 0 And commaPos < TxtDesc.TextLength Then
            TxtDesc.Text = TxtDesc.Text.Substring(0, commaPos) & " and" & TxtDesc.Text.Substring(commaPos + 1)
            ReplaceRow()
        End If
    End Sub
    Private Sub AddUndo()
        Dim undoSnapshot As New UndoData With {
        .undoName = TxtName.Text,
        .undoWikiUrl = TxtWiki.Text,
        .undoDesc = TxtDesc.Text,
        .undoList = New List(Of DataGridViewRow)}
        For Each oRow As DataGridViewRow In DgvAlso.Rows
            If oRow.Cells(alsoName.Name).Value IsNot Nothing Then
                Dim clonedRow As DataGridViewRow = oRow.Clone()
                For Each oCell As DataGridViewCell In oRow.Cells
                    clonedRow.Cells(oCell.ColumnIndex).Value = oCell.Value
                Next
                undoSnapshot.undoList.Add(clonedRow)
            End If
        Next
        UndoDataList.Add(undoSnapshot)
    End Sub
    Private Sub ReplaceRow()
        If DgvAlso.SelectedRows.Count = 1 Then
            AddUndo()
            Dim oRow As DataGridViewRow = DgvAlso.SelectedRows(0)
            ReplaceRowValues(oRow)
        End If
    End Sub
    Private Shared Function FormatUrl(_url As String) As String
        Dim splitUrl As String() = Split(_url, "//", 2)
        Dim returnUrl As String = "https://" & If(splitUrl.Length < 2, splitUrl(0), splitUrl(1))
        Return returnUrl
    End Function

    Private Sub ChkAnd_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAnd.CheckedChanged
        If ChkAnd.Checked Then
            CbSplit.SelectedIndex = CbSplit.FindString(" and")
        End If
    End Sub

    Private Sub BtnRemoveStart_Click(sender As Object, e As EventArgs) Handles BtnRemoveStart.Click
        If TxtDesc.SelectedText.Length > 0 Then
            RemoveSelectedText(True)
        Else
            GetSplitPart(1)
            If ChkAnd.Checked And CbSplit.Text.Trim = "and" Then
                MoveAnd()
            End If
        End If
        ChkAnd.Checked = False
    End Sub

    Private Sub BtnClearDesc_Click(sender As Object, e As EventArgs) Handles BtnClearDesc.Click
        TxtDesc.Text = ""
    End Sub
#End Region
End Class
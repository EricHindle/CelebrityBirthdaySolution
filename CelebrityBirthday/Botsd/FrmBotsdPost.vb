Imports System.IO
Imports System.Text

Public Class FrmBotsdPost
#Region "variables"
    Dim oAlsoFileName As String
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
        GetFormPos(Me, My.Settings.botsdformpos)
        Dim alsosText As String = GenerateAlsos()
        RtbText.Text = oPostText & alsosText
        oAlsoFileName = GenAlsoFileName()
    End Sub
    Private Sub FrmText_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.textformpos = SetFormPos(Me)
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
        TxtDesc.Text = Clipboard.GetText
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If Not String.IsNullOrEmpty(TxtName.Text) Then
            Dim oRow As DataGridViewRow = DgvAlso.Rows(DgvAlso.Rows.Add())
            oRow.Cells(alsoName.Name).Value = TxtName.Text
            oRow.Cells(alsoWiki.Name).Value = TxtWiki.Text
            oRow.Cells(alsoDesc.Name).Value = TxtDesc.Text
            TxtName.Text = ""
            TxtWiki.Text = ""
            TxtDesc.Text = ""
            SaveList()
        End If
    End Sub
    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtDesc.DragDrop,
                                                                                            TxtName.DragDrop,
                                                                                            TxtUrl.DragDrop,
                                                                                            TxtWiki.DragDrop
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
                                                                                                                TxtWiki.DragEnter
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
    Private Sub DgvAlso_SelectionChanged(sender As Object, e As EventArgs) Handles DgvAlso.SelectionChanged
        If DgvAlso.SelectedRows.Count > 0 AndAlso Not String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoName.Name).Value) Then
            TxtName.Text = If(String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoName.Name).Value), "", DgvAlso.SelectedRows(0).Cells(alsoName.Name).Value)
            TxtWiki.Text = If(String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoWiki.Name).Value), "", DgvAlso.SelectedRows(0).Cells(alsoWiki.Name).Value)
            TxtDesc.Text = If(String.IsNullOrEmpty(DgvAlso.SelectedRows(0).Cells(alsoDesc.Name).Value), "", DgvAlso.SelectedRows(0).Cells(alsoDesc.Name).Value)
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TxtName.Text = ""
        TxtWiki.Text = ""
        TxtDesc.Text = ""
    End Sub
#End Region
#Region "subroutines"
    Private Function GenerateAlsos() As String
        Dim sb As New StringBuilder
        For Each oRow As DataGridViewRow In DgvAlso.Rows
            If Not String.IsNullOrEmpty(oRow.Cells(alsoName.Name).Value) Then
                Dim oName As String = oRow.Cells(alsoName.Name).Value
                Dim oWiki As String = oRow.Cells(alsoWiki.Name).Value
                Dim oDesc As String = oRow.Cells(alsoDesc.Name).Value
                With sb
                    .Append("<a title=")
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(oName.Trim)
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(" href=")
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(oWiki.Trim)
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(" target=")
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(" _blank")
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(" rel=")
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append("noreferrer noopener")
                    .Append(My.Resources.DOUBLEQUOTES)
                    .Append(">")
                    .Append(oName.Trim)
                    .Append("</a> ")
                    .Append(oDesc.Trim({" "c, ","c, ";"c, "."c, "["c}))
                    .Append(".")
                    .Append(vbCrLf)
                End With
            End If
        Next
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
    Private Sub BtnSaveList_Click(sender As Object, e As EventArgs) Handles BtnSaveList.Click
        SaveList()
    End Sub

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

    Private Sub DisplayStatus(pText As String, Optional isAppend As Boolean = False)
        lblStatus.Text = If(isAppend, lblStatus.Text, "") & pText
        StatusStrip1.Refresh()
    End Sub
#End Region
End Class
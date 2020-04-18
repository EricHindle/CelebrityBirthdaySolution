Public Class FrmBotsdPost
    Private oNewPostNo As Integer
    Public Property NewPostNo() As Integer
        Get
            Return oNewPostNo
        End Get
        Set(ByVal value As Integer)
            oNewPostNo = value
        End Set
    End Property
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmText_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.botsdformpos)
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
End Class
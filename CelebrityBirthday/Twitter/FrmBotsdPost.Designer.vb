<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBotsdPost
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBotsdPost))
        Me.RtbText = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpperCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowercaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCopyText = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.TxtTitle = New System.Windows.Forms.TextBox()
        Me.BtnCopyTitle = New System.Windows.Forms.Button()
        Me.LblWpPostNo = New System.Windows.Forms.Label()
        Me.TxtUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnPosted = New System.Windows.Forms.Button()
        Me.BtnPasteUrl = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RtbText
        '
        Me.RtbText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RtbText.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RtbText.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtbText.Location = New System.Drawing.Point(19, 87)
        Me.RtbText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RtbText.Name = "RtbText"
        Me.RtbText.Size = New System.Drawing.Size(899, 333)
        Me.RtbText.TabIndex = 37
        Me.RtbText.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpperCaseToolStripMenuItem, Me.LowercaseToolStripMenuItem, Me.TitleCaseToolStripMenuItem, Me.ToolStripSeparator2, Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ClearToolStripMenuItem, Me.SelectAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 186)
        '
        'UpperCaseToolStripMenuItem
        '
        Me.UpperCaseToolStripMenuItem.Name = "UpperCaseToolStripMenuItem"
        Me.UpperCaseToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.UpperCaseToolStripMenuItem.Text = "UPPERCASE"
        '
        'LowercaseToolStripMenuItem
        '
        Me.LowercaseToolStripMenuItem.Name = "LowercaseToolStripMenuItem"
        Me.LowercaseToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.LowercaseToolStripMenuItem.Text = "lowercase"
        '
        'TitleCaseToolStripMenuItem
        '
        Me.TitleCaseToolStripMenuItem.Name = "TitleCaseToolStripMenuItem"
        Me.TitleCaseToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.TitleCaseToolStripMenuItem.Text = "Title Case"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(134, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'BtnCopyText
        '
        Me.BtnCopyText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyText.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyText.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyText.Location = New System.Drawing.Point(214, 500)
        Me.BtnCopyText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCopyText.Name = "BtnCopyText"
        Me.BtnCopyText.Size = New System.Drawing.Size(120, 41)
        Me.BtnCopyText.TabIndex = 39
        Me.BtnCopyText.Text = "Copy Text"
        Me.BtnCopyText.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(798, 498)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(120, 41)
        Me.BtnClose.TabIndex = 38
        Me.BtnClose.Text = "Cancel"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TxtTitle
        '
        Me.TxtTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTitle.Location = New System.Drawing.Point(19, 55)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(899, 24)
        Me.TxtTitle.TabIndex = 40
        '
        'BtnCopyTitle
        '
        Me.BtnCopyTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyTitle.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyTitle.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyTitle.Location = New System.Drawing.Point(42, 500)
        Me.BtnCopyTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCopyTitle.Name = "BtnCopyTitle"
        Me.BtnCopyTitle.Size = New System.Drawing.Size(120, 41)
        Me.BtnCopyTitle.TabIndex = 41
        Me.BtnCopyTitle.Text = "Copy Title"
        Me.BtnCopyTitle.UseVisualStyleBackColor = True
        '
        'LblWpPostNo
        '
        Me.LblWpPostNo.AutoSize = True
        Me.LblWpPostNo.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWpPostNo.Location = New System.Drawing.Point(16, 18)
        Me.LblWpPostNo.Name = "LblWpPostNo"
        Me.LblWpPostNo.Size = New System.Drawing.Size(20, 23)
        Me.LblWpPostNo.TabIndex = 42
        Me.LblWpPostNo.Text = "0"
        '
        'TxtUrl
        '
        Me.TxtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUrl.Location = New System.Drawing.Point(100, 427)
        Me.TxtUrl.Name = "TxtUrl"
        Me.TxtUrl.Size = New System.Drawing.Size(766, 24)
        Me.TxtUrl.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(29, 429)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 22)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "URL"
        '
        'BtnPosted
        '
        Me.BtnPosted.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPosted.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPosted.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPosted.Location = New System.Drawing.Point(629, 498)
        Me.BtnPosted.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnPosted.Name = "BtnPosted"
        Me.BtnPosted.Size = New System.Drawing.Size(120, 41)
        Me.BtnPosted.TabIndex = 45
        Me.BtnPosted.Text = "Posted"
        Me.BtnPosted.UseVisualStyleBackColor = True
        '
        'btnPasteUrl
        '
        Me.BtnPasteUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteUrl.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPasteUrl.Location = New System.Drawing.Point(883, 427)
        Me.BtnPasteUrl.Name = "btnPasteUrl"
        Me.BtnPasteUrl.Size = New System.Drawing.Size(35, 26)
        Me.BtnPasteUrl.TabIndex = 46
        Me.BtnPasteUrl.Text = "<"
        Me.BtnPasteUrl.UseVisualStyleBackColor = True
        '
        'FrmBotsdPost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(933, 554)
        Me.Controls.Add(Me.BtnPasteUrl)
        Me.Controls.Add(Me.BtnPosted)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtUrl)
        Me.Controls.Add(Me.LblWpPostNo)
        Me.Controls.Add(Me.BtnCopyTitle)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.RtbText)
        Me.Controls.Add(Me.BtnCopyText)
        Me.Controls.Add(Me.BtnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmBotsdPost"
        Me.Text = "FrmBotsdPost"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RtbText As RichTextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UpperCaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LowercaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TitleCaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnCopyText As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents TxtTitle As TextBox
    Friend WithEvents BtnCopyTitle As Button
    Friend WithEvents LblWpPostNo As Label
    Friend WithEvents TxtUrl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnPosted As Button
    Friend WithEvents BtnPasteUrl As Button
End Class

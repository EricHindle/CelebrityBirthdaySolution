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
        Me.DgvAlso = New System.Windows.Forms.DataGridView()
        Me.alsoName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alsoWiki = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alsoDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtWiki = New System.Windows.Forms.TextBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.BtnName = New System.Windows.Forms.Button()
        Me.BtnWiki = New System.Windows.Forms.Button()
        Me.BtnDesc = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.LblDay = New System.Windows.Forms.Label()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.LblYear = New System.Windows.Forms.Label()
        Me.BtnSaveList = New System.Windows.Forms.Button()
        Me.BtnLoadList = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnImportList = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnClearList = New System.Windows.Forms.Button()
        Me.BtnReplace = New System.Windows.Forms.Button()
        Me.NudSentences = New System.Windows.Forms.NumericUpDown()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DgvAlso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RtbText
        '
        Me.RtbText.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RtbText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RtbText.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtbText.Location = New System.Drawing.Point(0, 0)
        Me.RtbText.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.RtbText.Name = "RtbText"
        Me.RtbText.Size = New System.Drawing.Size(589, 469)
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
        Me.BtnCopyText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyText.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyText.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyText.Location = New System.Drawing.Point(408, 598)
        Me.BtnCopyText.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
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
        Me.BtnClose.Location = New System.Drawing.Point(1121, 598)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
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
        Me.TxtTitle.Location = New System.Drawing.Point(18, 55)
        Me.TxtTitle.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(1223, 24)
        Me.TxtTitle.TabIndex = 40
        '
        'BtnCopyTitle
        '
        Me.BtnCopyTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyTitle.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyTitle.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyTitle.Location = New System.Drawing.Point(264, 598)
        Me.BtnCopyTitle.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnCopyTitle.Name = "BtnCopyTitle"
        Me.BtnCopyTitle.Size = New System.Drawing.Size(120, 41)
        Me.BtnCopyTitle.TabIndex = 41
        Me.BtnCopyTitle.Text = "Copy Title"
        Me.BtnCopyTitle.UseVisualStyleBackColor = True
        '
        'LblWpPostNo
        '
        Me.LblWpPostNo.AutoSize = True
        Me.LblWpPostNo.Font = New System.Drawing.Font("Papyrus", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWpPostNo.Location = New System.Drawing.Point(17, 18)
        Me.LblWpPostNo.Name = "LblWpPostNo"
        Me.LblWpPostNo.Size = New System.Drawing.Size(28, 34)
        Me.LblWpPostNo.TabIndex = 42
        Me.LblWpPostNo.Text = "0"
        '
        'TxtUrl
        '
        Me.TxtUrl.AllowDrop = True
        Me.TxtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtUrl.Location = New System.Drawing.Point(94, 566)
        Me.TxtUrl.Name = "TxtUrl"
        Me.TxtUrl.Size = New System.Drawing.Size(1090, 24)
        Me.TxtUrl.TabIndex = 43
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(25, 568)
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
        Me.BtnPosted.Location = New System.Drawing.Point(923, 598)
        Me.BtnPosted.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnPosted.Name = "BtnPosted"
        Me.BtnPosted.Size = New System.Drawing.Size(120, 41)
        Me.BtnPosted.TabIndex = 45
        Me.BtnPosted.Text = "Posted"
        Me.BtnPosted.UseVisualStyleBackColor = True
        '
        'BtnPasteUrl
        '
        Me.BtnPasteUrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPasteUrl.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPasteUrl.Location = New System.Drawing.Point(1205, 566)
        Me.BtnPasteUrl.Name = "BtnPasteUrl"
        Me.BtnPasteUrl.Size = New System.Drawing.Size(35, 26)
        Me.BtnPasteUrl.TabIndex = 46
        Me.BtnPasteUrl.Text = "<"
        Me.BtnPasteUrl.UseVisualStyleBackColor = True
        '
        'DgvAlso
        '
        Me.DgvAlso.AllowUserToResizeRows = False
        Me.DgvAlso.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvAlso.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.DgvAlso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAlso.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.alsoName, Me.alsoWiki, Me.alsoDesc})
        Me.DgvAlso.Location = New System.Drawing.Point(3, 3)
        Me.DgvAlso.Name = "DgvAlso"
        Me.DgvAlso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvAlso.Size = New System.Drawing.Size(616, 276)
        Me.DgvAlso.TabIndex = 47
        '
        'alsoName
        '
        Me.alsoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.alsoName.HeaderText = "Name"
        Me.alsoName.MinimumWidth = 50
        Me.alsoName.Name = "alsoName"
        Me.alsoName.Width = 150
        '
        'alsoWiki
        '
        Me.alsoWiki.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.alsoWiki.HeaderText = "Wiki"
        Me.alsoWiki.MinimumWidth = 50
        Me.alsoWiki.Name = "alsoWiki"
        Me.alsoWiki.Width = 150
        '
        'alsoDesc
        '
        Me.alsoDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.alsoDesc.HeaderText = "Desc"
        Me.alsoDesc.MinimumWidth = 50
        Me.alsoDesc.Name = "alsoDesc"
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGenerate.Location = New System.Drawing.Point(44, 598)
        Me.BtnGenerate.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(120, 41)
        Me.BtnGenerate.TabIndex = 48
        Me.BtnGenerate.Text = "Generate Text"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'TxtName
        '
        Me.TxtName.AllowDrop = True
        Me.TxtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtName.Location = New System.Drawing.Point(78, 295)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(453, 24)
        Me.TxtName.TabIndex = 49
        '
        'TxtWiki
        '
        Me.TxtWiki.AllowDrop = True
        Me.TxtWiki.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWiki.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWiki.Location = New System.Drawing.Point(79, 326)
        Me.TxtWiki.Multiline = True
        Me.TxtWiki.Name = "TxtWiki"
        Me.TxtWiki.Size = New System.Drawing.Size(453, 39)
        Me.TxtWiki.TabIndex = 50
        '
        'TxtDesc
        '
        Me.TxtDesc.AllowDrop = True
        Me.TxtDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDesc.Location = New System.Drawing.Point(79, 371)
        Me.TxtDesc.Multiline = True
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(413, 43)
        Me.TxtDesc.TabIndex = 51
        '
        'BtnName
        '
        Me.BtnName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnName.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnName.Location = New System.Drawing.Point(10, 295)
        Me.BtnName.Name = "BtnName"
        Me.BtnName.Size = New System.Drawing.Size(63, 25)
        Me.BtnName.TabIndex = 55
        Me.BtnName.Text = "Name"
        Me.BtnName.UseVisualStyleBackColor = True
        '
        'BtnWiki
        '
        Me.BtnWiki.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnWiki.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWiki.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWiki.Location = New System.Drawing.Point(10, 326)
        Me.BtnWiki.Name = "BtnWiki"
        Me.BtnWiki.Size = New System.Drawing.Size(63, 25)
        Me.BtnWiki.TabIndex = 56
        Me.BtnWiki.Text = "Wiki"
        Me.BtnWiki.UseVisualStyleBackColor = True
        '
        'BtnDesc
        '
        Me.BtnDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnDesc.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDesc.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDesc.Location = New System.Drawing.Point(10, 371)
        Me.BtnDesc.Name = "BtnDesc"
        Me.BtnDesc.Size = New System.Drawing.Size(63, 25)
        Me.BtnDesc.TabIndex = 57
        Me.BtnDesc.Text = "Desc"
        Me.BtnDesc.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.Location = New System.Drawing.Point(545, 285)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(64, 47)
        Me.BtnAdd.TabIndex = 58
        Me.BtnAdd.Text = "Add to list"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClear.Location = New System.Drawing.Point(545, 378)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(64, 47)
        Me.BtnClear.TabIndex = 59
        Me.BtnClear.Text = "Clear Values"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'LblDay
        '
        Me.LblDay.AutoSize = True
        Me.LblDay.Font = New System.Drawing.Font("Papyrus", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDay.Location = New System.Drawing.Point(416, 18)
        Me.LblDay.Name = "LblDay"
        Me.LblDay.Size = New System.Drawing.Size(60, 34)
        Me.LblDay.TabIndex = 60
        Me.LblDay.Text = "Day"
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.Font = New System.Drawing.Font("Papyrus", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonth.Location = New System.Drawing.Point(481, 18)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(80, 34)
        Me.LblMonth.TabIndex = 61
        Me.LblMonth.Text = "Month"
        '
        'LblYear
        '
        Me.LblYear.AutoSize = True
        Me.LblYear.Font = New System.Drawing.Font("Papyrus", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYear.Location = New System.Drawing.Point(567, 18)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(63, 34)
        Me.LblYear.TabIndex = 62
        Me.LblYear.Text = "Year"
        '
        'BtnSaveList
        '
        Me.BtnSaveList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveList.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSaveList.Location = New System.Drawing.Point(197, 426)
        Me.BtnSaveList.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnSaveList.Name = "BtnSaveList"
        Me.BtnSaveList.Size = New System.Drawing.Size(95, 29)
        Me.BtnSaveList.TabIndex = 63
        Me.BtnSaveList.Text = "Save List"
        Me.BtnSaveList.UseVisualStyleBackColor = True
        '
        'BtnLoadList
        '
        Me.BtnLoadList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadList.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnLoadList.Location = New System.Drawing.Point(316, 426)
        Me.BtnLoadList.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnLoadList.Name = "BtnLoadList"
        Me.BtnLoadList.Size = New System.Drawing.Size(95, 30)
        Me.BtnLoadList.TabIndex = 64
        Me.BtnLoadList.Text = "Load List"
        Me.BtnLoadList.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 644)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1257, 22)
        Me.StatusStrip1.TabIndex = 65
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(5, 17)
        '
        'BtnImportList
        '
        Me.BtnImportList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnImportList.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImportList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImportList.Location = New System.Drawing.Point(78, 427)
        Me.BtnImportList.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnImportList.Name = "BtnImportList"
        Me.BtnImportList.Size = New System.Drawing.Size(95, 29)
        Me.BtnImportList.TabIndex = 66
        Me.BtnImportList.Text = "Import List"
        Me.BtnImportList.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(18, 87)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.RtbText)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1223, 473)
        Me.SplitContainer1.SplitterDistance = 593
        Me.SplitContainer1.TabIndex = 67
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NudSentences)
        Me.Panel1.Controls.Add(Me.BtnClearList)
        Me.Panel1.Controls.Add(Me.BtnReplace)
        Me.Panel1.Controls.Add(Me.DgvAlso)
        Me.Panel1.Controls.Add(Me.BtnImportList)
        Me.Panel1.Controls.Add(Me.BtnClear)
        Me.Panel1.Controls.Add(Me.BtnName)
        Me.Panel1.Controls.Add(Me.BtnAdd)
        Me.Panel1.Controls.Add(Me.BtnLoadList)
        Me.Panel1.Controls.Add(Me.TxtDesc)
        Me.Panel1.Controls.Add(Me.BtnWiki)
        Me.Panel1.Controls.Add(Me.TxtWiki)
        Me.Panel1.Controls.Add(Me.BtnSaveList)
        Me.Panel1.Controls.Add(Me.TxtName)
        Me.Panel1.Controls.Add(Me.BtnDesc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(622, 469)
        Me.Panel1.TabIndex = 68
        '
        'BtnClearList
        '
        Me.BtnClearList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClearList.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClearList.Location = New System.Drawing.Point(435, 425)
        Me.BtnClearList.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.BtnClearList.Name = "BtnClearList"
        Me.BtnClearList.Size = New System.Drawing.Size(95, 29)
        Me.BtnClearList.TabIndex = 68
        Me.BtnClearList.Text = "Clear List"
        Me.BtnClearList.UseVisualStyleBackColor = True
        '
        'BtnReplace
        '
        Me.BtnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnReplace.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReplace.Location = New System.Drawing.Point(545, 338)
        Me.BtnReplace.Name = "BtnReplace"
        Me.BtnReplace.Size = New System.Drawing.Size(64, 34)
        Me.BtnReplace.TabIndex = 67
        Me.BtnReplace.Text = "Replace"
        Me.BtnReplace.UseVisualStyleBackColor = True
        '
        'NudSentences
        '
        Me.NudSentences.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NudSentences.Location = New System.Drawing.Point(498, 372)
        Me.NudSentences.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudSentences.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudSentences.Name = "NudSentences"
        Me.NudSentences.Size = New System.Drawing.Size(33, 24)
        Me.NudSentences.TabIndex = 69
        Me.NudSentences.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'FrmBotsdPost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1257, 666)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.LblMonth)
        Me.Controls.Add(Me.LblDay)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.BtnPasteUrl)
        Me.Controls.Add(Me.BtnPosted)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtUrl)
        Me.Controls.Add(Me.LblWpPostNo)
        Me.Controls.Add(Me.BtnCopyTitle)
        Me.Controls.Add(Me.TxtTitle)
        Me.Controls.Add(Me.BtnCopyText)
        Me.Controls.Add(Me.BtnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmBotsdPost"
        Me.Text = "FrmBotsdPost"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DgvAlso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents DgvAlso As DataGridView
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents alsoName As DataGridViewTextBoxColumn
    Friend WithEvents alsoWiki As DataGridViewTextBoxColumn
    Friend WithEvents alsoDesc As DataGridViewTextBoxColumn
    Friend WithEvents TxtName As TextBox
    Friend WithEvents TxtWiki As TextBox
    Friend WithEvents TxtDesc As TextBox
    Friend WithEvents BtnName As Button
    Friend WithEvents BtnWiki As Button
    Friend WithEvents BtnDesc As Button
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents LblDay As Label
    Friend WithEvents LblMonth As Label
    Friend WithEvents LblYear As Label
    Friend WithEvents BtnSaveList As Button
    Friend WithEvents BtnLoadList As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents BtnImportList As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnReplace As Button
    Friend WithEvents BtnClearList As Button
    Friend WithEvents NudSentences As NumericUpDown
End Class

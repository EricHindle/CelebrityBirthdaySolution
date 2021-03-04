<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBotsd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBotsd))
        Me.rtbTweet = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.NudPic1Horizontal = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rtbFile1 = New System.Windows.Forms.RichTextBox()
        Me.DgvPairs = New System.Windows.Forms.DataGridView()
        Me.pairYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairWpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairUrl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtForename1 = New System.Windows.Forms.TextBox()
        Me.TxtSurname1 = New System.Windows.Forms.TextBox()
        Me.TxtShortDesc1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblSeq1 = New System.Windows.Forms.Label()
        Me.chkSel1 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate1 = New System.Windows.Forms.Button()
        Me.LblId1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblSeq2 = New System.Windows.Forms.Label()
        Me.ChkSel2 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate2 = New System.Windows.Forms.Button()
        Me.LblId2 = New System.Windows.Forms.Label()
        Me.TxtShortDesc2 = New System.Windows.Forms.TextBox()
        Me.TxtForename2 = New System.Windows.Forms.TextBox()
        Me.TxtSurname2 = New System.Windows.Forms.TextBox()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.BtnSwap = New System.Windows.Forms.Button()
        Me.cmbTwitterUsers = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkImages = New System.Windows.Forms.CheckBox()
        Me.LblDay = New System.Windows.Forms.Label()
        Me.LblMonth = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblSeq3 = New System.Windows.Forms.Label()
        Me.ChkSel3 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate3 = New System.Windows.Forms.Button()
        Me.LblId3 = New System.Windows.Forms.Label()
        Me.TxtShortDesc3 = New System.Windows.Forms.TextBox()
        Me.TxtForename3 = New System.Windows.Forms.TextBox()
        Me.TxtSurname3 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.LblSeq4 = New System.Windows.Forms.Label()
        Me.ChkSel4 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate4 = New System.Windows.Forms.Button()
        Me.LblId4 = New System.Windows.Forms.Label()
        Me.TxtShortDesc4 = New System.Windows.Forms.TextBox()
        Me.TxtForename4 = New System.Windows.Forms.TextBox()
        Me.TxtSurname4 = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rbImageCentre = New System.Windows.Forms.RadioButton()
        Me.rbImageRight = New System.Windows.Forms.RadioButton()
        Me.rbImageLeft = New System.Windows.Forms.RadioButton()
        Me.BtnGenWp = New System.Windows.Forms.Button()
        Me.BtnClearImages = New System.Windows.Forms.Button()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.BtnWpPost = New System.Windows.Forms.Button()
        Me.BtnCopyAll = New System.Windows.Forms.Button()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.BtnAtoZ = New System.Windows.Forms.Button()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnAlterPostNo = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.LblSeq6 = New System.Windows.Forms.Label()
        Me.ChkSel6 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate6 = New System.Windows.Forms.Button()
        Me.LblId6 = New System.Windows.Forms.Label()
        Me.TxtShortDesc6 = New System.Windows.Forms.TextBox()
        Me.TxtForename6 = New System.Windows.Forms.TextBox()
        Me.TxtSurname6 = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.LblSeq5 = New System.Windows.Forms.Label()
        Me.ChkSel5 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate5 = New System.Windows.Forms.Button()
        Me.LblId5 = New System.Windows.Forms.Label()
        Me.TxtShortDesc5 = New System.Windows.Forms.TextBox()
        Me.TxtForename5 = New System.Windows.Forms.TextBox()
        Me.TxtSurname5 = New System.Windows.Forms.TextBox()
        Me.BtnRmvPostDetails = New System.Windows.Forms.Button()
        Me.ChkHandles = New System.Windows.Forms.CheckBox()
        Me.BtnFb = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPairs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbTweet
        '
        Me.rtbTweet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbTweet.BackColor = System.Drawing.Color.Black
        Me.rtbTweet.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbTweet.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweet.ForeColor = System.Drawing.Color.White
        Me.rtbTweet.Location = New System.Drawing.Point(1179, 6)
        Me.rtbTweet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rtbTweet.Name = "rtbTweet"
        Me.rtbTweet.Size = New System.Drawing.Size(200, 487)
        Me.rtbTweet.TabIndex = 32
        Me.rtbTweet.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ClearToolStripMenuItem, Me.SelectAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 114)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 655)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1392, 22)
        Me.StatusStrip1.TabIndex = 33
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(1210, 606)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 34
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(1060, 407)
        Me.BtnSend.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(111, 34)
        Me.BtnSend.TabIndex = 34
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'NudPic1Horizontal
        '
        Me.NudPic1Horizontal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NudPic1Horizontal.Location = New System.Drawing.Point(730, 44)
        Me.NudPic1Horizontal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NudPic1Horizontal.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudPic1Horizontal.Name = "NudPic1Horizontal"
        Me.NudPic1Horizontal.Size = New System.Drawing.Size(52, 23)
        Me.NudPic1Horizontal.TabIndex = 7
        Me.NudPic1Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudPic1Horizontal.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(731, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Width"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(806, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(366, 86)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'rtbFile1
        '
        Me.rtbFile1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFile1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbFile1.Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbFile1.Location = New System.Drawing.Point(730, 98)
        Me.rtbFile1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rtbFile1.Name = "rtbFile1"
        Me.rtbFile1.Size = New System.Drawing.Size(444, 226)
        Me.rtbFile1.TabIndex = 14
        Me.rtbFile1.Text = ""
        '
        'DgvPairs
        '
        Me.DgvPairs.AllowUserToAddRows = False
        Me.DgvPairs.AllowUserToDeleteRows = False
        Me.DgvPairs.AllowUserToResizeColumns = False
        Me.DgvPairs.AllowUserToResizeRows = False
        Me.DgvPairs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvPairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPairs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pairYear, Me.pairPerson1, Me.pairPerson2, Me.pairPerson3, Me.pairPerson4, Me.pairPerson5, Me.pairPerson6, Me.pairWpNo, Me.pairUrl, Me.pairId1, Me.pairId2, Me.pairId3, Me.pairId4, Me.pairId5, Me.pairId6})
        Me.DgvPairs.Location = New System.Drawing.Point(16, 98)
        Me.DgvPairs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DgvPairs.MultiSelect = False
        Me.DgvPairs.Name = "DgvPairs"
        Me.DgvPairs.RowHeadersVisible = False
        Me.DgvPairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPairs.Size = New System.Drawing.Size(703, 295)
        Me.DgvPairs.TabIndex = 36
        '
        'pairYear
        '
        Me.pairYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairYear.HeaderText = "Year"
        Me.pairYear.Name = "pairYear"
        Me.pairYear.Width = 50
        '
        'pairPerson1
        '
        Me.pairPerson1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson1.HeaderText = "Person1"
        Me.pairPerson1.Name = "pairPerson1"
        Me.pairPerson1.Width = 150
        '
        'pairPerson2
        '
        Me.pairPerson2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson2.HeaderText = "Person2"
        Me.pairPerson2.Name = "pairPerson2"
        Me.pairPerson2.Width = 150
        '
        'pairPerson3
        '
        Me.pairPerson3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson3.HeaderText = "Person3"
        Me.pairPerson3.Name = "pairPerson3"
        '
        'pairPerson4
        '
        Me.pairPerson4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson4.HeaderText = "Person4"
        Me.pairPerson4.Name = "pairPerson4"
        Me.pairPerson4.Width = 60
        '
        'pairPerson5
        '
        Me.pairPerson5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson5.HeaderText = "Person5"
        Me.pairPerson5.Name = "pairPerson5"
        Me.pairPerson5.Width = 60
        '
        'pairPerson6
        '
        Me.pairPerson6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson6.HeaderText = "Person6"
        Me.pairPerson6.Name = "pairPerson6"
        Me.pairPerson6.Width = 60
        '
        'pairWpNo
        '
        Me.pairWpNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairWpNo.HeaderText = "WP No"
        Me.pairWpNo.Name = "pairWpNo"
        Me.pairWpNo.Width = 70
        '
        'pairUrl
        '
        Me.pairUrl.HeaderText = "Url"
        Me.pairUrl.Name = "pairUrl"
        Me.pairUrl.ReadOnly = True
        Me.pairUrl.Visible = False
        '
        'pairId1
        '
        Me.pairId1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId1.HeaderText = "Id1"
        Me.pairId1.Name = "pairId1"
        Me.pairId1.Visible = False
        Me.pairId1.Width = 30
        '
        'pairId2
        '
        Me.pairId2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId2.HeaderText = "Id2"
        Me.pairId2.Name = "pairId2"
        Me.pairId2.Visible = False
        Me.pairId2.Width = 30
        '
        'pairId3
        '
        Me.pairId3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId3.HeaderText = "Id3"
        Me.pairId3.Name = "pairId3"
        Me.pairId3.Visible = False
        Me.pairId3.Width = 30
        '
        'pairId4
        '
        Me.pairId4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId4.HeaderText = "Id4"
        Me.pairId4.Name = "pairId4"
        Me.pairId4.Visible = False
        Me.pairId4.Width = 30
        '
        'pairId5
        '
        Me.pairId5.HeaderText = "Id5"
        Me.pairId5.Name = "pairId5"
        Me.pairId5.Visible = False
        '
        'pairId6
        '
        Me.pairId6.HeaderText = "Id6"
        Me.pairId6.Name = "pairId6"
        Me.pairId6.Visible = False
        '
        'TxtForename1
        '
        Me.TxtForename1.Location = New System.Drawing.Point(57, 21)
        Me.TxtForename1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtForename1.Name = "TxtForename1"
        Me.TxtForename1.Size = New System.Drawing.Size(83, 23)
        Me.TxtForename1.TabIndex = 37
        '
        'TxtSurname1
        '
        Me.TxtSurname1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname1.Location = New System.Drawing.Point(146, 21)
        Me.TxtSurname1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSurname1.Name = "TxtSurname1"
        Me.TxtSurname1.Size = New System.Drawing.Size(87, 23)
        Me.TxtSurname1.TabIndex = 38
        '
        'TxtShortDesc1
        '
        Me.TxtShortDesc1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc1.Location = New System.Drawing.Point(57, 54)
        Me.TxtShortDesc1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtShortDesc1.Name = "TxtShortDesc1"
        Me.TxtShortDesc1.Size = New System.Drawing.Size(229, 23)
        Me.TxtShortDesc1.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LblSeq1)
        Me.GroupBox1.Controls.Add(Me.chkSel1)
        Me.GroupBox1.Controls.Add(Me.BtnUpdate1)
        Me.GroupBox1.Controls.Add(Me.LblId1)
        Me.GroupBox1.Controls.Add(Me.TxtShortDesc1)
        Me.GroupBox1.Controls.Add(Me.TxtForename1)
        Me.GroupBox1.Controls.Add(Me.TxtSurname1)
        Me.GroupBox1.Location = New System.Drawing.Point(166, 465)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Person 1"
        '
        'LblSeq1
        '
        Me.LblSeq1.AutoSize = True
        Me.LblSeq1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeq1.Location = New System.Drawing.Point(294, 57)
        Me.LblSeq1.Name = "LblSeq1"
        Me.LblSeq1.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblSeq1.Size = New System.Drawing.Size(22, 17)
        Me.LblSeq1.TabIndex = 46
        Me.LblSeq1.Text = "0"
        '
        'chkSel1
        '
        Me.chkSel1.AutoSize = True
        Me.chkSel1.Location = New System.Drawing.Point(9, 58)
        Me.chkSel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkSel1.Name = "chkSel1"
        Me.chkSel1.Size = New System.Drawing.Size(15, 14)
        Me.chkSel1.TabIndex = 45
        Me.chkSel1.UseVisualStyleBackColor = True
        '
        'BtnUpdate1
        '
        Me.BtnUpdate1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate1.Location = New System.Drawing.Point(239, 21)
        Me.BtnUpdate1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpdate1.Name = "BtnUpdate1"
        Me.BtnUpdate1.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate1.TabIndex = 42
        Me.BtnUpdate1.Text = "Update"
        Me.BtnUpdate1.UseVisualStyleBackColor = True
        '
        'LblId1
        '
        Me.LblId1.AutoSize = True
        Me.LblId1.Location = New System.Drawing.Point(6, 25)
        Me.LblId1.Name = "LblId1"
        Me.LblId1.Size = New System.Drawing.Size(45, 16)
        Me.LblId1.TabIndex = 41
        Me.LblId1.Text = "Label1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.LblSeq2)
        Me.GroupBox2.Controls.Add(Me.ChkSel2)
        Me.GroupBox2.Controls.Add(Me.BtnUpdate2)
        Me.GroupBox2.Controls.Add(Me.LblId2)
        Me.GroupBox2.Controls.Add(Me.TxtShortDesc2)
        Me.GroupBox2.Controls.Add(Me.TxtForename2)
        Me.GroupBox2.Controls.Add(Me.TxtSurname2)
        Me.GroupBox2.Location = New System.Drawing.Point(166, 555)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Person 2"
        '
        'LblSeq2
        '
        Me.LblSeq2.AutoSize = True
        Me.LblSeq2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeq2.Location = New System.Drawing.Point(294, 55)
        Me.LblSeq2.Name = "LblSeq2"
        Me.LblSeq2.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblSeq2.Size = New System.Drawing.Size(22, 17)
        Me.LblSeq2.TabIndex = 47
        Me.LblSeq2.Text = "0"
        '
        'ChkSel2
        '
        Me.ChkSel2.AutoSize = True
        Me.ChkSel2.Location = New System.Drawing.Point(9, 57)
        Me.ChkSel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkSel2.Name = "ChkSel2"
        Me.ChkSel2.Size = New System.Drawing.Size(15, 14)
        Me.ChkSel2.TabIndex = 44
        Me.ChkSel2.UseVisualStyleBackColor = True
        '
        'BtnUpdate2
        '
        Me.BtnUpdate2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate2.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate2.Location = New System.Drawing.Point(239, 22)
        Me.BtnUpdate2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpdate2.Name = "BtnUpdate2"
        Me.BtnUpdate2.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate2.TabIndex = 43
        Me.BtnUpdate2.Text = "Update"
        Me.BtnUpdate2.UseVisualStyleBackColor = True
        '
        'LblId2
        '
        Me.LblId2.AutoSize = True
        Me.LblId2.Location = New System.Drawing.Point(6, 25)
        Me.LblId2.Name = "LblId2"
        Me.LblId2.Size = New System.Drawing.Size(45, 16)
        Me.LblId2.TabIndex = 42
        Me.LblId2.Text = "Label2"
        '
        'TxtShortDesc2
        '
        Me.TxtShortDesc2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc2.Location = New System.Drawing.Point(57, 52)
        Me.TxtShortDesc2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtShortDesc2.Name = "TxtShortDesc2"
        Me.TxtShortDesc2.Size = New System.Drawing.Size(229, 23)
        Me.TxtShortDesc2.TabIndex = 39
        '
        'TxtForename2
        '
        Me.TxtForename2.Location = New System.Drawing.Point(57, 22)
        Me.TxtForename2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtForename2.Name = "TxtForename2"
        Me.TxtForename2.Size = New System.Drawing.Size(83, 23)
        Me.TxtForename2.TabIndex = 37
        '
        'TxtSurname2
        '
        Me.TxtSurname2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname2.Location = New System.Drawing.Point(146, 22)
        Me.TxtSurname2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSurname2.Name = "TxtSurname2"
        Me.TxtSurname2.Size = New System.Drawing.Size(87, 23)
        Me.TxtSurname2.TabIndex = 38
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGenerate.Location = New System.Drawing.Point(895, 359)
        Me.BtnGenerate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(111, 33)
        Me.BtnGenerate.TabIndex = 42
        Me.BtnGenerate.Text = "Generate"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'BtnSwap
        '
        Me.BtnSwap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSwap.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSwap.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSwap.Location = New System.Drawing.Point(259, 407)
        Me.BtnSwap.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSwap.Name = "BtnSwap"
        Me.BtnSwap.Size = New System.Drawing.Size(77, 34)
        Me.BtnSwap.TabIndex = 43
        Me.BtnSwap.Text = "Swap"
        Me.BtnSwap.UseVisualStyleBackColor = True
        '
        'cmbTwitterUsers
        '
        Me.cmbTwitterUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbTwitterUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTwitterUsers.FormattingEnabled = True
        Me.cmbTwitterUsers.Location = New System.Drawing.Point(917, 412)
        Me.cmbTwitterUsers.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbTwitterUsers.Name = "cmbTwitterUsers"
        Me.cmbTwitterUsers.Size = New System.Drawing.Size(126, 24)
        Me.cmbTwitterUsers.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(849, 415)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Send As"
        '
        'chkImages
        '
        Me.chkImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkImages.AutoSize = True
        Me.chkImages.Checked = True
        Me.chkImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImages.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkImages.Location = New System.Drawing.Point(730, 330)
        Me.chkImages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkImages.Name = "chkImages"
        Me.chkImages.Size = New System.Drawing.Size(107, 23)
        Me.chkImages.TabIndex = 46
        Me.chkImages.Text = "Include Images"
        Me.chkImages.UseVisualStyleBackColor = True
        '
        'LblDay
        '
        Me.LblDay.AutoSize = True
        Me.LblDay.Font = New System.Drawing.Font("Papyrus", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDay.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblDay.Location = New System.Drawing.Point(412, 15)
        Me.LblDay.Name = "LblDay"
        Me.LblDay.Size = New System.Drawing.Size(24, 30)
        Me.LblDay.TabIndex = 47
        Me.LblDay.Text = "1"
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.Font = New System.Drawing.Font("Papyrus", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonth.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblMonth.Location = New System.Drawing.Point(481, 15)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(80, 30)
        Me.LblMonth.TabIndex = 48
        Me.LblMonth.Text = "January"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.LblSeq3)
        Me.GroupBox3.Controls.Add(Me.ChkSel3)
        Me.GroupBox3.Controls.Add(Me.BtnUpdate3)
        Me.GroupBox3.Controls.Add(Me.LblId3)
        Me.GroupBox3.Controls.Add(Me.TxtShortDesc3)
        Me.GroupBox3.Controls.Add(Me.TxtForename3)
        Me.GroupBox3.Controls.Add(Me.TxtSurname3)
        Me.GroupBox3.Location = New System.Drawing.Point(493, 465)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox3.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Person 3"
        '
        'LblSeq3
        '
        Me.LblSeq3.AutoSize = True
        Me.LblSeq3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeq3.Location = New System.Drawing.Point(292, 57)
        Me.LblSeq3.Name = "LblSeq3"
        Me.LblSeq3.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblSeq3.Size = New System.Drawing.Size(22, 17)
        Me.LblSeq3.TabIndex = 47
        Me.LblSeq3.Text = "0"
        '
        'ChkSel3
        '
        Me.ChkSel3.AutoSize = True
        Me.ChkSel3.Location = New System.Drawing.Point(9, 58)
        Me.ChkSel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkSel3.Name = "ChkSel3"
        Me.ChkSel3.Size = New System.Drawing.Size(15, 14)
        Me.ChkSel3.TabIndex = 45
        Me.ChkSel3.UseVisualStyleBackColor = True
        '
        'BtnUpdate3
        '
        Me.BtnUpdate3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate3.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate3.Location = New System.Drawing.Point(239, 21)
        Me.BtnUpdate3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpdate3.Name = "BtnUpdate3"
        Me.BtnUpdate3.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate3.TabIndex = 43
        Me.BtnUpdate3.Text = "Update"
        Me.BtnUpdate3.UseVisualStyleBackColor = True
        '
        'LblId3
        '
        Me.LblId3.AutoSize = True
        Me.LblId3.Location = New System.Drawing.Point(6, 25)
        Me.LblId3.Name = "LblId3"
        Me.LblId3.Size = New System.Drawing.Size(45, 16)
        Me.LblId3.TabIndex = 42
        Me.LblId3.Text = "Label3"
        '
        'TxtShortDesc3
        '
        Me.TxtShortDesc3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc3.Location = New System.Drawing.Point(57, 54)
        Me.TxtShortDesc3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtShortDesc3.Name = "TxtShortDesc3"
        Me.TxtShortDesc3.Size = New System.Drawing.Size(229, 23)
        Me.TxtShortDesc3.TabIndex = 39
        '
        'TxtForename3
        '
        Me.TxtForename3.Location = New System.Drawing.Point(57, 21)
        Me.TxtForename3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtForename3.Name = "TxtForename3"
        Me.TxtForename3.Size = New System.Drawing.Size(83, 23)
        Me.TxtForename3.TabIndex = 37
        '
        'TxtSurname3
        '
        Me.TxtSurname3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname3.Location = New System.Drawing.Point(146, 21)
        Me.TxtSurname3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSurname3.Name = "TxtSurname3"
        Me.TxtSurname3.Size = New System.Drawing.Size(87, 23)
        Me.TxtSurname3.TabIndex = 38
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.LblSeq4)
        Me.GroupBox4.Controls.Add(Me.ChkSel4)
        Me.GroupBox4.Controls.Add(Me.BtnUpdate4)
        Me.GroupBox4.Controls.Add(Me.LblId4)
        Me.GroupBox4.Controls.Add(Me.TxtShortDesc4)
        Me.GroupBox4.Controls.Add(Me.TxtForename4)
        Me.GroupBox4.Controls.Add(Me.TxtSurname4)
        Me.GroupBox4.Location = New System.Drawing.Point(493, 555)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Person 4"
        '
        'LblSeq4
        '
        Me.LblSeq4.AutoSize = True
        Me.LblSeq4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeq4.Location = New System.Drawing.Point(292, 55)
        Me.LblSeq4.Name = "LblSeq4"
        Me.LblSeq4.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblSeq4.Size = New System.Drawing.Size(22, 17)
        Me.LblSeq4.TabIndex = 47
        Me.LblSeq4.Text = "0"
        '
        'ChkSel4
        '
        Me.ChkSel4.AutoSize = True
        Me.ChkSel4.Location = New System.Drawing.Point(9, 57)
        Me.ChkSel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkSel4.Name = "ChkSel4"
        Me.ChkSel4.Size = New System.Drawing.Size(15, 14)
        Me.ChkSel4.TabIndex = 46
        Me.ChkSel4.UseVisualStyleBackColor = True
        '
        'BtnUpdate4
        '
        Me.BtnUpdate4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate4.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate4.Location = New System.Drawing.Point(239, 22)
        Me.BtnUpdate4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpdate4.Name = "BtnUpdate4"
        Me.BtnUpdate4.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate4.TabIndex = 43
        Me.BtnUpdate4.Text = "Update"
        Me.BtnUpdate4.UseVisualStyleBackColor = True
        '
        'LblId4
        '
        Me.LblId4.AutoSize = True
        Me.LblId4.Location = New System.Drawing.Point(6, 25)
        Me.LblId4.Name = "LblId4"
        Me.LblId4.Size = New System.Drawing.Size(45, 16)
        Me.LblId4.TabIndex = 42
        Me.LblId4.Text = "Label4"
        '
        'TxtShortDesc4
        '
        Me.TxtShortDesc4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc4.Location = New System.Drawing.Point(57, 52)
        Me.TxtShortDesc4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtShortDesc4.Name = "TxtShortDesc4"
        Me.TxtShortDesc4.Size = New System.Drawing.Size(229, 23)
        Me.TxtShortDesc4.TabIndex = 39
        '
        'TxtForename4
        '
        Me.TxtForename4.Location = New System.Drawing.Point(57, 22)
        Me.TxtForename4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtForename4.Name = "TxtForename4"
        Me.TxtForename4.Size = New System.Drawing.Size(83, 23)
        Me.TxtForename4.TabIndex = 37
        '
        'TxtSurname4
        '
        Me.TxtSurname4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname4.Location = New System.Drawing.Point(146, 22)
        Me.TxtSurname4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSurname4.Name = "TxtSurname4"
        Me.TxtSurname4.Size = New System.Drawing.Size(87, 23)
        Me.TxtSurname4.TabIndex = 38
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.rbImageCentre)
        Me.GroupBox5.Controls.Add(Me.rbImageRight)
        Me.GroupBox5.Controls.Add(Me.rbImageLeft)
        Me.GroupBox5.Location = New System.Drawing.Point(1210, 497)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Size = New System.Drawing.Size(139, 103)
        Me.GroupBox5.TabIndex = 49
        Me.GroupBox5.TabStop = False
        '
        'rbImageCentre
        '
        Me.rbImageCentre.AutoSize = True
        Me.rbImageCentre.Checked = True
        Me.rbImageCentre.Font = New System.Drawing.Font("Papyrus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImageCentre.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbImageCentre.Location = New System.Drawing.Point(23, 71)
        Me.rbImageCentre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbImageCentre.Name = "rbImageCentre"
        Me.rbImageCentre.Size = New System.Drawing.Size(92, 22)
        Me.rbImageCentre.TabIndex = 2
        Me.rbImageCentre.TabStop = True
        Me.rbImageCentre.Text = "ImageCentre"
        Me.rbImageCentre.UseVisualStyleBackColor = True
        '
        'rbImageRight
        '
        Me.rbImageRight.AutoSize = True
        Me.rbImageRight.Font = New System.Drawing.Font("Papyrus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImageRight.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbImageRight.Location = New System.Drawing.Point(23, 44)
        Me.rbImageRight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbImageRight.Name = "rbImageRight"
        Me.rbImageRight.Size = New System.Drawing.Size(84, 22)
        Me.rbImageRight.TabIndex = 1
        Me.rbImageRight.Text = "Image Right"
        Me.rbImageRight.UseVisualStyleBackColor = True
        '
        'rbImageLeft
        '
        Me.rbImageLeft.AutoSize = True
        Me.rbImageLeft.Font = New System.Drawing.Font("Papyrus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImageLeft.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbImageLeft.Location = New System.Drawing.Point(23, 16)
        Me.rbImageLeft.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbImageLeft.Name = "rbImageLeft"
        Me.rbImageLeft.Size = New System.Drawing.Size(77, 22)
        Me.rbImageLeft.TabIndex = 0
        Me.rbImageLeft.Text = "ImageLeft"
        Me.rbImageLeft.UseVisualStyleBackColor = True
        '
        'BtnGenWp
        '
        Me.BtnGenWp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGenWp.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenWp.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGenWp.Location = New System.Drawing.Point(12, 409)
        Me.BtnGenWp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnGenWp.Name = "BtnGenWp"
        Me.BtnGenWp.Size = New System.Drawing.Size(138, 41)
        Me.BtnGenWp.TabIndex = 50
        Me.BtnGenWp.Text = "WordPress List"
        Me.BtnGenWp.UseVisualStyleBackColor = True
        '
        'BtnClearImages
        '
        Me.BtnClearImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClearImages.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClearImages.Location = New System.Drawing.Point(730, 407)
        Me.BtnClearImages.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnClearImages.Name = "BtnClearImages"
        Me.BtnClearImages.Size = New System.Drawing.Size(107, 34)
        Me.BtnClearImages.TabIndex = 51
        Me.BtnClearImages.Text = "Clear Images"
        Me.BtnClearImages.UseVisualStyleBackColor = True
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveImage.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSaveImage.Location = New System.Drawing.Point(730, 359)
        Me.BtnSaveImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(107, 34)
        Me.BtnSaveImage.TabIndex = 52
        Me.BtnSaveImage.Text = "Save Image"
        Me.BtnSaveImage.UseVisualStyleBackColor = True
        '
        'BtnWpPost
        '
        Me.BtnWpPost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnWpPost.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWpPost.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWpPost.Location = New System.Drawing.Point(12, 457)
        Me.BtnWpPost.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnWpPost.Name = "BtnWpPost"
        Me.BtnWpPost.Size = New System.Drawing.Size(138, 41)
        Me.BtnWpPost.TabIndex = 53
        Me.BtnWpPost.Text = "WordPress Post"
        Me.BtnWpPost.UseVisualStyleBackColor = True
        '
        'BtnCopyAll
        '
        Me.BtnCopyAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyAll.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyAll.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyAll.Location = New System.Drawing.Point(1060, 359)
        Me.BtnCopyAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnCopyAll.Name = "BtnCopyAll"
        Me.BtnCopyAll.Size = New System.Drawing.Size(111, 33)
        Me.BtnCopyAll.TabIndex = 54
        Me.BtnCopyAll.Text = "Copy All"
        Me.BtnCopyAll.UseVisualStyleBackColor = True
        '
        'BtnToday
        '
        Me.BtnToday.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToday.Location = New System.Drawing.Point(16, 16)
        Me.BtnToday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(75, 30)
        Me.BtnToday.TabIndex = 57
        Me.BtnToday.Text = "Today"
        Me.BtnToday.UseVisualStyleBackColor = True
        '
        'cboDay
        '
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(16, 57)
        Me.cboDay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(95, 27)
        Me.cboDay.TabIndex = 55
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(119, 57)
        Me.cboMonth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(240, 27)
        Me.cboMonth.TabIndex = 56
        '
        'BtnSelect
        '
        Me.BtnSelect.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSelect.Location = New System.Drawing.Point(365, 54)
        Me.BtnSelect.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(101, 33)
        Me.BtnSelect.TabIndex = 58
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'BtnAtoZ
        '
        Me.BtnAtoZ.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAtoZ.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAtoZ.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAtoZ.Location = New System.Drawing.Point(12, 505)
        Me.BtnAtoZ.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnAtoZ.Name = "BtnAtoZ"
        Me.BtnAtoZ.Size = New System.Drawing.Size(138, 39)
        Me.BtnAtoZ.TabIndex = 59
        Me.BtnAtoZ.Text = "A - Z"
        Me.BtnAtoZ.UseVisualStyleBackColor = True
        '
        'BtnRemove
        '
        Me.BtnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRemove.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRemove.Location = New System.Drawing.Point(374, 407)
        Me.BtnRemove.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(77, 34)
        Me.BtnRemove.TabIndex = 60
        Me.BtnRemove.Text = "Remove"
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAlterPostNo
        '
        Me.BtnAlterPostNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAlterPostNo.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAlterPostNo.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAlterPostNo.Location = New System.Drawing.Point(12, 551)
        Me.BtnAlterPostNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnAlterPostNo.Name = "BtnAlterPostNo"
        Me.BtnAlterPostNo.Size = New System.Drawing.Size(138, 39)
        Me.BtnAlterPostNo.TabIndex = 61
        Me.BtnAlterPostNo.Text = "Alter Post #"
        Me.BtnAlterPostNo.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.LblSeq6)
        Me.GroupBox6.Controls.Add(Me.ChkSel6)
        Me.GroupBox6.Controls.Add(Me.BtnUpdate6)
        Me.GroupBox6.Controls.Add(Me.LblId6)
        Me.GroupBox6.Controls.Add(Me.TxtShortDesc6)
        Me.GroupBox6.Controls.Add(Me.TxtForename6)
        Me.GroupBox6.Controls.Add(Me.TxtSurname6)
        Me.GroupBox6.Location = New System.Drawing.Point(822, 555)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox6.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox6.TabIndex = 47
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Person 6"
        '
        'LblSeq6
        '
        Me.LblSeq6.AutoSize = True
        Me.LblSeq6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeq6.Location = New System.Drawing.Point(292, 55)
        Me.LblSeq6.Name = "LblSeq6"
        Me.LblSeq6.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblSeq6.Size = New System.Drawing.Size(22, 17)
        Me.LblSeq6.TabIndex = 47
        Me.LblSeq6.Text = "0"
        '
        'ChkSel6
        '
        Me.ChkSel6.AutoSize = True
        Me.ChkSel6.Location = New System.Drawing.Point(9, 57)
        Me.ChkSel6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkSel6.Name = "ChkSel6"
        Me.ChkSel6.Size = New System.Drawing.Size(15, 14)
        Me.ChkSel6.TabIndex = 46
        Me.ChkSel6.UseVisualStyleBackColor = True
        '
        'BtnUpdate6
        '
        Me.BtnUpdate6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate6.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate6.Location = New System.Drawing.Point(239, 21)
        Me.BtnUpdate6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpdate6.Name = "BtnUpdate6"
        Me.BtnUpdate6.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate6.TabIndex = 43
        Me.BtnUpdate6.Text = "Update"
        Me.BtnUpdate6.UseVisualStyleBackColor = True
        '
        'LblId6
        '
        Me.LblId6.AutoSize = True
        Me.LblId6.Location = New System.Drawing.Point(6, 25)
        Me.LblId6.Name = "LblId6"
        Me.LblId6.Size = New System.Drawing.Size(45, 16)
        Me.LblId6.TabIndex = 42
        Me.LblId6.Text = "Label6"
        '
        'TxtShortDesc6
        '
        Me.TxtShortDesc6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc6.Location = New System.Drawing.Point(57, 52)
        Me.TxtShortDesc6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtShortDesc6.Name = "TxtShortDesc6"
        Me.TxtShortDesc6.Size = New System.Drawing.Size(229, 23)
        Me.TxtShortDesc6.TabIndex = 39
        '
        'TxtForename6
        '
        Me.TxtForename6.Location = New System.Drawing.Point(57, 22)
        Me.TxtForename6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtForename6.Name = "TxtForename6"
        Me.TxtForename6.Size = New System.Drawing.Size(83, 23)
        Me.TxtForename6.TabIndex = 37
        '
        'TxtSurname6
        '
        Me.TxtSurname6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname6.Location = New System.Drawing.Point(146, 22)
        Me.TxtSurname6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSurname6.Name = "TxtSurname6"
        Me.TxtSurname6.Size = New System.Drawing.Size(87, 23)
        Me.TxtSurname6.TabIndex = 38
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.LblSeq5)
        Me.GroupBox7.Controls.Add(Me.ChkSel5)
        Me.GroupBox7.Controls.Add(Me.BtnUpdate5)
        Me.GroupBox7.Controls.Add(Me.LblId5)
        Me.GroupBox7.Controls.Add(Me.TxtShortDesc5)
        Me.GroupBox7.Controls.Add(Me.TxtForename5)
        Me.GroupBox7.Controls.Add(Me.TxtSurname5)
        Me.GroupBox7.Location = New System.Drawing.Point(822, 465)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox7.Size = New System.Drawing.Size(322, 84)
        Me.GroupBox7.TabIndex = 48
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Person 5"
        '
        'LblSeq5
        '
        Me.LblSeq5.AutoSize = True
        Me.LblSeq5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeq5.Location = New System.Drawing.Point(292, 57)
        Me.LblSeq5.Name = "LblSeq5"
        Me.LblSeq5.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblSeq5.Size = New System.Drawing.Size(22, 17)
        Me.LblSeq5.TabIndex = 47
        Me.LblSeq5.Text = "0"
        '
        'ChkSel5
        '
        Me.ChkSel5.AutoSize = True
        Me.ChkSel5.Location = New System.Drawing.Point(9, 58)
        Me.ChkSel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkSel5.Name = "ChkSel5"
        Me.ChkSel5.Size = New System.Drawing.Size(15, 14)
        Me.ChkSel5.TabIndex = 45
        Me.ChkSel5.UseVisualStyleBackColor = True
        '
        'BtnUpdate5
        '
        Me.BtnUpdate5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdate5.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate5.Location = New System.Drawing.Point(239, 20)
        Me.BtnUpdate5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnUpdate5.Name = "BtnUpdate5"
        Me.BtnUpdate5.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate5.TabIndex = 43
        Me.BtnUpdate5.Text = "Update"
        Me.BtnUpdate5.UseVisualStyleBackColor = True
        '
        'LblId5
        '
        Me.LblId5.AutoSize = True
        Me.LblId5.Location = New System.Drawing.Point(6, 25)
        Me.LblId5.Name = "LblId5"
        Me.LblId5.Size = New System.Drawing.Size(45, 16)
        Me.LblId5.TabIndex = 42
        Me.LblId5.Text = "Label5"
        '
        'TxtShortDesc5
        '
        Me.TxtShortDesc5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc5.Location = New System.Drawing.Point(57, 54)
        Me.TxtShortDesc5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtShortDesc5.Name = "TxtShortDesc5"
        Me.TxtShortDesc5.Size = New System.Drawing.Size(229, 23)
        Me.TxtShortDesc5.TabIndex = 39
        '
        'TxtForename5
        '
        Me.TxtForename5.Location = New System.Drawing.Point(57, 21)
        Me.TxtForename5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtForename5.Name = "TxtForename5"
        Me.TxtForename5.Size = New System.Drawing.Size(83, 23)
        Me.TxtForename5.TabIndex = 37
        '
        'TxtSurname5
        '
        Me.TxtSurname5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname5.Location = New System.Drawing.Point(146, 21)
        Me.TxtSurname5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TxtSurname5.Name = "TxtSurname5"
        Me.TxtSurname5.Size = New System.Drawing.Size(87, 23)
        Me.TxtSurname5.TabIndex = 38
        '
        'BtnRmvPostDetails
        '
        Me.BtnRmvPostDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRmvPostDetails.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvPostDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvPostDetails.Location = New System.Drawing.Point(12, 599)
        Me.BtnRmvPostDetails.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnRmvPostDetails.Name = "BtnRmvPostDetails"
        Me.BtnRmvPostDetails.Size = New System.Drawing.Size(138, 39)
        Me.BtnRmvPostDetails.TabIndex = 62
        Me.BtnRmvPostDetails.Text = "Remove Post Details"
        Me.BtnRmvPostDetails.UseVisualStyleBackColor = True
        '
        'ChkHandles
        '
        Me.ChkHandles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkHandles.AutoSize = True
        Me.ChkHandles.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkHandles.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ChkHandles.Location = New System.Drawing.Point(867, 330)
        Me.ChkHandles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChkHandles.Name = "ChkHandles"
        Me.ChkHandles.Size = New System.Drawing.Size(117, 23)
        Me.ChkHandles.TabIndex = 63
        Me.ChkHandles.Text = "Include Handles"
        Me.ChkHandles.UseVisualStyleBackColor = True
        '
        'BtnFb
        '
        Me.BtnFb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnFb.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFb.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnFb.Location = New System.Drawing.Point(609, 407)
        Me.BtnFb.Name = "BtnFb"
        Me.BtnFb.Size = New System.Drawing.Size(83, 34)
        Me.BtnFb.TabIndex = 64
        Me.BtnFb.Text = "Facebook"
        Me.BtnFb.UseVisualStyleBackColor = True
        '
        'FrmBotsd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1392, 677)
        Me.Controls.Add(Me.BtnFb)
        Me.Controls.Add(Me.ChkHandles)
        Me.Controls.Add(Me.BtnRmvPostDetails)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.BtnAlterPostNo)
        Me.Controls.Add(Me.BtnRemove)
        Me.Controls.Add(Me.BtnAtoZ)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnToday)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.BtnCopyAll)
        Me.Controls.Add(Me.BtnWpPost)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.BtnClearImages)
        Me.Controls.Add(Me.BtnGenWp)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.LblMonth)
        Me.Controls.Add(Me.LblDay)
        Me.Controls.Add(Me.chkImages)
        Me.Controls.Add(Me.cmbTwitterUsers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnSwap)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rtbFile1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnSend)
        Me.Controls.Add(Me.DgvPairs)
        Me.Controls.Add(Me.NudPic1Horizontal)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.rtbTweet)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(1400, 600)
        Me.Name = "FrmBotsd"
        Me.Text = "Born On The Same Day"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPairs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtbTweet As RichTextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btnClose As Button
    Friend WithEvents BtnSend As Button
    Friend WithEvents NudPic1Horizontal As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents rtbFile1 As RichTextBox
    Friend WithEvents DgvPairs As DataGridView
    Friend WithEvents TxtForename1 As TextBox
    Friend WithEvents TxtSurname1 As TextBox
    Friend WithEvents TxtShortDesc1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblId1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblId2 As Label
    Friend WithEvents TxtShortDesc2 As TextBox
    Friend WithEvents TxtForename2 As TextBox
    Friend WithEvents TxtSurname2 As TextBox
    Friend WithEvents BtnUpdate1 As Button
    Friend WithEvents BtnUpdate2 As Button
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents BtnSwap As Button
    Friend WithEvents cmbTwitterUsers As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents chkImages As CheckBox
    Friend WithEvents LblDay As Label
    Friend WithEvents LblMonth As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BtnUpdate3 As Button
    Friend WithEvents LblId3 As Label
    Friend WithEvents TxtShortDesc3 As TextBox
    Friend WithEvents TxtForename3 As TextBox
    Friend WithEvents TxtSurname3 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnUpdate4 As Button
    Friend WithEvents LblId4 As Label
    Friend WithEvents TxtShortDesc4 As TextBox
    Friend WithEvents TxtForename4 As TextBox
    Friend WithEvents TxtSurname4 As TextBox
    Friend WithEvents chkSel1 As CheckBox
    Friend WithEvents ChkSel2 As CheckBox
    Friend WithEvents ChkSel3 As CheckBox
    Friend WithEvents ChkSel4 As CheckBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents rbImageCentre As RadioButton
    Friend WithEvents rbImageRight As RadioButton
    Friend WithEvents rbImageLeft As RadioButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnGenWp As Button
    Friend WithEvents BtnClearImages As Button
    Friend WithEvents BtnSaveImage As Button
    Friend WithEvents BtnWpPost As Button
    Friend WithEvents BtnCopyAll As Button
    Friend WithEvents BtnToday As Button
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents BtnSelect As Button
    Friend WithEvents BtnAtoZ As Button
    Friend WithEvents BtnRemove As Button
    Friend WithEvents BtnAlterPostNo As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ChkSel6 As CheckBox
    Friend WithEvents BtnUpdate6 As Button
    Friend WithEvents LblId6 As Label
    Friend WithEvents TxtShortDesc6 As TextBox
    Friend WithEvents TxtForename6 As TextBox
    Friend WithEvents TxtSurname6 As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents ChkSel5 As CheckBox
    Friend WithEvents BtnUpdate5 As Button
    Friend WithEvents LblId5 As Label
    Friend WithEvents TxtShortDesc5 As TextBox
    Friend WithEvents TxtForename5 As TextBox
    Friend WithEvents TxtSurname5 As TextBox
    Friend WithEvents pairYear As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson1 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson2 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson3 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson4 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson5 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson6 As DataGridViewTextBoxColumn
    Friend WithEvents pairWpNo As DataGridViewTextBoxColumn
    Friend WithEvents pairUrl As DataGridViewTextBoxColumn
    Friend WithEvents pairId1 As DataGridViewTextBoxColumn
    Friend WithEvents pairId2 As DataGridViewTextBoxColumn
    Friend WithEvents pairId3 As DataGridViewTextBoxColumn
    Friend WithEvents pairId4 As DataGridViewTextBoxColumn
    Friend WithEvents pairId5 As DataGridViewTextBoxColumn
    Friend WithEvents pairId6 As DataGridViewTextBoxColumn
    Friend WithEvents BtnRmvPostDetails As Button
    Friend WithEvents ChkHandles As CheckBox
    Friend WithEvents LblSeq1 As Label
    Friend WithEvents LblSeq2 As Label
    Friend WithEvents LblSeq3 As Label
    Friend WithEvents LblSeq4 As Label
    Friend WithEvents LblSeq6 As Label
    Friend WithEvents LblSeq5 As Label
    Friend WithEvents BtnFb As Button
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBotsd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBotsd))
        Me.rtbTweet = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.NudPic1Horizontal = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rtbFile1 = New System.Windows.Forms.RichTextBox()
        Me.dgvPairs = New System.Windows.Forms.DataGridView()
        Me.pairPerson1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairPerson4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtForename1 = New System.Windows.Forms.TextBox()
        Me.TxtSurname1 = New System.Windows.Forms.TextBox()
        Me.TxtShortDesc1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSel1 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate1 = New System.Windows.Forms.Button()
        Me.LblId1 = New System.Windows.Forms.Label()
        Me.DtpDob1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ChkSel2 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate2 = New System.Windows.Forms.Button()
        Me.LblId2 = New System.Windows.Forms.Label()
        Me.DtpDob2 = New System.Windows.Forms.DateTimePicker()
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
        Me.ChkSel3 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate3 = New System.Windows.Forms.Button()
        Me.LblId3 = New System.Windows.Forms.Label()
        Me.DtpDob3 = New System.Windows.Forms.DateTimePicker()
        Me.TxtShortDesc3 = New System.Windows.Forms.TextBox()
        Me.TxtForename3 = New System.Windows.Forms.TextBox()
        Me.TxtSurname3 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChkSel4 = New System.Windows.Forms.CheckBox()
        Me.BtnUpdate4 = New System.Windows.Forms.Button()
        Me.LblId4 = New System.Windows.Forms.Label()
        Me.DtpDob4 = New System.Windows.Forms.DateTimePicker()
        Me.TxtShortDesc4 = New System.Windows.Forms.TextBox()
        Me.TxtForename4 = New System.Windows.Forms.TextBox()
        Me.TxtSurname4 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPairs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbTweet
        '
        Me.rtbTweet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbTweet.BackColor = System.Drawing.Color.Black
        Me.rtbTweet.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweet.ForeColor = System.Drawing.Color.White
        Me.rtbTweet.Location = New System.Drawing.Point(1002, 6)
        Me.rtbTweet.Name = "rtbTweet"
        Me.rtbTweet.Size = New System.Drawing.Size(200, 353)
        Me.rtbTweet.TabIndex = 32
        Me.rtbTweet.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 590)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1214, 22)
        Me.StatusStrip1.TabIndex = 33
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LblStatus.Size = New System.Drawing.Size(3, 17)
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(1063, 551)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 34
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(864, 326)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(126, 33)
        Me.BtnSend.TabIndex = 34
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'NudPic1Horizontal
        '
        Me.NudPic1Horizontal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NudPic1Horizontal.Location = New System.Drawing.Point(561, 35)
        Me.NudPic1Horizontal.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NudPic1Horizontal.Name = "NudPic1Horizontal"
        Me.NudPic1Horizontal.Size = New System.Drawing.Size(53, 23)
        Me.NudPic1Horizontal.TabIndex = 7
        Me.NudPic1Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudPic1Horizontal.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(573, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Width"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(630, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(366, 62)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'rtbFile1
        '
        Me.rtbFile1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFile1.Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbFile1.Location = New System.Drawing.Point(633, 74)
        Me.rtbFile1.Name = "rtbFile1"
        Me.rtbFile1.Size = New System.Drawing.Size(363, 207)
        Me.rtbFile1.TabIndex = 14
        Me.rtbFile1.Text = ""
        '
        'dgvPairs
        '
        Me.dgvPairs.AllowUserToAddRows = False
        Me.dgvPairs.AllowUserToDeleteRows = False
        Me.dgvPairs.AllowUserToResizeColumns = False
        Me.dgvPairs.AllowUserToResizeRows = False
        Me.dgvPairs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPairs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pairPerson1, Me.pairPerson2, Me.pairPerson3, Me.pairPerson4, Me.pairId1, Me.pairId2, Me.pairId3, Me.pairId4})
        Me.dgvPairs.Location = New System.Drawing.Point(12, 74)
        Me.dgvPairs.MultiSelect = False
        Me.dgvPairs.Name = "dgvPairs"
        Me.dgvPairs.ReadOnly = True
        Me.dgvPairs.RowHeadersVisible = False
        Me.dgvPairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPairs.Size = New System.Drawing.Size(605, 285)
        Me.dgvPairs.TabIndex = 36
        '
        'pairPerson1
        '
        Me.pairPerson1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson1.HeaderText = "Person1"
        Me.pairPerson1.Name = "pairPerson1"
        Me.pairPerson1.ReadOnly = True
        Me.pairPerson1.Width = 150
        '
        'pairPerson2
        '
        Me.pairPerson2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson2.HeaderText = "Person2"
        Me.pairPerson2.Name = "pairPerson2"
        Me.pairPerson2.ReadOnly = True
        Me.pairPerson2.Width = 150
        '
        'pairPerson3
        '
        Me.pairPerson3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson3.HeaderText = "Person3"
        Me.pairPerson3.Name = "pairPerson3"
        Me.pairPerson3.ReadOnly = True
        Me.pairPerson3.Width = 150
        '
        'pairPerson4
        '
        Me.pairPerson4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson4.HeaderText = "Person4"
        Me.pairPerson4.Name = "pairPerson4"
        Me.pairPerson4.ReadOnly = True
        Me.pairPerson4.Width = 150
        '
        'pairId1
        '
        Me.pairId1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId1.HeaderText = "Id1"
        Me.pairId1.Name = "pairId1"
        Me.pairId1.ReadOnly = True
        Me.pairId1.Visible = False
        Me.pairId1.Width = 30
        '
        'pairId2
        '
        Me.pairId2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId2.HeaderText = "Id2"
        Me.pairId2.Name = "pairId2"
        Me.pairId2.ReadOnly = True
        Me.pairId2.Visible = False
        Me.pairId2.Width = 30
        '
        'pairId3
        '
        Me.pairId3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId3.HeaderText = "Id3"
        Me.pairId3.Name = "pairId3"
        Me.pairId3.ReadOnly = True
        Me.pairId3.Visible = False
        Me.pairId3.Width = 30
        '
        'pairId4
        '
        Me.pairId4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairId4.HeaderText = "Id4"
        Me.pairId4.Name = "pairId4"
        Me.pairId4.ReadOnly = True
        Me.pairId4.Visible = False
        Me.pairId4.Width = 30
        '
        'TxtForename1
        '
        Me.TxtForename1.Location = New System.Drawing.Point(77, 21)
        Me.TxtForename1.Name = "TxtForename1"
        Me.TxtForename1.Size = New System.Drawing.Size(148, 23)
        Me.TxtForename1.TabIndex = 37
        '
        'TxtSurname1
        '
        Me.TxtSurname1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname1.Location = New System.Drawing.Point(231, 21)
        Me.TxtSurname1.Name = "TxtSurname1"
        Me.TxtSurname1.Size = New System.Drawing.Size(201, 23)
        Me.TxtSurname1.TabIndex = 38
        '
        'TxtShortDesc1
        '
        Me.TxtShortDesc1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc1.Location = New System.Drawing.Point(47, 52)
        Me.TxtShortDesc1.Name = "TxtShortDesc1"
        Me.TxtShortDesc1.Size = New System.Drawing.Size(445, 23)
        Me.TxtShortDesc1.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkSel1)
        Me.GroupBox1.Controls.Add(Me.BtnUpdate1)
        Me.GroupBox1.Controls.Add(Me.LblId1)
        Me.GroupBox1.Controls.Add(Me.DtpDob1)
        Me.GroupBox1.Controls.Add(Me.TxtShortDesc1)
        Me.GroupBox1.Controls.Add(Me.TxtForename1)
        Me.GroupBox1.Controls.Add(Me.TxtSurname1)
        Me.GroupBox1.Location = New System.Drawing.Point(33, 365)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(584, 84)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Person 1"
        '
        'chkSel1
        '
        Me.chkSel1.AutoSize = True
        Me.chkSel1.Location = New System.Drawing.Point(6, 56)
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
        Me.BtnUpdate1.Location = New System.Drawing.Point(498, 50)
        Me.BtnUpdate1.Name = "BtnUpdate1"
        Me.BtnUpdate1.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate1.TabIndex = 42
        Me.BtnUpdate1.Text = "Update"
        Me.BtnUpdate1.UseVisualStyleBackColor = True
        '
        'LblId1
        '
        Me.LblId1.AutoSize = True
        Me.LblId1.Location = New System.Drawing.Point(26, 24)
        Me.LblId1.Name = "LblId1"
        Me.LblId1.Size = New System.Drawing.Size(45, 16)
        Me.LblId1.TabIndex = 41
        Me.LblId1.Text = "Label1"
        '
        'DtpDob1
        '
        Me.DtpDob1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDob1.Location = New System.Drawing.Point(439, 22)
        Me.DtpDob1.Name = "DtpDob1"
        Me.DtpDob1.Size = New System.Drawing.Size(136, 23)
        Me.DtpDob1.TabIndex = 40
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ChkSel2)
        Me.GroupBox2.Controls.Add(Me.BtnUpdate2)
        Me.GroupBox2.Controls.Add(Me.LblId2)
        Me.GroupBox2.Controls.Add(Me.DtpDob2)
        Me.GroupBox2.Controls.Add(Me.TxtShortDesc2)
        Me.GroupBox2.Controls.Add(Me.TxtForename2)
        Me.GroupBox2.Controls.Add(Me.TxtSurname2)
        Me.GroupBox2.Location = New System.Drawing.Point(33, 455)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(584, 84)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Person 2"
        '
        'ChkSel2
        '
        Me.ChkSel2.AutoSize = True
        Me.ChkSel2.Location = New System.Drawing.Point(6, 58)
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
        Me.BtnUpdate2.Location = New System.Drawing.Point(497, 51)
        Me.BtnUpdate2.Name = "BtnUpdate2"
        Me.BtnUpdate2.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate2.TabIndex = 43
        Me.BtnUpdate2.Text = "Update"
        Me.BtnUpdate2.UseVisualStyleBackColor = True
        '
        'LblId2
        '
        Me.LblId2.AutoSize = True
        Me.LblId2.Location = New System.Drawing.Point(26, 26)
        Me.LblId2.Name = "LblId2"
        Me.LblId2.Size = New System.Drawing.Size(45, 16)
        Me.LblId2.TabIndex = 42
        Me.LblId2.Text = "Label3"
        '
        'DtpDob2
        '
        Me.DtpDob2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDob2.Location = New System.Drawing.Point(438, 23)
        Me.DtpDob2.Name = "DtpDob2"
        Me.DtpDob2.Size = New System.Drawing.Size(136, 23)
        Me.DtpDob2.TabIndex = 40
        '
        'TxtShortDesc2
        '
        Me.TxtShortDesc2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc2.Location = New System.Drawing.Point(47, 53)
        Me.TxtShortDesc2.Name = "TxtShortDesc2"
        Me.TxtShortDesc2.Size = New System.Drawing.Size(445, 23)
        Me.TxtShortDesc2.TabIndex = 39
        '
        'TxtForename2
        '
        Me.TxtForename2.Location = New System.Drawing.Point(77, 23)
        Me.TxtForename2.Name = "TxtForename2"
        Me.TxtForename2.Size = New System.Drawing.Size(148, 23)
        Me.TxtForename2.TabIndex = 37
        '
        'TxtSurname2
        '
        Me.TxtSurname2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname2.Location = New System.Drawing.Point(231, 23)
        Me.TxtSurname2.Name = "TxtSurname2"
        Me.TxtSurname2.Size = New System.Drawing.Size(201, 23)
        Me.TxtSurname2.TabIndex = 38
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenerate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGenerate.Location = New System.Drawing.Point(774, 288)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(111, 33)
        Me.BtnGenerate.TabIndex = 42
        Me.BtnGenerate.Text = "Generate"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'BtnSwap
        '
        Me.BtnSwap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSwap.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSwap.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSwap.Location = New System.Drawing.Point(899, 287)
        Me.BtnSwap.Name = "BtnSwap"
        Me.BtnSwap.Size = New System.Drawing.Size(91, 33)
        Me.BtnSwap.TabIndex = 43
        Me.BtnSwap.Text = "Swap"
        Me.BtnSwap.UseVisualStyleBackColor = True
        '
        'cmbTwitterUsers
        '
        Me.cmbTwitterUsers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTwitterUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTwitterUsers.FormattingEnabled = True
        Me.cmbTwitterUsers.Location = New System.Drawing.Point(711, 330)
        Me.cmbTwitterUsers.Name = "cmbTwitterUsers"
        Me.cmbTwitterUsers.Size = New System.Drawing.Size(127, 24)
        Me.cmbTwitterUsers.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(643, 333)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Send As"
        '
        'chkImages
        '
        Me.chkImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkImages.AutoSize = True
        Me.chkImages.Checked = True
        Me.chkImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImages.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkImages.Location = New System.Drawing.Point(647, 294)
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
        Me.LblDay.Location = New System.Drawing.Point(45, 15)
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
        Me.LblMonth.Location = New System.Drawing.Point(114, 15)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(80, 30)
        Me.LblMonth.TabIndex = 48
        Me.LblMonth.Text = "January"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.ChkSel3)
        Me.GroupBox3.Controls.Add(Me.BtnUpdate3)
        Me.GroupBox3.Controls.Add(Me.LblId3)
        Me.GroupBox3.Controls.Add(Me.DtpDob3)
        Me.GroupBox3.Controls.Add(Me.TxtShortDesc3)
        Me.GroupBox3.Controls.Add(Me.TxtForename3)
        Me.GroupBox3.Controls.Add(Me.TxtSurname3)
        Me.GroupBox3.Location = New System.Drawing.Point(630, 365)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(572, 84)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Person 3"
        '
        'ChkSel3
        '
        Me.ChkSel3.AutoSize = True
        Me.ChkSel3.Location = New System.Drawing.Point(6, 56)
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
        Me.BtnUpdate3.Location = New System.Drawing.Point(489, 49)
        Me.BtnUpdate3.Name = "BtnUpdate3"
        Me.BtnUpdate3.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate3.TabIndex = 43
        Me.BtnUpdate3.Text = "Update"
        Me.BtnUpdate3.UseVisualStyleBackColor = True
        '
        'LblId3
        '
        Me.LblId3.AutoSize = True
        Me.LblId3.Location = New System.Drawing.Point(26, 25)
        Me.LblId3.Name = "LblId3"
        Me.LblId3.Size = New System.Drawing.Size(45, 16)
        Me.LblId3.TabIndex = 42
        Me.LblId3.Text = "Label3"
        '
        'DtpDob3
        '
        Me.DtpDob3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDob3.Location = New System.Drawing.Point(430, 21)
        Me.DtpDob3.Name = "DtpDob3"
        Me.DtpDob3.Size = New System.Drawing.Size(136, 23)
        Me.DtpDob3.TabIndex = 40
        '
        'TxtShortDesc3
        '
        Me.TxtShortDesc3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc3.Location = New System.Drawing.Point(47, 51)
        Me.TxtShortDesc3.Name = "TxtShortDesc3"
        Me.TxtShortDesc3.Size = New System.Drawing.Size(433, 23)
        Me.TxtShortDesc3.TabIndex = 39
        '
        'TxtForename3
        '
        Me.TxtForename3.Location = New System.Drawing.Point(77, 22)
        Me.TxtForename3.Name = "TxtForename3"
        Me.TxtForename3.Size = New System.Drawing.Size(148, 23)
        Me.TxtForename3.TabIndex = 37
        '
        'TxtSurname3
        '
        Me.TxtSurname3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname3.Location = New System.Drawing.Point(231, 22)
        Me.TxtSurname3.Name = "TxtSurname3"
        Me.TxtSurname3.Size = New System.Drawing.Size(189, 23)
        Me.TxtSurname3.TabIndex = 38
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.ChkSel4)
        Me.GroupBox4.Controls.Add(Me.BtnUpdate4)
        Me.GroupBox4.Controls.Add(Me.LblId4)
        Me.GroupBox4.Controls.Add(Me.DtpDob4)
        Me.GroupBox4.Controls.Add(Me.TxtShortDesc4)
        Me.GroupBox4.Controls.Add(Me.TxtForename4)
        Me.GroupBox4.Controls.Add(Me.TxtSurname4)
        Me.GroupBox4.Location = New System.Drawing.Point(630, 455)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(572, 84)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Person 4"
        '
        'ChkSel4
        '
        Me.ChkSel4.AutoSize = True
        Me.ChkSel4.Location = New System.Drawing.Point(6, 56)
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
        Me.BtnUpdate4.Location = New System.Drawing.Point(489, 52)
        Me.BtnUpdate4.Name = "BtnUpdate4"
        Me.BtnUpdate4.Size = New System.Drawing.Size(77, 27)
        Me.BtnUpdate4.TabIndex = 43
        Me.BtnUpdate4.Text = "Update"
        Me.BtnUpdate4.UseVisualStyleBackColor = True
        '
        'LblId4
        '
        Me.LblId4.AutoSize = True
        Me.LblId4.Location = New System.Drawing.Point(26, 25)
        Me.LblId4.Name = "LblId4"
        Me.LblId4.Size = New System.Drawing.Size(45, 16)
        Me.LblId4.TabIndex = 42
        Me.LblId4.Text = "Label3"
        '
        'DtpDob4
        '
        Me.DtpDob4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtpDob4.Location = New System.Drawing.Point(430, 22)
        Me.DtpDob4.Name = "DtpDob4"
        Me.DtpDob4.Size = New System.Drawing.Size(136, 23)
        Me.DtpDob4.TabIndex = 40
        '
        'TxtShortDesc4
        '
        Me.TxtShortDesc4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtShortDesc4.Location = New System.Drawing.Point(47, 51)
        Me.TxtShortDesc4.Name = "TxtShortDesc4"
        Me.TxtShortDesc4.Size = New System.Drawing.Size(433, 23)
        Me.TxtShortDesc4.TabIndex = 39
        '
        'TxtForename4
        '
        Me.TxtForename4.Location = New System.Drawing.Point(77, 22)
        Me.TxtForename4.Name = "TxtForename4"
        Me.TxtForename4.Size = New System.Drawing.Size(148, 23)
        Me.TxtForename4.TabIndex = 37
        '
        'TxtSurname4
        '
        Me.TxtSurname4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSurname4.Location = New System.Drawing.Point(231, 22)
        Me.TxtSurname4.Name = "TxtSurname4"
        Me.TxtSurname4.Size = New System.Drawing.Size(189, 23)
        Me.TxtSurname4.TabIndex = 38
        '
        'FrmBotsd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1214, 612)
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
        Me.Controls.Add(Me.dgvPairs)
        Me.Controls.Add(Me.NudPic1Horizontal)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.rtbTweet)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(1230, 500)
        Me.Name = "FrmBotsd"
        Me.Text = "Born On The Same Day"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPairs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents dgvPairs As DataGridView
    Friend WithEvents TxtForename1 As TextBox
    Friend WithEvents TxtSurname1 As TextBox
    Friend WithEvents TxtShortDesc1 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblId1 As Label
    Friend WithEvents DtpDob1 As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblId2 As Label
    Friend WithEvents DtpDob2 As DateTimePicker
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
    Friend WithEvents DtpDob3 As DateTimePicker
    Friend WithEvents TxtShortDesc3 As TextBox
    Friend WithEvents TxtForename3 As TextBox
    Friend WithEvents TxtSurname3 As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents BtnUpdate4 As Button
    Friend WithEvents LblId4 As Label
    Friend WithEvents DtpDob4 As DateTimePicker
    Friend WithEvents TxtShortDesc4 As TextBox
    Friend WithEvents TxtForename4 As TextBox
    Friend WithEvents TxtSurname4 As TextBox
    Friend WithEvents pairPerson1 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson2 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson3 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson4 As DataGridViewTextBoxColumn
    Friend WithEvents pairId1 As DataGridViewTextBoxColumn
    Friend WithEvents pairId2 As DataGridViewTextBoxColumn
    Friend WithEvents pairId3 As DataGridViewTextBoxColumn
    Friend WithEvents pairId4 As DataGridViewTextBoxColumn
    Friend WithEvents chkSel1 As CheckBox
    Friend WithEvents ChkSel2 As CheckBox
    Friend WithEvents ChkSel3 As CheckBox
    Friend WithEvents ChkSel4 As CheckBox
End Class

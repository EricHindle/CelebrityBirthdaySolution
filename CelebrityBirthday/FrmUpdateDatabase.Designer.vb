<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUpdateDatabase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUpdateDatabase))
        Me.cbNoTweet = New System.Windows.Forms.CheckBox()
        Me.btnTwitter = New System.Windows.Forms.Button()
        Me.txtTwitter = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnTidyDob = New System.Windows.Forms.Button()
        Me.btnRTB = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.btnClearDesc = New System.Windows.Forms.Button()
        Me.txtDthMth = New System.Windows.Forms.TextBox()
        Me.btnTidy = New System.Windows.Forms.Button()
        Me.btnCopyBirthName = New System.Windows.Forms.Button()
        Me.btnWiki = New System.Windows.Forms.Button()
        Me.txtDthDay = New System.Windows.Forms.TextBox()
        Me.btnCopyBirthPlace = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBirthName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBirthPlace = New System.Windows.Forms.TextBox()
        Me.btnCreateFullName = New System.Windows.Forms.Button()
        Me.btnSplitName = New System.Windows.Forms.Button()
        Me.lblID = New System.Windows.Forms.Label()
        Me.btnCreateShortDesc = New System.Windows.Forms.Button()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtForename = New System.Windows.Forms.TextBox()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.txtShortDesc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.lbPeople = New System.Windows.Forms.ListBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.txtDied = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rtbDesc = New System.Windows.Forms.RichTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnInsert = New System.Windows.Forms.Button()
        Me.btnClrNew = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClearList = New System.Windows.Forms.Button()
        Me.btnReloadSel = New System.Windows.Forms.Button()
        Me.btnLoadTable = New System.Windows.Forms.Button()
        Me.btnUpdateSel = New System.Windows.Forms.Button()
        Me.btnUpdateAll = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtLoadDay = New System.Windows.Forms.TextBox()
        Me.cbDateAmend = New System.Windows.Forms.CheckBox()
        Me.btnLoadUpd = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLoadMth = New System.Windows.Forms.TextBox()
        Me.txtLoadYr = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UseNicknameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpperCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LowercaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleCaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BtnGetWikiText = New System.Windows.Forms.Button()
        Me.NudSentences = New System.Windows.Forms.NumericUpDown()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbNoTweet
        '
        Me.cbNoTweet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbNoTweet.AutoSize = True
        Me.cbNoTweet.Location = New System.Drawing.Point(389, 562)
        Me.cbNoTweet.Name = "cbNoTweet"
        Me.cbNoTweet.Size = New System.Drawing.Size(94, 18)
        Me.cbNoTweet.TabIndex = 100
        Me.cbNoTweet.Text = "Don't tweet"
        Me.cbNoTweet.UseVisualStyleBackColor = True
        '
        'btnTwitter
        '
        Me.btnTwitter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTwitter.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTwitter.Location = New System.Drawing.Point(35, 555)
        Me.btnTwitter.Name = "btnTwitter"
        Me.btnTwitter.Size = New System.Drawing.Size(87, 37)
        Me.btnTwitter.TabIndex = 119
        Me.btnTwitter.Text = "Twitter:"
        Me.btnTwitter.UseVisualStyleBackColor = True
        '
        'txtTwitter
        '
        Me.txtTwitter.AllowDrop = True
        Me.txtTwitter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTwitter.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTwitter.Location = New System.Drawing.Point(162, 559)
        Me.txtTwitter.Name = "txtTwitter"
        Me.txtTwitter.Size = New System.Drawing.Size(217, 26)
        Me.txtTwitter.TabIndex = 99
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(129, 563)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(18, 14)
        Me.Label16.TabIndex = 118
        Me.Label16.Text = "@"
        '
        'btnTidyDob
        '
        Me.btnTidyDob.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTidyDob.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTidyDob.Location = New System.Drawing.Point(848, 232)
        Me.btnTidyDob.Name = "btnTidyDob"
        Me.btnTidyDob.Size = New System.Drawing.Size(61, 55)
        Me.btnTidyDob.TabIndex = 117
        Me.btnTidyDob.Text = "Tidy and Fix"
        Me.btnTidyDob.UseVisualStyleBackColor = True
        '
        'btnRTB
        '
        Me.btnRTB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRTB.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRTB.Location = New System.Drawing.Point(104, 370)
        Me.btnRTB.Name = "btnRTB"
        Me.btnRTB.Size = New System.Drawing.Size(43, 29)
        Me.btnRTB.TabIndex = 116
        Me.btnRTB.Text = "RTB"
        Me.btnRTB.UseVisualStyleBackColor = True
        '
        'txtDesc
        '
        Me.txtDesc.AllowDrop = True
        Me.txtDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDesc.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesc.Location = New System.Drawing.Point(162, 137)
        Me.txtDesc.Multiline = True
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDesc.Size = New System.Drawing.Size(672, 262)
        Me.txtDesc.TabIndex = 92
        '
        'btnClearDesc
        '
        Me.btnClearDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearDesc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearDesc.Location = New System.Drawing.Point(848, 139)
        Me.btnClearDesc.Name = "btnClearDesc"
        Me.btnClearDesc.Size = New System.Drawing.Size(61, 28)
        Me.btnClearDesc.TabIndex = 113
        Me.btnClearDesc.Text = "Clear"
        Me.btnClearDesc.UseVisualStyleBackColor = True
        '
        'txtDthMth
        '
        Me.txtDthMth.AllowDrop = True
        Me.txtDthMth.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDthMth.Location = New System.Drawing.Point(387, 97)
        Me.txtDthMth.Name = "txtDthMth"
        Me.txtDthMth.Size = New System.Drawing.Size(34, 24)
        Me.txtDthMth.TabIndex = 89
        '
        'btnTidy
        '
        Me.btnTidy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTidy.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTidy.Location = New System.Drawing.Point(848, 184)
        Me.btnTidy.Name = "btnTidy"
        Me.btnTidy.Size = New System.Drawing.Size(61, 28)
        Me.btnTidy.TabIndex = 114
        Me.btnTidy.Text = "Tidy"
        Me.btnTidy.UseVisualStyleBackColor = True
        '
        'btnCopyBirthName
        '
        Me.btnCopyBirthName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyBirthName.Location = New System.Drawing.Point(848, 509)
        Me.btnCopyBirthName.Name = "btnCopyBirthName"
        Me.btnCopyBirthName.Size = New System.Drawing.Size(35, 26)
        Me.btnCopyBirthName.TabIndex = 112
        Me.btnCopyBirthName.Text = "<"
        Me.btnCopyBirthName.UseVisualStyleBackColor = True
        '
        'btnWiki
        '
        Me.btnWiki.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWiki.Location = New System.Drawing.Point(35, 170)
        Me.btnWiki.Name = "btnWiki"
        Me.btnWiki.Size = New System.Drawing.Size(69, 42)
        Me.btnWiki.TabIndex = 110
        Me.btnWiki.Text = "Wiki" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lookup"
        Me.btnWiki.UseVisualStyleBackColor = True
        '
        'txtDthDay
        '
        Me.txtDthDay.AllowDrop = True
        Me.txtDthDay.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDthDay.Location = New System.Drawing.Point(346, 97)
        Me.txtDthDay.Name = "txtDthDay"
        Me.txtDthDay.Size = New System.Drawing.Size(33, 24)
        Me.txtDthDay.TabIndex = 88
        '
        'btnCopyBirthPlace
        '
        Me.btnCopyBirthPlace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyBirthPlace.Location = New System.Drawing.Point(848, 466)
        Me.btnCopyBirthPlace.Name = "btnCopyBirthPlace"
        Me.btnCopyBirthPlace.Size = New System.Drawing.Size(35, 26)
        Me.btnCopyBirthPlace.TabIndex = 111
        Me.btnCopyBirthPlace.Text = "<"
        Me.btnCopyBirthPlace.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(35, 513)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 14)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "Birth Name"
        '
        'txtBirthName
        '
        Me.txtBirthName.AllowDrop = True
        Me.txtBirthName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBirthName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirthName.Location = New System.Drawing.Point(162, 509)
        Me.txtBirthName.Name = "txtBirthName"
        Me.txtBirthName.Size = New System.Drawing.Size(672, 26)
        Me.txtBirthName.TabIndex = 98
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(35, 470)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 14)
        Me.Label14.TabIndex = 108
        Me.Label14.Text = "Birthplace"
        '
        'txtBirthPlace
        '
        Me.txtBirthPlace.AllowDrop = True
        Me.txtBirthPlace.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBirthPlace.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirthPlace.Location = New System.Drawing.Point(162, 466)
        Me.txtBirthPlace.Name = "txtBirthPlace"
        Me.txtBirthPlace.Size = New System.Drawing.Size(672, 26)
        Me.txtBirthPlace.TabIndex = 97
        '
        'btnCreateFullName
        '
        Me.btnCreateFullName.Location = New System.Drawing.Point(120, 16)
        Me.btnCreateFullName.Name = "btnCreateFullName"
        Me.btnCreateFullName.Size = New System.Drawing.Size(35, 26)
        Me.btnCreateFullName.TabIndex = 107
        Me.btnCreateFullName.Text = ">"
        Me.btnCreateFullName.UseVisualStyleBackColor = True
        '
        'btnSplitName
        '
        Me.btnSplitName.Location = New System.Drawing.Point(120, 54)
        Me.btnSplitName.Name = "btnSplitName"
        Me.btnSplitName.Size = New System.Drawing.Size(35, 26)
        Me.btnSplitName.TabIndex = 106
        Me.btnSplitName.Text = ">"
        Me.btnSplitName.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(35, 58)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(0, 18)
        Me.lblID.TabIndex = 104
        '
        'btnCreateShortDesc
        '
        Me.btnCreateShortDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateShortDesc.Location = New System.Drawing.Point(848, 423)
        Me.btnCreateShortDesc.Name = "btnCreateShortDesc"
        Me.btnCreateShortDesc.Size = New System.Drawing.Size(35, 26)
        Me.btnCreateShortDesc.TabIndex = 105
        Me.btnCreateShortDesc.Text = "<"
        Me.btnCreateShortDesc.UseVisualStyleBackColor = True
        '
        'txtSurname
        '
        Me.txtSurname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSurname.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurname.Location = New System.Drawing.Point(490, 54)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(295, 26)
        Me.txtSurname.TabIndex = 86
        '
        'txtForename
        '
        Me.txtForename.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForename.Location = New System.Drawing.Point(162, 54)
        Me.txtForename.Name = "txtForename"
        Me.txtForename.Size = New System.Drawing.Size(317, 26)
        Me.txtForename.TabIndex = 85
        '
        'btnDown
        '
        Me.btnDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDown.Location = New System.Drawing.Point(1223, 108)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(40, 43)
        Me.btnDown.TabIndex = 102
        Me.btnDown.Text = "Dn"
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'txtShortDesc
        '
        Me.txtShortDesc.AllowDrop = True
        Me.txtShortDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShortDesc.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortDesc.Location = New System.Drawing.Point(162, 423)
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Size = New System.Drawing.Size(672, 26)
        Me.txtShortDesc.TabIndex = 95
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(35, 426)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 14)
        Me.Label10.TabIndex = 103
        Me.Label10.Text = "Short desc"
        '
        'btnUp
        '
        Me.btnUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUp.Location = New System.Drawing.Point(1223, 58)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(40, 43)
        Me.btnUp.TabIndex = 101
        Me.btnUp.Text = "Up"
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'lbPeople
        '
        Me.lbPeople.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbPeople.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPeople.FormattingEnabled = True
        Me.lbPeople.ItemHeight = 18
        Me.lbPeople.Location = New System.Drawing.Point(926, 58)
        Me.lbPeople.Name = "lbPeople"
        Me.lbPeople.Size = New System.Drawing.Size(284, 418)
        Me.lbPeople.TabIndex = 83
        '
        'cboMonth
        '
        Me.cboMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(1003, 18)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(207, 27)
        Me.cboMonth.TabIndex = 82
        '
        'cboDay
        '
        Me.cboDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(926, 18)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(71, 27)
        Me.cboDay.TabIndex = 81
        '
        'txtDied
        '
        Me.txtDied.AllowDrop = True
        Me.txtDied.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDied.Location = New System.Drawing.Point(429, 97)
        Me.txtDied.Name = "txtDied"
        Me.txtDied.Size = New System.Drawing.Size(61, 24)
        Me.txtDied.TabIndex = 91
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(271, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Death"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 14)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "Description"
        '
        'txtYear
        '
        Me.txtYear.AllowDrop = True
        Me.txtYear.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.Location = New System.Drawing.Point(162, 97)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(79, 24)
        Me.txtYear.TabIndex = 87
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Year born"
        '
        'txtName
        '
        Me.txtName.AllowDrop = True
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(162, 18)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(623, 26)
        Me.txtName.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Name"
        '
        'rtbDesc
        '
        Me.rtbDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbDesc.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbDesc.Location = New System.Drawing.Point(162, 137)
        Me.rtbDesc.Name = "rtbDesc"
        Me.rtbDesc.Size = New System.Drawing.Size(672, 262)
        Me.rtbDesc.TabIndex = 115
        Me.rtbDesc.Text = ""
        Me.rtbDesc.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(35, 282)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(70, 65)
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(162, 663)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(100, 43)
        Me.btnUpdate.TabIndex = 122
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnInsert
        '
        Me.btnInsert.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnInsert.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInsert.Location = New System.Drawing.Point(44, 663)
        Me.btnInsert.Name = "btnInsert"
        Me.btnInsert.Size = New System.Drawing.Size(100, 43)
        Me.btnInsert.TabIndex = 121
        Me.btnInsert.Text = "Insert"
        Me.btnInsert.UseVisualStyleBackColor = True
        '
        'btnClrNew
        '
        Me.btnClrNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClrNew.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClrNew.Location = New System.Drawing.Point(526, 662)
        Me.btnClrNew.Name = "btnClrNew"
        Me.btnClrNew.Size = New System.Drawing.Size(99, 43)
        Me.btnClrNew.TabIndex = 126
        Me.btnClrNew.Text = "Clear"
        Me.btnClrNew.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnClearList)
        Me.GroupBox1.Controls.Add(Me.btnReloadSel)
        Me.GroupBox1.Controls.Add(Me.btnLoadTable)
        Me.GroupBox1.Controls.Add(Me.btnUpdateSel)
        Me.GroupBox1.Controls.Add(Me.btnUpdateAll)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Location = New System.Drawing.Point(884, 566)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 159)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database"
        '
        'btnClearList
        '
        Me.btnClearList.Location = New System.Drawing.Point(239, 96)
        Me.btnClearList.Name = "btnClearList"
        Me.btnClearList.Size = New System.Drawing.Size(100, 52)
        Me.btnClearList.TabIndex = 5
        Me.btnClearList.Text = "Clear list"
        Me.btnClearList.UseVisualStyleBackColor = True
        '
        'btnReloadSel
        '
        Me.btnReloadSel.Location = New System.Drawing.Point(132, 96)
        Me.btnReloadSel.Name = "btnReloadSel"
        Me.btnReloadSel.Size = New System.Drawing.Size(100, 52)
        Me.btnReloadSel.TabIndex = 4
        Me.btnReloadSel.Text = "Reload table item"
        Me.btnReloadSel.UseVisualStyleBackColor = True
        '
        'btnLoadTable
        '
        Me.btnLoadTable.Location = New System.Drawing.Point(132, 38)
        Me.btnLoadTable.Name = "btnLoadTable"
        Me.btnLoadTable.Size = New System.Drawing.Size(100, 52)
        Me.btnLoadTable.TabIndex = 1
        Me.btnLoadTable.Text = "Reload Full Table"
        Me.btnLoadTable.UseVisualStyleBackColor = True
        '
        'btnUpdateSel
        '
        Me.btnUpdateSel.Location = New System.Drawing.Point(24, 96)
        Me.btnUpdateSel.Name = "btnUpdateSel"
        Me.btnUpdateSel.Size = New System.Drawing.Size(100, 52)
        Me.btnUpdateSel.TabIndex = 3
        Me.btnUpdateSel.Text = "Update db selected"
        Me.btnUpdateSel.UseVisualStyleBackColor = True
        '
        'btnUpdateAll
        '
        Me.btnUpdateAll.Location = New System.Drawing.Point(24, 38)
        Me.btnUpdateAll.Name = "btnUpdateAll"
        Me.btnUpdateAll.Size = New System.Drawing.Size(100, 52)
        Me.btnUpdateAll.TabIndex = 0
        Me.btnUpdateAll.Text = "Update db  All"
        Me.btnUpdateAll.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(239, 38)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 52)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete Person"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1136, 742)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 28)
        Me.btnClose.TabIndex = 135
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtLoadDay
        '
        Me.txtLoadDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoadDay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadDay.Location = New System.Drawing.Point(952, 533)
        Me.txtLoadDay.Name = "txtLoadDay"
        Me.txtLoadDay.Size = New System.Drawing.Size(55, 22)
        Me.txtLoadDay.TabIndex = 136
        '
        'cbDateAmend
        '
        Me.cbDateAmend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDateAmend.AutoSize = True
        Me.cbDateAmend.Location = New System.Drawing.Point(1003, 509)
        Me.cbDateAmend.Name = "cbDateAmend"
        Me.cbDateAmend.Size = New System.Drawing.Size(107, 18)
        Me.cbDateAmend.TabIndex = 139
        Me.cbDateAmend.Text = "Date amended"
        Me.cbDateAmend.UseVisualStyleBackColor = True
        '
        'btnLoadUpd
        '
        Me.btnLoadUpd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadUpd.Location = New System.Drawing.Point(1184, 531)
        Me.btnLoadUpd.Name = "btnLoadUpd"
        Me.btnLoadUpd.Size = New System.Drawing.Size(52, 27)
        Me.btnLoadUpd.TabIndex = 140
        Me.btnLoadUpd.Text = "Upd"
        Me.btnLoadUpd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(881, 538)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 14)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Load date"
        '
        'txtLoadMth
        '
        Me.txtLoadMth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMth.Location = New System.Drawing.Point(1015, 533)
        Me.txtLoadMth.Name = "txtLoadMth"
        Me.txtLoadMth.Size = New System.Drawing.Size(55, 22)
        Me.txtLoadMth.TabIndex = 137
        '
        'txtLoadYr
        '
        Me.txtLoadYr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoadYr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadYr.Location = New System.Drawing.Point(1078, 533)
        Me.txtLoadYr.Name = "txtLoadYr"
        Me.txtLoadYr.Size = New System.Drawing.Size(82, 22)
        Me.txtLoadYr.TabIndex = 138
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 730)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 14)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "Label11"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UseNicknameToolStripMenuItem, Me.ToolStripSeparator3, Me.UpperCaseToolStripMenuItem, Me.LowercaseToolStripMenuItem, Me.TitleCaseToolStripMenuItem, Me.ToolStripSeparator2, Me.CopyToolStripMenuItem, Me.CutToolStripMenuItem, Me.PasteToolStripMenuItem, Me.ClearToolStripMenuItem, Me.SelectAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(151, 214)
        '
        'UseNicknameToolStripMenuItem
        '
        Me.UseNicknameToolStripMenuItem.Name = "UseNicknameToolStripMenuItem"
        Me.UseNicknameToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UseNicknameToolStripMenuItem.Text = "Use Nickname"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(147, 6)
        '
        'UpperCaseToolStripMenuItem
        '
        Me.UpperCaseToolStripMenuItem.Name = "UpperCaseToolStripMenuItem"
        Me.UpperCaseToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.UpperCaseToolStripMenuItem.Text = "UPPERCASE"
        '
        'LowercaseToolStripMenuItem
        '
        Me.LowercaseToolStripMenuItem.Name = "LowercaseToolStripMenuItem"
        Me.LowercaseToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.LowercaseToolStripMenuItem.Text = "lowercase"
        '
        'TitleCaseToolStripMenuItem
        '
        Me.TitleCaseToolStripMenuItem.Name = "TitleCaseToolStripMenuItem"
        Me.TitleCaseToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TitleCaseToolStripMenuItem.Text = "Title Case"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(147, 6)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'SelectAllToolStripMenuItem
        '
        Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.SelectAllToolStripMenuItem.Text = "Select All"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 783)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1271, 22)
        Me.StatusStrip1.TabIndex = 143
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BtnGetWikiText
        '
        Me.BtnGetWikiText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGetWikiText.Location = New System.Drawing.Point(35, 219)
        Me.BtnGetWikiText.Name = "BtnGetWikiText"
        Me.BtnGetWikiText.Size = New System.Drawing.Size(69, 42)
        Me.BtnGetWikiText.TabIndex = 144
        Me.BtnGetWikiText.Text = "Get Wiki Text"
        Me.BtnGetWikiText.UseVisualStyleBackColor = True
        '
        'NudSentences
        '
        Me.NudSentences.Location = New System.Drawing.Point(109, 231)
        Me.NudSentences.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudSentences.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudSentences.Name = "NudSentences"
        Me.NudSentences.Size = New System.Drawing.Size(46, 22)
        Me.NudSentences.TabIndex = 145
        Me.NudSentences.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'FrmUpdateDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(1271, 805)
        Me.Controls.Add(Me.NudSentences)
        Me.Controls.Add(Me.BtnGetWikiText)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtLoadDay)
        Me.Controls.Add(Me.cbDateAmend)
        Me.Controls.Add(Me.btnLoadUpd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLoadMth)
        Me.Controls.Add(Me.txtLoadYr)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnInsert)
        Me.Controls.Add(Me.btnClrNew)
        Me.Controls.Add(Me.cbNoTweet)
        Me.Controls.Add(Me.btnTwitter)
        Me.Controls.Add(Me.txtTwitter)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnTidyDob)
        Me.Controls.Add(Me.btnRTB)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.btnClearDesc)
        Me.Controls.Add(Me.txtDthMth)
        Me.Controls.Add(Me.btnTidy)
        Me.Controls.Add(Me.btnCopyBirthName)
        Me.Controls.Add(Me.btnWiki)
        Me.Controls.Add(Me.txtDthDay)
        Me.Controls.Add(Me.btnCopyBirthPlace)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtBirthName)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtBirthPlace)
        Me.Controls.Add(Me.btnCreateFullName)
        Me.Controls.Add(Me.btnSplitName)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.btnCreateShortDesc)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.txtForename)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.txtShortDesc)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.lbPeople)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.txtDied)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rtbDesc)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1040, 710)
        Me.Name = "FrmUpdateDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Database"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbNoTweet As CheckBox
    Friend WithEvents btnTwitter As Button
    Friend WithEvents txtTwitter As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents btnTidyDob As Button
    Friend WithEvents btnRTB As Button
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents btnClearDesc As Button
    Friend WithEvents txtDthMth As TextBox
    Friend WithEvents btnTidy As Button
    Friend WithEvents btnCopyBirthName As Button
    Friend WithEvents btnWiki As Button
    Friend WithEvents txtDthDay As TextBox
    Friend WithEvents btnCopyBirthPlace As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents txtBirthName As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtBirthPlace As TextBox
    Friend WithEvents btnCreateFullName As Button
    Friend WithEvents btnSplitName As Button
    Friend WithEvents lblID As Label
    Friend WithEvents btnCreateShortDesc As Button
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents txtForename As TextBox
    Friend WithEvents btnDown As Button
    Friend WithEvents txtShortDesc As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnUp As Button
    Friend WithEvents lbPeople As ListBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents txtDied As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtYear As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rtbDesc As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnInsert As Button
    Friend WithEvents btnClrNew As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnClearList As Button
    Friend WithEvents btnReloadSel As Button
    Friend WithEvents btnLoadTable As Button
    Friend WithEvents btnUpdateSel As Button
    Friend WithEvents btnUpdateAll As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtLoadDay As TextBox
    Friend WithEvents cbDateAmend As CheckBox
    Friend WithEvents btnLoadUpd As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLoadMth As TextBox
    Friend WithEvents txtLoadYr As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UseNicknameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents UpperCaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LowercaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TitleCaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BtnGetWikiText As Button
    Friend WithEvents NudSentences As NumericUpDown
End Class

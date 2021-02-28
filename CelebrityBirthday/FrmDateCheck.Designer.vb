<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDateCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDateCheck))
        Me.DgvWarnings = New System.Windows.Forms.DataGridView()
        Me.xId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xBirth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xWikiBirth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xWikiExtract = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xWikiId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xPersonDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BtnWikiUpdate = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtWiki = New System.Windows.Forms.TextBox()
        Me.LblId = New System.Windows.Forms.Label()
        Me.BtnSingleUpdate = New System.Windows.Forms.Button()
        Me.TxtFullDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtFullName = New System.Windows.Forms.TextBox()
        Me.nudSelectCount = New System.Windows.Forms.NumericUpDown()
        Me.TxtToDay = New System.Windows.Forms.TextBox()
        Me.TxtToMonth = New System.Windows.Forms.TextBox()
        Me.TxtToYear = New System.Windows.Forms.TextBox()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.BtnFromWordPress = New System.Windows.Forms.Button()
        Me.BtnAll = New System.Windows.Forms.Button()
        Me.TxtFromYear = New System.Windows.Forms.TextBox()
        Me.TxtFromMonth = New System.Windows.Forms.TextBox()
        Me.TxtFromDay = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnToWordPress = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnCopyDate = New System.Windows.Forms.Button()
        Me.BtnClearDetails = New System.Windows.Forms.Button()
        Me.TxtWikiId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnMonth = New System.Windows.Forms.Button()
        Me.BtnWpDesc = New System.Windows.Forms.Button()
        Me.BtnBotSD = New System.Windows.Forms.Button()
        Me.ChkShowImage = New System.Windows.Forms.CheckBox()
        Me.BtnRemoveRow = New System.Windows.Forms.Button()
        CType(Me.DgvWarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.nudSelectCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvWarnings
        '
        Me.DgvWarnings.AllowUserToAddRows = False
        Me.DgvWarnings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvWarnings.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.DgvWarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvWarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.xId, Me.xName, Me.xBirth, Me.xWikiBirth, Me.xWikiExtract, Me.xWikiId, Me.xPersonDescription, Me.xImg})
        Me.DgvWarnings.Location = New System.Drawing.Point(12, 12)
        Me.DgvWarnings.Name = "DgvWarnings"
        Me.DgvWarnings.ReadOnly = True
        Me.DgvWarnings.RowHeadersVisible = False
        Me.DgvWarnings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvWarnings.Size = New System.Drawing.Size(1015, 596)
        Me.DgvWarnings.TabIndex = 0
        '
        'xId
        '
        Me.xId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xId.HeaderText = "Id"
        Me.xId.Name = "xId"
        Me.xId.ReadOnly = True
        Me.xId.Width = 50
        '
        'xName
        '
        Me.xName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xName.HeaderText = "Name"
        Me.xName.Name = "xName"
        Me.xName.ReadOnly = True
        Me.xName.Width = 250
        '
        'xBirth
        '
        Me.xBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xBirth.HeaderText = "Birth Date"
        Me.xBirth.Name = "xBirth"
        Me.xBirth.ReadOnly = True
        Me.xBirth.Width = 125
        '
        'xWikiBirth
        '
        Me.xWikiBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xWikiBirth.HeaderText = "Wiki Birth Date"
        Me.xWikiBirth.Name = "xWikiBirth"
        Me.xWikiBirth.ReadOnly = True
        Me.xWikiBirth.Width = 125
        '
        'xWikiExtract
        '
        Me.xWikiExtract.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.xWikiExtract.HeaderText = "Description"
        Me.xWikiExtract.Name = "xWikiExtract"
        Me.xWikiExtract.ReadOnly = True
        '
        'xWikiId
        '
        Me.xWikiId.HeaderText = "WikiId"
        Me.xWikiId.Name = "xWikiId"
        Me.xWikiId.ReadOnly = True
        Me.xWikiId.Visible = False
        '
        'xPersonDescription
        '
        Me.xPersonDescription.HeaderText = "Full Description"
        Me.xPersonDescription.Name = "xPersonDescription"
        Me.xPersonDescription.ReadOnly = True
        Me.xPersonDescription.Visible = False
        '
        'xImg
        '
        Me.xImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xImg.HeaderText = "Img"
        Me.xImg.Name = "xImg"
        Me.xImg.ReadOnly = True
        Me.xImg.Width = 65
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 668)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1344, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(3, 17)
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(1181, 625)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnWikiUpdate
        '
        Me.BtnWikiUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWikiUpdate.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWikiUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWikiUpdate.Location = New System.Drawing.Point(1256, 584)
        Me.BtnWikiUpdate.Name = "BtnWikiUpdate"
        Me.BtnWikiUpdate.Size = New System.Drawing.Size(74, 24)
        Me.BtnWikiUpdate.TabIndex = 17
        Me.BtnWikiUpdate.Text = "Update"
        Me.ToolTip1.SetToolTip(Me.BtnWikiUpdate, "Update WikiId for person")
        Me.BtnWikiUpdate.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnStart.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnStart.Location = New System.Drawing.Point(783, 625)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(139, 33)
        Me.BtnStart.TabIndex = 16
        Me.BtnStart.Text = "Start Check"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(1196, 421)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 22)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "To this"
        '
        'TxtWiki
        '
        Me.TxtWiki.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWiki.Font = New System.Drawing.Font("Consolas", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWiki.Location = New System.Drawing.Point(3, 3)
        Me.TxtWiki.Multiline = True
        Me.TxtWiki.Name = "TxtWiki"
        Me.TxtWiki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtWiki.Size = New System.Drawing.Size(289, 124)
        Me.TxtWiki.TabIndex = 63
        '
        'LblId
        '
        Me.LblId.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblId.AutoSize = True
        Me.LblId.Font = New System.Drawing.Font("Papyrus", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblId.Location = New System.Drawing.Point(1041, 12)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(17, 21)
        Me.LblId.TabIndex = 61
        Me.LblId.Text = "0"
        '
        'BtnSingleUpdate
        '
        Me.BtnSingleUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSingleUpdate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSingleUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSingleUpdate.Location = New System.Drawing.Point(1045, 373)
        Me.BtnSingleUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSingleUpdate.Name = "BtnSingleUpdate"
        Me.BtnSingleUpdate.Size = New System.Drawing.Size(135, 33)
        Me.BtnSingleUpdate.TabIndex = 60
        Me.BtnSingleUpdate.Text = "Single Update"
        Me.ToolTip1.SetToolTip(Me.BtnSingleUpdate, "Update Date of Birth and Text for person")
        Me.BtnSingleUpdate.UseVisualStyleBackColor = True
        '
        'TxtFullDesc
        '
        Me.TxtFullDesc.AllowDrop = True
        Me.TxtFullDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFullDesc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFullDesc.Location = New System.Drawing.Point(3, 3)
        Me.TxtFullDesc.Multiline = True
        Me.TxtFullDesc.Name = "TxtFullDesc"
        Me.TxtFullDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtFullDesc.Size = New System.Drawing.Size(289, 126)
        Me.TxtFullDesc.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(597, 631)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 22)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Count"
        '
        'TxtFullName
        '
        Me.TxtFullName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFullName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFullName.Location = New System.Drawing.Point(1126, 12)
        Me.TxtFullName.Name = "TxtFullName"
        Me.TxtFullName.Size = New System.Drawing.Size(206, 23)
        Me.TxtFullName.TabIndex = 56
        '
        'nudSelectCount
        '
        Me.nudSelectCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudSelectCount.Location = New System.Drawing.Point(655, 632)
        Me.nudSelectCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudSelectCount.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudSelectCount.Name = "nudSelectCount"
        Me.nudSelectCount.Size = New System.Drawing.Size(65, 20)
        Me.nudSelectCount.TabIndex = 55
        '
        'TxtToDay
        '
        Me.TxtToDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtToDay.Location = New System.Drawing.Point(1196, 446)
        Me.TxtToDay.Name = "TxtToDay"
        Me.TxtToDay.Size = New System.Drawing.Size(32, 20)
        Me.TxtToDay.TabIndex = 66
        '
        'TxtToMonth
        '
        Me.TxtToMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtToMonth.Location = New System.Drawing.Point(1234, 446)
        Me.TxtToMonth.Name = "TxtToMonth"
        Me.TxtToMonth.Size = New System.Drawing.Size(32, 20)
        Me.TxtToMonth.TabIndex = 67
        '
        'TxtToYear
        '
        Me.TxtToYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtToYear.Location = New System.Drawing.Point(1272, 446)
        Me.TxtToYear.Name = "TxtToYear"
        Me.TxtToYear.Size = New System.Drawing.Size(48, 20)
        Me.TxtToYear.TabIndex = 68
        '
        'BtnToday
        '
        Me.BtnToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnToday.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToday.Location = New System.Drawing.Point(180, 627)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(72, 28)
        Me.BtnToday.TabIndex = 136
        Me.BtnToday.Text = "Today"
        Me.ToolTip1.SetToolTip(Me.BtnToday, "Select Today only")
        Me.BtnToday.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(368, 628)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(207, 27)
        Me.cboMonth.TabIndex = 135
        '
        'cboDay
        '
        Me.cboDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(281, 628)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(71, 27)
        Me.cboDay.TabIndex = 134
        '
        'BtnFromWordPress
        '
        Me.BtnFromWordPress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFromWordPress.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFromWordPress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnFromWordPress.Location = New System.Drawing.Point(1045, 473)
        Me.BtnFromWordPress.Name = "BtnFromWordPress"
        Me.BtnFromWordPress.Size = New System.Drawing.Size(135, 33)
        Me.BtnFromWordPress.TabIndex = 137
        Me.BtnFromWordPress.Text = "From WordPress"
        Me.ToolTip1.SetToolTip(Me.BtnFromWordPress, "Open WordPress for From Dater")
        Me.BtnFromWordPress.UseVisualStyleBackColor = True
        '
        'BtnAll
        '
        Me.BtnAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAll.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAll.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAll.Location = New System.Drawing.Point(12, 627)
        Me.BtnAll.Name = "BtnAll"
        Me.BtnAll.Size = New System.Drawing.Size(72, 28)
        Me.BtnAll.TabIndex = 138
        Me.BtnAll.Text = "All"
        Me.ToolTip1.SetToolTip(Me.BtnAll, "Select All Persons")
        Me.BtnAll.UseVisualStyleBackColor = True
        '
        'TxtFromYear
        '
        Me.TxtFromYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromYear.Location = New System.Drawing.Point(1121, 447)
        Me.TxtFromYear.Name = "TxtFromYear"
        Me.TxtFromYear.Size = New System.Drawing.Size(48, 20)
        Me.TxtFromYear.TabIndex = 142
        '
        'TxtFromMonth
        '
        Me.TxtFromMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromMonth.Location = New System.Drawing.Point(1083, 447)
        Me.TxtFromMonth.Name = "TxtFromMonth"
        Me.TxtFromMonth.Size = New System.Drawing.Size(32, 20)
        Me.TxtFromMonth.TabIndex = 141
        '
        'TxtFromDay
        '
        Me.TxtFromDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromDay.Location = New System.Drawing.Point(1045, 446)
        Me.TxtFromDay.Name = "TxtFromDay"
        Me.TxtFromDay.Size = New System.Drawing.Size(32, 20)
        Me.TxtFromDay.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(1045, 421)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 22)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "From this"
        '
        'BtnToWordPress
        '
        Me.BtnToWordPress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnToWordPress.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToWordPress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToWordPress.Location = New System.Drawing.Point(1196, 473)
        Me.BtnToWordPress.Name = "BtnToWordPress"
        Me.BtnToWordPress.Size = New System.Drawing.Size(135, 33)
        Me.BtnToWordPress.TabIndex = 143
        Me.BtnToWordPress.Text = "To WordPress"
        Me.ToolTip1.SetToolTip(Me.BtnToWordPress, "Open WordPress for To Date")
        Me.BtnToWordPress.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainer1.Location = New System.Drawing.Point(1033, 41)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtFullDesc)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TxtWiki)
        Me.SplitContainer1.Size = New System.Drawing.Size(299, 274)
        Me.SplitContainer1.SplitterDistance = 136
        Me.SplitContainer1.TabIndex = 144
        '
        'BtnCopyDate
        '
        Me.BtnCopyDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyDate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyDate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyDate.Location = New System.Drawing.Point(1045, 333)
        Me.BtnCopyDate.Name = "BtnCopyDate"
        Me.BtnCopyDate.Size = New System.Drawing.Size(135, 33)
        Me.BtnCopyDate.TabIndex = 145
        Me.BtnCopyDate.Text = "Copy Date"
        Me.ToolTip1.SetToolTip(Me.BtnCopyDate, "Copy selected text or wiki date to person text")
        Me.BtnCopyDate.UseVisualStyleBackColor = True
        '
        'BtnClearDetails
        '
        Me.BtnClearDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClearDetails.Font = New System.Drawing.Font("Papyrus", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClearDetails.Location = New System.Drawing.Point(1256, 333)
        Me.BtnClearDetails.Name = "BtnClearDetails"
        Me.BtnClearDetails.Size = New System.Drawing.Size(76, 23)
        Me.BtnClearDetails.TabIndex = 146
        Me.BtnClearDetails.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.BtnClearDetails, "Clear perosn details")
        Me.BtnClearDetails.UseVisualStyleBackColor = True
        '
        'TxtWikiId
        '
        Me.TxtWikiId.AllowDrop = True
        Me.TxtWikiId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWikiId.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWikiId.Location = New System.Drawing.Point(1074, 584)
        Me.TxtWikiId.Name = "TxtWikiId"
        Me.TxtWikiId.Size = New System.Drawing.Size(176, 24)
        Me.TxtWikiId.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(1034, 587)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 19)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Wiki"
        '
        'BtnMonth
        '
        Me.BtnMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnMonth.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMonth.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnMonth.Location = New System.Drawing.Point(102, 627)
        Me.BtnMonth.Name = "BtnMonth"
        Me.BtnMonth.Size = New System.Drawing.Size(72, 28)
        Me.BtnMonth.TabIndex = 151
        Me.BtnMonth.Text = "Month"
        Me.ToolTip1.SetToolTip(Me.BtnMonth, "Select Today only")
        Me.BtnMonth.UseVisualStyleBackColor = True
        '
        'BtnWpDesc
        '
        Me.BtnWpDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWpDesc.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWpDesc.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWpDesc.Location = New System.Drawing.Point(1045, 526)
        Me.BtnWpDesc.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnWpDesc.Name = "BtnWpDesc"
        Me.BtnWpDesc.Size = New System.Drawing.Size(135, 33)
        Me.BtnWpDesc.TabIndex = 149
        Me.BtnWpDesc.Text = "Get Description"
        Me.BtnWpDesc.UseVisualStyleBackColor = True
        '
        'BtnBotSD
        '
        Me.BtnBotSD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBotSD.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotSD.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBotSD.Location = New System.Drawing.Point(1196, 526)
        Me.BtnBotSD.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnBotSD.Name = "BtnBotSD"
        Me.BtnBotSD.Size = New System.Drawing.Size(135, 33)
        Me.BtnBotSD.TabIndex = 150
        Me.BtnBotSD.Text = "BotSD"
        Me.BtnBotSD.UseVisualStyleBackColor = True
        '
        'ChkShowImage
        '
        Me.ChkShowImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkShowImage.AutoSize = True
        Me.ChkShowImage.Location = New System.Drawing.Point(937, 633)
        Me.ChkShowImage.Name = "ChkShowImage"
        Me.ChkShowImage.Size = New System.Drawing.Size(90, 17)
        Me.ChkShowImage.TabIndex = 152
        Me.ChkShowImage.Text = "Show Images"
        Me.ChkShowImage.UseVisualStyleBackColor = True
        '
        'BtnRemoveRow
        '
        Me.BtnRemoveRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveRow.Font = New System.Drawing.Font("Papyrus", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemoveRow.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRemoveRow.Location = New System.Drawing.Point(1234, 373)
        Me.BtnRemoveRow.Name = "BtnRemoveRow"
        Me.BtnRemoveRow.Size = New System.Drawing.Size(98, 23)
        Me.BtnRemoveRow.TabIndex = 153
        Me.BtnRemoveRow.Text = "Remove Row"
        Me.ToolTip1.SetToolTip(Me.BtnRemoveRow, "Clear perosn details")
        Me.BtnRemoveRow.UseVisualStyleBackColor = True
        '
        'FrmDateCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1344, 690)
        Me.Controls.Add(Me.BtnRemoveRow)
        Me.Controls.Add(Me.ChkShowImage)
        Me.Controls.Add(Me.BtnMonth)
        Me.Controls.Add(Me.BtnBotSD)
        Me.Controls.Add(Me.BtnWpDesc)
        Me.Controls.Add(Me.TxtWikiId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnClearDetails)
        Me.Controls.Add(Me.BtnCopyDate)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BtnToWordPress)
        Me.Controls.Add(Me.TxtFromYear)
        Me.Controls.Add(Me.TxtFromMonth)
        Me.Controls.Add(Me.TxtFromDay)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnAll)
        Me.Controls.Add(Me.BtnFromWordPress)
        Me.Controls.Add(Me.BtnToday)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.TxtToYear)
        Me.Controls.Add(Me.TxtToMonth)
        Me.Controls.Add(Me.TxtToDay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.BtnSingleUpdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFullName)
        Me.Controls.Add(Me.nudSelectCount)
        Me.Controls.Add(Me.DgvWarnings)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.BtnWikiUpdate)
        Me.Controls.Add(Me.BtnStart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDateCheck"
        Me.Text = "Date Check"
        CType(Me.DgvWarnings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.nudSelectCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvWarnings As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents btnClose As Button
    Friend WithEvents BtnWikiUpdate As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtWiki As TextBox
    Friend WithEvents LblId As Label
    Friend WithEvents BtnSingleUpdate As Button
    Friend WithEvents TxtFullDesc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtFullName As TextBox
    Friend WithEvents nudSelectCount As NumericUpDown
    Friend WithEvents TxtToDay As TextBox
    Friend WithEvents TxtToMonth As TextBox
    Friend WithEvents TxtToYear As TextBox
    Friend WithEvents BtnToday As Button
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents BtnFromWordPress As Button
    Friend WithEvents BtnAll As Button
    Friend WithEvents TxtFromYear As TextBox
    Friend WithEvents TxtFromMonth As TextBox
    Friend WithEvents TxtFromDay As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnToWordPress As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnCopyDate As Button
    Friend WithEvents BtnClearDetails As Button
    Friend WithEvents TxtWikiId As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents BtnWpDesc As Button
    Friend WithEvents BtnBotSD As Button
    Friend WithEvents BtnMonth As Button
    Friend WithEvents xId As DataGridViewTextBoxColumn
    Friend WithEvents xName As DataGridViewTextBoxColumn
    Friend WithEvents xBirth As DataGridViewTextBoxColumn
    Friend WithEvents xWikiBirth As DataGridViewTextBoxColumn
    Friend WithEvents xWikiExtract As DataGridViewTextBoxColumn
    Friend WithEvents xWikiId As DataGridViewTextBoxColumn
    Friend WithEvents xPersonDescription As DataGridViewTextBoxColumn
    Friend WithEvents xImg As DataGridViewImageColumn
    Friend WithEvents ChkShowImage As CheckBox
    Friend WithEvents BtnRemoveRow As Button
End Class

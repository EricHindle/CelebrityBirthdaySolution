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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDateCheck))
        Me.DgvWarnings = New System.Windows.Forms.DataGridView()
        Me.xId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xBirth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xWikiBirth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xWikiExtract = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xWikiId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xPersonDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xAudit = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.BtnCopyName = New System.Windows.Forms.Button()
        Me.BtnWikiOpen = New System.Windows.Forms.Button()
        Me.BtnAuditView = New System.Windows.Forms.Button()
        Me.BtnWpDesc = New System.Windows.Forms.Button()
        Me.BtnBotSD = New System.Windows.Forms.Button()
        Me.ChkShowImage = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnBotsdPostNo = New System.Windows.Forms.Button()
        Me.BtnOthPersonId = New System.Windows.Forms.Button()
        Me.BtnBotsdId = New System.Windows.Forms.Button()
        Me.BtnBotsdUrl = New System.Windows.Forms.Button()
        Me.BtnUpdPerson = New System.Windows.Forms.Button()
        Me.BtnBotsdUpdUrl = New System.Windows.Forms.Button()
        Me.BtnBotsdListUrl = New System.Windows.Forms.Button()
        Me.BtnReseqOld = New System.Windows.Forms.Button()
        Me.BtnReseqNew = New System.Windows.Forms.Button()
        Me.BtnNewBotsdUrl = New System.Windows.Forms.Button()
        Me.BtnNewListUrl = New System.Windows.Forms.Button()
        Me.BtnRmvImage = New System.Windows.Forms.Button()
        Me.BtnUpdOldPost = New System.Windows.Forms.Button()
        Me.BtnAddImg = New System.Windows.Forms.Button()
        Me.BtnMoveImg = New System.Windows.Forms.Button()
        Me.BtnUpdNewPost = New System.Windows.Forms.Button()
        Me.BtnImgDesc = New System.Windows.Forms.Button()
        Me.BtnReseqNewGroup = New System.Windows.Forms.Button()
        Me.BtnUpdOldBotsdPost = New System.Windows.Forms.Button()
        Me.BtnRmvRow = New System.Windows.Forms.Button()
        Me.BtnUpdCbPicDesc = New System.Windows.Forms.Button()
        Me.BtnUpdNewCbPage = New System.Windows.Forms.Button()
        Me.BtnAddCbPic = New System.Windows.Forms.Button()
        Me.BtnRmvOldPicture = New System.Windows.Forms.Button()
        Me.BtnUpdOldCbPage = New System.Windows.Forms.Button()
        Me.BtnMoveCbPic = New System.Windows.Forms.Button()
        Me.BtnUpdNewBotsdList = New System.Windows.Forms.Button()
        Me.BtnUpdateNewBotsdPost = New System.Windows.Forms.Button()
        Me.BtnReseqOldGroup = New System.Windows.Forms.Button()
        Me.BtnUpdOldBotsdList = New System.Windows.Forms.Button()
        Me.BtnRmvOldBotsdPost = New System.Windows.Forms.Button()
        Me.BtnRmvBotsdRecord = New System.Windows.Forms.Button()
        Me.BtnRmvOtherBotsdId = New System.Windows.Forms.Button()
        Me.BtnRmvBotsdId = New System.Windows.Forms.Button()
        Me.BtnUpdatePerson = New System.Windows.Forms.Button()
        Me.BtnRemoveRow = New System.Windows.Forms.Button()
        Me.ChkNoExtract = New System.Windows.Forms.CheckBox()
        Me.ChkNoDates = New System.Windows.Forms.CheckBox()
        CType(Me.DgvWarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.nudSelectCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.DgvWarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.xId, Me.xName, Me.xBirth, Me.xWikiBirth, Me.xWikiExtract, Me.xWikiId, Me.xPersonDescription, Me.xAudit, Me.xImg})
        Me.DgvWarnings.Location = New System.Drawing.Point(12, 12)
        Me.DgvWarnings.Name = "DgvWarnings"
        Me.DgvWarnings.ReadOnly = True
        Me.DgvWarnings.RowHeadersVisible = False
        Me.DgvWarnings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvWarnings.Size = New System.Drawing.Size(781, 707)
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
        Me.xName.Width = 150
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
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.xWikiExtract.DefaultCellStyle = DataGridViewCellStyle1
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
        'xAudit
        '
        Me.xAudit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xAudit.HeaderText = ""
        Me.xAudit.Name = "xAudit"
        Me.xAudit.ReadOnly = True
        Me.xAudit.Width = 40
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 779)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1344, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(9, 17)
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(1234, 736)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 33)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnWikiUpdate
        '
        Me.BtnWikiUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWikiUpdate.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWikiUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWikiUpdate.Location = New System.Drawing.Point(1048, 650)
        Me.BtnWikiUpdate.Name = "BtnWikiUpdate"
        Me.BtnWikiUpdate.Size = New System.Drawing.Size(92, 24)
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
        Me.BtnStart.Location = New System.Drawing.Point(743, 736)
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
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(1200, 481)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 17)
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
        Me.TxtWiki.Size = New System.Drawing.Size(289, 153)
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
        Me.BtnSingleUpdate.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSingleUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSingleUpdate.Location = New System.Drawing.Point(1048, 426)
        Me.BtnSingleUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSingleUpdate.Name = "BtnSingleUpdate"
        Me.BtnSingleUpdate.Size = New System.Drawing.Size(135, 49)
        Me.BtnSingleUpdate.TabIndex = 60
        Me.BtnSingleUpdate.Text = "Start Update"
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
        Me.TxtFullDesc.Size = New System.Drawing.Size(289, 135)
        Me.TxtFullDesc.TabIndex = 59
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(597, 742)
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
        Me.nudSelectCount.Location = New System.Drawing.Point(655, 743)
        Me.nudSelectCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudSelectCount.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudSelectCount.Name = "nudSelectCount"
        Me.nudSelectCount.Size = New System.Drawing.Size(65, 20)
        Me.nudSelectCount.TabIndex = 55
        '
        'TxtToDay
        '
        Me.TxtToDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtToDay.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToDay.Location = New System.Drawing.Point(1200, 506)
        Me.TxtToDay.Name = "TxtToDay"
        Me.TxtToDay.Size = New System.Drawing.Size(32, 24)
        Me.TxtToDay.TabIndex = 66
        '
        'TxtToMonth
        '
        Me.TxtToMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtToMonth.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToMonth.Location = New System.Drawing.Point(1238, 506)
        Me.TxtToMonth.Name = "TxtToMonth"
        Me.TxtToMonth.Size = New System.Drawing.Size(32, 24)
        Me.TxtToMonth.TabIndex = 67
        '
        'TxtToYear
        '
        Me.TxtToYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtToYear.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToYear.Location = New System.Drawing.Point(1276, 507)
        Me.TxtToYear.Name = "TxtToYear"
        Me.TxtToYear.Size = New System.Drawing.Size(48, 24)
        Me.TxtToYear.TabIndex = 68
        '
        'BtnToday
        '
        Me.BtnToday.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnToday.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToday.Location = New System.Drawing.Point(180, 738)
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
        Me.cboMonth.Location = New System.Drawing.Point(368, 739)
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
        Me.cboDay.Location = New System.Drawing.Point(281, 739)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(71, 27)
        Me.cboDay.TabIndex = 134
        '
        'BtnFromWordPress
        '
        Me.BtnFromWordPress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFromWordPress.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFromWordPress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnFromWordPress.Location = New System.Drawing.Point(1048, 537)
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
        Me.BtnAll.Location = New System.Drawing.Point(12, 738)
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
        Me.TxtFromYear.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromYear.Location = New System.Drawing.Point(1125, 507)
        Me.TxtFromYear.Name = "TxtFromYear"
        Me.TxtFromYear.Size = New System.Drawing.Size(48, 24)
        Me.TxtFromYear.TabIndex = 142
        '
        'TxtFromMonth
        '
        Me.TxtFromMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromMonth.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromMonth.Location = New System.Drawing.Point(1087, 507)
        Me.TxtFromMonth.Name = "TxtFromMonth"
        Me.TxtFromMonth.Size = New System.Drawing.Size(32, 24)
        Me.TxtFromMonth.TabIndex = 141
        '
        'TxtFromDay
        '
        Me.TxtFromDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtFromDay.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromDay.Location = New System.Drawing.Point(1048, 506)
        Me.TxtFromDay.Name = "TxtFromDay"
        Me.TxtFromDay.Size = New System.Drawing.Size(32, 24)
        Me.TxtFromDay.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(1048, 481)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 17)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "From this"
        '
        'BtnToWordPress
        '
        Me.BtnToWordPress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnToWordPress.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToWordPress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToWordPress.Location = New System.Drawing.Point(1200, 537)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(299, 329)
        Me.SplitContainer1.SplitterDistance = 153
        Me.SplitContainer1.TabIndex = 144
        '
        'BtnCopyDate
        '
        Me.BtnCopyDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyDate.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyDate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyDate.Location = New System.Drawing.Point(1048, 382)
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
        Me.BtnClearDetails.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearDetails.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClearDetails.Location = New System.Drawing.Point(1267, 382)
        Me.BtnClearDetails.Name = "BtnClearDetails"
        Me.BtnClearDetails.Size = New System.Drawing.Size(65, 33)
        Me.BtnClearDetails.TabIndex = 146
        Me.BtnClearDetails.Text = "Clear"
        Me.ToolTip1.SetToolTip(Me.BtnClearDetails, "Clear perosn details")
        Me.BtnClearDetails.UseVisualStyleBackColor = True
        '
        'TxtWikiId
        '
        Me.TxtWikiId.AllowDrop = True
        Me.TxtWikiId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWikiId.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWikiId.Location = New System.Drawing.Point(1048, 620)
        Me.TxtWikiId.Name = "TxtWikiId"
        Me.TxtWikiId.Size = New System.Drawing.Size(161, 24)
        Me.TxtWikiId.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(1048, 600)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 17)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Wiki"
        '
        'BtnMonth
        '
        Me.BtnMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnMonth.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMonth.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnMonth.Location = New System.Drawing.Point(102, 738)
        Me.BtnMonth.Name = "BtnMonth"
        Me.BtnMonth.Size = New System.Drawing.Size(72, 28)
        Me.BtnMonth.TabIndex = 151
        Me.BtnMonth.Text = "Month"
        Me.ToolTip1.SetToolTip(Me.BtnMonth, "Select Today only")
        Me.BtnMonth.UseVisualStyleBackColor = True
        '
        'BtnCopyName
        '
        Me.BtnCopyName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyName.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyName.Image = Global.CelebrityBirthday.My.Resources.Resources.copyiconpale
        Me.BtnCopyName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCopyName.Location = New System.Drawing.Point(1246, 686)
        Me.BtnCopyName.Name = "BtnCopyName"
        Me.BtnCopyName.Size = New System.Drawing.Size(68, 33)
        Me.BtnCopyName.TabIndex = 155
        Me.BtnCopyName.Text = "Name"
        Me.BtnCopyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolTip1.SetToolTip(Me.BtnCopyName, "Copy selected text or wiki date to person text")
        Me.BtnCopyName.UseVisualStyleBackColor = True
        '
        'BtnWikiOpen
        '
        Me.BtnWikiOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWikiOpen.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWikiOpen.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWikiOpen.Location = New System.Drawing.Point(1246, 632)
        Me.BtnWikiOpen.Name = "BtnWikiOpen"
        Me.BtnWikiOpen.Size = New System.Drawing.Size(89, 42)
        Me.BtnWikiOpen.TabIndex = 156
        Me.BtnWikiOpen.Text = "Open wiki"
        Me.ToolTip1.SetToolTip(Me.BtnWikiOpen, "Update WikiId for person")
        Me.BtnWikiOpen.UseVisualStyleBackColor = True
        '
        'BtnAuditView
        '
        Me.BtnAuditView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAuditView.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAuditView.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAuditView.Location = New System.Drawing.Point(1188, 426)
        Me.BtnAuditView.Name = "BtnAuditView"
        Me.BtnAuditView.Size = New System.Drawing.Size(52, 49)
        Me.BtnAuditView.TabIndex = 157
        Me.BtnAuditView.Text = "View Audit"
        Me.ToolTip1.SetToolTip(Me.BtnAuditView, "Update WikiId for person")
        Me.BtnAuditView.UseVisualStyleBackColor = True
        '
        'BtnWpDesc
        '
        Me.BtnWpDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWpDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnWpDesc.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWpDesc.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWpDesc.Image = Global.CelebrityBirthday.My.Resources.Resources.copyiconpale
        Me.BtnWpDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnWpDesc.Location = New System.Drawing.Point(1048, 686)
        Me.BtnWpDesc.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnWpDesc.Name = "BtnWpDesc"
        Me.BtnWpDesc.Size = New System.Drawing.Size(161, 33)
        Me.BtnWpDesc.TabIndex = 149
        Me.BtnWpDesc.Text = "Get Description"
        Me.BtnWpDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnWpDesc.UseVisualStyleBackColor = True
        '
        'BtnBotSD
        '
        Me.BtnBotSD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnBotSD.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotSD.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBotSD.Location = New System.Drawing.Point(1234, 577)
        Me.BtnBotSD.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.BtnBotSD.Name = "BtnBotSD"
        Me.BtnBotSD.Size = New System.Drawing.Size(101, 33)
        Me.BtnBotSD.TabIndex = 150
        Me.BtnBotSD.Text = "BotSD"
        Me.BtnBotSD.UseVisualStyleBackColor = True
        '
        'ChkShowImage
        '
        Me.ChkShowImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkShowImage.AutoSize = True
        Me.ChkShowImage.Checked = True
        Me.ChkShowImage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkShowImage.Location = New System.Drawing.Point(897, 744)
        Me.ChkShowImage.Name = "ChkShowImage"
        Me.ChkShowImage.Size = New System.Drawing.Size(90, 17)
        Me.ChkShowImage.TabIndex = 152
        Me.ChkShowImage.Text = "Show Images"
        Me.ChkShowImage.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnBotsdPostNo)
        Me.GroupBox1.Controls.Add(Me.BtnOthPersonId)
        Me.GroupBox1.Controls.Add(Me.BtnBotsdId)
        Me.GroupBox1.Controls.Add(Me.BtnBotsdUrl)
        Me.GroupBox1.Controls.Add(Me.BtnUpdPerson)
        Me.GroupBox1.Controls.Add(Me.BtnBotsdUpdUrl)
        Me.GroupBox1.Controls.Add(Me.BtnBotsdListUrl)
        Me.GroupBox1.Controls.Add(Me.BtnReseqOld)
        Me.GroupBox1.Controls.Add(Me.BtnReseqNew)
        Me.GroupBox1.Controls.Add(Me.BtnNewBotsdUrl)
        Me.GroupBox1.Controls.Add(Me.BtnNewListUrl)
        Me.GroupBox1.Controls.Add(Me.BtnRmvImage)
        Me.GroupBox1.Controls.Add(Me.BtnUpdOldPost)
        Me.GroupBox1.Controls.Add(Me.BtnAddImg)
        Me.GroupBox1.Controls.Add(Me.BtnMoveImg)
        Me.GroupBox1.Controls.Add(Me.BtnUpdNewPost)
        Me.GroupBox1.Controls.Add(Me.BtnImgDesc)
        Me.GroupBox1.Controls.Add(Me.BtnReseqNewGroup)
        Me.GroupBox1.Controls.Add(Me.BtnUpdOldBotsdPost)
        Me.GroupBox1.Controls.Add(Me.BtnRmvRow)
        Me.GroupBox1.Controls.Add(Me.BtnUpdCbPicDesc)
        Me.GroupBox1.Controls.Add(Me.BtnUpdNewCbPage)
        Me.GroupBox1.Controls.Add(Me.BtnAddCbPic)
        Me.GroupBox1.Controls.Add(Me.BtnRmvOldPicture)
        Me.GroupBox1.Controls.Add(Me.BtnUpdOldCbPage)
        Me.GroupBox1.Controls.Add(Me.BtnMoveCbPic)
        Me.GroupBox1.Controls.Add(Me.BtnUpdNewBotsdList)
        Me.GroupBox1.Controls.Add(Me.BtnUpdateNewBotsdPost)
        Me.GroupBox1.Controls.Add(Me.BtnReseqOldGroup)
        Me.GroupBox1.Controls.Add(Me.BtnUpdOldBotsdList)
        Me.GroupBox1.Controls.Add(Me.BtnRmvOldBotsdPost)
        Me.GroupBox1.Controls.Add(Me.BtnRmvBotsdRecord)
        Me.GroupBox1.Controls.Add(Me.BtnRmvOtherBotsdId)
        Me.GroupBox1.Controls.Add(Me.BtnRmvBotsdId)
        Me.GroupBox1.Controls.Add(Me.BtnUpdatePerson)
        Me.GroupBox1.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox1.Location = New System.Drawing.Point(799, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(228, 707)
        Me.GroupBox1.TabIndex = 154
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Checklist"
        '
        'BtnBotsdPostNo
        '
        Me.BtnBotsdPostNo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotsdPostNo.Location = New System.Drawing.Point(152, 29)
        Me.BtnBotsdPostNo.Name = "BtnBotsdPostNo"
        Me.BtnBotsdPostNo.Size = New System.Drawing.Size(70, 23)
        Me.BtnBotsdPostNo.TabIndex = 53
        Me.BtnBotsdPostNo.Text = "dbUpd"
        Me.BtnBotsdPostNo.UseVisualStyleBackColor = True
        '
        'BtnOthPersonId
        '
        Me.BtnOthPersonId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOthPersonId.Location = New System.Drawing.Point(152, 67)
        Me.BtnOthPersonId.Name = "BtnOthPersonId"
        Me.BtnOthPersonId.Size = New System.Drawing.Size(70, 23)
        Me.BtnOthPersonId.TabIndex = 52
        Me.BtnOthPersonId.Text = "dbUpd"
        Me.BtnOthPersonId.UseVisualStyleBackColor = True
        '
        'BtnBotsdId
        '
        Me.BtnBotsdId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotsdId.Location = New System.Drawing.Point(152, 105)
        Me.BtnBotsdId.Name = "BtnBotsdId"
        Me.BtnBotsdId.Size = New System.Drawing.Size(70, 23)
        Me.BtnBotsdId.TabIndex = 51
        Me.BtnBotsdId.Text = "dbUpd"
        Me.BtnBotsdId.UseVisualStyleBackColor = True
        '
        'BtnBotsdUrl
        '
        Me.BtnBotsdUrl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotsdUrl.Location = New System.Drawing.Point(152, 143)
        Me.BtnBotsdUrl.Name = "BtnBotsdUrl"
        Me.BtnBotsdUrl.Size = New System.Drawing.Size(70, 23)
        Me.BtnBotsdUrl.TabIndex = 50
        Me.BtnBotsdUrl.Text = "webUpd"
        Me.BtnBotsdUrl.UseVisualStyleBackColor = True
        '
        'BtnUpdPerson
        '
        Me.BtnUpdPerson.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdPerson.Location = New System.Drawing.Point(152, 181)
        Me.BtnUpdPerson.Name = "BtnUpdPerson"
        Me.BtnUpdPerson.Size = New System.Drawing.Size(70, 23)
        Me.BtnUpdPerson.TabIndex = 49
        Me.BtnUpdPerson.Text = "dbUpd"
        Me.BtnUpdPerson.UseVisualStyleBackColor = True
        '
        'BtnBotsdUpdUrl
        '
        Me.BtnBotsdUpdUrl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotsdUpdUrl.Location = New System.Drawing.Point(152, 219)
        Me.BtnBotsdUpdUrl.Name = "BtnBotsdUpdUrl"
        Me.BtnBotsdUpdUrl.Size = New System.Drawing.Size(70, 23)
        Me.BtnBotsdUpdUrl.TabIndex = 48
        Me.BtnBotsdUpdUrl.Text = "webUpd"
        Me.BtnBotsdUpdUrl.UseVisualStyleBackColor = True
        '
        'BtnBotsdListUrl
        '
        Me.BtnBotsdListUrl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotsdListUrl.Location = New System.Drawing.Point(152, 257)
        Me.BtnBotsdListUrl.Name = "BtnBotsdListUrl"
        Me.BtnBotsdListUrl.Size = New System.Drawing.Size(70, 23)
        Me.BtnBotsdListUrl.TabIndex = 47
        Me.BtnBotsdListUrl.Text = "webUpd"
        Me.BtnBotsdListUrl.UseVisualStyleBackColor = True
        '
        'BtnReseqOld
        '
        Me.BtnReseqOld.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReseqOld.Location = New System.Drawing.Point(152, 295)
        Me.BtnReseqOld.Name = "BtnReseqOld"
        Me.BtnReseqOld.Size = New System.Drawing.Size(70, 23)
        Me.BtnReseqOld.TabIndex = 46
        Me.BtnReseqOld.Text = "dbUpd"
        Me.BtnReseqOld.UseVisualStyleBackColor = True
        '
        'BtnReseqNew
        '
        Me.BtnReseqNew.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReseqNew.Location = New System.Drawing.Point(152, 333)
        Me.BtnReseqNew.Name = "BtnReseqNew"
        Me.BtnReseqNew.Size = New System.Drawing.Size(70, 23)
        Me.BtnReseqNew.TabIndex = 45
        Me.BtnReseqNew.Text = "dbUpd"
        Me.BtnReseqNew.UseVisualStyleBackColor = True
        '
        'BtnNewBotsdUrl
        '
        Me.BtnNewBotsdUrl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNewBotsdUrl.Location = New System.Drawing.Point(152, 371)
        Me.BtnNewBotsdUrl.Name = "BtnNewBotsdUrl"
        Me.BtnNewBotsdUrl.Size = New System.Drawing.Size(70, 23)
        Me.BtnNewBotsdUrl.TabIndex = 44
        Me.BtnNewBotsdUrl.Text = "webUpd"
        Me.BtnNewBotsdUrl.UseVisualStyleBackColor = True
        '
        'BtnNewListUrl
        '
        Me.BtnNewListUrl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNewListUrl.Location = New System.Drawing.Point(152, 409)
        Me.BtnNewListUrl.Name = "BtnNewListUrl"
        Me.BtnNewListUrl.Size = New System.Drawing.Size(70, 23)
        Me.BtnNewListUrl.TabIndex = 43
        Me.BtnNewListUrl.Text = "webUpd"
        Me.BtnNewListUrl.UseVisualStyleBackColor = True
        '
        'BtnRmvImage
        '
        Me.BtnRmvImage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvImage.Location = New System.Drawing.Point(152, 447)
        Me.BtnRmvImage.Name = "BtnRmvImage"
        Me.BtnRmvImage.Size = New System.Drawing.Size(70, 23)
        Me.BtnRmvImage.TabIndex = 42
        Me.BtnRmvImage.Text = "webUpd"
        Me.BtnRmvImage.UseVisualStyleBackColor = True
        '
        'BtnUpdOldPost
        '
        Me.BtnUpdOldPost.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdOldPost.Location = New System.Drawing.Point(152, 485)
        Me.BtnUpdOldPost.Name = "BtnUpdOldPost"
        Me.BtnUpdOldPost.Size = New System.Drawing.Size(70, 23)
        Me.BtnUpdOldPost.TabIndex = 41
        Me.BtnUpdOldPost.Text = "webUpd"
        Me.BtnUpdOldPost.UseVisualStyleBackColor = True
        '
        'BtnAddImg
        '
        Me.BtnAddImg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddImg.Location = New System.Drawing.Point(152, 523)
        Me.BtnAddImg.Name = "BtnAddImg"
        Me.BtnAddImg.Size = New System.Drawing.Size(70, 23)
        Me.BtnAddImg.TabIndex = 40
        Me.BtnAddImg.Text = "webUpd"
        Me.BtnAddImg.UseVisualStyleBackColor = True
        '
        'BtnMoveImg
        '
        Me.BtnMoveImg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveImg.Location = New System.Drawing.Point(152, 561)
        Me.BtnMoveImg.Name = "BtnMoveImg"
        Me.BtnMoveImg.Size = New System.Drawing.Size(70, 23)
        Me.BtnMoveImg.TabIndex = 39
        Me.BtnMoveImg.Text = "webUpd"
        Me.BtnMoveImg.UseVisualStyleBackColor = True
        '
        'BtnUpdNewPost
        '
        Me.BtnUpdNewPost.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdNewPost.Location = New System.Drawing.Point(152, 598)
        Me.BtnUpdNewPost.Name = "BtnUpdNewPost"
        Me.BtnUpdNewPost.Size = New System.Drawing.Size(70, 23)
        Me.BtnUpdNewPost.TabIndex = 38
        Me.BtnUpdNewPost.Text = "webUpd"
        Me.BtnUpdNewPost.UseVisualStyleBackColor = True
        '
        'BtnImgDesc
        '
        Me.BtnImgDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImgDesc.Location = New System.Drawing.Point(152, 637)
        Me.BtnImgDesc.Name = "BtnImgDesc"
        Me.BtnImgDesc.Size = New System.Drawing.Size(70, 23)
        Me.BtnImgDesc.TabIndex = 37
        Me.BtnImgDesc.Text = "webUpd"
        Me.BtnImgDesc.UseVisualStyleBackColor = True
        '
        'BtnReseqNewGroup
        '
        Me.BtnReseqNewGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReseqNewGroup.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnReseqNewGroup.Location = New System.Drawing.Point(6, 329)
        Me.BtnReseqNewGroup.Name = "BtnReseqNewGroup"
        Me.BtnReseqNewGroup.Size = New System.Drawing.Size(140, 29)
        Me.BtnReseqNewGroup.TabIndex = 18
        Me.BtnReseqNewGroup.Text = "Reseq new grp"
        Me.BtnReseqNewGroup.UseVisualStyleBackColor = True
        '
        'BtnUpdOldBotsdPost
        '
        Me.BtnUpdOldBotsdPost.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdOldBotsdPost.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdOldBotsdPost.Location = New System.Drawing.Point(6, 215)
        Me.BtnUpdOldBotsdPost.Name = "BtnUpdOldBotsdPost"
        Me.BtnUpdOldBotsdPost.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdOldBotsdPost.TabIndex = 17
        Me.BtnUpdOldBotsdPost.Text = "Update old botsd post"
        Me.BtnUpdOldBotsdPost.UseVisualStyleBackColor = True
        '
        'BtnRmvRow
        '
        Me.BtnRmvRow.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvRow.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvRow.Location = New System.Drawing.Point(6, 671)
        Me.BtnRmvRow.Name = "BtnRmvRow"
        Me.BtnRmvRow.Size = New System.Drawing.Size(140, 29)
        Me.BtnRmvRow.TabIndex = 16
        Me.BtnRmvRow.Text = "Remove row"
        Me.BtnRmvRow.UseVisualStyleBackColor = True
        '
        'BtnUpdCbPicDesc
        '
        Me.BtnUpdCbPicDesc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdCbPicDesc.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdCbPicDesc.Location = New System.Drawing.Point(6, 633)
        Me.BtnUpdCbPicDesc.Name = "BtnUpdCbPicDesc"
        Me.BtnUpdCbPicDesc.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdCbPicDesc.TabIndex = 15
        Me.BtnUpdCbPicDesc.Text = "Update picture desc"
        Me.BtnUpdCbPicDesc.UseVisualStyleBackColor = True
        '
        'BtnUpdNewCbPage
        '
        Me.BtnUpdNewCbPage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdNewCbPage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdNewCbPage.Location = New System.Drawing.Point(6, 595)
        Me.BtnUpdNewCbPage.Name = "BtnUpdNewCbPage"
        Me.BtnUpdNewCbPage.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdNewCbPage.TabIndex = 14
        Me.BtnUpdNewCbPage.Text = "Update new CB page"
        Me.BtnUpdNewCbPage.UseVisualStyleBackColor = True
        '
        'BtnAddCbPic
        '
        Me.BtnAddCbPic.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddCbPic.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAddCbPic.Location = New System.Drawing.Point(6, 519)
        Me.BtnAddCbPic.Name = "BtnAddCbPic"
        Me.BtnAddCbPic.Size = New System.Drawing.Size(140, 29)
        Me.BtnAddCbPic.TabIndex = 13
        Me.BtnAddCbPic.Text = "Add CB picture"
        Me.BtnAddCbPic.UseVisualStyleBackColor = True
        '
        'BtnRmvOldPicture
        '
        Me.BtnRmvOldPicture.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvOldPicture.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvOldPicture.Location = New System.Drawing.Point(6, 443)
        Me.BtnRmvOldPicture.Name = "BtnRmvOldPicture"
        Me.BtnRmvOldPicture.Size = New System.Drawing.Size(140, 29)
        Me.BtnRmvOldPicture.TabIndex = 12
        Me.BtnRmvOldPicture.Text = "Remove old picture"
        Me.BtnRmvOldPicture.UseVisualStyleBackColor = True
        '
        'BtnUpdOldCbPage
        '
        Me.BtnUpdOldCbPage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdOldCbPage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdOldCbPage.Location = New System.Drawing.Point(6, 481)
        Me.BtnUpdOldCbPage.Name = "BtnUpdOldCbPage"
        Me.BtnUpdOldCbPage.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdOldCbPage.TabIndex = 11
        Me.BtnUpdOldCbPage.Text = "Update old CB Page"
        Me.BtnUpdOldCbPage.UseVisualStyleBackColor = True
        '
        'BtnMoveCbPic
        '
        Me.BtnMoveCbPic.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMoveCbPic.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnMoveCbPic.Location = New System.Drawing.Point(6, 557)
        Me.BtnMoveCbPic.Name = "BtnMoveCbPic"
        Me.BtnMoveCbPic.Size = New System.Drawing.Size(140, 29)
        Me.BtnMoveCbPic.TabIndex = 10
        Me.BtnMoveCbPic.Text = "Move CB picture"
        Me.BtnMoveCbPic.UseVisualStyleBackColor = True
        '
        'BtnUpdNewBotsdList
        '
        Me.BtnUpdNewBotsdList.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdNewBotsdList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdNewBotsdList.Location = New System.Drawing.Point(6, 405)
        Me.BtnUpdNewBotsdList.Name = "BtnUpdNewBotsdList"
        Me.BtnUpdNewBotsdList.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdNewBotsdList.TabIndex = 8
        Me.BtnUpdNewBotsdList.Text = "Update new botsd list"
        Me.BtnUpdNewBotsdList.UseVisualStyleBackColor = True
        '
        'BtnUpdateNewBotsdPost
        '
        Me.BtnUpdateNewBotsdPost.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdateNewBotsdPost.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdateNewBotsdPost.Location = New System.Drawing.Point(6, 367)
        Me.BtnUpdateNewBotsdPost.Name = "BtnUpdateNewBotsdPost"
        Me.BtnUpdateNewBotsdPost.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdateNewBotsdPost.TabIndex = 7
        Me.BtnUpdateNewBotsdPost.Text = "Upd new botsd post"
        Me.BtnUpdateNewBotsdPost.UseVisualStyleBackColor = True
        '
        'BtnReseqOldGroup
        '
        Me.BtnReseqOldGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReseqOldGroup.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnReseqOldGroup.Location = New System.Drawing.Point(6, 291)
        Me.BtnReseqOldGroup.Name = "BtnReseqOldGroup"
        Me.BtnReseqOldGroup.Size = New System.Drawing.Size(140, 29)
        Me.BtnReseqOldGroup.TabIndex = 6
        Me.BtnReseqOldGroup.Text = "Reseq old grp"
        Me.BtnReseqOldGroup.UseVisualStyleBackColor = True
        '
        'BtnUpdOldBotsdList
        '
        Me.BtnUpdOldBotsdList.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdOldBotsdList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdOldBotsdList.Location = New System.Drawing.Point(6, 253)
        Me.BtnUpdOldBotsdList.Name = "BtnUpdOldBotsdList"
        Me.BtnUpdOldBotsdList.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdOldBotsdList.TabIndex = 5
        Me.BtnUpdOldBotsdList.Text = "Update old botsd list"
        Me.BtnUpdOldBotsdList.UseVisualStyleBackColor = True
        '
        'BtnRmvOldBotsdPost
        '
        Me.BtnRmvOldBotsdPost.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvOldBotsdPost.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvOldBotsdPost.Location = New System.Drawing.Point(6, 139)
        Me.BtnRmvOldBotsdPost.Name = "BtnRmvOldBotsdPost"
        Me.BtnRmvOldBotsdPost.Size = New System.Drawing.Size(140, 29)
        Me.BtnRmvOldBotsdPost.TabIndex = 4
        Me.BtnRmvOldBotsdPost.Text = "Remove old post"
        Me.BtnRmvOldBotsdPost.UseVisualStyleBackColor = True
        '
        'BtnRmvBotsdRecord
        '
        Me.BtnRmvBotsdRecord.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvBotsdRecord.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvBotsdRecord.Location = New System.Drawing.Point(6, 101)
        Me.BtnRmvBotsdRecord.Name = "BtnRmvBotsdRecord"
        Me.BtnRmvBotsdRecord.Size = New System.Drawing.Size(140, 29)
        Me.BtnRmvBotsdRecord.TabIndex = 3
        Me.BtnRmvBotsdRecord.Text = "Remove botsd rec"
        Me.BtnRmvBotsdRecord.UseVisualStyleBackColor = True
        '
        'BtnRmvOtherBotsdId
        '
        Me.BtnRmvOtherBotsdId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvOtherBotsdId.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvOtherBotsdId.Location = New System.Drawing.Point(6, 63)
        Me.BtnRmvOtherBotsdId.Name = "BtnRmvOtherBotsdId"
        Me.BtnRmvOtherBotsdId.Size = New System.Drawing.Size(140, 29)
        Me.BtnRmvOtherBotsdId.TabIndex = 2
        Me.BtnRmvOtherBotsdId.Text = "Remove other botsd id"
        Me.BtnRmvOtherBotsdId.UseVisualStyleBackColor = True
        '
        'BtnRmvBotsdId
        '
        Me.BtnRmvBotsdId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvBotsdId.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvBotsdId.Location = New System.Drawing.Point(6, 25)
        Me.BtnRmvBotsdId.Name = "BtnRmvBotsdId"
        Me.BtnRmvBotsdId.Size = New System.Drawing.Size(140, 29)
        Me.BtnRmvBotsdId.TabIndex = 1
        Me.BtnRmvBotsdId.Text = "Remove botsd id"
        Me.BtnRmvBotsdId.UseVisualStyleBackColor = True
        '
        'BtnUpdatePerson
        '
        Me.BtnUpdatePerson.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdatePerson.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdatePerson.Location = New System.Drawing.Point(6, 177)
        Me.BtnUpdatePerson.Name = "BtnUpdatePerson"
        Me.BtnUpdatePerson.Size = New System.Drawing.Size(140, 29)
        Me.BtnUpdatePerson.TabIndex = 0
        Me.BtnUpdatePerson.Text = "Update Person"
        Me.BtnUpdatePerson.UseVisualStyleBackColor = True
        '
        'BtnRemoveRow
        '
        Me.BtnRemoveRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRemoveRow.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemoveRow.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRemoveRow.Location = New System.Drawing.Point(1245, 425)
        Me.BtnRemoveRow.Name = "BtnRemoveRow"
        Me.BtnRemoveRow.Size = New System.Drawing.Size(86, 50)
        Me.BtnRemoveRow.TabIndex = 19
        Me.BtnRemoveRow.Text = "Remove row"
        Me.BtnRemoveRow.UseVisualStyleBackColor = True
        '
        'ChkNoExtract
        '
        Me.ChkNoExtract.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkNoExtract.AutoSize = True
        Me.ChkNoExtract.Location = New System.Drawing.Point(993, 744)
        Me.ChkNoExtract.Name = "ChkNoExtract"
        Me.ChkNoExtract.Size = New System.Drawing.Size(106, 17)
        Me.ChkNoExtract.TabIndex = 158
        Me.ChkNoExtract.Text = "Show No Extract"
        Me.ChkNoExtract.UseVisualStyleBackColor = True
        '
        'ChkNoDates
        '
        Me.ChkNoDates.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkNoDates.AutoSize = True
        Me.ChkNoDates.Checked = True
        Me.ChkNoDates.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkNoDates.Location = New System.Drawing.Point(1105, 744)
        Me.ChkNoDates.Name = "ChkNoDates"
        Me.ChkNoDates.Size = New System.Drawing.Size(101, 17)
        Me.ChkNoDates.TabIndex = 159
        Me.ChkNoDates.Text = "Show No Dates"
        Me.ChkNoDates.UseVisualStyleBackColor = True
        '
        'FrmDateCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1344, 801)
        Me.Controls.Add(Me.ChkNoDates)
        Me.Controls.Add(Me.ChkNoExtract)
        Me.Controls.Add(Me.BtnAuditView)
        Me.Controls.Add(Me.BtnWikiOpen)
        Me.Controls.Add(Me.BtnCopyName)
        Me.Controls.Add(Me.BtnRemoveRow)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.MinimumSize = New System.Drawing.Size(1360, 840)
        Me.Name = "FrmDateCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
        Me.GroupBox1.ResumeLayout(False)
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
    Friend WithEvents ChkShowImage As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BtnRmvRow As Button
    Friend WithEvents BtnUpdCbPicDesc As Button
    Friend WithEvents BtnUpdNewCbPage As Button
    Friend WithEvents BtnAddCbPic As Button
    Friend WithEvents BtnRmvOldPicture As Button
    Friend WithEvents BtnUpdOldCbPage As Button
    Friend WithEvents BtnMoveCbPic As Button
    Friend WithEvents BtnUpdNewBotsdList As Button
    Friend WithEvents BtnUpdateNewBotsdPost As Button
    Friend WithEvents BtnReseqOldGroup As Button
    Friend WithEvents BtnUpdOldBotsdList As Button
    Friend WithEvents BtnRmvOldBotsdPost As Button
    Friend WithEvents BtnRmvBotsdRecord As Button
    Friend WithEvents BtnRmvOtherBotsdId As Button
    Friend WithEvents BtnRmvBotsdId As Button
    Friend WithEvents BtnUpdatePerson As Button
    Friend WithEvents BtnUpdOldBotsdPost As Button
    Friend WithEvents BtnReseqNewGroup As Button
    Friend WithEvents BtnRemoveRow As Button
    Friend WithEvents BtnCopyName As Button
    Friend WithEvents BtnWikiOpen As Button
    Friend WithEvents BtnAuditView As Button
    Friend WithEvents xId As DataGridViewTextBoxColumn
    Friend WithEvents xName As DataGridViewTextBoxColumn
    Friend WithEvents xBirth As DataGridViewTextBoxColumn
    Friend WithEvents xWikiBirth As DataGridViewTextBoxColumn
    Friend WithEvents xWikiExtract As DataGridViewTextBoxColumn
    Friend WithEvents xWikiId As DataGridViewTextBoxColumn
    Friend WithEvents xPersonDescription As DataGridViewTextBoxColumn
    Friend WithEvents xAudit As DataGridViewTextBoxColumn
    Friend WithEvents xImg As DataGridViewImageColumn
    Friend WithEvents ChkNoExtract As CheckBox
    Friend WithEvents ChkNoDates As CheckBox
    Friend WithEvents BtnBotsdPostNo As Button
    Friend WithEvents BtnOthPersonId As Button
    Friend WithEvents BtnBotsdId As Button
    Friend WithEvents BtnBotsdUrl As Button
    Friend WithEvents BtnUpdPerson As Button
    Friend WithEvents BtnBotsdUpdUrl As Button
    Friend WithEvents BtnBotsdListUrl As Button
    Friend WithEvents BtnReseqOld As Button
    Friend WithEvents BtnReseqNew As Button
    Friend WithEvents BtnNewBotsdUrl As Button
    Friend WithEvents BtnNewListUrl As Button
    Friend WithEvents BtnRmvImage As Button
    Friend WithEvents BtnUpdOldPost As Button
    Friend WithEvents BtnAddImg As Button
    Friend WithEvents BtnMoveImg As Button
    Friend WithEvents BtnUpdNewPost As Button
    Friend WithEvents BtnImgDesc As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDailyTweets
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDailyTweets))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.LblImageCount = New System.Windows.Forms.Label()
        Me.NudPic1Horizontal = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbSplitImages = New System.Windows.Forms.RadioButton()
        Me.RbSingleImage = New System.Windows.Forms.RadioButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.rtbFile1 = New System.Windows.Forms.RichTextBox()
        Me.BtnCopyselected = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnCopyAll = New System.Windows.Forms.Button()
        Me.NudBirthdaysPerTweet = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtStats = New System.Windows.Forms.TextBox()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.tvBirthday = New System.Windows.Forms.TreeView()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbImageCentre = New System.Windows.Forms.RadioButton()
        Me.rbImageRight = New System.Windows.Forms.RadioButton()
        Me.rbImageLeft = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChkAtNextBirthday = New System.Windows.Forms.CheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbHandles = New System.Windows.Forms.RadioButton()
        Me.rbAges = New System.Windows.Forms.RadioButton()
        Me.cmbTwitterUsers = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkImages = New System.Windows.Forms.CheckBox()
        Me.rtbTweet = New System.Windows.Forms.RichTextBox()
        Me.BtnReGen = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NudAnnivsPerTweet = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnTotd = New System.Windows.Forms.Button()
        Me.BtnUncheck = New System.Windows.Forms.Button()
        Me.BtnDeleteImages = New System.Windows.Forms.Button()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.BtnExplorer = New System.Windows.Forms.Button()
        Me.BtnTweetDeck = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.NudBirthdaysPerTweet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NudAnnivsPerTweet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 765)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1348, 22)
        Me.StatusStrip1.TabIndex = 0
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
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(360, 360)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'cboDay
        '
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(103, 7)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(95, 27)
        Me.cboDay.TabIndex = 2
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(206, 7)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(240, 27)
        Me.cboMonth.TabIndex = 3
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSaveImage.Location = New System.Drawing.Point(1189, 140)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(139, 33)
        Me.BtnSaveImage.TabIndex = 5
        Me.BtnSaveImage.Text = "Save Images"
        Me.BtnSaveImage.UseVisualStyleBackColor = True
        '
        'LblImageCount
        '
        Me.LblImageCount.AutoSize = True
        Me.LblImageCount.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImageCount.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblImageCount.Location = New System.Drawing.Point(306, 269)
        Me.LblImageCount.Name = "LblImageCount"
        Me.LblImageCount.Size = New System.Drawing.Size(64, 17)
        Me.LblImageCount.TabIndex = 6
        Me.LblImageCount.Text = "0 Images"
        '
        'NudPic1Horizontal
        '
        Me.NudPic1Horizontal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudPic1Horizontal.Location = New System.Drawing.Point(58, 587)
        Me.NudPic1Horizontal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudPic1Horizontal.Name = "NudPic1Horizontal"
        Me.NudPic1Horizontal.Size = New System.Drawing.Size(53, 22)
        Me.NudPic1Horizontal.TabIndex = 7
        Me.NudPic1Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudPic1Horizontal.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 591)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Width"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(1189, 716)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RbSplitImages)
        Me.GroupBox1.Controls.Add(Me.RbSingleImage)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 78)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'RbSplitImages
        '
        Me.RbSplitImages.AutoSize = True
        Me.RbSplitImages.Checked = True
        Me.RbSplitImages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSplitImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.RbSplitImages.Location = New System.Drawing.Point(23, 44)
        Me.RbSplitImages.Name = "RbSplitImages"
        Me.RbSplitImages.Size = New System.Drawing.Size(97, 17)
        Me.RbSplitImages.TabIndex = 1
        Me.RbSplitImages.TabStop = True
        Me.RbSplitImages.Text = "Twitter Images"
        Me.RbSplitImages.UseVisualStyleBackColor = True
        '
        'RbSingleImage
        '
        Me.RbSingleImage.AutoSize = True
        Me.RbSingleImage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSingleImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.RbSingleImage.Location = New System.Drawing.Point(23, 16)
        Me.RbSingleImage.Name = "RbSingleImage"
        Me.RbSingleImage.Size = New System.Drawing.Size(86, 17)
        Me.RbSingleImage.TabIndex = 0
        Me.RbSingleImage.Text = "Single Image"
        Me.RbSingleImage.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(471, 46)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(706, 659)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(698, 632)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Born On This Day"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(9, 6)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSend)
        Me.SplitContainer1.Panel1.Controls.Add(Me.NudPic1Horizontal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtbFile1)
        Me.SplitContainer1.Size = New System.Drawing.Size(683, 620)
        Me.SplitContainer1.SplitterDistance = 369
        Me.SplitContainer1.TabIndex = 23
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(206, 576)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(139, 33)
        Me.BtnSend.TabIndex = 34
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'rtbFile1
        '
        Me.rtbFile1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFile1.Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbFile1.Location = New System.Drawing.Point(3, 3)
        Me.rtbFile1.Name = "rtbFile1"
        Me.rtbFile1.Size = New System.Drawing.Size(297, 607)
        Me.rtbFile1.TabIndex = 14
        Me.rtbFile1.Text = ""
        '
        'BtnCopyselected
        '
        Me.BtnCopyselected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyselected.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyselected.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyselected.Location = New System.Drawing.Point(1189, 220)
        Me.BtnCopyselected.Name = "BtnCopyselected"
        Me.BtnCopyselected.Size = New System.Drawing.Size(139, 33)
        Me.BtnCopyselected.TabIndex = 21
        Me.BtnCopyselected.Text = "Copy Selected"
        Me.BtnCopyselected.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.CopyAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 48)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CopyToolStripMenuItem.Text = "Copy Selected"
        '
        'CopyAllToolStripMenuItem
        '
        Me.CopyAllToolStripMenuItem.Name = "CopyAllToolStripMenuItem"
        Me.CopyAllToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CopyAllToolStripMenuItem.Text = "Copy All"
        '
        'BtnCopyAll
        '
        Me.BtnCopyAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyAll.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyAll.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyAll.Location = New System.Drawing.Point(1189, 181)
        Me.BtnCopyAll.Name = "BtnCopyAll"
        Me.BtnCopyAll.Size = New System.Drawing.Size(139, 33)
        Me.BtnCopyAll.TabIndex = 22
        Me.BtnCopyAll.Text = "Copy All"
        Me.BtnCopyAll.UseVisualStyleBackColor = True
        '
        'NudBirthdaysPerTweet
        '
        Me.NudBirthdaysPerTweet.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudBirthdaysPerTweet.ForeColor = System.Drawing.Color.Black
        Me.NudBirthdaysPerTweet.Location = New System.Drawing.Point(692, 9)
        Me.NudBirthdaysPerTweet.Name = "NudBirthdaysPerTweet"
        Me.NudBirthdaysPerTweet.Size = New System.Drawing.Size(56, 24)
        Me.NudBirthdaysPerTweet.TabIndex = 23
        Me.NudBirthdaysPerTweet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(754, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "per Tweet"
        '
        'TxtStats
        '
        Me.TxtStats.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtStats.Location = New System.Drawing.Point(1188, 9)
        Me.TxtStats.Multiline = True
        Me.TxtStats.Name = "TxtStats"
        Me.TxtStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtStats.Size = New System.Drawing.Size(139, 114)
        Me.TxtStats.TabIndex = 26
        '
        'BtnToday
        '
        Me.BtnToday.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToday.Location = New System.Drawing.Point(14, 7)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(75, 30)
        Me.BtnToday.TabIndex = 27
        Me.BtnToday.Text = "Today"
        Me.BtnToday.UseVisualStyleBackColor = True
        '
        'tvBirthday
        '
        Me.tvBirthday.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvBirthday.CheckBoxes = True
        Me.tvBirthday.Location = New System.Drawing.Point(14, 49)
        Me.tvBirthday.Name = "tvBirthday"
        Me.tvBirthday.Size = New System.Drawing.Size(223, 664)
        Me.tvBirthday.TabIndex = 28
        '
        'btnSelect
        '
        Me.btnSelect.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSelect.Location = New System.Drawing.Point(280, 67)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(139, 33)
        Me.btnSelect.TabIndex = 29
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.cmbTwitterUsers)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.chkImages)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(1183, 269)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 437)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tweet Options"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.rbImageCentre)
        Me.GroupBox4.Controls.Add(Me.rbImageRight)
        Me.GroupBox4.Controls.Add(Me.rbImageLeft)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 332)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(139, 94)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        '
        'rbImageCentre
        '
        Me.rbImageCentre.AutoSize = True
        Me.rbImageCentre.Checked = True
        Me.rbImageCentre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImageCentre.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbImageCentre.Location = New System.Drawing.Point(23, 66)
        Me.rbImageCentre.Name = "rbImageCentre"
        Me.rbImageCentre.Size = New System.Drawing.Size(88, 17)
        Me.rbImageCentre.TabIndex = 2
        Me.rbImageCentre.TabStop = True
        Me.rbImageCentre.Text = "ImageCentre"
        Me.rbImageCentre.UseVisualStyleBackColor = True
        '
        'rbImageRight
        '
        Me.rbImageRight.AutoSize = True
        Me.rbImageRight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImageRight.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbImageRight.Location = New System.Drawing.Point(23, 41)
        Me.rbImageRight.Name = "rbImageRight"
        Me.rbImageRight.Size = New System.Drawing.Size(83, 17)
        Me.rbImageRight.TabIndex = 1
        Me.rbImageRight.Text = "Image Right"
        Me.rbImageRight.UseVisualStyleBackColor = True
        '
        'rbImageLeft
        '
        Me.rbImageLeft.AutoSize = True
        Me.rbImageLeft.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbImageLeft.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbImageLeft.Location = New System.Drawing.Point(23, 16)
        Me.rbImageLeft.Name = "rbImageLeft"
        Me.rbImageLeft.Size = New System.Drawing.Size(74, 17)
        Me.rbImageLeft.TabIndex = 0
        Me.rbImageLeft.Text = "ImageLeft"
        Me.rbImageLeft.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkAtNextBirthday)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.rbHandles)
        Me.GroupBox3.Controls.Add(Me.rbAges)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 104)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(137, 138)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        '
        'ChkAtNextBirthday
        '
        Me.ChkAtNextBirthday.AutoSize = True
        Me.ChkAtNextBirthday.Checked = True
        Me.ChkAtNextBirthday.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAtNextBirthday.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAtNextBirthday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ChkAtNextBirthday.Location = New System.Drawing.Point(28, 72)
        Me.ChkAtNextBirthday.Name = "ChkAtNextBirthday"
        Me.ChkAtNextBirthday.Size = New System.Drawing.Size(104, 17)
        Me.ChkAtNextBirthday.TabIndex = 37
        Me.ChkAtNextBirthday.Text = "at next birthday"
        Me.ChkAtNextBirthday.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.RadioButton1.Location = New System.Drawing.Point(16, 105)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(54, 18)
        Me.RadioButton1.TabIndex = 36
        Me.RadioButton1.Text = "None"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbHandles
        '
        Me.rbHandles.AutoSize = True
        Me.rbHandles.Checked = True
        Me.rbHandles.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHandles.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbHandles.Location = New System.Drawing.Point(16, 14)
        Me.rbHandles.Name = "rbHandles"
        Me.rbHandles.Size = New System.Drawing.Size(112, 18)
        Me.rbHandles.TabIndex = 34
        Me.rbHandles.TabStop = True
        Me.rbHandles.Text = "Twitter Handles"
        Me.rbHandles.UseVisualStyleBackColor = True
        '
        'rbAges
        '
        Me.rbAges.AutoSize = True
        Me.rbAges.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAges.ForeColor = System.Drawing.Color.RoyalBlue
        Me.rbAges.Location = New System.Drawing.Point(16, 44)
        Me.rbAges.Name = "rbAges"
        Me.rbAges.Size = New System.Drawing.Size(77, 18)
        Me.rbAges.TabIndex = 35
        Me.rbAges.Text = "Age/Year"
        Me.rbAges.UseVisualStyleBackColor = True
        '
        'cmbTwitterUsers
        '
        Me.cmbTwitterUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTwitterUsers.FormattingEnabled = True
        Me.cmbTwitterUsers.Location = New System.Drawing.Point(14, 46)
        Me.cmbTwitterUsers.Name = "cmbTwitterUsers"
        Me.cmbTwitterUsers.Size = New System.Drawing.Size(127, 24)
        Me.cmbTwitterUsers.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(10, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Send As"
        '
        'chkImages
        '
        Me.chkImages.AutoSize = True
        Me.chkImages.Checked = True
        Me.chkImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImages.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkImages.Location = New System.Drawing.Point(24, 75)
        Me.chkImages.Name = "chkImages"
        Me.chkImages.Size = New System.Drawing.Size(109, 18)
        Me.chkImages.TabIndex = 0
        Me.chkImages.Text = "Include Images"
        Me.chkImages.UseVisualStyleBackColor = True
        '
        'rtbTweet
        '
        Me.rtbTweet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbTweet.BackColor = System.Drawing.Color.Black
        Me.rtbTweet.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweet.ForeColor = System.Drawing.Color.White
        Me.rtbTweet.Location = New System.Drawing.Point(243, 305)
        Me.rtbTweet.Name = "rtbTweet"
        Me.rtbTweet.Size = New System.Drawing.Size(222, 447)
        Me.rtbTweet.TabIndex = 31
        Me.rtbTweet.Text = ""
        '
        'BtnReGen
        '
        Me.BtnReGen.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReGen.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnReGen.Location = New System.Drawing.Point(280, 123)
        Me.BtnReGen.Name = "BtnReGen"
        Me.BtnReGen.Size = New System.Drawing.Size(139, 33)
        Me.BtnReGen.TabIndex = 32
        Me.BtnReGen.Text = "ReGenerate"
        Me.BtnReGen.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(1063, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "per Tweet"
        '
        'NudAnnivsPerTweet
        '
        Me.NudAnnivsPerTweet.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudAnnivsPerTweet.ForeColor = System.Drawing.Color.Black
        Me.NudAnnivsPerTweet.Location = New System.Drawing.Point(1001, 10)
        Me.NudAnnivsPerTweet.Name = "NudAnnivsPerTweet"
        Me.NudAnnivsPerTweet.Size = New System.Drawing.Size(56, 24)
        Me.NudAnnivsPerTweet.TabIndex = 33
        Me.NudAnnivsPerTweet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(613, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Birthdays"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(899, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 17)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Anniversaries"
        '
        'BtnTotd
        '
        Me.BtnTotd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTotd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTotd.Location = New System.Drawing.Point(259, 205)
        Me.BtnTotd.Name = "BtnTotd"
        Me.BtnTotd.Size = New System.Drawing.Size(178, 33)
        Me.BtnTotd.TabIndex = 38
        Me.BtnTotd.Text = "Tweet of the Day"
        Me.BtnTotd.UseVisualStyleBackColor = True
        '
        'BtnUncheck
        '
        Me.BtnUncheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnUncheck.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUncheck.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUncheck.Location = New System.Drawing.Point(14, 719)
        Me.BtnUncheck.Name = "BtnUncheck"
        Me.BtnUncheck.Size = New System.Drawing.Size(95, 29)
        Me.BtnUncheck.TabIndex = 39
        Me.BtnUncheck.Text = "Uncheck All"
        Me.BtnUncheck.UseVisualStyleBackColor = True
        '
        'BtnDeleteImages
        '
        Me.BtnDeleteImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDeleteImages.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDeleteImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDeleteImages.Location = New System.Drawing.Point(951, 716)
        Me.BtnDeleteImages.Name = "BtnDeleteImages"
        Me.BtnDeleteImages.Size = New System.Drawing.Size(139, 33)
        Me.BtnDeleteImages.TabIndex = 40
        Me.BtnDeleteImages.Text = "Clear Images"
        Me.BtnDeleteImages.UseVisualStyleBackColor = True
        '
        'BtnNext
        '
        Me.BtnNext.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnNext.Location = New System.Drawing.Point(452, 7)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(75, 30)
        Me.BtnNext.TabIndex = 41
        Me.BtnNext.Text = "Next"
        Me.BtnNext.UseVisualStyleBackColor = True
        '
        'BtnExplorer
        '
        Me.BtnExplorer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnExplorer.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExplorer.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnExplorer.Location = New System.Drawing.Point(501, 716)
        Me.BtnExplorer.Name = "BtnExplorer"
        Me.BtnExplorer.Size = New System.Drawing.Size(139, 33)
        Me.BtnExplorer.TabIndex = 42
        Me.BtnExplorer.Text = "Open Explorer"
        Me.BtnExplorer.UseVisualStyleBackColor = True
        '
        'BtnTweetDeck
        '
        Me.BtnTweetDeck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTweetDeck.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTweetDeck.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTweetDeck.Location = New System.Drawing.Point(656, 716)
        Me.BtnTweetDeck.Name = "BtnTweetDeck"
        Me.BtnTweetDeck.Size = New System.Drawing.Size(155, 33)
        Me.BtnTweetDeck.TabIndex = 43
        Me.BtnTweetDeck.Text = "Open TweetDeck"
        Me.BtnTweetDeck.UseVisualStyleBackColor = True
        '
        'FrmTweet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1348, 787)
        Me.Controls.Add(Me.BtnTweetDeck)
        Me.Controls.Add(Me.BtnExplorer)
        Me.Controls.Add(Me.BtnNext)
        Me.Controls.Add(Me.BtnDeleteImages)
        Me.Controls.Add(Me.BtnUncheck)
        Me.Controls.Add(Me.BtnTotd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.NudAnnivsPerTweet)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnReGen)
        Me.Controls.Add(Me.rtbTweet)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.tvBirthday)
        Me.Controls.Add(Me.BtnToday)
        Me.Controls.Add(Me.TxtStats)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NudBirthdaysPerTweet)
        Me.Controls.Add(Me.BtnCopyAll)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BtnCopyselected)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.LblImageCount)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1364, 709)
        Me.Name = "FrmTweet"
        Me.Text = "Daily Tweets"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.NudBirthdaysPerTweet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NudAnnivsPerTweet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents BtnSaveImage As Button
    Friend WithEvents LblImageCount As Label
    Friend WithEvents NudPic1Horizontal As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbSplitImages As RadioButton
    Friend WithEvents RbSingleImage As RadioButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents rtbFile1 As RichTextBox
    Friend WithEvents BtnCopyselected As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnCopyAll As Button
    Friend WithEvents CopyAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NudBirthdaysPerTweet As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtStats As TextBox
    Friend WithEvents BtnToday As Button
    Friend WithEvents tvBirthday As TreeView
    Friend WithEvents btnSelect As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkImages As CheckBox
    Friend WithEvents cmbTwitterUsers As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnSend As Button
    Friend WithEvents rtbTweet As RichTextBox
    Friend WithEvents rbAges As RadioButton
    Friend WithEvents rbHandles As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents BtnReGen As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NudAnnivsPerTweet As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnTotd As Button
    Friend WithEvents BtnUncheck As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbImageRight As RadioButton
    Friend WithEvents rbImageLeft As RadioButton
    Friend WithEvents rbImageCentre As RadioButton
    Friend WithEvents BtnDeleteImages As Button
    Friend WithEvents BtnNext As Button
    Friend WithEvents BtnExplorer As Button
    Friend WithEvents BtnTweetDeck As Button
    Friend WithEvents ChkAtNextBirthday As CheckBox
End Class

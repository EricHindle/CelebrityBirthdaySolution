﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImageEdit
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImageEdit))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnRotate = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnLoadImage = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.PicCapture = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PreviewPictureBox = New System.Windows.Forms.PictureBox()
        Me.lblCroppedImage = New System.Windows.Forms.Label()
        Me.BtnSaveCroppedImage = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TbBrightness = New System.Windows.Forms.TrackBar()
        Me.btnReset = New System.Windows.Forms.Label()
        Me.TbContrast = New System.Windows.Forms.TrackBar()
        Me.BtnResetAdjustments = New System.Windows.Forms.Button()
        Me.pnlAdjustImage = New System.Windows.Forms.Panel()
        Me.NudSaveSize = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudPenSize = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbYellow = New System.Windows.Forms.RadioButton()
        Me.rbRed = New System.Windows.Forms.RadioButton()
        Me.rbWhite = New System.Windows.Forms.RadioButton()
        Me.rbBlack = New System.Windows.Forms.RadioButton()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.BtnResize = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PicCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreviewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAdjustImage.SuspendLayout()
        CType(Me.NudSaveSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudPenSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblSize})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(939, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'lblSize
        '
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(0, 17)
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(852, 443)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 34)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnRotate
        '
        Me.BtnRotate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRotate.BackColor = System.Drawing.Color.White
        Me.BtnRotate.Image = Global.CelebrityBirthday.My.Resources.Resources.refresh
        Me.BtnRotate.Location = New System.Drawing.Point(667, 370)
        Me.BtnRotate.Name = "BtnRotate"
        Me.BtnRotate.Size = New System.Drawing.Size(42, 43)
        Me.BtnRotate.TabIndex = 41
        Me.BtnRotate.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.BtnRotate, "Rotate image 90deg")
        Me.BtnRotate.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Location = New System.Drawing.Point(12, 144)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(89, 57)
        Me.BtnClear.TabIndex = 2
        Me.BtnClear.Text = "Clear Image"
        Me.ToolTip1.SetToolTip(Me.BtnClear, "Clear picture box")
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnLoadImage
        '
        Me.BtnLoadImage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLoadImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadImage.Location = New System.Drawing.Point(12, 52)
        Me.BtnLoadImage.Name = "BtnLoadImage"
        Me.BtnLoadImage.Size = New System.Drawing.Size(89, 56)
        Me.BtnLoadImage.TabIndex = 0
        Me.BtnLoadImage.Text = "Load Image"
        Me.ToolTip1.SetToolTip(Me.BtnLoadImage, "Load picture box from file")
        Me.BtnLoadImage.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(12, 239)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(89, 57)
        Me.BtnSave.TabIndex = 45
        Me.BtnSave.Text = "Save Image"
        Me.ToolTip1.SetToolTip(Me.BtnSave, "Save image from picture box")
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'PicCapture
        '
        Me.PicCapture.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PicCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicCapture.Location = New System.Drawing.Point(136, 73)
        Me.PicCapture.Name = "PicCapture"
        Me.PicCapture.Size = New System.Drawing.Size(500, 400)
        Me.PicCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicCapture.TabIndex = 21
        Me.PicCapture.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 27)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Raw Image"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'PreviewPictureBox
        '
        Me.PreviewPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PreviewPictureBox.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PreviewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PreviewPictureBox.Location = New System.Drawing.Point(810, 40)
        Me.PreviewPictureBox.Name = "PreviewPictureBox"
        Me.PreviewPictureBox.Size = New System.Drawing.Size(60, 60)
        Me.PreviewPictureBox.TabIndex = 29
        Me.PreviewPictureBox.TabStop = False
        '
        'lblCroppedImage
        '
        Me.lblCroppedImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCroppedImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCroppedImage.Location = New System.Drawing.Point(770, 9)
        Me.lblCroppedImage.Name = "lblCroppedImage"
        Me.lblCroppedImage.Size = New System.Drawing.Size(140, 27)
        Me.lblCroppedImage.TabIndex = 10
        Me.lblCroppedImage.Text = "Cropped Image"
        Me.lblCroppedImage.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'BtnSaveCroppedImage
        '
        Me.BtnSaveCroppedImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveCroppedImage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSaveCroppedImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveCroppedImage.Location = New System.Drawing.Point(765, 216)
        Me.BtnSaveCroppedImage.Name = "BtnSaveCroppedImage"
        Me.BtnSaveCroppedImage.Size = New System.Drawing.Size(162, 32)
        Me.BtnSaveCroppedImage.TabIndex = 5
        Me.BtnSaveCroppedImage.Text = "Save Cropped Image"
        Me.BtnSaveCroppedImage.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 328)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 57)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Image import:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Max width 1000" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Max height 700"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Location = New System.Drawing.Point(295, 14)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(19, 16)
        Me.lblFilename.TabIndex = 31
        Me.lblFilename.Text = "..."
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(747, 372)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 41)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Click and drag on the image to select the area to crop"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 14)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Brightness"
        '
        'TbBrightness
        '
        Me.TbBrightness.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbBrightness.AutoSize = False
        Me.TbBrightness.LargeChange = 2
        Me.TbBrightness.Location = New System.Drawing.Point(2, 92)
        Me.TbBrightness.Maximum = 30
        Me.TbBrightness.Minimum = 10
        Me.TbBrightness.Name = "TbBrightness"
        Me.TbBrightness.Size = New System.Drawing.Size(91, 27)
        Me.TbBrightness.TabIndex = 35
        Me.TbBrightness.TickFrequency = 2
        Me.TbBrightness.Value = 20
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.AutoSize = True
        Me.btnReset.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(17, 10)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(53, 14)
        Me.btnReset.TabIndex = 38
        Me.btnReset.Text = "Contrast"
        '
        'TbContrast
        '
        Me.TbContrast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TbContrast.AutoSize = False
        Me.TbContrast.LargeChange = 3
        Me.TbContrast.Location = New System.Drawing.Point(2, 32)
        Me.TbContrast.Maximum = 28
        Me.TbContrast.Minimum = 1
        Me.TbContrast.Name = "TbContrast"
        Me.TbContrast.Size = New System.Drawing.Size(91, 27)
        Me.TbContrast.TabIndex = 37
        Me.TbContrast.TickFrequency = 3
        Me.TbContrast.Value = 10
        '
        'BtnResetAdjustments
        '
        Me.BtnResetAdjustments.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResetAdjustments.Location = New System.Drawing.Point(12, 136)
        Me.BtnResetAdjustments.Name = "BtnResetAdjustments"
        Me.BtnResetAdjustments.Size = New System.Drawing.Size(75, 32)
        Me.BtnResetAdjustments.TabIndex = 39
        Me.BtnResetAdjustments.Text = "Reset"
        Me.BtnResetAdjustments.UseVisualStyleBackColor = True
        '
        'pnlAdjustImage
        '
        Me.pnlAdjustImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAdjustImage.BackColor = System.Drawing.Color.GhostWhite
        Me.pnlAdjustImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAdjustImage.Controls.Add(Me.btnReset)
        Me.pnlAdjustImage.Controls.Add(Me.BtnResetAdjustments)
        Me.pnlAdjustImage.Controls.Add(Me.TbBrightness)
        Me.pnlAdjustImage.Controls.Add(Me.Label6)
        Me.pnlAdjustImage.Controls.Add(Me.TbContrast)
        Me.pnlAdjustImage.Location = New System.Drawing.Point(650, 39)
        Me.pnlAdjustImage.Name = "pnlAdjustImage"
        Me.pnlAdjustImage.Size = New System.Drawing.Size(100, 180)
        Me.pnlAdjustImage.TabIndex = 40
        '
        'NudSaveSize
        '
        Me.NudSaveSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NudSaveSize.Location = New System.Drawing.Point(838, 175)
        Me.NudSaveSize.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.NudSaveSize.Minimum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.NudSaveSize.Name = "NudSaveSize"
        Me.NudSaveSize.Size = New System.Drawing.Size(58, 23)
        Me.NudSaveSize.TabIndex = 42
        Me.NudSaveSize.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(761, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Save size"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.nudPenSize)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.rbYellow)
        Me.GroupBox1.Controls.Add(Me.rbRed)
        Me.GroupBox1.Controls.Add(Me.rbWhite)
        Me.GroupBox1.Controls.Add(Me.rbBlack)
        Me.GroupBox1.Location = New System.Drawing.Point(775, 254)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(143, 115)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pen"
        '
        'nudPenSize
        '
        Me.nudPenSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudPenSize.Location = New System.Drawing.Point(77, 77)
        Me.nudPenSize.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudPenSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudPenSize.Name = "nudPenSize"
        Me.nudPenSize.Size = New System.Drawing.Size(35, 23)
        Me.nudPenSize.TabIndex = 45
        Me.nudPenSize.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 14)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Pen size"
        '
        'rbYellow
        '
        Me.rbYellow.AutoSize = True
        Me.rbYellow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbYellow.Location = New System.Drawing.Point(71, 48)
        Me.rbYellow.Name = "rbYellow"
        Me.rbYellow.Size = New System.Drawing.Size(61, 18)
        Me.rbYellow.TabIndex = 3
        Me.rbYellow.Text = "Yellow"
        Me.rbYellow.UseVisualStyleBackColor = True
        '
        'rbRed
        '
        Me.rbRed.AutoSize = True
        Me.rbRed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRed.Location = New System.Drawing.Point(71, 22)
        Me.rbRed.Name = "rbRed"
        Me.rbRed.Size = New System.Drawing.Size(46, 18)
        Me.rbRed.TabIndex = 2
        Me.rbRed.Text = "Red"
        Me.rbRed.UseVisualStyleBackColor = True
        '
        'rbWhite
        '
        Me.rbWhite.AutoSize = True
        Me.rbWhite.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbWhite.Location = New System.Drawing.Point(8, 48)
        Me.rbWhite.Name = "rbWhite"
        Me.rbWhite.Size = New System.Drawing.Size(58, 18)
        Me.rbWhite.TabIndex = 1
        Me.rbWhite.Text = "White"
        Me.rbWhite.UseVisualStyleBackColor = True
        '
        'rbBlack
        '
        Me.rbBlack.AutoSize = True
        Me.rbBlack.Checked = True
        Me.rbBlack.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBlack.Location = New System.Drawing.Point(8, 22)
        Me.rbBlack.Name = "rbBlack"
        Me.rbBlack.Size = New System.Drawing.Size(52, 18)
        Me.rbBlack.TabIndex = 0
        Me.rbBlack.TabStop = True
        Me.rbBlack.Text = "Black"
        Me.rbBlack.UseVisualStyleBackColor = True
        '
        'TxtSurname
        '
        Me.TxtSurname.Location = New System.Drawing.Point(326, 44)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(184, 23)
        Me.TxtSurname.TabIndex = 81
        '
        'TxtForename
        '
        Me.TxtForename.Location = New System.Drawing.Point(136, 44)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(184, 23)
        Me.TxtForename.TabIndex = 80
        '
        'BtnResize
        '
        Me.BtnResize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnResize.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResize.Location = New System.Drawing.Point(902, 174)
        Me.BtnResize.Name = "BtnResize"
        Me.BtnResize.Size = New System.Drawing.Size(25, 23)
        Me.BtnResize.TabIndex = 82
        Me.BtnResize.Text = "*"
        Me.BtnResize.UseVisualStyleBackColor = True
        '
        'FrmImageEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(939, 504)
        Me.Controls.Add(Me.BtnResize)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NudSaveSize)
        Me.Controls.Add(Me.BtnRotate)
        Me.Controls.Add(Me.pnlAdjustImage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnSaveCroppedImage)
        Me.Controls.Add(Me.BtnLoadImage)
        Me.Controls.Add(Me.lblCroppedImage)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.PreviewPictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PicCapture)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1900, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(955, 543)
        Me.Name = "FrmImageEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Editing"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PicCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreviewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbContrast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAdjustImage.ResumeLayout(False)
        Me.pnlAdjustImage.PerformLayout()
        CType(Me.NudSaveSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudPenSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PicCapture As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PreviewPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents lblCroppedImage As System.Windows.Forms.Label
    Friend WithEvents BtnLoadImage As System.Windows.Forms.Button
    Friend WithEvents BtnSaveCroppedImage As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TbBrightness As System.Windows.Forms.TrackBar
    Friend WithEvents btnReset As System.Windows.Forms.Label
    Friend WithEvents TbContrast As System.Windows.Forms.TrackBar
    Friend WithEvents BtnResetAdjustments As System.Windows.Forms.Button
    Friend WithEvents pnlAdjustImage As System.Windows.Forms.Panel
    Friend WithEvents BtnRotate As System.Windows.Forms.Button
    Friend WithEvents NudSaveSize As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbYellow As RadioButton
    Friend WithEvents rbRed As RadioButton
    Friend WithEvents rbWhite As RadioButton
    Friend WithEvents rbBlack As RadioButton
    Friend WithEvents BtnSave As Button
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents nudPenSize As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents BtnResize As Button
    Friend WithEvents lblSize As ToolStripStatusLabel
End Class

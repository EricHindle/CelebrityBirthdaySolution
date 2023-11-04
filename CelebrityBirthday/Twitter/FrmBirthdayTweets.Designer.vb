' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBirthdayTweets
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBirthdayTweets))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.CbParams = New System.Windows.Forms.ComboBox()
        Me.CbTweetType = New System.Windows.Forms.ComboBox()
        Me.CbUserType = New System.Windows.Forms.ComboBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.ChkOncePerDay = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CbTwitterUsers = New System.Windows.Forms.ComboBox()
        Me.ChkCurrentDay = New System.Windows.Forms.CheckBox()
        Me.CbDay = New System.Windows.Forms.ComboBox()
        Me.CbMonth = New System.Windows.Forms.ComboBox()
        Me.ChkImages = New System.Windows.Forms.CheckBox()
        Me.ChkHandles = New System.Windows.Forms.CheckBox()
        Me.ChkAge = New System.Windows.Forms.CheckBox()
        Me.ChkMultiImage = New System.Windows.Forms.CheckBox()
        Me.ChkNextBirthday = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbRight = New System.Windows.Forms.RadioButton()
        Me.RbCentre = New System.Windows.Forms.RadioButton()
        Me.RbLeft = New System.Windows.Forms.RadioButton()
        Me.NudPicHorizontal = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GrpImages = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NudAnnivsPerTweet = New System.Windows.Forms.NumericUpDown()
        Me.NudBirthdaysPerTweet = New System.Windows.Forms.NumericUpDown()
        Me.BtnRun = New System.Windows.Forms.Button()
        Me.BtnStore = New System.Windows.Forms.Button()
        Me.ChkAuto = New System.Windows.Forms.CheckBox()
        Me.GrpManual = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NudPicHorizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpImages.SuspendLayout()
        CType(Me.NudAnnivsPerTweet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudBirthdaysPerTweet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpManual.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 425)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(645, 22)
        Me.StatusStrip1.TabIndex = 17
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
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(530, 383)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(102, 38)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'CbParams
        '
        Me.CbParams.FormattingEnabled = True
        Me.CbParams.Location = New System.Drawing.Point(73, 12)
        Me.CbParams.Name = "CbParams"
        Me.CbParams.Size = New System.Drawing.Size(536, 26)
        Me.CbParams.TabIndex = 0
        '
        'CbTweetType
        '
        Me.CbTweetType.FormattingEnabled = True
        Me.CbTweetType.Location = New System.Drawing.Point(136, 84)
        Me.CbTweetType.Name = "CbTweetType"
        Me.CbTweetType.Size = New System.Drawing.Size(146, 26)
        Me.CbTweetType.TabIndex = 1
        '
        'CbUserType
        '
        Me.CbUserType.FormattingEnabled = True
        Me.CbUserType.Location = New System.Drawing.Point(310, 84)
        Me.CbUserType.Name = "CbUserType"
        Me.CbUserType.Size = New System.Drawing.Size(150, 26)
        Me.CbUserType.TabIndex = 2
        '
        'BtnClear
        '
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClear.Location = New System.Drawing.Point(13, 78)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(66, 37)
        Me.BtnClear.TabIndex = 7
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(133, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Tweet Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(307, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 18)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Twitter User Type"
        '
        'BtnAdd
        '
        Me.BtnAdd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAdd.Location = New System.Drawing.Point(13, 153)
        Me.BtnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(66, 37)
        Me.BtnAdd.TabIndex = 8
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate.Location = New System.Drawing.Point(13, 211)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(66, 37)
        Me.BtnUpdate.TabIndex = 9
        Me.BtnUpdate.Text = "Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDelete.Location = New System.Drawing.Point(13, 269)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(66, 37)
        Me.BtnDelete.TabIndex = 10
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'ChkOncePerDay
        '
        Me.ChkOncePerDay.AutoSize = True
        Me.ChkOncePerDay.Location = New System.Drawing.Point(6, 49)
        Me.ChkOncePerDay.Name = "ChkOncePerDay"
        Me.ChkOncePerDay.Size = New System.Drawing.Size(173, 22)
        Me.ChkOncePerDay.TabIndex = 3
        Me.ChkOncePerDay.Text = "Only run once per day"
        Me.ChkOncePerDay.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(482, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 18)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Run As"
        '
        'CbTwitterUsers
        '
        Me.CbTwitterUsers.FormattingEnabled = True
        Me.CbTwitterUsers.Location = New System.Drawing.Point(485, 84)
        Me.CbTwitterUsers.Name = "CbTwitterUsers"
        Me.CbTwitterUsers.Size = New System.Drawing.Size(141, 26)
        Me.CbTwitterUsers.TabIndex = 3
        '
        'ChkCurrentDay
        '
        Me.ChkCurrentDay.AutoSize = True
        Me.ChkCurrentDay.Location = New System.Drawing.Point(6, 15)
        Me.ChkCurrentDay.Name = "ChkCurrentDay"
        Me.ChkCurrentDay.Size = New System.Drawing.Size(182, 22)
        Me.ChkCurrentDay.TabIndex = 0
        Me.ChkCurrentDay.Text = "Tweets for Current Day"
        Me.ChkCurrentDay.UseVisualStyleBackColor = True
        '
        'CbDay
        '
        Me.CbDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbDay.FormattingEnabled = True
        Me.CbDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.CbDay.Location = New System.Drawing.Point(229, 12)
        Me.CbDay.Name = "CbDay"
        Me.CbDay.Size = New System.Drawing.Size(57, 27)
        Me.CbDay.TabIndex = 1
        '
        'CbMonth
        '
        Me.CbMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbMonth.FormattingEnabled = True
        Me.CbMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.CbMonth.Location = New System.Drawing.Point(294, 12)
        Me.CbMonth.Name = "CbMonth"
        Me.CbMonth.Size = New System.Drawing.Size(192, 27)
        Me.CbMonth.TabIndex = 2
        '
        'ChkImages
        '
        Me.ChkImages.AutoSize = True
        Me.ChkImages.Location = New System.Drawing.Point(6, 26)
        Me.ChkImages.Name = "ChkImages"
        Me.ChkImages.Size = New System.Drawing.Size(116, 22)
        Me.ChkImages.TabIndex = 0
        Me.ChkImages.Text = "Show Images"
        Me.ChkImages.UseVisualStyleBackColor = True
        '
        'ChkHandles
        '
        Me.ChkHandles.AutoSize = True
        Me.ChkHandles.Location = New System.Drawing.Point(6, 88)
        Me.ChkHandles.Name = "ChkHandles"
        Me.ChkHandles.Size = New System.Drawing.Size(117, 22)
        Me.ChkHandles.TabIndex = 4
        Me.ChkHandles.Text = "Show Handles"
        Me.ChkHandles.UseVisualStyleBackColor = True
        '
        'ChkAge
        '
        Me.ChkAge.AutoSize = True
        Me.ChkAge.Location = New System.Drawing.Point(157, 88)
        Me.ChkAge.Name = "ChkAge"
        Me.ChkAge.Size = New System.Drawing.Size(91, 22)
        Me.ChkAge.TabIndex = 5
        Me.ChkAge.Text = "Show Age"
        Me.ChkAge.UseVisualStyleBackColor = True
        '
        'ChkMultiImage
        '
        Me.ChkMultiImage.AutoSize = True
        Me.ChkMultiImage.Location = New System.Drawing.Point(6, 59)
        Me.ChkMultiImage.Name = "ChkMultiImage"
        Me.ChkMultiImage.Size = New System.Drawing.Size(99, 22)
        Me.ChkMultiImage.TabIndex = 2
        Me.ChkMultiImage.Text = "MultiImage"
        Me.ChkMultiImage.UseVisualStyleBackColor = True
        '
        'ChkNextBirthday
        '
        Me.ChkNextBirthday.AutoSize = True
        Me.ChkNextBirthday.Location = New System.Drawing.Point(282, 88)
        Me.ChkNextBirthday.Name = "ChkNextBirthday"
        Me.ChkNextBirthday.Size = New System.Drawing.Size(164, 22)
        Me.ChkNextBirthday.TabIndex = 6
        Me.ChkNextBirthday.Text = "Age at Next Birthday"
        Me.ChkNextBirthday.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbRight)
        Me.GroupBox1.Controls.Add(Me.RbCentre)
        Me.GroupBox1.Controls.Add(Me.RbLeft)
        Me.GroupBox1.Location = New System.Drawing.Point(128, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(214, 39)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'RbRight
        '
        Me.RbRight.AutoSize = True
        Me.RbRight.Location = New System.Drawing.Point(150, 13)
        Me.RbRight.Name = "RbRight"
        Me.RbRight.Size = New System.Drawing.Size(58, 22)
        Me.RbRight.TabIndex = 2
        Me.RbRight.TabStop = True
        Me.RbRight.Text = "Right"
        Me.RbRight.UseVisualStyleBackColor = True
        '
        'RbCentre
        '
        Me.RbCentre.AutoSize = True
        Me.RbCentre.Location = New System.Drawing.Point(69, 13)
        Me.RbCentre.Name = "RbCentre"
        Me.RbCentre.Size = New System.Drawing.Size(69, 22)
        Me.RbCentre.TabIndex = 1
        Me.RbCentre.TabStop = True
        Me.RbCentre.Text = "Centre"
        Me.RbCentre.UseVisualStyleBackColor = True
        '
        'RbLeft
        '
        Me.RbLeft.AutoSize = True
        Me.RbLeft.Location = New System.Drawing.Point(6, 13)
        Me.RbLeft.Name = "RbLeft"
        Me.RbLeft.Size = New System.Drawing.Size(51, 22)
        Me.RbLeft.TabIndex = 0
        Me.RbLeft.TabStop = True
        Me.RbLeft.Text = "Left"
        Me.RbLeft.UseVisualStyleBackColor = True
        '
        'NudPicHorizontal
        '
        Me.NudPicHorizontal.ForeColor = System.Drawing.Color.RoyalBlue
        Me.NudPicHorizontal.Location = New System.Drawing.Point(176, 58)
        Me.NudPicHorizontal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudPicHorizontal.Name = "NudPicHorizontal"
        Me.NudPicHorizontal.Size = New System.Drawing.Size(53, 25)
        Me.NudPicHorizontal.TabIndex = 3
        Me.NudPicHorizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudPicHorizontal.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(125, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 18)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Width"
        '
        'GrpImages
        '
        Me.GrpImages.Controls.Add(Me.NudPicHorizontal)
        Me.GrpImages.Controls.Add(Me.GroupBox1)
        Me.GrpImages.Controls.Add(Me.ChkMultiImage)
        Me.GrpImages.Controls.Add(Me.Label4)
        Me.GrpImages.Controls.Add(Me.ChkImages)
        Me.GrpImages.Location = New System.Drawing.Point(134, 313)
        Me.GrpImages.Name = "GrpImages"
        Me.GrpImages.Size = New System.Drawing.Size(362, 87)
        Me.GrpImages.TabIndex = 6
        Me.GrpImages.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(278, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 18)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Anniversaries per Tweet"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(59, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 18)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Birthdays per Tweet"
        '
        'NudAnnivsPerTweet
        '
        Me.NudAnnivsPerTweet.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudAnnivsPerTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.NudAnnivsPerTweet.Location = New System.Drawing.Point(229, 132)
        Me.NudAnnivsPerTweet.Name = "NudAnnivsPerTweet"
        Me.NudAnnivsPerTweet.Size = New System.Drawing.Size(43, 25)
        Me.NudAnnivsPerTweet.TabIndex = 8
        Me.NudAnnivsPerTweet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'NudBirthdaysPerTweet
        '
        Me.NudBirthdaysPerTweet.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NudBirthdaysPerTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.NudBirthdaysPerTweet.Location = New System.Drawing.Point(6, 132)
        Me.NudBirthdaysPerTweet.Name = "NudBirthdaysPerTweet"
        Me.NudBirthdaysPerTweet.Size = New System.Drawing.Size(44, 25)
        Me.NudBirthdaysPerTweet.TabIndex = 7
        Me.NudBirthdaysPerTweet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnRun
        '
        Me.BtnRun.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRun.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRun.Location = New System.Drawing.Point(554, 313)
        Me.BtnRun.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnRun.Name = "BtnRun"
        Me.BtnRun.Size = New System.Drawing.Size(66, 66)
        Me.BtnRun.TabIndex = 12
        Me.BtnRun.Text = "RUN"
        Me.BtnRun.UseVisualStyleBackColor = True
        '
        'BtnStore
        '
        Me.BtnStore.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStore.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnStore.Location = New System.Drawing.Point(13, 327)
        Me.BtnStore.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnStore.Name = "BtnStore"
        Me.BtnStore.Size = New System.Drawing.Size(66, 37)
        Me.BtnStore.TabIndex = 11
        Me.BtnStore.Text = "Store"
        Me.BtnStore.UseVisualStyleBackColor = True
        '
        'ChkAuto
        '
        Me.ChkAuto.AutoSize = True
        Me.ChkAuto.Location = New System.Drawing.Point(137, 122)
        Me.ChkAuto.Name = "ChkAuto"
        Me.ChkAuto.Size = New System.Drawing.Size(57, 22)
        Me.ChkAuto.TabIndex = 4
        Me.ChkAuto.Text = "Auto"
        Me.ChkAuto.UseVisualStyleBackColor = True
        '
        'GrpManual
        '
        Me.GrpManual.Controls.Add(Me.ChkCurrentDay)
        Me.GrpManual.Controls.Add(Me.ChkOncePerDay)
        Me.GrpManual.Controls.Add(Me.CbMonth)
        Me.GrpManual.Controls.Add(Me.CbDay)
        Me.GrpManual.Controls.Add(Me.Label6)
        Me.GrpManual.Controls.Add(Me.ChkHandles)
        Me.GrpManual.Controls.Add(Me.Label5)
        Me.GrpManual.Controls.Add(Me.ChkAge)
        Me.GrpManual.Controls.Add(Me.NudAnnivsPerTweet)
        Me.GrpManual.Controls.Add(Me.ChkNextBirthday)
        Me.GrpManual.Controls.Add(Me.NudBirthdaysPerTweet)
        Me.GrpManual.Location = New System.Drawing.Point(134, 146)
        Me.GrpManual.Name = "GrpManual"
        Me.GrpManual.Size = New System.Drawing.Size(492, 161)
        Me.GrpManual.TabIndex = 5
        Me.GrpManual.TabStop = False
        '
        'FrmBirthdayTweets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 447)
        Me.Controls.Add(Me.GrpManual)
        Me.Controls.Add(Me.ChkAuto)
        Me.Controls.Add(Me.BtnStore)
        Me.Controls.Add(Me.BtnRun)
        Me.Controls.Add(Me.GrpImages)
        Me.Controls.Add(Me.CbTwitterUsers)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.CbUserType)
        Me.Controls.Add(Me.CbTweetType)
        Me.Controls.Add(Me.CbParams)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmBirthdayTweets"
        Me.Text = "Run Birthday Tweets"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NudPicHorizontal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpImages.ResumeLayout(False)
        Me.GrpImages.PerformLayout()
        CType(Me.NudAnnivsPerTweet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudBirthdaysPerTweet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpManual.ResumeLayout(False)
        Me.GrpManual.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents btnClose As Button
    Friend WithEvents CbParams As ComboBox
    Friend WithEvents CbTweetType As ComboBox
    Friend WithEvents CbUserType As ComboBox
    Friend WithEvents BtnClear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnAdd As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents ChkOncePerDay As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CbTwitterUsers As ComboBox
    Friend WithEvents ChkCurrentDay As CheckBox
    Friend WithEvents CbDay As ComboBox
    Friend WithEvents CbMonth As ComboBox
    Friend WithEvents ChkImages As CheckBox
    Friend WithEvents ChkHandles As CheckBox
    Friend WithEvents ChkAge As CheckBox
    Friend WithEvents ChkMultiImage As CheckBox
    Friend WithEvents ChkNextBirthday As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbRight As RadioButton
    Friend WithEvents RbCentre As RadioButton
    Friend WithEvents RbLeft As RadioButton
    Friend WithEvents NudPicHorizontal As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents GrpImages As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NudAnnivsPerTweet As NumericUpDown
    Friend WithEvents NudBirthdaysPerTweet As NumericUpDown
    Friend WithEvents BtnRun As Button
    Friend WithEvents BtnStore As Button
    Friend WithEvents ChkAuto As CheckBox
    Friend WithEvents GrpManual As GroupBox
End Class

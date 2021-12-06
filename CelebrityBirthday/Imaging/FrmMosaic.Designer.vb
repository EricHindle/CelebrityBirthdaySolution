<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMosaic
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMosaic))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NudWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NudHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.lblImgCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnRegen = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblImgShown = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudSkip = New System.Windows.Forms.NumericUpDown()
        Me.chkBotSD = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboDay = New System.Windows.Forms.ComboBox()
        Me.BtnToday = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSkip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 697)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1276, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblStatus.Size = New System.Drawing.Size(6, 17)
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(1177, 654)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(87, 40)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1252, 592)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'NudWidth
        '
        Me.NudWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudWidth.Location = New System.Drawing.Point(226, 665)
        Me.NudWidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NudWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudWidth.Name = "NudWidth"
        Me.NudWidth.Size = New System.Drawing.Size(68, 22)
        Me.NudWidth.TabIndex = 3
        Me.NudWidth.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(180, 669)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Width"
        '
        'NudHeight
        '
        Me.NudHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudHeight.Location = New System.Drawing.Point(349, 665)
        Me.NudHeight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NudHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudHeight.Name = "NudHeight"
        Me.NudHeight.Size = New System.Drawing.Size(68, 22)
        Me.NudHeight.TabIndex = 5
        Me.NudHeight.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(300, 669)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Height"
        '
        'cboMonth
        '
        Me.cboMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(226, 628)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(161, 27)
        Me.cboMonth.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(178, 635)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Month"
        '
        'BtnSelect
        '
        Me.BtnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSelect.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSelect.Location = New System.Drawing.Point(757, 623)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(87, 40)
        Me.BtnSelect.TabIndex = 1
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveImage.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSaveImage.Location = New System.Drawing.Point(1032, 627)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(139, 33)
        Me.BtnSaveImage.TabIndex = 9
        Me.BtnSaveImage.Text = "Save Image"
        Me.BtnSaveImage.UseVisualStyleBackColor = True
        '
        'lblImgCount
        '
        Me.lblImgCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblImgCount.AutoSize = True
        Me.lblImgCount.Location = New System.Drawing.Point(21, 616)
        Me.lblImgCount.Name = "lblImgCount"
        Me.lblImgCount.Size = New System.Drawing.Size(14, 14)
        Me.lblImgCount.TabIndex = 10
        Me.lblImgCount.Text = "0"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(21, 635)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "images selected"
        '
        'BtnRegen
        '
        Me.BtnRegen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRegen.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRegen.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRegen.Location = New System.Drawing.Point(863, 623)
        Me.BtnRegen.Name = "BtnRegen"
        Me.BtnRegen.Size = New System.Drawing.Size(135, 40)
        Me.BtnRegen.TabIndex = 12
        Me.BtnRegen.Text = "Regenerate Image"
        Me.BtnRegen.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(21, 680)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 14)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "images shown"
        '
        'LblImgShown
        '
        Me.LblImgShown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblImgShown.AutoSize = True
        Me.LblImgShown.Location = New System.Drawing.Point(21, 661)
        Me.LblImgShown.Name = "LblImgShown"
        Me.LblImgShown.Size = New System.Drawing.Size(14, 14)
        Me.LblImgShown.TabIndex = 13
        Me.LblImgShown.Text = "0"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(439, 669)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 14)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Skip Rows"
        '
        'nudSkip
        '
        Me.nudSkip.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudSkip.Location = New System.Drawing.Point(507, 665)
        Me.nudSkip.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nudSkip.Name = "nudSkip"
        Me.nudSkip.Size = New System.Drawing.Size(68, 22)
        Me.nudSkip.TabIndex = 15
        '
        'chkBotSD
        '
        Me.chkBotSD.AutoSize = True
        Me.chkBotSD.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkBotSD.Location = New System.Drawing.Point(525, 635)
        Me.chkBotSD.Name = "chkBotSD"
        Me.chkBotSD.Size = New System.Drawing.Size(86, 18)
        Me.chkBotSD.TabIndex = 17
        Me.chkBotSD.Text = "BotSD only"
        Me.chkBotSD.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label7.Location = New System.Drawing.Point(407, 635)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 14)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Day"
        '
        'CboDay
        '
        Me.CboDay.FormattingEnabled = True
        Me.CboDay.Items.AddRange(New Object() {"All", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.CboDay.Location = New System.Drawing.Point(440, 632)
        Me.CboDay.Name = "CboDay"
        Me.CboDay.Size = New System.Drawing.Size(61, 22)
        Me.CboDay.TabIndex = 19
        '
        'BtnToday
        '
        Me.BtnToday.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnToday.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnToday.Location = New System.Drawing.Point(633, 627)
        Me.BtnToday.Name = "BtnToday"
        Me.BtnToday.Size = New System.Drawing.Size(75, 30)
        Me.BtnToday.TabIndex = 28
        Me.BtnToday.Text = "Today"
        Me.BtnToday.UseVisualStyleBackColor = True
        '
        'FrmMosaic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1276, 719)
        Me.Controls.Add(Me.BtnToday)
        Me.Controls.Add(Me.CboDay)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkBotSD)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudSkip)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblImgShown)
        Me.Controls.Add(Me.BtnRegen)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblImgCount)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NudHeight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NudWidth)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmMosaic"
        Me.Text = "Mosaic"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSkip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BtnClose As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NudWidth As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents NudHeight As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnSelect As Button
    Friend WithEvents BtnSaveImage As Button
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents lblImgCount As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnRegen As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents LblImgShown As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents nudSkip As NumericUpDown
    Friend WithEvents chkBotSD As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CboDay As ComboBox
    Friend WithEvents BtnToday As Button
End Class

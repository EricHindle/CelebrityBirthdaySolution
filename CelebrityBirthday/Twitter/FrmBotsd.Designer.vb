<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.pairId1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pairId2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtForename1 = New System.Windows.Forms.TextBox()
        Me.TxtSurname1 = New System.Windows.Forms.TextBox()
        Me.TxtShortDesc1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnUpdate1 = New System.Windows.Forms.Button()
        Me.LblId1 = New System.Windows.Forms.Label()
        Me.DtpDob1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
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
        Me.StatusStrip1.SuspendLayout()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPairs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbTweet
        '
        Me.rtbTweet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbTweet.BackColor = System.Drawing.Color.Black
        Me.rtbTweet.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweet.ForeColor = System.Drawing.Color.White
        Me.rtbTweet.Location = New System.Drawing.Point(1028, 6)
        Me.rtbTweet.Name = "rtbTweet"
        Me.rtbTweet.Size = New System.Drawing.Size(222, 497)
        Me.rtbTweet.TabIndex = 32
        Me.rtbTweet.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 546)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1262, 22)
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
        Me.btnClose.Location = New System.Drawing.Point(1111, 510)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 34
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnSend
        '
        Me.BtnSend.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(565, 210)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(139, 33)
        Me.BtnSend.TabIndex = 34
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'NudPic1Horizontal
        '
        Me.NudPic1Horizontal.Location = New System.Drawing.Point(373, 99)
        Me.NudPic1Horizontal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudPic1Horizontal.Name = "NudPic1Horizontal"
        Me.NudPic1Horizontal.Size = New System.Drawing.Size(53, 23)
        Me.NudPic1Horizontal.TabIndex = 7
        Me.NudPic1Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudPic1Horizontal.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(370, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Width"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(361, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(360, 60)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'rtbFile1
        '
        Me.rtbFile1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFile1.Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbFile1.Location = New System.Drawing.Point(727, 6)
        Me.rtbFile1.Name = "rtbFile1"
        Me.rtbFile1.Size = New System.Drawing.Size(295, 241)
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
        Me.dgvPairs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pairPerson1, Me.pairPerson2, Me.pairId1, Me.pairId2})
        Me.dgvPairs.Location = New System.Drawing.Point(12, 37)
        Me.dgvPairs.MultiSelect = False
        Me.dgvPairs.Name = "dgvPairs"
        Me.dgvPairs.ReadOnly = True
        Me.dgvPairs.RowHeadersVisible = False
        Me.dgvPairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPairs.Size = New System.Drawing.Size(343, 497)
        Me.dgvPairs.TabIndex = 36
        '
        'pairPerson1
        '
        Me.pairPerson1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson1.HeaderText = "Person1"
        Me.pairPerson1.Name = "pairPerson1"
        Me.pairPerson1.ReadOnly = True
        Me.pairPerson1.Width = 170
        '
        'pairPerson2
        '
        Me.pairPerson2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.pairPerson2.HeaderText = "Person2"
        Me.pairPerson2.Name = "pairPerson2"
        Me.pairPerson2.ReadOnly = True
        Me.pairPerson2.Width = 170
        '
        'pairId1
        '
        Me.pairId1.HeaderText = "Id1"
        Me.pairId1.Name = "pairId1"
        Me.pairId1.ReadOnly = True
        Me.pairId1.Visible = False
        '
        'pairId2
        '
        Me.pairId2.HeaderText = "Id2"
        Me.pairId2.Name = "pairId2"
        Me.pairId2.ReadOnly = True
        Me.pairId2.Visible = False
        '
        'TxtForename1
        '
        Me.TxtForename1.Location = New System.Drawing.Point(6, 23)
        Me.TxtForename1.Name = "TxtForename1"
        Me.TxtForename1.Size = New System.Drawing.Size(259, 23)
        Me.TxtForename1.TabIndex = 37
        '
        'TxtSurname1
        '
        Me.TxtSurname1.Location = New System.Drawing.Point(271, 23)
        Me.TxtSurname1.Name = "TxtSurname1"
        Me.TxtSurname1.Size = New System.Drawing.Size(381, 23)
        Me.TxtSurname1.TabIndex = 38
        '
        'TxtShortDesc1
        '
        Me.TxtShortDesc1.Location = New System.Drawing.Point(6, 52)
        Me.TxtShortDesc1.Name = "TxtShortDesc1"
        Me.TxtShortDesc1.Size = New System.Drawing.Size(646, 23)
        Me.TxtShortDesc1.TabIndex = 39
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnUpdate1)
        Me.GroupBox1.Controls.Add(Me.LblId1)
        Me.GroupBox1.Controls.Add(Me.DtpDob1)
        Me.GroupBox1.Controls.Add(Me.TxtShortDesc1)
        Me.GroupBox1.Controls.Add(Me.TxtForename1)
        Me.GroupBox1.Controls.Add(Me.TxtSurname1)
        Me.GroupBox1.Location = New System.Drawing.Point(364, 253)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(658, 114)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Person 1"
        '
        'BtnUpdate1
        '
        Me.BtnUpdate1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate1.Location = New System.Drawing.Point(491, 81)
        Me.BtnUpdate1.Name = "BtnUpdate1"
        Me.BtnUpdate1.Size = New System.Drawing.Size(139, 27)
        Me.BtnUpdate1.TabIndex = 42
        Me.BtnUpdate1.Text = "Update"
        Me.BtnUpdate1.UseVisualStyleBackColor = True
        '
        'LblId1
        '
        Me.LblId1.AutoSize = True
        Me.LblId1.Location = New System.Drawing.Point(6, 86)
        Me.LblId1.Name = "LblId1"
        Me.LblId1.Size = New System.Drawing.Size(45, 16)
        Me.LblId1.TabIndex = 41
        Me.LblId1.Text = "Label1"
        '
        'DtpDob1
        '
        Me.DtpDob1.Location = New System.Drawing.Point(120, 81)
        Me.DtpDob1.Name = "DtpDob1"
        Me.DtpDob1.Size = New System.Drawing.Size(158, 23)
        Me.DtpDob1.TabIndex = 40
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnUpdate2)
        Me.GroupBox2.Controls.Add(Me.LblId2)
        Me.GroupBox2.Controls.Add(Me.DtpDob2)
        Me.GroupBox2.Controls.Add(Me.TxtShortDesc2)
        Me.GroupBox2.Controls.Add(Me.TxtForename2)
        Me.GroupBox2.Controls.Add(Me.TxtSurname2)
        Me.GroupBox2.Location = New System.Drawing.Point(361, 389)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(658, 114)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Person 2"
        '
        'BtnUpdate2
        '
        Me.BtnUpdate2.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdate2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdate2.Location = New System.Drawing.Point(485, 81)
        Me.BtnUpdate2.Name = "BtnUpdate2"
        Me.BtnUpdate2.Size = New System.Drawing.Size(139, 27)
        Me.BtnUpdate2.TabIndex = 43
        Me.BtnUpdate2.Text = "Update"
        Me.BtnUpdate2.UseVisualStyleBackColor = True
        '
        'LblId2
        '
        Me.LblId2.AutoSize = True
        Me.LblId2.Location = New System.Drawing.Point(6, 86)
        Me.LblId2.Name = "LblId2"
        Me.LblId2.Size = New System.Drawing.Size(45, 16)
        Me.LblId2.TabIndex = 42
        Me.LblId2.Text = "Label3"
        '
        'DtpDob2
        '
        Me.DtpDob2.Location = New System.Drawing.Point(123, 81)
        Me.DtpDob2.Name = "DtpDob2"
        Me.DtpDob2.Size = New System.Drawing.Size(158, 23)
        Me.DtpDob2.TabIndex = 40
        '
        'TxtShortDesc2
        '
        Me.TxtShortDesc2.Location = New System.Drawing.Point(6, 52)
        Me.TxtShortDesc2.Name = "TxtShortDesc2"
        Me.TxtShortDesc2.Size = New System.Drawing.Size(646, 23)
        Me.TxtShortDesc2.TabIndex = 39
        '
        'TxtForename2
        '
        Me.TxtForename2.Location = New System.Drawing.Point(6, 23)
        Me.TxtForename2.Name = "TxtForename2"
        Me.TxtForename2.Size = New System.Drawing.Size(262, 23)
        Me.TxtForename2.TabIndex = 37
        '
        'TxtSurname2
        '
        Me.TxtSurname2.Location = New System.Drawing.Point(274, 22)
        Me.TxtSurname2.Name = "TxtSurname2"
        Me.TxtSurname2.Size = New System.Drawing.Size(378, 23)
        Me.TxtSurname2.TabIndex = 38
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGenerate.Location = New System.Drawing.Point(565, 113)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(139, 33)
        Me.BtnGenerate.TabIndex = 42
        Me.BtnGenerate.Text = "Generate"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'BtnSwap
        '
        Me.BtnSwap.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSwap.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSwap.Location = New System.Drawing.Point(565, 161)
        Me.BtnSwap.Name = "BtnSwap"
        Me.BtnSwap.Size = New System.Drawing.Size(139, 33)
        Me.BtnSwap.TabIndex = 43
        Me.BtnSwap.Text = "Swap"
        Me.BtnSwap.UseVisualStyleBackColor = True
        '
        'cmbTwitterUsers
        '
        Me.cmbTwitterUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTwitterUsers.FormattingEnabled = True
        Me.cmbTwitterUsers.Location = New System.Drawing.Point(373, 170)
        Me.cmbTwitterUsers.Name = "cmbTwitterUsers"
        Me.cmbTwitterUsers.Size = New System.Drawing.Size(127, 24)
        Me.cmbTwitterUsers.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(369, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Send As"
        '
        'chkImages
        '
        Me.chkImages.AutoSize = True
        Me.chkImages.Checked = True
        Me.chkImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImages.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkImages.Location = New System.Drawing.Point(373, 200)
        Me.chkImages.Name = "chkImages"
        Me.chkImages.Size = New System.Drawing.Size(107, 23)
        Me.chkImages.TabIndex = 46
        Me.chkImages.Text = "Include Images"
        Me.chkImages.UseVisualStyleBackColor = True
        '
        'LblDay
        '
        Me.LblDay.AutoSize = True
        Me.LblDay.Font = New System.Drawing.Font("Papyrus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDay.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblDay.Location = New System.Drawing.Point(33, 9)
        Me.LblDay.Name = "LblDay"
        Me.LblDay.Size = New System.Drawing.Size(21, 25)
        Me.LblDay.TabIndex = 47
        Me.LblDay.Text = "1"
        '
        'LblMonth
        '
        Me.LblMonth.AutoSize = True
        Me.LblMonth.Font = New System.Drawing.Font("Papyrus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonth.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblMonth.Location = New System.Drawing.Point(86, 9)
        Me.LblMonth.Name = "LblMonth"
        Me.LblMonth.Size = New System.Drawing.Size(68, 25)
        Me.LblMonth.TabIndex = 48
        Me.LblMonth.Text = "January"
        '
        'FrmBotsd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1262, 568)
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
    Friend WithEvents pairPerson1 As DataGridViewTextBoxColumn
    Friend WithEvents pairPerson2 As DataGridViewTextBoxColumn
    Friend WithEvents pairId1 As DataGridViewTextBoxColumn
    Friend WithEvents pairId2 As DataGridViewTextBoxColumn
End Class

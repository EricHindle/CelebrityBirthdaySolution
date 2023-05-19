<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSingleTweet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            oTweetTa.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSingleTweet))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rtbTweetProgress = New System.Windows.Forms.RichTextBox()
        Me.RtbTweetText = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTwitterUsers = New System.Windows.Forms.ComboBox()
        Me.BtnImage = New System.Windows.Forms.Button()
        Me.BtnCreateFullName = New System.Windows.Forms.Button()
        Me.BtnSplitName = New System.Windows.Forms.Button()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblImageFile = New System.Windows.Forms.Label()
        Me.NudSentences = New System.Windows.Forms.NumericUpDown()
        Me.BtnGetWikiText = New System.Windows.Forms.Button()
        Me.LblImageName = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.chkImages = New System.Windows.Forms.CheckBox()
        Me.LblTweetLength = New System.Windows.Forms.Label()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.BtnClearImages = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(683, 525)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(162, 41)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'rtbTweetProgress
        '
        Me.rtbTweetProgress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbTweetProgress.BackColor = System.Drawing.Color.Black
        Me.rtbTweetProgress.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweetProgress.ForeColor = System.Drawing.Color.White
        Me.rtbTweetProgress.Location = New System.Drawing.Point(586, 57)
        Me.rtbTweetProgress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbTweetProgress.Name = "rtbTweetProgress"
        Me.rtbTweetProgress.Size = New System.Drawing.Size(257, 398)
        Me.rtbTweetProgress.TabIndex = 23
        Me.rtbTweetProgress.Text = ""
        '
        'RtbTweetText
        '
        Me.RtbTweetText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RtbTweetText.ContextMenuStrip = Me.ContextMenuStrip1
        Me.RtbTweetText.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtbTweetText.Location = New System.Drawing.Point(23, 383)
        Me.RtbTweetText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RtbTweetText.Name = "RtbTweetText"
        Me.RtbTweetText.Size = New System.Drawing.Size(420, 162)
        Me.RtbTweetText.TabIndex = 26
        Me.RtbTweetText.Text = ""
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
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(449, 485)
        Me.BtnSend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(96, 60)
        Me.BtnSend.TabIndex = 27
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 576)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(857, 22)
        Me.StatusStrip1.TabIndex = 28
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(583, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Send As"
        '
        'cmbTwitterUsers
        '
        Me.cmbTwitterUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTwitterUsers.FormattingEnabled = True
        Me.cmbTwitterUsers.Location = New System.Drawing.Point(646, 18)
        Me.cmbTwitterUsers.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTwitterUsers.Name = "cmbTwitterUsers"
        Me.cmbTwitterUsers.Size = New System.Drawing.Size(197, 24)
        Me.cmbTwitterUsers.TabIndex = 31
        '
        'BtnImage
        '
        Me.BtnImage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImage.Location = New System.Drawing.Point(23, 108)
        Me.BtnImage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnImage.Name = "BtnImage"
        Me.BtnImage.Size = New System.Drawing.Size(80, 34)
        Me.BtnImage.TabIndex = 32
        Me.BtnImage.Text = "Get Image"
        Me.BtnImage.UseVisualStyleBackColor = True
        '
        'BtnCreateFullName
        '
        Me.BtnCreateFullName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCreateFullName.Location = New System.Drawing.Point(23, 12)
        Me.BtnCreateFullName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCreateFullName.Name = "BtnCreateFullName"
        Me.BtnCreateFullName.Size = New System.Drawing.Size(41, 32)
        Me.BtnCreateFullName.TabIndex = 36
        Me.BtnCreateFullName.Text = ">"
        Me.BtnCreateFullName.UseVisualStyleBackColor = True
        '
        'BtnSplitName
        '
        Me.BtnSplitName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSplitName.Location = New System.Drawing.Point(23, 59)
        Me.BtnSplitName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSplitName.Name = "BtnSplitName"
        Me.BtnSplitName.Size = New System.Drawing.Size(41, 32)
        Me.BtnSplitName.TabIndex = 37
        Me.BtnSplitName.Text = ">"
        Me.BtnSplitName.UseVisualStyleBackColor = True
        '
        'TxtSurname
        '
        Me.TxtSurname.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSurname.Location = New System.Drawing.Point(237, 59)
        Me.TxtSurname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(174, 26)
        Me.TxtSurname.TabIndex = 35
        '
        'TxtForename
        '
        Me.TxtForename.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForename.Location = New System.Drawing.Point(72, 59)
        Me.TxtForename.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(159, 26)
        Me.TxtForename.TabIndex = 34
        '
        'TxtName
        '
        Me.TxtName.AllowDrop = True
        Me.TxtName.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(70, 18)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(287, 26)
        Me.TxtName.TabIndex = 33
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CelebrityBirthday.My.Resources.Resources.NoImage
        Me.PictureBox1.Location = New System.Drawing.Point(23, 295)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.TabIndex = 131
        Me.PictureBox1.TabStop = False
        '
        'LblImageFile
        '
        Me.LblImageFile.AutoSize = True
        Me.LblImageFile.Location = New System.Drawing.Point(114, 139)
        Me.LblImageFile.Name = "LblImageFile"
        Me.LblImageFile.Size = New System.Drawing.Size(68, 17)
        Me.LblImageFile.TabIndex = 132
        Me.LblImageFile.Text = "Image File"
        '
        'NudSentences
        '
        Me.NudSentences.Location = New System.Drawing.Point(117, 194)
        Me.NudSentences.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NudSentences.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudSentences.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudSentences.Name = "NudSentences"
        Me.NudSentences.Size = New System.Drawing.Size(54, 24)
        Me.NudSentences.TabIndex = 134
        Me.NudSentences.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BtnGetWikiText
        '
        Me.BtnGetWikiText.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGetWikiText.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGetWikiText.Location = New System.Drawing.Point(23, 160)
        Me.BtnGetWikiText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnGetWikiText.Name = "BtnGetWikiText"
        Me.BtnGetWikiText.Size = New System.Drawing.Size(80, 58)
        Me.BtnGetWikiText.TabIndex = 133
        Me.BtnGetWikiText.Text = "Get Wiki Text"
        Me.BtnGetWikiText.UseVisualStyleBackColor = True
        '
        'LblImageName
        '
        Me.LblImageName.AutoSize = True
        Me.LblImageName.Location = New System.Drawing.Point(114, 108)
        Me.LblImageName.Name = "LblImageName"
        Me.LblImageName.Size = New System.Drawing.Size(85, 17)
        Me.LblImageName.TabIndex = 135
        Me.LblImageName.Text = "Image Name"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(124, 266)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(421, 109)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 136
        Me.PictureBox2.TabStop = False
        '
        'chkImages
        '
        Me.chkImages.AutoSize = True
        Me.chkImages.Checked = True
        Me.chkImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImages.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkImages.Location = New System.Drawing.Point(372, 226)
        Me.chkImages.Name = "chkImages"
        Me.chkImages.Size = New System.Drawing.Size(109, 18)
        Me.chkImages.TabIndex = 138
        Me.chkImages.Text = "Include Images"
        Me.chkImages.UseVisualStyleBackColor = True
        '
        'LblTweetLength
        '
        Me.LblTweetLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTweetLength.AutoSize = True
        Me.LblTweetLength.Location = New System.Drawing.Point(20, 549)
        Me.LblTweetLength.Name = "LblTweetLength"
        Me.LblTweetLength.Size = New System.Drawing.Size(16, 17)
        Me.LblTweetLength.TabIndex = 137
        Me.LblTweetLength.Text = "0"
        '
        'BtnClear
        '
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClear.Location = New System.Drawing.Point(484, 12)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(80, 34)
        Me.BtnClear.TabIndex = 140
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSaveImage.Location = New System.Drawing.Point(23, 243)
        Me.BtnSaveImage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(88, 34)
        Me.BtnSaveImage.TabIndex = 141
        Me.BtnSaveImage.Text = "Save Image"
        Me.BtnSaveImage.UseVisualStyleBackColor = True
        '
        'BtnClearImages
        '
        Me.BtnClearImages.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClearImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClearImages.Location = New System.Drawing.Point(349, 169)
        Me.BtnClearImages.Name = "BtnClearImages"
        Me.BtnClearImages.Size = New System.Drawing.Size(142, 41)
        Me.BtnClearImages.TabIndex = 142
        Me.BtnClearImages.Text = "Clear Images"
        Me.BtnClearImages.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(582, 485)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(259, 23)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Check Twitter User Logged In"
        '
        'FrmSingleTweet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(857, 598)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.BtnClearImages)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.chkImages)
        Me.Controls.Add(Me.LblTweetLength)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblImageName)
        Me.Controls.Add(Me.NudSentences)
        Me.Controls.Add(Me.BtnGetWikiText)
        Me.Controls.Add(Me.LblImageFile)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnCreateFullName)
        Me.Controls.Add(Me.BtnSplitName)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.BtnImage)
        Me.Controls.Add(Me.RtbTweetText)
        Me.Controls.Add(Me.cmbTwitterUsers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSend)
        Me.Controls.Add(Me.rtbTweetProgress)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmSingleTweet"
        Me.Text = "Send Tweet"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents rtbTweetProgress As RichTextBox
    Friend WithEvents RtbTweetText As RichTextBox
    Friend WithEvents BtnSend As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTwitterUsers As ComboBox
    Friend WithEvents BtnImage As Button
    Friend WithEvents BtnCreateFullName As Button
    Friend WithEvents BtnSplitName As Button
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents TxtName As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblImageFile As Label
    Friend WithEvents NudSentences As NumericUpDown
    Friend WithEvents BtnGetWikiText As Button
    Friend WithEvents LblImageName As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents chkImages As CheckBox
    Friend WithEvents LblTweetLength As Label
    Friend WithEvents BtnClear As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnSaveImage As Button
    Friend WithEvents BtnClearImages As Button
    Friend WithEvents Label7 As Label
End Class

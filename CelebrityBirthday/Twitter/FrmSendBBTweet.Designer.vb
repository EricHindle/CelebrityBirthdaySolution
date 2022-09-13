<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSendBBTweet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSendBBTweet))
        Me.chkImages = New System.Windows.Forms.CheckBox()
        Me.LblTweetLength = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LblImageName = New System.Windows.Forms.Label()
        Me.LblImageFile = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.RtbTweetText = New System.Windows.Forms.RichTextBox()
        Me.rtbTweetProgress = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.TxtSuffix = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkImages
        '
        Me.chkImages.AutoSize = True
        Me.chkImages.Checked = True
        Me.chkImages.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImages.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.chkImages.Location = New System.Drawing.Point(338, 149)
        Me.chkImages.Name = "chkImages"
        Me.chkImages.Size = New System.Drawing.Size(104, 18)
        Me.chkImages.TabIndex = 175
        Me.chkImages.Text = "Include Image"
        Me.chkImages.UseVisualStyleBackColor = True
        '
        'LblTweetLength
        '
        Me.LblTweetLength.AutoSize = True
        Me.LblTweetLength.Location = New System.Drawing.Point(20, 288)
        Me.LblTweetLength.Name = "LblTweetLength"
        Me.LblTweetLength.Size = New System.Drawing.Size(13, 13)
        Me.LblTweetLength.TabIndex = 174
        Me.LblTweetLength.Text = "0"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(22, 175)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(421, 109)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 173
        Me.PictureBox2.TabStop = False
        '
        'LblImageName
        '
        Me.LblImageName.AutoSize = True
        Me.LblImageName.Location = New System.Drawing.Point(108, 98)
        Me.LblImageName.Name = "LblImageName"
        Me.LblImageName.Size = New System.Drawing.Size(67, 13)
        Me.LblImageName.TabIndex = 172
        Me.LblImageName.Text = "Image Name"
        '
        'LblImageFile
        '
        Me.LblImageFile.AutoSize = True
        Me.LblImageFile.Location = New System.Drawing.Point(108, 122)
        Me.LblImageFile.Name = "LblImageFile"
        Me.LblImageFile.Size = New System.Drawing.Size(55, 13)
        Me.LblImageFile.TabIndex = 169
        Me.LblImageFile.Text = "Image File"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CelebrityBirthday.My.Resources.Resources.NoImage
        Me.PictureBox1.Location = New System.Drawing.Point(22, 87)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.TabIndex = 168
        Me.PictureBox1.TabStop = False
        '
        'RtbTweetText
        '
        Me.RtbTweetText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RtbTweetText.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RtbTweetText.Location = New System.Drawing.Point(23, 305)
        Me.RtbTweetText.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RtbTweetText.Name = "RtbTweetText"
        Me.RtbTweetText.Size = New System.Drawing.Size(420, 200)
        Me.RtbTweetText.TabIndex = 157
        Me.RtbTweetText.Text = ""
        '
        'rtbTweetProgress
        '
        Me.rtbTweetProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbTweetProgress.BackColor = System.Drawing.Color.Black
        Me.rtbTweetProgress.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweetProgress.ForeColor = System.Drawing.Color.White
        Me.rtbTweetProgress.Location = New System.Drawing.Point(449, 15)
        Me.rtbTweetProgress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbTweetProgress.Name = "rtbTweetProgress"
        Me.rtbTweetProgress.Size = New System.Drawing.Size(267, 423)
        Me.rtbTweetProgress.TabIndex = 155
        Me.rtbTweetProgress.Text = ""
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(574, 464)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(138, 41)
        Me.btnClose.TabIndex = 154
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'TxtName
        '
        Me.TxtName.AllowDrop = True
        Me.TxtName.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(22, 12)
        Me.TxtName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(287, 26)
        Me.TxtName.TabIndex = 163
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 518)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(725, 22)
        Me.StatusStrip1.TabIndex = 159
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
        'TxtSurname
        '
        Me.TxtSurname.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSurname.Location = New System.Drawing.Point(269, 53)
        Me.TxtSurname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(174, 26)
        Me.TxtSurname.TabIndex = 165
        '
        'TxtForename
        '
        Me.TxtForename.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForename.Location = New System.Drawing.Point(22, 53)
        Me.TxtForename.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(230, 26)
        Me.TxtForename.TabIndex = 164
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(449, 445)
        Me.BtnSend.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(96, 60)
        Me.BtnSend.TabIndex = 158
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'TxtSuffix
        '
        Me.TxtSuffix.Location = New System.Drawing.Point(355, 103)
        Me.TxtSuffix.Name = "TxtSuffix"
        Me.TxtSuffix.Size = New System.Drawing.Size(79, 20)
        Me.TxtSuffix.TabIndex = 176
        '
        'FrmSendBBTweet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 540)
        Me.Controls.Add(Me.TxtSuffix)
        Me.Controls.Add(Me.chkImages)
        Me.Controls.Add(Me.LblTweetLength)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LblImageName)
        Me.Controls.Add(Me.LblImageFile)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.RtbTweetText)
        Me.Controls.Add(Me.rtbTweetProgress)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.BtnSend)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSendBBTweet"
        Me.Text = "Send BB Tweet"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkImages As CheckBox
    Friend WithEvents LblTweetLength As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LblImageName As Label
    Friend WithEvents LblImageFile As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RtbTweetText As RichTextBox
    Friend WithEvents rtbTweetProgress As RichTextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents TxtName As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents BtnSend As Button
    Friend WithEvents TxtSuffix As TextBox
End Class

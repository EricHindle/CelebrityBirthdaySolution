' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTwitterAuth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTwitterAuth))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtVerifiedOauthTokenSecret = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtVerifiedOauthToken = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtOauthVerifier = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtOauthTokenSecret = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtOauthToken = New System.Windows.Forms.TextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.cmbTwitterUsers = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAuthenticate = New System.Windows.Forms.Button()
        Me.rtbTweetProgress = New System.Windows.Forms.RichTextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 634)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(848, 22)
        Me.StatusStrip1.TabIndex = 29
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
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(8, 597)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(259, 23)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "Check Twitter User Logged In"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(368, 434)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(162, 14)
        Me.Label5.TabIndex = 169
        Me.Label5.Text = "verified oauth_token_secret"
        '
        'TxtVerifiedOauthTokenSecret
        '
        Me.TxtVerifiedOauthTokenSecret.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtVerifiedOauthTokenSecret.Location = New System.Drawing.Point(368, 451)
        Me.TxtVerifiedOauthTokenSecret.Name = "TxtVerifiedOauthTokenSecret"
        Me.TxtVerifiedOauthTokenSecret.Size = New System.Drawing.Size(382, 25)
        Me.TxtVerifiedOauthTokenSecret.TabIndex = 168
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label6.Location = New System.Drawing.Point(368, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 14)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "verified oauth_token"
        '
        'TxtVerifiedOauthToken
        '
        Me.TxtVerifiedOauthToken.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtVerifiedOauthToken.Location = New System.Drawing.Point(368, 407)
        Me.TxtVerifiedOauthToken.Name = "TxtVerifiedOauthToken"
        Me.TxtVerifiedOauthToken.Size = New System.Drawing.Size(382, 25)
        Me.TxtVerifiedOauthToken.TabIndex = 166
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(19, 478)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 14)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "oauth_verifier"
        '
        'TxtOauthVerifier
        '
        Me.TxtOauthVerifier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtOauthVerifier.Location = New System.Drawing.Point(19, 495)
        Me.TxtOauthVerifier.Name = "TxtOauthVerifier"
        Me.TxtOauthVerifier.Size = New System.Drawing.Size(322, 25)
        Me.TxtOauthVerifier.TabIndex = 164
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label3.Location = New System.Drawing.Point(19, 434)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 14)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "oauth_token_secret"
        '
        'TxtOauthTokenSecret
        '
        Me.TxtOauthTokenSecret.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtOauthTokenSecret.Location = New System.Drawing.Point(19, 451)
        Me.TxtOauthTokenSecret.Name = "TxtOauthTokenSecret"
        Me.TxtOauthTokenSecret.Size = New System.Drawing.Size(322, 25)
        Me.TxtOauthTokenSecret.TabIndex = 162
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(19, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "oauth_token"
        '
        'TxtOauthToken
        '
        Me.TxtOauthToken.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtOauthToken.Location = New System.Drawing.Point(19, 407)
        Me.TxtOauthToken.Name = "TxtOauthToken"
        Me.TxtOauthToken.Size = New System.Drawing.Size(322, 25)
        Me.TxtOauthToken.TabIndex = 160
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(23, 25)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(450, 318)
        Me.WebBrowser1.TabIndex = 159
        '
        'cmbTwitterUsers
        '
        Me.cmbTwitterUsers.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTwitterUsers.FormattingEnabled = True
        Me.cmbTwitterUsers.Location = New System.Drawing.Point(111, 13)
        Me.cmbTwitterUsers.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTwitterUsers.Name = "cmbTwitterUsers"
        Me.cmbTwitterUsers.Size = New System.Drawing.Size(257, 24)
        Me.cmbTwitterUsers.TabIndex = 158
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Send As"
        '
        'BtnAuthenticate
        '
        Me.BtnAuthenticate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAuthenticate.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAuthenticate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAuthenticate.Location = New System.Drawing.Point(508, 507)
        Me.BtnAuthenticate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnAuthenticate.Name = "BtnAuthenticate"
        Me.BtnAuthenticate.Size = New System.Drawing.Size(110, 41)
        Me.BtnAuthenticate.TabIndex = 156
        Me.BtnAuthenticate.Text = "Authenticate"
        Me.BtnAuthenticate.UseVisualStyleBackColor = True
        '
        'rtbTweetProgress
        '
        Me.rtbTweetProgress.BackColor = System.Drawing.Color.Black
        Me.rtbTweetProgress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbTweetProgress.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTweetProgress.ForeColor = System.Drawing.Color.White
        Me.rtbTweetProgress.Location = New System.Drawing.Point(0, 0)
        Me.rtbTweetProgress.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbTweetProgress.Name = "rtbTweetProgress"
        Me.rtbTweetProgress.Size = New System.Drawing.Size(370, 318)
        Me.rtbTweetProgress.TabIndex = 155
        Me.rtbTweetProgress.Text = ""
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(674, 589)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(162, 41)
        Me.btnClose.TabIndex = 154
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 53)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtbTweetProgress)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(824, 318)
        Me.SplitContainer1.SplitterDistance = 370
        Me.SplitContainer1.TabIndex = 171
        '
        'FrmTwitterAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 656)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtVerifiedOauthTokenSecret)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtVerifiedOauthToken)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtOauthVerifier)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtOauthTokenSecret)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtOauthToken)
        Me.Controls.Add(Me.cmbTwitterUsers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnAuthenticate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmTwitterAuth"
        Me.Text = "Twitter Authorisation"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtVerifiedOauthTokenSecret As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtVerifiedOauthToken As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtOauthVerifier As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtOauthTokenSecret As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtOauthToken As TextBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents cmbTwitterUsers As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnAuthenticate As Button
    Friend WithEvents rtbTweetProgress As RichTextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents SplitContainer1 As SplitContainer
End Class

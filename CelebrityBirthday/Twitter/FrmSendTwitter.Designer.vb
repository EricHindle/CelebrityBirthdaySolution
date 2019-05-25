<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSendTwitter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSendTwitter))
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.rtbTweet = New System.Windows.Forms.RichTextBox()
        Me.BtnAuthenticate = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.rtbTweetText = New System.Windows.Forms.RichTextBox()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboDay
        '
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(12, 12)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(95, 27)
        Me.cboDay.TabIndex = 19
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(115, 12)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(240, 27)
        Me.cboMonth.TabIndex = 20
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(764, 574)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSelect.Location = New System.Drawing.Point(754, 11)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(139, 33)
        Me.btnSelect.TabIndex = 21
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'rtbTweet
        '
        Me.rtbTweet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbTweet.Location = New System.Drawing.Point(12, 45)
        Me.rtbTweet.Name = "rtbTweet"
        Me.rtbTweet.Size = New System.Drawing.Size(343, 254)
        Me.rtbTweet.TabIndex = 23
        Me.rtbTweet.Text = ""
        '
        'BtnAuthenticate
        '
        Me.BtnAuthenticate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAuthenticate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAuthenticate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAuthenticate.Location = New System.Drawing.Point(216, 316)
        Me.BtnAuthenticate.Name = "BtnAuthenticate"
        Me.BtnAuthenticate.Size = New System.Drawing.Size(139, 33)
        Me.BtnAuthenticate.TabIndex = 24
        Me.BtnAuthenticate.Text = "Authenticate"
        Me.BtnAuthenticate.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(501, 60)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(392, 326)
        Me.WebBrowser1.TabIndex = 25
        '
        'rtbTweetText
        '
        Me.rtbTweetText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rtbTweetText.Location = New System.Drawing.Point(23, 376)
        Me.rtbTweetText.Name = "rtbTweetText"
        Me.rtbTweetText.Size = New System.Drawing.Size(331, 231)
        Me.rtbTweetText.TabIndex = 26
        Me.rtbTweetText.Text = ""
        '
        'BtnSend
        '
        Me.BtnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSend.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSend.Location = New System.Drawing.Point(413, 574)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(139, 33)
        Me.BtnSend.TabIndex = 27
        Me.BtnSend.Text = "Send"
        Me.BtnSend.UseVisualStyleBackColor = True
        '
        'FrmSendTwitter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(944, 620)
        Me.Controls.Add(Me.BtnSend)
        Me.Controls.Add(Me.rtbTweetText)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.BtnAuthenticate)
        Me.Controls.Add(Me.rtbTweet)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboMonth)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSendTwitter"
        Me.Text = "FrmSendTwitter"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents btnClose As Button
    Friend WithEvents btnSelect As Button
    Friend WithEvents rtbTweet As RichTextBox
    Friend WithEvents BtnAuthenticate As Button
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents rtbTweetText As RichTextBox
    Friend WithEvents BtnSend As Button
End Class

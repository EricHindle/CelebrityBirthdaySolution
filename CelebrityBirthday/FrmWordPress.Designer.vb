<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWordPress
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWordPress))
        Me.btnCopyExcerpt = New System.Windows.Forms.Button()
        Me.btnCopyFull = New System.Windows.Forms.Button()
        Me.txtCurrentExcerpt = New System.Windows.Forms.TextBox()
        Me.txtCurrentText = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.txtLoadMth = New System.Windows.Forms.TextBox()
        Me.txtLoadYr = New System.Windows.Forms.TextBox()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.BtnBrowser = New System.Windows.Forms.Button()
        Me.TxtLoadDay = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnGetName = New System.Windows.Forms.Button()
        Me.BtnGetDescription = New System.Windows.Forms.Button()
        Me.TxtSelectedName = New System.Windows.Forms.TextBox()
        Me.TxtSelectedDescription = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCopyExcerpt
        '
        Me.btnCopyExcerpt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyExcerpt.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyExcerpt.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCopyExcerpt.Location = New System.Drawing.Point(440, 95)
        Me.btnCopyExcerpt.Name = "btnCopyExcerpt"
        Me.btnCopyExcerpt.Size = New System.Drawing.Size(61, 29)
        Me.btnCopyExcerpt.TabIndex = 65
        Me.btnCopyExcerpt.Text = "Copy"
        Me.btnCopyExcerpt.UseVisualStyleBackColor = True
        '
        'btnCopyFull
        '
        Me.btnCopyFull.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyFull.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyFull.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCopyFull.Location = New System.Drawing.Point(440, 268)
        Me.btnCopyFull.Name = "btnCopyFull"
        Me.btnCopyFull.Size = New System.Drawing.Size(61, 31)
        Me.btnCopyFull.TabIndex = 62
        Me.btnCopyFull.Text = "Copy"
        Me.btnCopyFull.UseVisualStyleBackColor = True
        '
        'txtCurrentExcerpt
        '
        Me.txtCurrentExcerpt.AllowDrop = True
        Me.txtCurrentExcerpt.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCurrentExcerpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentExcerpt.Location = New System.Drawing.Point(0, 0)
        Me.txtCurrentExcerpt.Multiline = True
        Me.txtCurrentExcerpt.Name = "txtCurrentExcerpt"
        Me.txtCurrentExcerpt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCurrentExcerpt.Size = New System.Drawing.Size(434, 146)
        Me.txtCurrentExcerpt.TabIndex = 58
        Me.txtCurrentExcerpt.WordWrap = False
        '
        'txtCurrentText
        '
        Me.txtCurrentText.AllowDrop = True
        Me.txtCurrentText.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCurrentText.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentText.Location = New System.Drawing.Point(0, 0)
        Me.txtCurrentText.Multiline = True
        Me.txtCurrentText.Name = "txtCurrentText"
        Me.txtCurrentText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCurrentText.Size = New System.Drawing.Size(434, 330)
        Me.txtCurrentText.TabIndex = 57
        Me.txtCurrentText.WordWrap = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCurrentText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCopyFull)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCurrentExcerpt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCopyExcerpt)
        Me.SplitContainer1.Size = New System.Drawing.Size(508, 488)
        Me.SplitContainer1.SplitterDistance = 334
        Me.SplitContainer1.TabIndex = 68
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(935, 566)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 43)
        Me.BtnClose.TabIndex = 69
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(89, 507)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(207, 27)
        Me.cboMonth.TabIndex = 84
        '
        'cboDay
        '
        Me.cboDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(12, 507)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(71, 27)
        Me.cboDay.TabIndex = 83
        '
        'txtLoadMth
        '
        Me.txtLoadMth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMth.Location = New System.Drawing.Point(66, 566)
        Me.txtLoadMth.Name = "txtLoadMth"
        Me.txtLoadMth.Size = New System.Drawing.Size(48, 22)
        Me.txtLoadMth.TabIndex = 85
        '
        'txtLoadYr
        '
        Me.txtLoadYr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtLoadYr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadYr.Location = New System.Drawing.Point(120, 566)
        Me.txtLoadYr.Name = "txtLoadYr"
        Me.txtLoadYr.Size = New System.Drawing.Size(71, 22)
        Me.txtLoadYr.TabIndex = 86
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer2.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1000, 488)
        Me.SplitContainer2.SplitterDistance = 508
        Me.SplitContainer2.TabIndex = 87
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(484, 484)
        Me.WebBrowser1.TabIndex = 0
        '
        'BtnBrowser
        '
        Me.BtnBrowser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBrowser.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBrowser.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBrowser.Location = New System.Drawing.Point(383, 529)
        Me.BtnBrowser.Name = "BtnBrowser"
        Me.BtnBrowser.Size = New System.Drawing.Size(106, 58)
        Me.BtnBrowser.TabIndex = 88
        Me.BtnBrowser.Text = "Open Browser"
        Me.BtnBrowser.UseVisualStyleBackColor = True
        '
        'TxtLoadDay
        '
        Me.TxtLoadDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtLoadDay.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLoadDay.Location = New System.Drawing.Point(12, 565)
        Me.TxtLoadDay.Name = "TxtLoadDay"
        Me.TxtLoadDay.Size = New System.Drawing.Size(48, 22)
        Me.TxtLoadDay.TabIndex = 89
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 612)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1024, 22)
        Me.StatusStrip1.TabIndex = 90
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
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 548)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Page Load Date"
        '
        'BtnGetName
        '
        Me.BtnGetName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGetName.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.copyicon
        Me.BtnGetName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnGetName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGetName.Location = New System.Drawing.Point(805, 511)
        Me.BtnGetName.Name = "BtnGetName"
        Me.BtnGetName.Size = New System.Drawing.Size(30, 30)
        Me.BtnGetName.TabIndex = 92
        Me.BtnGetName.UseVisualStyleBackColor = True
        '
        'BtnGetDescription
        '
        Me.BtnGetDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGetDescription.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.copyicon
        Me.BtnGetDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnGetDescription.Location = New System.Drawing.Point(841, 579)
        Me.BtnGetDescription.Name = "BtnGetDescription"
        Me.BtnGetDescription.Size = New System.Drawing.Size(30, 30)
        Me.BtnGetDescription.TabIndex = 93
        Me.BtnGetDescription.UseVisualStyleBackColor = True
        '
        'TxtSelectedName
        '
        Me.TxtSelectedName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtSelectedName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedName.Location = New System.Drawing.Point(526, 511)
        Me.TxtSelectedName.Name = "TxtSelectedName"
        Me.TxtSelectedName.Size = New System.Drawing.Size(263, 27)
        Me.TxtSelectedName.TabIndex = 94
        '
        'TxtSelectedDescription
        '
        Me.TxtSelectedDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtSelectedDescription.Location = New System.Drawing.Point(526, 544)
        Me.TxtSelectedDescription.Multiline = True
        Me.TxtSelectedDescription.Name = "TxtSelectedDescription"
        Me.TxtSelectedDescription.Size = New System.Drawing.Size(309, 65)
        Me.TxtSelectedDescription.TabIndex = 95
        '
        'FrmWordPress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1024, 634)
        Me.Controls.Add(Me.TxtSelectedDescription)
        Me.Controls.Add(Me.TxtSelectedName)
        Me.Controls.Add(Me.BtnGetDescription)
        Me.Controls.Add(Me.BtnGetName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TxtLoadDay)
        Me.Controls.Add(Me.BtnBrowser)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.txtLoadMth)
        Me.Controls.Add(Me.txtLoadYr)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.BtnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmWordPress"
        Me.Text = "WordPress"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCopyExcerpt As Button
    Friend WithEvents btnCopyFull As Button
    Friend WithEvents txtCurrentExcerpt As TextBox
    Friend WithEvents txtCurrentText As TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnClose As Button
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents txtLoadMth As TextBox
    Friend WithEvents txtLoadYr As TextBox
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents BtnBrowser As Button
    Friend WithEvents TxtLoadDay As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnGetName As Button
    Friend WithEvents BtnGetDescription As Button
    Friend WithEvents TxtSelectedName As TextBox
    Friend WithEvents TxtSelectedDescription As TextBox
End Class

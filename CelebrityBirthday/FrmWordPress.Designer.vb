<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWordPress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWordPress))
        Me.btnClrExcerpt = New System.Windows.Forms.Button()
        Me.btnCopyExcerpt = New System.Windows.Forms.Button()
        Me.btnClrCurr = New System.Windows.Forms.Button()
        Me.btnGenExcerpt = New System.Windows.Forms.Button()
        Me.btnCopyFull = New System.Windows.Forms.Button()
        Me.txtCurrentExcerpt = New System.Windows.Forms.TextBox()
        Me.btnGenFullText = New System.Windows.Forms.Button()
        Me.txtCurrentText = New System.Windows.Forms.TextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.txtLoadMth = New System.Windows.Forms.TextBox()
        Me.txtLoadYr = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClrExcerpt
        '
        Me.btnClrExcerpt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClrExcerpt.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClrExcerpt.Location = New System.Drawing.Point(625, 128)
        Me.btnClrExcerpt.Name = "btnClrExcerpt"
        Me.btnClrExcerpt.Size = New System.Drawing.Size(85, 26)
        Me.btnClrExcerpt.TabIndex = 66
        Me.btnClrExcerpt.Text = "Clear"
        Me.btnClrExcerpt.UseVisualStyleBackColor = True
        '
        'btnCopyExcerpt
        '
        Me.btnCopyExcerpt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyExcerpt.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyExcerpt.Location = New System.Drawing.Point(636, 85)
        Me.btnCopyExcerpt.Name = "btnCopyExcerpt"
        Me.btnCopyExcerpt.Size = New System.Drawing.Size(61, 26)
        Me.btnCopyExcerpt.TabIndex = 65
        Me.btnCopyExcerpt.Text = "Copy"
        Me.btnCopyExcerpt.UseVisualStyleBackColor = True
        '
        'btnClrCurr
        '
        Me.btnClrCurr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClrCurr.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClrCurr.Location = New System.Drawing.Point(625, 244)
        Me.btnClrCurr.Name = "btnClrCurr"
        Me.btnClrCurr.Size = New System.Drawing.Size(85, 26)
        Me.btnClrCurr.TabIndex = 63
        Me.btnClrCurr.Text = "Clear"
        Me.btnClrCurr.UseVisualStyleBackColor = True
        '
        'btnGenExcerpt
        '
        Me.btnGenExcerpt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenExcerpt.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenExcerpt.Location = New System.Drawing.Point(625, 41)
        Me.btnGenExcerpt.Name = "btnGenExcerpt"
        Me.btnGenExcerpt.Size = New System.Drawing.Size(85, 26)
        Me.btnGenExcerpt.TabIndex = 64
        Me.btnGenExcerpt.Text = "Generate"
        Me.btnGenExcerpt.UseVisualStyleBackColor = True
        '
        'btnCopyFull
        '
        Me.btnCopyFull.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyFull.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyFull.Location = New System.Drawing.Point(636, 201)
        Me.btnCopyFull.Name = "btnCopyFull"
        Me.btnCopyFull.Size = New System.Drawing.Size(61, 26)
        Me.btnCopyFull.TabIndex = 62
        Me.btnCopyFull.Text = "Copy"
        Me.btnCopyFull.UseVisualStyleBackColor = True
        '
        'txtCurrentExcerpt
        '
        Me.txtCurrentExcerpt.AllowDrop = True
        Me.txtCurrentExcerpt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentExcerpt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentExcerpt.Location = New System.Drawing.Point(0, 3)
        Me.txtCurrentExcerpt.Multiline = True
        Me.txtCurrentExcerpt.Name = "txtCurrentExcerpt"
        Me.txtCurrentExcerpt.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCurrentExcerpt.Size = New System.Drawing.Size(608, 163)
        Me.txtCurrentExcerpt.TabIndex = 58
        Me.txtCurrentExcerpt.WordWrap = False
        '
        'btnGenFullText
        '
        Me.btnGenFullText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenFullText.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenFullText.Location = New System.Drawing.Point(625, 160)
        Me.btnGenFullText.Name = "btnGenFullText"
        Me.btnGenFullText.Size = New System.Drawing.Size(85, 26)
        Me.btnGenFullText.TabIndex = 60
        Me.btnGenFullText.Text = "Generate"
        Me.btnGenFullText.UseVisualStyleBackColor = True
        '
        'txtCurrentText
        '
        Me.txtCurrentText.AllowDrop = True
        Me.txtCurrentText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCurrentText.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentText.Location = New System.Drawing.Point(3, 6)
        Me.txtCurrentText.Multiline = True
        Me.txtCurrentText.Name = "txtCurrentText"
        Me.txtCurrentText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtCurrentText.Size = New System.Drawing.Size(605, 285)
        Me.txtCurrentText.TabIndex = 57
        Me.txtCurrentText.WordWrap = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCurrentText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGenFullText)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCopyFull)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnClrCurr)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.txtCurrentExcerpt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClrExcerpt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnGenExcerpt)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnCopyExcerpt)
        Me.SplitContainer1.Size = New System.Drawing.Size(726, 467)
        Me.SplitContainer1.SplitterDistance = 294
        Me.SplitContainer1.TabIndex = 68
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Location = New System.Drawing.Point(660, 496)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 33)
        Me.BtnClose.TabIndex = 69
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(89, 496)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(207, 27)
        Me.cboMonth.TabIndex = 84
        '
        'cboDay
        '
        Me.cboDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(12, 496)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(71, 27)
        Me.cboDay.TabIndex = 83
        '
        'txtLoadMth
        '
        Me.txtLoadMth.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMth.Location = New System.Drawing.Point(379, 500)
        Me.txtLoadMth.Name = "txtLoadMth"
        Me.txtLoadMth.Size = New System.Drawing.Size(48, 22)
        Me.txtLoadMth.TabIndex = 85
        '
        'txtLoadYr
        '
        Me.txtLoadYr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLoadYr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadYr.Location = New System.Drawing.Point(433, 500)
        Me.txtLoadYr.Name = "txtLoadYr"
        Me.txtLoadYr.Size = New System.Drawing.Size(71, 22)
        Me.txtLoadYr.TabIndex = 86
        '
        'FrmWordPress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(747, 541)
        Me.Controls.Add(Me.txtLoadMth)
        Me.Controls.Add(Me.txtLoadYr)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.SplitContainer1)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClrExcerpt As Button
    Friend WithEvents btnCopyExcerpt As Button
    Friend WithEvents btnClrCurr As Button
    Friend WithEvents btnGenExcerpt As Button
    Friend WithEvents btnCopyFull As Button
    Friend WithEvents txtCurrentExcerpt As TextBox
    Friend WithEvents btnGenFullText As Button
    Friend WithEvents txtCurrentText As TextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnClose As Button
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents txtLoadMth As TextBox
    Friend WithEvents txtLoadYr As TextBox
End Class

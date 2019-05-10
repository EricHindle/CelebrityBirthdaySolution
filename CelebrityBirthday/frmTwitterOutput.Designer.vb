<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTwitterOutput
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTwitterOutput))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tvBirthday = New System.Windows.Forms.TreeView()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDailyFile = New System.Windows.Forms.RadioButton()
        Me.rbSingleFile = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbBoth = New System.Windows.Forms.RadioButton()
        Me.rbAnnivOnly = New System.Windows.Forms.RadioButton()
        Me.rbBirthdaysOnly = New System.Windows.Forms.RadioButton()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.rtbFile1 = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TcFileTabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.BtnRewrite = New System.Windows.Forms.Button()
        Me.BtnCopyselected = New System.Windows.Forms.Button()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TcFileTabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 18)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(611, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 18)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "To"
        '
        'tvBirthday
        '
        Me.tvBirthday.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvBirthday.CheckBoxes = True
        Me.tvBirthday.Location = New System.Drawing.Point(35, 85)
        Me.tvBirthday.Name = "tvBirthday"
        Me.tvBirthday.Size = New System.Drawing.Size(348, 425)
        Me.tvBirthday.TabIndex = 3
        '
        'btnWrite
        '
        Me.btnWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWrite.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWrite.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnWrite.Location = New System.Drawing.Point(820, 341)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(139, 33)
        Me.btnWrite.TabIndex = 7
        Me.btnWrite.Text = "Write Files"
        Me.btnWrite.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSelect.Location = New System.Drawing.Point(820, 26)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(139, 33)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(820, 477)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.rbDailyFile)
        Me.GroupBox1.Controls.Add(Me.rbSingleFile)
        Me.GroupBox1.Location = New System.Drawing.Point(820, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 88)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'rbDailyFile
        '
        Me.rbDailyFile.AutoSize = True
        Me.rbDailyFile.Checked = True
        Me.rbDailyFile.Location = New System.Drawing.Point(17, 51)
        Me.rbDailyFile.Name = "rbDailyFile"
        Me.rbDailyFile.Size = New System.Drawing.Size(88, 22)
        Me.rbDailyFile.TabIndex = 1
        Me.rbDailyFile.TabStop = True
        Me.rbDailyFile.Text = "Daily Files"
        Me.rbDailyFile.UseVisualStyleBackColor = True
        '
        'rbSingleFile
        '
        Me.rbSingleFile.AutoSize = True
        Me.rbSingleFile.Location = New System.Drawing.Point(17, 23)
        Me.rbSingleFile.Name = "rbSingleFile"
        Me.rbSingleFile.Size = New System.Drawing.Size(87, 22)
        Me.rbSingleFile.TabIndex = 0
        Me.rbSingleFile.Text = "Single File"
        Me.rbSingleFile.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rbBoth)
        Me.GroupBox2.Controls.Add(Me.rbAnnivOnly)
        Me.GroupBox2.Controls.Add(Me.rbBirthdaysOnly)
        Me.GroupBox2.Location = New System.Drawing.Point(820, 177)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(139, 123)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'rbBoth
        '
        Me.rbBoth.AutoSize = True
        Me.rbBoth.Checked = True
        Me.rbBoth.Location = New System.Drawing.Point(17, 83)
        Me.rbBoth.Name = "rbBoth"
        Me.rbBoth.Size = New System.Drawing.Size(56, 22)
        Me.rbBoth.TabIndex = 2
        Me.rbBoth.TabStop = True
        Me.rbBoth.Text = "Both"
        Me.rbBoth.UseVisualStyleBackColor = True
        '
        'rbAnnivOnly
        '
        Me.rbAnnivOnly.AutoSize = True
        Me.rbAnnivOnly.Location = New System.Drawing.Point(17, 55)
        Me.rbAnnivOnly.Name = "rbAnnivOnly"
        Me.rbAnnivOnly.Size = New System.Drawing.Size(102, 22)
        Me.rbAnnivOnly.TabIndex = 1
        Me.rbAnnivOnly.Text = "Anniversary"
        Me.rbAnnivOnly.UseVisualStyleBackColor = True
        '
        'rbBirthdaysOnly
        '
        Me.rbBirthdaysOnly.AutoSize = True
        Me.rbBirthdaysOnly.Location = New System.Drawing.Point(17, 27)
        Me.rbBirthdaysOnly.Name = "rbBirthdaysOnly"
        Me.rbBirthdaysOnly.Size = New System.Drawing.Size(86, 22)
        Me.rbBirthdaysOnly.TabIndex = 0
        Me.rbBirthdaysOnly.Text = "Birthdays"
        Me.rbBirthdaysOnly.UseVisualStyleBackColor = True
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "dd MMMM"
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(458, 12)
        Me.dtpFrom.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpFrom.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(135, 26)
        Me.dtpFrom.TabIndex = 11
        Me.dtpFrom.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "dd MMMM"
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(653, 12)
        Me.dtpTo.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.dtpTo.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(135, 26)
        Me.dtpTo.TabIndex = 12
        Me.dtpTo.Value = New Date(2000, 12, 31, 0, 0, 0, 0)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(977, 22)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(3, 17)
        '
        'rtbFile1
        '
        Me.rtbFile1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFile1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.rtbFile1.Font = New System.Drawing.Font("Consolas", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbFile1.Location = New System.Drawing.Point(6, 3)
        Me.rtbFile1.Name = "rtbFile1"
        Me.rtbFile1.Size = New System.Drawing.Size(400, 388)
        Me.rtbFile1.TabIndex = 14
        Me.rtbFile1.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(103, 26)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'TcFileTabs
        '
        Me.TcFileTabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TcFileTabs.Controls.Add(Me.TabPage1)
        Me.TcFileTabs.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcFileTabs.Location = New System.Drawing.Point(389, 58)
        Me.TcFileTabs.Multiline = True
        Me.TcFileTabs.Name = "TcFileTabs"
        Me.TcFileTabs.SelectedIndex = 0
        Me.TcFileTabs.Size = New System.Drawing.Size(420, 452)
        Me.TcFileTabs.TabIndex = 15
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.BtnRewrite)
        Me.TabPage1.Controls.Add(Me.rtbFile1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(412, 426)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "File"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'BtnRewrite
        '
        Me.BtnRewrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRewrite.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRewrite.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRewrite.Location = New System.Drawing.Point(72, 397)
        Me.BtnRewrite.Name = "BtnRewrite"
        Me.BtnRewrite.Size = New System.Drawing.Size(119, 23)
        Me.BtnRewrite.TabIndex = 15
        Me.BtnRewrite.Text = "Rewrite File"
        Me.BtnRewrite.UseVisualStyleBackColor = True
        '
        'BtnCopyselected
        '
        Me.BtnCopyselected.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyselected.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyselected.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnCopyselected.Location = New System.Drawing.Point(820, 417)
        Me.BtnCopyselected.Name = "BtnCopyselected"
        Me.BtnCopyselected.Size = New System.Drawing.Size(139, 33)
        Me.BtnCopyselected.TabIndex = 16
        Me.BtnCopyselected.Text = "Copy Selected"
        Me.BtnCopyselected.UseVisualStyleBackColor = True
        '
        'cboDay
        '
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(40, 12)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(95, 27)
        Me.cboDay.TabIndex = 17
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(143, 12)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(240, 27)
        Me.cboMonth.TabIndex = 18
        '
        'frmTwitterOutput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(977, 562)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.BtnCopyselected)
        Me.Controls.Add(Me.TcFileTabs)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnWrite)
        Me.Controls.Add(Me.tvBirthday)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimumSize = New System.Drawing.Size(650, 600)
        Me.Name = "frmTwitterOutput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Twitter Output"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TcFileTabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tvBirthday As TreeView
    Friend WithEvents btnWrite As Button
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbDailyFile As RadioButton
    Friend WithEvents rbSingleFile As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbBoth As RadioButton
    Friend WithEvents rbAnnivOnly As RadioButton
    Friend WithEvents rbBirthdaysOnly As RadioButton
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents rtbFile1 As RichTextBox
    Friend WithEvents TcFileTabs As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents BtnRewrite As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents BtnCopyselected As Button
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboMonth As ComboBox
End Class

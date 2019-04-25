<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchDb
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchDb))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NameToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DescToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.lblNav = New System.Windows.Forms.Label()
        Me.cbRev = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbNsSemiC = New System.Windows.Forms.CheckBox()
        Me.cbNsAnd = New System.Windows.Forms.CheckBox()
        Me.cbNsLfeed = New System.Windows.Forms.CheckBox()
        Me.cbNsComma = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbRsSp = New System.Windows.Forms.RadioButton()
        Me.rbRsComma = New System.Windows.Forms.RadioButton()
        Me.btnWikiFind = New System.Windows.Forms.Button()
        Me.btnDbFind = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnFwd = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(1002, 681)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowDrop = True
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.DarkKhaki
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PersonName, Me.PersonYear, Me.PersonMonth, Me.PersonDay, Me.PersonDesc})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1049, 92)
        Me.DataGridView1.TabIndex = 1
        '
        'PersonName
        '
        Me.PersonName.HeaderText = "Name"
        Me.PersonName.Name = "PersonName"
        Me.PersonName.Width = 200
        '
        'PersonYear
        '
        Me.PersonYear.HeaderText = "Year"
        Me.PersonYear.Name = "PersonYear"
        '
        'PersonMonth
        '
        Me.PersonMonth.HeaderText = "Month"
        Me.PersonMonth.Name = "PersonMonth"
        '
        'PersonDay
        '
        Me.PersonDay.HeaderText = "Day"
        Me.PersonDay.Name = "PersonDay"
        '
        'PersonDesc
        '
        Me.PersonDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PersonDesc.HeaderText = "Short description"
        Me.PersonDesc.Name = "PersonDesc"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindToolStripMenuItem, Me.ReCheckToolStripMenuItem, Me.AddToolStripMenuItem, Me.ToolStripSeparator1, Me.NameToolStripMenuItem2, Me.DateToolStripMenuItem1, Me.DescToolStripMenuItem1, Me.NameToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(136, 164)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'ReCheckToolStripMenuItem
        '
        Me.ReCheckToolStripMenuItem.Name = "ReCheckToolStripMenuItem"
        Me.ReCheckToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ReCheckToolStripMenuItem.Text = "ReCheck"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(132, 6)
        '
        'NameToolStripMenuItem2
        '
        Me.NameToolStripMenuItem2.Name = "NameToolStripMenuItem2"
        Me.NameToolStripMenuItem2.Size = New System.Drawing.Size(135, 22)
        Me.NameToolStripMenuItem2.Text = "Name"
        '
        'DateToolStripMenuItem1
        '
        Me.DateToolStripMenuItem1.Name = "DateToolStripMenuItem1"
        Me.DateToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.DateToolStripMenuItem1.Text = "Date"
        '
        'DescToolStripMenuItem1
        '
        Me.DescToolStripMenuItem1.Name = "DescToolStripMenuItem1"
        Me.DescToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.DescToolStripMenuItem1.Text = "Desc"
        '
        'NameToolStripMenuItem
        '
        Me.NameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.YearToolStripMenuItem, Me.MonthToolStripMenuItem, Me.DayToolStripMenuItem})
        Me.NameToolStripMenuItem.Name = "NameToolStripMenuItem"
        Me.NameToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.NameToolStripMenuItem.Text = "Paste Other"
        '
        'YearToolStripMenuItem
        '
        Me.YearToolStripMenuItem.Name = "YearToolStripMenuItem"
        Me.YearToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.YearToolStripMenuItem.Text = "Year"
        '
        'MonthToolStripMenuItem
        '
        Me.MonthToolStripMenuItem.Name = "MonthToolStripMenuItem"
        Me.MonthToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.MonthToolStripMenuItem.Text = "Month"
        '
        'DayToolStripMenuItem
        '
        Me.DayToolStripMenuItem.Name = "DayToolStripMenuItem"
        Me.DayToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.DayToolStripMenuItem.Text = "Day"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(27, 687)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1049, 549)
        Me.WebBrowser1.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(95, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1053, 653)
        Me.SplitContainer1.SplitterDistance = 96
        Me.SplitContainer1.TabIndex = 4
        '
        'txtURL
        '
        Me.txtURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtURL.Location = New System.Drawing.Point(132, 669)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(360, 20)
        Me.txtURL.TabIndex = 5
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGo.Location = New System.Drawing.Point(498, 666)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(30, 24)
        Me.btnGo.TabIndex = 6
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'lblNav
        '
        Me.lblNav.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNav.AutoSize = True
        Me.lblNav.Location = New System.Drawing.Point(548, 672)
        Me.lblNav.Name = "lblNav"
        Me.lblNav.Size = New System.Drawing.Size(16, 13)
        Me.lblNav.TabIndex = 7
        Me.lblNav.Text = "..."
        '
        'cbRev
        '
        Me.cbRev.AutoSize = True
        Me.cbRev.Location = New System.Drawing.Point(12, 236)
        Me.cbRev.Name = "cbRev"
        Me.cbRev.Size = New System.Drawing.Size(66, 17)
        Me.cbRev.TabIndex = 8
        Me.cbRev.Text = "Reverse"
        Me.cbRev.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbNsSemiC)
        Me.GroupBox1.Controls.Add(Me.cbNsAnd)
        Me.GroupBox1.Controls.Add(Me.cbNsLfeed)
        Me.GroupBox1.Controls.Add(Me.cbNsComma)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(82, 198)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Name Sep"
        '
        'cbNsSemiC
        '
        Me.cbNsSemiC.AutoSize = True
        Me.cbNsSemiC.Checked = True
        Me.cbNsSemiC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNsSemiC.Location = New System.Drawing.Point(6, 88)
        Me.cbNsSemiC.Name = "cbNsSemiC"
        Me.cbNsSemiC.Size = New System.Drawing.Size(73, 17)
        Me.cbNsSemiC.TabIndex = 3
        Me.cbNsSemiC.Text = "semicolon"
        Me.cbNsSemiC.UseVisualStyleBackColor = True
        '
        'cbNsAnd
        '
        Me.cbNsAnd.AutoSize = True
        Me.cbNsAnd.Checked = True
        Me.cbNsAnd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNsAnd.Location = New System.Drawing.Point(6, 65)
        Me.cbNsAnd.Name = "cbNsAnd"
        Me.cbNsAnd.Size = New System.Drawing.Size(44, 17)
        Me.cbNsAnd.TabIndex = 2
        Me.cbNsAnd.Text = "and"
        Me.cbNsAnd.UseVisualStyleBackColor = True
        '
        'cbNsLfeed
        '
        Me.cbNsLfeed.AutoSize = True
        Me.cbNsLfeed.Checked = True
        Me.cbNsLfeed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNsLfeed.Location = New System.Drawing.Point(6, 42)
        Me.cbNsLfeed.Name = "cbNsLfeed"
        Me.cbNsLfeed.Size = New System.Drawing.Size(63, 17)
        Me.cbNsLfeed.TabIndex = 1
        Me.cbNsLfeed.Text = "linefeed"
        Me.cbNsLfeed.UseVisualStyleBackColor = True
        '
        'cbNsComma
        '
        Me.cbNsComma.AutoSize = True
        Me.cbNsComma.Checked = True
        Me.cbNsComma.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNsComma.Location = New System.Drawing.Point(6, 19)
        Me.cbNsComma.Name = "cbNsComma"
        Me.cbNsComma.Size = New System.Drawing.Size(60, 17)
        Me.cbNsComma.TabIndex = 0
        Me.cbNsComma.Text = "comma"
        Me.cbNsComma.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbRsSp)
        Me.GroupBox2.Controls.Add(Me.rbRsComma)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 270)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(82, 111)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Rev Sep"
        '
        'rbRsSp
        '
        Me.rbRsSp.AutoSize = True
        Me.rbRsSp.Location = New System.Drawing.Point(5, 42)
        Me.rbRsSp.Name = "rbRsSp"
        Me.rbRsSp.Size = New System.Drawing.Size(56, 17)
        Me.rbRsSp.TabIndex = 1
        Me.rbRsSp.Text = "Space"
        Me.rbRsSp.UseVisualStyleBackColor = True
        '
        'rbRsComma
        '
        Me.rbRsComma.AutoSize = True
        Me.rbRsComma.Checked = True
        Me.rbRsComma.Location = New System.Drawing.Point(6, 19)
        Me.rbRsComma.Name = "rbRsComma"
        Me.rbRsComma.Size = New System.Drawing.Size(60, 17)
        Me.rbRsComma.TabIndex = 0
        Me.rbRsComma.TabStop = True
        Me.rbRsComma.Text = "Comma"
        Me.rbRsComma.UseVisualStyleBackColor = True
        '
        'btnWikiFind
        '
        Me.btnWikiFind.Location = New System.Drawing.Point(7, 495)
        Me.btnWikiFind.Name = "btnWikiFind"
        Me.btnWikiFind.Size = New System.Drawing.Size(75, 60)
        Me.btnWikiFind.TabIndex = 13
        Me.btnWikiFind.Text = "Find Selected in wiki"
        Me.btnWikiFind.UseVisualStyleBackColor = True
        '
        'btnDbFind
        '
        Me.btnDbFind.Location = New System.Drawing.Point(7, 417)
        Me.btnDbFind.Name = "btnDbFind"
        Me.btnDbFind.Size = New System.Drawing.Size(75, 60)
        Me.btnDbFind.TabIndex = 14
        Me.btnDbFind.Text = "Find Selected in Database"
        Me.btnDbFind.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(7, 586)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 15
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnFwd
        '
        Me.btnFwd.Location = New System.Drawing.Point(7, 615)
        Me.btnFwd.Name = "btnFwd"
        Me.btnFwd.Size = New System.Drawing.Size(75, 23)
        Me.btnFwd.TabIndex = 16
        Me.btnFwd.Text = "Forward"
        Me.btnFwd.UseVisualStyleBackColor = True
        '
        'frmSearchDb
        '
        Me.AcceptButton = Me.btnGo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.OldLace
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1160, 722)
        Me.Controls.Add(Me.btnFwd)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnDbFind)
        Me.Controls.Add(Me.btnWikiFind)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cbRev)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblNav)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmSearchDb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Search database"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PersonName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonDay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PersonDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents lblNav As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NameToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DescToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbRev As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbRsSp As System.Windows.Forms.RadioButton
    Friend WithEvents rbRsComma As System.Windows.Forms.RadioButton
    Friend WithEvents cbNsSemiC As System.Windows.Forms.CheckBox
    Friend WithEvents cbNsAnd As System.Windows.Forms.CheckBox
    Friend WithEvents cbNsLfeed As System.Windows.Forms.CheckBox
    Friend WithEvents cbNsComma As System.Windows.Forms.CheckBox
    Friend WithEvents ReCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWikiFind As System.Windows.Forms.Button
    Friend WithEvents btnDbFind As System.Windows.Forms.Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnFwd As Button
End Class

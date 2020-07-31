<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddWikiIds
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddWikiIds))
        Me.dgvWikiIds = New System.Windows.Forms.DataGridView()
        Me.xId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xDob = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xShortDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xExclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.xAlternates = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.nudSelectCount = New System.Windows.Forms.NumericUpDown()
        Me.TxtFullName = New System.Windows.Forms.TextBox()
        Me.TxtDob = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtShortDesc = New System.Windows.Forms.TextBox()
        Me.BtnSingleUpdate = New System.Windows.Forms.Button()
        Me.LblId = New System.Windows.Forms.Label()
        Me.lbWikiIds = New System.Windows.Forms.ListBox()
        Me.txtWiki = New System.Windows.Forms.TextBox()
        Me.TxtUseThis = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvWikiIds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.nudSelectCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvWikiIds
        '
        Me.dgvWikiIds.AllowUserToAddRows = False
        Me.dgvWikiIds.AllowUserToDeleteRows = False
        Me.dgvWikiIds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWikiIds.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvWikiIds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWikiIds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.xId, Me.xName, Me.xDob, Me.xShortDesc, Me.xDesc, Me.xExclude, Me.xAlternates})
        Me.dgvWikiIds.Location = New System.Drawing.Point(14, 15)
        Me.dgvWikiIds.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvWikiIds.Name = "dgvWikiIds"
        Me.dgvWikiIds.RowHeadersVisible = False
        Me.dgvWikiIds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWikiIds.Size = New System.Drawing.Size(1168, 315)
        Me.dgvWikiIds.TabIndex = 18
        '
        'xId
        '
        Me.xId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xId.HeaderText = "Id"
        Me.xId.Name = "xId"
        Me.xId.ReadOnly = True
        Me.xId.Width = 50
        '
        'xName
        '
        Me.xName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xName.HeaderText = "Name"
        Me.xName.Name = "xName"
        Me.xName.ReadOnly = True
        Me.xName.Width = 200
        '
        'xDob
        '
        Me.xDob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xDob.HeaderText = "DoB"
        Me.xDob.Name = "xDob"
        '
        'xShortDesc
        '
        Me.xShortDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xShortDesc.HeaderText = "Desc"
        Me.xShortDesc.Name = "xShortDesc"
        Me.xShortDesc.Width = 150
        '
        'xDesc
        '
        Me.xDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xDesc.HeaderText = "WikiId"
        Me.xDesc.Name = "xDesc"
        Me.xDesc.Width = 200
        '
        'xExclude
        '
        Me.xExclude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xExclude.HeaderText = "Exclude"
        Me.xExclude.Name = "xExclude"
        '
        'xAlternates
        '
        Me.xAlternates.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.xAlternates.HeaderText = "Alternates"
        Me.xAlternates.Name = "xAlternates"
        Me.xAlternates.ReadOnly = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(1022, 487)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(162, 41)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BtnStart
        '
        Me.BtnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnStart.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnStart.Location = New System.Drawing.Point(12, 487)
        Me.BtnStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(106, 41)
        Me.BtnStart.TabIndex = 20
        Me.BtnStart.Text = "Start Check"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 532)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1196, 22)
        Me.StatusStrip1.TabIndex = 22
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(5, 17)
        '
        'nudSelectCount
        '
        Me.nudSelectCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudSelectCount.Location = New System.Drawing.Point(275, 496)
        Me.nudSelectCount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nudSelectCount.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudSelectCount.Name = "nudSelectCount"
        Me.nudSelectCount.Size = New System.Drawing.Size(65, 24)
        Me.nudSelectCount.TabIndex = 23
        '
        'TxtFullName
        '
        Me.TxtFullName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtFullName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFullName.Location = New System.Drawing.Point(14, 388)
        Me.TxtFullName.Name = "TxtFullName"
        Me.TxtFullName.Size = New System.Drawing.Size(344, 23)
        Me.TxtFullName.TabIndex = 25
        '
        'TxtDob
        '
        Me.TxtDob.AllowDrop = True
        Me.TxtDob.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtDob.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDob.Location = New System.Drawing.Point(364, 388)
        Me.TxtDob.Name = "TxtDob"
        Me.TxtDob.Size = New System.Drawing.Size(112, 23)
        Me.TxtDob.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(150, 498)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 22)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Selection Count"
        '
        'txtShortDesc
        '
        Me.txtShortDesc.AllowDrop = True
        Me.txtShortDesc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtShortDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortDesc.Location = New System.Drawing.Point(14, 420)
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Size = New System.Drawing.Size(462, 23)
        Me.txtShortDesc.TabIndex = 29
        '
        'BtnSingleUpdate
        '
        Me.BtnSingleUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSingleUpdate.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSingleUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSingleUpdate.Location = New System.Drawing.Point(1022, 353)
        Me.BtnSingleUpdate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnSingleUpdate.Name = "BtnSingleUpdate"
        Me.BtnSingleUpdate.Size = New System.Drawing.Size(162, 41)
        Me.BtnSingleUpdate.TabIndex = 30
        Me.BtnSingleUpdate.Text = "Single Update"
        Me.BtnSingleUpdate.UseVisualStyleBackColor = True
        '
        'LblId
        '
        Me.LblId.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblId.AutoSize = True
        Me.LblId.Font = New System.Drawing.Font("Papyrus", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.ForeColor = System.Drawing.Color.RoyalBlue
        Me.LblId.Location = New System.Drawing.Point(12, 353)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(17, 21)
        Me.LblId.TabIndex = 31
        Me.LblId.Text = "0"
        '
        'lbWikiIds
        '
        Me.lbWikiIds.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbWikiIds.FormattingEnabled = True
        Me.lbWikiIds.ItemHeight = 16
        Me.lbWikiIds.Location = New System.Drawing.Point(491, 337)
        Me.lbWikiIds.Name = "lbWikiIds"
        Me.lbWikiIds.Size = New System.Drawing.Size(224, 180)
        Me.lbWikiIds.TabIndex = 32
        '
        'txtWiki
        '
        Me.txtWiki.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWiki.Font = New System.Drawing.Font("Consolas", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWiki.Location = New System.Drawing.Point(721, 337)
        Me.txtWiki.Multiline = True
        Me.txtWiki.Name = "txtWiki"
        Me.txtWiki.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtWiki.Size = New System.Drawing.Size(269, 132)
        Me.txtWiki.TabIndex = 50
        '
        'TxtUseThis
        '
        Me.TxtUseThis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtUseThis.Location = New System.Drawing.Point(804, 487)
        Me.TxtUseThis.Name = "TxtUseThis"
        Me.TxtUseThis.Size = New System.Drawing.Size(186, 24)
        Me.TxtUseThis.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(721, 489)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 22)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Use this"
        '
        'FrmAddWikiIds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1196, 554)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUseThis)
        Me.Controls.Add(Me.txtWiki)
        Me.Controls.Add(Me.lbWikiIds)
        Me.Controls.Add(Me.LblId)
        Me.Controls.Add(Me.BtnSingleUpdate)
        Me.Controls.Add(Me.txtShortDesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFullName)
        Me.Controls.Add(Me.TxtDob)
        Me.Controls.Add(Me.nudSelectCount)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvWikiIds)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.BtnStart)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAddWikiIds"
        Me.Text = "Add Wiki Ids"
        CType(Me.dgvWikiIds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.nudSelectCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvWikiIds As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents nudSelectCount As NumericUpDown
    Friend WithEvents TxtFullName As TextBox
    Friend WithEvents TxtDob As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtShortDesc As TextBox
    Friend WithEvents xId As DataGridViewTextBoxColumn
    Friend WithEvents xName As DataGridViewTextBoxColumn
    Friend WithEvents xDob As DataGridViewTextBoxColumn
    Friend WithEvents xShortDesc As DataGridViewTextBoxColumn
    Friend WithEvents xDesc As DataGridViewTextBoxColumn
    Friend WithEvents xExclude As DataGridViewCheckBoxColumn
    Friend WithEvents xAlternates As DataGridViewTextBoxColumn
    Friend WithEvents BtnSingleUpdate As Button
    Friend WithEvents LblId As Label
    Friend WithEvents lbWikiIds As ListBox
    Friend WithEvents txtWiki As TextBox
    Friend WithEvents TxtUseThis As TextBox
    Friend WithEvents Label2 As Label
End Class

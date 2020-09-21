<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeathCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDeathCheck))
        Me.dgvWarnings = New System.Windows.Forms.DataGridView()
        Me.xId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xBirth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xDeath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnWrite = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvWarnings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvWarnings
        '
        Me.dgvWarnings.AllowUserToAddRows = False
        Me.dgvWarnings.AllowUserToDeleteRows = False
        Me.dgvWarnings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWarnings.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvWarnings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvWarnings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.xId, Me.xName, Me.xBirth, Me.xDeath, Me.xDesc})
        Me.dgvWarnings.Location = New System.Drawing.Point(12, 12)
        Me.dgvWarnings.Name = "dgvWarnings"
        Me.dgvWarnings.ReadOnly = True
        Me.dgvWarnings.RowHeadersVisible = False
        Me.dgvWarnings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvWarnings.Size = New System.Drawing.Size(1074, 469)
        Me.dgvWarnings.TabIndex = 0
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
        Me.xName.Width = 150
        '
        'xBirth
        '
        Me.xBirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xBirth.HeaderText = "Birth"
        Me.xBirth.Name = "xBirth"
        Me.xBirth.ReadOnly = True
        '
        'xDeath
        '
        Me.xDeath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xDeath.HeaderText = "Death"
        Me.xDeath.Name = "xDeath"
        Me.xDeath.ReadOnly = True
        '
        'xDesc
        '
        Me.xDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.xDesc.HeaderText = "Description"
        Me.xDesc.Name = "xDesc"
        Me.xDesc.ReadOnly = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(947, 500)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblCount, Me.ToolStripStatusLabel1, Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 536)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1098, 22)
        Me.StatusStrip1.TabIndex = 10
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
        'BtnStart
        '
        Me.BtnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStart.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnStart.Location = New System.Drawing.Point(236, 500)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(139, 33)
        Me.BtnStart.TabIndex = 11
        Me.BtnStart.Text = "Start Check"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'BtnWrite
        '
        Me.BtnWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWrite.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWrite.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWrite.Location = New System.Drawing.Point(445, 500)
        Me.BtnWrite.Name = "BtnWrite"
        Me.BtnWrite.Size = New System.Drawing.Size(139, 33)
        Me.BtnWrite.TabIndex = 12
        Me.BtnWrite.Text = "Write File"
        Me.BtnWrite.UseVisualStyleBackColor = True
        '
        'lblCount
        '
        Me.lblCount.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblCount.Size = New System.Drawing.Size(39, 17)
        Me.lblCount.Text = "0 of 0"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'FrmDeathCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1098, 558)
        Me.Controls.Add(Me.dgvWarnings)
        Me.Controls.Add(Me.BtnWrite)
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDeathCheck"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Who's Brown Bread"
        CType(Me.dgvWarnings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As Button
    Friend WithEvents dgvWarnings As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnWrite As Button
    Friend WithEvents xId As DataGridViewTextBoxColumn
    Friend WithEvents xName As DataGridViewTextBoxColumn
    Friend WithEvents xBirth As DataGridViewTextBoxColumn
    Friend WithEvents xDeath As DataGridViewTextBoxColumn
    Friend WithEvents xDesc As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblCount As ToolStripStatusLabel
End Class

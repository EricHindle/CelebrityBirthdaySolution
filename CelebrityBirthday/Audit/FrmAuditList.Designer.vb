<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAuditList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAuditList))
        Me.DgvAudit = New System.Windows.Forms.DataGridView()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LblDataType = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.aud_datatype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aud_before = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aud_after = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aud_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DgvAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvAudit
        '
        Me.DgvAudit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvAudit.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAudit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.aud_datatype, Me.aud_before, Me.aud_after, Me.aud_date})
        Me.DgvAudit.Location = New System.Drawing.Point(12, 52)
        Me.DgvAudit.Name = "DgvAudit"
        Me.DgvAudit.RowHeadersVisible = False
        Me.DgvAudit.Size = New System.Drawing.Size(724, 417)
        Me.DgvAudit.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.Controls.Add(Me.LblDataType)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.LblName)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(437, 34)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'LblDataType
        '
        Me.LblDataType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblDataType.AutoSize = True
        Me.LblDataType.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDataType.Location = New System.Drawing.Point(3, 0)
        Me.LblDataType.Name = "LblDataType"
        Me.LblDataType.Size = New System.Drawing.Size(116, 23)
        Me.LblDataType.TabIndex = 0
        Me.LblDataType.Text = "Date of birth"
        Me.LblDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "changes for"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblName
        '
        Me.LblName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(240, 0)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(120, 23)
        Me.LblName.TabIndex = 2
        Me.LblName.Text = "person name"
        Me.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(661, 475)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 38)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'aud_datatype
        '
        Me.aud_datatype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.aud_datatype.HeaderText = "Type"
        Me.aud_datatype.Name = "aud_datatype"
        Me.aud_datatype.Width = 120
        '
        'aud_before
        '
        Me.aud_before.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.aud_before.HeaderText = "Before"
        Me.aud_before.Name = "aud_before"
        '
        'aud_after
        '
        Me.aud_after.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.aud_after.HeaderText = "After"
        Me.aud_after.Name = "aud_after"
        '
        'aud_date
        '
        Me.aud_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.aud_date.HeaderText = "Change Date"
        Me.aud_date.Name = "aud_date"
        Me.aud_date.Width = 150
        '
        'FrmAuditList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(748, 525)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.DgvAudit)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAuditList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Audit List"
        CType(Me.DgvAudit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgvAudit As DataGridView
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents LblDataType As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblName As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents aud_datatype As DataGridViewTextBoxColumn
    Friend WithEvents aud_before As DataGridViewTextBoxColumn
    Friend WithEvents aud_after As DataGridViewTextBoxColumn
    Friend WithEvents aud_date As DataGridViewTextBoxColumn
End Class

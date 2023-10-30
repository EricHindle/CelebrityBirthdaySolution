' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReminders
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReminders))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DgvReminders = New System.Windows.Forms.DataGridView()
        Me.remId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remPersonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remNote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.BtnUpdatePerson = New System.Windows.Forms.Button()
        Me.LblPersonId = New System.Windows.Forms.Label()
        Me.TxtPerson = New System.Windows.Forms.TextBox()
        Me.cbName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RtbNote = New System.Windows.Forms.RichTextBox()
        Me.LblId = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DgvReminders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 332)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(644, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(2, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(9, 17)
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(258, 279)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(73, 38)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DgvReminders
        '
        Me.DgvReminders.AllowUserToAddRows = False
        Me.DgvReminders.AllowUserToDeleteRows = False
        Me.DgvReminders.BackgroundColor = System.Drawing.Color.SteelBlue
        Me.DgvReminders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvReminders.ColumnHeadersVisible = False
        Me.DgvReminders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.remId, Me.remPersonId, Me.remName, Me.remNote})
        Me.DgvReminders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvReminders.Location = New System.Drawing.Point(0, 0)
        Me.DgvReminders.MultiSelect = False
        Me.DgvReminders.Name = "DgvReminders"
        Me.DgvReminders.ReadOnly = True
        Me.DgvReminders.RowHeadersVisible = False
        Me.DgvReminders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvReminders.Size = New System.Drawing.Size(298, 328)
        Me.DgvReminders.TabIndex = 2
        '
        'remId
        '
        Me.remId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remId.HeaderText = "Id"
        Me.remId.Name = "remId"
        Me.remId.ReadOnly = True
        Me.remId.Visible = False
        Me.remId.Width = 50
        '
        'remPersonId
        '
        Me.remPersonId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remPersonId.HeaderText = "personId"
        Me.remPersonId.Name = "remPersonId"
        Me.remPersonId.ReadOnly = True
        Me.remPersonId.Width = 60
        '
        'remName
        '
        Me.remName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.remName.HeaderText = "Name"
        Me.remName.Name = "remName"
        Me.remName.ReadOnly = True
        Me.remName.Width = 150
        '
        'remNote
        '
        Me.remNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.remNote.HeaderText = "Note"
        Me.remNote.Name = "remNote"
        Me.remNote.ReadOnly = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DgvReminders)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnUpdatePerson)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RtbNote)
        Me.SplitContainer1.Panel2.Controls.Add(Me.LblId)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnClear)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnRemove)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnAdd)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BtnClose)
        Me.SplitContainer1.Size = New System.Drawing.Size(644, 332)
        Me.SplitContainer1.SplitterDistance = 302
        Me.SplitContainer1.TabIndex = 3
        '
        'BtnUpdatePerson
        '
        Me.BtnUpdatePerson.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnUpdatePerson.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnUpdatePerson.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpdatePerson.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnUpdatePerson.Location = New System.Drawing.Point(232, 7)
        Me.BtnUpdatePerson.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnUpdatePerson.Name = "BtnUpdatePerson"
        Me.BtnUpdatePerson.Size = New System.Drawing.Size(100, 28)
        Me.BtnUpdatePerson.TabIndex = 12
        Me.BtnUpdatePerson.Text = "Update Person"
        Me.BtnUpdatePerson.UseVisualStyleBackColor = True
        '
        'LblPersonId
        '
        Me.LblPersonId.AutoSize = True
        Me.LblPersonId.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPersonId.Location = New System.Drawing.Point(6, 54)
        Me.LblPersonId.Name = "LblPersonId"
        Me.LblPersonId.Size = New System.Drawing.Size(47, 17)
        Me.LblPersonId.TabIndex = 11
        Me.LblPersonId.Text = "Label3"
        '
        'TxtPerson
        '
        Me.TxtPerson.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPerson.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPerson.Location = New System.Drawing.Point(74, 21)
        Me.TxtPerson.Name = "TxtPerson"
        Me.TxtPerson.Size = New System.Drawing.Size(232, 24)
        Me.TxtPerson.TabIndex = 10
        '
        'cbName
        '
        Me.cbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbName.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbName.FormattingEnabled = True
        Me.cbName.Location = New System.Drawing.Point(88, 51)
        Me.cbName.Name = "cbName"
        Me.cbName.Size = New System.Drawing.Size(218, 24)
        Me.cbName.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Person:"
        '
        'RtbNote
        '
        Me.RtbNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RtbNote.Location = New System.Drawing.Point(5, 40)
        Me.RtbNote.Name = "RtbNote"
        Me.RtbNote.Size = New System.Drawing.Size(326, 147)
        Me.RtbNote.TabIndex = 7
        Me.RtbNote.Text = ""
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.Location = New System.Drawing.Point(99, 13)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(23, 17)
        Me.LblId.TabIndex = 6
        Me.LblId.Text = "-1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Reminder Id:"
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClear.Location = New System.Drawing.Point(181, 279)
        Me.BtnClear.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(73, 38)
        Me.BtnClear.TabIndex = 4
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'BtnRemove
        '
        Me.BtnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRemove.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnRemove.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRemove.Location = New System.Drawing.Point(82, 279)
        Me.BtnRemove.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 38)
        Me.BtnRemove.TabIndex = 3
        Me.BtnRemove.Text = "Remove"
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAdd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAdd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAdd.Location = New System.Drawing.Point(5, 279)
        Me.BtnAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 38)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbName)
        Me.GroupBox1.Controls.Add(Me.TxtPerson)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.LblPersonId)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 193)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 81)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Person Search"
        '
        'FrmReminders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(644, 354)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmReminders"
        Me.Text = "Reminders"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DgvReminders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents BtnClose As Button
    Friend WithEvents DgvReminders As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents RtbNote As RichTextBox
    Friend WithEvents LblId As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClear As Button
    Friend WithEvents BtnRemove As Button
    Friend WithEvents BtnAdd As Button
    Friend WithEvents cbName As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPerson As TextBox
    Friend WithEvents LblPersonId As Label
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents remId As DataGridViewTextBoxColumn
    Friend WithEvents remPersonId As DataGridViewTextBoxColumn
    Friend WithEvents remName As DataGridViewTextBoxColumn
    Friend WithEvents remNote As DataGridViewTextBoxColumn
    Friend WithEvents BtnUpdatePerson As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDeathList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDeathList))
        Me.DgvPeople = New System.Windows.Forms.DataGridView()
        Me.tId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tForename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tSurname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tDeathDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tDeathMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tDeathYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tYearsDead = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tShortDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tBirthDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tBirthMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tBirthYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tBirthPlace = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tBirthName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.nudYear = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ChkShowImage = New System.Windows.Forms.CheckBox()
        Me.BtnBBTweet = New System.Windows.Forms.Button()
        CType(Me.DgvPeople, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvPeople
        '
        Me.DgvPeople.AllowUserToAddRows = False
        Me.DgvPeople.AllowUserToDeleteRows = False
        Me.DgvPeople.AllowUserToResizeRows = False
        Me.DgvPeople.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPeople.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tId, Me.tForename, Me.tSurname, Me.tDeathDay, Me.tDeathMonth, Me.tDeathYear, Me.tYearsDead, Me.tAge, Me.tShortDesc, Me.tBirthDay, Me.tBirthMonth, Me.tBirthYear, Me.tBirthPlace, Me.tBirthName, Me.tImg})
        Me.DgvPeople.Location = New System.Drawing.Point(14, 13)
        Me.DgvPeople.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvPeople.MultiSelect = False
        Me.DgvPeople.Name = "DgvPeople"
        Me.DgvPeople.RowHeadersVisible = False
        Me.DgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPeople.Size = New System.Drawing.Size(1323, 487)
        Me.DgvPeople.TabIndex = 0
        '
        'tId
        '
        Me.tId.HeaderText = "Id"
        Me.tId.Name = "tId"
        Me.tId.Visible = False
        '
        'tForename
        '
        Me.tForename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tForename.HeaderText = "Forename"
        Me.tForename.Name = "tForename"
        '
        'tSurname
        '
        Me.tSurname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tSurname.HeaderText = "Surname"
        Me.tSurname.Name = "tSurname"
        '
        'tDeathDay
        '
        Me.tDeathDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tDeathDay.HeaderText = "Death Day"
        Me.tDeathDay.Name = "tDeathDay"
        Me.tDeathDay.Width = 50
        '
        'tDeathMonth
        '
        Me.tDeathMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tDeathMonth.HeaderText = "Death Month"
        Me.tDeathMonth.Name = "tDeathMonth"
        Me.tDeathMonth.Width = 50
        '
        'tDeathYear
        '
        Me.tDeathYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tDeathYear.HeaderText = "Death Year"
        Me.tDeathYear.Name = "tDeathYear"
        Me.tDeathYear.Width = 60
        '
        'tYearsDead
        '
        Me.tYearsDead.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tYearsDead.HeaderText = "Time Dead"
        Me.tYearsDead.Name = "tYearsDead"
        '
        'tAge
        '
        Me.tAge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tAge.HeaderText = "Age"
        Me.tAge.Name = "tAge"
        Me.tAge.Width = 50
        '
        'tShortDesc
        '
        Me.tShortDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.tShortDesc.HeaderText = "Description"
        Me.tShortDesc.Name = "tShortDesc"
        '
        'tBirthDay
        '
        Me.tBirthDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tBirthDay.HeaderText = "Birth Day"
        Me.tBirthDay.Name = "tBirthDay"
        Me.tBirthDay.Width = 50
        '
        'tBirthMonth
        '
        Me.tBirthMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tBirthMonth.HeaderText = "Birth Month"
        Me.tBirthMonth.Name = "tBirthMonth"
        Me.tBirthMonth.Width = 50
        '
        'tBirthYear
        '
        Me.tBirthYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tBirthYear.HeaderText = "Birth Year"
        Me.tBirthYear.Name = "tBirthYear"
        Me.tBirthYear.Width = 60
        '
        'tBirthPlace
        '
        Me.tBirthPlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tBirthPlace.HeaderText = "Birth Place"
        Me.tBirthPlace.Name = "tBirthPlace"
        Me.tBirthPlace.Width = 150
        '
        'tBirthName
        '
        Me.tBirthName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tBirthName.HeaderText = "Birth Name"
        Me.tBirthName.Name = "tBirthName"
        Me.tBirthName.Width = 150
        '
        'tImg
        '
        Me.tImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.tImg.HeaderText = "Img"
        Me.tImg.Name = "tImg"
        Me.tImg.ReadOnly = True
        Me.tImg.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tImg.Visible = False
        Me.tImg.Width = 65
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(1175, 506)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(162, 36)
        Me.BtnClose.TabIndex = 14
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSelect
        '
        Me.BtnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnSelect.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSelect.Location = New System.Drawing.Point(183, 508)
        Me.BtnSelect.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(162, 36)
        Me.BtnSelect.TabIndex = 15
        Me.BtnSelect.Text = "Select"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'nudYear
        '
        Me.nudYear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.nudYear.Location = New System.Drawing.Point(69, 516)
        Me.nudYear.Margin = New System.Windows.Forms.Padding(4)
        Me.nudYear.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(90, 22)
        Me.nudYear.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(29, 518)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Year"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 550)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1351, 22)
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(10, 17)
        '
        'ChkShowImage
        '
        Me.ChkShowImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkShowImage.AutoSize = True
        Me.ChkShowImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ChkShowImage.Location = New System.Drawing.Point(356, 518)
        Me.ChkShowImage.Name = "ChkShowImage"
        Me.ChkShowImage.Size = New System.Drawing.Size(100, 18)
        Me.ChkShowImage.TabIndex = 19
        Me.ChkShowImage.Text = "Show Images"
        Me.ChkShowImage.UseVisualStyleBackColor = True
        '
        'BtnBBTweet
        '
        Me.BtnBBTweet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnBBTweet.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBBTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBBTweet.Location = New System.Drawing.Point(515, 506)
        Me.BtnBBTweet.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnBBTweet.Name = "BtnBBTweet"
        Me.BtnBBTweet.Size = New System.Drawing.Size(162, 36)
        Me.BtnBBTweet.TabIndex = 20
        Me.BtnBBTweet.Text = "BB Tweet"
        Me.BtnBBTweet.UseVisualStyleBackColor = True
        '
        'FrmDeathList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1351, 572)
        Me.Controls.Add(Me.BtnBBTweet)
        Me.Controls.Add(Me.ChkShowImage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudYear)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.DgvPeople)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmDeathList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Death List"
        CType(Me.DgvPeople, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DgvPeople As DataGridView
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSelect As Button
    Friend WithEvents nudYear As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents tId As DataGridViewTextBoxColumn
    Friend WithEvents tForename As DataGridViewTextBoxColumn
    Friend WithEvents tSurname As DataGridViewTextBoxColumn
    Friend WithEvents tDeathDay As DataGridViewTextBoxColumn
    Friend WithEvents tDeathMonth As DataGridViewTextBoxColumn
    Friend WithEvents tDeathYear As DataGridViewTextBoxColumn
    Friend WithEvents tYearsDead As DataGridViewTextBoxColumn
    Friend WithEvents tAge As DataGridViewTextBoxColumn
    Friend WithEvents tShortDesc As DataGridViewTextBoxColumn
    Friend WithEvents tBirthDay As DataGridViewTextBoxColumn
    Friend WithEvents tBirthMonth As DataGridViewTextBoxColumn
    Friend WithEvents tBirthYear As DataGridViewTextBoxColumn
    Friend WithEvents tBirthPlace As DataGridViewTextBoxColumn
    Friend WithEvents tBirthName As DataGridViewTextBoxColumn
    Friend WithEvents tImg As DataGridViewImageColumn
    Friend WithEvents ChkShowImage As CheckBox
    Friend WithEvents BtnBBTweet As Button
End Class

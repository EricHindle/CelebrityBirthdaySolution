﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSearch))
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.DgvPeople = New System.Windows.Forms.DataGridView()
        Me.SelPersonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selPersonDay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selPersonMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelPersonYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelPersonForename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelPersonSurname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xImg = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnSearchByName = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BtnFindInWiki = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnDbUpdate = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnWordPress = New System.Windows.Forms.Button()
        Me.BtnTweet = New System.Windows.Forms.Button()
        Me.BtnImgUpdate = New System.Windows.Forms.Button()
        Me.BtnPasteName = New System.Windows.Forms.Button()
        Me.ChkShowImage = New System.Windows.Forms.CheckBox()
        CType(Me.DgvPeople, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtForename
        '
        Me.TxtForename.AllowDrop = True
        Me.TxtForename.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForename.Location = New System.Drawing.Point(82, 12)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(310, 22)
        Me.TxtForename.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Id"
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(82, 49)
        Me.txtId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(135, 22)
        Me.txtId.TabIndex = 2
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
        Me.DgvPeople.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelPersonId, Me.selPersonDay, Me.selPersonMonth, Me.SelPersonYear, Me.SelPersonForename, Me.SelPersonSurname, Me.selDesc, Me.xImg})
        Me.DgvPeople.Location = New System.Drawing.Point(23, 92)
        Me.DgvPeople.MultiSelect = False
        Me.DgvPeople.Name = "DgvPeople"
        Me.DgvPeople.ReadOnly = True
        Me.DgvPeople.RowHeadersVisible = False
        Me.DgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPeople.Size = New System.Drawing.Size(1030, 434)
        Me.DgvPeople.TabIndex = 10
        '
        'SelPersonId
        '
        Me.SelPersonId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SelPersonId.HeaderText = "Id"
        Me.SelPersonId.Name = "SelPersonId"
        Me.SelPersonId.ReadOnly = True
        Me.SelPersonId.Width = 50
        '
        'selPersonDay
        '
        Me.selPersonDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.selPersonDay.HeaderText = "Day"
        Me.selPersonDay.Name = "selPersonDay"
        Me.selPersonDay.ReadOnly = True
        Me.selPersonDay.Width = 50
        '
        'selPersonMonth
        '
        Me.selPersonMonth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.selPersonMonth.HeaderText = "Month"
        Me.selPersonMonth.Name = "selPersonMonth"
        Me.selPersonMonth.ReadOnly = True
        Me.selPersonMonth.Width = 50
        '
        'SelPersonYear
        '
        Me.SelPersonYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SelPersonYear.HeaderText = "Year"
        Me.SelPersonYear.Name = "SelPersonYear"
        Me.SelPersonYear.ReadOnly = True
        Me.SelPersonYear.Width = 50
        '
        'SelPersonForename
        '
        Me.SelPersonForename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SelPersonForename.HeaderText = "Forename"
        Me.SelPersonForename.Name = "SelPersonForename"
        Me.SelPersonForename.ReadOnly = True
        Me.SelPersonForename.Width = 200
        '
        'SelPersonSurname
        '
        Me.SelPersonSurname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SelPersonSurname.HeaderText = "Surname"
        Me.SelPersonSurname.Name = "SelPersonSurname"
        Me.SelPersonSurname.ReadOnly = True
        Me.SelPersonSurname.Width = 200
        '
        'selDesc
        '
        Me.selDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.selDesc.HeaderText = "Description"
        Me.selDesc.Name = "selDesc"
        Me.selDesc.ReadOnly = True
        '
        'xImg
        '
        Me.xImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.xImg.HeaderText = "Img"
        Me.xImg.Name = "xImg"
        Me.xImg.ReadOnly = True
        Me.xImg.Visible = False
        Me.xImg.Width = 65
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(1081, 481)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(117, 45)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSearchByName
        '
        Me.BtnSearchByName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearchByName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSearchByName.Location = New System.Drawing.Point(15, 28)
        Me.BtnSearchByName.Name = "BtnSearchByName"
        Me.BtnSearchByName.Size = New System.Drawing.Size(107, 54)
        Me.BtnSearchByName.TabIndex = 0
        Me.BtnSearchByName.Text = "SEARCH"
        Me.BtnSearchByName.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnSearchByName)
        Me.GroupBox1.Location = New System.Drawing.Point(1066, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(135, 94)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Database Search"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtnFindInWiki)
        Me.GroupBox2.Location = New System.Drawing.Point(1066, 214)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(135, 63)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Wiki Search"
        '
        'BtnFindInWiki
        '
        Me.BtnFindInWiki.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFindInWiki.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnFindInWiki.Location = New System.Drawing.Point(15, 19)
        Me.BtnFindInWiki.Name = "BtnFindInWiki"
        Me.BtnFindInWiki.Size = New System.Drawing.Size(107, 36)
        Me.BtnFindInWiki.TabIndex = 0
        Me.BtnFindInWiki.Text = "Search by name"
        Me.BtnFindInWiki.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 544)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1213, 22)
        Me.StatusStrip1.TabIndex = 0
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
        'BtnDbUpdate
        '
        Me.BtnDbUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDbUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDbUpdate.Location = New System.Drawing.Point(15, 19)
        Me.BtnDbUpdate.Name = "BtnDbUpdate"
        Me.BtnDbUpdate.Size = New System.Drawing.Size(107, 36)
        Me.BtnDbUpdate.TabIndex = 0
        Me.BtnDbUpdate.Text = "Database"
        Me.BtnDbUpdate.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClear.Location = New System.Drawing.Point(1081, 12)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(107, 36)
        Me.BtnClear.TabIndex = 4
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.BtnWordPress)
        Me.GroupBox3.Controls.Add(Me.BtnTweet)
        Me.GroupBox3.Controls.Add(Me.BtnImgUpdate)
        Me.GroupBox3.Controls.Add(Me.BtnDbUpdate)
        Me.GroupBox3.Location = New System.Drawing.Point(1066, 283)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(135, 192)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Open form"
        '
        'BtnWordPress
        '
        Me.BtnWordPress.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWordPress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWordPress.Location = New System.Drawing.Point(15, 145)
        Me.BtnWordPress.Name = "BtnWordPress"
        Me.BtnWordPress.Size = New System.Drawing.Size(107, 36)
        Me.BtnWordPress.TabIndex = 3
        Me.BtnWordPress.Text = "WordPress"
        Me.BtnWordPress.UseVisualStyleBackColor = True
        '
        'BtnTweet
        '
        Me.BtnTweet.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTweet.Location = New System.Drawing.Point(15, 103)
        Me.BtnTweet.Name = "BtnTweet"
        Me.BtnTweet.Size = New System.Drawing.Size(107, 36)
        Me.BtnTweet.TabIndex = 2
        Me.BtnTweet.Text = "Twitter"
        Me.BtnTweet.UseVisualStyleBackColor = True
        '
        'BtnImgUpdate
        '
        Me.BtnImgUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImgUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImgUpdate.Location = New System.Drawing.Point(15, 61)
        Me.BtnImgUpdate.Name = "BtnImgUpdate"
        Me.BtnImgUpdate.Size = New System.Drawing.Size(107, 36)
        Me.BtnImgUpdate.TabIndex = 1
        Me.BtnImgUpdate.Text = "Image"
        Me.BtnImgUpdate.UseVisualStyleBackColor = True
        '
        'BtnPasteName
        '
        Me.BtnPasteName.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.paste
        Me.BtnPasteName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnPasteName.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPasteName.Location = New System.Drawing.Point(398, 7)
        Me.BtnPasteName.Name = "BtnPasteName"
        Me.BtnPasteName.Size = New System.Drawing.Size(30, 30)
        Me.BtnPasteName.TabIndex = 6
        Me.BtnPasteName.Text = "<"
        Me.BtnPasteName.UseVisualStyleBackColor = True
        '
        'ChkShowImage
        '
        Me.ChkShowImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkShowImage.AutoSize = True
        Me.ChkShowImage.Location = New System.Drawing.Point(1098, 54)
        Me.ChkShowImage.Name = "ChkShowImage"
        Me.ChkShowImage.Size = New System.Drawing.Size(90, 17)
        Me.ChkShowImage.TabIndex = 11
        Me.ChkShowImage.Text = "Show Images"
        Me.ChkShowImage.UseVisualStyleBackColor = True
        '
        'FrmSearch
        '
        Me.AcceptButton = Me.BtnSearchByName
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1213, 566)
        Me.Controls.Add(Me.ChkShowImage)
        Me.Controls.Add(Me.BtnPasteName)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.DgvPeople)
        Me.Controls.Add(Me.BtnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSearch"
        Me.Text = "Search"
        CType(Me.DgvPeople, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtForename As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents DgvPeople As DataGridView
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnSearchByName As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnFindInWiki As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents BtnDbUpdate As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents BtnImgUpdate As Button
    Friend WithEvents BtnTweet As Button
    Friend WithEvents BtnWordPress As Button
    Friend WithEvents BtnPasteName As Button
    Friend WithEvents ChkShowImage As CheckBox
    Friend WithEvents SelPersonId As DataGridViewTextBoxColumn
    Friend WithEvents selPersonDay As DataGridViewTextBoxColumn
    Friend WithEvents selPersonMonth As DataGridViewTextBoxColumn
    Friend WithEvents SelPersonYear As DataGridViewTextBoxColumn
    Friend WithEvents SelPersonForename As DataGridViewTextBoxColumn
    Friend WithEvents SelPersonSurname As DataGridViewTextBoxColumn
    Friend WithEvents selDesc As DataGridViewTextBoxColumn
    Friend WithEvents xImg As DataGridViewImageColumn
End Class

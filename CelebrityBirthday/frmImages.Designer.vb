<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmImages
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImages))
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.ListBoxPeople = New System.Windows.Forms.ListBox()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnPicSave = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.txtLoadYr = New System.Windows.Forms.TextBox()
        Me.txtLoadMth = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnLoadDateUpdate = New System.Windows.Forms.Button()
        Me.cbImgType = New System.Windows.Forms.ComboBox()
        Me.BtnMakeImgName = New System.Windows.Forms.Button()
        Me.txtImgName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnFindImage = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.DgvPeople = New System.Windows.Forms.DataGridView()
        Me.SelPersonId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelPersonYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SelPersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSearchByName = New System.Windows.Forms.Button()
        Me.BtnSearchById = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.lblImgDateMsg = New System.Windows.Forms.Label()
        Me.TxtImageUrl = New System.Windows.Forms.TextBox()
        Me.TxtImageFilename = New System.Windows.Forms.TextBox()
        Me.BtnUrlCopy = New System.Windows.Forms.Button()
        Me.BtnFilenameCopy = New System.Windows.Forms.Button()
        Me.TxtWpLoadYear = New System.Windows.Forms.TextBox()
        Me.TxtWpLoadMth = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblWpDateMsg = New System.Windows.Forms.Label()
        Me.BtnWpImageRefresh = New System.Windows.Forms.Button()
        Me.BtnFileImageRefresh = New System.Windows.Forms.Button()
        Me.BtnWpImgGen = New System.Windows.Forms.Button()
        Me.BtnFileImgGen = New System.Windows.Forms.Button()
        Me.BtnCopyLoadDate = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPeople, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDay
        '
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(30, 13)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(82, 27)
        Me.cboDay.TabIndex = 0
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(120, 13)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(206, 27)
        Me.cboMonth.TabIndex = 1
        '
        'ListBoxPeople
        '
        Me.ListBoxPeople.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListBoxPeople.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBoxPeople.FormattingEnabled = True
        Me.ListBoxPeople.ItemHeight = 18
        Me.ListBoxPeople.Location = New System.Drawing.Point(30, 48)
        Me.ListBoxPeople.Name = "ListBoxPeople"
        Me.ListBoxPeople.Size = New System.Drawing.Size(295, 400)
        Me.ListBoxPeople.TabIndex = 18
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(856, 564)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(117, 45)
        Me.BtnClose.TabIndex = 17
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(360, 249)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(360, 377)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 131
        Me.PictureBox2.TabStop = False
        '
        'BtnPicSave
        '
        Me.BtnPicSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPicSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPicSave.Location = New System.Drawing.Point(910, 270)
        Me.BtnPicSave.Name = "BtnPicSave"
        Me.BtnPicSave.Size = New System.Drawing.Size(63, 97)
        Me.BtnPicSave.TabIndex = 13
        Me.BtnPicSave.Text = "Save Image to File"
        Me.BtnPicSave.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(340, 219)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Image from Wordpress"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(340, 349)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Image from file"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(337, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Name"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Location = New System.Drawing.Point(346, 701)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(82, 70)
        Me.PictureBox3.TabIndex = 130
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Location = New System.Drawing.Point(476, 701)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(82, 70)
        Me.PictureBox4.TabIndex = 131
        Me.PictureBox4.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(346, 776)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 27)
        Me.Button1.TabIndex = 127
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(307, 701)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Wp"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(436, 701)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "File"
        '
        'TxtForename
        '
        Me.TxtForename.AllowDrop = True
        Me.TxtForename.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForename.Location = New System.Drawing.Point(402, 55)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(310, 22)
        Me.TxtForename.TabIndex = 4
        '
        'txtLoadYr
        '
        Me.txtLoadYr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadYr.Location = New System.Drawing.Point(558, 175)
        Me.txtLoadYr.Name = "txtLoadYr"
        Me.txtLoadYr.Size = New System.Drawing.Size(95, 22)
        Me.txtLoadYr.TabIndex = 11
        '
        'txtLoadMth
        '
        Me.txtLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMth.Location = New System.Drawing.Point(490, 175)
        Me.txtLoadMth.Name = "txtLoadMth"
        Me.txtLoadMth.Size = New System.Drawing.Size(46, 22)
        Me.txtLoadMth.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(337, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 14)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Image Load Date"
        '
        'BtnLoadDateUpdate
        '
        Me.BtnLoadDateUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadDateUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadDateUpdate.Location = New System.Drawing.Point(886, 99)
        Me.BtnLoadDateUpdate.Name = "BtnLoadDateUpdate"
        Me.BtnLoadDateUpdate.Size = New System.Drawing.Size(87, 65)
        Me.BtnLoadDateUpdate.TabIndex = 12
        Me.BtnLoadDateUpdate.Text = "Update Image Data"
        Me.BtnLoadDateUpdate.UseVisualStyleBackColor = True
        '
        'cbImgType
        '
        Me.cbImgType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImgType.FormattingEnabled = True
        Me.cbImgType.Items.AddRange(New Object() {".jpg", ".bmp", ".gif", ".png", ".jpeg"})
        Me.cbImgType.Location = New System.Drawing.Point(433, 133)
        Me.cbImgType.Name = "cbImgType"
        Me.cbImgType.Size = New System.Drawing.Size(103, 22)
        Me.cbImgType.TabIndex = 9
        '
        'BtnMakeImgName
        '
        Me.BtnMakeImgName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMakeImgName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMakeImgName.Location = New System.Drawing.Point(806, 97)
        Me.BtnMakeImgName.Name = "BtnMakeImgName"
        Me.BtnMakeImgName.Size = New System.Drawing.Size(28, 28)
        Me.BtnMakeImgName.TabIndex = 7
        Me.BtnMakeImgName.Text = "<"
        Me.BtnMakeImgName.UseVisualStyleBackColor = True
        '
        'txtImgName
        '
        Me.txtImgName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImgName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImgName.Location = New System.Drawing.Point(433, 101)
        Me.txtImgName.Name = "txtImgName"
        Me.txtImgName.Size = New System.Drawing.Size(355, 22)
        Me.txtImgName.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(337, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 14)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Image Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(337, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Image Name"
        '
        'BtnFindImage
        '
        Me.BtnFindImage.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFindImage.Location = New System.Drawing.Point(346, 524)
        Me.BtnFindImage.Name = "BtnFindImage"
        Me.BtnFindImage.Size = New System.Drawing.Size(108, 85)
        Me.BtnFindImage.TabIndex = 14
        Me.BtnFindImage.Text = "Find an Image for Person"
        Me.BtnFindImage.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(337, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 14)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Id"
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(402, 18)
        Me.txtId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(135, 22)
        Me.txtId.TabIndex = 2
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Location = New System.Drawing.Point(886, 16)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(87, 25)
        Me.BtnClear.TabIndex = 3
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'DgvPeople
        '
        Me.DgvPeople.AllowUserToAddRows = False
        Me.DgvPeople.AllowUserToDeleteRows = False
        Me.DgvPeople.AllowUserToResizeRows = False
        Me.DgvPeople.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPeople.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelPersonId, Me.SelPersonYear, Me.SelPersonName})
        Me.DgvPeople.Location = New System.Drawing.Point(29, 456)
        Me.DgvPeople.MultiSelect = False
        Me.DgvPeople.Name = "DgvPeople"
        Me.DgvPeople.ReadOnly = True
        Me.DgvPeople.RowHeadersVisible = False
        Me.DgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPeople.Size = New System.Drawing.Size(296, 153)
        Me.DgvPeople.TabIndex = 19
        '
        'SelPersonId
        '
        Me.SelPersonId.HeaderText = "Id"
        Me.SelPersonId.Name = "SelPersonId"
        Me.SelPersonId.ReadOnly = True
        Me.SelPersonId.Width = 50
        '
        'SelPersonYear
        '
        Me.SelPersonYear.HeaderText = "Year"
        Me.SelPersonYear.Name = "SelPersonYear"
        Me.SelPersonYear.ReadOnly = True
        Me.SelPersonYear.Width = 50
        '
        'SelPersonName
        '
        Me.SelPersonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SelPersonName.HeaderText = "Name"
        Me.SelPersonName.Name = "SelPersonName"
        Me.SelPersonName.ReadOnly = True
        '
        'BtnSearchByName
        '
        Me.BtnSearchByName.Location = New System.Drawing.Point(651, 568)
        Me.BtnSearchByName.Name = "BtnSearchByName"
        Me.BtnSearchByName.Size = New System.Drawing.Size(107, 36)
        Me.BtnSearchByName.TabIndex = 16
        Me.BtnSearchByName.Text = "Search by name"
        Me.BtnSearchByName.UseVisualStyleBackColor = True
        '
        'BtnSearchById
        '
        Me.BtnSearchById.Location = New System.Drawing.Point(512, 568)
        Me.BtnSearchById.Name = "BtnSearchById"
        Me.BtnSearchById.Size = New System.Drawing.Size(107, 36)
        Me.BtnSearchById.TabIndex = 15
        Me.BtnSearchById.Text = "Search by id"
        Me.BtnSearchById.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 627)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(987, 22)
        Me.StatusStrip1.TabIndex = 29
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 17)
        '
        'TxtSurname
        '
        Me.TxtSurname.AllowDrop = True
        Me.TxtSurname.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSurname.Location = New System.Drawing.Point(719, 55)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(238, 22)
        Me.TxtSurname.TabIndex = 5
        '
        'lblImgDateMsg
        '
        Me.lblImgDateMsg.AutoSize = True
        Me.lblImgDateMsg.Location = New System.Drawing.Point(751, 179)
        Me.lblImgDateMsg.Name = "lblImgDateMsg"
        Me.lblImgDateMsg.Size = New System.Drawing.Size(131, 14)
        Me.lblImgDateMsg.TabIndex = 134
        Me.lblImgDateMsg.Text = "** No image load date"
        '
        'TxtImageUrl
        '
        Me.TxtImageUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImageUrl.Location = New System.Drawing.Point(452, 257)
        Me.TxtImageUrl.Name = "TxtImageUrl"
        Me.TxtImageUrl.Size = New System.Drawing.Size(396, 22)
        Me.TxtImageUrl.TabIndex = 139
        '
        'TxtImageFilename
        '
        Me.TxtImageFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImageFilename.Location = New System.Drawing.Point(452, 375)
        Me.TxtImageFilename.Name = "TxtImageFilename"
        Me.TxtImageFilename.Size = New System.Drawing.Size(396, 22)
        Me.TxtImageFilename.TabIndex = 140
        '
        'BtnUrlCopy
        '
        Me.BtnUrlCopy.Image = Global.CelebrityBirthday.My.Resources.Resources.copyicon
        Me.BtnUrlCopy.Location = New System.Drawing.Point(452, 285)
        Me.BtnUrlCopy.Name = "BtnUrlCopy"
        Me.BtnUrlCopy.Size = New System.Drawing.Size(33, 33)
        Me.BtnUrlCopy.TabIndex = 141
        Me.BtnUrlCopy.UseVisualStyleBackColor = True
        '
        'BtnFilenameCopy
        '
        Me.BtnFilenameCopy.Image = Global.CelebrityBirthday.My.Resources.Resources.copyicon
        Me.BtnFilenameCopy.Location = New System.Drawing.Point(452, 405)
        Me.BtnFilenameCopy.Name = "BtnFilenameCopy"
        Me.BtnFilenameCopy.Size = New System.Drawing.Size(33, 33)
        Me.BtnFilenameCopy.TabIndex = 142
        Me.BtnFilenameCopy.UseVisualStyleBackColor = True
        '
        'TxtWpLoadYear
        '
        Me.TxtWpLoadYear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWpLoadYear.Location = New System.Drawing.Point(558, 481)
        Me.TxtWpLoadYear.Name = "TxtWpLoadYear"
        Me.TxtWpLoadYear.Size = New System.Drawing.Size(95, 22)
        Me.TxtWpLoadYear.TabIndex = 136
        '
        'TxtWpLoadMth
        '
        Me.TxtWpLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWpLoadMth.Location = New System.Drawing.Point(490, 481)
        Me.TxtWpLoadMth.Name = "TxtWpLoadMth"
        Me.TxtWpLoadMth.Size = New System.Drawing.Size(46, 22)
        Me.TxtWpLoadMth.TabIndex = 135
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(337, 484)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 14)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Wordpress Load Date"
        '
        'lblWpDateMsg
        '
        Me.lblWpDateMsg.AutoSize = True
        Me.lblWpDateMsg.Location = New System.Drawing.Point(691, 485)
        Me.lblWpDateMsg.Name = "lblWpDateMsg"
        Me.lblWpDateMsg.Size = New System.Drawing.Size(157, 14)
        Me.lblWpDateMsg.TabIndex = 138
        Me.lblWpDateMsg.Text = "** No Wordpress load date"
        '
        'BtnWpImageRefresh
        '
        Me.BtnWpImageRefresh.Image = Global.CelebrityBirthday.My.Resources.Resources.refresh
        Me.BtnWpImageRefresh.Location = New System.Drawing.Point(512, 285)
        Me.BtnWpImageRefresh.Name = "BtnWpImageRefresh"
        Me.BtnWpImageRefresh.Size = New System.Drawing.Size(33, 33)
        Me.BtnWpImageRefresh.TabIndex = 143
        Me.BtnWpImageRefresh.UseVisualStyleBackColor = True
        '
        'BtnFileImageRefresh
        '
        Me.BtnFileImageRefresh.Image = Global.CelebrityBirthday.My.Resources.Resources.refresh
        Me.BtnFileImageRefresh.Location = New System.Drawing.Point(512, 405)
        Me.BtnFileImageRefresh.Name = "BtnFileImageRefresh"
        Me.BtnFileImageRefresh.Size = New System.Drawing.Size(33, 33)
        Me.BtnFileImageRefresh.TabIndex = 144
        Me.BtnFileImageRefresh.UseVisualStyleBackColor = True
        '
        'BtnWpImgGen
        '
        Me.BtnWpImgGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWpImgGen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWpImgGen.Location = New System.Drawing.Point(854, 253)
        Me.BtnWpImgGen.Name = "BtnWpImgGen"
        Me.BtnWpImgGen.Size = New System.Drawing.Size(28, 28)
        Me.BtnWpImgGen.TabIndex = 145
        Me.BtnWpImgGen.Text = "<"
        Me.BtnWpImgGen.UseVisualStyleBackColor = True
        '
        'BtnFileImgGen
        '
        Me.BtnFileImgGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFileImgGen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFileImgGen.Location = New System.Drawing.Point(854, 371)
        Me.BtnFileImgGen.Name = "BtnFileImgGen"
        Me.BtnFileImgGen.Size = New System.Drawing.Size(28, 28)
        Me.BtnFileImgGen.TabIndex = 146
        Me.BtnFileImgGen.Text = "<"
        Me.BtnFileImgGen.UseVisualStyleBackColor = True
        '
        'BtnCopyLoadDate
        '
        Me.BtnCopyLoadDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyLoadDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyLoadDate.Location = New System.Drawing.Point(684, 171)
        Me.BtnCopyLoadDate.Name = "BtnCopyLoadDate"
        Me.BtnCopyLoadDate.Size = New System.Drawing.Size(28, 28)
        Me.BtnCopyLoadDate.TabIndex = 147
        Me.BtnCopyLoadDate.Text = "<"
        Me.BtnCopyLoadDate.UseVisualStyleBackColor = True
        '
        'FrmImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(987, 649)
        Me.Controls.Add(Me.BtnCopyLoadDate)
        Me.Controls.Add(Me.BtnFileImgGen)
        Me.Controls.Add(Me.BtnWpImgGen)
        Me.Controls.Add(Me.BtnFileImageRefresh)
        Me.Controls.Add(Me.BtnWpImageRefresh)
        Me.Controls.Add(Me.BtnFilenameCopy)
        Me.Controls.Add(Me.BtnUrlCopy)
        Me.Controls.Add(Me.TxtImageFilename)
        Me.Controls.Add(Me.TxtImageUrl)
        Me.Controls.Add(Me.lblWpDateMsg)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtWpLoadMth)
        Me.Controls.Add(Me.TxtWpLoadYear)
        Me.Controls.Add(Me.lblImgDateMsg)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSearchById)
        Me.Controls.Add(Me.BtnFindImage)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.DgvPeople)
        Me.Controls.Add(Me.cbImgType)
        Me.Controls.Add(Me.BtnMakeImgName)
        Me.Controls.Add(Me.txtImgName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnSearchByName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ListBoxPeople)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnLoadDateUpdate)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLoadMth)
        Me.Controls.Add(Me.BtnPicSave)
        Me.Controls.Add(Me.txtLoadYr)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtForename)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmImages"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Images"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPeople, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents ListBoxPeople As ListBox
    Friend WithEvents BtnClose As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents BtnPicSave As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents txtLoadYr As TextBox
    Friend WithEvents txtLoadMth As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtnLoadDateUpdate As Button
    Friend WithEvents cbImgType As ComboBox
    Friend WithEvents BtnMakeImgName As Button
    Friend WithEvents txtImgName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnFindImage As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents BtnClear As Button
    Friend WithEvents DgvPeople As DataGridView
    Friend WithEvents BtnSearchByName As Button
    Friend WithEvents BtnSearchById As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents SelPersonId As DataGridViewTextBoxColumn
    Friend WithEvents SelPersonYear As DataGridViewTextBoxColumn
    Friend WithEvents SelPersonName As DataGridViewTextBoxColumn
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents lblImgDateMsg As Label
    Friend WithEvents TxtImageUrl As TextBox
    Friend WithEvents TxtImageFilename As TextBox
    Friend WithEvents BtnUrlCopy As Button
    Friend WithEvents BtnFilenameCopy As Button
    Friend WithEvents TxtWpLoadYear As TextBox
    Friend WithEvents TxtWpLoadMth As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents lblWpDateMsg As Label
    Friend WithEvents BtnWpImageRefresh As Button
    Friend WithEvents BtnFileImageRefresh As Button
    Friend WithEvents BtnWpImgGen As Button
    Friend WithEvents BtnFileImgGen As Button
    Friend WithEvents BtnCopyLoadDate As Button
End Class

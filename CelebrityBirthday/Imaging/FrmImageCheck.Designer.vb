<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImageCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImageCheck))
        Me.DgvMissingImages = New System.Windows.Forms.DataGridView()
        Me.personId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PersonName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.personError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnCopyLoadDate = New System.Windows.Forms.Button()
        Me.BtnFileImgGen = New System.Windows.Forms.Button()
        Me.BtnWpImgGen = New System.Windows.Forms.Button()
        Me.BtnFileImageRefresh = New System.Windows.Forms.Button()
        Me.BtnWpImageRefresh = New System.Windows.Forms.Button()
        Me.TxtImageFilename = New System.Windows.Forms.TextBox()
        Me.TxtImageUrl = New System.Windows.Forms.TextBox()
        Me.lblWpDateMsg = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtWpLoadMth = New System.Windows.Forms.TextBox()
        Me.TxtWpLoadYear = New System.Windows.Forms.TextBox()
        Me.lblImgDateMsg = New System.Windows.Forms.Label()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.BtnFindImage = New System.Windows.Forms.Button()
        Me.cbImgType = New System.Windows.Forms.ComboBox()
        Me.BtnMakeImgName = New System.Windows.Forms.Button()
        Me.txtImgName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnLoadDateUpdate = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLoadMth = New System.Windows.Forms.TextBox()
        Me.BtnPicSave = New System.Windows.Forms.Button()
        Me.txtLoadYr = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.DgvMissingImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvMissingImages
        '
        Me.DgvMissingImages.AllowUserToAddRows = False
        Me.DgvMissingImages.AllowUserToDeleteRows = False
        Me.DgvMissingImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvMissingImages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.personId, Me.PersonName, Me.personError})
        Me.DgvMissingImages.Location = New System.Drawing.Point(11, 12)
        Me.DgvMissingImages.Name = "DgvMissingImages"
        Me.DgvMissingImages.ReadOnly = True
        Me.DgvMissingImages.RowHeadersVisible = False
        Me.DgvMissingImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvMissingImages.Size = New System.Drawing.Size(180, 568)
        Me.DgvMissingImages.TabIndex = 1
        '
        'personId
        '
        Me.personId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.personId.HeaderText = "Id"
        Me.personId.Name = "personId"
        Me.personId.ReadOnly = True
        Me.personId.Visible = False
        '
        'PersonName
        '
        Me.PersonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PersonName.HeaderText = "Name"
        Me.PersonName.Name = "PersonName"
        Me.PersonName.ReadOnly = True
        Me.PersonName.Visible = False
        '
        'personError
        '
        Me.personError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.personError.HeaderText = "Err"
        Me.personError.Name = "personError"
        Me.personError.ReadOnly = True
        Me.personError.Visible = False
        '
        'BtnCopyLoadDate
        '
        Me.BtnCopyLoadDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCopyLoadDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCopyLoadDate.Location = New System.Drawing.Point(591, 166)
        Me.BtnCopyLoadDate.Name = "BtnCopyLoadDate"
        Me.BtnCopyLoadDate.Size = New System.Drawing.Size(28, 28)
        Me.BtnCopyLoadDate.TabIndex = 185
        Me.BtnCopyLoadDate.Text = "<"
        Me.BtnCopyLoadDate.UseVisualStyleBackColor = True
        '
        'BtnFileImgGen
        '
        Me.BtnFileImgGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFileImgGen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFileImgGen.Location = New System.Drawing.Point(747, 366)
        Me.BtnFileImgGen.Name = "BtnFileImgGen"
        Me.BtnFileImgGen.Size = New System.Drawing.Size(28, 28)
        Me.BtnFileImgGen.TabIndex = 184
        Me.BtnFileImgGen.Text = "<"
        Me.BtnFileImgGen.UseVisualStyleBackColor = True
        '
        'BtnWpImgGen
        '
        Me.BtnWpImgGen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnWpImgGen.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWpImgGen.Location = New System.Drawing.Point(747, 248)
        Me.BtnWpImgGen.Name = "BtnWpImgGen"
        Me.BtnWpImgGen.Size = New System.Drawing.Size(28, 28)
        Me.BtnWpImgGen.TabIndex = 183
        Me.BtnWpImgGen.Text = "<"
        Me.BtnWpImgGen.UseVisualStyleBackColor = True
        '
        'BtnFileImageRefresh
        '
        Me.BtnFileImageRefresh.Image = Global.CelebrityBirthday.My.Resources.Resources.refresh
        Me.BtnFileImageRefresh.Location = New System.Drawing.Point(332, 400)
        Me.BtnFileImageRefresh.Name = "BtnFileImageRefresh"
        Me.BtnFileImageRefresh.Size = New System.Drawing.Size(33, 33)
        Me.BtnFileImageRefresh.TabIndex = 182
        Me.BtnFileImageRefresh.UseVisualStyleBackColor = True
        '
        'BtnWpImageRefresh
        '
        Me.BtnWpImageRefresh.Image = Global.CelebrityBirthday.My.Resources.Resources.refresh
        Me.BtnWpImageRefresh.Location = New System.Drawing.Point(332, 283)
        Me.BtnWpImageRefresh.Name = "BtnWpImageRefresh"
        Me.BtnWpImageRefresh.Size = New System.Drawing.Size(33, 33)
        Me.BtnWpImageRefresh.TabIndex = 181
        Me.BtnWpImageRefresh.UseVisualStyleBackColor = True
        '
        'TxtImageFilename
        '
        Me.TxtImageFilename.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImageFilename.Location = New System.Drawing.Point(332, 369)
        Me.TxtImageFilename.Name = "TxtImageFilename"
        Me.TxtImageFilename.Size = New System.Drawing.Size(409, 25)
        Me.TxtImageFilename.TabIndex = 178
        '
        'TxtImageUrl
        '
        Me.TxtImageUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImageUrl.Location = New System.Drawing.Point(332, 252)
        Me.TxtImageUrl.Name = "TxtImageUrl"
        Me.TxtImageUrl.Size = New System.Drawing.Size(409, 25)
        Me.TxtImageUrl.TabIndex = 177
        '
        'lblWpDateMsg
        '
        Me.lblWpDateMsg.AutoSize = True
        Me.lblWpDateMsg.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblWpDateMsg.Location = New System.Drawing.Point(571, 480)
        Me.lblWpDateMsg.Name = "lblWpDateMsg"
        Me.lblWpDateMsg.Size = New System.Drawing.Size(187, 18)
        Me.lblWpDateMsg.TabIndex = 176
        Me.lblWpDateMsg.Text = "** No Wordpress load date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label7.Location = New System.Drawing.Point(217, 479)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 14)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "Wordpress Load Date"
        '
        'TxtWpLoadMth
        '
        Me.TxtWpLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWpLoadMth.Location = New System.Drawing.Point(370, 476)
        Me.TxtWpLoadMth.Name = "TxtWpLoadMth"
        Me.TxtWpLoadMth.Size = New System.Drawing.Size(46, 22)
        Me.TxtWpLoadMth.TabIndex = 173
        '
        'TxtWpLoadYear
        '
        Me.TxtWpLoadYear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWpLoadYear.Location = New System.Drawing.Point(438, 476)
        Me.TxtWpLoadYear.Name = "TxtWpLoadYear"
        Me.TxtWpLoadYear.Size = New System.Drawing.Size(95, 22)
        Me.TxtWpLoadYear.TabIndex = 174
        '
        'lblImgDateMsg
        '
        Me.lblImgDateMsg.AutoSize = True
        Me.lblImgDateMsg.Location = New System.Drawing.Point(631, 174)
        Me.lblImgDateMsg.Name = "lblImgDateMsg"
        Me.lblImgDateMsg.Size = New System.Drawing.Size(156, 18)
        Me.lblImgDateMsg.TabIndex = 172
        Me.lblImgDateMsg.Text = "** No image load date"
        '
        'TxtSurname
        '
        Me.TxtSurname.AllowDrop = True
        Me.TxtSurname.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSurname.Location = New System.Drawing.Point(520, 50)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(238, 22)
        Me.TxtSurname.TabIndex = 151
        '
        'BtnFindImage
        '
        Me.BtnFindImage.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFindImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnFindImage.Location = New System.Drawing.Point(829, 203)
        Me.BtnFindImage.Name = "BtnFindImage"
        Me.BtnFindImage.Size = New System.Drawing.Size(85, 79)
        Me.BtnFindImage.TabIndex = 159
        Me.BtnFindImage.Text = "Find an Image for Person"
        Me.BtnFindImage.UseVisualStyleBackColor = True
        '
        'cbImgType
        '
        Me.cbImgType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbImgType.FormattingEnabled = True
        Me.cbImgType.Items.AddRange(New Object() {".jpg", ".bmp", ".gif", ".png", ".jpeg"})
        Me.cbImgType.Location = New System.Drawing.Point(313, 128)
        Me.cbImgType.Name = "cbImgType"
        Me.cbImgType.Size = New System.Drawing.Size(103, 22)
        Me.cbImgType.TabIndex = 154
        '
        'BtnMakeImgName
        '
        Me.BtnMakeImgName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMakeImgName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMakeImgName.Location = New System.Drawing.Point(713, 92)
        Me.BtnMakeImgName.Name = "BtnMakeImgName"
        Me.BtnMakeImgName.Size = New System.Drawing.Size(28, 28)
        Me.BtnMakeImgName.TabIndex = 153
        Me.BtnMakeImgName.Text = "<"
        Me.BtnMakeImgName.UseVisualStyleBackColor = True
        '
        'txtImgName
        '
        Me.txtImgName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtImgName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImgName.Location = New System.Drawing.Point(313, 96)
        Me.txtImgName.Name = "txtImgName"
        Me.txtImgName.Size = New System.Drawing.Size(382, 22)
        Me.txtImgName.TabIndex = 152
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label9.Location = New System.Drawing.Point(217, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 14)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "Image Type"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label8.Location = New System.Drawing.Point(217, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 14)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Image Name"
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(282, 13)
        Me.txtId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(135, 22)
        Me.txtId.TabIndex = 148
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label4.Location = New System.Drawing.Point(217, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 14)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "Id"
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(817, 535)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(108, 45)
        Me.BtnClose.TabIndex = 162
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(240, 244)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 170
        Me.PictureBox1.TabStop = False
        '
        'BtnLoadDateUpdate
        '
        Me.BtnLoadDateUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnLoadDateUpdate.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadDateUpdate.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnLoadDateUpdate.Location = New System.Drawing.Point(829, 100)
        Me.BtnLoadDateUpdate.Name = "BtnLoadDateUpdate"
        Me.BtnLoadDateUpdate.Size = New System.Drawing.Size(85, 79)
        Me.BtnLoadDateUpdate.TabIndex = 157
        Me.BtnLoadDateUpdate.Text = "Update Image Data"
        Me.BtnLoadDateUpdate.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Location = New System.Drawing.Point(240, 372)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 171
        Me.PictureBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label5.Location = New System.Drawing.Point(217, 174)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 14)
        Me.Label5.TabIndex = 167
        Me.Label5.Text = "Image Load Date"
        '
        'txtLoadMth
        '
        Me.txtLoadMth.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadMth.Location = New System.Drawing.Point(370, 170)
        Me.txtLoadMth.Name = "txtLoadMth"
        Me.txtLoadMth.Size = New System.Drawing.Size(46, 22)
        Me.txtLoadMth.TabIndex = 155
        '
        'BtnPicSave
        '
        Me.BtnPicSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPicSave.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPicSave.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPicSave.Location = New System.Drawing.Point(829, 306)
        Me.BtnPicSave.Name = "BtnPicSave"
        Me.BtnPicSave.Size = New System.Drawing.Size(85, 79)
        Me.BtnPicSave.TabIndex = 158
        Me.BtnPicSave.Text = "Save Image to File"
        Me.BtnPicSave.UseVisualStyleBackColor = True
        '
        'txtLoadYr
        '
        Me.txtLoadYr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoadYr.Location = New System.Drawing.Point(438, 170)
        Me.txtLoadYr.Name = "txtLoadYr"
        Me.txtLoadYr.Size = New System.Drawing.Size(95, 22)
        Me.txtLoadYr.TabIndex = 156
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label12.Location = New System.Drawing.Point(220, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 168
        Me.Label12.Text = "Image from Wordpress"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label13.Location = New System.Drawing.Point(220, 344)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 169
        Me.Label13.Text = "Image from file"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(217, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 14)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Name"
        '
        'TxtForename
        '
        Me.TxtForename.AllowDrop = True
        Me.TxtForename.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForename.Location = New System.Drawing.Point(282, 50)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(228, 22)
        Me.TxtForename.TabIndex = 150
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSearch.Location = New System.Drawing.Point(817, 430)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(108, 68)
        Me.BtnSearch.TabIndex = 186
        Me.BtnSearch.Text = "Run Check"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 614)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(937, 22)
        Me.StatusStrip1.TabIndex = 187
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(0)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LblStatus.Size = New System.Drawing.Size(7, 22)
        '
        'FrmImageCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(937, 636)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnCopyLoadDate)
        Me.Controls.Add(Me.BtnFileImgGen)
        Me.Controls.Add(Me.BtnWpImgGen)
        Me.Controls.Add(Me.BtnFileImageRefresh)
        Me.Controls.Add(Me.BtnWpImageRefresh)
        Me.Controls.Add(Me.TxtImageFilename)
        Me.Controls.Add(Me.TxtImageUrl)
        Me.Controls.Add(Me.lblWpDateMsg)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtWpLoadMth)
        Me.Controls.Add(Me.TxtWpLoadYear)
        Me.Controls.Add(Me.lblImgDateMsg)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.BtnFindImage)
        Me.Controls.Add(Me.cbImgType)
        Me.Controls.Add(Me.BtnMakeImgName)
        Me.Controls.Add(Me.txtImgName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label4)
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
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.DgvMissingImages)
        Me.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmImageCheck"
        Me.Text = "Image Check"
        CType(Me.DgvMissingImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvMissingImages As DataGridView
    Friend WithEvents BtnCopyLoadDate As Button
    Friend WithEvents BtnFileImgGen As Button
    Friend WithEvents BtnWpImgGen As Button
    Friend WithEvents BtnFileImageRefresh As Button
    Friend WithEvents BtnWpImageRefresh As Button
    Friend WithEvents TxtImageFilename As TextBox
    Friend WithEvents TxtImageUrl As TextBox
    Friend WithEvents lblWpDateMsg As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtWpLoadMth As TextBox
    Friend WithEvents TxtWpLoadYear As TextBox
    Friend WithEvents lblImgDateMsg As Label
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents BtnFindImage As Button
    Friend WithEvents cbImgType As ComboBox
    Friend WithEvents BtnMakeImgName As Button
    Friend WithEvents txtImgName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtId As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnLoadDateUpdate As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtLoadMth As TextBox
    Friend WithEvents BtnPicSave As Button
    Friend WithEvents txtLoadYr As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents BtnSearch As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents personId As DataGridViewTextBoxColumn
    Friend WithEvents PersonName As DataGridViewTextBoxColumn
    Friend WithEvents personError As DataGridViewTextBoxColumn
End Class

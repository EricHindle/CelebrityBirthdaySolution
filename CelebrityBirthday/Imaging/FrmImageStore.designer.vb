﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImageStore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImageStore))
        Me.btnSavepic = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSelFolder = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.LblImagePath = New System.Windows.Forms.Label()
        Me.btnGetImage = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PasteImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.BtnEditImage = New System.Windows.Forms.Button()
        Me.btnLoadImage = New System.Windows.Forms.Button()
        Me.lblImageFile = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSavepic
        '
        Me.btnSavepic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavepic.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavepic.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSavepic.Location = New System.Drawing.Point(920, 273)
        Me.btnSavepic.Name = "btnSavepic"
        Me.btnSavepic.Size = New System.Drawing.Size(87, 59)
        Me.btnSavepic.TabIndex = 64
        Me.btnSavepic.Text = "Save Image"
        Me.btnSavepic.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(923, 569)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 51)
        Me.btnClose.TabIndex = 68
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSelFolder
        '
        Me.btnSelFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelFolder.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelFolder.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSelFolder.Location = New System.Drawing.Point(920, 113)
        Me.btnSelFolder.Name = "btnSelFolder"
        Me.btnSelFolder.Size = New System.Drawing.Size(87, 59)
        Me.btnSelFolder.TabIndex = 69
        Me.btnSelFolder.Text = "Set image folder"
        Me.btnSelFolder.UseVisualStyleBackColor = True
        '
        'LblImagePath
        '
        Me.LblImagePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblImagePath.AutoSize = True
        Me.LblImagePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblImagePath.Location = New System.Drawing.Point(29, 549)
        Me.LblImagePath.Name = "LblImagePath"
        Me.LblImagePath.Size = New System.Drawing.Size(73, 16)
        Me.LblImagePath.TabIndex = 70
        Me.LblImagePath.Text = "ImagePath"
        '
        'btnGetImage
        '
        Me.btnGetImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetImage.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnGetImage.Location = New System.Drawing.Point(920, 33)
        Me.btnGetImage.Name = "btnGetImage"
        Me.btnGetImage.Size = New System.Drawing.Size(87, 59)
        Me.btnGetImage.TabIndex = 72
        Me.btnGetImage.Text = "Search for Images"
        Me.btnGetImage.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(17, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 498)
        Me.Panel1.TabIndex = 75
        '
        'PictureBox1
        '
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(884, 494)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 58
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasteImageToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(139, 26)
        '
        'PasteImageToolStripMenuItem
        '
        Me.PasteImageToolStripMenuItem.Name = "PasteImageToolStripMenuItem"
        Me.PasteImageToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PasteImageToolStripMenuItem.Text = "Paste Image"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1022, 22)
        Me.StatusStrip1.TabIndex = 76
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.LblStatus.Name = "lblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.LblStatus.Size = New System.Drawing.Size(63, 17)
        Me.LblStatus.Text = "No Picture"
        '
        'TxtForename
        '
        Me.TxtForename.Location = New System.Drawing.Point(89, 5)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(189, 22)
        Me.TxtForename.TabIndex = 77
        '
        'TxtSurname
        '
        Me.TxtSurname.Location = New System.Drawing.Point(350, 5)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(209, 22)
        Me.TxtSurname.TabIndex = 79
        '
        'BtnEditImage
        '
        Me.BtnEditImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEditImage.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnEditImage.Location = New System.Drawing.Point(920, 353)
        Me.BtnEditImage.Name = "BtnEditImage"
        Me.BtnEditImage.Size = New System.Drawing.Size(87, 59)
        Me.BtnEditImage.TabIndex = 80
        Me.BtnEditImage.Text = "Edit Image"
        Me.BtnEditImage.UseVisualStyleBackColor = True
        '
        'btnLoadImage
        '
        Me.btnLoadImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadImage.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnLoadImage.Location = New System.Drawing.Point(920, 193)
        Me.btnLoadImage.Name = "btnLoadImage"
        Me.btnLoadImage.Size = New System.Drawing.Size(87, 59)
        Me.btnLoadImage.TabIndex = 81
        Me.btnLoadImage.Text = "Load Image"
        Me.btnLoadImage.UseVisualStyleBackColor = True
        '
        'lblImageFile
        '
        Me.lblImageFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblImageFile.AutoSize = True
        Me.lblImageFile.Location = New System.Drawing.Point(29, 586)
        Me.lblImageFile.Name = "lblImageFile"
        Me.lblImageFile.Size = New System.Drawing.Size(62, 14)
        Me.lblImageFile.TabIndex = 83
        Me.lblImageFile.Text = "Image File"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(929, 436)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(69, 65)
        Me.PictureBox2.TabIndex = 132
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(15, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 14)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Forename"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(284, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Surname"
        '
        'FrmImageStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1022, 661)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblImageFile)
        Me.Controls.Add(Me.btnLoadImage)
        Me.Controls.Add(Me.BtnEditImage)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGetImage)
        Me.Controls.Add(Me.LblImagePath)
        Me.Controls.Add(Me.btnSelFolder)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSavepic)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmImageStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Store"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSavepic As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSelFolder As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LblImagePath As System.Windows.Forms.Label
    Friend WithEvents btnGetImage As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents TxtSurname As TextBox
    Friend WithEvents BtnEditImage As Button
    Friend WithEvents btnLoadImage As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents PasteImageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblImageFile As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class

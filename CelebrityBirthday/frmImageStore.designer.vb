<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageStore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageStore))
        Me.PicBrowser = New System.Windows.Forms.WebBrowser()
        Me.btnSavepic = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSelFolder = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.LblImagePath = New System.Windows.Forms.Label()
        Me.lblPicUrl = New System.Windows.Forms.Label()
        Me.btnGetImage = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.PicStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TxtForename = New System.Windows.Forms.TextBox()
        Me.lblSearchUrl = New System.Windows.Forms.Label()
        Me.TxtSurname = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PicBrowser
        '
        Me.PicBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicBrowser.Location = New System.Drawing.Point(0, 0)
        Me.PicBrowser.MinimumSize = New System.Drawing.Size(23, 22)
        Me.PicBrowser.Name = "PicBrowser"
        Me.PicBrowser.Size = New System.Drawing.Size(884, 494)
        Me.PicBrowser.TabIndex = 57
        '
        'btnSavepic
        '
        Me.btnSavepic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavepic.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavepic.Location = New System.Drawing.Point(920, 271)
        Me.btnSavepic.Name = "btnSavepic"
        Me.btnSavepic.Size = New System.Drawing.Size(87, 59)
        Me.btnSavepic.TabIndex = 64
        Me.btnSavepic.Text = "Save Image"
        Me.btnSavepic.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(923, 569)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 51)
        Me.btnClose.TabIndex = 68
        Me.btnClose.Text = "close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSelFolder
        '
        Me.btnSelFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelFolder.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelFolder.Location = New System.Drawing.Point(920, 120)
        Me.btnSelFolder.Name = "btnSelFolder"
        Me.btnSelFolder.Size = New System.Drawing.Size(87, 103)
        Me.btnSelFolder.TabIndex = 69
        Me.btnSelFolder.Text = "Set default image folder"
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
        'lblPicUrl
        '
        Me.lblPicUrl.AutoSize = True
        Me.lblPicUrl.Location = New System.Drawing.Point(29, 605)
        Me.lblPicUrl.Name = "lblPicUrl"
        Me.lblPicUrl.Size = New System.Drawing.Size(63, 14)
        Me.lblPicUrl.TabIndex = 71
        Me.lblPicUrl.Text = "Picture Url"
        '
        'btnGetImage
        '
        Me.btnGetImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetImage.Location = New System.Drawing.Point(920, 33)
        Me.btnGetImage.Name = "btnGetImage"
        Me.btnGetImage.Size = New System.Drawing.Size(87, 57)
        Me.btnGetImage.TabIndex = 72
        Me.btnGetImage.Text = "Get Images"
        Me.btnGetImage.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PicBrowser)
        Me.Panel1.Location = New System.Drawing.Point(17, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 498)
        Me.Panel1.TabIndex = 75
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PicStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1022, 22)
        Me.StatusStrip1.TabIndex = 76
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'PicStatus
        '
        Me.PicStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.PicStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicStatus.Name = "PicStatus"
        Me.PicStatus.Size = New System.Drawing.Size(63, 17)
        Me.PicStatus.Text = "No Picture"
        '
        'TxtForename
        '
        Me.TxtForename.Location = New System.Drawing.Point(19, 5)
        Me.TxtForename.Name = "TxtForename"
        Me.TxtForename.Size = New System.Drawing.Size(189, 22)
        Me.TxtForename.TabIndex = 77
        '
        'lblSearchUrl
        '
        Me.lblSearchUrl.AutoSize = True
        Me.lblSearchUrl.Location = New System.Drawing.Point(29, 578)
        Me.lblSearchUrl.Name = "lblSearchUrl"
        Me.lblSearchUrl.Size = New System.Drawing.Size(62, 14)
        Me.lblSearchUrl.TabIndex = 78
        Me.lblSearchUrl.Text = "Search Url"
        '
        'TxtSurname
        '
        Me.TxtSurname.Location = New System.Drawing.Point(214, 5)
        Me.TxtSurname.Name = "TxtSurname"
        Me.TxtSurname.Size = New System.Drawing.Size(209, 22)
        Me.TxtSurname.TabIndex = 79
        '
        'frmImageStore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1022, 661)
        Me.Controls.Add(Me.TxtSurname)
        Me.Controls.Add(Me.lblSearchUrl)
        Me.Controls.Add(Me.TxtForename)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGetImage)
        Me.Controls.Add(Me.lblPicUrl)
        Me.Controls.Add(Me.LblImagePath)
        Me.Controls.Add(Me.btnSelFolder)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSavepic)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImageStore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pictures"
        Me.Panel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PicBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents btnSavepic As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSelFolder As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LblImagePath As System.Windows.Forms.Label
    Friend WithEvents lblPicUrl As System.Windows.Forms.Label
    Friend WithEvents btnGetImage As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents PicStatus As ToolStripStatusLabel
    Friend WithEvents TxtForename As TextBox
    Friend WithEvents lblSearchUrl As Label
    Friend WithEvents TxtSurname As TextBox
End Class

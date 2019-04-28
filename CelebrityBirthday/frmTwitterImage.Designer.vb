<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTwitterImage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTwitterImage))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.BtnGenImage = New System.Windows.Forms.Button()
        Me.BtnSaveImage = New System.Windows.Forms.Button()
        Me.LblImageCount = New System.Windows.Forms.Label()
        Me.NudPic1Horizontal = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbSplitImages = New System.Windows.Forms.RadioButton()
        Me.RbSingleImage = New System.Windows.Forms.RadioButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(615, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.LblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LblStatus.Size = New System.Drawing.Size(3, 17)
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(3, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(420, 240)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'cboDay
        '
        Me.cboDay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(14, 13)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(95, 27)
        Me.cboDay.TabIndex = 2
        '
        'cboMonth
        '
        Me.cboMonth.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cboMonth.Location = New System.Drawing.Point(117, 13)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(240, 27)
        Me.cboMonth.TabIndex = 3
        '
        'BtnGenImage
        '
        Me.BtnGenImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGenImage.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGenImage.Location = New System.Drawing.Point(464, 162)
        Me.BtnGenImage.Name = "BtnGenImage"
        Me.BtnGenImage.Size = New System.Drawing.Size(139, 33)
        Me.BtnGenImage.TabIndex = 4
        Me.BtnGenImage.Text = "Generate Images"
        Me.BtnGenImage.UseVisualStyleBackColor = True
        '
        'BtnSaveImage
        '
        Me.BtnSaveImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveImage.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSaveImage.Location = New System.Drawing.Point(464, 232)
        Me.BtnSaveImage.Name = "BtnSaveImage"
        Me.BtnSaveImage.Size = New System.Drawing.Size(139, 33)
        Me.BtnSaveImage.TabIndex = 5
        Me.BtnSaveImage.Text = "Save Images"
        Me.BtnSaveImage.UseVisualStyleBackColor = True
        '
        'LblImageCount
        '
        Me.LblImageCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblImageCount.AutoSize = True
        Me.LblImageCount.Location = New System.Drawing.Point(372, 20)
        Me.LblImageCount.Name = "LblImageCount"
        Me.LblImageCount.Size = New System.Drawing.Size(57, 14)
        Me.LblImageCount.TabIndex = 6
        Me.LblImageCount.Text = "0 Images"
        '
        'NudPic1Horizontal
        '
        Me.NudPic1Horizontal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudPic1Horizontal.Location = New System.Drawing.Point(51, 365)
        Me.NudPic1Horizontal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudPic1Horizontal.Name = "NudPic1Horizontal"
        Me.NudPic1Horizontal.Size = New System.Drawing.Size(53, 22)
        Me.NudPic1Horizontal.TabIndex = 7
        Me.NudPic1Horizontal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NudPic1Horizontal.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Width"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnClose.Location = New System.Drawing.Point(464, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(139, 33)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RbSplitImages)
        Me.GroupBox1.Controls.Add(Me.RbSingleImage)
        Me.GroupBox1.Location = New System.Drawing.Point(464, 299)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(139, 93)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'RbSplitImages
        '
        Me.RbSplitImages.AutoSize = True
        Me.RbSplitImages.Checked = True
        Me.RbSplitImages.Font = New System.Drawing.Font("Papyrus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSplitImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.RbSplitImages.Location = New System.Drawing.Point(23, 49)
        Me.RbSplitImages.Name = "RbSplitImages"
        Me.RbSplitImages.Size = New System.Drawing.Size(100, 22)
        Me.RbSplitImages.TabIndex = 1
        Me.RbSplitImages.TabStop = True
        Me.RbSplitImages.Text = "Twitter Images"
        Me.RbSplitImages.UseVisualStyleBackColor = True
        '
        'RbSingleImage
        '
        Me.RbSingleImage.AutoSize = True
        Me.RbSingleImage.Font = New System.Drawing.Font("Papyrus", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSingleImage.ForeColor = System.Drawing.Color.RoyalBlue
        Me.RbSingleImage.Location = New System.Drawing.Point(23, 21)
        Me.RbSingleImage.Name = "RbSingleImage"
        Me.RbSingleImage.Size = New System.Drawing.Size(92, 22)
        Me.RbSingleImage.TabIndex = 0
        Me.RbSingleImage.Text = "Single Image"
        Me.RbSingleImage.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(14, 46)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(444, 419)
        Me.TabControl1.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.NudPic1Horizontal)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(436, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Born On This Day"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FrmTwitterImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(615, 500)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.LblImageCount)
        Me.Controls.Add(Me.BtnSaveImage)
        Me.Controls.Add(Me.BtnGenImage)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmTwitterImage"
        Me.Text = "Twitter Image"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NudPic1Horizontal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents BtnGenImage As Button
    Friend WithEvents BtnSaveImage As Button
    Friend WithEvents LblImageCount As Label
    Friend WithEvents NudPic1Horizontal As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents LblStatus As ToolStripStatusLabel
    Friend WithEvents btnClose As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbSplitImages As RadioButton
    Friend WithEvents RbSingleImage As RadioButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
End Class

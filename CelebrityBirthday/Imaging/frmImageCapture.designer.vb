<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageCapture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageCapture))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnRotate = New System.Windows.Forms.Button()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.previewPictureBox = New System.Windows.Forms.PictureBox()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnLoadImage = New System.Windows.Forms.Button()
        Me.BtnSaveCroppedImage = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbBrightness = New System.Windows.Forms.TrackBar()
        Me.btnReset = New System.Windows.Forms.Label()
        Me.tbContrast = New System.Windows.Forms.TrackBar()
        Me.BtnResetAdjustments = New System.Windows.Forms.Button()
        Me.pnlAdjustImage = New System.Windows.Forms.Panel()
        Me.nudSaveSize = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.previewPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAdjustImage.SuspendLayout()
        CType(Me.nudSaveSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 494)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(934, 24)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackgroundImage = Global.CelebrityBirthday.My.Resources.Resources.StatusBar
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(20, 19)
        Me.lblStatus.Text = "   "
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClose.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(847, 457)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 34)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnRotate
        '
        Me.BtnRotate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnRotate.BackColor = System.Drawing.Color.White
        Me.BtnRotate.Image = Global.CelebrityBirthday.My.Resources.Resources.refresh
        Me.BtnRotate.Location = New System.Drawing.Point(662, 384)
        Me.BtnRotate.Name = "BtnRotate"
        Me.BtnRotate.Size = New System.Drawing.Size(42, 43)
        Me.BtnRotate.TabIndex = 41
        Me.BtnRotate.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.BtnRotate, "Rotate image 90deg")
        Me.BtnRotate.UseVisualStyleBackColor = False
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.Color.LightSteelBlue
        Me.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCapture.Location = New System.Drawing.Point(136, 39)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(500, 400)
        Me.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picCapture.TabIndex = 21
        Me.picCapture.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(132, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 27)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Raw Image"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'previewPictureBox
        '
        Me.previewPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.previewPictureBox.BackColor = System.Drawing.Color.LightSteelBlue
        Me.previewPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.previewPictureBox.Location = New System.Drawing.Point(785, 39)
        Me.previewPictureBox.Name = "previewPictureBox"
        Me.previewPictureBox.Size = New System.Drawing.Size(120, 120)
        Me.previewPictureBox.TabIndex = 29
        Me.previewPictureBox.TabStop = False
        '
        'BtnClear
        '
        Me.BtnClear.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClear.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Location = New System.Drawing.Point(12, 144)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(89, 57)
        Me.BtnClear.TabIndex = 2
        Me.BtnClear.Text = "Clear Image"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(765, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 27)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Cropped Image"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'BtnLoadImage
        '
        Me.BtnLoadImage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLoadImage.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadImage.Location = New System.Drawing.Point(12, 52)
        Me.BtnLoadImage.Name = "BtnLoadImage"
        Me.BtnLoadImage.Size = New System.Drawing.Size(89, 56)
        Me.BtnLoadImage.TabIndex = 0
        Me.BtnLoadImage.Text = "Load Image"
        Me.BtnLoadImage.UseVisualStyleBackColor = True
        '
        'BtnSaveCroppedImage
        '
        Me.BtnSaveCroppedImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnSaveCroppedImage.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSaveCroppedImage.Font = New System.Drawing.Font("Papyrus", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveCroppedImage.Location = New System.Drawing.Point(760, 204)
        Me.BtnSaveCroppedImage.Name = "BtnSaveCroppedImage"
        Me.BtnSaveCroppedImage.Size = New System.Drawing.Size(162, 32)
        Me.BtnSaveCroppedImage.TabIndex = 5
        Me.BtnSaveCroppedImage.Text = "Save Cropped Image"
        Me.BtnSaveCroppedImage.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 328)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 57)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Image import:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Max width 1000" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Max height 700"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Location = New System.Drawing.Point(295, 14)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(20, 16)
        Me.lblFilename.TabIndex = 31
        Me.lblFilename.Text = "..."
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(734, 386)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(171, 41)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Click and drag on the image to select the area to crop"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 16)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Brightness"
        '
        'tbBrightness
        '
        Me.tbBrightness.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbBrightness.AutoSize = False
        Me.tbBrightness.LargeChange = 2
        Me.tbBrightness.Location = New System.Drawing.Point(0, 89)
        Me.tbBrightness.Maximum = 30
        Me.tbBrightness.Minimum = 10
        Me.tbBrightness.Name = "tbBrightness"
        Me.tbBrightness.Size = New System.Drawing.Size(91, 27)
        Me.tbBrightness.TabIndex = 35
        Me.tbBrightness.TickFrequency = 2
        Me.tbBrightness.Value = 20
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.AutoSize = True
        Me.btnReset.Location = New System.Drawing.Point(17, 10)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(56, 16)
        Me.btnReset.TabIndex = 38
        Me.btnReset.Text = "Contrast"
        '
        'tbContrast
        '
        Me.tbContrast.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbContrast.AutoSize = False
        Me.tbContrast.LargeChange = 3
        Me.tbContrast.Location = New System.Drawing.Point(0, 29)
        Me.tbContrast.Maximum = 28
        Me.tbContrast.Minimum = 1
        Me.tbContrast.Name = "tbContrast"
        Me.tbContrast.Size = New System.Drawing.Size(91, 27)
        Me.tbContrast.TabIndex = 37
        Me.tbContrast.TickFrequency = 3
        Me.tbContrast.Value = 10
        '
        'BtnResetAdjustments
        '
        Me.BtnResetAdjustments.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResetAdjustments.Location = New System.Drawing.Point(12, 136)
        Me.BtnResetAdjustments.Name = "BtnResetAdjustments"
        Me.BtnResetAdjustments.Size = New System.Drawing.Size(75, 32)
        Me.BtnResetAdjustments.TabIndex = 39
        Me.BtnResetAdjustments.Text = "Reset"
        Me.BtnResetAdjustments.UseVisualStyleBackColor = True
        '
        'pnlAdjustImage
        '
        Me.pnlAdjustImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAdjustImage.BackColor = System.Drawing.Color.GhostWhite
        Me.pnlAdjustImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlAdjustImage.Controls.Add(Me.btnReset)
        Me.pnlAdjustImage.Controls.Add(Me.BtnResetAdjustments)
        Me.pnlAdjustImage.Controls.Add(Me.tbBrightness)
        Me.pnlAdjustImage.Controls.Add(Me.Label6)
        Me.pnlAdjustImage.Controls.Add(Me.tbContrast)
        Me.pnlAdjustImage.Location = New System.Drawing.Point(645, 39)
        Me.pnlAdjustImage.Name = "pnlAdjustImage"
        Me.pnlAdjustImage.Size = New System.Drawing.Size(100, 180)
        Me.pnlAdjustImage.TabIndex = 40
        '
        'nudSaveSize
        '
        Me.nudSaveSize.Location = New System.Drawing.Point(847, 175)
        Me.nudSaveSize.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
        Me.nudSaveSize.Minimum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudSaveSize.Name = "nudSaveSize"
        Me.nudSaveSize.Size = New System.Drawing.Size(58, 23)
        Me.nudSaveSize.TabIndex = 42
        Me.nudSaveSize.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(766, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Save size"
        '
        'frmImageCapture
        '
        Me.AcceptButton = Me.BtnClose
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(934, 518)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudSaveSize)
        Me.Controls.Add(Me.BtnRotate)
        Me.Controls.Add(Me.pnlAdjustImage)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnSaveCroppedImage)
        Me.Controls.Add(Me.BtnLoadImage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.previewPictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picCapture)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.RoyalBlue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImageCapture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.previewPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbBrightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbContrast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAdjustImage.ResumeLayout(False)
        Me.pnlAdjustImage.PerformLayout()
        CType(Me.nudSaveSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents previewPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnLoadImage As System.Windows.Forms.Button
    Friend WithEvents BtnSaveCroppedImage As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbBrightness As System.Windows.Forms.TrackBar
    Friend WithEvents btnReset As System.Windows.Forms.Label
    Friend WithEvents tbContrast As System.Windows.Forms.TrackBar
    Friend WithEvents BtnResetAdjustments As System.Windows.Forms.Button
    Friend WithEvents pnlAdjustImage As System.Windows.Forms.Panel
    Friend WithEvents BtnRotate As System.Windows.Forms.Button
    Friend WithEvents nudSaveSize As NumericUpDown
    Friend WithEvents Label5 As Label
End Class

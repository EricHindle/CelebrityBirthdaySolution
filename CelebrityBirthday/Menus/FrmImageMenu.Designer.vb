' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImageMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImageMenu))
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnMosaic = New System.Windows.Forms.Button()
        Me.BtnImageEditing = New System.Windows.Forms.Button()
        Me.BtnPictures = New System.Windows.Forms.Button()
        Me.BtnImages = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnImageCheck = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(100, 379)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(151, 49)
        Me.BtnClose.TabIndex = 19
        Me.BtnClose.Text = "Back"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnMosaic
        '
        Me.BtnMosaic.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnMosaic.Location = New System.Drawing.Point(12, 303)
        Me.BtnMosaic.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnMosaic.Name = "BtnMosaic"
        Me.BtnMosaic.Size = New System.Drawing.Size(151, 49)
        Me.BtnMosaic.TabIndex = 20
        Me.BtnMosaic.Text = "Mosaic"
        Me.BtnMosaic.UseVisualStyleBackColor = True
        '
        'BtnImageEditing
        '
        Me.BtnImageEditing.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImageEditing.Location = New System.Drawing.Point(186, 239)
        Me.BtnImageEditing.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnImageEditing.Name = "BtnImageEditing"
        Me.BtnImageEditing.Size = New System.Drawing.Size(151, 49)
        Me.BtnImageEditing.TabIndex = 21
        Me.BtnImageEditing.Text = "Image Editing"
        Me.BtnImageEditing.UseVisualStyleBackColor = True
        '
        'BtnPictures
        '
        Me.BtnPictures.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPictures.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnPictures.Location = New System.Drawing.Point(12, 239)
        Me.BtnPictures.Name = "BtnPictures"
        Me.BtnPictures.Size = New System.Drawing.Size(151, 49)
        Me.BtnPictures.TabIndex = 22
        Me.BtnPictures.Text = "Find Image"
        Me.BtnPictures.UseVisualStyleBackColor = True
        '
        'BtnImages
        '
        Me.BtnImages.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImages.Location = New System.Drawing.Point(12, 175)
        Me.BtnImages.Name = "BtnImages"
        Me.BtnImages.Size = New System.Drawing.Size(151, 49)
        Me.BtnImages.TabIndex = 23
        Me.BtnImages.Text = "Database Images"
        Me.BtnImages.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(121, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10)
        Me.Label1.Size = New System.Drawing.Size(216, 76)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Celebrity Birthdays" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Images" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.CelebrityBirthday.My.Resources.Resources.cake_with_candle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 133)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'BtnImageCheck
        '
        Me.BtnImageCheck.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImageCheck.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImageCheck.Location = New System.Drawing.Point(186, 175)
        Me.BtnImageCheck.Name = "BtnImageCheck"
        Me.BtnImageCheck.Size = New System.Drawing.Size(151, 49)
        Me.BtnImageCheck.TabIndex = 26
        Me.BtnImageCheck.Text = "Missing Image Check"
        Me.BtnImageCheck.UseVisualStyleBackColor = True
        '
        'FrmImageMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 440)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnImageCheck)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnImages)
        Me.Controls.Add(Me.BtnPictures)
        Me.Controls.Add(Me.BtnImageEditing)
        Me.Controls.Add(Me.BtnMosaic)
        Me.Controls.Add(Me.BtnClose)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmImageMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnMosaic As Button
    Friend WithEvents BtnImageEditing As Button
    Friend WithEvents BtnPictures As Button
    Friend WithEvents BtnImages As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnImageCheck As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenu2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenu2))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnSendTweet = New System.Windows.Forms.Button()
        Me.BtnBrownBread = New System.Windows.Forms.Button()
        Me.BtnTwitter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnTapestry = New System.Windows.Forms.Button()
        Me.BtnImageEditing = New System.Windows.Forms.Button()
        Me.TxtBirthdateCheck = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.CelebrityBirthday.My.Resources.Resources.cake_with_candle
        Me.PictureBox1.Location = New System.Drawing.Point(15, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 133)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'BtnSendTweet
        '
        Me.BtnSendTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSendTweet.Location = New System.Drawing.Point(186, 237)
        Me.BtnSendTweet.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnSendTweet.Name = "BtnSendTweet"
        Me.BtnSendTweet.Size = New System.Drawing.Size(151, 49)
        Me.BtnSendTweet.TabIndex = 16
        Me.BtnSendTweet.Text = "Single Tweet"
        Me.BtnSendTweet.UseVisualStyleBackColor = True
        '
        'BtnBrownBread
        '
        Me.BtnBrownBread.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBrownBread.Location = New System.Drawing.Point(185, 176)
        Me.BtnBrownBread.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnBrownBread.Name = "BtnBrownBread"
        Me.BtnBrownBread.Size = New System.Drawing.Size(151, 49)
        Me.BtnBrownBread.TabIndex = 15
        Me.BtnBrownBread.Text = "Brown Bread"
        Me.BtnBrownBread.UseVisualStyleBackColor = True
        '
        'BtnTwitter
        '
        Me.BtnTwitter.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTwitter.Location = New System.Drawing.Point(15, 176)
        Me.BtnTwitter.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnTwitter.Name = "BtnTwitter"
        Me.BtnTwitter.Size = New System.Drawing.Size(151, 49)
        Me.BtnTwitter.TabIndex = 14
        Me.BtnTwitter.Text = "Twitter"
        Me.BtnTwitter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Papyrus", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(135, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10)
        Me.Label1.Size = New System.Drawing.Size(201, 52)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Celebrity Birthdays"
        '
        'BtnClose
        '
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(86, 432)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(151, 49)
        Me.BtnClose.TabIndex = 18
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnTapestry
        '
        Me.BtnTapestry.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTapestry.Location = New System.Drawing.Point(15, 237)
        Me.BtnTapestry.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnTapestry.Name = "BtnTapestry"
        Me.BtnTapestry.Size = New System.Drawing.Size(151, 49)
        Me.BtnTapestry.TabIndex = 19
        Me.BtnTapestry.Text = "Tapestry"
        Me.BtnTapestry.UseVisualStyleBackColor = True
        '
        'BtnImageEditing
        '
        Me.BtnImageEditing.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImageEditing.Location = New System.Drawing.Point(15, 298)
        Me.BtnImageEditing.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnImageEditing.Name = "BtnImageEditing"
        Me.BtnImageEditing.Size = New System.Drawing.Size(151, 49)
        Me.BtnImageEditing.TabIndex = 20
        Me.BtnImageEditing.Text = "Image Editing"
        Me.BtnImageEditing.UseVisualStyleBackColor = True
        '
        'txtBirthdateCheck
        '
        Me.TxtBirthdateCheck.ForeColor = System.Drawing.Color.RoyalBlue
        Me.TxtBirthdateCheck.Location = New System.Drawing.Point(186, 298)
        Me.TxtBirthdateCheck.Margin = New System.Windows.Forms.Padding(6)
        Me.TxtBirthdateCheck.Name = "txtBirthdateCheck"
        Me.TxtBirthdateCheck.Size = New System.Drawing.Size(151, 49)
        Me.TxtBirthdateCheck.TabIndex = 21
        Me.TxtBirthdateCheck.Text = "Check"
        Me.TxtBirthdateCheck.UseVisualStyleBackColor = True
        '
        'FrmMenu2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 509)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtBirthdateCheck)
        Me.Controls.Add(Me.BtnImageEditing)
        Me.Controls.Add(Me.BtnTapestry)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnSendTweet)
        Me.Controls.Add(Me.BtnBrownBread)
        Me.Controls.Add(Me.BtnTwitter)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Papyrus", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FrmMenu2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnSendTweet As Button
    Friend WithEvents BtnBrownBread As Button
    Friend WithEvents BtnTwitter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnTapestry As Button
    Friend WithEvents BtnImageEditing As Button
    Friend WithEvents TxtBirthdateCheck As Button
End Class

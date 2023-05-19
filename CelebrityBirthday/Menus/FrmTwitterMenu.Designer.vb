' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTwitterMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTwitterMenu))
        Me.BtnTweet = New System.Windows.Forms.Button()
        Me.BtnSendTweet = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnTwitterMosaic = New System.Windows.Forms.Button()
        Me.BtnAuthenticateTwitter = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnTweet
        '
        Me.BtnTweet.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTweet.Location = New System.Drawing.Point(14, 179)
        Me.BtnTweet.Name = "BtnTweet"
        Me.BtnTweet.Size = New System.Drawing.Size(151, 49)
        Me.BtnTweet.TabIndex = 14
        Me.BtnTweet.Text = "Daily Tweets"
        Me.BtnTweet.UseVisualStyleBackColor = True
        '
        'BtnSendTweet
        '
        Me.BtnSendTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSendTweet.Location = New System.Drawing.Point(188, 252)
        Me.BtnSendTweet.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnSendTweet.Name = "BtnSendTweet"
        Me.BtnSendTweet.Size = New System.Drawing.Size(151, 49)
        Me.BtnSendTweet.TabIndex = 18
        Me.BtnSendTweet.Text = "Single Tweet"
        Me.BtnSendTweet.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(92, 406)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(151, 49)
        Me.BtnClose.TabIndex = 19
        Me.BtnClose.Text = "Back"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(123, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10)
        Me.Label1.Size = New System.Drawing.Size(216, 76)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Celebrity Birthdays" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Twitter"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.CelebrityBirthday.My.Resources.Resources.cake_with_candle
        Me.PictureBox1.Location = New System.Drawing.Point(14, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 133)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        '
        'BtnTwitterMosaic
        '
        Me.BtnTwitterMosaic.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTwitterMosaic.Location = New System.Drawing.Point(14, 252)
        Me.BtnTwitterMosaic.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnTwitterMosaic.Name = "BtnTwitterMosaic"
        Me.BtnTwitterMosaic.Size = New System.Drawing.Size(151, 49)
        Me.BtnTwitterMosaic.TabIndex = 22
        Me.BtnTwitterMosaic.Text = "Twitter Mosaic"
        Me.BtnTwitterMosaic.UseVisualStyleBackColor = True
        '
        'BtnAuthenticateTwitter
        '
        Me.BtnAuthenticateTwitter.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAuthenticateTwitter.Location = New System.Drawing.Point(188, 179)
        Me.BtnAuthenticateTwitter.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnAuthenticateTwitter.Name = "BtnAuthenticateTwitter"
        Me.BtnAuthenticateTwitter.Size = New System.Drawing.Size(151, 49)
        Me.BtnAuthenticateTwitter.TabIndex = 23
        Me.BtnAuthenticateTwitter.Text = "Authenticate"
        Me.BtnAuthenticateTwitter.UseVisualStyleBackColor = True
        '
        'FrmTwitterMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 467)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnAuthenticateTwitter)
        Me.Controls.Add(Me.BtnTwitterMosaic)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSendTweet)
        Me.Controls.Add(Me.BtnTweet)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmTwitterMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnTweet As Button
    Friend WithEvents BtnSendTweet As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnTwitterMosaic As Button
    Friend WithEvents BtnAuthenticateTwitter As Button
End Class

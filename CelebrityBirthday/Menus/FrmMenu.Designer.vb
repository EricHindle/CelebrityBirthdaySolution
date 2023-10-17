<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenu))
        Me.BtnDatabase = New System.Windows.Forms.Button()
        Me.BtnImages = New System.Windows.Forms.Button()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnWordPress = New System.Windows.Forms.Button()
        Me.BtnTweet = New System.Windows.Forms.Button()
        Me.BtnMore = New System.Windows.Forms.Button()
        Me.Version = New System.Windows.Forms.Label()
        Me.LblCelebrities = New System.Windows.Forms.Label()
        Me.BtnBotsdWP = New System.Windows.Forms.Button()
        Me.BtnDeadList = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnDatabase
        '
        Me.BtnDatabase.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDatabase.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDatabase.Location = New System.Drawing.Point(15, 246)
        Me.BtnDatabase.Name = "BtnDatabase"
        Me.BtnDatabase.Size = New System.Drawing.Size(151, 49)
        Me.BtnDatabase.TabIndex = 0
        Me.BtnDatabase.Text = "Database"
        Me.BtnDatabase.UseVisualStyleBackColor = True
        '
        'BtnImages
        '
        Me.BtnImages.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImages.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnImages.Location = New System.Drawing.Point(189, 314)
        Me.BtnImages.Name = "BtnImages"
        Me.BtnImages.Size = New System.Drawing.Size(151, 49)
        Me.BtnImages.TabIndex = 1
        Me.BtnImages.Text = "Images"
        Me.BtnImages.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSearch.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnSearch.Location = New System.Drawing.Point(15, 175)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(325, 52)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "Search"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(189, 509)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(151, 49)
        Me.BtnClose.TabIndex = 9
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnWordPress
        '
        Me.BtnWordPress.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWordPress.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWordPress.Location = New System.Drawing.Point(189, 380)
        Me.BtnWordPress.Name = "BtnWordPress"
        Me.BtnWordPress.Size = New System.Drawing.Size(151, 49)
        Me.BtnWordPress.TabIndex = 4
        Me.BtnWordPress.Text = "WordPress"
        Me.BtnWordPress.UseVisualStyleBackColor = True
        '
        'BtnTweet
        '
        Me.BtnTweet.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTweet.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnTweet.Location = New System.Drawing.Point(15, 314)
        Me.BtnTweet.Name = "BtnTweet"
        Me.BtnTweet.Size = New System.Drawing.Size(151, 49)
        Me.BtnTweet.TabIndex = 3
        Me.BtnTweet.Text = "Twitter"
        Me.BtnTweet.UseVisualStyleBackColor = True
        '
        'BtnMore
        '
        Me.BtnMore.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMore.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnMore.Location = New System.Drawing.Point(15, 450)
        Me.BtnMore.Name = "BtnMore"
        Me.BtnMore.Size = New System.Drawing.Size(151, 49)
        Me.BtnMore.TabIndex = 8
        Me.BtnMore.Text = "More..."
        Me.BtnMore.UseVisualStyleBackColor = True
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Version.AutoSize = True
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Version.Location = New System.Drawing.Point(19, 564)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(156, 17)
        Me.Version.TabIndex = 12
        Me.Version.Text = "Version {0}.{1}.{2}.{3}"
        Me.Version.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'LblCelebrities
        '
        Me.LblCelebrities.Location = New System.Drawing.Point(124, 114)
        Me.LblCelebrities.Name = "LblCelebrities"
        Me.LblCelebrities.Size = New System.Drawing.Size(216, 34)
        Me.LblCelebrities.TabIndex = 13
        Me.LblCelebrities.Text = "{0} Celebrities"
        Me.LblCelebrities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnBotsdWP
        '
        Me.BtnBotsdWP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBotsdWP.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBotsdWP.Location = New System.Drawing.Point(15, 382)
        Me.BtnBotsdWP.Name = "BtnBotsdWP"
        Me.BtnBotsdWP.Size = New System.Drawing.Size(151, 49)
        Me.BtnBotsdWP.TabIndex = 14
        Me.BtnBotsdWP.Text = "Born on the Same Day"
        Me.BtnBotsdWP.UseVisualStyleBackColor = True
        '
        'BtnDeadList
        '
        Me.BtnDeadList.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDeadList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDeadList.Location = New System.Drawing.Point(189, 246)
        Me.BtnDeadList.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.BtnDeadList.Name = "BtnDeadList"
        Me.BtnDeadList.Size = New System.Drawing.Size(151, 49)
        Me.BtnDeadList.TabIndex = 24
        Me.BtnDeadList.Text = "Dead List"
        Me.BtnDeadList.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label1.Location = New System.Drawing.Point(124, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(10)
        Me.Label1.Size = New System.Drawing.Size(216, 49)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Celebrity Birthdays"
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
        Me.PictureBox1.TabIndex = 25
        Me.PictureBox1.TabStop = False
        '
        'FrmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 596)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BtnDeadList)
        Me.Controls.Add(Me.BtnBotsdWP)
        Me.Controls.Add(Me.LblCelebrities)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.BtnMore)
        Me.Controls.Add(Me.BtnWordPress)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSearch)
        Me.Controls.Add(Me.BtnTweet)
        Me.Controls.Add(Me.BtnImages)
        Me.Controls.Add(Me.BtnDatabase)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FrmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnDatabase As Button
    Friend WithEvents BtnImages As Button
    Friend WithEvents BtnSearch As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnWordPress As Button
    Friend WithEvents BtnTweet As Button
    Friend WithEvents BtnMore As Button
    Friend WithEvents Version As Label
    Friend WithEvents LblCelebrities As Label
    Friend WithEvents BtnBotsdWP As Button
    Friend WithEvents BtnDeadList As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class

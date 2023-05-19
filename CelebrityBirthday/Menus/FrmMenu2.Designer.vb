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
        Me.BtnBrownBread = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.TxtBirthdateCheck = New System.Windows.Forms.Button()
        Me.BtnWikiIds = New System.Windows.Forms.Button()
        Me.BtnDeadList = New System.Windows.Forms.Button()
        Me.BtnViewLog = New System.Windows.Forms.Button()
        Me.BtnOptions = New System.Windows.Forms.Button()
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
        'BtnBrownBread
        '
        Me.BtnBrownBread.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnBrownBread.Location = New System.Drawing.Point(15, 246)
        Me.BtnBrownBread.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnBrownBread.Name = "BtnBrownBread"
        Me.BtnBrownBread.Size = New System.Drawing.Size(151, 49)
        Me.BtnBrownBread.TabIndex = 15
        Me.BtnBrownBread.Text = "Brown Bread"
        Me.BtnBrownBread.UseVisualStyleBackColor = True
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
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Celebrity Birthdays"
        '
        'BtnClose
        '
        Me.BtnClose.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnClose.Location = New System.Drawing.Point(102, 412)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(151, 49)
        Me.BtnClose.TabIndex = 18
        Me.BtnClose.Text = "Back"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TxtBirthdateCheck
        '
        Me.TxtBirthdateCheck.ForeColor = System.Drawing.Color.RoyalBlue
        Me.TxtBirthdateCheck.Location = New System.Drawing.Point(15, 175)
        Me.TxtBirthdateCheck.Margin = New System.Windows.Forms.Padding(6)
        Me.TxtBirthdateCheck.Name = "TxtBirthdateCheck"
        Me.TxtBirthdateCheck.Size = New System.Drawing.Size(151, 49)
        Me.TxtBirthdateCheck.TabIndex = 21
        Me.TxtBirthdateCheck.Text = "DoB Check"
        Me.TxtBirthdateCheck.UseVisualStyleBackColor = True
        '
        'BtnWikiIds
        '
        Me.BtnWikiIds.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnWikiIds.Location = New System.Drawing.Point(189, 175)
        Me.BtnWikiIds.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnWikiIds.Name = "BtnWikiIds"
        Me.BtnWikiIds.Size = New System.Drawing.Size(151, 49)
        Me.BtnWikiIds.TabIndex = 22
        Me.BtnWikiIds.Text = "Wiki Ids"
        Me.BtnWikiIds.UseVisualStyleBackColor = True
        '
        'BtnDeadList
        '
        Me.BtnDeadList.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnDeadList.Location = New System.Drawing.Point(189, 246)
        Me.BtnDeadList.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnDeadList.Name = "BtnDeadList"
        Me.BtnDeadList.Size = New System.Drawing.Size(151, 49)
        Me.BtnDeadList.TabIndex = 23
        Me.BtnDeadList.Text = "Dead List"
        Me.BtnDeadList.UseVisualStyleBackColor = True
        '
        'BtnViewLog
        '
        Me.BtnViewLog.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnViewLog.Location = New System.Drawing.Point(15, 317)
        Me.BtnViewLog.Margin = New System.Windows.Forms.Padding(6)
        Me.BtnViewLog.Name = "BtnViewLog"
        Me.BtnViewLog.Size = New System.Drawing.Size(151, 49)
        Me.BtnViewLog.TabIndex = 24
        Me.BtnViewLog.Text = "View Log"
        Me.BtnViewLog.UseVisualStyleBackColor = True
        '
        'BtnOptions
        '
        Me.BtnOptions.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOptions.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnOptions.Location = New System.Drawing.Point(189, 317)
        Me.BtnOptions.Name = "BtnOptions"
        Me.BtnOptions.Size = New System.Drawing.Size(151, 49)
        Me.BtnOptions.TabIndex = 26
        Me.BtnOptions.Text = "Options"
        Me.BtnOptions.UseVisualStyleBackColor = True
        '
        'FrmMenu2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnDeadList)
        Me.Controls.Add(Me.BtnOptions)
        Me.Controls.Add(Me.BtnBrownBread)
        Me.Controls.Add(Me.BtnWikiIds)
        Me.Controls.Add(Me.TxtBirthdateCheck)
        Me.Controls.Add(Me.BtnViewLog)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FrmMenu2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnBrownBread As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents TxtBirthdateCheck As Button
    Friend WithEvents BtnWikiIds As Button
    Friend WithEvents BtnViewLog As Button
    Friend WithEvents BtnDeadList As Button
    Friend WithEvents BtnOptions As Button
End Class

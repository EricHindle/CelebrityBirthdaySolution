<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOptions))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtNewImagePath = New System.Windows.Forms.TextBox()
        Me.txtImagePath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTwitterFilePath = New System.Windows.Forms.TextBox()
        Me.Version = New System.Windows.Forms.Label()
        Me.BtnResetForms = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtImageSearch = New System.Windows.Forms.TextBox()
        Me.TxtWordPress = New System.Windows.Forms.TextBox()
        Me.TxtWikiSearch = New System.Windows.Forms.TextBox()
        Me.txtTwitterSearch = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtTwitterImagePath = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtWordPressDate = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtWikiExtract = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnGlobalSettings = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.NudSentences = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BtnRmvWord = New System.Windows.Forms.Button()
        Me.BtnAddWord = New System.Windows.Forms.Button()
        Me.LbSplitWords = New System.Windows.Forms.ListBox()
        Me.TxtSplitWords = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtLogFilePath = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnCancel.Location = New System.Drawing.Point(392, 633)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(87, 41)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Papyrus", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.RoyalBlue
        Me.btnSave.Location = New System.Drawing.Point(272, 633)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 41)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtNewImagePath
        '
        Me.txtNewImagePath.Location = New System.Drawing.Point(172, 59)
        Me.txtNewImagePath.Name = "txtNewImagePath"
        Me.txtNewImagePath.Size = New System.Drawing.Size(333, 22)
        Me.txtNewImagePath.TabIndex = 2
        '
        'txtImagePath
        '
        Me.txtImagePath.Location = New System.Drawing.Point(172, 26)
        Me.txtImagePath.Name = "txtImagePath"
        Me.txtImagePath.Size = New System.Drawing.Size(333, 22)
        Me.txtImagePath.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Image Path"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "New Image Path"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Twitter File Path"
        '
        'txtTwitterFilePath
        '
        Me.txtTwitterFilePath.Location = New System.Drawing.Point(172, 92)
        Me.txtTwitterFilePath.Name = "txtTwitterFilePath"
        Me.txtTwitterFilePath.Size = New System.Drawing.Size(333, 22)
        Me.txtTwitterFilePath.TabIndex = 6
        '
        'Version
        '
        Me.Version.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.Font = New System.Drawing.Font("Papyrus", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Version.Location = New System.Drawing.Point(12, 656)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(214, 28)
        Me.Version.TabIndex = 8
        Me.Version.Text = "Version {0}.{1}.{2}.{3}"
        '
        'BtnResetForms
        '
        Me.BtnResetForms.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnResetForms.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnResetForms.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnResetForms.Location = New System.Drawing.Point(16, 580)
        Me.BtnResetForms.Name = "BtnResetForms"
        Me.BtnResetForms.Size = New System.Drawing.Size(86, 60)
        Me.BtnResetForms.TabIndex = 9
        Me.BtnResetForms.Text = "Reset Form Positions"
        Me.BtnResetForms.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(149, 14)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Google Image Search URL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "WordPress URL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Wiki Search URL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 149)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Twitter Search URL"
        '
        'TxtImageSearch
        '
        Me.TxtImageSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtImageSearch.Location = New System.Drawing.Point(172, 29)
        Me.TxtImageSearch.Name = "TxtImageSearch"
        Me.TxtImageSearch.Size = New System.Drawing.Size(231, 22)
        Me.TxtImageSearch.TabIndex = 14
        '
        'TxtWordPress
        '
        Me.TxtWordPress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWordPress.Location = New System.Drawing.Point(172, 68)
        Me.TxtWordPress.Name = "TxtWordPress"
        Me.TxtWordPress.Size = New System.Drawing.Size(231, 22)
        Me.TxtWordPress.TabIndex = 15
        '
        'TxtWikiSearch
        '
        Me.TxtWikiSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWikiSearch.Location = New System.Drawing.Point(172, 107)
        Me.TxtWikiSearch.Name = "TxtWikiSearch"
        Me.TxtWikiSearch.Size = New System.Drawing.Size(231, 22)
        Me.TxtWikiSearch.TabIndex = 16
        '
        'txtTwitterSearch
        '
        Me.txtTwitterSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTwitterSearch.Location = New System.Drawing.Point(172, 146)
        Me.txtTwitterSearch.Name = "txtTwitterSearch"
        Me.txtTwitterSearch.Size = New System.Drawing.Size(231, 22)
        Me.txtTwitterSearch.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtLogFilePath)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtTwitterImagePath)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtTwitterFilePath)
        Me.GroupBox1.Controls.Add(Me.txtNewImagePath)
        Me.GroupBox1.Controls.Add(Me.txtImagePath)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 198)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Paths"
        '
        'TxtTwitterImagePath
        '
        Me.TxtTwitterImagePath.Location = New System.Drawing.Point(172, 125)
        Me.TxtTwitterImagePath.Name = "TxtTwitterImagePath"
        Me.TxtTwitterImagePath.Size = New System.Drawing.Size(333, 22)
        Me.TxtTwitterImagePath.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 128)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 14)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Twitter Image File Path"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TxtWordPressDate)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TxtWikiExtract)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtTwitterSearch)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TxtWikiSearch)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtWordPress)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TxtImageSearch)
        Me.GroupBox2.Location = New System.Drawing.Point(118, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 331)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "URLs"
        '
        'TxtWordPressDate
        '
        Me.TxtWordPressDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWordPressDate.Location = New System.Drawing.Point(172, 182)
        Me.TxtWordPressDate.Multiline = True
        Me.TxtWordPressDate.Name = "TxtWordPressDate"
        Me.TxtWordPressDate.Size = New System.Drawing.Size(231, 36)
        Me.TxtWordPressDate.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(151, 14)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "WordPress Date Page URL"
        '
        'TxtWikiExtract
        '
        Me.TxtWikiExtract.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWikiExtract.Location = New System.Drawing.Point(172, 233)
        Me.TxtWikiExtract.Multiline = True
        Me.TxtWikiExtract.Name = "TxtWikiExtract"
        Me.TxtWikiExtract.Size = New System.Drawing.Size(231, 61)
        Me.TxtWikiExtract.TabIndex = 19
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 14)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Wiki Extract URL"
        '
        'BtnGlobalSettings
        '
        Me.BtnGlobalSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnGlobalSettings.Font = New System.Drawing.Font("Papyrus", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGlobalSettings.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnGlobalSettings.Location = New System.Drawing.Point(108, 580)
        Me.BtnGlobalSettings.Name = "BtnGlobalSettings"
        Me.BtnGlobalSettings.Size = New System.Drawing.Size(86, 60)
        Me.BtnGlobalSettings.TabIndex = 20
        Me.BtnGlobalSettings.Text = "Global Settings"
        Me.BtnGlobalSettings.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(225, 580)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 14)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Wiki sentences"
        '
        'NudSentences
        '
        Me.NudSentences.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NudSentences.Location = New System.Drawing.Point(329, 578)
        Me.NudSentences.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NudSentences.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NudSentences.Name = "NudSentences"
        Me.NudSentences.Size = New System.Drawing.Size(60, 22)
        Me.NudSentences.TabIndex = 22
        Me.NudSentences.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.BtnRmvWord)
        Me.GroupBox3.Controls.Add(Me.BtnAddWord)
        Me.GroupBox3.Controls.Add(Me.LbSplitWords)
        Me.GroupBox3.Controls.Add(Me.TxtSplitWords)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 216)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(96, 331)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Split words"
        '
        'BtnRmvWord
        '
        Me.BtnRmvWord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnRmvWord.Font = New System.Drawing.Font("Wide Latin", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRmvWord.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnRmvWord.Location = New System.Drawing.Point(54, 302)
        Me.BtnRmvWord.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnRmvWord.Name = "BtnRmvWord"
        Me.BtnRmvWord.Size = New System.Drawing.Size(32, 22)
        Me.BtnRmvWord.TabIndex = 3
        Me.BtnRmvWord.Text = "-"
        Me.BtnRmvWord.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnRmvWord.UseVisualStyleBackColor = True
        '
        'BtnAddWord
        '
        Me.BtnAddWord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnAddWord.Font = New System.Drawing.Font("Wide Latin", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddWord.ForeColor = System.Drawing.Color.RoyalBlue
        Me.BtnAddWord.Location = New System.Drawing.Point(6, 302)
        Me.BtnAddWord.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnAddWord.Name = "BtnAddWord"
        Me.BtnAddWord.Size = New System.Drawing.Size(32, 22)
        Me.BtnAddWord.TabIndex = 2
        Me.BtnAddWord.Text = "+"
        Me.BtnAddWord.UseVisualStyleBackColor = True
        '
        'LbSplitWords
        '
        Me.LbSplitWords.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LbSplitWords.FormattingEnabled = True
        Me.LbSplitWords.ItemHeight = 14
        Me.LbSplitWords.Location = New System.Drawing.Point(6, 17)
        Me.LbSplitWords.Name = "LbSplitWords"
        Me.LbSplitWords.Size = New System.Drawing.Size(84, 256)
        Me.LbSplitWords.Sorted = True
        Me.LbSplitWords.TabIndex = 1
        '
        'TxtSplitWords
        '
        Me.TxtSplitWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtSplitWords.Location = New System.Drawing.Point(6, 278)
        Me.TxtSplitWords.Name = "TxtSplitWords"
        Me.TxtSplitWords.Size = New System.Drawing.Size(84, 22)
        Me.TxtSplitWords.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 161)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 14)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Log File Path"
        '
        'TxtLogFilePath
        '
        Me.TxtLogFilePath.Location = New System.Drawing.Point(172, 158)
        Me.TxtLogFilePath.Name = "TxtLogFilePath"
        Me.TxtLogFilePath.Size = New System.Drawing.Size(333, 22)
        Me.TxtLogFilePath.TabIndex = 11
        '
        'FrmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(549, 687)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.NudSentences)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.BtnGlobalSettings)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnResetForms)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmOptions"
        Me.Text = "Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NudSentences, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtNewImagePath As System.Windows.Forms.TextBox
    Friend WithEvents txtImagePath As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTwitterFilePath As TextBox
    Friend WithEvents Version As Label
    Friend WithEvents BtnResetForms As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtImageSearch As TextBox
    Friend WithEvents TxtWordPress As TextBox
    Friend WithEvents TxtWikiSearch As TextBox
    Friend WithEvents txtTwitterSearch As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BtnGlobalSettings As Button
    Friend WithEvents TxtWikiExtract As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents NudSentences As NumericUpDown
    Friend WithEvents TxtTwitterImagePath As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtWordPressDate As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TxtSplitWords As TextBox
    Friend WithEvents BtnAddWord As Button
    Friend WithEvents LbSplitWords As ListBox
    Friend WithEvents BtnRmvWord As Button
    Friend WithEvents TxtLogFilePath As TextBox
    Friend WithEvents Label12 As Label
End Class

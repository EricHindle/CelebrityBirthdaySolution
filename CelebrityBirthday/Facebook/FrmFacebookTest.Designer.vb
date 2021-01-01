<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFacebookTest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFacebookTest))
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnTest1 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.TxtUAccessKey = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPAccessKey = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(712, 588)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(92, 40)
        Me.BtnCancel.TabIndex = 0
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnTest1
        '
        Me.BtnTest1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnTest1.Location = New System.Drawing.Point(32, 586)
        Me.BtnTest1.Name = "BtnTest1"
        Me.BtnTest1.Size = New System.Drawing.Size(75, 42)
        Me.BtnTest1.TabIndex = 1
        Me.BtnTest1.Text = "Test1"
        Me.BtnTest1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(20, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(815, 259)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'TxtUAccessKey
        '
        Me.TxtUAccessKey.Location = New System.Drawing.Point(20, 319)
        Me.TxtUAccessKey.Multiline = True
        Me.TxtUAccessKey.Name = "TxtUAccessKey"
        Me.TxtUAccessKey.Size = New System.Drawing.Size(772, 58)
        Me.TxtUAccessKey.TabIndex = 3
        Me.TxtUAccessKey.Text = "EAACHZBQRkG5wBADWZCSL1VkG7G0vfZCsNNXvr3egVqsrOxQpMMAZCSxK2LlChtPxPtCxvwMZCxb5Tr2l" &
    "O7uWzooZCEzjP0ILNxbZAteDTUb5ZBUSdwTO9EWrJejZAl8tPxHxcDKb36bkr0DZAqzcZCYhJGnHOJBA" &
    "ZC9jnImRaR7YWfZAihgZDZD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 388)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Page Access Key"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 299)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "User Access Key"
        '
        'TxtPAccessKey
        '
        Me.TxtPAccessKey.Location = New System.Drawing.Point(20, 418)
        Me.TxtPAccessKey.Multiline = True
        Me.TxtPAccessKey.Name = "TxtPAccessKey"
        Me.TxtPAccessKey.Size = New System.Drawing.Size(772, 58)
        Me.TxtPAccessKey.TabIndex = 5
        Me.TxtPAccessKey.Text = "EAACHZBQRkG5wBAAv2iTBdgRzNEHpRhsQcZC8oKdLe9fvDf6dkf9qgMtCdKMHuE7vGU2Yth5oYXZBVXMZ" &
    "AZCfJQf9LdBqzMQQQHtWAuNiXydXQ6j5PfgxYrYuVPtLSqqNW3RGHbWGzvcxSMN53qO5T44RA01sbZCZ" &
    "CbZCkqRZCdXQixb0cZB22CRiph" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'FrmFacebookTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 643)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtPAccessKey)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtUAccessKey)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BtnTest1)
        Me.Controls.Add(Me.BtnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmFacebookTest"
        Me.Text = "FrmFacebookTest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnTest1 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents TxtUAccessKey As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtPAccessKey As TextBox
End Class

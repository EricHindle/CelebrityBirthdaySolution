Public Class FrmOptions

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveOptions()
        Me.Close()
    End Sub

    Private Sub SaveOptions()
        My.Settings.newimagepath = txtNewImagePath.Text
        My.Settings.ImgFolder = txtImagePath.Text
        My.Settings.TwitterFilePath = txtTwitterFilePath.Text
        My.Settings.Save()
    End Sub

    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadOptions()
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

    End Sub

    Private Sub LoadOptions()
        txtNewImagePath.Text = My.Settings.newimagepath
        txtImagePath.Text = My.Settings.ImgFolder
        txtTwitterFilePath.Text = My.Settings.TwitterFilePath
    End Sub
End Class
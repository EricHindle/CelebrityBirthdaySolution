Public Class FrmMenu
    Private Sub BtnMain_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Using _main As New frmMain
            _main.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnImages_Click(sender As Object, e As EventArgs) Handles BtnImages.Click
        Me.Hide()
        Using imgForm As New FrmImages
            imgForm.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnTwitter_Click(sender As Object, e As EventArgs) Handles BtnTwitter.Click
        Me.Hide()
        Using _twitterForm As New frmTwitterOutput
            _twitterForm.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnDatabase_Click(sender As Object, e As EventArgs) Handles BtnDatabase.Click
        Me.Hide()
        Using _database As New FrmUpdateDatabase
            _database.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnOptions_Click(sender As Object, e As EventArgs) Handles BtnOptions.Click
        Me.Hide()
        Using _options As New FrmOptions
            _options.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnPictures_Click(sender As Object, e As EventArgs) Handles BtnPictures.Click
        Me.Hide()
        Using _pictures As New frmImageStore
            _pictures.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Me.Hide()
        Using _search As New FrmSearch
            _search.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnBrowser_Click(sender As Object, e As EventArgs) Handles BtnBrowser.Click
        Me.Hide()
        Using _browser As New FrmBrowser
            _browser.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnWordPress.Click
        Me.Hide()
        Using _wordPress As New FrmWordPress
            _wordPress.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub BtnMosaic_Click(sender As Object, e As EventArgs) Handles BtnMosaic.Click
        Me.Hide()
        Using _mosaic As New FrmTwitterImage
            _mosaic.ShowDialog()
        End Using
        Me.Show()
    End Sub
    Private Sub FrmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.callUpgrade = 0 Then
            My.Settings.Upgrade()
            My.Settings.callUpgrade = 1
            My.Settings.Save()
        End If
    End Sub
End Class
Public Class FrmOptions

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveOptions()
        Me.Close()
    End Sub

    Private Sub SaveOptions()
        My.Settings.NewImagePath = txtNewImagePath.Text
        My.Settings.ImgPath = txtImagePath.Text
        My.Settings.TwitterFilePath = txtTwitterFilePath.Text
        My.Settings.twitterImageFolder = TxtTwitterImagePath.Text
        My.Settings.TwitterSearchUrl = txtTwitterSearch.Text
        My.Settings.WordPressUrl = TxtWordPress.Text
        My.Settings.wikiSearchUrl = TxtWikiSearch.Text
        My.Settings.googleImageSearch = TxtImageSearch.Text
        My.Settings.wikiExtractSearch = TxtWikiExtract.Text
        My.Settings.wikiSentences = NudSentences.Value
        My.Settings.WordPressMonthUrl = TxtWordPressDate.Text
        My.Settings.SplitWords = Replace(TxtSplitWords.Text, vbCrLf, "~")
        My.Settings.Save()
    End Sub

    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadOptions()
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
    End Sub

    Private Sub LoadOptions()
        TxtSplitWords.Text = Replace(My.Settings.SplitWords, "~", vbCrLf)
        txtNewImagePath.Text = My.Settings.NewImagePath
        txtImagePath.Text = My.Settings.ImgPath
        txtTwitterFilePath.Text = My.Settings.TwitterFilePath
        TxtTwitterImagePath.Text = My.Settings.twitterImageFolder
        txtTwitterSearch.Text = My.Settings.TwitterSearchUrl
        TxtWordPress.Text = My.Settings.WordPressUrl
        TxtWikiSearch.Text = My.Settings.wikiSearchUrl
        TxtImageSearch.Text = My.Settings.googleImageSearch
        TxtWikiExtract.Text = My.Settings.wikiExtractSearch
        TxtWordPressDate.Text = My.Settings.WordPressMonthUrl
        NudSentences.Value = My.Settings.wikiSentences
    End Sub

    Private Sub BtnResetForms_Click(sender As Object, e As EventArgs) Handles BtnResetForms.Click
        My.Settings.mainformpos = "5~5~1095~1050"
        My.Settings.findformpos = "5~5~760~1176"
        My.Settings.imgbrowsepos = "5~5~727~1170"
        My.Settings.imgselectpos = "5~5~699~1038"
        My.Settings.updformpos = "5~5~843~1287"
        My.Settings.imgformpos = "5~5~687~1003"
        My.Settings.twitterfilespos = "5~5~600~600"
        My.Settings.twitterimagepos = "5~5~600~600"
        My.Settings.capformpos = "5~5~950~560"
        My.Settings.bwsrformpos = "5~5~1200~730"
        My.Settings.srchformpos = "5~5~1125~600"
        My.Settings.wprformpos = "5~5~1040~670"
        My.Settings.textformpos = "5~5~800~500"
        My.Settings.botsdformpos = "5~5~1300~650"
        My.Settings.Save()
    End Sub

    Private Sub BtnGlobalSettings_Click(sender As Object, e As EventArgs) Handles BtnGlobalSettings.Click
        Me.Hide()

        Using _settings As New FrmGlobalSettings
            _settings.ShowDialog()
        End Using
        Me.Show()
    End Sub
End Class
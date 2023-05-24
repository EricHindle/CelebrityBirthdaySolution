' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text

Public NotInheritable Class FrmOptions

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveOptions()
        Close()
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
        My.Settings.LogFolder = TxtLogFilePath.Text
        Dim sb As New StringBuilder
        For Each splitword As String In LbSplitWords.Items
            sb.Append(splitword).Append("~"c)
        Next
        My.Settings.SplitWords = sb.ToString.TrimEnd("~")
        My.Settings.isSqlServer = chkSqlServer.Checked
        My.Settings.twitterAuthCallback = TxtCallback.Text
        My.Settings.fileRetentionPeriod = NudRetention.Value
        My.Settings.srchShowImages = ChkShowImages.Checked
        My.Settings.Save()
    End Sub

    Private Sub FrmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        LoadOptions()
        Version.Text = System.String.Format(myStringFormatProvider, Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)
    End Sub

    Private Sub LoadOptions()
        For Each splitWord As String In Split(My.Settings.SplitWords, "~")
            LbSplitWords.Items.Add(splitWord)
        Next
        TxtCallback.Text = My.Settings.twitterAuthCallback
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
        TxtLogFilePath.Text = My.Settings.LogFolder
        NudSentences.Value = My.Settings.wikiSentences
        chkSqlServer.Checked = My.Settings.isSqlServer
        NudRetention.Value = My.Settings.fileRetentionPeriod
        ChkShowImages.Checked = My.Settings.srchShowImages
    End Sub

    Private Sub BtnResetForms_Click(sender As Object, e As EventArgs) Handles BtnResetForms.Click
        My.Settings.mainformpos = "5~5~1095~1050"
        My.Settings.findformpos = "5~5~760~1176"
        My.Settings.imgbrowsepos = "5~5~727~1170"
        My.Settings.imgselectpos = "5~5~699~1038"
        My.Settings.updformpos = "5~5~843~1287"
        My.Settings.imgformpos = "5~5~687~1003"
        My.Settings.twitterfilespos = "5~5~600~600"
        My.Settings.twitterAuthFormPos = "104~104~695~864"
        My.Settings.twitterBbFormPos = "208~208~579~741"
        My.Settings.twitterDailyFormPos = "31~83~826~1364"
        My.Settings.twitterMosaicFormPos = "234~234~399~816"
        My.Settings.twitterSingleFormPos = "132~243~637~873"
        My.Settings.capformpos = "5~5~950~560"
        My.Settings.bwsrformpos = "5~5~1200~730"
        My.Settings.srchformpos = "5~5~1125~600"
        My.Settings.wprformpos = "5~5~1040~670"
        My.Settings.textformpos = "5~5~800~500"
        My.Settings.botsdformpos = "5~5~1300~650"
        My.Settings.Save()
    End Sub

    Private Sub BtnGlobalSettings_Click(sender As Object, e As EventArgs) Handles BtnGlobalSettings.Click
        Hide()

        Using _settings As New FrmGlobalSettings
            _settings.ShowDialog()
        End Using
        Show()
    End Sub

    Private Sub BtnAddWord_Click(sender As Object, e As EventArgs) Handles BtnAddWord.Click
        LbSplitWords.Items.Add(TxtSplitWords.Text)
    End Sub

    Private Sub BtnRmvWord_Click(sender As Object, e As EventArgs) Handles BtnRmvWord.Click
        If LbSplitWords.SelectedItems.Count = 1 Then
            LbSplitWords.Items.Remove(LbSplitWords.SelectedItem)
        End If
    End Sub

    Private Sub FrmOptions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub

    Private Sub BtnBackup_Click(sender As Object, e As EventArgs) Handles BtnBackup.Click
        Using _backup As New FrmBackup
            _backup.ShowDialog()
        End Using
    End Sub

    Private Sub BtnHousekeeping_Click(sender As Object, e As EventArgs) Handles BtnHousekeeping.Click
        Dim twitterImageFolder As String = My.Settings.twitterImageFolder
        Dim logFolder As String = My.Settings.LogFolder
        Dim retentionPeriod As Integer = My.Settings.fileRetentionPeriod
        TidyFiles(twitterImageFolder, "*.*", retentionPeriod)
        TidyFiles(logFolder, "*.*", retentionPeriod)
        MsgBox("Tidy complete", MsgBoxStyle.Information, "Housekeeping")
    End Sub
    Public Sub TidyFiles(ByVal sFolder As String, ByVal sPattern As String, ByVal iRetain As Integer, Optional ByVal bSubfolders As Boolean = False)
        Dim oDirInfo As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(sFolder)
        LogUtil.Info("Tidying files in " & sFolder & " older than " & iRetain & " days", "TidyFiles")
        Try
            Dim oFileList As FileInfo() = oDirInfo.GetFiles(sPattern, If(bSubfolders, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly))
            For Each oFileInfo As FileInfo In oFileList
                If (oFileInfo.Attributes And FileAttributes.ReadOnly) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.Hidden) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.System) = 0 _
                       And (oFileInfo.Attributes And FileAttributes.Directory) = 0 Then
                    Dim oDate As Date = oFileInfo.LastWriteTime
                    Dim iDaysOld As Integer = DateDiff("d", oDate, Now)
                    If iDaysOld >= iRetain Then
                        Try
                            My.Computer.FileSystem.DeleteFile(oFileInfo.FullName)
                            LogUtil.Info(oFileInfo.Name & " - " & iDaysOld & " days old - deleted", "TidyFiles")
                        Catch ex As Exception
                            LogUtil.Exception("Unable to remove " & oFileInfo.FullName, ex, "TidyFiles")
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            LogUtil.Exception("Problem tidying files", ex, "TidyFiles")
        End Try
    End Sub
End Class
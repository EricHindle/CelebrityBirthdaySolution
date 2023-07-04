' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Net
Imports System.Text
Imports Tweetinvi.Core.Web

Public Class FrmSingleTweet
#Region "properties"
    Private _sendAs As String
    Private _tweetText As String
    Public Property TweetText() As String
        Get
            Return _tweetText
        End Get
        Set(ByVal value As String)
            _tweetText = value
        End Set
    End Property
    Public Property SendAs() As String
        Get
            Return _sendAs
        End Get
        Set(ByVal value As String)
            _sendAs = value
        End Set
    End Property
#End Region
#Region "variables"
    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil
    Private ReadOnly oTweetTa As New CelebrityBirthdayDataSetTableAdapters.TweetsTableAdapter
#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub FrmSendTwitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.twitterSingleFormPos)
        NudSentences.Value = My.Settings.wikiSentences
        RtbTweetText.AllowDrop = True
        FillTwitterUserList()
        cmbTwitterUsers.SelectedIndex = cmbTwitterUsers.FindStringExact(SendAs)
        RtbTweetText.Text = TweetText
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        BtnSend.Enabled = False
        Dim isOkToSend As Boolean = True
        If cmbTwitterUsers.SelectedIndex < 0 Then
            isOkToSend = False
        End If
        If isOkToSend Then
            WriteTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
            SendTheTweet()
            WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))
        Else
            WriteTrace("Tweet not sent")
        End If
        BtnSend.Enabled = True
    End Sub
    Private Sub FrmSendTwitter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        oTweetTa.Dispose()
        My.Settings.twitterSingleFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub CopyToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        GetSourceControl(menuItem).Copy()
    End Sub
    Private Sub CutToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        GetSourceControl(menuItem).Cut()
    End Sub
    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(sender)

        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox?.SelectAll()
        End If

    End Sub
    Private Sub PasteToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Paste()
        End If

    End Sub
    Private Sub ClearToolStripMenuItem_Click(ByVal menuItem As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Dim sourceControl As Object = GetSourceControl(menuItem)
        If TypeOf sourceControl Is TextBox Or TypeOf sourceControl Is RichTextBox Then
            Dim _textBox As TextBoxBase = CType(sourceControl, TextBoxBase)
            _textBox.Text = ""
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub
    Private Sub ClearForm()
        TxtForename.Text = ""
        TxtSurname.Text = ""
        rtbTweetProgress.Text = ""
        RtbTweetText.Text = ""
        PictureBox1.Image = My.Resources.NoImage
        PictureBox2.Image = Nothing
        LblTweetLength.Text = ""
        LblImageName.Text = ""
        LblImageFile.Text = ""
    End Sub
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs) Handles BtnSaveImage.Click
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _fileName As String = GetUniqueFname(Path.Combine(_path, My.Resources.SINGLE_TWEET) & ".jpg")
        oImageUtil.SaveImageFromPictureBox(PictureBox2, PictureBox2.Width, PictureBox2.Height, _fileName)
    End Sub
    Private Sub BtnClearImages_Click(sender As Object, e As EventArgs) Handles BtnClearImages.Click
        If MsgBox("Confirm delete tweet images", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.twitterImageFolder, FileIO.SearchOption.SearchTopLevelOnly, {My.Resources.SINGLE_TWEET & "*.*"})
            For Each _imageFile As String In _imageList
                My.Computer.FileSystem.DeleteFile(_imageFile)
            Next
        End If
    End Sub
    Private Sub TxtForename_TextChanged(sender As Object, e As EventArgs) Handles TxtSurname.TextChanged, TxtForename.TextChanged
        If Not String.IsNullOrEmpty(TxtForename.Text) Or Not String.IsNullOrEmpty(TxtSurname.Text) Then
            LblImageName.Text = MakeImageName(TxtForename.Text, TxtSurname.Text)
            Dim thumbnailImage As String = ""
            Dim _list As List(Of Person) = GetPeopleByName(TxtForename.Text, TxtSurname.Text)
            If _list.Count = 1 Then
                Dim oPerson As Person = _list(0)
                If oPerson.Image IsNot Nothing Then
                    thumbnailImage = Path.Combine(My.Settings.ImgPath, oPerson.Image.ImageFileName & oPerson.Image.ImageFileType)
                    RtbTweetText.Text = oPerson.Description
                End If
            Else
                thumbnailImage = Path.Combine(My.Settings.ImgPath, LblImageName.Text) & ".jpg"
                RtbTweetText.Text = GetWikiText(NudSentences.Value)
            End If
            LblImageFile.Text = thumbnailImage
            PictureBox1.ImageLocation = thumbnailImage
            CreateTwitterImage(thumbnailImage)
        Else
            ClearForm()
        End If
    End Sub
    Private Sub RtbTweetText_TextChanged(sender As Object, e As EventArgs) Handles RtbTweetText.TextChanged
        Dim _tweetLength As Integer = RtbTweetText.Text.Replace(vbCr, "").Length
        LblTweetLength.Text = If(_tweetLength > 280, "** ", "") & _tweetLength
    End Sub
    Private Sub BtnImage_Click(sender As Object, e As EventArgs) Handles BtnImage.Click
        If Not String.IsNullOrEmpty(TxtForename.Text) Or Not String.IsNullOrEmpty(TxtSurname.Text) Then
            LblImageName.Text = MakeImageName(TxtForename.Text, TxtSurname.Text)
            Using _imagestore As New FrmImageStore
                _imagestore.Forename = TxtForename.Text.Trim
                _imagestore.Surname = TxtSurname.Text.Trim
                _imagestore.ShowDialog()
                PictureBox1.ImageLocation = _imagestore.SavedImage
                CreateTwitterImage(_imagestore.SavedImage)
            End Using
        Else
            MsgBox("No name supplied", MsgBoxStyle.Exclamation, "Name missing")
        End If
    End Sub
    Private Sub BtnCreateFullName_Click(sender As Object, e As EventArgs) Handles BtnCreateFullName.Click
        TxtName.Text = If(String.IsNullOrEmpty(TxtForename.Text), "", TxtForename.Text.Trim & " ") & TxtSurname.Text.Trim
    End Sub
    Private Sub BtnSplitName_Click(sender As Object, e As EventArgs) Handles BtnSplitName.Click
        TxtName.Text = TxtName.Text.Trim
        Dim names As String() = Split(TxtName.Text, " ")
        TxtSurname.Text = names(UBound(names))
        If Not String.IsNullOrEmpty(TxtSurname.Text) Then
            TxtForename.Text = TxtName.Text.Replace(TxtSurname.Text, "").Trim
        End If
    End Sub
    Private Sub TextBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TxtName.DragDrop,
                                                                                            TxtForename.DragDrop,
                                                                                            TxtSurname.DragDrop

        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            Dim oBox As TextBox = CType(sender, TextBox)
            Dim item As String = e.Data.GetData(DataFormats.StringFormat)
            Dim textlen As Integer = oBox.TextLength
            Dim startpos As Integer = oBox.SelectionStart
            If textlen = 0 Then
                oBox.Text = item.Trim
            Else
                If startpos = 0 Then
                    oBox.SelectedText = item.TrimStart
                Else
                    If oBox.Text.Substring(startpos - 1, 1) = "." Then
                        oBox.SelectedText = " " & item.TrimStart
                    Else
                        oBox.SelectedText = item
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub TextBox_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtName.DragOver,
                                                                                                                TxtForename.DragOver,
                                                                                                                TxtSurname.DragOver

        Try
            If e.Data.GetDataPresent(DataFormats.StringFormat) Then
                Dim oBox As TextBox = CType(sender, TextBox)
                oBox.Select(TextBoxCursorPos(oBox, e.X, e.Y), 0)
            End If
        Catch ex As InvalidCastException

        End Try
    End Sub
    Private Sub TextBox_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TxtForename.DragEnter,
                                                                                                                TxtSurname.DragEnter,
                                                                                                                TxtName.DragEnter
        If e.Data.GetDataPresent(DataFormats.StringFormat) Then
            e.Effect = DragDropEffects.Copy
        Else
            If e.Data.GetDataPresent(DataFormats.Text) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If
        End If
    End Sub
    Private Sub BtnGetWikiText_Click(sender As Object, e As EventArgs) Handles BtnGetWikiText.Click
        RtbTweetText.Text = GetWikiText(NudSentences.Value)
    End Sub
#End Region
#Region "subroutines"
    Private Shared Function GetTwitterName(_innerHtml As String) As String
        Dim _pos1 As Integer = _innerHtml.IndexOf("span class=""name""", StringComparison.CurrentCultureIgnoreCase) + 18
        Dim _pos2 As Integer = _innerHtml.IndexOf("/span", _pos1, StringComparison.CurrentCultureIgnoreCase)
        Dim _twitterName As String = "Unknown"
        If _pos1 > 0 AndAlso _pos2 > _pos1 Then
            _twitterName = _innerHtml.Substring(_pos1, _pos2 - _pos1 - 1)
        End If
        Return _twitterName
    End Function
    Private Sub FillTwitterUserList()
        cmbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            cmbTwitterUsers.Items.Add(_user)
        Next
    End Sub
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweetProgress.Text &= vbCrLf & sText
        LogUtil.Info(sText, MyBase.Name)
    End Sub
    Private Async Sub SendTheTweet()
        Dim _tweetText As String = RtbTweetText.Text
        Dim _imageFile As String = Nothing
        If chkImages.Checked Then
            If My.Computer.FileSystem.FileExists(LblImageFile.Text) Then
                WriteTrace("Saving Image")
                Dim _path As String = My.Settings.twitterImageFolder
                If Not My.Computer.FileSystem.DirectoryExists(_path) Then
                    My.Computer.FileSystem.CreateDirectory(_path)
                End If
                Dim _fileName As String = GetUniqueFname(Path.Combine(_path, My.Resources.SINGLE_TWEET) & ".jpg")
                _imageFile = oImageUtil.SaveImageFromPictureBox(PictureBox2, PictureBox2.Width, PictureBox2.Height, _fileName)
                WriteTrace("Saved to " & _fileName)
            Else
                WriteTrace("Image not found")
            End If
        End If
        WriteTrace("Posting tweet")
        Dim result As ITwitterResult = Await PostTheTweet(_tweetText, cmbTwitterUsers.SelectedItem, _imageFile)
        If result.Response.IsSuccessStatusCode = True Then
            WriteTrace("OK: " & CStr(result.Response.StatusCode))
        Else
            WriteTrace("Tweet Failed : " & CStr(result.Response.StatusCode))
        End If
    End Sub
    Private Sub CreateTwitterImage(_image As String)
        LblImageFile.Text = _image
        Dim _imageidentity As New ImageIdentity(-1, _image, "", "", "")
        Dim _person As New Person(TxtForename.Text, TxtSurname.Text, "", "", 0, 0, 0, 0, 0, 0, "", "", _imageidentity, Nothing)
        Dim _pictureList As New List(Of Person) From {_person}
        ModCbImageUtil.GenerateImage(PictureBox2, _pictureList, 1, 1, HindlewareLib.Imaging.ImageUtil.AlignType.Centre)
        WriteTrace("Generated image")
    End Sub
    Private Function GetWikiText(_sentences As Integer) As String
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(TxtName.Text, _sentences))
        Dim extract As String = GetExtractFromResponse(_response)
        Return extract
    End Function
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, lblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, lblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
#End Region
End Class
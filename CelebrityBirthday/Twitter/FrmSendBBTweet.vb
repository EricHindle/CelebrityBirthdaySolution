' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports Tweetinvi.Core.Web

Public Class FrmSendBBTweet
#Region "properties"
    Private _shortDesc As String
    Private _birthDate As DateTime
    Private _deathDate As DateTime
    Private _longDesc As String
    Private _deadPerson As Person
    Private oImageUtil As New HindlewareLib.Imaging.ImageUtil
    Public Property DeadPerson() As Person
        Get
            Return _deadPerson
        End Get
        Set(ByVal value As Person)
            _deadPerson = value
        End Set
    End Property
#End Region
#Region "variables"

    Private ReadOnly oSender As String = GlobalSettings.GetSetting("BBREAD_USER")
    Private ReadOnly vowels As Char() = {"a"c, "e"c, "i"c, "o"c, "u"c}

#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub FrmSendBBTweet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.twitterBbFormPos)
        RtbTweetText.AllowDrop = True
        TxtSuffix.Text = ".jpg"
        If _deadPerson IsNot Nothing Then
            _shortDesc = _deadPerson.ShortDesc
            _longDesc = _deadPerson.Description
            _birthDate = _deadPerson.DateOfBirth
            _deathDate = _deadPerson.DateOfDeath
            TxtForename.Text = _deadPerson.ForeName
            TxtSurname.Text = _deadPerson.Surname
            TxtName.Text = _deadPerson.Name
        End If
        LblImageName.Text = _deadPerson.Image.ImageFileName
        Dim thumbnailImage As String = Path.Combine(My.Settings.ImgPath, LblImageName.Text) & ".jpg"
        If My.Computer.FileSystem.FileExists(thumbnailImage) Then
            PictureBox1.ImageLocation = thumbnailImage
            CreateTwitterImage(thumbnailImage)
        End If
        Dim desc As String = _deadPerson.Description
        Dim text1 As String() = Split(_deadPerson.Description, "(", 2)
        If text1.Length > 1 Then
            Dim text2 As String() = Split(text1(1), ")", 2)
            If text2.Length > 1 Then
                desc = text1(0).TrimEnd & " " & text2(1).TrimStart
            End If
        End If
        Dim tweetText As New StringBuilder
        tweetText.Append(_deadPerson.ShortDesc.Trim(".")) _
                .Append(" "c) _
                .Append(_deadPerson.Name) _
                .Append(" has died aged ") _
                .Append(CStr(CalculateAge())) _
                .Append("."c) _
                .Append(vbCrLf).Append(vbCrLf)
        tweetText.Append(desc) _
                .Append(vbCrLf).Append(vbCrLf)
        tweetText.Append(_deadPerson.Name) _
                .Append(" "c) _
                .Append(Format(_birthDate, "dd/MM/yyyy")) _
                .Append(" - ") _
                .Append(Format(_deathDate, "dd/MM/yyyy")) _
                .Append(vbCrLf)
        RtbTweetText.Text = tweetText.ToString
        If String.IsNullOrWhiteSpace(oSender) Then
            MsgBox("No Twitter User Setting", MsgBoxStyle.Critical, "Twitter Error")
            Close()
        End If
    End Sub
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        WriteTrace("Sending Tweet")
        BtnSend.Enabled = False
        Dim isOkToSend As Boolean = True
        If RtbTweetText.Text.Replace(vbCr, "").Length > TWEET_MAX_LEN Then
            isOkToSend = False
            WriteTrace("Message too long to send")
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
        My.Settings.twitterBbFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub RtbTweetText_TextChanged(sender As Object, e As EventArgs) Handles RtbTweetText.TextChanged
        Dim _tweetLength As Integer = RtbTweetText.Text.Replace(vbCr, "").Length
        LblTweetLength.Text = If(_tweetLength > 280, "** ", "") & _tweetLength
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
#End Region
#Region "subroutines"
    Private Function ShortdescStartsWithVowel(shortDesc As String) As Boolean
        Return shortDesc.ToLower.IndexOfAny(vowels) >= 0
    End Function
    Private Sub WriteTrace(sText As String)
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
        Dim result As ITwitterResult = Await PostTheTweet(_tweetText, oSender, _imageFile)
        If result.Response.IsSuccessStatusCode = True Then
            WriteTrace("OK: " & result.Response.StatusCode)
        Else
            WriteTrace("Tweet Failed : " & result.Response.StatusCode)
        End If
    End Sub

    Private Sub CreateTwitterImage(_image As String)
        LblImageFile.Text = _image
        Dim _imageidentity As New ImageIdentity(-1, _image, "", "", "")
        Dim _person As New Person(-1, TxtForename.Text, TxtSurname.Text, "", "", 0, 0, 0, 0, 0, 0, "", "", _imageidentity, Nothing)
        Dim _pictureList As New List(Of Person) From {_person}
        ModCbImageUtil.GenerateImage(PictureBox2, _pictureList, 1, 1, HindlewareLib.Imaging.ImageUtil.AlignType.Centre)
        WriteTrace("Created image")
    End Sub
    Public Function CalculateAge() As Integer
        Dim bdiff As Integer = 0
        If _birthDate < _deathDate Then
            bdiff = DateDiff(DateInterval.Year, _birthDate, _deathDate)
            If _birthDate > _deathDate.AddYears(-bdiff) Then bdiff -= 1
        End If
        Return bdiff
    End Function

    Private Sub TxtSuffix_TextChanged(sender As Object, e As EventArgs) Handles TxtSuffix.TextChanged
        Dim thumbnailImage As String = Path.Combine(My.Settings.ImgPath, LblImageName.Text) & TxtSuffix.Text
        If My.Computer.FileSystem.FileExists(thumbnailImage) Then
            PictureBox1.ImageLocation = thumbnailImage
            CreateTwitterImage(thumbnailImage)
        End If
    End Sub
#End Region
End Class
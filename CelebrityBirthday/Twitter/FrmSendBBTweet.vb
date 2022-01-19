﻿' Hindleware
' Copyright (c) 2021, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Text
Imports TweetSharp
Public Class FrmSendBBTweet
#Region "properties"
    Private _shortDesc As String
    Private _birthDate As DateTime
    Private _deathDate As DateTime
    Private _longDesc As String
    Private _deadPerson As Person
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
    Private isDone As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private ReadOnly oSender As String = "WhosBrownBread"
    Private ReadOnly vowels As Char() = {"a"c, "e"c, "i"c, "o"c, "u"c}

#End Region
#Region "form handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub FrmSendTwitter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.sndtwformpos)
        RtbTweetText.AllowDrop = True
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
        If _deadPerson IsNot Nothing Then
            _shortDesc = _deadPerson.ShortDesc
            _longDesc = _deadPerson.Description
            _birthDate = _deadPerson.DateOfBirth
            _deathDate = _deadPerson.DateOfDeath
            TxtForename.Text = _deadPerson.ForeName
            TxtSurname.Text = _deadPerson.Surname
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
            .Append(" ") _
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
    End Sub
    Private Function ShortdescStartsWithVowel(shortDesc As String) As Boolean
        Return shortDesc.ToLower.IndexOfAny(vowels) >= 0
    End Function
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Dim isOkToSend As Boolean = True
        'If cmbTwitterUsers.SelectedIndex >= 0 Then
        Dim _auth As TwitterOAuth = GetAuthById(oSender)
        ' Dim _auth As TwitterOAuth = GetAuthById(cmbTwitterUsers.SelectedItem)
        If _auth IsNot Nothing Then
            If String.IsNullOrEmpty(_auth.Verifier) Then
                isOkToSend = False
            Else
                tw.Verifier = _auth.Verifier
            End If
            If String.IsNullOrEmpty(_auth.Token) Then
                isOkToSend = False
            Else
                tw.Token = _auth.Token
            End If
            If String.IsNullOrEmpty(_auth.TokenSecret) Then
                isOkToSend = False
            Else
                tw.TokenSecret = _auth.TokenSecret
            End If
        Else
            isOkToSend = False
        End If
        'End If
        WriteTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
        isDone = False
        If isOkToSend Then
            SendTheTweet()
        End If
        WriteTrace(isDone)
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))
    End Sub
    Private Sub FrmSendTwitter_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.sndtwformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub RtbTweetText_TextChanged(sender As Object, e As EventArgs) Handles RtbTweetText.TextChanged
        Dim _tweetLength As Integer = RtbTweetText.Text.Replace(vbCr, "").Length
        LblTweetLength.Text = If(_tweetLength > 280, "** ", "") & CStr(_tweetLength)
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
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweetProgress.Text &= vbCrLf & sText
        If isStatus Then ShowStatus(sText)
        LogUtil.Info(sText, MyBase.Name)
    End Sub
    Private Sub SendTheTweet()
        WriteTrace("Sending Tweet")
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = RtbTweetText.Text
        sto.Status = msg.Substring(0, Math.Min(msg.Length, TWEET_MAX_LEN)) ' max tweet length; tweets fail if too long...
        Dim _mediaId As String = Nothing
        Dim _imageFile As String = Nothing
        If chkImages.Checked Then
            If My.Computer.FileSystem.FileExists(LblImageFile.Text) Then
                WriteTrace("Saving Image")
                Dim _path As String = My.Settings.twitterImageFolder
                If Not My.Computer.FileSystem.DirectoryExists(_path) Then
                    My.Computer.FileSystem.CreateDirectory(_path)
                End If
                Dim _fileName As String = GetUniqueFname(Path.Combine(_path, My.Resources.SINGLE_TWEET) & ".jpg")
                _imageFile = ImageUtil.SaveImageFromPictureBox(PictureBox2, PictureBox2.Width, PictureBox2.Height, _fileName)
                WriteTrace("Saved to " & _fileName)
                WriteTrace("Posting image")
                Dim _twitterUplMedia As TwitterUploadedMedia = PostMedia(twitter, _imageFile)
                If _twitterUplMedia IsNot Nothing Then
                    Dim _uploadedSize As Long = _twitterUplMedia.Size
                    Dim _uploadedImage As UploadedImage = _twitterUplMedia.Image
                    WriteTrace("Image upload size: " & CStr(_uploadedSize), False)
                    _mediaId = _twitterUplMedia.Media_Id
                Else
                    WriteTrace("No image upload", False)
                End If
            End If
        End If
        If Not String.IsNullOrEmpty(_mediaId) Then
            InsertTweet(_imageFile, Today.Month + 1, Today.Day + 1, 1, _mediaId, oSender, "I")
            sto.MediaIds = {_mediaId}
        End If
        WriteTrace("Sending tweet")
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        If _twitterStatus IsNot Nothing Then
            InsertTweet(sto.Status, Today.Month + 1, Today.Day + 1, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
            WriteTrace("OK: " & _twitterStatus.Id, True)
        Else
            ' tweet failed
            WriteTrace("Failed", True)
        End If
    End Sub
    Private Sub ShowStatus(pText As String)
        lblStatus.Text = pText
        StatusStrip1.Refresh()
    End Sub
    Private Shared Function StatusToString(pStatus As TweetSharp.TwitterStatus) As String
        Dim statusText As New StringBuilder()
        statusText _
            .Append("Id=").Append(pStatus.IdStr).Append(vbCrLf) _
            .Append("FullText=").Append(pStatus.FullText).Append(vbCrLf) _
            .Append("Author=").Append(pStatus.Author.ScreenName).Append(vbCrLf) _
            .Append("User=").Append(pStatus.User.ScreenName).Append("("c).Append(pStatus.User.Name).Append(")"c).Append(vbCrLf)
        Return statusText.ToString
    End Function
    Private Sub CreateTwitterImage(_image As String)
        LblImageFile.Text = _image
        Dim _imageidentity As New ImageIdentity(-1, _image, "", "", "")
        Dim _person As New Person(TxtForename.Text, TxtSurname.Text, "", "", 0, 0, 0, 0, 0, 0, "", "", _imageidentity, Nothing)
        Dim _pictureList As New List(Of Person) From {_person}
        ImageUtil.GenerateImage(PictureBox2, _pictureList, 1, 1, ImageUtil.AlignType.Centre)
        WriteTrace("Created image")
    End Sub
    Public Function CalculateAge() As Integer
        Dim bdiff As Integer = 0
        If _birthDate < _deathDate Then
            bdiff = DateDiff(DateInterval.Year, _birthDate, _deathDate)
            If (_birthDate > _deathDate.AddYears(-bdiff)) Then bdiff -= 1
        End If
        Return bdiff
    End Function
#End Region
End Class
Imports System.IO
Imports TweetSharp

Public Class FrmBotsd
    Private oImagePair As New List(Of Person)
    Private IsNoGenerate As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private _day As Integer
    Private _month As Integer
    Public Property ThisMonth() As Integer
        Get
            Return _month
        End Get
        Set(ByVal value As Integer)
            _month = value
        End Set
    End Property
    Public Property ThisDay() As Integer
        Get
            Return _Day
        End Get
        Set(ByVal value As Integer)
            _Day = value
        End Set
    End Property
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnSendClick(sender As Object, e As EventArgs)
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            SendTweet(SaveImage())
        Else
            Using _sendTweet As New FrmSendTwitter
                _sendTweet.TweetText = rtbFile1.Text
                _sendTweet.ShowDialog()
            End Using
        End If
    End Sub
    Private Function SaveImage() As String
        DisplayStatus("Saving File")
        Dim _path As String = My.Settings.twitterImageFolder
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _add As String = "BOTSD"
        Dim _fileName As String = Path.Combine(_path, _add.Replace("_", "_" & LblDay.Text & "_" & LblMonth.Text & "_mosaic_") & ".jpg")

        ImageUtil.saveImageFromPictureBox(PictureBox1, PictureBox1.Width, PictureBox1.Height, _fileName)
        DisplayStatus("File saved")
        Return _fileName
    End Function
    Private Sub FillTwitterUserList()
        cmbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            cmbTwitterUsers.Items.Add(_user)
        Next
    End Sub
    Private Sub GeneratePicture(_pictureBox As PictureBox, _imageTable As List(Of Person), _width As Integer)
        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            ImageUtil.GenerateImage(_pictureBox, _imageTable, _width, _height)
        Else
            _pictureBox.Image = Nothing
        End If
    End Sub

    Private Sub NudPic1Horizontal_ValueChanged(sender As Object, e As EventArgs) Handles NudPic1Horizontal.ValueChanged
        If Not IsNoGenerate Then
            GeneratePicture(PictureBox1, oImagePair, NudPic1Horizontal.Value)
        End If
    End Sub

    Private Sub SendTweet(_filename As String)
        Dim isOkToSend As Boolean = True
        If cmbTwitterUsers.SelectedIndex >= 0 Then
            Try
                Dim _auth As TwitterOAuth = GetAuthById(cmbTwitterUsers.SelectedItem)
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
            Catch ex As Exception
                WriteTrace(ex.Message)
                isOkToSend = False
            End Try
        End If
        WriteTrace("Entering SendTweet " & Format(Now, "hh:MM:ss"))
        If isOkToSend Then
            SendTheTweet(rtbFile1.Text, _filename)
        End If
        WriteTrace("Back from SendTweet " & Format(Now, "hh:MM:ss"))

    End Sub
    Private Sub SendTheTweet(_tweetText As String, Optional _filename As String = Nothing)
        DisplayStatus("Sending Tweet")
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = _tweetText
        sto.Status = msg.Substring(0, Math.Min(msg.Length, 280)) ' max tweet length; tweets fail if too long...
        Dim _mediaId As String = Nothing
        If chkImages.Checked Then
            Dim _twitterUplMedia As TwitterUploadedMedia = PostMedia(twitter, _filename)
            If _twitterUplMedia IsNot Nothing Then
                Dim _uploadedSize As Long = _twitterUplMedia.Size
                Dim _uploadedImage As UploadedImage = _twitterUplMedia.Image
                WriteTrace("Image upload size: " & CStr(_uploadedSize), False)
                _mediaId = _twitterUplMedia.Media_Id
            Else
                WriteTrace("No image upload", False)
            End If
        End If
        If Not String.IsNullOrEmpty(_mediaId) Then
            InsertTweet("", _month, _day, 1, _mediaId, cmbTwitterUsers.SelectedItem, "I")
            sto.MediaIds = {_mediaId}
        End If
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        If _twitterStatus IsNot Nothing Then
            InsertTweet(sto.Status, _month, _day, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
            WriteTrace("OK: " & _twitterStatus.Id, True)
        Else
            ' tweet failed
            WriteTrace("Failed", True)
        End If
    End Sub
    Private Sub WriteTrace(sText As String, Optional isStatus As Boolean = False)
        rtbTweet.Text &= vbCrLf & sText
        If isStatus Then DisplayStatus(sText)
    End Sub
    Private Sub DisplayStatus(_text As String, Optional _isAppend As Boolean = False)
        If _isAppend Then
            LblStatus.Text &= _text
        Else
            LblStatus.Text = _text
        End If
        StatusStrip1.Refresh()
    End Sub

    Private Sub FrmBotsd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblMonth.Text = Format(New Date(2000, _month, 1), "MMMM")
        LblDay.Text = CStr(_day)
        GetAuthData()
        FillTwitterUserList()
    End Sub
    Private Sub GetAuthData()
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
    End Sub

    Public Sub AddPair(ByRef _person1 As Person, _person2 As Person)
        Dim _pairRow As DataGridViewRow = dgvPairs.Rows(dgvPairs.Rows.Add())
        _pairRow.Cells(pairId1.Name).Value = _person1.Id
        _pairRow.Cells(pairId2.Name).Value = _person2.Id
        _pairRow.Cells(pairPerson1.Name).Value = _person1.Name
        _pairRow.Cells(pairPerson2.Name).Value = _person2.Name
    End Sub

    Private Sub dgvPairs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPairs.SelectionChanged
        If dgvPairs.SelectedRows.Count = 1 Then
            Try
                Dim _pickPerson1 As Person = GetFullPersonById(dgvPairs.SelectedRows(0).Cells(pairId1.Name).Value)
                Dim _pickPerson2 As Person = GetFullPersonById(dgvPairs.SelectedRows(0).Cells(pairId2.Name).Value)
                TxtForename1.Text = _pickPerson1.ForeName
                TxtSurname1.Text = _pickPerson1.Surname
                DtpDob1.Value = _pickPerson1.DateOfBirth.Value
                TxtShortDesc1.Text = _pickPerson1.ShortDesc
                LblId1.Text = CStr(_pickPerson1.Id)
                TxtForename2.Text = _pickPerson2.ForeName
                TxtSurname2.Text = _pickPerson2.Surname
                DtpDob2.Value = _pickPerson2.DateOfBirth.Value
                TxtShortDesc2.Text = _pickPerson2.ShortDesc
                LblId2.Text = CStr(_pickPerson2.Id)
            Catch ex As Exception
                DisplayStatus("Person exception")
            End Try
        End If
    End Sub
End Class
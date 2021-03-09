Imports System.Timers
Imports TweetSharp
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Reflection
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Public Class BirthdayTweets
#Region "enum"
    Private Enum TweetType
        Birthday
        Anniversary
        Full
    End Enum
#End Region
#Region "constants"
    Private Const NUD_BASENAME As String = "NudHorizontal"
    Private Const PICBOX_BASENAME As String = "pictureBox"
    Private Const SC_BASENAME As String = "SplitContainer"
    Private ReadOnly vbcrlf As Char = Convert.ToChar(vbLf, myStringFormatProvider)
    Private Const LAST_CELEB_TWEET As String = "LastCelebTweet"
    Private Const LAST_HBURPDAY_TWEET As String = "LastHBurpdayTweet"
    Private Const TWEET_TIME As String = "TweetTime"
    Private Shared Timer1 As System.Timers.Timer
    Private Const BIRTHDAY_HDR As String = "Birthdays_"
    Private Const ANNIV_HDR As String = "Anniv_"
    Private Const LINEFEED As String = Chr(13) + Chr(10)
#End Region
#Region "variables"
    Private Shared personTable As New List(Of Person)
    Private Shared oBirthdayList As New List(Of Person)
    Private Shared oAnniversaryList As New List(Of Person)
    Private Shared oTweetLists As New List(Of List(Of Person))
    Private Shared IsNoGenerate As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private Shared isBuildingTrees As Boolean
    Private Shared tvBirthday As TreeView
#End Region
    Protected Overrides Sub OnStart(ByVal args() As String)
        Timer1 = New System.Timers.Timer
        AddHandler Timer1.Elapsed, AddressOf Timer1_Tick
        LogUtil.LogFolder = My.Settings.LogFolder
        LogUtil.InitialiseLogging()
        LogUtil.StartLogging()
        Timer1.Interval = 10000
        Timer1.Start()
    End Sub
    Protected Overrides Sub OnStop()
        Timer1.Stop()
        LogUtil.Info("Stopping the Service")
        LogUtil.StopLogging()
        ' Add code here to perform any tear-down necessary to stop your service.
        MyBase.OnStop()
    End Sub

    Protected Overrides Sub OnShutdown()
        Timer1.Stop()
        LogUtil.Info("Shutdown detected")
        LogUtil.StopLogging()
        MyBase.OnShutdown()
    End Sub

    Protected Overrides Sub OnPause()
        LogUtil.Info("Service paused")
        Timer1.Stop()
        MyBase.OnPause()
    End Sub

    Protected Overrides Sub OnContinue()
        LogUtil.Info("Service continues")
        Timer1.Start()
        MyBase.OnContinue()
    End Sub

    Private Shared Sub Timer1_Tick(source As Object, e As ElapsedEventArgs)
        Try
            LogUtil.Info("----------------------------------------- start")
            Timer1.Stop()
            LogUtil.Info("Stopped timer")
            Dim celebLastTweetDate As Date = GlobalSettings.GetSetting(LAST_CELEB_TWEET)
            Dim hburpdayLastTweetDate As Date = GlobalSettings.GetSetting(LAST_HBURPDAY_TWEET)
            Dim todaysDate As String = Format(Today.Date, "yyyy-MM-dd")
            Dim tweetTime As DateTime = CDate(todaysDate & " " & GlobalSettings.GetSetting(TWEET_TIME))
            Try
                If celebLastTweetDate < Today.Date Then
                    If Now > tweetTime Then
                        LogUtil.Info("Sending CeleBirthday tweets for " & todaysDate)
                        LogUtil.Info("Selecting people")
                        SelectPeople()
                        '                    SendCbBirthdayTweets()
                        '                    SendCbAnniversaryTweets()
                        GlobalSettings.SetSetting(LAST_CELEB_TWEET, "date", todaysDate, "")
                        LogUtil.Info("CeleBirthday tweets complete for " & todaysDate)
                    End If
                End If
            Catch ex As Exception
                LogUtil.Exception("CeleBirthday tweets failed", ex)
            End Try
            Try
                If hburpdayLastTweetDate < Today.Date Then
                    If Now > tweetTime Then
                        LogUtil.Info("Sending HBurpday tweets for " & todaysDate)
                        LogUtil.Info("Selecting people")
                        SelectPeople()

                        '                    SendHbBirthdayTweets()
                        '                    SendHbAnniversaryTweets()
                        GlobalSettings.SetSetting(LAST_HBURPDAY_TWEET, "date", todaysDate, "")
                        LogUtil.Info("HBurpday tweets complete for " & todaysDate)
                    End If
                End If
            Catch ex As Exception
                LogUtil.Exception("HBurpday tweets failed", ex)
            End Try
            LogUtil.Info("Restarted timer")
            LogUtil.Info("------------------------------------------- end")
            Timer1.Start()
        Catch ex As Exception
            LogUtil.Exception("Failed", ex)
        End Try
    End Sub

    Private Sub SendHbAnniversaryTweets()
        Throw New NotImplementedException()
    End Sub

    Private Sub SendHbBirthdayTweets()
        Throw New NotImplementedException()
    End Sub

    Private Sub SendCbAnniversaryTweets()
        Throw New NotImplementedException()
    End Sub

    Private Sub SendCbBirthdayTweets()
        Throw New NotImplementedException()
    End Sub

    Private Shared Sub SelectPeople()
        If BuildTrees() Then
            GenerateAllTweets()
        Else
            LogUtil.Info("No people selected")
        End If
    End Sub
    Private Shared Function BuildTrees() As Boolean
        LogUtil.Info("Building trees")
        isBuildingTrees = True
        Dim isBuiltOk As Boolean
        LogUtil.Info("Selecting...")
        tvBirthday.Nodes.Clear()
        personTable.Clear()
        Try

            Dim _day As Integer = Today.Day
            Dim _mth As Integer = Today.Month
            '        Dim testDate As Date = New Date(2000, cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1)
            personTable = FindPeopleByDate(_day, _mth, True)
            oBirthdayList = FindBirthdays(_day, _mth, True)
            oAnniversaryList = FindAnniversaries(_day, _mth, True)
            'AddTypeNode(oAnniversaryList, testDate, tvBirthday, My.Resources.ANNIVERSARY)
            'AddTypeNode(oBirthdayList, testDate, tvBirthday, My.Resources.BIRTHDAY)
            LogUtil.Info("Selection Complete")
            isBuiltOk = True

        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("BuildTrees error", ex)
            isBuiltOk = False
        End Try
        isBuildingTrees = False
        Return isBuiltOk
    End Function
    Private Shared Sub GenerateAllTweets()
        LogUtil.Info("Generating all tweets")
        Dim _imageStart As Integer = 0
        Dim _dateLength As Integer = Format(Today, "dd MMMM").Length
        oTweetLists = New List(Of List(Of Person))
        Dim _birthdayImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oBirthdayList, _dateLength + BIRTHDAY_HDR.Length + 3, TweetType.Birthday)
        oTweetLists.AddRange(_birthdayImageTweets)
        GenerateTweets(oTweetLists, _imageStart, TweetType.Birthday)
        _imageStart = oTweetLists.Count
        Dim _annivImageTweets As List(Of List(Of Person)) = SplitIntoTweets(oAnniversaryList, _dateLength + ANNIV_HDR.Length + 3, TweetType.Anniversary)
        oTweetLists.AddRange(_annivImageTweets)
        GenerateTweets(oTweetLists, _imageStart, TweetType.Anniversary)
        LogUtil.Info("Images Complete")
    End Sub
    Private Shared Sub GenerateTweets(_tweetLists As List(Of List(Of Person)), _listStart As Integer, _tweetType As TweetType)
        For _personIndex As Integer = _listStart To _tweetLists.Count - 1
            Dim _personList As List(Of Person) = _tweetLists(_personIndex)
            LogUtil.Info(">" & CStr(_personIndex), True)
            IsNoGenerate = True
            Dim personCt As Integer = _personList.Count
            Dim colCt As Integer
            If personCt <= 12 Then
                colCt = Math.Ceiling(personCt / 2)
            Else
                colCt = 6
                Dim list5 As New List(Of Integer)({13, 14, 15, 18, 19, 20})
                If list5.Contains(personCt) Then
                    colCt = 5
                End If
            End If
            Dim _width As Integer = colCt
            Dim _image As Image = GeneratePicture(_personList, _width)
            Dim _text As String = GenerateText(_personList, _tweetType, _personIndex - _listStart + 1, _tweetLists.Count - _listStart)
            IsNoGenerate = False
        Next
    End Sub
    Private Shared Function GenerateText(_imageTable As List(Of Person), _type As TweetType, _index As Integer, _numberOfLists As Integer) As String
        LogUtil.Info("Generating text")
        Dim _outString As New StringBuilder

        _outString.Append(Format(Today, "MMMM")).Append(" "c).Append(Format(Today, "dd")).Append(LINEFEED).Append(LINEFEED)
        _outString.Append(GetHeading(_type)).Append(LINEFEED)
        Dim _footer As String = If(_numberOfLists > 1, CStr(_index) & "/" & CStr(_numberOfLists), "")
        For Each _person As Person In _imageTable
            _outString.Append(_person.Name)
            If TweetType.Anniversary Then

                Dim _yr As Integer = CInt(_person.BirthYear)
                    Dim _birthyear As String = CStr(Math.Abs(_yr))
                    If _yr < 0 Then
                        _birthyear &= " BCE"
                    End If
                    _outString.Append(" (" & _birthyear & ")")

            End If
            If _type = TweetType.Birthday Then
                If _person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle) Then
                    _outString.Append(" @").Append(_person.Social.TwitterHandle)
                End If
            End If
            _outString.Append(LINEFEED)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(LINEFEED).Append(_footer)
        End If
        Return _outString.ToString.Trim(LINEFEED)
    End Function
    Private Shared Function GeneratePicture(_imageTable As List(Of Person), _width As Integer) As Image
        LogUtil.Info("Generating picture")
        Dim _image As Image
        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            _image = GenerateTweetImage(_imageTable, _width, _height)
        Else
            _image = Nothing
        End If
        Return _image
    End Function
    Private Shared Function GenerateTweetImage(_imageTable As List(Of Person), _width As Integer, _height As Integer) As Image
        Dim pAlignType As ImageUtil.AlignType = ImageUtil.AlignType.Centre
        Dim _image As Image = ImageUtil.GenerateImage(_imageTable, _width, _height, pAlignType)
        LogUtil.Info("Image complete", False)
        Return _image
    End Function
    Private Sub SendTweet(_filename As String, twitterUser As String, twitterText As String)
        Dim isOkToSend As Boolean = True
        isOkToSend = SetupOAuth(isOkToSend, twitterUser)
        LogUtil.Info("Entering SendTweet " & Format(Now, "hh:mm:ss"))
        If isOkToSend Then
            SendTheTweet(twitterText, _filename)
        End If
        LogUtil.Info("Back from SendTweet " & Format(Now, "hh:mm:ss"))
    End Sub
    Private Function SetupOAuth(isOkToSend As Boolean, twitterUser As String) As Boolean
        Dim _auth As TwitterOAuth = GetAuthById(twitterUser)
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

        Return isOkToSend
    End Function
    Private Sub SendTheTweet(_tweetText As String, twitterUser As String, Optional _filename As String = Nothing)
        LogUtil.Info("Sending Tweet as " & twitterUser)
        Dim twitter = New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim sto = New SendTweetOptions
        Dim msg = _tweetText
        sto.Status = msg.Substring(0, Math.Min(msg.Length, TWEET_MAX_LEN)) ' max tweet length; tweets fail if too long...
        Dim _mediaId As String = Nothing

        Dim _twitterUplMedia As TwitterUploadedMedia = PostMedia(twitter, _filename)
        If _twitterUplMedia IsNot Nothing Then
            Dim _uploadedSize As Long = _twitterUplMedia.Size
            Dim _uploadedImage As UploadedImage = _twitterUplMedia.Image
            LogUtil.Info("Image upload size: " & CStr(_uploadedSize))
            _mediaId = _twitterUplMedia.Media_Id
        Else
            LogUtil.Info("No image upload")
        End If

        If Not String.IsNullOrEmpty(_mediaId) Then
            InsertTweet(_filename, Today.Month, Today.Day, 1, _mediaId, twitterUser, "I")
            sto.MediaIds = {_mediaId}
        End If
        Dim _twitterStatus As TweetSharp.TwitterStatus = twitter.SendTweet(sto)
        If _twitterStatus IsNot Nothing Then
            InsertTweet(sto.Status, Today.Month, Today.Day, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
            LogUtil.Info("OK: " & _twitterStatus.Id)
        Else
            ' tweet failed
            LogUtil.Info("Failed")
        End If
    End Sub
    Private Sub GetAuthData()
        Dim _auth As TwitterOAuth = GetAuthById("Twitter")
        If _auth IsNot Nothing Then
            tw.ConsumerKey = _auth.Token
            tw.ConsumerSecret = _auth.TokenSecret
        End If
    End Sub
    Private Shared Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer, _type As TweetType) As List(Of List(Of Person))
        Dim availableLength As Integer = TWEET_MAX_LEN - _headerLength
        Dim _totalLengthOfTweet As Integer = 0
        Dim _lengthsText As String = ""
        Dim _numberOfTweets As Integer = GetExpectedNumberOfTweets(oPersonlist, _type, availableLength, _totalLengthOfTweet)
        Dim _startIndex As Integer = 0
        Dim _endIndex As Integer = oPersonlist.Count - 1

        Dim _numberOfNamesPerTweet As Integer = GetNumberOfPersonsPerTweet(oPersonlist.Count, _type, _numberOfTweets)

        Dim ListOfLists As New List(Of List(Of Person))
        Do Until _startIndex > _endIndex
            Dim _rangeCount As Integer = Math.Min(_numberOfNamesPerTweet, _endIndex + 1)
            Dim _range As List(Of Person) = oPersonlist.GetRange(_endIndex - _rangeCount + 1, _rangeCount)
            Dim _numberOfNamesThisTweet As Integer = _numberOfNamesPerTweet
            Do Until GetExpectedNumberOfTweets(_range, _type, availableLength, _totalLengthOfTweet) = 1
                _numberOfNamesThisTweet -= 1
                _rangeCount = Math.Min(_numberOfNamesThisTweet, _endIndex + 1)
                _range = oPersonlist.GetRange(_endIndex - _rangeCount + 1, _rangeCount)
            Loop
            _lengthsText = CStr(_totalLengthOfTweet) & vbCrLf & _lengthsText
            ListOfLists.Add(BuildList(_range))
            _endIndex -= _rangeCount
        Loop
        ListOfLists.Reverse()
        Return ListOfLists
    End Function
    Private Shared Function GetNumberOfPersonsPerTweet(oPersonListCount As Integer, _type As TweetType, oNumberOfTweets As Integer) As Integer
        Dim _nudValue As Integer
        Dim _numberOfPersonsPerTweet As Integer
        Try
            If _nudValue > 0 Then
                _numberOfPersonsPerTweet = _nudValue
            Else
                _numberOfPersonsPerTweet = Math.Ceiling(oPersonListCount / oNumberOfTweets)
            End If
        Catch ex As OverflowException
            LogUtil.Exception("GetNumberOfPersonsPerTweet", ex)
        End Try

        Return _numberOfPersonsPerTweet
    End Function
    Private Shared Function BuildList(oPersonList As List(Of Person)) As List(Of Person)
        Dim _tweetList As New List(Of Person)
        For Each oPerson As Person In oPersonList
            _tweetList.Add(oPerson)
        Next
        Return _tweetList
    End Function
    Private Shared Function GetExpectedNumberOfTweets(oPersonlist As List(Of Person), _type As TweetType, availableLength As Integer, ByRef _totalLength As Integer) As Integer
        _totalLength = GetTotalLengthOfTweet(oPersonlist, _type)
        Return Math.Ceiling(_totalLength / availableLength)
    End Function
    Private Shared Function GetTotalLengthOfTweet(oPersonlist As List(Of Person), _type As TweetType) As Integer
        Dim _totalLength As Integer = 0
        For Each _person As Person In oPersonlist
            Dim _tweetLineLength As Integer = GetTweetLineLength(_person, _type)
            _totalLength += _tweetLineLength
        Next
        Return _totalLength
    End Function
    Private Shared Function GetTweetLineLength(_person As Person, _type As TweetType) As Integer
        Dim _length As Integer = _person.Name.Length _
            + If(_type = TweetType.Birthday, _person.Social.TwitterHandle.Length + If(_person.Social.TwitterHandle.Length > 0, 2, 0), 0) _
            + If(_type = TweetType.Anniversary, 7, 0) _
            + 1
        Return _length
    End Function
    Private Shared Function GetHeading(_type As TweetType) As String
        Dim _header As String = ""
        If _type = TweetType.Anniversary Then
            _header = ANNIV_HDR
        End If
        If _type = TweetType.Birthday Then
            _header = BIRTHDAY_HDR
        End If
        Return _header
    End Function

End Class

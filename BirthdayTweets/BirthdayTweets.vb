Imports System.Timers
Imports TweetSharp
Imports System.Text
Imports System.Drawing

Public Class BirthdayTweets
#Region "enum"
    Private Enum TweetType
        Birthday
        Anniversary
        Full
    End Enum
    Private Enum TweetUserType
        CelebBirthday
        HBurpday
    End Enum
#End Region
#Region "classes"
    Private Class CbTweet
        Private _tweetText As String
        Private _tweetImage As Image
        Public Property TweetImage() As Image
            Get
                Return _tweetImage
            End Get
            Set(ByVal value As Image)
                _tweetImage = value
            End Set
        End Property
        Public Property TweetText() As String
            Get
                Return _tweetText
            End Get
            Set(ByVal value As String)
                _tweetText = value
            End Set
        End Property
    End Class
#End Region
#Region "constants"
    Private Const LAST_CELEB_TWEET As String = "LastCelebTweet"
    Private Const LAST_HBURPDAY_TWEET As String = "LastHBurpdayTweet"
    Private Const TWEET_TIME As String = "TweetTime"
    Private Const BIRTHDAY_HDR As String = "Birthdays_"
    Private Const ANNIV_HDR As String = "Anniv_"
    Private Shared ReadOnly LINEFEED As String = Convert.ToChar(vbLf, myStringFormatProvider)
    Private Const TIMER_INTERVAL As Integer = 60000
    Private Const CELEB_USER As String = "CelebBirthdayUK"
    Private Const HBURPDAY_HDR As String = "HBurpday"
#End Region
#Region "variables"
    Private Shared Timer1 As System.Timers.Timer
    Private Shared oBirthdayList As New List(Of Person)
    Private Shared oAnniversaryList As New List(Of Person)
    Private Shared oTweetLists As New List(Of List(Of Person))
    Private Shared oTodaysTweets As List(Of CbTweet)
    Private Shared IsNoGenerate As Boolean
    Private ReadOnly tw As New TwitterOAuth
    Private Shared isBuildingLists As Boolean
#End Region
#Region "service"
    Protected Overrides Sub OnStart(ByVal args() As String)
        Timer1 = New System.Timers.Timer
        AddHandler Timer1.Elapsed, AddressOf Timer1_Tick
        LogUtil.InitialiseLogging()
        LogUtil.StartLogging()
        Timer1.Interval = My.Settings.TimerInterval
        Timer1.Start()
    End Sub
    Protected Overrides Sub OnStop()
        LogUtil.Info("----- Stopping the Service -----")
        Timer1.Stop()
    End Sub

    Protected Overrides Sub OnShutdown()
        LogUtil.Info("----- Shutdown detected -----")
        Timer1.Stop()
    End Sub

    Protected Overrides Sub OnPause()
        LogUtil.Info("----- Service paused -----")
        Timer1.Stop()
    End Sub

    Protected Overrides Sub OnContinue()
        LogUtil.Info("----- Service continues -----")
        Timer1.Start()
    End Sub
#End Region
#Region "timer"
    Private Shared Sub Timer1_Tick(source As Object, e As ElapsedEventArgs)
        Try
            LogUtil.Info("----------------------------------------- start")
            Timer1.Stop()
            LogUtil.Info("Stopped timer")
            Dim celebLastTweetDate As Date = GlobalSettings.GetSetting(LAST_CELEB_TWEET)
            Dim todaysDate As String = Format(Now, "yyyy-MM-dd")
            Dim tweetTime As DateTime = CDate(todaysDate & " " & GlobalSettings.GetSetting(TWEET_TIME))
            Try
                If celebLastTweetDate < Today.Date Then
                    If Now > tweetTime Then
                        LogUtil.Info("Sending tweets for " & todaysDate)
                        LogUtil.Info("Selecting people")
                        If BuildPersonLists() Then
                            LogUtil.Info("Generating CeleBirthday tweets")
                            GenerateAllTweets(TweetUserType.CelebBirthday)
                            '                    SendCbBirthdayTweets()
                            '                    SendCbAnniversaryTweets()
                            LogUtil.Info("CeleBirthday tweets complete")
                            LogUtil.Info("Generating HBurpday tweets")
                            GenerateAllTweets(TweetUserType.HBurpday)
                            '                    SendHbBirthdayTweets()
                            '                    SendHbAnniversaryTweets()
                            GlobalSettings.SetSetting(LAST_CELEB_TWEET, "date", todaysDate, "")
                            LogUtil.Info("HBurpday Tweets complete")
                        Else
                            LogUtil.Problem("Tweets not sent - selection error")
                        End If
                    End If
                End If
            Catch ex As Exception
                LogUtil.Exception("CeleBirthday tweets failed", ex)
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
#End Region
#Region "tweets"
    Private Shared Function BuildPersonLists() As Boolean
        LogUtil.Info("Building person lists")
        isBuildingLists = True
        Dim isBuiltOk As Boolean
        LogUtil.Info("Selecting...")
        Try
            Dim _day As Integer = Today.Day
            Dim _mth As Integer = Today.Month
            oBirthdayList = FindBirthdays(_day, _mth)
            oAnniversaryList = FindAnniversaries(_day, _mth)
            LogUtil.Info("Selection Complete")
            isBuiltOk = True
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("BuildPersonLists error", ex)
            isBuiltOk = False
        End Try
        isBuildingLists = False
        Return isBuiltOk
    End Function
    Private Shared Sub GenerateAllTweets(_tweetUserType As TweetUserType)
        LogUtil.Info("Generating all tweets")
        oTodaysTweets = New List(Of CbTweet)
        oTweetLists = New List(Of List(Of Person))

        GenerateTweetsForType(TweetType.Birthday, oBirthdayList, _tweetUserType, BIRTHDAY_HDR)
        GenerateTweetsForType(TweetType.Anniversary, oAnniversaryList, _tweetUserType, ANNIV_HDR)

        LogUtil.Info("Tweets Created")
    End Sub

    Private Shared Sub GenerateTweetsForType(_tweetType As TweetType, oPersonList As List(Of Person), _tweetUserType As TweetUserType, _header As String)
        Dim _dateLength As Integer = Format(Today, "dd MMMM").Length
        Dim _imageStart As Integer = oTweetLists.Count
        Dim _splitTweets As List(Of List(Of Person)) = SplitIntoTweets(oPersonList, _dateLength + _header.Length + 3, _tweetType)
        GenerateTweets(_splitTweets, _tweetType, _tweetUserType)
    End Sub

    Private Shared Sub GenerateTweets(_tweetLists As List(Of List(Of Person)), _tweetType As TweetType, _tweetUserType As TweetUserType)
        Dim _tweetIndex As Integer = 0
        For Each _personlist As List(Of Person) In _tweetLists
            _tweetIndex += 1
            Dim personCt As Integer = _personlist.Count
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
            Dim _cbTweet As New CbTweet With {
                .TweetImage = GeneratePicture(_personlist, _width),
                .TweetText = GenerateText(_personlist, _tweetType, _tweetIndex, _tweetLists.Count, _tweetUserType)
            }
            oTodaysTweets.Add(_cbTweet)
        Next
    End Sub
    Private Shared Function GenerateText(_imageTable As List(Of Person), _type As TweetType, _index As Integer, _numberOfLists As Integer, _userType As TweetUserType) As String
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
            _lengthsText = CStr(_totalLengthOfTweet) & LINEFEED & _lengthsText
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
#End Region
End Class

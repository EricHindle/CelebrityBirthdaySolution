﻿Imports System.Collections.ObjectModel
Imports System.Data.Common
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Timers
Imports TweetSharp
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
    Private Const LAST_HBURP_TWEET As String = "LastHburpTweet"
    Private Const LAST_BOTSD_TWEET As String = "LastBotsdTweet"

    Private Const TWEET_TIME As String = "TweetTime"
    Private Const TIMER_INTERVAL As String = "ServiceTimerInterval"
    Private Const BIRTHDAY_FNAME As String = "Birthdays_"
    Private Const ANNIV_FNAME As String = "Anniv_"
    Private Const BOTSD_FNAME As String = "Botsd_"

    Private Const ANNIV_HDR As String = "Today is the anniversary of the birth of"
    Private Const BIRTHDAY_HDR As String = "Happy birthday today to"
    Private Shared ReadOnly LINEFEED As String = Convert.ToChar(vbLf, myStringFormatProvider)
    Private Const CELEB_USER As String = "CelebBirthdayUK"
    Private Const HBURPDAY_USER As String = "HBurpday"
    Private Const BOTSD_USER As String = "NotTwins1"
    'Private Const CELEB_USER As String = "FunsterMuddy"
    'Private Const HBURPDAY_USER As String = "FunsterMuddy"
    'Private Const BOTSD_USER As String = "FunsterMuddy"
    Private Const EMAIL_TO_ADDRESS As String = "SendErrorTo"
    Private Const EMAIL_FROM_ADDRESS As String = "SendEmailFrom"
    Private Const EMAIL_FROM_NAME As String = "SendEmailName"
    Private Const TWEET_FOOTER_LENGTH As Integer = 5
    Private Const NOT_DELETED As String = "File not deleted"
#End Region
#Region "variables"
    Public Shared Timer1 As System.Timers.Timer
    Private Shared oBirthdayList As New List(Of Person)
    Private Shared oAnniversaryList As New List(Of Person)
    Private Shared ReadOnly tw As New TwitterOAuth
    Private Shared todayDay As String
    Private Shared todayMonth As String
    Private Shared tweetHeaderDate As String
    Private Shared ReadOnly oBotSDList As New List(Of List(Of Person))
    Private Shared toAddr As String
    Private Shared fromAddr As String
    Private Shared fromName As String

#End Region
#Region "service"
    Protected Overrides Sub OnStart(ByVal args() As String)
        Timer1 = New System.Timers.Timer
        AddHandler Timer1.Elapsed, AddressOf Timer1_Tick
        LogUtil.InitialiseLogging()
        LogUtil.StartLogging()
        GetIntervalAndStartTimer(5)
        SendEmail("BirthdayTweets started", "The BirthdayTweets service has started")
    End Sub
    Protected Overrides Sub OnStop()
        Const Psub As String = "OnStop"
        LogUtil.Info("----- Stopping the Service -----", Psub)
        Timer1.Stop()
        SendEmail("BirthdayTweets stopped", "The BirthdayTweets service has stopped")
    End Sub

    Protected Overrides Sub OnShutdown()
        Const Psub As String = "OnShutdown"
        LogUtil.Info("----- Shutdown detected -----", Psub)
        Timer1.Stop()
        SendEmail("BirthdayTweets shut down", "The BirthdayTweets service has shut down")
    End Sub

    Protected Overrides Sub OnPause()
        Const Psub As String = "OnPause"
        LogUtil.Info("----- Service paused -----", Psub)
        Timer1.Stop()
        SendEmail("BirthdayTweets paused", "The BirthdayTweets service has paused")
    End Sub

    Protected Overrides Sub OnContinue()
        Const Psub As String = "OnContinue"
        LogUtil.Info("----- Service continues -----", Psub)
        Timer1.Start()
        SendEmail("BirthdayTweets continues", "The BirthdayTweets service has continued")
    End Sub
#End Region
#Region "timer"
    Private Shared Sub GetIntervalAndStartTimer(interval As Integer)
        Const Psub As String = "GetIntervalAndStartTimer"
        LogUtil.Info("Getting timer interval", Psub)
        Try
            interval = GlobalSettings.GetSetting(TIMER_INTERVAL)
        Catch ex As DbException
            LogUtil.Exception("Could not get interval setting from dB", ex, Psub)
        End Try
        StartTimer(interval)
        LogUtil.Info("Timer started with interval " & CStr(interval) & " minutes", Psub)
    End Sub
    Private Shared Sub StartTimer(timerIntervalMinutes As Integer)
        Const Psub As String = "StartTimer"
        LogUtil.Info("Starting timer", Psub)
        Timer1.Interval = timerIntervalMinutes * 60 * 1000
        Timer1.Start()
    End Sub
    Public Shared Sub Timer1_Tick(source As Object, e As ElapsedEventArgs)
        Const Psub As String = "Timer1_Tick"

        Try
            LogUtil.Info("----------------------------------------- tick", Psub)
            Timer1.Stop()
            LogUtil.Info("Stopped timer", Psub)
            GetAuthData()
            ClearImages()
            Dim celebLastTweetDate As Date = GlobalSettings.GetSetting(LAST_CELEB_TWEET)
            Dim hburpLastTweetDate As Date = GlobalSettings.GetSetting(LAST_HBURP_TWEET)
            Dim botsdLastTweetDate As Date = GlobalSettings.GetSetting(LAST_BOTSD_TWEET)
            Dim todaysDate As String = Format(Now, "yyyy-MM-dd")
            todayDay = Format(Now, "dd")
            todayMonth = Format(Now, "MMMM")
            tweetHeaderDate = todayMonth & " " & todayDay
            Dim tweetTime As DateTime = CDate(todaysDate & " " & GlobalSettings.GetSetting(TWEET_TIME))
            If celebLastTweetDate < Today.Date Then
                If Now > tweetTime Then
                    LogUtil.Info("Sending CelebBirthday tweets for " & todaysDate, Psub)
                    LogUtil.Info("Selecting people", Psub)
                    If BuildPersonLists() Then
                        If SendCbBirthdayTweets() AndAlso
                            SendCbAnniversaryTweets() Then
                            LogUtil.Info("CelebBirthday tweets complete", Psub)
                            GlobalSettings.SetSetting(LAST_CELEB_TWEET, "date", todaysDate, "")
                        Else
                            LogUtil.Problem("CelebBirthday Tweets not sent - error", Psub)
                            SendEmail("CelebBirthday Tweets error", "CelebBirthday Tweets not sent - error")
                        End If
                    Else
                        LogUtil.Problem("CelebBirthday Tweets not sent - selection error", Psub)
                        SendEmail("CelebBirthday Tweets error", "CelebBirthday Tweets not sent - selection error")
                    End If
                End If
            End If
            If hburpLastTweetDate < Today.Date Then
                If Now > tweetTime Then
                    LogUtil.Info("Sending HBurpday birthday tweets for " & todaysDate, Psub)
                    LogUtil.Info("Selecting people", Psub)
                    If BuildPersonLists() Then
                        If SendHbBirthdayTweets() AndAlso
                            SendHbAnniversaryTweets() Then
                            LogUtil.Info("HBurpday Tweets complete", Psub)
                            GlobalSettings.SetSetting(LAST_HBURP_TWEET, "date", todaysDate, "")
                        Else
                            LogUtil.Problem("HBurpday Birthday Tweets not sent - error", Psub)
                            SendEmail("HBurpday Birthday Tweets error", "HBurpday Birthday Tweets not sent - error")
                        End If
                    Else
                        LogUtil.Problem("HBurpday Birthday Tweets not sent - selection error", Psub)
                        SendEmail("HBurpday Birthday Tweets error", "HBurpday Birthday Tweets not sent - selection error")
                    End If
                End If
            End If

            If botsdLastTweetDate < Today.Date Then
                If Now > tweetTime Then
                    LogUtil.Info("Sending botsd tweets for " & todaysDate, Psub)
                    LogUtil.Info("Selecting pairs", Psub)
                    If SelectPairs() Then
                        If SendBotsdTweets() Then
                            LogUtil.Info("BotSD tweets complete", Psub)
                            GlobalSettings.SetSetting(LAST_BOTSD_TWEET, "date", todaysDate, "")
                        Else
                            LogUtil.Problem("BotSD Tweets not sent - error", Psub)
                            SendEmail("BotSD Tweets error", "BotSD Tweets not sent - error")
                        End If
                    Else
                        LogUtil.Problem("BotSD Tweets not sent - selection error", Psub)
                        SendEmail("BotSD Tweets error", "BotSD Tweets not sent - selection error")
                    End If
                End If
            End If
        Catch ex As DbException
            LogUtil.Exception("Could not get data from dB", ex, Psub)
            SendEmail("BirthdayTweets Db exception", "Could not get data from dB" & vbCrLf & ex.Message)
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("Argument Out Of Range Exception", ex, Psub)
            SendEmail("BirthdayTweets ArgumentOutOfRangeException exception", "Argument Out Of Range Exception" & vbCrLf & ex.Message)
        End Try
        GetIntervalAndStartTimer(30)
        LogUtil.Info("Restarted timer", Psub)
        LogUtil.Info("------------------------------------------- end", Psub)
    End Sub
    Private Shared Sub GetEmailSettings()
        toAddr = GlobalSettings.GetSetting(EMAIL_TO_ADDRESS)
        fromAddr = GlobalSettings.GetSetting(EMAIL_FROM_ADDRESS)
        fromName = GlobalSettings.GetSetting(EMAIL_FROM_NAME)
    End Sub
    Private Shared Sub SendEmail(strSubject As String, strBody As String)
        GetEmailSettings()
        EmailUtil.SendMail(fromAddr, toAddr, Array.Empty(Of String), strSubject, strBody, fromName)
    End Sub
#End Region
#Region "tweets"
    Private Shared Function SendHbAnniversaryTweets() As Boolean
        Const Psub As String = "SendHbAnniversaryTweets"
        Dim isSentOK As Boolean = True
        LogUtil.Info("Generating HBurpday anniversary tweets", Psub)
        Dim cbTweets As List(Of CbTweet) = GenerateTweets(oAnniversaryList, TweetType.Anniversary, TweetUserType.HBurpday, ANNIV_HDR)
        LogUtil.Info("Sending HBurpday anniversary tweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, ANNIV_FNAME)
            If Not SendTheTweet(tweetToSend, HBURPDAY_USER, imageFilename) Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
    Private Shared Function SendHbBirthdayTweets() As Boolean
        Const Psub As String = "SendHbBirthdayTweets"
        Dim isSentOK As Boolean = True
        LogUtil.Info("Generating HBurpday birthday tweets", Psub)
        Dim cbTweets As List(Of CbTweet) = GenerateTweets(oBirthdayList, TweetType.Birthday, TweetUserType.HBurpday, BIRTHDAY_HDR)
        LogUtil.Info("Sending HBurpday birthday tweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, BIRTHDAY_FNAME)
            If Not SendTheTweet(tweetToSend, HBURPDAY_USER, imageFilename) Then
                isSentOK = False
            End If
        Next
        Return isSentOK

    End Function
    Private Shared Function SendCbAnniversaryTweets() As Boolean
        Const Psub As String = "SendCbAnniversaryTweets"
        Dim isSentOK As Boolean = True
        LogUtil.Info("Generating CelebBirthday anniversary tweets", Psub)
        Dim cbTweets As List(Of CbTweet) = GenerateTweets(oAnniversaryList, TweetType.Anniversary, TweetUserType.CelebBirthday, ANNIV_HDR)
        LogUtil.Info("Sending CelebBirthday anniversary tweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, ANNIV_FNAME)
            If Not SendTheTweet(tweetToSend, CELEB_USER, imageFilename) Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
    Private Shared Function SendCbBirthdayTweets() As Boolean
        Const Psub As String = "SendCbBirthdayTweets"
        Dim isSentOK As Boolean = True
        LogUtil.Info("Generating CelebBirthday birthday tweets", Psub)
        Dim cbTweets As List(Of CbTweet) = GenerateTweets(oBirthdayList, TweetType.Birthday, TweetUserType.CelebBirthday, BIRTHDAY_HDR)
        LogUtil.Info("Sending CelebBirthday birthday tweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, BIRTHDAY_FNAME)
            If Not SendTheTweet(tweetToSend, CELEB_USER, imageFilename) Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
    Private Shared Function SendBotsdTweets() As Boolean
        Const Psub As String = "SendBotsdTweets"
        Dim isSentOK As Boolean = True
        LogUtil.Info("Generating BotSD tweets", Psub)
        Dim cbTweets As List(Of CbTweet) = GenerateBotSDTweets(oBotSDList)
        LogUtil.Info("Sending BotSDtweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, BOTSD_FNAME)
            If Not SendTheTweet(tweetToSend, BOTSD_USER, imageFilename) Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
    Private Shared Function GenerateBotSDTweets(oBotSDList As List(Of List(Of Person))) As List(Of CbTweet)
        Dim cbTweets As New List(Of CbTweet)
        For Each oPersonList As List(Of Person) In oBotSDList
            Dim _cbTweet As New CbTweet With {
          .TweetImage = GeneratePicture(oPersonList, oPersonList.Count),
          .TweetText = GenerateBotsdText(oPersonList)
          }
            cbTweets.Add(_cbTweet)
        Next
        Return cbTweets
    End Function
    Private Shared Function GenerateTweets(oPersonList As List(Of Person), _tweetType As TweetType, _tweetUserType As TweetUserType, _header As String) As List(Of CbTweet)
        Const pSub As String = "GenerateTweets"
        Dim dateLength As Integer = tweetHeaderDate.Length
        Dim headerLength As Integer = dateLength + _header.Length + 3
        Dim tweetLists As List(Of List(Of Person)) = SplitIntoTweets(oPersonList, headerLength, _tweetType, _tweetUserType)
        Dim tweetIndex As Integer = 0
        Dim cbTweets As New List(Of CbTweet)
        For Each _personlist As List(Of Person) In tweetLists
            tweetIndex += 1
            LogUtil.Info("Tweet " & CStr(tweetIndex), pSub)
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
                .TweetText = GenerateText(_personlist, _tweetType, tweetIndex, tweetLists.Count, _tweetUserType)
            }
            cbTweets.Add(_cbTweet)
        Next
        Return cbTweets
    End Function
    Private Shared Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer, _type As TweetType, _userType As TweetUserType) As List(Of List(Of Person))
        Const pSub As String = "SplitIntoTweets"
        LogUtil.Info("Splitting " & CStr(oPersonlist.Count) & " persons into tweets", pSub)
        Dim availableLength As Integer = TWEET_MAX_LEN - _headerLength
        Dim totalLengthOfTweet As Integer = 0
        Dim numberOfTweets As Integer = GuessNumberOfTweets(oPersonlist, _type, availableLength, totalLengthOfTweet, _userType)
        If numberOfTweets > 1 Then
            availableLength -= TWEET_FOOTER_LENGTH
            numberOfTweets = GuessNumberOfTweets(oPersonlist, _type, availableLength, totalLengthOfTweet, _userType)
        End If
        Dim startIndex As Integer = 0
        Dim endIndex As Integer = oPersonlist.Count - 1
        Dim guessNamesPerTweet As Integer = Math.Ceiling(oPersonlist.Count / numberOfTweets)
        Dim ListOfLists As New List(Of List(Of Person))
        Do Until startIndex > endIndex
            Dim _rangeCount As Integer = Math.Min(guessNamesPerTweet, endIndex + 1)
            Dim _range As List(Of Person) = oPersonlist.GetRange(endIndex - _rangeCount + 1, _rangeCount)
            Dim _numberOfNamesThisTweet As Integer = guessNamesPerTweet
            Do Until GuessNumberOfTweets(_range, _type, availableLength, totalLengthOfTweet, _userType) = 1
                _numberOfNamesThisTweet -= 1
                _rangeCount = Math.Min(_numberOfNamesThisTweet, endIndex + 1)
                _range = oPersonlist.GetRange(endIndex - _rangeCount + 1, _rangeCount)
            Loop
            ListOfLists.Add(BuildList(_range))
            endIndex -= _rangeCount
        Loop
        ListOfLists.Reverse()
        LogUtil.Info("Split into " & CStr(ListOfLists.Count) & " tweets", pSub)
        Return ListOfLists
    End Function
    Private Shared Function BuildList(oPersonList As List(Of Person)) As List(Of Person)
        Dim _tweetList As New List(Of Person)
        For Each oPerson As Person In oPersonList
            _tweetList.Add(oPerson)
        Next
        Return _tweetList
    End Function
    Private Shared Function GuessNumberOfTweets(oPersonlist As List(Of Person), _type As TweetType, availableLength As Integer, ByRef _totalLength As Integer, _userType As TweetUserType) As Integer
        _totalLength = GetTotalLengthOfNames(oPersonlist, _type, _userType)
        Return Math.Ceiling(_totalLength / availableLength)
    End Function
    Private Shared Function GetTotalLengthOfNames(oPersonlist As List(Of Person), _type As TweetType, _userType As TweetUserType) As Integer
        Dim totalLength As Integer = 0
        For Each _person As Person In oPersonlist
            totalLength += GetTweetLineLength(_person, _type, _userType) + 1
        Next
        Return totalLength
    End Function
    Private Shared Function GetTweetLineLength(_person As Person, _type As TweetType, _userType As TweetUserType) As Integer
        Dim tweetLine As String = GenerateTweetLine(_person, _type, _userType)
        Return tweetLine.Length
    End Function
    Private Shared Function GenerateBotsdText(oPersonList As List(Of Person)) As String
        Const Psub As String = "GenerateBotsdText"
        LogUtil.Info("Generating text", Psub)
        Dim _outString As New StringBuilder
        Dim _index As Integer = 0
        Dim _dob As String = ""
        For Each _person As Person In oPersonList
            Select Case _index
                Case 0
                    _dob = Format(_person.DateOfBirth, "d MMMM yyyy")
                Case oPersonList.Count - 1
                    _outString.Append(vbCrLf)
                    _outString.Append("and ")
                Case Else
                    _outString.Append(vbCrLf)
            End Select
            _outString.Append(_person.Name)
            _outString.Append(", ")
            _outString.Append(_person.ShortDesc.Trim("."))
            _outString.Append(","c)
            _index += 1
        Next
        _outString.Append(vbCrLf)
        _outString.Append("were ")
        If oPersonList.Count = 2 Then
            _outString.Append("both")
        Else
            _outString.Append("all")
        End If
        _outString.Append(" born on ")
        _outString.Append(_dob)
        Return _outString.ToString
    End Function
    Private Shared Function GenerateText(_imageTable As List(Of Person), _type As TweetType, _index As Integer, _numberOfLists As Integer, _userType As TweetUserType) As String
        Const Psub As String = "GenerateText"
        LogUtil.Info("Generating text", Psub)
        Dim _outString As New StringBuilder
        _outString.Append(tweetHeaderDate).Append(LINEFEED).Append(LINEFEED)
        _outString.Append(GetHeading(_type)).Append(LINEFEED)
        Dim _footer As String = If(_numberOfLists > 1, CStr(_index) & "/" & CStr(_numberOfLists), "")
        For Each _person As Person In _imageTable
            _outString.Append(GenerateTweetLine(_person, _type, _userType))
            _outString.Append(LINEFEED)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(LINEFEED).Append(_footer)
        End If
        Return _outString.ToString.Trim(LINEFEED)
    End Function
    Private Shared Function GeneratePicture(_imageTable As List(Of Person), _width As Integer) As Image
        Const Psub As String = "GeneratePicture"
        LogUtil.Info("Generating picture", Psub)
        Dim _image As Image
        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            _image = ImageUtil.GenerateImage(_imageTable, _width, _height, ImageUtil.AlignType.Centre)
        Else
            _image = Nothing
        End If
        Return _image
    End Function
    Private Shared Function SendTheTweet(_cbTweet As CbTweet, twitterUser As String, Optional _filename As String = Nothing) As Boolean
        Const Psub As String = "SendTheTweet"
        Dim isTweetSentOk As Boolean = False
        Dim isImageSentOk As Boolean = False

        If SetupOAuth(twitterUser) Then
            LogUtil.Info("Sending Tweet as " & twitterUser, Psub)
            Dim twitter As New TwitterService(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
            Dim sto As New SendTweetOptions
            Dim msg As String = _cbTweet.TweetText
            sto.Status = msg.Substring(0, Math.Min(msg.Length, TWEET_MAX_LEN)) ' max tweet length; tweets fail if too long...
            Dim _mediaId As String = Nothing
            Dim _twitterUplMedia As TwitterUploadedMedia = PostMedia(twitter, _filename)
            If _twitterUplMedia IsNot Nothing Then
                Dim _uploadedSize As Long = _twitterUplMedia.Size
                Dim _uploadedImage As UploadedImage = _twitterUplMedia.Image
                LogUtil.Info("Image upload size: " & CStr(_uploadedSize), Psub)
                _mediaId = _twitterUplMedia.Media_Id
                isImageSentOk = True
            Else
                LogUtil.Info("No image upload", Psub)
            End If
            If Not String.IsNullOrEmpty(_mediaId) Then
                InsertTweet(_filename, Today.Month, Today.Day, 1, _mediaId, twitterUser, "I")
                sto.MediaIds = {_mediaId}
            End If
            Dim _twitterStatus As TwitterStatus = twitter.SendTweet(sto)
            If _twitterStatus IsNot Nothing Then
                isTweetSentOk = True
                InsertTweet(sto.Status, Today.Month, Today.Day, 1, _twitterStatus.Id, _twitterStatus.User.Name, "T")
                LogUtil.Info("OK: " & _twitterStatus.Id, Psub)
            Else
                ' tweet failed
                LogUtil.Info("Failed", Psub)
            End If
        End If
        Return isTweetSentOk And isImageSentOk
    End Function
    Private Shared Function GenerateTweetLine(_person As Person, _type As TweetType, _userType As TweetUserType) As String
        Dim tweetLine As New StringBuilder
        tweetLine.Append(_person.Name)
        Dim twitterHandle As String = If(_person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle), " @" & _person.Social.TwitterHandle, "")
        Dim _age As String = "(" & CStr(CalculateAge(_person)) & ")"
        Dim _year As String = "(" & _person.BirthYear & If(_person.BirthYear < 0, "BCE", "") & ")"
        If _userType = TweetUserType.CelebBirthday Then
            If _type = TweetType.Birthday Then
                tweetLine.Append(twitterHandle)
            End If
        ElseIf _userType = TweetUserType.HBurpday Then
            If _type = TweetType.Birthday Then
                tweetLine.Append(" "c).Append(_age)
            ElseIf _type = TweetType.Anniversary Then
                tweetLine.Append(" "c).Append(_year)
            End If
        End If
        Return tweetLine.ToString
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
#Region "auth"
    Private Shared Sub GetAuthData()
        Const Psub As String = "GetAuthData"
        Try
            Dim _auth As TwitterOAuth = GetAuthById("Twitter")
            If _auth IsNot Nothing Then
                tw.ConsumerKey = _auth.Token
                tw.ConsumerSecret = _auth.TokenSecret
            End If
        Catch ex As DbException
            LogUtil.Exception("Could not get auth data from dB", ex, Psub)
        End Try
    End Sub
    Private Shared Function SetupOAuth(twitterUser As String) As Boolean
        Dim isOKToSend As Boolean = True
        Dim _auth As TwitterOAuth = GetAuthById(twitterUser)
        Const Psub As String = "SetupOAuth"
        If _auth IsNot Nothing Then
            If String.IsNullOrEmpty(_auth.Verifier) Then
                isOKToSend = False
            Else
                tw.Verifier = _auth.Verifier
            End If
            If String.IsNullOrEmpty(_auth.Token) Then
                isOKToSend = False
            Else
                tw.Token = _auth.Token
            End If
            If String.IsNullOrEmpty(_auth.TokenSecret) Then
                isOKToSend = False
            Else
                tw.TokenSecret = _auth.TokenSecret
            End If
        Else
            LogUtil.Problem("Problem with Twitter auth", Psub)
            isOKToSend = False
        End If
        Return isOKToSend
    End Function
#End Region
#Region "images"
    Private Shared Sub ClearImages(Optional isConfirm As Boolean = True)
        Const Psub As String = "ClearImages"
        LogUtil.Info("Deleting tweet images", Psub)
        Try
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.TwitterImgPath,
                                                                                              FileIO.SearchOption.SearchTopLevelOnly,
                                                                                              {BIRTHDAY_FNAME & "*.jpg", ANNIV_FNAME & "*.jpg", BOTSD_FNAME & "*.jpg"})
            For Each _imageFile As String In _imageList
                LogUtil.Info(_imageFile, Psub)
                My.Computer.FileSystem.DeleteFile(_imageFile)
            Next
        Catch ex1 As ArgumentNullException
            LogUtil.Exception(NOT_DELETED, ex1, Psub)
        Catch ex2 As PathTooLongException
            LogUtil.Exception(NOT_DELETED, ex2, Psub)
        Catch ex3 As NotSupportedException
            LogUtil.Exception(NOT_DELETED, ex3, Psub)
        Catch ex4 As IOException
            LogUtil.Exception(NOT_DELETED, ex4, Psub)
        Catch ex5 As Security.SecurityException
            LogUtil.Exception(NOT_DELETED, ex5, Psub)
        Catch ex6 As UnauthorizedAccessException
            LogUtil.Exception(NOT_DELETED, ex6, Psub)
        End Try
    End Sub
    Private Shared Function SaveImage(cb As CbTweet, typeText As String) As String
        Dim _path As String = My.Settings.TwitterImgPath
        Const Psub As String = "SaveImage"
        If Not My.Computer.FileSystem.DirectoryExists(_path) Then
            My.Computer.FileSystem.CreateDirectory(_path)
        End If
        Dim _fileName As String = Path.Combine(_path, typeText.Replace("_", "_" & todayDay & "_" & todayMonth) & ".jpg")
        If My.Computer.FileSystem.FileExists(_fileName) Then
            _fileName = GetUniqueFname(_fileName)
        End If

        LogUtil.Info("Saving image to file " & _fileName, Psub)
        ImageUtil.SaveImage(cb.TweetImage, _fileName)
        LogUtil.Info("Image file saved", Psub)
        Return _fileName
    End Function
    Private Shared Function GetUniqueFname(ByVal filename As String, ByVal Optional pPath As String = Nothing) As String
        Dim newfilename As String = filename
        Const Psub As String = "GetUniqueFname"
        If pPath Is Nothing Then pPath = Path.GetDirectoryName(filename)
        Try
            For subs As Integer = 0 To 999
                newfilename = Path.Combine(pPath, Path.GetFileNameWithoutExtension(filename) & "_" & CStr(subs) & Path.GetExtension(filename))
                If My.Computer.FileSystem.FileExists(newfilename) = False Then
                    Exit For
                End If
            Next
        Catch ex As ArgumentException
            LogUtil.Exception("Get unique filename ArgumentException", ex, Psub)
        End Try
        Return newfilename
    End Function
#End Region
#Region "persons"
    Private Shared Function BuildPersonLists() As Boolean
        Const Psub As String = "BuildPersonLists"
        LogUtil.Info("Building person lists", Psub)
        Dim isBuiltOk As Boolean
        Try
            Dim _day As Integer = Today.Day
            Dim _mth As Integer = Today.Month
            oBirthdayList = FindBirthdays(_day, _mth)
            oAnniversaryList = FindAnniversaries(_day, _mth)
            LogUtil.Info("Selection Complete", Psub)
            isBuiltOk = True
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("Build Person Lists ArgumentOutOfRangeException", ex, Psub)
            isBuiltOk = False
        End Try
        Return isBuiltOk
    End Function
    Private Shared Function SelectPairs() As Boolean
        Dim isOK As Boolean = True
        Const Psub As String = "SelectPairs"
        LogUtil.Info("Selecting shared birthdays", Psub)
        oBotSDList.Clear()
        Dim _fullList As List(Of Person) = FindTodays(Now.Day, Now.Month, False)
        Dim lastYear As String = ""
        Dim _sameYearList As New List(Of Person)
        For Each oPerson As Person In _fullList
            If Not oPerson.BirthYear.Equals(lastYear, Global.System.StringComparison.Ordinal) Then
                If _sameYearList.Count > 1 Then
                    oBotSDList.Add(_sameYearList)
                End If
                _sameYearList = New List(Of Person)
                lastYear = oPerson.BirthYear
            End If
            _sameYearList.Add(oPerson)
        Next
        If _sameYearList.Count > 1 Then
            oBotSDList.Add(_sameYearList)
        End If
        LogUtil.Info(CStr(oBotSDList.Count) & " same birthdays found", Psub)
        Return isOK
    End Function
#End Region
End Class

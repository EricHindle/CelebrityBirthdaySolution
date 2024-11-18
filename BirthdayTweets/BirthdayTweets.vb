' Hindleware
' Copyright (c) 2020-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Collections.ObjectModel
Imports System.Data.Common
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports Tweetinvi
Imports Tweetinvi.Core.Web

Public Class BirthdayTweets
#Region "enum"
    Public Enum TweetType
        Birthday
        Anniversary
        Death
        BotSD
        ForNowBirthday
        Test
        Bluesky
    End Enum
    Public Enum TwitterUserType
        CelebBirthday
        HBurpday
        BrownBread
        BotSD
        ForNowCeleb
        Test
        Bluesky
    End Enum
#End Region
#Region "classes"
    Private Class RunParam
        Private _tweetType As TweetType
        Private _tweetUserType As TwitterUserType
        Private _twitterUser As String
        Private _isSelectToday As Boolean
        Private _selectDay As Integer
        Private _selectMonth As Integer
        Private _isShowImages As Boolean
        Private _isShowHandles As Boolean
        Private _isShowAge As Boolean
        Private _isNextBirthday As Boolean
        Private _isMultiImage As Boolean
        Private _lrc As String
        Private _width As Integer
        Private _bdayCt As Integer
        Private _annivCt As Integer
        Private _isOncePerDay As Boolean
        Public Property TweetUserType() As TwitterUserType
            Get
                Return _tweetUserType
            End Get
            Set(ByVal value As TwitterUserType)
                _tweetUserType = value
            End Set
        End Property
        Public Property IsOncePerDay() As Boolean
            Get
                Return _isOncePerDay
            End Get
            Set(ByVal value As Boolean)
                _isOncePerDay = value
            End Set
        End Property
        Public Property TweetType() As TweetType
            Get
                Return _tweetType
            End Get
            Set(ByVal value As TweetType)
                _tweetType = value
            End Set
        End Property
        Public Property AnniversaryCount() As Integer
            Get
                Return _annivCt
            End Get
            Set(ByVal value As Integer)
                _annivCt = value
            End Set
        End Property
        Public Property BirthdayCount() As Integer
            Get
                Return _bdayCt
            End Get
            Set(ByVal value As Integer)
                _bdayCt = value
            End Set
        End Property
        Public Property Width() As Integer
            Get
                Return _width
            End Get
            Set(ByVal value As Integer)
                _width = value
            End Set
        End Property
        Public Property Lrc() As String
            Get
                Return _lrc
            End Get
            Set(ByVal value As String)
                _lrc = value
            End Set
        End Property
        Public Property IsMultiImage() As Boolean
            Get
                Return _isMultiImage
            End Get
            Set(ByVal value As Boolean)
                _isMultiImage = value
            End Set
        End Property
        Public Property IsNextBirthday() As Boolean
            Get
                Return _isNextBirthday
            End Get
            Set(ByVal value As Boolean)
                _isNextBirthday = value
            End Set
        End Property
        Public Property IsAge() As Boolean
            Get
                Return _isShowAge
            End Get
            Set(ByVal value As Boolean)
                _isShowAge = value
            End Set
        End Property
        Public Property IsHandles() As Boolean
            Get
                Return _isShowHandles
            End Get
            Set(ByVal value As Boolean)
                _isShowHandles = value
            End Set
        End Property
        Public Property IsImages() As Boolean
            Get
                Return _isShowImages
            End Get
            Set(ByVal value As Boolean)
                _isShowImages = value
            End Set
        End Property
        Public Property SelectMonth() As Integer
            Get
                Return _selectMonth
            End Get
            Set(ByVal value As Integer)
                _selectMonth = value
            End Set
        End Property
        Public Property SelectDay() As Integer
            Get
                Return _selectDay
            End Get
            Set(ByVal value As Integer)
                _selectDay = value
            End Set
        End Property
        Public Property TwitterUser() As String
            Get
                Return _twitterUser
            End Get
            Set(ByVal value As String)
                _twitterUser = value
            End Set
        End Property
        Public Property IsSelectToday() As Boolean
            Get
                Return _isSelectToday
            End Get
            Set(ByVal value As Boolean)
                _isSelectToday = value
            End Set
        End Property
        Public Sub New(pLine As String)
            InitialiseParam()
            Dim paramValues As String() = Split(pLine, ",")
            If Not String.IsNullOrWhiteSpace(pLine) AndAlso Not pLine.StartsWith("#") AndAlso paramValues.Count > 2 Then
                _tweetType = CType(paramValues(0), TweetType)
                _tweetUserType = CType(paramValues(1), TwitterUserType)
                _twitterUser = paramValues(2)
                If paramValues.Count = 3 Then
                    pLine = GlobalSettings.GetSetting(_twitterUser & "_" & _tweetType & "_TwitterParams")
                    LogUtil.ShowProgress("Auto : " & _twitterUser & "_" & _tweetType.ToString)
                    paramValues = Split(pLine, ",")
                End If
                LogUtil.ShowProgress("User : " & _twitterUser & "  Tweet Type : " & _tweetType)
                _isSelectToday = paramValues.Count > 3 AndAlso paramValues(3).First = "y"c
                LogUtil.ShowProgress("  Today : " & _isSelectToday)
                If IsSelectToday Then
                    _selectDay = Today.Day
                    _selectMonth = Today.Month
                Else
                    _selectDay = If(paramValues.Count > 4 AndAlso IsNumeric(paramValues(4)), CInt(paramValues(4)), 0)
                    _selectMonth = If(paramValues.Count > 5 AndAlso IsNumeric(paramValues(5)), CInt(paramValues(5)), 0)
                End If
                LogUtil.ShowProgress("  Date : " & _selectDay & "/" & _selectMonth)
                _isShowImages = paramValues.Count > 6 AndAlso paramValues(6).First = "y"c
                LogUtil.ShowProgress("  Images : " & _isShowImages)
                If paramValues.Count > 7 AndAlso paramValues(7).First = "y"c Then
                    _isShowHandles = True
                    LogUtil.ShowProgress("  Handles : " & _isShowHandles)
                    _isShowAge = False
                    _isNextBirthday = False
                Else
                    If paramValues.Count > 8 AndAlso paramValues(8).First = "y"c Then
                        _isShowAge = True
                        LogUtil.ShowProgress("  Show Age : " & _isShowAge)
                        _isNextBirthday = paramValues.Count > 9 AndAlso paramValues(9).First = "y"c
                        LogUtil.ShowProgress("  Next Birthday : " & _isNextBirthday)
                    Else
                        _isShowAge = False
                        _isNextBirthday = False
                    End If
                End If
                _isMultiImage = paramValues.Count > 10 AndAlso paramValues(10).First = "y"c
                LogUtil.ShowProgress("  MultiImage : " & _isMultiImage)
                _lrc = If(paramValues.Count > 11, paramValues(11).First(), "c")
                LogUtil.ShowProgress("  L/R/C : " & _lrc)
                _width = If(paramValues.Count > 12 AndAlso IsNumeric(paramValues(12)), CInt(paramValues(12)), 6)
                _bdayCt = If(paramValues.Count > 13 AndAlso IsNumeric(paramValues(13)), CInt(paramValues(13)), 0)
                _annivCt = If(paramValues.Count > 14 AndAlso IsNumeric(paramValues(14)), CInt(paramValues(14)), 0)
                _isOncePerDay = paramValues.Count > 15 AndAlso paramValues(15).First = "y"c
                LogUtil.ShowProgress(If(_isOncePerDay, "Once per day", "On demand"))
            End If
        End Sub
        Private Sub InitialiseParam()
            _tweetUserType = TwitterUserType.HBurpday
            _tweetType = TweetType.Birthday
            _twitterUser = ""
            _isSelectToday = True
            _selectDay = 0
            _selectMonth = 0
            _isShowImages = True
            _isShowHandles = False
            _isShowAge = True
            _isNextBirthday = False
            _isMultiImage = True
            _lrc = "c"
            _width = 6
            _bdayCt = 0
            _annivCt = 0
        End Sub
    End Class
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
    Private Const LAST_BBREAD_TWEET As String = "LastBrownBreadTweet"
    Private Const LAST_FORNOW_TWEET As String = "LastForNowTweet"
    Private Const TWEET_TIME As String = "TweetTime"
    Private Const TIMER_INTERVAL As String = "ServiceTimerInterval"
    Private Const BIRTHDAY_FNAME As String = "Birthdays_"
    Private Const ANNIV_FNAME As String = "Anniv_"
    Private Const BOTSD_FNAME As String = "Botsd_"
    Private Const BBREAD_FNAME As String = "BBread_"
    Private Const FORNOW_FNAME As String = "ForNow_"
    Private Const ANNIV_HDR As String = "Today is the anniversary of the birth of"
    Private Const BIRTHDAY_HDR As String = "Happy birthday today to"
    Private Const HBURPDAY_HDR As String = "Today's birthdays :-"
    Private Const BBREAD_HDR As String = "Remembering those who died on this day :"
    Private Const FORNOW_HDR As String = "🎂 A very happy birthday today to"
    Private Shared ReadOnly BCAKE As String = "🎂"
    Private Const TEST_HDR As String = "Born on this day:"
    Private Shared ReadOnly LINEFEED As String = Convert.ToChar(vbLf, myStringFormatProvider)
    Private Const CELEB_USER_KEY As String = "CELEB_USER"
    Private Const BSKY_CELEB_USER_KEY As String = "BSKY_CELEB_USER"
    Private Const HBURPDAY_USER_KEY As String = "HBURPDAY_USER"
    Private Const BOTSD_USER_KEY As String = "BOTSD_USER"
    Private Const BBREAD_USER_KEY As String = "BBREAD_USER"
    Private Const FORNOW_USER_KEY As String = "FORNOW_USER"
    Private Const EMAIL_TO_ADDRESS As String = "SendErrorTo"
    Private Const EMAIL_FROM_ADDRESS As String = "SendEmailFrom"
    Private Const EMAIL_FROM_NAME As String = "SendEmailName"
    Private Const TWEET_FOOTER_LENGTH As Integer = 5
    Private Const NOT_DELETED As String = "File not deleted"
    Private Const PARAM_FILE As String = "PARAM_FILE"
#End Region
#Region "variables"
    Private Shared celebUser As String = "CelebBirthdayUK"
    Private Shared hburpdayUser As String = "HBurpday"
    Private Shared botsdUser As String = "NotTwins1"
    Private Shared bbreadUser As String = "WhosBrownBread"
    Private Shared fornowUser As String = "TotesBirthdays"
    Private Shared bskycelebUser As String = "celebbirthdayuk.bsky.social"
    Private Shared ReadOnly testUser As String = "FunsterMuddy"
    Private Shared oBirthdayList As New List(Of Person)
    Private Shared oAnniversaryList As New List(Of Person)
    Private Shared oDeathList As New List(Of Person)
    Private Shared oForNowList As New List(Of Person)
    Private Shared ReadOnly tw As New TwitterOAuth
    Private Shared selectDay As String
    Private Shared selectMonth As String
    Private Shared tweetHeaderDate As String
    Private Shared ReadOnly oBotSDList As New List(Of List(Of Person))
    Private Shared toAddr As String
    Private Shared fromAddr As String
    Private Shared fromName As String
    Private Shared paramList As New List(Of RunParam)
#End Region
#Region "main"
    '    The main entry point For the process
    Shared Sub Main()
        InitialiseApplication()
        LogUtil.InitialiseLogging()
        LogUtil.StartLogging()
        Dim cmdLine As ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
        If cmdLine.Count > 0 Then
            LogUtil.ShowProgress("Command line parameter:")
            LogUtil.ShowProgress("  " & cmdLine(0))
            paramList.Clear()
            paramList.Add(New RunParam(cmdLine(0)))
            SendAllTweets(False)
        Else
            ReadParameters(GlobalSettings.GetSetting(PARAM_FILE))
            SendAllTweets(False)
        End If
        LogUtil.ShowProgress("Run Complete")
    End Sub
    Private Shared Sub InitialiseApplication()
        LogUtil.LogFolder = My.Settings.LogFolder
        celebUser = GlobalSettings.GetSetting(CELEB_USER_KEY)
        bskycelebUser = GlobalSettings.GetSetting(BSKY_CELEB_USER_KEY)
        hburpdayUser = GlobalSettings.GetSetting(HBURPDAY_USER_KEY)
        bbreadUser = GlobalSettings.GetSetting(BBREAD_USER_KEY)
        botsdUser = GlobalSettings.GetSetting(BOTSD_USER_KEY)
        fornowUser = GlobalSettings.GetSetting(FORNOW_USER_KEY)
    End Sub
    Private Shared Sub ReadParameters(pFilename As String)
        Dim pSub As String = "ReadParameters"
        LogUtil.ShowProgress("Reading parameters", pSub)
        Dim _paramFile As String = pFilename.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        If My.Computer.FileSystem.FileExists(_paramFile) Then
            Using _paramFileReader As New StreamReader(_paramFile)
                Dim line As String
                line = _paramFileReader.ReadLine
                Do While line IsNot Nothing
                    Dim _param As New RunParam(line.Trim)
                    If Not String.IsNullOrWhiteSpace(_param.TwitterUser) Then
                        paramList.Add(_param)
                    End If
                    line = _paramFileReader.ReadLine
                Loop
            End Using
        Else
            LogUtil.ShowProgress("Parameter file " & _paramFile & " not found", pSub)
        End If
    End Sub
    Public Shared Sub SendAllTweets(Optional isDoTest As Boolean = True)
        Const Psub As String = "SendAllTweets"
        Try
            LogUtil.ShowProgress("----------------------------------------- start", Psub)
            GetAuthData()
            ClearImages()
            Dim todaysDate As String = Format(Now, "yyyy-MM-dd")
            SetSelectDate(Now)
            Dim tweetTime As Date = todaysDate & " " & GlobalSettings.GetSetting(TWEET_TIME)
            Dim networkOK As Boolean = False
            Dim testCount As Integer = 0
            If isDoTest Then
                LogUtil.ShowProgress("Testing tweet", Psub)
                networkOK = TestTweet(FindRandomBirthday)
            Else
                networkOK = True
            End If
            Do Until networkOK Or testCount > 10
                Threading.Thread.Sleep(10000)
                networkOK = TestTweet(FindRandomBirthday)
                testCount += 1
            Loop
            If networkOK Then
                For Each _param As RunParam In paramList
                    LogUtil.ShowProgress("Param: " & _param.TwitterUser & " " & _param.TweetType.ToString, Psub)
                    If Not _param.IsSelectToday Then
                        Dim runDate As New Date(Now.Year, _param.SelectMonth, _param.SelectDay)
                        SetSelectDate(runDate)
                    End If
                    Dim _lastRunDate As Date = GetLastRunDate(_param.TweetType, _param.TwitterUser)
                    Dim isOkToRun As Boolean = True
                    If _param.IsSelectToday AndAlso _param.IsOncePerDay AndAlso (_lastRunDate >= Today.Date Or Now < tweetTime) Then
                        LogUtil.ShowProgress("Last run : " & Format(_lastRunDate, "dd MMM yyyy"))
                        LogUtil.ShowProgress("** Not due to be run", Psub)
                        isOkToRun = False
                    End If

                    If isOkToRun Then
                        Dim isRanOk As Boolean = False
                        Select Case _param.TweetType
                            Case TweetType.Birthday
                                isRanOk = SendTweets(_param)
                            Case TweetType.Anniversary
                                isRanOk = SendTweets(_param)
                            Case TweetType.Death
                                isRanOk = SendTweets(_param)
                            Case TweetType.BotSD
                                isRanOk = SendBotsdTweets(_param)
                            Case TweetType.ForNowBirthday
                                isRanOk = SendForNowTweets(_param)
                            Case TweetType.Bluesky
                                isRanOk = SendBlueskyTweets(_param)
                        End Select
                        If isRanOk Then SetLastRunDate(_param.TweetType, _param.TwitterUser)
                    End If
                Next
            Else
                LogUtil.ShowProgress("Test Tweet failed", Psub)
                LogUtil.ShowProgress("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! failed", Psub)
            End If
        Catch ex As DbException
            LogUtil.Exception("Could not get data from dB", ex, Psub)
            SendEmail("BirthdayTweets Db exception", "Could not get data from dB" & vbCrLf & ex.Message)
        Catch ex As ArgumentOutOfRangeException
            LogUtil.Exception("Argument Out Of Range Exception", ex, Psub)
            SendEmail("BirthdayTweets ArgumentOutOfRangeException exception", "Argument Out Of Range Exception" & vbCrLf & ex.Message)
        End Try
        LogUtil.ShowProgress("------------------------------------------- end", Psub)
    End Sub
    Private Shared Sub SetSelectDate(runDate As Date)
        selectDay = Format(runDate, "dd")
        selectMonth = Format(runDate, "MMMM")
        tweetHeaderDate = selectMonth & " " & selectDay
    End Sub
    Private Shared Function GetLastRunDate(tweetType As TweetType, twitterUser As String) As Date
        Dim _settingKey As String = twitterUser & "_" & tweetType & "_" & "LastRun"
        Dim _lastTweetDate As Date = GlobalSettings.GetDateSetting(_settingKey)
        Return _lastTweetDate
    End Function
    Private Shared Sub SetLastRunDate(tweetType As TweetType, twitterUser As String)
        Dim _settingKey As String = twitterUser & "_" & tweetType & "_" & "LastRun"
        Dim _lastTweetDate As String = Format(Today, "yyyy-MM-dd")
        GlobalSettings.SetSetting(_settingKey, "date", _lastTweetDate, "")
    End Sub
    Private Shared Function SendTweets(_param As RunParam) As Boolean
        Dim pSub As String = "SendTweets"
        Dim _runDesc As String = _param.TwitterUser & _param.TweetType.ToString
        Dim isSentOk As Boolean = True
        LogUtil.ShowProgress("Sending " & _runDesc & " tweets for " & tweetHeaderDate, pSub)
        LogUtil.ShowProgress("Selecting people", pSub)
        Dim oPersonList As List(Of Person) = BuildPersonList(_param)
        If oPersonList.Count > 0 Then
            LogUtil.ShowProgress("Generating " & _runDesc & " tweets", pSub)
            Dim cbTweets As List(Of CbTweet) = GenerateTweets(oPersonList, _param)
            LogUtil.ShowProgress("Sending " & _runDesc & " tweets", pSub)
            For Each tweetToSend As CbTweet In cbTweets
                Dim imageFilename As String = SaveImage(tweetToSend, _runDesc & "_")
                If Not SendTheTweet(tweetToSend, _param.TwitterUser, imageFilename).Result Then
                    isSentOk = False
                End If
            Next

            If isSentOk Then
                LogUtil.ShowProgress(_runDesc & " complete", pSub)
            Else
                LogUtil.Problem(_runDesc & " not sent - error", pSub)
                SendEmail("CelebBirthday Tweets error", "CelebBirthday Tweets not sent - error")
            End If
        Else
            LogUtil.Problem(_runDesc & " not sent - selection error", pSub)
            SendEmail("CelebBirthday Tweets error", "CelebBirthday Tweets not sent - selection error")
        End If
        Return isSentOk
    End Function
    Private Shared Function SendBlueskyTweets(_param As RunParam) As Boolean
        Dim _rnd As New Random
        Dim pSub As String = "SendBlueskyTweets"
        Dim _runDesc As String = _param.TwitterUser & _param.TweetType.ToString
        Dim isSentOk As Boolean = True
        LogUtil.ShowProgress("Sending " & _runDesc & " tweets for " & tweetHeaderDate, pSub)
        LogUtil.ShowProgress("Selecting people", pSub)
        _param.TweetType = TweetType.Birthday
        Dim bskypassword As String = GlobalSettings.GetSetting(bskycelebUser)
        Dim oPersonList As List(Of Person) = BuildPersonList(_param)
        Dim cbTweets As New List(Of CbTweet)
        If oPersonList.Count > 0 Then
            LogUtil.ShowProgress("Generating " & _runDesc & " tweets", pSub)
            cbTweets = GenerateTweets(oPersonList, _param)
        End If
        _param.TweetType = TweetType.Anniversary
        oPersonList = BuildPersonList(_param)
        If oPersonList.Count > 0 Then
            cbTweets.AddRange(GenerateTweets(oPersonList, _param))
        End If
        If cbTweets.Count > 0 Then
            LogUtil.ShowProgress("Sending " & _runDesc & " tweets", pSub)
            Dim _bskyPath As String = "D:\hindleware\CelebrityBirthdaySolution\BlueSkyTest\bin\Debug\net8.0\BlueSkyTest.exe"
            Dim isUseMethod1 As Boolean = _rnd.Next(1, 10) < 6
            For Each tweetToSend As CbTweet In cbTweets
                Dim imageFilename As String = SaveImage(tweetToSend, _runDesc & "_")
                Try
                    Dim postText As String = tweetToSend.TweetText.Replace(vbLf, "~")
                    Dim method As String = If(isUseMethod1, "1", "2")
                    Dim bskyPost As String = """" & postText & """ """ & bskycelebUser & """ """ & bskypassword & """ " & method
                    LogUtil.ShowProgress("Running " & _bskyPath, pSub)
                    LogUtil.Info("Sending post :", pSub)
                    LogUtil.Info(postText)
                    LogUtil.Info(" using username " & bskycelebUser)
                    LogUtil.Info("      by method " & method)
                    Process.Start(_bskyPath, bskyPost)
                    Threading.Thread.Sleep(_rnd.Next(10, 20) * 1000)
                    isSentOk = True
                    isUseMethod1 = Not isUseMethod1
                Catch ex As Exception
                    LogUtil.ShowProgress("Exception running " & _bskyPath, pSub)
                End Try
            Next

            If isSentOk Then
                _param.TweetType = TweetType.Bluesky
                LogUtil.ShowProgress(_runDesc & " complete", pSub)
            Else
                LogUtil.Problem(_runDesc & " not sent - error", pSub)
                SendEmail("CelebBirthday Tweets error", "CelebBirthday Tweets not sent - error")
            End If
        Else
            LogUtil.Problem(_runDesc & " not sent - selection error", pSub)
            SendEmail("CelebBirthday Tweets error", "CelebBirthday Tweets not sent - selection error")
        End If
        Return isSentOk
    End Function
    Private Shared Function TestTweet(randomPerson As Person) As Boolean
        Const Psub As String = "TestTweet"
        Dim isSentOK As Boolean = True
        Dim _list As New List(Of Person) From {
            randomPerson
        }
        LogUtil.ShowProgress("Generating test tweet", Psub)
        Dim _testParam As New RunParam("5,5,FunsterMuddy,y,,,y,n,n,n,n,c,6,0,0,y")
        Dim cbTweets As List(Of CbTweet) = GenerateTweets(_list, _testParam)
        LogUtil.ShowProgress("Sending test birthday tweet", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, BIRTHDAY_FNAME)
            If Not SendTheTweet(tweetToSend, testUser, imageFilename).Result Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
#End Region
#Region "email"
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
    Private Shared Function SendBotsdTweets(pParam As RunParam) As Boolean
        Const Psub As String = "SendBotsdTweets"
        Dim isSentOK As Boolean = True
        Dim oListOfLists As List(Of List(Of Person)) = SelectPairs(pParam)
        LogUtil.ShowProgress("Generating BotSD tweets", Psub)
        Dim cbTweets As List(Of CbTweet) = GenerateBotSDTweets(oListOfLists, pParam)
        LogUtil.ShowProgress("Sending BotSDtweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, BOTSD_FNAME)
            If Not SendTheTweet(tweetToSend, pParam.TwitterUser, imageFilename).Result Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
    Private Shared Function SendForNowTweets(pParam As RunParam) As Boolean
        Const Psub As String = "SendForNowTweets"
        Dim isSentOK As Boolean = True
        LogUtil.ShowProgress("Generating For Now tweets", Psub)
        Dim oPersonList As List(Of Person) = BuildPersonList(pParam)
        Dim cbTweets As New List(Of CbTweet)
        For Each oFnCeleb As Person In oPersonList
            Dim _fnList As New List(Of Person) From {
                oFnCeleb
            }
            cbTweets.AddRange(GenerateTweets(_fnList, pParam))
        Next
        LogUtil.ShowProgress("Sending For Now tweets", Psub)
        For Each tweetToSend As CbTweet In cbTweets
            Dim imageFilename As String = SaveImage(tweetToSend, FORNOW_FNAME)
            If Not SendTheTweet(tweetToSend, pParam.TwitterUser, imageFilename).Result Then
                isSentOK = False
            End If
        Next
        Return isSentOK
    End Function
    Private Shared Function GenerateBotSDTweets(oBotSDList As List(Of List(Of Person)), pParam As RunParam) As List(Of CbTweet)
        Dim cbTweets As New List(Of CbTweet)
        For Each oPersonList As List(Of Person) In oBotSDList
            Dim _cbTweet As New CbTweet With {
          .TweetImage = GeneratePicture(oPersonList, oPersonList.Count, pParam.TweetType),
          .TweetText = GenerateBotsdText(oPersonList)
          }
            cbTweets.Add(_cbTweet)
        Next
        Return cbTweets
    End Function
    Private Shared Function GenerateTweets(oPersonList As List(Of Person), pParam As RunParam) As List(Of CbTweet)
        Const pSub As String = "GenerateTweets"
        Dim _tweetType As TweetType = pParam.TweetType
        Dim _tweetUserType As TwitterUserType = pParam.TweetUserType
        Dim _header As String = GetHeading(pParam)
        Dim dateLength As Integer = tweetHeaderDate.Length
        Dim headerLength As Integer = dateLength + _header.Length + 3
        Dim tweetLists As List(Of List(Of Person)) = SplitIntoTweets(oPersonList, headerLength, pParam)
        Dim tweetIndex As Integer = 0
        Dim cbTweets As New List(Of CbTweet)
        For Each _personlist As List(Of Person) In tweetLists
            tweetIndex += 1
            LogUtil.ShowProgress("Tweet " & tweetIndex, pSub)
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
                .TweetImage = GeneratePicture(_personlist, _width, _tweetType),
                .TweetText = GenerateText(_personlist, pParam, tweetIndex, tweetLists.Count)
            }
            cbTweets.Add(_cbTweet)
        Next
        Return cbTweets
    End Function
    Private Shared Function SplitIntoTweets(oPersonlist As List(Of Person), _headerLength As Integer, pParam As RunParam) As List(Of List(Of Person))
        Const pSub As String = "SplitIntoTweets"
        LogUtil.ShowProgress("Splitting " & oPersonlist.Count & " persons into tweets", pSub)
        Dim availableLength As Integer = TWEET_MAX_LEN - _headerLength
        Dim totalLengthOfTweet As Integer = 0
        Dim numberOfTweets As Integer = GuessNumberOfTweets(oPersonlist, pParam, availableLength, totalLengthOfTweet)
        If numberOfTweets > 1 Then
            availableLength -= TWEET_FOOTER_LENGTH
            numberOfTweets = GuessNumberOfTweets(oPersonlist, pParam, availableLength, totalLengthOfTweet)
        End If
        Dim startIndex As Integer = 0
        Dim endIndex As Integer = oPersonlist.Count - 1
        Dim guessNamesPerTweet As Integer = Math.Ceiling(oPersonlist.Count / numberOfTweets)
        Dim ListOfLists As New List(Of List(Of Person))
        Do Until startIndex > endIndex
            Dim _rangeCount As Integer = Math.Min(guessNamesPerTweet, endIndex + 1)
            Dim _range As List(Of Person) = oPersonlist.GetRange(endIndex - _rangeCount + 1, _rangeCount)
            Dim _numberOfNamesThisTweet As Integer = guessNamesPerTweet
            Do Until GuessNumberOfTweets(_range, pParam, availableLength, totalLengthOfTweet) = 1
                _numberOfNamesThisTweet -= 1
                _rangeCount = Math.Min(_numberOfNamesThisTweet, endIndex + 1)
                _range = oPersonlist.GetRange(endIndex - _rangeCount + 1, _rangeCount)
            Loop
            ListOfLists.Add(BuildList(_range))
            endIndex -= _rangeCount
        Loop
        ListOfLists.Reverse()
        LogUtil.ShowProgress("Split into " & ListOfLists.Count & " tweets", pSub)
        Return ListOfLists
    End Function
    Private Shared Function BuildList(oPersonList As List(Of Person)) As List(Of Person)
        Dim _tweetList As New List(Of Person)
        For Each oPerson As Person In oPersonList
            _tweetList.Add(oPerson)
        Next
        Return _tweetList
    End Function
    Private Shared Function GuessNumberOfTweets(oPersonlist As List(Of Person), pParam As RunParam, availableLength As Integer, ByRef _totalLength As Integer) As Integer
        _totalLength = GetTotalLengthOfNames(oPersonlist, pParam)
        Return Math.Ceiling(_totalLength / availableLength)
    End Function
    Private Shared Function GetTotalLengthOfNames(oPersonlist As List(Of Person), pParam As RunParam) As Integer
        Dim totalLength As Integer = 0
        For Each _person As Person In oPersonlist
            totalLength += GetTweetLineLength(_person, pParam) + 1
        Next
        Return totalLength
    End Function
    Private Shared Function GetTweetLineLength(_person As Person, pParam As RunParam) As Integer
        Dim tweetLine As String = GenerateTweetLine(_person, pParam)
        Return tweetLine.Length
    End Function
    Private Shared Function GenerateBotsdText(oPersonList As List(Of Person)) As String
        Const Psub As String = "GenerateBotsdText"
        LogUtil.ShowProgress("Generating text", Psub)
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
    Private Shared Function GenerateText(_imageTable As List(Of Person), pParam As RunParam, _index As Integer, _numberOfLists As Integer) As String
        Const Psub As String = "GenerateText"
        LogUtil.ShowProgress("Generating text", Psub)
        Dim _outString As New StringBuilder
        _outString.Append(tweetHeaderDate).Append(LINEFEED).Append(LINEFEED)
        _outString.Append(GetHeading(pParam)).Append(LINEFEED)
        Dim _footer As String = If(_numberOfLists > 1, _index & "/" & _numberOfLists, "")
        For Each _person As Person In _imageTable
            _outString.Append(GenerateTweetLine(_person, pParam))
            _outString.Append(LINEFEED)
        Next
        If Not String.IsNullOrEmpty(_footer) Then
            _outString.Append(LINEFEED).Append(_footer)
        End If
        Return _outString.ToString.Trim(LINEFEED)
    End Function
    Private Shared Function GeneratePicture(_imageTable As List(Of Person), _width As Integer, _tweetType As TweetType) As Image
        Const Psub As String = "GeneratePicture"
        LogUtil.ShowProgress("Generating picture", Psub)
        Dim _image As Image
        If _imageTable.Count > 0 Then
            Dim _height As Integer = Math.Ceiling(_imageTable.Count / _width)
            _image = ImageUtil.GenerateImage(_imageTable, _width, _height, ImageUtil.AlignType.Centre, _tweetType)
        Else
            _image = Nothing
        End If
        Return _image
    End Function
    Private Shared Async Function SendTheTweet(_cbTweet As CbTweet, twitterUser As String, Optional _filename As String = Nothing) As Task(Of Boolean)
        Const Psub As String = "SendTheTweet"
        LogUtil.ShowProgress("Sending Tweet as " & twitterUser, Psub)
        Dim isTweetSentOk As Boolean = True
        Dim isImageSentOk As Boolean = True
        SetupOAuth(twitterUser)
        Dim userClient = New TwitterClient(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim user = Await userClient.Users.GetAuthenticatedUserAsync()
        Dim tweetinviLogoBinary As Byte() = File.ReadAllBytes(_filename)
        Dim UploadedImage As Models.IMedia = Await userClient.Upload.UploadTweetImageAsync(tweetinviLogoBinary)
        If UploadedImage.UploadedMediaInfo.MediaId = 0 Then
            isImageSentOk = False
        End If
        Try
            Dim poster = New TweetsV2Poster(userClient)
            Dim mediaList As New List(Of String) From {
                UploadedImage.UploadedMediaInfo.MediaId
            }
            Dim media As New TweetV2ImageIds With {.MediaId = mediaList}
            Dim result As ITwitterResult = Await poster.PostTweet(New TweetV2PostContent With {
                                                                                               .Text = _cbTweet.TweetText,
                                                                                               .MediaIds = media
                                                                                              })
            If result.Response.IsSuccessStatusCode = False Then
                isTweetSentOk = False
            End If
        Catch ex As Exception
        End Try
        Return isTweetSentOk And isImageSentOk
    End Function
    Private Shared Function GenerateTweetLine(_person As Person, pParam As RunParam) As String
        Dim tweetLine As New StringBuilder
        tweetLine.Append(_person.Name)
        Try
            Dim twitterHandle As String = If(_person.Social IsNot Nothing AndAlso Not String.IsNullOrEmpty(_person.Social.TwitterHandle), " @" & _person.Social.TwitterHandle, "")
            Dim nameHashTag As String = "#" & _person.Name.Replace(" ", "")
            Dim _age As String = "(" & CalculateAge(_person, pParam.IsNextBirthday) & ")"
            Dim _year As String = "(" & _person.BirthYear.Trim("-") & If(_person.BirthYear < 0, "BCE", "") & ")"
            Dim _deathYear As String = "(" & CStr(_person.DeathYear).Trim("-") & If(_person.DeathYear < 0, "BCE", "") & ")"
            Select Case pParam.TweetType
                Case TweetType.Anniversary
                    tweetLine.Append(" "c).Append(_year)
                Case TweetType.Death
                    tweetLine.Append(" "c).Append(_deathYear)
                Case Else
                    If pParam.IsAge Then
                        tweetLine.Append(" "c).Append(_age)
                    End If
                    If pParam.IsHandles Then
                        tweetLine.Append(twitterHandle)
                    End If
            End Select
            If pParam.TweetUserType = TwitterUserType.ForNowCeleb Then
                tweetLine.Append(LINEFEED).Append(LINEFEED).Append(twitterHandle).Append(" "c).Append(nameHashTag)
            End If
        Catch ex As Exception
            LogUtil.Exception("Error", ex, "GenerateTweetLine")
        End Try
        Return tweetLine.ToString
    End Function
    Private Shared Function GetHeading(pParam As RunParam) As String
        Dim _header As String = ""
        Dim _tweettype As TweetType = pParam.TweetType
        Dim _tweetUserType As TwitterUserType = pParam.TweetUserType
        Select Case _tweettype
            Case TweetType.Birthday
                Select Case _tweetUserType
                    Case TwitterUserType.CelebBirthday
                        _header = BIRTHDAY_HDR
                    Case TwitterUserType.HBurpday
                        _header = HBURPDAY_HDR
                    Case TwitterUserType.Test
                        _header = TEST_HDR
                    Case TwitterUserType.Bluesky
                        _header = HBURPDAY_HDR
                End Select
            Case TweetType.Anniversary
                _header = ANNIV_HDR
            Case TweetType.Death
                _header = BBREAD_HDR
            Case TweetType.ForNowBirthday
                _header = FORNOW_HDR
            Case TweetType.Test
                _header = BCAKE & " " & TEST_HDR
        End Select
        Return _header
    End Function
#End Region
#Region "auth"
    Private Shared Sub GetAuthData()
        Const Psub As String = "GetAuthData"
        Try
            Dim _auth As TwitterOAuth = GetAuthById("*TwitterAuth")
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
        LogUtil.ShowProgress("Deleting tweet images", Psub)
        Try
            Dim _imageList As ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(My.Settings.TwitterImgPath,
                                                                                              FileIO.SearchOption.SearchTopLevelOnly,
                                                                                              {"*.jpg"})
            For Each _imageFile As String In _imageList
                LogUtil.ShowProgress(_imageFile, Psub)
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
        Catch ex5 As System.Security.SecurityException
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
        Dim _fileName As String = Path.Combine(_path, typeText.Replace("_", "_" & selectDay & "_" & selectMonth) & ".jpg")
        If My.Computer.FileSystem.FileExists(_fileName) Then
            _fileName = GetUniqueFname(_fileName)
        End If
        LogUtil.ShowProgress("Saving image to file " & _fileName, Psub)
        ImageUtil.SaveImage(cb.TweetImage, _fileName)
        LogUtil.ShowProgress("Image file saved", Psub)
        Return _fileName
    End Function
    Private Shared Function GetUniqueFname(ByVal filename As String, ByVal Optional pPath As String = Nothing) As String
        Dim newfilename As String = filename
        Const Psub As String = "GetUniqueFname"
        If pPath Is Nothing Then pPath = Path.GetDirectoryName(filename)
        Try
            For subs As Integer = 0 To 999
                newfilename = Path.Combine(pPath, Path.GetFileNameWithoutExtension(filename) & "_" & subs & Path.GetExtension(filename))
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
    Private Shared Function BuildPersonList(pParam As RunParam) As List(Of Person)
        Const Psub As String = "BuildPersonList"
        LogUtil.ShowProgress("Building person list", Psub)
        Dim oPersonList As New List(Of Person)
        Try
            Dim _day As Integer = pParam.SelectDay
            Dim _mth As Integer = pParam.SelectMonth
            Select Case pParam.TweetType
                Case TweetType.Birthday
                    oPersonList = FindBirthdays(_day, _mth)
                Case TweetType.Anniversary
                    oPersonList = FindAnniversaries(_day, _mth)
                Case TweetType.Death
                    oPersonList = FindDeaths(_day, _mth)
                Case TweetType.ForNowBirthday
                    oPersonList = FindForNowBirthdays(_day, _mth)
                Case TweetType.Bluesky
                    oPersonList = FindBirthdays(_day, _mth)
            End Select
            LogUtil.ShowProgress("Selection Complete", Psub)
        Catch ex As ArgumentOutOfRangeException
            oPersonList.Clear()
            LogUtil.Exception("Build Person Lists ArgumentOutOfRangeException", ex, Psub)
        End Try
        Return oPersonList
    End Function
    Private Shared Function SelectPairs(pParam As RunParam) As List(Of List(Of Person))
        Const Psub As String = "SelectPairs"
        LogUtil.ShowProgress("Selecting shared birthdays", Psub)
        Dim oBotSDList As New List(Of List(Of Person))
        Dim _fullList As List(Of Person) = FindTodays(pParam.SelectDay, pParam.SelectMonth, False)
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
        LogUtil.ShowProgress(oBotSDList.Count & " same birthdays found", Psub)
        Return oBotSDList
    End Function
#End Region
End Class

' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports HindlewareLib.Logging
Public Class FrmBirthdayTweets
#Region "constants"
    Private Const PARAM_FILE As String = "PARAM_FILE"
#End Region
#Region "enum"
    Public Enum TweetType
        Birthday
        Anniversary
        Death
        BotSD
        ForNowBirthday
        Test
    End Enum
    Public Enum TwitterUserType
        CelebBirthday
        HBurpday
        BrownBread
        BotSD
        ForNowCeleb
        Test
    End Enum
#End Region
#Region "variables"
    Private paramList As New List(Of RunParam)
    Private Shared oSource As String
    Private isLoading As Boolean
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
        Public Sub New()
            InitialiseParam()
        End Sub
        Public Sub New(pLine As String)
            InitialiseParam()
            Dim paramValues As String() = Split(pLine, ",")
            If Not String.IsNullOrWhiteSpace(pLine) AndAlso Not pLine.StartsWith("#") AndAlso paramValues.Length > 2 Then
                _tweetType = CType(paramValues(0), TweetType)
                _tweetUserType = CType(paramValues(1), TwitterUserType)
                _twitterUser = paramValues(2)
                If paramValues.Length = 3 Then
                    pLine = GlobalSettings.GetSetting(_twitterUser & "_" & _tweetType & "_TwitterParams")
                    ShowStatus("Auto : " & _twitterUser & "_" & _tweetType.ToString, oSource)
                    paramValues = Split(pLine, ",")
                End If
                ShowStatus("User : " & _twitterUser & "  Tweet Type : " & _tweetType, oSource)
                _isSelectToday = paramValues.Length > 3 AndAlso paramValues(3).First = "y"c
                ShowStatus("  Today : " & _isSelectToday, oSource)
                If IsSelectToday Then
                    _selectDay = 0
                    _selectMonth = 0
                Else
                    _selectDay = If(paramValues.Length > 4 AndAlso IsNumeric(paramValues(4)), CInt(paramValues(4)), 0)
                    _selectMonth = If(paramValues.Length > 5 AndAlso IsNumeric(paramValues(5)), CInt(paramValues(5)), 0)
                End If
                ShowStatus("  Date : " & _selectDay & "/" & _selectMonth, oSource)
                _isShowImages = paramValues.Length > 6 AndAlso paramValues(6).First = "y"c
                ShowStatus("  Images : " & _isShowImages, oSource)
                If paramValues.Length > 7 AndAlso paramValues(7).First = "y"c Then
                    _isShowHandles = True
                    ShowStatus("  Handles : " & _isShowHandles, oSource)
                    _isShowAge = False
                    _isNextBirthday = False
                Else
                    If paramValues.Length > 8 AndAlso paramValues(8).First = "y"c Then
                        _isShowAge = True
                        ShowStatus("  Show Age : " & _isShowAge, oSource)
                        _isNextBirthday = paramValues.Length > 9 AndAlso paramValues(9).First = "y"c
                        ShowStatus("  Next Birthday : " & _isNextBirthday, oSource)
                    Else
                        _isShowAge = False
                        _isNextBirthday = False
                    End If
                End If
                _isMultiImage = paramValues.Length > 10 AndAlso paramValues(10).First = "y"c
                ShowStatus("  MultiImage : " & _isMultiImage, oSource)
                _lrc = If(paramValues.Length > 11, paramValues(11).First(), "c")
                ShowStatus("  L/R/C : " & _lrc, oSource)
                _width = If(paramValues.Length > 12 AndAlso IsNumeric(paramValues(12)), CInt(paramValues(12)), 6)
                _bdayCt = If(paramValues.Length > 13 AndAlso IsNumeric(paramValues(13)), CInt(paramValues(13)), 0)
                _annivCt = If(paramValues.Length > 14 AndAlso IsNumeric(paramValues(14)), CInt(paramValues(14)), 0)
                _isOncePerDay = paramValues.Length > 15 AndAlso paramValues(15).First = "y"c
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
#Region "form control handlers"
    Private Sub FrmBirthdayTweets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.twitterBdayFormPos)
        oSource = MyBase.Name
        isLoading = True
        CbTweetType.DataSource = [Enum].GetValues(GetType(TweetType))
        CbUserType.DataSource = [Enum].GetValues(GetType(TwitterUserType))
        FillTwitterUserList()
        ReadParameters(GlobalSettings.GetSetting(PARAM_FILE))
        ClearForm()
        isLoading = False
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub FrmBirthdayTweets_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.twitterBdayFormPos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub CbParams_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbParams.SelectedIndexChanged
        If Not isLoading AndAlso CbParams.SelectedIndex > -1 Then
            ClearForm()
            LoadFormFromParam(paramList(CbParams.SelectedIndex))
        End If
    End Sub
#End Region
#Region "subroutines"
    Private Sub FillTwitterUserList()
        cbTwitterUsers.Items.Clear()
        Dim _users As List(Of String) = GetTwitterUsers()
        For Each _user As String In _users
            CbTwitterUsers.Items.Add(_user)
        Next
    End Sub
    Private Sub ReadParameters(pFilename As String)
        ShowStatus("Reading parameters", LblStatus, True, oSource)
        CbParams.Items.Clear()
        Dim _paramFile As String = pFilename.Replace("%applicationpath%", My.Application.Info.DirectoryPath)
        If My.Computer.FileSystem.FileExists(_paramFile) Then
            Using _paramFileReader As New StreamReader(_paramFile)
                Dim line As String
                line = _paramFileReader.ReadLine
                Do While line IsNot Nothing
                    Dim _param As New RunParam(line.Trim)
                    If Not String.IsNullOrWhiteSpace(_param.TwitterUser) Then
                        paramList.Add(_param)
                        CbParams.Items.Add(line)
                    End If
                    line = _paramFileReader.ReadLine
                Loop
            End Using
            CbParams.SelectedIndex = -1
            ShowStatus(CStr(paramList.Count) & " parameters read", LblStatus, True, oSource)
        Else
            ShowStatus("Parameter file " & _paramFile & " not found", oSource)
        End If
    End Sub
    Private Sub ClearForm()
        CbTweetType.SelectedIndex = -1
        CbUserType.SelectedIndex = -1
        CbDay.SelectedIndex = -1
        CbMonth.SelectedIndex = -1
        ChkCurrentDay.Checked = False
        ChkOncePerDay.Checked = False
        ChkImages.Checked = False
        ChkHandles.Checked = False
        ChkAge.Checked = False
        NudBirthdaysPerTweet.Value = 0
        NudAnnivsPerTweet.Value = 0
        RbLeft.Checked = False
        RbCentre.Checked = True
        RbRight.Checked = False
        ChkMultiImage.Checked = False
        NudPicHorizontal.Value = 6
    End Sub
    Private Sub LoadFormFromParam(pParam As RunParam)
        With pParam
            CbTweetType.SelectedIndex = .TweetType
            CbUserType.SelectedIndex = .TweetUserType
            ChkOncePerDay.Checked = .IsOncePerDay
            CbTwitterUsers.SelectedIndex = CbTwitterUsers.FindStringExact(.TwitterUser)
            ChkCurrentDay.Checked = .IsSelectToday
            CbDay.SelectedIndex = .SelectDay - 1
            CbMonth.SelectedIndex = .SelectMonth - 1
            ChkCurrentDay.Checked = .IsSelectToday
            ChkImages.Checked = .IsImages
            ChkHandles.Checked = .IsHandles
            ChkAge.Checked = .IsAge
            NudBirthdaysPerTweet.Value = .BirthdayCount
            NudAnnivsPerTweet.Value = .AnniversaryCount
            RbLeft.Checked = .Lrc = "l"
            RbCentre.Checked = .Lrc = "c"
            RbRight.Checked = .Lrc = "r"
            ChkMultiImage.Checked = .IsMultiImage
            NudPicHorizontal.Value = .Width
        End With
    End Sub
    Private Function CreateParamFromForm() As RunParam
        Dim _runParam As New RunParam
        With _runParam
            .TweetType = CbTweetType.SelectedIndex
            .TweetUserType = CbUserType.SelectedIndex
            .IsOncePerDay = ChkOncePerDay.Checked
            .TwitterUser = CbTwitterUsers.SelectedValue
            .IsSelectToday = ChkCurrentDay.Checked
            .SelectDay = CbDay.SelectedIndex + 1
            .SelectMonth = CbMonth.SelectedIndex + 1
            .IsSelectToday = ChkCurrentDay.Checked
            .IsImages = ChkImages.Checked
            .IsHandles = ChkHandles.Checked
            .IsAge = ChkAge.Checked
            .BirthdayCount = NudBirthdaysPerTweet.Value
            .AnniversaryCount = NudAnnivsPerTweet.Value
            .Lrc = If(RbLeft.Checked, "l", If(RbRight.Checked, "r", "c"))
            .IsMultiImage = ChkMultiImage.Checked
            .Width = NudPicHorizontal.Value
        End With
        Return _runParam
    End Function
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearForm()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        paramList.Add(CreateParamFromForm)
    End Sub
#End Region
End Class
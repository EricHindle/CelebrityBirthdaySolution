' Hindleware
' Copyright (c) 2021-22, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class SocialMedia
    Private _id As Integer
    Private _twitterHandle As String
    Private _noTweet As Boolean
    Private _wikiId As String
    Private _botsd As Integer
    Private _isTwin As Boolean
    Private _celebrityType As Integer
    Public Property CelebrityType() As Integer
        Get
            Return _celebrityType
        End Get
        Set(ByVal value As Integer)
            _celebrityType = value
        End Set
    End Property
    Public Property IsTwin() As Boolean
        Get
            Return _isTwin
        End Get
        Set(ByVal value As Boolean)
            _isTwin = value
        End Set
    End Property
    Public Property Botsd() As Integer
        Get
            Return _botsd
        End Get
        Set(ByVal value As Integer)
            _botsd = value
        End Set
    End Property
    Public Property WikiId() As String
        Get
            Return _wikiId
        End Get
        Set(ByVal value As String)
            _wikiId = value
        End Set
    End Property
    Public Property IsNoTweet() As Boolean
        Get
            Return _noTweet
        End Get
        Set(ByVal value As Boolean)
            _noTweet = value
        End Set
    End Property
    Public Property TwitterHandle() As String
        Get
            Return _twitterHandle
        End Get
        Set(ByVal value As String)
            _twitterHandle = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private Sub Initialise()
        _id = -1
        _twitterHandle = ""
        _noTweet = False
        _wikiId = ""
        _botsd = 0
        _celebrityType = 0
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, pTwitterHandle As String, pNoTweet As Boolean, pWikiId As String, pBotsd As Integer, pIsTwin As Boolean, pCelebType As Integer)
        Initialise()
        _id = pId
        _twitterHandle = pTwitterHandle
        _noTweet = pNoTweet
        _wikiId = pWikiId
        _botsd = pBotsd
        _isTwin = pIsTwin
        _celebrityType = pCelebType
    End Sub
    Public Sub New(pSocialMedia As SocialMedia)
        Initialise()
        If pSocialMedia IsNot Nothing Then
            _id = pSocialMedia.Id
            _twitterHandle = pSocialMedia.TwitterHandle
            _noTweet = pSocialMedia.IsNoTweet
            _wikiId = pSocialMedia.WikiId
            _botsd = pSocialMedia.Botsd
            _isTwin = pSocialMedia.IsTwin
            _celebrityType = pSocialMedia.CelebrityType
        End If
    End Sub
    Public Sub New(pSocialMedia As CelebrityBirthdayDataSet.SocialMediaRow)
        Initialise()
        If pSocialMedia IsNot Nothing Then
            _id = pSocialMedia.personId
            _twitterHandle = pSocialMedia.twitterHandle
            _noTweet = pSocialMedia.noTweet
            _wikiId = If(pSocialMedia.IswikiIdNull, "", pSocialMedia.wikiId)
            _botsd = If(pSocialMedia.IsbotsdNull, 0, pSocialMedia.botsd)
            _isTwin = If(pSocialMedia.IsisTwinNull, 0, pSocialMedia.isTwin)
            _celebrityType = If(pSocialMedia.IscelebtypeNull, 0, pSocialMedia.celebtype)
        End If
    End Sub

End Class

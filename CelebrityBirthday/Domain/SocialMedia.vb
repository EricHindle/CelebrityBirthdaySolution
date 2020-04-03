Public Class SocialMedia
    Private _id As Integer
    Private _twitterHandle As String
    Private _noTweet As Boolean
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
    End Sub
    Public Sub New()
        Initialise()
    End Sub
    Public Sub New(pId As Integer, pTwitterHandle As String, pNoTweet As Boolean)
        Initialise()
        _id = pId
        _twitterHandle = pTwitterHandle
        _noTweet = pNoTweet
    End Sub
    Public Sub New(pSocialMedia As SocialMedia)
        Initialise()
        If pSocialMedia IsNot Nothing Then
            _id = pSocialMedia.Id
            _twitterHandle = pSocialMedia.TwitterHandle
            _noTweet = pSocialMedia.IsNoTweet
        End If
    End Sub
    Public Sub New(pSocialMedia As CelebrityBirthdayDataSet.SocialMediaRow)
        Initialise()
        If pSocialMedia IsNot Nothing Then
            _id = pSocialMedia.personId
            _twitterHandle = pSocialMedia.twitterHandle
            _noTweet = pSocialMedia.noTweet
        End If
    End Sub
End Class

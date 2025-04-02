' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Threading.Tasks
Imports Tweetinvi
Imports Tweetinvi.Core.Web
Imports Tweetinvi.WebLogic

Module modTwitter
    Public tw As New TwitterOAuth
    Public Sub SetConsumerKey()
        tw = New TwitterOAuth
        Dim projectId As String = GlobalSettings.GetSetting("TwitterProjectKey")
        Dim _auth As TwitterOAuth = GetAuthById(projectId)
        tw.ConsumerKey = _auth.Token
        tw.ConsumerSecret = _auth.TokenSecret
    End Sub
    Public Async Function PostTheTweet(_tweetText As String, twitterUser As String, Optional _filename As String = Nothing) As Task(Of ITwitterResult)
        Const Psub As String = "PostTheTweet"
        LogUtil.Info("Sending Tweet as " & twitterUser, Psub)
        SetConsumerKey()
        SetupOAuth(twitterUser)
        Dim userClient = New TwitterClient(tw.ConsumerKey, tw.ConsumerSecret, tw.Token, tw.TokenSecret)
        Dim user = Await userClient.Users.GetAuthenticatedUserAsync()
        Dim oResult As ITwitterResult = Nothing
        Dim poster = New TweetsV2Poster(userClient)
        If _filename IsNot Nothing Then
            Try
                ' Post media
                LogUtil.Info("Posting Image from " & _filename, Psub)
                Dim tweetinviLogoBinary As Byte() = File.ReadAllBytes(_filename)
                Dim UploadedImage As Models.IMedia = Await userClient.Upload.UploadTweetImageAsync(tweetinviLogoBinary)
                Dim uploadedMediaId As String = UploadedImage.UploadedMediaInfo.MediaId
                LogUtil.Info("Image Id : " & uploadedMediaId, Psub)
                ' Post Tweet with Image
                LogUtil.Info("Posting Tweet", Psub)
                Dim mediaList As New List(Of String) From {
                   uploadedMediaId
                }
                Dim _mediaIds As New TweetV2ImageIds With {.MediaId = mediaList}
                oResult = Await poster.PostTweet(New TweetV2PostTextAndMedia With {
                                                                            .Text = _tweetText,
                                                                            .MediaIds = _mediaIds
                                                                            })
            Catch ex As Exception
                LogUtil.Exception("Twitter post exception", ex, Psub)
                oResult = New TwitterResult With {
                    .Response = New TwitterResponse With {
                    .StatusCode = 999}
                }
            End Try
        Else
            Try
                ' Post Tweet 
                oResult = Await poster.PostTweet(New TweetV2PostText With {
                                                                    .Text = _tweetText
                                                                    })
            Catch ex As Exception
                LogUtil.Exception("Twitter post exception", ex, Psub)
                oResult = New TwitterResult With {
                    .Response = New TwitterResponse With {
                    .StatusCode = 999}
                }
            End Try
        End If
        Return oResult
    End Function
    Public Function SetupOAuth(twitterUser As String) As Boolean
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

End Module

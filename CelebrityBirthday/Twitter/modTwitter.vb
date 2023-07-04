' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Threading.Tasks
Imports Tweetinvi
Imports Tweetinvi.Core.Web
Imports Tweetinvi.Models.V2

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
        Dim _result As ITwitterResult = Nothing
        If _filename IsNot Nothing Then
            ' Post media

            Dim tweetinviLogoBinary As Byte() = File.ReadAllBytes(_filename)
            Dim UploadedImage As Models.IMedia = Await userClient.Upload.UploadTweetImageAsync(tweetinviLogoBinary)

            Try
                Dim poster = New TweetsV2Poster(userClient)
                Dim mediaList As New List(Of String) From {
               UploadedImage.UploadedMediaInfo.MediaId
            }
                Dim media As New TweetV2ImageIds With {.MediaId = mediaList}
                _result = Await poster.PostTweet(New TweetV2PostTextAndMedia With {
                                                                            .Text = _tweetText,
                                                                            .MediaIds = media
                                                                            })
            Catch ex As Exception
            End Try



            '_result = Await UploadText(userClient, _tweetText, UploadedImage.UploadedMediaInfo.MediaId).Result
        Else
            Try
                Dim poster = New TweetsV2Poster(userClient)
                _result = Await poster.PostTweet(New TweetV2PostText With {
                                                                    .Text = _tweetText
                                                                    })
            Catch ex As Exception
            End Try
            '  _result = UploadText(userClient, _tweetText).Result
        End If
        Return _result
    End Function
    'Private Async Function UploadText(userClient As TwitterClient, _tweettext As String, _mediaId As Long) As Task(Of ITwitterResult)
    '    Dim _result As ITwitterResult = Nothing
    '    Try
    '        Dim poster = New TweetsV2Poster(userClient)
    '        Dim mediaList As New List(Of String) From {
    '           _mediaId
    '        }
    '        Dim media As New TweetV2ImageIds With {.MediaId = mediaList}
    '        _result = Await poster.PostTweet(New TweetV2PostTextAndMedia With {
    '                                                                        .Text = _tweettext,
    '                                                                        .MediaIds = media
    '                                                                        })
    '    Catch ex As Exception
    '    End Try
    '    Return _result
    'End Function
    'Private Async Function UploadText(userClient As TwitterClient, _tweettext As String) As Task(Of ITwitterResult)
    '    Dim _result As ITwitterResult = Nothing
    '    Try
    '        Dim poster = New TweetsV2Poster(userClient)
    '        _result = Await poster.PostTweet(New TweetV2PostText With {
    '                                                                .Text = _tweettext
    '                                                                })
    '    Catch ex As Exception
    '    End Try
    '    Return _result
    'End Function
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

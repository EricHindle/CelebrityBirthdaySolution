' Hindleware
' Copyright (c) 2020-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Tweetinvi
Imports Tweetinvi.Core.Web
Imports Tweetinvi.Models

Public Class TweetsV2Poster
    Private ReadOnly client As ITwitterClient

    Public Sub New(ByVal client As ITwitterClient)
        Me.client = client
    End Sub

    Public Function PostTweet(ByVal tweetContent As TweetV2PostTextAndMedia) As Task(Of ITwitterResult)
        Dim _content As String = client.Json.Serialize(tweetContent)
        Return ExecuteRequest(_content)
    End Function
    Public Function PostTweet(ByVal tweetContent As TweetV2PostText) As Task(Of ITwitterResult)
        Dim _content As String = client.Json.Serialize(tweetContent)
        Return ExecuteRequest(_content)
    End Function
    Public Function ExecuteRequest(ByVal tweetContent As String) As Task(Of ITwitterResult)
        Return client.Execute.AdvanceRequestAsync(Function(ByVal request As ITwitterRequest)
                                                      Dim jsonBody = tweetContent
                                                      Dim content = New StringContent(jsonBody, Encoding.UTF8, "application/json")
                                                      request.Query.Url = "https://api.twitter.com/2/tweets"
                                                      request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST
                                                      request.Query.HttpContent = content
                                                      Return request
                                                  End Function)
    End Function

End Class

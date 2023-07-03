' Hindleware
' Copyright (c) 2020-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Net.Http
Imports System.Text
Imports Tweetinvi
Imports Tweetinvi.Core.Web
Imports Tweetinvi.Models

Public Class TweetsV2Poster
    Private ReadOnly client As ITwitterClient

    Public Sub New(ByVal client As ITwitterClient)
        Me.client = client
    End Sub

    Public Function PostTweet(ByVal tweetParams As TweetV2PostContent) As Task(Of ITwitterResult)

        Return client.Execute.AdvanceRequestAsync(Function(ByVal request As ITwitterRequest)
                                                      Dim jsonBody = client.Json.Serialize(tweetParams)
                                                      Dim content = New StringContent(jsonBody, Encoding.UTF8, "application/json")
                                                      request.Query.Url = "https://api.twitter.com/2/tweets"
                                                      request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST
                                                      request.Query.HttpContent = content
                                                      Return request
                                                  End Function)
    End Function
End Class

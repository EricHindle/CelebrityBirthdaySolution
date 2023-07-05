' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Newtonsoft.Json
Public Class TweetV2PostText
    <JsonProperty("text")>
    Public Property Text As String = String.Empty
End Class
Public Class TweetV2PostTextAndMedia
    Inherits TweetV2PostText
    <JsonProperty("media")>
    Public Property MediaIds As TweetV2ImageIds
End Class
Public Class TweetV2ImageIds
    <JsonProperty("media_ids")>
    Public Property MediaId As List(Of String)
End Class

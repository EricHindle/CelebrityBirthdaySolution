' Hindleware
' Copyright (c) 2020-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports Newtonsoft.Json

Public Class TweetV2PostContent
    <JsonProperty("text")>
    Public Property Text As String = String.Empty

    <JsonProperty("media")>
    Public Property MediaIds As TweetV2ImageIds
End Class
Public Class TweetV2ImageIds
    <JsonProperty("media_ids")>
    Public Property MediaId As List(Of String)
End Class

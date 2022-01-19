' Hindleware
' Copyright (c) 2021-22, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO
Imports System.Reflection
Imports TweetSharp
Module modTwitter
    Public Function PostMedia(pTwitterService As TwitterService, _filename As String) As TwitterUploadedMedia
        Dim _uploadOptions As New UploadMediaOptions
        Dim _mediaFile As New MediaFile With {
            .FileName = _filename
        }
        Dim _twitterUplMedia As TwitterUploadedMedia = Nothing
        Try
            Using _imgstream As New FileStream(_filename, FileMode.Open)
                _mediaFile.Content = _imgstream
                _uploadOptions.Media = _mediaFile
                _twitterUplMedia = pTwitterService.UploadMedia(_uploadOptions)
            End Using
        Catch ex As IOException
            DisplayException(MethodBase.GetCurrentMethod, ex, "IO")
        End Try
        Return _twitterUplMedia
    End Function

End Module

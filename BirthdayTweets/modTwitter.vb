﻿Imports System.IO
Imports System.Reflection
Imports TweetSharp
Module modTwitter
    Public Function PostMedia(pTwitterService As TwitterService, _filename As String) As TwitterUploadedMedia
        Const Psub As String = "PostMedia"
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
            LogUtil.Exception("Pos tMedia IOException", ex, Psub)
        End Try
        Return _twitterUplMedia
    End Function

End Module

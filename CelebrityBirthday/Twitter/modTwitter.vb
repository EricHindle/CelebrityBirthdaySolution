Imports System.Drawing.Imaging
Imports System.IO
Imports TweetSharp
Module modTwitter
    Public Function PostMedia(pTwitterService As TwitterService, _filename As String) As TwitterUploadedMedia
        Dim _uploadOptions As New UploadMediaOptions
        Dim _mediaFile As New MediaFile With {
            .FileName = _filename
        }
        Dim _twitterUplMedia As TwitterUploadedMedia
        Using _imgstream As New FileStream(_filename, FileMode.Open)
            _mediaFile.Content = _imgstream
            _uploadOptions.Media = _mediaFile
            _twitterUplMedia = pTwitterService.UploadMedia(_uploadOptions)
        End Using
        Return _twitterUplMedia
    End Function

End Module

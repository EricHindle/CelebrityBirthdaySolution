Imports System.IO
Imports System.Reflection
Imports TweetSharp
Module modTwitter
    Public Function PostMedia(pTwitterService As TwitterService, _filename As String) As TwitterUploadedMedia
        Const Psub As String = "PostMedia"
        Dim _uploadOptions As New UploadMediaOptions
        Dim tryLimit As Integer = Math.Max(1, GlobalSettings.GetIntegerSetting("TwitterImageRetryLimit"))
        LogUtil.Debug("TwitterImageRetryLimit " & CStr(tryLimit), Psub)
        Dim _mediaFile As New MediaFile With {
            .FileName = _filename
        }
        Dim _twitterUplMedia As TwitterUploadedMedia = Nothing
        Try
            Dim _tries As Integer = 0
            Do While _tries < tryLimit
                Using _imgstream As New FileStream(_filename, FileMode.Open)
                    _mediaFile.Content = _imgstream
                    _uploadOptions.Media = _mediaFile
                    _twitterUplMedia = pTwitterService.UploadMedia(_uploadOptions)
                    _tries += 1
                    If _twitterUplMedia Is Nothing Then
                        LogUtil.Info("Twitter media upload failed", Psub)
                        If _tries < tryLimit Then
                            LogUtil.Info("Trying again.", Psub)
                        Else
                            LogUtil.Info("No more tries", Psub)
                        End If
                    Else
                        LogUtil.Info("Twitter media upload complete", Psub)
                        Exit Do
                    End If
                End Using
            Loop
        Catch ex As IOException
            LogUtil.Exception("Pos tMedia IOException", ex, Psub)
        End Try
        Return _twitterUplMedia
    End Function

End Module

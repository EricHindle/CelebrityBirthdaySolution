Imports System.IO

Imports System.Net
Imports System.Reflection

Public Class frmImageStore
#Region "variables"
    Dim b() As Byte '   Store picture bytes
    Dim sImagePath As String
    Dim sApplicationPath As String
    Dim bLoadingPicture As Boolean = False
    Dim isSaved As Boolean = True
#End Region
#Region "properties"
    Private _forename As String
    Private _surname As String
    Public Property Surname() As String
        Get
            Return _surname
        End Get
        Set(ByVal value As String)
            _surname = value
        End Set
    End Property
    Public Property Forename() As String
        Get
            Return _forename
        End Get
        Set(ByVal value As String)
            _forename = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub ImageStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtForename.Text = _forename
        TxtSurname.Text = _surname
        GetFormPos(Me, My.Settings.imgselectpos)
        sApplicationPath = My.Application.Info.DirectoryPath
        sImagePath = My.Settings.newimagepath.Replace("<applicationpath>", sApplicationPath)
        OpenImageSearch()
        LblImagePath.Text = sImagePath
        lblPicUrl.Text = ""
        If My.Computer.FileSystem.DirectoryExists(sImagePath) = False Then
            My.Computer.FileSystem.CreateDirectory(sImagePath)
        End If
        isSaved = True
    End Sub
    Private Sub BtnSavepic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavepic.Click
        sImagePath = My.Settings.newimagepath.Replace("<applicationpath>", sApplicationPath)
        If bLoadingPicture Then
            MsgBox("Picture still loading", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim url As String = lblPicUrl.Text
        Dim ext As String = Path.GetExtension(url)
        If String.IsNullOrEmpty(ext) Then
            ext = ".jpg"
        End If
        Dim picname As String = Path.GetFileNameWithoutExtension(url)
        Dim strFName As String = ""
        Dim _Filename As String = MakeImageName(TxtForename.Text, TxtSurname.Text)
        Dim request As WebRequest = Nothing
        Try
            For Each c In Path.GetInvalidFileNameChars()
                _Filename = _Filename.Replace(c, "").Trim
            Next
            strFName = Path.Combine(sImagePath, _Filename & ext)
            PicStatus.Text = "Saving " & picname
            Me.Refresh()
            If My.Computer.FileSystem.FileExists(strFName) Then
                strFName = GetUniqueFname(strFName)
            End If
            Me.Refresh()
            ' Create a request for the URL. 
            request = WebRequest.Create(url)
            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials
        Catch ex As Exception
            If DisplayException(ex) = MsgBoxResult.No Then Exit Sub
        End Try
        ' Get the response.
        Try
            Dim response As WebResponse = request.GetResponse()

            ' Display the status.
            PicStatus.Text = CType(response, HttpWebResponse).StatusDescription
            Me.Refresh()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()

            ' Read the content.
            Dim buffer(4096) As Byte
            Dim memorystream As New MemoryStream
            Dim bct As Integer = -1
            PicStatus.Text = "Writing memory stream"
            Me.Refresh()
            Do While (bct <> 0)
                bct = dataStream.Read(buffer, 0, buffer.Length)
                memorystream.Write(buffer, 0, bct)
            Loop
            b = memorystream.ToArray()
            PicStatus.Text = "Writing file"
            Me.Refresh()
            If b.Length > 0 Then
                Dim bw As BinaryWriter = Nothing
                Try
                    bw = New BinaryWriter(File.Open(strFName, FileMode.Create))
                    bw.Write(b)
                Catch ex As Exception
                    MsgBox("Error writing file")
                Finally
                    If bw IsNot Nothing Then
                        bw.Close()
                    End If
                    bw = Nothing
                End Try
            End If
            ' Clean up the streams and the response.
            memorystream.Close()
            response.Close()
            memorystream.Dispose()
            response = Nothing
            PicStatus.Text = "Saved " & strFName
            isSaved = True
        Catch ex As Exception
            If DisplayException(ex) = MsgBoxResult.No Then Exit Sub
            PicStatus.Text = ex.Message
        End Try
    End Sub
    Private Sub PicBrowser_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles PicBrowser.DocumentCompleted
        PicStatus.Text = "Picture complete"
        bLoadingPicture = False
        lblPicUrl.Text = PicBrowser.Url.ToString
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        My.Settings.imgselectpos = SetFormPos(Me)
        My.Settings.Save()
        Me.Close()
    End Sub
    Private Sub BtnSelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelFolder.Click
        FolderBrowserDialog1.SelectedPath = My.Settings.newimagepath
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim sFolder = FolderBrowserDialog1.SelectedPath
            My.Settings.newimagepath = sFolder
            My.Settings.Save()
            LblImagePath.Text = sFolder
        End If
    End Sub
    Private Sub FrmImageStore_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        My.Settings.imgselectpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub PicBrowser_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PicBrowser.NewWindow
        e.Cancel = True
        PicBrowser.Navigate(PicBrowser.StatusText)
    End Sub
    Private Sub BtnGetImage_Click(sender As Object, e As EventArgs) Handles btnGetImage.Click
        isSaved = False
        lblPicUrl.Text = ""
        OpenImageSearch()
        PicStatus.Text = "Getting images for " & TxtForename.Text.Trim
    End Sub
    Private Sub FrmImageStore_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not isSaved Then
            If MsgBox("Image has not been saved. OK to close?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub PicBrowser_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles PicBrowser.Navigated
        lblPicUrl.Text = If(PicBrowser.Url Is Nothing, "", PicBrowser.Url.ToString)
        isSaved = False
    End Sub
#End Region
#Region "functions"
    Private Sub OpenImageSearch()
        Dim _name As String = If(String.IsNullOrEmpty(TxtForename.Text.Trim), "", TxtForename.Text.Trim & " ") & TxtSurname.Text.Trim
        If Not String.IsNullOrEmpty(_name) Then
            Dim sUrl As String = GetGoogleSearchString(_name)
            Process.Start(sUrl)
            lblSearchUrl.Text = sUrl
        End If
    End Sub
    Private Function GetUniqueFname(ByVal filename As String) As String
        Dim newfilename As String = filename
        Try
            For subs As Integer = 0 To 999
                newfilename = Path.Combine(sImagePath, Path.GetFileNameWithoutExtension(filename) & "_" & CStr(subs) & Path.GetExtension(filename))
                If My.Computer.FileSystem.FileExists(newfilename) = False Then
                    Exit For
                End If
            Next
        Catch ex As Exception
            DisplayException(ex)
        End Try
        Return newfilename
    End Function
    Private Function DisplayException(ByVal ex As Exception) As MsgBoxResult
        Return MsgBox("Exception: " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message) & vbCrLf & "OK to continue?", MsgBoxStyle.YesNo, "Excpetion")
    End Function
#End Region
End Class
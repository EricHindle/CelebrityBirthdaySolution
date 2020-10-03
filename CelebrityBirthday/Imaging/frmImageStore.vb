Imports System.IO

Imports System.Net
Imports System.Reflection

Public Class FrmImageStore
#Region "variables"
    Dim sImagePath As String
    Dim sApplicationPath As String
    Dim isSaved As Boolean = True
    Dim _latestSavedFile As String = ""
#End Region
#Region "properties"
    Private _forename As String
    Private _surname As String
    Private _savedImage As String
    Public Property SavedImage() As String
        Get
            Return _savedImage
        End Get
        Set(ByVal value As String)
            _savedImage = value
        End Set
    End Property
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
        LogUtil.Info("Loading", MyBase.Name)
        PictureBox1.AllowDrop = True
        TxtForename.Text = _forename
        TxtSurname.Text = _surname
        GetFormPos(Me, My.Settings.imgselectpos)
        sApplicationPath = My.Application.Info.DirectoryPath
        sImagePath = My.Settings.NewImagePath.Replace("<applicationpath>", sApplicationPath)
        OpenImageSearch()
        LblImagePath.Text = sImagePath
        If My.Computer.FileSystem.DirectoryExists(sImagePath) = False Then
            My.Computer.FileSystem.CreateDirectory(sImagePath)
        End If
        isSaved = True
    End Sub
    Private Sub BtnSavepic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavepic.Click
        If PictureBox1.Image IsNot Nothing Then
            sImagePath = My.Settings.NewImagePath.Replace("<applicationpath>", sApplicationPath)
            Try
                Dim _Filename As String = MakeImageName(TxtForename.Text, TxtSurname.Text)
                If String.IsNullOrEmpty(_Filename) = False Then
                    Dim strFName As String = Path.Combine(sImagePath, _Filename & ".jpg")
                    If My.Computer.FileSystem.FileExists(strFName) Then
                        strFName = GetUniqueFname(strFName)
                    End If
                    _latestSavedFile = strFName
                    lblImageFile.Text = strFName
                    PicStatus.Text = "Saving " & strFName
                    Me.Refresh()
                    PictureBox1.Image.Save(strFName, Imaging.ImageFormat.Jpeg)
                    PicStatus.Text = "Saved " & strFName
                    isSaved = True
                Else
                    MsgBox("No name entered. Cannot save to file.", MsgBoxStyle.Exclamation, "Missing name")
                End If
            Catch ex As ArgumentException
                If DisplayException(ex) = MsgBoxResult.No Then Exit Sub
                PicStatus.Text = ex.Message
            End Try
        Else
            MsgBox("No image. Cannot save to file.", MsgBoxStyle.Exclamation, "Missing image")
        End If
    End Sub
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        My.Settings.imgselectpos = SetFormPos(Me)
        My.Settings.Save()
        Me.Close()
    End Sub
    Private Sub BtnSelFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelFolder.Click
        FolderBrowserDialog1.SelectedPath = My.Settings.NewImagePath
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim sFolder = FolderBrowserDialog1.SelectedPath
            My.Settings.NewImagePath = sFolder
            My.Settings.Save()
            LblImagePath.Text = sFolder
        End If
    End Sub
    Private Sub FrmImageStore_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        My.Settings.imgselectpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnGetImage_Click(sender As Object, e As EventArgs) Handles btnGetImage.Click
        isSaved = False
        OpenImageSearch()
        PicStatus.Text = "Getting images for " & TxtForename.Text.Trim
    End Sub
    Private Sub FrmImageStore_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        If Not isSaved Then
            If MsgBox("Image has not been saved. OK to close?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Warning") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
        My.Settings.imgselectpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnEditImage_Click(sender As Object, e As EventArgs) Handles BtnEditImage.Click
        _savedImage = Nothing
        Using _editImage As New frmImageCapture
            _editImage.ImageFile = _latestSavedFile
            _editImage.Forename = TxtForename.Text
            _editImage.Surname = TxtSurname.Text
            _editImage.ShowDialog()
            _savedImage = _editImage.SavedImage
            PictureBox2.ImageLocation = _savedImage
        End Using
    End Sub
    Private Sub BtnLoadImage_Click(sender As Object, e As EventArgs) Handles btnLoadImage.Click
        Try
            Dim oImageFilename As String = ImageUtil.GetImageFileName(ImageUtil.OpenOrSave.Open, ImageUtil.ImageType.ALL)
            _latestSavedFile = oImageFilename
            lblImageFile.Text = _latestSavedFile
            Dim sizeMessage As String = ""
            If Not String.IsNullOrEmpty(oImageFilename) Then
                Dim oImage As Image = Image.FromFile(oImageFilename)
                Dim loadedImage As Image = oImage.Clone
                If oImage IsNot Nothing Then
                    PictureBox1.Image = loadedImage
                End If
                oImage.Dispose()
            End If
            Dim filenameparts As List(Of String) = Split(Path.GetFileNameWithoutExtension(_latestSavedFile), "-").ToList
            If String.IsNullOrEmpty(TxtSurname.Text) Then
                TxtSurname.Text = filenameparts.Last
                filenameparts.RemoveAt(filenameparts.Count - 1)
            End If
            If String.IsNullOrEmpty(TxtForename.Text) Then
                TxtForename.Text = String.Join(" ", filenameparts)
            End If
        Catch ex As ArgumentException
            DisplayException(ex)
        Catch ex As FileNotFoundException
            DisplayException(ex)
        Catch ex As OutOfMemoryException
            DisplayException(ex)
            GC.Collect()
        End Try
    End Sub
    Private Sub PasteImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteImageToolStripMenuItem.Click
        If Clipboard.ContainsImage Then
            PictureBox1.Image = Clipboard.GetImage
        End If
    End Sub

#End Region
#Region "functions"
    Private Sub OpenImageSearch()
        Dim _name As String = If(String.IsNullOrEmpty(TxtForename.Text.Trim), "", TxtForename.Text.Trim & " ") & TxtSurname.Text.Trim
        If Not String.IsNullOrEmpty(_name) Then
            Dim sUrl As String = GetGoogleSearchString(_name)
            Process.Start(sUrl)
        End If
    End Sub
    Private Shared Function DisplayException(ByVal ex As Exception) As MsgBoxResult
        Return MsgBox("Exception: " & ex.Message & vbCrLf & If(ex.InnerException Is Nothing, "", ex.InnerException.Message) & vbCrLf & "OK to continue?", MsgBoxStyle.YesNo, "Excpetion")
    End Function
#End Region
End Class
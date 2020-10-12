Imports System.IO
Imports System.Reflection

Public Class ImageIdentity
    Implements IDisposable

    Private _id As Integer
    Private _imageFileName As String
    Private _imageFileType As String
    Private _imageLoadYear As String
    Private _imageLoadMonth As String
    Private _imagePhoto As Image
    Public Property Photo() As Image
        Get
            Return _imagePhoto
        End Get
        Set(ByVal value As Image)
            _imagePhoto = value
        End Set
    End Property
    Public Property ImageLoadMonth() As String
        Get
            Return _imageLoadMonth
        End Get
        Set(ByVal value As String)
            _imageLoadMonth = value
        End Set
    End Property
    Public Property ImageLoadYear() As String
        Get
            Return _imageLoadYear
        End Get
        Set(ByVal value As String)
            _imageLoadYear = value
        End Set
    End Property
    Public Property ImageFileType() As String
        Get
            Return _imageFileType
        End Get
        Set(ByVal value As String)
            _imageFileType = value
        End Set
    End Property
    Public Property ImageFileName() As String
        Get
            Return _imageFileName
        End Get
        Set(ByVal value As String)
            _imageFileName = value
        End Set
    End Property
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private Sub InitialiseImage()
        _id = -1
        _imageFileName = ""
        _imageFileType = ""
        _imageLoadMonth = ""
        _imageLoadYear = ""
        _imagePhoto = New Bitmap(60, 60)
    End Sub
    Public Sub New()
        InitialiseImage()
    End Sub
    Public Sub New(pId As Integer, pFileName As String, pFileType As String, pLoadMonth As String, pLoadYear As String)
        _id = pId
        _imageFileName = pFileName
        _imageFileType = pFileType
        _imageLoadMonth = pLoadMonth
        _imageLoadYear = pLoadYear
        _imagePhoto = GetPhotoFromFile()
    End Sub

    Public Sub New(pImage As ImageIdentity)
        If pImage IsNot Nothing Then
            _id = pImage.Id
            _imageFileName = pImage.ImageFileName
            _imageFileType = pImage.ImageFileType
            _imageLoadMonth = pImage.ImageLoadMonth
            _imageLoadYear = pImage.ImageLoadYear
            _imagePhoto = pImage.Photo
        Else
            InitialiseImage()
        End If
    End Sub
    Public Sub New(ByRef oRow As CelebrityBirthdayDataSet.ImageRow)
        If oRow IsNot Nothing Then
            _id = oRow.id
            _imageFileName = oRow.imgfilename
            _imageFileType = oRow.imgfiletype
            _imageLoadMonth = oRow.imgloadmonth
            _imageLoadYear = oRow.imgloadyr
            _imagePhoto = GetPhotoFromFile()
        Else
            InitialiseImage()
        End If
    End Sub
    Public Function FullFileName() As String
        Return _imageFileName.Trim & _imageFileType.Trim
    End Function
    Private Function GetPhotoFromFile() As Image
        Dim _imageFromFile As Image = New Bitmap(60, 60)
        If Not String.IsNullOrEmpty(_imageFileName) Then
            Dim _Filename As String = Path.Combine(My.Settings.ImgPath, _imageFileName & _imageFileType)
            If My.Computer.FileSystem.FileExists(_Filename) Then
                Try
                    _imageFromFile = Image.FromFile(_Filename)
                Catch ex As OutOfMemoryException
                    DisplayException(MethodBase.GetCurrentMethod, ex, "Out of Memory")
                Catch ex As FileNotFoundException
                    DisplayException(MethodBase.GetCurrentMethod, ex, "File Not Found")
                Catch ex As ArgumentException
                    DisplayException(MethodBase.GetCurrentMethod, ex, "Argument")
                End Try
            Else
                LogUtil.Debug(_Filename & " does not exist")
            End If
        End If
        Return _imageFromFile
    End Function
    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposing Then
            _imagePhoto.Dispose()
        End If
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
End Class

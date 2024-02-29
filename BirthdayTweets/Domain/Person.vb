' Hindleware
' Copyright (c) 2020-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Web.UI

Public Class Person
    Implements IDisposable
#Region "properties"
    Private _id As Integer
    Private _forename As String
    Private _surname As String
    Private _birthYear As String
    Private _deathYear As Integer
    Private _description As String
    Private _birthMonth As Integer
    Private _birthDay As Integer
    Private _ShortDesc As String
    Private _birthPlace As String
    Private _birthName As String
    Private _sortSeq As Integer
    Private _unsavedChanges As Boolean
    Private _deathday As Integer
    Private _deathMonth As Integer
    Private _image As ImageIdentity
    Private _social As SocialMedia

    Public Property Social() As SocialMedia
        Get
            Return _social
        End Get
        Set(ByVal value As SocialMedia)
            _social = value
        End Set
    End Property
    Public Property Image() As ImageIdentity
        Get
            Return _image
        End Get
        Set(ByVal value As ImageIdentity)
            _image = value
        End Set
    End Property
    Public Property DeathMonth() As Integer
        Get
            Return _deathMonth
        End Get
        Set(ByVal value As Integer)
            _deathMonth = value
        End Set
    End Property
    Public Property DeathDay() As Integer
        Get
            Return _deathday
        End Get
        Set(ByVal value As Integer)
            _deathday = value
        End Set
    End Property
    Public Property BirthPlace() As String
        Get
            Return _birthPlace
        End Get
        Set(ByVal value As String)
            _birthPlace = value
        End Set
    End Property
    Public Property BirthName() As String
        Get
            Return _birthName
        End Get
        Set(ByVal value As String)
            _birthName = value
        End Set
    End Property
    Public Property UnsavedChanges() As Boolean
        Get
            Return _unsavedChanges
        End Get
        Set(ByVal value As Boolean)
            _unsavedChanges = value
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
    Public Property Sortseq() As Integer
        Get
            Return _sortSeq
        End Get
        Set(ByVal value As Integer)
            _sortSeq = value
        End Set
    End Property
    Public Property ShortDesc() As String
        Get
            Return _ShortDesc
        End Get
        Set(ByVal value As String)
            _ShortDesc = value
        End Set
    End Property
    Public Property BirthDay() As Integer
        Get
            Return _birthDay
        End Get
        Set(ByVal value As Integer)
            _birthDay = value
        End Set
    End Property
    Public Property BirthMonth() As Integer
        Get
            Return _birthMonth
        End Get
        Set(ByVal value As Integer)
            _birthMonth = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property
    Public Property DeathYear() As Integer
        Get
            Return _deathYear
        End Get
        Set(ByVal value As Integer)
            _deathYear = value
        End Set
    End Property
    Public Property BirthYear() As String
        Get
            Return _birthYear
        End Get
        Set(ByVal value As String)
            _birthYear = value
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
    Public Property ForeName() As String
        Get
            Return _forename
        End Get
        Set(ByVal value As String)
            _forename = value
        End Set
    End Property
    Public ReadOnly Property IBirthYear() As Integer
        Get
            Dim iYr As Integer = 0
            Dim isBC As Boolean = _birthYear.ToLower(myCultureInfo).IndexOf("bc", StringComparison.CurrentCultureIgnoreCase) >= 0
            Try
                iYr = Integer.Parse(_birthYear.ToLower(myCultureInfo).Replace("bc", "").Trim(), myStringFormatProvider)
                If isBC Then
                    iYr *= -1
                End If
            Catch ex As OverflowException
            Catch ex As ArgumentException
            Catch ex As FormatException
            End Try
            Return iYr
        End Get
    End Property
    Public ReadOnly Property Name() As String
        Get
            Return If(String.IsNullOrEmpty(_forename), _surname, _forename & " " & _surname)
        End Get
    End Property
    Public ReadOnly Property DateOfBirth As Date?
        Get
            Const Psub As String = "DateOfBirth"
            Dim _dob As Date? = Nothing
            Try
                _dob = New Date(_birthYear, _birthMonth, _birthDay)
            Catch ex As ArgumentOutOfRangeException
                LogUtil.Problem(Name & "Invalid date of birth", Psub)
            End Try
            Return _dob
        End Get
    End Property
    Public ReadOnly Property DateOfDeath As Date?
        Get
            Const Psub As String = "DateOfDeath"
            Dim _dod As Date? = Nothing
            If _deathYear <> 0 Then
                Try
                    _dod = New Date(_birthYear, _birthMonth, _birthDay)
                Catch ex As ArgumentOutOfRangeException
                    LogUtil.Problem(Name & "Invalid date of death", Psub)
                End Try
            End If
            Return _dod
        End Get
    End Property
#End Region
#Region "constructors"
    Private Sub InitialisePerson()
        _id = -1
        _forename = ""
        _surname = ""
        _ShortDesc = ""
        _sortSeq = 0
        _description = ""
        _birthDay = 0
        _birthMonth = 0
        _birthYear = ""
        _deathYear = 0
        _image = New ImageIdentity()
        _unsavedChanges = False
        _deathMonth = 0
        _deathday = 0
        _birthName = ""
        _birthPlace = ""
        _social = New SocialMedia()
    End Sub
    Public Sub New()
        InitialisePerson()
    End Sub
    Public Sub New(ByVal pForename As String, ByVal pSurname As String, ByVal pDesc As String, ByVal pShortDesc As String, ByVal pDay As Integer, ByVal pMonth As Integer, ByVal pYear As String, ByVal pDeathYr As Integer, ByVal pDeathMonth As Integer, ByVal pDeathDay As Integer, ByVal pBirthName As String, ByVal pBirthPlace As String, ByVal pImage As ImageIdentity, ByVal pSocial As SocialMedia)
        InitialisePerson()
        _id = -1
        _forename = If(pForename, "")
        _surname = If(pSurname, "")
        _ShortDesc = If(pShortDesc, "")
        _sortSeq = 0
        _description = If(pDesc, "")
        _birthDay = pDay
        _birthMonth = pMonth
        _birthYear = If(pYear, "")
        _deathYear = pDeathYr
        _image = If(pImage, New ImageIdentity)
        _deathMonth = pDeathMonth
        _deathday = pDeathDay
        _birthName = If(pBirthName, "")
        _birthPlace = If(pBirthPlace, "")
        _social = If(pSocial, New SocialMedia)
        _unsavedChanges = False
        If String.IsNullOrEmpty(pForename) And String.IsNullOrEmpty(pSurname) Then
            MsgBox("Please supply a name", MsgBoxStyle.Exclamation, "Data error")
        End If

    End Sub
    Public Sub New(ByVal pPerson As Person, Optional isIncludeImage As Boolean = True)
        InitialisePerson()
        If pPerson IsNot Nothing Then
            _id = pPerson.Id
            _forename = pPerson.ForeName
            _surname = pPerson.Surname
            _ShortDesc = pPerson.ShortDesc
            _sortSeq = pPerson.Sortseq
            _description = pPerson.Description
            _birthDay = pPerson.BirthDay
            _birthMonth = pPerson.BirthMonth
            _birthYear = pPerson.BirthYear
            _deathYear = pPerson.DeathYear
            If isIncludeImage Then
                _image = pPerson.Image
            Else
                _image = New ImageIdentity()
            End If
            _deathMonth = pPerson.DeathMonth
            _deathday = pPerson.DeathDay
            _birthName = pPerson.BirthName
            _birthPlace = pPerson.BirthPlace
            _social = pPerson.Social
        End If
        _unsavedChanges = False
    End Sub
    Public Sub New(ByRef oRow As CelebrityBirthdayDataSet.PersonRow, ByVal oSocial As SocialMedia, ByVal oImage As ImageIdentity)
        InitialisePerson()
        If oRow IsNot Nothing Then
            _id = oRow.id
            _forename = oRow.forename
            _surname = oRow.surname
            _description = oRow.longdesc
            _ShortDesc = oRow.shortdesc
            _birthDay = oRow.birthday
            _birthMonth = oRow.birthmonth
            _birthYear = oRow.birthyear
            _deathYear = oRow.deathyear
            _deathMonth = oRow.deathmonth
            _deathday = oRow.deathday
            _birthPlace = oRow.birthplace
            _birthName = oRow.birthname
            _sortSeq = oRow.sortseq
        End If
        If oImage IsNot Nothing Then
            _image = oImage
        End If
        If oSocial IsNot Nothing Then
            _social = oSocial
        End If
        _unsavedChanges = False
    End Sub
    Public Sub New(ByRef oRow As CelebrityBirthdayDataSet.FullPersonRow, Optional isIncludeImage As Boolean = True)
        InitialisePerson()
        If oRow IsNot Nothing Then
            _id = oRow.id
            _forename = If(oRow.IsforenameNull(), "", oRow.forename)
            _surname = oRow.surname
            _description = If(oRow.IslongdescNull(), "", oRow.longdesc)
            _ShortDesc = If(oRow.IsshortdescNull(), "", oRow.shortdesc)
            _birthDay = oRow.birthday
            _birthMonth = oRow.birthmonth
            _birthYear = oRow.birthyear
            _deathYear = oRow.deathyear
            _deathMonth = If(oRow.IsdeathmonthNull(), 0, oRow.deathmonth)
            _deathday = If(oRow.IsdeathdayNull(), 0, oRow.deathday)
            _birthPlace = If(oRow.IsbirthplaceNull(), "", oRow.birthplace)
            _birthName = If(oRow.IsbirthnameNull(), "", oRow.birthname)
            Dim _imgFilename As String = If(oRow.IsimgfilenameNull(), "", oRow.imgfilename)
            Dim _imgFileType As String = If(oRow.IsimgfiletypeNull(), "", oRow.imgfiletype)
            Dim _imgLoadMonth As String = If(oRow.IsimgloadmonthNull(), "00", oRow.imgloadmonth)
            Dim _imgLoadYr As String = If(oRow.IsimgloadyrNull(), "00", oRow.imgloadyr)
            Dim _twitterHandle As String = If(oRow.IstwitterHandleNull, "", oRow.twitterHandle)
            Dim _isNoTweet As Boolean = If(oRow.IsnoTweetNull, True, oRow.noTweet)
            Dim _wikiId As String = If(oRow.IswikiIdNull, "", oRow.wikiId)
            Dim _botsd As Integer = If(oRow.IsbotsdNull, -1, oRow.botsd)
            Dim _isTwin As Boolean = If(oRow.IsisTwinNull, False, oRow.isTwin)
            If isIncludeImage Then
                _image = New ImageIdentity(oRow.id, _imgFilename, _imgFileType, _imgLoadMonth, _imgLoadYr)
            Else
                _image = New ImageIdentity()
            End If
            _sortSeq = oRow.sortseq
            _social = New SocialMedia(oRow.id, _twitterHandle, _isNoTweet, _wikiId, _botsd, _isTwin)
        End If
        _unsavedChanges = False
    End Sub
    Public Sub New(ByRef oRow As CelebrityBirthdayDataSet.PersonRow)
        InitialisePerson()
        If oRow IsNot Nothing Then
            _id = oRow.id
            _forename = oRow.forename
            _surname = oRow.surname
            _description = oRow.longdesc
            _ShortDesc = oRow.shortdesc
            _birthDay = oRow.birthday
            _birthMonth = oRow.birthmonth
            _birthYear = oRow.birthyear
            _deathYear = oRow.deathyear
            _deathMonth = oRow.deathmonth
            _deathday = oRow.deathday
            _birthPlace = oRow.birthplace
            _birthName = oRow.birthname
            _sortSeq = oRow.sortseq
        End If
        _unsavedChanges = False
    End Sub
#End Region
#Region "dispose"
    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposing Then
            _image.Dispose()
        End If
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class

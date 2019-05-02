Public Class Person

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
    Public Sub New()
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

    Public Sub New(ByVal pForename As String, ByVal pSurname As String, ByVal pDesc As String, ByVal pShortDesc As String, ByVal pDay As Integer, ByVal pMonth As Integer, ByVal pYear As String, ByVal pDeathYr As Integer, ByVal pDeathMonth As Integer, ByVal pDeathDay As Integer, ByVal pBirthName As String, ByVal pBirthPlace As String, ByVal pImage As ImageIdentity, ByVal pSocial As SocialMedia)
        _id = -1
        _forename = pForename
        _surname = pSurname
        _ShortDesc = pShortDesc
        _sortSeq = 0
        _surname = pSurname
        _description = pDesc
        _birthDay = pDay
        _birthMonth = pMonth
        _birthYear = pYear
        _deathYear = pDeathYr
        _image = pImage
        _deathMonth = pDeathMonth
        _deathday = pDeathDay
        _birthName = pBirthName
        _birthPlace = pBirthPlace
        _social = pSocial
        _unsavedChanges = False

        If pForename = "" And pSurname = "" Then
            MsgBox("Please supply a name", MsgBoxStyle.Exclamation, "Data error")
        End If

    End Sub
    Public Sub New(ByVal pPerson As Person)
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
        _image = pPerson.Image
        _deathMonth = pPerson.DeathMonth
        _deathday = pPerson.DeathDay
        _birthName = pPerson.BirthName
        _birthPlace = pPerson.BirthPlace
        _social = pPerson.Social
        _unsavedChanges = False
    End Sub
    Public Sub New(ByRef oRow As CelebrityBirthdayDataSet.PersonRow, ByVal oSocial As SocialMedia, ByVal oImage As ImageIdentity)
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
        _image = oImage
        _sortSeq = oRow.sortseq
        _social = oSocial
        _unsavedChanges = False
    End Sub
    Public Sub New(ByRef oRow As CelebrityBirthdayDataSet.FullPersonRow)
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
        _image = New ImageIdentity(oRow.id, oRow.imgfilename, oRow.imgfiletype, oRow.imgloadmonth, oRow.imgloadyr)
        _sortSeq = oRow.sortseq
        _social = New SocialMedia(oRow.id, oRow.twitterHandle, oRow.noTweet)
        _unsavedChanges = False
    End Sub
    Public ReadOnly Property IBirthYear() As Integer
        Get
            Dim iYr As Integer = 0
            Dim isBC As Boolean = _birthYear.ToLower.IndexOf("bc") >= 0
            Try
                iYr = Integer.Parse(_birthYear.ToLower.Replace("bc", "").Trim)
                If isBC Then
                    iYr *= -1
                End If
            Catch ex As Exception
            End Try

            Return iYr
        End Get
    End Property
    Public ReadOnly Property Name() As String
        Get
            Return If(String.IsNullOrEmpty(_forename), _surname, _forename & " " & _surname)
        End Get
    End Property
End Class

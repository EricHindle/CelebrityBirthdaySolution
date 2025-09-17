' Hindleware
' Copyright (c) 2019-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class PersonBuilder
    Private _id As Integer
    Private _forename As String
    Private _surname As String
    Private _birthYear As String
    Private _deathYear As Integer
    Private _description As String
    Private _birthMonth As Integer
    Private _birthDay As Integer
    Private _shortDesc As String
    Private _birthPlace As String
    Private _birthName As String
    Private _deathday As Integer
    Private _deathMonth As Integer
    Private _image As ImageIdentity
    Private _social As SocialMedia

    Public Shared Function APerson() As PersonBuilder
        Return New PersonBuilder
    End Function
    Public Function StartingWithNothing() As PersonBuilder
        _id = -1
        _forename = ""
        _surname = ""
        _description = ""
        _shortDesc = ""
        _birthName = ""
        _image = Nothing
        _birthYear = ""
        _deathYear = 0
        _birthMonth = 0
        _birthDay = 0
        _birthPlace = ""
        _deathday = 0
        _deathMonth = 0
        _social = Nothing
        Return Me
    End Function
    Public Function StartingWith(ByRef pPerson As Person) As PersonBuilder
        StartingWithNothing()
        If pPerson IsNot Nothing Then
            _id = pPerson.Id
            _forename = pPerson.ForeName
            _surname = pPerson.Surname
            _description = pPerson.Description
            _shortDesc = pPerson.ShortDesc
            _birthName = pPerson.BirthName
            _image = pPerson.Image
            _birthYear = pPerson.BirthYear
            _deathYear = pPerson.DeathYear
            _birthMonth = pPerson.BirthMonth
            _birthDay = pPerson.BirthDay
            _birthPlace = pPerson.BirthPlace
            _deathday = pPerson.DeathDay
            _deathMonth = pPerson.DeathMonth
            _social = pPerson.Social
        End If
        Return Me
    End Function
    Public Function StartingWith(ByRef oRow As CelebrityBirthdayDataSet.PersonRow) As PersonBuilder
        StartingWithNothing()
        If oRow IsNot Nothing Then
            _id = oRow.id
            _forename = oRow.forename
            _surname = oRow.surname
            _description = If(oRow.IslongdescNull, "", oRow.longdesc)
            _shortDesc = If(oRow.IsshortdescNull, "", oRow.shortdesc)
            _birthPlace = If(oRow.IsbirthplaceNull, "", oRow.birthplace)
            _birthName = If(oRow.IsbirthnameNull, "", oRow.birthname)
            _birthYear = oRow.birthyear
            _deathYear = oRow.deathyear
            _birthMonth = oRow.birthmonth
            _birthDay = oRow.birthday
            _deathday = If(oRow.IsdeathdayNull, 0, oRow.deathday)
            _deathMonth = If(oRow.IsdeathmonthNull, 0, oRow.deathmonth)
            _social = Nothing
            _image = Nothing
        End If
        Return Me
    End Function
    Public Function WithId(pId As Integer) As PersonBuilder
        _id = pId
        Return Me
    End Function
    Public Function WithForename(pForename As String) As PersonBuilder
        _forename = pForename
        Return Me
    End Function
    Public Function WithSurname(pSurname As String) As PersonBuilder
        _surname = pSurname
        Return Me
    End Function
    Public Function WithDescription(pDescription As String) As PersonBuilder
        _description = pDescription
        Return Me
    End Function
    Public Function WithShortdDesc(pDescription As String) As PersonBuilder
        _shortDesc = pDescription
        Return Me
    End Function
    Public Function WithDateOfBirth(pDay As Integer, pMonth As Integer, pYear As Integer) As PersonBuilder
        _birthDay = pDay
        _birthMonth = pMonth
        _birthYear = pYear
        Return Me
    End Function
    Public Function WithDateOfDeath(pDay As Integer, pMonth As Integer, pYear As Integer) As PersonBuilder
        _deathday = pDay
        _deathMonth = pMonth
        _deathYear = pYear
        Return Me
    End Function
    Public Function WithPlaceOfBirth(pPlaceOfBirth As String) As PersonBuilder
        _birthPlace = pPlaceOfBirth
        Return Me
    End Function
    Public Function WithBirthName(pBirthName As String) As PersonBuilder
        _birthName = pBirthName
        Return Me
    End Function
    Public Function WithImage(pImage As ImageIdentity) As PersonBuilder
        _image = pImage
        Return Me
    End Function
    Public Function WithSocial(pSocial As SocialMedia) As PersonBuilder
        _social = pSocial
        Return Me
    End Function
    Public Function Build() As Person
        Return New Person(_id,
                          _forename,
                            _surname,
                            _description,
                            _shortDesc,
                            _birthDay,
                            _birthMonth,
                            _birthYear,
                            _deathYear,
                            _deathMonth,
                            _deathday,
                            _birthName,
                            _birthPlace,
                            _image,
                            _social)
    End Function
End Class

Module modDatabase
#Region "data"
    Private ReadOnly oTwta As New CelebrityBirthdayDataSetTableAdapters.SocialMediaTableAdapter
    Private ReadOnly oTwtable As New CelebrityBirthdayDataSet.SocialMediaDataTable
    Private ReadOnly oPersonTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
    Private ReadOnly oPersonTable As New CelebrityBirthdayDataSet.PersonDataTable
    Private ReadOnly oDatesTa As New CelebrityBirthdayDataSetTableAdapters.DatesTableAdapter
    Private ReadOnly oDatesTable As New CelebrityBirthdayDataSet.DatesDataTable
    Private ReadOnly oImgTa As New CelebrityBirthdayDataSetTableAdapters.ImageTableAdapter
    Private ReadOnly oImgTable As New CelebrityBirthdayDataSet.ImageDataTable
    Private ReadOnly oFullPersonTa As New CelebrityBirthdayDataSetTableAdapters.FullPersonTableAdapter
    Private ReadOnly oFullPersonTable As New CelebrityBirthdayDataSet.FullPersonDataTable
#End Region
#Region "person"
    Public Function DeletePerson(ByVal _id As Integer)
        Return oPersonTa.DeletePerson(_id)
    End Function
    Public Function DeleteTwitterHandle(ByVal _id As Integer) As Integer
        Return oTwta.DeleteTwitter(_id)
    End Function
    Public Function GetPersonById(ByVal _id As Integer) As Person
        Dim iCt As Integer = oPersonTa.FillById(oPersonTable, _id)
        Dim newPerson As Person = Nothing
        If iCt = 1 Then
            Dim oRow As CelebrityBirthdayDataSet.PersonRow = oPersonTable.Rows(0)
            newPerson = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
        End If
        Return newPerson
    End Function
    Public Function GetFullPersonById(ByVal _id As Integer) As Person
        Dim iCt As Integer = oFullPersonTa.FillById(oFullPersonTable, _id)
        Dim newPerson As Person = Nothing
        If iCt = 1 Then
            Dim oRow As CelebrityBirthdayDataSet.FullPersonRow = oFullPersonTable.Rows(0)
            newPerson = New Person(oRow)
        End If
        Return newPerson
    End Function
    Public Function InsertPerson(ByVal oPerson As Person) As Integer
        Dim sortSeq As Integer = 0
        Dim newId As Integer = oPersonTa.InsertPerson(oPerson.ForeName,
                                                oPerson.Surname,
                                                CInt(oPerson.BirthYear),
                                                oPerson.BirthMonth,
                                                oPerson.BirthDay,
                                                oPerson.DeathYear,
                                                oPerson.ShortDesc,
                                                oPerson.Description,
                                                sortSeq,
                                                Today.Date,
                                                oPerson.BirthPlace,
                                                oPerson.BirthName,
                                                oPerson.DeathMonth,
                                                oPerson.DeathDay)
        oPerson.Id = newId
        UpdateSocialMedia(oPerson)
        Return newId
    End Function
    Public Function UpdatePerson(ByVal oPerson As Person) As Integer
        Dim iCt As Integer = oPersonTa.UpdatePerson(oPerson.ForeName,
                                              oPerson.Surname,
                                              CInt(oPerson.BirthYear),
                                              oPerson.BirthMonth,
                                              oPerson.BirthDay,
                                              oPerson.DeathYear,
                                              oPerson.ShortDesc,
                                              oPerson.Description,
                                              oPerson.Sortseq,
                                              oPerson.BirthPlace,
                                              oPerson.BirthName,
                                              oPerson.DeathMonth,
                                              oPerson.DeathDay,
                                              oPerson.Id)
        UpdateSocialMedia(oPerson)
        Return iCt
    End Function
    Public Function GetPeopleByDate(oDay As Integer, oMonth As Integer) As ArrayList
        Dim oPersonTable As New ArrayList
        oPersonTa.FillByMonthDay(modDatabase.oPersonTable, oMonth, oDay)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In modDatabase.oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonTable.Add(oPerson)
        Next
        Return oPersonTable
    End Function
    Public Function FindPeopleByDate(oDay As Integer, oMonth As Integer) As List(Of Person)
        Dim oPersonTable As New List(Of Person)
        oPersonTa.FillByMonthDay(modDatabase.oPersonTable, oMonth, oDay)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In modDatabase.oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonTable.Add(oPerson)
        Next
        Return oPersonTable
    End Function
    Public Function GetPeopleByName(oForename As String, oSurname As String) As ArrayList
        Dim oPersonTable As New ArrayList
        oPersonTa.FillByName(modDatabase.oPersonTable, oForename, oSurname)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In modDatabase.oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonTable.Add(oPerson)
        Next
        Return oPersonTable
    End Function
    Public Function GetPeopleLikeName(oForename As String, oSurname As String) As ArrayList
        Dim oPersonTable As New ArrayList
        oPersonTa.FillByPersonLikeName(modDatabase.oPersonTable, oForename, oSurname)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In modDatabase.oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonTable.Add(oPerson)
        Next
        Return oPersonTable
    End Function
    Public Function FindPeopleLikeName(oForename As String, oSurname As String) As List(Of Person)
        Dim oPersonTable As New List(Of Person)
        oPersonTa.FillByPersonLikeName(modDatabase.oPersonTable, oForename, oSurname)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In modDatabase.oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonTable.Add(oPerson)
        Next
        Return oPersonTable
    End Function
    Public Function FindBirthdays(oDay As Integer, oMonth As Integer)
        oFullPersonTa.FillByBirthday(oFullPersonTable, oMonth, oDay)
        Dim _List As New List(Of Person)
        For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
            _List.Add(New Person(oRow))
        Next
        Return _List
    End Function
    Public Function FindAnniversaries(oDay As Integer, oMonth As Integer)
        oFullPersonTa.FillByAnniversary(oFullPersonTable, oDay, oMonth)
        Dim _List As New List(Of Person)
        For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
            _List.Add(New Person(oRow))
        Next
        Return _List
    End Function
#End Region
#Region "image"
    Public Function GetImageById(ByVal _id As Integer) As ImageIdentity
        Dim ict As Integer = oImgTa.FillById(oImgTable, _id)
        Dim oIRow As CelebrityBirthdayDataSet.ImageRow = Nothing
        Dim oImage As ImageIdentity = New ImageIdentity()
        If ict = 1 Then
            oImage = New ImageIdentity(oImgTable.Rows(0))
        End If
        Return oImage
    End Function
    Public Function IsExistsImage(ByVal _id As Integer) As Boolean
        Return GetImageById(_id).Id > -1
    End Function
    Public Function GetAlternateImageDate(ByVal Id As Integer) As Date?
        Dim loadDate As Date? = Nothing
        Dim oImage As ImageIdentity = GetImageById(Id)
        Dim sYear As Integer
        Dim sMonth As Integer
        If oImage IsNot Nothing Then
            If oImage.ImageLoadYear IsNot Nothing AndAlso IsNumeric(oImage.ImageLoadYear) Then
                sYear = CInt(oImage.ImageLoadYear)
            End If
            If oImage.ImageLoadMonth IsNot Nothing AndAlso IsNumeric(oImage.ImageLoadMonth) Then
                sMonth = CInt(oImage.ImageLoadMonth)
            End If
            If sYear > 0 And sMonth > 0 Then
                loadDate = New Date(sYear, sMonth, 1)
            End If
        End If
        Return loadDate
    End Function
    Public Function InsertImage(oId As Integer, imgFileName As String, imgFileType As String, loadMonth As String, loadYear As String) As Integer
        Return oImgTa.InsertImage(oId, imgFileName, imgFileType, loadYear, loadMonth)
    End Function
    Public Function UpdateImage(oId As Integer, imgFileName As String, imgFileType As String, loadMonth As String, loadYear As String) As Integer
        Return oImgTa.UpdateImage(imgFileName, imgFileType, loadYear, loadMonth, oId)
    End Function

#End Region
#Region "social media"
    Public Function GetSocialMedia(ByVal _id As Integer) As SocialMedia
        Dim oTwRow As CelebrityBirthdayDataSet.SocialMediaRow = Nothing
        Dim tCt As Integer = oTwta.FillById(oTwtable, _id)
        Dim oSocial As SocialMedia = New SocialMedia
        If tCt = 1 Then
            oSocial = New SocialMedia(oTwtable.Rows(0))
        End If
        Return oSocial
    End Function
    Public Sub UpdateSocialMedia(ByRef _person As Person)
        DeleteTwitterHandle(_person.Id)
        If _person.Social IsNot Nothing Then
            oTwta.InsertTwitter(_person.Id, _person.Social.TwitterHandle, _person.Social.IsNoTweet)
        End If
    End Sub
#End Region
#Region "dates"
    Public Sub UpdateDate(LoadYr As String, LoadMth As String, isDateAmend As Boolean, LoadDay As String, DayIndex As Decimal?, MonthIndex As Decimal?)
        oDatesTa.UpdateDate(LoadYr, LoadMth, isDateAmend, LoadDay, DayIndex, MonthIndex)
    End Sub
    Public Function GetWordPressLoadDate(oDay As Integer, oMonth As Integer) As Date?
        Dim loadDate As Date?
        Dim iCt As Integer = oDatesTa.FillByDate(oDatesTable, oDay, oMonth)
        Dim oDateRow As CelebrityBirthdayDataSet.DatesRow = Nothing
        If iCt = 1 Then
            oDateRow = oDatesTable.Rows(0)
            loadDate = New Date(CInt(oDateRow.uploadyear), CInt(oDateRow.uploadmonth), CInt(oDateRow.uploadday))
        End If
        Return loadDate
    End Function
#End Region
End Module

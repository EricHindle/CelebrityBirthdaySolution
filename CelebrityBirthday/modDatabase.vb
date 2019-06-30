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
    Private ReadOnly oTwitterAuthTa As New CelebrityBirthdayDataSetTableAdapters.TwitterAuthTableAdapter
    Private ReadOnly oTwitterAuthTable As New CelebrityBirthdayDataSet.TwitterAuthDataTable
    Private ReadOnly oTweetTa As New CelebrityBirthdayDataSetTableAdapters.TweetsTableAdapter

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

    Public Function GetPeopleByName(oForename As String, oSurname As String) As ArrayList
        Dim oPersonList As New ArrayList
        oPersonTa.FillByName(oPersonTable, oForename, oSurname)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonList.Add(oPerson)
        Next
        Return oPersonList
    End Function
    Public Function GetPeopleLikeName(oForename As String, oSurname As String) As ArrayList
        Dim oPersonList As New ArrayList
        oPersonTa.FillByPersonLikeName(oPersonTable, oForename, oSurname)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonList.Add(oPerson)
        Next
        Return oPersonList
    End Function
    Public Function FindPeopleLikeName(oForename As String, oSurname As String) As List(Of Person)
        Dim oPersonList As New List(Of Person)
        oPersonTa.FillByPersonLikeName(oPersonTable, oForename, oSurname)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            oPersonList.Add(oPerson)
        Next
        Return oPersonList
    End Function
    Public Function FindPeopleByDate(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean) As List(Of Person)
        Dim oPersonList As New List(Of Person)
        oPersonTa.FillByMonthDay(oPersonTable, oMonth, oDay)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
            Dim oPerson As Person = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            If Not isTweetsOnly Or Not oPerson.Social.IsNoTweet Then
                oPersonList.Add(oPerson)
            Else
                Debug.Print("Excluding " & oPerson.Name)
            End If
        Next
        Return oPersonList
    End Function
    Public Function FindLivingPeople() As List(Of Person)
        oFullPersonTa.Fill(oFullPersonTable)
        Dim _List As New List(Of Person)
        For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
            If oRow.deathyear = 0 Then
                _List.Add(New Person(oRow))
            End If
        Next
        Return _List
    End Function
    Public Function FindBirthdays(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean)
        oFullPersonTa.FillByBirthday(oFullPersonTable, oMonth, oDay)
        Dim _List As New List(Of Person)
        For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
            Dim oPerson As Person = New Person(oRow)
            If Not isTweetsOnly Or Not oPerson.Social.IsNoTweet Then
                _List.Add(oPerson)
            Else
                Debug.Print("Excluding " & oPerson.Name)
            End If
        Next
        Return _List
    End Function
    Public Function FindAnniversaries(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean)
        oFullPersonTa.FillByAnniversary(oFullPersonTable, oDay, oMonth)
        Dim _List As New List(Of Person)
        For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
            Dim oPerson As Person = New Person(oRow)
            If Not isTweetsOnly Or Not oPerson.Social.IsNoTweet Then
                _List.Add(oPerson)
            Else
                Debug.Print("Excluding " & oPerson.Name)
            End If
        Next
        Return _List
    End Function
#End Region
#Region "image"
    Public Function GetImageById(ByVal _id As Integer) As ImageIdentity
        Dim ict As Integer = oImgTa.FillById(oImgTable, _id)
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
    Public Function DeleteImage(oId As Integer) As Integer
        Return oImgTa.DeleteImage(oId)
    End Function
#End Region
#Region "social media"
    Public Function GetSocialMedia(ByVal _id As Integer) As SocialMedia
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
        Dim oDateRow As CelebrityBirthdayDataSet.DatesRow
        If iCt = 1 Then
            oDateRow = oDatesTable.Rows(0)
            loadDate = New Date(CInt(oDateRow.uploadyear), CInt(oDateRow.uploadmonth), CInt(oDateRow.uploadday))
        End If
        Return loadDate
    End Function
    Public Function GetDatesRow(oDay As Integer, oMonth As Integer) As CelebrityBirthday.CelebrityBirthdayDataSet.DatesRow
        Dim iCt As Integer = oDatesTa.FillByDate(oDatesTable, oDay, oMonth)
        Dim oDrow As CelebrityBirthdayDataSet.DatesRow = Nothing
        If iCt = 1 Then
            oDrow = oDatesTable.Rows(0)
        End If
        Return oDrow
    End Function
    Public Function GetAuthById(pId As String) As TwitterOAuth
        Dim oTwAuth As TwitterOAuth = Nothing
        If oTwitterAuthTa.FillById(oTwitterAuthTable, pId) = 1 Then
            Dim oRow As CelebrityBirthdayDataSet.TwitterAuthRow = oTwitterAuthTable.Rows(0)
            oTwAuth = New TwitterOAuth
            oTwAuth.Token = If(oRow.IsTokenNull, "", oRow.Token)
            oTwAuth.TokenSecret = If(oRow.IsSecretNull, "", oRow.Secret)
            oTwAuth.Verifier = If(oRow.IsVerifierNull, "", oRow.Verifier)
        End If
        Return oTwAuth
    End Function
    Public Function UpdateAuth(pId, pToken, pSecret, pVerifier) As Boolean
        Dim isOK As Boolean
        If GetAuthById(pId) Is Nothing Then
            isOK = oTwitterAuthTa.InsertAuth(pId, pVerifier, pToken, pSecret) = 1
        Else
            isOK = oTwitterAuthTa.UpdateAuth(pVerifier, pToken, pSecret, pId) = 1
        End If
        Return isOK
    End Function
    Public Function GetTwitterUsers() As List(Of String)
        Dim _list As New List(Of String)
        oTwitterAuthTa.Fill(oTwitterAuthTable)
        For Each oRow As CelebrityBirthdayDataSet.TwitterAuthRow In oTwitterAuthTable.Rows
            _list.Add(oRow.Id)
        Next
        Return _list
    End Function
    Public Function InsertTweet(pText As String, pMonth As Integer?, pDay As Integer?, pSeq As Integer?, pId As String, pAccount As String, pType As String) As Boolean
        oTweetTa.InsertTweet(Now, pText, pMonth, pDay, pSeq, pId, pAccount, pType)
    End Function
#End Region
End Module

Imports System.Data.Common
Imports System.Reflection

Module modDatabase
#Region "constants"
    Private Const MODULE_NAME As String = "modDatabase"
    Private Const MODULE_TYPE As String = "Database"
#End Region
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
    Private ReadOnly oBotsdTa As New CelebrityBirthdayDataSetTableAdapters.BotSDTableAdapter
    Private ReadOnly oBotsdTable As New CelebrityBirthdayDataSet.BotSDDataTable
    Private ReadOnly oBotsdViewTa As New CelebrityBirthdayDataSetTableAdapters.BornOnTheSameDayTableAdapter
    Private ReadOnly oBotsdViewTable As New CelebrityBirthdayDataSet.BornOnTheSameDayDataTable
    Private ReadOnly oAuditTa As New CelebrityBirthdayDataSetTableAdapters.AuditTableAdapter
    Private ReadOnly oSettingsTa As New CelebrityBirthdayDataSetTableAdapters.SettingsTableAdapter
    Private ReadOnly oSocialMediaTa As New CelebrityBirthdayDataSetTableAdapters.SocialMediaTableAdapter
#End Region
#Region "backup"
    Public Function GetPersonTable() As CelebrityBirthdayDataSet.PersonDataTable
        Return oPersonTa.GetData()
    End Function
    Public Function GetAuditTable() As CelebrityBirthdayDataSet.AuditDataTable
        Return oAuditTa.GetData
    End Function
    Public Function GetBotSDTable() As CelebrityBirthdayDataSet.BotSDDataTable
        Return oBotsdTa.GetData
    End Function
    Public Function GetDatesTable() As CelebrityBirthdayDataSet.DatesDataTable
        Dim ds As New CelebrityBirthdayDataSet
        Dim dt As New CelebrityBirthdayDataSet.DatesDataTable
        ds.Tables.Add(dt)
        ds.EnforceConstraints = False
        Dim da As New CelebrityBirthdayDataSetTableAdapters.DatesTableAdapter
        da.Fill(dt)
        Return dt
    End Function
    Public Function GetImageTable() As CelebrityBirthdayDataSet.ImageDataTable
        Return oImgTa.GetData
    End Function
    Public Function GetSettingsTable() As CelebrityBirthdayDataSet.SettingsDataTable
        Return oSettingsTa.GetData
    End Function
    Public Function GetSocialMediaTable() As CelebrityBirthdayDataSet.SocialMediaDataTable
        Return oSocialMediaTa.GetData
    End Function
    Public Function GetTweetsTable() As CelebrityBirthdayDataSet.TweetsDataTable
        Return oTweetTa.GetData
    End Function
    Public Function GetTwitterAuthTable() As CelebrityBirthdayDataSet.TwitterAuthDataTable
        Return oTwitterAuthTa.GetData
    End Function
#End Region
#Region "person"

    Public Function DeletePerson(ByVal _id As Integer)
        LogUtil.Info("Deleting person " & CStr(_id), MODULE_NAME)
        Return oPersonTa.DeletePerson(_id)
    End Function
    Public Function DeleteSocialMedia(ByVal _id As Integer) As Integer
        LogUtil.Info("Deleting social media for " & CStr(_id), MODULE_NAME)
        Return oTwta.DeleteTwitter(_id)
    End Function
    Public Function CountPeople() As Integer
        Dim iCt As Integer
        Try
            iCt = oPersonTa.CountPeople
        Catch ex As DbException
            If StartSqlService() Then
                Try
                    iCt = oPersonTa.CountPeople
                Catch ex1 As DbException
                    DisplayException(MethodBase.GetCurrentMethod, ex1, MODULE_TYPE)
                    iCt = -1
                End Try
            Else
                iCt = -1
            End If
        End Try
        Return iCt
    End Function
    Private Function StartSqlService() As Boolean
        Dim isOK As Boolean = True
        If My.Settings.isSqlServer Then
            LogUtil.Info("Starting SQL Server", MODULE_NAME)
            Try
                Dim procStartInfo As New ProcessStartInfo
                With procStartInfo
                    .UseShellExecute = True
                    .FileName = "net.exe"
                    .Arguments = " start ""SQL Server (SQLEXPRESS)"""
                    .WindowStyle = ProcessWindowStyle.Normal
                    .Verb = "runas"
                End With
                Dim thisProcess As Process = Process.Start(procStartInfo)
                thisProcess.WaitForExit(120000)
            Catch ex As System.ComponentModel.Win32Exception
                DisplayException(MethodBase.GetCurrentMethod, ex, "Win32")
                isOK = False
            End Try
        Else
            LogUtil.Info("SQL Server not available", MODULE_NAME)
            isOK = False
        End If
        Return isOK
    End Function
    Public Function GetPersonById(ByVal _id As Integer) As Person
        Dim newPerson As Person = Nothing
        Try
            Dim iCt As Integer = oPersonTa.FillById(oPersonTable, _id)

            If iCt = 1 Then
                Dim oRow As CelebrityBirthdayDataSet.PersonRow = oPersonTable.Rows(0)
                newPerson = New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return newPerson
    End Function
    Public Function GetFullPersonById(ByVal _id As Integer, Optional isIncludeImage As Boolean = True) As Person
        Dim newPerson As Person = Nothing
        Try
            Dim iCt As Integer = oFullPersonTa.FillById(oFullPersonTable, _id)
            If iCt = 1 Then
                Dim oRow As CelebrityBirthdayDataSet.FullPersonRow = oFullPersonTable.Rows(0)
                newPerson = New Person(oRow, isIncludeImage)
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return newPerson
    End Function
    Public Function GetPeopleByDeathYear(ByVal _year As Integer) As CelebrityBirthdayDataSet.PersonDataTable
        oPersonTa.FillByDeathYear(oPersonTable, _year)
        Return oPersonTable
    End Function
    Public Function GetPeopleByDateofBirth(ByVal _year As Integer, ByVal _month As Integer, ByVal _day As Integer) As CelebrityBirthdayDataSet.PersonDataTable
        oPersonTa.FillByDob(oPersonTable, _year, _month, _day)
        Return oPersonTable
    End Function
    Public Function InsertPerson(ByRef oPerson As Person) As Integer
        Dim sortSeq As Integer = 0
        Dim newId As Integer = -1
        Try
            LogUtil.Info("Inserting " & oPerson.Name, MODULE_NAME)
            newId = oPersonTa.InsertPerson(oPerson.ForeName,
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
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return newId
    End Function
    Public Function UpdatePerson(ByVal oPerson As Person) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating " & oPerson.Name, MODULE_NAME)
            iCt = oPersonTa.UpdatePerson(oPerson.ForeName,
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
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function UpdateShortDesc(ByVal oPerson As Person) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating short description for " & oPerson.Name, MODULE_NAME)
            iCt = oPersonTa.UpdateShortDesc(oPerson.ShortDesc, oPerson.Id)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function UpdateSortSeq(ByVal personId As Integer, ByVal newSortSeq As Integer) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating sort sequence for " & CStr(personId), MODULE_NAME)
            iCt = oPersonTa.UpdateSortSeq(newSortSeq, personId)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function UpdateDateOfBirth(ByVal oPersonId As Integer, oDay As Integer, oMonth As Integer, oYear As Integer, oDesc As String) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating date of birth for " & CStr(oPersonId), MODULE_NAME)
            iCt = oPersonTa.UpdateDoB(oYear, oMonth, oDay, oDesc, oPersonId)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function GetPeopleByDate(oDay As Integer, oMonth As Integer, Optional isGetPhoto As Boolean = True) As ArrayList
        Dim oPersonTable As New ArrayList
        Try
            oPersonTa.FillByMonthDay(modDatabase.oPersonTable, oMonth, oDay)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In modDatabase.oPersonTable.Rows
                Dim oPerson As New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id, isGetPhoto))
                oPersonTable.Add(oPerson)
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return oPersonTable
    End Function
    Public Function GetPeopleByName(oForename As String, oSurname As String) As ArrayList
        Dim oPersonList As New ArrayList
        Try
            oPersonTa.FillByName(oPersonTable, oForename, oSurname)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
                Dim oPerson As New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
                oPersonList.Add(oPerson)
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return oPersonList
    End Function
    Public Function GetPeopleLikeName(oForename As String, oSurname As String) As ArrayList
        Dim oPersonList As New ArrayList
        Try
            oPersonTa.FillByPersonLikeName(oPersonTable, oForename, oSurname)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
                Dim oPerson As New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
                oPersonList.Add(oPerson)
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return oPersonList
    End Function
    Public Function FindPeopleLikeName(oForename As String, oSurname As String) As List(Of Person)
        Dim oPersonList As New List(Of Person)
        Try
            oPersonTa.FillByPersonLikeName(oPersonTable, oForename, oSurname)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
                Dim oPerson As New Person(oRow, GetSocialMedia(oRow.id), GetImageById(oRow.id))
                oPersonList.Add(oPerson)
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return oPersonList
    End Function
    Public Function FindPeopleByDate(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean, Optional isGetPhoto As Boolean = True) As List(Of Person)
        Dim oPersonList As New List(Of Person)
        Try
            oPersonTa.FillByMonthDay(oPersonTable, oMonth, oDay)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
                Dim _socialMedia As SocialMedia = GetSocialMedia(oRow.id)
                If Not isTweetsOnly Or Not _socialMedia.IsNoTweet Then
                    oPersonList.Add(New Person(oRow, _socialMedia, GetImageById(oRow.id, isGetPhoto)))
                End If
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try

        Return oPersonList
    End Function
    Public Function FindLivingPeople(Optional isIncludeImage As Boolean = True) As List(Of Person)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.Fill(oFullPersonTable)

            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If oRow.deathyear = 0 Then
                    _List.Add(New Person(oRow, isIncludeImage))
                End If
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return _List
    End Function
    Public Function FindEverybody() As List(Of Person)
        Dim _List As New List(Of Person)
        Try
            oPersonTa.Fill(oPersonTable)
            For Each oRow As CelebrityBirthdayDataSet.PersonRow In oPersonTable.Rows
                Dim newPerson As New Person(oRow) With {
                    .Social = GetSocialMedia(oRow.id)
                }
                _List.Add(newPerson)
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return _List
    End Function
    Public Function FindTodays(oDay As Integer, oMonth As Integer, isIgnoreNoTweet As Boolean, isIgnoreTwins As Boolean)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByDayAndMonth(oFullPersonTable, oDay, oMonth)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If isIgnoreNoTweet And oRow.noTweet Then
                    Continue For
                Else
                    If isIgnoreTwins And oRow.isTwin Then
                        Continue For
                    Else
                        _List.Add(New Person(oRow))
                    End If
                End If
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return _List
    End Function
    Public Function FindBirthdays(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByBirthday(oFullPersonTable, oMonth, oDay)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If Not isTweetsOnly Or Not oRow.noTweet Then
                    _List.Add(New Person(oRow))
                End If
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return _List
    End Function
    Public Function FindAnniversaries(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByAnniversary(oFullPersonTable, oDay, oMonth)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If Not isTweetsOnly Or Not oRow.noTweet Then
                    _List.Add(New Person(oRow))
                End If
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return _List
    End Function
#End Region
#Region "image"
    Public Function GetImageById(ByVal _id As Integer, Optional isGetPhoto As Boolean = True) As ImageIdentity
        Try
            Dim ict As Integer = oImgTa.FillById(oImgTable, _id)
            If ict = 1 Then
                Return New ImageIdentity(oImgTable.Rows(0), isGetPhoto)
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return New ImageIdentity
    End Function
    Public Function IsExistsImage(ByVal _id As Integer) As Boolean
        Dim oImage As ImageIdentity = GetImageById(_id)
        Dim isExists As Boolean = oImage.Id > -1
        oImage.Dispose()
        Return isExists
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
        oImage.Dispose()
        Return loadDate
    End Function
    Public Function InsertImage(oId As Integer, imgFileName As String, imgFileType As String, loadMonth As String, loadYear As String) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Inserting image for " & CStr(oId), MODULE_NAME)
            iCt = oImgTa.InsertImage(oId, imgFileName, imgFileType, loadYear, loadMonth)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function UpdateImage(oId As Integer, imgFileName As String, imgFileType As String, loadMonth As String, loadYear As String) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating image for " & CStr(oId), MODULE_NAME)
            iCt = oImgTa.UpdateImage(imgFileName, imgFileType, loadYear, loadMonth, oId)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function DeleteImage(oId As Integer) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Deleting image for " & CStr(oId), MODULE_NAME)
            iCt = oImgTa.DeleteImage(oId)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
#End Region
#Region "social media"
    Public Function GetSocialMedia(ByVal _id As Integer) As SocialMedia
        Dim tCt As Integer = oTwta.FillById(oTwtable, _id)
        Dim oSocial As New SocialMedia
        If tCt = 1 Then
            oSocial = New SocialMedia(oTwtable.Rows(0))
        End If
        Return oSocial
    End Function
    Public Sub InsertSocialMedia(_id As Integer, _twitterHandle As String, _isNoTweet As Boolean, _wikiId As String, _botsd As Integer, _isTwin As Boolean)
        LogUtil.Info("Inserting social media for " & CStr(_id), MODULE_NAME)
        oTwta.InsertTwitter(_id, _twitterHandle, _isNoTweet, _wikiId, _botsd, _isTwin)
    End Sub
    Public Sub UpdateSocialMedia(ByRef _person As Person)
        DeleteSocialMedia(_person.Id)
        Dim _social As SocialMedia = _person.Social
        If _social IsNot Nothing Then
            InsertSocialMedia(_person.Id, _social.TwitterHandle, _social.IsNoTweet, _social.WikiId, _social.Botsd, _social.IsTwin)
        End If
    End Sub
    Public Sub UpdateWikiId(pPersonId As Integer, pWikiId As String)
        LogUtil.Info("Updating wiki id " & pWikiId, MODULE_NAME)
        Dim updCt As Integer = oTwta.UpdateWikiId(pWikiId, pPersonId)
    End Sub
    Public Function UpdateBotsdId(ByVal oSocial As SocialMedia) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating BotSD id on social media for " & CStr(oSocial.Id), MODULE_NAME)
            iCt = oTwta.UpdateBotsd(oSocial.Botsd, oSocial.Id)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function UpdateBotsdId(ByVal _personId As Integer, ByVal _btsdId As Integer) As Integer
        Dim iCt As Integer = -1
        Try
            LogUtil.Info("Updating BotSD id on social media for " & CStr(_personId), MODULE_NAME)
            iCt = oTwta.UpdateBotsd(_btsdId, _personId)
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
#End Region
#Region "dates"
    Public Function UpdateImageDate(LoadYr As String, LoadMth As String, isDateAmend As Boolean, LoadDay As String, DayIndex As Decimal?, MonthIndex As Decimal?) As Integer
        Dim iCt As Integer = -1
        Try
            iCt = oDatesTa.UpdateDate(LoadYr, LoadMth, isDateAmend, LoadDay, DayIndex, MonthIndex, "I")
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function UpdatePageDate(LoadYr As String, LoadMth As String, isDateAmend As Boolean, LoadDay As String, DayIndex As Decimal?, MonthIndex As Decimal?) As Integer
        Dim iCt As Integer = -1
        Try
            iCt = oDatesTa.UpdateDate(LoadYr, LoadMth, isDateAmend, LoadDay, DayIndex, MonthIndex, "P")
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return iCt
    End Function
    Public Function GetWordPressLoadDate(oDay As Integer, oMonth As Integer, oType As String) As Date?
        Dim loadDate As Date?
        Try
            Dim iCt As Integer = oDatesTa.FillByDateAndType(oDatesTable, oDay, oMonth, oType)
            Dim oDateRow As CelebrityBirthdayDataSet.DatesRow
            If iCt = 1 Then
                oDateRow = oDatesTable.Rows(0)
                loadDate = New Date(CInt(oDateRow.uploadyear), CInt(oDateRow.uploadmonth), CInt(oDateRow.uploadday))
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return loadDate
    End Function
    Public Function GetDatesRow(oDay As Integer, oMonth As Integer, oType As String) As CelebrityBirthday.CelebrityBirthdayDataSet.DatesRow
        Dim oDrow As CelebrityBirthdayDataSet.DatesRow = Nothing
        Try
            Dim iCt As Integer = oDatesTa.FillByDateAndType(oDatesTable, oDay, oMonth, oType)
            If iCt = 1 Then
                oDrow = oDatesTable.Rows(0)
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return oDrow
    End Function
    Public Function GetAuthById(pId As String) As TwitterOAuth
        Dim oTwAuth As TwitterOAuth = Nothing
        Try
            If oTwitterAuthTa.FillById(oTwitterAuthTable, pId) = 1 Then
                Dim oRow As CelebrityBirthdayDataSet.TwitterAuthRow = oTwitterAuthTable.Rows(0)
                oTwAuth = New TwitterOAuth With {
                    .Token = If(oRow.IsTokenNull, "", oRow.Token),
                    .TokenSecret = If(oRow.IsSecretNull, "", oRow.Secret),
                    .Verifier = If(oRow.IsVerifierNull, "", oRow.Verifier)
                }
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return oTwAuth
    End Function
    Public Function UpdateAuth(pId, pToken, pSecret, pVerifier) As Boolean
        Dim isOK As Boolean
        Try
            If GetAuthById(pId) Is Nothing Then
                isOK = oTwitterAuthTa.InsertAuth(pId, pVerifier, pToken, pSecret) = 1
            Else
                isOK = oTwitterAuthTa.UpdateAuth(pVerifier, pToken, pSecret, pId) = 1
            End If
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return isOK
    End Function
    Public Function GetTwitterUsers() As List(Of String)
        Dim _list As New List(Of String)
        Try
            oTwitterAuthTa.Fill(oTwitterAuthTable)
            For Each oRow As CelebrityBirthdayDataSet.TwitterAuthRow In oTwitterAuthTable.Rows
                _list.Add(oRow.Id)
            Next
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return _list
    End Function
    Public Function InsertTweet(pText As String, pMonth As Integer?, pDay As Integer?, pSeq As Integer?, pId As String, pAccount As String, pType As String) As Boolean
        Dim isOK As Boolean = False
        Try
            isOK = oTweetTa.InsertTweet(Now, If(String.IsNullOrEmpty(pText), "", pText), pMonth, pDay, pSeq, pId, pAccount, pType) = 1
        Catch dbEx As DbException
            DisplayException(MethodBase.GetCurrentMethod(), dbEx, MODULE_TYPE)
        End Try
        Return isOK
    End Function
#End Region
#Region "BornOnTheSameDay"
    Public Function UpdateBotsd(btsdDay As Integer, btsdMonth As Integer, btsdYear As Integer, btsdPostNo As Integer, btsdUrl As String) As Integer
        Dim rtnValue As Integer
        oBotsdTa.FillByPostNo(oBotsdTable, btsdPostNo)
        If oBotsdTable.Rows.Count > 0 Then
            Dim oRow As CelebrityBirthdayDataSet.BotSDRow = oBotsdTable.Rows(0)
            Dim btsdId As Integer = oRow.btsdId
            oBotsdTa.UpdateBotsd(btsdDay, btsdMonth, btsdYear, btsdPostNo, btsdUrl, btsdId)
            rtnValue = btsdId
        Else
            rtnValue = InsertBotsd(btsdDay, btsdMonth, btsdYear, btsdPostNo, btsdUrl)
        End If
        Return rtnValue
    End Function
    Public Function UpdateBotsd(btsdPostNo As Integer, btsdNewPostNo As Integer) As Integer
        Dim rtnValue As Integer
        oBotsdTa.FillByPostNo(oBotsdTable, btsdPostNo)
        If oBotsdTable.Rows.Count > 0 Then
            Dim oRow As CelebrityBirthdayDataSet.BotSDRow = oBotsdTable.Rows(0)
            Dim btsdId As Integer = oRow.btsdId
            Dim btsdDay As Integer = oRow.btsdDay
            Dim btsdMonth As Integer = oRow.btsdMonth
            Dim btsdYear As Integer = oRow.btsdYear
            Dim btsdUrl As String = oRow.btsdUrl
            oBotsdTa.UpdateBotsd(btsdDay, btsdMonth, btsdYear, btsdNewPostNo, btsdUrl, btsdId)
            rtnValue = btsdId
        Else
            rtnValue = -1
        End If
        Return rtnValue
    End Function
    Public Function InsertBotsd(btsdDay As Integer, btsdMonth As Integer, btsdYear As Integer, btsdPostNo As Integer, btsdUrl As String) As Integer
        Return oBotsdTa.InsertBotsd(btsdDay, btsdMonth, btsdYear, btsdPostNo, btsdUrl)
    End Function
    Public Function GetBotsd(btsdId As Integer) As CelebrityBirthdayDataSet.BotSDRow
        Dim oRow As CelebrityBirthdayDataSet.BotSDRow = Nothing
        If oBotsdTa.FillById(oBotsdTable, btsdId) = 1 Then
            oRow = oBotsdTable.Rows(0)
        End If
        Return oRow
    End Function
    Public Function GetBotsdIndex() As DataRowCollection
        Try
            oBotsdViewTa.FillByAtoZ(oBotsdViewTable)
        Catch ex As DbException
            DisplayException(MethodBase.GetCurrentMethod, ex, MODULE_TYPE)
            oBotsdViewTable.Rows.Clear()
        End Try

        Return oBotsdViewTable.Rows
    End Function
    Public Function GetBotsdViewByPostNo(postNo As Integer) As DataRowCollection
        Try
            oBotsdViewTa.FillByPostNo(oBotsdViewTable, postNo)
        Catch ex As DbException
            DisplayException(MethodBase.GetCurrentMethod, ex, MODULE_TYPE)
            oBotsdViewTable.Rows.Clear()
        End Try
        Return oBotsdViewTable.Rows
    End Function
    Public Function DeleteBotsdById(ByVal _id As Integer) As Integer
        Return oBotsdTa.DeleteBotsd(_id)
    End Function
    Public Function DeleteBotsdByPostNo(ByVal _postNo As Integer) As Integer
        Return oBotsdTa.DeleteByPostNo(_postNo)
    End Function
#End Region
End Module

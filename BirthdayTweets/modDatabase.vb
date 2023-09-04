' Hindleware
' Copyright (c) 2020-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common

Module modDatabase
#Region "data"

    Private ReadOnly oTwta As New CelebrityBirthdayDataSetTableAdapters.SocialMediaTableAdapter
    Private ReadOnly oTwtable As New CelebrityBirthdayDataSet.SocialMediaDataTable
    Private ReadOnly oPersonTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
    Private ReadOnly oPersonTable As New CelebrityBirthdayDataSet.PersonDataTable
    Private ReadOnly oImgTa As New CelebrityBirthdayDataSetTableAdapters.ImageTableAdapter
    Private ReadOnly oImgTable As New CelebrityBirthdayDataSet.ImageDataTable
    Private ReadOnly oFullPersonTa As New CelebrityBirthdayDataSetTableAdapters.FullPersonTableAdapter
    Private ReadOnly oFullPersonTable As New CelebrityBirthdayDataSet.FullPersonDataTable
    Private ReadOnly oTwitterAuthTa As New CelebrityBirthdayDataSetTableAdapters.TwitterAuthTableAdapter
    Private ReadOnly oTwitterAuthTable As New CelebrityBirthdayDataSet.TwitterAuthDataTable
    Private ReadOnly oTweetTa As New CelebrityBirthdayDataSetTableAdapters.TweetsTableAdapter
#End Region
#Region "person"
    Public Function FindTodays(oDay As Integer, oMonth As Integer, isTwin As Boolean)
        Const Psub As String = "FindTodays"
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByDayAndMonth(oFullPersonTable, oDay, oMonth, isTwin)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                _List.Add(New Person(oRow))
            Next
            LogUtil.ShowProgress(_List.Count & " birthdays found (no twins)", Psub)
        Catch dbEx As DbException
            LogUtil.Exception("Finding today's birthdays DbException", dbEx, Psub)
        End Try
        Return _List
    End Function

    Public Function FindRandomBirthday() As Person
        Const Psub As String = "FindRandom"
        Dim _person As New Person
        Try
            Dim _month As Integer = Today.Month
            Dim _day As Integer = Today.Day
            oFullPersonTa.FillByRandom(oFullPersonTable, _month, _day)
            If oFullPersonTable.Rows.Count > 0 Then
                Dim _row As CelebrityBirthdayDataSet.FullPersonRow = oFullPersonTable.Rows(0)
                _person = New Person(_row, True)
            End If
            LogUtil.ShowProgress(_person.Name & " birthday found", Psub)
        Catch dbEx As DbException
            LogUtil.Exception("Finding random birthday DbException", dbEx, Psub)
        End Try
        Return _person
    End Function

    Public Function FindPeopleByDate(oDay As Integer, oMonth As Integer, isTweetsOnly As Boolean, Optional isGetPhoto As Boolean = True) As List(Of Person)
        Const Psub As String = "FindPeopleByDate"
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
            LogUtil.Exception("Find People DbException", dbEx, Psub)
        End Try

        Return oPersonList
    End Function
    Public Function FindBirthdays(oDay As Integer, oMonth As Integer) As List(Of Person)
        Const Psub As String = "FindBirthdays"
        LogUtil.ShowProgress("Finding list of people with birthdays", Psub)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByBirthday(oFullPersonTable, oMonth, oDay)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If Not oRow.noTweet And oRow.celebtype <> 4 Then
                    _List.Add(New Person(oRow))
                End If
            Next
        Catch dbEx As DbException
            LogUtil.Exception("Finding birthdays DbException", dbEx, Psub)
        End Try
        Return _List
    End Function
    Public Function FindAnniversaries(oDay As Integer, oMonth As Integer) As List(Of Person)
        Const Psub As String = "FindAnniversaries"
        LogUtil.ShowProgress("Finding list of people with anniversaries", Psub)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByAnniversary(oFullPersonTable, oDay, oMonth)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If Not oRow.noTweet And oRow.celebtype <> 4 Then
                    _List.Add(New Person(oRow))
                End If
            Next
        Catch dbEx As DbException
            LogUtil.Exception("Finding anniversaries DbException", dbEx, Psub)
        End Try
        Return _List
    End Function
    Public Function FindDeaths(oDay As Integer, omonth As Integer) As List(Of Person)
        Const Psub As String = "FindDeaths"
        LogUtil.ShowProgress("Finding list of people who have died", Psub)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByDeaths(oFullPersonTable, omonth, oDay)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If Not oRow.noTweet And oRow.celebtype <> 4 Then
                    _List.Add(New Person(oRow))
                End If
            Next
        Catch dbEx As DbException
            LogUtil.Exception("Finding deaths DbException", dbEx, Psub)
        End Try
        Return _List
    End Function
    Public Function FindForNowBirthdays(oDay As Integer, omonth As Integer) As List(Of Person)
        Const Psub As String = "FindForNowBirthdays"
        LogUtil.ShowProgress("Finding list of people who are famous for now", Psub)
        Dim _List As New List(Of Person)
        Try
            oFullPersonTa.FillByFnBirthday(oFullPersonTable, omonth, oDay)
            For Each oRow As CelebrityBirthdayDataSet.FullPersonRow In oFullPersonTable.Rows
                If Not oRow.noTweet Then
                    _List.Add(New Person(oRow))
                End If
            Next
        Catch dbEx As DbException
            LogUtil.Exception("Finding fornow DbException", dbEx, Psub)
        End Try
        Return _List
    End Function
#End Region
#Region "image"
    Public Function GetImageById(ByVal _id As Integer, Optional isGetPhoto As Boolean = True) As ImageIdentity
        Const Psub As String = "GetImageById"
        Try
            Dim ict As Integer = oImgTa.FillById(oImgTable, _id)
            If ict = 1 Then
                Return New ImageIdentity(oImgTable.Rows(0), isGetPhoto)
            End If
        Catch dbEx As DbException
            LogUtil.Exception("Get Image DbException", dbEx, Psub)
        End Try
        Return New ImageIdentity
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

#End Region
#Region "dates"
    Public Function GetAuthById(pId As String) As TwitterOAuth
        Const Psub As String = "GetAuthById"
        Dim oTwAuth As TwitterOAuth = Nothing
        Try
            If oTwitterAuthTa.FillById(oTwitterAuthTable, pId) = 1 Then
                Dim oRow As CelebrityBirthdayDataSet.TwitterAuthRow = oTwitterAuthTable.Rows(0)
                oTwAuth = New TwitterOAuth With {
                    .Token = If(oRow.IsTokenNull, "", oRow.Token),
                    .TokenSecret = If(oRow.IsSecretNull, "", oRow.Secret),
                    .Verifier = If(oRow.IsVerifierNull, "", oRow.Verifier)
                }
            Else
                LogUtil.Problem("Twitter user " & pId & " not found in database", Psub)
            End If
        Catch dbEx As DbException
            LogUtil.Exception("Get Auth DbException", dbEx, Psub)
        End Try
        Return oTwAuth
    End Function
    Public Function GetTwitterUsers() As List(Of String)
        Const Psub As String = "GetTwitterUsers"
        Dim _list As New List(Of String)
        Try
            oTwitterAuthTa.Fill(oTwitterAuthTable)
            For Each oRow As CelebrityBirthdayDataSet.TwitterAuthRow In oTwitterAuthTable.Rows
                _list.Add(oRow.Id)
            Next
        Catch dbEx As DbException
            LogUtil.Exception("Get Twitter Users DbException", dbEx, Psub)
        End Try
        Return _list
    End Function
    Public Function InsertTweet(pText As String, pMonth As Integer?, pDay As Integer?, pSeq As Integer?, pId As String, pAccount As String, pType As String) As Boolean
        Const Psub As String = "InsertTweet"
        Dim isOK As Boolean = False
        Try
            isOK = oTweetTa.InsertTweet(Now, If(String.IsNullOrEmpty(pText), "", pText), pMonth, pDay, pSeq, pId, pAccount, pType) = 1
        Catch dbEx As DbException
            LogUtil.Exception("Insert Tweet DbException", dbEx, Psub)
        End Try
        Return isOK
    End Function
#End Region
End Module

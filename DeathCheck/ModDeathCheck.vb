Imports System.Data.Common
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Reflection

Module ModDeathCheck
#Region "variables"
    Private personTable As List(Of Person)
    Private toAddr As String
    Private fromAddr As String
    Private fromName As String
    Private Const EMAIL_TO_ADDRESS As String = "SendErrorTo"
    Private Const EMAIL_FROM_ADDRESS As String = "SendEmailFrom"
    Private Const EMAIL_FROM_NAME As String = "SendEmailName"
    Private deadList As New List(Of Person)
#End Region
    Sub Main()
        InitialiseApplication()
        RunDeathCheck()
        Dim outputFile As String = WriteFile()
        If deadList.Count > 0 Then
            Try
                Dim deathList As String = My.Computer.FileSystem.ReadAllText(outputFile)
                Dim message As String = "Deaths found:" & vbCrLf & deathList
                SendEmail("Deaths found", message)
            Catch ex As IOException
                LogUtil.Exception("Error retrieving file contents", ex, "Main")
            End Try
        End If
        CloseApplication()
    End Sub

    Private Sub CloseApplication()
        LogUtil.Info("End of Run", "CloseApplication")
    End Sub

    Private Sub InitialiseApplication()
        LogUtil.InitialiseLogging()
        LogUtil.StartLogging()
        Dim sConnection As String() = Split(My.Settings.CelebrityBirthdayConnectionString, ";")
        Dim serverName As String = ""
        Dim dbName As String = ""
        For Each oConn As String In sConnection
            Dim nvp As String() = Split(oConn, "=")
            If nvp.GetUpperBound(0) = 1 Then
                Select Case nvp(0)
                    Case "Data Source"
                        serverName = nvp(1)
                    Case "Initial Catalog"
                        dbName = nvp(1)
                End Select
            End If
        Next
        Dim _runtime As List(Of String) = {"Computer name : " & My.Computer.Name,
                                            "Data connection: ",
                                            "   server=" & serverName,
                                            "   database=" & dbName,
                                            "Application path is " & My.Application.Info.DirectoryPath}.ToList
        For Each _rt As String In _runtime
            LogUtil.Info(_rt, "InitialiseApplication")
        Next

    End Sub
    Private Sub RunDeathCheck()
        Dim pSub As String = "RunDeathCheck"
        LogUtil.Info("Finding the living", pSub)
        personTable = FindLivingPeople(False)
        LogUtil.Info("Found " & CStr(personTable.Count) & " people", pSub)
        Dim countText As String = "{0} of " & CStr(personTable.Count)
        Dim iCt As Integer = 0
        For Each _person In personTable
            Try
                iCt += 1
                Dim searchString As String = ""
                If _person.Social IsNot Nothing Then
                    searchString = _person.Social.WikiId
                End If
                If String.IsNullOrEmpty(searchString) Then
                    searchString = _person.Name
                End If
                Dim _wikiExtract As String = GetWikiExtract(searchString, 3)
                Dim datesFound As CbDates = Nothing
                Dim cbdates As List(Of CbDates) = ExtractCbdatesFromWikiExtract(_wikiExtract)
                If cbdates.Count = 1 Then
                    datesFound = cbdates(0)
                Else
                    For Each _cbdates As CbDates In cbdates
                        Dim _dob As Date = _cbdates.BirthDate.DateValue
                        If _person.DateOfBirth = _dob Then
                            datesFound = _cbdates
                            Exit For
                        End If
                    Next
                End If
                If datesFound IsNot Nothing Then
                    If datesFound.DeathDate.IsValidDate Then
                        Dim _dateOfDeath As String = datesFound.DeathDate.FormattedDateString
                        LogUtil.Info(_person.Name & " died " & _dateOfDeath)
                        deadList.Add(_person)
                    End If
                End If

            Catch ex As DbException
                If DisplayException(MethodBase.GetCurrentMethod(), ex, "dB", True) = MsgBoxResult.No Then Exit Sub
            End Try
        Next
    End Sub
    Private Function WriteFile() As String
        Dim _filename As String = Path.Combine(My.Settings.TwitterFilePath, "deadpeople.csv")
        LogUtil.Info("Writing " & _filename, True)
        Try
            Using _outfile As New StreamWriter(_filename, False)
                WriteListToFile(_outfile)
            End Using
        Catch ex As IOException
            LogUtil.Exception("Error opening file", ex, "WriteFile")
        End Try
        Return _filename
    End Function
    Private Sub GetEmailSettings()
        toAddr = GlobalSettings.GetSetting(EMAIL_TO_ADDRESS)
        fromAddr = GlobalSettings.GetSetting(EMAIL_FROM_ADDRESS)
        fromName = GlobalSettings.GetSetting(EMAIL_FROM_NAME)
    End Sub
    Private Sub SendEmail(strSubject As String, strBody As String)
        GetEmailSettings()
        EmailUtil.SendMail(fromAddr, toAddr, Array.Empty(Of String), strSubject, strBody, fromName)
    End Sub
    Private Sub WriteListToFile(_outfile As StreamWriter)
        Try
            For Each _person As Person In deadList
                _outfile.WriteLine(CStr(_person.Id) & "," & _person.Name & "," & Format(_person.DateOfBirth, "dd MMM yyyy") & "," & Format(_person.DateOfDeath, "dd MMM yyyy"))
            Next
        Catch ex As IOException
            LogUtil.Exception("Error writing file", ex, "WriteListToFile")
        End Try
    End Sub
End Module

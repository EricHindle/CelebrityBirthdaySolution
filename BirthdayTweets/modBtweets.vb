' Hindleware
' Copyright (c) 2020-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Globalization

Module modBtweets
    Public Const TWEET_MAX_LEN As Integer = 280
    Public myCultureInfo As CultureInfo = CultureInfo.CurrentUICulture
    Public myStringFormatProvider As IFormatProvider = myCultureInfo.GetFormat(GetType(String))
    Public Function CalculateAge(oPerson As Person, Optional isNextBirthday As Boolean = True) As Integer
        Dim _years As Integer = 0
        Dim _dob As Date
        If oPerson.BirthYear > 0 Then
            Try
                _dob = New Date(oPerson.BirthYear, oPerson.BirthMonth, oPerson.BirthDay)
                Dim _thisMonth As Integer = Today.Month
                Dim _thisDay As Integer = Today.Day
                _years = DateDiff(DateInterval.Year, _dob, Today)
                If (_thisMonth > oPerson.BirthMonth OrElse (_thisMonth = oPerson.BirthMonth And _thisDay > oPerson.BirthDay)) And isNextBirthday Then
                    _years += 1
                End If
            Catch ex As Exception
                LogUtil.Exception("Date error " & oPerson.Name, ex, "CalculateAge")
            End Try

        End If
        Return _years
    End Function
End Module

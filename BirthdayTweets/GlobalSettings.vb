' Hindleware
' Copyright (c) 2020-2023 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
''' <summary>
''' Options and settings to be used by all users
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class GlobalSettings
    Private Shared ReadOnly oTa As New CelebrityBirthdayDataSetTableAdapters.SettingsTableAdapter
    Private Shared ReadOnly oTable As New CelebrityBirthdayDataSet.SettingsDataTable
    ''' <summary>
    ''' Get a setting
    ''' </summary>
    ''' <param name="settingName">Name of setting to be returned</param>
    ''' <returns>Value of setting</returns>
    ''' <remarks></remarks>
    Public Shared Function GetSetting(ByVal settingName As String) As Object
        Dim rtnValue As Object = Nothing
        Try
            Dim i As Integer = oTa.FillByKey(oTable, settingName)
            If i = 1 Then
                Dim oRow As CelebrityBirthdayDataSet.SettingsRow = oTable.Rows(0)
                Dim value As String = oRow.pValue
                Try
                    Select Case oRow.pType.ToLower(myCultureInfo)
                        Case "string"
                            rtnValue = value
                        Case "integer"
                            rtnValue = CInt(value)
                        Case "date"
                            rtnValue = CDate(value)
                        Case "boolean"
                            rtnValue = CBool(value)
                        Case "decimal"
                            rtnValue = CDec(value)
                        Case "char"
                            rtnValue = CChar(value)
                    End Select
                Catch ex As OverflowException
                    LogUtil.Exception("Global value exception for " & settingName, ex, "GetSetting")
                End Try
            Else
                oTa.InsertSetting(settingName, "", "string", "")
                LogUtil.Problem("Missing Global value " & settingName, "GetSetting")
                rtnValue = Nothing
            End If
        Catch ex As ArgumentNullException
            LogUtil.Exception("Global value ArgumentNullException for " & settingName, ex, "GetSetting")
        Catch ex As InvalidOperationException
            LogUtil.Exception("Global value InvalidOperationException for " & settingName, ex, "GetSetting")
        End Try
        Return rtnValue
    End Function
    Public Shared Function GetBooleanSetting(ByVal settingName As String) As Boolean
        Dim rtnBooleanValue As Boolean = False
        Dim rtnValue As Object = GetSetting(settingName)
        If rtnValue Is Nothing Then
            LogUtil.Problem("Missing Global value " & settingName, "GetBooleanSetting")
        Else
            rtnBooleanValue = CBool(rtnValue)
        End If
        Return rtnBooleanValue
    End Function
    Public Shared Function GetIntegerSetting(ByVal settingName As String) As Integer
        Dim rtnIntegerValue As Integer = 0
        Dim rtnValue As Object = GetSetting(settingName)
        If rtnValue Is Nothing Then
            LogUtil.Problem("Missing Global value " & settingName, "GetIntegerSetting")
        Else
            rtnIntegerValue = CInt(rtnValue)
        End If
        Return rtnIntegerValue
    End Function
    Public Shared Function GetDateSetting(ByVal settingName As String) As Date
        Dim rtnDateValue As Date = Date.MinValue
        Dim rtnValue As Object = GetSetting(settingName)
        If rtnValue Is Nothing Then
            LogUtil.Problem("Missing Global value " & settingName, "GetIntegerSetting")
        Else
            If IsDate(rtnValue) Then
                rtnDateValue = CDate(rtnValue)
            Else
                LogUtil.Problem("Invalid date global value " & settingName, "GetIntegerSetting")
            End If
        End If
        Return rtnDateValue
    End Function
    Public Shared Function SetSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        Dim rtnVal As Boolean = True
        Try
            oTa.UpdateSetting(settingValue, settingType, settingGroup, settingName)
        Catch ex As DbException
            rtnVal = False
        End Try
        Return rtnVal
    End Function
    Public Shared Function NewSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String, ByVal Optional settingGroup As String = "") As Boolean
        Dim rtnVal As Boolean = True
        Try
            oTa.InsertSetting(settingName, settingValue, settingType, settingGroup)
        Catch ex As DbException
            rtnVal = False
        End Try
        Return rtnVal
    End Function
End Class

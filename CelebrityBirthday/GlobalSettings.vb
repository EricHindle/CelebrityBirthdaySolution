﻿
''' <summary>
''' Options and settings to be used by all users
''' </summary>
''' <remarks></remarks>
Public Class GlobalSettings
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
            Dim i As Integer = oTa.FillByName(oTable, settingName)

            If i = 1 Then
                Dim oRow As CelebrityBirthdayDataSet.SettingsRow = oTable.Rows(0)
                Dim value As String = oRow.pValue
                Try
                    Select Case oRow.pType.ToLower
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
                Catch ex As Exception

                End Try
            Else
                oTa.InsertSetting(settingName, "", "string")
                rtnValue = ""
            End If
        Catch ex As Exception
            Throw
        End Try
        Return rtnValue
    End Function

    Public Shared Function SetSetting(ByVal settingName As String, ByVal settingType As String, ByVal settingValue As String) As Boolean
        Dim rtnVal As Boolean = True
        Try
            oTa.UpdateSetting(settingValue, settingType, settingName)
        Catch ex As Exception
            rtnVal = False
        End Try
        Return rtnVal
    End Function

    Public Shared Sub LoadGlobalSettings()

        My.Settings.Save()
    End Sub

End Class
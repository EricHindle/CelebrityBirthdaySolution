Imports System.Data.Common
Imports System.Reflection

Module modDatabase
#Region "constants"
    Private Const MODULE_NAME As String = "modDatabase"
    Private Const MODULE_TYPE As String = "Database"
#End Region
#Region "data"


    Private ReadOnly oFullPersonTa As New CelebrityBirthdayDataSetTableAdapters.FullPersonTableAdapter
    Private ReadOnly oFullPersonTable As New CelebrityBirthdayDataSet.FullPersonDataTable

#End Region

#Region "person"



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

#End Region

End Module

Imports System.Data.Common
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text
Imports System.Web.Script.Serialization

Public Class FrmAddWikiIds
#Region "variables"
    Private personTable As List(Of Person)
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        dgvWikiIds.Rows.Clear()
        DisplayMessage("Finding everybody")
        Try
            personTable = FindEverybody()
        Catch ex As DbException
            If MsgBox("Exception during list load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try
        Dim totalPeople As Integer = personTable.Count
        Dim _ct As Integer = 0
        Dim _addedCt As Integer = 0
        DisplayMessage("Found " & CStr(totalPeople) & " people")
        For Each _person In personTable
            _ct += 1
            DisplayMessage(CStr(_ct) & " of " & CStr(totalPeople))
            If String.IsNullOrEmpty(_person.Social.WikiId) Then
                Dim _searchName As String = If(String.IsNullOrEmpty(_person.ForeName), "", _person.ForeName.Trim & " ") & _person.Surname.Trim
                Dim _response As WebResponse = NavigateToUrl(GetWikiTitleString(_searchName))
                Dim pageTitle As List(Of String) = GetDataFromResponse(_response)
                _addedCt += AddWikiIdRow(_person, pageTitle)
                If nudSelectCount.Value > 0 AndAlso _addedCt = nudSelectCount.Value Then
                    Exit For
                End If
                Dim remainder As Integer
                Math.DivRem(_ct, 20, remainder)
                If remainder = 0 Then
                    dgvWikiIds.Refresh()
                End If
            End If
            _person.Dispose()
        Next
    End Sub
    Private Sub BtnWrite_Click(sender As Object, e As EventArgs) Handles BtnWrite.Click
        Dim ict As Integer = 0
        For Each oRow As DataGridViewRow In dgvWikiIds.Rows
            ict += 1
            DisplayMessage(CStr(ict))
            If oRow.Cells(xExclude.Name).Value = False Then
                If GetSocialMedia(oRow.Cells(xId.Name).Value).Id < 0 Then
                    InsertSocialMedia(oRow.Cells(xId.Name).Value, "", False, oRow.Cells(xDesc.Name).Value, 0)
                Else
                    UpdateWikiId(oRow.Cells(xId.Name).Value, oRow.Cells(xDesc.Name).Value)
                End If

            End If
        Next
    End Sub
#End Region
#Region "subroutines"
    Private Function AddWikiIdRow(pPerson As Person, pageTitles As List(Of String)) As Integer
        Dim isAdded As Integer = 0
        If pPerson IsNot Nothing And pageTitles IsNot Nothing Then
            Dim oRow As DataGridViewRow = dgvWikiIds.Rows(dgvWikiIds.Rows.Add())
            oRow.Cells(xExclude.Name).Value = True
            oRow.Cells(xId.Name).Value = pPerson.Id
            oRow.Cells(xName.Name).Value = pPerson.Name
            If pageTitles.Count > 0 Then
                Dim alts As New StringBuilder()
                For Each _title As String In pageTitles
                    alts.Append(_title).Append("|")
                Next
                oRow.Cells(xAlternates.Name).Value = alts.ToString
                oRow.Cells(xDesc.Name).Value = pageTitles(0)
                oRow.Cells(xExclude.Name).Value = False
                isAdded = 1
            End If
        End If
        Return isAdded
    End Function
    Private Sub DisplayMessage(oText As String)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
    End Sub
    Public Shared Function GetDataFromResponse(pResponse As WebResponse) As List(Of String)
        Dim oExtract As String
        Dim wikipage As String
        Dim titleList As New List(Of String)
        If Not pResponse Is Nothing Then
            Try
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(pResponse.GetResponseStream())
                wikipage = sr.ReadToEnd
                Dim jss As New JavaScriptSerializer()
                Dim extractDictionary As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)
                If extractDictionary.ContainsKey("query") Then
                    Dim queryDictionary As Dictionary(Of String, Object) = extractDictionary("query")
                    If queryDictionary.ContainsKey("allpages") Then
                        Dim _pagesList As ArrayList = TryCast(queryDictionary("allpages"), ArrayList)
                        If _pagesList IsNot Nothing Then
                            If _pagesList.Count > 0 Then
                                For Each _page In _pagesList
                                    Dim pageDictionary As Dictionary(Of String, Object) = _page
                                    If pageDictionary.ContainsKey("title") Then
                                        oExtract = TryCast(pageDictionary("title"), String)
                                        titleList.Add(oExtract.Replace(" ", "_"))
                                    End If
                                Next
                            End If
                        End If
                    Else
                        oExtract = "Error"
                    End If
                End If
                sr.Dispose()
            Catch ex As ArgumentException
                DisplayException(MethodBase.GetCurrentMethod, ex, "Argument")
            Catch ex As InvalidOperationException
                DisplayException(MethodBase.GetCurrentMethod, ex, "Invalid Operation")
            Catch ex As OutOfMemoryException
                DisplayException(MethodBase.GetCurrentMethod, ex, "Out Of Memory")
            Catch ex As IOException
                DisplayException(MethodBase.GetCurrentMethod, ex, "IO")
            Catch ex As NullReferenceException
                DisplayException(MethodBase.GetCurrentMethod, ex, "NullReference")
            End Try
        End If
        Return titleList
    End Function
#End Region
End Class
' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Text
Imports System.Web.Script.Serialization

Public Class FrmAddWikiIds
#Region "variables"
    Private personTable As List(Of Person)
    Private isLoadingTable As Boolean
#End Region
#Region "form control handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        isLoadingTable = True
        dgvWikiIds.Rows.Clear()
        ClearPersonDetails()
        DisplayAndLog("Finding everybody")
        Try
            personTable = FindEverybody()
        Catch ex As DbException
            LogUtil.Problem("Exception during list load : " & ex.Message)
            If MsgBox("Exception during list load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try
        Dim totalPeople As Integer = personTable.Count
        Dim _ct As Integer = 0
        Dim _addedCt As Integer = 0
        DisplayAndLog("Found " & totalPeople & " people")
        For Each _person In personTable
            _ct += 1
            ShowProgress(_ct & " of " & totalPeople, lblStatus, False)
            If String.IsNullOrEmpty(_person.Social.WikiId) Then
                Dim searchName As String = If(String.IsNullOrEmpty(_person.ForeName), "", _person.ForeName.Trim & " ") & _person.Surname.Trim
                FindPossibleWikiIds(_addedCt, _person, searchName)
                If NudSelectCount.Value > 0 AndAlso _addedCt = NudSelectCount.Value Then
                    Exit For
                End If
            Else
                Dim wikiText As String = GetWikiText(2, _person.ForeName, _person.Surname, _person.Social.WikiId)
                If wikiText.Contains("may refer to") Then
                    Dim searchName As String = _person.Social.WikiId
                    FindPossibleWikiIds(_addedCt, _person, searchName)
                    If NudSelectCount.Value > 0 AndAlso _addedCt = NudSelectCount.Value Then
                        Exit For
                    End If
                End If
            End If
            _person.Dispose()
        Next
        DisplayAndLog("Find Complete")
        dgvWikiIds.ClearSelection()
        isLoadingTable = False
    End Sub
    Private Sub FindPossibleWikiIds(ByRef _addedCt As Integer, _person As Person, ByRef searchName As String)
        Dim pageTitle As New List(Of String)
        Dim allDone As Boolean = False
        Do Until allDone
            Dim searchstring As String = GetWikiTitleString(searchName)
            Dim _response As WebResponse = NavigateToUrl(searchstring)
            Dim _continue As String = ""
            Dim addList As List(Of String) = GetDataFromResponse(_response, _continue)
            pageTitle.AddRange(addList)
            If String.IsNullOrEmpty(_continue) Then
                allDone = True
            Else
                searchName = _continue
            End If
        Loop
        _addedCt += AddWikiIdRow(_person, pageTitle, False)
    End Sub
    Private Sub DgvWikiIds_SelectionChanged(sender As Object, e As EventArgs) Handles dgvWikiIds.SelectionChanged
        If Not isLoadingTable Then
            ClearPersonDetails()
            If dgvWikiIds.SelectedRows.Count = 1 Then
                Dim oRow As DataGridViewRow = dgvWikiIds.SelectedRows(0)
                LblId.Text = oRow.Cells(xId.Name).Value
                TxtFullName.Text = oRow.Cells(xName.Name).Value
                TxtDob.Text = oRow.Cells(xDob.Name).Value
                txtShortDesc.Text = oRow.Cells(xShortDesc.Name).Value
                Dim _wikiIds As List(Of String) = Split(oRow.Cells(xAlternates.Name).Value, "|").ToList
                For Each _wikiId As String In _wikiIds
                    lbWikiIds.Items.Add(_wikiId)
                Next
            End If
        End If
    End Sub
    Private Sub BtnSingleUpdate_Click(sender As Object, e As EventArgs) Handles BtnSingleUpdate.Click
        Dim pPersonId As Integer = LblId.Text
        Dim pWikiId As String = ""
        If pPersonId > 0 Then
            If Not String.IsNullOrEmpty(TxtUseThis.Text) Then
                pWikiId = TxtUseThis.Text.Trim
            ElseIf lbWikiIds.SelectedIndex >= 0 Then
                pWikiId = lbWikiIds.SelectedItem
            End If
            If Not String.IsNullOrEmpty(pWikiId) Then
                UpdateWikiId(pPersonId, pWikiId)
                DisplayAndLog("Updated " & pWikiId)
                ClearPersonDetails()
            End If
        End If
    End Sub
    Private Sub BtnWrite_Click(sender As Object, e As EventArgs)
        Dim ict As Integer = 0
        For Each oRow As DataGridViewRow In dgvWikiIds.Rows
            ict += 1
            ShowProgress(ict, lblStatus, False)
            If oRow.Cells(xExclude.Name).Value = False Then
                If GetSocialMedia(oRow.Cells(xId.Name).Value).Id < 0 Then
                    InsertSocialMedia(oRow.Cells(xId.Name).Value, "", False, oRow.Cells(xDesc.Name).Value, 0, False, 0)
                Else
                    UpdateWikiId(oRow.Cells(xId.Name).Value, oRow.Cells(xDesc.Name).Value)
                End If
            End If
        Next
    End Sub
#End Region
#Region "subroutines"
    Private Function AddWikiIdRow(pPerson As Person, pageTitles As List(Of String), Optional isAutoUpdate As Boolean = False) As Integer
        Dim isAdded As Integer = 0
        If pPerson IsNot Nothing And pageTitles IsNot Nothing Then
            Dim oRow As DataGridViewRow = dgvWikiIds.Rows(dgvWikiIds.Rows.Add())
            oRow.Cells(xExclude.Name).Value = True
            oRow.Cells(xId.Name).Value = pPerson.Id
            oRow.Cells(xName.Name).Value = pPerson.Name
            oRow.Cells(xDob.Name).Value = Format(pPerson.DateOfBirth, "dd-MMM-yyyy")
            oRow.Cells(xShortDesc.Name).Value = pPerson.ShortDesc.Substring(0, Math.Min(30, pPerson.ShortDesc.Length))
            If pageTitles.Count > 0 Then
                Dim alts As New StringBuilder()
                For Each _title As String In pageTitles
                    alts.Append(_title).Append("|"c)
                Next
                oRow.Cells(xAlternates.Name).Value = alts.ToString
                oRow.Cells(xDesc.Name).Value = pageTitles(0)
                oRow.Cells(xExclude.Name).Value = Not isAutoUpdate
                isAdded = 1
                dgvWikiIds.Refresh()
            End If
        End If
        Return isAdded
    End Function
    'Private Sub DisplayMessage(oText As String)
    '    lblStatus.Text = oText
    '    StatusStrip1.Refresh()
    'End Sub
    Public Shared Function GetDataFromResponse(ByRef pResponse As WebResponse, ByRef pContinue As String) As List(Of String)
        Dim oExtract As String
        Dim wikipage As String
        Dim titleList As New List(Of String)
        If pResponse IsNot Nothing Then
            Try
                Dim sr As New System.IO.StreamReader(pResponse.GetResponseStream())
                wikipage = sr.ReadToEnd
                Dim jss As New JavaScriptSerializer()
                Dim extractDictionary As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)
                If extractDictionary.ContainsKey("continue") Then
                    Dim contDictionary As Dictionary(Of String, Object) = extractDictionary("continue")
                    If contDictionary.ContainsKey("apcontinue") Then
                        pContinue = TryCast(contDictionary("apcontinue"), String)
                    End If
                End If
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
    Private Sub ClearPersonDetails()
        lbWikiIds.Items.Clear()
        TxtFullName.Text = ""
        TxtDob.Text = ""
        txtShortDesc.Text = ""
        LblId.Text = -1
        txtWiki.Text = ""
        TxtUseThis.Text = ""
    End Sub
    Private Sub LbWikiIds_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbWikiIds.SelectedIndexChanged
        If lbWikiIds.SelectedIndex >= 0 Then
            txtWiki.Text = GetWikiText(2, "", "", lbWikiIds.SelectedItem)
        Else
            txtWiki.Text = ""
        End If
    End Sub

    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, lblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, lblStatus, True, MyBase.Name,, isMessagebox)
    End Sub

    Private Sub FrmAddWikiIds_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
    End Sub
#End Region
End Class
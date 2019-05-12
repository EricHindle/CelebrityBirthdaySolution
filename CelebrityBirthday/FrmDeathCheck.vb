Imports System.Net
Imports System.Web.Script.Serialization
Public Class FrmDeathCheck
    Private personTable As List(Of Person)



    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmDeathCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        DisplayMessage("Finding the living")
        personTable = FindLivingPeople()
        DisplayMessage("Found " & CStr(personTable.Count) & " people")
        For Each _person In personTable
            DisplayMessage(CStr(_person.Id) & " " & _person.Name)
            AddAllRow(_person)
            GetWikiDeathDate(_person.Name)


        Next
    End Sub

    Private Sub GetWikiDeathDate(_searchName As String)
        Dim _response As WebResponse = NavigateToUrl(GetWikiExtractString(_searchName))
        Dim extract As String = GetExtractFromResponse(_response)


    End Sub

    Public Function NavigateToUrl(pSearchString As String) As WebResponse
        Dim request As WebRequest = Nothing
        ' Create a request for the URL. 
        request = WebRequest.Create(pSearchString)
        ' If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials
        Return request.GetResponse()
    End Function

    Public Function GetExtractFromResponse(pResponse As WebResponse) As String
        Dim _extract As String = ""
        Try
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(pResponse.GetResponseStream())
            Dim wikipage As String = sr.ReadToEnd
            Dim jss As New JavaScriptSerializer()
            Dim extractDictionary As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(wikipage)
            Dim queryDictionary As Dictionary(Of String, Object) = extractDictionary("query")
            Dim _pagesList As ArrayList = TryCast(queryDictionary("pages"), ArrayList)
            If _pagesList IsNot Nothing Then
                Dim pageDictionary As Dictionary(Of String, Object) = _pagesList(0)
                _extract = TryCast(pageDictionary("extract"), String)
            End If
        Catch ex As Exception
        End Try
        Return _extract
    End Function
    Private Sub DisplayMessage(oText As String)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
    End Sub

    Private Function AddAllRow(oPerson As Person) As DataGridViewRow
        Dim _newRow As DataGridViewRow = dgvAllPersons.Rows(dgvAllPersons.Rows.Add())
        _newRow.Cells(allId.Name).Value = oPerson.Id
        _newRow.Cells(allName.Name).Value = oPerson.Name
        _newRow.Cells(allDob.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth.Value, "dd MMM yyyy"))
        dgvAllPersons.Refresh()
        Return _newRow
    End Function

    Private Function AddXRow(oPerson As Person, oDateOfDeath As Date?, oDesc As String) As DataGridViewRow
        Dim _newRow As DataGridViewRow = dgvWarnings.Rows(dgvWarnings.Rows.Add())
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xDeath.Name).Value = If(oDateOfDeath Is Nothing, "", Format(oDateOfDeath, "dd MMM yyyy"))
        _newRow.Cells(xDeath.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        dgvAllPersons.Refresh()
        Return _newRow
    End Function

End Class
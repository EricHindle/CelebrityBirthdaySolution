Imports System.Data.Common
Imports System.Text

Structure WikiBirthInfo
    Private _birthDate As Date?
    Private _errordesc As String
    Sub New(pBirthDate As Date?, pErrorDesc As String)
        _birthDate = pBirthDate
        _errordesc = pErrorDesc
    End Sub
    Public Property ErrorDesc() As String
        Get
            Return _errordesc
        End Get
        Set(ByVal value As String)
            _errordesc = value
        End Set
    End Property
    Public Property BirthDate() As Date?
        Get
            Return _birthDate
        End Get
        Set(ByVal value As Date?)
            _birthDate = value
        End Set
    End Property
End Structure
Public NotInheritable Class FrmDateCheck
#Region "variables"
    Private personList As New List(Of Person)
    Private personTable As New List(Of Person)
    Private isLoadingTable As Boolean
    Private isWikiIdChanged As Boolean
#End Region
#Region "form event handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        ClearPersonDetails()
        isLoadingTable = True
        DgvWarnings.Columns().Item(xImg.Name).Visible = ChkShowImage.Checked
        DgvWarnings.Rows.Clear()
        Me.Refresh()
        personList = New List(Of Person)
        Try
            If cboDay.SelectedIndex < 0 And cboMonth.SelectedIndex < 0 Then
                If MsgBox("Do you really want to select all persons?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Check") = MsgBoxResult.Yes Then
                    DisplayMessage("Finding everybody", True)
                    personList = FindEverybody()
                End If
            ElseIf cboDay.SelectedIndex < 0 Then
                DisplayMessage("Finding persons for " & CStr(cboMonth.SelectedItem), True)
                personList = FindPeopleByDate(-1, cboMonth.SelectedIndex + 1, False, False)
            Else
                DisplayMessage("Finding persons for " & CStr(cboDay.SelectedIndex + 1) & "/" & CStr(cboMonth.SelectedIndex + 1), True)
                personList = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, False, False)
            End If
        Catch ex As DbException
            LogUtil.Problem("Exception during list load : " & ex.Message)
            If MsgBox("Exception during list load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                Exit Sub
            End If
        End Try
        Dim totalPeople As Integer = personList.Count
        Dim _ct As Integer = 0
        Dim _addedct As Integer = 0
        DisplayMessage("Found " & CStr(totalPeople) & " people")
        personTable.Clear()
        For Each _person In personList
            _ct += 1
            DisplayMessage(CStr(_ct) & " of " & CStr(totalPeople))
            Try
                Dim extract As String = ""
                Dim wikiId As String = ""
                If _person.Social IsNot Nothing Then
                    wikiId = _person.Social.WikiId
                End If
                Dim _wikiBirthInfo As WikiBirthInfo = GetWikiBirthDate(extract, _person.ForeName, _person.Surname, wikiId)
                Dim _dateOfBirth As Date? = _wikiBirthInfo.BirthDate
                Dim _desc As String = extract
                If Not String.IsNullOrEmpty(_wikiBirthInfo.ErrorDesc) Then
                    _desc = _wikiBirthInfo.ErrorDesc
                End If
                If _dateOfBirth IsNot Nothing Then
                    If _dateOfBirth.Value <> _person.DateOfBirth Then
                        AddXRow(_person, Format(_dateOfBirth.Value, "dd MMM yyyy"), _desc, wikiId)
                        personTable.Add(_person)
                        _addedct += 1
                        If nudSelectCount.Value > 0 AndAlso _addedct = nudSelectCount.Value Then
                            Exit For
                        End If
                    End If
                    'Else
                    '    AddXRow(_person, "", "Can't find wiki Date of birth")
                End If
            Catch ex As ArgumentException
                LogUtil.Problem("Exception during list load : " & ex.Message)
                If MsgBox(_person.Name & vbCrLf & "Exception during table load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End Try
        Next
        DgvWarnings.ClearSelection()
        DisplayMessage("Selection complete")
        isLoadingTable = False
    End Sub
    Private Sub DgvWarnings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvWarnings.CellDoubleClick
        If e.RowIndex >= 0 And e.RowIndex < DgvWarnings.Rows.Count Then
            Dim tRow As DataGridViewRow = DgvWarnings.Rows(e.RowIndex)
            Dim _index As Integer = tRow.Cells(xId.Name).Value
            Using _update As New FrmUpdateDatabase
                _update.PersonId = _index
                _update.ShowDialog()
            End Using
        End If

    End Sub
    Private Sub DgvWarnings_SelectionChanged(sender As Object, e As EventArgs) Handles DgvWarnings.SelectionChanged
        If Not isLoadingTable Then
            ClearPersonDetails()
            If DgvWarnings.SelectedRows.Count = 1 Then
                Dim oRow As DataGridViewRow = DgvWarnings.SelectedRows(0)
                LblId.Text = oRow.Cells(xId.Name).Value
                TxtFullName.Text = oRow.Cells(xName.Name).Value
                TxtFullDesc.Text = oRow.Cells(xPersonDescription.Name).Value
                TxtWiki.Text = oRow.Cells(xWikiExtract.Name).Value
                Dim FromDt As Date = CDate(oRow.Cells(xBirth.Name).Value)
                Dim ToDt As Date = CDate(oRow.Cells(xWikiBirth.Name).Value)
                TxtToDay.Text = Format(ToDt, "dd")
                TxtToMonth.Text = Format(ToDt, "MM")
                TxtToYear.Text = Format(ToDt, "yyyy")
                TxtFromDay.Text = Format(FromDt, "dd")
                TxtFromMonth.Text = Format(FromDt, "MM")
                TxtFromYear.Text = Format(FromDt, "yyyy")
                TxtWikiId.Text = oRow.Cells(xWikiId.Name).Value
                isWikiIdChanged = False
            End If
        End If
    End Sub
    Private Sub BtnSingleUpdate_Click(sender As Object, e As EventArgs) Handles BtnSingleUpdate.Click
        If DgvWarnings.SelectedRows.Count = 1 Then
            Dim oPerson As Person = personTable(DgvWarnings.SelectedRows(0).Index)
            ResetChecklistButtons()
            Dim isOldReseqRequired As Boolean = False
            If oPerson.Social IsNot Nothing AndAlso oPerson.Social.Botsd > 0 Then
                Dim oBotsdId As Integer = oPerson.Social.Botsd
                Dim oBotsdRow As CelebrityBirthdayDataSet.BotSDRow = GetBotsd(oBotsdId)
                Dim oBotsdPostNo As Integer = If(oBotsdRow Is Nothing, 0, oBotsdRow.btsdPostNo)
                Dim oBotsdRowCollection As DataRowCollection = GetBotsdViewByPostNo(oBotsdPostNo)
                BtnRmvBotsdId.Visible = True
                Dim otherBotsd As New List(Of Integer)
                For Each oViewRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow In oBotsdRowCollection
                    If Not oViewRow.IspersonIdNull AndAlso oViewRow.personId <> oPerson.Id Then
                        otherBotsd.Add(oViewRow.personId)
                    End If
                Next
                If otherBotsd.Count = 1 Then
                    BtnRmvOtherBotsdId.Visible = True
                End If
                If otherBotsd.Count < 2 Then
                    BtnRmvBotsdRecord.Visible = True
                    BtnRmvOldBotsdPost.Visible = True
                Else
                    BtnUpdOldBotsdPost.Visible = True
                End If
                BtnUpdOldBotsdList.Visible = True
                isOldReseqRequired = True
            End If
            BtnUpdatePerson.Visible = True
            If isOldReseqRequired Then BtnReseqOldGroup.Visible = True
            Dim oNewGroup As CelebrityBirthdayDataSet.PersonDataTable = GetPeopleByDateofBirth(oPerson.BirthYear, oPerson.BirthMonth, oPerson.BirthDay)
            If oNewGroup.Rows.Count > 1 Then
                BtnReseqNewGroup.Visible = True
                BtnUpdateNewBotsdPost.Visible = True
                BtnPosted.Visible = True
                BtnUpdNewBotsdList.Visible = True
            End If
            Dim isYearOnlyChange As Boolean = TxtFromDay.Text = TxtToDay.Text AndAlso TxtFromMonth.Text = TxtToMonth.Text
            If isYearOnlyChange Then
                BtnMoveCbPic.Visible = True
            Else
                BtnRmvOldPicture.Visible = True
                BtnUpdOldCbPage.Visible = True
                BtnAddCbPic.Visible = True
            End If
            BtnUpdCbPicDesc.Visible = True
            BtnUpdNewCbPage.Visible = True
            BtnRmvRow.Visible = True
        End If
    End Sub
    Private Sub BtnWordPress_Click(sender As Object, e As EventArgs) Handles BtnFromWordPress.Click
        OpenWordPress(CInt(TxtFromDay.Text), CInt(TxtFromMonth.Text))
    End Sub
    Private Sub BtnToWordPress_Click(sender As Object, e As EventArgs) Handles BtnToWordPress.Click
        OpenWordPress(CInt(TxtToDay.Text), CInt(TxtToMonth.Text))
    End Sub
    Private Sub BtnToday_Click(sender As Object, e As EventArgs) Handles BtnToday.Click
        cboDay.SelectedIndex = Today.Day - 1
        cboMonth.SelectedIndex = Today.Month - 1
    End Sub
    Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click
        cboDay.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
    End Sub
    Private Sub BtnCopyText_Click(sender As Object, e As EventArgs) Handles BtnCopyDate.Click
        Dim personStringList As List(Of String) = ParseStringWithBrackets(TxtFullDesc.Text)
        If TxtWiki.SelectionLength > 0 Then
            TxtFullDesc.Text = personStringList(0) & "(" & TxtWiki.SelectedText & ")" & personStringList(2)
        Else
            Dim wikiStringList As List(Of String) = ParseStringWithBrackets(TxtWiki.Text)
            If personStringList.Count = 3 And wikiStringList.Count = 3 Then
                TxtFullDesc.Text = personStringList(0) & "(" & wikiStringList(1) & ")" & personStringList(2)
            End If
        End If
        DisplayMessage("Date copied to full desc", True)
    End Sub
    Private Sub BtnClearDetails_Click(sender As Object, e As EventArgs) Handles BtnClearDetails.Click
        ClearPersonDetails()
    End Sub
    Private Sub TxtWikiId_TextChanged(sender As Object, e As EventArgs) Handles TxtWikiId.TextChanged
        isWikiIdChanged = True
    End Sub
    Private Sub BtnWikiUpdate_Click(sender As Object, e As EventArgs) Handles BtnWikiUpdate.Click
        If isWikiIdChanged Then
            DisplayMessage("Updating wiki id", True)
            UpdateWikiId(CInt(LblId.Text), TxtWikiId.Text)
            DisplayMessage(LblId.Text & "Wiki Id Updated to " & TxtWikiId.Text, True)
        End If
    End Sub
    Private Sub Date_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        ClearPersonDetails()
        DisplayMessage("")
    End Sub
    Private Sub FrmDateCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        ResetChecklistButtons()
    End Sub
    Private Sub FrmDateCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
    Private Sub BtnWpDesc_Click(sender As Object, e As EventArgs) Handles BtnWpDesc.Click
        Dim wpText As String = ""
        Dim oPerson As Person = GetPersonById(CInt(LblId.Text))
        If oPerson IsNot Nothing Then
            DisplayMessage("Generating WordPress description for " & TxtFullName.Text, True)
            Dim sBorn As String = ""
            If oPerson.BirthName.Length > 0 Or oPerson.BirthPlace.Length > 0 Then
                sBorn = " Born" & If(oPerson.BirthName.Length > 0, " " & oPerson.BirthName, "") & If(oPerson.BirthPlace.Length > 0, " in " & oPerson.BirthPlace, "") & "."
            End If
            Dim sDied As String = " (d. " & CStr(Math.Abs(oPerson.DeathYear)) & If(oPerson.DeathYear < 0, " BCE", "") & ")"
            Dim sText As New StringBuilder
            With sText
                .Append(TxtFullDesc.Text)
                .Append(sBorn)
                .Append(If(oPerson.DeathYear = 0, "", sDied))
            End With
            wpText = sText.ToString
        End If
        Clipboard.SetText(wpText)
        oPerson.Dispose()
    End Sub
    Private Sub BtnBotSD_Click(sender As Object, e As EventArgs) Handles BtnBotSD.Click
        DisplayMessage("Born on the same day update", True)
        Using _botsd As New FrmBotsd
            If cboDay.SelectedIndex < 0 Then
                If IsNumeric(TxtToDay.Text) Then
                    _botsd.ThisDay = CInt(TxtToDay.Text)
                End If
            Else
                _botsd.ThisDay = cboDay.SelectedIndex + 1
            End If
            _botsd.ThisMonth = cboMonth.SelectedIndex + 1
            _botsd.ShowDialog()
        End Using
        DisplayMessage("")
    End Sub
    Private Sub BtnMonth_Click(sender As Object, e As EventArgs) Handles BtnMonth.Click
        cboDay.SelectedIndex = -1
    End Sub
    Private Sub ChkShowImage_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShowImage.CheckedChanged
        DgvWarnings.Columns().Item(xImg.Name).Visible = ChkShowImage.Checked
        For Each tRow As DataGridViewRow In DgvWarnings.Rows
            tRow.Height = If(ChkShowImage.Checked, 65, DgvWarnings.RowTemplate.Height)
        Next
    End Sub

#End Region
#Region "subroutines"
    Private Shared Function GetWikiBirthDate(ByRef extract As String, _forename As String, _surname As String, Optional wikiId As String = "") As WikiBirthInfo
        Dim _wikiBirthInfo As New WikiBirthInfo(Nothing, "")
        Dim _birthDate As Date? = Nothing
        Try
            extract = GetWikiText(3, _forename, _surname, wikiId)
            If extract.Contains("may refer to:") = False Then
                Dim _desc As String = RemoveSquareBrackets(FixQuotesAndHyphens(extract, True))
                Dim _parts As List(Of String) = ParseStringWithBrackets(_desc)
                If _parts.Count = 3 Then
                    Dim datePart As String = _parts(1)
                    Dim _dates As String() = Split(datePart, "-")
                    If _dates.Length > 0 Then
                        Try
                            Dim firstPart As String = _dates(0).Trim
                            firstPart = firstPart.Replace("N.", "").Replace("S.", "").Replace("(", "").Replace(")", "").Replace("O.", "").Replace(";", "").Replace("  ", " ")
                            Dim DateParts As String() = Split(firstPart, " ")
                            Dim DatePartsList As List(Of String) = DateParts.ToList

                            For bitNo As Integer = DatePartsList.Count - 1 To 0 Step -1
                                If IsNumeric(DatePartsList(bitNo)) Then Exit For
                                DatePartsList.RemoveAt(bitNo)
                            Next
                            If DatePartsList.Count = 0 Then
                                _wikiBirthInfo.ErrorDesc = "No date present"
                            Else
                                Dim firstDate As String = If(DatePartsList.Count > 2, DateParts(DatePartsList.Count - 3), 1) & " " & If(DatePartsList.Count > 1, DatePartsList(DatePartsList.Count - 2), "January") & " " & If(DatePartsList.Count > 0, DatePartsList(DatePartsList.Count - 1), "1900")
                                If IsDate(firstDate) Then
                                    _birthDate = CDate(firstDate)
                                Else
                                    _wikiBirthInfo.ErrorDesc = "Not a date: " & firstDate
                                End If
                            End If
                        Catch ex As OverflowException
                            _wikiBirthInfo.ErrorDesc = "Not a date: " & _dates(0)
                        End Try
                    End If
                End If
            Else
                _wikiBirthInfo.ErrorDesc = "may refer to"
            End If

        Catch ex As ArgumentException
            _wikiBirthInfo.ErrorDesc = ex.Message
        Catch ex As System.Security.SecurityException
            _wikiBirthInfo.ErrorDesc = ex.Message
        End Try
        _wikiBirthInfo.BirthDate = _birthDate
        Return _wikiBirthInfo
    End Function
    Private Sub DisplayMessage(oText As String, Optional isLogged As Boolean = False)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(oText, MyBase.Name)
    End Sub
    Private Function AddXRow(oPerson As Person, oDateOfBirth As String, oDesc As String, oWikiId As String) As DataGridViewRow
        Dim _newRow As DataGridViewRow = DgvWarnings.Rows(DgvWarnings.Rows.Add())
        _newRow.Height = If(ChkShowImage.Checked, 65, DgvWarnings.RowTemplate.Height)
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xWikiBirth.Name).Value = oDateOfBirth
        _newRow.Cells(xWikiExtract.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        _newRow.Cells(xPersonDescription.Name).Value = oPerson.Description
        _newRow.Cells(xWikiId.Name).Value = If(String.IsNullOrEmpty(oWikiId), "", oWikiId)
        Dim imageCell As DataGridViewImageCell = _newRow.Cells(xImg.Name)
        Dim oImageIdentity = GetImageById(oPerson.Id, True)
        If oImageIdentity IsNot Nothing Then
            imageCell.Value = oImageIdentity.Photo.Clone
            oImageIdentity.Dispose()
        End If

        DgvWarnings.Refresh()
        Return _newRow
    End Function
    Private Sub ClearPersonDetails()
        TxtFullName.Text = ""
        TxtFullDesc.Text = ""
        LblId.Text = -1
        TxtWiki.Text = ""
        TxtToDay.Text = ""
        TxtToMonth.Text = ""
        TxtToYear.Text = ""
        TxtFromDay.Text = ""
        TxtFromMonth.Text = ""
        TxtFromYear.Text = ""
        TxtWikiId.Text = ""
        isWikiIdChanged = False
    End Sub
    Private Sub OpenWordPress(pDay As Integer, pMonth As Integer)
        DisplayMessage("Opening WordPress form for " & CStr(pDay) & "/" & CStr(pMonth), True)
        Using _wordpress As New FrmWordPress
            _wordpress.DaySelection = pDay
            _wordpress.MonthSelection = pMonth
            _wordpress.ShowDialog()
        End Using
        DisplayMessage("")
    End Sub
    Private Sub ResetChecklistButtons()
        HideChecklistButtons
        DisableChecklistButtons
    End Sub
    Private Sub HideChecklistButtons()
        BtnRmvBotsdId.Visible = False
        BtnRmvOtherBotsdId.Visible = False
        BtnRmvBotsdRecord.Visible = False
        BtnRmvOldBotsdPost.Visible = False
        BtnUpdOldBotsdPost.Visible = False
        BtnUpdOldBotsdList.Visible = False
        BtnUpdatePerson.Visible = False
        BtnReseqOldGroup.Visible = False
        BtnReseqNewGroup.Visible = False
        BtnUpdateNewBotsdPost.Visible = False
        BtnPosted.Visible = False
        BtnUpdNewBotsdList.Visible = False
        BtnRmvOldPicture.Visible = False
        BtnUpdOldCbPage.Visible = False
        BtnAddCbPic.Visible = False
        BtnMoveCbPic.Visible = False
        BtnUpdCbPicDesc.Visible = False
        BtnUpdNewCbPage.Visible = False
        BtnRmvRow.Visible = False
    End Sub
    Private Sub DisableChecklistButtons()
        BtnRmvBotsdId.Enabled = False
        BtnRmvOtherBotsdId.Enabled = False
        BtnRmvBotsdRecord.Enabled = False
        BtnRmvOldBotsdPost.Enabled = False
        BtnUpdOldBotsdPost.Enabled = False
        BtnUpdOldBotsdList.Enabled = False
        BtnUpdatePerson.Enabled = False
        BtnReseqOldGroup.Enabled = False
        BtnReseqNewGroup.Enabled = False
        BtnUpdateNewBotsdPost.Enabled = False
        BtnPosted.Enabled = False
        BtnUpdNewBotsdList.Enabled = False
        BtnRmvOldPicture.Enabled = False
        BtnUpdOldCbPage.Enabled = False
        BtnAddCbPic.Enabled = False
        BtnMoveCbPic.Enabled = False
        BtnUpdCbPicDesc.Enabled = False
        BtnUpdNewCbPage.Enabled = False
        BtnRmvRow.Enabled = False
    End Sub
#End Region
#Region "checklist"
    Private Sub BtnRmvBotsdId_Click(sender As Object, e As EventArgs) Handles BtnRmvBotsdId.Click
        DisplayMessage("Removing BotSD id", True)
        If DgvWarnings.SelectedRows.Count = 1 Then
            Dim oPerson As Person = personTable(DgvWarnings.SelectedRows(0).Index)
            Dim oSocial As SocialMedia = oPerson.Social
            If oSocial IsNot Nothing Then
                If oSocial.Botsd > 0 Then
                    UpdateBotsdId(oPerson.Id, 0)
                    DisplayMessage("Removed BotSD Id from person " & CStr(oPerson.Id) & " " & oPerson.Surname, True)
                Else
                    DisplayMessage("No BotSD id to remove", True)
                End If
            Else
                DisplayMessage("No social details", True)
            End If
        Else
            DisplayMessage("No person selected", True)
        End If

    End Sub

    Private Sub BtnRmvOtherBotsdId_Click(sender As Object, e As EventArgs) Handles BtnRmvOtherBotsdId.Click

    End Sub

    Private Sub BtnRmvBotsdRecord_Click(sender As Object, e As EventArgs) Handles BtnRmvBotsdRecord.Click

    End Sub

    Private Sub BtnRmvOldBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnRmvOldBotsdPost.Click

    End Sub

    Private Sub BtnUpdOldBotsdList_Click(sender As Object, e As EventArgs) Handles BtnUpdOldBotsdList.Click

    End Sub

    Private Sub BtnUpdatePerson_Click(sender As Object, e As EventArgs) Handles BtnUpdatePerson.Click
        If DgvWarnings.SelectedRows.Count = 1 Then
            Dim oPerson As Person = personTable(DgvWarnings.SelectedRows(0).Index)
            If Not String.IsNullOrEmpty(TxtToYear.Text) And
                Not String.IsNullOrEmpty(TxtToMonth.Text) And
                Not String.IsNullOrEmpty(TxtToDay.Text) And
                IsDate(TxtToDay.Text & "/" & TxtToMonth.Text & "/" & TxtToYear.Text) Then
                DisplayMessage("Updating DoB and text for " & TxtFullName.Text, True)
                Dim pYear As Integer = CInt(TxtToYear.Text)
                Dim pMonth As Integer = CInt(TxtToMonth.Text)
                Dim pDay As Integer = CInt(TxtToDay.Text)
                UpdateDateOfBirth(oPerson.Id, pDay, pMonth, pYear, TxtFullDesc.Text)
                oPerson = GetFullPersonById(oPerson.Id, False)
                DisplayMessage("Updated " & CStr(oPerson.Id), True)
            End If
        End If
    End Sub

    Private Sub BtnReseqOldGroup_Click(sender As Object, e As EventArgs) Handles BtnReseqOldGroup.Click

    End Sub

    Private Sub BtnUpdateNewBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnUpdateNewBotsdPost.Click

    End Sub

    Private Sub BtnPosted_Click(sender As Object, e As EventArgs) Handles BtnPosted.Click

    End Sub

    Private Sub BtnUpdNewBotsdList_Click(sender As Object, e As EventArgs) Handles BtnUpdNewBotsdList.Click

    End Sub

    Private Sub BtnRmvOldPicture_Click(sender As Object, e As EventArgs) Handles BtnRmvOldPicture.Click

    End Sub

    Private Sub BtnUpdOldCbPage_Click(sender As Object, e As EventArgs) Handles BtnUpdOldCbPage.Click

    End Sub

    Private Sub BtnAddCbPic_Click(sender As Object, e As EventArgs) Handles BtnAddCbPic.Click

    End Sub

    Private Sub BtnMoveCbPic_Click(sender As Object, e As EventArgs) Handles BtnMoveCbPic.Click

    End Sub

    Private Sub BtnUpdCbPicDesc_Click(sender As Object, e As EventArgs) Handles BtnUpdCbPicDesc.Click

    End Sub

    Private Sub BtnUpdNewCbPage_Click(sender As Object, e As EventArgs) Handles BtnUpdNewCbPage.Click

    End Sub

    Private Sub BtnRmvRow_Click(sender As Object, e As EventArgs) Handles BtnRmvRow.Click
        RemoveSelectedRow()
    End Sub

    Private Sub RemoveSelectedRow()
        If DgvWarnings.SelectedRows.Count = 1 Then
            DgvWarnings.SelectedRows(0).Visible = False
            DgvWarnings.ClearSelection()
        End If
    End Sub

    Private Sub BtnUpdatePerson_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles BtnUpdatePerson.ContextMenuStripChanged

    End Sub

    Private Sub BtnUpdOldBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnUpdOldBotsdPost.Click

    End Sub

    Private Sub BtnReseqNewGroup_Click(sender As Object, e As EventArgs) Handles BtnReseqNewGroup.Click

    End Sub

    Private Sub BtnRemoveRow_Click(sender As Object, e As EventArgs) Handles BtnRemoveRow.Click
        RemoveSelectedRow()
    End Sub
#End Region



End Class
Imports System.Data.Common
Imports System.Text

Structure WikiBirthInfo
    Private _birthDate As CbDate
    Private _errordesc As String
    Private _wikiExtract As String
    Public Property WikiExtract() As String
        Get
            Return _wikiExtract
        End Get
        Set(ByVal value As String)
            _wikiExtract = value
        End Set
    End Property
    Public Property ErrorDesc() As String
        Get
            Return _errordesc
        End Get
        Set(ByVal value As String)
            _errordesc = value
        End Set
    End Property
    Public Property BirthDate() As CbDate
        Get
            Return _birthDate
        End Get
        Set(ByVal value As CbDate)
            _birthDate = value
        End Set
    End Property
    Sub New(pBirthDate As CbDate, pExtract As String, pErrorDesc As String)
        _birthDate = pBirthDate
        _wikiExtract = pExtract
        _errordesc = pErrorDesc
    End Sub
End Structure
Public NotInheritable Class FrmDateCheck
#Region "variables"
    Private personList As New List(Of Person)
    Private ReadOnly personTable As New List(Of Person)
    Private isLoadingTable As Boolean
    Private isWikiIdChanged As Boolean
    Private fromDate As Date
    Private toDate As Date
    Private oldPageLoadDay As String
    Private oldPageLoadMonth As String
    Private oldPageLoadYear As String
    Private newPageLoadDay As String
    Private newPageLoadMonth As String
    Private newPageLoadYear As String

#End Region
#Region "form event handlers"
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        ResetChecklistButtons()
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
        DisplayMessage("Found " & CStr(totalPeople) & " people", True)
        personTable.Clear()
        For Each _person In personList
            _ct += 1
            DisplayMessage(CStr(_ct) & " of " & CStr(totalPeople))
            Try
                Dim wikiId As String = ""
                If _person.Social IsNot Nothing Then
                    wikiId = _person.Social.WikiId
                End If
                Dim _wikiBirthInfo As WikiBirthInfo = GetWikiBirthDate(_person, wikiId)
                Dim _desc As String
                If _wikiBirthInfo.BirthDate IsNot Nothing AndAlso _wikiBirthInfo.BirthDate.IsValidDate Then
                    Dim _dateOfBirth As Date = _wikiBirthInfo.BirthDate.DateValue
                    If _dateOfBirth <> _person.DateOfBirth Then
                        AddXRow(_person, Format(_dateOfBirth, "dd MMM yyyy"), _wikiBirthInfo.WikiExtract, wikiId)
                        personTable.Add(_person)
                        _addedct += 1
                        If nudSelectCount.Value > 0 AndAlso _addedct = nudSelectCount.Value Then
                            Exit For
                        End If
                    End If
                Else
                    _desc = _wikiBirthInfo.ErrorDesc
                    AddXRow(_person, "", _wikiBirthInfo.WikiExtract, wikiId)
                    personTable.Add(_person)

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
                fromDate = CDate(oRow.Cells(xBirth.Name).Value)
                Dim wikiDate As String = oRow.Cells(xWikiBirth.Name).Value
                If Not String.IsNullOrEmpty(wikiDate) AndAlso IsDate(wikiDate) Then
                    toDate = CDate(wikiDate)
                    TxtToDay.Text = Format(toDate, "dd")
                    TxtToMonth.Text = Format(toDate, "MM")
                    TxtToYear.Text = Format(toDate, "yyyy")
                End If
                TxtFromDay.Text = Format(fromDate, "dd")
                TxtFromMonth.Text = Format(fromDate, "MM")
                TxtFromYear.Text = Format(fromDate, "yyyy")
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
                '
                ' BotSD work required
                '
                Dim oBotsdId As Integer = oPerson.Social.Botsd
                Dim oBotsdRow As CelebrityBirthdayDataSet.BotSDRow = GetBotsd(oBotsdId)
                Dim oBotsdPostNo As Integer = If(oBotsdRow Is Nothing, 0, oBotsdRow.btsdPostNo)
                Dim oBotsdRowCollection As DataRowCollection = GetBotsdViewByPostNo(oBotsdPostNo)
                LblBotsdPostNo.Text = "#" & CStr(oBotsdPostNo)
                '
                ' Remove BotSD id
                '
                BtnRmvBotsdId.Visible = True
                ' 
                ' List other people on the same day
                '
                Dim otherBotsd As New List(Of Integer)
                For Each oViewRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow In oBotsdRowCollection
                    If Not oViewRow.IspersonIdNull AndAlso oViewRow.personId <> oPerson.Id Then
                        otherBotsd.Add(oViewRow.personId)
                    End If
                Next
                '
                'If only one person will remain - remove their botsd id too
                '
                If otherBotsd.Count = 1 Then
                    LblOthPersonId.Text = CStr(otherBotsd(0))
                    BtnRmvOtherBotsdId.Visible = True
                End If
                If otherBotsd.Count < 2 Then
                    ' No longert a BotSD
                    BtnRmvBotsdRecord.Visible = True
                    LblBotsdId.Text = CStr(oBotsdId)
                    BtnRmvOldBotsdPost.Visible = True
                    LblBotsdUrl.Text = oBotsdRow.btsdUrl

                Else
                    ' still a BotSD
                    BtnUpdOldBotsdPost.Visible = True
                    LblBotsdUpdUrl.Text = oBotsdRow.btsdUrl
                End If
                ' list will need changing
                BtnUpdOldBotsdList.Visible = True
                LblBotsdListUrl.Text = My.Settings.botsdWordPressUrl & Format(fromDate, "MMMM") & "/"
                isOldReseqRequired = True
            End If
            BtnUpdatePerson.Visible = True
            LblUpdPerson.Text = CStr(oPerson.Id)
            '
            ' After person has been updated, BotSD group needs resequencing
            '
            If isOldReseqRequired Then
                BtnReseqOldGroup.Visible = True
                LblReseqOld.Text = "reqd"
            End If
            'Find any existing people on intended new dob
            Dim oNewGroup As New CelebrityBirthdayDataSet.PersonDataTable
            Try
                oNewGroup = GetPeopleByDateofBirth(toDate.Year, toDate.Month, toDate.Day)
            Catch ex As Exception
                DisplayMessage("Invalid To Date")
            End Try
            ' If this person will be in a BotSD group
            If oNewGroup.Rows.Count > 0 Then
                BtnReseqNewGroup.Visible = True
                LblReseqNew.Text = "reqd"
                BtnUpdateNewBotsdPost.Visible = True
                LblNewBotsdUrl.Text = GetGroupUrl(oNewGroup)
                BtnUpdNewBotsdList.Visible = True
                LblNewListUrl.Text = My.Settings.botsdWordPressUrl & Format(toDate, "MMMM") & "/"
            End If
            Dim isYearOnlyChange As Boolean = TxtFromDay.Text = TxtToDay.Text AndAlso TxtFromMonth.Text = TxtToMonth.Text
            '
            ' If only the year of birth is changing, the person will stay on the same CB post
            ' The picture may need to be moved
            ' otherwise 
            ' The both posts and pictures need changing
            If isYearOnlyChange Then
                BtnMoveCbPic.Visible = True
                LblMoveImage.Text = GetNewPageLoadDate()
            Else
                BtnRmvOldPicture.Visible = True
                LblRmvImage.Text = GetOldPageLoadDate()
                BtnUpdOldCbPage.Visible = True
                LblUpdOldPost.Text = LblRmvImage.Text
                BtnAddCbPic.Visible = True
                LblAddImage.Text = GetNewPageLoadDate()
            End If
            BtnUpdCbPicDesc.Visible = True
            LblImageName.Text = oPerson.Image.ImageFileName
            BtnUpdNewCbPage.Visible = True
            LblUpdNewPost.Text = GetNewPageLoadDate()
            BtnRmvRow.Visible = True
        End If
    End Sub
    Private Function GetOldPageLoadDate() As String
        oldPageLoadYear = ""
        oldPageLoadMonth = ""
        oldPageLoadDay = ""
        Dim oDrow As CelebrityBirthdayDataSet.DatesRow = GetDatesRow(fromDate.Day, fromDate.Month, "P")
        If oDrow IsNot Nothing Then
            oldPageLoadYear = If(oDrow.IsuploadyearNull, "", oDrow.uploadyear)
            oldPageLoadMonth = If(oDrow.IsuploadmonthNull, "", oDrow.uploadmonth)
            oldPageLoadDay = If(oDrow.IsuploaddayNull, "", oDrow.uploadday)
        End If
        Return oldPageLoadDay & "-" & oldPageLoadMonth & "-" & oldPageLoadYear
    End Function
    Private Function GetNewPageLoadDate() As String
        newPageLoadYear = ""
        newPageLoadMonth = ""
        newPageLoadDay = ""
        Dim oDrow As CelebrityBirthdayDataSet.DatesRow = GetDatesRow(toDate.Day, toDate.Month, "P")
        If oDrow IsNot Nothing Then
            newPageLoadYear = If(oDrow.IsuploadyearNull, "", oDrow.uploadyear)
            newPageLoadMonth = If(oDrow.IsuploadmonthNull, "", oDrow.uploadmonth)
            newPageLoadDay = If(oDrow.IsuploaddayNull, "", oDrow.uploadday)
        End If
        Return newPageLoadDay & "-" & newPageLoadMonth & "-" & newPageLoadYear
    End Function
    Private Shared Function GetGroupUrl(oNewGroup As CelebrityBirthdayDataSet.PersonDataTable) As String
        Dim newUrl As String = ""
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oNewGroup.Rows
            Dim _person As Person = New Person(oRow)
            If _person.Social.Botsd > 0 Then
                Dim _row As CelebrityBirthdayDataSet.BotSDRow = GetBotsd(_person.Social.Botsd)
                If _row IsNot Nothing Then
                    newUrl = _row.btsdUrl
                    Exit For
                End If
            End If
        Next
        Return newUrl
    End Function

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
    Private Sub BtnWikiOpen_Click(sender As Object, e As EventArgs) Handles BtnWikiOpen.Click
        If Not String.IsNullOrEmpty(TxtWikiId.Text) Then
            DisplayMessage("Opening Wikipedia", True)
            Process.Start(My.Resources.WIKIURL & TxtWikiId.Text.Trim)
        End If
    End Sub
    Private Sub Date_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        ClearPersonDetails()
        DisplayMessage("")
    End Sub
    Private Sub FrmDateCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.datecheckformpos)
        ResetChecklistButtons()
    End Sub
    Private Sub FrmDateCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.datecheckformpos = SetFormPos(Me)
        My.Settings.Save()
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
                _botsd.ThisDay = toDate.Day
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
    Private Shared Function GetWikiBirthDate(_person As Person, Optional wikiId As String = "") As WikiBirthInfo
        Dim _birthDate As CbDate = Nothing
        Dim _wikiBirthInfo As New WikiBirthInfo(_birthDate, GetWikiExtract(wikiId, 3), "")
        Try
            Dim _dates As List(Of CbDate) = GetPersonDatesFromWiki(_wikiBirthInfo.WikiExtract, _person)
            If _dates.Count > 0 Then
                Dim wikiDateOfBirth As CbDate = _dates(0)
                Dim wikiDateOfDeath As CbDate = New CbDate()
                If _dates.Count > 1 Then
                    wikiDateOfDeath = _dates(1)
                End If
                _wikiBirthInfo.BirthDate = wikiDateOfBirth
                'Try
                '    If Not String.IsNullOrEmpty(_dates(0).DateString) Then
                '        Dim firstPart As String = _dates(0).DateString.Trim
                '        firstPart = firstPart.Replace("N.", "").Replace("S.", "").Replace("(", "").Replace(")", "").Replace("O.", "").Replace(";", "").Replace("  ", " ")
                '        Dim DateParts As String() = Split(firstPart, " ")
                '        Dim DatePartsList As List(Of String) = DateParts.ToList

                '        For bitNo As Integer = DatePartsList.Count - 1 To 0 Step -1
                '            If IsNumeric(DatePartsList(bitNo)) Then Exit For
                '            DatePartsList.RemoveAt(bitNo)
                '        Next
                '        If DatePartsList.Count = 0 Then
                '            _wikiBirthInfo.ErrorDesc = "No date present"
                '        Else
                '            Dim firstDate As String = If(DatePartsList.Count > 2, DateParts(DatePartsList.Count - 3), 1) & " " & If(DatePartsList.Count > 1, DatePartsList(DatePartsList.Count - 2), "January") & " " & If(DatePartsList.Count > 0, DatePartsList(DatePartsList.Count - 1), "1900")
                '            If IsDate(firstDate) Then
                '                _wikiBirthInfo.BirthDate = New CbDate(firstDate)
                '            Else
                '                _wikiBirthInfo.ErrorDesc = "Not a date: " & firstDate
                '            End If
                '        End If
                '    Else
                '        _wikiBirthInfo.ErrorDesc = "No date present"
                '    End If
                'Catch ex As OverflowException
                '    _wikiBirthInfo.ErrorDesc = "Not a date: " & _dates(0).DateString
                'End Try
            Else
                _wikiBirthInfo.ErrorDesc = "No dates found in wiki extract"
            End If

        Catch ex As ArgumentException
            _wikiBirthInfo.ErrorDesc = ex.Message
        Catch ex As System.Security.SecurityException
            _wikiBirthInfo.ErrorDesc = ex.Message
        End Try
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
        HideChecklistButtons()
        ClearChecklistLabels()
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
        BtnUpdNewBotsdList.Visible = False
        BtnRmvOldPicture.Visible = False
        BtnUpdOldCbPage.Visible = False
        BtnAddCbPic.Visible = False
        BtnMoveCbPic.Visible = False
        BtnUpdCbPicDesc.Visible = False
        BtnUpdNewCbPage.Visible = False
        BtnRmvRow.Visible = False
    End Sub
    Private Sub ClearChecklistLabels()
        LblBotsdPostNo.Text = ""
        LblOthPersonId.Text = ""
        LblBotsdId.Text = ""
        LblBotsdUrl.Text = ""
        LblBotsdUpdUrl.Text = ""
        LblBotsdListUrl.Text = ""
        LblUpdPerson.Text = ""
        LblReseqOld.Text = ""
        LblReseqNew.Text = ""
        LblNewListUrl.Text = ""
        LblNewBotsdUrl.Text = ""
        LblRmvImage.Text = ""
        LblAddImage.Text = ""
        LblImageName.Text = ""
        LblUpdNewPost.Text = ""
        LblUpdOldPost.Text = ""
        LblMoveImage.Text = ""
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
                    LblBotsdPostNo.Text = "done"
                Else
                    DisplayMessage("No BotSD id to remove", True)
                    LblBotsdPostNo.Text = "err"
                End If
            Else
                DisplayMessage("No social details", True)
                LblBotsdPostNo.Text = "err"
            End If
        Else
            DisplayMessage("No person selected", True)
            LblBotsdPostNo.Text = "err"
        End If

    End Sub

    Private Sub BtnRmvOtherBotsdId_Click(sender As Object, e As EventArgs) Handles BtnRmvOtherBotsdId.Click
        DisplayMessage("Removing other BotSD id", True)
        If Not String.IsNullOrEmpty(LblOthPersonId.Text) AndAlso IsNumeric(LblOthPersonId.Text) Then
            UpdateBotsdId(CInt(LblOthPersonId.Text), 0)
            DisplayMessage("Removed BotSD Id from person " & CStr(LblOthPersonId.Text))
            LblOthPersonId.Text = "done"
        Else
            DisplayMessage("No person identified", True)
            LblOthPersonId.Text = "err"
        End If
    End Sub

    Private Sub BtnRmvBotsdRecord_Click(sender As Object, e As EventArgs) Handles BtnRmvBotsdRecord.Click
        DisplayMessage("Removing BotSD record", True)
        If Not String.IsNullOrEmpty(LblBotsdId.Text) AndAlso IsNumeric(LblBotsdId.Text) Then
            Dim botsdId As Integer = CInt(LblBotsdId.Text)
            If DeleteBotsdById(botsdId) = 1 Then
                LblBotsdId.Text = "done"
            Else
                LblBotsdId.Text = "failed"
            End If
        Else
            DisplayMessage("No post identified", True)
            LblBotsdId.Text = "err"
        End If
    End Sub
    Private Sub BtnRmvOldBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnRmvOldBotsdPost.Click
        DisplayMessage("Opening old BotSD post for removal")
        Try
            Process.Start(LblBotsdUrl.Text)
            LblBotsdUrl.Text = "open"
        Catch ex As ComponentModel.Win32Exception
            LblBotsdUrl.Text = "invalid"
        End Try
    End Sub
    Private Sub BtnUpdOldBotsdList_Click(sender As Object, e As EventArgs) Handles BtnUpdOldBotsdList.Click
        DisplayMessage("Opening old BotSD list for amendment")
        Try
            Process.Start(LblBotsdListUrl.Text)
            LblBotsdListUrl.Text = "open"
        Catch ex As ComponentModel.Win32Exception
            LblBotsdListUrl.Text = "invalid"
        End Try
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = fromDate.Day
            _botsd.ThisMonth = fromDate.Month
            _botsd.ShowDialog()
        End Using
    End Sub
    Private Sub BtnUpdatePerson_Click(sender As Object, e As EventArgs) Handles BtnUpdatePerson.Click
        If DgvWarnings.SelectedRows.Count = 1 Then
            Dim oPerson As Person = personTable(DgvWarnings.SelectedRows(0).Index)
            If Not String.IsNullOrEmpty(TxtToYear.Text) And
                Not String.IsNullOrEmpty(TxtToMonth.Text) And
                Not String.IsNullOrEmpty(TxtToDay.Text) And
                IsDate(TxtToDay.Text & "/" & TxtToMonth.Text & "/" & TxtToYear.Text) Then
                DisplayMessage("Updating DoB and text for " & TxtFullName.Text, True)
                UpdateDateOfBirth(oPerson.Id, toDate.Day, toDate.Month, toDate.Year, TxtFullDesc.Text)
                oPerson = GetFullPersonById(oPerson.Id, False)
                DisplayMessage("Updated " & CStr(oPerson.Id), True)
                LblUpdPerson.Text = "done"
            End If
        End If
    End Sub
    Private Sub BtnReseqOldGroup_Click(sender As Object, e As EventArgs) Handles BtnReseqOldGroup.Click
        Dim oldGroup As CelebrityBirthdayDataSet.PersonDataTable
        oldGroup = GetPeopleByDateofBirth(fromDate.Year, fromDate.Month, fromDate.Day)
        Dim newSeq As Integer = 0
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oldGroup
            UpdateSortSeq(oRow.id, newSeq)
            newSeq += 1
        Next
        LblReseqOld.Text = "done"
        DisplayMessage("Resequenced old BotSD group", True)
    End Sub
    Private Sub BtnUpdateNewBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnUpdateNewBotsdPost.Click
        DisplayMessage("Opening new BotSD post for amendment")
        Try
            If Not String.IsNullOrEmpty(LblNewBotsdUrl.Text) Then
                Process.Start(LblNewBotsdUrl.Text)
                LblNewBotsdUrl.Text = "open"
            Else
                LblNewBotsdUrl.Text = "n/a"
            End If
        Catch ex As ComponentModel.Win32Exception
            LblNewBotsdUrl.Text = "invalid"
        End Try
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = toDate.Day
            _botsd.ThisMonth = toDate.Month
            _botsd.ShowDialog()
        End Using
    End Sub
    Private Sub BtnUpdNewBotsdList_Click(sender As Object, e As EventArgs) Handles BtnUpdNewBotsdList.Click
        DisplayMessage("Opening new BotSD list for amendment")
        Try
            Process.Start(LblNewListUrl.Text)
            LblNewListUrl.Text = "open"
        Catch ex As ComponentModel.Win32Exception
            LblNewListUrl.Text = "invalid"
        End Try
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = toDate.Day
            _botsd.ThisMonth = toDate.Month
            _botsd.ShowDialog()
        End Using

    End Sub
    Private Sub BtnRmvOldPicture_Click(sender As Object, e As EventArgs) Handles BtnRmvOldPicture.Click, BtnUpdOldCbPage.Click
        DisplayMessage("Updating old CB post")
        Dim _selMonth As String = Format(fromDate, "MMMM")
        Dim _selDay As String = CStr(fromDate.Day)
        Dim sUrl As String = GetWordPressMonthUrl(oldPageLoadYear, oldPageLoadMonth, oldPageLoadDay, _selDay, _selMonth.ToLower(myCultureInfo))
        Process.Start(sUrl)
        LblRmvImage.Text = "open"
        LblUpdOldPost.Text = "open"
        OpenWordPress(fromDate.Day, fromDate.Month)
    End Sub

    Private Sub BtnUpdCbPicDesc_Click(sender As Object, e As EventArgs) Handles BtnUpdCbPicDesc.Click
        DisplayMessage("Updating CB image description")
        Dim _selMonth As String = Format(toDate, "MMMM")
        Dim _selDay As String = CStr(toDate.Day)
        Dim sUrl As String = GetWordPressMonthUrl(newPageLoadYear, newPageLoadMonth, newPageLoadDay, _selDay, _selMonth.ToLower(myCultureInfo)) & LblImageName.Text & "/"
        Process.Start(sUrl)
        LblImageName.Text = "open"
    End Sub
    Private Sub BtnUpdNewCbPage_Click(sender As Object, e As EventArgs) Handles BtnUpdNewCbPage.Click, BtnAddCbPic.Click, BtnMoveCbPic.Click
        DisplayMessage("Updating new CB post")
        TxtWiki.Text = GetPersonContext()
        Dim _selMonth As String = Format(toDate, "MMMM")
        Dim _selDay As String = CStr(toDate.Day)
        Dim sUrl As String = GetWordPressMonthUrl(newPageLoadYear, newPageLoadMonth, newPageLoadDay, _selDay, _selMonth.ToLower(myCultureInfo))
        Process.Start(sUrl)
        If Not String.IsNullOrEmpty(LblAddImage.Text) Then
            LblAddImage.Text = "open"
        End If
        If Not String.IsNullOrEmpty(LblMoveImage.Text) Then
            LblMoveImage.Text = "open"
        End If
        LblUpdNewPost.Text = "open"
        OpenWordPress(toDate.Day, toDate.Month)
    End Sub

    Private Function GetPersonContext() As String
        Dim _list As New StringBuilder
        If DgvWarnings.SelectedRows.Count = 1 Then
            Dim _name As String = DgvWarnings.SelectedRows(0).Cells(xName.Name).Value
            Dim personTable As List(Of Person) = FindPeopleByDate(toDate.Day, toDate.Month, False, False)
            Dim thisPerson As Person = GetPersonById(CInt(LblId.Text))
            Dim _index As Integer = personTable.FindIndex(Function(_person As Person) _person.Name = _name)
            If _index > 0 Then
                _list.Append(CStr(personTable(_index - 1).BirthYear)).Append(" "c).Append(personTable(_index - 1).Name).Append(vbCrLf)
            End If
            _list.Append(CStr(personTable(_index).BirthYear)).Append(" "c).Append(personTable(_index).Name).Append(vbCrLf)
            If _index < personTable.Count - 1 Then
                _list.Append(CStr(personTable(_index + 1).BirthYear)).Append(" "c).Append(personTable(_index + 1).Name).Append(vbCrLf)
            End If
        End If
        Return _list.ToString
    End Function

    Private Sub BtnRmvRow_Click(sender As Object, e As EventArgs) Handles BtnRmvRow.Click
        RemoveSelectedRow()
        ResetChecklistButtons()
    End Sub

    Private Sub RemoveSelectedRow()
        If DgvWarnings.SelectedRows.Count = 1 Then
            DgvWarnings.SelectedRows(0).Visible = False
            DgvWarnings.ClearSelection()
        End If
    End Sub

    Private Sub BtnUpdOldBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnUpdOldBotsdPost.Click
        DisplayMessage("Opening old BotSD post for amendment")
        Try
            Process.Start(LblBotsdUpdUrl.Text)
            LblBotsdUpdUrl.Text = "open"
        Catch ex As ComponentModel.Win32Exception
            LblBotsdUpdUrl.Text = "invalid"
        End Try
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = CInt(TxtFromDay.Text)
            _botsd.ThisMonth = CInt(TxtFromMonth.Text)
            _botsd.ShowDialog()
        End Using
    End Sub

    Private Sub BtnReseqNewGroup_Click(sender As Object, e As EventArgs) Handles BtnReseqNewGroup.Click
        Dim newGroup As CelebrityBirthdayDataSet.PersonDataTable
        newGroup = GetPeopleByDateofBirth(toDate.Year, toDate.Month, toDate.Day)
        Dim newSeq As Integer = 0
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In newGroup
            UpdateSortSeq(oRow.id, newSeq)
            newSeq += 1
        Next
        LblReseqNew.Text = "done"
        DisplayMessage("Resequenced new BotSD group", True)
    End Sub

    Private Sub BtnRemoveRow_Click(sender As Object, e As EventArgs) Handles BtnRemoveRow.Click
        RemoveSelectedRow()
        ResetChecklistButtons()
    End Sub

    Private Sub LblBotsdUrl_Click(sender As Object, e As EventArgs) Handles LblBotsdUrl.DoubleClick,
                                                                            LblBotsdUpdUrl.DoubleClick,
                                                                            LblBotsdListUrl.DoubleClick,
                                                                            LblNewBotsdUrl.DoubleClick,
                                                                            LblRmvImage.DoubleClick,
                                                                            LblAddImage.DoubleClick,
                                                                            LblNewListUrl.DoubleClick,
                                                                            LblRmvImage.DoubleClick,
                                                                            LblUpdOldPost.DoubleClick,
                                                                            LblAddImage.DoubleClick,
                                                                            LblMoveImage.DoubleClick,
                                                                            LblUpdNewPost.DoubleClick,
                                                                            LblImageName.DoubleClick
        Dim _label As Label = CType(sender, Label)
        _label.Text = "done"
    End Sub
    Private Sub BtnCopyName_Click(sender As Object, e As EventArgs) Handles BtnCopyName.Click
        If DgvWarnings.SelectedRows.Count = 1 Then
            Clipboard.SetText(DgvWarnings.SelectedRows(0).Cells(xName.Name).Value)
        End If
    End Sub


#End Region
End Class
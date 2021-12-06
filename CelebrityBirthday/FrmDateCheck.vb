Imports System.Data.Common
Imports System.Text

Structure WikiBirthInfo
    Private _wikiDates As CbDates
    Private _errordesc As String
    Private _wikiExtract As String
    Private _isNoExtract As Boolean
    Private _isNoDates As Boolean
    Public Property IsNoDates() As Boolean
        Get
            Return _isNoDates
        End Get
        Set(ByVal value As Boolean)
            _isNoDates = value
        End Set
    End Property
    Public Property IsNoExtract() As Boolean
        Get
            Return _isNoExtract
        End Get
        Set(ByVal value As Boolean)
            _isNoExtract = value
        End Set
    End Property
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
    Public Property WikiDates() As CbDates
        Get
            Return _wikiDates
        End Get
        Set(ByVal value As CbDates)
            _wikiDates = value
        End Set
    End Property
    Sub New(pBirthDate As CbDates, pExtract As String, pErrorDesc As String)
        _wikiDates = pBirthDate
        _wikiExtract = pExtract
        _errordesc = pErrorDesc
        _isNoExtract = False
        _isNoDates = False

    End Sub
End Structure
Structure CheckListActionButton
    Private _actionButton As Button
    Private _actionText As String
    Private _resultText As String
    Private _resultStyle As DlgShowText.MessageStyle
    Public Property ResultStyle() As DlgShowText.MessageStyle
        Get
            Return _resultStyle
        End Get
        Set(ByVal value As DlgShowText.MessageStyle)
            _resultStyle = value
        End Set
    End Property
    Public Property ResultText() As String
        Get
            Return _resultText
        End Get
        Set(ByVal value As String)
            _resultText = value
        End Set
    End Property
    Public Property ActionText() As String
        Get
            Return _actionText
        End Get
        Set(ByVal value As String)
            _actionText = value
        End Set
    End Property
    Public Property ActionButton() As Button
        Get
            Return _actionButton
        End Get
        Set(ByVal value As Button)
            _actionButton = value
        End Set
    End Property
    Sub New(pButton As Button, pText As String)
        _actionButton = pButton
        _actionText = pText
        _resultText = ""
        _resultStyle = DlgShowText.MessageStyle.none
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
    Private abBotsdPostNo As CheckListActionButton
    Private abOthPersonId As CheckListActionButton
    Private abBotsdId As CheckListActionButton
    Private abBotsdUrl As CheckListActionButton
    Private abBotsdUpdUrl As CheckListActionButton
    Private abBotsdListUrl As CheckListActionButton
    Private abUpdPerson As CheckListActionButton
    Private abReseqOld As CheckListActionButton
    Private abReseqNew As CheckListActionButton
    Private abNewListUrl As CheckListActionButton
    Private abNewBotsdUrl As CheckListActionButton
    Private abRmvImage As CheckListActionButton
    Private abAddImg As CheckListActionButton
    Private abImgDesc As CheckListActionButton
    Private abUpdNewPost As CheckListActionButton
    Private abUpdOldPost As CheckListActionButton
    Private abMoveImg As CheckListActionButton
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
                    ShowStatus("Finding everybody", True)
                    personList = FindEverybody()
                End If
            ElseIf cboDay.SelectedIndex < 0 Then
                ShowStatus("Finding persons for " & CStr(cboMonth.SelectedItem), True)
                personList = FindPeopleByDate(-1, cboMonth.SelectedIndex + 1, False, False)
            Else
                ShowStatus("Finding persons for " & CStr(cboDay.SelectedIndex + 1) & "/" & CStr(cboMonth.SelectedIndex + 1), True)
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
        ShowStatus("Found " & CStr(totalPeople) & " people", True)
        personTable.Clear()
        For Each _person In personList
            _ct += 1
            ShowStatus(CStr(_ct) & " of " & CStr(totalPeople))
            Try
                Dim wikiId As String = ""
                If _person.Social IsNot Nothing Then
                    wikiId = _person.Social.WikiId
                End If
                Dim _wikiBirthInfo As WikiBirthInfo = GetWikiBirthDate(_person, wikiId)
                If _wikiBirthInfo.WikiDates IsNot Nothing AndAlso _wikiBirthInfo.WikiDates.BirthDate.IsValidDate Then
                    Dim _dateOfBirth As Date = _wikiBirthInfo.WikiDates.BirthDate.DateValue
                    If _dateOfBirth <> _person.DateOfBirth Then
                        Dim isAudit As Boolean = AuditUtil.GetDobChanges(_person.Id).Rows.Count > 0
                        AddXRow(_person, Format(_dateOfBirth, "dd MMM yyyy"), _wikiBirthInfo.WikiExtract, wikiId, isAudit)
                        personTable.Add(_person)
                        _addedct += 1
                        If nudSelectCount.Value > 0 AndAlso _addedct = nudSelectCount.Value Then
                            Exit For
                        End If
                    End If
                Else
                    If ChkNoExtract.Checked And _wikiBirthInfo.IsNoExtract Then
                        AddErrorRow(_person, wikiId, _wikiBirthInfo)
                    End If
                    If ChkNoDates.Checked And _wikiBirthInfo.IsNoDates Then
                        AddErrorRow(_person, wikiId, _wikiBirthInfo)
                    End If
                End If
            Catch ex As ArgumentException
                LogUtil.Problem("Exception during list load : " & ex.Message)
                If MsgBox(_person.Name & vbCrLf & "Exception during table load" & vbCrLf & ex.Message & vbCrLf & "OK to continue?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Error") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End Try
        Next
        DgvWarnings.ClearSelection()
        ShowStatus("Selection complete")
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
                '
                ' Remove BotSD id
                '
                ShowButtonToRemoveBotsdId(oBotsdPostNo)             ' dB update
                ' 
                ' List other people born on the same day
                '
                Dim otherBotsd As New List(Of Integer)
                For Each oViewRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow In oBotsdRowCollection
                    If Not oViewRow.IspersonIdNull AndAlso oViewRow.personId <> oPerson.Id Then
                        otherBotsd.Add(oViewRow.personId)
                    End If
                Next
                '
                ' If only one person will remain - remove their botsd id too
                '
                If otherBotsd.Count = 1 Then
                    ShowButtonToRemoveOtherBotsdId(otherBotsd)      ' dB update
                End If
                '
                ' If no longer a BotSD
                '
                If otherBotsd.Count < 2 Then
                    ShowButtonToRemoveBotsdRecord(oBotsdId)         ' dB Update
                    ShowButtonToRemoveBotsdPost(oBotsdRow)          ' Web update
                Else
                    '
                    ' still a BotSD
                    '
                    ShowButtonToUpdateBotsdPost(oBotsdRow)          ' Web update
                End If
                ' list will need changing
                ShowButtonToUpdateBotsdList()                       ' Web update
                isOldReseqRequired = True
            End If
            ShowButtonToUpdatePerson(oPerson)                       ' dB update
            '
            ' After person has been updated, BotSD group needs resequencing
            '
            If isOldReseqRequired Then
                ShowButtonToResequenceOldGroup()                    ' dB update
            End If
            'Find any existing people on intended new dob
            Dim oNewGroup As New CelebrityBirthdayDataSet.PersonDataTable
            Try
                oNewGroup = GetPeopleByDateofBirth(toDate.Year, toDate.Month, toDate.Day)
            Catch ex As Exception
                ShowStatus("Invalid To Date")
            End Try
            ' If this person will be in a BotSD group
            If oNewGroup.Rows.Count > 0 Then
                ShowButtonToResequenceNewGroup()                    ' dB update
                ShowButtonToUpdateNewBotsdPost(oNewGroup)           ' Web update
                ShowButtonToUpdateNewBotsdList()                    ' Web update
            End If
            Dim isYearOnlyChange As Boolean = TxtFromDay.Text = TxtToDay.Text AndAlso TxtFromMonth.Text = TxtToMonth.Text
            '
            ' If only the year of birth is changing, the person will stay on the same CB post
            ' The picture may need to be moved
            ' otherwise 
            ' The both posts and pictures need changing
            If isYearOnlyChange Then
                ShowButtonToMovePicture()                           ' Web update
            Else
                ShowButtonToRemoveOldPicture()                      ' Web update
                ShowButtonToUpdateOldPage()                         ' Web update
                ShowButtonToAddPicture()                            ' Web update
            End If
            ShowButtonToUpdatePictureDescription(oPerson)           ' Web update
            ShowButtonToUpdateNewPost()                             ' Web update
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
        ShowStatus("Date copied to full desc", True)
    End Sub
    Private Sub BtnClearDetails_Click(sender As Object, e As EventArgs) Handles BtnClearDetails.Click
        ClearPersonDetails()
    End Sub
    Private Sub TxtWikiId_TextChanged(sender As Object, e As EventArgs) Handles TxtWikiId.TextChanged
        isWikiIdChanged = True
    End Sub
    Private Sub BtnWikiUpdate_Click(sender As Object, e As EventArgs) Handles BtnWikiUpdate.Click
        If isWikiIdChanged Then
            ShowStatus("Updating wiki id", True)
            UpdateWikiId(CInt(LblId.Text), TxtWikiId.Text)
            ShowStatus(LblId.Text & "Wiki Id Updated to " & TxtWikiId.Text, True)
        End If
    End Sub
    Private Sub BtnWikiOpen_Click(sender As Object, e As EventArgs) Handles BtnWikiOpen.Click
        If Not String.IsNullOrEmpty(TxtWikiId.Text) Then
            ShowStatus("Opening Wikipedia", True)
            Try
                Process.Start(My.Resources.WIKIURL & TxtWikiId.Text.Trim)
            Catch ex As InvalidOperationException
                ShowStatus("Error opening wiki " & TxtWikiId.Text, True)
            Catch ex As ComponentModel.Win32Exception
                ShowStatus("Error opening wiki " & TxtWikiId.Text, True)
            End Try
        End If
    End Sub
    Private Sub Date_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        ClearPersonDetails()
        ShowStatus("")
    End Sub
    Private Sub FrmDateCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        GetFormPos(Me, My.Settings.datecheckformpos)
        CreateActionButtons()
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
            wpText = GetPictureText(oPerson)
        End If
        Clipboard.SetText(wpText)
        oPerson.Dispose()
    End Sub


    Private Sub BtnBotSD_Click(sender As Object, e As EventArgs) Handles BtnBotSD.Click
        ShowStatus("Born on the same day update", True)
        Using _botsd As New FrmBotsd
            If cboDay.SelectedIndex < 0 Then
                _botsd.ThisDay = toDate.Day
            Else
                _botsd.ThisDay = cboDay.SelectedIndex + 1
            End If
            _botsd.ThisMonth = cboMonth.SelectedIndex + 1
            _botsd.ShowDialog()
        End Using
        ShowStatus("")
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
    Private Function GetPictureText(oPerson As Person) As String
        Dim wpText As String
        ShowStatus("Generating WordPress description for " & TxtFullName.Text, True)
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
        Return wpText
    End Function
    Private Shared Function GetWikiBirthDate(_person As Person, Optional wikiId As String = "") As WikiBirthInfo
        Dim _wikiBirthInfo As New WikiBirthInfo(Nothing, GetWikiExtract(wikiId, 3), "")
        If String.IsNullOrEmpty(_wikiBirthInfo.WikiExtract.Trim) Then
            _wikiBirthInfo.ErrorDesc = "No wiki extract available for " & _person.Name
            _wikiBirthInfo.IsNoExtract = True
        Else
            Dim _wikiExtract As String = _wikiBirthInfo.WikiExtract
            Dim datesFound As CbDates = Nothing
            Dim cbdates As List(Of CbDates) = ExtractCbdatesFromWikiExtract(_wikiExtract)
            If cbdates.Count > 0 Then
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
                    If datesFound Is Nothing Then
                        datesFound = cbdates(0)
                    End If
                End If
                _wikiBirthInfo.WikiDates = datesFound
            Else
                LogUtil.Problem("Cannot find dates for " & _person.Name)
                _wikiBirthInfo.ErrorDesc = "Cannot find dates for " & _person.Name
                _wikiBirthInfo.IsNoDates = True
            End If
        End If
        Return _wikiBirthInfo
    End Function
    Private Sub ShowStatus(oText As String, Optional isLogged As Boolean = False)
        lblStatus.Text = oText
        StatusStrip1.Refresh()
        If isLogged Then LogUtil.Info(oText, MyBase.Name)
    End Sub
    Private Sub DisplayMessage(oButton As CheckListActionButton)
        Using _msgbox As New DlgShowText
            _msgbox.Message = oButton.ResultText
            _msgbox.Style = oButton.ResultStyle
            _msgbox.ShowDialog()
        End Using
    End Sub
    Private Function AddXRow(oPerson As Person, oDateOfBirth As String, oDesc As String, oWikiId As String, isAudit As Boolean) As DataGridViewRow
        Dim _newRow As DataGridViewRow = DgvWarnings.Rows(DgvWarnings.Rows.Add())
        _newRow.Height = If(ChkShowImage.Checked, 65, DgvWarnings.RowTemplate.Height)
        _newRow.Cells(xId.Name).Value = oPerson.Id
        _newRow.Cells(xName.Name).Value = oPerson.Name
        _newRow.Cells(xBirth.Name).Value = If(oPerson.DateOfBirth Is Nothing, "", Format(oPerson.DateOfBirth, "dd MMM yyyy"))
        _newRow.Cells(xWikiBirth.Name).Value = oDateOfBirth
        _newRow.Cells(xWikiExtract.Name).Value = If(String.IsNullOrEmpty(oDesc), "", oDesc)
        _newRow.Cells(xPersonDescription.Name).Value = oPerson.Description
        _newRow.Cells(xWikiId.Name).Value = If(String.IsNullOrEmpty(oWikiId), "", oWikiId)
        _newRow.Cells(xAudit.Name).Value = If(isAudit, "*", "")
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
        ShowStatus("Opening WordPress form for " & CStr(pDay) & "/" & CStr(pMonth), True)
        Using _wordpress As New FrmWordPress
            _wordpress.DaySelection = pDay
            _wordpress.MonthSelection = pMonth
            _wordpress.ShowDialog()
        End Using
        ShowStatus("")
    End Sub
    Private Sub ResetChecklistButtons()
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
        UnsetButton(abBotsdPostNo)
        UnsetButton(abOthPersonId)
        UnsetButton(abBotsdId)
        UnsetButton(abBotsdUrl)
        UnsetButton(abBotsdUpdUrl)
        UnsetButton(abBotsdListUrl)
        UnsetButton(abUpdPerson)
        UnsetButton(abReseqOld)
        UnsetButton(abReseqNew)
        UnsetButton(abNewListUrl)
        UnsetButton(abNewBotsdUrl)
        UnsetButton(abRmvImage)
        UnsetButton(abAddImg)
        UnsetButton(abImgDesc)
        UnsetButton(abUpdNewPost)
        UnsetButton(abUpdOldPost)
        UnsetButton(abMoveImg)
    End Sub
    Private Sub AddErrorRow(_person As Person, wikiId As String, _wikiBirthInfo As WikiBirthInfo)
        Dim _desc As String = "** " & _wikiBirthInfo.ErrorDesc & " **"
        AddXRow(_person, "", _desc & vbCrLf & _wikiBirthInfo.WikiExtract, wikiId, False)
        personTable.Add(_person)
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
            Dim _person As New Person(oRow)
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
#End Region
#Region "checklist"
    Private Sub BtnRmvBotsdId_Click(sender As Object, e As EventArgs) Handles BtnRmvBotsdId.Click
        ShowStatus("Removing BotSD id", True)
        If DgvWarnings.SelectedRows.Count = 1 Then
            Dim oPerson As Person = personTable(DgvWarnings.SelectedRows(0).Index)
            Dim oSocial As SocialMedia = oPerson.Social
            If oSocial IsNot Nothing Then
                If oSocial.Botsd > 0 Then
                    UpdateBotsdId(oPerson.Id, 0)
                    SetOKResult(abBotsdPostNo, "Removed BotSD Id from person " & CStr(oPerson.Id) & " " & oPerson.Surname)
                Else
                    SetErrorResult(abBotsdPostNo, "No BotSD id to remove")
                End If
            Else
                SetErrorResult(abBotsdPostNo, "No social details")
            End If
        Else
            SetErrorResult(abBotsdPostNo, "No person selected")
        End If

    End Sub
    Private Sub BtnRmvOtherBotsdId_Click(sender As Object, e As EventArgs) Handles BtnRmvOtherBotsdId.Click
        ShowStatus("Removing other BotSD id", True)
        Dim _actionText As String = abOthPersonId.ActionText
        If Not String.IsNullOrEmpty(_actionText) AndAlso IsNumeric(_actionText) Then
            UpdateBotsdId(CInt(_actionText), 0)
            SetOKResult(abOthPersonId, "Removed BotSD Id from person " & CStr(_actionText))
        Else
            SetErrorResult(abOthPersonId, "No person identified")
        End If
    End Sub
    Private Sub BtnRmvBotsdRecord_Click(sender As Object, e As EventArgs) Handles BtnRmvBotsdRecord.Click
        ShowStatus("Removing BotSD record", True)
        Dim _actionText As String = abBotsdId.ActionText
        If Not String.IsNullOrEmpty(_actionText) AndAlso IsNumeric(_actionText) Then
            Dim botsdId As Integer = CInt(_actionText)
            If DeleteBotsdById(botsdId) = 1 Then
                SetOKResult(abBotsdId, "Botsd record deleted")
            Else
                SetErrorResult(abBotsdId, "Botsd record deletion failed")
            End If
        Else
            SetErrorResult(abBotsdId, "Botsd record not identified for deletion")
        End If
    End Sub
    Private Sub BtnRmvOldBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnRmvOldBotsdPost.Click
        ShowStatus("Opening old BotSD post for removal")
        Try
            Process.Start(abBotsdUrl.ActionText)
            SetButton(abBotsdUrl,, "Done")
        Catch ex As InvalidOperationException
            SetErrorResult(abBotsdUrl, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abBotsdUrl, ex.Message)
        End Try
    End Sub
    Private Sub BtnUpdOldBotsdList_Click(sender As Object, e As EventArgs) Handles BtnUpdOldBotsdList.Click
        Dim msgText As String = "Opening old BotSD list for amendment"
        ShowStatus(msgText, True)
        Try
            Process.Start(abBotsdListUrl.ActionText)
            SetButton(abBotsdListUrl, , "Done")
        Catch ex As InvalidOperationException
            SetErrorResult(abBotsdListUrl, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abBotsdListUrl, ex.Message)
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
                ShowStatus("Updating DoB and text for " & TxtFullName.Text, True)
                If UpdateDateOfBirth(oPerson.Id, toDate.Day, toDate.Month, toDate.Year, TxtFullDesc.Text) = 1 Then
                    AuditUtil.AddDobChange(oPerson.Id, fromDate, toDate)
                    SetOKResult(abUpdPerson, "Updated " & CStr(oPerson.Id))
                Else
                    SetErrorResult(abUpdPerson, "Person update failed")
                End If
            Else
                SetErrorResult(abUpdPerson, "Invalid date of birth. Person not updated.")
            End If
        End If
    End Sub
    Private Sub BtnReseqOldGroup_Click(sender As Object, e As EventArgs) Handles BtnReseqOldGroup.Click
        ShowStatus("Resequencing old BotSD group", True)
        Dim oldGroup As CelebrityBirthdayDataSet.PersonDataTable
        oldGroup = GetPeopleByDateofBirth(fromDate.Year, fromDate.Month, fromDate.Day)
        Dim newSeq As Integer = 0
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oldGroup
            UpdateSortSeq(oRow.id, newSeq)
            newSeq += 1
        Next
        SetOKResult(abReseqOld, "Resequenced old BotSD group")
    End Sub
    Private Sub BtnUpdateNewBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnUpdateNewBotsdPost.Click
        ShowStatus("Opening new BotSD post for amendment")
        Try
            If Not String.IsNullOrEmpty(abNewBotsdUrl.ActionText) Then
                Process.Start(abNewBotsdUrl.ActionText)
                SetButton(abNewBotsdUrl,, "Done")
            Else
                SetButtonResult(abNewBotsdUrl, "Web update not required", "n/a", DlgShowText.MessageStyle.plain)
            End If
        Catch ex As InvalidOperationException
            SetErrorResult(abNewBotsdUrl, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abNewBotsdUrl, ex.Message)
        End Try
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = toDate.Day
            _botsd.ThisMonth = toDate.Month
            _botsd.ShowDialog()
        End Using
    End Sub
    Private Sub BtnUpdNewBotsdList_Click(sender As Object, e As EventArgs) Handles BtnUpdNewBotsdList.Click
        ShowStatus("Opening new BotSD list for amendment")
        Try
            Process.Start(abNewListUrl.ActionText)
            SetButton(abNewListUrl,, "Done")
        Catch ex As InvalidOperationException
            SetErrorResult(abNewListUrl, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abNewListUrl, ex.Message)
        End Try
        Using _botsd As New FrmBotsd
            _botsd.ThisDay = toDate.Day
            _botsd.ThisMonth = toDate.Month
            _botsd.ShowDialog()
        End Using
    End Sub
    Private Sub BtnOldPostOrPicture_Click(sender As Object, e As EventArgs) Handles BtnRmvOldPicture.Click, BtnUpdOldCbPage.Click
        ShowStatus("Updating old CB post")
        Try
            Dim _selMonth As String = Format(fromDate, "MMMM")
            Dim _selDay As String = CStr(fromDate.Day)
            Dim sUrl As String = GetWordPressMonthUrl(oldPageLoadYear, oldPageLoadMonth, oldPageLoadDay, _selDay, _selMonth.ToLower(myCultureInfo))
            Process.Start(sUrl)
            SetButton(abRmvImage,, "Done")
            SetButton(abUpdOldPost,, "Done")
            OpenWordPress(fromDate.Day, fromDate.Month)
        Catch ex As InvalidOperationException
            SetErrorResult(abRmvImage, ex.Message)
            SetErrorResult(abUpdOldPost, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abRmvImage, ex.Message)
            SetErrorResult(abUpdOldPost, ex.Message)
        End Try

    End Sub
    Private Sub BtnUpdCbPicDesc_Click(sender As Object, e As EventArgs) Handles BtnUpdCbPicDesc.Click
        ShowStatus("Updating CB image description")
        Try
            Dim oPerson As Person = personTable(DgvWarnings.SelectedRows(0).Index)
            If oPerson IsNot Nothing Then
                Clipboard.SetText(GetPictureText(oPerson))
            End If
            Dim _selMonth As String = Format(toDate, "MMMM")
            Dim _selDay As String = CStr(toDate.Day)
            Dim sUrl As String = GetWordPressMonthUrl(newPageLoadYear, newPageLoadMonth, newPageLoadDay, _selDay, _selMonth.ToLower(myCultureInfo)) & abImgDesc.ActionText & "/"
            Process.Start(sUrl)
            SetButton(abImgDesc,, "Done")
        Catch ex As InvalidOperationException
            SetErrorResult(abImgDesc, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abImgDesc, ex.Message)
        End Try
    End Sub
    Private Sub BtnUpdNewCbPage_Click(sender As Object, e As EventArgs) Handles BtnUpdNewCbPage.Click, BtnAddCbPic.Click, BtnMoveCbPic.Click
        ShowStatus("Updating new CB post")
        TxtWiki.Text = GetPersonContext()
        Try
            Dim _selMonth As String = Format(toDate, "MMMM")
            Dim _selDay As String = CStr(toDate.Day)
            Dim sUrl As String = GetWordPressMonthUrl(newPageLoadYear, newPageLoadMonth, newPageLoadDay, _selDay, _selMonth.ToLower(myCultureInfo))
            Process.Start(sUrl)
            If Not String.IsNullOrEmpty(abAddImg.ActionText) Then
                SetButton(abAddImg,, "Done")
            End If
            If Not String.IsNullOrEmpty(abMoveImg.ActionText) Then
                SetButton(abMoveImg,, "Done")
            End If
            SetButton(abUpdNewPost,, "Done")
            OpenWordPress(toDate.Day, toDate.Month)
        Catch ex As InvalidOperationException
            SetErrorResult(abUpdNewPost, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abUpdNewPost, ex.Message)
        End Try
    End Sub
    Private Sub BtnRmvRow_Click(sender As Object, e As EventArgs) Handles BtnRmvRow.Click
        RemoveSelectedRow()
        ResetChecklistButtons()
    End Sub
    Private Sub BtnUpdOldBotsdPost_Click(sender As Object, e As EventArgs) Handles BtnUpdOldBotsdPost.Click
        ShowStatus("Opening old BotSD post for amendment")
        Try
            Process.Start(abBotsdUpdUrl.ActionText)
            SetButton(abBotsdUpdUrl,, "Done")
        Catch ex As InvalidOperationException
            SetErrorResult(abBotsdUpdUrl, ex.Message)
        Catch ex As ComponentModel.Win32Exception
            SetErrorResult(abBotsdUpdUrl, ex.Message)
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
        Dim msgText As String = "Resequenced new BotSD group"
        SetButtonResult(abReseqNew, msgText, "OK")
        ShowStatus(msgText, True)
    End Sub
    Private Sub BtnRemoveRow_Click(sender As Object, e As EventArgs) Handles BtnRemoveRow.Click
        RemoveSelectedRow()
        ResetChecklistButtons()
    End Sub
    Private Sub BtnCopyName_Click(sender As Object, e As EventArgs) Handles BtnCopyName.Click
        If DgvWarnings.SelectedRows.Count = 1 Then
            Clipboard.SetText(DgvWarnings.SelectedRows(0).Cells(xName.Name).Value)
        End If
    End Sub
    Private Sub BtnAuditView_Click(sender As Object, e As EventArgs) Handles BtnAuditView.Click
        If DgvWarnings.SelectedRows.Count > 0 Then
            Dim tRow As DataGridViewRow = DgvWarnings.SelectedRows(0)
            Dim oPersonId As Integer = tRow.Cells(xId.Name).Value
            Using _audit As New FrmAuditList
                _audit.DataType = "dob"
                _audit.PersonId = oPersonId
                _audit.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnBotsdPostNo_Click(sender As Object, e As EventArgs) Handles BtnBotsdPostNo.Click
        DisplayMessage(abBotsdPostNo)
    End Sub
    Private Sub BtnOthPersonId_Click(sender As Object, e As EventArgs) Handles BtnOthPersonId.Click
        DisplayMessage(abOthPersonId)
    End Sub
    Private Sub BtnBotsdId_Click(sender As Object, e As EventArgs) Handles BtnBotsdId.Click
        DisplayMessage(abBotsdId)
    End Sub
    Private Sub BtnBotsdUrl_Click(sender As Object, e As EventArgs) Handles BtnBotsdUrl.Click
        If String.IsNullOrEmpty(abBotsdUrl.ResultText) Then
            SetOKResult(abBotsdUrl, "Remove old post complete")
        Else
            DisplayMessage(abBotsdUrl)
        End If
    End Sub
    Private Sub BtnUpdPerson_Click(sender As Object, e As EventArgs) Handles BtnUpdPerson.Click
        DisplayMessage(abUpdPerson)
    End Sub
    Private Sub BtnReseqOld_Click(sender As Object, e As EventArgs) Handles BtnReseqOld.Click
        DisplayMessage(abReseqOld)
    End Sub
    Private Sub BtnReseqNew_Click(sender As Object, e As EventArgs) Handles BtnReseqNew.Click
        DisplayMessage(abReseqNew)
    End Sub
    Private Sub BtnNewBotsdUrl_Click(sender As Object, e As EventArgs) Handles BtnNewBotsdUrl.Click
        If String.IsNullOrEmpty(abNewBotsdUrl.ResultText) Then
            SetOKResult(abNewBotsdUrl, "Born on the Same Day post updated")
        Else
            DisplayMessage(abNewBotsdUrl)
        End If
    End Sub
    Private Sub BtnNewListUrl_Click(sender As Object, e As EventArgs) Handles BtnNewListUrl.Click
        If String.IsNullOrEmpty(abNewListUrl.ResultText) Then
            SetOKResult(abNewListUrl, "Born on the Same Day list page updated")
        Else
            DisplayMessage(abNewListUrl)
        End If
    End Sub
    Private Sub BtnUpdOldPost_Click(sender As Object, e As EventArgs) Handles BtnUpdOldPost.Click
        If String.IsNullOrEmpty(abUpdOldPost.ResultText) Then
            SetOKResult(abUpdOldPost, "Old date page updated")
        Else
            DisplayMessage(abUpdOldPost)
        End If
    End Sub
    Private Sub BtnMoveImg_Click(sender As Object, e As EventArgs) Handles BtnMoveImg.Click
        If String.IsNullOrEmpty(abMoveImg.ResultText) Then
            SetOKResult(abMoveImg, "Picture moved on date page")
        Else
            DisplayMessage(abMoveImg)
        End If
    End Sub
    Private Sub BtnUpdNewPost_Click(sender As Object, e As EventArgs) Handles BtnUpdNewPost.Click
        If String.IsNullOrEmpty(abUpdNewPost.ResultText) Then
            SetOKResult(abUpdNewPost, "New date page updated")
        Else
            DisplayMessage(abUpdNewPost)
        End If
    End Sub
    Private Sub BtnImgName_Click(sender As Object, e As EventArgs) Handles BtnImgDesc.Click
        If String.IsNullOrEmpty(abImgDesc.ResultText) Then
            SetOKResult(abImgDesc, "Picture description updated")
        Else
            DisplayMessage(abImgDesc)
        End If
    End Sub
    Private Sub BtnRmvImage_Click(sender As Object, e As EventArgs) Handles BtnRmvImage.Click
        If String.IsNullOrEmpty(abRmvImage.ResultText) Then
            SetOKResult(abRmvImage, "Picture removed from old date page")
        Else
            DisplayMessage(abRmvImage)
        End If
    End Sub
    Private Sub BtnAddImg_Click(sender As Object, e As EventArgs) Handles BtnAddImg.Click
        If String.IsNullOrEmpty(abAddImg.ResultText) Then
            SetOKResult(abAddImg, "Picture added to new date page")
        Else
            DisplayMessage(abAddImg)
        End If
    End Sub
    Private Sub BtnBotsdListUrl_Click(sender As Object, e As EventArgs) Handles BtnBotsdListUrl.Click
        If String.IsNullOrEmpty(abBotsdListUrl.ResultText) Then
            SetOKResult(abBotsdListUrl, "Born on the Same Day list updated")
        Else
            DisplayMessage(abBotsdListUrl)
        End If
    End Sub
    Private Sub BtnBotsdUpdUrl_Click(sender As Object, e As EventArgs) Handles BtnBotsdUpdUrl.Click
        If String.IsNullOrEmpty(abBotsdUpdUrl.ResultText) Then
            SetOKResult(abBotsdUpdUrl, "Born on the Same Day post updated")
        Else
            DisplayMessage(abBotsdUpdUrl)
        End If
    End Sub
    Private Sub SetErrorResult(ByRef resultButton As CheckListActionButton, msgText As String)
        ShowStatus(msgText, True)
        SetButtonResult(resultButton, msgText, "err", DlgShowText.MessageStyle.warn)
    End Sub
    Private Sub SetOKResult(ByRef resultButton As CheckListActionButton, msgText As String)
        ShowStatus(msgText, True)
        SetButtonResult(resultButton, msgText, "OK", DlgShowText.MessageStyle.plain)
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
    Private Sub RemoveSelectedRow()
        If DgvWarnings.SelectedRows.Count = 1 Then
            DgvWarnings.SelectedRows(0).Visible = False
            DgvWarnings.ClearSelection()
        End If
    End Sub
    Private Sub CreateActionButtons()
        abBotsdPostNo = New CheckListActionButton(BtnBotsdPostNo, "")
        abOthPersonId = New CheckListActionButton(BtnOthPersonId, "")
        abBotsdId = New CheckListActionButton(BtnBotsdId, "")
        abBotsdUrl = New CheckListActionButton(BtnBotsdUrl, "")
        abBotsdUpdUrl = New CheckListActionButton(BtnBotsdUpdUrl, "")
        abBotsdListUrl = New CheckListActionButton(BtnBotsdListUrl, "")
        abUpdPerson = New CheckListActionButton(BtnUpdPerson, "")
        abReseqOld = New CheckListActionButton(BtnReseqOld, "")
        abReseqNew = New CheckListActionButton(BtnReseqNew, "")
        abNewListUrl = New CheckListActionButton(BtnNewListUrl, "")
        abNewBotsdUrl = New CheckListActionButton(BtnNewBotsdUrl, "")
        abRmvImage = New CheckListActionButton(BtnRmvImage, "")
        abAddImg = New CheckListActionButton(BtnAddImg, "")
        abImgDesc = New CheckListActionButton(BtnImgDesc, "")
        abUpdNewPost = New CheckListActionButton(BtnUpdNewPost, "")
        abUpdOldPost = New CheckListActionButton(BtnUpdOldPost, "")
        abMoveImg = New CheckListActionButton(BtnMoveImg, "")
    End Sub
    Private Sub ShowButtonToUpdateNewPost()
        BtnUpdNewCbPage.Visible = True
        SetButton(abUpdNewPost, GetNewPageLoadDate())
    End Sub
    Private Sub ShowButtonToUpdatePictureDescription(oPerson As Person)
        BtnUpdCbPicDesc.Visible = True
        SetButton(abImgDesc, oPerson.Image.ImageFileName)
    End Sub
    Private Sub ShowButtonToAddPicture()
        BtnAddCbPic.Visible = True
        SetButton(abAddImg, GetNewPageLoadDate())
    End Sub
    Private Sub ShowButtonToUpdateOldPage()
        BtnUpdOldCbPage.Visible = True
        SetButton(abUpdOldPost, BtnRmvImage.Text)
    End Sub
    Private Sub ShowButtonToRemoveOldPicture()
        BtnRmvOldPicture.Visible = True
        SetButton(abRmvImage, GetOldPageLoadDate())
    End Sub
    Private Sub ShowButtonToMovePicture()
        BtnMoveCbPic.Visible = True
        SetButton(abMoveImg, GetNewPageLoadDate())
    End Sub
    Private Sub ShowButtonToUpdateNewBotsdList()
        BtnUpdNewBotsdList.Visible = True
        SetButton(abNewListUrl, My.Settings.botsdWordPressUrl & Format(toDate, "MMMM") & "/",, False)
    End Sub
    Private Sub ShowButtonToUpdateNewBotsdPost(oNewGroup As CelebrityBirthdayDataSet.PersonDataTable)
        BtnUpdateNewBotsdPost.Visible = True
        SetButton(abNewBotsdUrl, GetGroupUrl(oNewGroup),, False)
    End Sub
    Private Sub ShowButtonToResequenceNewGroup()
        BtnReseqNewGroup.Visible = True
        SetButton(abReseqNew,,, False)
    End Sub
    Private Sub ShowButtonToResequenceOldGroup()
        BtnReseqOldGroup.Visible = True
        SetButton(abReseqOld, ,, False)
    End Sub
    Private Sub ShowButtonToUpdatePerson(oPerson As Person)
        BtnUpdatePerson.Visible = True
        SetButton(abUpdPerson, CStr(oPerson.Id),, False)
    End Sub
    Private Sub ShowButtonToUpdateBotsdList()
        BtnUpdOldBotsdList.Visible = True
        SetButton(abBotsdListUrl, My.Settings.botsdWordPressUrl & Format(fromDate, "MMMM") & "/",, False)
    End Sub
    Private Sub ShowButtonToUpdateBotsdPost(oBotsdRow As CelebrityBirthdayDataSet.BotSDRow)
        BtnUpdOldBotsdPost.Visible = True
        SetButton(abBotsdUpdUrl, oBotsdRow.btsdUrl,, False)
    End Sub
    Private Sub ShowButtonToRemoveBotsdPost(oBotsdRow As CelebrityBirthdayDataSet.BotSDRow)
        BtnRmvOldBotsdPost.Visible = True
        SetButton(abBotsdUrl, oBotsdRow.btsdUrl,, False)
    End Sub
    Private Sub ShowButtonToRemoveBotsdRecord(oBotsdId As Integer)
        BtnRmvBotsdRecord.Visible = True
        SetButton(abBotsdId, CStr(oBotsdId),, False)
    End Sub
    Private Sub ShowButtonToRemoveOtherBotsdId(otherBotsd As List(Of Integer))
        BtnRmvOtherBotsdId.Visible = True
        SetButton(abOthPersonId, CStr(otherBotsd(0)),, False)
    End Sub
    Private Sub ShowButtonToRemoveBotsdId(oBotsdPostNo As Integer)
        BtnRmvBotsdId.Visible = True
        SetButton(abBotsdPostNo, "#" & CStr(oBotsdPostNo),, False)
    End Sub
    Private Shared Sub SetButton(ByRef pButton As CheckListActionButton, Optional pActionText As String = Nothing, Optional pButtonText As String = "", Optional pEnabled As Boolean = True)
        If pButton.ActionButton IsNot Nothing Then
            pButton.ActionButton.Text = pButtonText
            pButton.ActionButton.Visible = Not String.IsNullOrEmpty(pButtonText)
            pButton.ActionButton.Enabled = pEnabled
        End If
        If pActionText IsNot Nothing Then pButton.ActionText = pActionText
        pButton.ResultText = ""
    End Sub
    Private Shared Sub SetButtonResult(ByRef pButton As CheckListActionButton, pResultText As String, Optional pButtonText As String = "", Optional pStyle As DlgShowText.MessageStyle = DlgShowText.MessageStyle.none)
        If pResultText IsNot Nothing Then
            pButton.ResultText = pResultText
            pButton.ResultStyle = pStyle
            If pButton.ActionButton IsNot Nothing Then
                pButton.ActionButton.Text = pButtonText
                pButton.ActionButton.Visible = Not String.IsNullOrEmpty(pButtonText)
                pButton.ActionButton.Enabled = True
            End If
        End If
    End Sub
    Private Shared Sub UnsetButton(ByRef pButton As CheckListActionButton)
        If pButton.ActionButton IsNot Nothing Then
            pButton.ActionButton.Text = ""
            pButton.ActionButton.Visible = False
        End If
        pButton.ActionText = ""
    End Sub
#End Region
End Class
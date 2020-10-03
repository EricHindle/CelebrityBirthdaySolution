Imports System.Text

Public Class FrmWordPress
#Region "constants"
    Private Const DOUBLE_QUOTES As String = """"
    Private ReadOnly A_TAG_START As String = "<a href=""" & My.Resources.WPFILESURL
    Private Const A_TAG_END As String = ">"
    Private Const IMG_TAG_START As String = "<img title="
    Private ReadOnly IMG_TAG_MIDDLE As String = " src=""" & My.Resources.WPFILESURL
    Private Const IMG_TAG_ALT As String = " alt="
    Private Const IMG_TAG_SIZE As String = " width=""60"" height=""60"" />"
    Private Const STRONG_TAG_START As String = "</a> <strong>"
    Private Const STRONG_TAG_END As String = "</strong>"
    Private Const EXCERPT_START As String = "Today's Birthdays:<br />"
    Private Const EXCERPT_DIV As String = "<div style=""width:200px;float:left;font-family:arial;font-size:12px;"">"
    Private Const EXCERPT_DIV_END As String = "</div>"

#End Region
#Region "variables"
    Dim personTable As List(Of Person)
    Private urlYear As String = "2013"
    Private urlMonth As String = "03"
#End Region
#Region "properties"
    Private _daySelection As Integer
    Private _monthSelection As Integer
    Public Property MonthSelection() As Integer
        Get
            Return _monthSelection
        End Get
        Set(ByVal value As Integer)
            _monthSelection = value
        End Set
    End Property
    Public Property DaySelection() As Integer
        Get
            Return _daySelection
        End Get
        Set(ByVal value As Integer)
            _daySelection = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub BtnCopyFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyFull.Click
        My.Computer.Clipboard.SetText(txtCurrentText.Text)
    End Sub
    Private Sub BtnCopyExcerpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyExcerpt.Click
        My.Computer.Clipboard.SetText(txtCurrentExcerpt.Text)
    End Sub
    Private Sub BtnLoadTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            Dim _wpDate As Date? = GetWordPressLoadDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, "P")
            TxtLoadDay.Text = If(_wpDate Is Nothing, "", Format(_wpDate, "dd"))
            txtLoadMth.Text = If(_wpDate Is Nothing, "", Format(_wpDate, "MM"))
            txtLoadYr.Text = If(_wpDate Is Nothing, "", Format(_wpDate, "yyyy"))
            personTable = New List(Of Person)
            personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, False)
            GenFullText()
            GenExcerpt()
            WebBrowser1.DocumentText = TextToHtml(txtCurrentText.Text)
        End If
    End Sub
    Private Sub FrmWordPress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        ClearForm()
        If Not String.IsNullOrEmpty(_daySelection) AndAlso Not String.IsNullOrEmpty(_monthSelection) Then
            cboDay.SelectedIndex = _daySelection - 1
            cboMonth.SelectedIndex = _monthSelection - 1
        End If
        GetFormPos(Me, My.Settings.wprformpos)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
#End Region
#Region "subroutines"
    Shared Function AddQuotes(pText As String) As String
        Return DOUBLE_QUOTES & pText & DOUBLE_QUOTES
    End Function
    Private Sub GenFullText()
        Dim lastYear As String = ""
        Dim newText As New StringBuilder()
        For Each oPerson As Person In personTable
            SetImageDate(oPerson.Id)
            If oPerson.BirthYear <> lastYear Then
                Dim _birthYear As Integer = Math.Abs(CInt(oPerson.BirthYear))
                newText.Append("<h3>").Append(CStr(_birthYear)).Append(If(oPerson.BirthYear < 0, " BCE", "")).Append("</h3>").Append(vbCrLf)
                lastYear = oPerson.BirthYear
            End If
            Dim lowername As String = oPerson.Image.ImageFileName
            If lowername.Length = 0 Then
                lowername = oPerson.Name.ToLower(myCultureInfo).Replace(" ", "-").Replace(".", "")
            End If
            Dim sBorn As String = ""
            If oPerson.BirthName.Length > 0 Or oPerson.BirthPlace.Length > 0 Then
                sBorn = " Born" & If(oPerson.BirthName.Length > 0, " " & oPerson.BirthName, "") & If(oPerson.BirthPlace.Length > 0, " in " & oPerson.BirthPlace, "") & "."
            End If
            Dim sDied As String = " (d. " & CStr(Math.Abs(oPerson.DeathYear)) & If(oPerson.DeathYear < 0, " BCE", "") & ")"
            With newText
                .Append(A_TAG_START)
                .Append(urlYear)
                .Append(MY.resources.SLASH)
                .Append(urlMonth)
                .Append(MY.resources.SLASH)
                .Append(lowername)
                .Append(oPerson.Image.ImageFileType)
                .Append(DOUBLE_QUOTES)
                .Append(A_TAG_END)
                .Append(IMG_TAG_START)
                .Append(AddQuotes(oPerson.Name))
                .Append(IMG_TAG_MIDDLE)
                .Append(urlYear)
                .Append(MY.resources.SLASH)
                .Append(urlMonth)
                .Append(MY.resources.SLASH)
                .Append(lowername)
                .Append(oPerson.Image.ImageFileType)
                .Append(DOUBLE_QUOTES)
                .Append(IMG_TAG_ALT)
                .Append(AddQuotes(oPerson.Name))
                .Append(IMG_TAG_SIZE)
                .Append(STRONG_TAG_START)
                .Append(oPerson.Name)
                .Append(STRONG_TAG_END)
                .Append(vbCrLf)
                .Append(oPerson.Description)
                .Append(sBorn)
                .Append(If(oPerson.DeathYear = 0, "", sDied))
                .Append(vbCrLf)
                .Append(MY.resources.break)
                .Append(vbCrLf)
            End With
        Next
        txtCurrentText.Text = newText.ToString
    End Sub
    Private Sub SetImageDate(_personId As Integer)
        Dim oImage As ImageIdentity = GetImageById(_personId)
        urlMonth = txtLoadMth.Text
        urlYear = txtLoadYr.Text
        If oImage IsNot Nothing Then
            If oImage.ImageLoadYear IsNot Nothing AndAlso IsNumeric(oImage.ImageLoadYear) Then
                urlYear = oImage.ImageLoadYear
            End If
            If oImage.ImageLoadMonth IsNot Nothing AndAlso IsNumeric(oImage.ImageLoadMonth) Then
                urlMonth = oImage.ImageLoadMonth
            End If
        End If
        oImage.Dispose()
    End Sub
    Private Sub GenExcerpt()
        Dim bOK As Boolean = True
        Dim listRem As Integer
        Dim listSize As Integer
        Dim pList As New List(Of Person)
        pList.AddRange(personTable)
        If pList.Count = 0 Then
            bOK = False
        Else
            listRem = pList.Count Mod 3
            listSize = Int(pList.Count / 3)
            If listRem > 0 Then
                If listRem = 1 Then
                    pList.Insert((listSize * 2) + 1, New Person)
                End If
                pList.Add(New Person)
                listSize += 1
            End If
        End If
        If bOK Then
            Dim newText As New StringBuilder(EXCERPT_START)
            newText.Append(vbCrLf)
            Dim iCt As Integer = 0
            For Each oPerson As Person In pList
                If iCt = 0 Then
                    newText.Append(EXCERPT_DIV).Append(vbCrLf)
                End If
                With newText
                    .Append(oPerson.Name)
                    .Append("<br />")
                    .Append(vbCrLf)
                End With
                iCt += 1
                If iCt = listSize Then
                    newText.Append(EXCERPT_DIV_END).Append(vbCrLf)
                    iCt = 0
                End If
            Next
            txtCurrentExcerpt.Text = newText.ToString
        End If
    End Sub
    Private Sub ClearForm()
        txtCurrentExcerpt.Text = ""
        txtCurrentText.Text = ""
        cboDay.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        personTable = New List(Of Person)
    End Sub
    Private Shared Function TextToHtml(pText As String) As String
        Dim HtmlString As New StringBuilder
        Dim _html As String = HtmlString.Append("<html>") _
            .Append("<font ") _
            .Append("Size = '2' ") _
            .Append("face='Verdana' ") _
            .Append(">") _
            .Append(pText) _
            .Append("</font>") _
            .Append("</html>").ToString
        Return _html
    End Function

    Private Sub BtnBrowser_Click(sender As Object, e As EventArgs) Handles BtnBrowser.Click
        If cboMonth.SelectedIndex >= 0 Then
            Dim _selMonth As String = cboMonth.SelectedItem
            Dim _selDay As String = cboDay.SelectedItem
            Dim sUrl As String = GetWordPressMonthUrl(txtLoadYr.Text, txtLoadMth.Text, TxtLoadDay.Text, _selDay, _selMonth.ToLower(myCultureInfo))
            Process.Start(sUrl)
        End If

    End Sub
    Private Sub ShowStatus(pText As String)
        lblStatus.Text = pText
        StatusStrip1.Refresh()
    End Sub

    Private Sub FrmWordPress_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LogUtil.Info("Closing", MyBase.Name)
        My.Settings.wprformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    'Form overrides dispose to clean up the component list.

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing AndAlso personTable IsNot Nothing Then
                For Each oPerson In personTable
                    oPerson.Dispose()
                Next
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

#End Region
End Class
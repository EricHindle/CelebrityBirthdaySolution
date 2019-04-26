Imports System.Text

Public Class FrmWordPress
    Dim personTable As List(Of Person)
    Private urlYear As String = "2013"
    Private urlMonth As String = "03"
    Private Const A_TAG_START As String = "<a href=""http://celebritybirthday.files.wordpress.com/"
    Private Const A_TAG_END As String = """>"
    Private Const IMG_TAG_START As String = "<img title="""
    Private Const IMG_TAG_MIDDLE As String = """ src=""http://celebritybirthday.files.wordpress.com/"
    Private Const IMG_TAG_END As String = """ alt="""" width=""60"" height=""60"" />"
    Private Const STRONG_TAG_START As String = "</a> <strong>"
    Private Const STRONG_TAG_END As String = "</strong>"
    Private Const EXCERPT_START As String = "Today's Birthdays:<br />"
    Private Const EXCERPT_DIV As String = "<div style=""width:200px;float:left;font-family:arial;font-size:12px;"">"
    Private Const EXCERPT_DIV_END As String = "</div>"
    Private Const BREAK As String = "<br>"
    Private Sub GenFullText()
        Dim lastYear As String = ""
        Dim newText As New StringBuilder()
        For Each oPerson As Person In personTable
            SetImageDate(oPerson.Id)


            If oPerson.BirthYear <> lastYear Then
                newText.Append("<h3>").Append(oPerson.BirthYear).Append("</h3>").Append(vbCrLf)
                lastYear = oPerson.BirthYear
            End If
            Dim lowername As String = oPerson.Image.ImageFileName
            If lowername.Length = 0 Then
                lowername = oPerson.Name.ToLower.Replace(" ", "-").Replace(".", "")
            End If
            Dim sBorn As String = ""
            If oPerson.BirthName.Length > 0 Or oPerson.BirthPlace.Length > 0 Then
                sBorn = " Born" & If(oPerson.BirthName.Length > 0, " " & oPerson.BirthName, "") & If(oPerson.BirthPlace.Length > 0, " in " & oPerson.BirthPlace, "") & "."
            End If
            Dim sDied As String = " (d. " & CStr(oPerson.DeathYear) & ")"
            With newText
                .Append(A_TAG_START)
                .Append(urlYear)
                .Append("/")
                .Append(urlMonth)
                .Append("/")
                .Append(lowername)
                .Append(oPerson.Image.ImageFileType)
                .Append(A_TAG_END)
                .Append(IMG_TAG_START)
                .Append(oPerson.Name)
                .Append(IMG_TAG_MIDDLE)
                .Append(urlYear)
                .Append("/")
                .Append(urlMonth)
                .Append("/")
                .Append(lowername)
                .Append(oPerson.Image.ImageFileType)
                .Append(IMG_TAG_END)
                .Append(STRONG_TAG_START)
                .Append(oPerson.Name)
                .Append(STRONG_TAG_END)
                .Append(vbCrLf)
                .Append(oPerson.Description)
                .Append(sBorn)
                .Append(If(oPerson.DeathYear = 0, "", sDied))
                .Append(vbCrLf)
                .Append(BREAK)
            End With
        Next
        txtCurrentText.Text = newText.ToString
    End Sub
    Private Sub setImageDate(_personId As Integer)
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
    End Sub
    Private Sub GenExcerpt()
        Dim bOK As Boolean = True
        'Dim listRem As Integer
        Dim listSize As Integer
        Dim pList As New List(Of Person)
        pList.AddRange(personTable)
        'If lbPeople.Items.Count = 0 Then
        '    bOK = False
        'Else
        '    listRem = lbPeople.Items.Count Mod 3
        '    listSize = Int(lbPeople.Items.Count / 3)
        '    If listRem > 0 Then
        '        If listRem = 1 Then
        '            pList.Insert((listSize * 2) + 1, New Person)
        '        End If
        '        pList.Add(New Person)
        '        listSize += 1
        '    End If
        'End If
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

    Private Sub BtnCopyFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyFull.Click
        My.Computer.Clipboard.SetText(txtCurrentText.Text)

    End Sub

    Private Sub BtnCopyExcerpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyExcerpt.Click
        My.Computer.Clipboard.SetText(txtCurrentExcerpt.Text)

    End Sub


    Private Sub BtnLoadTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            Dim _wpDate As Date? = GetWordPressLoadDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            txtLoadMth.Text = If(_wpDate Is Nothing, "", Format(_wpDate, "MM"))
            txtLoadYr.Text = If(_wpDate Is Nothing, "", Format(_wpDate, "yyyy"))
            personTable = New List(Of Person)
            personTable = FindPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            GenFullText()
            GenExcerpt()
            WebBrowser1.DocumentText = txtCurrentText.Text
        End If
    End Sub

    Private Sub FrmWordPress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearForm
    End Sub
    Private Sub ClearForm()
        txtCurrentExcerpt.Text = ""
        txtCurrentText.Text = ""
        cboDay.SelectedIndex = -1
        cboMonth.SelectedIndex = -1
        personTable = New List(Of Person)
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub


End Class
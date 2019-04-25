Imports System.Text

Public Class FrmWordPress
    Dim personTable As List(Of Person)
    Dim urlYear As String = "2013"
    Dim urlMonth As String = "03"
    Dim aTagStart As String = "<a href=""http://celebritybirthday.files.wordpress.com/"
    Dim aTagEnd As String = """>"
    Dim imgTagStart As String = "<img title="""
    Dim imgTagMiddle As String = """ src=""http://celebritybirthday.files.wordpress.com/"
    Dim imgTagEnd As String = """ alt="""" width=""60"" height=""60"" />"
    Dim strongTagStart As String = "</a> <strong>"
    Dim strongTagEnd As String = "</strong>"
    Dim excerptStart As String = "Today's Birthdays:<br />"
    Dim excerptDiv As String = "<div style=""width:200px;float:left;font-family:arial;font-size:12px;"">"
    Dim excerptDivEnd As String = "</div>"
    Private Sub BtnGenFullText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenFullText.Click
        Dim lastYear As String = ""
        Dim newText As New StringBuilder()
            For Each oPerson As Person In personTable
                GetUrlDate(oPerson.Id)
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
                    .Append(aTagStart)
                    .Append(urlYear)
                    .Append("/")
                    .Append(urlMonth)
                    .Append("/")
                    .Append(lowername)
                    .Append(oPerson.Image.ImageFileType)
                    .Append(aTagEnd)
                    .Append(imgTagStart)
                    .Append(oPerson.Name)
                    .Append(imgTagMiddle)
                    .Append(urlYear)
                    .Append("/")
                    .Append(urlMonth)
                    .Append("/")
                    .Append(lowername)
                    .Append(oPerson.Image.ImageFileType)
                    .Append(imgTagEnd)
                    .Append(strongTagStart)
                    .Append(oPerson.Name)
                    .Append(strongTagEnd)
                    .Append(vbCrLf)
                    .Append(oPerson.Description)
                    .Append(sBorn)
                    .Append(If(oPerson.DeathYear = 0, "", sDied))
                    .Append(vbCrLf)
                End With
            Next
        txtCurrentText.Text = newText.ToString
    End Sub

    Private Sub BtnGenExcerpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenExcerpt.Click
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
            Dim newText As New StringBuilder(excerptStart)
            newText.Append(vbCrLf)
            Dim iCt As Integer = 0
            For Each oPerson As Person In pList
                If iCt = 0 Then
                    newText.Append(excerptDiv).Append(vbCrLf)
                End If
                With newText
                    .Append(oPerson.Name)
                    .Append("<br />")
                    .Append(vbCrLf)
                End With
                iCt += 1
                If iCt = listSize Then
                    newText.Append(excerptDivEnd).Append(vbCrLf)
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
            personTable = New List(Of Person)
            personTable = FindPeopleByDate(cboMonth.SelectedIndex + 1, cboDay.SelectedIndex + 1)
        End If
    End Sub

    Private Sub GetUrlDate(ByRef Id As Integer)

        If txtCurrentText.TextLength > 0 Then
            Dim currParts1 As String() = Split(txtCurrentText.Text, "<h3>")
            If currParts1.Length > 1 Then
                Dim entry1 As String = currParts1(1)
                Dim url1 As String() = Split(entry1, ".com")
                Dim entry11 As String = url1(1)
                Dim url11 As String() = Split(entry11, ".")
                Dim date1 As String() = Split(url11(0), "/")
                urlYear = date1(1)
                urlMonth = date1(2)
            End If
        Else

            urlYear = txtLoadYr.Text
            urlMonth = txtLoadMth.Text

        End If

    End Sub
End Class
Imports System.Windows.Forms

Public Class frmSearchDb
    Private _url As String
    Public Property theUrl() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property
    Private _searchName As String
    Public Property searchName() As String
        Get
            Return _searchName
        End Get
        Set(ByVal value As String)
            _searchName = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.findformpos = setFormPos(Me)
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.SelectedRows(0).Selected = False
        End If
        DataGridView1.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub DataGridView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragDrop
        If (e.Data.GetDataPresent(GetType(System.String))) Then
            Dim item As String = e.Data.GetData(GetType(System.String))
            If cbNsComma.Checked Then
                item = item.Replace(",", "~")
            End If

            If cbNsLfeed.Checked Then
                item = item.Replace(vbLf, "~").Replace(vbCr, "")
            End If

            If cbNsAnd.Checked Then
                item = item.Replace(" and ", "~")
            End If

            If cbNsSemiC.Checked Then
                item = item.Replace(";", "~")
            End If

            Dim namelist As String() = Split(item, "~")
            For Each thisName As String In namelist
                thisName = thisName.Trim.ToLower
                Dim sRSep As String = " "
                If rbRsComma.Checked Then
                    sRSep = ","
                End If
                If rbRsSp.Checked Then
                    sRSep = " "
                End If
                If cbRev.Checked Then
                    Dim nameparts As String() = Split(thisName, sRSep)
                    Select Case nameparts.Count
                        Case 1
                            thisName = nameparts(0).Trim
                        Case Else
                            thisName = nameparts(1).Trim & " " & nameparts(0).Trim
                    End Select
                End If
                thisName = thisName.Trim(" ").Trim(".")
                CheckName(thisName)
            Next

        End If
    End Sub
    Private Sub CheckName(ByVal sName As String, Optional ByVal pos As Integer = -1)
        Dim anyFound As Boolean = False
        Debug.Print(sName)
        Dim names As String() = Split(sName.Trim, " ")
        Dim sForename As String
        Dim sSurname As String
        Dim sLastname As String
        sLastname = names(UBound(names))
        sForename = "%" & sName.Replace(sLastname, "").Trim & "%"
        sSurname = "%" & sLastname & "%"
        Debug.Print(sForename & "~" & sSurname)
        Dim oTable As New CelebrityBirthdayDataSet.PersonDataTable
        If FindPerson(sForename, sSurname, oTable) > 0 Then
            anyFound = True
            FillTable(oTable, pos)
        ElseIf names(0) = "sir" Then
            sForename = sForename.Replace("sir ", "")
            Debug.Print(sForename & "~" & sSurname)
            If FindPerson(sForename, sSurname, oTable) > 0 Then
                anyFound = True
                FillTable(oTable, pos)
            End If
        End If
        If Not anyFound Then
            Dim rct As Integer
            If pos >= 0 And pos < DataGridView1.Rows.Count Then
                DataGridView1.Rows.Insert(pos, 1)
                rct = pos
            Else
                rct = DataGridView1.Rows.Add()
            End If
            Dim tRow As DataGridViewRow = DataGridView1.Rows(rct)
            tRow.Cells("PersonName").Value = sName
            tRow.Cells("PersonYear").Value = "Not Found"
        End If

    End Sub
    Private Function FindPerson(ByVal pForename As String, ByVal pSurname As String, ByRef oTable As CelebrityBirthdayDataSet.PersonDataTable) As Integer
        Dim oTa As New CelebrityBirthdayDataSetTableAdapters.PersonTableAdapter
        Dim ict As Integer = oTa.FillByName(oTable, pForename, pSurname)
        If ict = 0 Then
            Dim sForename As String = ToSimpleCharacters(pForename)
            Dim sSurname As String = ToSimpleCharacters(pSurname)
            Debug.Print(sForename & "~" & sSurname)
            ict = oTa.FillByName(oTable, pForename, pSurname)
        End If
        Return ict
    End Function

    Private Sub FillTable(ByRef oTable As CelebrityBirthdayDataSet.PersonDataTable, ByVal pos As Integer)
        For Each oRow As CelebrityBirthdayDataSet.PersonRow In oTable.Rows
            Dim rct As Integer
            If pos >= 0 And pos < DataGridView1.Rows.Count Then
                DataGridView1.Rows.Insert(pos, 1)
                rct = pos
            Else
                rct = DataGridView1.Rows.Add()
            End If

            Dim tRow As DataGridViewRow = DataGridView1.Rows(rct)
            tRow.Cells("PersonName").Value = oRow.forename & " " & oRow.surname
            tRow.Cells("PersonYear").Value = oRow.birthyear
            tRow.Cells("PersonMonth").Value = oRow.birthmonth
            tRow.Cells("PersonDay").Value = oRow.birthday
            tRow.Cells("PersonDesc").Value = oRow.shortdesc
        Next
    End Sub

    Private Sub DataGridView1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DataGridView1.DragEnter
        If (e.Data.GetDataPresent(GetType(System.String))) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        FindinWiki()
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim sSrchname As String = DataGridView1.SelectedRows(0).Cells("PersonName").Value
            Dim sYear As String = DataGridView1.SelectedRows(0).Cells("PersonYear").Value
            Dim sMonth As String = DataGridView1.SelectedRows(0).Cells("PersonMonth").Value
            Dim sDay As String = DataGridView1.SelectedRows(0).Cells("PersonDay").Value
            Dim sDesc As String = DataGridView1.SelectedRows(0).Cells("PersonDesc").Value

            With frmMain
                .txtName.Text = sSrchname
                .txtShortDesc.Text = sDesc
                .txtDesc.Text = sDesc
                .txtYear.Text = sYear
                .cboDay.SelectedIndex = CInt(sDay) - 1
                .cboMonth.SelectedIndex = CInt(sMonth) - 1
                .btnSplitName_Click(sender, e)
                .btnMakeImgName_Click(sender, e)
            End With

        End If

    End Sub


    Private Sub YearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.SelectedRows(0).Cells("PersonYear").Value = My.Computer.Clipboard.GetText()
        End If

    End Sub

    Private Sub MonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim sMth As String = My.Computer.Clipboard.GetText().Trim
            Dim iMth As Integer
            If IsNumeric(sMth) Then
                iMth = CInt(sMth)
                If iMth > 0 And iMth < 13 Then
                    DataGridView1.SelectedRows(0).Cells("PersonMonth").Value = sMth
                End If
            Else
                iMth = frmMain.cboMonth.FindStringExact(sMth) + 1
                If iMth >= 0 Then
                    DataGridView1.SelectedRows(0).Cells("PersonMonth").Value = CStr(iMth)
                End If
            End If


        End If

    End Sub

    Private Sub DayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.SelectedRows(0).Cells("PersonDay").Value = My.Computer.Clipboard.GetText()
        End If

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        lblNav.Text = "Complete"
        txtURL.Text = WebBrowser1.Url.AbsoluteUri
    End Sub

    Private Sub NameToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NameToolStripMenuItem2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.SelectedRows(0).Cells("PersonName").Value = My.Computer.Clipboard.GetText()
        End If
    End Sub

    Private Sub DateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateToolStripMenuItem1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim sDate As String = My.Computer.Clipboard.GetText().Trim

            If IsDate(sDate) Then
                Dim dtDate As Date = CDate(sDate)
                DataGridView1.SelectedRows(0).Cells("PersonMonth").Value = dtDate.Month
                DataGridView1.SelectedRows(0).Cells("PersonDay").Value = dtDate.Day
                DataGridView1.SelectedRows(0).Cells("PersonYear").Value = dtDate.Year
            End If
        End If

    End Sub

    Private Sub DescToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescToolStripMenuItem1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            DataGridView1.SelectedRows(0).Cells("PersonDesc").Value = My.Computer.Clipboard.GetText()
        End If
    End Sub

    Private Sub FindPeople_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

    Private Sub FindPeople_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.findformpos)
    End Sub

    Private Sub ReCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReCheckToolStripMenuItem.Click
        FindinDb()
    End Sub

    Private Sub frmSearchDb_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        My.Settings.findformpos = setFormPos(Me)
        My.Settings.Save()
    End Sub

    Private Sub btnWikiFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWikiFind.Click

        If DataGridView1.SelectedRows.Count > 0 Then
            _searchName = DataGridView1.SelectedRows(0).Cells("PersonName").Value
            FindinWiki()
        End If

    End Sub

    Private Sub btnDbFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDbFind.Click
        FindinDb()
    End Sub

    Private Sub FindinDb()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim oRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim iPos As Integer = oRow.Index
            If oRow.Cells(Me.PersonName.Name).Value IsNot Nothing Then
                Dim sName As String = oRow.Cells(Me.PersonName.Name).Value
                DataGridView1.Rows.RemoveAt(iPos)
                CheckName(sName, iPos)
            Else
                MsgBox("No person selected", MsgBoxStyle.Exclamation, "Error")
            End If
        End If
    End Sub

    Public Sub FindinWiki()
        Dim searchstring As String = "http://en.wikipedia.org/w/index.php?search="
        _url = searchstring & _searchName
        lblNav.Text = "Finding " & _searchName
        WebBrowser1.Navigate(_url)
    End Sub

    Public Sub FindinTwitter()
        Dim searchstring As String = "https://twitter.com/search?f=users&src=typd&q="
        _url = searchstring & _searchName
        lblNav.Text = "Finding " & _searchName
        WebBrowser1.Navigate(_url)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub btnFwd_Click(sender As Object, e As EventArgs) Handles btnFwd.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        WebBrowser1.Navigate(txtURL.Text)
    End Sub
End Class

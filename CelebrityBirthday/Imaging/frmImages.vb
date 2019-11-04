﻿Imports System.IO
Imports System.Text

Public Class FrmImages
#Region "constants"
    Private Const NO_LOAD_DATE As String = "No load date available"
    Private Const ID_NOT_FOUND As String = "Id not found"
    Private Const SEP As String = "/"
#End Region
#Region "properties"
    Private _personId As Integer
    Public Property PersonId() As Integer
        Get
            Return _personId
        End Get
        Set(ByVal value As Integer)
            _personId = value
        End Set
    End Property
#End Region

#Region "variables"
    Private bLoadingPerson As Boolean = False
    Private personTable As ArrayList
    Private bLoadingPeople As Boolean
#End Region
#Region "control handlers"
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        CloseForm()
    End Sub
    Private Sub FrmImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetFormPos(Me, My.Settings.imgformpos)
        ClearDetails()
        txtLoadYr.Text = String.Empty
        txtLoadMth.Text = String.Empty
        cbImgType.SelectedIndex = 0
        bLoadingPerson = False
        If _personId > 0 Then
            LoadScreenFromId(_personId)
        End If
    End Sub
    Private Sub BtnFindImage_Click(sender As Object, e As EventArgs) Handles BtnFindImage.Click
        Using _imagestore As New frmImageStore
            _imagestore.Forename = TxtForename.Text.Trim
            _imagestore.Surname = TxtSurname.Text.Trim
            _imagestore.ShowDialog()
        End Using
    End Sub
    Private Sub BirthDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDay.SelectedIndexChanged, cboMonth.SelectedIndexChanged
        lblStatus.Text = String.Empty
        If cboDay.SelectedIndex >= 0 And cboMonth.SelectedIndex >= 0 Then
            lblStatus.Text = "Loading Table From Database"
            Me.Refresh()
            personTable = New ArrayList
            ListBoxPeople.Items.Clear()
            personTable = GetPeopleByDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1)
            For Each oPerson As Person In personTable
                ListBoxPeople.Items.Add(oPerson.BirthYear & " " & oPerson.Name)
            Next
            Dim loadDate As Date? = GetWordPressLoadDate(cboDay.SelectedIndex + 1, cboMonth.SelectedIndex + 1, "I")
            If loadDate IsNot Nothing Then
                TxtWpLoadMth.Text = Format(loadDate.Value, "MM")
                TxtWpLoadYear.Text = Format(loadDate.Value, "yyyy")
                lblWpDateMsg.Text = String.Empty
            Else
                TxtWpLoadMth.Text = String.Empty
                TxtWpLoadYear.Text = String.Empty
                lblWpDateMsg.Text = NO_LOAD_DATE
            End If
            lblStatus.Text += " - Complete"
        End If
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearDetails()
        DgvPeople.Rows.Clear()
    End Sub
    Private Sub DgvPeople_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPeople.SelectionChanged
        If Not bLoadingPeople Then
            If DgvPeople.SelectedRows.Count = 1 Then
                Dim _id As Integer = DgvPeople.SelectedRows(0).Cells(SelPersonId.Name).Value
                txtId.Text = CStr(_id)
                LoadScreenFromId(_id)
            End If
        End If
    End Sub
    Private Sub BtnSearchByName_Click(sender As Object, e As EventArgs) Handles BtnSearchByName.Click
        bLoadingPeople = True
        DgvPeople.Rows.Clear()
        Dim selectedPersons As ArrayList = GetPeopleLikeName(TxtForename.Text, TxtSurname.Text)
        For Each oPerson As Person In selectedPersons
            Dim tRow As DataGridViewRow = DgvPeople.Rows(DgvPeople.Rows.Add)
            tRow.Cells(SelPersonId.Name).Value = oPerson.Id
            tRow.Cells(SelPersonName.Name).Value = oPerson.Name
            tRow.Cells(SelPersonYear.Name).Value = oPerson.BirthYear
        Next
        DgvPeople.ClearSelection()
        bLoadingPeople = False
    End Sub
    Private Sub LbPeople_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxPeople.SelectedIndexChanged
        lblStatus.Text = String.Empty
        bLoadingPerson = True
        If ListBoxPeople.SelectedIndex >= 0 Then
            Dim oPerson As Person = personTable(ListBoxPeople.SelectedIndex)
            txtId.Text = oPerson.Id
            LoadScreenFromPerson(oPerson)
        Else
            ClearDetails()
        End If
        bLoadingPerson = False
    End Sub
    Private Sub FrmImages_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.imgformpos = SetFormPos(Me)
        My.Settings.Save()
    End Sub
    Private Sub BtnMakeImgName_Click(sender As Object, e As EventArgs) Handles BtnMakeImgName.Click
        txtImgName.Text = MakeImageName(TxtForename.Text, TxtSurname.Text)
    End Sub
    Private Sub BtnSearchById_Click(sender As Object, e As EventArgs) Handles BtnSearchById.Click
        LoadScreenFromId(txtId.Text)
    End Sub
    Private Sub BtnPicSave_Click(sender As Object, e As EventArgs) Handles BtnPicSave.Click
        Dim oFilename As String = Path.Combine(My.Settings.ImgPath, txtImgName.Text & cbImgType.SelectedItem)
        SaveImage(TxtImageUrl.Text, oFilename)
    End Sub
    Private Sub BtnLoadDateUpdate_Click(sender As Object, e As EventArgs) Handles BtnLoadDateUpdate.Click
        Dim _id As Integer = CInt(txtId.Text)
        If IsExistsImage(_id) Then
            UpdateImage(_id, txtImgName.Text, cbImgType.SelectedItem, txtLoadMth.Text, txtLoadYr.Text)
        Else
            InsertImage(_id, txtImgName.Text, cbImgType.SelectedItem, txtLoadMth.Text, txtLoadYr.Text)
        End If
        Dim oImage As ImageIdentity = GetImageById(_id)
        Dim currentPerson = FindPersonById(_id)
        If currentPerson IsNot Nothing Then
            currentPerson.image = oImage
        End If
        LoadScreenFromPerson(currentPerson)
    End Sub
    Private Sub BtnUrlCopy_Click(sender As Object, e As EventArgs) Handles BtnUrlCopy.Click
        Clipboard.SetText(TxtImageUrl.Text)
    End Sub
    Private Sub BtnFilenameCopy_Click(sender As Object, e As EventArgs) Handles BtnFilenameCopy.Click
        Clipboard.SetText(TxtImageFilename.Text)
    End Sub
    Private Sub BtnWpImageRefresh_Click(sender As Object, e As EventArgs) Handles BtnWpImageRefresh.Click
        PictureBox1.ImageLocation = TxtImageUrl.Text
    End Sub
    Private Sub BtnFileImageRefresh_Click(sender As Object, e As EventArgs) Handles BtnFileImageRefresh.Click
        PictureBox2.ImageLocation = TxtImageFilename.Text
    End Sub
    Private Sub BtnFileImgGen_Click(sender As Object, e As EventArgs) Handles BtnFileImgGen.Click
        TxtImageFilename.Text = Path.Combine(My.Settings.ImgPath, txtImgName.Text & cbImgType.SelectedItem)
    End Sub
    Private Sub BtnWpImgGen_Click(sender As Object, e As EventArgs) Handles BtnWpImgGen.Click
        TxtImageUrl.Text = My.Settings.WordPressUrl & txtLoadYr.Text & SEP & txtLoadMth.Text & SEP & txtImgName.Text & cbImgType.SelectedItem
    End Sub
    Private Sub BtnCopyLoadDate_Click(sender As Object, e As EventArgs) Handles BtnCopyLoadDate.Click
        txtLoadMth.Text = TxtWpLoadMth.Text
        txtLoadYr.Text = TxtWpLoadYear.Text
    End Sub
#End Region
#Region "subroutines"
    Private Sub CloseForm()
        Me.Close()
    End Sub
    Private Sub ClearDetails()
        txtId.Text = String.Empty
        TxtForename.Text = String.Empty
        TxtSurname.Text = String.Empty
        txtImgName.Text = String.Empty
        txtLoadMth.Text = String.Empty
        txtLoadYr.Text = String.Empty
        PictureBox1.ImageLocation = String.Empty
        PictureBox2.ImageLocation = String.Empty
        cbImgType.SelectedIndex = -1
        lblImgDateMsg.Text = String.Empty
    End Sub
    Private Function LoadScreenFromId(ByVal oId As Integer) As Person
        Dim oPerson As Person = Nothing
        Try
            oPerson = GetFullPersonById(oId)
            If oPerson IsNot Nothing Then
                LoadScreenFromPerson(oPerson)
                Dim _dob As Date = New Date(oPerson.BirthYear, oPerson.BirthMonth, oPerson.BirthDay)
                cboDay.SelectedIndex = CStr(_dob.Day) - 1
                cboMonth.SelectedIndex = cboMonth.FindString(Format(_dob, "MMMM"))
            Else
                lblStatus.Text = ID_NOT_FOUND
            End If
        Catch ex As Exception
            lblStatus.Text = "Unable to load Person" & vbCrLf & ex.Message
        End Try
        Return oPerson
    End Function
    Private Sub LoadScreenFromPerson(ByRef oPerson As Person)
        ClearDetails()
        txtId.Text = oPerson.Id
        TxtForename.Text = oPerson.ForeName
        TxtSurname.Text = oPerson.Surname
        If oPerson.Image IsNot Nothing Then
            txtImgName.Text = oPerson.Image.ImageFileName
            cbImgType.SelectedIndex = cbImgType.FindString(oPerson.Image.ImageFileType)
            Dim sYear As String = oPerson.Image.ImageLoadYear
            Dim sMth As String = oPerson.Image.ImageLoadMonth
            txtLoadMth.Text = sMth
            txtLoadYr.Text = sYear
            Try
                Dim sSimplename As String = MakeImageName(TxtForename.Text, TxtSurname.Text)
                Dim generatedImageName As String = Path.Combine(My.Settings.ImgPath, sSimplename & cbImgType.SelectedItem)
                Dim storedImageName As String = Path.Combine(My.Settings.ImgPath, oPerson.Image.ImageFileName.Trim & cbImgType.SelectedItem)
                TxtImageFilename.Text = storedImageName
                PictureBox1.ImageLocation = String.Empty
                PictureBox2.ImageLocation = String.Empty
                PictureBox1.ImageLocation = My.Settings.WordPressUrl & sYear & SEP & sMth & SEP & oPerson.Image.FullFileName
                TxtImageUrl.Text = PictureBox1.ImageLocation
                If Not String.IsNullOrEmpty(oPerson.Image.ImageFileName.Trim) AndAlso Not My.Computer.FileSystem.FileExists(storedImageName) Then
                    SaveImage(PictureBox1.ImageLocation, storedImageName)
                End If
                PictureBox2.ImageLocation = storedImageName
            Catch ex As Exception
                lblStatus.Text = ex.Message
            End Try

        End If
    End Sub
    Private Function FindPersonById(_id As Integer)
        Dim thisPerson As Person = Nothing
        For Each oPerson As Person In personTable
            If oPerson.Id = _id Then
                thisPerson = oPerson
            End If
        Next
        Return thisPerson
    End Function

#End Region
End Class
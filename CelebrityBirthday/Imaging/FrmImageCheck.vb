' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.IO

Public Class FrmImageCheck
#Region "constants"
    Private Const SEP As String = "/"
#End Region
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FrmImageCheck_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub FrmImageCheck_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub BtnLoadDateUpdate_Click(sender As Object, e As EventArgs) Handles BtnLoadDateUpdate.Click
        'If String.IsNullOrEmpty(txtImgName.Text) Then
        '    txtImgName.Text = MakeImageName(TxtForename.Text, TxtSurname.Text)
        'End If
        'If String.IsNullOrEmpty(txtLoadMth.Text) And String.IsNullOrEmpty(txtLoadYr.Text) Then
        '    txtLoadMth.Text = TxtWpLoadMth.Text
        '    txtLoadYr.Text = TxtWpLoadYear.Text
        'End If
        'Dim _id As Integer = CInt(txtId.Text)
        'If IsExistsImage(_id) Then
        '    UpdateImage(_id, txtImgName.Text, cbImgType.Text, txtLoadMth.Text, txtLoadYr.Text)
        'Else
        '    InsertImage(_id, txtImgName.Text, cbImgType.Text, txtLoadMth.Text, txtLoadYr.Text)
        'End If
        'Dim oImage As ImageIdentity = GetImageById(_id)
        'Dim currentPerson As Person = FindPersonById(_id)
        'If currentPerson IsNot Nothing Then
        '    currentPerson.Image = oImage
        'End If
        'LoadScreenFromPerson(currentPerson)
        'oImage.Dispose()
        'currentPerson.Dispose()
    End Sub
    Private Sub BtnPicSave_Click(sender As Object, e As EventArgs) Handles BtnPicSave.Click
        'If String.IsNullOrEmpty(TxtImageFilename.Text) Then
        '    TxtImageFilename.Text = Path.Combine(My.Settings.ImgPath, txtImgName.Text & cbImgType.Text)
        'End If
        'PictureBox2.Image.Dispose()
        'PictureBox2.ImageLocation = ""
        'SaveImage(New Uri(TxtImageUrl.Text), TxtImageFilename.Text)
        'PictureBox2.ImageLocation = TxtImageFilename.Text
    End Sub
    Private Sub BtnFindImage_Click(sender As Object, e As EventArgs) Handles BtnFindImage.Click
        Dim _savedFile As String = Nothing
        Using _imagestore As New FrmImageStore
            _imagestore.Forename = TxtForename.Text.Trim
            _imagestore.Surname = TxtSurname.Text.Trim
            _imagestore.ShowDialog()
            _savedFile = _imagestore.SavedImage
        End Using
        If Not String.IsNullOrEmpty(_savedFile) Then
            ReplaceImageFile(_savedFile)
        End If
    End Sub
    Private Sub ReplaceImageFile(savedFile As String)
        If MsgBox("Use new saved file?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "New image") = MsgBoxResult.Yes Then
            txtImgName.Text = Path.GetFileNameWithoutExtension(savedFile)
            TxtImageFilename.Text = Path.Combine(My.Settings.ImgPath, txtImgName.Text & cbImgType.Text)
            PictureBox2.ImageLocation = TxtImageFilename.Text
        End If
    End Sub
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
                Dim generatedImageName As String = Path.Combine(My.Settings.ImgPath, sSimplename & cbImgType.Text)
                Dim storedImageName As String = Path.Combine(My.Settings.ImgPath, oPerson.Image.ImageFileName.Trim & cbImgType.Text)
                TxtImageFilename.Text = storedImageName
                PictureBox1.ImageLocation = String.Empty
                PictureBox2.ImageLocation = String.Empty
                PictureBox1.ImageLocation = My.Settings.WordPressUrl & sYear & SEP & sMth & SEP & oPerson.Image.FullFileName
                TxtImageUrl.Text = PictureBox1.ImageLocation
                If Not String.IsNullOrEmpty(oPerson.Image.ImageFileName.Trim) AndAlso Not My.Computer.FileSystem.FileExists(storedImageName) Then
                    SaveImage(New Uri(PictureBox1.ImageLocation), storedImageName)
                End If
                If oPerson.Image.Photo IsNot Nothing Then
                    PictureBox2.Image = oPerson.Image.Photo
                Else
                    PictureBox2.ImageLocation = storedImageName
                End If

            Catch ex As ArgumentException
                ShowStatus("Error loading person", LblStatus, True, MyBase.Name, ex)
            End Try
        End If
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
    Private Function FindPersonById(_id As Integer) As Person
        Dim thisPerson As Person = Nothing
        'For Each oPerson As Person In personTable
        '    If oPerson.Id = _id Then
        '        thisPerson = oPerson
        '    End If
        'Next
        Return thisPerson
    End Function

    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, LblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, LblStatus, True, MyBase.Name,, isMessagebox)
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim _personList As List(Of Person) = GetAllPersons()
        For Each _person As Person In _personList
            If _person.Image Is Nothing OrElse _person.Image.Photo Is Nothing Then
                AddTableRow(_person, 0)
                LoadScreenFromPerson(_person)
                Refresh()
                ShowStatus(_person.Id & " " & _person.Name & " Image file missing", LblStatus, True, MyBase.Name)
            Else
                ShowStatus(_person.Id & " " & _person.Name, LblStatus, False, MyBase.Name)
            End If
        Next
    End Sub
    Private Sub AddTableRow(pPerson As Person, pErr As Integer)
        Dim newRow As DataGridViewRow = DgvMissingImages.Rows(DgvMissingImages.Rows.Add)
        newRow.Cells(personId.Name).Value = pPerson.Id
        newRow.Cells(PersonName.Name).Value = pPerson.Name
        newRow.Cells(personError.Name).Value = pErr
    End Sub
End Class

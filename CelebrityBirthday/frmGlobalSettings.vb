''' <summary>
''' Form to maintain Global Settings values
''' </summary>
''' <remarks>Global Settings are settings which must be the same for all system users.
''' The Keys for the settings are hardcoded so the records must not be deleted from the table.
''' New setting records are not needed unless the code changes, so they cannot be created here.</remarks>
Public Class FrmGlobalSettings
#Region "Constants"
    Private Const FORM_NAME As String = "Global Settings"
#End Region
#Region "Private variable instances"
    Private ReadOnly oTa As New CelebrityBirthdayDataSetTableAdapters.SettingsTableAdapter
    Private ReadOnly oTable As New CelebrityBirthdayDataSet.SettingsDataTable
#End Region
#Region "Form"
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oTa.Fill(oTable)
        cbSelect.DataSource = oTable
        cbSelect.DisplayMember = "pKey"
        cbSelect.ValueMember = "pKey"
        lblFormName.Text = FORM_NAME
        clearForm()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearForm()
        cbSelect.SelectedIndex = -1
        cbType.SelectedValue = 0
        txtValue.Text = ""
    End Sub

    Private Sub FillForm(ByVal _name As String)
        Dim _table As New CelebrityBirthdayDataSet.SettingsDataTable
        Dim i As Integer = oTa.FillByName(_table, _name)
        If i = 1 Then
            Dim oRow As CelebrityBirthdayDataSet.SettingsRow = _table.Rows(0)
            txtValue.Text = oRow.pValue
            cbType.SelectedIndex = cbType.FindString(oRow.pType)
        Else
            lblStatus.Text = "Cannot identify a single record"
        End If
        _table.Dispose()
    End Sub

    Private Sub CbSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSelect.SelectedIndexChanged
        If cbSelect.SelectedIndex > -1 Then
            If TypeOf cbSelect.SelectedValue Is String Then
                FillForm(cbSelect.SelectedValue)
            End If
        Else
            ClearForm()
        End If
    End Sub
#End Region
#Region "Update"

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If cbSelect.SelectedIndex > -1 Then
            Dim recordId As String = cbSelect.SelectedValue

            If GlobalSettings.setSetting(recordId, cbType.SelectedItem, txtValue.Text) Then
                LogStatus(recordId & " updated")
            Else
                LogStatus(recordId & " NOT updated")
            End If
        Else
            MsgBox("Pick an item from the list", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Selection error")
        End If
        oTa.Fill(oTable)
        ClearForm()
    End Sub
#End Region
#Region "Subroutines"
    Private Sub LogStatus(ByVal sText As String)
        lblStatus.Text = sText
    End Sub
#End Region
End Class
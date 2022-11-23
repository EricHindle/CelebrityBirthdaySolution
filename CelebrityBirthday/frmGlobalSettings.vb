' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Data.Common
''' <summary>
''' Form to maintain Global Settings values
''' </summary>
''' <remarks>Global Settings are settings which must be the same for all system users.
''' The Keys for the settings are hardcoded so the records must not be deleted from the table.
''' New setting records are not needed unless the code changes, so they cannot be created here.</remarks>
Public Class FrmGlobalSettings
#Region "Private variable instances"
    Private ReadOnly oTa As New CelebrityBirthdayDataSetTableAdapters.SettingsTableAdapter
    Private ReadOnly oTable As New CelebrityBirthdayDataSet.SettingsDataTable
#End Region
#Region "Form"
    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LogUtil.Info("Loading", MyBase.Name)
        Try
            oTa.Fill(oTable)
        Catch ex As DbException
            LogUtil.Problem("Exception during Global Settings table load : " & ex.Message)
        End Try
        cbSelect.DataSource = oTable
        cbSelect.DisplayMember = "pKey"
        cbSelect.ValueMember = "pKey"
        lblFormName.Text = My.Resources.GLOBAL_SETTINGS
        ClearForm()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub ClearForm()
        cbSelect.SelectedIndex = -1
        cbType.SelectedValue = 0
        txtValue.Text = ""
        TxtGroup.Text = ""
    End Sub

    Private Sub FillForm(ByVal _name As String)
        Dim _table As New CelebrityBirthdayDataSet.SettingsDataTable
        Dim i As Integer = oTa.FillByName(_table, _name)
        If i = 1 Then
            Dim oRow As CelebrityBirthdayDataSet.SettingsRow = _table.Rows(0)
            txtValue.Text = oRow.pValue
            cbType.SelectedIndex = cbType.FindString(oRow.pType)
            TxtGroup.Text = oRow.pGroup
        Else
            lblStatus.Text = My.Resources.NO_SINGLE_RECORD
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

            If GlobalSettings.SetSetting(recordId, cbType.SelectedItem, txtValue.Text, TxtGroup.Text) Then
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
    'Form overrides dispose to clean up the component list.
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing Then
                oTa.Dispose()
                oTable.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private Sub FrmGlobalSettings_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        LogUtil.Info("Closing", MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, lblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, lblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
#End Region
End Class
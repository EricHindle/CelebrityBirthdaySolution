Imports System.Text

Public Class FrmRmvPost
    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        LblMessage.Text = ""
        If Not String.IsNullOrEmpty(TxtExistingNo.Text) AndAlso IsNumeric(TxtExistingNo.Text) Then
            Dim _postNo As Integer = CInt(TxtExistingNo.Text)
            Dim postRows As DataRowCollection = GetBotsdViewByPostNo(_postNo)
            Dim postRowDetails As New StringBuilder
            For Each postRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow In postRows
                Dim updCt As Integer = UpdateBotsdId(postRow.personId, 0)
                postRowDetails.Clear()
                postRowDetails.Append(postRow.forename).Append(" ").Append(postRow.surname).Append(" (").Append(postRow.birthyear).Append(" - ").Append(If(postRow.deathyear <> 0, postRow.deathyear, "")).Append(")")
                If updCt > 0 Then
                    postRowDetails.Append(" updated")
                Else
                    postRowDetails.Append(" **ERROR")
                End If
                LblMessage.Text &= postRowDetails.ToString & vbCrLf
            Next
            Dim delCt As Integer = DeleteBotsdByPostNo(_postNo)
            postRowDetails.Clear()
            postRowDetails.Append("Post ").Append(_postNo)
            If delCt > 0 Then
                postRowDetails.Append(" deleted")
            Else
                postRowDetails.Append(" **ERROR")
            End If
            LblMessage.Text &= postRowDetails.ToString
            Else
                MsgBox("Must supply existing and new numbers", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
        LblMessage.Text = ""
        If Not String.IsNullOrEmpty(TxtExistingNo.Text) AndAlso IsNumeric(TxtExistingNo.Text) Then
            Dim _postNo As Integer = CInt(TxtExistingNo.Text)
            Dim postRows As DataRowCollection = GetBotsdViewByPostNo(_postNo)
            If postRows.Count > 0 Then
                For Each postRow As CelebrityBirthdayDataSet.BornOnTheSameDayRow In postRows
                    Dim postRowDetails As New StringBuilder
                    postRowDetails.Append(postRow.forename).Append(" ").Append(postRow.surname).Append(" (").Append(postRow.birthyear).Append(" - ").Append(If(postRow.deathyear <> 0, postRow.deathyear, "")).Append(")")
                    LblMessage.Text &= postRowDetails.ToString & vbCrLf
                Next
            Else
                LblMessage.Text = "No post found for this number"
            End If
        Else
            LblMessage.Text = "Must supply existing post number"
        End If
    End Sub
End Class
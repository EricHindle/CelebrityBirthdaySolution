' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Partial Class CelebrityBirthdayDataSet
    Partial Public Class FullPersonDataTable
        Private Sub FullPersonDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If e.Column.ColumnName = imgloadyrColumn.ColumnName Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

Namespace CelebrityBirthdayDataSetTableAdapters

End Namespace

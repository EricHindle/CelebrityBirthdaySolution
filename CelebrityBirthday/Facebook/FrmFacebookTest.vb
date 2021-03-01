Imports Facebook
Public NotInheritable Class FrmFacebookTest
    Private Sub BtnTest1_Click(sender As Object, e As EventArgs) Handles BtnTest1.Click
        Dim accessToken As String = "EAACHZBQRkG5wBADWZCSL1VkG7G0vfZCsNNXvr3egVqsrOxQpMMAZCSxK2LlChtPxPtCxvwMZCxb5Tr2lO7uWzooZCEzjP0ILNxbZAteDTUb5ZBUSdwTO9EWrJejZAl8tPxHxcDKb36bkr0DZAqzcZCYhJGnHOJBAZC9jnImRaR7YWfZAihgZDZD"

        Dim client As New FacebookClient(accessToken)
        client.AppId = "149503590275996"
        Dim botsdId As String = "148115045309594"
        Dim myId As String = "4949346001774389"
        Try
            Dim params As New JsonObject From {
                New KeyValuePair(Of String, Object)("access_token", accessToken)
            }
            Dim response As JsonObject = client.Get("me/accounts", params)

            RichTextBox1.Text = response.ToString
            Dim pageAccessToken As Object = ""
            Dim pageId As Object = ""
            Dim jarray As JsonArray = Nothing
            response.TryGetValue("data", jarray)
            Dim jobj As Facebook.JsonObject = jarray(0)

            jobj.TryGetValue("id", pageId)
            jobj.TryGetValue("access_token", pageAccessToken)

            Dim postparams As New JsonObject
            postparams.Add(New KeyValuePair(Of String, Object)("message", "Happy New Year to all our readers."))
            postparams.Add(New KeyValuePair(Of String, Object)("access_token", pageAccessToken))
            RichTextBox1.Text &= vbCrLf & vbCrLf & pageAccessToken

            '          RichTextBox1.Text &= vbCrLf & vbCrLf & client.Post(postparams).ToString()

        Catch ex As Reflection.TargetParameterCountException
            LogUtil.Exception("Exception", ex, MyBase.Name)

        Catch ex As FacebookOAuthException
            LogUtil.Exception("Exception", ex, MyBase.Name)
        End Try


    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
End Class
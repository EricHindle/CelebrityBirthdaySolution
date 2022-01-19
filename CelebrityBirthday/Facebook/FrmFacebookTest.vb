Imports Facebook
Public NotInheritable Class FrmFacebookTest
    Private Const EMAIL_TO_ADDRESS As String = "SendErrorTo"
    Private Const EMAIL_FROM_ADDRESS As String = "SendEmailFrom"
    Private Const SMTP_USERNAME As String = "SMTPUsername"
    Private Const SMTP_PASSWORD As String = "SMTPPassword"
    Private Const SMTP_HOST As String = "SMTPHost"
    Private Const SMTP_REQ_CRED As String = "SMTPRequiresCredentials"
    Private Const SMTP_PORT As String = "SMTPPort"
    Private Const SMTP_SSL As String = "SMTPEnableSSL"

    Private Sub BtnTest1_Click(sender As Object, e As EventArgs) Handles BtnTest1.Click
        Dim accessToken As String = "EAACHZBQRkG5wBADWZCSL1VkG7G0vfZCsNNXvr3egVqsrOxQpMMAZCSxK2LlChtPxPtCxvwMZCxb5Tr2lO7uWzooZCEzjP0ILNxbZAteDTUb5ZBUSdwTO9EWrJejZAl8tPxHxcDKb36bkr0DZAqzcZCYhJGnHOJBAZC9jnImRaR7YWfZAihgZDZD"

        Dim client As New FacebookClient(accessToken) With {
            .AppId = "149503590275996"
        }
        'Dim botsdId As String = "148115045309594"
        'Dim myId As String = "4949346001774389"
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

            Dim postparams As New JsonObject From {
                New KeyValuePair(Of String, Object)("message", "Happy New Year to all our readers."),
                New KeyValuePair(Of String, Object)("access_token", pageAccessToken)
            }
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DisplayAndLog("Sending")
        EmailUtil.TestEmailSend(TxtFrom.Text.Trim,
                                TxtTo.Text.Trim,
                                TxtSubject.Text.Trim,
                                TxtBody.Text.Trim,
                                TxtName.Text.Trim,
                                TxtHost.Text.Trim,
                                CInt(TxtPort.Text),
                                TxtUsername.Text.Trim,
                                TxtPassword.Text.Trim,
                                cbSSL.Checked)
        DisplayAndLog("Done")
    End Sub

    Private Sub FrmFacebookTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtName.Text = "Eric Hindle"
        TxtSubject.Text = "Testing vb.net email"
        TxtFrom.Text = GlobalSettings.GetSetting(EMAIL_FROM_ADDRESS)
        TxtTo.Text = GlobalSettings.GetSetting(EMAIL_TO_ADDRESS)
        TxtHost.Text = GlobalSettings.GetSetting(SMTP_HOST)
        TxtPort.Text = GlobalSettings.GetIntegerSetting(SMTP_PORT)
        TxtUsername.Text = GlobalSettings.GetSetting(SMTP_USERNAME)
        TxtPassword.Text = GlobalSettings.GetSetting(SMTP_PASSWORD)
        TxtGmail.Text = "qmzlhznjpxwgcayk"
        cbSSL.Checked = GlobalSettings.GetBooleanSetting(SMTP_SSL)
    End Sub

    Private Sub TxtFrom_TextChanged(sender As Object, e As EventArgs) Handles TxtFrom.TextChanged, TxtTo.TextChanged, TxtHost.TextChanged, TxtPort.TextChanged, TxtUsername.TextChanged, TxtPassword.TextChanged
        FillBody()
    End Sub

    Private Sub FillBody()
        TxtBody.Text = TxtFrom.Text & vbCrLf &
             TxtTo.Text & vbCrLf &
            TxtHost.Text & vbCrLf &
            TxtPort.Text & vbCrLf &
            TxtUsername.Text & vbCrLf &
            TxtPassword.Text & vbCrLf &
            CStr(cbSSL.Checked)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TxtPassword.Text = TxtGmail.Text
    End Sub
    Private Sub DisplayAndLog(pText As String)
        ShowProgress(pText, LblStatus, True, MyBase.Name)
    End Sub
    Private Sub DisplayAndLog(pText As String, isMessagebox As Boolean)
        ShowProgress(pText, LblStatus, True, MyBase.Name,, isMessagebox)
    End Sub
End Class
' Hindleware
' Copyright (c) 2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Imports System.Drawing
Imports System.IO
Imports System.Net
Imports System.Net.Mime

''' <summary>
''' Utility for sending emails
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class EmailUtil
    Private Const className As String = "EmailUtil"
    Private Const USE_SMTP As String = "UseSMTP"
    Private Const SMTP_USERNAME As String = "SMTPUsername"
    Private Const SMTP_PASSWORD As String = "SMTPPassword"
    Private Const SMTP_HOST As String = "SMTPHost"
    Private Const SMTP_REQ_CRED As String = "SMTPRequiresCredentials"
    Private Const SMTP_PORT As String = "SMTPPort"
    Private Const SMTP_SSL As String = "SMTPEnableSSL"
    Private Const SEND_VIA As String = "SendMailViaSMTP"

    ''' <summary>
    ''' Send an email
    ''' </summary>
    ''' <param name="strToName">List of To email addresses</param>
    ''' <param name="strCC">List of cc email addresses</param>
    ''' <param name="strSubject">Email subject text</param>
    ''' <param name="strBody">Email body text</param>
    ''' <param name="strFilenames">List of files to be attached</param>
    ''' <param name="bodyType">Indicator to show HTML or plain text body</param>
    ''' <param name="oFont">Font for HTML body</param>
    ''' <param name="deleteAfterSubmit">Indicator to show if email should be retained in the outbox (and sent mail table)</param>
    ''' <returns>True if email sent OK</returns>
    ''' <remarks></remarks>
    Public Shared Function SendMail(ByVal strFromAddr As String,
                                    ByVal strToName As String,
                                      ByVal strCC As String(),
                                      ByVal strSubject As String,
                                      ByVal strBody As String,
                                      Optional ByVal strFromName As String = Nothing,
                                      Optional ByVal strFilenames As String() = Nothing,
                                      Optional ByVal bodyType As Integer = 1,
                                      Optional ByVal oFont As System.Drawing.Font = Nothing,
                                      Optional ByVal deleteAfterSubmit As Boolean = False,
                                      Optional ByVal readReceiptRequired As Boolean = False,
                                      Optional ByVal deliveryReportRequired As Boolean = False) As Boolean
        Return SendMailViaSMTP(strFromAddr,
                               strToName,
                               strCC,
                               strSubject,
                               strBody,
                               strFromName,
                               strFilenames,
                               bodyType,
                               oFont,
                               deleteAfterSubmit,
                               readReceiptRequired,
                               deliveryReportRequired)
    End Function
    '
    ' Sends an email via SMTP
    '    
    Public Shared Function SendMailViaSMTP(ByVal strFromAddress As String,
                                           ByVal strToAddress As String,
                                          ByVal strCC As String(),
                                          ByVal strSubject As String,
                                          ByVal strBody As String,
                                          Optional ByVal strFromName As String = Nothing,
                                          Optional ByVal strFilenames As String() = Nothing,
                                          Optional ByVal bodyType As Integer = 1,
                                          Optional ByVal oFont As System.Drawing.Font = Nothing,
                                          Optional ByVal deleteAfterSubmit As Boolean = False,
                                          Optional ByVal readReceiptRequired As Boolean = False,
                                          Optional ByVal deliveryReportRequired As Boolean = False) As Boolean
        LogUtil.Info("Sending email by SMTP", SEND_VIA)
        Dim isSentOK As Boolean
        Try
            Dim objMessage As Mail.MailMessage
            Dim objEmailClient As New Mail.SmtpClient
            If String.IsNullOrEmpty(strToAddress) Then
                LogUtil.Problem("No 'To' email address specified", SEND_VIA)
                Throw New ApplicationException("Error: No To address")
            End If
            objMessage = New Mail.MailMessage(strFromAddress, strToAddress, strSubject, strBody)
            If Not String.IsNullOrEmpty(strFromName) Then
                objMessage.From = New Mail.MailAddress(strFromAddress, strFromName)
            End If
            Dim smtpUserName As String = GlobalSettings.GetSetting(SMTP_USERNAME)
            Dim smtpPassword As String = GlobalSettings.GetSetting(SMTP_PASSWORD)
            Dim bodyformat As Integer = bodyType
            If bodyformat = 0 Then
                ConvertBodyToHtml(strBody, oFont, objMessage)
                objMessage.IsBodyHtml = True
            End If

            '
            ' Validate the parameters
            '
            Dim strSmtpHost As String = GlobalSettings.GetSetting(SMTP_HOST)
            If String.IsNullOrEmpty(strSmtpHost) Then
                LogUtil.Problem("No smtp host specified", SEND_VIA)
                Throw New ApplicationException("Error: No Mail Host")
            End If
            If strCC IsNot Nothing AndAlso strCC.Length > 0 Then
                For Each ccAddress As String In strCC
                    If Not String.IsNullOrEmpty(ccAddress) Then
                        objMessage.CC.Add(New Mail.MailAddress(ccAddress))
                    End If
                Next
            End If
            '
            ' If there is no file name or file cannot be found continue with no attachment
            '
            If strFilenames IsNot Nothing AndAlso strFilenames.Length > 0 Then
                For Each strFilename As String In strFilenames
                    If My.Computer.FileSystem.FileExists(strFilename) Then
                        LogUtil.Info("Adding attachment " & strFilename, SEND_VIA)
                        objMessage.Attachments.Add(New Mail.Attachment(strFilename))
                    Else
                        LogUtil.Problem("Cannot find attachment " & strFilename, SEND_VIA)
                    End If
                Next
            End If
            '
            ' Connect to the host
            '
            LogUtil.Info("Setting host")
            LogUtil.Info(strSmtpHost)
            objEmailClient.Host = strSmtpHost

            If GlobalSettings.GetBooleanSetting(SMTP_REQ_CRED) Then
                LogUtil.Info("Setting credentials")
                LogUtil.Info(smtpUserName)
                LogUtil.Info(smtpPassword)
                objEmailClient.Credentials = New NetworkCredential(smtpUserName, smtpPassword)
            End If

            Dim strSmtpPort As Integer = GlobalSettings.GetIntegerSetting(SMTP_PORT)
            If strSmtpPort > 0 Then
                LogUtil.Info("Setting port")
                LogUtil.Info(strSmtpPort)
                objEmailClient.Port = strSmtpPort
            End If
            If GlobalSettings.GetBooleanSetting(SMTP_SSL) Then
                LogUtil.Info("SSL enabled")
                objEmailClient.EnableSsl = True
            End If
            '
            ' Send the email
            '

            objEmailClient.Send(objMessage)

            objMessage.Dispose()
            objMessage = Nothing
            objEmailClient = Nothing
            isSentOK = True
        Catch mailex As Mail.SmtpFailedRecipientsException
            LogUtil.Exception("SmtpFailedRecipientsException occurred sending email : ", mailex, SEND_VIA)
            isSentOK = False
        Catch ex As ApplicationException
            LogUtil.Exception("ApplicationException occurred sending email : ", ex, SEND_VIA)
            isSentOK = False
        Catch exc As System.Net.Mail.SmtpException
            LogUtil.Exception("SmtpException occurred sending email : ", exc, SEND_VIA)
            isSentOK = False
        End Try
        Return isSentOK
    End Function
    Private Shared Sub ConvertBodyToHtml(ByVal strBody As String, ByVal oFont As Font, ByRef objMessage As Mail.MailMessage)
        Dim attachlist As ArrayList = ConvertToHtml(strBody, oFont)
        With objMessage
            .Body = strBody
            For Each strImageFile As String In attachlist
                ' Create  the file attachment for this e-mail message.
                Dim data As New Mail.Attachment(strImageFile, MediaTypeNames.Application.Octet)
                .Attachments.Add(data)
            Next
        End With
    End Sub
    Private Shared Function ConvertToHtml(ByRef strBody As String, ByVal oFont As Font) As ArrayList
        Dim attachList As New ArrayList
        If oFont IsNot Nothing Then
            strBody = "<span style='font-size:" & oFont.SizeInPoints & "pt;font-family:""" & oFont.Name & """;color:black'>" &
            strBody & "</span>"
        End If
        strBody = strBody.Replace(vbCrLf, "<br />")
        '========= add image in the body ===========
        ' add image as an attachment
        ' include a tag inside the body HTML to pick up the image
        Do While True
            Dim iImgSt As Integer = strBody.IndexOf("{img:")
            If iImgSt > -1 Then
                Dim iImgEnd = strBody.IndexOf("}", iImgSt + 5)
                Dim strImageFile As String = strBody.Substring(iImgSt + 5, iImgEnd - iImgSt - 5)
                Dim sImage As String = Path.GetFileName(strImageFile)
                If My.Computer.FileSystem.FileExists(strImageFile) Then
                    attachList.Add(strImageFile)

                    strBody = strBody.Substring(0, iImgSt) &
                           "<IMG alt='' hspace=0 src='cid:" & sImage & "' align=baseline border=0>&nbsp;" &
                    strBody.Substring(iImgEnd + 1)
                Else
                    strBody = strBody.Substring(0, iImgSt) &
                    strBody.Substring(iImgEnd + 1)
                End If
            Else
                Exit Do
            End If
        Loop
        '=========

        Return attachList
    End Function

End Class

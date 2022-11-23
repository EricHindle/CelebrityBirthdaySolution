' Hindleware
' Copyright (c) 2019-2022 Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

Public Class DlgShowText
#Region "enums"
    Public Enum MessageStyle
        none
        plain
        warn
        critical
        night
        custom
    End Enum
#End Region
#Region "properties"

    Private _msg As String = ""
    Private _font As Font
    Private _backcolour As Color = Color.Black
    Private _forecolour As Color = Color.White
    Private _style As MessageStyle = MessageStyle.none
    Public Property Style() As MessageStyle
        Get
            Return _style
        End Get
        Set(ByVal value As MessageStyle)
            _style = value
        End Set
    End Property
    Public Property ForeColour() As Color
        Get
            Return _forecolour
        End Get
        Set(ByVal value As Color)
            _forecolour = value
        End Set
    End Property
    Public Property BackColour() As Color
        Get
            Return _backcolour
        End Get
        Set(ByVal value As Color)
            _backcolour = value
        End Set
    End Property
    Public Property MessageFont() As Font
        Get
            Return _font
        End Get
        Set(ByVal value As Font)
            _font = value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property
#End Region
#Region "form control handlers"
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        DialogResult = System.Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub DlgShowText_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _font Is Nothing Then _font = LblMessage.Font

        LblMessage.Text = _msg
        Select Case _style
            Case MessageStyle.plain
                LblMessage.BackColor = Color.White
                LblMessage.ForeColor = Color.Black
            Case MessageStyle.warn
                LblMessage.BackColor = Color.Blue
                LblMessage.ForeColor = Color.White
            Case MessageStyle.critical
                LblMessage.BackColor = Color.Red
                LblMessage.ForeColor = Color.Yellow
            Case MessageStyle.night
                LblMessage.BackColor = Color.Black
                LblMessage.ForeColor = Color.White
            Case MessageStyle.custom
                LblMessage.BackColor = _backcolour
                LblMessage.ForeColor = _forecolour
        End Select
        LblMessage.Font = _font
    End Sub
#End Region
End Class

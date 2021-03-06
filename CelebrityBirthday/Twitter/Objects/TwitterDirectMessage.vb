﻿
Public Class TwitterDirectMessage
        Inherits XmlObjectBase

        Private _ID As Int64
        Private _SenderID As Int64
        Private _Text As String = String.Empty
        Private _RecipientID As Int64
        Private _CreatedAt As DateTime
        Private _SenderScreenName As String = String.Empty
        Private _RecipientScreenName As String = String.Empty
        Private _Sender As New TwitterUser
        Private _Recipient As New TwitterUser


        ''' <summary>
        ''' The ID of the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An <c>Int64</c> representing the direct message ID.</returns>
        ''' <remarks></remarks>
        Public Property ID() As Int64
            Get
                Return _ID
            End Get
            Set(ByVal value As Int64)
                _ID = value
            End Set
        End Property

        ''' <summary>
        ''' The ID of the user who sent the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An <c>Int64</c> representing the sender's user ID.</returns>
        ''' <remarks></remarks>
        Public Property SenderID() As Int64
            Get
                Return _SenderID
            End Get
            Set(ByVal value As Int64)
                _SenderID = value
            End Set
        End Property

        ''' <summary>
        ''' The text of the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>String</c> representing the direct message.</returns>
        ''' <remarks></remarks>
        Public Property Text() As String
            Get
                Return _Text
            End Get
            Set(ByVal value As String)
                _Text = value
            End Set
        End Property

        ''' <summary>
        ''' THe ID of the user to whom the message is being sent.
        ''' </summary>
        ''' <value></value>
        ''' <returns>An <c>Int64</c> representing the recipient's user ID.</returns>
        ''' <remarks></remarks>
        Public Property RecipientID() As Int64
            Get
                Return _RecipientID
            End Get
            Set(ByVal value As Int64)
                _RecipientID = value
            End Set
        End Property

        ''' <summary>
        ''' The date and time that the direct message was posted.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>DateTime</c> representing the date and time the direct message was posted.</returns>
        ''' <remarks>
        ''' This value is UTC time.
        ''' </remarks>
        Public Property CreatedAt() As DateTime
            Get
                Return _CreatedAt
            End Get
            Set(ByVal value As DateTime)
                _CreatedAt = value
            End Set
        End Property

        ''' <summary>
        ''' The date and time that the direct message was posted.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>DateTime</c> representing the date and time the direct message was posted.</returns>
        ''' <remarks>
        ''' This value is local time.
        ''' <para/>
        ''' This property is read-only because it is generated in TwitterVB, rather than the Twitter API.
        ''' </remarks>
        Public ReadOnly Property CreatedAtLocalTime() As DateTime
            Get
                Return Me.CreatedAt.ToLocalTime
            End Get
        End Property

        ''' <summary>
        ''' The screen name of the user sending the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>String</c> representing the screen name of the user who sent the message.</returns>
        ''' <remarks></remarks>
        Public Property SenderScreenName() As String
            Get
                Return _SenderScreenName
            End Get
            Set(ByVal value As String)
                _SenderScreenName = value
            End Set
        End Property

        ''' <summary>
        ''' The screen name of the user receiving the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>String</c> representing the screen name of the user who received the message.</returns>
        ''' <remarks></remarks>
        Public Property RecipientScreenName() As String
            Get
                Return _RecipientScreenName
            End Get
            Set(ByVal value As String)
                _RecipientScreenName = value
            End Set
        End Property

        ''' <summary>
        ''' The user sending the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>TwitterUser</c> object representing the user who sent the message.</returns>
        ''' <remarks></remarks>
        Public Property Sender() As TwitterUser
            Get
                Return _Sender
            End Get
            Set(ByVal value As TwitterUser)
                _Sender = value
            End Set
        End Property

        ''' <summary>
        ''' The user receiving the direct message.
        ''' </summary>
        ''' <value></value>
        ''' <returns>A <c>TwitterUser</c> object representing the user who received the message.</returns>
        ''' <remarks></remarks>
        Public Property Recipient() As TwitterUser
            Get
                Return _Recipient
            End Get
            Set(ByVal value As TwitterUser)
                _Recipient = value
            End Set
        End Property

        ''' <summary>
        ''' Creates a new <c>DirectMessage</c> object.
        ''' </summary>
        ''' <param name="DirectMessageNode">An <c>XmlNode</c> from the Twitter API response representing a direct message.</param>
        ''' <remarks></remarks>
        ''' <exclude/>
        Public Sub New(ByVal DirectMessageNode As System.Xml.XmlNode)
            Me.ID = XmlInt64_Get(DirectMessageNode("id"))
            Me.SenderID = XmlInt64_Get(DirectMessageNode("sender_id"))
            Me.Text = XmlString_Get(DirectMessageNode("text"))
            Me.RecipientID = XmlInt64_Get(DirectMessageNode("recipient_id"))
            Me.CreatedAt = XmlDate_Get(DirectMessageNode("created_at"))
            Me.SenderScreenName = XmlString_Get(DirectMessageNode("sender_screen_name"))
            Me.RecipientScreenName = XmlString_Get(DirectMessageNode("recipient_screen_name"))

            If DirectMessageNode("sender") IsNot Nothing Then
                Me.Sender = New TwitterUser(DirectMessageNode("sender"))
            End If

            If DirectMessageNode("recipient") IsNot Nothing Then
                Me.Recipient = New TwitterUser(DirectMessageNode("recipient"))
            End If
        End Sub

        ''' <summary>
        ''' Default constructor
        ''' </summary>
        ''' <remarks></remarks>
        ''' <exclude/>
        Public Sub New()
        End Sub

    End Class


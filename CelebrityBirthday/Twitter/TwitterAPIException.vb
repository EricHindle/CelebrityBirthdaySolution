' Hindleware
' Copyright (c) 2021-22, Eric Hindle
' All rights reserved.
'
' Author Eric Hindle
'

<Serializable>
Public Class TwitterAPIException
    Inherits System.Exception
#Region "constructors"
    Public Sub New()
    End Sub
    Public Sub New(Message As String)
        MyBase.New(Message)
    End Sub
    Public Sub New(Message As String, InnerException As Exception)
        MyBase.New(Message, InnerException)
    End Sub
    Public Sub New(InnerException As Exception)
        MyBase.New(Nothing, InnerException)
    End Sub
    Protected Sub New(serializationInfo As Runtime.Serialization.SerializationInfo, streamingContext As Runtime.Serialization.StreamingContext)
        Throw New NotImplementedException()
    End Sub
#End Region
#Region "properties"
    Private _url As Uri
    Public Property Url() As Uri
        Get
            Return _url
        End Get
        Set(ByVal value As Uri)
            _url = value
        End Set
    End Property

    Private _method As String = String.Empty
    Public Property Method() As String
        Get
            Return _method
        End Get
        Set(ByVal value As String)
            _method = value
        End Set
    End Property

    Private _authType As String = String.Empty
    Public Property AuthType() As String
        Get
            Return _authType
        End Get
        Set(ByVal value As String)
            _authType = value
        End Set
    End Property

    Private _response As System.Net.WebResponse
    Public Property Response() As System.Net.WebResponse
        Get
            Return _response
        End Get
        Set(ByVal value As System.Net.WebResponse)
            _response = value
        End Set
    End Property

    Private _status As System.Net.WebExceptionStatus
    Public Property Status() As System.Net.WebExceptionStatus
        Get
            Return _status
        End Get
        Set(ByVal value As System.Net.WebExceptionStatus)
            _status = value
        End Set
    End Property
#End Region

End Class

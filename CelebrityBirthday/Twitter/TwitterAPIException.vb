Public Class TwitterAPIException
    Inherits System.Exception

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

    Public Url As String = String.Empty
    Public Method As String = String.Empty
    Public AuthType As String = String.Empty
    Public Response As System.Net.WebResponse
    Public Status As System.Net.WebExceptionStatus

End Class

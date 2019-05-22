Namespace TwitterVB2
Public Class PagedResults(Of T)
    Inherits List(Of T)
    
    Public Sub New()
        LCursor = -1
    End Sub
    
    Public Sub New(Cursor As Long)
        LCursor = Cursor
    End Sub
    
    Dim LCursor As Long
    Public Property Cursor() As Long
        Get
            Return LCursor
        End Get
        Set
            LCursor = Value
        End Set
    End Property
    
    Public ReadOnly Property HasMore() As Boolean
        Get
            Return Cursor <> 0
        End Get
    End Property
    
End Class
End NameSpace

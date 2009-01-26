Namespace XB2.Components
    Public Class Rolling

        Private _links As LinkCollection
        Private _title As String = ""
        Private _description As String = ""

        Public Property Links() As LinkCollection
            Get
                Return _links
            End Get
            Set(ByVal Value As LinkCollection)
                _links = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

    End Class
End Namespace

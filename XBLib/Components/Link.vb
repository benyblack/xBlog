Namespace XB2.Components
    Public Class Link

        Private _id As Int32 = 0
        Private _text As String = ""
        Private _url As String = ""
        Private _target As String = ""
        Private _tooltip As String = ""

#Region "   Properties   "

        Public Property [Id]() As Int32
            Get
                Return _id
            End Get
            Set(ByVal Value As Int32)
                _id = Value
            End Set
        End Property

        Public Property [Text]() As String
            Get
                Return _text
            End Get
            Set(ByVal Value As String)
                _text = Value
            End Set
        End Property

        Public Property Url() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property Target() As String
            Get
                Return _target
            End Get
            Set(ByVal Value As String)
                _target = Value
            End Set
        End Property

        Public Property ToolTip() As String
            Get
                Return _tooltip
            End Get
            Set(ByVal Value As String)
                _tooltip = Value
            End Set
        End Property

#End Region

    End Class

End Namespace
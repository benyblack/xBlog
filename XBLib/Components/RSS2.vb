Namespace XB2.Components.Syndication

    Public Class RSS2

        Dim _channel As Rss2Channel
        Dim _items As Rss2ItemCollection

        Public Sub New()
            _channel = New Rss2Channel
            _items = New Rss2ItemCollection
        End Sub

#Region "   Properties   "

        Public Property Channel() As Rss2Channel
            Get
                Return _channel
            End Get
            Set(ByVal Value As Rss2Channel)
                _channel = Value
            End Set
        End Property

        Public Property Items() As Rss2ItemCollection
            Get
                Return _items
            End Get
            Set(ByVal Value As Rss2ItemCollection)
                _items = Value
            End Set
        End Property

#End Region

    End Class

    Public Class Rss2Channel

        Dim _title As String = ""
        Dim _link As String = ""
        Dim _description As String = ""

#Region "   Properties   "

        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property

        Public Property Link() As String
            Get
                Return _link
            End Get
            Set(ByVal Value As String)
                _link = Value
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

#End Region

    End Class

    Public Class Rss2Item

        Dim _title As String = ""
        Dim _link As String = ""
        Dim _description As String = ""
        Dim _author As String = ""
        Dim _comments As String = ""
        Dim _pubdate As String = ""

#Region "   Properties   "

        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
            End Set
        End Property

        Public Property Link() As String
            Get
                Return _link
            End Get
            Set(ByVal Value As String)
                _link = Value
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

        Public Property Author() As String
            Get
                Return _author
            End Get
            Set(ByVal Value As String)
                _author = Value
            End Set
        End Property

        Public Property Comments() As String
            Get
                Return _comments
            End Get
            Set(ByVal Value As String)
                _comments = Value
            End Set
        End Property

        Public Property PubDate() As String
            Get
                Return _pubdate
            End Get
            Set(ByVal Value As String)
                _pubdate = Value
            End Set
        End Property

#End Region

    End Class

    Public Class Rss2ItemCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As Rss2Item
            Get
                Return CType(list.Item(Index), Rss2Item)
            End Get
        End Property

        Public Sub Add(ByVal r As Rss2Item)
            list.Add(r)
        End Sub

        Public Sub Remove(ByVal r As Rss2Item)
            list.Remove(r)
        End Sub

    End Class

End Namespace

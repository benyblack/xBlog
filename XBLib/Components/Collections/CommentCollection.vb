Namespace XB2.Components
    Public Class CommentCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As Comment
            Get
                Return CType(list.Item(Index), Comment)
            End Get
        End Property

        Public Sub Add(ByVal c As Comment)
            list.Add(c)
        End Sub

        Public Sub Remove(ByVal c As Comment)
            list.Remove(c)
        End Sub
    End Class
End Namespace

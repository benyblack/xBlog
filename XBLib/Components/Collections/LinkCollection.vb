Namespace XB2.Components
    Public Class LinkCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As Link
            Get
                Return CType(list.Item(Index), Link)
            End Get
        End Property

        Public Sub Add(ByVal l As Link)
            list.Add(l)
        End Sub

        Public Sub Remove(ByVal l As Link)
            list.Remove(l)
        End Sub

    End Class
End Namespace

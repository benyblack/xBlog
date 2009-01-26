Namespace XB2.Components
    Public Class RollingCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As Rolling
            Get
                Return CType(list.Item(Index), Rolling)
            End Get
        End Property

        Public Sub Add(ByVal r As Rolling)
            list.Add(r)
        End Sub

        Public Sub Remove(ByVal r As Rolling)
            list.Remove(r)
        End Sub

    End Class
End Namespace
Namespace XB2.Components
    Public Class BlogCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As Blog
            Get
                Return CType(list.Item(Index), Blog)
            End Get
        End Property

        Public Sub Add(ByVal b As Blog)
            list.Add(b)
        End Sub

        Public Sub Remove(ByVal b As Blog)
            list.Remove(b)
        End Sub

        Public Function GetlastId() As Int32
            Dim lid As Int32 = 0
            For i As Int32 = 0 To list.Count - 1
                If CType(list(i), Blog).ID > lid Then
                    lid = CType(list(i), Blog).ID
                End If

            Next
            Return lid

        End Function

        Public Function GetBlogByName(ByVal Name As String) As Blog
            If Name = "" Or Name.ToLower = "admin" AndAlso list.Count > 0 Then Return list.Item(0)
            For i As Int32 = 0 To Me.List.Count - 1
                Dim b As Blog = list.Item(i)
                If b.Name.ToLower = Name.ToLower Then
                    Return b
                End If

            Next
            Return Nothing

        End Function

        Public Function GetAuthors() As String()
            Dim Authors(Me.Count - 1) As String
            For i As Int32 = 0 To Me.Count - 1
                Authors(i) = Me.Item(i).Name

            Next
            Return Authors

        End Function

    End Class
End Namespace

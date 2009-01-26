Namespace XB2.Components
    Public Class PostCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As Post
            Get
                Return CType(list.Item(Index), Post)
            End Get
        End Property

        Private Function GetPostByID(ByVal postId As Int32)
            For i As Int32 = 0 To list.Count - 1
                If list(i).PostID = postId Then Return Me.Item(i)

            Next
            Return Nothing

        End Function

        Public Sub Add(ByVal p As Post)
            list.Add(p)
        End Sub

        Public Sub Remove(ByVal p As Post)
            list.Remove(p)
        End Sub

        Public Sub Sort()
            Dim alid As New ArrayList
            Dim al As New ArrayList
            For i As Int32 = 0 To list.Count - 1
                alid.Add(Me.Item(i).PostID)

            Next
            alid.Sort(New myReverserClass)
            For i As Int32 = 0 To list.Count - 1
                al.Add(GetPostByID(alid(i)))
            Next
            For i As Int32 = 0 To list.Count - 1
                list(i) = al(i)

            Next
            al = Nothing
            alid = Nothing

        End Sub

        Public Sub SortDesc()
            Dim alid As New ArrayList
            Dim al As New ArrayList
            For i As Int32 = 0 To list.Count - 1
                alid.Add(Me.Item(i).PostID)

            Next
            alid.Sort()
            For i As Int32 = 0 To list.Count - 1
                al.Add(GetPostByID(alid(i)))
            Next
            For i As Int32 = 0 To list.Count - 1
                list(i) = al(i)

            Next
            al = Nothing
            alid = Nothing

        End Sub

    End Class

    Public Class myReverserClass
        Implements IComparer

        ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
           Implements IComparer.Compare
            Return New CaseInsensitiveComparer().Compare(y, x)
        End Function 'IComparer.Compare

    End Class 'myReverserClass

End Namespace

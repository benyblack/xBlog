Namespace XB2.Components
    Public Class UserCollection
        Inherits Collections.CollectionBase

        Default Public ReadOnly Property Item(ByVal Index As Int32) As User
            Get
                Return CType(list.Item(Index), User)
            End Get
        End Property

        Public Sub Add(ByVal u As User)
            list.Add(u)
        End Sub

        Public Sub Remove(ByVal u As User)
            list.Remove(u)
        End Sub

        Public Function GetlastId() As Int32
            Dim lid As Int32 = 0
            For i As Int32 = 0 To list.Count - 1
                If CType(list(i), User).ID > lid Then
                    lid = CType(list(i), User).ID
                End If

            Next
            Return lid

        End Function

        Public Function GetUserByName(ByVal Name As String) As User
            If Name = "" Then Return list(0)
            For i As Int32 = 0 To Me.List.Count - 1
                Dim u As User = list.Item(i)
                If u.UserName.ToLower = Name.ToLower Then
                    Return u
                End If

            Next
            Return Nothing

        End Function

        Public Function GetAdminUser() As User
            For i As Int32 = 0 To list.Count - 1
                If Item(i).IsInRole("admin") Then
                    Return Item(i)

                End If

            Next
            Return Nothing

        End Function

    End Class
End Namespace

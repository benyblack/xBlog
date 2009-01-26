Imports XB2.Components

Namespace XB2.Data
    Public Interface IUserManager

        Function ExistUser(ByVal uid As String) As Boolean
        Function ExistEmail(ByVal Email As String) As Boolean
        Function Authenticate(ByVal uid As String, ByVal pwd As String) As Boolean
        Function GetUser(ByRef uid As String) As User
        Function GetUsers() As UserCollection
        Function AddUser(ByVal _user As User) As Boolean
        Function UpdateUser(ByVal _user As User, ByVal ChanePassword As Boolean) As Boolean
        Function DeleteUser(ByVal UserName As String) As Boolean
        Function ChangePassword(ByVal uid As String, ByVal pwd As String) As Boolean

    End Interface
End Namespace

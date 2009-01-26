Imports System.Web

Namespace XB2.Components
    Public Class Exceptions

        Public Shared Sub ShowErr(ByVal Message As String)
            HttpContext.Current.Response.Redirect("~/Utility/Err.aspx?msg=" & Message)
        End Sub

    End Class
End Namespace

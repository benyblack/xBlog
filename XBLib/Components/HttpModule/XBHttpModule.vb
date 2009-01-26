Imports System.Web
Imports System.Web.SessionState
Imports System.Web.Security
Imports System.Net
Imports System.Security.Principal
Imports XB2.Utility.WebSite
'Imports XB2.Data.Tracker

Namespace XB2.Components
    Public Class XBHttpModule
        Implements IHttpModule

#Region " Component Designer Generated Code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
        End Sub

#End Region

        'Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        '    ' XB2.Data.Tracker
        '    AddCounter()

        'End Sub

        Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            If HttpContext.Current.Request.Url.ToString().ToLower.StartsWith("http://www.") Then
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString().ToLower.Replace("http://www.", "http://"))

            End If
            ' XB2.Utility.WebSite
            ReWritePath(HttpContext.Current.Request)

        End Sub

        Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
            Dim cookieName As String = FormsAuthentication.FormsCookieName
            Dim authCookie As HttpCookie = HttpContext.Current.Request.Cookies(cookieName)
            If authCookie Is DBNull.Value Then
                ' There is no authentication cookie.
                Return

            End If
            Dim authTicket As FormsAuthenticationTicket
            Try
                authTicket = FormsAuthentication.Decrypt(authCookie.Value)

            Catch ex As Exception
                ' Log exception details (omitted for simplicity)
                Return
            End Try

            If authTicket Is DBNull.Value Then
                ' Cookie failed to decrypt.
                Return

            End If
            Dim roles As String() = authTicket.UserData.Split("|")
            ' Create an Identity object
            Dim id As New FormsIdentity(authTicket)
            ' This principal will flow throughout the request.
            Dim principal As New GenericPrincipal(id, roles)
            ' Attach the new principal object to the current HttpContext object
            HttpContext.Current.User = principal

        End Sub

        Public Sub Dispose() Implements System.Web.IHttpModule.Dispose

        End Sub

        Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
            AddHandler context.BeginRequest, AddressOf Application_BeginRequest
            AddHandler context.AuthenticateRequest, AddressOf Application_AuthenticateRequest


        End Sub

    End Class
End Namespace

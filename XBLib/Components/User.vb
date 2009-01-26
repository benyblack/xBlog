Namespace XB2.Components
    Public Class User

        Private _id As Int32 = -1
        Private _uid As String = ""
        Private _pwd As String = ""
        Private _roles As String = ""
        Private _name As String = ""
        Private _age As Byte = 0
        Private _location As String = ""
        Private _email As String = ""
        Private _url As String = ""
        Private _YAHOO As String = ""
        Private _MSN As String = ""
        Private _ICQ As String = ""
        Private _AIM As String = ""
        Private _signupDate As DateTime = DateTime.MinValue
        Private _blog As Blog = Nothing
        Private _enabled As Boolean = False

        Public Sub New()
        End Sub

        Public Property ID() As Int32
            Get
                Return _id
            End Get
            Set(ByVal Value As Int32)
                _id = Value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _uid
            End Get
            Set(ByVal Value As String)
                _uid = Value
            End Set
        End Property

        Public Property Password() As String
            Get
                Return _pwd
            End Get
            Set(ByVal Value As String)
                _pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Value, "sha1")

            End Set
        End Property

        Public Property Roles() As String
            Get
                Return _roles
            End Get
            Set(ByVal Value As String)
                _roles = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal Value As String)
                _name = Value
            End Set
        End Property

        Public Property SignUpDate() As DateTime
            Get
                Return _signupDate
            End Get
            Set(ByVal Value As DateTime)
                _signupDate = Value
            End Set
        End Property

        Public Property Age() As Byte
            Get
                Return _age
            End Get
            Set(ByVal Value As Byte)
                _age = Value
            End Set
        End Property

        Public Property Location() As String
            Get
                Return _location
            End Get
            Set(ByVal Value As String)
                _location = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal Value As String)
                _email = Value
            End Set
        End Property

        Public Property Web() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property YAHOO() As String
            Get
                Return _YAHOO
            End Get
            Set(ByVal Value As String)
                _YAHOO = Value
            End Set
        End Property

        Public Property MSN() As String
            Get
                Return _MSN
            End Get
            Set(ByVal Value As String)
                _MSN = Value
            End Set
        End Property

        Public Property ICQ() As String
            Get
                Return _ICQ
            End Get
            Set(ByVal Value As String)
                _ICQ = Value
            End Set
        End Property

        Public Property AIM() As String
            Get
                Return _AIM
            End Get
            Set(ByVal Value As String)
                _AIM = Value
            End Set
        End Property

        Public Property [Blog]() As Blog
            Get
                Return _blog
            End Get
            Set(ByVal Value As Blog)
                _blog = Value
            End Set
        End Property

        Public Property Enabled() As Boolean
            Get
                Return _enabled
            End Get
            Set(ByVal Value As Boolean)
                _enabled = Value
            End Set
        End Property

        Public Function IsInRole(ByVal r As String) As Boolean
            Dim myroles() As String = Split(Me.Roles, "|")
            For i As Int32 = 0 To myroles.Length - 1
                If myroles(i).ToLower = r.ToLower Then
                    Return True
                End If

            Next
            Return False

        End Function

    End Class
End Namespace

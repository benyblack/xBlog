Namespace XB2.Components
    Public Class Comment

        Dim _commentID As Int32 = -1
        Dim _postid As Int32 = -1
        Dim _body As String = ""
        Dim _commentDate As String = ""
        Dim _author As String = ""
        Dim _ip As String = ""
        Dim _email As String = ""
        Dim _url As String = ""
        Dim _showMail As Boolean = False

        Public Property CommentID() As Int32
            Get
                Return _commentID
            End Get
            Set(ByVal Value As Int32)
                _commentID = Value
            End Set
        End Property

        Public Property PostId() As Int32
            Get
                Return _postid
            End Get
            Set(ByVal Value As Int32)
                _postid = Value
            End Set
        End Property

        Public Property Body() As String
            Get
                Return _body
            End Get
            Set(ByVal Value As String)
                _body = Value
            End Set
        End Property

        Public Property CommentDate() As String
            Get
                Return _commentDate
            End Get
            Set(ByVal Value As String)
                _commentDate = Value
            End Set
        End Property

        Public Property Author() As String
            Get
                Return _author
            End Get
            Set(ByVal Value As String)
                _author = Value
            End Set
        End Property

        Public Property ip() As String
            Get
                Return _ip
            End Get
            Set(ByVal Value As String)
                _ip = Value
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

        Public Property URL() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property ShowEmail() As Boolean
            Get
                Return _showMail
            End Get
            Set(ByVal Value As Boolean)
                _showMail = Value
            End Set
        End Property

    End Class
End Namespace

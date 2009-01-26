Namespace XB2.Components
    Public Class Post
        Implements IComparable
        Private _postID As Int32 = 0
        Private _postDate As DateTime
        Private _title As String = ""
        Private _author As String = ""
        Private _place As String = ""
        Private _body As String = ""
        Private _category As String = ""
        Private _hasComment As Boolean = True
        Private _commentTitle As String = ""
        Private _commentCount As Int32 = 0
        Private _showinmain As Boolean = False

        Public Property PostID() As Int32
            Get
                Return _postID
            End Get
            Set(ByVal Value As Int32)
                _postID = Value
            End Set
        End Property

        Public Property PostDate() As DateTime
            Get
                Return _postDate
            End Get
            Set(ByVal Value As DateTime)
                _postDate = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return _title
            End Get
            Set(ByVal Value As String)
                _title = Value
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

        Public Property Place() As String
            Get
                Return _place
            End Get
            Set(ByVal Value As String)
                _place = Value
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

        Public Property Category() As String
            Get
                Return _category
            End Get
            Set(ByVal Value As String)
                _category = Value
            End Set
        End Property

        Public Property HasComment() As Boolean
            Get
                Return _hasComment
            End Get
            Set(ByVal Value As Boolean)
                _hasComment = Value
            End Set
        End Property

        Public Property CommentTitle() As String
            Get
                Return _commentTitle
            End Get
            Set(ByVal Value As String)
                _commentTitle = Value
            End Set
        End Property

        Public Property CommentCount() As Integer
            Get
                Return _commentCount
            End Get
            Set(ByVal Value As Integer)
                _commentCount = Value
            End Set
        End Property

        Public Property ShowInMain() As Boolean
            Get
                Return _showinmain
            End Get
            Set(ByVal Value As Boolean)
                _showinmain = Value
            End Set
        End Property

        Public Function GetPostUrl() As String
            Dim _language As String = XB2.Utility.WebSite.CurrentBlog.Language
            Dim url As String = XBConfig.HostUrl
            If _language.ToLower = "fa" Then
                Dim pcal As New Globalization.PersianCalendar
                Dim yyyy As String = pcal.GetYear(_postDate)
                Dim mm As String = pcal.GetMonth(_postDate)
                Dim dd As String = pcal.GetDayOfMonth(_postDate)
                url += _author & "/archive/" & yyyy & "/" & mm & "/" & dd & "/" & _postID & ".aspx"

            Else
                url += _author & "/archive/" & _postDate.Year & "/" & _postDate.Month & "/" & _postDate.Day & "/" & _postID & ".aspx"

            End If
            Return url

        End Function

        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            If TypeOf obj Is Post Then
                Dim temp As Post = CType(obj, Post)

                Return _postDate.CompareTo(temp._postDate)
            End If

        End Function

        Public Function GetEditHref() As String
            Dim href As String = XBConfig.HostUrl & XBConfig.ControlPanel & "EditPost.aspx?id="
            href += Me.PostID & "&draft=0"
            Return href

        End Function

    End Class
End Namespace

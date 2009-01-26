Imports System.Configuration.ConfigurationSettings
Imports System.Xml
Imports System.Web
Imports XB2.Data

Namespace XB2.Components
    Public Class XBConfig

        Private _blogs As BlogCollection = Nothing
        Private _users As UserCollection = Nothing
        Private dp As XmlConfiguration = Nothing

#Region "   Constructor  "

        Public Sub New()
            _blogs = New BlogCollection
            _users = New UserCollection
            dp = New XmlConfiguration
            dp.GetConfig(Me)

        End Sub

#End Region

#Region "   Properties   "

        Public ReadOnly Property Blogs() As BlogCollection
            Get
                Return _blogs
            End Get
        End Property

        Public ReadOnly Property Users() As UserCollection
            Get
                Return _users
            End Get
        End Property

        Public ReadOnly Property SiteSettings() As Blog
            Get
                If Not _blogs Is Nothing AndAlso _blogs.Count > 0 Then
                    Return _blogs(0)

                Else
                    Return Nothing

                End If
            End Get
        End Property

        ' Shared Properties
        Public Shared ReadOnly Property HostUrl() As String
            Get
                Dim hu As String = AppSettings("hostUrl")
                If Not hu.EndsWith("/") Then hu += "/"
                Return hu
            End Get
        End Property

        Public Shared ReadOnly Property ControlPanel() As String
            Get
                Dim cp As String = AppSettings("ControlPanelPath")
                If Not cp.EndsWith("/") Then cp += "/"
                Return cp
            End Get
        End Property

        Public Shared ReadOnly Property [TimeZone]() As TimeSpan
            Get
                Dim tz As String() = Split(AppSettings("TimeZone"), ":")
                Dim hh As Int32 = tz(0)
                Dim mm As String = tz(1)
                Dim ts As New TimeSpan(hh, mm, 0)
                If System.TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now()) Then
                    ts = New TimeSpan(hh + 1, mm, 0)
                End If
                Return ts

            End Get
        End Property

        Public Shared ReadOnly Property RootPath() As String
            Get
                Dim _root As String = HttpContext.Current.Server.MapPath("~")
                If Not _root.EndsWith("\") Then _root += "\"
                Return _root
            End Get
        End Property

        ' Xblog.net Files Path

        Public Shared ReadOnly Property XMLFilesPath() As String
            Get
                Dim _xfp As String = RootPath & AppSettings("XMLFilesPath")
                If Not _xfp.EndsWith("\") Then _xfp += "\"
                Return _xfp
            End Get
        End Property

        Public Shared ReadOnly Property XMLFilesUrl() As Uri
            Get
                Dim _xfp As String = HostUrl & AppSettings("XMLFilesPath")
                If Not _xfp.EndsWith("/") Then _xfp += "/"
                Return New Uri(_xfp)
            End Get
        End Property

        Public Shared ReadOnly Property ConfigFilePath() As String
            Get
                Return XMLFilesPath & "xb.config"
            End Get
        End Property

        Public Shared ReadOnly Property ArchiveFilePath() As String
            Get
                Return XMLFilesPath() & "Archives\"
            End Get
        End Property

        Public Shared ReadOnly Property DraftFilePath() As String
            Get
                Return XMLFilesPath() & "Draft\"
            End Get
        End Property

        Public Shared ReadOnly Property CommentsFilePath() As String
            Get
                Return XMLFilesPath() & "Comments\"
            End Get
        End Property

        Public Shared ReadOnly Property TemplateFilePath() As String
            Get
                Return XMLFilesPath() & "Template\"
            End Get
        End Property

        Public Shared ReadOnly Property TemplateFilesUrl() As Uri
            Get
                Dim _xfp As String = HostUrl & AppSettings("XMLFilesPath") & "/Template/"
                Return New Uri(_xfp)

            End Get
        End Property

        Public Shared ReadOnly Property TrackerFilePath() As String
            Get
                Return XMLFilesPath() & "Tracker\"
            End Get
        End Property

        Public Shared ReadOnly Property LinksFilePath() As String
            Get
                Return XMLFilesPath() & "Links\"
            End Get
        End Property

#End Region

#Region "   Public       "

        Public Sub UpdateConfig()
            dp.SetConfig(Me)

        End Sub

        Public Sub UpdateBlogConfig(ByVal b As Blog)
            dp.SetBlogConfig(b)

        End Sub

        Public Shared ReadOnly Property Themes() As String()
            Get
                Dim di As New IO.DirectoryInfo(RootPath & "Themes/")
                Dim dis() As IO.DirectoryInfo = di.GetDirectories()
                Dim al As New ArrayList
                For i As Int32 = 0 To dis.Length - 1
                    al.Add(dis(i).Name)

                Next
                Return al.ToArray(GetType(String))

            End Get
        End Property

        Public Shared ReadOnly Property ThemesUrl() As String
            Get
                Return HostUrl & AppSettings("ThemesPath") & "/"
            End Get
        End Property

        Public Shared ReadOnly Property ThemesFolder() As String
            Get
                Return AppSettings("ThemesPath")
            End Get
        End Property

        Public Shared ReadOnly Property ThemesPath() As String
            Get
                Return RootPath & AppSettings("ThemesPath") & "\"
            End Get
        End Property

        Public Function GetCurrentBlogName() As String
            If Utility.WebSite.CurrentBlogName = "" Then
                Return "default"
            Else
                Return Utility.WebSite.CurrentBlogName
            End If

        End Function

        Public Shared Function GetNow() As DateTime
            Dim ts As TimeSpan = XBConfig.TimeZone
            Return System.TimeZone.CurrentTimeZone.ToUniversalTime(Now()).Add(ts)

        End Function

#End Region

    End Class

End Namespace

Namespace XB2.Components
    Public Class Blog

#Region "   Fields  "

        Private _id As Int32 = 0
        Private _username As String = ""
        Private _title As String = ""
        Private _description As String = ""
        Private _postcount As Int32 = 0
        Private _language As String = ""
        Private _theme As String = ""
        Private _cats() As String = Nothing
        Private _ext As String = ".resources"
        Private _xfp As String = XBConfig.XMLFilesPath
        Private _enabled As Boolean = False

#End Region

#Region "   Properties   "

        Public Property [ID]() As Int32
            Get
                Return _id
            End Get
            Set(ByVal Value As Int32)
                _id = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return _username
            End Get
            Set(ByVal Value As String)
                _username = Value.ToLower
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

        Public Property Description() As String
            Get
                Return _description
            End Get
            Set(ByVal Value As String)
                _description = Value
            End Set
        End Property

        Public Property PostCount() As Int32
            Get
                Return _postcount
            End Get
            Set(ByVal Value As Int32)
                _postcount = Value
            End Set
        End Property

        Public Property Language() As String
            Get
                Return _language
            End Get
            Set(ByVal Value As String)
                _language = Value
            End Set
        End Property

        Public Property Theme() As String
            Get
                Return _theme
            End Get
            Set(ByVal Value As String)
                _theme = Value
            End Set
        End Property

        Public Property Categories() As String()
            Get
                Return _cats
            End Get
            Set(ByVal Value As String())
                _cats = Value
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

        Public ReadOnly Property MyBaseUrl() As String
            Get
                Dim myurl As String = XBConfig.HostUrl & Me.Name
                If Not myurl.EndsWith("/") Then myurl += "/"
                Return myurl
            End Get
        End Property

        Public Function GetXMLFilesPath() As String

            If Not _xfp.EndsWith("\") Then _xfp += "\"
            Return _xfp

        End Function

        Public Function GetArchiveFilePath() As String

            Return GetXMLFilesPath() & "Archives\" & Me.Name & ".{0}" & _ext

        End Function

        Public Function GetDraftFilePath() As String

            Return GetXMLFilesPath() & "Draft\" & Me.Name & ".index" & _ext

        End Function

        Public Function GetCommentsFilePath() As String

            Return GetXMLFilesPath() & "Comments\" & Me.Name & ".{0}" & _ext

        End Function

        Public Function GetPostTemplateFilePath() As String

            Return GetXMLFilesPath() & "Template\" & Me.Name & ".BB.txt"

        End Function

        Public Function GetCommentTemplateFilePath() As String

            Return GetXMLFilesPath() & "Template\" & Me.Name & ".BC.txt"

        End Function

        Public Function GetTrackerFilePath() As String

            Return GetXMLFilesPath() & "Tracker\" & Me.Name & ".{0}" & _ext

        End Function

        Public Function GetLinksFilePath() As String

            Return GetXMLFilesPath() & "Links\" & Me.Name & ".links" & _ext

        End Function

#End Region

    End Class
End Namespace

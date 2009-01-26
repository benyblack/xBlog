Imports XB2.Components

Namespace XB2.Data
    Public Interface IConfiguration

        Sub GetConfig(ByRef xbcnf As XBConfig)
        Sub SetConfig(ByVal xbcnf As XBConfig)
        Sub SetBlogConfig(ByVal b As Blog)
        Sub AddBlog(ByVal b As Blog)
        Sub DeleteBlog(ByVal Name As String)

    End Interface
End Namespace

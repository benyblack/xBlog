Imports XB2.Components

Namespace XB2.Data
    Public Interface IDataProvider

#Region "       Posts       "

        Function GetPosts(ByVal PostCount As Int32, ByVal Category As String, _
                ByVal Author As String) As PostCollection

        Function GetPostsForControlPanel(ByRef postCounter As Int32, ByVal IsDraft As Boolean, _
                ByVal StartId As Int32, ByVal EndId As Int32) As PostCollection

        Function GetPosts(ByVal Year As Int32, ByVal Month As Int32, ByVal Day As Int32, _
                ByVal author As String, ByVal ShowInFirstPage As Boolean) As PostCollection

        Function GetPostDates(ByVal d As DateTime) As DateTime()
        Function GetPost(ByVal id As Int32) As Post
        Function GetDraftPost(ByVal Id As Int32) As Post
        Function GetLastPostId() As Int32
        Function AddPost(ByVal _post As Post, ByVal isDraft As Boolean) As Boolean
        Function UpdatePost(ByVal _post As Post, ByVal isDraft As Boolean) As String
        Function DeletePost(ByVal PostId As String, ByVal isDraft As Boolean) As String
        Function GetPostsCount(ByVal isDraft As Boolean, ByVal ForCP As Boolean) As Integer
        Function GetPostsCountByDate(ByVal ArchiveFileName As String, ByVal ForCP As Boolean) As Int32
        Function GetPostCountByCategory(ByVal Category As String) As Int32
        Function GetPostCountByAuthor(ByVal Author As String) As Int32

#End Region

#Region "      Comments     "

        Function GetComments(ByVal PostId As Int32) As CommentCollection
        Function GetComments(ByVal PostId As Int32, ByVal StartId As Int32, ByVal Endid As Int32) As CommentCollection
        Function AddComment(ByVal _comment As Comment, ByVal BlogToComment As String) As Boolean
        Function DeleteComment(ByVal CommentID As Int32, ByVal BlogToComment As String, ByVal PostId As Int32) As String
        Function DeleteComments(ByVal PostId As Int32, ByVal BlogToComment As String) As String
        Function GetCommentsCount(ByVal PostId As Int32, ByVal BlogToCount As String) As Int32

#End Region

#Region "       Search      "

        ' Function SearchPosts(ByVal Author As String, ByVal Word As String) As PostCollection
        ' Function SearchPosts(ByVal Word As String)

#End Region

#Region "       Links       "

        Function GetLinks(ByVal Rolling As String) As LinkCollection
        Function GetRollings() As RollingCollection
        Function AddRolling(ByVal Title As String, ByVal Description As String) As Boolean
        Function UpdateRolling(ByVal Title As String, ByVal Description As String, ByVal index As Int32) As Boolean
        Function DeleteRolling(ByVal index As Int32) As Boolean
        Function AddLink(ByVal RollingName As String, ByVal L As Link) As Boolean
        Function UpdateLink(ByVal RollingName As String, ByVal L As Link, ByVal index As Int32) As Boolean
        Function DeleteLink(ByVal RollingName As String, ByVal index As Int32) As Boolean
        Sub SendRollingDown(ByVal index As Int32)
        Sub SendLinkup(ByVal RollingName As String, ByVal index As Int32)
        Sub SendLinkDown(ByVal RollingName As String, ByVal index As Int32)

#End Region

#Region "      Generals     "

        Function GetArchiveFileList(ByVal BlogName As String) As String()

#End Region

    End Interface
End Namespace

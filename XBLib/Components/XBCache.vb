'------------------------------------------------------------------------------
' <copyright company="Telligent Systems">
'     Copyright (c) Telligent Systems Corporation.  All rights reserved.
' </copyright> 
'Edited By DNE Group 2005/09/18
'------------------------------------------------------------------------------
Imports System
Imports System.Collections
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.Caching

Namespace XB2.Components

    '/ <summary>
    '/ Summary description for XBCache.
    '/ </summary>
    Public Class XBCache

        Private Sub New()
        End Sub 'New 

        '>> Based on Factor = 5 default value
        Public Shared DayFactor As Integer = 17280
        Public Shared HourFactor As Integer = 720
        Public Shared MinuteFactor As Integer = 12

        Private Shared _cache As Cache

        Private Shared Factor As Integer = 5


        Public Shared Sub ReSetFactor(ByVal cacheFactor As Integer)
            Factor = cacheFactor

        End Sub

        '/ <summary>
        '/ Static initializer should ensure we only have to look up the current cache
        '/ instance once.
        '/ </summary>
        Shared Sub New()
            Dim context As HttpContext = HttpContext.Current
            If Not (context Is Nothing) Then
                _cache = context.Cache
            Else
                _cache = HttpRuntime.Cache
            End If

        End Sub


        '/ <summary>
        '/ Removes all items from the Cache
        '/ </summary>
        Public Shared Sub Clear()
            Dim CacheEnum As IDictionaryEnumerator = _cache.GetEnumerator()
            While CacheEnum.MoveNext()
                _cache.Remove(CacheEnum.Key.ToString())
            End While

        End Sub


        Public Shared Sub RemoveByPattern(ByVal pattern As String)
            Dim CacheEnum As IDictionaryEnumerator = _cache.GetEnumerator()
            Dim regex As New regex(pattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline Or RegexOptions.Compiled)
            While CacheEnum.MoveNext()
                If regex.IsMatch(CacheEnum.Key.ToString()) Then
                    _cache.Remove(CacheEnum.Key.ToString())
                End If
            End While

        End Sub

        '/ <summary>
        '/ Removes the specified key from the cache
        '/ </summary>
        '/ <param name="key"></param>
        Public Shared Sub Remove(ByVal key As String)
            _cache.Remove(key)

        End Sub 'Remove


        '/ <summary>
        '/ Insert the current "obj" into the cache. 
        '/ </summary>
        '/ <param name="key"></param>
        '/ <param name="obj"></param>
        Public Overloads Shared Sub Insert(ByVal key As String, ByVal obj As Object)
            Insert(key, obj, Nothing, 1)

        End Sub


        Public Overloads Shared Sub Insert(ByVal key As String, ByVal obj As Object, ByVal dep As CacheDependency)
            Insert(key, obj, dep, HourFactor * 12)

        End Sub


        Public Overloads Shared Sub Insert(ByVal key As String, ByVal obj As Object, ByVal seconds As Integer)
            Insert(key, obj, Nothing, seconds)

        End Sub


        Public Overloads Shared Sub Insert(ByVal key As String, ByVal obj As Object, ByVal seconds As Integer, ByVal priority As CacheItemPriority)
            Insert(key, obj, Nothing, seconds, priority)

        End Sub


        Public Overloads Shared Sub Insert(ByVal key As String, ByVal obj As Object, ByVal dep As CacheDependency, ByVal seconds As Integer)
            Insert(key, obj, dep, seconds, CacheItemPriority.Normal)

        End Sub


        Public Overloads Shared Sub Insert(ByVal key As String, ByVal obj As Object, ByVal dep As CacheDependency, ByVal seconds As Integer, ByVal priority As CacheItemPriority)
            If Not (obj Is Nothing) Then
                _cache.Insert(key, obj, dep, DateTime.Now.AddSeconds(Factor * seconds), TimeSpan.Zero, priority, Nothing)
            End If

        End Sub


        Public Shared Sub MicroInsert(ByVal key As String, ByVal obj As Object, ByVal secondFactor As Integer)
            If Not (obj Is Nothing) Then
                _cache.Insert(key, obj, Nothing, DateTime.Now.AddSeconds(Factor * secondFactor), TimeSpan.Zero)
            End If

        End Sub


        '/ <summary>
        '/ Insert an item into the cache for the Maximum allowed time
        '/ </summary>
        '/ <param name="key"></param>
        '/ <param name="obj"></param>
        Public Overloads Shared Sub Max(ByVal key As String, ByVal obj As Object)
            Max(key, obj, Nothing)

        End Sub


        Public Overloads Shared Sub Max(ByVal key As String, ByVal obj As Object, ByVal dep As CacheDependency)
            If Not (obj Is Nothing) Then
                _cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, Nothing)
            End If

        End Sub


        Public Shared Function [Get](ByVal key As String) As Object
            Return _cache(key)

        End Function

    End Class
End Namespace
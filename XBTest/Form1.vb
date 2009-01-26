Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



    End Sub

    Sub Add()
        Dim srcTree As XElement = _
                <Root>
                    <Element1>1</Element1>
                    <Element2>2</Element2>
                    <Element3>3</Element3>
                    <Element4>4</Element4>
                    <Element5>5</Element5>
                </Root>
        Dim xmlTree As XElement = _
                <Root>
                    <NewElement>Content</NewElement>
                </Root>
        xmlTree.Add( _
            From el In srcTree.Elements _
            Where CInt(el) >= 3 _
            Select el)
        Console.WriteLine(xmlTree)

    End Sub

    Sub remove()
        Dim xmlTree As XElement = _
        <Root>
            <Child1>child1 content</Child1>
            <Child2>child2 content</Child2>
            <Child3>child3 content</Child3>
            <Child4>child4 content</Child4>
            <Child5>child5 content</Child5>
        </Root>

        Dim child3 As XElement = xmlTree.<Child3>(0)
        child3.Remove()
        Console.WriteLine(xmlTree)

    End Sub

    Sub updatee()
        Dim xmlTree As XElement = _
        <Root>
            <Child1>child1 content</Child1>
            <Child2>child2 content</Child2>
            <Child3>child3 content</Child3>
            <Child4>child4 content</Child4>
            <Child5>child5 content</Child5>
        </Root>

        Dim child3 As XElement = xmlTree.<Child3>(0)
        child3.ReplaceWith(<NewChild>new content</NewChild>)
        Console.WriteLine(xmlTree)

    End Sub

    Sub setvalue()
        Dim root As XElement = _
        <Root>
            <Child>child content</Child>
        </Root>

        root.SetValue("new content")
        Console.WriteLine(root)

    End Sub

    Sub tree1()
        Dim srcTree As XElement = _
    <Root>
        <Element>1</Element>
        <Element>2</Element>
        <Element>3</Element>
        <Element>4</Element>
        <Element>5</Element>
    </Root>
        Dim xmlTree As XElement = _
            <Root>
                <Child>1</Child>
                <Child>2</Child>
                <%= From el In srcTree.Elements() _
                    Where CInt(el) > 2 _
                    Select el %>
            </Root>
        Console.WriteLine(xmlTree)

        '------------------------------------

        Dim str As String
        str = "Some content"
        Dim root As XElement = <Root><%= str %></Root>
        Console.WriteLine(root)

        '-------------------------------------

        Dim arr As Integer() = {1, 2, 3}
        Dim n As XElement = _
            <Root>
                <%= From i In arr Select <Child><%= i %></Child> %>
            </Root>
        Console.WriteLine(n)

        '-------------------------------------

        Dim eleName As String = "ele"
        Dim attName As String = "att"
        Dim attValue As String = "aValue"
        Dim eleValue As String = "eValue"
        Dim n2 As XElement = _
            <Root <%= attName %>=<%= attValue %>>
                <<%= eleName %>>
                    <%= eleValue %>
                </>
            </Root>
        Console.WriteLine(n2)


    End Sub

    Sub ClonningAttaching()
        ' Create a tree with a child element.
        Dim xmlTree1 As XElement = _
            <Root>
                <Child1>1</Child1>
            </Root>

        ' Create an element that is not parented.
        Dim child2 As XElement = <Child2>2</Child2>

        ' Create a tree and add Child1 and Child2 to it.
        Dim xmlTree2 As XElement = _
            <Root>
                <%= xmlTree1.<Child1>(0) %>
                <%= child2 %>
            </Root>

        ' Compare Child1 identity.
        Console.WriteLine("Child1 was {0}", _
            IIf(xmlTree1.Element("Child1") Is xmlTree2.Element("Child1"), _
            "attached", "cloned"))

        ' Compare Child2 identity.
        Console.WriteLine("Child2 was {0}", _
            IIf(child2 Is xmlTree2.Element("Child2"), _
            "attached", "cloned"))

    End Sub

End Class

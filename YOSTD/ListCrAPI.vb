Imports System.IO
Imports System.Text.RegularExpressions

Public Class [List]
    Dim items As ArrayList
    Public Sub New()
        items = New ArrayList
    End Sub

    Public Function Append(value As Object) As Integer
        If items.Count = 0 Then
            Return items.Add(value)
        End If
        items.Insert(0, value)
        Return items.Count
    End Function
    Public Function Add(value As Object) As Integer
        Return items.Add(value)
    End Function

    Public Function AddWithSplit(values As Object, pattern As Object) As Integer
        Dim splitItems() As String
        splitItems = Regex.Split(values, pattern)
        Dim listSplitLength As Integer = splitItems.Length - 1
        For index = 0 To listSplitLength
            items.Add(splitItems(index))
        Next
        Return items.Count
    End Function

    Public Function Insert(index As Integer, value As String) As Integer
        If items.Count = 0 Then
            Return items.Add(value)
        End If
        items.Insert(index, value)
        Return items.Count
    End Function
    Public Function Import(YODA_F As String) As Integer
        Dim itemList As ArrayList = YODA_Format.ReadYODA(YODA_F)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            items.Add(itemList(index))
        Next
        Return items.Count
    End Function

    Public Sub Save(path As String)
        File.WriteAllText(path, YODA_Format.WriteYODA(items))
    End Sub

    Public Sub Load(path As String)
        If File.Exists(path) = False Then
            Throw New Exception(path & " - Yoda file not found.")
            Return
        End If
        Dim yodaPlainText As String = File.ReadAllText(path)
        items = YODA_Format.ReadYODA(yodaPlainText)
    End Sub

    Public Function [Set](YODA_F As String) As Integer
        items.Clear()
        Dim itemList As ArrayList = YODA_Format.ReadYODA(YODA_F)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            items.Add(itemList(index))
        Next
        Return items.Count
    End Function

    Public Function Clone() As String
        Return YODA_Format.WriteYODA(items)
    End Function

    Public Function Iter(item As Object) As Integer
        Dim numOfIter As Integer = 0
        For index = 0 To items.Count - 1
            If item = items(index) Then
                numOfIter += 1
            End If
        Next
        Return numOfIter
    End Function

    Public Function Count() As Integer
        Return items.Count
    End Function

    Public Sub Clear()
        items.Clear()
    End Sub

    Public Function Remove(value As Object) As Boolean
        Dim itemsCount As Integer = items.Count - 1
        For index = 0 To itemsCount
            If items(index) = value Then
                items.RemoveAt(index)
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub RemoveAt(index As Integer)
        items.RemoveAt(index)
    End Sub

    Public Sub Sort()
        items.Sort()
    End Sub
    Public Sub Reverse()
        Dim departList As New ArrayList
        Dim itemsCount As Integer = items.Count - 1
        For index = itemsCount To 0 Step -1
            departList.Add(items(index))
        Next
        items = departList
    End Sub

    Public Function Contains(value As String) As Boolean
        Dim itemsCount As Integer = items.Count - 1
        For index = 0 To itemsCount
            If items(index).ToString.Contains(value) Then Return True
        Next
        Return False
    End Function

    Public Function StartsWith(value As String) As Boolean
        Dim itemsCount As Integer = items.Count - 1
        For index = 0 To itemsCount
            If items(index).ToString.StartsWith(value) Then Return True
        Next
        Return False
    End Function

    Public Function EndsWith(value As String) As Boolean
        Dim itemsCount As Integer = items.Count - 1
        For index = 0 To itemsCount
            If items(index).ToString.EndsWith(value) Then Return True
        Next
        Return False
    End Function

    Public Function Pattern(regexCode As String) As Boolean
        Dim itemsCount As Integer = items.Count - 1
        For index = 0 To itemsCount
            If Regex.IsMatch(items(index).ToString, regexCode) Then Return True
        Next
        Return False
    End Function
    Public Function [Get](index As Integer) As String
        If index <> -1 Then
            Return items(index)
        Else
            Return items(items.Count - 1)
        End If
    End Function

    Public Function GetIndex(value As String) As Integer
        Dim itemsCount As Integer = items.Count - 1
        For index = 0 To itemsCount
            If value = items(index) Then Return index
        Next
        Return -1
    End Function

    Public Function Pop() As String
        If items.Count = 0 Then Throw New Exception("pop from empty list.")
        Dim item As String = items(items.Count - 1)
        If items.Count <> 1 Then
            items.RemoveAt(items.Count - 1)
        Else
            items.Clear()
        End If
        Return item
    End Function

    Public Function PopLeft() As String
        If items.Count = 0 Then Throw New Exception("pop from empty list.")
        Dim item As String = items(0)
        If items.Count <> 1 Then
            items.RemoveAt(0)
        Else
            items.Clear()
        End If
        Return item
    End Function


End Class

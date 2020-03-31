Imports System.IO

Public Class [Stack]
    Private sharedStack As System.Collections.Stack
    Public Sub New()
        sharedStack = New System.Collections.Stack
    End Sub

    Private Function GetArrFromStack() As ArrayList
        Dim items As New ArrayList
        Dim stackCount As Integer = sharedStack.Count - 1
        Dim obj() As Object = sharedStack.ToArray()
        For index = 0 To stackCount
            items.Add(obj(index))
        Next
        Return items
    End Function
    Public Function Import(YODA_F As String) As Integer
        Dim itemList As ArrayList = YODA_Format.ReadYODA(YODA_F)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            sharedStack.Push(itemList(index))
        Next
        Return sharedStack.Count
    End Function

    Public Sub Save(path As String)
        File.WriteAllText(path, YODA_Format.WriteYODA(GetArrFromStack()))
    End Sub

    Public Sub Load(path As String)
        If File.Exists(path) = False Then
            Throw New Exception(path & " - Yoda file not found.")
            Return
        End If
        Dim yodaPlainText As String = File.ReadAllText(path)
        Dim itemList As ArrayList = YODA_Format.ReadYODA(yodaPlainText)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            sharedStack.Push(itemList(index))
        Next
    End Sub

    Public Function [Set](YODA_F As String) As Integer
        sharedStack.Clear()
        Dim itemList As ArrayList = YODA_Format.ReadYODA(YODA_F)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            sharedStack.Push(itemList(index))
        Next
        Return sharedStack.Count
    End Function

    Public Function Clone() As String
        Return YODA_Format.WriteYODA(GetArrFromStack())
    End Function

    Public Sub Push(value As String)
        sharedStack.Push(value)
    End Sub

    Public Function Peek()
        If sharedStack.Count = 0 Then Return 0
        Return sharedStack.Peek
    End Function

    Public Function Pop()
        If sharedStack.Count = 0 Then Return 0
        Return sharedStack.Pop
    End Function

    Public Function Count() As Integer
        Return sharedStack.Count
    End Function

    Public Function Contains(value As String) As Boolean
        Return sharedStack.Contains(value)
    End Function

    Public Sub Clear()
        sharedStack.Clear()
    End Sub

    Public Function Empty() As Boolean
        If sharedStack.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class

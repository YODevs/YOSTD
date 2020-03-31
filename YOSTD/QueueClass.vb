Imports System.IO
Public Class [Queue]
    Private sharedQueue As System.Collections.Queue
    Public Sub New()
        sharedQueue = New System.Collections.Queue
    End Sub

    Private Function GetArrFromStack() As ArrayList
        Dim items As New ArrayList
        Dim stackCount As Integer = sharedQueue.Count - 1
        Dim obj() As Object = sharedQueue.ToArray()
        For index = 0 To stackCount
            items.Add(obj(index))
        Next
        Return items
    End Function
    Public Function Import(YODA_F As String) As Integer
        Dim itemList As ArrayList = YODA_Format.ReadYODA(YODA_F)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            sharedQueue.Enqueue(itemList(index))
        Next
        Return sharedQueue.Count
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
            sharedQueue.Enqueue(itemList(index))
        Next
    End Sub

    Public Function [Set](YODA_F As String) As Integer
        sharedQueue.Clear()
        Dim itemList As ArrayList = YODA_Format.ReadYODA(YODA_F)
        Dim itemCount As Integer = itemList.Count - 1
        For index = 0 To itemCount
            sharedQueue.Enqueue(itemList(index))
        Next
        Return sharedQueue.Count
    End Function

    Public Function Clone() As String
        Return YODA_Format.WriteYODA(GetArrFromStack())
    End Function

    Public Sub Enqueue(value As String)
        sharedQueue.Enqueue(value)
    End Sub

    Public Function Peek()
        If sharedQueue.Count = 0 Then Return 0
        Return sharedQueue.Peek
    End Function

    Public Function Dequeue()
        If sharedQueue.Count = 0 Then Return 0
        Return sharedQueue.Dequeue
    End Function

    Public Function Count() As Integer
        Return sharedQueue.Count
    End Function

    Public Function Contains(value As String) As Boolean
        Return sharedQueue.Contains(value)
    End Function

    Public Sub Clear()
        sharedQueue.Clear()
    End Sub

    Public Function Empty() As Boolean
        If sharedQueue.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

End Class


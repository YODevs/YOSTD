Public Class Map
    Private indexList, valueList As New ArrayList

    Public Sub New()

    End Sub

    Public Function Import(YODA_F_Map As String) As Integer
        Dim mapFormatGen As YODA_Format.YODAMapFormat = YODA_Format.ReadYODA_Map(YODA_F_Map)
        Dim itemCount As Integer = mapFormatGen.keys.Count - 1
        For index = 0 To itemCount
            indexList.Add(mapFormatGen.keys(index))
            valueList.Add(mapFormatGen.values(index))
        Next
        Return mapFormatGen.keys.Count
    End Function

    Public Function Clone() As String
        Return YODA_Format.WriteYODA_Map(indexList, valueList)
    End Function

    Public Function Add(key As String, value As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If

        Dim getKey As String
        For index = 0 To indexList.Count - 1
            getKey = indexList(index).ToString
            If getKey = key Then
                Throw New Exception("This key is already registered, you can use 'update' method.")
                Return False
            End If
        Next

        indexList.Add(key)
        valueList.Add(value)
        Return True
    End Function

    Public Function ContainsKey(key As String) As String
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If

        Dim getKey As String
        For index = 0 To indexList.Count - 1
            getKey = indexList(index).ToString
            If getKey.Contains(key) Then
                Return getKey
            End If
        Next


        Return False
    End Function

    Public Function ContainsValue(value As String) As String
        If value = Nothing Then
            Throw New Exception("Value is empty.")
        End If

        Dim getValue As String
        For index = 0 To indexList.Count - 1
            getValue = valueList(index).ToString
            If getValue.Contains(value) Then
                Return getValue
            End If
        Next


        Return False
    End Function


    Public Function [Get](key As String) As String
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If

        Dim getKey As String
        For index = 0 To indexList.Count - 1
            getKey = indexList(index).ToString
            If getKey = key Then
                Return valueList(index)
            End If
        Next

        Throw New Exception(key & " - Key is not defined.")

        Return -1
    End Function

    Public Function [GetWithIndex](indexRep As Integer) As String
        If indexRep > 0 AndAlso indexList.Count > indexRep Then
            Return valueList(indexRep)
        Else
            Throw New Exception("The index '" & indexRep & "' entered in the validation was rejected.")
        End If

        Return -1
    End Function
    Public Function [Remove](key As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If

        Dim getKey As String
        For index = 0 To indexList.Count - 1
            getKey = indexList(index).ToString
            If getKey = key Then
                indexList.RemoveAt(index)
                valueList.RemoveAt(index)
                Return True
            End If
        Next

        Throw New Exception(key & " - Key is not defined.")
        Return False
    End Function

    Public Function [Clear]() As Boolean
        If indexList.Count = 0 Then Return False
        indexList.Clear()
        valueList.Clear()
        Return True
    End Function

    Public Function [Size]() As Integer
        Return indexList.Count
    End Function

    Public Function IsEmpty() As Boolean
        If indexList.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function GetAll()
        If indexList.Count = 0 Then
            Return "map is empty."
        Else



            Dim retTe As String = "{"
            Dim keyList, valList As String
            Dim indexListCount As Integer = indexList.Count
            For index = 0 To indexListCount - 1
                keyList = indexList(index)
                valList = valueList(index)
                retTe &= "{'" & keyList & "','" & valList & "'}"
                If index <> indexListCount - 1 Then
                    retTe &= ","
                End If
            Next
            retTe &= "}"
            Return retTe

        End If


    End Function

    Public Function [Update](key As String, value As String) As Boolean
        If key = Nothing Then
            Throw New Exception("Key is empty.")
        End If

        Dim getKey As String
        For index = 0 To indexList.Count - 1
            getKey = indexList(index).ToString
            If getKey = key Then
                valueList.Insert(index + 1, value)
                valueList.RemoveAt(index)
                Return True
            End If
        Next

        Throw New Exception(key & " - Key is not defined.")
        Return False
    End Function
End Class

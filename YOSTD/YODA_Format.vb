﻿Public Class YODA_Format

    Friend Shared Function WriteYODA(items As ArrayList) As String
        Dim countOfItems As Integer = items.Count - 1
        If countOfItems = -1 Then Return "![]"
        Dim YODA_Format As String = "!["
        Dim item As String = String.Empty
        For index = 0 To countOfItems
            item = items(index)
            Replace_Unique_Char(item)
            If index <> countOfItems Then
                YODA_Format &= """" & item & ""","
            Else
                YODA_Format &= """" & item & """]"
            End If
        Next
        Return YODA_Format
    End Function

    Private Shared Sub Replace_Unique_Char(ByRef obj As String)
        obj = obj.Replace("'", "&apos;")
        obj = obj.Replace("""", "&quot;")
    End Sub
    Private Shared Sub Return_Unique_Char(ByRef obj As String)
        obj = obj.Replace("&apos;", "'")
        obj = obj.Replace("&quot;", """")
    End Sub

    Friend Shared Function ReadYODA(YODA_F As String) As ArrayList
        YODA_F = YODA_F.Trim
        Dim item As String = String.Empty
        Dim items As New ArrayList
        If YODA_F = String.Empty Or YODA_F = "![]" Then
            Return items
        ElseIf YODA_F.StartsWith("![") = False And YODA_F.EndsWith("]") Then
            Throw New Exception("The format of data markup is unclear.")
        End If
        YODA_F = YODA_F.Remove(0, 2)
        YODA_F = YODA_F.Remove(YODA_F.Length - 1).Trim
        Dim cotStarter As Char = YODA_F(0)

        If cotStarter <> "'" And cotStarter <> """" Then
            Throw New Exception(cotStarter & " - Starter is incomprehensible, start with a string quotation.")
        End If

        Dim lenOfYODA As Integer = YODA_F.Length - 1
        Dim nextItem As Boolean = False
        For index = 0 To lenOfYODA
            If nextItem Then
                If YODA_F(index) = " " Then
                    Continue For
                ElseIf YODA_F(index) = "," Then
                    nextItem = False
                    Continue For
                Else
                    Throw New Exception(YODA_F(index) & " - Unauthorized character found outside of string.")
                End If
            End If
            item &= YODA_F(index)
            If item.Length > 1 AndAlso item.StartsWith(cotStarter) AndAlso item.EndsWith(cotStarter) Then
                item = item.Remove(0, 1)
                item = item.Remove(item.Length - 1)
                Return_Unique_Char(item)
                items.Add(item)
                item = ""
                nextItem = True
            End If
        Next

        Return items
    End Function
End Class
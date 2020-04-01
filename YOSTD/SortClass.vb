Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CompilerServices

Public Class Sort

    Private Shared Sub CheckVaildItems(items As ArrayList, referAlgorithm As String)
        For index = 0 To items.Count - 1
            If IsNumeric(items(index)) = False Then
                Throw New Exception("The " & referAlgorithm & " sorting algorithm cannot use string['" & items(index) & "'].")
            End If
        Next
    End Sub
#Region "BubbleSort"

    Public Shared Function BubbleSort(YODA_F As String) As String
        Dim items As ArrayList = YODA_Format.ReadYODA(YODA_F)
        CheckVaildItems(items, "Bubble")
        For i = 1 To (items.Count - 1)
            For j = 0 To ((items.Count - 1) - i)
                If items(j) > items(j + 1) Then
                    items(j) = items(j) Xor items(j + 1)
                    items(j + 1) = items(j + 1) Xor items(j)
                    items(j) = items(j) Xor items(j + 1)
                End If
            Next
        Next
        Return YODA_Format.WriteYODA(items)
    End Function

#End Region




#Region "GnomeSort"

    Public Shared Function GnomeSort(YODA_F As String) As String
        Dim items As ArrayList = YODA_Format.ReadYODA(YODA_F)
        CheckVaildItems(items, "Bubble")
        Dim i As Integer = 1
        While i < items.Count
            If CInt(items(i - 1)) <= CInt(items(i)) Then
                i += 1
            Else
                Dim tmp As Integer = items(i)
                items(i) = items(i - 1)
                items(i - 1) = tmp
                i -= 1
                If i = 0 Then
                    i = 1
                End If
            End If
        End While
        Return YODA_Format.WriteYODA(items)
    End Function

#End Region


#Region "BeadSort"


    Public Shared Function BeadSort(YODA_F As String) As String
        Dim items As ArrayList = YODA_Format.ReadYODA(YODA_F)
        CheckVaildItems(items, "Bead")
        Dim i As Integer, j As Integer, max As Integer, sum As Integer
        Dim beads As Byte()

        i = 1
        max = items(0)
        While i < items.Count
            If CInt(items(i)) > max Then
                max = CInt(items(i))
            End If
            i += 1
        End While

        beads = New Byte(max * items.Count - 1) {}

        For i = 0 To items.Count - 1
            For j = 0 To items(i) - 1
                beads(i * max + j) = 1
            Next
        Next

        For j = 0 To max - 1
            sum = 0
            i = 0
            While i < items.Count
                sum += beads(i * max + j)
                beads(i * max + j) = 0
                i += 1
            End While

            For i = items.Count - sum To items.Count - 1
                beads(i * max + j) = 1
            Next
        Next

        For i = 0 To items.Count - 1
            j = 0
            While j < max AndAlso Convert.ToBoolean(beads(i * max + j))
                j += 1
            End While
            items(i) = j
        Next

        Return YODA_Format.WriteYODA(items)
    End Function


#End Region

End Class

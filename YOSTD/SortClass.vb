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


End Class

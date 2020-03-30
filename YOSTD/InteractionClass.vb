Imports System.Text.RegularExpressions
Public Class Interaction


    Public Shared cursor As String = "->"

    Public Shared Function ShowMenu(items As String) As Object
        Dim menuIndex As Short = 0
        Dim key As ConsoleKeyInfo
        Dim textForPrint As String
        Dim menuItems() As Object = YODA_Format.ReadYODA(items).ToArray
        Dim staticCursorTop As Integer = Console.CursorTop
        Do
            Console.CursorTop = staticCursorTop
            textForPrint = String.Empty
            For index = 0 To menuItems.Length - 1
                If menuIndex = index Then
                    textForPrint &= vbCrLf & cursor
                    textForPrint &= menuItems(index)
                Else
                    textForPrint &= vbCrLf & menuItems(index) & Space(cursor.Length)
                End If
            Next
            Console.WriteLine(textForPrint)
            key = Console.ReadKey(True)
            If key.Key.ToString() = "DownArrow" Then
                menuIndex = menuIndex + 1
                If menuIndex > menuItems.Length - 1 Then
                    menuIndex = 0
                End If
            ElseIf key.Key.ToString() = "UpArrow" Then
                menuIndex = menuIndex - 1
                If menuIndex < 0 Then
                    menuIndex = Convert.ToInt16(menuItems.Length - 1)
                End If
            End If
        Loop While key.Key.ToString <> "Enter"

        Return menuItems(menuIndex)
    End Function


End Class

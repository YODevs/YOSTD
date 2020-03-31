Public Class ProgressBar
    Private currentCursorTop As Integer
    Private printStr, progCharLen() As String
    Private progressEnabled As Boolean = False
    Private rndGet As New Random(0)
    Public progress As Integer = 0
    Public progressChar As Char = "="
    Public enabledProgress As Boolean = True
    Public spaceProgressChar As Char = "-"
    Public Sub New()
    End Sub

    Public Sub ShowProgress()
        currentCursorTop = Console.CursorTop
        printStr = "[" & Space(50) & "]"
        Console.WriteLine(printStr)
        progressEnabled = True
        progCharLen = {"\", "|", "/", "-", "\", "|", "/", "-", "*"}
    End Sub
    Public Sub Increase()
        If progress = 100 Or progressEnabled = False Then
            Return
        End If
        Console.CursorTop = currentCursorTop
        progress += 1
        Dim getRen As Integer = progress / 2
        Dim dtr As New String(progressChar, getRen)
        Dim fsTest As Int16 = 50 - getRen
        Dim drr As New String(spaceProgressChar, fsTest)
        Dim textVal As String = ""
        If enabledProgress Then
            printStr = "[" & dtr & drr & "]" & progCharLen(rndGet.Next(0, 9)) & Space(1) & progress & "%  "
        Else
            printStr = "[" & dtr & drr & "]"
        End If
        Console.WriteLine(printStr)
    End Sub
    Public Sub Decrease()
        If progress = 0 Or progressEnabled = False Then
            Return
        End If
        Console.CursorTop = currentCursorTop
        progress -= 1
        Dim getRen As Integer = progress / 2
        Dim dtr As New String(progressChar, getRen)
        Dim fsTest As Int16 = 50 - getRen
        Dim drr As New String(spaceProgressChar, fsTest)
        If enabledProgress Then
            printStr = "[" & dtr & drr & "]" & progCharLen(rndGet.Next(0, 9)) & Space(1) & progress & "%"
        Else
            printStr = "[" & dtr & drr & "]"
        End If
        Console.WriteLine(printStr & Space(5))
    End Sub

    Public Sub HideProgress()
        If progressEnabled = False Then
            Return
        End If
        Console.CursorTop = currentCursorTop
        Console.WriteLine(Space(printStr.Length + 2))
    End Sub

    Public Sub ResetProgress()
        progress = 0
    End Sub
End Class

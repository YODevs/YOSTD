Public Class App

    Public Shared Sub print(text As String)
        Console.Out.Write(text)
    End Sub

    Public Shared Sub Println(text As String)
        Console.Out.WriteLine(text)
    End Sub

    Public Shared Sub SetTitle(titleInp As String)
        Console.Title = titleInp
    End Sub

    Public Shared Sub EraseScreen()
        Console.Clear()
    End Sub

    Public Shared Sub EraseLine()
        Console.CursorLeft = 0
        Console.Write(Space(Console.BufferWidth))

    End Sub


    Public Shared Sub ShowCursor()
        Console.CursorVisible = True
    End Sub

    Public Shared Sub HideCursor()
        Console.CursorVisible = False
    End Sub

    Public Shared Sub SetCursorSize(size As Integer)
        Try
            Console.CursorSize = size
        Catch ex As Exception
            mtDevelop.Develop.VSError("CursorSize Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetCursorXPos(x As Integer)
        Try
            Console.CursorLeft = x
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetCursorXPos Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetCursorYPos(y As Integer)
        Try
            Console.CursorTop = y
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetCursorYPos Error", ex.Message)
        End Try
    End Sub
    Public Shared Sub SetCursorPos(x As Integer, y As Integer)
        Try
            Console.CursorLeft = x
            Console.CursorTop = y
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetCursorPos Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetBackgroundColor(intColor As Integer)
        Try
            Console.BackgroundColor = intColor
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetBackgroundColor Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetForegroundColor(intColor As Integer)
        Try
            Console.ForegroundColor = intColor
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetForegroundColor Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub ResetColor()
        Console.ResetColor()
    End Sub

    Public Shared Sub YOSize(height As Integer, width As Integer)
        Try
            Console.WindowHeight = height
            Console.WindowWidth = width
        Catch ex As Exception
            mtDevelop.Develop.VSError("YOSize Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub YOHeight(height As Integer)
        Try
            Console.WindowHeight = height
        Catch ex As Exception
            mtDevelop.Develop.VSError("YOHeight Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub YOWidth(width As Integer)
        Try
            Console.WindowWidth = width
        Catch ex As Exception
            mtDevelop.Develop.VSError("YOWidth Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetBufferHeight(value As Integer)
        Try
            Console.BufferHeight = value
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetBufferHeight Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetBufferWidth(value As Integer)
        Try
            Console.BufferWidth = value
        Catch ex As Exception
            mtDevelop.Develop.VSError("SetBufferWidth Error", ex.Message)
        End Try
    End Sub

    Public Shared Sub SetTreatControlCAsInput(value As Boolean)
        Console.TreatControlCAsInput = value
    End Sub

    Public Shared Function GetTitle()
        Return Console.Title
    End Function

    Public Shared Function GetBackgroundColor() As Integer
        Return Console.BackgroundColor
    End Function

    Public Shared Function GetForegroundColor() As Integer
        Return Console.ForegroundColor
    End Function

    Public Shared Function GetCursorSize() As Integer
        Return Console.CursorSize
    End Function

    Public Shared Function GetCursorTop() As Integer
        Return Console.CursorTop
    End Function

    Public Shared Function GetCursorLeft() As Integer
        Return Console.CursorLeft
    End Function

    Public Shared Function GetYOHeight() As Integer
        Return Console.WindowHeight
    End Function
    Public Shared Function GetYOWidth() As Integer
        Return Console.WindowWidth
    End Function

    Public Shared Function GetCursorVisible() As Boolean
        Return Console.CursorVisible
    End Function

    Public Shared Function GetBufferHeight() As Integer
        Return Console.BufferHeight
    End Function
    Public Shared Function GetBufferWidth() As Integer
        Return Console.BufferWidth
    End Function
    Public Shared Function GetTreatControlCAsInput() As Integer
        Return Console.TreatControlCAsInput
    End Function

End Class

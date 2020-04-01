Public Class StopWatch
    Public days, hours, minutes, seconds, milliseconds, ticks As Integer
    Private startTime As Long = 0
    Public smartTimeSpan As TimeSpan

    Public Sub New()

    End Sub
    Public Function Start()
        days = 0
        hours = 0
        minutes = 0
        seconds = 0
        milliseconds = 0
        ticks = 0

        startTime = DateTime.Now.Ticks
        Return DateTime.Now.Ticks

    End Function

    Public Function [Stop]()
        If startTime = 0 Then
            Throw New Exception("Start the stopwatch first with the 'Start()' method.")
        End If
        Dim elapsedTicks As Long = DateTime.Now.Ticks - startTime - 200
        smartTimeSpan = New TimeSpan(elapsedTicks)
        days = smartTimeSpan.Days
        hours = smartTimeSpan.Hours
        minutes = smartTimeSpan.Minutes
        seconds = smartTimeSpan.Seconds
        milliseconds = smartTimeSpan.Milliseconds
        ticks = smartTimeSpan.Ticks

        Return DateTime.Now.Ticks
    End Function

End Class

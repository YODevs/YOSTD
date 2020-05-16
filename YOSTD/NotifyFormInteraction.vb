Imports System.Timers
Imports System.Windows.Forms

Public Class NotifyFormInteraction
    Public XenTimer As New System.Timers.Timer
    Public getWidthDef As Int32 = 0
    Public hppub As Integer

    Private Sub NotifyFormInteraction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        XenTimer.AutoReset = True
        AddHandler XenTimer.Elapsed, AddressOf TimerProcess_Tick
        XenTimer.Start()
        Dim hPrForm As Integer = 0
        If Notify.hPrForm = 0 AndAlso Application.OpenForms.Count > 1 Then
            Notify.hPrForm = Application.OpenForms(Application.OpenForms.Count - 2).Height + Me.Height + 5
        End If
        If Application.OpenForms.Count > 1 Then
            hPrForm = Notify.hPrForm
            Notify.hPrForm += Application.OpenForms(Application.OpenForms.Count - 2).Height + 5
            Me.SetDesktopLocation(getWidthDef, Screen.PrimaryScreen.WorkingArea.Height - hPrForm)
        End If
        Me.Tag = hPrForm
        hppub = hPrForm
    End Sub

    Private Sub TimerProcess_Tick(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub


End Class
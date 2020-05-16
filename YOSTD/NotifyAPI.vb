Imports System.Windows.Forms

Public Class Notify

    Public Shared hPrForm As Integer = 0
    Private th As System.Threading.Thread
    Private NotifyForm As NotifyFormInteraction

    Public interval As Integer = 500
    Public Sub New()
        NotifyForm = New NotifyFormInteraction
        th = New Threading.Thread(AddressOf NotifyForm.ShowDialog)
    End Sub

    Public Sub Show(text As String)
        Dim rnd As New Random
        NotifyForm.Tag = rnd.Next(99999, 999999)

        'If IsAlive Then
        'NotifyForm.Close()
        'End If

        If th.IsAlive Then
            th = New Threading.Thread(AddressOf NotifyForm.ShowDialog)
        End If

        NotifyForm.getWidthDef = Screen.PrimaryScreen.WorkingArea.Width - NotifyForm.Width
        NotifyForm.SetDesktopLocation(Screen.PrimaryScreen.WorkingArea.Width - NotifyForm.Width, Screen.PrimaryScreen.WorkingArea.Height - NotifyForm.Height)
        th.SetApartmentState(Threading.ApartmentState.MTA)
        th.Start()
        NotifyForm.XenTimer.Interval = interval
        NotifyForm.caption.Text = text
        Threading.Thread.Sleep(10)
    End Sub

    Public Sub Hide()
        NotifyForm.Close()
    End Sub


    Public ReadOnly Property IsAlive() As Boolean
        Get
            Try
                For index = 0 To Application.OpenForms.Count - 1
                    If Application.OpenForms(index).Tag = NotifyForm.Tag Then
                        Return True
                    End If
                Next
            Catch ex As Exception
                Return False
            End Try
            Return False
        End Get
    End Property

End Class

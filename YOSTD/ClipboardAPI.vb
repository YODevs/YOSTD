
Imports System.Drawing

Public Class ClipBoard


    Public Shared Sub SetData(value As String)
        My.Computer.Clipboard.SetText(value)
    End Sub

    Public Shared Function GetData() As String
        If My.Computer.Clipboard.ContainsText = False Then Return Nothing
        Return My.Computer.Clipboard.GetText()
    End Function

    Public Shared Sub ClearData()
        My.Computer.Clipboard.Clear()
    End Sub

    Public ReadOnly Property containsData() As String
        Get
            Return My.Computer.Clipboard.ContainsText
        End Get
    End Property

End Class

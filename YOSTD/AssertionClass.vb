Public Class Assert
    Private formReportUnitTest As New ReportUnitTest

    Private th As New System.Threading.Thread(AddressOf formReportUnitTest.ShowDialog)

    Public Sub New()

    End Sub
    Private Sub ShowReportUnitTest()
        If formReportUnitTest.IsHandleCreated = False Then
            th.SetApartmentState(Threading.ApartmentState.STA)
            th.Start()
        Else
            Threading.Thread.Sleep(15)
            formReportUnitTest.dtReport.AutoResizeColumns()
        End If
    End Sub
    Private Sub ReCheckOutputColor()
        For index = 0 To formReportUnitTest.dtReport.Rows.Count - 2
            If formReportUnitTest.dtReport.Rows.Item(index).Cells(4).Value = "Pass" Then
                formReportUnitTest.dtReport.Rows.Item(index).Cells(4).ToolTipText = "Pass Test"
            Else
                formReportUnitTest.dtReport.Rows.Item(index).Cells(4).ErrorText = "Faild Test"
            End If
        Next
    End Sub

    Public Sub IsTrue(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If idealResult = realResult Then
            result = "Pass"
        End If
        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "Equal", result)
        ReCheckOutputColor()
    End Sub


    Public Sub IsFalse(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If idealResult <> realResult Then
            result = "Pass"
        End If
        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "UnEqual", result)
        ReCheckOutputColor()
    End Sub


    Public Sub Contains(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If realResult.Contains(idealResult) Then
            result = "Pass"
        End If
        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "Contains", result)
        ReCheckOutputColor()
    End Sub

    Public Sub StartsWith(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If realResult.StartsWith(idealResult) Then
            result = "Pass"
        End If
        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "StartsWith", result)
        ReCheckOutputColor()
    End Sub

    Public Sub EndsWith(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If realResult.EndsWith(idealResult) Then
            result = "Pass"
        End If
        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "EndsWith", result)
        ReCheckOutputColor()
    End Sub

    Public Sub FindOut(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        Dim items As ArrayList = YODA_Format.ReadYODA(realResult)
        For index = 0 To items.Count - 1
            If items(index) = idealResult Then
                result = "Pass"
                Exit For
            End If
        Next

        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "FindOut", result)
        ReCheckOutputColor()
    End Sub


    Public Sub IsGreater(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If IsNumeric(realResult) AndAlso IsNumeric(idealResult) Then

            If idealResult.Contains(".") Or idealResult.Contains(".") Then
                If realResult > idealResult Then
                    result = "Pass"
                End If

            Else
                Dim igIntLeft, igIntRight As Integer
                igIntLeft = realResult
                igIntRight = idealResult
                If igIntLeft > igIntRight Then
                    result = "Pass"
                End If
            End If
        End If

        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "Greater", result)
        ReCheckOutputColor()
    End Sub


    Public Sub IsGreaterEq(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If IsNumeric(realResult) AndAlso IsNumeric(idealResult) Then

            If idealResult.Contains(".") Or idealResult.Contains(".") Then
                If realResult >= idealResult Then
                    result = "Pass"
                End If

            Else
                Dim igIntLeft, igIntRight As Integer
                igIntLeft = realResult
                igIntRight = idealResult
                If igIntLeft >= igIntRight Then
                    result = "Pass"
                End If
            End If
        End If

        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "Greater / Eq", result)
        ReCheckOutputColor()
    End Sub

    Public Sub IsLess(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If IsNumeric(realResult) AndAlso IsNumeric(idealResult) Then

            If idealResult.Contains(".") Or idealResult.Contains(".") Then
                If realResult < idealResult Then
                    result = "Pass"
                End If

            Else
                Dim igIntLeft, igIntRight As Integer
                igIntLeft = realResult
                igIntRight = idealResult
                If igIntLeft < igIntRight Then
                    result = "Pass"
                End If
            End If
        End If

        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "Less", result)
        ReCheckOutputColor()
    End Sub

    Public Sub IsLessEq(idTest As String, realResult As String, idealResult As String)
        ShowReportUnitTest()
        Dim result As String = "Failed"
        If IsNumeric(realResult) AndAlso IsNumeric(idealResult) Then

            If idealResult.Contains(".") Or idealResult.Contains(".") Then
                If realResult <= idealResult Then
                    result = "Pass"
                End If

            Else
                Dim igIntLeft, igIntRight As Integer
                igIntLeft = realResult
                igIntRight = idealResult
                If igIntLeft <= igIntRight Then
                    result = "Pass"
                End If
            End If
        End If

        formReportUnitTest.dtReport.Rows.Add(idTest, realResult, idealResult, "Less / Eq", result)
        ReCheckOutputColor()
    End Sub


End Class

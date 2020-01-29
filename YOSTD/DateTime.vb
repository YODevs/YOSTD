Public Class [Date]

    ''' <summary>
    ''' Return date and time in arbitrary format.
    ''' </summary>
    ''' <param name="format">Primary date format</param>
    ''' <returns>String</returns>
    Public Shared Function GetDate(format As String) As String

        If format = Nothing Then Return DateTime.Now 'Return with default format

        Dim setLoopChar As Boolean = False
        Dim getSingleFormat As String = String.Empty
        Dim returnDate As String = format

        For Each GetChar As Char In format

            Select Case GetChar
                Case "{"
                    getSingleFormat = GetChar
                    setLoopChar = True
                Case "}"
                    setLoopChar = False
                    getSingleFormat &= GetChar
                    'Validation and replacement in elementary history format
                    returnDate = returnDate.Replace(getSingleFormat, CheckSingleFormat(getSingleFormat))
                    getSingleFormat = String.Empty
                Case Else
                    If setLoopChar Then
                        getSingleFormat &= GetChar
                        Continue For
                    End If
            End Select
        Next

        Return returnDate
    End Function

    Private Shared Function CheckSingleFormat(singleFormat As String)
        singleFormat = singleFormat.Remove(0, 1)
        singleFormat = singleFormat.Remove(singleFormat.Length - 1)
        singleFormat = singleFormat.Trim

        'Identify constant expressions in string
        Dim getDataOfSingleFormat As String = String.Empty
        Select Case singleFormat
            Case "Y"
                getDataOfSingleFormat = DateTime.Now.Year
            Case "M"
                getDataOfSingleFormat = DateTime.Now.Month
            Case "D"
                getDataOfSingleFormat = DateTime.Now.Day
            Case "DW"
                getDataOfSingleFormat = DateTime.Now.DayOfWeek
            Case "DY"
                getDataOfSingleFormat = DateTime.Now.DayOfYear
            Case "h"
                getDataOfSingleFormat = DateTime.Now.Hour
            Case "m"
                getDataOfSingleFormat = DateTime.Now.Minute
            Case "s"
                getDataOfSingleFormat = DateTime.Now.Second
            Case "t"
                getDataOfSingleFormat = DateTime.Now.Millisecond
            Case Else
                Return Nothing
        End Select

        Return getDataOfSingleFormat
    End Function

End Class
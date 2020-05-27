Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Table
    'Clone From https://github.com/khalidabuhakmeh/ConsoleTables/
    Private _Rows As System.Collections.Generic.IList(Of Object()), _Options As TableOptions, _ColumnTypes As System.Type()
    Public Property Columns As IList(Of Object)

    Public Property Rows As IList(Of Object())
        Get
            Return _Rows
        End Get
        Protected Set(ByVal value As IList(Of Object()))
            _Rows = value
        End Set
    End Property

    Public Property Options As TableOptions
        Get
            Return _Options
        End Get
        Protected Set(ByVal value As TableOptions)
            _Options = value
        End Set
    End Property

    Public Property ColumnTypes As Type()
        Get
            Return _ColumnTypes
        End Get
        Private Set(ByVal value As Type())
            _ColumnTypes = value
        End Set
    End Property

    Public Shared NumericTypes As HashSet(Of Type) = New HashSet(Of Type) From {
        GetType(Integer),
        GetType(Double),
        GetType(Decimal),
        GetType(Long),
        GetType(Short),
        GetType(SByte),
        GetType(Byte),
        GetType(ULong),
        GetType(UShort),
        GetType(UInteger),
        GetType(Single)
    }

    <Obsolete>
    Public Sub New()
        Me.New(New TableOptions With {
            .Columns = New List(Of String)()
        })
    End Sub

    <Obsolete>
    Public Sub New(ByVal options As TableOptions)
        Me.Options = If(options, CSharpImpl.__Throw(Of TableOptions)(New ArgumentNullException("options")))
        Rows = New List(Of Object())()
        Columns = New List(Of Object)(options.Columns)
    End Sub



    Public Function Show()
        Write(0)
        Return Rows.Count
    End Function

    Public Sub AddColumn(nColumns_YODAFormat As String)
        Dim columnItems As ArrayList = YODA_Format.ReadYODA(nColumns_YODAFormat)
        For index = 0 To columnItems.Count - 1
            Columns.Add(columnItems(index))
        Next
    End Sub

    Public Sub AddRow(nRows_YODAFormat As String)
        Dim rowItems As ArrayList = YODA_Format.ReadYODA(nRows_YODAFormat)
        If nRows_YODAFormat Is Nothing Then Throw New ArgumentNullException(NameOf(nRows_YODAFormat))
        If Not Columns.Any() Then Throw New Exception("Set the columns first")
        If Columns.Count <> rowItems.Count Then Throw New Exception($"The number columns in the row ({Columns.Count}) does not match the values ({rowItems.Count  })")
        Dim items() As Object = rowItems.ToArray
        Rows.Add(items)
    End Sub
    Public Function AddColumnT(ByVal names As IEnumerable(Of String)) As Table
        For Each name In names
            Columns.Add(name)
        Next
        Return Me
    End Function

    Public Function AddRowT(ParamArray values As Object()) As Table
        If values Is Nothing Then Throw New ArgumentNullException(NameOf(values))
        If Not Columns.Any() Then Throw New Exception("Set the columns first")
        If Columns.Count <> values.Length Then Throw New Exception($"The number columns in the row ({Columns.Count}) does not match the values ({values.Length}")
        Rows.Add(values)
        Return Me
    End Function

    Public Function Configure(ByVal action As Action(Of TableOptions)) As Table
        action(Options)
        Return Me
    End Function

    <Obsolete>
    Public Shared Function From(Of T)(ByVal values As IEnumerable(Of T)) As Table
        Dim table = New Table With {
            .ColumnTypes = GetColumnsType(Of T)().ToArray()
        }
        Dim columns = GetColumns(Of T)()
        table.AddColumnT(columns)

        For Each propertyValues In values.[Select](Function(value) columns.[Select](Function(column) GetColumnValue(Of T)(value, column)))
            table.AddRowT(propertyValues.ToArray())
        Next

        Return table
    End Function

    Public Overrides Function ToString() As String
        Dim builder = New StringBuilder()
        Dim columnLengths = Me.ColumnLengths()
        Dim columnAlignment = Enumerable.Range(0, Columns.Count).[Select](New Func(Of Integer, String)(AddressOf GetNumberAlignment)).ToList()
        Dim format = Enumerable.Range(0, Columns.Count).[Select](Function(i) " | {" & i & "," & columnAlignment(i) & columnLengths(i) & "}").Aggregate(Function(s, a) s & a) & " |"
        Dim maxRowLength = Math.Max(0, If(Rows.Any(), Rows.Max(Function(row) String.Format(format, row).Length), 0))
        Dim columnHeaders = String.Format(format, Columns.ToArray())
        Dim longestLine = Math.Max(maxRowLength, columnHeaders.Length)
        Dim results = Rows.[Select](Function(row) String.Format(format, row)).ToList()
        Dim divider = " " & String.Join("", Enumerable.Repeat("-", longestLine - 1)) & " "
        builder.AppendLine(divider)
        builder.AppendLine(columnHeaders)

        For Each row In results
            builder.AppendLine(divider)
            builder.AppendLine(row)
        Next

        builder.AppendLine(divider)

        If Options.EnableCount Then
            builder.AppendLine("")
            builder.AppendFormat(" Count: {0}", Rows.Count)
        End If

        Return builder.ToString()
    End Function

    Public Function ToMarkDownString() As String
        Return ToMarkDownString("|"c)
    End Function

    Private Function ToMarkDownString(ByVal delimiter As Char) As String
        Dim builder = New StringBuilder()
        Dim columnLengths = Me.ColumnLengths()
        Dim format = Me.Format(columnLengths, delimiter)
        Dim columnHeaders = String.Format(format, Columns.ToArray())
        Dim results = Rows.[Select](Function(row) String.Format(format, row)).ToList()
        Dim divider = System.Text.RegularExpressions.Regex.Replace(columnHeaders, "[^|]", "-")
        builder.AppendLine(columnHeaders)
        builder.AppendLine(divider)
        results.ForEach(Sub(row) builder.AppendLine(row))
        Return builder.ToString()
    End Function

    Public Function ToMinimalString() As String
        Return ToMarkDownString(Char.MinValue)
    End Function

    Public Function ToStringAlternative() As String
        Dim builder = New StringBuilder()
        Dim columnLengths = Me.ColumnLengths()
        Dim format = Me.Format(columnLengths)
        Dim columnHeaders = String.Format(format, Columns.ToArray())
        Dim results = Rows.[Select](Function(row) String.Format(format, row)).ToList()
        Dim divider = System.Text.RegularExpressions.Regex.Replace(columnHeaders, "[^|]", "-")
        Dim dividerPlus = divider.Replace("|", "+")
        builder.AppendLine(dividerPlus)
        builder.AppendLine(columnHeaders)

        For Each row In results
            builder.AppendLine(dividerPlus)
            builder.AppendLine(row)
        Next

        builder.AppendLine(dividerPlus)
        Return builder.ToString()
    End Function

    Private Function Format(ByVal columnLengths As List(Of Integer), ByVal Optional delimiter As Char = "|"c) As String
        ' set right alinment if is a number
        Dim columnAlignment = Enumerable.Range(0, Columns.Count).[Select](New Func(Of Integer, String)(AddressOf GetNumberAlignment)).ToList()
        Dim delimiterStr = If(delimiter = Char.MinValue, String.Empty, delimiter.ToString())
        Dim l_Format = (Enumerable.Aggregate(Of String)(Enumerable.Select(Of Integer, Global.System.[String])(Enumerable.Range(CInt(0), CInt(Columns.Count)), CType(Function(i) CStr(" " & delimiterStr & " {" & i & "," & columnAlignment(CInt(i)) & columnLengths(CInt(i)) & "}"), Func(Of Integer, String))), CType(Function(s, a) CStr(s & a), Func(Of String, String, String))) & " " & delimiterStr).Trim()
        Return l_Format
    End Function

    Private Function GetNumberAlignment(ByVal i As Integer) As String
        Return If(Options.NumberAlignment = Alignment.Right AndAlso ColumnTypes IsNot Nothing AndAlso NumericTypes.Contains(ColumnTypes(i)), "", "-")
    End Function

    Private Function ColumnLengths() As List(Of Integer)
        Dim l_ColumnLengths = Columns.[Select](Function(t, i) Enumerable.Select(Of Object, Global.System.Int32)(Enumerable.Where(Of Object)(Enumerable.Union(Of Object)(Enumerable.Select(Of Object(), Global.System.[Object])(Rows, CType(Function(x) CObj(x(CInt(i))), Func(Of Object(), Object))), CType({Columns(CInt(i))}, IEnumerable(Of Object))), CType(Function(x) CBool(x IsNot Nothing), Func(Of Object, Boolean))), CType(Function(x) CInt(x.ToString().Length), Func(Of Object, Integer))).Max()).ToList()
        Return l_ColumnLengths
    End Function

    Public Sub Write(ByVal Optional format As Format = 0)
        Select Case format
            Case Format.Default
                Options.OutputTo.WriteLine(ToString())
            Case Format.MarkDown
                Options.OutputTo.WriteLine(ToMarkDownString())
            Case Format.Alternative
                Options.OutputTo.WriteLine(ToStringAlternative())
            Case Format.Minimal
                Options.OutputTo.WriteLine(ToMinimalString())
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(format), format, Nothing)
        End Select
    End Sub

    Private Shared Function GetColumns(Of T)() As IEnumerable(Of String)
        Return GetType(T).GetProperties().[Select](Function(x) x.Name).ToArray()
    End Function

    Private Shared Function GetColumnValue(Of T)(ByVal target As Object, ByVal column As String) As Object
        Return GetType(T).GetProperty(column).GetValue(target, Nothing)
    End Function

    Private Shared Function GetColumnsType(Of T)() As IEnumerable(Of Type)
        Return GetType(T).GetProperties().[Select](Function(x) x.PropertyType).ToArray()
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class

Public Class TableOptions
    Public Property Columns As IEnumerable(Of String) = New List(Of String)()
    Public Property EnableCount As Boolean = False


    Public Property NumberAlignment As Alignment = Alignment.Left

    Public Property OutputTo As TextWriter = Console.Out

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal throw statements")>
        Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class

Public Enum Format
        [Default] = 0
        MarkDown = 1
        Alternative = 2
        Minimal = 3
    End Enum

    Public Enum Alignment
        Left
        Right
    End Enum

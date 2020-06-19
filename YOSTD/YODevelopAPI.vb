Imports System.Reflection

Public Class YODevelopAPI

    Public typeDev As System.Type
    Public assemblyDev As System.Reflection.Assembly
    Public objectDev As System.Object

    Public Sub New()
        assemblyDev = Reflection.Assembly.GetEntryAssembly()
        typeDev = assemblyDev.GetType("YO_Co.mt_YODevelop")
        If IsNothing(typeDev) Then
            Throw New Exception("'YO_Co.mt_YODevelop' type was not found in the assembly.")
        End If
    End Sub

    Public Sub AddVariable(type As String, variableName As String, value As String, Optional isConstant As Boolean = False)
        typeDev.InvokeMember("AddVariable", BindingFlags.InvokeMethod, Nothing, Nothing, New Object() {type, variableName, value, isConstant})
    End Sub

    Public Function SetValue(variableName As String, newValue As Object) As Boolean
        Return typeDev.InvokeMember("SetValue", BindingFlags.InvokeMethod, Nothing, Nothing, New Object() {variableName, newValue})
    End Function

    Public Function GetValue(variableName As String) As Object
        Return typeDev.InvokeMember("GetValue", BindingFlags.InvokeMethod, Nothing, Nothing, New Object() {variableName})
    End Function

    Public Function GetValueByPointer(pointer As String) As Object
        Return typeDev.InvokeMember("GetValueByPointer", BindingFlags.InvokeMethod, Nothing, Nothing, New Object() {pointer})
    End Function
End Class

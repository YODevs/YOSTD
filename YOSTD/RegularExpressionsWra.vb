Imports System.Text

Public Class [regex]

    Public regexOpt As RegularExpressions.RegexOptions
    Public matchObj As RegularExpressions.Match
    Public Sub New()

    End Sub

    Public Property RegexOption() As Integer
        Get
            Return regexOpt
        End Get
        Set(ByVal value As Integer)
            regexOpt = value
        End Set
    End Property

    Public ReadOnly Property MatchResult() As Boolean
        Get
            If IsNothing(matchObj) Then
                Throw New Exception("Must first call the 'MatchStr($cust _text,$cust pattern)' function.")
                Return 0
            End If
            Return matchObj.Success
        End Get
    End Property

    Public ReadOnly Property MatchValue() As String
        Get
            If IsNothing(matchObj) Then
                Throw New Exception("Must first call the 'MatchStr($cust _text,$cust pattern)' function.")
                Return 0
            End If
            Return matchObj.Success
        End Get
    End Property

    Public ReadOnly Property MatchLength() As Integer
        Get
            If IsNothing(matchObj) Then
                Throw New Exception("Must first call the 'MatchStr($cust _text,$cust pattern)' function.")
                Return 0
            End If
            Return matchObj.Length
        End Get
    End Property

    Public Function IsMatch(text As String, pattern As String) As Boolean
        Return RegularExpressions.Regex.IsMatch(text, pattern, regexOpt)
    End Function

    Public Function MatchStr(text As String, pattern As String) As String
        matchObj = RegularExpressions.Regex.Match(text, pattern, regexOpt)
        Return matchObj.Value
    End Function
End Class

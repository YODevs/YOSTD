Imports System.Runtime.CompilerServices
Imports System.Runtime.ConstrainedExecution
Imports System.Security
Imports System.Text

Public Class MathFunc

    Public Shared ReadOnly Property PI() As Double
        Get
            Return 3.14159265358979
        End Get
    End Property
    Public Shared ReadOnly Property TUA() As Double
        Get
            Return 6.28318530717958
        End Get
    End Property
    Public Shared ReadOnly Property E() As Double
        Get
            Return 2.71828182845904
        End Get
    End Property
    Public Shared Function Factorial(ByVal number As Integer) As Long
        If number < 0 Then
            'Unexpected number
            Return -1
        End If

        Dim result As Long = 1
        For i As Integer = 1 To number
            result *= i
        Next

        Return result
    End Function

    Public Shared Function Abs(ByVal value As Decimal) As Decimal
        If (value >= 0) Then
            Return value
        End If
        Return value * -1
    End Function

    Public Shared Function BigMul(ByVal a As Integer, ByVal b As Integer) As Long
        Return (a * b)
    End Function

    Public Shared Function Ceiling(ByVal number As Decimal) As Decimal
        Return Decimal.Ceiling(number)
    End Function

    Public Shared Function Floor(ByVal number As Decimal) As Decimal
        Return Decimal.Floor(number)
    End Function

    Public Shared Function Log(ByVal number As Double, ByVal newBase As Double) As Double
        If Double.IsNaN(number) Then
            Return number
        End If
        If Double.IsNaN(newBase) Then
            Return newBase
        End If
        If ((newBase <> 1) AndAlso ((number = 1) OrElse ((newBase <> 0) AndAlso Not Double.IsPositiveInfinity(newBase)))) Then
            Return (Math.Log(number) / Math.Log(newBase))
        End If
        Return Double.NaN
    End Function
    Public Shared Function Max(ByVal val1 As Long, ByVal val2 As Long) As Long
        If (val1 < val2) Then
            Return val2
        End If
        Return val1
    End Function

    Public Shared Function Min(ByVal val1 As Long, ByVal val2 As Long) As Long
        If (val1 > val2) Then
            Return val2
        End If
        Return val1
    End Function


    Public Shared Function Round(ByVal d As Decimal) As Decimal
        Return Decimal.Round(d, 0)
    End Function

    Public Shared Function Sign(ByVal value As Decimal) As Integer
        If (value < Decimal.Zero) Then
            Return -1
        End If
        If (value > Decimal.Zero) Then
            Return 1
        End If
        Return 0
    End Function




#Region "Convertors"

    Private Enum RomanDigit
        I = 1
        V = 5
        X = 10
        L = 50
        C = 100
        D = 500
        M = 1000
    End Enum

    Public Shared Function CRomanToNumbers(roman As String) As Integer
        roman = roman.ToUpper().Trim()
        If roman = "N" Then
            Return 0
        End If

        Dim ptr As Integer = 0
        Dim values As New ArrayList()
        Dim maxDigit As Integer = 1000
        While ptr < roman.Length
            Dim numeral As Char = roman(ptr)
            Dim digit As Integer = CInt([Enum].Parse(GetType(RomanDigit), numeral.ToString()))

            Dim nextDigit As Integer = 0
            If ptr < roman.Length - 1 Then
                Dim nextNumeral As Char = roman(ptr + 1)
                nextDigit = CInt([Enum].Parse(GetType(RomanDigit), nextNumeral.ToString()))

                If nextDigit > digit Then
                    maxDigit = digit - 1
                    digit = nextDigit - digit
                    ptr += 1
                End If
            End If

            values.Add(digit)
            ptr += 1
        End While

        Dim total As Integer = 0
        For Each digit As Integer In values
            total += digit
        Next

        Return total
    End Function


    Public Shared Function COctalToDecimal(octal As String) As Integer
        Dim octLength As Integer = octal.Length
        Dim dec As Double = 0

        For i As Integer = 0 To octLength - 1
            dec += (CByte(AscW(octal(i))) - 48) * System.Math.Pow(8, ((octLength - i) - 1))
        Next

        Return CInt(System.Math.Truncate(dec))
    End Function


    Public Shared Function COctalToASCII(oct As String) As String
        Dim ascii As String = String.Empty

        For i As Integer = 0 To oct.Length - 1 Step 3
            ascii += ChrW(COctalToDecimal(oct.Substring(i, 3)))
        Next

        Return ascii
    End Function


    Public Shared Function CNumbersToWords(num As ULong) As String
        Dim words As New StringBuilder()
        Dim singles As String() = New String() {"zero", "one", "two", "three", "four", "five",
        "six", "seven", "eight", "nine"}
        Dim teens As String() = New String() {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
        "sixteen", "seventeen", "eighteen", "nineteen"}
        Dim tens As String() = New String() {"", "", "twenty", "thirty", "forty", "fifty",
        "sixty", "seventy", "eighty", "ninety"}
        Dim powers As String() = New String() {"", "thousand", "million", "billion", "trillion", "quadrillion",
        "quintillion"}

        If num >= 1000 Then
            For i As Integer = powers.Length - 1 To 0 Step -1
                Dim power As ULong = CULng(System.Math.Pow(1000, i))
                Dim count As ULong = (num - (num Mod power)) \ power

                If num > power Then
                    words.Append(CNumbersToWords(count) & " " & powers(i))
                    num -= count * power
                End If
            Next
        End If

        If num >= 100 Then
            Dim count As ULong = (num - (num Mod 100)) \ 100
            words.Append(CNumbersToWords(count) & " hundred")
            num -= count * 100
        End If

        If num >= 20 AndAlso num < 100 Then
            Dim count As ULong = (num - (num Mod 10)) \ 10
            words.Append(" " & tens(count))
            num -= count * 10
        End If

        If num >= 10 AndAlso num < 20 Then
            words.Append(" " & teens(num - 10))
            num = 0
        End If

        If num > 0 AndAlso num < 10 Then
            words.Append(" " & singles(num))
        End If

        Return words.ToString()
    End Function



    Public Shared Function CNumbersToRoman(num As Integer) As String
        Dim roman As New StringBuilder()

        Dim totalM As Integer = Int(num \ 1000)
        num = num Mod 1000
        Dim totalCM As Integer = Int(num \ 900)
        num = num Mod 900

        Dim totalD As Integer = Int(num \ 500)
        num = num Mod 500
        Dim totalCD As Integer = Int(num \ 400)
        num = num Mod 400

        Dim totalC As Integer = Int(num \ 100)
        num = num Mod 100
        Dim totalXC As Integer = Int(num \ 90)
        num = num Mod 90

        Dim totalL As Integer = Int(num \ 50)
        num = num Mod 50
        Dim totalXL As Integer = Int(num \ 40)
        num = num Mod 40

        Dim totalX As Integer = Int(num \ 10)
        num = num Mod 10
        Dim totalIX As Integer = Int(num \ 9)
        num = num Mod 9

        Dim totalV As Integer = Int(num \ 5)
        num = num Mod 5
        Dim totalIV As Integer = Int(num \ 4)
        num = num Mod 4

        roman.Append(RepeatString("M", totalM))
        roman.Append(RepeatString("CM", totalCM))
        roman.Append(RepeatString("D", totalD))
        roman.Append(RepeatString("CD", totalCD))
        roman.Append(RepeatString("C", totalC))
        roman.Append(RepeatString("XC", totalXC))
        roman.Append(RepeatString("L", totalL))
        roman.Append(RepeatString("XL", totalXL))
        roman.Append(RepeatString("X", totalX))
        roman.Append(RepeatString("IX", totalIX))
        roman.Append(RepeatString("V", totalV))
        roman.Append(RepeatString("IV", totalIV))
        roman.Append(RepeatString("I", num))

        Return roman.ToString()
    End Function

    Private Shared Function RepeatString(s As String, count As Integer) As String
        If count < 0 Then
            Return String.Empty
        End If

        Dim str As New StringBuilder(count)

        For i As Integer = 0 To count - 1
            str.Append(s)
        Next

        Return str.ToString()
    End Function



    Public Shared Function CHexadecimalToDecimal(hex As String) As Integer
        hex = hex.ToUpper()

        Dim hexLength As Integer = hex.Length
        Dim dec As Double = 0

        For i As Integer = 0 To hexLength - 1
            Dim b As Byte = CByte(AscW(hex(i)))

            If b >= 48 AndAlso b <= 57 Then
                b -= 48
            ElseIf b >= 65 AndAlso b <= 70 Then
                b -= 55
            End If

            dec += b * System.Math.Pow(16, ((hexLength - i) - 1))
        Next

        Return CInt(System.Math.Truncate(dec))
    End Function


    Public Shared Function CHexadecimalToASCII(hex As String) As String
        Dim ascii As String = String.Empty

        For i As Integer = 0 To hex.Length - 1 Step 2
            ascii += ChrW(CHexadecimalToDecimal(hex.Substring(i, 2)))
        Next

        Return ascii
    End Function



    Public Shared Function CDecimalToOctal(dec As Integer) As String
        If dec < 1 Then Return "0"

        Dim octStr As String = String.Empty

        While dec > 0
            octStr = octStr.Insert(0, (dec Mod 8).ToString())
            dec = Int(dec / 8)
        End While

        Return octStr
    End Function


    Public Shared Function CDecimalToHexadecimal(dec As Integer) As String
        If dec < 1 Then Return "0"

        Dim hex As Integer = dec
        Dim hexStr As String = String.Empty

        While dec > 0
            hex = dec Mod 16

            If hex < 10 Then
                hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString())
            Else
                hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString())
            End If

            dec = Int(dec / 16)
        End While

        Return hexStr
    End Function



    Public Shared Function CDecimalToBinary(dec As Integer) As String
        If dec < 1 Then Return "0"

        Dim binStr As String = String.Empty

        While dec > 0
            binStr = binStr.Insert(0, (dec Mod 2).ToString())
            dec = Int(dec / 2)
        End While

        Return binStr
    End Function


    Public Shared Function CDecimalToASCII(dec As String) As String
        Dim ascii As String = String.Empty

        For i As Integer = 0 To dec.Length - 1 Step 3
            ascii += CChar(ChrW(Convert.ToByte(dec.Substring(i, 3))))
        Next

        Return ascii
    End Function


    Public Shared Function CBinaryToDecimal(bin As String) As Integer
        Dim binLength As Integer = bin.Length
        Dim dec As Double = 0

        For i As Integer = 0 To binLength - 1
            dec += (CByte(AscW(bin(i))) - 48) * System.Math.Pow(2, ((binLength - i) - 1))
        Next

        Return CInt(System.Math.Truncate(dec))
    End Function

    Public Shared Function CBinaryToASCII(bin As String) As String
        Dim ascii As String = String.Empty

        For i As Integer = 0 To bin.Length - 1 Step 8
            ascii += ChrW(CBinaryToDecimal(bin.Substring(i, 8)))
        Next

        Return ascii
    End Function


    Public Shared Function CASCIIToOctal(str As String) As String
        Dim oct As String = String.Empty

        For i As Integer = 0 To str.Length - 1
            Dim cOct As String = CDecimalToOctal(AscW(str(i)))

            If cOct.Length < 3 Then
                cOct = cOct.PadLeft(3, "0"c)
            End If

            oct += cOct
        Next

        Return oct
    End Function


    Public Shared Function CASCIIToHexadecimal(str As String) As String
        Dim hex As String = String.Empty

        For i As Integer = 0 To str.Length - 1
            Dim chex As String = CDecimalToHexadecimal(AscW(str(i)))

            If chex.Length = 1 Then
                chex = chex.Insert(0, "0")
            End If

            hex += chex
        Next

        Return hex
    End Function


    Public Shared Function CASCIIToDecimal(str As String) As String
        Dim dec As String = String.Empty

        For i As Integer = 0 To str.Length - 1
            Dim [cDec] As String = CByte(AscW(str(i))).ToString()

            If [cDec].Length < 3 Then
                [cDec] = [cDec].PadLeft(3, "0"c)
            End If

            dec += [cDec]
        Next

        Return dec
    End Function

    Public Shared Function CASCIIToBinary(ByVal str As String) As String
        Dim bin As String = String.Empty

        For i As Integer = 0 To str.Length - 1
            Dim cBin As String = CDecimalToBinary(Convert.ToInt32(str(i)))

            If cBin.Length < 8 Then
                cBin = cBin.PadLeft(8, "0"c)
            End If

            bin += cBin
        Next

        Return bin
    End Function

    Public Shared Function CWordsToNumbers(words As String) As ULong
        If String.IsNullOrEmpty(words) Then
            Return 0
        End If
        words = words.Trim()
        words += " "c

        Dim number As ULong = 0
        Dim singles As String() = New String() {"zero", "one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine"}
        Dim teens As String() = New String() {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
            "sixteen", "seventeen", "eighteen", "nineteen"}
        Dim tens As String() = New String() {"", "", "twenty", "thirty", "forty", "fifty",
            "sixty", "seventy", "eighty", "ninty"}
        Dim powers As String() = New String() {"", "thousand", "million", "billion", "trillion", "quadrillion",
            "quintillion"}

        For i As Integer = powers.Length - 1 To 0 Step -1
            If Not String.IsNullOrEmpty(powers(i)) Then
                Dim index As Integer = words.IndexOf(powers(i))

                If index >= 0 AndAlso words(index + powers(i).Length) = " "c Then
                    Dim count As ULong = CWordsToNumbers(words.Substring(0, index))
                    number += count * CULng(System.Math.Pow(1000, i))
                    words = words.Remove(0, index)
                End If
            End If
        Next

        If True Then
            Dim index As Integer = words.IndexOf("hundred")

            If index >= 0 AndAlso words(index + "hundred".Length) = " "c Then
                Dim count As ULong = CWordsToNumbers(words.Substring(0, index))
                number += count * 100
                words = words.Remove(0, index)
            End If
        End If

        For i As Integer = tens.Length - 1 To 0 Step -1
            If Not String.IsNullOrEmpty(tens(i)) Then
                Dim index As Integer = words.IndexOf(tens(i))

                If index >= 0 AndAlso words(index + tens(i).Length) = " "c Then
                    number += CUInt(i * 10)
                    words = words.Remove(0, index)
                End If
            End If
        Next

        For i As Integer = teens.Length - 1 To 0 Step -1
            If Not String.IsNullOrEmpty(teens(i)) Then
                Dim index As Integer = words.IndexOf(teens(i))

                If index >= 0 AndAlso words(index + teens(i).Length) = " "c Then
                    number += CUInt(i + 10)
                    words = words.Remove(0, index)
                End If
            End If
        Next

        For i As Integer = singles.Length - 1 To 0 Step -1
            If Not String.IsNullOrEmpty(singles(i)) Then
                Dim index As Integer = words.IndexOf(singles(i) & " "c)

                If index >= 0 AndAlso words(index + singles(i).Length) = " "c Then
                    number += CUInt(i)
                    words = words.Remove(0, index)
                End If
            End If
        Next

        Return number
    End Function
#End Region





















End Class

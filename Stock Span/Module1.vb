Imports System
Imports System.IO
Imports System.Text

Module Module1
    Dim numOfStock, stockValues(), Result(), S(99999) As UInteger
    Dim path As String = "E:\งาน ป.โท\Algor\StockSpan\stockspan\Stock Span\data.in"
    Sub Main()

        Dim fileReader As StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(path)
        Dim stringReader As String
        stringReader = fileReader.ReadToEnd
        Dim words As String() = Split(stringReader, vbCrLf)
        Dim toInt As UInteger() = Array.ConvertAll(words, Function(str) UInt32.Parse(str))
        '---------------------------------------------------------------------------------------------------

        Console.WriteLine("---------- My Algor ------------------------------------")
        Result = processTest(toInt)
        Console.WriteLine()
        Console.WriteLine("---------- OnWeb Algor ------------------------------------")
        calculateSpan(toInt, 99999, S)

        Console.WriteLine("-----------------------------------------------------------")
        Console.WriteLine("-------------------- End Thank You ------------------------")
        Console.WriteLine("-----------------------------------------------------------")
        Console.ReadLine()
    End Sub

    Sub input()
        Console.Write("Input number of stock’s  : ")
        numOfStock = Console.ReadLine() - 1

        ReDim stockValues(numOfStock)
        ReDim Result(numOfStock)

        For i As UInteger = 0 To numOfStock
            Console.Write("Input Stock Value of day " + (i + 1).ToString() + " : ")
            stockValues(i) = Console.ReadLine()
        Next
    End Sub

    Sub process()
        For i As UInteger = 0 To numOfStock
            Result(i) = 1
            For j As Integer = i To 0 Step -1
                If stockValues(i) > stockValues(j) Then
                    Result(i) = Result(i) + 1
                End If
            Next
        Next
    End Sub

    Function processTest(source As UInteger()) As UInteger()
        Dim numOfStock As Integer = source.Length - 1
        Dim stockValues(numOfStock), Result(numOfStock) As UInteger
        stockValues = source
        Dim DateStart As Date = Now
        Console.WriteLine("Start at {0} ", DateStart.ToString("MM/dd/yyyy hh:mm:ss.fffffff tt"))
        For i As UInteger = 0 To numOfStock
            Result(i) = 1
            For j As Integer = i To 0 Step -1
                If i <> j Then
                    If stockValues(i) > stockValues(j) Then
                        Result(i) = Result(i) + 1
                    Else
                        Exit For
                    End If
                End If
            Next
            If i = 49999 Or i = 59999 Or i = 69999 Or i = 79999 Or i = 89999 Or i = 99999 Then
                Console.WriteLine("Run time at {0} is : {1} Milliseconds", (i + 1), (Now - DateStart).ToString("fffffff"))
            End If
        Next
        Console.WriteLine("End at {0} ", Now.ToString("MM/dd/yyyy hh:mm:ss.fffffff tt"))
        Return Result
    End Function

    Sub calculateSpan(price() As UInteger, n As UInteger, S() As UInteger)
        Dim j As Integer
        ' Span value of first day Is always 1
        S(0) = 1
        ' Calculate span value of remaining days by linearly checking
        ' previous days
        Dim DateStart As Date = Now
        Console.WriteLine("Start at {0} ", DateStart.ToString("MM/dd/yyyy hh:mm:ss.fffffff tt"))
        For i As UInteger = 0 To n Step 1
            S(i) = 1 ' Initialize span value

            ' Traverse left while the next element on left Is smaller
            ' than price(i)
            j = i - 1
            While (j >= 0) AndAlso (price(i) > price(j))
                S(i) = S(i) + 1
                j = j - 1
            End While
            If i = 49999 Or i = 59999 Or i = 69999 Or i = 79999 Or i = 89999 Or i = 99999 Then
                Console.WriteLine("Run time at {0} is : {1} Milliseconds", (i + 1), (Now - DateStart).ToString("fffffff"))
            End If
        Next
        Console.WriteLine("End at {0} ", Now.ToString("MM/dd/yyyy hh:mm:ss.fffffff tt"))
    End Sub
    Sub printResult(source As UInteger())
        Dim numOfStock As Integer = 20
        Console.WriteLine("-----------------------------------------------------------")
        For i As UInteger = 0 To numOfStock
            Console.WriteLine("Stock Span is : " + source(i).ToString())
        Next
    End Sub
End Module

Imports ClosedXML.Excel
Module ExcelModule

    Function getDatasFromExcel(bookPath As String, sheetName As String)
        Dim i As Integer, j As Integer
        Dim rowdata As New List(Of String)
        Dim datas As New List(Of Object)

        Using wb = New XLWorkbook(bookPath)
            Dim sh As IXLWorksheet = wb.Worksheet(sheetName)

            Dim lastrow As Integer = sh.LastRowUsed.RowNumber
            Dim lastcol As Integer = sh.LastColumnUsed.ColumnNumber
            Dim range = sh.RangeUsed


            For j = 1 To lastrow
                rowdata = New List(Of String)
                For i = 1 To lastcol
                    'Console.WriteLine(i)
                    Dim test As String = range.Cell(j, i).GetFormattedString()
                    'rowdata.Add(sh.Cell(j, i).Value)

                Next
                datas.Add(rowdata)
            Next

        End Using

        Return datas
    End Function





End Module

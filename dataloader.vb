Module dataloader

    Function getDataFromCSV(filePath As String)
        'System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)
        Dim parser As New FileIO.TextFieldParser(filePath,
                                                 System.Text.Encoding.GetEncoding("utf-8"))
        parser.TextFieldType = FileIO.FieldType.Delimited
        parser.SetDelimiters(",") ' 区切り文字はコンマ

        Dim datas As New List(Of String())
        While Not parser.EndOfData
            datas.Add(parser.ReadFields()) ' 1行読み込み

        End While


        Return datas
    End Function




End Module

Public Class Material

    Public recipe As Recipe
    Public ID As String
    Public amount As Long   '必要量/回
    Public amountPmin As Double ' 必要量/分

    Public Sub New(ID, amount, nGenPminOfParrentRecipe)
        Me.ID = ID
        Me.amount = amount
        Me.amountPmin = amount * nGenPminOfParrentRecipe

    End Sub
End Class

Public Class Material

    Public recipe As Recipe
    Public ID As String
    Public amount As Long   '必要量/回
    Public amountPmin As Double ' 必要量/分
    Public effi As Double

    Public Sub New(ID, amount, nGenPminOfParrentRecipe)
        Me.ID = ID
        Me.amount = amount
        Me.amountPmin = amount * nGenPminOfParrentRecipe
        Me.effi = 0


    End Sub

    Public Sub setRecipe(recipe As Recipe)
        Me.recipe = recipe
        Me.effi = Me.amountPmin / Me.recipe.amountPmin

    End Sub

End Class

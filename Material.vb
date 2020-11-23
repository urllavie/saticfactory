Public Class Material

    Public recipe As Recipe
    Public ID As String
    Public amount As Long   '必要量/回

    Public Sub New(ID, amount)
        Me.ID = ID
        Me.amount = amount

    End Sub
End Class

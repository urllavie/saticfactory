Public Class Recipe

    Public ID As String         'ID
    Public name As String       'アイテム名
    Public mathine As String    '機器名
    Public amount As Long       '生産量/回
    Public generateTime As Double '生産時間/回
    Public nMaterials As Long   '材料の種類数
    Public materials As New List(Of Material) '材料
    Public ngenPmin As Double   '生産回数/分
    Public amountPmin As Double '生産量/分


    Const colID = 0
    Const colName = 1
    Const colMathine = 2
    Const colAmount = 3
    Const colGenerateTime = 4
    Const colNMaterials = 6
    Private colMaterialsID = {7, 11, 15, 19}


    Public Sub New(data As Object)
        Dim i
        Me.ID = data(colID)
        Me.name = data(colName)
        Me.mathine = data(colMathine)
        Me.amount = data(colAmount)
        Me.generateTime = data(colGenerateTime)
        Me.nMaterials = data(colNMaterials)
        Me.ngenPmin = 60 / Me.generateTime
        Me.amountPmin = Me.ngenPmin * Me.amount

        For i = 0 To Me.nMaterials - 1
            Me.materials.Add(New Material(data(colMaterialsID(i)), data(colMaterialsID(i) + 2), ngenPmin))

        Next

    End Sub
End Class

Imports System

Public Module RecipeCreater
    Sub Main(ByVal Args() As String)


        Dim recipes As Dictionary(Of String, Recipe)
        recipes = getRecipes()



        If Args.Length = 0 Then
            Call showAllRecipes(recipes)
        ElseIf Args.Length = 1 Then
            Dim shownRecipeIDorName = Args(0)
            Call outputrecipes(shownRecipeIDorName, recipes)
        ElseIf Args.Length = 2 Then

            ouputSummedMaterial(Args(0), Args(1), recipes)
        Else
            Console.WriteLine("引数は０～１個です")

        End If

    End Sub

    Sub ouputSummedMaterial(RecipeID, MaterialID, recipes)

        Console.WriteLine(recipes(RecipeID).name & "に必要な材料:" & recipes(MaterialID).name)

        Dim summedAmount As Double = 0
        Dim summedMathine As Double = 0

        summedAmount = calcSummedAmount(recipes(RecipeID), recipes(MaterialID), summedAmount, 1)


        Console.WriteLine(summedAmount & "個 : " & summedAmount / recipes(MaterialID).amountPmin & "機")

    End Sub

    Function calcSummedAmount(recipe As Recipe, material As Recipe, summedAmount As Double, effi As Double)

        Dim m As Material

        For Each m In recipe.materials
            If m.ID = material.ID Then
                summedAmount = summedAmount + m.amountPmin * effi

            End If
            summedAmount = calcSummedAmount(m.recipe, material, summedAmount, m.amountPmin * effi / m.recipe.amountPmin)

        Next

        Return summedAmount

    End Function



    Sub showAllRecipes(recipes As Dictionary(Of String, Recipe))

        For Each recipe In recipes.Values

            Console.WriteLine(recipe.ID + " : " + recipe.name)

        Next



    End Sub

    Sub outputrecipes(shownRecipeIDorName As String, recipes As Dictionary(Of String, Recipe))

        Dim col As Long
        col = 0

        Call outputRecipe(recipes(shownRecipeIDorName), col, recipes(shownRecipeIDorName).ngenPmin, recipes(shownRecipeIDorName).amount, "", "")

    End Sub

    Sub outputRecipe(recipe As Recipe, col As Long, ngenPmin As Double,
                     amount As Long, str As String, strNext As String)

        Dim m



        Console.WriteLine(str & " " & recipe.name & " : " & recipe.amount * ngenPmin &
                          " 個: " & Math.Round(ngenPmin / recipe.ngenPmin, 2) & "機")
        Console.WriteLine(strNext)

        Dim cmat As Long
        cmat = 0
        For Each m In recipe.materials
            Dim strNe As String
            cmat = cmat + 1
            Dim ccol As Long
            ccol = col

            strNe = strNext


            If recipe.nMaterials - cmat + 1 = 1 Then
                strNe = strNe & "┗━━━"
                strNext = strNext & " 　　　"
            ElseIf recipe.nMaterials - cmat + 1 > 1 Then
                strNe = strNe & "┣━━━"
                strNext = strNext & "┃　　　"
            End If

            Call outputRecipe(m.recipe, col + 1, m.amount * ngenPmin / m.recipe.amount,
                              m.recipe.amount, strNe, strNext)

            strNext = Left(strNext, Len(strNext) - 4)
        Next

    End Sub


    Function getRecipes()

        Dim datas As Object
        Dim data As Object
        Dim recipes As New Dictionary(Of String, Recipe)


        Dim bookPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase & "\recipe.csv"

        datas = getDataFromCSV(bookPath)

        For Each data In datas
            If data(0) = "ID" Then
                Continue For
            End If
            Dim recipe As New Recipe(data)
            recipes.Add(recipe.ID, recipe)
        Next

        For Each recipe In recipes
            For Each material In recipe.Value.materials
                material.setRecipe(recipes(material.ID))


            Next

        Next


        Return recipes

    End Function


End Module

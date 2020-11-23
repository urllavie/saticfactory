Imports System

Module RecipeCreater
    Sub Main(ByVal Args() As String)


        Dim recipes As Dictionary(Of String, Recipe)
        recipes = getRecipes()

        Call showRecipes(recipes)


        'Call outputrecipes()




    End Sub

    Sub showRecipes(recipes As Dictionary(Of String, Recipe))

        For Each recipe In recipes.Values

            Console.WriteLine(recipe.ID + " : " + recipe.name)

        Next



    End Sub

    Sub outputrecipes()

        Dim recipes As Dictionary(Of String, Recipe)

        recipes = getRecipes()



        'Dim row As Long
        'Dim col As Long
        'row = 1
        'col = 1
        'For Each r In recipes
        '    Call outputRecipe(r, row, col, r.ngenPmin, r.amount)
        '    'ws2.Cells(row, 1) = "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------"
        '    row = row + 2
        'Next


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
                material.recipe = recipes(material.ID)

            Next

        Next


        Return recipes

    End Function


End Module

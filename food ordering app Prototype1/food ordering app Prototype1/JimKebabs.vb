Imports System.Data.OleDb
Public Class JimKebabs
    Dim Connection As New OleDbConnection
    Public Sub JimKebabs_Initialize()

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If

        Connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\CS\z.TERMINAL PROJECT\SnackShack.accdb;Persist Security Info=False;"

        If Connection.State = ConnectionState.Closed Then
            Connection.Open()
        End If

        Dim Adapter As New OleDbDataAdapter("SELECT * FROM Ingredients", Connection)
        Dim Dataset As New DataSet
        Adapter.Fill(Dataset, "Ingredients")
        Connection.Close()

        Dim Columns(9) As String
        Dim Results(9) As Integer
        Dim i As Integer

        For i = 0 To Dataset.Tables(0).Columns.Count - 1
            Columns(i) = Dataset.Tables(0).Columns(i).ColumnName
        Next

        For i = 0 To Dataset.Tables(0).Rows(0).ItemArray.Count - 1
            Results(i) = Dataset.Tables(0).Rows(0).ItemArray(i)
        Next

        Check_Ingredient_Availability(Columns, Results)
        'MessageBox.Show("nice")

    End Sub
    Private Sub picBack_Click(sender As Object, e As EventArgs) Handles picBack.Click

        Me.Hide()
        Form4.Show()

    End Sub
    Private Sub Check_Ingredient_Availability(Columns As String(), Results As Integer())
        '"Essentials"
        Dim GingerIndex As Integer = Array.IndexOf(Columns, "Ginger")
        Dim GingerAmount As Integer = Results(GingerIndex)

        Dim GarlicIndex As Integer = Array.IndexOf(Columns, "Garlic")
        Dim GarlicAmount As Integer = Results(GarlicIndex)

        Dim OnionIndex As Integer = Array.IndexOf(Columns, "Onion")
        Dim OnionAmount As Integer = Results(OnionIndex)

        Dim SaltIndex As Integer = Array.IndexOf(Columns, "Salt")
        Dim SaltAmount As Integer = Results(SaltIndex)

        Dim LemonIndex As Integer = Array.IndexOf(Columns, "Lemon")
        Dim LemonAmount As Integer = Results(LemonIndex)

        '"Replaceables"
        Dim ChickenIndex As Integer = Array.IndexOf(Columns, "Chicken")
        Dim ChickenAmount As Integer = Results(ChickenIndex)

        Dim BeefIndex As Integer = Array.IndexOf(Columns, "Beef")
        Dim BeefAmount As Integer = Results(BeefIndex)

        Dim TofuIndex As Integer = Array.IndexOf(Columns, "Tofu")
        Dim TofuAmount As Integer = Results(TofuIndex)

        If GingerAmount <= 0 Or GarlicAmount <= 0 Or OnionAmount <= 0 Or SaltAmount <= 0 Or LemonAmount <= 0 Then
            OutOfIngredients()
        End If

        If ChickenAmount <= 0 Then
            If BeefAmount > 0 Then
                lblingredient.Text += Columns(BeefIndex)
            ElseIf TofuAmount > 0 Then
                lblingredient.Text += Columns(TofuIndex)
            Else
                OutOfIngredients()
            End If
        Else
            lblingredient.Text += Columns(ChickenIndex)
        End If

    End Sub
    Private Sub OutOfIngredients()

        btnOrderKebab.Enabled = False 'Disables the button to process the order.
        lblingredient.Text = "Insufficient ingredients." 'Changes the labels text to "Insuffcient ingredients.".
        lblingredient.Enabled = False 'Disables the "ingredient" label to grey it out.

    End Sub
    Private Sub btnOrderKebab_Click(sender As Object, e As EventArgs) Handles btnOrderKebab.Click

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
        End If

        Connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\CS\z.TERMINAL PROJECT\SnackShack.accdb;Persist Security Info=False;"

        If Connection.State = ConnectionState.Closed Then
            Connection.Open()
        End If

        Dim IDArray As New OleDbDataAdapter($"SELECT ID FROM Cart", Connection)
        Dim Dataset As New DataSet
        Dim IDlen As Integer
        IDArray.Fill(Dataset, "Cart")
        Connection.Close()

        IDlen = Dataset.Tables(0).Rows.Count

        Dim meal As New Dish
        Dish.ID = IDlen
        Dish.Price = "10.99"
        Dish.DishName = "Malai Seekh Kebab"
        Dish.Username = Context.LoggedInUser

        If Connection.State = ConnectionState.Closed Then
            Connection.Open()
        End If

        Dim create As New OleDbCommand($"INSERT INTO Cart([Price],[DishName],[Username])VALUES('{Dish.Price}','{Dish.DishName}','{Dish.Username}')", Connection)
        create.ExecuteNonQuery()

        Context.Cart = {meal}

        Me.Hide()
        Cart.Show()
        Cart.CartInitialize()

    End Sub
End Class
Public Class Form4


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Me.Visible = False

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Me.Hide() 'Hides the home page form.
        JimKebabs.Show() 'Opens "JimsKebabs" restaurant's form.
        JimKebabs.JimKebabs_Initialize() 'Runs the menu update subroutine upon clicking the page before it loads.

    End Sub

    Private Sub picPizza_Click(sender As Object, e As EventArgs) Handles picPizza.Click

        Me.Hide() 'Closes the home page form.
        Pizza.Show() 'Opens up the pizza category

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub
    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click

        Me.Hide()
        Active_orders.Show()

    End Sub
End Class
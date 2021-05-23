Public Class Cart
    Public Sub CartInitialize()

        lblCartDish.Text = "- " + Context.Cart.FirstOrDefault().DishName
        lblSubtotal.Text = $"£{Context.Cart.FirstOrDefault().Price}"
        lblCartETA.Text = "45 Minutes"
        lblOrderID.Text = Context.Cart.FirstOrDefault().ID

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Hide()
        CheckoutPage.Show()
        CheckoutPage.CheckoutInitialize()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Me.Hide()
        Form4.Show()

    End Sub
End Class
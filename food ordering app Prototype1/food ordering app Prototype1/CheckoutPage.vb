Public Class CheckoutPage
    Public Sub CheckoutInitialize()

        txtCheckoutDish.Text = "- " + Context.Cart.FirstOrDefault().DishName

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtFirstName.Text = Nothing Or txtLastName.Text = Nothing Or txtPostCode.Text = Nothing Or txtStreetAddress.Text = Nothing Or txtCardNumber.Text = Nothing Or
            cboExpiryMonth.SelectedItem = Nothing Or cboExpiryYear.SelectedItem = Nothing Or txtCardNumber.Text.Length <> 16 Or txtCVV.Text.Length <> 3 Then
            MessageBox.Show("One or more fields have been left incomplete or blank.", "Error")
        Else

            Me.Hide()
            MessageBox.Show("Hi " + Context.Cart.FirstOrDefault.Username + " thanks for ordering with SnackShack! Your order will be with you shortly!")
            Form4.Show()

        End If

        Active_orders.OrdersInitialize()

    End Sub
End Class
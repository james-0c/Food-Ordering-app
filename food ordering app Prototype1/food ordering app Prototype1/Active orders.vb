Public Class Active_orders

    Public Sub OrdersInitialize()

        lblID.Text = "- " + Context.Cart.FirstOrDefault.ID.ToString
        lblSubtotal.Text = "- £" + Context.Cart.FirstOrDefault.Price
        lblETA.Text = "- 45 Minutes"

    End Sub


    Private Sub Active_orders_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
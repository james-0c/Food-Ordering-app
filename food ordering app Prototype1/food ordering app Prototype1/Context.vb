Public Class Context 'Used to tell us who was logged in when placing orders. - allows data to be passed around forms

    Public Shared Cart As Dish()
    Public Shared LoggedInUser As String

End Class
Public Class Dish

    Public Shared ID As Integer
    Public Shared Price As String
    Public Shared DishName As String
    Public Shared Username As String

End Class

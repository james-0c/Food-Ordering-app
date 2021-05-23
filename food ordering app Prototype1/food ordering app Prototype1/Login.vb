Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Form2

    Dim Connection As New OleDbConnection

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text = Nothing Or txtPassword.Text = Nothing Then 'Presence check to ensure that Username and Password fields have data entered into them.
            MessageBox.Show("Please ensure empty fields are filled.", "Error") 'Outputs a messagebox informing the user that they have left data entry fields blank.
        End If

        Connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = F:\CS\z.TERMINAL PROJECT\UserDetailsTable.accdb" 'Sets the string in which gives the directory used to open the linked database.
        Connection.Open() 'Opens the connection to the linked database. 
        Dim Command As OleDbCommand = New OleDbCommand("SELECT * FROM UserDetails WHERE [Username]='" & txtUsername.Text & "'AND [Password]='" & txtPassword.Text & "'", Connection)
        Dim Adapter As OleDbDataReader = Command.ExecuteReader
        'These 2 above lines select the values from the table in which match the input and compares if they match.

        If Adapter.Read() = True Then 'If the value check is true then the following executes.
            Me.Hide() 'Hides the Login form.
            Form4.Show() 'Opens the Home page form.
            MsgBox("Successful login", MsgBoxStyle.Information) 'If they do match then the box informs the user that login was successful.
        Else
            MsgBox("Login failure", MsgBoxStyle.Critical) 'If the details couldn't be found within the table there is a login failure.
        End If

        Context.LoggedInUser = txtUsername.Text 'Tells the orders table which user is logged in.

    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Me.Hide() 'Hides the Login form.
        Form1.Show() 'Opens the singup page form.

    End Sub
End Class
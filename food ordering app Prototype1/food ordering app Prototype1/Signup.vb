Imports System.Data.OleDb
Public Class Form1
    Dim Connection As New OleDbConnection
    Private Sub Join_Click(sender As Object, e As EventArgs) Handles btnJoin.Click 'Opens the subroutine the button carries out when clicked.

        Connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\CS\z.TERMINAL PROJECT\UserDetailsTable.accdb;Persist Security Info=False;" 'Sets the string used to open a database.

        If EmailAddress.Text = Nothing Or Username.Text = Nothing Or Password.Text = Nothing Or Password.Text.Length < 8 Then 'If statement -presence check and password length check- where it is checking for whether any of the text fields are empty, this statement covers majority of the class.
            MessageBox.Show("Please ensure empty fields are filled, and password length is greater than 7.", "Error") 'Displays a message box telling the user that there are empty fields and loops back to the presence/length check.
        Else

            If Connection.State = ConnectionState.Closed Then 'this is checking the connection state to the data source, if it is closed then the connection is opened.
                Connection.Open() 'Opens the connection to the data source.
            End If

            Using Command As New OleDbCommand("SELECT COUNT(*) FROM UserDetails WHERE [Username] = @USERNAME OR [Password] = @PASSWORD OR [EmailAddress] = @EMAILADDRESS", Connection) 'This is responsible for ensuring that a username that already exists isn't registered VVV
                Command.Parameters.AddWithValue("@USERNAME", OleDbType.VarChar).Value = Username.Text.Trim
                Command.Parameters.AddWithValue("@PASSWORD", OleDbType.VarChar).Value = Password.Text.Trim
                Command.Parameters.AddWithValue("@EMAILADDRESS", OleDbType.VarChar).Value = EmailAddress.Text.Trim 'these 3 lines are responsible for setting the inputs into the textboxes equal to their given labels within the select statement.

                If Connection.State = ConnectionState.Closed Then 'checking the state of the class' connection to the data source.
                    Connection.Open() 'opens the connection to the database for the class
                End If

                Dim count = Convert.ToInt32(Command.ExecuteScalar()) 'Declares variable count and converts it into a 32-bit signed integer, then executes the query and returns the the first column of the first row.
                If count > 0 Then 'if there is a return count returns as > 0 and therefore the username is taken and the below executes.
                    MessageBox.Show("Username has already been taken") 'Tells the user that their entered username is already in use.
                    Exit Sub 'Closes the subroutine
                End If 'Closes the If statement.
            End Using

            Using create As New OleDbCommand("INSERT INTO UserDetails([Username],[Password],[EmailAddress])VALUES(@USERNAME,@PASSWORD,@EMAILADDRESS)", Connection)
                create.Parameters.AddWithValue("@USERNAME", OleDbType.VarChar).Value = Username.Text.Trim
                create.Parameters.AddWithValue("@PASSWORD", OleDbType.VarChar).Value = Password.Text.Trim
                create.Parameters.AddWithValue("@EMAILADDRESS", OleDbType.VarChar).Value = EmailAddress.Text.Trim 'these 4 lines are responsible for the inserting the entered account details into my "AccountDetails" table.

                If create.ExecuteNonQuery Then 'This is responsible for ensuring that if the SQL statement has executed and the user details have been inserted then the below lines run.
                    MessageBox.Show("Account successfully registered") 'Displays a MessageBox to inform the user their account is registered.
                    Username.Clear() 'clears the username text entry field.
                    Password.Clear() 'clears the password text entry field.
                    EmailAddress.Clear() 'clears the emailaddress text entry field.
                End If
            End Using

            Me.Hide() 'Hides the account signup form.
            Form4.Show() 'opens the home page form.

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Me.Hide() 'Hides the signup form.
        Form2.Show() 'Opens the Login page form.

    End Sub
End Class

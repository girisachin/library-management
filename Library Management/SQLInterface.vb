Imports MySql.Data.MySqlClient
Public Class SQLInterface

	Public Shared con As MySqlConnection = New MySqlConnection("server=" + My.Settings.server + "; user id=" + My.Settings.username + "; password=" + My.Settings.password + "; database=" + My.Settings.database)
	'A SET OF COMMAND IN MYSQL
	Public Shared cmd As New MySqlCommand
	'SET A CLASS THAT SERVES AS THE BRIDGE BETWEEN A DATASET AND Library_Management FOR SAVING AND RETRIEVING DATA.
	Public Shared da As New MySqlDataAdapter
	'SET A CLASS THAT CONSISTS SPECIFIC TABLE IN THE Library_Management
	Public Shared dt As New DataTable
	Public Shared result As Integer

	Public Shared Function Login() As Boolean
		' Function will return status of query ( because we may need it in our parent form)
		If GLogin.LoggedIn = True Then
			Return True
		End If
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "SELECT * FROM users WHERE BINARY Username ='" & GLogin.Username & "'"
			End With
			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
			da.SelectCommand = cmd
			dt = New DataTable
			da.Fill(dt)
			'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
			Dim maxrow As Integer = dt.Rows.Count
			'CHECKING IF THE DATA IS EXIST IN THE ROW OF THE TABLE

			If maxrow = 1 Then
				'GLogin.LoggedIn = True
				GLogin.Fullname = dt.Rows(0).Item(0).ToString()
				GLogin.PasswordHash = dt.Rows(0).Item(2).ToString()
				GLogin.Salt = dt.Rows(0).Item(3).ToString()
				GLogin.AccType = dt.Rows(0).Item(4).ToString()
				GLogin.BooksIssued = Integer.Parse(dt.Rows(0).Item(6).ToString())
				GLogin.Due = Integer.Parse(dt.Rows(0).Item(7).ToString())
			Else
				GLogin.LogOut()
				con.Close()
				Return False
			End If
		Catch ex As Exception
			Msg.Err("SQL Error1: " + ex.StackTrace)
			GLogin.LogOut()
		End Try
		con.Close()
		Dim temp As String = CheckOldPassword(Encrypt_Sha512(GLogin.UnhashedPassword))
		If temp = GLogin.PasswordHash Then
			GLogin.LoggedIn = True
		Else
			GLogin.LogOut()
		End If
		Return GLogin.LoggedIn
	End Function


	Public Shared Function Register() As Boolean
		' Function will return status of query ( because we may need it in our parent form)
		Dim maxrow As Integer = 1
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "SELECT * FROM users WHERE BINARY Username ='" & GLogin.Username & "'"
			End With
			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
			da.SelectCommand = cmd
			dt = New DataTable
			da.Fill(dt)
			'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
			maxrow = dt.Rows.Count
		Catch ex As Exception
			Msg.Err("SQL Error2: " + ex.Message)
		End Try
		con.Close()

		If maxrow <> 0 Then
			Alert("Error", "Username already Taken")
			Return False
		End If

		Try
			'OPENING THE CONNECTION
			con.Open()
			'HOLDS THE DATA TO BE EXECUTED


			cmd.Connection = con
			cmd.CommandText = "INSERT INTO users(Name,Username,Pass,Salt,AccType)" & "VALUES ('" & GLogin.Fullname & "','" & GLogin.Username & "','" & GLogin.PasswordHash & "','" & GLogin.Salt & "','" & GLogin.AccType & "')"

			'EXECUTE THE DATA
			result = cmd.ExecuteNonQuery
			'CHECKING IF THE DATA HAS BEEN EXECUTED OR NOT
			If result = 1 Then
				Alert("Success", "You have been registered.")
			Else
				Alert("Error", "Failed to register the user.")
			End If
			con.Close()
		Catch ex As Exception
			Msg.Err("SQL Error3: " + ex.Message)
		End Try
		If result > 0 Then
			Return True
		Else
			Return False
		End If
	End Function

	Public Shared Function EditProfileData(ByVal NewUsername As String, ByVal NewFullname As String, ByVal NewAccType As String) As Boolean
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE users SET Username ='" + NewUsername + "', Name ='" + NewFullname + "', AccType ='" + NewAccType + "' WHERE username='" + GLogin.Username + "'"
			End With

			result = cmd.ExecuteNonQuery
			If result = 1 Then
				con.Close()
				GLogin.Username = NewUsername
				GLogin.Fullname = NewFullname
				GLogin.AccType = NewAccType
				Return True
			Else
				Return False
			End If

			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

		Catch ex As MySqlException
			Msg.Err("SQL Error4: " + ex.Message)
			Return False
		End Try
	End Function

	Public Shared Function ChangePassword() As Boolean
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE user SET Password='" & GLogin.PasswordHash & "', Salt='" & GLogin.Salt & "' where Username='" + GLogin.Username + "'"
			End With

			result = cmd.ExecuteNonQuery
			If result = 1 Then
				con.Close()
				Return True
			Else
				Return False
			End If

			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

		Catch ex As MySqlException
			Msg.Err("SQL Error5: " + ex.Message)
			Return False
		End Try
	End Function
	Public Shared Sub PopulateBrowseBooksTable()
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "SELECT * FROM books"
			End With
			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
			da.SelectCommand = cmd
			da.Fill(dt)
			Dim bs As BindingSource = New BindingSource()
			bs.DataSource = dt
			AAAAMainForm.BrowseBooksDataGrid.DataSource = bs
		Catch ex As Exception
			GetServer.ShowDialog()
			Environment.Exit(0)
		End Try
		con.Close()
	End Sub
End Class
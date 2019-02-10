Imports MySql.Data.MySqlClient
Public Class SQLInterface

	Public Shared con As MySqlConnection = New MySqlConnection("server=" + My.Settings.server + "; user id=" + My.Settings.username + "; password=" + My.Settings.password + "; database=" + My.Settings.database)
	'A SET OF COMMAND IN MYSQL
	Public Shared cmd As New MySqlCommand
	'SET A CLASS THAT SERVES AS THE BRIDGE BETWEEN A DATASET AND Library_Management FOR SAVING AND RETRIEVING DATA.
	Public Shared da As New MySqlDataAdapter

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
			Dim dt As DataTable = New DataTable
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
		Dim result As Integer = -1

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
		Dim result As Integer = -1

		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE users SET Username ='" + NewUsername + "', Name ='" + NewFullname + "', AccType ='" + NewAccType + "' WHERE Username='" + GLogin.Username + "'"
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
		Dim result As Integer = -1

		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE users SET Pass='" & GLogin.PasswordHash & "', Salt='" & GLogin.Salt & "' WHERE BiNARY Username='" + GLogin.Username + "'"
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
			Dim dt As DataTable = New DataTable
			da.Fill(dt)
			Dim bs As BindingSource = New BindingSource()
			bs.DataSource = dt
			AAAAMainForm.BrowseBooksDataGrid.DataSource = bs
		Catch ex As Exception
			Msg.Err("SQL Error6: " + ex.Message)
		End Try
		con.Close()
	End Sub
	Public Shared Function DoesUsernameExists(ByVal Str As String) As Boolean
		Dim maxrow As Integer = -1
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "SELECT * FROM users WHERE BINARY Username ='" & Str & "'"
			End With
			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
			da.SelectCommand = cmd
			Dim dt As DataTable = New DataTable
			da.Fill(dt)
			'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
			maxrow = dt.Rows.Count
		Catch ex As Exception

			Msg.Err("SQL Error6: " + ex.Message)

		End Try
		con.Close()

		If maxrow <> 0 And maxrow <> -1 Then
			Return True
		End If
		Return False
	End Function
	Public Shared Function DoesBookIDExists(ByVal Str As String) As Boolean
		Dim maxrow As Integer = -1
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "SELECT * FROM books WHERE ID ='" & Str & "'"
			End With
			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
			da.SelectCommand = cmd
			Dim dt As DataTable = New DataTable
			da.Fill(dt)
			'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
			maxrow = dt.Rows.Count
		Catch ex As Exception

			Msg.Err("SQL Error6: " + ex.Message)

		End Try
		con.Close()

		If maxrow <> 0 And maxrow <> -1 Then
			Return True
		End If
		Return False
	End Function
	Public Shared Function AdminDeleteAccount(ByVal Username As String) As Boolean
		Dim maxrow As Integer = -100
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "DELETE FROM users WHERE Username = '" + Username + "'"
			End With
			'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
			maxrow = cmd.ExecuteNonQuery
			If maxrow = 1 Then
				con.Close()
				Return True
			Else
				Return False
			End If
		Catch ex As Exception
			Msg.Err("SQL Error6: " + ex.Message)
		End Try
		con.Close()
		Return False
	End Function
	Public Shared Function AdminRegister() As Boolean
		' Function will return status of query ( because we may need it in our parent form)
		Dim result As Integer = -1


		Try
			'OPENING THE CONNECTION
			con.Open()
			'HOLDS THE DATA TO BE EXECUTED


			cmd.Connection = con
			cmd.CommandText = "INSERT INTO users(Name,Username,Pass,Salt,AccType)" & "VALUES ('" & GAdmin.Fullname & "','" & GAdmin.Username & "','" & GAdmin.PasswordHash & "','" & GAdmin.Salt & "','" & GAdmin.AccType & "')"

			'EXECUTE THE DATA
			result = cmd.ExecuteNonQuery
			'CHECKING IF THE DATA HAS BEEN EXECUTED OR NOT
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
	Public Shared Function AdminAddBookInfo(ByVal Name As String, ByVal Author As String, ByVal ISBN As String, ByVal Genre As String, ByVal copies As String) As Boolean
		' Function will return status of query ( because we may need it in our parent form)
		Dim result As Integer = -1

		Try
			'OPENING THE CONNECTION
			con.Open()
			'HOLDS THE DATA TO BE EXECUTED
			cmd.Connection = con
			cmd.CommandText = "INSERT INTO books(Name,Author,ISBN,Genre,Copies,`Left`) " & "VALUES ('" & Name & "','" & Author & "','" & ISBN & "','" & Genre & "'," & copies & "," + copies + ")"
			'Console.WriteLine(cmd.CommandText)
			'EXECUTE THE DATA
			result = cmd.ExecuteNonQuery
			'CHECKING IF THE DATA HAS BEEN EXECUTED OR NOT
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
	Public Shared Function AdminDeleteBook(ByVal Bookid As String) As Boolean
		Dim maxrow As Integer = -100
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "DELETE FROM books WHERE ID = '" + Bookid + "'"
			End With
			'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
			maxrow = cmd.ExecuteNonQuery
			If maxrow = 1 Then
				con.Close()
				Return True
			Else
				Return False
			End If
		Catch ex As Exception
			Msg.Err("SQL Error6: " + ex.Message)
		End Try
		con.Close()
		Return False

    End Function


    Public Shared Sub PopulateSearchBooksTable(ByVal bookid As String, ByVal isbn As String, ByVal bookname As String, ByVal genre As String, ByVal author As String)

        Try
            con.Open()

            With cmd
                .Connection = con
                .CommandText = "SELECT * FROM books where Id like '%" & bookid & "%' and isbn like '%" & isbn & "%' and name like '%" & bookname & "%' and genre like '%" & genre & "%' and author like '%" & author & "%' "
            End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            Dim bs As BindingSource = New BindingSource()
            bs.DataSource = dt
            BookList.SearchBookDataGrid.DataSource = bs
        Catch ex As Exception
			Msg.Err("SQL Error6: " + ex.Message)
		End Try
        con.Close()
    End Sub
	Public Shared Function GetSysDateTime() As Boolean
		Dim res As Integer = -1
		Try
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "SELECT 1 FROM DUAL"
			da.SelectCommand = cmd
			Dim dt As DataTable = New DataTable
			da.Fill(dt)
			res = dt.Rows.Count
			con.Close()
		Catch ex As MySqlException
			Return False
		End Try
		If res = 1 Then
			Return True
		End If
		Return False
	End Function
	   Public Shared Sub loadissuedbooks(ByRef books(,) As String)
        Dim bookinfo() As String
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = "SELECT book1,book2,book3,book4,book5,book6,book7,book8,book9,book10 FROM users WHERE BINARY Username ='" & GLogin.Username & "'"
            End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
            Dim maxrow As Integer = dt.Rows.Count
            'CHECKING IF THE DATA IS EXIST IN THE ROW OF THE TABLE
            Dim i As Integer = 1
            If maxrow = 1 Then
                For j As Integer = 0 To 10
                    If String.IsNullOrEmpty(dt.Rows(0).Item(j).ToString()) = False Or dt.Rows(0).Item(j).ToString <> Nothing Then

                        bookinfo = dt.Rows(0).Item(j).ToString().Split("|")
                        books(i, 0) = bookinfo(0)
                        books(i, 1) = bookinfo(1)
                        i = i + 1

                    End If
                Next
            End If
        Catch ex As Exception
            Msg.Err("SQL Error1: " + ex.StackTrace)
            GLogin.LogOut()
        End Try
        con.Close()
    End Sub


    'ASSUMING GLOGIN BOOKS ARRAY IS ALREADY UPDATED.
    Public Shared Sub updateissuebooktable(ByVal bookid As Integer)
        Dim result As Integer = -1

        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = "UPDATE users SET Book1 ='" + GLogin.books(1, 0) + "'|'" & GLogin.books(1, 1) & "',  Book2 ='" + GLogin.books(2, 0) + "'|'" & GLogin.books(2, 1) & "', Book3 ='" + GLogin.books(3, 0) + "'|'" & GLogin.books(3, 1) & "',Book4 ='" + GLogin.books(4, 0) + "'|'" & GLogin.books(4, 1) & "',Book5 ='" + GLogin.books(5, 0) + "'|'" & GLogin.books(5, 1) & "',Book6 ='" + GLogin.books(6, 0) + "'|'" & GLogin.books(6, 1) & "',Book7 ='" + GLogin.books(7, 0) + "'|'" & GLogin.books(7, 1) & "',Book8 ='" + GLogin.books(8, 0) + "'|'" & GLogin.books(8, 1) & "',Book9 ='" + GLogin.books(9, 0) + "'|'" & GLogin.books(9, 1) & "',Book10 ='" + GLogin.books(10, 0) + "'|'" & GLogin.books(10, 1) & "' WHERE Username='" + GLogin.Username + "'"
            End With

            result = cmd.ExecuteNonQuery
            If result = 1 Then

            Else
            End If
            con.Close()
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

        Catch ex As MySqlException
            Msg.Err("SQL Error4: " + ex.Message)
        End Try

    End Sub

End Class
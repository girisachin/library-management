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
				.CommandText = "SELECT * FROM users WHERE BINARY Username ='" & GLogin.Username & "' and confirmed = 'Yes'"
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
                GLogin.confirmed = dt.Rows(0).Item(8).ToString()
                Dim i As Integer = 0
				Dim bookinfo() As String
			For j As Integer = 9 To 18
					If String.IsNullOrEmpty(dt.Rows(0).Item(j).ToString().Trim) = False Or dt.Rows(0).Item(j).ToString.Trim <> Nothing Or dt.Rows(0).Item(j).ToString.Trim <> "" Then
						i = i + 1
						bookinfo = dt.Rows(0).Item(j).ToString().Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)
						GLogin.books(i, 0) = bookinfo(0)
						GLogin.books(i, 1) = bookinfo(1)
					Else
						i = i + 1
						GLogin.books(i, 0) = ""
						GLogin.books(i, 1) = ""
					End If
				Next
		Else
				GLogin.LogOut()
				con.Close()
				Return False
			End If
		Catch ex As Exception
		Msg.Err("SQL Error1: " + ex.Message)
		GLogin.LogOut()
		Return False
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
				.CommandText = "UPDATE users SET Username ='" + NewUsername + "', Name ='" + NewFullname + "', AccType ='" + NewAccType + "' WHERE BINARY Username='" + GLogin.Username + "'"
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
			Dim bs As BindingSource = New BindingSource With {
				.DataSource = dt
			}
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
				.CommandText = "SELECT * FROM users WHERE BINARY Username ='" & Str & "' and confirmed='Yes'"
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
    Public Shared Function returnissuedbooksofuser(ByVal username As String) As Integer
        Dim issuednum As Integer
        Dim maxrow As Integer = -1
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = "select NoOfBooks FROM users WHERE BINARY Username = '" + username + "'"
            End With
            'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
            maxrow = cmd.ExecuteNonQuery

            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            'DECLARING AN INTEGER TO SET THE MAXROWS OF THE TABLE
            maxrow = dt.Rows.Count
            'CHECKING IF THE DATA IS EXIST IN THE ROW OF THE TABLE

            If maxrow = 1 Then
                issuednum = dt.Rows(0).Item(0)

                con.Close()
                Return issuednum
            Else
                Return 1
            End If
        Catch ex As Exception
            Msg.Err("SQL Error6: " + ex.Message)
        End Try
        con.Close()

        Return 1
    End Function
    Public Shared Function AdminDeleteAccount(ByVal Username As String) As Boolean
		Dim maxrow As Integer = -100
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "DELETE FROM users WHERE BINARY Username = '" + Username + "'"
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
			cmd.CommandText = "INSERT INTO users(Name,Username,Pass,Salt,AccType,Confirmed)" & "VALUES ('" & GAdmin.Fullname & "','" & GAdmin.Username & "','" & GAdmin.PasswordHash & "','" & GAdmin.Salt & "','" & GAdmin.AccType & "','Yes')"

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
				.CommandText = "SELECT * FROM books where Id like '%" + bookid + "%' and isbn like '%" & isbn & "%' and name like '%" + bookname + "%' and genre like '%" & genre & "%' and author like '%" & author & "%' "
			End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
			da.Fill(dt)
			con.Close()

			If dt.Rows.Count = 0 Then
				Alert("Warning", "No Books for given search criteria")
				Exit Sub
			End If
			Dim bs As BindingSource = New BindingSource With {
				.DataSource = dt
			}
			BookList.SearchBookDataGrid.DataSource = bs
			BookList.Show()
		Catch ex As Exception
			Msg.Err("SQL Error6: " + ex.Message)
		End Try
        con.Close()
    End Sub
	Public Shared Function GetSysDateTime() As Boolean
		Dim res As Integer = -1
		Dim dt As DataTable = New DataTable
		Try
			con.Open()
			cmd.Connection = con
            cmd.CommandText = "SELECT date_format(sysdate(), '%e/%c/%Y') FROM DUAL"
			da.SelectCommand = cmd
			da.Fill(dt)
			res = dt.Rows.Count
			con.Close()
		Catch ex As MySqlException
			Return False
		End Try
		If res = 1 Then
			servertime = dt.Rows(0).Item(0)
            clienttime = Now.Day.ToString + "/" + Now.Month.ToString + "/" + Now.Year.ToString 'String.Format("{0:dd/MM/yyyy}", Now().Date.)
			Return True
		End If
		Return False
	End Function



	'ASSUMING GLOGIN BOOKS ARRAY IS ALREADY UPDATED.
	Public Shared Function UpdateIssueBookTable(ByVal id As String) As Boolean
		Dim result As Integer = -1
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE users Set NoOfBooks='" & GLogin.BooksIssued & "', Book1 ='" + GLogin.books(1, 0) + " " + GLogin.books(1, 1) + "', Book2 ='" + GLogin.books(2, 0) + " " & GLogin.books(2, 1) & "', Book3 ='" + GLogin.books(3, 0) + " " & GLogin.books(3, 1) & "',Book4 ='" + GLogin.books(4, 0) + " " & GLogin.books(4, 1) & "',Book5 ='" + GLogin.books(5, 0) + " " & GLogin.books(5, 1) & "',Book6 = '" + GLogin.books(6, 0) + " " & GLogin.books(6, 1) & "',Book7 ='" + GLogin.books(7, 0) + " " & GLogin.books(7, 1) & "',Book8 ='" + GLogin.books(8, 0) + " " & GLogin.books(8, 1) & "',Book9 ='" + GLogin.books(9, 0) + " " & GLogin.books(9, 1) & "',Book10 ='" + GLogin.books(10, 0) + " " & GLogin.books(10, 1) & "' WHERE BINARY Username='" + GLogin.Username + "'"
			End With

			result = cmd.ExecuteNonQuery

			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

			con.Close()
			If result <> 1 Then
				Return False
			End If
			con.Open()
			result = -1
			With cmd
				.Connection = con
				.CommandText = "UPDATE books Set `Left` = `Left` -1 where ID = '" + id + "'"
			End With

			result = cmd.ExecuteNonQuery

			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

			con.Close()
		Catch ex As MySqlException
			Msg.Err("SQL Error4: " + ex.Message)
			Return False
		End Try
		If result = 1 Then
			Return True
		Else
			Return False
		End If
	End Function
	Public Shared Function AreCopiesLeft(ByVal id As String) As Boolean
		Dim res As Integer = -1
		Dim dt As DataTable = New DataTable
		Try
			con.Open()
			cmd.Connection = con
			cmd.CommandText = "SELECT `Left` FROM books where ID = '" + id + "'"
			da.SelectCommand = cmd
			da.Fill(dt)
			con.Close()
		Catch ex As MySqlException
			Return False
		End Try
		res = Convert.ToUInt64(dt.Rows(0).Item(0).ToString)

		If res > 0 Then
			Return True
		End If
		Return False
	End Function
	Public Shared Function IsCorrectBookID(ByVal id As String) As Boolean
		Dim res As Integer = -1
		Dim dt As DataTable = New DataTable
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT `Left` FROM books where ID = '" + id + "'"
            da.SelectCommand = cmd
            da.Fill(dt)
            con.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
            Return False
		End Try
		res = dt.Rows.Count

		If res > 0 Then
			Return True
		End If
		Return False
	End Function
	Public Shared Function ReturnBook(ByVal id As String) As Boolean
		Dim result As Integer = -1
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE users SET Due = " + GLogin.Due.ToString + ",NoOfBooks='" & GLogin.BooksIssued & "', Book1 ='" + GLogin.books(1, 0) + " " + GLogin.books(1, 1) + "', Book2 ='" + GLogin.books(2, 0) + " " & GLogin.books(2, 1) & "', Book3 ='" + GLogin.books(3, 0) + " " & GLogin.books(3, 1) & "',Book4 ='" + GLogin.books(4, 0) + " " & GLogin.books(4, 1) & "',Book5 ='" + GLogin.books(5, 0) + " " & GLogin.books(5, 1) & "',Book6 = '" + GLogin.books(6, 0) + " " & GLogin.books(6, 1) & "',Book7 ='" + GLogin.books(7, 0) + " " & GLogin.books(7, 1) & "',Book8 ='" + GLogin.books(8, 0) + " " & GLogin.books(8, 1) & "',Book9 ='" + GLogin.books(9, 0) + " " & GLogin.books(9, 1) & "',Book10 ='" + GLogin.books(10, 0) + " " & GLogin.books(10, 1) & "' WHERE BINARY Username='" + GLogin.Username + "'"
				'.CommandText = "UPDATE users SET Due = " + GLogin.Due + ", NoOfBooks=" + GLogin.BooksIssued + ", Book1 ='" + GLogin.books(1, 0) + " " + GLogin.books(1, 1) + "', Book2 ='" + GLogin.books(2, 0) + " " + GLogin.books(2, 1) + "', Book3 ='" + GLogin.books(3, 0) + " " + GLogin.books(3, 1) + "', Book4 ='" + GLogin.books(4, 0) + " " + GLogin.books(4, 1) + "', Book5 ='" + GLogin.books(5, 0) + " " + GLogin.books(5, 1) + "', Book6 ='" + GLogin.books(6, 0) + " " + GLogin.books(6, 1) + "', Book7 ='" + GLogin.books(7, 0) + " " + GLogin.books(7, 1) + "', Book8 ='" + GLogin.books(8, 0) + " " + GLogin.books(8, 1) + "', Book9 ='" + GLogin.books(9, 0) + " " + GLogin.books(9, 1) + "', Book10='" + GLogin.books(10, 0) + " " + GLogin.books(10, 1) + "' WHERE Username='" + GLogin.Username + "'"
				Console.WriteLine(cmd.CommandText)
			End With
			result = cmd.ExecuteNonQuery
			con.Close()
			result = -1
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE books SET `Left`=`Left`+1 where ID = '" + id + "'"
			End With
			result = cmd.ExecuteNonQuery
			con.Close()
		Catch ex As MySqlException
			Msg.Err("SQL Error4: " + ex.Message)
			Return False
		End Try
		If result = 1 Then
			Return True
		Else
			Return False
		End If
	End Function
	Public Shared Sub PopulateIssuedBooks()
        If GLogin.BooksIssued = 0 Then
            IssuedBooks.Close()
            Exit Sub
        End If
        Try
            con.Open()
            Dim str As String = "SELECT ID, name, Author, ISBN, Genre FROM books where Id in ("
            Dim first As Boolean = True
            For i As Integer = 1 To 10
                If GLogin.books(i, 0).Trim <> "" Then
                    If first = True Then
                        first = False
                        str = str + GLogin.books(i, 0)
                    Else
                        str = str + "," + GLogin.books(i, 0)
                    End If
                End If
            Next
            str = str + ")"
            With cmd
                .Connection = con
                .CommandText = str
            End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            Dim dt2 As DataTable = New DataTable
            Dim dc1, dc2, dc3, dc4, dc5, dc6 As New DataColumn
            dc1.DataType = System.Type.GetType("System.String")
            dc1.Caption = "ID"
            dc1.ColumnName = "ID"
            dc2.DataType = System.Type.GetType("System.String")
            dc2.Caption = "Name"
            dc2.ColumnName = "Name"
            dc3.DataType = System.Type.GetType("System.String")
            dc3.Caption = "Author"
            dc3.ColumnName = "Author"
            dc4.DataType = System.Type.GetType("System.String")
            dc4.Caption = "ISBN"
            dc4.ColumnName = "ISBN"
            dc5.DataType = System.Type.GetType("System.String")
            dc5.Caption = "Genre"
            dc5.ColumnName = "Genre"
            dc6.DataType = System.Type.GetType("System.String")
            dc6.Caption = "DueDate"
            dc6.ColumnName = "DueDate"
            da.Fill(dt)
            dt2.Columns.AddRange(New DataColumn() {dc1, dc2, dc3, dc4, dc5, dc6})
            Dim dr As DataRow
            For i As Integer = 0 To dt.Rows.Count - 1
                dr = dt2.NewRow
                dr("ID") = dt.Rows(i).Item(0).ToString
                dr("Name") = dt.Rows(i).Item(1).ToString
                dr("Author") = dt.Rows(i).Item(2).ToString
                dr("ISBN") = dt.Rows(i).Item(3).ToString
                dr("Genre") = dt.Rows(i).Item(4).ToString
                For j As Integer = 1 To 10
                    If IsNothing(GLogin.books(j, 0)) = False AndAlso GLogin.books(j, 0).ToString.Trim = dt.Rows(i).Item(0).ToString Then
                        dr("DueDate") = GLogin.books(j, 1).ToString.Trim
                        Exit For
                    End If
                Next
                dt2.Rows.Add(dr)
            Next
            Dim bs As BindingSource = New BindingSource With {
                .DataSource = dt2
            }
            IssuedBooks.IssuedBookDataGrid.DataSource = bs
        Catch ex As Exception
            Msg.Err("SQL Error6: " + ex.Message)
        End Try
        con.Close()
    End Sub
    Public Shared Function AdminEditAccount(ByVal NewUsername As String, ByVal NewFullname As String, ByVal NewPassword As String, ByVal OldUsername As String, ByVal acctype As String) As Boolean
        Dim str As String = "UPDATE users SET Username ='" + NewUsername + "' "
        If NewFullname <> "" Then
            str = str + ", Name = '" + NewFullname + "' "
        End If
		If NewPassword <> "" Then
			str = str + ", Pass= '" + NewPassword + "', Salt = '" + GAdmin.Salt + "' "
		End If
		If acctype.Trim <> "" Then
			str = str + ", AccType= '" + acctype + "' "
		End If
		str = str + "where Username = '" + OldUsername + "'"
        Dim result As Integer = -1
        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = str
            End With
            result = cmd.ExecuteNonQuery
            con.Close()
        Catch ex As MySqlException
            Msg.Err("SQL Error4: " + ex.Message)
            Return False
        End Try
        If result = 1 Then
            Return True
        Else
            Return False
        End If

    End Function
	Public Shared Function AdminEditBook(ByVal id As String, ByVal isbn As String, ByVal name As String, ByVal author As String, ByVal genre As String, ByVal copies As String, ByVal left As String) As Boolean
		Dim str As String = "UPDATE books SET ID = '" + id + "' "
		If isbn <> "" Then
			str = str + ", ISBN = '" + isbn + "' "
		End If
		If name <> "" Then
			str = str + ", Name= '" + name + "' "
		End If
		If author <> "" Then
			str = str + ", Author= '" + author + "' "
		End If
		If genre <> "" Then
			str = str + ", Genre= '" + genre + "' "
		End If
		If genre <> "" Then
			str = str + ", Genre= '" + genre + "' "
		End If
		If copies <> "" Then
			str = str + ", Copies= '" + copies + "' "
			str = str + ", `Left`= '" + left + "' "
		End If
		str = str + " where ID = '" + id.ToString + "'"
		Dim result As Integer = -1
		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = str
			End With
			result = cmd.ExecuteNonQuery
			con.Close()
		Catch ex As MySqlException
			Msg.Err("SQL Error4: " + ex.Message)
			Return False
		End Try
		If result = 1 Then
			Return True
		Else
			Return False
		End If
	End Function
	Public Shared Function BooksCopiesMinusLeft(ByVal id As String) As Integer
        Dim Res As Integer = 0
        Try
            con.Open()
            With cmd
                .Connection = con
				.CommandText = "SELECT Copies, `Left` FROM books where ID ='" + id + "'"
			End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            con.Close()
            Res = Integer.Parse(dt.Rows(0).Item(0)) - Integer.Parse(dt.Rows(0).Item(1))
        Catch ex As Exception
            Msg.Err("SQL Error6: " + ex.Message)
            Return 0
        End Try
        Return Res
    End Function

    Public Shared Sub PopulateApprovalDataGrid()
        Try
            con.Open()
            With cmd
                .Connection = con
				.CommandText = "SELECT Username,Name,AccType as 'Promote To' FROM users where confirmed = 'No'"
			End With
            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management
            da.SelectCommand = cmd
            Dim dt As DataTable = New DataTable
            da.Fill(dt)
            Dim bs As BindingSource = New BindingSource With {
                .DataSource = dt
            }
            AAAAMainForm.AdminApprovalDataGrid.DataSource = bs
        Catch ex As Exception
            Msg.Err("SQL Error6: " + ex.Message)
        End Try
        con.Close()
    End Sub

    Public Shared Sub approveuser(ByVal username As String)
        Dim result As Integer = -1

        Try
            con.Open()
            With cmd
                .Connection = con
				.CommandText = "UPDATE users SET confirmed = 'Yes' where BINARY Username = '" & username & "'"
			End With

            result = cmd.ExecuteNonQuery
            Alert("Success", "User is approved !")

            If result = 1 Then
            Else
            End If
            con.Close()


            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

        Catch ex As MySqlException
            Msg.Err("SQL Error4: " + ex.Message)

        End Try
    End Sub

    Public Shared Sub disapproveuser(ByVal username As String)
        Dim result As Integer = -1

        Try
            con.Open()
            With cmd
                .Connection = con
                .CommandText = "DELETE from users where username = '" & username & "'"
            End With

            result = cmd.ExecuteNonQuery
            Alert("Success", "User Deleted!")
            If result = 1 Then
            Else
            End If
            con.Close()


            'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

        Catch ex As MySqlException
            Msg.Err("SQL Error4: " + ex.Message)

        End Try
    End Sub
	Public Shared Function ClearDue(ByVal username As String) As Boolean
		Dim result As Integer = -1

		Try
			con.Open()
			With cmd
				.Connection = con
				.CommandText = "UPDATE users set Due = 0 where username = '" & username & "'"
			End With

			result = cmd.ExecuteNonQuery
			con.Close()


			'FILLING THE DATA IN A SPICIFIC TABLE OF THE Library_Management

		Catch ex As MySqlException
			Msg.Err("SQL Error4: " + ex.Message)
			Return False
		End Try
		If result = 1 Then
			Return True
		Else
			Return False
		End If
	End Function

End Class

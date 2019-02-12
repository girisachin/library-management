Public Class ShowBookInfo
	' Shows informatin about a book
	Public Sub ShowBook(ByVal id As String)
		' Sets text-completions for dropdown
		SQLInterface.GetBookInfo(id)
		If GLogin.LoggedIn = False Then
			Action.Items.Add("Login and Issue")
		Else
			Dim found As Boolean = False
			For i As Integer = 1 To 10
				If GLogin.books(i, 0) = id Then
					Action.Items.Add("ReIssue")
					Action.Items.Add("Return")
					found = True
					Exit For
				End If
			Next
			If found = False Then
				Action.Items.Add("Issue")
			End If
		End If
		Action.SelectedIndex = 0
		Me.Show()
	End Sub

	Private Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
		' Handles all cases for issue, login, reissue and return depending on text of dropdown
		If Action.Text = "Issue" Then
			IssueBookByID(BookID.Text)
		ElseIf Action.Text = "Return" Then
			ReturnBookByID(BookID.Text)
		ElseIf Action.Text = "ReIssue" Then
			For i As Integer = 1 To 10
				If GLogin.books(i, 0) = BookID.Text Then
					GLogin.books(i, 1) = String.Format("{0:dd/MM/yyyy}", Now().AddDays(45))
					'MessageBox.Show("Book Renewed , Due date = " + GLogin.books(i, 1), "Renewed!")
					Alert("Success", "Book Renewed , Due date = " + GLogin.books(i, 1))
					'GLogin.BooksIssued = GLogin.BooksIssued + 1
					If SQLInterface.UpdateIssueBookTable(GLogin.books(i, 0)) = False Then
						Alert("Error", "Could not Renew book")
					Else
						Alert("Success", "Book Renewed Successfully")
					End If
				End If
			Next
		ElseIf Action.Text = "Login and Issue" Then
			AAAAMainForm.TabControlMain.SelectedTab = AAAAMainForm.LoginSignupTab
		End If
		SQLInterface.PopulateIssuedBooks()
		SQLInterface.PopulateBrowseBooksTable()
		Me.Close()
	End Sub
End Class

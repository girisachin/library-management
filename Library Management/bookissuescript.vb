Module bookissuescript

	Sub IssueBookByID(ByVal bookid As String)
		If (GLogin.BooksIssued < 7 AndAlso GLogin.AccType = "Student") Or (GLogin.BooksIssued < 10) Then
			For i As Integer = 1 To 10
				If GLogin.books(i, 0) = bookid Then
					Alert("Warning", "Already Issued")
					Exit Sub
				End If
			Next
			If SQLInterface.AreCopiesLeft(bookid) = False Then
				Alert("Error", "Book Not Available for Issue")
				Exit Sub
			End If

			For i As Integer = 1 To 10
				If GLogin.books(i, 0) = "" Then
					GLogin.books(i, 0) = bookid
					GLogin.books(i, 1) = String.Format("{0:yyyy/MM/dd}", Now().AddDays(45))
					MessageBox.Show(GLogin.books(i, 1))
					GLogin.BooksIssued = GLogin.BooksIssued + 1
					If SQLInterface.UpdateIssueBookTable() = False Then
						Alert("Error", "Could not issue book")
						Exit Sub
					Else
						Alert("Success", "Book Issued Successfully")
						Exit Sub
					End If
					Exit Sub
				End If
			Next
		End If

		Exit Sub
	End Sub



End Module

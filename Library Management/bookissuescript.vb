Module bookissuescript

	Sub IssueBookByID(ByVal bookid As String)
		If (GLogin.BooksIssued < 7 AndAlso GLogin.AccType = "Student") Or (GLogin.BooksIssued < 10) Then
			For i As Integer = 1 To 10
				If GLogin.books(i, 0) = bookid Then
					Alert("Warning", "Already Issued")
					Exit Sub
				End If
			Next
			If SQLInterface.IsCorrectBookID(bookid) = False Then
				Alert("Error", "Book ID Incorrect")
				Exit Sub
			End If
			If SQLInterface.AreCopiesLeft(bookid) = False Then
				Alert("Error", "Book Not Available for Issue")
				Exit Sub
			End If

			For i As Integer = 1 To 10
				If GLogin.books(i, 0) = "" Then
					GLogin.books(i, 0) = bookid
					GLogin.books(i, 1) = String.Format("{0:dd/MM/yyyy}", Now().AddDays(45))
					MessageBox.Show(GLogin.books(i, 1))
					GLogin.BooksIssued = GLogin.BooksIssued + 1
					If SQLInterface.UpdateIssueBookTable(GLogin.books(i, 0)) = False Then
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

    Function CalculateDue() As Integer
        Dim due As Integer = 0
        Dim datediffval As Integer

        For i As Integer = 1 To 10
            If GLogin.books(i, 0).Trim <> "" Then
                datediffval = DateDiff("d", GLogin.books(i, 1), DateAndTime.Now())
                If datediffval > 45 Then
                    due = due + (datediffval - 45) * 1
                    GLogin.due_array(i) = (datediffval - 45) * 1
                End If

            Else

                GLogin.due_array(i) = 0

            End If
        Next

        GLogin.Due = due

        Return due
    End Function


End Module

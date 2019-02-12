Module bookissuescript

    Sub IssueBookByID(ByVal bookid As String)   'Issued the book, we search the book by its bookid.
        If GLogin.LoggedIn = False Then
            AAAAMainForm.TabControlMain.SelectedTab = AAAAMainForm.LoginSignupTab
            Alert("Warning", "You need to login first")
            Exit Sub
        End If
        If GLogin.confirmed = "No" Then
            Alert("Error", "Your account is not Confirmed yet. Contact Admin.")
            Exit Sub
        End If
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
                    'MessageBox.Show("Book Issued , Due date = " + GLogin.books(i, 1), "Issued!")
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

    Sub ReturnBookByID(ByVal bookid As String)      'returns the book by its book id.

        If GLogin.BooksIssued = 0 Then
            Alert("Error", "No books Issued")
            Exit Sub
        End If
        If ValidateInteger(bookid) = False Then
            Alert("Warning", "Use only integers in book ID")
            Exit Sub
        End If
        Dim BookFound As Boolean = False
        'Dim i As Integer
        'Dim diff As Long
        Dim bookdue As Integer = 0
        For i = 1 To 10
            If GLogin.books(i, 0) = bookid Then
                bookdue = GLogin.due_array(i)
                GLogin.books(i, 0) = ""
                GLogin.books(i, 1) = ""
                BookFound = True
                Exit For
            End If
        Next
        'If diff > 4 Then
        '	GLogin.Due += Convert.ToInt32(diff.ToString)
        '	SummaryDueTextBox.Text = GLogin.Due
        'End If
        Dim result As Boolean = False
        If BookFound = True AndAlso SQLInterface.DoesBookIDExists(bookid) = True Then
            GLogin.BooksIssued -= 1
            result = SQLInterface.ReturnBook(bookid)
            updateDueIssueText()
        End If

        'Dim result As Boolean = SQLInterface.ReturnBook(ReturnBookInfoTextBox.Text)
        If result = False Then ' some due added by late submission of this book
            Exit Sub
        End If
        If result = True Then

            SQLInterface.PopulateIssuedBooks()
            If bookdue = 0 Then
                Alert("Success", "Book was Returned Successfully")
            Else
                Alert("Warning", "Book Returned Late. Due =" + bookdue.ToString)
            End If
        End If

    End Sub

    Function CalculateDue() As Integer
        Dim due As Integer = 0
        Dim datediffval As Integer

        For i As Integer = 1 To 10
            If GLogin.books(i, 0).Trim <> "" Then
				'datediffval = DateDiff("d", GLogin.books(i, 1), String.Format("{0:dd/MM/yyyy}", Now()))
				datediffval = 0
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

    Sub updateDueIssueText()

        CalculateDue()
        AAAAMainForm.SummaryDueTextBox.Text = GLogin.Due.ToString
        AAAAMainForm.SummaryBooksIssuedTextBox.Text = GLogin.BooksIssued.ToString

    End Sub




End Module

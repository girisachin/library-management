Public Class IssuedBooks
	Private Sub IssuedBooks_Load(sender As Object, e As EventArgs) Handles Me.Load

        SQLInterface.PopulateIssuedBooks()
    End Sub
    Private BookCurrentRow As Integer = -1

    Private Sub BookList_Load(sender As Object, e As EventArgs) Handles Me.Load
        IssuedBookDataGrid.ClearSelection()
    End Sub

    Private Sub MyClose1_Click(sender As Object, e As EventArgs) Handles MyClose1.Click
        Me.Close()
    End Sub
    Private Sub CopyBookNameToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookNameToolStrip.Click
        Dim s As String = IssuedBookDataGrid.Rows(BookCurrentRow).Cells(1).Value.ToString
        Clipboard.SetText(s)
    End Sub
    Private Sub CopyISBNNumberToolStrip_Click(sender As Object, e As EventArgs) Handles CopyISBNNumberToolStrip.Click
        Dim s As String = IssuedBookDataGrid.Rows(BookCurrentRow).Cells(3).Value.ToString
        Clipboard.SetText(s)
    End Sub
    Private Sub CopyBookIDToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookIDToolStrip.Click
        Dim s As String = IssuedBookDataGrid.Rows(BookCurrentRow).Cells(0).Value.ToString
        Clipboard.SetText(s)
    End Sub
    Private Sub IssueSelectedBookToolStrip_Click(sender As Object, e As EventArgs) Handles IssueSelectedBookToolStrip.Click
        Dim bookid As String = IssuedBookDataGrid.Rows(BookCurrentRow).Cells(0).Value.ToString
        'If SQLInterface.DoesBookIDExists(bookid) = True Then
        '    GLogin.BooksIssued = GLogin.BooksIssued - 1
        '    SQLInterface.ReturnBook(bookid)
        '    updateDueIssueText()
        'End If
        ReturnBookByID(bookid)

    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles IssuedBookDataGrid.CellMouseEnter
        BookCurrentRow = e.RowIndex
        If e.RowIndex >= 0 Then
            IssuedBookDataGrid.ClearSelection()
            IssuedBookDataGrid.Rows(e.RowIndex).Selected = True
        Else
            IssuedBookDataGrid.ClearSelection()
        End If
    End Sub

    Private Sub RenewSelectedBookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenewSelectedBookToolStripMenuItem.Click
        Dim bookid As String = IssuedBookDataGrid.Rows(BookCurrentRow).Cells(0).Value.ToString

        For i As Integer = 1 To 10
            If GLogin.books(i, 0) = bookid Then
                GLogin.books(i, 1) = String.Format("{0:dd/MM/yyyy}", Now().AddDays(45))
                'MessageBox.Show("Book Renewed , Due date = " + GLogin.books(i, 1), "Renewed!")
                Alert("Success", "Book Renewed , Due date = " + GLogin.books(i, 1))
				'GLogin.BooksIssued = GLogin.BooksIssued + 1
				If SQLInterface.UpdateIssueBookTable(GLogin.books(i, 0)) = False Then
                    Alert("Error", "Could not Renewed book")
                    Exit Sub
                Else

                    Alert("Success", "Book Renewed Successfully")
                    Exit Sub
                End If
                Exit Sub
            End If
        Next
        SQLInterface.PopulateIssuedBooks()

    End Sub
    Private Sub IssuedBookDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles IssuedBookDataGrid.CellContentClick

    End Sub

    Private Sub IssuedBookDataGrid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles IssuedBookDataGrid.CellDoubleClick
		ShowBookInfo.ShowBook(IssuedBookDataGrid.Rows(e.RowIndex).Cells(0).Value.ToString)
	End Sub
End Class

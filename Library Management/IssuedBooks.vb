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
End Class

Public Class BookList
	Private SearchBookCurrentRow As Integer = -1

	Private Sub BookList_Load(sender As Object, e As EventArgs) Handles Me.Load
		SearchBookDataGrid.ClearSelection()
	End Sub

	Private Sub MyClose1_Click(sender As Object, e As EventArgs) Handles MyClose1.Click
		Me.Close()
	End Sub
	Private Sub CopyBookNameToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookNameToolStrip.Click
		Dim s As String = SearchBookDataGrid.Rows(SearchBookCurrentRow).Cells(1).Value.ToString
		Clipboard.SetText(s)
	End Sub
	Private Sub CopyISBNNumberToolStrip_Click(sender As Object, e As EventArgs) Handles CopyISBNNumberToolStrip.Click
		Dim s As String = SearchBookDataGrid.Rows(SearchBookCurrentRow).Cells(3).Value.ToString
		Clipboard.SetText(s)
	End Sub
	Private Sub CopyBookIDToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookIDToolStrip.Click
		Dim s As String = SearchBookDataGrid.Rows(SearchBookCurrentRow).Cells(0).Value.ToString
		Clipboard.SetText(s)
	End Sub
	Private Sub IssueSelectedBookToolStrip_Click(sender As Object, e As EventArgs) Handles IssueSelectedBookToolStrip.Click
        Dim bookid As String = SearchBookDataGrid.Rows(SearchBookCurrentRow).Cells(0).Value.ToString
        IssueBookByID(bookid)

        SQLInterface.PopulateSearchBooksTable(AAAAMainForm.SearchBookIDTextBox.Text, AAAAMainForm.SearchBookISBNTextBox.Text, AAAAMainForm.SearchBookNameTextBox.Text, AAAAMainForm.SearchBookGenreTextBox.Text, AAAAMainForm.SearchBookAuthorTextBox.Text)

    End Sub
	Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles SearchBookDataGrid.CellMouseEnter
		SearchBookCurrentRow = e.RowIndex
		If e.RowIndex >= 0 Then
			SearchBookDataGrid.ClearSelection()
			SearchBookDataGrid.Rows(e.RowIndex).Selected = True
		Else
			SearchBookDataGrid.ClearSelection()
		End If
	End Sub
End Class
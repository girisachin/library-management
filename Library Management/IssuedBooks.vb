Public Class IssuedBooks
	Private Sub IssuedBooks_Load(sender As Object, e As EventArgs) Handles Me.Load
		SQLInterface.PopulateIssuedBooks()
		Dim DueDate As New System.Windows.Forms.DataGridViewTextBoxColumn()
		DueDate.HeaderText = "Due Date"
		IssuedBookDataGrid.Columns.Insert(4, DueDate)
		'IssuedBookDataGrid.Column
		For i As Integer = 1 To 10
			For j As Integer = 0 To IssuedBookDataGrid.Rows.Count - 1
				If GLogin.books(i, 0).ToString.Trim <> "" AndAlso IssuedBookDataGrid.Rows(j).Cells(0).Value.ToString = GLogin.books(i, 0).ToString Then
					IssuedBookDataGrid.Rows(j).Cells(5).Value = GLogin.books(i, 1).ToString
					Exit For
				End If
			Next
		Next
	End Sub
End Class
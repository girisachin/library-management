Public Class ShowBookInfo
	Public Sub ShowBook(ByVal id As String)
		If GLogin.LoggedIn = False Then
			Action.Items.Add("Login and Issue")
			Action.SelectedIndex = 0
			Exit Sub
		End If
		Dim found As Boolean = False
		For i As Integer = 1 To 10
			If GLogin.books(i, 0) = id Then
				Action.Items.Add("ReIssue")
				Action.Items.Add("Return")
				Action.SelectedIndex = 0
				found = True
				Exit For
			End If
		Next
		If found = False Then
		Action.Items.Add("Issue")
			Action.SelectedIndex = 0
		End If






		Me.Show()
	End Sub
End Class

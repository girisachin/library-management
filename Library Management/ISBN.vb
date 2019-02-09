Module ISBN
	' ISBN Research Link - https://en.wikipedia.org/wiki/International_Standard_Book_Number
	Public Function ValidateISBN(ByVal ISBN As String) As Boolean
		If Len(ISBN) = 10 Then
			Dim ISBN10Sum As Integer
			ISBN10Sum = 10 * Convert.ToInt32(ISBN.Substring(0, 1))
			ISBN10Sum = ISBN10Sum + 9 * Convert.ToInt32(ISBN.Substring(1, 1))
			ISBN10Sum = ISBN10Sum + 8 * Convert.ToInt32(ISBN.Substring(2, 1))
			ISBN10Sum = ISBN10Sum + 7 * Convert.ToInt32(ISBN.Substring(3, 1))
			ISBN10Sum = ISBN10Sum + 6 * Convert.ToInt32(ISBN.Substring(4, 1))
			ISBN10Sum = ISBN10Sum + 5 * Convert.ToInt32(ISBN.Substring(5, 1))
			ISBN10Sum = ISBN10Sum + 4 * Convert.ToInt32(ISBN.Substring(6, 1))
			ISBN10Sum = ISBN10Sum + 3 * Convert.ToInt32(ISBN.Substring(7, 1))
			ISBN10Sum = ISBN10Sum + 2 * Convert.ToInt32(ISBN.Substring(8, 1))
			ISBN10Sum = ISBN10Sum + Convert.ToInt32(ISBN.Substring(9, 1))
			ISBN10Sum = (ISBN10Sum Mod 11)
			If ISBN10Sum = 0 Then
				Return True
			End If
		End If
		If Len(ISBN) = 13 Then
			Dim ISBN13Sum As Integer
			ISBN13Sum = Convert.ToInt32(ISBN.Substring(0, 1))
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(1, 1)) * 3
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(2, 1))
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(3, 1)) * 3
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(4, 1))
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(5, 1)) * 3
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(6, 1))
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(7, 1)) * 3
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(8, 1))
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(9, 1)) * 3
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(10, 1))
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(11, 1)) * 3
			ISBN13Sum = ISBN13Sum + Convert.ToInt32(ISBN.Substring(12, 1))
			ISBN13Sum = (ISBN13Sum Mod 10)
			If ISBN13Sum = 0 Then
				Return True
			End If
		End If
		Return False
	End Function
End Module

Module Validation
	Public servertime As String
	Public clienttime As String

	Public Function ValidateUsername(ByVal Str As String) As Boolean
		For Each C As Char In Str
			If AscW(C) >= AscW("a") AndAlso AscW("z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("A") AndAlso AscW("Z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("0") AndAlso AscW("9") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) = AscW("_") Then
				Continue For
			Else
				Return False
			End If
		Next
		Return True
	End Function
	Public Function ValidateFullname(ByVal Str As String) As Boolean
		For Each C As Char In Str
			If AscW(C) >= AscW("a") AndAlso AscW("z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("A") AndAlso AscW("Z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) = AscW(" ") Then
				Continue For
			Else
				Return False
			End If
		Next
		Return True
	End Function
	Public Function ValidateBookname(ByVal Str As String) As Boolean
		For Each C As Char In Str
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			ElseIf AscW("a") <= AscW(C) AndAlso AscW(C) <= AscW("z") Then
				Continue For
			ElseIf AscW("A") <= AscW(C) AndAlso AscW(C) <= AscW("Z") Then
				Continue For
			ElseIf AscW("_") = AscW(C) Or AscW(C) = AscW(" ") Or AscW(":") = AscW(C) Or AscW(C) = AscW("'") Or AscW(C) = AscW(",") Or AscW(C) = AscW("(") Or AscW(C) = AscW(")") Or AscW(C) = AscW("+") Then
				Continue For
			Else
				Return False
			End If
		Next
		Return True
	End Function
	Public Function ValidateBookAuthor(ByVal Str As String) As Boolean
		Return ValidateBookname(Str)
	End Function
	Public Function ValidateBookGenre(ByVal Str As String) As Boolean
		Return ValidateBookname(Str)
	End Function
	Public Function ValidateInteger(ByVal Str As String) As Boolean
		For Each C As Char In Str
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			Else
				Return False
			End If
		Next
		Return True
	End Function
End Module

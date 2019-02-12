Public Class GLogin

	Public Shared Username As String = ""
	Public Shared Fullname As String = ""
	Public Shared PasswordHash As String = ""
	Public Shared AccType As String = ""
	Public Shared UnhashedPassword As String = ""
	Public Shared Due As Integer = 0
	Public Shared BooksIssued As Integer = 0
	Public Shared lib_id As Integer = 0
	Public Shared LoggedIn As Boolean = False
	Public Shared Salt As String = ""
	Public Shared TempSalt As String = ""
    Public Shared TempHash As String = ""
	Public Shared confirmed As String = ""

	Public Shared due_array(10) As Integer
    Public Shared books(10, 10) As String    '1ST INDEX CONTAINS BOOKID AND 2ND INDEX CONTAINS DATE.



    'Public Shared ParentForm As String = ""
    Public Shared Sub LogOut()
		Username = ""
		Fullname = ""
		UnhashedPassword = ""
		PasswordHash = ""
		AccType = ""
		Salt = ""
		Due = 0
		BooksIssued = 0
        lib_id = 0
        confirmed = ""
        LoggedIn = False
		'ParentForm = ""
	End Sub
End Class

Public Class GAdmin

	Public Shared Username As String = ""
	Public Shared Fullname As String = ""
	Public Shared PasswordHash As String = ""
	Public Shared AccType As String = ""
	Public Shared UnhashedPassword As String = ""
	Public Shared Salt As String = ""
	'Public Shared ParentForm As String = ""
	Public Shared Sub LogOut()
		Username = ""
		Fullname = ""
		UnhashedPassword = ""
		PasswordHash = ""
		AccType = ""
		Salt = ""
		'ParentForm = ""
	End Sub
End Class



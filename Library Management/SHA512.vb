'Imports System.Security.Cryptography.SHA512

' This class can never see password (except when initial encrypt_sha512 call )
Module SHA512
	Public Function Encrypt_Sha512(ByVal StrToHash As String) As String
		' encrypts a string to sha512
		Dim SHA512Obj As System.Security.Cryptography.SHA512 = New System.Security.Cryptography.SHA512Managed()

		Dim BytesToHash() As Byte = System.Text.Encoding.UTF8.GetBytes(StrToHash)
		BytesToHash = SHA512Obj.ComputeHash(BytesToHash)

		Dim EncodedString As String = ""

		For Each ByteWord As Byte In BytesToHash
			EncodedString += ByteWord.ToString("x2")
		Next
		Return EncodedString
	End Function

	Public Function EncryptNewPassword(ByVal PasswordHash As String) As String
		' generates salt in glogin and returns final hash
		Dim Charset As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-"
		Dim Chars() As Char = Charset.ToCharArray
		Dim bytes() As Byte
		ReDim bytes(10)
		Dim RNGObj As Security.Cryptography.RNGCryptoServiceProvider = New Security.Cryptography.RNGCryptoServiceProvider()
		RNGObj.GetBytes(bytes)
		GLogin.Salt = ""
		For Each b As Byte In bytes
			GLogin.Salt = GLogin.Salt + Chars.ElementAt(b Mod 64).ToString
		Next
		Return Encrypt_Sha512(GLogin.Salt + PasswordHash + "d5eba9b008f69bd56e")
	End Function
	Public Function AdminEncryptNewPassword(ByVal PasswordHash As String) As String
		' returns final hash and salt
		Dim Charset As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-"
		Dim Chars() As Char = Charset.ToCharArray
		Dim bytes() As Byte
		ReDim bytes(10)
		Dim RNGObj As Security.Cryptography.RNGCryptoServiceProvider = New Security.Cryptography.RNGCryptoServiceProvider()
		RNGObj.GetBytes(bytes)
		GAdmin.Salt = ""
		For Each b As Byte In bytes
			GAdmin.Salt = GAdmin.Salt + Chars.ElementAt(b Mod 64).ToString
		Next
		Return Encrypt_Sha512(GAdmin.Salt + PasswordHash + "d5eba9b008f69bd56e")
	End Function

	Public Function CheckOldPassword(ByVal PasswordHash As String) As String
		' makes hash using old salt
		If GLogin.LoggedIn = True Then
			Alert("Error", "Already logged in")
			Return ""
		End If
		If GLogin.Salt = "" Then
			Alert("Error", "Earlier Salt not Found")
			GLogin.LogOut()
			Return Nothing
		End If
		Return Encrypt_Sha512(GLogin.Salt + PasswordHash + "d5eba9b008f69bd56e")
	End Function

End Module

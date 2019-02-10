Imports MySql.Data.MySqlClient
Public Class AAAAMainForm
	Private HiddenPages As List(Of TabPage) = New List(Of TabPage)
	Public Sub AlertFunction(ByVal status As String, ByVal str As String)
		If status = "Success" Then
			AlertBox1.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Success, str, 4000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Success, str, 4000)
		ElseIf status = "Warning" Then
			AlertBox1.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Info, str, 4000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Info, str, 4000)
		Else
			AlertBox1.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Error, str, 4000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Error, str, 4000)
		End If
	End Sub
	Private Sub EnablePage(ByVal Page As TabPage)
		TabControlMain.TabPages.Add(Page)
		HiddenPages.Remove(Page)
	End Sub
	Private Sub DisablePage(ByVal Page As TabPage)
		HiddenPages.Add(Page)
		TabControlMain.TabPages.Remove(Page)
	End Sub
	Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
		For Each Page As TabPage In HiddenPages
			Page.Dispose()
		Next
		MyBase.OnFormClosed(e)
	End Sub
	Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles AAAAExitButton.Click
		Environment.Exit(0)
	End Sub
	Private Sub LoginPasswordPicture_Click(sender As Object, e As EventArgs) Handles AAALoginPasswordPicture.Click
		If LoginPasswordTextBox.UseSystemPasswordChar = True Then
			LoginPasswordTextBox.UseSystemPasswordChar = False
			AAALoginPasswordPicture.Image = My.Resources.ResourceManager.GetObject("show")
		Else
			LoginPasswordTextBox.UseSystemPasswordChar = True
			AAALoginPasswordPicture.Image = My.Resources.ResourceManager.GetObject("hide")
		End If
	End Sub
	Private Sub SignupPasswordPicture_Click(sender As Object, e As EventArgs) Handles AAASignupPasswordPicture.Click
		If SignupPasswordTextBox.UseSystemPasswordChar = True Then
			SignupPasswordTextBox.UseSystemPasswordChar = False
			AAASignupPasswordPicture.Image = My.Resources.ResourceManager.GetObject("show")
		Else
			SignupPasswordTextBox.UseSystemPasswordChar = True
			AAASignupPasswordPicture.Image = My.Resources.ResourceManager.GetObject("hide")
		End If
	End Sub
	Private Sub SignupPasswordConfirm_Click(sender As Object, e As EventArgs) Handles AAASignupConfirmPasswordPicture.Click
		If SignupConfirmPasswordTextBox.UseSystemPasswordChar = True Then
			SignupConfirmPasswordTextBox.UseSystemPasswordChar = False
			AAASignupConfirmPasswordPicture.Image = My.Resources.ResourceManager.GetObject("show")
		Else
			SignupConfirmPasswordTextBox.UseSystemPasswordChar = True
			AAASignupConfirmPasswordPicture.Image = My.Resources.ResourceManager.GetObject("hide")
		End If
	End Sub
	Private Sub LoginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginButton.Click
		If ValidateUsername(LoginUsernameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics( a-z or A-Z ) or underscores( _ )")
			GLogin.LogOut()
			Exit Sub
		End If
		GLogin.LogOut()
		GLogin.Username = LoginUsernameTextBox.Text
		GLogin.UnhashedPassword = LoginPasswordTextBox.Text 'CheckOldPassword(PasswordTextBox.Text)
		If SQLInterface.Login() = True Then
			StatusBar.Text = "Logged in as " + GLogin.AccType + " - " + GLogin.Fullname
			Alert("Success", "Logged In !")
			DisablePage(LoginSignupTab)
			EnablePage(IssueBookTab)
			EnablePage(SummaryTab)
			AAAALogoutButton.Visible = True
			If GLogin.AccType = "Admin" Then
				EnablePage(AdminOptionsTab)
			End If
			SummaryDueTextBox.Text = GLogin.Due.ToString
			SummaryBooksIssuedTextBox.Text = GLogin.BooksIssued.ToString
			SummaryUsernameTextBox.Text = GLogin.Username
			SummaryFullnameTextBox.Text = GLogin.Fullname
			If GLogin.AccType = "Admin" Then
				SummaryProfileDropDownBox.SelectedIndex = 2
			ElseIf GLogin.AccType = "Teacher" Then
				SummaryProfileDropDownBox.SelectedIndex = 1
			Else
				SummaryProfileDropDownBox.SelectedIndex = 0
			End If
		Else
			Alert("Error", "Username and Password do not match")
			GLogin.LogOut()
		End If
	End Sub
	Private Sub SignupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignupButton.Click
		If SignupPasswordTextBox.Text <> SignupConfirmPasswordTextBox.Text Then
			Alert("Error", "Passwords do not match! Enter passwords again carefully!")
			SignupPasswordTextBox.Text = ""
			SignupConfirmPasswordTextBox.Text = ""
			Exit Sub
		End If
		If ValidateUsername(SignupUsernameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics( a-z or A-Z ) or underscores( _ )")
			GLogin.LogOut()
			Exit Sub
		End If
		If ValidateFullname(SignupFullnameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics( a-z or A-Z ) or space")
			GLogin.LogOut()
			Exit Sub
		End If
		If Len(SignupUsernameTextBox.Text) < 4 Then
			Alert("Warning", "Use atleast 4 digits in username")
			GLogin.LogOut()
			Exit Sub
		End If
		If Len(SignupConfirmPasswordTextBox.Text) < 6 Then
			Alert("Warning", "Use atleast 6 digit password")
			GLogin.LogOut()
			Exit Sub
		End If
		If SQLInterface.DoesUsernameExists(SignupUsernameTextBox.Text) Then
			Alert("Warning", "Username already exists")
			Exit Sub
		End If
		GLogin.Username = SignupUsernameTextBox.Text
		GLogin.Fullname = SignupFullnameTextBox.Text
		GLogin.PasswordHash = EncryptNewPassword(Encrypt_Sha512(SignupPasswordTextBox.Text))
		GLogin.AccType = SignupDropDownBox.Text

		SQLInterface.Register()
		SignupPasswordTextBox.Text = ""
		SignupConfirmPasswordTextBox.Text = ""
		SignupUsernameTextBox.Text = ""
		SignupFullnameTextBox.Text = ""
	End Sub
	Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
		SignupDropDownBox.SelectedIndex = 0
		AAAALogoutButton.Visible = False
		DisablePage(AdminOptionsTab)
		DisablePage(SummaryTab)
		DisablePage(IssueBookTab)
		ReturnBookSearchDropDown.SelectedIndex = 0
		SQLInterface.PopulateBrowseBooksTable()
		StatusBar.Text = "Not Logged In"
		BrowseBooksDataGrid.ClearSelection()
	End Sub
	Private Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles AAAALogoutButton.Click
		LoginUsernameTextBox.Text = ""
		LoginPasswordTextBox.Text = ""
		SignupUsernameTextBox.Text = ""
		SignupPasswordTextBox.Text = ""
		SignupConfirmPasswordTextBox.Text = ""
		SignupFullnameTextBox.Text = ""
		SignupDropDownBox.SelectedIndex = 0
		GLogin.LogOut()
		If TabControlMain.TabPages.Contains(AdminOptionsTab) = True Then
			DisablePage(AdminOptionsTab)
		End If
		DisablePage(IssueBookTab)
		DisablePage(SummaryTab)
		EnablePage(LoginSignupTab)
		StatusBar.Text = "Not Logged In"
	End Sub
	Private Sub SummaryOldPasswordPicture_Click(sender As Object, e As EventArgs) Handles SummaryOldPasswordPicture.Click
		If SummaryOldPasswordTextbox.UseSystemPasswordChar = True Then
			SummaryOldPasswordTextbox.UseSystemPasswordChar = False
			SummaryOldPasswordPicture.Image = My.Resources.ResourceManager.GetObject("show")
		Else
			SummaryOldPasswordTextbox.UseSystemPasswordChar = True
			SummaryOldPasswordPicture.Image = My.Resources.ResourceManager.GetObject("hide")
		End If
	End Sub
	Private Sub SummaryNewPasswordPicture_Click(sender As Object, e As EventArgs) Handles AAASummaryNewPasswordPicture.Click
		If SummaryNewPasswordTextBox.UseSystemPasswordChar = True Then
			SummaryNewPasswordTextBox.UseSystemPasswordChar = False
			AAASummaryNewPasswordPicture.Image = My.Resources.ResourceManager.GetObject("show")
		Else
			SummaryNewPasswordTextBox.UseSystemPasswordChar = True
			AAASummaryNewPasswordPicture.Image = My.Resources.ResourceManager.GetObject("hide")
		End If
	End Sub
	Private Sub SummaryConfirmPasswordPicture_Click(sender As Object, e As EventArgs) Handles AAASummaryConfirmPasswordPicture.Click
		If SummaryConfirmPasswordTextBox.UseSystemPasswordChar = True Then
			SummaryConfirmPasswordTextBox.UseSystemPasswordChar = False
			AAASummaryConfirmPasswordPicture.Image = My.Resources.ResourceManager.GetObject("show")
		Else
			SummaryConfirmPasswordTextBox.UseSystemPasswordChar = True
			AAASummaryConfirmPasswordPicture.Image = My.Resources.ResourceManager.GetObject("hide")
		End If
	End Sub
	Private Sub CopyBookNameToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookNameToolStrip.Click
		Dim s As String = BrowseBooksDataGrid.CurrentRow.Cells(1).Value.ToString
		Clipboard.SetText(s)
	End Sub
	Private Sub CopyISBNNumberToolStrip_Click(sender As Object, e As EventArgs) Handles CopyISBNNumberToolStrip.Click
		Dim s As String = BrowseBooksDataGrid.CurrentRow.Cells(3).Value.ToString
		Clipboard.SetText(s)
	End Sub
	Private Sub CopyBookIDToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookIDToolStrip.Click
		Dim s As String = BrowseBooksDataGrid.CurrentRow.Cells(0).Value.ToString
		Clipboard.SetText(s)
	End Sub
	Private Sub IssueSelectedBookToolStrip_Click(sender As Object, e As EventArgs) Handles IssueSelectedBookToolStrip.Click
		' Todo: Issue Book Here using bookid
		Dim bookid As String = BrowseBooksDataGrid.CurrentRow.Cells(0).Value.ToString
	End Sub
	Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BrowseBooksDataGrid.CellMouseEnter
		BrowseBooksDataGrid.ClearSelection()
		If e.RowIndex >= 0 Then
			BrowseBooksDataGrid.Rows(e.RowIndex).Selected = True
		End If
	End Sub
	Private Sub SearchBookButton_Click(sender As Object, e As EventArgs) Handles SearchBookButton.Click
		Dim BookID As String = ""
		Dim BookISBN As String = ""
		Dim BookName As String = ""
		Dim BookAuthor As String = ""
		BookID = SearchBookIDTextBox.Text.Trim
		BookISBN = SearchBookISBNTextBox.Text
		BookName = SearchBookNameTextBox.Text.Trim
		BookAuthor = SearchBookAuthorTextBox.Text.Trim

		If ValidateInteger(BookID) = False AndAlso BookID <> "" Then
			Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
			Exit Sub
		End If
		If BookISBN.Length <> 13 AndAlso BookISBN.Length <> 10 AndAlso BookISBN.Length <> 0 Then
			Alert("Warning", "Enter 10 digit or 13 digit ISBN only")
			Exit Sub
		End If
		If ValidateISBN(BookISBN) = False AndAlso BookISBN <> "" Then
			Alert("Warning", "ISBN Checksum Incorrect")
			Exit Sub
		End If
		If ValidateBookname(BookName) = False AndAlso BookName <> "" Then
			Alert("Warning", "Incorrect Book Name ( Only Alphanumeric, space and symbols( _,: ) allowed")
			Exit Sub
		End If
		If ValidateBookAuthor(BookAuthor) = False AndAlso BookAuthor <> "" Then
			Alert("Warning", "Incorrect Author Name ( Only Alphanumeric, space and symbols( _,:' ) allowed")
			Exit Sub
		End If
		' TODO: Search Book Here
	End Sub
	Private Sub AlertBox_Click(sender As Object, e As EventArgs) Handles AlertBox1.Click, AlertBox2.Click, AlertBox3.Click, AlertBox4.Click, AlertBox5.Click, AlertBox6.Click, AlertBox7.Click, AlertBox8.Click
		AlertBox1.Visible = False
		AlertBox2.Visible = False
		AlertBox3.Visible = False
		AlertBox4.Visible = False
		AlertBox5.Visible = False
		AlertBox6.Visible = False
		AlertBox7.Visible = False
		AlertBox8.Visible = False
	End Sub
	Private Sub IssueButton_Click(sender As Object, e As EventArgs) Handles IssueButton.Click
		If GLogin.BooksIssued = 7 AndAlso GLogin.AccType = "Student" Then
			Alert("Warning", "Can not issue more than 7 books")
		ElseIf GLogin.BooksIssued = 10 Then
			Alert("Warning", "Can not issue more than 10 books")
		End If
		If IssueBookSearchDropDown.SelectedIndex = 0 Then
			If ValidateInteger(IssueBookInfoTextBox.Text) = False Then
				Alert("Warning", "Incorrect ISBN Number ( Only Numbers Allowed )")
				Exit Sub
			End If
			If Len(IssueBookInfoTextBox.Text) <> 13 AndAlso Len(IssueBookInfoTextBox.Text) <> 10 Then
				Alert("Warning", "ISBN number must be 10 or 13 digits long")
				Exit Sub
			End If
			If ValidateISBN(IssueBookInfoTextBox.Text) = False Then
				Alert("Error", "ISBN checksum does not match")
				Exit Sub
			End If
			' TODO: Search using ISBN here and issue the book
			Exit Sub
		ElseIf IssueBookSearchDropDown.SelectedIndex = 1 Then
			If ValidateInteger(IssueBookInfoTextBox.Text) = False Then
				Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
				Exit Sub
			End If
			' TODO: Search using BookID here and issue the book
			Alert("Success", "Book Issued(Mock)")
			GLogin.BooksIssued += 1
		End If
	End Sub
	Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
		If GLogin.BooksIssued = 0 Then
			Alert("Error", "No books Issued")
		End If
		If ReturnBookSearchDropDown.SelectedIndex = 0 Then
			If ValidateInteger(IssueBookInfoTextBox.Text) = False Then
				Alert("Warning", "Incorrect ISBN Number ( Only Numbers Allowed )")
				Exit Sub
			End If
			If Len(IssueBookInfoTextBox.Text.Trim) <> 13 AndAlso Len(IssueBookInfoTextBox.Text.Trim) <> 10 Then
				Alert("Warning", "ISBN number must be 10 or 13 digits long")
				Exit Sub
			End If
			If ValidateISBN(IssueBookInfoTextBox.Text) = False Then
				Alert("Error", "ISBN checksum does not match")
			End If
			' TODO: Search using ISBN here and issue the book
		End If
		' TODO: Get list of books issued
		'		Get time from Server
		If False Then 'if not in list of books issued
			Alert("Error", "You did not issued this book in the first place")
			Exit Sub
		End If
		If True Then ' some due added by late submission of this book
			Msg.Info("This book was returned late. Due = " + "(DueValue)")
		End If
		' TODO: remove returned book from user account, add 1 to number of copies in ventory
		If True Then ' Successful return
			Alert("Success", "Book Returned")
			GLogin.BooksIssued -= 1
		Else
			Alert("Error", "Can not process book return")
		End If
	End Sub
	Private Sub AdminAddAccButton_Click(sender As Object, e As EventArgs) Handles AdminAddAccButton.Click
		If AdminAddAccPasswordTextBox.Text <> AdminAddAccConfirmPasswordTextBox.Text Then
			Alert("Error", "Passwords do not match! Enter passwords again carefully!")
			AdminAddAccPasswordTextBox.Text = ""
			AdminAddAccConfirmPasswordTextBox.Text = ""
			Exit Sub
		End If
		If ValidateUsername(AdminAddAccUsernameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics or underscores")
			Exit Sub
		End If
		If ValidateFullname(AdminAddAccFullnameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics or space")
			Exit Sub
		End If
		If SQLInterface.DoesUsernameExists(SummaryUsernameTextBox.Text) Then
			Alert("Warning", "Username already exists")
			Exit Sub
		End If
		' TODO: Admin register function
	End Sub
	Private Sub AdminEditAccButton_Click(sender As Object, e As EventArgs) Handles AdminEditAccButton.Click
		If AdminAddAccPasswordTextBox.Text <> AdminAddAccConfirmPasswordTextBox.Text Then
			Alert("Error", "Passwords do not match! Enter passwords again carefully!")
			AdminEditAccConfirmPasswordTextBox.Text = ""
			AdminEditAccConfirmPasswordTextBox.Text = ""
			Exit Sub
		End If
		If ValidateUsername(AdminEditAccOldUsernameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics or underscores in old username")
			Exit Sub
		End If
		If ValidateUsername(AdminEditAccNewUsernameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics or underscores in new username")
			Exit Sub
		End If
		If ValidateFullname(AdminEditAccNewFullnameTextBox.Text) = False Then
			Alert("Warning", "Use only alphanumerics or space in new fullname")
			Exit Sub
		End If
		' TODO: Admin Update function
	End Sub

	Private Sub SummaryEditProfileButton_Click(sender As Object, e As EventArgs) Handles SummaryEditProfileButton.Click
		If ValidateUsername(SummaryUsernameTextBox.Text) = False Then
			Alert("Warning", "Use only Alphanumerics and unerscores in username")
			Exit Sub
		End If
		Console.WriteLine("1")

		If ValidateFullname(SummaryFullnameTextBox.Text) = False Then
			Alert("Warning", "Use only Alphanumerics and space in fullname")
			Exit Sub
		End If
		Console.WriteLine("2")
		If GLogin.AccType <> "Admin" Then
			If Len(SummaryUsernameTextBox.Text) < 4 Then
				Alert("Warning", "Use atleast 4 digits in username")
				Exit Sub
			End If
			If Len(SummaryFullnameTextBox.Text) < 6 Then
				Alert("Warning", "Use atleast 6 digits in password")
				Exit Sub
			End If
		End If
		Console.WriteLine("3")

		If SQLInterface.DoesUsernameExists(SummaryUsernameTextBox.Text) = False Then
			Alert("Warning", "Username already exists")
			Exit Sub
		End If
		Console.WriteLine("4")

		If SQLInterface.EditProfileData(SummaryUsernameTextBox.Text, SummaryFullnameTextBox.Text, SummaryProfileDropDownBox.Text) = False Then
			Alert("Error", "Edit Profile Failed")
			Exit Sub
		End If
		Console.WriteLine("5")

		Alert("Success", "Profile Edited Successfully")
	End Sub

	Private Sub SummaryChangePasswordButton_Click(sender As Object, e As EventArgs) Handles SummaryChangePasswordButton.Click
		If SummaryNewPasswordTextBox.Text <> SummaryConfirmPasswordTextBox.Text Then
			Alert("Warning", "New Passwords do not match. Try Again")
			SummaryNewPasswordTextBox.Text = ""
			SummaryConfirmPasswordTextBox.Text = ""
			Exit Sub
		End If
		If Len(SummaryConfirmPasswordTextBox.Text) < 6 Then
			Alert("Warning", "Use atleast 6 digits in password")
		End If
		GLogin.TempHash = GLogin.PasswordHash
		GLogin.TempSalt = GLogin.Salt
		If GLogin.TempHash = Encrypt_Sha512(GLogin.Salt + Encrypt_Sha512(SummaryOldPasswordTextbox.Text) + "d5eba9b008f69bd56e") Then
			GLogin.PasswordHash = SHA512.EncryptNewPassword(Encrypt_Sha512(SummaryNewPasswordTextBox.Text))
			If SQLInterface.ChangePassword() = True Then
				Alert("Success", "password changed successfully")
			Else
				Alert("Error", "error changing password")
				GLogin.PasswordHash = GLogin.TempHash
				GLogin.Salt = GLogin.TempSalt
			End If
		Else
			Alert("Error", "Old Password is incorrect. Try Again")
			SummaryOldPasswordTextbox.Text = ""
			SummaryNewPasswordTextBox.Text = ""
			SummaryConfirmPasswordTextBox.Text = ""
		End If
		GLogin.LoggedIn = True
	End Sub

End Class


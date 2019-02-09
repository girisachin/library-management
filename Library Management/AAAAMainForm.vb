Imports MySql.Data.MySqlClient
Public Class AAAAMainForm
	Private HiddenPages As List(Of TabPage) = New List(Of TabPage)

	Public Sub AlertFunction(ByVal status As String, ByVal str As String)
		Dim x As Integer = 0
		If status = "Success" Then

			AlertBox1.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Success, str, 7000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Success, str, 7000)
		ElseIf status = "Warning" Then
			AlertBox1.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Info, str, 7000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Info, str, 7000)
		Else
			AlertBox1.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Error, str, 7000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Error, str, 7000)
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
		If LoginUsernameTextBox.Text = "" Or LoginPasswordTextBox.Text = "" Then
			Alert("Warning", "Username/Password fields can not be empty")
			GLogin.LogOut()
			Exit Sub
		End If
		For Each C As Char In LoginUsernameTextBox.Text
			If AscW(C) >= AscW("a") AndAlso AscW("z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("A") AndAlso AscW("Z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("0") AndAlso AscW("9") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) = AscW("_") Then
				Continue For
			Else
				Alert("Warning", "Use only alphanumerics( a-z or A-Z ) or underscores( _ )")
				GLogin.LogOut()
				Exit Sub
			End If
		Next
		If Len(LoginUsernameTextBox.Text.Trim) < 4 Then
			Alert("Warning", "Use atleast 4 digits in username")
			GLogin.LogOut()
			Exit Sub
		End If
		If Len(LoginPasswordTextBox.Text.Trim) < 6 Then
			Alert("Warning", "Use atleast 6 digits in password")
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
		For Each C As Char In SignupUsernameTextBox.Text
			If AscW(C) >= AscW("a") AndAlso AscW("z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("A") AndAlso AscW("Z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("0") AndAlso AscW("9") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) = AscW("_") Then
				Continue For
			Else
				Alert("Warning", "Invalid Characters in Username. Use only alphanumerics( a-z or A-Z ) or underscores( _ )")
				GLogin.LogOut()
				Exit Sub
			End If
		Next
		GLogin.Username = SignupUsernameTextBox.Text
		For Each C As Char In SignupFullnameTextBox.Text
			If AscW(C) >= AscW("a") AndAlso AscW("z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) >= AscW("A") AndAlso AscW("Z") >= AscW(C) Then
				Continue For
			ElseIf AscW(C) = AscW(" ") Then
				Continue For
			Else
				Alert("Warning", "Invalid Characters in Name. Use only alphanumerics( a-z or A-Z ) or Space")
				GLogin.LogOut()
				Exit Sub
			End If
		Next
		If Len(SignupUsernameTextBox.Text.Trim) < 4 Then
			Alert("Warning", "Use atleast 4 digits in username")
			GLogin.LogOut()
			Exit Sub
		End If
		If Len(SignupConfirmPasswordTextBox.Text.Trim) < 6 Then
			Alert("Warning", "Use atleast 6 digit password")
			GLogin.LogOut()
			Exit Sub
		End If

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
		' Todo: Issue Book Here
		Console.WriteLine(BrowseBooksDataGrid.CurrentRow.Cells(3).Value.ToString)
	End Sub
	Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BrowseBooksDataGrid.CellMouseEnter
		BrowseBooksDataGrid.ClearSelection()
		If e.RowIndex >= 0 Then
			BrowseBooksDataGrid.Rows(e.RowIndex).Selected = True
		End If
	End Sub

	Private Sub SearchBookButton_Click(sender As Object, e As EventArgs) Handles SearchBookButton.Click
		For Each C As Char In SearchBookIDTextBox.Text
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			Else
				Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
				Exit Sub
			End If
		Next
		For Each C As Char In SearchISBNTextBox.Text
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			Else
				Alert("Warning", "Incorrect ISBN Number ( Only Numbers Allowed )")
				Exit Sub
			End If
		Next
		If Len(SearchISBNTextBox.Text) <> 13 AndAlso Len(SearchISBNTextBox.Text) <> 10 Then
			Alert("Warning", "ISBN number must be 10 or 13 digits long")
			Exit Sub
		End If
		If ValidateISBN(SearchISBNTextBox.Text) = False Then
			Alert("Error", "ISBN checksum does not match")
		End If
		For Each C As Char In SearchBookNameTextBox.Text
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			ElseIf AscW("a") <= AscW(C) AndAlso AscW(C) <= AscW("A") Then
				Continue For
			ElseIf AscW("A") <= AscW(C) AndAlso AscW(C) <= AscW("Z") Then
				Continue For
			ElseIf AscW("_") = AscW(C) Or AscW(C) = AscW(" ") Or AscW(":") = AscW(C) Or AscW(C) = AscW("'") Or AscW(C) = AscW(",") Or AscW(C) = AscW("(") Or AscW(C) = AscW(")") Then
				Continue For
			Else
				Alert("Warning", "Incorrect Book Name ( Only Alphanumeric, space and symbols( _,:' ) allowed")
				Exit Sub
			End If
		Next
		For Each C As Char In SearchAuthorTextBox.Text
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			ElseIf AscW("a") <= AscW(C) AndAlso AscW(C) <= AscW("z") Then
				Continue For
			ElseIf AscW("A") <= AscW(C) AndAlso AscW(C) <= AscW("Z") Then
				Continue For
			ElseIf AscW("_") = AscW(C) Or AscW(C) = AscW(" ") Or AscW(":") = AscW(C) Or AscW(C) = AscW("'") Or AscW(C) = AscW(",") Or AscW(C) = AscW("(") Or AscW(C) = AscW(")") Then
				Continue For
			Else
				Alert("Warning", "Incorrect Author Name ( Only Alphanumeric, space and symbols( _,:' ) allowed")
				Exit Sub
			End If
		Next
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
		If IssueBookSearchDropDown.SelectedIndex = 0 Then
			For Each C As Char In IssueBookInfoTextBox.Text
				If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
					Continue For
				Else
					Alert("Warning", "Incorrect ISBN Number ( Only Numbers Allowed )")
					Exit Sub
				End If
			Next
			If Len(IssueBookInfoTextBox.Text) <> 13 AndAlso Len(IssueBookInfoTextBox.Text) <> 10 Then
				Alert("Warning", "ISBN number must be 10 or 13 digits long")
				Exit Sub
			End If
			If ValidateISBN(IssueBookInfoTextBox.Text) = False Then
				Alert("Error", "ISBN checksum does not match")
			End If
			' TODO: Search using ISBN here and issue the book
			Exit Sub
		ElseIf IssueBookSearchDropDown.SelectedIndex = 1 Then
			For Each C As Char In IssueBookInfoTextBox.Text
				If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
					Continue For
				Else
					Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
					Exit Sub
				End If
			Next
			' TODO: Search using BookID here and issue the book
		End If
	End Sub

	Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
		If ReturnBookSearchDropDown.SelectedIndex = 0 Then
			For Each C As Char In ReturnBookInfoTextBox.Text
				If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
					Continue For
				Else
					Alert("Warning", "Incorrect ISBN Number ( Only Numbers Allowed )")
					Exit Sub
				End If
			Next
			If Len(IssueBookInfoTextBox.Text) <> 13 AndAlso Len(IssueBookInfoTextBox.Text) <> 10 Then
				Alert("Warning", "ISBN number must be 10 or 13 digits long")
				Exit Sub
			End If
			If ValidateISBN(IssueBookInfoTextBox.Text) = False Then
				Alert("Error", "ISBN checksum does not match")
			End If
			' TODO: Search using ISBN here and issue the book
			Exit Sub
		ElseIf ReturnBookSearchDropDown.SelectedIndex = 1 Then
			For Each C As Char In ReturnBookInfoTextBox.Text
				If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
					Continue For
				Else
					Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
					Exit Sub
				End If
			Next
			' TODO: Search using BookID here and issue the book
		End If
	End Sub

	'Private Sub MyTextBox1_TextChanged(sender As Object, e As EventArgs) Handles MyTextBox1.TextChanged
	'	My.Settings.username = MyTextBox1.Text
	'	My.Settings.Save()
	'	SQLInterface.con.Dispose()
	'	SQLInterface.con = New MySqlConnection("server=" + My.Settings.server + "; user id=" + My.Settings.username + "; password=" + My.Settings.password + "; database=" + My.Settings.database)
	'End Sub
End Class


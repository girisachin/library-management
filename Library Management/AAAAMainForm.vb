Imports MySql.Data.MySqlClient
Public Class AAAAMainForm
    Private BrowseBookCurrentRow As Integer = -1
    Private approvalgridcurrentrow As Integer = -1
    Private HiddenPages As List(Of TabPage) = New List(Of TabPage)
	Public Sub AlertFunction(ByVal status As String, ByVal str As String)
		If status = "Success" Then
			AlertBox1.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Success, str, 2000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Success, str, 2000)
		ElseIf status = "Warning" Then
			AlertBox1.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Info, str, 2000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Info, str, 2000)
		Else
			AlertBox1.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox2.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox3.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox4.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox5.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox6.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox7.ShowControl(MyAlertBox._Kind.Error, str, 2000)
			AlertBox8.ShowControl(MyAlertBox._Kind.Error, str, 2000)
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
			' Logged in successfully
			StatusBar.Text = "Logged in as " + GLogin.Username + "(" + GLogin.AccType + ")"
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
			MyTextBox3.Text = GLogin.Fullname
			MyTextBox4.Text = GLogin.Username
			If GLogin.AccType = "Admin" Then
				SummaryProfileDropDownBox.SelectedIndex = 2
			ElseIf GLogin.AccType = "Teacher" Then
				SummaryProfileDropDownBox.SelectedIndex = 1
			Else
				SummaryProfileDropDownBox.SelectedIndex = 0
			End If
			'SQLInterface.loadissuedbooks(GLogin.books)
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
		If Len(SignupFullnameTextBox.Text.Trim) <> 0 Then
			Alert("Error", "Check Your Fullname")
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
		If SQLInterface.DoesUsernameExists(SignupUsernameTextBox.Text) = True Then
			Alert("Warning", "Username already exists")
			Exit Sub
		End If
		GLogin.Username = SignupUsernameTextBox.Text
		GLogin.Fullname = SignupFullnameTextBox.Text
		GLogin.PasswordHash = EncryptNewPassword(Encrypt_Sha512(SignupPasswordTextBox.Text))
		GLogin.AccType = SignupDropDownBox.Text

		If SQLInterface.Register() = True Then
			SignupPasswordTextBox.Text = ""
			SignupConfirmPasswordTextBox.Text = ""
			SignupUsernameTextBox.Text = ""
			SignupFullnameTextBox.Text = ""
			Alert("Success", "Signup Successful")
		Else
			Alert("Error", "Could not register")
		End If
	End Sub
	Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
		SignupDropDownBox.SelectedIndex = 0
		AAAALogoutButton.Visible = False
		DisablePage(AdminOptionsTab)
		DisablePage(SummaryTab)
		DisablePage(IssueBookTab)
		AdminAddAccDropDown.SelectedIndex = 0
		StatusBar.Text = "Not Logged In"
		While SQLInterface.GetSysDateTime() = False
			GetServer.ShowDialog()
		End While
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
		Dim s As String = BrowseBooksDataGrid.Rows(BrowseBookCurrentRow).Cells(1).Value.ToString
		Clipboard.SetText(s)
    End Sub
    Private Sub CopyISBNNumberToolStrip_Click(sender As Object, e As EventArgs) Handles CopyISBNNumberToolStrip.Click
		Dim s As String = BrowseBooksDataGrid.Rows(BrowseBookCurrentRow).Cells(3).Value.ToString
		Clipboard.SetText(s)
    End Sub
    Private Sub CopyBookIDToolStrip_Click(sender As Object, e As EventArgs) Handles CopyBookIDToolStrip.Click
		Dim s As String = BrowseBooksDataGrid.Rows(BrowseBookCurrentRow).Cells(0).Value.ToString
		Clipboard.SetText(s)
    End Sub
    Private Sub IssueSelectedBookToolStrip_Click(sender As Object, e As EventArgs) Handles IssueSelectedBookToolStrip.Click
        If GLogin.LoggedIn = False Then
            TabControlMain.SelectedTab = LoginSignupTab
            Alert("Warning", "Please Login to continue")
        End If
        If GLogin.BooksIssued = 7 AndAlso GLogin.AccType = "Student" Then
            Alert("Warning", "Can not issue more than 7 books")
        ElseIf GLogin.BooksIssued = 10 Then
            Alert("Warning", "Can not issue more than 10 books")
        End If
        Dim bookid As String = BrowseBooksDataGrid.Rows(BrowseBookCurrentRow).Cells(0).Value.ToString
        If Convert.ToUInt64(BrowseBooksDataGrid.Rows(BrowseBookCurrentRow).Cells(5).Value) <= 0 Then
            Alert("Error", "Book not available for issue")
            Exit Sub
        End If
        IssueBookByID(bookid)
        SQLInterface.PopulateBrowseBooksTable()
        ' Todo: Issue Book Here using bookid
    End Sub
    Private Sub DataGridView1_CellMouseEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BrowseBooksDataGrid.CellMouseEnter
        BrowseBookCurrentRow = e.RowIndex
        BrowseBooksDataGrid.ClearSelection()
        If e.RowIndex >= 0 Then
            BrowseBooksDataGrid.Rows(e.RowIndex).Selected = True
        End If
    End Sub
    Private Sub SearchBookButton_Click(sender As Object, e As EventArgs) Handles SearchBookButton.Click
        Dim BookID As String = ""
        Dim BookISBN As String = ""
        Dim BookName As String = ""
        Dim Genre As String = ""
        Dim BookAuthor As String = ""
        BookID = SearchBookIDTextBox.Text.Trim
        BookISBN = SearchBookISBNTextBox.Text
        BookName = SearchBookNameTextBox.Text.Trim
        Genre = SearchBookGenreTextBox.Text.Trim
        BookAuthor = SearchBookAuthorTextBox.Text.Trim
        If BookID = "" And BookISBN = "" And BookName = "" And Genre = "" And BookAuthor = "" Then
            TabControlMain.SelectedTab = BrowseBooksTab
            SearchBookIDTextBox.Text = ""
            SearchBookISBNTextBox.Text = ""
            SearchBookNameTextBox.Text = ""
            SearchBookGenreTextBox.Text = ""
            SearchBookAuthorTextBox.Text = ""
            Exit Sub
        End If
        If ValidateInteger(BookID) = False AndAlso BookID <> "" Then
            Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
            Exit Sub
        End If
        If BookISBN.Length <> 13 AndAlso BookISBN.Length <> 10 AndAlso BookISBN.Length <> 0 Then
            Alert("Warning", "Enter 10 digit or 13 digit ISBN only")
            Exit Sub
        End If
        If ValidateInteger(BookISBN) = False AndAlso BookISBN <> "" Then
            Alert("Warning", "Incorrect ISBN ( Only Numbers Allowed )")
            Exit Sub
        End If
        If ValidateBookname(BookName) = False AndAlso BookName <> "" Then
            Alert("Warning", "Incorrect Book Name ( Only Alphanumeric, space and symbols( _,: ) allowed")
            Exit Sub
        End If
        If ValidateBookGenre(Genre) = False AndAlso Genre <> "" Then
            Alert("Warning", "Incorrect Genre ( Only Alphanumeric, space and symbols( _,:' ) allowed")
            Exit Sub
        End If
        If ValidateBookAuthor(BookAuthor) = False AndAlso BookAuthor <> "" Then
            Alert("Warning", "Incorrect Author Name ( Only Alphanumeric, space and symbols( _,:' ) allowed")
            Exit Sub
        End If
        ' TODO: Search Book Here
        BookName = BookName.Replace("'", "''")
        Genre = Genre.Replace("'", "''")
        BookAuthor = BookAuthor.Replace("'", "''")
        SQLInterface.PopulateSearchBooksTable(BookID, BookISBN, BookName, Genre, BookAuthor)
        BookList.Show()
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

        If ValidateInteger(IssueBookInfoTextBox.Text) = False Then
            Alert("Warning", "Incorrect Book ID ( Only Numbers Allowed )")
            Exit Sub
        End If

        ' TODO: Search using BookID here and issue the book
        IssueBookByID(IssueBookInfoTextBox.Text)
        updateDueIssueText()

    End Sub
    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click

        ReturnBookByID(ReturnBookInfoTextBox.Text)

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
        If SQLInterface.DoesUsernameExists(AdminAddAccUsernameTextBox.Text) = True Then
            Alert("Warning", "Username already exists")
            Exit Sub
        End If

        GAdmin.Username = AdminAddAccUsernameTextBox.Text
        GAdmin.Fullname = AdminAddAccFullnameTextBox.Text
        GAdmin.PasswordHash = AdminEncryptNewPassword(Encrypt_Sha512(AdminAddAccPasswordTextBox.Text))
        GAdmin.AccType = AdminAddAccDropDown.Text

        If SQLInterface.AdminRegister() = True Then
            AdminAddAccPasswordTextBox.Text = ""
            AdminAddAccConfirmPasswordTextBox.Text = ""
            AdminAddAccUsernameTextBox.Text = ""
            AdminAddAccFullnameTextBox.Text = ""
            Alert("Success", "Account successfuffy created")
        Else
            Alert("Error", "Could not create Account")
        End If
    End Sub
    Private Sub AdminEditAccButton_Click(sender As Object, e As EventArgs) Handles AdminEditAccButton.Click
        If AdminEditAccNewPasswordTextBox.Text <> AdminEditAccConfirmPasswordTextBox.Text Then
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
        If AdminEditAccOldUsernameTextBox.Text = GLogin.Username Then
            Alert("Warning", "Edit your own Accoubnt from Dashboard")
            Exit Sub
        End If
        Dim NewUsername As String = ""
        Dim NewFullname As String = ""
        Dim NewPassword As String = ""
        NewUsername = AdminEditAccNewUsernameTextBox.Text
        NewPassword = AdminEditAccNewPasswordTextBox.Text
        NewFullname = AdminEditAccNewFullnameTextBox.Text
        If NewUsername = "" Then
            NewUsername = AdminEditAccOldUsernameTextBox.Text
        End If
        If NewPassword <> "" Then
            NewPassword = Encrypt_Sha512(NewPassword)
            NewPassword = AdminEncryptNewPassword(NewPassword)
        End If
        If SQLInterface.DoesUsernameExists(AdminEditAccOldUsernameTextBox.Text) = False Then
            Alert("Warning", "Username does not exist")
            Exit Sub
        End If

        If SQLInterface.AdminEditAccount(NewUsername, NewFullname, NewPassword, AdminEditAccOldUsernameTextBox.Text, AdminEditAccTypeDropDown.Text) = False Then
            Alert("Error", "Counld not edit Account")
            Exit Sub
        End If
        Alert("Success", "Account Edited Successfully")
    End Sub
    Private Sub SummaryEditProfileButton_Click(sender As Object, e As EventArgs) Handles SummaryEditProfileButton.Click
        If ValidateUsername(SummaryUsernameTextBox.Text) = False Then
            Alert("Warning", "Use only Alphanumerics and unerscores in username")
            Exit Sub
        End If

        If ValidateFullname(SummaryFullnameTextBox.Text) = False Then
            Alert("Warning", "Use only Alphanumerics and space in fullname")
            Exit Sub
        End If
        If GLogin.AccType <> "Admin" Then
            If Len(SummaryUsernameTextBox.Text) < 4 Then
                Alert("Warning", "Use atleast 4 digits in username")
                Exit Sub
            End If
        End If

        If SummaryUsernameTextBox.Text <> "" AndAlso GLogin.Username <> SummaryUsernameTextBox.Text AndAlso SQLInterface.DoesUsernameExists(SummaryUsernameTextBox.Text) = True Then
            Alert("Warning", "Username already exists")
            Exit Sub
        End If

        If SQLInterface.EditProfileData(SummaryUsernameTextBox.Text, SummaryFullnameTextBox.Text, SummaryProfileDropDownBox.Text) = False Then
            Alert("Error", "Edit Profile Failed")
            Exit Sub
        End If
        StatusBar.Text = "Logged in as " + GLogin.Username + "(" + GLogin.AccType + ")"
        Alert("Success", "Profile Edited Successfully")
        MyTextBox3.Text = GLogin.Fullname
        MyTextBox4.Text = GLogin.Username
    End Sub
    Private Sub SummaryChangePasswordButton_Click(sender As Object, e As EventArgs) Handles SummaryChangePasswordButton.Click
        If SummaryNewPasswordTextBox.Text <> SummaryConfirmPasswordTextBox.Text Then
            Alert("Warning", "New Passwords do not match. Try Again")
            SummaryNewPasswordTextBox.Text = ""
            SummaryConfirmPasswordTextBox.Text = ""
            Exit Sub
        End If
        If SummaryOldPasswordTextbox.Text = SummaryNewPasswordTextBox.Text Then
            Alert("Warning", "Old Password = new Password")
            Exit Sub
        End If
        If Len(SummaryConfirmPasswordTextBox.Text) < 6 And GLogin.AccType <> "Admin" Then
            Alert("Warning", "Use atleast 6 digits in password")
            Exit Sub
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
    Private Sub AdminDeleteAccButton_Click(sender As Object, e As EventArgs) Handles AdminDeleteAccButton.Click
        If ValidateUsername(AdminDeleteAccUsernameTextBox.Text) = False Then
            Alert("Warning", "Use only alphanumerics and underscore in username to delete")
            Exit Sub
        End If
        If SQLInterface.DoesUsernameExists(AdminDeleteAccUsernameTextBox.Text) = False Then
            Alert("Error", "Username does not exists")
            Exit Sub
        End If

        If SQLInterface.returnissuedbooksofuser(AdminDeleteAccUsernameTextBox.Text) <> 0 Then
            Alert("Warning", "Cannot Delete Acount!, User has to return the issued.")
            Exit Sub
        End If

        If AdminDeleteAccUsernameTextBox.Text = GLogin.Username Then
            If SQLInterface.AdminDeleteAccount(AdminDeleteAccUsernameTextBox.Text) = False Then
                Alert("Error", "Could not delete account. Try Again Later")
                Exit Sub
            End If
            Alert("Success", "Account Deleted Successfully")
            If GLogin.AccType = "Admin" Then
                DisablePage(AdminOptionsTab)
            End If
            GLogin.LogOut()
            StatusBar.Text = "Not Logged In"
            Alert("Success", "Logged Out !")
            EnablePage(LoginSignupTab)
            DisablePage(IssueBookTab)
            DisablePage(SummaryTab)
            AAAALogoutButton.Visible = False
            SummaryDueTextBox.Text = "0"
            SummaryBooksIssuedTextBox.Text = "0"
            SummaryUsernameTextBox.Text = ""
            SummaryProfileDropDownBox.SelectedIndex = 0
            Exit Sub
        End If
        If SQLInterface.AdminDeleteAccount(AdminDeleteAccUsernameTextBox.Text) = False Then
            Alert("Error", "Could not delete account. Try Again Later")
            Exit Sub
        End If
        Alert("Success", "Account Deleted Successfully")
    End Sub
    Private Sub AdminRemoveBookButton_Click(sender As Object, e As EventArgs) Handles AdminRemoveBookButton.Click
        If ValidateInteger(AdminRemoveBookIDTextBox.Text) = False Then
            Alert("Warning", "Use only alphanumerics and underscore in bookid to delete")
            Exit Sub
        End If
        If SQLInterface.DoesBookIDExists(AdminRemoveBookIDTextBox.Text) = False Then
            Alert("Error", "Book does not exist")
            Exit Sub
        End If
        If SQLInterface.AdminDeleteBook(AdminRemoveBookIDTextBox.Text) = False Then
            Alert("Error", "Could not delete book. Try Again Later")
            Exit Sub
        End If
        Alert("Success", "Book Deleted Successfully")
    End Sub
    Private Sub AdminAddBookButton_Click(sender As Object, e As EventArgs) Handles AdminAddBookButton.Click
        If ValidateInteger(AdminAddBookISBN.Text) = False Then
            Alert("Warning", "Use ony 10 or 13 digit integers in ISBN")
            Exit Sub
        End If
        If ValidateISBN(AdminAddBookISBN.Text) = False Then
            Alert("Warning", "ISBN checksum failed")
            Exit Sub
        End If
        If AdminAddBookName.Text = "" Or ValidateBookname(AdminAddBookName.Text) = False Then
            Alert("Warning", "Use some alphanumerics or space in book name")
            Exit Sub
        End If
        If AdminAddBookAuthor.Text = "" Or ValidateBookAuthor(AdminAddBookAuthor.Text) = False Then
            Alert("Warning", "Use some alphanumerics or space in book author")
            Exit Sub
        End If
        If AdminAddBookGenre.Text = "" Or ValidateBookGenre(AdminAddBookGenre.Text) = False Then
            Alert("Warning", "Use some alphanumerics or space in book genre")
            Exit Sub
        End If
        If ValidateInteger(AdminAddBookCopies.Text) = False Or AdminAddBookCopies.Text = "" Then
            Alert("Warning", "Use integers in book name")
            Exit Sub
        End If
        If SQLInterface.AdminAddBookInfo(AdminAddBookName.Text, AdminAddBookAuthor.Text, AdminAddBookISBN.Text, AdminAddBookGenre.Text, AdminAddBookCopies.Text) = False Then
            Alert("Error", "Can not add book")
            Exit Sub
        End If
        AdminAddBookName.Text = ""
        AdminAddBookAuthor.Text = ""
        AdminAddBookISBN.Text = ""
        AdminAddBookGenre.Text = ""
        AdminAddBookCopies.Text = ""

        Alert("Success", "Book Added")
    End Sub
    Private Sub TabControlMain_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlMain.Selected
        '      SignupDropDownBox.SelectedIndex = 0
        '      AAAALogoutButton.Visible = False
        ''DisablePage(AdminOptionsTab)
        ''DisablePage(SummaryTab)
        ''DisablePage(IssueBookTab)
        'IssueBookSearchDropDown.SelectedIndex = 0
        '      ReturnBookSearchDropDown.SelectedIndex = 0
        '      SQLInterface.PopulateBrowseBooksTable()
        '      BrowseBooksDataGrid.ClearSelection()
        '      AdminAddAccDropDown.SelectedIndex = 0
        If e.TabPage.Name = "LoginSignupTab" Then
        ElseIf e.TabPage.Name = "SummaryTab" Then
            MyTextBox3.Text = GLogin.Fullname
            MyTextBox4.Text = GLogin.Username
            'CalculateDue()
            'SummaryDueTextBox.Text = GLogin.Due.ToString
            'SummaryBooksIssuedTextBox.Text = GLogin.BooksIssued.ToString
            updateDueIssueText()

        ElseIf e.TabPage.Name = "BrowseBooksTab" Then
            BrowseBooksDataGrid.ClearSelection()
            SQLInterface.PopulateBrowseBooksTable()
        End If
        'e.TabPage.Name
    End Sub
    Private Sub AAAALogoutButton_Click(sender As Object, e As EventArgs) Handles AAAALogoutButton.Click
        If GLogin.AccType = "Admin" Then
            DisablePage(AdminOptionsTab)
        End If
        GLogin.LogOut()
        StatusBar.Text = "Not Logged In"
        Alert("Success", "Logged Out !")
        EnablePage(LoginSignupTab)
        DisablePage(IssueBookTab)
        DisablePage(SummaryTab)
        AAAALogoutButton.Visible = False
        SummaryDueTextBox.Text = "0"
        SummaryBooksIssuedTextBox.Text = "0"
        SummaryUsernameTextBox.Text = ""
        SummaryProfileDropDownBox.SelectedIndex = 0
    End Sub
    Private Sub SummaryViewIssuedBooks_Click(sender As Object, e As EventArgs) Handles SummaryViewIssuedBooks.Click
        If GLogin.BooksIssued = 0 Then
            Alert("Warning", "No Books Issued")
        Else
            IssuedBooks.Show()
        End If
    End Sub
    Private Sub AdminEditBookButton_Click(sender As Object, e As EventArgs) Handles AdminEditBookButton.Click
        If ValidateInteger(AdminEditBookID.Text) = False Then
            Alert("Warning", "Use integers in Book ID")
            Exit Sub
        End If
        If ValidateInteger(AdminEditBookISBN.Text) = False Then
            Alert("Warning", "Use only integers in ISBN")
            Exit Sub
        End If
        If ValidateISBN(AdminEditBookISBN.Text) = False Then
            Alert("Error", "ISBN checksum Failed")
            Exit Sub
        End If
        If ValidateBookname(AdminEditBookName.Text) = False Then
            Alert("Warning", "Invalid Chars in BookName")
            Exit Sub
        End If
        If ValidateBookAuthor(AdminEditBookAuthor.Text) = False Then
            Alert("Warning", "Invalid Chars in Book Author Name")
            Exit Sub
        End If
        If ValidateBookGenre(AdminEditBookGenreTextBox.Text) = False Then
            Alert("Warning", "Invalid Chars in Genre")
            Exit Sub
        End If
        If ValidateInteger(AdminEditBookCopies.Text) = False Then
            Alert("Warning", "Use integers in number of Copies")
            Exit Sub
        End If
        If SQLInterface.IsCorrectBookID(AdminEditBookID.Text) = False Then
            Alert("Error", "Book Does not Exist")
        End If
        Dim issued As String = ""
        Dim left As String = ""
        issued = SQLInterface.BooksCopiesMinusLeft(AdminEditBookID.Text).ToString
        Try
            left = (Convert.ToUInt64(AdminEditBookCopies.Text) - Convert.ToUInt64(issued)).ToString
        Catch ex As Exception
            Alert("error", "Cannot Edit, Enter Valid number of Copies")
            Exit Sub
        End Try
        If left < 0 Then
            Alert("Error", "More number of copies are already issued")
            Exit Sub
        End If
        If SQLInterface.AdminEditBook(AdminEditBookID.Text, AdminEditBookISBN.Text, AdminEditBookName.Text, AdminEditBookAuthor.Text, AdminEditBookGenreTextBox.Text, AdminEditBookCopies.Text, left) = False Then
            Alert("Error", "Could Not Edit bookinfo")
            Exit Sub
        End If
        Alert("Success", "Book Edited Successfully")
    End Sub

    Private Sub EditAccountToolStrip_Click(sender As Object, e As EventArgs) Handles ApproveToolStrip.Click
        Dim username As String = AdminApprovalDataGrid.Rows(approvalgridcurrentrow).Cells(0).Value.ToString
        SQLInterface.approveuser(username)
        SQLInterface.PopulateApprovalDataGrid()

    End Sub

    Private Sub CopyBookIDToolStrip1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AdminTabControl_Selected(sender As Object, e As TabControlEventArgs) Handles AdminTabControl.Selected
        If e.TabPage.Name = "ApprovalsTab" Then
            SQLInterface.PopulateApprovalDataGrid()
        End If
    End Sub

    Private Sub DisapproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisapproveToolStripMenuItem.Click
        Dim username As String = AdminApprovalDataGrid.Rows(approvalgridcurrentrow).Cells(0).Value.ToString
        SQLInterface.disapproveuser(username)
        SQLInterface.PopulateApprovalDataGrid()
    End Sub

    Private Sub AdminApprovalDataGrid_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles AdminApprovalDataGrid.CellMouseEnter
        approvalgridcurrentrow = e.RowIndex
        AdminApprovalDataGrid.ClearSelection()
        If e.RowIndex >= 0 Then
            AdminApprovalDataGrid.Rows(e.RowIndex).Selected = True
        End If

    End Sub
End Class


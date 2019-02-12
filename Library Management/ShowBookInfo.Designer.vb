<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowBookInfo
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.FormSkin1 = New Library_Management.FormSkin()
		Me.GoButton = New Library_Management.MyButton()
		Me.Action = New Library_Management.MyComboBox()
		Me.MyLabel5 = New Library_Management.MyLabel()
		Me.MyLabel4 = New Library_Management.MyLabel()
		Me.MyLabel3 = New Library_Management.MyLabel()
		Me.MyLabel2 = New Library_Management.MyLabel()
		Me.MyLabel1 = New Library_Management.MyLabel()
		Me.CopiesLeft = New Library_Management.MyTextBox()
		Me.BookISBN = New Library_Management.MyTextBox()
		Me.BookAuthor = New Library_Management.MyTextBox()
		Me.BookName = New Library_Management.MyTextBox()
		Me.BookID = New Library_Management.MyTextBox()
		Me.MyMini1 = New Library_Management.MyMini()
		Me.MyClose1 = New Library_Management.MyClose()
		Me.Genre = New Library_Management.MyTextBox()
		Me.Label = New Library_Management.MyLabel()
		Me.FormSkin1.SuspendLayout()
		Me.SuspendLayout()
		'
		'FormSkin1
		'
		Me.FormSkin1.BackColor = System.Drawing.Color.White
		Me.FormSkin1.Controls.Add(Me.GoButton)
		Me.FormSkin1.Controls.Add(Me.Action)
		Me.FormSkin1.Controls.Add(Me.MyLabel5)
		Me.FormSkin1.Controls.Add(Me.Label)
		Me.FormSkin1.Controls.Add(Me.MyLabel4)
		Me.FormSkin1.Controls.Add(Me.MyLabel3)
		Me.FormSkin1.Controls.Add(Me.MyLabel2)
		Me.FormSkin1.Controls.Add(Me.MyLabel1)
		Me.FormSkin1.Controls.Add(Me.CopiesLeft)
		Me.FormSkin1.Controls.Add(Me.Genre)
		Me.FormSkin1.Controls.Add(Me.BookISBN)
		Me.FormSkin1.Controls.Add(Me.BookAuthor)
		Me.FormSkin1.Controls.Add(Me.BookName)
		Me.FormSkin1.Controls.Add(Me.BookID)
		Me.FormSkin1.Controls.Add(Me.MyMini1)
		Me.FormSkin1.Controls.Add(Me.MyClose1)
		Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
		Me.FormSkin1.Name = "FormSkin1"
		Me.FormSkin1.Size = New System.Drawing.Size(823, 479)
		Me.FormSkin1.TabIndex = 0
		Me.FormSkin1.Text = "Book Info"
		'
		'GoButton
		'
		Me.GoButton.BackColor = System.Drawing.Color.Transparent
		Me.GoButton.Cursor = System.Windows.Forms.Cursors.Hand
		Me.GoButton.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.GoButton.Location = New System.Drawing.Point(359, 411)
		Me.GoButton.Name = "GoButton"
		Me.GoButton.Size = New System.Drawing.Size(106, 32)
		Me.GoButton.TabIndex = 5
		Me.GoButton.Text = "Go"
		'
		'Action
		'
		Me.Action.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
		Me.Action.Cursor = System.Windows.Forms.Cursors.Hand
		Me.Action.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.Action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.Action.Font = New System.Drawing.Font("Segoe UI", 8.0!)
		Me.Action.ForeColor = System.Drawing.Color.White
		Me.Action.FormattingEnabled = True
		Me.Action.ItemHeight = 18
		Me.Action.Location = New System.Drawing.Point(325, 381)
		Me.Action.Name = "Action"
		Me.Action.Size = New System.Drawing.Size(175, 24)
		Me.Action.TabIndex = 4
		'
		'MyLabel5
		'
		Me.MyLabel5.AutoSize = True
		Me.MyLabel5.BackColor = System.Drawing.Color.Transparent
		Me.MyLabel5.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyLabel5.ForeColor = System.Drawing.Color.White
		Me.MyLabel5.Location = New System.Drawing.Point(250, 310)
		Me.MyLabel5.Name = "MyLabel5"
		Me.MyLabel5.Size = New System.Drawing.Size(87, 21)
		Me.MyLabel5.TabIndex = 3
		Me.MyLabel5.Text = "Copies Left"
		'
		'MyLabel4
		'
		Me.MyLabel4.AutoSize = True
		Me.MyLabel4.BackColor = System.Drawing.Color.Transparent
		Me.MyLabel4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyLabel4.ForeColor = System.Drawing.Color.White
		Me.MyLabel4.Location = New System.Drawing.Point(250, 240)
		Me.MyLabel4.Name = "MyLabel4"
		Me.MyLabel4.Size = New System.Drawing.Size(44, 21)
		Me.MyLabel4.TabIndex = 3
		Me.MyLabel4.Text = "ISBN"
		'
		'MyLabel3
		'
		Me.MyLabel3.AutoSize = True
		Me.MyLabel3.BackColor = System.Drawing.Color.Transparent
		Me.MyLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyLabel3.ForeColor = System.Drawing.Color.White
		Me.MyLabel3.Location = New System.Drawing.Point(250, 205)
		Me.MyLabel3.Name = "MyLabel3"
		Me.MyLabel3.Size = New System.Drawing.Size(97, 21)
		Me.MyLabel3.TabIndex = 3
		Me.MyLabel3.Text = "Book Author"
		'
		'MyLabel2
		'
		Me.MyLabel2.AutoSize = True
		Me.MyLabel2.BackColor = System.Drawing.Color.Transparent
		Me.MyLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyLabel2.ForeColor = System.Drawing.Color.White
		Me.MyLabel2.Location = New System.Drawing.Point(250, 170)
		Me.MyLabel2.Name = "MyLabel2"
		Me.MyLabel2.Size = New System.Drawing.Size(91, 21)
		Me.MyLabel2.TabIndex = 3
		Me.MyLabel2.Text = "Book Name"
		'
		'MyLabel1
		'
		Me.MyLabel1.AutoSize = True
		Me.MyLabel1.BackColor = System.Drawing.Color.Transparent
		Me.MyLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyLabel1.ForeColor = System.Drawing.Color.White
		Me.MyLabel1.Location = New System.Drawing.Point(250, 135)
		Me.MyLabel1.Name = "MyLabel1"
		Me.MyLabel1.Size = New System.Drawing.Size(64, 21)
		Me.MyLabel1.TabIndex = 3
		Me.MyLabel1.Text = "Book ID"
		'
		'CopiesLeft
		'
		Me.CopiesLeft.BackColor = System.Drawing.Color.Transparent
		Me.CopiesLeft.Location = New System.Drawing.Point(348, 306)
		Me.CopiesLeft.MaxLength = 32767
		Me.CopiesLeft.Multiline = False
		Me.CopiesLeft.Name = "CopiesLeft"
		Me.CopiesLeft.ReadOnly = True
		Me.CopiesLeft.Size = New System.Drawing.Size(225, 29)
		Me.CopiesLeft.TabIndex = 2
		Me.CopiesLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.CopiesLeft.UseSystemPasswordChar = False
		'
		'BookISBN
		'
		Me.BookISBN.BackColor = System.Drawing.Color.Transparent
		Me.BookISBN.Location = New System.Drawing.Point(348, 236)
		Me.BookISBN.MaxLength = 32767
		Me.BookISBN.Multiline = False
		Me.BookISBN.Name = "BookISBN"
		Me.BookISBN.ReadOnly = True
		Me.BookISBN.Size = New System.Drawing.Size(225, 29)
		Me.BookISBN.TabIndex = 2
		Me.BookISBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.BookISBN.UseSystemPasswordChar = False
		'
		'BookAuthor
		'
		Me.BookAuthor.BackColor = System.Drawing.Color.Transparent
		Me.BookAuthor.Location = New System.Drawing.Point(348, 201)
		Me.BookAuthor.MaxLength = 32767
		Me.BookAuthor.Multiline = False
		Me.BookAuthor.Name = "BookAuthor"
		Me.BookAuthor.ReadOnly = True
		Me.BookAuthor.Size = New System.Drawing.Size(225, 29)
		Me.BookAuthor.TabIndex = 2
		Me.BookAuthor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.BookAuthor.UseSystemPasswordChar = False
		'
		'BookName
		'
		Me.BookName.BackColor = System.Drawing.Color.Transparent
		Me.BookName.Location = New System.Drawing.Point(348, 166)
		Me.BookName.MaxLength = 32767
		Me.BookName.Multiline = False
		Me.BookName.Name = "BookName"
		Me.BookName.ReadOnly = True
		Me.BookName.Size = New System.Drawing.Size(225, 29)
		Me.BookName.TabIndex = 2
		Me.BookName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.BookName.UseSystemPasswordChar = False
		'
		'BookID
		'
		Me.BookID.BackColor = System.Drawing.Color.Transparent
		Me.BookID.Location = New System.Drawing.Point(348, 131)
		Me.BookID.MaxLength = 32767
		Me.BookID.Multiline = False
		Me.BookID.Name = "BookID"
		Me.BookID.ReadOnly = True
		Me.BookID.Size = New System.Drawing.Size(225, 29)
		Me.BookID.TabIndex = 2
		Me.BookID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.BookID.UseSystemPasswordChar = False
		'
		'MyMini1
		'
		Me.MyMini1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyMini1.BackColor = System.Drawing.Color.White
		Me.MyMini1.Font = New System.Drawing.Font("Marlett", 12.0!)
		Me.MyMini1.Location = New System.Drawing.Point(769, 12)
		Me.MyMini1.Name = "MyMini1"
		Me.MyMini1.Size = New System.Drawing.Size(18, 18)
		Me.MyMini1.TabIndex = 1
		Me.MyMini1.Text = "MyMini1"
		'
		'MyClose1
		'
		Me.MyClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyClose1.BackColor = System.Drawing.Color.White
		Me.MyClose1.Font = New System.Drawing.Font("Marlett", 10.0!)
		Me.MyClose1.Location = New System.Drawing.Point(793, 12)
		Me.MyClose1.Name = "MyClose1"
		Me.MyClose1.Size = New System.Drawing.Size(18, 18)
		Me.MyClose1.TabIndex = 0
		Me.MyClose1.Text = "MyClose1"
		'
		'Genre
		'
		Me.Genre.BackColor = System.Drawing.Color.Transparent
		Me.Genre.Location = New System.Drawing.Point(348, 271)
		Me.Genre.MaxLength = 32767
		Me.Genre.Multiline = False
		Me.Genre.Name = "Genre"
		Me.Genre.ReadOnly = True
		Me.Genre.Size = New System.Drawing.Size(225, 29)
		Me.Genre.TabIndex = 2
		Me.Genre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Genre.UseSystemPasswordChar = False
		'
		'Label
		'
		Me.Label.AutoSize = True
		Me.Label.BackColor = System.Drawing.Color.Transparent
		Me.Label.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.Label.ForeColor = System.Drawing.Color.White
		Me.Label.Location = New System.Drawing.Point(250, 275)
		Me.Label.Name = "Label"
		Me.Label.Size = New System.Drawing.Size(52, 21)
		Me.Label.TabIndex = 3
		Me.Label.Text = "Genre"
		'
		'ShowBookInfo
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(823, 479)
		Me.Controls.Add(Me.FormSkin1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "ShowBookInfo"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ShowBookInfo"
		Me.TransparencyKey = System.Drawing.Color.Fuchsia
		Me.FormSkin1.ResumeLayout(False)
		Me.FormSkin1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents FormSkin1 As FormSkin
	Friend WithEvents MyMini1 As MyMini
	Friend WithEvents MyClose1 As MyClose
	Friend WithEvents MyLabel5 As MyLabel
	Friend WithEvents MyLabel4 As MyLabel
	Friend WithEvents MyLabel3 As MyLabel
	Friend WithEvents MyLabel2 As MyLabel
	Friend WithEvents MyLabel1 As MyLabel
	Friend WithEvents CopiesLeft As MyTextBox
	Friend WithEvents BookISBN As MyTextBox
	Friend WithEvents BookAuthor As MyTextBox
	Friend WithEvents BookName As MyTextBox
	Friend WithEvents BookID As MyTextBox
	Friend WithEvents GoButton As MyButton
	Friend WithEvents Action As MyComboBox
	Friend WithEvents Label As MyLabel
	Friend WithEvents Genre As MyTextBox
End Class

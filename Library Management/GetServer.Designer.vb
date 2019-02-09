<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GetServer
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
		Me.MyAlertBox1 = New Library_Management.MyAlertBox()
		Me.MyLabel1 = New Library_Management.MyLabel()
		Me.MyTextBox1 = New Library_Management.MyTextBox()
		Me.MyButton1 = New Library_Management.MyButton()
		Me.MyClose1 = New Library_Management.MyClose()
		Me.FormSkin1.SuspendLayout()
		Me.SuspendLayout()
		'
		'FormSkin1
		'
		Me.FormSkin1.BackColor = System.Drawing.Color.White
		Me.FormSkin1.Controls.Add(Me.MyAlertBox1)
		Me.FormSkin1.Controls.Add(Me.MyLabel1)
		Me.FormSkin1.Controls.Add(Me.MyTextBox1)
		Me.FormSkin1.Controls.Add(Me.MyButton1)
		Me.FormSkin1.Controls.Add(Me.MyClose1)
		Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
		Me.FormSkin1.Name = "FormSkin1"
		Me.FormSkin1.Size = New System.Drawing.Size(578, 341)
		Me.FormSkin1.TabIndex = 0
		Me.FormSkin1.Text = "FormSkin1"
		'
		'MyAlertBox1
		'
		Me.MyAlertBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		Me.MyAlertBox1.Cursor = System.Windows.Forms.Cursors.Hand
		Me.MyAlertBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		Me.MyAlertBox1.Kind = Library_Management.MyAlertBox._Kind.Success
		Me.MyAlertBox1.Location = New System.Drawing.Point(3, 296)
		Me.MyAlertBox1.Name = "MyAlertBox1"
		Me.MyAlertBox1.Size = New System.Drawing.Size(572, 42)
		Me.MyAlertBox1.TabIndex = 4
		Me.MyAlertBox1.Text = "MyAlertBox1"
		Me.MyAlertBox1.Visible = False
		'
		'MyLabel1
		'
		Me.MyLabel1.BackColor = System.Drawing.Color.Transparent
		Me.MyLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyLabel1.ForeColor = System.Drawing.Color.White
		Me.MyLabel1.Location = New System.Drawing.Point(167, 83)
		Me.MyLabel1.Name = "MyLabel1"
		Me.MyLabel1.Size = New System.Drawing.Size(244, 64)
		Me.MyLabel1.TabIndex = 3
		Me.MyLabel1.Text = "Could not connect to SQL Server. Check your Server Name/IP"
		Me.MyLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'MyTextBox1
		'
		Me.MyTextBox1.BackColor = System.Drawing.Color.Transparent
		Me.MyTextBox1.Location = New System.Drawing.Point(180, 187)
		Me.MyTextBox1.MaxLength = 32767
		Me.MyTextBox1.Multiline = False
		Me.MyTextBox1.Name = "MyTextBox1"
		Me.MyTextBox1.ReadOnly = False
		Me.MyTextBox1.Size = New System.Drawing.Size(219, 29)
		Me.MyTextBox1.TabIndex = 2
		Me.MyTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.MyTextBox1.UseSystemPasswordChar = False
		'
		'MyButton1
		'
		Me.MyButton1.BackColor = System.Drawing.Color.Transparent
		Me.MyButton1.Cursor = System.Windows.Forms.Cursors.Hand
		Me.MyButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.MyButton1.Location = New System.Drawing.Point(236, 249)
		Me.MyButton1.Name = "MyButton1"
		Me.MyButton1.Size = New System.Drawing.Size(106, 32)
		Me.MyButton1.TabIndex = 1
		Me.MyButton1.Text = "OK"
		'
		'MyClose1
		'
		Me.MyClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyClose1.BackColor = System.Drawing.Color.White
		Me.MyClose1.Font = New System.Drawing.Font("Marlett", 10.0!)
		Me.MyClose1.Location = New System.Drawing.Point(548, 12)
		Me.MyClose1.Name = "MyClose1"
		Me.MyClose1.Size = New System.Drawing.Size(18, 18)
		Me.MyClose1.TabIndex = 0
		Me.MyClose1.Text = "MyClose1"
		'
		'GetServer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(578, 341)
		Me.Controls.Add(Me.FormSkin1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "GetServer"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "GetServer"
		Me.TransparencyKey = System.Drawing.Color.Fuchsia
		Me.FormSkin1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents FormSkin1 As FormSkin
	Friend WithEvents MyLabel1 As MyLabel
	Friend WithEvents MyTextBox1 As MyTextBox
	Friend WithEvents MyButton1 As MyButton
	Friend WithEvents MyClose1 As MyClose
	Friend WithEvents MyAlertBox1 As MyAlertBox
End Class

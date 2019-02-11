<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	_
	Partial Class Msg
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
		_
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
		<System.Diagnostics.DebuggerStepThrough()>
			_
			Private Sub InitializeComponent()
		Me.FormSkin1 = New Library_Management.FormSkin()
		Me.OK = New Library_Management.MyButton()
		Me.ErrorLabel = New Library_Management.MyLabel()
		Me.MyClose1 = New Library_Management.MyClose()
		Me.FormSkin1.SuspendLayout()
		Me.SuspendLayout()
		'
		'FormSkin1
		'
		Me.FormSkin1.BackColor = System.Drawing.Color.White
		Me.FormSkin1.Controls.Add(Me.OK)
		Me.FormSkin1.Controls.Add(Me.ErrorLabel)
		Me.FormSkin1.Controls.Add(Me.MyClose1)
		Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
		Me.FormSkin1.Name = "FormSkin1"
		Me.FormSkin1.Size = New System.Drawing.Size(638, 321)
		Me.FormSkin1.TabIndex = 0
		Me.FormSkin1.Text = "Error"
		'
		'OK
		'
		Me.OK.BackColor = System.Drawing.Color.Transparent
		Me.OK.Cursor = System.Windows.Forms.Cursors.Hand
		Me.OK.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.OK.Location = New System.Drawing.Point(557, 276)
		Me.OK.Name = "OK"
		Me.OK.Size = New System.Drawing.Size(69, 33)
		Me.OK.TabIndex = 2
		Me.OK.Text = "OK"
		'
		'ErrorLabel
		'
		Me.ErrorLabel.BackColor = System.Drawing.Color.Transparent
		Me.ErrorLabel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ErrorLabel.ForeColor = System.Drawing.Color.White
		Me.ErrorLabel.Location = New System.Drawing.Point(12, 66)
		Me.ErrorLabel.Name = "ErrorLabel"
		Me.ErrorLabel.Size = New System.Drawing.Size(614, 207)
		Me.ErrorLabel.TabIndex = 1
		Me.ErrorLabel.Text = "MyLabel1"
		Me.ErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'MyClose1
		'
		Me.MyClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyClose1.BackColor = System.Drawing.Color.White
		Me.MyClose1.Font = New System.Drawing.Font("Marlett", 10.0!)
		Me.MyClose1.Location = New System.Drawing.Point(608, 12)
		Me.MyClose1.Name = "MyClose1"
		Me.MyClose1.Size = New System.Drawing.Size(18, 18)
		Me.MyClose1.TabIndex = 0
		Me.MyClose1.Text = "MyClose1"
		'
		'Msg
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(638, 321)
		Me.Controls.Add(Me.FormSkin1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "Msg"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Msg"
		Me.TransparencyKey = System.Drawing.Color.Fuchsia
		Me.FormSkin1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents FormSkin1 As FormSkin
	Friend WithEvents OK As MyButton
	Friend WithEvents ErrorLabel As MyLabel
	Friend WithEvents MyClose1 As MyClose
End Class

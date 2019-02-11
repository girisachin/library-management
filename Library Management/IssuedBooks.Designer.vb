<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IssuedBooks
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	Private Sub InitializeComponent()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.FormSkin1 = New Library_Management.FormSkin()
		Me.IssuedBookDataGrid = New System.Windows.Forms.DataGridView()
		Me.MyClose1 = New Library_Management.MyClose()
		Me.MyMini1 = New Library_Management.MyMini()
		Me.FormSkin1.SuspendLayout()
		CType(Me.IssuedBookDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'FormSkin1
		'
		Me.FormSkin1.BackColor = System.Drawing.Color.White
		Me.FormSkin1.Controls.Add(Me.MyMini1)
		Me.FormSkin1.Controls.Add(Me.MyClose1)
		Me.FormSkin1.Controls.Add(Me.IssuedBookDataGrid)
		Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
		Me.FormSkin1.Name = "FormSkin1"
		Me.FormSkin1.Size = New System.Drawing.Size(800, 450)
		Me.FormSkin1.TabIndex = 0
		Me.FormSkin1.Text = "Issued Books"
		'
		'IssuedBookDataGrid
		'
		Me.IssuedBookDataGrid.AllowUserToAddRows = False
		Me.IssuedBookDataGrid.AllowUserToDeleteRows = False
		DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
		Me.IssuedBookDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.IssuedBookDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.IssuedBookDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
		Me.IssuedBookDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.IssuedBookDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
		Me.IssuedBookDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
		DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
		Me.IssuedBookDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.IssuedBookDataGrid.Cursor = System.Windows.Forms.Cursors.Default
		DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.DefaultCellStyle = DataGridViewCellStyle8
		Me.IssuedBookDataGrid.GridColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
		Me.IssuedBookDataGrid.Location = New System.Drawing.Point(0, 51)
		Me.IssuedBookDataGrid.Name = "IssuedBookDataGrid"
		DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
		Me.IssuedBookDataGrid.RowHeadersVisible = False
		DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.RowsDefaultCellStyle = DataGridViewCellStyle10
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		Me.IssuedBookDataGrid.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.RowTemplate.ReadOnly = True
		Me.IssuedBookDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.IssuedBookDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.IssuedBookDataGrid.ShowCellErrors = False
		Me.IssuedBookDataGrid.ShowEditingIcon = False
		Me.IssuedBookDataGrid.ShowRowErrors = False
		Me.IssuedBookDataGrid.Size = New System.Drawing.Size(800, 399)
		Me.IssuedBookDataGrid.TabIndex = 3
		'
		'MyClose1
		'
		Me.MyClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyClose1.BackColor = System.Drawing.Color.White
		Me.MyClose1.Font = New System.Drawing.Font("Marlett", 10.0!)
		Me.MyClose1.Location = New System.Drawing.Point(770, 12)
		Me.MyClose1.Name = "MyClose1"
		Me.MyClose1.Size = New System.Drawing.Size(18, 18)
		Me.MyClose1.TabIndex = 4
		Me.MyClose1.Text = "MyClose1"
		'
		'MyMini1
		'
		Me.MyMini1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyMini1.BackColor = System.Drawing.Color.White
		Me.MyMini1.Font = New System.Drawing.Font("Marlett", 12.0!)
		Me.MyMini1.Location = New System.Drawing.Point(746, 12)
		Me.MyMini1.Name = "MyMini1"
		Me.MyMini1.Size = New System.Drawing.Size(18, 18)
		Me.MyMini1.TabIndex = 5
		Me.MyMini1.Text = "MyMini1"
		'
		'IssuedBooks
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.FormSkin1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "IssuedBooks"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "IssuedBooks"
		Me.TransparencyKey = System.Drawing.Color.Fuchsia
		Me.FormSkin1.ResumeLayout(False)
		CType(Me.IssuedBookDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents FormSkin1 As FormSkin
	Friend WithEvents MyMini1 As MyMini
	Friend WithEvents MyClose1 As MyClose
	Friend WithEvents IssuedBookDataGrid As DataGridView
End Class

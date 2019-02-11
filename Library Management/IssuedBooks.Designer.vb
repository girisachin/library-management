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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.FormSkin1 = New Library_Management.FormSkin()
		Me.MyMini1 = New Library_Management.MyMini()
		Me.MyClose1 = New Library_Management.MyClose()
		Me.IssuedBookDataGrid = New System.Windows.Forms.DataGridView()
		Me.IssuedBooksContextMenu = New Library_Management.MyContextMenuStrip()
		Me.IssueSelectedBookToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyBookNameToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyISBNNumberToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyBookIDToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.FormSkin1.SuspendLayout()
		CType(Me.IssuedBookDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.IssuedBooksContextMenu.SuspendLayout()
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
		'IssuedBookDataGrid
		'
		Me.IssuedBookDataGrid.AllowUserToAddRows = False
		Me.IssuedBookDataGrid.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.IssuedBookDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.IssuedBookDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.IssuedBookDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
		Me.IssuedBookDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.IssuedBookDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
		Me.IssuedBookDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.IssuedBookDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.IssuedBookDataGrid.ContextMenuStrip = Me.IssuedBooksContextMenu
		Me.IssuedBookDataGrid.Cursor = System.Windows.Forms.Cursors.Default
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.DefaultCellStyle = DataGridViewCellStyle3
		Me.IssuedBookDataGrid.GridColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
		Me.IssuedBookDataGrid.Location = New System.Drawing.Point(0, 51)
		Me.IssuedBookDataGrid.Name = "IssuedBookDataGrid"
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
		Me.IssuedBookDataGrid.RowHeadersVisible = False
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.IssuedBookDataGrid.RowsDefaultCellStyle = DataGridViewCellStyle5
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
		'IssuedBooksContextMenu
		'
		Me.IssuedBooksContextMenu.Font = New System.Drawing.Font("Segoe UI", 8.0!)
		Me.IssuedBooksContextMenu.ForeColor = System.Drawing.Color.White
		Me.IssuedBooksContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
		Me.IssuedBooksContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IssueSelectedBookToolStrip, Me.CopyBookNameToolStrip, Me.CopyISBNNumberToolStrip, Me.CopyBookIDToolStrip})
		Me.IssuedBooksContextMenu.Name = "BrowseBooksContextMenu"
		Me.IssuedBooksContextMenu.ShowCheckMargin = True
		Me.IssuedBooksContextMenu.ShowImageMargin = False
		Me.IssuedBooksContextMenu.Size = New System.Drawing.Size(186, 92)
		'
		'IssueSelectedBookToolStrip
		'
		Me.IssueSelectedBookToolStrip.Name = "IssueSelectedBookToolStrip"
		Me.IssueSelectedBookToolStrip.Size = New System.Drawing.Size(185, 22)
		Me.IssueSelectedBookToolStrip.Text = "Return Selected Book"
		'
		'CopyBookNameToolStrip
		'
		Me.CopyBookNameToolStrip.Name = "CopyBookNameToolStrip"
		Me.CopyBookNameToolStrip.Size = New System.Drawing.Size(185, 22)
		Me.CopyBookNameToolStrip.Text = "Copy Book Name"
		'
		'CopyISBNNumberToolStrip
		'
		Me.CopyISBNNumberToolStrip.Name = "CopyISBNNumberToolStrip"
		Me.CopyISBNNumberToolStrip.Size = New System.Drawing.Size(185, 22)
		Me.CopyISBNNumberToolStrip.Text = "Copy ISBN Number"
		'
		'CopyBookIDToolStrip
		'
		Me.CopyBookIDToolStrip.Name = "CopyBookIDToolStrip"
		Me.CopyBookIDToolStrip.Size = New System.Drawing.Size(185, 22)
		Me.CopyBookIDToolStrip.Text = "Copy Book ID"
		'
		'IssuedBooks
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.FormSkin1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "IssuedBooks"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "IssuedBooks"
		Me.TransparencyKey = System.Drawing.Color.Fuchsia
		Me.FormSkin1.ResumeLayout(False)
		CType(Me.IssuedBookDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.IssuedBooksContextMenu.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents FormSkin1 As FormSkin
	Friend WithEvents MyMini1 As MyMini
	Friend WithEvents MyClose1 As MyClose
	Friend WithEvents IssuedBookDataGrid As DataGridView
	Friend WithEvents IssuedBooksContextMenu As MyContextMenuStrip
	Friend WithEvents IssueSelectedBookToolStrip As ToolStripMenuItem
	Friend WithEvents CopyBookNameToolStrip As ToolStripMenuItem
	Friend WithEvents CopyISBNNumberToolStrip As ToolStripMenuItem
	Friend WithEvents CopyBookIDToolStrip As ToolStripMenuItem
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BookList
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
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.FormSkin1 = New Library_Management.FormSkin()
		Me.SearchBookDataGrid = New System.Windows.Forms.DataGridView()
		Me.SearchBooksContextMenu = New Library_Management.MyContextMenuStrip()
		Me.IssueSelectedBookToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyBookNameToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyISBNNumberToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.CopyBookIDToolStrip = New System.Windows.Forms.ToolStripMenuItem()
		Me.MyMini1 = New Library_Management.MyMini()
		Me.MyClose1 = New Library_Management.MyClose()
		Me.FormSkin1.SuspendLayout()
		CType(Me.SearchBookDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SearchBooksContextMenu.SuspendLayout()
		Me.SuspendLayout()
		'
		'FormSkin1
		'
		Me.FormSkin1.BackColor = System.Drawing.Color.White
		Me.FormSkin1.Controls.Add(Me.SearchBookDataGrid)
		Me.FormSkin1.Controls.Add(Me.MyMini1)
		Me.FormSkin1.Controls.Add(Me.MyClose1)
		Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
		Me.FormSkin1.Margin = New System.Windows.Forms.Padding(2)
		Me.FormSkin1.Name = "FormSkin1"
		Me.FormSkin1.Size = New System.Drawing.Size(895, 537)
		Me.FormSkin1.TabIndex = 0
		Me.FormSkin1.Text = "Book List"
		'
		'SearchBookDataGrid
		'
		Me.SearchBookDataGrid.AllowUserToAddRows = False
		Me.SearchBookDataGrid.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SearchBookDataGrid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.SearchBookDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.SearchBookDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
		Me.SearchBookDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
		Me.SearchBookDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.SearchBookDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken
		Me.SearchBookDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SearchBookDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
		Me.SearchBookDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.SearchBookDataGrid.ContextMenuStrip = Me.SearchBooksContextMenu
		Me.SearchBookDataGrid.Cursor = System.Windows.Forms.Cursors.Default
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SearchBookDataGrid.DefaultCellStyle = DataGridViewCellStyle3
		Me.SearchBookDataGrid.GridColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
		Me.SearchBookDataGrid.Location = New System.Drawing.Point(0, 41)
		Me.SearchBookDataGrid.Name = "SearchBookDataGrid"
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
		DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SearchBookDataGrid.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
		Me.SearchBookDataGrid.RowHeadersVisible = False
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SearchBookDataGrid.RowsDefaultCellStyle = DataGridViewCellStyle5
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10.0!)
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
		Me.SearchBookDataGrid.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
		Me.SearchBookDataGrid.RowTemplate.ReadOnly = True
		Me.SearchBookDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.SearchBookDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.SearchBookDataGrid.ShowCellErrors = False
		Me.SearchBookDataGrid.ShowEditingIcon = False
		Me.SearchBookDataGrid.ShowRowErrors = False
		Me.SearchBookDataGrid.Size = New System.Drawing.Size(895, 496)
		Me.SearchBookDataGrid.TabIndex = 2
		'
		'SearchBooksContextMenu
		'
		Me.SearchBooksContextMenu.Font = New System.Drawing.Font("Segoe UI", 8.0!)
		Me.SearchBooksContextMenu.ForeColor = System.Drawing.Color.White
		Me.SearchBooksContextMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
		Me.SearchBooksContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IssueSelectedBookToolStrip, Me.CopyBookNameToolStrip, Me.CopyISBNNumberToolStrip, Me.CopyBookIDToolStrip})
		Me.SearchBooksContextMenu.Name = "BrowseBooksContextMenu"
		Me.SearchBooksContextMenu.ShowCheckMargin = True
		Me.SearchBooksContextMenu.ShowImageMargin = False
		Me.SearchBooksContextMenu.Size = New System.Drawing.Size(177, 92)
		'
		'IssueSelectedBookToolStrip
		'
		Me.IssueSelectedBookToolStrip.Name = "IssueSelectedBookToolStrip"
		Me.IssueSelectedBookToolStrip.Size = New System.Drawing.Size(176, 22)
		Me.IssueSelectedBookToolStrip.Text = "Issue Selected Book"
		'
		'CopyBookNameToolStrip
		'
		Me.CopyBookNameToolStrip.Name = "CopyBookNameToolStrip"
		Me.CopyBookNameToolStrip.Size = New System.Drawing.Size(176, 22)
		Me.CopyBookNameToolStrip.Text = "Copy Book Name"
		'
		'CopyISBNNumberToolStrip
		'
		Me.CopyISBNNumberToolStrip.Name = "CopyISBNNumberToolStrip"
		Me.CopyISBNNumberToolStrip.Size = New System.Drawing.Size(176, 22)
		Me.CopyISBNNumberToolStrip.Text = "Copy ISBN Number"
		'
		'CopyBookIDToolStrip
		'
		Me.CopyBookIDToolStrip.Name = "CopyBookIDToolStrip"
		Me.CopyBookIDToolStrip.Size = New System.Drawing.Size(176, 22)
		Me.CopyBookIDToolStrip.Text = "Copy Book ID"
		'
		'MyMini1
		'
		Me.MyMini1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.MyMini1.BackColor = System.Drawing.Color.White
		Me.MyMini1.Font = New System.Drawing.Font("Marlett", 12.0!)
		Me.MyMini1.Location = New System.Drawing.Point(844, 11)
		Me.MyMini1.Margin = New System.Windows.Forms.Padding(2)
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
		Me.MyClose1.Location = New System.Drawing.Point(866, 11)
		Me.MyClose1.Margin = New System.Windows.Forms.Padding(2)
		Me.MyClose1.Name = "MyClose1"
		Me.MyClose1.Size = New System.Drawing.Size(18, 18)
		Me.MyClose1.TabIndex = 0
		Me.MyClose1.Text = "MyClose1"
		'
		'BookList
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(895, 537)
		Me.Controls.Add(Me.FormSkin1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Margin = New System.Windows.Forms.Padding(2)
		Me.Name = "BookList"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "BookList"
		Me.TransparencyKey = System.Drawing.Color.Fuchsia
		Me.FormSkin1.ResumeLayout(False)
		CType(Me.SearchBookDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SearchBooksContextMenu.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents FormSkin1 As Library_Management.FormSkin
    Friend WithEvents MyMini1 As Library_Management.MyMini
    Friend WithEvents MyClose1 As Library_Management.MyClose
    Friend WithEvents SearchBookDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents SearchBooksContextMenu As Library_Management.MyContextMenuStrip
    Friend WithEvents IssueSelectedBookToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyBookNameToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyISBNNumberToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyBookIDToolStrip As System.Windows.Forms.ToolStripMenuItem
End Class

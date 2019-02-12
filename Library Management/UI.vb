Imports System.Drawing.Drawing2D, System.ComponentModel, System.Windows.Forms
Module Faltu_Ke_Variables_Jo_Shayad_Kabhi_Kaam_Bhi_Na_Aaye
	Friend G As Graphics, B As Bitmap
	Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
	Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
	Friend AlertSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}
	Friend Color1 As Color = Color.FromArgb(60, 70, 73)
	Friend Color2 As Color = Color.FromArgb(45, 47, 49)
	Friend Color3 As Color = Color.FromArgb(168, 35, 35)
	Friend Color4 As Color = Color.FromArgb(243, 243, 243)
	Friend Color5 As Color = Color.FromArgb(53, 58, 60)
	Friend Color6 As Color = Color.FromArgb(35, 168, 109)
	Friend Color7 As Color = Color.FromArgb(67, 109, 200)
	Friend Color8 As Color = Color.FromArgb(0, 122, 204)
	Friend Color9 As Color = Color.FromArgb(192, 192, 192)
	Friend Color10 As Color = Color.FromArgb(60, 85, 79)
	Friend Color11 As Color = Color.FromArgb(35, 169, 110)
	Friend Color12 As Color = Color.FromArgb(87, 71, 71)
	Friend Color13 As Color = Color.FromArgb(254, 142, 122)
	Friend Color14 As Color = Color.FromArgb(70, 91, 94)
	Friend Color15 As Color = Color.FromArgb(97, 185, 186)
	Friend Color16 As Color = Color.FromArgb(25, 27, 29)
	Friend Color17 As Color = Color.FromArgb(45, 45, 48)
	Friend Color18 As Color = Color.FromArgb(35, 37, 39)
	Friend Color19 As Color = Color.FromArgb(220, 85, 96)
End Module

Enum MouseState As Byte
	None = 0
	Over = 1
	Down = 2
	Block = 3
End Enum

Class FormSkin : Inherits ContainerControl

	Private W, H As Integer
	Private Cap As Boolean = False
	Private MousePoint As New Point(0, 0)


	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, 50).Contains(e.Location) Then
			Cap = True
			MousePoint = e.Location
		End If
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e) : Cap = False
	End Sub
	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		MyBase.OnMouseMove(e)
		If Cap Then
			Parent.Location = MousePosition - MousePoint
		End If
	End Sub
	Protected Overrides Sub OnCreateControl()
		MyBase.OnCreateControl()
		ParentForm.FormBorderStyle = FormBorderStyle.None
		ParentForm.AllowTransparency = False
		ParentForm.TransparencyKey = Color.Fuchsia
		ParentForm.FindForm.StartPosition = FormStartPosition.CenterScreen
		Dock = DockStyle.Fill
		Invalidate()
	End Sub

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
		DoubleBuffered = True
		BackColor = Color.White
		Font = New Font("Segoe UI", 12)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width : H = Height
		Dim Base As New Rectangle(0, 0, W, H), Header As New Rectangle(0, 0, W, 50)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			'  Base
			.FillRectangle(New SolidBrush(Color1), Base)
			'  Header
			.FillRectangle(New SolidBrush(Color18), Header)
			'  Logo
			.FillRectangle(New SolidBrush(Color3), New Rectangle(8, 16, 4, 18))
			.FillRectangle(New SolidBrush(Color4), New Rectangle(16, 16, 4, 18))
			.FillRectangle(New SolidBrush(Color6), 24, 16, 4, 18)
			.DrawString(Text, Font, New SolidBrush(Color4), New Rectangle(34, 15, W, H), NearSF)
			'  Border
			.DrawRectangle(New Pen(Color5), Base)
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyClose : Inherits Control

	Private State As MouseState = MouseState.None
	Private x As Integer
	Protected Overrides Sub OnMouseEnter(e As EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		MyBase.OnMouseMove(e)
		x = e.X : Invalidate()
	End Sub
	Protected Overrides Sub OnClick(e As EventArgs)
		FindForm.Close()
		MyBase.OnClick(e)
	End Sub

	Protected Overrides Sub OnResize(e As EventArgs)
		MyBase.OnResize(e)
		Size = New Size(18, 18)
	End Sub

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
		DoubleBuffered = True
		BackColor = Color.White
		Size = New Size(18, 18)
		Anchor = AnchorStyles.Top Or AnchorStyles.Right
		Font = New Font("Marlett", 10)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		Dim B As New Bitmap(Width, Height)
		Dim G As Graphics = Graphics.FromImage(B)
		Dim Base As New Rectangle(0, 0, Width, Height)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			'  Base
			.FillRectangle(New SolidBrush(Color3), Base)
			'  X
			.DrawString("r", Font, New SolidBrush(Color4), New Rectangle(0, 0, Width - 1, Height), CenterSF)
			'  Hover/down
			Select Case State
				Case MouseState.Over
					.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.White)), Base)
				Case MouseState.Down
					.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), Base)
			End Select
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyMini : Inherits Control

	Private State As MouseState = MouseState.None
	Private x As Integer
	Protected Overrides Sub OnMouseEnter(e As EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		MyBase.OnMouseMove(e)
		x = e.X : Invalidate()
	End Sub
	Protected Overrides Sub OnClick(e As EventArgs)
		MyBase.OnClick(e)
		Select Case FindForm.WindowState
			Case FormWindowState.Normal
				FindForm.WindowState = FormWindowState.Minimized
			Case FormWindowState.Maximized
				FindForm.WindowState = FormWindowState.Minimized
		End Select
	End Sub

	Protected Overrides Sub OnResize(e As EventArgs)
		MyBase.OnResize(e)
		Size = New Size(18, 18)
	End Sub

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
		DoubleBuffered = True
		BackColor = Color.White
		Size = New Size(18, 18)
		Anchor = AnchorStyles.Top Or AnchorStyles.Right
		Font = New Font("Marlett", 12)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		Dim B As New Bitmap(Width, Height)
		Dim G As Graphics = Graphics.FromImage(B)
		Dim Base As New Rectangle(0, 0, Width, Height)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			'  Base
			.FillRectangle(New SolidBrush(Color8), Base)
			'  Minimize
			.DrawString("0", Font, New SolidBrush(Color4), New Rectangle(2, 1, Width, Height), CenterSF)
			'  Hover/down
			Select Case State
				Case MouseState.Over
					.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.White)), Base)
				Case MouseState.Down
					.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), Base)
			End Select
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyButton : Inherits Control

	Private W, H As Integer
	Private State As MouseState = MouseState.None


	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseEnter(e As EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub


	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
		DoubleBuffered = True
		Size = New Size(106, 32)
		BackColor = Color.Transparent
		Font = New Font("Segoe UI", 12)
		Cursor = Cursors.Hand
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width - 1 : H = Height - 1
		Dim GP As New GraphicsPath
		Dim Base As New Rectangle(0, 0, W, H)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			Select Case State
				Case MouseState.None
					'  Base
					.FillRectangle(New SolidBrush(Color6), Base)
					'  Text
					.DrawString(Text, Font, New SolidBrush(Color4), Base, CenterSF)
				Case MouseState.Over
					'  Base
					.FillRectangle(New SolidBrush(Color6), Base)
					.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), Base)
					'  Text
					.DrawString(Text, Font, New SolidBrush(Color4), Base, CenterSF)
				Case MouseState.Down
					'  Base
					.FillRectangle(New SolidBrush(Color6), Base)
					.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), Base)
					'  Text
					.DrawString(Text, Font, New SolidBrush(Color4), Base, CenterSF)
			End Select
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
<DefaultEvent("TextChanged")> Class MyTextBox : Inherits Control

	Private W, H As Integer
	Private State As MouseState = MouseState.None
	Private WithEvents TB As Windows.Forms.TextBox
	Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left


	<Category("Options")>
	Property TextAlign() As HorizontalAlignment
		Get
			Return _TextAlign
		End Get
		Set(ByVal value As HorizontalAlignment)
			_TextAlign = value
			If TB IsNot Nothing Then
				TB.TextAlign = value
			End If
		End Set
	End Property
	Private _MaxLength As Integer = 32767
	<Category("Options")>
	Property MaxLength() As Integer
		Get
			Return _MaxLength
		End Get
		Set(ByVal value As Integer)
			_MaxLength = value
			If TB IsNot Nothing Then
				TB.MaxLength = value
			End If
		End Set
	End Property
	Private _ReadOnly As Boolean
	<Category("Options")>
	Property [ReadOnly]() As Boolean
		Get
			Return _ReadOnly
		End Get
		Set(ByVal value As Boolean)
			_ReadOnly = value
			If TB IsNot Nothing Then
				TB.ReadOnly = value
			End If
		End Set
	End Property
	Private _UseSystemPasswordChar As Boolean
	<Category("Options")>
	Property UseSystemPasswordChar() As Boolean
		Get
			Return _UseSystemPasswordChar
		End Get
		Set(ByVal value As Boolean)
			_UseSystemPasswordChar = value
			If TB IsNot Nothing Then
				TB.UseSystemPasswordChar = value
			End If
		End Set
	End Property
	Private _Multiline As Boolean
	<Category("Options")>
	Property Multiline() As Boolean
		Get
			Return _Multiline
		End Get
		Set(ByVal value As Boolean)
			_Multiline = value
			If TB IsNot Nothing Then
				TB.Multiline = value
				If value Then
					TB.Height = Height - 11
				Else
					Height = TB.Height + 11
				End If
			End If
		End Set
	End Property
	<Category("Options")>
	Overrides Property Text As String
		Get
			Return MyBase.Text
		End Get
		Set(ByVal value As String)
			MyBase.Text = value
			If TB IsNot Nothing Then
				TB.Text = value
			End If
		End Set
	End Property
	<Category("Options")>
	Overrides Property Font As Font
		Get
			Return MyBase.Font
		End Get
		Set(ByVal value As Font)
			MyBase.Font = value
			If TB IsNot Nothing Then
				TB.Font = value
				TB.Location = New Point(3, 5)
				TB.Width = Width - 6
				If Not _Multiline Then
					Height = TB.Height + 11
				End If
			End If
		End Set
	End Property
	Protected Overrides Sub OnCreateControl()
		MyBase.OnCreateControl()
		If Not Controls.Contains(TB) Then
			Controls.Add(TB)
		End If
	End Sub
	Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
		Text = TB.Text
	End Sub
	Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
		If e.Control AndAlso e.KeyCode = Keys.A Then
			TB.SelectAll()
			e.SuppressKeyPress = True
		End If
		If e.Control AndAlso e.KeyCode = Keys.C Then
			TB.Copy()
			e.SuppressKeyPress = True
		End If
	End Sub
	Protected Overrides Sub OnResize(ByVal e As EventArgs)
		TB.Location = New Point(5, 5)
		TB.Width = Width - 10
		If _Multiline Then
			TB.Height = Height - 11
		Else
			Height = TB.Height + 11
		End If
		MyBase.OnResize(e)
	End Sub


	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : TB.Focus() : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseEnter(e As EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : TB.Focus() : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub


	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
		DoubleBuffered = True
		BackColor = Color.Transparent
		TB = New TextBox With {
			.Font = New Font("Segoe UI", 10),
			.Text = Text,
			.BackColor = Color2,
			.ForeColor = Color9,
			.MaxLength = _MaxLength,
			.Multiline = _Multiline,
			.ReadOnly = _ReadOnly,
			.UseSystemPasswordChar = _UseSystemPasswordChar,
			.BorderStyle = BorderStyle.None,
			.Location = New Point(5, 5),
			.Width = Width - 10,
			.Cursor = Cursors.IBeam
		}
		If _Multiline Then
			TB.Height = Height - 11
		Else
			Height = TB.Height + 11
		End If
		AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
		AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width - 1 : H = Height - 1
		Dim Base As New Rectangle(0, 0, W, H)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			'  Colors
			TB.BackColor = Color2
			TB.ForeColor = Color9
			'  Base
			.FillRectangle(New SolidBrush(Color2), Base)
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyTabControl : Inherits TabControl

	Private W, H As Integer


	Protected Overrides Sub CreateHandle()
		MyBase.CreateHandle()
		Alignment = TabAlignment.Top
	End Sub

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
		DoubleBuffered = True
		BackColor = Color1
		Font = New Font("Segoe UI", 10)
		SizeMode = TabSizeMode.Fixed
		ItemSize = New Size(120, 40)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width - 1 : H = Height - 1
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(Color2)
			Try : SelectedTab.BackColor = Color1 : Catch : End Try
			For i = 0 To TabCount - 1
				Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
				Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height))
				If i = SelectedIndex Then
					'  Base
					.FillRectangle(New SolidBrush(Color2), BaseSize)
					'  Gradiant
					'.fill
					.FillRectangle(New SolidBrush(Color6), BaseSize)
					'  ImageList
					If ImageList IsNot Nothing Then
						Try
							If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
								'  Image
								.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
								'  Text
								.DrawString("      " & TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
							Else
								'  Text
								.DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
							End If
						Catch ex As Exception
							Throw New Exception(ex.Message)
						End Try
					Else
						'  Text
						.DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
					End If
				Else
					'  Base
					.FillRectangle(New SolidBrush(Color2), BaseSize)
					'  ImageList
					If ImageList IsNot Nothing Then
						Try
							If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
								'  Image
								.DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
								'  Text
								.DrawString("      " & TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
							Else
								'  Text
								.DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
							End If
						Catch ex As Exception
							Throw New Exception(ex.Message)
						End Try
					Else
						'  Text
						.DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
					End If
				End If
			Next
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyAlertBox : Inherits Control

	Private W, H As Integer
	Private K As _Kind
	Private _Text As String
	Private State As MouseState = MouseState.None
	Private X As Integer
	Private WithEvents T As Timer


	<Flags()>
	Enum _Kind
		[Success]
		[Error]
		[Info]
	End Enum

	<Category("Options")>
	Public Property Kind As _Kind
		Get
			Return K
		End Get
		Set(value As _Kind)
			K = value
		End Set
	End Property
	<Category("Options")>
	Overrides Property Text As String
		Get
			Return MyBase.Text
		End Get
		Set(ByVal value As String)
			MyBase.Text = value
			If _Text IsNot Nothing Then
				_Text = value
			End If
		End Set
	End Property
	<Category("Options")>
	Shadows Property Visible As Boolean
		Get
			Return MyBase.Visible = False
		End Get
		Set(value As Boolean)
			MyBase.Visible = value
		End Set
	End Property

	Protected Overrides Sub OnTextChanged(e As EventArgs)
		MyBase.OnTextChanged(e) : Invalidate()
	End Sub
	Protected Overrides Sub OnResize(e As EventArgs)
		MyBase.OnResize(e)
		Height = 42
	End Sub
	Public Sub ShowControl(Kind As _Kind, Str As String, Interval As Integer)
		K = Kind
		Text = Str
		Me.Visible = True
		T = New Timer With {
			.Interval = Interval,
			.Enabled = True
		}
	End Sub
	Private Sub T_Tick(sender As Object, e As EventArgs) Handles T.Tick
		Me.Visible = False
		T.Enabled = False
		T.Dispose()
	End Sub

	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseEnter(e As EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		MyBase.OnMouseMove(e)
		X = e.X : Invalidate()
	End Sub
	Protected Overrides Sub OnClick(e As EventArgs)
		MyBase.OnClick(e)
		Me.Visible = False
	End Sub


	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width - 1 : H = Height - 1
		Dim Base As New Rectangle(0, 0, W, H)
		With G
			.SmoothingMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			Select Case K
				Case _Kind.Success
					'  Base
					.FillRectangle(New SolidBrush(Color10), Base)
					'  Ellipse
					.FillEllipse(New SolidBrush(Color11), New Rectangle(8, 9, 24, 24))
					.FillEllipse(New SolidBrush(Color10), New Rectangle(10, 11, 20, 20))
					'  Checked Sign
					.DrawString("ü", New Font("Wingdings", 22), New SolidBrush(Color11), New Rectangle(7, 7, W, H), NearSF)
					.DrawString(Text, Font, New SolidBrush(Color11), New Rectangle(48, 12, W - 72, H), AlertSF)
					'  X button
					.FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 30, H - 29, 17, 17))
					.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color10), New Rectangle(W - 28, 16, W, H), NearSF)
					Select Case State ' -- Mouse Over
						Case MouseState.Over
							.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 28, 16, W, H), NearSF)
					End Select
				Case _Kind.Error
					'  Base
					.FillRectangle(New SolidBrush(Color12), Base)
					'  Ellipse
					.FillEllipse(New SolidBrush(Color13), New Rectangle(8, 9, 24, 24))
					.FillEllipse(New SolidBrush(Color12), New Rectangle(10, 11, 20, 20))
					'  X Sign
					.DrawString("r", New Font("Marlett", 16), New SolidBrush(Color13), New Rectangle(6, 11, W, H), NearSF)
					.DrawString(Text, Font, New SolidBrush(Color13), New Rectangle(48, 12, W - 72, H), AlertSF)
					'  X button
					.FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 32, H - 29, 17, 17))
					.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color12), New Rectangle(W - 30, 17, W, H), NearSF)
					Select Case State
						Case MouseState.Over ' -- Mouse Over
							.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 30, 15, W, H), NearSF)
					End Select
				Case _Kind.Info
					'  Base
					.FillRectangle(New SolidBrush(Color14), Base)
					'  Ellipse
					.FillEllipse(New SolidBrush(Color15), New Rectangle(8, 9, 24, 24))
					.FillEllipse(New SolidBrush(Color14), New Rectangle(10, 11, 20, 20))
					'  Info Sign
					.DrawString("¡", New Font("Segoe UI", 20, FontStyle.Bold), New SolidBrush(Color15), New Rectangle(12, -4, W, H), NearSF)
					.DrawString(Text, Font, New SolidBrush(Color15), New Rectangle(48, 12, W - 72, H), AlertSF)
					'  X button
					.FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 32, H - 29, 17, 17))
					.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color14), New Rectangle(W - 30, 17, W, H), NearSF)
					Select Case State
						Case MouseState.Over ' -- Mouse Over
							.DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 30, 17, W, H), NearSF)
					End Select
			End Select
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyComboBox : Inherits Windows.Forms.ComboBox
	Private W, H As Integer
	Private x, y As Integer
	Private State As MouseState = MouseState.None
	Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseEnter(e As EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(e As EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		MyBase.OnMouseMove(e)
			Cursor = Cursors.Hand
	End Sub
	Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
		MyBase.OnDrawItem(e) : Invalidate()
		If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			Invalidate()
		End If
	End Sub
	Protected Overrides Sub OnClick(e As EventArgs)
		MyBase.OnClick(e) : Invalidate()
	End Sub

	Sub DrawItem_(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
		If e.Index < 0 Then Exit Sub
		e.DrawBackground()
		e.DrawFocusRectangle()
		e.Graphics.SmoothingMode = 2
		e.Graphics.PixelOffsetMode = 2
		e.Graphics.TextRenderingHint = 5
		e.Graphics.InterpolationMode = 7
		If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
			'  Selected item
			e.Graphics.FillRectangle(New SolidBrush(Color6), e.Bounds)
		Else
			'  Not Selected
			e.Graphics.FillRectangle(New SolidBrush(Color16), e.Bounds)
		End If
		'  Text
		e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), New Font("Segoe UI", 8),
					 Brushes.White, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height))
		e.Graphics.Dispose()
	End Sub
	Protected Overrides Sub OnResize(e As EventArgs)
		MyBase.OnResize(e)
		Height = 18
	End Sub

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
		DoubleBuffered = True
		DrawMode = DrawMode.OwnerDrawFixed
		BackColor = Color17
		ForeColor = Color.White
		DropDownStyle = ComboBoxStyle.DropDownList
		Cursor = Cursors.Hand
		ItemHeight = 18
		Font = New Font("Segoe UI", 8, FontStyle.Regular)
	End Sub
	Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width : H = Height
		Dim Base As New Rectangle(0, 0, W, H)
		Dim Button As New Rectangle(CInt(W - 40), 0, W, H)
		Dim GP, GP2 As New GraphicsPath
		With G
			.Clear(Color17)
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			'  Base
			.FillRectangle(New SolidBrush(Color2), Base)
			'  Button
			GP.Reset()
			GP.AddRectangle(Button)
			.SetClip(GP)
			.FillRectangle(New SolidBrush(Color16), Button)
			.ResetClip()
			'  Lines
			.DrawLine(Pens.White, W - 10, 6, W - 30, 6)
			.DrawLine(Pens.White, W - 10, 12, W - 30, 12)
			.DrawLine(Pens.White, W - 10, 18, W - 30, 18)
			'  Text
			.DrawString(Text, Font, Brushes.White, New Point(4, 6), NearSF)
		End With
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyGroupBox : Inherits ContainerControl

	Private W, H As Integer

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
		DoubleBuffered = True
		BackColor = Color.Transparent
		Size = New Size(240, 180)
		Font = New Font("Segoe ui", 10)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width : H = Height
		Dim GP, GP2, GP3 As New GraphicsPath
		Dim Base As New Rectangle(3, 3, W - 6, H - 6)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			.FillRectangle(New SolidBrush(Color1), Base)
			'  ShowText
			.DrawString(Text, Font, New SolidBrush(Color6), New Rectangle(16, 16, W, H), NearSF)
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyContextMenuStrip : Inherits ContextMenuStrip
	Protected Overrides Sub OnTextChanged(e As EventArgs)
		MyBase.OnTextChanged(e) : Invalidate()
	End Sub
	Sub New()
		MyBase.New()
		Renderer = New ToolStripProfessionalRenderer(New TColorTable())
		ShowImageMargin = False
		ForeColor = Color.White
		Font = New Font("Segoe UI", 8)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		MyBase.OnPaint(e)
		e.Graphics.TextRenderingHint = 5
	End Sub
	Class TColorTable : Inherits ProfessionalColorTable

		Public Overrides ReadOnly Property ButtonSelectedBorder As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property CheckBackground() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property CheckPressedBackground() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property CheckSelectedBackground() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property MenuBorder() As Color
			Get
				Return Color5
			End Get
		End Property
		Public Overrides ReadOnly Property MenuItemBorder() As Color
			Get
				Return Color5
			End Get
		End Property
		Public Overrides ReadOnly Property MenuItemSelected() As Color
			Get
				Return Color6
			End Get
		End Property
		Public Overrides ReadOnly Property SeparatorDark() As Color
			Get
				Return Color2
			End Get
		End Property
		Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
			Get
				Return Color2
			End Get
		End Property

	End Class
End Class
Class MyStatusBar : Inherits Control

	Private W, H As Integer


	Protected Overrides Sub CreateHandle()
		MyBase.CreateHandle()
		Dock = DockStyle.Bottom
	End Sub
	Protected Overrides Sub OnTextChanged(e As EventArgs)
		MyBase.OnTextChanged(e) : Invalidate()
	End Sub
	Function GetTimeDate() As String
		Return DateTime.Now.Date & " " & DateTime.Now.ToString("HH:mm")
	End Function

	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
		DoubleBuffered = True
		Font = New Font("Segoe UI", 8)
		ForeColor = Color.White
		Size = New Size(Width, 20)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width : H = Height
		Dim Base As New Rectangle(0, 0, W, H)
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(Color18)
			'  Base
			.FillRectangle(New SolidBrush(Color18), Base)
			'  Text
			.DrawString(Text, Font, Brushes.White, New Rectangle(10, 4, W, H), NearSF)
			'  Rectangle
			.FillRectangle(New SolidBrush(Color6), New Rectangle(4, 4, 4, 14))
			'  TimeDate
			.DrawString(GetTimeDate, Font, New SolidBrush(Color.White), New Rectangle(-4, -2, W, H), New StringFormat() _
							With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Far})
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class
Class MyLabel : Inherits Label
	Protected Overrides Sub OnTextChanged(e As EventArgs)
		MyBase.OnTextChanged(e) : Invalidate()
	End Sub
	Sub New()
		SetStyle(ControlStyles.SupportsTransparentBackColor, True)
		Font = New Font("Segoe UI", 8)
		ForeColor = Color.White
		BackColor = Color.Transparent
		Text = Text
	End Sub


End Class
<DefaultEvent("CheckedChanged")> Class MyToggle : Inherits Control
	Private W, H As Integer
	Private _Checked As Boolean = True
	Private State As MouseState = MouseState.None
	Public Event CheckedChanged(ByVal sender As Object)
	<Category("Options")>
	Public Property Checked As Boolean
		Get
			Return _Checked
		End Get
		Set(value As Boolean)
			_Checked = value
		End Set
	End Property
	Protected Overrides Sub OnTextChanged(e As EventArgs)
		MyBase.OnTextChanged(e) : Invalidate()
	End Sub
	Protected Overrides Sub OnResize(e As EventArgs)
		MyBase.OnResize(e)
		Width = 76
		Height = 33
	End Sub
	Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
		MyBase.OnMouseEnter(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
		MyBase.OnMouseDown(e)
		State = MouseState.Down : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
		MyBase.OnMouseLeave(e)
		State = MouseState.None : Invalidate()
	End Sub
	Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
		MyBase.OnMouseUp(e)
		State = MouseState.Over : Invalidate()
	End Sub
	Protected Overrides Sub OnClick(e As EventArgs)
		MyBase.OnClick(e)
		_Checked = Not _Checked
		RaiseEvent CheckedChanged(Me)
	End Sub
	Sub New()
		SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor, True)
		DoubleBuffered = True
		BackColor = Color.Transparent
		Cursor = Cursors.Hand
		Font = New Font("Segoe UI", 10)
		Size = New Size(76, 33)
	End Sub
	Protected Overrides Sub OnPaint(e As PaintEventArgs)
		B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
		W = Width - 1 : H = Height - 1
		Dim GP, GP2 As New GraphicsPath
		Dim Base As New Rectangle(0, 0, W, H)
		Dim Toggle As Rectangle
		With G
			.SmoothingMode = 2
			.PixelOffsetMode = 2
			.TextRenderingHint = 5
			.Clear(BackColor)
			If _Checked = False Then
				Toggle = New Rectangle(W - 28, 4, 22, H - 8)
				.FillRectangle(New SolidBrush(Color2), Base)
				.FillRectangle(New SolidBrush(Color19), Toggle)
				'-- Text
				.DrawString("OFF", Font, New SolidBrush(Color19), New Rectangle(-12, 2, W, H), CenterSF)
			Else
				Toggle = New Rectangle(6, 4, 22, H - 8)
				.FillRectangle(New SolidBrush(Color2), Base)
				.FillRectangle(New SolidBrush(Color6), Toggle)
				'-- Text
				.DrawString("ON", Font, New SolidBrush(Color6), New Rectangle(12, 2, W, H), CenterSF)
			End If
		End With
		MyBase.OnPaint(e)
		G.Dispose()
		e.Graphics.InterpolationMode = 7
		e.Graphics.DrawImageUnscaled(B, 0, 0)
		B.Dispose()
	End Sub
End Class

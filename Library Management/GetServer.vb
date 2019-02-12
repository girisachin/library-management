Public Class GetServer
	Private Sub GetServer_Load(sender As Object, e As EventArgs) Handles Me.Load
		' get saved ip
		MyTextBox1.Text = My.Settings.server.ToString
	End Sub

	Private Sub MyButton1_Click(sender As Object, e As EventArgs) Handles MyButton1.Click
		' change server ip
		For Each C As Char In MyTextBox1.Text
			If AscW("0") <= AscW(C) AndAlso AscW(C) <= AscW("9") Then
				Continue For
			ElseIf AscW("a") <= AscW(C) AndAlso AscW(C) <= AscW("z") Then
				Continue For
			ElseIf AscW("A") <= AscW(C) AndAlso AscW(C) <= AscW("Z") Then
				Continue For
			ElseIf AscW("_") = AscW(C) Or AscW(".") = AscW(C) Or AscW(C) = AscW("%") Or AscW(C) = AscW("/") Then
				Continue For
			Else
				MyAlertBox1.ShowControl(MyAlertBox._Kind.Error, "Incorrect Server Name", 2000)
				Exit Sub
			End If
		Next
		My.Settings.server = MyTextBox1.Text
		My.Settings.Save()
		Me.Close()
	End Sub

	Private Sub MyButton2_Click(sender As Object, e As EventArgs) Handles MyButton2.Click
		Environment.Exit(0)
	End Sub

	Private Sub MyClose1_Click(sender As Object, e As EventArgs) Handles MyClose1.Click
		Environment.Exit(0)
	End Sub
End Class
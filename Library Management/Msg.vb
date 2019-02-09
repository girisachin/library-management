Public Class Msg
	Public Sub Err(ByVal Str As String)
		FormSkin1.Text = "Error"
		ErrorLabel.Text = Str
		Me.ShowDialog()
		Alert("Error", Str)
	End Sub
	Public Sub Info(ByVal Str As String)
		FormSkin1.Text = "Warning"
		ErrorLabel.Text = Str
		Me.ShowDialog()
		Alert("Warning", Str)
	End Sub
	Public Sub Success(ByVal Str As String)
		FormSkin1.Text = "Success"
		ErrorLabel.Text = Str
		Me.ShowDialog()
		Alert("Success", Str)
	End Sub

	Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
		Alert(FormSkin1.Text, ErrorLabel.Text)
		Me.Close()
	End Sub
End Class
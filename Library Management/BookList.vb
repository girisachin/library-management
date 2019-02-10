Public Class BookList

    Private Sub FormSkin1_Click(sender As Object, e As EventArgs) Handles FormSkin1.Click

    End Sub

    Private Sub Book_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BookList_Load(sender As Object, e As EventArgs) Handles Me.Load
        SearchBookGrid.ClearSelection()
    End Sub

    Private Sub MyClose1_Click(sender As Object, e As EventArgs) Handles MyClose1.Click
        Me.Close()
    End Sub

    Private Sub MyMini1_Click(sender As Object, e As EventArgs) Handles MyMini1.Click

    End Sub
End Class
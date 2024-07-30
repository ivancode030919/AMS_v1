Public Class VendorAddandUpdate
    Private Sub VendorAddandUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub VendorAddandUpdate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
        If SimpleButton2.Text = "Save" Then
        Else
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

    End Sub
End Class
Public Class UserChangePass


    Public userID As Integer
    Private Sub UserChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If TextBox2.Text = String.Empty Then
            MsgBox("Invalid Password...")
        Else
            UserClass.UpdateUserPass(User.Userid, TextBox2.Text)
        End If

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Label3.Text = "*"
        TextBox2.Text = ""
        Me.Close()
    End Sub

    Private Sub UserChangePass_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Label3.Text = "*"
            TextBox2.Text = ""
            Me.Close()
        End If
    End Sub
End Class
Public Class UpdateSelection
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
        UserUpdate.ShowDialog()
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
        UserChangePass.ShowDialog()
        Me.Close()
    End Sub
End Class
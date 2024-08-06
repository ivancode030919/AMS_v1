Public Class ReqCancel

    Public requestno As String = ""
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to Continue?", "Decision Box", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            UpdateClass.CancellationReason(requestno, TextBox1.Text)
            TextBox1.Text = String.Empty
            requestno = String.Empty
            With Rqregister
                .Label3.Visible = True
                .SimpleButton1.Enabled = False
                .SimpleButton2.Enabled = False
                .SimpleButton3.Enabled = False
            End With

            With RequestRegister
                .display()
            End With

            MessageBox.Show("Successfully Cancelled", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Dispose()
        Else

        End If


    End Sub


End Class
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
        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Asset Condition Code")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Asset Condition Description")
        Else
            If SimpleButton2.Text = "Record" Then
                If VendorClass.FetchVenCount(TextBox1.Text) > 0 Then
                    MessageBox.Show("Vendor Code Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    VendorClass.SaveVendor(TextBox1.Text, TextBox2.Text)
                End If

            ElseIf SimpleButton2.Text = "Save" Then
                VendorClass.UpdateVendor(Vendor.VenID, TextBox1.Text, TextBox2.Text)
            End If

        End If
    End Sub
End Class
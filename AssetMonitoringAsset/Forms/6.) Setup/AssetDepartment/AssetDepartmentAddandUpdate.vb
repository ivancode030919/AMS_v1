Public Class AssetDepartmentAddandUpdate
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Asset Department Code")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Asset Department Description")
        Else
            If SimpleButton2.Text = "Record" Then
                If DepartmentClass.FetchDepCount(TextBox1.Text) > 0 Then
                    MessageBox.Show("Department Code Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    DepartmentClass.SaveDepartment(TextBox1.Text, TextBox2.Text, ComboBox1.Text)
                End If
            ElseIf SimpleButton2.Text = "Save" Then
                DepartmentClass.UpdateDepartment(AssetDepartment.DepID, TextBox1.Text, TextBox2.Text, ComboBox1.Text)
            End If
        End If
    End Sub

    Private Sub AssetDepartmentAddandUpdate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            If SimpleButton2.Text = "Save" Then
            Else
                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            End If

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

    Private Sub AssetDepartmentAddandUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
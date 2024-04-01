Public Class UserAdd

    Public EmpID As Integer
    Private Sub UserAddandUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        EmployeeList.modty = 2
        EmployeeList.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If Label3.Text = "*" Then
            MsgBox("Please Select Employee...")
        Else
            If FetchClass.CountUserEmployee(EmpID) >= 1 Then
                MsgBox("Employee Had Already Existing Account")
            ElseIf FetchClass.CountUserEmployee(EmpID) = 0 Then

                If FetchClass.CountUsername(TextBox1.Text) > 1 Then
                    MsgBox("Username Already Existed...")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                Else
                    InsertionClass.SaveUser(TextBox1.Text, TextBox2.Text, EmpID, ComboBox2.Text, ComboBox1.Text)
                End If
            End If

        End If


    End Sub

    Private Sub UserAddandUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        Label3.Text = "*"
    End Sub

    Private Sub UserAddandUpdate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Label3.Text = "*"
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
            Me.Close()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Label3.Text = "*"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        Me.Close()
    End Sub
End Class
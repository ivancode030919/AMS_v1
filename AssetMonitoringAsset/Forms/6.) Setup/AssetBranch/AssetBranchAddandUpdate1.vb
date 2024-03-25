Public Class AssetBranchAddandUpdate1
    Private Sub AssetBranchAddandUpdate1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click


        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Asset Type Code")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Asset Type Description")
        Else
            If SimpleButton2.Text = "Record" Then
                If BranchClass.FetchBCCount(TextBox1.Text) > 0 Then
                    MessageBox.Show("Branch Code Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    BranchClass.SaveBranch(TextBox1.Text, TextBox2.Text)
                End If
            ElseIf SimpleButton2.Text = "Save" Then
                BranchClass.UpdateBranch(AssetBranch.BranID, TextBox1.Text, TextBox2.Text)
            End If
        End If
    End Sub

    Private Sub AssetBranchAddandUpdate1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
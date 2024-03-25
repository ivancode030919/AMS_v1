Public Class Reference
    Private Sub Reference_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Public Sub display()
        dgv.DataSource = ReferenceClass.ViewRef(TextBox3.Text)
        dgv.Columns(0).HeaderText = "Reference ID"
        dgv.Columns(1).HeaderText = "Reference"
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        SimpleButton2.Enabled = False
    End Sub

    Private Sub Reference_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        SimpleButton2.Enabled = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox1.Text = String.Empty Then

            If TextBox2.Text = String.Empty Then
                MessageBox.Show("Invalid Reference", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If (MessageBox.Show("Do You Want To Add?", "Confirmation", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No) Then

                Else
                    ReferenceClass.SaveReference(TextBox2.Text)
                End If
            End If
        Else
            MessageBox.Show("Please Clear Before Adding New Reference", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click



        If TextBox1.Text = String.Empty Or TextBox2.Text = String.Empty Then
            MessageBox.Show("Please Select Reference Before Updating", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            If (MessageBox.Show("Do You Want To Update?", "Confirmation", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No) Then

            Else
                ReferenceClass.UpdateReference(TextBox2.Text, Integer.Parse(TextBox1.Text))
            End If

        End If
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)
            TextBox1.Text = selectedrow.Cells(0).Value.ToString
            TextBox2.Text = selectedrow.Cells(1).Value.ToString

            SimpleButton2.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        display()
    End Sub
End Class
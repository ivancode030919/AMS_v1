Public Class ProcureRegister
    Private Sub ProcureRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv.DataSource = ViewClass.ViewProcureRegister(TextBox2.Text, DateTimePicker1.Value, DateTimePicker2.Value)
        With dgv
            .Columns(0).HeaderText = "Request Number"
            .Columns(1).HeaderText = "Requestor"
            .Columns(2).HeaderText = "Department"
            .Columns(3).HeaderText = "Branch"
            .Columns(4).HeaderText = "Company"
            .Columns(5).HeaderText = "Date"


            .Columns(0).Width = "125"
            .Columns(1).Width = "150"
            .Columns(2).Width = "200"
            .Columns(3).Width = "200"
            .Columns(4).Width = "200"
            .Columns(5).Width = "125"

            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex

        With ProcureDetail
            .transid = dgv.Rows(row).Cells(6).Value.ToString
            .TextBox1.Text = dgv.Rows(row).Cells(0).Value.ToString
            .TextBox2.Text = dgv.Rows(row).Cells(1).Value.ToString
            .DateTimePicker1.Value = dgv.Rows(row).Cells(5).Value.ToString
            .ShowDialog()
        End With
    End Sub

End Class
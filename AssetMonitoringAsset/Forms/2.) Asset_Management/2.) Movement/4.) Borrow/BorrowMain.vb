Public Class BorrowMain

    Private Sub BorrowMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv.DataSource = ViewClass.ViewBorrowRegister(TextBox2.Text, DateTimePicker1.Value, DateTimePicker2.Value, Home.EmployeeID)

        With dgv

            .Columns(0).HeaderText = "Request Number"
            .Columns(1).HeaderText = "Requestor"
            .Columns(2).HeaderText = "Department"
            .Columns(3).HeaderText = "Branch"
            .Columns(4).HeaderText = "Company"
            .Columns(5).HeaderText = "Date"

            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        display()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub BorrowMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub BorrowMain_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        Dim row As Integer = dgv.CurrentCell.RowIndex

        With BorrowDetails

            .transid = Integer.Parse(dgv.Rows(row).Cells(6).Value.ToString)
            .TextBox1.Text = dgv.Rows(row).Cells(0).Value.ToString
            .TextBox2.Text = dgv.Rows(row).Cells(1).Value.ToString
            .DateTimePicker1.Value = Date.Parse(dgv.Rows(row).Cells(5).Value.ToString)
            .ShowDialog()

        End With

    End Sub
End Class
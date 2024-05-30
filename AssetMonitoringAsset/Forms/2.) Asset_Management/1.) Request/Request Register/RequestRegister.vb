Public Class RequestRegister

    Private stat1 As Integer
    Private Sub RequestRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
        RadioButton1.Checked = True
    End Sub

    Public Sub display()
        dgv.DataSource = ViewClass.FetchsRequstRegister(stat1, DateTimePicker1.Value, DateTimePicker2.Value)
        With dgv
            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "Request No."
            .Columns(2).HeaderText = "Transaction Type"
            .Columns(3).HeaderText = "Company"
            .Columns(4).HeaderText = "Department"
            .Columns(5).HeaderText = "Branch"
            .Columns(6).HeaderText = "Section"
            .Columns(7).HeaderText = "Requestor"
            .Columns(8).HeaderText = "Status"
            .Columns(9).Visible = False
            .Columns(10).Visible = False
        End With

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex
        With Rqregister
            .headerid = Integer.Parse(dgv.Rows(row).Cells(9).Value.ToString)
            .requestby = dgv.Rows(row).Cells(10).Value
            .Rtype = dgv.Rows(row).Cells(2).Value.ToString
            .TextBox3.Text = dgv.Rows(row).Cells(2).Value.ToString
            .TextBox1.Text = dgv.Rows(row).Cells(1).Value.ToString
            .TextBox2.Text = dgv.Rows(row).Cells(7).Value.ToString
            .ShowDialog()
        End With
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        stat1 = 1
        display()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        stat1 = 2
        display()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        stat1 = 4
        display()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        stat1 = 3
        display()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Me.Dispose()
        Home.IsMdiContainer = False
    End Sub

    Private Sub RequestRegister_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub
End Class
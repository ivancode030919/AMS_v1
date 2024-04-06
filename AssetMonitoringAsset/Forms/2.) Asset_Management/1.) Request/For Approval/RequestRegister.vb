Public Class RequestRegister

    Private stat1 As String = ""
    Private Sub RequestRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv.DataSource = ViewClass.FetchsRequstRegister(stat1)
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
        stat1 = "OPEN"
    End Sub
End Class
Public Class AssignemntRegister

    Private filter As String

    Private Sub AssignemntRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        filter = "O"
        display()
    End Sub
    Private Sub display()
        dgv.DataSource = ViewClass.ViewAssignmentRegister(TextBox2.Text, d1.Value, d2.Value, filter)

        With dgv
            .Columns(0).HeaderText = "Entry Number"
            .Columns(1).HeaderText = "Requestor"
            .Columns(2).HeaderText = "Date"
        End With
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        display()
    End Sub

    Private Sub d1_ValueChanged(sender As Object, e As EventArgs) Handles d1.ValueChanged
        display()
    End Sub

    Private Sub d2_ValueChanged(sender As Object, e As EventArgs) Handles d2.ValueChanged
        display()
    End Sub

    Private Sub AssignemntRegister_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub




    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        filter = "O"
        display()
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        filter = "R"
        display()
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        filter = "S"
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex
    End Sub
End Class
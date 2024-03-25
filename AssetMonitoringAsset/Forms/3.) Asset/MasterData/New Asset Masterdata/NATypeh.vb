Public Class NATypeh
    Public rowToEdit As Integer
    Private Sub NATypeh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchdata()

    End Sub

    Private Sub fetchdata()
        dgview2.DataSource = ViewClass.ViewNaAsset(TextBox1.Text)
        dgview2.Columns(0).Visible = False
        dgview2.Columns(1).HeaderText = "Type Code"
        dgview2.Columns(2).HeaderText = "Type Description"
    End Sub

    Private Sub Dgview2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview2.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview2.Rows(index)


            With NewAsset.dgview
                .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(2).Value.ToString
                .Rows(rowToEdit).Cells(5).Value = selectedrow.Cells(0).Value.ToString
            End With
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        fetchdata()
    End Sub

    Private Sub NATypeh_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub
End Class
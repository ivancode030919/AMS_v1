Public Class NAcategory
    Public rowToEdit As Integer

    Private Sub NAcategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Ddgview1()
    End Sub
    Private Sub Ddgview1()
        dgview2.DataSource = ViewClass.ViewNaCategory(TextBox1.Text)
        dgview2.Columns(0).Visible = False
        dgview2.Columns(1).HeaderText = "Category Code"
        dgview2.Columns(2).HeaderText = "Category Description"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Ddgview1()
    End Sub

    Private Sub Dgview2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview2.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview2.Rows(index)

            With NewAsset.dgview
                .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(2).Value.ToString
                .Rows(rowToEdit).Cells(4).Value = selectedrow.Cells(0).Value.ToString
            End With
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NAcategory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub
End Class
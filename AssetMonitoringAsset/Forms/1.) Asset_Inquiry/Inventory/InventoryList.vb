Public Class InventoryList

    Private Sub InventoryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Public Sub Display()

        Dim fltr As Integer

        If RadioButton2.Checked = True Then
            fltr = 1
        ElseIf RadioButton1.Checked = True Then
            fltr = 2
        ElseIf RadioButton4.Checked = True Then
            fltr = 3
        ElseIf RadioButton3.Checked = True Then
            fltr = 4
        End If
        FetchClass.ViewInventory()
        With dgv
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Quantity"
        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Display()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Display()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Display()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Display()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)
            With Details
                .ac = selectedrow.Cells(0).Value.ToString
                .ShowDialog()
            End With


        Catch ex As Exception

        End Try


    End Sub

    Private Sub InventoryList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
        End If
    End Sub
End Class
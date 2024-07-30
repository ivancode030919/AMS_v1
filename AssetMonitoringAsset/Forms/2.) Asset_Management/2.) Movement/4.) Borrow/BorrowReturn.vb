Public Class BorrowReturn
    Private Sub BorrowReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvDisplay()
    End Sub

    Public Sub DgvDisplay()
        Dgv.Columns.Clear()
        Dgv.DataSource = ViewClass.ViewBorrowedItems(TextBox1.Text, TextBox2.Text)

        Dim btnColumn As New DataGridViewButtonColumn()
        btnColumn.Name = "Status"
        btnColumn.HeaderText = ""
        btnColumn.Text = "Return"
        btnColumn.UseColumnTextForButtonValue = True
        Dgv.Columns.Insert(0, btnColumn)

    End Sub

    Private Sub BorrowReturn_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub BorrowReturn_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        DgvDisplay()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        DgvDisplay()
    End Sub

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellContentClick
        Dim index As Integer = Dgv.CurrentCell.RowIndex

        If e.ColumnIndex = 0 Then

            Dim result As DialogResult = MessageBox.Show("Do you want to return this Item?", "Validation", MessageBoxButtons.OKCancel)

            If result = DialogResult.OK Then

                With BorrowerRetuenConfirmation
                    .PropertyCode = Dgv.Rows(index).Cells(2).Value
                    .BorrowerID = Dgv.Rows(index).Cells(1).Value
                    .ShowDialog()
                End With

            ElseIf result = DialogResult.Cancel Then

            End If

        End If

    End Sub
End Class
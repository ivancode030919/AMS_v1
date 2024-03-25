Public Class NACondition
    Public rowToEdit As Integer
    Public modty As Integer

    Private Sub NACondition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fetchdata()
    End Sub


    Private Sub fetchdata()
        dgview2.DataSource = ConditionClass.ViewNaCondition(TextBox1.Text)
        dgview2.Columns(0).Visible = False
        dgview2.Columns(1).HeaderText = "Condition Code"
        dgview2.Columns(2).HeaderText = "Condition Description"
    End Sub

    Private Sub Dgview2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview2.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview2.Rows(index)

            If modty = 1 Then
                With BuildAsset.dgview
                    .Rows(rowToEdit).Cells(11).Value = selectedrow.Cells(2).Value.ToString
                End With
            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        fetchdata()
    End Sub

    Private Sub NACondition_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub
End Class
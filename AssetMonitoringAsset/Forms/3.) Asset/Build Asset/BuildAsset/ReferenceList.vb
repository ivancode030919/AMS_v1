Public Class ReferenceList
    Public rowToEdit As Integer
    Public modty As Integer
    Private Sub ReferenceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()

        dgv.DataSource = ReferenceClass.ViewRef(TextBox1.Text)

        With dgv
            .Columns(0).HeaderText = "Reference ID"
            .Columns(1).HeaderText = "Reference"
        End With
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)

            If modty = 1 Then
                With BuildAsset.dgview
                    .Rows(rowToEdit).Cells(9).Value = selectedrow.Cells(1).Value.ToString
                End With
            ElseIf modty = 2 Then
                'With AssetAcquisition.dgview
                '    .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(1).Value.ToString
                'End With
            End If


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReferenceList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
        End If
    End Sub
End Class
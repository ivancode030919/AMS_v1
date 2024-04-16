Public Class ProcureDetail
    Public transid As Integer
    Private Sub ProcureDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If e.ColumnIndex = 5 Then
            Dim row As Integer = dgv.CurrentCell.RowIndex
            Dim itmcd As String = dgv.Rows(row).Cells(0).Value.ToString
            Dim itmid As String = dgv.Rows(row).Cells(6).Value.ToString

            With RecvReqConfrm
                .ItemCode = itmcd
                .ItemId = itmid
                .ShowDialog()
            End With
        End If
    End Sub


    Public Sub display()
        'gv.Columns.Clear()
        dgv.DataSource = ViewClass.ViewProcureDetails(transid)
        With dgv
            .Columns(0).HeaderText = "Item Code"
            .Columns(1).HeaderText = "Class"
            .Columns(2).HeaderText = "Request For"
            .Columns(3).HeaderText = "Quantity"
            .Columns(4).HeaderText = "Remarks"
            .Columns(5).HeaderText = "Status"

        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProcureDetail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'dgv.Columns.Clear()
    End Sub

End Class
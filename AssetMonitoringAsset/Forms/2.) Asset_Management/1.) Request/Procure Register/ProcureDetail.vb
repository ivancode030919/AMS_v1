Public Class ProcureDetail
    Public transid As Integer
    Private Sub ProcureDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

    End Sub


    Public Sub display()
        dgv.DataSource = ViewClass.ViewProcureDetails(transid)

        With dgv
            .Columns(0).HeaderText = "Item Code"
            .Columns(1).HeaderText = "Class"
            .Columns(2).HeaderText = "Request For"
            .Columns(3).HeaderText = "Quantity"
            .Columns(4).HeaderText = "Remarks"

            .Columns.Add("5", "Receive Status")
            .Columns(5).ReadOnly = True

        End With
    End Sub
End Class
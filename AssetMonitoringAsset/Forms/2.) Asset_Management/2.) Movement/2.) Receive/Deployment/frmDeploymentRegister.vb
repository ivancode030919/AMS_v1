Public Class frmDeploymentRegister
    Private Sub frmDeploymentRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayDatagrid()
    End Sub

    Private Sub DisplayDatagrid()
        DepDgv.DataSource = ViewClass.ViewDeployemntRegisterHeader(DateTimePicker1.Value, DateTimePicker2.Value, TextBox2.Text)

        With DepDgv
            .Columns(0).HeaderText = "Deployment ID"
            .Columns(1).HeaderText = "Deployed By"
            .Columns(2).HeaderText = "Runner"
            .Columns(3).HeaderText = "Date / Time"
            .Columns(4).Visible = False
            .Columns(3).DefaultCellStyle.Format = "MM/dd/yyyy - hh:mm:ss tt"

        End With
    End Sub

    Private Sub frmDeploymentRegister_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub frmDeploymentRegister_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub DepDgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DepDgv.CellDoubleClick
        Dim index As Integer = DepDgv.CurrentCell.RowIndex

        With frmDeploymentRegisterDetail
            .transid = DepDgv.Rows(index).Cells(4).Value
            .ShowDialog()
        End With
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DisplayDatagrid()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        DisplayDatagrid()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        DisplayDatagrid()
    End Sub
End Class
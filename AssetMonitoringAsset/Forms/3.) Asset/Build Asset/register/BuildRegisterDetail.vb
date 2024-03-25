Public Class BuildRegisterDetail
    Public entry As Integer
    Private Sub BuildRegisterDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdgv()

    End Sub

    Public Sub viewdgv()
        'dgv.DataSource = AssetHeaderClass.Fetchregister1(entry)

        'dgv.Columns(0).HeaderText = "Asset Code"
        'dgv.Columns(1).HeaderText = "Description"
        'dgv.Columns(2).HeaderText = "Category"
        'dgv.Columns(3).HeaderText = "Asset Type"
        'dgv.Columns(5).HeaderText = "Condition"
        'dgv.Columns(6).HeaderText = "Reference"
        'dgv.Columns(7).HeaderText = "Number"
        'dgv.Columns(8).HeaderText = "Quantity"

    End Sub
    Private Sub Dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

    End Sub

    Private Sub BuildRegisterDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox2.Text = ""
            TextBox1.Text = ""
            TextBox3.Text = ""
        End If
    End Sub
End Class
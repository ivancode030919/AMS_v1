Public Class Details
    Public ac As String = ""
    Public code As String = ""
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv.DataSource = ViewClass.ViewInventoryDetails(Integer.Parse(ac), TextBox1.Text)

        With dgv
            .Columns(0).HeaderText = "Property Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Quantity"
            .Columns(3).HeaderText = "Department"
            .Columns(4).HeaderText = "Branch"
            .Columns(5).HeaderText = "Section"
            .Columns(6).HeaderText = "Keeper"
            .Columns(7).HeaderText = "Owner"
        End With

    End Sub

    Private Sub Details_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        display()
    End Sub

    Private Sub Details_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Text = String.Empty
    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub
End Class
Public Class BorrowReturn
    Private Sub BorrowReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvDisplay()
    End Sub

    Private Sub DgvDisplay()
        Dgv.Columns.Clear()
        Dgv.DataSource = ViewClass.ViewBorrowedItems(TextBox1.Text, TextBox2.Text)
        Dgv.Columns.Add(6, "Status")

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
End Class
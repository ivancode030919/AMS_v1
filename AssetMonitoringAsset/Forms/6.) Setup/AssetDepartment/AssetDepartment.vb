Public Class AssetDepartment

    Public DepID As Integer
    Private Sub AssetDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewDepartment()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Add" Then
            AssetDepartmentAddandUpdate.TextBox1.Text = String.Empty
            AssetDepartmentAddandUpdate.TextBox2.Text = String.Empty
            AssetDepartmentAddandUpdate.SimpleButton2.Text = "Record"
            AssetDepartmentAddandUpdate.ShowDialog()
        ElseIf SimpleButton1.Text = "Update Department" Then
            AssetDepartmentAddandUpdate.Text = "Update"
            AssetDepartmentAddandUpdate.SimpleButton2.Text = "Save"
            AssetDepartmentAddandUpdate.ShowDialog()
        End If
    End Sub

    Public Sub ViewDepartment()
        DepartmentClass.ViewDepartment(TextBox3.Text)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewDepartment()
    End Sub

    Private Sub AssetDepartment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        SimpleButton1.Text = "Add"
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            DepID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Department"

            With AssetDepartmentAddandUpdate
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub AssetDepartment_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub
End Class
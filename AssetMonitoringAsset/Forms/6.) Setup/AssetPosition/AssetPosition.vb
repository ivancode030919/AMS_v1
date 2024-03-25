Public Class AssetPosition

    Public posID As Integer
    Private Sub AssetPosotion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewPosition()
    End Sub

    Public Sub ViewPosition()
        PositionClass.ViewBranch(TextBox3.Text)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Add" Then
            AssetPositionAddandUpdate.TextBox1.Text = String.Empty
            AssetPositionAddandUpdate.TextBox2.Text = String.Empty
            AssetPositionAddandUpdate.SimpleButton2.Text = "Record"
            AssetPositionAddandUpdate.ShowDialog()
        ElseIf SimpleButton1.Text = "Update Position" Then
            AssetPositionAddandUpdate.Text = "Update"
            AssetPositionAddandUpdate.SimpleButton2.Text = "Save"
            AssetPositionAddandUpdate.ShowDialog()
        End If
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            posID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Position"

            With AssetPositionAddandUpdate
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

    Private Sub AssetPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub AssetPosition_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewPosition()
    End Sub
End Class
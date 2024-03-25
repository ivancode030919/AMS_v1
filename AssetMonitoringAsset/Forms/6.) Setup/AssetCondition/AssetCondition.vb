Public Class AssetCondition
    Public ConID As Integer
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Add" Then
            AssetConditionAddandUpdate.TextBox1.Text = String.Empty
            AssetConditionAddandUpdate.TextBox2.Text = String.Empty
            AssetConditionAddandUpdate.SimpleButton2.Text = "Record"
            AssetConditionAddandUpdate.ShowDialog()
        ElseIf SimpleButton1.Text = "Update Condition" Then
            AssetConditionAddandUpdate.Text = "Update"
            AssetConditionAddandUpdate.SimpleButton2.Text = "Save"
            AssetConditionAddandUpdate.ShowDialog()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub AssetCondition_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub AssetCondition_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        SimpleButton1.Text = "Add"
    End Sub

    Private Sub AssetCondition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewCondition()
    End Sub

    Public Sub ViewCondition()
        ConditionClass.ViewCondition(TextBox3.Text)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewCondition()
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            ConID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Condition"

            With AssetConditionAddandUpdate
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class AssetType
    Public TypeID As Integer
    Private Sub AssetType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewType()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Add" Then


            AssetTypeAddandUpdate.TextBox1.Text = String.Empty
            AssetTypeAddandUpdate.TextBox2.Text = String.Empty
            AssetTypeAddandUpdate.SimpleButton2.Text = "Record"
            AssetTypeAddandUpdate.ShowDialog()

        ElseIf SimpleButton1.Text = "Update Asset Type" Then

            AssetTypeAddandUpdate.Text = "Update"
            AssetTypeAddandUpdate.SimpleButton2.Text = "Save"
            AssetTypeAddandUpdate.ShowDialog()

        End If

    End Sub

    Public Sub ViewType()
        TypeClass.ViewAssetType(TextBox3.Text)
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick

        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            TypeID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Asset Type"

            With AssetTypeAddandUpdate
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewType()
    End Sub

    Private Sub AssetType_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub AssetType_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub
End Class
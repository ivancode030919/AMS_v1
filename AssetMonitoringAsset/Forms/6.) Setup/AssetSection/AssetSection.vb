Public Class AssetSection
    Public SecID As Integer
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Add" Then
            AssetSectionAddandUpdate1.TextBox1.Text = String.Empty
            AssetSectionAddandUpdate1.TextBox2.Text = String.Empty
            AssetSectionAddandUpdate1.SimpleButton2.Text = "Record"
            AssetSectionAddandUpdate1.ShowDialog()
        ElseIf SimpleButton1.Text = "Update Section" Then
            AssetSectionAddandUpdate1.Text = "Update"
            AssetSectionAddandUpdate1.SimpleButton2.Text = "Save"
            AssetSectionAddandUpdate1.ShowDialog()
        End If
    End Sub

    Private Sub AssetSection_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub AssetSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewSection()
    End Sub

    Public Sub ViewSection()
        SectionClass.ViewSection(TextBox3.Text)
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            SecID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Section"

            With AssetSectionAddandUpdate1
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewSection()
    End Sub

    Private Sub AssetSection_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub
End Class
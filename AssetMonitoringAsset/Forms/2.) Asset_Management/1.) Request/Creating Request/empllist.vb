Public Class empllist
    Public modty As Integer
    Public rowToEdit As Integer

    Private Sub empllist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdg()
    End Sub
    Private Sub viewdg()

        If Home.UserType = "ADMIN" Then
            dgview.DataSource = EmployeeClass.ViewEmployeeList5(TextBox1.Text)
        Else
            dgview.DataSource = EmployeeClass.ViewEmployeeList4(Home.BranchID, Home.DepartmentID, Home.SectionID, TextBox1.Text)
        End If

        With dgview
            .Columns(0).HeaderText = "ID"
            .Columns(1).HeaderText = "Name"
        End With

    End Sub

    Private Sub dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = dgview.Rows(index)

        If modty = 1 Then
            With Request.dgv
                .Rows(rowToEdit).Cells(5).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(1).Value.ToString
            End With
        ElseIf modty = 2 Then
            With Request.dgv
                .Rows(rowToEdit).Cells(7).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(1).Value.ToString
            End With
        ElseIf modty = 3 Then
            With Request.dgv
                .Rows(rowToEdit).Cells(5).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(1).Value.ToString
            End With

        ElseIf modty = 4 Then
            With Assignment1.dgv
                .Rows(rowToEdit).Cells(7).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(1).Value.ToString
            End With
        End If


        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        viewdg()
    End Sub
End Class
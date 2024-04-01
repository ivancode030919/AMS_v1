Public Class EmployeeList
    Public rowToEdit As Integer
    Public modty As Integer

    Private Sub EmployeeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdg()
    End Sub

    Private Sub viewdg()
        dgview.DataSource = ViewClass.ViewEmployeeList(TextBox1.Text)
    End Sub

    Private Sub Dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)

            If modty = 1 Then

                With BuildAsset.dgview
                    .Rows(rowToEdit).Cells(17).Value = selectedrow.Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(5).Value = selectedrow.Cells(2).Value.ToString + ", " + selectedrow.Cells(1).Value.ToString
                End With


            ElseIf modty = 2 Then

                With UserAdd
                    .Label3.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                    .EmpID = Integer.Parse(selectedrow.Cells(0).Value.ToString)
                    .TextBox1.Enabled = True
                    .TextBox2.Enabled = True
                End With

            ElseIf modty = 3 Then

                With BuildAsset.dgview
                    .Rows(rowToEdit).Cells(18).Value = selectedrow.Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(6).Value = selectedrow.Cells(2).Value.ToString + ", " + selectedrow.Cells(1).Value.ToString
                End With
            End If



            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        viewdg()
    End Sub

    Private Sub EmployeeList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
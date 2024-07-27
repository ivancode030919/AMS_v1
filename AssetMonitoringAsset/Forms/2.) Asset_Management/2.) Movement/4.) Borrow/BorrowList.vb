Public Class BorrowList
    Private ChoiceDisplay As Integer

    Private Sub BorrowList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Public Sub DisplayOwnedItems()
        Try
            Dgv.Columns.Clear()

            If ChoiceDisplay = 1 Then
                ' Set DataSource for the DataGridView
                Dgv.DataSource = ViewClass.ViewItemsInBorrow
                ' Add CheckBoxColumn to DataGridView
                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.Width = 18 ' Set a reasonable width
                checkBoxColumn.TrueValue = True
                checkBoxColumn.FalseValue = False
                Dgv.Columns.Insert(0, checkBoxColumn)
                Dgv.Columns.Add(6, "Status")
                ' Add another column (index 6) to the DataGridView
                Dgv.Columns(5).Visible = False
                Dgv.Columns(5).ReadOnly = True

                'Dgv.Columns(1)









            ElseIf ChoiceDisplay = 2 Then
                ' Implement the logic for ChoiceDisplay = 2 if required
            End If

            For Each row As DataGridViewRow In Dgv.Rows
                If Not row.IsNewRow Then
                    Dim cellValue As String = row.Cells(5).Value
                    If cellValue = "Allowed" Then
                        row.Cells(0).Value = True
                    Else
                        row.Cells(0).Value = False
                    End If
                    row.Cells(6).Value = row.Cells(5).Value
                End If

            Next

        Catch ex As Exception
            ' Handle exceptions here
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Text = "Owned Items" Then
            ChoiceDisplay = 1
            DisplayOwnedItems()
        ElseIf ComboBox1.Text = "Borrowed Items" Then
            ChoiceDisplay = 2
            DisplayOwnedItems()
        End If

    End Sub

    Private Sub Dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellClick
        Dim index As Integer = Dgv.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then

            Dim StatTrue As String = Dgv.Rows(index).Cells(6).Value
            Dim PD As String = Dgv.Rows(index).Cells(1).Value
            Dim NewStat As String = ""
            If StatTrue = "Allowed" Then
                Dgv.Rows(index).Cells(0).Value = True
                Dgv.Rows(index).Cells(6).Value = "Not Allowed"
                NewStat = "Not Allowed"
            ElseIf StatTrue = "Not Allowed" Then
                Dgv.Rows(index).Cells(0).Value = False
                Dgv.Rows(index).Cells(6).Value = "Allowed"
                NewStat = "Allowed"
            End If
            UpdateClass.UpdateBorrowStat(PD, NewStat)
        Else

        End If

    End Sub
End Class



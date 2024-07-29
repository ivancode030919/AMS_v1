Public Class BorrowList
    Private ChoiceDisplay As Integer

    Private Sub BorrowList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
    End Sub


    Public Sub DisplayOwnedItems()
        Try
            Dgv.Columns.Clear()
            If ChoiceDisplay = 1 Then
                ' Set DataSource for the DataGridView
                Dgv.DataSource = ViewClass.ViewItemsInBorrow(TextBox1.Text, TextBox2.Text)
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

                Dgv.Columns(1).HeaderText = "Property Code"
                Dgv.Columns(2).HeaderText = "Descriptsion"
                Dgv.Columns(3).HeaderText = "Quantity"
                Dgv.Columns(4).HeaderText = "Owner/Keeper"
                Dgv.Columns(5).HeaderText = "Status"

                Dgv.Columns(1).Width = 200
                Dgv.Columns(2).Width = 400
                Dgv.Columns(3).Width = 100
                Dgv.Columns(4).Width = 250
                Dgv.Columns(5).Width = 150

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

            ElseIf ChoiceDisplay = 2 Then
                Dgv.DataSource = ViewClass.ViewBorrowedItems(TextBox1.Text, TextBox2.Text)
            End If

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

    Private Sub Dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv.CellContentClick

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

    Private Sub BorrowList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        DisplayOwnedItems()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        DisplayOwnedItems()
    End Sub

End Class



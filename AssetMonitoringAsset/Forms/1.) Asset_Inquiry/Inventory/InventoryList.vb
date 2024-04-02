Public Class InventoryList

    Private Sub InventoryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Public Sub Display()
        Dim depcode As String
        If Home.UserType = "ADMIN" Then
            depcode = ""
        Else
            depcode = Home.Department
        End If

        FetchClass.ViewInventory(TextBox1.Text, depcode, ComboBox1.Text, ComboBox2.Text)

        With dgv
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Quantity"
        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Display()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs)
        Display()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        Display()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs)
        Display()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)
        Display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)
            With Details
                .ac = selectedrow.Cells(0).Value.ToString
                .ShowDialog()
            End With


        Catch ex As Exception

        End Try


    End Sub

    Private Sub InventoryList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            ComboBox1.DataSource = Nothing
            ComboBox1.Enabled = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            ComboBox1.DataSource = FetchClass.ViewCboxCat()
            RadioButton6.Checked = False
            ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ComboBox2.DataSource = Nothing
            ComboBox2.Enabled = False
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ComboBox2.DataSource = FetchClass.ViewCboxtype()
            RadioButton2.Checked = False
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub InventoryList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RadioButton6.Checked = True
        RadioButton2.Checked = True
        TextBox1.Text = String.Empty
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Display()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Display()
    End Sub
End Class
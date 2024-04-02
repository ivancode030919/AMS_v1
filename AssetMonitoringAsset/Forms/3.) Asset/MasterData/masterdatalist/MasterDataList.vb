Public Class MasterDataList
    Private Sub MasterDataList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()
        dgv.DataSource = ViewClass.Fetchmasterdata(TextBox1.Text, ComboBox1.Text, ComboBox2.Text)
        'dgv.Columns(0).HeaderText = "Asset Code"
        'dgv.Columns(1).HeaderText = "Description"
        'dgv.Columns(2).HeaderText = "Category"
        'dgv.Columns(3).HeaderText = "Asset Type"
        'dgv.Columns(4).HeaderText = "Condition"
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            ComboBox1.DataSource = FetchClass.ViewCboxCat()
            RadioButton6.Checked = False
            ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Checked = True Then
            ComboBox2.DataSource = FetchClass.ViewCboxtype()
            RadioButton2.Checked = False
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        display()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
        display()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            ComboBox1.DataSource = Nothing
            ComboBox1.Enabled = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ComboBox2.DataSource = Nothing
            ComboBox2.Enabled = False
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MasterDataList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            RadioButton6.Checked = True

            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub MasterDataList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        TextBox1.Text = String.Empty
        RadioButton6.Checked = True

        RadioButton2.Checked = True
    End Sub
End Class
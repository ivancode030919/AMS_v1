Public Class Details
    Public ac As String = ""
    Public code As String = ""
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()

        If Home.UserType = "ADMIN" Then
            dgv.DataSource = ViewClass.ViewInventoryDetails(Integer.Parse(ac))

            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Department"
                .Columns(4).HeaderText = "Branch"
                .Columns(5).HeaderText = "Section"
                .Columns(6).HeaderText = "Keeper"
                .Columns(7).HeaderText = "Owner"
            End With

        ElseIf Home.UserType = "BPC" Then

        ElseIf Home.UserType = "SPC" Then

        ElseIf Home.UserType = "DPC" Then

        End If


    End Sub

    Private Sub Details_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
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

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ComboBox2.DataSource = Nothing
            ComboBox2.Enabled = False
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ComboBox2.DataSource = TypeClass.ViewCboxtype()
            RadioButton2.Checked = False
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        display()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub Details_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RadioButton6.Checked = True
        RadioButton2.Checked = True
        TextBox1.Text = String.Empty
    End Sub
End Class
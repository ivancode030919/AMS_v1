Public Class Employee

    Public updatethis As Boolean = False

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox1.Text = "" Then

            With EmployeeAddandUpdate
                .TextBox1.Text = ""
                .TextBox2.Text = ""
            End With
            EmployeeAddandUpdate.ShowDialog()
        Else


        End If

    End Sub

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee()
    End Sub


    Public Sub viewEmployee()
        ViewClass.ViewEmployee(TextBox2.Text, ComboBox1.Text, ComboBox2.Text, ComboBox3.Text, ComboBox4.Text)

    End Sub

    Private Sub closingss()
        ComboBox1.DataSource = Nothing
        ComboBox1.Items.Clear()
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
            Label5.Text = selectedrow.Cells(0).Value.ToString
            'DepID = CInt(selectedrow.Cells(0).Value)
            SimpleButton2.Visible = True
            SimpleButton3.Visible = True

            With EmployeeAddandUpdate

                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
                .ComboBox2.Text = selectedrow.Cells(3).Value.ToString

                .updateID = Integer.Parse(Label5.Text)

            End With
            SimpleButton1.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        viewEmployee()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Enabled = False
        With EmployeeAddandUpdate
            .Text = "Update"
            .SimpleButton1.Text = "Save"
        End With
        EmployeeAddandUpdate.ShowDialog()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        viewEmployee()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        viewEmployee()
    End Sub

    Private Sub Employee_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        closingss()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            RadioButton5.Checked = False
            ComboBox1.DataSource = Nothing
            ComboBox1.Items.Clear()
            ComboBox1.Enabled = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            RadioButton6.Checked = False
            ComboBox1.DataSource = BranchClass.ViewCboxBranch
            ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        If RadioButton8.Checked = True Then
            RadioButton7.Checked = False
            ComboBox2.DataSource = Nothing
            ComboBox2.Items.Clear()
            ComboBox2.Enabled = False
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        If RadioButton7.Checked = True Then
            RadioButton8.Checked = False
            ComboBox2.DataSource = DepartmentClass.ViewCboxDepartment
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        viewEmployee()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        viewEmployee()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            RadioButton3.Checked = False
            ComboBox4.DataSource = Nothing
            ComboBox4.Items.Clear()
            ComboBox4.Enabled = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            RadioButton4.Checked = False
            ComboBox4.DataSource = PositionClass.ViewCboxPosition
            ComboBox4.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
            ComboBox3.DataSource = Nothing
            ComboBox3.Items.Clear()
            ComboBox3.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
            ComboBox3.DataSource = SectionClass.ViewCboxSection
            ComboBox3.Enabled = True
        End If
    End Sub

    Private Sub Employee_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty

            Label5.Text = "*"
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        With EmployeeAddandUpdate
            .Text = "Add"
            .SimpleButton1.Text = "Record"
        End With
        SimpleButton1.Enabled = True
        TextBox1.Text = String.Empty
        SimpleButton2.Visible = False
        SimpleButton3.Visible = False
        Label5.Text = "*"
        TextBox2.Text = String.Empty
        SimpleButton2.Visible = False
    End Sub
End Class
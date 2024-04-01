Public Class User

    Public Statid As String = ""
    Public Userid As Integer
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Label4.Text = "*"
        Label5.Text = "*"
        UserAdd.ShowDialog()
    End Sub

    Private Sub User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Viewdg()
    End Sub

    Public Sub Viewdg()
        dgview.DataSource = ViewClass.FetchUser(Statid, ComboBox4.Text, TextBox3.Text)
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            Statid = "Active"
        End If
        Viewdg()
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            Statid = "Inactive"
        End If
        Viewdg()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Viewdg()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            ComboBox4.DataSource = PositionClass.ViewCboxPosition
            RadioButton4.Checked = False
            ComboBox4.Enabled = True
            Viewdg()
        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            Viewdg()
            RadioButton3.Checked = False
            ComboBox4.DataSource = Nothing
            ComboBox4.Enabled = False
            ComboBox4.Items.Clear()
        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Viewdg()

    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)

            Label4.Text = selectedrow.Cells(1).Value.ToString
            Label5.Text = selectedrow.Cells(2).Value.ToString
            Userid = Integer.Parse(selectedrow.Cells(0).Value.ToString)
            SimpleButton2.Visible = True

            With UserUpdate
                .Label3.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                If selectedrow.Cells(4).Value.ToString = "Active" Then
                    .RadioButton6.Checked = True
                    .RadioButton5.Checked = False
                ElseIf selectedrow.Cells(4).Value.ToString = "Inactive" Then
                    .RadioButton5.Checked = True
                    .RadioButton6.Checked = False
                End If
            End With

            With UserChangePass
                .Label3.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub User_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Label4.Text = "*"
        Label5.Text = "*"
    End Sub

    Private Sub User_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Label4.Text = "*"
            Label5.Text = "*"
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        UpdateSelection.Show()
    End Sub


End Class
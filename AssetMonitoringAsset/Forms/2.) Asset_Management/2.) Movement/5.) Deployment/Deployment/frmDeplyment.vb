Public Class frmDeplyment

    Public RunnerID As Integer

    Private Sub frmDeplyment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()

        dgv.Columns.Clear()

        If ComboBox1.Text = "Procurement" Then
            dgv.DataSource = ViewClass.ViewForDeploymentProcurement
            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.Width = 18 ' Set a reasonable width
            checkBoxColumn.TrueValue = True
            checkBoxColumn.FalseValue = False
            dgv.Columns.Insert(0, checkBoxColumn)

            For i As Integer = 1 To 6
                dgv.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next

            dgv.Columns(1).HeaderText = "Property Code"
            dgv.Columns(2).HeaderText = "Description"
            dgv.Columns(3).HeaderText = "Requested For"
            dgv.Columns(4).HeaderText = "Reference"
            dgv.Columns(5).HeaderText = "Reference No."
            dgv.Columns(6).HeaderText = "Deployed"

            dgv.Columns(6).Visible = False
            dgv.Columns(7).Visible = False
            dgv.Columns(8).Visible = False

        ElseIf ComboBox1.Text = "Borrow" Then

            dgv.DataSource = ViewClass.ViewForDeploymentBorrow

            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.Width = 18 ' Set a reasonable width
            checkBoxColumn.TrueValue = True
            checkBoxColumn.FalseValue = False
            dgv.Columns.Insert(0, checkBoxColumn)

            For i As Integer = 1 To 6
                dgv.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Next

            dgv.Columns(1).HeaderText = "Property Code"
            dgv.Columns(2).HeaderText = "Description"
            dgv.Columns(3).HeaderText = "Requested For"
            dgv.Columns(4).HeaderText = "Date From"
            dgv.Columns(5).HeaderText = "Date To"
            dgv.Columns(6).Visible = False
            dgv.Columns(7).Visible = False

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = String.Empty Then
            MessageBox.Show("Invalid Category", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox2.Text = String.Empty Then
            MessageBox.Show("Please Select Runner to Proceed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            Dim trueCount As Integer = 0

            For Each row As DataGridViewRow In dgv.Rows
                ' Check if the row is not a new row
                If Not row.IsNewRow Then
                    Dim cellValue As Boolean = Convert.ToBoolean(row.Cells(0).Value)
                    If cellValue = True Then
                        trueCount += 1
                    End If
                End If
            Next

            If trueCount = 0 Then
                MessageBox.Show("Please Select to Deploy Items", "Notification")
            Else
                Dim result As DialogResult = MessageBox.Show("Do you want to Deploy this " & trueCount & " Items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then

                    Dim DepID As String = FetchClass.DepID

                    InsertionClass.SaveDeploymentHeader(DepID, RunnerID, ComboBox1.Text)

                    Dim TransID As Integer = FetchClass.DeploymentTransID

                    For Each row As DataGridViewRow In dgv.Rows

                        Dim cellValue As Boolean = Convert.ToBoolean(row.Cells(0).Value)

                        If cellValue = True Then

                            If ComboBox1.Text = "Procurement" Then

                                Dim InvId As Integer = row.Cells(7).Value
                                Dim ProCode As String = row.Cells(1).Value
                                Dim Rqnumber As Integer = row.Cells(8).Value.ToString

                                UpdateClass.UpdateDeploymentProcurement(ProCode, InvId)
                                InsertionClass.SaveDeploymentDetail(ProCode, TransID, Rqnumber)

                            ElseIf ComboBox1.Text = "Borrow" Then

                                Dim InvId As Integer = row.Cells(6).Value
                                Dim ProCode As String = row.Cells(1).Value
                                Dim Rqnumber As Integer = row.Cells(7).Value.ToString

                                UpdateClass.UpdateDeploymentBorrow(ProCode, InvId, RunnerID)
                                InsertionClass.SaveDeploymentDetail(ProCode, TransID, Rqnumber)

                            End If

                        End If

                    Next

                    display()
                    TextBox2.Text = String.Empty
                    MessageBox.Show("Successfully Deployed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ElseIf result = DialogResult.No Then

                End If

            End If

        End If




    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        EmployeeList.modty = 5
        EmployeeList.ShowDialog()
    End Sub

    Private Sub frmDeplyment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub frmDeplyment_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()
    End Sub

End Class
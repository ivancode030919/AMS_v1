﻿Public Class FrmRecvItems
    Public BorrowerID As String
    Private Sub FrmRecvItems_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub FrmRecvItems_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub FrmRecvItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()

        dgv.Columns.Clear()
        dgv.DataSource = ViewClass.ViewForReceiveEndUser(ComboBox1.Text)

        If ComboBox1.Text = "Procurement" Then

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
            dgv.Columns(6).HeaderText = "Receive"
            dgv.Columns(7).Visible = False
            dgv.Columns(6).Visible = False

            dgv.Columns.Add("Col8", "Receive")
            dgv.Columns(8).HeaderText = "Receive"

            CheckReceive()

        ElseIf ComboBox1.Text = "Borrow" Then
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
            dgv.Columns(6).HeaderText = "Remarks"
            dgv.Columns(7).Visible = False

        ElseIf ComboBox1.Text = "Transfer Ownership" Then
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = String.Empty Then
            MessageBox.Show("Invalid Category", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf TextBox1.Text = String.Empty Then
            MessageBox.Show("Please Select Receive By to Proceed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                Dim result As DialogResult = MessageBox.Show("Do you want to Receive this " & trueCount & " Items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then

                    For Each row As DataGridViewRow In dgv.Rows

                        Dim cellValue As Boolean = Convert.ToBoolean(row.Cells(0).Value)

                        If cellValue = True Then

                            Dim InvId As Integer = row.Cells(7).Value
                            Dim ProCode As String = row.Cells(1).Value

                            If ComboBox1.Text = "Procurement" Then
                                UpdateClass.UpdateReceivePROCUREMENT(ProCode, InvId, BorrowerID)
                            ElseIf ComboBox1.Text = "Borrow" Then
                                UpdateClass.UpdateReceiveBorrow(ProCode, InvId, BorrowerID)
                            ElseIf ComboBox1.Text = "Transfer Ownership" Then

                            End If


                        End If

                    Next

                    display()
                    TextBox1.Text = String.Empty
                    MessageBox.Show("Successfully Deployed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ElseIf result = DialogResult.No Then

                End If
            End If

        End If




    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        EmployeeList.modty = 6
        EmployeeList.ShowDialog()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()
    End Sub

    Private Sub CheckReceive()
        If ComboBox1.Text = "Procurement" Then

            If dgv.Rows.Count > 0 Then

                For Each row1 As DataGridViewRow In dgv.Rows
                    If Convert.ToBoolean(row1.Cells(6).Value) = False Then
                        row1.Cells(8).Value = "Not Receive"
                    Else
                        row1.Cells(8).Value = "Receive"
                    End If
                Next


            End If

        End If
    End Sub
End Class
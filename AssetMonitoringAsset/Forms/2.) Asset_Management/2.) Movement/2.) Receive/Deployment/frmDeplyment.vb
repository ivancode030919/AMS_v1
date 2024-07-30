﻿Public Class frmDeplyment
    Private Sub frmDeplyment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv.Columns.Clear()
        dgv.DataSource = ViewClass.ViewForDeployment

        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.Width = 18 ' Set a reasonable width
        checkBoxColumn.TrueValue = True
        checkBoxColumn.FalseValue = False
        dgv.Columns.Insert(0, checkBoxColumn)

        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dgv.Columns(1).HeaderText = "Property Code"
        dgv.Columns(2).HeaderText = "Description"
        dgv.Columns(3).HeaderText = "Requested For"
        dgv.Columns(4).HeaderText = "Reference"
        dgv.Columns(5).HeaderText = "Reference No."
        dgv.Columns(6).HeaderText = "Deployed"

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


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

                For Each row As DataGridViewRow In dgv.Rows
                    Dim cellValue As Boolean = Convert.ToBoolean(row.Cells(0).Value)

                    If cellValue = True Then
                        Dim InvId As Integer = row.Cells(7).Value
                        Dim ProCode As String = row.Cells(1).Value
                        MsgBox(InvId & " and " & ProCode)
                        UpdateClass.UpdateDeployment(ProCode, InvId)
                    End If

                Next

                display()
                MessageBox.Show("Successfully Deployed", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ElseIf result = DialogResult.No Then

            End If
        End If


    End Sub
End Class
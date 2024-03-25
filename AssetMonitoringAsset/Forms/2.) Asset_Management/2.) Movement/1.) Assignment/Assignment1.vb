Public Class Assignment1

    Public headerid As Integer
    Public requestor As Integer
    Public allowtoaddrow As String = "Y"
    Private Sub Assignment1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If allowtoaddrow = "Y" Then
            dgv.AllowUserToAddRows = True


        ElseIf allowtoaddrow = "N" Then
            dgv.AllowUserToAddRows = False

        End If
        display()


    End Sub


    Public Sub display()

        ViewClass.FetchRegisterDetail(headerid)
        With dgv
            .Columns(1).HeaderText = "Asset Code"
            .Columns(2).HeaderText = "Class"
            .Columns(3).HeaderText = "Assign For"
            .Columns(4).HeaderText = "Quantity"
            .Columns(5).HeaderText = "Remarks"
            .Columns(6).HeaderText = "State"
            .Columns(7).HeaderText = "Available Quantity"
            .Columns(8).HeaderText = "NewOwnderID"

            .Columns(0).Visible = False
            .Columns(8).Visible = False

            .Columns.Add("9", "Assigned Asset")
            .Columns(9).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True

            If allowtoaddrow = "N" Then
                .Columns(4).ReadOnly = True
                .Columns(6).Visible = True
            ElseIf allowtoaddrow = "Y" Then
                .Columns(4).ReadOnly = False
                .Columns(6).Visible = False
            End If
        End With
    End Sub

    Public Sub display2()

        With dgv
            .Columns(1).HeaderText = "Asset Code"
            .Columns(2).HeaderText = "Class"
            .Columns(3).HeaderText = "Assign For"
            .Columns(4).HeaderText = "Quantity"
            .Columns(5).HeaderText = "Remarks"
            .Columns(6).HeaderText = "State"
            .Columns(7).HeaderText = "Available Quantity"
            .Columns(8).HeaderText = "NewOwnderID"
            .Columns(0).Visible = False
            .Columns(8).Visible = False

            .Columns.Add("9", "Assigned Asset")
            .Columns(9).ReadOnly = True
        End With
    End Sub

    Private Sub Assignment1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        If allowtoaddrow = "Y" Then

            If e.ColumnIndex = 1 Then

                Dim index As Integer
                index = e.RowIndex
                Dim selectedrow As DataGridViewRow
                selectedrow = dgv.Rows(index)

                With AssetList3
                    .rowToEdit = index
                    .mode1 = 1
                    .modty = 5
                    .ac = selectedrow.Cells(1).Value
                    .Show()
                End With
            ElseIf e.ColumnIndex = 3 Then

                Dim index As Integer
                index = e.RowIndex
                Dim selectedrow As DataGridViewRow
                selectedrow = dgv.Rows(index)

                With empllist
                    .rowToEdit = index
                    .modty = 4
                    .Show()
                End With

            ElseIf e.ColumnIndex = 8 Then

                Dim index As Integer
                index = e.RowIndex
                Dim selectedrow As DataGridViewRow
                selectedrow = dgv.Rows(index)

                With AssetList3
                    .rowToEdit = index
                    .mode1 = 3
                    .modty = 4
                    .ac = selectedrow.Cells(1).Value
                    .Show()
                End With

            End If

        ElseIf allowtoaddrow = "N" Then

            If e.ColumnIndex = 9 Then
                Dim index As Integer
                index = e.RowIndex
                Dim selectedrow As DataGridViewRow
                selectedrow = dgv.Rows(index)

                With AssetList3
                    .rowToEdit = index
                    .mode1 = 3
                    .modty = 4
                    .ac = selectedrow.Cells(1).Value
                    .Show()
                End With

            End If

        End If




    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim user As Integer = Home.UserID
        InsertionClass.SaveAssignmentHeader(TextBox1.Text, user, DateTimePicker1.Value, headerid)

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then

                Dim id As String = row.Cells(0).Value
                Dim ItemCode As String = row.Cells(1).Value
                Dim qty As String = row.Cells(4).Value
                Dim Propertycode As String = row.Cells(9).Value
                Dim NewOwnerID As String = row.Cells(8).Value

                UpdateClass.UpdateAssignProperty(Propertycode, NewOwnerID)
                UpdateClass.UpdateStatusReq(id)
                InsertionClass.SaveAssignmentDetails(Double.Parse(qty), Propertycode, headerid, user, ItemCode)

            End If
        Next
        MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
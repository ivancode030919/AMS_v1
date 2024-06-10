Public Class Assignment1

    Public headerid As Integer
    Public requestor As Integer
    Public allowtoaddrow As Boolean = False
    Public winstatemax As Boolean = False

    Private Sub Assignment1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If allowtoaddrow = True Then

            dgv.AllowUserToAddRows = True
            TextBox1.Text = FetchClass.FetchAssignmentEntryNumber
            TextBox2.Text = FetchClass.fetchRequestor(Home.EmployeeID)

        ElseIf allowtoaddrow = False Then
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
            .Columns(9).HeaderText = "Assign Asset"

            .Columns(0).Visible = False
            .Columns(8).Visible = False

            '.Columns.Add("9", "Assigned Asset")
            .Columns(9).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True

            If allowtoaddrow = False Then
                .Columns(4).ReadOnly = True
                .Columns(6).Visible = True
            ElseIf allowtoaddrow = True Then
                .Columns(4).ReadOnly = False
                .Columns(6).Visible = False
            End If
        End With


    End Sub

    Private Sub Assignment1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim committedRowsCount As Integer = dgv.Rows.Cast(Of DataGridViewRow)().Count(Function(row) Not row.IsNewRow)

        If committedRowsCount >= 1 Then
            MsgBox("save dapat")

        ElseIf committedRowsCount = 0 Then
            MsgBox("not save")
        End If

        If winstatemax = True Then
            Home.IsMdiContainer = False
            winstatemax = False
            Me.Dispose()
        Else
            Me.Dispose()
        End If

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        'Try
        Dim row As Integer = dgv.CurrentCell.RowIndex

        If allowtoaddrow = True Then

            If e.ColumnIndex = 1 Then

                With AssetList3
                    .rowToEdit = row
                    .mode1 = 1
                    .modty = 5
                    .ac = dgv.Rows(row).Cells(1).Value
                    .ShowDialog()
                End With

            ElseIf e.ColumnIndex = 3 Then

                With empllist
                    .rowToEdit = row
                    .modty = 4
                    .ShowDialog()
                End With

            ElseIf e.ColumnIndex = 9 Then

                With AssetList3
                    .rowToEdit = row
                    .modty = 4
                    .mode1 = 3
                    .AssignQty = dgv.Rows(row).Cells(4).Value
                    .Newowner = dgv.Rows(row).Cells(8).Value
                    .ItemClass = dgv.Rows(row).Cells(2).Value
                    .ac = dgv.Rows(row).Cells(1).Value
                    .ShowDialog()
                End With

            End If

        ElseIf allowtoaddrow = False Then

            If e.ColumnIndex = 9 Then

                With AssetList3
                    .rowToEdit = row
                    .mode1 = 3
                    .modty = 4
                    .AssignQty = dgv.Rows(row).Cells(4).Value
                    .Newowner = dgv.Rows(row).Cells(8).Value
                    .ItemClass = dgv.Rows(row).Cells(2).Value
                    .ac = dgv.Rows(row).Cells(1).Value
                    .ReqId = dgv.Rows(row).Cells(0).Value
                    .ShowDialog()

                End With

            End If

            End If
        'Catch ex As Exception
        '    MsgBox("Assignment.Error.Double.Click.01")
        'End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgv_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValidated

        If allowtoaddrow = True Then

            If e.ColumnIndex = 1 Then

                For Each row As DataGridViewRow In dgv.Rows

                    'Assuming itemcode is stored in a specific column (adjust as needed)
                    Dim itemcode As String = row.Cells(1).Value

                    'Fetch asset without owner for the specific itemcode
                    row.Cells(7).Value = FetchClass.FetchAssetWithoutOwner(itemcode)

                    'Check if the Item is Consumable or Non-Consumable
                    If FetchClass.CheckifCosumable(itemcode) Is Nothing Then
                        row.Cells(4).Value = "1"
                        row.Cells(4).ReadOnly = True
                    Else
                        row.Cells(4).Value = ""
                        row.Cells(4).ReadOnly = False
                    End If

                    'Clear if no Available Assets
                    If row.Cells(7).Value Is Nothing Then
                        row.Cells(7).Value = 0
                        MessageBox.Show("No Available Asset for this Item", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        row.Cells(1).Value = String.Empty
                        row.Cells(2).Value = String.Empty
                        row.Cells(3).Value = String.Empty
                        row.Cells(4).Value = String.Empty
                        row.Cells(5).Value = String.Empty
                        row.Cells(6).Value = String.Empty
                        row.Cells(7).Value = String.Empty
                        row.Cells(8).Value = String.Empty
                        row.Cells(9).Value = String.Empty
                        row.Cells(1).Selected = True
                    Else

                    End If

                Next

            End If

        ElseIf allowtoaddrow = False Then
            ' Handle the case when adding rows is not allowed
        End If

    End Sub

    Private Sub Assignment1_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave

        Dim committedRowsCount As Integer = dgv.Rows.Cast(Of DataGridViewRow)().Count(Function(row) Not row.IsNewRow)

        If committedRowsCount >= 1 Then
            MsgBox("save dapat")

        ElseIf committedRowsCount = 0 Then
            MsgBox("not save")
        End If

        If winstatemax = True Then
            Home.IsMdiContainer = False
            winstatemax = False
            Me.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub



    Private Sub AddRecord()

        Dim user As Integer = Home.UserID

            InsertionClass.SaveAssignmentHeader(TextBox1.Text, user, DateTimePicker1.Value, headerid)

        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                Dim headid As Integer = FetchClass.FetchTransHeaderIDAssignment
                Dim id As String = row.Cells(0).Value
                Dim ItemCode As String = row.Cells(1).Value
                Dim qty As String = row.Cells(4).Value
                Dim Propertycode As String = row.Cells(9).Value
                Dim NewOwnerID As String = row.Cells(8).Value
                Dim Availableqty As String = row.Cells(7).Value

                If allowtoaddrow = True Then

                ElseIf allowtoaddrow = False Then

                    UpdateClass.UpdateStatusReq(id)

                End If

                InsertionClass.SaveAssignmentDetails(Double.Parse(qty), Propertycode, headid, user, ItemCode, Availableqty)

            End If
        Next

        Rqregister.display()
        MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

        TextBox1.Text = FetchClass.FetchAssignmentEntryNumber
        dgv.Rows.Clear()
        dgv.Enabled = True

    End Sub
End Class
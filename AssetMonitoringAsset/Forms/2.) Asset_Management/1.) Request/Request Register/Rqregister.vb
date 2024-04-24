Public Class Rqregister

    Public headerid As Integer
    Public requestby As Integer
    Public Rtype As String = ""
    Private qtysum As Integer

    Private Sub Rqregister_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Rstatus As String = FetchClass.FetchRequestStatus(TextBox1.Text)
        If Rstatus = "OPEN" Then
            SimpleButton1.Enabled = True
            SimpleButton2.Enabled = True
            SimpleButton3.Enabled = True
            Label3.Visible = False
            dgv.Enabled = True
            ForQtySum()
        ElseIf Rstatus = "CANCELLED" Then
            SimpleButton1.Enabled = False
            SimpleButton2.Enabled = False
            SimpleButton3.Enabled = False
            Label3.Visible = True
            dgv.Enabled = False
        Else
            SimpleButton1.Enabled = False
            SimpleButton2.Enabled = False
            SimpleButton3.Enabled = False
            dgv.Enabled = False
        End If
        display()
    End Sub

    Public Sub display()
        SimpleButton2.Text = "Record"
        ViewClass.FetchRegisterDetail1(headerid, Rtype)

        If Rtype = "PROCURE" Then
            SimpleButton1.Visible = True
            With dgv
                .Columns(1).HeaderText = "Asset Code"
                .Columns(2).HeaderText = "Class"
                .Columns(3).HeaderText = "Request For"
                .Columns(4).HeaderText = "Quantity"
                .Columns(5).HeaderText = "Remarks"
                .Columns(6).HeaderText = "State"
                .Columns(7).HeaderText = "Available"
                .Columns(8).HeaderText = "RequestorID"
                .Columns(0).Visible = False
                .Columns(8).Visible = False
                .ReadOnly = True
            End With
        ElseIf Rtype = "BORROW" Then
            SimpleButton1.Enabled = False
            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Borrowee"
                .Columns(4).HeaderText = "Date Borrowed"
                .Columns(5).HeaderText = "Date to be Return"
                .Columns(6).HeaderText = "Remarks"
                .Columns(7).Visible = False
                .ReadOnly = True
            End With
        ElseIf Rtype = "TRANSFER OWNERSHIP" Then
            'DISPLAY IF THE REQUEST TYPE IS TRANSFER OWNERSHIP
        End If

    End Sub

    Private Sub Closing1()
        dgv.Columns.Clear()
        qtysum = 0
    End Sub

    Private Sub Rqregister_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Closing1()
    End Sub

    Private Sub ForQtySum()

        If TextBox3.Text = "PROCURE" Then
            ' Initialize qtysum to 0 before the loop
            Dim qtysum As Integer = 0

            For Each row As DataGridViewRow In dgv.Rows
                ' Check if the cell value is not null before parsing
                Dim cellValue As Object = row.Cells(7).Value

                If cellValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cellValue.ToString()) Then
                    qtysum += Integer.Parse(cellValue.ToString())
                End If
            Next

            Dim Rstatus As String = FetchClass.FetchRequestStatus(TextBox1.Text)
            If Rstatus = "OPEN" Then

                If qtysum > 0 Then
                    SimpleButton1.Enabled = True
                Else
                    SimpleButton1.Enabled = False
                End If

            End If


        ElseIf TextBox3.Text = "BORROW" Then
            ElseIf TextBox3.Text = "TRANSFER OWNERSHIP" Then

            End If

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        If TextBox3.Text = "PROCURE" Then
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow

            selectedrow = dgv.Rows(index)

            Dim row As Integer = dgv.CurrentCell.RowIndex
            If e.ColumnIndex = 6 Then

                With ChngState
                    .rowToEdit = row
                    .id = selectedrow.Cells(0).Value
                    .Stat = selectedrow.Cells(6).Value
                    .ShowDialog()
                End With

            End If
        ElseIf TextBox3.Text = "BORROW" Then
        ElseIf TextBox3.Text = "TRANSFER OWNERSHIP" Then

        End If

    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        With Assignment1
            .TextBox1.Text = TextBox1.Text
            .TextBox2.Text = TextBox2.Text
            .allowtoaddrow = "N"

            .headerid = headerid
            .requestor = requestby
            .Show()
        End With
    End Sub

    Private Sub dgv_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.RowValidated
        If TextBox3.Text = "PROCURE" Then

            Try

                Dim Rstatus As String = FetchClass.FetchRequestStatus(TextBox1.Text)
                If Rstatus = "OPEN" Then
                    For Each row As DataGridViewRow In dgv.Rows

                        If row.Cells(6).Value.ToString = "CLOSED" Then
                            SimpleButton1.Enabled = False
                            ' type1 for update to be re-use it is a condition on update
                            Dim type1 As Integer = 1
                            UpdateClass.UpdateStatusReqHeader(headerid, type1)


                        ElseIf row.Cells(7).Value.ToString = 0 Then

                            SimpleButton1.Enabled = False
                        Else
                            SimpleButton1.Enabled = True
                        End If

                    Next
                End If

            Catch ex As Exception
                MsgBox("Error.For Approval.02")
            End Try

        ElseIf TextBox3.Text = "BORROW" Then

        ElseIf TextBox3.Text = "TRANSFER OWNERSHIP" Then

        End If




    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            If SimpleButton2.Text = "Record" Then

                If TextBox3.Text = "PROCURE" Then

                    ' type1 for update to be re-use it is a condition on update
                    Dim type1 As Integer = 2
                    UpdateClass.UpdateStatusReqHeader(headerid, type1)
                    InsertionClass.SaveProcurementHeader(TextBox1.Text, Home.EmployeeID, DateTimePicker1.Value)

                    For Each row As DataGridViewRow In dgv.Rows

                        If Not row.IsNewRow Then

                            Dim HeaderId As Integer = FetchClass.FetchTransIdForApproval
                            Dim AssetCode As String = row.Cells(1).Value.ToString
                            Dim ItemClass As String = row.Cells(2).Value.ToString
                            Dim RequestFor As String = row.Cells(8).Value.ToString
                            Dim Quantity As String = row.Cells(4).Value.ToString
                            Dim Remarks As String = row.Cells(5).Value.ToString
                            Dim State As String = row.Cells(6).Value.ToString
                            InsertionClass.SaveProcurementDetail(AssetCode, ItemClass, RequestFor, Quantity, Remarks, State, HeaderId)

                        End If
                    Next
                    RequestRegister.display()
                    MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton2.Text = "Close"

                ElseIf TextBox3.Text = "BORROW" Then

                    ' type1 for update to be re-use it is a condition on update
                    Dim type1 As Integer = 1
                    UpdateClass.UpdateStatusReqHeader(headerid, type1)
                    InsertionClass.SaveBorrowHeader(TextBox1.Text, Home.EmployeeID, DateTimePicker1.Value)

                    For Each row As DataGridViewRow In dgv.Rows

                        If Not row.IsNewRow Then
                            Dim HeaderId As Integer = FetchClass.FetchTransIdForApprovalBorrow

                            Dim PropertyCode As String = row.Cells(0).Value.ToString
                            Dim Quanity As String = row.Cells(2).Value.ToString
                            Dim Borrowee As String = row.Cells(7).Value.ToString
                            Dim DateBorrow As String = row.Cells(4).Value.ToString
                            Dim DateTobeReturn As String = row.Cells(5).Value.ToString
                            Dim Remarks As String = row.Cells(6).Value.ToString
                            InsertionClass.SaveBorrowDetail(PropertyCode, Quanity, Borrowee, DateBorrow, DateTobeReturn, Remarks, HeaderId)

                        End If
                    Next
                    RequestRegister.display()
                    MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    SimpleButton2.Text = "Close"
                ElseIf TextBox3.Text = "TRANSFER OWNERSHIP" Then
                    '' type1 for update to be re-use it is a condition on update
                    'Dim type1 As Integer = 2
                    'UpdateClass.UpdateStatusReqHeader(headerid, type1)
                    'InsertionClass.SaveProcurementHeader(TextBox1.Text, Home.EmployeeID, DateTimePicker1.Value)

                    'For Each row As DataGridViewRow In dgv.Rows

                    '    If Not row.IsNewRow Then

                    '        Dim HeaderId As Integer = FetchClass.FetchTransIdForApproval
                    '        Dim AssetCode As String = row.Cells(1).Value.ToString
                    '        Dim ItemClass As String = row.Cells(2).Value.ToString
                    '        Dim RequestFor As String = row.Cells(8).Value.ToString
                    '        Dim Quantity As String = row.Cells(4).Value.ToString
                    '        Dim Remarks As String = row.Cells(5).Value.ToString
                    '        Dim State As String = row.Cells(6).Value.ToString
                    '        InsertionClass.SaveProcurementDetail(AssetCode, ItemClass, RequestFor, Quantity, Remarks, State, HeaderId)

                    '    End If
                    'Next
                    'RequestRegister.display()
                    'MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'SimpleButton2.Text = "Close"
                End If



            ElseIf SimpleButton2.Text = "Close" Then
                closingform()
            End If


        Catch ex As Exception
            MsgBox("Error.For Approval.01")
        End Try
    End Sub


    Private Sub closingform()
        Me.Close()

    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        Dim result As DialogResult = MessageBox.Show("Do you want to cancel this Request?", "Decision Box", MessageBoxButtons.YesNo)

        If result = DialogResult.Yes Then
            With ReqCancel
                .requestno = TextBox1.Text
                .ShowDialog()
            End With
        Else

        End If

    End Sub


End Class
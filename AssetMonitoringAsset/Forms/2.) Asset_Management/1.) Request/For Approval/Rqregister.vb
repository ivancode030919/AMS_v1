Public Class Rqregister

    Public headerid As Integer
    Public requestby As Integer
    Public Rtype As String = ""
    Private qtysum As Integer

    Private Sub Rqregister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
        ForQtySum()

    End Sub

    Public Sub display()

        If Rtype = "Procure" Then
            'DISPLAY IF THE REQUEST TYPE IS PROCUREMENT
            ViewClass.FetchRegisterDetail1(headerid, Rtype)

            'dgv.Enabled = True
            With dgv
                .Columns(1).HeaderText = "Asset Code"
                .Columns(2).HeaderText = "Class"
                .Columns(3).HeaderText = "Request For"
                .Columns(4).HeaderText = "Quantity"
                .Columns(5).HeaderText = "Remarks"
                .Columns(6).HeaderText = "State"
                .Columns(7).HeaderText = "Available"
                .Columns(0).Visible = False
                .ReadOnly = True
            End With

        ElseIf Rtype = "Borrow" Then
            'DISPLAY IF THE REQUEST TYPE IS BORROW
        ElseIf Rtype = "PrTransfer Ownershipocure" Then
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
        ' Initialize qtysum to 0 before the loop
        Dim qtysum As Integer = 0

        For Each row As DataGridViewRow In dgv.Rows
            ' Check if the cell value is not null before parsing
            Dim cellValue As Object = row.Cells(7).Value

            If cellValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(cellValue.ToString()) Then
                qtysum += Integer.Parse(cellValue.ToString())
            End If
        Next

        If qtysum > 0 Then
            SimpleButton1.Visible = True
        Else
            SimpleButton1.Visible = False
        End If
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

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

        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(6).Value.ToString = "CLOSED" Then
                SimpleButton1.Visible = False
                UpdateClass.UpdateStatusReqHeader(headerid)
            Else
                SimpleButton1.Visible = True
            End If
        Next

    End Sub
End Class
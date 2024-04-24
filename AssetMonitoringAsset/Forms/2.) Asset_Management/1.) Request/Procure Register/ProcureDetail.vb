Public Class ProcureDetail
    Public transid As Integer
    Public btnColumn As New DataGridViewButtonColumn()
    Private Sub ProcureDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        display()
    End Sub

    Public Sub display()
        dgv.Rows.Clear()
        dgv.Columns.Clear()
        btnColumn.Dispose()
        dgv.DataSource = ViewClass.ViewProcureDetails(transid)
        With dgv
            .Columns(0).HeaderText = "Item Code"
            .Columns(1).HeaderText = "Class"
            .Columns(2).HeaderText = "Request For"
            .Columns(3).HeaderText = "Quantity"
            .Columns(4).HeaderText = "Remarks"
            .Columns(5).HeaderText = "Status"

            ' Create a new DataGridViewButtonColumn


            btnColumn.HeaderText = "Action"
            btnColumn.Text = "Button Text" ' Set the text displayed on the buttons
            btnColumn.UseColumnTextForButtonValue = True ' Display the same text for all buttons

            ' Add the button column after the "Status" column (index 5)
            .Columns.Insert(6, btnColumn)
            MsgBox("Before Load: btnColumn index = " & dgv.Columns.IndexOf(btnColumn))
        End With
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProcureDetail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgv.DataSource = Nothing
        dgv.Columns.Clear()
        dgv.Rows.Clear()
        btnColumn.Dispose()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick

        If e.ColumnIndex = 6 Then
            Dim row As Integer = dgv.CurrentCell.RowIndex
            Dim itmcd As String = dgv.Rows(row).Cells(0).Value.ToString
            Dim itmid As String = dgv.Rows(row).Cells(7).Value.ToString

            With RecvReqConfrm
                .ItemCode = itmcd
                .ItemId = itmid
                .ShowDialog()
            End With
        End If
    End Sub
End Class
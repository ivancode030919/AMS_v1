Public Class ProcureDetail
    Public transid As Integer
    Public Colindex As Integer

    Private Sub ProcureDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        display()
    End Sub

    Public Sub display()

        With DataGridView1
            .DataSource = Nothing
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()

        End With

        DataGridView1.DataSource = ViewClass.ViewProcureDetails(transid)

        With DataGridView1
            .Columns(0).HeaderText = "Item Code"
            .Columns(1).HeaderText = "Class"
            .Columns(2).HeaderText = "Request For"
            .Columns(3).HeaderText = "Quantity"
            .Columns(4).HeaderText = "Remarks"
            .Columns(5).HeaderText = "Status"
            .Columns(6).Visible = False
            .Columns(7).Visible = False

            .Columns(8).HeaderText = "Property Code"
            .Columns(9).HeaderText = "Description"
            .Columns(10).HeaderText = "Ref"
            .Columns(11).HeaderText = "Refno"

            Dim btnColumn As New DataGridViewButtonColumn()
            btnColumn.Name = "UpdateStat"
            btnColumn.HeaderText = "Update Status"
            btnColumn.Text = "Update"
            btnColumn.UseColumnTextForButtonValue = True
            .Columns.Add(btnColumn)

        End With

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ProcureDetail_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        With DataGridView1
            .DataSource = Nothing
            .Columns.Clear()
            .Rows.Clear()
            .Refresh()

        End With
    End Sub

    'Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles SimpleButton2.Click

    '    For Each row As DataGridViewRow In DataGridView1.Rows

    '        If row.Cells(5).Value.ToString = "RECEIVED" Then

    '            'Dim totalRowCount As Integer = dgv.Rows.Count

    '            'MsgBox(totalRowCount)

    '            MsgBox("Hello")
    '        End If

    '    Next

    'End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        'Dim row As Integer = DataGridView1.CurrentCell.ColumnIndex

        'MsgBox(row)
        'MsgBox(DataGridView1.Columns(row).Name)
        'If col = 5 Then
        '    Dim row As Integer = DataGridView1.CurrentCell.RowIndex
        '    Dim itmcd As String = DataGridView1.Rows(row).Cells(0).Value.ToString
        '    Dim itmid As String = DataGridView1.Rows(row).Cells(6).Value.ToString

        'End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If e.ColumnIndex = DataGridView1.Columns("UpdateStat").Index Then

            Dim row As Integer = DataGridView1.CurrentCell.RowIndex
            Dim itmcd As Integer
            Dim itmid As Integer


            If DataGridView1.Columns(0).Name <> "AssetCode" Then
                itmcd = Integer.Parse(DataGridView1.Rows(row).Cells(1).Value.ToString())
            Else
                itmcd = Integer.Parse(DataGridView1.Rows(row).Cells(0).Value.ToString())
            End If

            If DataGridView1.Columns(6).Name <> "id" Then
                itmid = Integer.Parse(DataGridView1.Rows(row).Cells(6 + 1).Value.ToString())
            Else
                itmid = Integer.Parse(DataGridView1.Rows(row).Cells(6).Value.ToString())
            End If

            With RecvReqConfrm
                .ItemCode = itmcd
                .ItemId = itmid
                .rowToEdit = row
                .ShowDialog()
            End With


            RecordReceiveItems()

        End If

    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub RecordReceiveItems()

        For Each row As DataGridViewRow In DataGridView1.Rows

            Dim stat As String = row.Cells(5).Value.ToString

            If stat = "RECEIVED" Then

                If Not row.IsNewRow Then

                    Dim Itemcode As Integer = Integer.Parse(row.Cells(0).Value.ToString)
                    Dim ItemClass As String = row.Cells(1).Value.ToString
                    Dim PropertyCode As String = row.Cells(8).Value.ToString
                    Dim Description As String = row.Cells(9).Value.ToString
                    Dim qty As String = row.Cells(3).Value.ToString
                    Dim owner As String = row.Cells(7).Value.ToString
                    Dim reference As String = row.Cells(10).Value.ToString
                    Dim referenceno As String = row.Cells(11).Value.ToString

                    Dim PropertyCodeCount As Integer = FetchClass.FetchPropertyCode(PropertyCode)

                    If PropertyCodeCount = 0 Then

                        InsertionClass.SaveAssetInventory(Itemcode, ItemClass, PropertyCode, Description, Double.Parse(qty), Integer.Parse(owner), Integer.Parse(owner), 0, reference, referenceno, "Not Allowed", 0, 0, "New Item: Good", 0, False, True)
                        MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Else

                    End If


                End If

            Else

            End If

        Next

    End Sub
End Class
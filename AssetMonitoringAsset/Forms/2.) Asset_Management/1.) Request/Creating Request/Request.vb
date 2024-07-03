Public Class Request


    Public branID As Integer
    Public depID As Integer
    Public SecID As Integer
    Public EmpID As Integer


    Private Sub AcquisitionRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.Select()
        TextBox2.Text = FetchClass.fetchRequestor(Home.EmployeeID)
        ComboBox2.Enabled = True
    End Sub

    Public Sub DisplayProcure()

        dgv.Columns.Add("0", "Asset Code")
        dgv.Columns.Add("1", "Description")
        dgv.Columns.Add("2", "Quantity")
        dgv.Columns.Add("3", "Owner")
        dgv.Columns.Add("4", "Remarks")
        dgv.Columns.Add("5", "EmplID")
        dgv.Columns.Add("6", "Category")

        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(3).ReadOnly = True

        dgv.Columns(5).Visible = False
        dgv.Columns(6).Visible = False

    End Sub
    Public Sub DisplayBorrow()

        dgv.Columns.Add("0", "Property Code")
        dgv.Columns.Add("1", "Description")
        dgv.Columns.Add("2", "Quantity")
        dgv.Columns.Add("3", "Borrowee")
        dgv.Columns.Add("4", "Date From")
        dgv.Columns.Add("5", "Date To")
        dgv.Columns.Add("6", "Remarks")
        dgv.Columns.Add("7", "EmplID")

        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(3).ReadOnly = True
        dgv.Columns(4).ReadOnly = True
        dgv.Columns(5).ReadOnly = True
        dgv.Columns(7).Visible = False
    End Sub

    Public Sub DisplayTransfer()

        dgv.Columns.Add("0", "Property Code")
        dgv.Columns.Add("1", "Description")
        dgv.Columns.Add("2", "Quantity")
        dgv.Columns.Add("3", "New Owner")
        dgv.Columns.Add("4", "Remarks")
        dgv.Columns.Add("5", "EmplID")

        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(3).ReadOnly = True
    End Sub


    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex

        If e.ColumnIndex = 0 AndAlso ComboBox2.Text = "PROCURE" Then
            AssetList3.modty = 2
            AssetList3.mode1 = 1
            AssetList3.rowToEdit = row
            AssetList3.ShowDialog()
        ElseIf e.ColumnIndex = 3 AndAlso ComboBox2.Text = "PROCURE" Then
            Empllist.modty = 1
            Empllist.rowToEdit = row
            Empllist.ShowDialog()
        ElseIf e.ColumnIndex = 0 AndAlso ComboBox2.Text = "BORROW" Then
            AssetList3.modty = 3
            AssetList3.mode1 = 2
            AssetList3.rowToEdit = row
            AssetList3.ShowDialog()
        ElseIf e.ColumnIndex = 3 AndAlso ComboBox2.Text = "BORROW" Then
            Empllist.modty = 2
            Empllist.rowToEdit = row
            Empllist.ShowDialog()
        ElseIf e.ColumnIndex = 4 AndAlso ComboBox2.Text = "BORROW" Then
            date1.modty = 1
            date1.Text = "Date From"
            date1.rowToEdit = row
            date1.ShowDialog()
        ElseIf e.ColumnIndex = 5 AndAlso ComboBox2.Text = "BORROW" Then
            date1.modty = 2
            date1.Text = "Date To"
            date1.rowToEdit = row
            date1.ShowDialog()
        ElseIf e.ColumnIndex = 0 AndAlso ComboBox2.Text = "TRANSFER OWNERSHIP" Then
            AssetList3.modty = 3
            AssetList3.mode1 = 2
            AssetList3.rowToEdit = row
            AssetList3.ShowDialog()
        ElseIf e.ColumnIndex = 3 AndAlso ComboBox2.Text = "TRANSFER OWNERSHIP" Then
            Empllist.modty = 3
            Empllist.rowToEdit = row
            Empllist.ShowDialog()
        End If


    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If ComboBox2.Text = "" Then
            MessageBox.Show("Please Select Transaction Type...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf dgv.Rows.Count <= 1 Then
            MessageBox.Show("Please Input Items to be Requested...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If SimpleButton2.Text = "Record" Then
                Dim Stat1 As String = "OPEN"
                Dim rn As String = FetchClass.FetchEntryID2

                InsertionClass.SaveRequestHeader(rn, Home.EmployeeID, DateTimePicker1.Value, Stat1, ComboBox2.Text)
                If ComboBox2.Text = "PROCURE" Then

                    For Each row As DataGridViewRow In dgv.Rows

                        If Not row.IsNewRow Then
                            Dim headid = FetchClass.FetchTransHeaderIDRequest
                            Dim AssetCode As String = row.Cells(0).Value.ToString
                            Dim Des As String = row.Cells(1).Value.ToString
                            Dim qty As String = row.Cells(2).Value.ToString
                            Dim Owner As String = row.Cells(5).Value.ToString
                            Dim Remarks As String = row.Cells(4).Value.ToString
                            InsertionClass.SaveProcurement(Integer.Parse(AssetCode), Des, Double.Parse(qty), Integer.Parse(Owner), Remarks, headid)
                        End If
                    Next

                ElseIf ComboBox2.Text = "BORROW" Then

                    For Each row As DataGridViewRow In dgv.Rows
                        If Not row.IsNewRow Then
                            Dim headid = FetchClass.FetchTransHeaderIDRequest
                            Dim PropertyCode As String = row.Cells(0).Value.ToString
                            Dim Des As String = row.Cells(1).Value.ToString
                            Dim qty As String = row.Cells(2).Value.ToString
                            Dim Borrowee As String = row.Cells(7).Value.ToString
                            Dim DateFrom As String = row.Cells(4).Value.ToString
                            Dim DateTo As String = row.Cells(5).Value.ToString
                            Dim Remarks As String = row.Cells(6).Value.ToString
                            InsertionClass.SaveBorrow(PropertyCode, Des, Double.Parse(qty), Integer.Parse(Borrowee), Remarks, Date.Parse(DateFrom), Date.Parse(DateTo), headid)
                        End If
                    Next
                ElseIf ComboBox2.Text = "TRANSFER OWNERSHIP" Then

                    For Each row As DataGridViewRow In dgv.Rows

                        If Not row.IsNewRow Then
                            Dim headid As Integer = FetchClass.FetchTransHeaderIDRequest
                            Dim PropertyCode As String = row.Cells(0).Value.ToString
                            Dim Des As String = row.Cells(1).Value.ToString
                            Dim qty As String = row.Cells(2).Value.ToString
                            Dim Newowner As String = row.Cells(5).Value.ToString
                            Dim Remarks As String = row.Cells(4).Value.ToString
                            InsertionClass.SaveTRansferOwner(PropertyCode, Des, qty, Integer.Parse(Newowner), Remarks, headid)
                        End If
                    Next
                End If

                MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox1.Text = rn
                dgv.Enabled = False
                SimpleButton2.Text = "New Entry"
                ComboBox2.Enabled = False

            ElseIf SimpleButton2.Text = "New Entry" Then
                ComboBox2.Enabled = True
                TextBox1.Text = String.Empty
                ComboBox2.SelectedIndex = -1
                TextBox2.Text = String.Empty
                DateTimePicker1.Value = Date.Now
                dgv.Rows.Clear()
                dgv.Columns.Clear()
                dgv.Enabled = True
                SimpleButton2.Text = "Record"

            End If

        End If
    End Sub

    Private Sub AcquisitionRequest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgv.Rows.Clear()
        dgv.Columns.Clear()
        ComboBox2.SelectedIndex = -1

    End Sub

    Private Sub dgv_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValidated
        Try

            Dim rowIndex As Integer = e.RowIndex


            If e.ColumnIndex = 4 Then
                Dim row As Integer = dgv.CurrentCell.RowIndex
                If dgv.Rows(row).Cells(4).Value Is Nothing Then
                    MessageBox.Show("Please put remarks to proceed...", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "PROCURE" Then
            dgv.Rows.Clear()
            dgv.Columns.Clear()
            DisplayProcure()
        ElseIf ComboBox2.Text = "BORROW" Then
            dgv.Rows.Clear()
            dgv.Columns.Clear()
            DisplayBorrow()
        ElseIf ComboBox2.Text = "TRANSFER OWNERSHIP" Then
            dgv.Rows.Clear()
            dgv.Columns.Clear()
            DisplayTransfer()
        End If
    End Sub

    Public Sub checkqtybycat()
        Dim row As Integer = dgv.CurrentCell.RowIndex
        If ComboBox2.Text = "PROCURE" Then
            If dgv.Rows(row).Cells(6).Value.ToString = "NCD" Then
                dgv.Rows(row).Cells(2).ReadOnly = True
                dgv.Rows(row).Cells(2).Value = "1"

            ElseIf dgv.Rows(row).Cells(6).Value.ToString = "NCN" Then
                dgv.Rows(row).Cells(2).ReadOnly = True
                dgv.Rows(row).Cells(2).Value = "1"
            Else
                dgv.Rows(row).Cells(2).ReadOnly = False
                dgv.Rows(row).Cells(2).Value = "0"
            End If

        ElseIf ComboBox2.Text = "BORROW" Then
            dgv.Rows(row).Cells(2).ReadOnly = True
            dgv.Rows(row).Cells(2).Value = "1"
        ElseIf ComboBox2.Text = "TRANSFER OWNERSHIP" Then
            dgv.Rows(row).Cells(2).ReadOnly = True
            dgv.Rows(row).Cells(2).Value = "1"
        End If
    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub Request_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub
End Class
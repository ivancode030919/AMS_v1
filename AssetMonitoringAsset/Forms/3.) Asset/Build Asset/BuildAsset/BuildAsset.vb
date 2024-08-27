Public Class BuildAsset
    Private Sub BuildAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Displaydg()
    End Sub

    Public Sub Displaydg()

        dgview.AllowUserToAddRows = True
        DateTimePicker1.Value = DateTime.Now.Date()

        dgview.Columns.Add("0", "Asset Code")
        dgview.Columns.Add("1", "Class")
        dgview.Columns.Add("2", "Property Code")
        dgview.Columns.Add("3", "Description")
        dgview.Columns.Add("4", "Quantity")
        dgview.Columns.Add("5", "Keeper")
        dgview.Columns.Add("6", "Owner")
        dgview.Columns.Add("7", "Borrower")
        dgview.Columns.Add("8", "Borrower Status")
        dgview.Columns.Add("9", "Reference")
        dgview.Columns.Add("10", "Reference No.")
        dgview.Columns.Add("11", "Condition")
        dgview.Columns.Add("12", "Statu1")
        dgview.Columns.Add("13", "Status2")
        dgview.Columns.Add("14", "Cat")
        dgview.Columns.Add("15", "Type")
        dgview.Columns.Add("16", "Series")
        dgview.Columns.Add("17", "KeeperID")
        dgview.Columns.Add("18", "OwnerID")

        With dgview

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True
            .Columns(11).ReadOnly = True

            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False


        End With

    End Sub

    Private Sub Dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick

        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then
            AssetList3.mode1 = 1
            AssetList3.modty = 1
            AssetList3.rowToEdit = row
            AssetList3.ShowDialog()

        ElseIf e.ColumnIndex = 5 Then

            EmployeeList.modty = 1
            EmployeeList.rowToEdit = row
            EmployeeList.ShowDialog()
        ElseIf e.ColumnIndex = 6 Then

            EmployeeList.modty = 3
            EmployeeList.rowToEdit = row
            EmployeeList.ShowDialog()

        ElseIf e.ColumnIndex = 11 Then
            NACondition.modty = 1
            NACondition.rowToEdit = row
            NACondition.ShowDialog()


        ElseIf e.ColumnIndex = 9 Then

            ReferenceList.modty = 1
            ReferenceList.rowToEdit = row
            ReferenceList.ShowDialog()

        End If


    End Sub

    Private Sub BuildAsset_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        fordgvclearing()
    End Sub

    Public Sub fordgvclearing()
        dgview.Rows.Clear()
        dgview.Columns.Clear()
    End Sub

    Private Sub BuildAsset_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 2 Then

            Dim gf As String = InventoryClass.FetchPropertyCode(dgview.Rows(row).Cells(14).Value.ToString, dgview.Rows(row).Cells(15).Value.ToString)
            dgview.Rows(row).Cells(16).Value = gf
            InsertionClass.SavePropertyCode(dgview.Rows(row).Cells(14).Value.ToString, dgview.Rows(row).Cells(15).Value.ToString, dgview.Rows(row).Cells(16).Value.ToString)
            dgview.Rows(row).Cells(2).Value = dgview.Rows(row).Cells(14).Value.ToString + "-" + dgview.Rows(row).Cells(15).Value.ToString + "-" + dgview.Rows(row).Cells(16).Value.ToString

        ElseIf e.ColumnIndex = 5 Then
            dgview.Rows(row).Cells(5).Value = " "
            dgview.Rows(row).Cells(17).Value = "0"
        ElseIf e.ColumnIndex = 6 Then
            dgview.Rows(row).Cells(6).Value = " "
            dgview.Rows(row).Cells(18).Value = "0"
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click


        If SimpleButton1.Text = "Record" Then

            Dim entryno As String = FetchClass.FetchEntryno
            InsertionClass.SaveBuildHeader(entryno, DateTimePicker1.Value, TextBox1.Text, Home.EmployeeID)

            For Each row As DataGridViewRow In dgview.Rows
                If Not row.IsNewRow Then

                    Dim AssetCode As String = row.Cells(0).Value
                    Dim Class1 As String = row.Cells(1).Value
                    Dim PropertyCode As String = row.Cells(2).Value
                    Dim Des As String = row.Cells(3).Value
                    Dim Qty As String = row.Cells(4).Value
                    Dim Keeper As String = row.Cells(17).Value
                    Dim Owner As String = row.Cells(18).Value
                    Dim Borrower As String = "0"
                    Dim BorrowerStat As String = "Not Allowed"
                    Dim Ref As String = row.Cells(9).Value
                    Dim Refno As String = row.Cells(10).Value
                    Dim Condition As String = row.Cells(11).Value
                    Dim stat1 As String = ""
                    Dim stat2 As String = ""

                    Dim headerid As Integer = FetchClass.FetchHeaderID

                    InsertionClass.SaveAssetInventory(Integer.Parse(AssetCode), Class1, PropertyCode, Des, Double.Parse(Qty), Integer.Parse(Keeper),
                                                       Integer.Parse(Owner), Integer.Parse(Borrower), Ref, Refno, BorrowerStat, stat1, stat2, Condition, 0, False, True, "000000")

                    InsertionClass.SaveBuildDetail(Integer.Parse(AssetCode), Class1, PropertyCode, Des, Double.Parse(Qty), Integer.Parse(Keeper),
                                                       Integer.Parse(Owner), Integer.Parse(Borrower), Ref, Refno, BorrowerStat, stat1, stat2, Condition, headerid)

                End If
            Next

            Label2.Visible = True
            Label2.Text = FetchClass.FetchEntryn1
            MessageBox.Show("Successfully Recorded...", "Notification", MessageBoxButtons.OK)
            dgview.Enabled = False
            SimpleButton1.Text = "New Entry"

        ElseIf SimpleButton1.Text = "New Entry" Then

            dgview.Rows.Clear()
            dgview.Enabled = True
            SimpleButton1.Text = "Record"
            TextBox1.Text = String.Empty
            Label2.Visible = False

        End If


    End Sub


End Class
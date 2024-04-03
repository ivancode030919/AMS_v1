Imports System.Data.OleDb

Public Class BuildAssetImport

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
        Dim openFileDialog1 As New OpenFileDialog()
            ' Set the title and filters for the file dialog
            openFileDialog1.Title = "Select Excel File"
            openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*"

            ' Show the file dialog
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                ' Get the selected file path
                Dim filePath As String = openFileDialog1.FileName

                ' Specify the connection string for Excel
                Dim connectionString As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties=Excel 12.0;"

                ' Create a connection to Excel
                Using connection As New OleDbConnection(connectionString)
                    ' Open the connection
                    connection.Open()

                    ' Specify the query to select data from the Excel sheet
                    Dim query As String = "SELECT * FROM [Sheet1$]"

                    ' Create a data adapter
                    Using adapter As New OleDbDataAdapter(query, connection)
                        ' Create a data table to hold the data
                        Dim dataTable As New DataTable()

                        ' Fill the data table with data from the Excel sheet
                        adapter.Fill(dataTable)

                        ' Bind the data table to the DataGridView
                        dgv.DataSource = dataTable
                        With dgv

                            '.Columns(0).Width = 100
                            '.Columns(1).Width = 300
                            '.Columns(2).Width = 200
                            '.Columns(3).Width = 200

                            .Columns(0).HeaderText = "Asset Code"
                            .Columns(1).HeaderText = "Class"
                            .Columns(2).HeaderText = "Property Code"
                            .Columns(3).HeaderText = "Full Description"
                            .Columns(4).HeaderText = "Quantity"
                            .Columns(5).HeaderText = "Keeper(Employee ID)"
                            .Columns(6).HeaderText = "Owner(Employee ID)"
                            .Columns(7).HeaderText = "Borrower"
                            .Columns(8).HeaderText = "Reference (Serial)"
                            .Columns(9).HeaderText = "Reference #"
                            .Columns(10).HeaderText = "Barrower Stat"
                            .Columns(11).HeaderText = "Status 1"
                            .Columns(12).HeaderText = "Status 2"
                            .Columns(13).HeaderText = "Condition"
                        End With



                    End Using
                End Using
            End If
        Catch ex As Exception
        MsgBox("Please Close the Opened Excel File")
        End Try

    End Sub


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try

            For Each row As DataGridViewRow In dgv.Rows

                If Not row.IsNewRow Then
                    Dim AssetCode As String = row.Cells(0).Value.ToString
                    Dim Class1 As String = row.Cells(1).Value.ToString
                    Dim PropertyCode As String = row.Cells(2).Value.ToString
                    Dim Des As String = row.Cells(3).Value.ToString
                    Dim Qty As String = row.Cells(4).Value.ToString
                    Dim Keeper As String = row.Cells(5).Value.ToString
                    Dim Ownwer As String = row.Cells(6).Value.ToString
                    Dim Borrower As String = row.Cells(7).Value.ToString
                    Dim Reference As String = row.Cells(8).Value.ToString
                    Dim Referenceno As String = row.Cells(9).Value.ToString
                    Dim BorroerStat As String = row.Cells(10).Value.ToString
                    Dim Status1 As String = row.Cells(11).Value.ToString
                    Dim Status2 As String = row.Cells(12).Value.ToString
                    Dim Condition As String = row.Cells(13).Value.ToString
                    InsertionClass.ImportExistingAssets(AssetCode, Class1, PropertyCode, Des, Double.Parse(Qty), Integer.Parse(Keeper), Integer.Parse(Ownwer), Integer.Parse(Borrower), Reference, Referenceno, BorroerStat, Status1, Status2, Condition)
                End If
            Next

            MessageBox.Show("Successfully Recorded...", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            dgv.Columns.Clear()

        Catch ex As Exception
        MessageBox.Show("Invalid Entry, Please Contact Programmer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

End Class
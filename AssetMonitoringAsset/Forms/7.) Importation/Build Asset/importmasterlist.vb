Imports System.Data.OleDb

Public Class importmasterlist
    Private Sub importmasterlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
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
                End Using
            End Using
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try

            For Each row As DataGridViewRow In dgv.Rows

                If Not row.IsNewRow Then

                    Dim Itemcode As String = row.Cells(0).Value.ToString
                    Dim Description As String = row.Cells(1).Value.ToString
                    Dim Category As String = row.Cells(2).Value.ToString
                    Dim Type As String = row.Cells(3).Value.ToString
                    Dim date1 As String = Date.Now.ToString
                    Dim date2 As String = Date.Now.ToString
                    Dim user1 As String = Home.UserID.ToString
                    Dim user2 As String = Home.UserID.ToString
                    Dim AH As String = "0"
                    InsertionClass.SaveMasterlistImport(Itemcode, Description, Integer.Parse(Category), Integer.Parse(Type), Date.Parse(date1), Date.Parse(date2), Integer.Parse(user1), Integer.Parse(user2), Integer.Parse(AH))
                End If
            Next

            MsgBox("Successfully Recorded...")
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            dgv.Columns.Clear()

        Catch ex As Exception
            MessageBox.Show("Invalid Entry, Please Contact Programmer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class
Public Class NewAsset

    Private lastItemCode As Integer = FetchClass.FetchLastItemcode

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        NAcategory.Show()
    End Sub

    Private Sub NewAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
        lastItemCode = FetchClass.FetchLastItemcode
    End Sub

    Public Sub Display()
        dgview.AllowUserToAddRows = True
        DateTimePicker1.Value = DateTime.Now.Date()
        Label2.Text = FetchClass.FetchEntryID

        dgview.Columns.Add("0", "Asset Code")
        dgview.Columns.Add("1", "Asset Description")
        dgview.Columns.Add("2", "Categories")
        dgview.Columns.Add("3", "Asset Type")

        'GETS THE VALUE ID'
        dgview.Columns.Add("5", "CatID")
        dgview.Columns.Add("6", "AssTypeID")


        dgview.Columns(5).Visible = False
        dgview.Columns(4).Visible = False

        dgview.Columns(0).ReadOnly = True
        dgview.Columns(2).ReadOnly = True
        dgview.Columns(3).ReadOnly = True
        dgview.Columns(4).ReadOnly = True

        dgview.Rows.Clear()
    End Sub

    Private Sub Dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 2 Then
            NAcategory.rowToEdit = row
            NAcategory.ShowDialog()

        ElseIf e.ColumnIndex = 3 Then
            NATypeh.rowToEdit = row
            NATypeh.ShowDialog()
        End If
    End Sub

    Private Sub NewAsset_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            dgview.Rows.Clear()
            dgview.Columns.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
            InsertionClass.SaveMasterlistHeader(Label2.Text, TextBox1.Text, DateTimePicker1.Value)

            For Each row As DataGridViewRow In dgview.Rows
                If Not row.IsNewRow Then

                    Dim TransHeaderID As Integer = FetchClass.FetchTransHeaderID
                    Dim Assetcode As String = row.Cells(0).Value.ToString
                    Dim description As String = row.Cells(1).Value.ToString
                    Dim category As String = row.Cells(4).Value.ToString
                    Dim type As String = row.Cells(5).Value.ToString
                    InsertionClass.SaveAssetDetail(Integer.Parse(Assetcode), description, Integer.Parse(category), Integer.Parse(type), TransHeaderID)
                End If
            Next
            TextBox1.Text = String.Empty
            Label2.Text = String.Empty
            Fordgvclearing()
            Display()
            MsgBox("Successfully Recorded...")

        Catch ex As Exception
            MessageBox.Show("Invalid Entry, Please Check blank Cells...", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub Fordgvclearing()
        dgview.Rows.Clear()
        dgview.Columns.Clear()
    End Sub

    Private Sub NewAsset_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub dgview_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgview.CellValidating

        If e.ColumnIndex = 1 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Description")
            SimpleButton1.Enabled = False
        ElseIf e.ColumnIndex = 2 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Category")
            SimpleButton1.Enabled = False
        ElseIf e.ColumnIndex = 3 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Asset Type")
            SimpleButton1.Enabled = False
        ElseIf e.ColumnIndex = 4 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Condition")
            SimpleButton1.Enabled = False
        Else
            SimpleButton1.Enabled = True
        End If
    End Sub

    Private Sub dgview_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellLeave
        If e.ColumnIndex = 1 AndAlso e.RowIndex <> -1 AndAlso Not dgview.Rows(e.RowIndex).IsNewRow Then
            lastItemCode += 1
            dgview.Rows(e.RowIndex).Cells(0).Value = lastItemCode.ToString()
        End If
    End Sub
End Class
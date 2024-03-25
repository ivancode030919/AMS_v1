Public Class Vendor
    Public VenID As Integer
    Private Sub Vendor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewVendor()
    End Sub


    Public Sub ViewVendor()
        VendorClass.ViewVendor(TextBox3.Text)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "New Vendor" Then
            VendorAddandUpdate.TextBox1.Text = String.Empty
            VendorAddandUpdate.TextBox2.Text = String.Empty
            VendorAddandUpdate.SimpleButton2.Text = "Record"
            VendorAddandUpdate.ShowDialog()
        ElseIf SimpleButton1.Text = "Update Vendor" Then
            VendorAddandUpdate.Text = "Update"
            VendorAddandUpdate.SimpleButton2.Text = "Save"
            VendorAddandUpdate.ShowDialog()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Text = "New Vendor"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            VenID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Vendor"

            With VendorAddandUpdate
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Vendor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SimpleButton1.Text = "New Position"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewVendor()
    End Sub

    Private Sub Vendor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub
End Class
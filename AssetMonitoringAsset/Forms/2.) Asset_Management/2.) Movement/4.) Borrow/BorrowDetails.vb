Public Class BorrowDetails

    Public transid As Integer
    Private Sub BorrowDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Public Sub display()
        dgv.DataSource = ViewClass.ViewBorrowDetails(transid)
    End Sub
End Class
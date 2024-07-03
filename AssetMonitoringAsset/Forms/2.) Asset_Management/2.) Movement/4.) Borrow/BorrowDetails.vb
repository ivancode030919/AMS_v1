Public Class BorrowDetails

    Public transid As Integer
    Private Sub BorrowDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub



    Public Sub Display()
        dgv.DataSource = ViewClass.ViewBorrowDetails(transid)
    End Sub
End Class
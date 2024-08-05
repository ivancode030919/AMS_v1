Public Class BorrowDetails

    Public transid As Integer
    Private Sub BorrowDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub



    Public Sub Display()
        dgv.DataSource = ViewClass.ViewBorrowDetails(transid)
    End Sub

    Private Sub BorrowDetails_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub

    Private Sub BorrowDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Home.IsMdiContainer = False
        Me.Dispose()
    End Sub
End Class
Public Class ProcureRegister
    Private Sub ProcureRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Public Sub display()
        dgv.DataSource = ViewClass.ViewProcureRegister
    End Sub
End Class
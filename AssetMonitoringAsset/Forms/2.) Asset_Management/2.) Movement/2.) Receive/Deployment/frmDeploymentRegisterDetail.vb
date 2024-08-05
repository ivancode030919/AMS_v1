Public Class frmDeploymentRegisterDetail
    Public transid As Integer
    Private Sub frmDeploymentRegisterDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loaddgv()
    End Sub


    Private Sub Loaddgv()
        DepDgv.DataSource = ViewClass.ViewDeployemntRegisterDetail(transid)
    End Sub
End Class
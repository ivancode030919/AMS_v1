Public Class frmDeploymentRegisterDetail
    Public transid As Integer
    Private Sub frmDeploymentRegisterDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loaddgv()
    End Sub
    Private Sub Loaddgv()
        DepDgv.DataSource = ViewClass.ViewDeployemntRegisterDetail(transid)

        With DepDgv
            .Columns(0).HeaderText = "Property Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Runner"
            .Columns(3).HeaderText = "Date Deployed"
            .Columns(4).HeaderText = "Reference Request Number"
        End With


    End Sub
End Class
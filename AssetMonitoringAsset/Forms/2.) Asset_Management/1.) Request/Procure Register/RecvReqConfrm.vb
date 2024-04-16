Public Class RecvReqConfrm

    Public ItemCode As Integer
    Public ItemId As Integer
    Private Sub RecvReqConfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(294, 85)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Receive" Then
            Label1.Text = FetchClass.FetchLastProteryCode(ItemCode)
            Me.Size = New Size(294, 200)
            SimpleButton1.Text = "Record"
            SimpleButton2.Text = "Cancel"

        ElseIf SimpleButton1.Text = "Record" Then
            SimpleButton1.Text = "Receive"
            Me.Size = New Size(294, 90)

        End If



        'UpdateClass.UpdateProStat(ItemId, 1)
        'ProcureDetail.display()


    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        UpdateClass.UpdateProStat(ItemId, 0)
        ProcureDetail.display()
    End Sub

    Private Sub RecvReqConfrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing



        SimpleButton1.Text = "Receive"
        Me.Size = New Size(294, 90)
    End Sub
End Class
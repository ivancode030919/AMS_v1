Public Class ChngState

    Public Stat As String = ""
    Public id As Integer
    Public rowToEdit As Integer
    Private Sub ChngState_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckStat()
    End Sub

    Private Sub CheckStat()
        If Stat = "CANCELLED" Then
            RadioButton1.Checked = True
        ElseIf Stat = "OPEN" Then
            RadioButton2.Checked = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        UpdateClass.UpdateState(id, Stat)
        Me.Close()
        Rqregister.display()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Stat = "CANCELLED"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Stat = "OPEN"
        End If
    End Sub
End Class
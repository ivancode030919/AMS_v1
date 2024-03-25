Public Class date1
    Public modty As Integer
    Public rowToEdit As Integer
    Private Sub date1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim val As String = DateTimePicker1.Value.ToShortDateString

        If modty = 1 Then
            With Request.dgv
                .Rows(rowToEdit).Cells(4).Value = val
            End With


        ElseIf modty = 2 Then
            With Request.dgv
                .Rows(rowToEdit).Cells(5).Value = val
            End With
        End If


        Me.Close()

    End Sub
End Class
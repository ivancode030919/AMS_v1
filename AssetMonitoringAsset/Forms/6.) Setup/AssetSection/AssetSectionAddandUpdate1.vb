Public Class AssetSectionAddandUpdate1
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Section Code")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Section Description")
        Else
            If SimpleButton2.Text = "Record" Then
                If SectionClass.FetchSecCount(TextBox1.Text) > 0 Then
                    MessageBox.Show("Section Code Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Else
                    SectionClass.SaveSection(TextBox1.Text, TextBox2.Text)
                End If

            ElseIf SimpleButton2.Text = "Save" Then
                SectionClass.UpdateSection(AssetSection.SecID, TextBox1.Text, TextBox2.Text)
            End If

        End If
    End Sub
End Class
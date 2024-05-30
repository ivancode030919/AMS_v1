Public Class RecvReqConfrm

    Public ItemCode As Integer
    Public ItemId As Integer
    Public UpdateStat As Integer
    Public rowToEdit As Integer
    Private Sub RecvReqConfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Size(294, 85)
        Dim State As String = FetchClass.FetchRequestStatus(ItemId)

        If State = "OPEN" Then

            SimpleButton1.Enabled = True
            SimpleButton2.Enabled = True

        ElseIf State = "RECEIVED" Then

            SimpleButton1.Enabled = False
            SimpleButton2.Enabled = False
            MessageBox.Show("This item is already received...Cannot be cancelled!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Receive" Then

            Label1.Text = FetchClass.FetchLastProteryCode(ItemCode)
            Me.Size = New Size(294, 310)
            SimpleButton1.Text = "Generate"
            SimpleButton2.Text = "Cancel"

        ElseIf SimpleButton1.Text = "Generate" Then

            If TextBox1.Text = String.Empty Then
                MessageBox.Show("Property code description is invalid...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                UpdateClass.UpdateProStat(ItemId, 1, Label1.Text, TextBox1.Text, ComboBox1.Text, TextBox3.Text)
                With ProcureDetail.DataGridView1
                    Dim PropertyCode As String = Label1.Text
                    Dim PDes As String = TextBox1.Text

                    If .Columns(8).Name <> "PropertyCode" Then
                        .Rows(rowToEdit).Cells(9).Value = PropertyCode
                    Else
                        .Rows(rowToEdit).Cells(8).Value = PropertyCode
                    End If

                    If .Columns(9).Name <> "Description" Then
                        .Rows(rowToEdit).Cells(10).Value = PDes
                    Else
                        .Rows(rowToEdit).Cells(9).Value = PDes
                    End If

                    If .Columns(10).Name <> "Reference" Then
                        .Rows(rowToEdit).Cells(11).Value = ComboBox1.Text
                    Else
                        .Rows(rowToEdit).Cells(10).Value = ComboBox1.Text
                    End If

                    If .Columns(11).Name <> "ReferenceNo" Then
                        .Rows(rowToEdit).Cells(12).Value = TextBox3.Text
                    Else
                        .Rows(rowToEdit).Cells(11).Value = TextBox3.Text
                    End If

                End With
                ProcureDetail.display()
                TextBox1.Text = String.Empty
                Me.Dispose()
            End If

        End If

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        Dim result As DialogResult = MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            UpdateClass.UpdateProStat(ItemId, 0, "", "", "", "")
            Me.Dispose()
            ProcureDetail.display()
        Else

        End If

    End Sub

    Private Sub RecvReqConfrm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        SimpleButton1.Text = "Receive"
        Me.Size = New Size(294, 90)
        SimpleButton1.Enabled = True
        SimpleButton2.Enabled = True
    End Sub
End Class
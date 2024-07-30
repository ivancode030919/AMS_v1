Public Class BorrowerRetuenConfirmation
    Public PropertyCode As String
    Public BorrowerID As String

    Private Sub BorrowerRetuenConfirmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = "Return Property Code: " & vbCrLf & PropertyCode
        'Suggest()
    End Sub

    'Private Sub Suggest()
    '    Dim payList As List(Of String) = FetchClass.FetchEmployeeName

    '    Dim suggestions As New AutoCompleteStringCollection()
    '    suggestions.AddRange(payList.ToArray())

    '    With TextBox2
    '        .Text = ""
    '        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        .AutoCompleteSource = AutoCompleteSource.CustomSource
    '        .AutoCompleteCustomSource = suggestions
    '    End With

    'End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        EmployeeList.modty = 4
        EmployeeList.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = String.Empty Then

            MessageBox.Show("Select Runner", "Validation")
            TextBox2.Focus()

        Else

            UpdateClass.UpdateReturnItem(PropertyCode, BorrowerID)
            MessageBox.Show("Successfully Recorded", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information)
            BorrowReturn.DgvDisplay()
            Me.Close()
        End If

    End Sub

    Private Sub BorrowerRetuenConfirmation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox2.Text = String.Empty
    End Sub
End Class
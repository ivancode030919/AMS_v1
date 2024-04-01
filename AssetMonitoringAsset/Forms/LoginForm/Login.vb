Public Class Login
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Username...")
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Password...")
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        Else
            If FetchClass.FetchLogin(TextBox1.Text, TextBox2.Text) = 0 Then
                MsgBox("Invalid User Account...")
                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            ElseIf FetchClass.FetchLogin(TextBox1.Text, TextBox2.Text) = 1 Then
                loaddetails()
                Home.Show()
                Me.Hide()

                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            Else
                MsgBox("Multiple Account is Not Permitted...Please Contact SPU")
            End If
        End If

    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Public Sub loaddetails()
        With Home

            .UserID = FetchClass.FetcUserID(TextBox1.Text, TextBox2.Text)
            .EmployeeID = FetchClass.FetcEmployeeID(.UserID)
            .UserType = FetchClass.FetcUserType(.EmployeeID)

            .Branch = FetchClass.FetcBranch(TextBox1.Text, TextBox2.Text)
            .BranchID = FetchClass.FetcBranchID(.Branch)

            .Department = FetchClass.FetcDepartment1(TextBox1.Text, TextBox2.Text)
            .DepartmentID = FetchClass.FetcDepartmentID(.Department)

            .Section = FetchClass.FetcSection(TextBox1.Text, TextBox2.Text)
            .SectionID = FetchClass.FetcSectionID(.Section)
        End With
    End Sub
End Class
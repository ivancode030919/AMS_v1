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
            If UserClass.FetchLogin(TextBox1.Text, TextBox2.Text) = 0 Then
                MsgBox("Invalid User Account...")
                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            ElseIf UserClass.FetchLogin(TextBox1.Text, TextBox2.Text) = 1 Then
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

            .Branch = UserClass.FetcBranch(TextBox1.Text, TextBox2.Text)
            .Department = UserClass.FetcDepartment(TextBox1.Text, TextBox2.Text)
            .Section = UserClass.FetcSection(TextBox1.Text, TextBox2.Text)
            .UserID = UserClass.FetcUserID(TextBox1.Text, TextBox2.Text)
            .EmployeeID = UserClass.FetcEmployeeID(.UserID)
            .UserType = UserClass.FetcUserType(.EmployeeID)
            .BranchID = UserClass.FetcBranchID(.Branch)
            .DepartmentID = UserClass.FetcDepartmentID(.Department)
            .SectionID = UserClass.FetcSectionID(.Section)
        End With
    End Sub
End Class
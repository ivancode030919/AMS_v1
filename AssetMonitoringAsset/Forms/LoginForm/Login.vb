Public Class Login
    Public images As Image()
    ' Declare a counter to track the current image index
    Public currentIndex As Integer = 0

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BACKPIC()
    End Sub



    Public Sub loadDetails()
        With Home

            .UserID = FetchClass.FetchUserID(TextBox1.Text, TextBox2.Text)
            .EmployeeID = FetchClass.FetchEmployeeID(.UserID)
            .UserType = FetchClass.FetchUserType(.EmployeeID)

            .Branch = FetchClass.FetchBranch(TextBox1.Text, TextBox2.Text)
            .BranchID = FetchClass.FetchBranchID(.Branch)

            .Department = FetchClass.FetchDepartment1(TextBox1.Text, TextBox2.Text)
            .DepartmentID = FetchClass.FetchDepartmentID(.Department)

            .Section = FetchClass.FetchSection(TextBox1.Text, TextBox2.Text)
            .SectionID = FetchClass.FetcSectionID(.Section)
        End With
    End Sub

    Public Sub Login()

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
                loadDetails()
                Home.Show()
                Me.Hide()

                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            Else
                MsgBox("Multiple Account is Not Permitted...Please Contact SPU")
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Login()
        End If

    End Sub






    Public Sub BACKPIC()
        ' Initialize the images array with the images from resources
        images = New Image() {
        My.Resources._1,
        My.Resources._2,
        My.Resources._3,
        My.Resources._4,
        My.Resources._5}

        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage ' Stretch the image

        ' Configure the timer
        Timer1.Interval = 1000 ' Set the interval to 2000 milliseconds (2 seconds)
        Timer1.Start()

        ' Set the initial image
        PictureBox1.Image = images(currentIndex)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Increment the index to show the next image
        currentIndex += 1

        ' Check if currentIndex is within bounds before accessing images array
        If currentIndex >= 0 AndAlso currentIndex < images.Length Then
            PictureBox1.Image = images(currentIndex)
        Else
            ' Handle the out-of-range condition (e.g., reset currentIndex)
            currentIndex = 0
            PictureBox1.Image = images(currentIndex)
        End If
    End Sub
End Class
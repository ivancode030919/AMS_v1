Public Class EmployeeAddandUpdate

    Public branID As String = ""
    Public SecID As String = ""
    Public DepID As String = ""
    Public PosID As String = ""
    Public ManagerID1 As String = ""
    Public updateID As Integer
    Private Sub EmployeeAddandUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sectioncb()
        Poscb()
        Depcb()
        managercbx()
        Brcb()


        ComboBox5.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox6.SelectedIndex = -1


    End Sub

    Private Sub Sectioncb()
        ComboBox3.DataSource = SectionClass.ViewCboxSection
    End Sub

    Private Sub Depcb()
        ComboBox2.DataSource = DepartmentClass.ViewCboxDepartment
    End Sub

    Private Sub Poscb()
        ComboBox4.DataSource = PositionClass.ViewCboxPosition
    End Sub

    Private Sub Brcb()
        ComboBox1.DataSource = BranchClass.ViewCboxBranch
    End Sub

    Private employeeData As List(Of Object)

    Private Sub managercbx()
        ComboBox5.DataSource = PositionClass.ViewCboxManager
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid First Name...")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Last Name...")
        Else
            If SimpleButton1.Text = "Record" Then
                If FetchClass.FetchEmployeeCount(TextBox1.Text, TextBox2.Text) > 0 Then
                    MessageBox.Show("Employee Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    InsertionClass.SaveEmployee(TextBox1.Text, TextBox2.Text, Integer.Parse(branID), Integer.Parse(DepID), Integer.Parse(PosID), Integer.Parse(SecID), Integer.Parse(ManagerID1), ComboBox6.Text)
                End If

            ElseIf SimpleButton1.Text = "Save" Then
                UpdateClass.UpdateEmployee(updateID, TextBox1.Text, TextBox2.Text, Integer.Parse(branID), Integer.Parse(DepID), Integer.Parse(PosID), Integer.Parse(SecID), Integer.Parse(ManagerID1), ComboBox6.Text)
            End If
        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged


        branID = BranchClass.FetchBranchID(ComboBox1.Text).ToString()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        DepID = DepartmentClass.FetchDepartmentID(ComboBox2.Text).ToString()

        If ComboBox2.Text = "Special Project Unit" Then
            ComboBox1.Text = ""
            ComboBox3.Text = ""
            ComboBox1.Enabled = False
            ComboBox3.Enabled = False
            ComboBox1.Text = "Not Applicable"
            ComboBox3.Text = "Not Applicable"
        ElseIf ComboBox2.Text = "Accounting " Then
            ComboBox1.Text = ""
            ComboBox3.Text = ""
            ComboBox1.Enabled = False
            ComboBox3.Enabled = False
        ElseIf ComboBox2.Text = "N/A" Then
            ComboBox1.Text = ""
            ComboBox3.Text = ""
            ComboBox1.Enabled = False
            ComboBox3.Enabled = False
            ComboBox1.Text = "Not Applicable"
            ComboBox3.Text = "Not Applicable"
        ElseIf ComboBox2.Text = "Marketing" Then
            ComboBox1.Text = ""
            ComboBox3.Text = ""
            ComboBox1.Enabled = False
            ComboBox3.Enabled = False
            ComboBox3.Text = "Not Applicable"
            ComboBox1.Text = "Not Applicable"
        ElseIf ComboBox2.Text = "Accounting" Then
            ComboBox1.Text = ""
            ComboBox3.Text = ""
            ComboBox1.Enabled = False
            ComboBox3.Enabled = False
            ComboBox3.Text = "Not Applicable"
            ComboBox1.Text = "Not Applicable"
        Else
            ComboBox1.Enabled = True
            ComboBox3.Enabled = True
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        PosID = PositionClass.FetchPositionID(ComboBox4.Text).ToString()

        If ComboBox4.Text = "Department Manager" Then
            ComboBox5.Enabled = False
            ComboBox5.SelectedIndex = -1
            ManagerID1 = "0"

        ElseIf ComboBox4.Text = "Branch Manager" Then
            ComboBox5.Enabled = False
            ComboBox5.SelectedIndex = -1
            ManagerID1 = "0"
        Else
            ComboBox5.Enabled = True
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        SecID = SectionClass.FetchSectionID(ComboBox3.Text).ToString()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

    End Sub

    Private Sub EmployeeAddandUpdate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            If SimpleButton2.Text = "Save" Then
            Else
                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            End If

        End If
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        If ComboBox5.Text = "" Then

        Else
            Dim selectedValue As String = ComboBox5.SelectedItem.ToString()

            ' Find the position of the hyphen
            Dim hyphenIndex As Integer = selectedValue.IndexOf("-")

            ' Check if the hyphen is found
            If hyphenIndex <> -1 Then
                ' Extract the numeric part and store it in the ManagerID variable
                Dim ManagerID As String = selectedValue.Substring(0, hyphenIndex)
                ' Now, ManagerID contains the numeric part "123"
                ' You can use ManagerID as needed in your code      MessageBox.Show("ManagerID: " & ManagerID)
                ManagerID1 = ManagerID

            End If
        End If


    End Sub
End Class
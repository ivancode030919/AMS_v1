Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class EmployeeClass
    Public Shared Function GetEmployee() As System.Data.Linq.Table(Of tblEmployee)
        Return db.GetTable(Of tblEmployee)()
    End Function

    Public Shared Sub SaveEmployee(ByVal fname As String, ByVal lname As String, ByVal BranchID As Integer, ByVal DepID As Integer, ByVal PID As Integer, ByVal SecID As Integer, ByVal manager As Integer, ByVal compny As String)
        'Try
        Dim user As Integer = Home.UserID
        Dim currentdate As Date = DateTime.Now.Date()

        Dim post As Table(Of tblEmployee) = EmployeeClass.GetEmployee
        Dim p As New tblEmployee With
                {
                    .FirstName = StrConv(fname, VbStrConv.ProperCase),
                    .LastName = StrConv(lname, VbStrConv.ProperCase),
                    .BranchID = BranchID,
                    .DepartmentID = DepID,
                    .PositionID = PID,
                    .SectionID = SecID,
                    .AddbyUserID = user,
                    .Datecreated = currentdate,
                    .Manager = manager,
                    .Company = compny
                }

        post.InsertOnSubmit(p)
        post.Context.SubmitChanges()
        MessageBox.Show("Employee Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'After Insert Load View
        Employee.viewEmployee()

        With EmployeeAddandUpdate
            .TextBox1.Text = String.Empty
            .TextBox2.Text = String.Empty
            .Close()
        End With
        'Catch ex As Exception
        '    MsgBox("Invalid Data...")
        'End Try
    End Sub

    Public Shared Sub ViewEmployee(ByVal Search As String, ByVal Bra As String, ByVal Dep As String, ByVal Pos As String, ByVal Sec As String)

        Try

            With Employee.dgview

                'soure for viewing
                .DataSource = db.spViewEmployee(Search, Bra, Dep, Sec, Pos)
                'hide column 0

                'set column name
                .Columns(0).HeaderText = "Employee ID"
                .Columns(1).HeaderText = "First Name"
                .Columns(2).HeaderText = "Last Name"
                .Columns(3).HeaderText = "Department"
                .Columns(4).HeaderText = "Branch"
                .Columns(5).HeaderText = "Section"
                .Columns(6).HeaderText = "Position"
                .Columns(7).HeaderText = "Manager"
                .Columns(8).HeaderText = "Company"
                .Columns(9).HeaderText = "Date Added"
                'set column Width
                '.dgview.Columns(1).Width = 100
                '.dgview.Columns(3).Width = 125

                'datagrid text alignment
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub







    Public Shared Function ViewEmployeeList(ByVal search As String) As Object
        Dim querysection = (From s In db.tblEmployees
                            Where s.FirstName.Contains(search) Or s.LastName.Contains(search)
                            Order By s.EmployeeID
                            Select s.EmployeeID, s.FirstName, s.LastName).ToList
        Return querysection
    End Function

    Public Shared Function ViewEmployeeList4(ByVal branch As Integer, ByVal dept As Integer, ByVal section As Integer, ByVal search As String) As Object

        Dim querysection = (From s In db.tblEmployees
                            Where (s.BranchID = branch AndAlso s.DepartmentID = dept AndAlso s.SectionID = section) And s.FirstName.Contains(search) Or s.LastName.Contains(search) Or (s.FirstName + " " + s.LastName).Contains(search)
                            Order By s.EmployeeID
                            Let g = s.FirstName + " " + s.LastName
                            Select s.EmployeeID, g).ToList
        Return querysection

    End Function




    Public Shared Function FetchEmCount(ByVal fname As String, ByVal lname As String) As Integer
        Dim count As Integer = (From s In db.tblEmployees
                                Where (s.FirstName.Contains(fname) And s.LastName.Contains(lname))
                                Select s).Count()
        Return count
    End Function


    Public Shared Function ViewEmployeeList2(ByVal search As String) As Object
        Dim querysection = (From s In db.tblEmployees
                            Join p In db.tblBranches On s.BranchID Equals p.BranchID
                            Join l In db.tblDepartments On s.DepartmentID Equals l.DepartmentID
                            Join g In db.tblSections On s.SectionID Equals g.SectionID
                            Where s.FirstName.Contains(search) Or s.LastName.Contains(search)
                            Order By s.EmployeeID
                            Select s.EmployeeID, s.FirstName, s.LastName, p.BranchDescription, l.DepartmentDescription, g.SectionDecription, p.BranchID, l.DepartmentID, g.SectionID).ToList
        Return querysection
    End Function





End Class

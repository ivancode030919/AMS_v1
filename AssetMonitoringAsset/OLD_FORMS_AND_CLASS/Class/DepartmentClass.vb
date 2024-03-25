Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class DepartmentClass
    Public Shared Function GetAssetDepartment() As System.Data.Linq.Table(Of tblDepartment)
        Return db.GetTable(Of tblDepartment)()
    End Function

    Public Shared Sub SaveDepartment(ByVal Code As String, ByVal Des As String, ByVal loc As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spNewDepartment(Code.ToUpper, StrConv(Des, VbStrConv.ProperCase), currentdate, currentdate, user, user, loc)
            MessageBox.Show("Department Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetDepartment.ViewDepartment()

            With AssetDepartmentAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewDepartment(ByVal Search As String)
        Try

            With AssetDepartment

                'soure for viewing
                .dgview.DataSource = db.spViewDepartment(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Department Code"
                .dgview.Columns(2).HeaderText = "Description"
                .dgview.Columns(3).HeaderText = "Date Modified"

                'set column Width
                '.dgview.Columns(1).Width = 100
                '.dgview.Columns(3).Width = 125

                'datagrid text alignment
                .dgview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try


    End Sub

    Public Shared Sub UpdateDepartment(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String, ByVal loc As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateDepartment(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper, loc)
            MessageBox.Show("Department Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            With AssetDepartment
                .ViewDepartment()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With


            With AssetDepartmentAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function ViewCboxDepartment() As List(Of String)

        Dim querysection = (From s In db.tblDepartments
                            Order By s.DepartmentID
                            Select s.DepartmentDescription).ToList
        Return querysection
    End Function


    Public Shared Function FetchDepartmentID(ByVal Des As String) As Object
        Dim querysection = (From s In db.tblDepartments
                            Where s.DepartmentDescription.Contains(Des)
                            Select s.DepartmentID).FirstOrDefault

        Return querysection
    End Function

    Public Shared Function FetchDepCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblDepartments
                                Where (s.DepartmentCode.Contains(code))
                                Select s.DepartmentCode).Count()
        Return count
    End Function
End Class

Public Class UpdateClass

    '------------------------------------------------------------------------------------
    'Update State in Request
    '------------------------------------------------------------------------------------
    Public Shared Sub UpdateState(ByVal id As Integer, ByVal stat As String)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestDetail)()
                              Where (p.id = id)
                              Select p).FirstOrDefault()
            updateStat.State = stat
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.17")
        End Try

    End Sub

    '------------------------------------------------------------------------------------
    'Update Category
    '------------------------------------------------------------------------------------
    Public Shared Sub UpdateCategory(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateCategory(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Asset Category Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View



            With AssetCategory
                .ViewCategory()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetCategoryAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Error.18")
        End Try
    End Sub

    '------------------------------------------------------------------------------------
    'Update Employee
    '------------------------------------------------------------------------------------
    Public Shared Sub UpdateEmployee(ByVal typeid As Integer, ByVal fname As String, ByVal lname As String, ByVal BranchID As Integer, ByVal DepID As Integer, ByVal PID As Integer, ByVal SecID As Integer, ByVal manager As Integer, ByVal compny As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateEmployee(typeid, StrConv(fname, VbStrConv.ProperCase), StrConv(lname, VbStrConv.ProperCase), BranchID, DepID, PID, SecID, manager, compny)
            MessageBox.Show("Branch Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View

            'With Login
            '    .loaddetails()
            'End With
            With Employee
                .viewEmployee()
                .TextBox1.Text = String.Empty

                .Label5.Text = ""
                .SimpleButton2.Visible = False
            End With

            With EmployeeAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Error.19")
        End Try
    End Sub

    '------------------------------------------------------------------------------------
    'Update For Assigned Items with property code
    '------------------------------------------------------------------------------------
    Public Shared Sub UpdateAssignProperty(ByVal PropertyCode As String, ByVal NewOwner As Integer)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where p.PropertyCode = PropertyCode
                              Select p).FirstOrDefault()
            updateStat.Owner = NewOwner
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.20")
        End Try

    End Sub

    '------------------------------------------------------------------------------------
    'Update Status of Request
    '------------------------------------------------------------------------------------
    Public Shared Sub UpdateStatusReq(ByVal ID As Integer)
        Dim Status As String = "CLOSED"
        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestDetail)()
                              Where p.id = ID
                              Select p).FirstOrDefault()
            updateStat.State = Status
        db.SubmitChanges()

        Catch ex As Exception
        MsgBox("Error.21")
        End Try

    End Sub

End Class

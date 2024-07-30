Public Class UpdateClass

    'Update State in Request
    Public Shared Sub UpdateState(ByVal id As Integer, ByVal stat As String)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestDetail)()
                              Where (p.id = id)
                              Select p).FirstOrDefault()
            updateStat.State = stat
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.17")
        End Try

    End Sub

    'Update Category
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
            MsgBox("Error.U.18")
        End Try
    End Sub


    'Update Employee
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
            MsgBox("Error.U.19")
        End Try
    End Sub


    'Update For Assigned Items with property code
    Public Shared Sub UpdateAssignProperty(ByVal PropertyCode As String, ByVal NewOwner As Integer)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where p.PropertyCode = PropertyCode
                              Select p).FirstOrDefault()
            updateStat.Owner = NewOwner
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.20")
        End Try

    End Sub


    'Update State of Request
    Public Shared Sub UpdateStatusReq(ByVal ID As Integer)
        Dim Status As String = "CLOSED"
        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestDetail)()
                              Where p.id = ID
                              Select p).FirstOrDefault()
            updateStat.State = Status
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.21")
        End Try

    End Sub


    'Update Status of Request Header
    Public Shared Sub UpdateStatusReqHeader(ByVal ID As Integer, ByVal type As Integer)

        Try
            If type = 1 Then

                Dim Status As String = "CLOSED"
                Dim updateStat = (From p In db.GetTable(Of tblRequestHeader)()
                                  Where p.HeaderId = ID
                                  Select p).FirstOrDefault()
                updateStat.Stat = Status
                db.SubmitChanges()

            ElseIf type = 2 Then

                Dim Status As String = "APPROVED"
                Dim updateStat = (From p In db.GetTable(Of tblRequestHeader)()
                                  Where p.HeaderId = ID
                                  Select p).FirstOrDefault()
                updateStat.Stat = Status
                db.SubmitChanges()

            End If


        Catch ex As Exception
            MsgBox("Error.U.21")
        End Try
    End Sub

    'Update User Status
    Public Shared Sub UpdateUserStat(ByVal Stat As String, ByVal UID As Integer)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblUser)()
                              Where p.UserID = UID
                              Select p).SingleOrDefault()
            updateStat.Status = Stat
            db.SubmitChanges()
            MessageBox.Show("User Status Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With UserUpdate
                .Label3.Text = "*"
                .Close()
            End With
            With User
                .Viewdg()
            End With

        Catch ex As Exception
            MsgBox("Error.U.22")
        End Try
    End Sub

    'Update User Password
    Public Shared Sub UpdateUserPass(ByVal id As Integer, ByVal pass As String)
        Try
            'Insert Asset in DB
            db.spUpdateUser(id, pass)
            MessageBox.Show("User Password Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            User.Viewdg()
            With UserChangePass
                .TextBox2.Text = ""
                .Label3.Text = "*"
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Error.U.23")
        End Try
    End Sub

    'Update Procure Status
    Public Shared Sub UpdateProStat(ByVal itemid As Integer, ByVal Stat As Integer,
                                    ByVal PropertyCode As String, ByVal Descrip As String,
                                    ByVal Ref As String, ByVal Refno As String)
        Try

            Dim Status As String = ""
            If Stat = 1 Then
                Status = "RECEIVED"
            ElseIf Stat = 0 Then
                Status = "CANCELLED"
            End If

            Dim updateStat = (From p In db.GetTable(Of tblProcureDetail)()
                              Where p.id = itemid
                              Select p).FirstOrDefault()
            updateStat.State = Status
            updateStat.PropertyCode = PropertyCode
            updateStat.Description = Descrip
            updateStat.Reference = Ref
            updateStat.ReferenceNo = Refno

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.24")
        End Try
    End Sub


    'Update State in Request
    Public Shared Sub CancellationReason(ByVal Requestno As String, ByVal reason As String)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestHeader)()
                              Where (p.RequestNo = Requestno)
                              Select p).FirstOrDefault()
            updateStat.Stat = "CANCELLED"
            updateStat.CancellationRemark = reason
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.25")
        End Try

    End Sub


    'Update Consumable Qty When Assigning in a new Item
    Public Shared Sub UpdateAssetQty(ByVal Invd As Integer, ByVal Qty As Double)


        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where (p.InvID = Invd)
                              Select p).FirstOrDefault()
            updateStat.Qty = Qty


            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.26")
        End Try

    End Sub

    'Update For Assigned Items with property code
    Public Shared Sub UpdateReqstQuantity(ByVal reqi8d As Integer, ByVal Quantiy As Double, ByVal ProCode As String)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestDetail)()
                              Where p.id = reqi8d
                              Select p).FirstOrDefault()
            updateStat.Qty = Quantiy
            updateStat.PropertyCode = ProCode
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.27")
        End Try

    End Sub

    Public Shared Sub UpdateBorrowStat(PropertyCode As String, Status As String)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where p.PropertyCode = PropertyCode
                              Select p).FirstOrDefault()
            updateStat.borrowerStat = Status
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.28")
        End Try

    End Sub

    Public Shared Sub UpdateInventoryBorrower(PropertyCode As String, Borrower As String)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where p.PropertyCode = PropertyCode
                              Select p).FirstOrDefault()
            updateStat.Borrower = Borrower
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.29")
        End Try
    End Sub

    Public Shared Sub UpdateReturnItem(PropertyCode As String, Runner As String)
        Try
            Dim updateBorrower = (From p In db.GetTable(Of tblAssetInventory)()
                                  Where p.PropertyCode = PropertyCode
                                  Select p).FirstOrDefault()
            updateBorrower.Borrower = 0

            Dim updateStat = (From p In db.GetTable(Of tblBorrowDetail)()
                              Where p.PropertyCode = PropertyCode
                              Select p).FirstOrDefault()
            updateStat.IsReturn = True
            updateStat.IsReturnDate = DateAndTime.Now
            updateStat.ReturnBy = Home.EmployeeID
            updateStat.Runner = Runner

            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Error.U.30")
        End Try
    End Sub

    Public Shared Sub UpdateDeployment(PropertyCode As String, InvId As Integer)

        Dim updateDeployment = (From p In db.GetTable(Of tblAssetInventory)()
                                Where p.InvID = InvId And p.PropertyCode = PropertyCode
                                Select p).FirstOrDefault()

        updateDeployment.Deployed = 1
        updateDeployment.DateDeployed = DateAndTime.Now
        updateDeployment.DeployBy = Home.EmployeeID

        db.SubmitChanges()
    End Sub

End Class

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class InsertionClass
    '--------------------------------------------------------------------------------------------
    'Save in tblRequest Detail
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAquisitionRequest() As System.Data.Linq.Table(Of tblRequestDetail)
        Return db.GetTable(Of tblRequestDetail)()
    End Function

    '--------------------------------------------------------------------------------------------
    'Save in tblprocure Detail
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetProcureDetail() As System.Data.Linq.Table(Of tblProcureDetail)
        Return db.GetTable(Of tblProcureDetail)()
    End Function
    '--------------------------------------------------------------------------------------------
    'Save in tblprocure Header
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetProcureHeader() As System.Data.Linq.Table(Of tblProcureHeader)
        Return db.GetTable(Of tblProcureHeader)()
    End Function

    '--------------------------------------------------------------------------------------------
    'Save in tblRequestHeader
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAqRequestHeader() As System.Data.Linq.Table(Of tblRequestHeader)
        Return db.GetTable(Of tblRequestHeader)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblEmployee
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetEmployee() As System.Data.Linq.Table(Of tblEmployee)
        Return db.GetTable(Of tblEmployee)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblAllocationHeader
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAllocationHeader() As System.Data.Linq.Table(Of tblAllocationHeader)
        Return db.GetTable(Of tblAllocationHeader)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblAllocationHeader
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAllocationDetail() As System.Data.Linq.Table(Of tblAllocationDetail)
        Return db.GetTable(Of tblAllocationDetail)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblCategory
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAssetCategory() As System.Data.Linq.Table(Of tblCategory)
        Return db.GetTable(Of tblCategory)()
    End Function

    Public Shared Function GetAssetBuildHeader() As System.Data.Linq.Table(Of tblmasterlisheader)
        Return db.GetTable(Of tblmasterlisheader)()
    End Function
    '--------------------------------------------------------------------------------------------
    'For tblPropertyCodeSeries
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAssetBuildDetail() As System.Data.Linq.Table(Of tblmasterlistdetail)
        Return db.GetTable(Of tblmasterlistdetail)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblPropertyCodeSeries
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetPropertyCode() As System.Data.Linq.Table(Of tblPropertyCodeSery)
        Return db.GetTable(Of tblPropertyCodeSery)()
    End Function
    '--------------------------------------------------------------------------------------------
    'For tblAssetInventory
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetInventory() As System.Data.Linq.Table(Of tblAssetInventory)
        Return db.GetTable(Of tblAssetInventory)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblBuildDetail
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetBuildDetail() As System.Data.Linq.Table(Of tblBuildDetail)
        Return db.GetTable(Of tblBuildDetail)()
    End Function

    '--------------------------------------------------------------------------------------------
    'For tblBuildHeader
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetBuildHeader() As System.Data.Linq.Table(Of tblBuildHeader)
        Return db.GetTable(Of tblBuildHeader)()
    End Function

    '--------------------------------------------------------------------------------------------
    'Save To Records in tblBuildHeader Header
    '--------------------------------------------------------------------------------------------

    Public Shared Sub SaveBuildHeader(ByVal Entryno As String,
                                      ByVal TransDate As Date,
                                      ByVal Remarks As String,
                                      ByVal Emplyid As Integer)
        Try
            Dim post As Table(Of tblBuildHeader) = InsertionClass.GetBuildHeader
            Dim p As New tblBuildHeader With
                {
            .EntryNumber = Entryno,
            .TransDate = TransDate,
            .Remarks = Remarks,
            .UserID = Emplyid
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    '--------------------------------------------------------------------------------------------
    'Save in tblAssetInventory
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveAssetInventory(ByVal AssetCode As Integer,
                                         ByVal Class1 As String,
                                         ByVal PropertyCode As String,
                                         ByVal Des As String,
                                         ByVal Qty As Double,
                                         ByVal Keeper As Integer,
                                         ByVal Owner As Integer,
                                         ByVal Borrower As Integer,
                                         ByVal Reference As String,
                                         ByVal ReferenceNo As String,
                                         ByVal BorrowerStat As String,
                                         ByVal Status1 As String,
                                         ByVal Status2 As String,
                                         ByVal con As String)
        Try
            Dim post As Table(Of tblAssetInventory) = InsertionClass.GetInventory
            Dim p As New tblAssetInventory With
                {
                .AssetCode = AssetCode,
                .[Class] = Class1,
                .PropertyCode = PropertyCode,
                .Des = Des,
                .Qty = Qty,
                .Keeper = Keeper,
                .Owner = Owner,
                .Borrower = Borrower,
                .Reference = Reference,
                .Referenceno = ReferenceNo,
                .borrowerStat = BorrowerStat,
                .Status1 = Status1,
                .Status2 = Status2,
                .Condition = con
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Save To Records in tblBuildDetail Detail
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveBuildDetail(ByVal AssetCode As Integer,
                                        ByVal Class1 As String,
                                        ByVal PropertyCode As String,
                                        ByVal Des As String,
                                        ByVal Qty As Double,
                                        ByVal Keeper As Integer,
                                        ByVal Owner As Integer,
                                        ByVal Borrower As Integer,
                                        ByVal Reference As String,
                                        ByVal ReferenceNo As String,
                                        ByVal BorrowerStat As String,
                                        ByVal Status1 As String,
                                        ByVal Status2 As String,
                                        ByVal con As String,
                                        ByVal HeaderID As Integer)
        Try
            Dim post As Table(Of tblBuildDetail) = InsertionClass.GetBuildDetail
            Dim p As New tblBuildDetail With
                {
                .AssetCode = AssetCode,
                .[Class] = Class1,
                .PropertyCode = PropertyCode,
                .Des = Des,
                .Qty = Qty,
                .Keeper = Keeper,
                .Owner = Owner,
                .Borrower = Borrower,
                .Reference = Reference,
                .Referenceno = ReferenceNo,
                .borrowerStat = BorrowerStat,
                .Status1 = Status1,
                .Status2 = Status2,
                .Condition = con,
                .headerid = HeaderID
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Save in tblPropertyCodeSeries
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SavePropertyCode(ByVal Cat1 As String,
                                       ByVal Type As String,
                                       ByVal series1 As String)

        Try

            Dim post As Table(Of tblPropertyCodeSery) = InsertionClass.GetPropertyCode
            Dim p As New tblPropertyCodeSery With
                {
             .cat = Cat1,
             .type = Type,
             .series = series1
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try

    End Sub

    '--------------------------------------------------------------------------------------------
    'Save in New Asset Class Detail
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveAssetDetail(ByVal Assetcode As String,
                                      ByVal Description As String,
                                      ByVal Category As Integer,
                                      ByVal Type As Integer,
                                      ByVal TransHeaderId As Integer)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            Dim post As Table(Of tblmasterlistdetail) = InsertionClass.GetAssetBuildDetail

            Dim p As New tblmasterlistdetail With
                {
                  .ItemCode = Assetcode,
                  .AssetDescription = Description,
                  .CategoryID = Category,
                  .AssetTypeID = Type,
                  .DateCreated = currentdate,
                  .DateModified = currentdate,
                  .UserID = user,
                  .UserIDModified = user,
                  .AssetHeaderID = TransHeaderId
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Import Data in tblAssetDetailMasterlist
    '--------------------------------------------------------------------------------------------

    Public Shared Sub SaveMasterlistImport(ByVal itemcode As String,
                                           ByVal des As String,
                                           ByVal catid As Integer,
                                           ByVal typeid As Integer,
                                           ByVal date1 As Date,
                                           ByVal date2 As Date,
                                           ByVal user1 As Integer,
                                           ByVal user2 As Integer,
                                           ByVal AH As Integer)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            Dim post As Table(Of tblmasterlistdetail) = InsertionClass.GetAssetBuildDetail

            Dim p As New tblmasterlistdetail With
                {
                 .ItemCode = itemcode,
                 .AssetDescription = des,
                 .CategoryID = catid,
                 .AssetTypeID = typeid,
                 .DateCreated = date1,
                 .DateModified = date2,
                 .UserID = user1,
                 .UserIDModified = user2,
                 .AssetHeaderID = AH
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Save in New Asset Class Header
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveMasterlistHeader(ByVal entry As String,
                                           ByVal remarks As String,
                                           ByVal date1 As Date)
        Try

            Dim user As Integer = Home.UserID
            Dim post As Table(Of tblmasterlisheader) = InsertionClass.GetAssetBuildHeader

            Dim p As New tblmasterlisheader With
                {
                  .UserID = user,
                  .EntryNumber = entry,
                  .TransDate = date1,
                  .Remarks = remarks
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            'After Insert Load View

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Save in New Category
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveCategory(ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spNewCategory(ATC.ToUpper, StrConv(ATD, VbStrConv.ProperCase), currentdate, currentdate, user, user)
            MessageBox.Show("Asset Category Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetCategory.ViewCategory()

            With AssetCategoryAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Save in Assignment Header 
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveAssignmentHeader(ByVal Entrynumber As String,
                                           ByVal Requestor As Integer,
                                           ByVal HDate As Date,
                                           ByVal RequestID As Integer)
        Try
            Dim post As Table(Of tblAllocationHeader) = InsertionClass.GetAllocationHeader
            Dim p As New tblAllocationHeader With
                {
              .EntryNumber = Entrynumber,
              .Requestor = Requestor,
              .[Date] = HDate,
              .RequestID = RequestID
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------
    'Save in Assignment Details
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveAssignmentDetails(ByVal Qty As Double,
                                            ByVal PropertryCode As String,
                                            ByVal HeaderId As String,
                                            ByVal Employee As String,
                                            ByVal ItemCode As String)
        Try
            Dim post As Table(Of tblAllocationDetail) = InsertionClass.GetAllocationDetail
            Dim p As New tblAllocationDetail With
                {
                  .Qty = Qty,
                  .PropertyCode = PropertryCode,
                  .HeaderID = HeaderId,
                  .Employee = Employee,
                  .ItemCode = ItemCode
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------
    'Save in Employee
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveEmployee(ByVal fname As String,
                                   ByVal lname As String,
                                   ByVal BranchID As Integer,
                                   ByVal DepID As Integer,
                                   ByVal PID As Integer,
                                   ByVal SecID As Integer,
                                   ByVal manager As Integer,
                                   ByVal compny As String)
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
    '--------------------------------------------------------------------------------------------
    'Save in Request Header
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveRequestHeader(ByVal reqno As String,
                                        ByVal reqby As Integer,
                                        ByVal date1 As Date,
                                        ByVal stat As String,
                                        ByVal rtype As String)
        Try
            Dim post As Table(Of tblRequestHeader) = InsertionClass.GetAqRequestHeader

            Dim p As New tblRequestHeader With
                {
                  .RequestNo = reqno,
                  .RequestBy = reqby,
                  .[Date] = date1,
                  .Stat = stat,
                  .RequestType = rtype,
                  .Stat1 = 0,
                  .Stat2 = 0,
                  .Stat3 = 0,
                  .Stat4 = 0
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------
    'Save in Procurement Header
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveProcurementHeader(ByVal RequestNUmber As String,
                                            ByVal Requestor As Integer,
                                            ByVal pdate As Date)
        Try
            Dim Trastype As String = "Procure"
            Dim post As Table(Of tblProcureHeader) = InsertionClass.GetProcureHeader

            Dim p As New tblProcureHeader With
                {
               .RequestNumber = RequestNUmber,
               .Requestor = Requestor,
               .TransType = Trastype,
               .[Date] = pdate
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
    '--------------------------------------------------------------------------------------------
    'Save in Procurement DEtail
    '--------------------------------------------------------------------------------------------
    Public Shared Sub SaveProcurementDetail(ByVal AssetCode As String,
                                            ByVal ItemClass As String,
                                            ByVal Requestfor As String,
                                            ByVal Quantity As Double,
                                            ByVal remaks As String,
                                            ByVal State As String,
                                            ByVal TransId As Integer)
        Try

            Dim Trastype As String = "Procure"
            Dim post As Table(Of tblProcureDetail) = InsertionClass.GetProcureDetail

            Dim p As New tblProcureDetail With
                {
               .AssetCode = AssetCode,
               .[Class] = ItemClass,
               .Requestfor = Requestfor,
               .Quantity = Quantity,
               .Remarks = remaks,
               .State = State,
               .TransID = TransId
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    'Save Request Procurement
    '------------------------------------------------------------------------------------
    Public Shared Sub SaveProcurement(ByVal assetcode As Integer,
                           ByVal Class1 As String,
                           ByVal Qty As Double,
                           ByVal Owner As Integer,
                           ByVal remarks As String,
                           ByVal HeaderID As Integer)


        Dim Status = "OPEN"
        Dim State = "OPEN"
        Dim Approval = 0
        Dim post As Table(Of tblRequestDetail) = InsertionClass.GetAquisitionRequest
        Dim p As New tblRequestDetail With
            {
             .AssetCode = assetcode,
             .[Class] = Class1,
             .Qty = Qty,
             .Owner = Owner,
             .Remarks = remarks,
             .HeaderID = HeaderID,
             .Status = Status,
             .State = State,
             .Approve1 = Approval,
             .Approve2 = Approval,
             .Approve3 = Approval,
             .Approve4 = Approval
            }
        post.InsertOnSubmit(p)
        post.Context.SubmitChanges()


    End Sub

    '------------------------------------------------------------------------------------
    'Save Request Borrow 
    '------------------------------------------------------------------------------------
    Public Shared Sub SaveBorrow(ByVal PropertyCode As String,
                          ByVal Des As String,
                          ByVal Qty As Double,
                          ByVal Borrowee As Integer,
                          ByVal remarks As String,
                          ByVal Date1 As Date,
                          ByVal Date2 As Date,
                          ByVal HeaderID As Integer)

        Try
            Dim Status = "OPEN"
            Dim Approval = 0
            Dim post As Table(Of tblRequestDetail) = InsertionClass.GetAquisitionRequest
            Dim p As New tblRequestDetail With
                {
                 .PropertyCode = PropertyCode,
                 .Description = Des,
                 .Qty = Qty,
                 .Borrowee = Borrowee,
                 .Remarks = remarks,
                 .DateFrom = Date1,
                 .DateTo = Date2,
                 .HeaderID = HeaderID,
                 .Status = Status,
                 .Approve1 = Approval,
                 .Approve2 = Approval,
                 .Approve3 = Approval,
                 .Approve4 = Approval
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '------------------------------------------------------------------------------------
    'Save Request Transfer
    '------------------------------------------------------------------------------------
    Public Shared Sub SaveTRansferOwner(ByVal PropertyCode As String,
                         ByVal Des As String,
                         ByVal Qty As Double,
                         ByVal NewOwnwer As Integer,
                         ByVal remarks As String,
                         ByVal HeaderID As Integer)

        Try
            Dim Status = "OPEN"
            Dim Approval = 0
            Dim post As Table(Of tblRequestDetail) = InsertionClass.GetAquisitionRequest
            Dim p As New tblRequestDetail With
                {
                 .PropertyCode = PropertyCode,
                 .Description = Des,
                 .Qty = Qty,
                 .NewOwner = NewOwnwer,
                 .Remarks = remarks,
                 .HeaderID = HeaderID,
                 .Status = Status,
                 .Approve1 = Approval,
                 .Approve2 = Approval,
                 .Approve3 = Approval,
                 .Approve4 = Approval
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
End Class

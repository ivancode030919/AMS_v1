Public Class ViewClass

    '------------------------------------------------------------------------------------
    'Display in Detail In Request Register
    '------------------------------------------------------------------------------------
    Public Shared Sub FetchRegisterDetail1(ByVal HeaderID As Integer, ByVal RequestType As String)

        If RequestType = "PROCURE" Then
            Dim depID As Integer
            If Home.UserType = "ADMIN" Then
                'Condition in Scalar-Valued-Function
                depID = 0
            ElseIf Home.UserType = "DPC" Then
                'Condition in Scalar-Valued-Function
                depID = Home.DepartmentID
            ElseIf Home.UserType = "BPC" Then
                depID = 1
            End If

            With Rqregister
                .dgv.DataSource = db.ShowAssetAvailabilityProcure(HeaderID, depID)
            End With
        ElseIf RequestType = "BORROW" Then
            With Rqregister
                .dgv.DataSource = db.ShowAssetAvailabilityBorrow(HeaderID)
            End With
        ElseIf RequestType = "TRANSFER OWNERSHIP" Then
        End If

    End Sub

    '------------------------------------------------------------------------------------
    'Display in Assignmet1 form for datagridview
    '------------------------------------------------------------------------------------
    Public Shared Function FetchRegisterDetail(ByVal headerid As Integer) As Object
        Dim depID As Integer

        If Home.UserType = "ADMIN" Then
            depID = 0
        ElseIf Home.UserType = "BPC" Then
            depID = 1
        ElseIf Home.UserType = "DPC" Then
            depID = Home.DepartmentID
        End If

        With Assignment1
            .dgv.DataSource = db.ShowAssetAvailability2(headerid, depID)
        End With

    End Function

    '------------------------------------------------------------------------------------
    'Display in Asset3 Form
    '------------------------------------------------------------------------------------
    Public Shared Function ViewInventoryDetails1() As Object
        Dim query = (From q In db.tblAssetInventories
                     Join w In db.tblEmployees On q.Owner Equals w.EmployeeID
                     Join e In db.tblDepartments On w.DepartmentID Equals e.DepartmentID
                     Join r In db.tblBranches On w.BranchID Equals r.BranchID
                     Join t In db.tblSections On w.SectionID Equals t.SectionID
                     Join y In db.tblEmployees On q.Keeper Equals y.EmployeeID
                     Let n = w.FirstName + ", " + w.LastName Let m = y.LastName + ", " + y.FirstName
                     Select q.PropertyCode, q.Des, q.Qty, e.DepartmentDescription, r.BranchDescription, t.SectionDecription, n, m)
        Return query
    End Function

    '------------------------------------------------------------------------------------
    'Display in Assignment Form For Choosing To be Assigned Assets that is Available
    '------------------------------------------------------------------------------------
    Public Shared Function ViewAvailableAssets(ByVal ac As Integer) As Object

        If Home.UserType = "ADMIN" Then

            Dim query = (From q In db.tblAssetInventories
                         Join y In db.tblEmployees On q.Keeper Equals y.EmployeeID
                         Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                         Join r In db.tblBranches On y.BranchID Equals r.BranchID
                         Join t In db.tblSections On y.SectionID Equals t.SectionID
                         Where q.Owner = 0 And q.AssetCode = ac
                         Let m = y.LastName + ", " + y.FirstName
                         Select q.PropertyCode, q.Des, q.Qty, m, e.DepartmentDescription, r.BranchDescription, t.SectionDecription, q.Reference, q.Referenceno, q.InvID)
            Return query

        ElseIf Home.UserType = "DPC" Then

            Dim query = (From q In db.tblAssetInventories
                         Join y In db.tblEmployees On q.Keeper Equals y.EmployeeID
                         Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                         Join r In db.tblBranches On y.BranchID Equals r.BranchID
                         Join t In db.tblSections On y.SectionID Equals t.SectionID
                         Where q.Owner = 0 And q.AssetCode = ac And (y.DepartmentID = Home.DepartmentID)
                         Let m = y.LastName + ", " + y.FirstName
                         Select q.PropertyCode, q.Des, q.Qty, m, e.DepartmentDescription, r.BranchDescription, t.SectionDecription, q.Reference, q.Referenceno, q.InvID)

        ElseIf Home.UserType = "BPC" Then

            Dim query = (From q In db.tblAssetInventories
                         Join y In db.tblEmployees On q.Keeper Equals y.EmployeeID
                         Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                         Join r In db.tblBranches On y.BranchID Equals r.BranchID
                         Join t In db.tblSections On y.SectionID Equals t.SectionID
                         Where q.Owner = 0 And q.AssetCode = ac And (y.DepartmentID = Home.DepartmentID)
                         Let m = y.LastName + ", " + y.FirstName
                         Select q.PropertyCode, q.Des, q.Qty, m, e.DepartmentDescription, r.BranchDescription, t.SectionDecription, q.Reference, q.Referenceno, q.InvID)
            Return query

        End If


    End Function

    '------------------------------------------------------------------------------------
    'Display Asset Type in Adding New Asset Class for Choosing Type
    '------------------------------------------------------------------------------------
    Public Shared Function ViewNaAsset(ByVal search As String) As Object

        Dim querysection = (From s In db.tblAssetTypes
                            Where ((s.AssetTypeCode.Contains(search) Or s.AssetTypeDescription.Contains(search)) Or search = "")
                            Order By s.AssetTypeID
                            Select s.AssetTypeID, s.AssetTypeCode, s.AssetTypeDescription).ToList
        Return querysection
    End Function
    '------------------------------------------------------------------------------------
    'Display Asset Category in Adding New Asset Class  for Choosing Category
    '------------------------------------------------------------------------------------
    Public Shared Function ViewNaCategory(ByVal search As String) As Object

        Dim querysection = (From s In db.tblCategories
                            Where ((s.CategoryCode.Contains(search) Or s.CategoryDescription.Contains(search)) Or search = "")
                            Order By s.CategoryID
                            Select s.CategoryID, s.CategoryCode, s.CategoryDescription).ToList
        Return querysection
    End Function
    '------------------------------------------------------------------------------------
    'Display Inventory Details in 
    '------------------------------------------------------------------------------------
    Public Shared Function ViewInventoryDetails(ByVal AssetCode As Integer, ByVal search As String) As Object
        Dim DepCode As String


        If Home.UserType = "ADMIN" Then
            'Make All Asset Visible in Admin
            DepCode = ""
        Else
            'Make not Admin User Type Department Ownership
            DepCode = Home.Department
        End If

        Dim vinv = (From p In db.tblAssetInventories
                    Group Join y In db.tblEmployees On p.Keeper Equals y.EmployeeID Into KeeperGroup = Group
                    From y In KeeperGroup.DefaultIfEmpty()
                    Group Join t In db.tblEmployees On p.Owner Equals t.EmployeeID Into OwnerGroup = Group
                    From t In OwnerGroup.DefaultIfEmpty()
                    Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                    Join h In db.tblBranches On y.BranchID Equals h.BranchID
                    Join l In db.tblSections On y.SectionID Equals l.SectionID
                    Where p.AssetCode = AssetCode And e.DepartmentCode.Contains(DepCode) AndAlso (p.PropertyCode.Contains(search) Or p.Des.Contains(search))
                    Let f = y.LastName + ", " + y.FirstName Let q = t.LastName + ", " + t.FirstName Let o = p.PropertyCode & If(p.IsChildSeries = 0, "", "-" & p.IsChildSeries.ToString())
                    Select o, p.Des, p.Qty, e.DepartmentDescription, h.BranchDescription, l.SectionDecription, f, q).ToList
        Return vinv


    End Function

    'Display Request Register(For Approval) Details in 
    Public Shared Function FetchsRequstRegister(ByVal stat1 As String, ByVal date1 As Date, date2 As Date) As Object
        Dim stat2 As String

        If stat1 = 1 Then
            stat2 = "OPEN"
        ElseIf stat1 = 2 Then
            stat2 = ""
        ElseIf stat1 = 3 Then
            stat2 = "CLOSED"
        ElseIf stat1 = 4 Then
            stat2 = "CANCELLED"
        Else
            stat2 = ""
        End If

        Dim query = (From s In db.tblRequestHeaders
                     Join k In db.tblEmployees On s.RequestBy Equals k.EmployeeID
                     Join f In db.tblDepartments On k.DepartmentID Equals f.DepartmentID
                     Join h In db.tblBranches On k.BranchID Equals h.BranchID
                     Join q In db.tblSections On k.SectionID Equals q.SectionID
                     Where s.Stat.Contains(stat2) AndAlso (s.Date >= date1 AndAlso s.Date <= date2)
                     Let y = k.LastName + ", " + k.FirstName
                     Select s.Date, s.RequestNo, s.RequestType, k.Company, f.DepartmentDescription, h.BranchDescription, q.SectionDecription, y, s.Stat, s.HeaderId, s.RequestBy).ToList
        Return query

    End Function

    '------------------------------------------------------------------------------------
    'Display Item List in AssetList
    '------------------------------------------------------------------------------------
    Public Shared Function Fetchrlist1(ByVal Search As String) As Object

        Dim querysection = (From f In db.tblmasterlistdetails
                            Join d In db.tblCategories On f.CategoryID Equals d.CategoryID
                            Join g In db.tblAssetTypes On f.AssetTypeID Equals g.AssetTypeID
                            Where (f.AssetDescription.Contains(Search) Or f.ItemCode = Search)
                            Order By f.AssetDescription Ascending
                            Select f.ItemCode, f.AssetDescription, f.ItemID, d.CategoryCode, g.AssetTypeCode)

        Return querysection
    End Function

    '------------------------------------------------------------------------------------
    'Display Item List in Masterdata
    '------------------------------------------------------------------------------------
    Public Shared Function Fetchmasterdata(ByVal Search As String, ByVal Cat As String, ByVal type As String) As Object
        Dim querysection = (From f In db.tblmasterlistdetails
                            Join c In db.tblCategories On f.CategoryID Equals c.CategoryID
                            Join k In db.tblAssetTypes On f.AssetTypeID Equals k.AssetTypeID
                            Where (f.AssetDescription.Contains(Search) Or f.ItemCode = Search) And (c.CategoryDescription = Cat Or Cat = "") And (k.AssetTypeDescription = type Or type = "")
                            Order By f.AssetDescription Ascending
                            Select f.ItemCode, f.AssetDescription, c.CategoryDescription, k.AssetTypeDescription).ToList()
        Return querysection
    End Function
    '------------------------------------------------------------------------------------
    'Display Item List in New Asset Register
    '------------------------------------------------------------------------------------
    Public Shared Function FetchDatatoDGV1(ByVal Search As String, ByVal date1 As Date, ByVal date2 As Date, ByVal mods As Integer) As Object
        Dim querysection = (From s In db.tblAssetHeaders
                            Join u In db.tblUsers On s.UserID Equals u.UserID
                            Join j In db.tblEmployees On u.EmployeeID Equals j.EmployeeID
                            Where (s.EntryNumber.Contains(Search)) And (s.TransDate >= date1 AndAlso s.TransDate <= date2) And (s.module1 = mods)
                            Order By s.AssetHeaderID Ascending
                            Let fl = j.FirstName + " " + j.LastName
                            Select New With {s.TransDate, s.EntryNumber, s.Remarks, fl, s.AssetHeaderID}).ToList()
        Return querysection
    End Function

    '------------------------------------------------------------------------------------
    'Display In Procure Register
    '------------------------------------------------------------------------------------
    Public Shared Function ViewProcureRegister(ByVal rqnumber As String, ByVal date1 As Date, ByVal date2 As Date) As Object
        Dim querysection = (From s In db.tblProcureHeaders
                            Join r In db.tblEmployees On s.Requestor Equals r.EmployeeID
                            Join t In db.tblDepartments On r.DepartmentID Equals t.DepartmentID
                            Join y In db.tblBranches On r.BranchID Equals y.BranchID
                            Where s.Date >= date1 AndAlso s.Date <= date2 AndAlso s.RequestNumber.Contains(rqnumber)
                            Let x = r.FirstName + " " + r.LastName
                            Select s.RequestNumber, x, t.DepartmentDescription, y.BranchDescription, r.Company, s.Date, s.id).ToList()
        Return querysection
    End Function

    'View Employee List
    Public Shared Function ViewEmployeeList(ByVal search As String) As Object
        Dim querysection = (From s In db.tblEmployees
                            Where s.FirstName.Contains(search) Or s.LastName.Contains(search)
                            Order By s.EmployeeID
                            Select s.EmployeeID, s.FirstName, s.LastName).ToList
        Return querysection
    End Function

    'View Users
    Public Shared Function FetchUser(ByVal stat As String, Optional ByVal des As String = "", Optional ByVal search As String = "") As Object

        Dim querysection = (From s In db.tblUsers
                            Join d In db.tblEmployees On s.EmployeeID Equals d.EmployeeID
                            Join f In db.tblPositions On d.PositionID Equals f.PositionID
                            Where (s.Status = stat) And f.PositionDescription.Contains(des) And (d.FirstName.Contains(search) Or d.LastName.Contains(search))
                            Order By s.UserID
                            Select s.UserID, d.FirstName, d.LastName, f.PositionDescription, s.Status).ToList()
        Return querysection
    End Function

    'View Employee in Request
    Public Shared Function ViewEmployeeList5(ByVal search As String) As Object

        If Home.UserType = "ADMIN" Then

            Dim querysection = (From s In db.tblEmployees
                                Where s.FirstName.Contains(search) Or s.LastName.Contains(search) Or (s.FirstName + " " + s.LastName).Contains(search)
                                Order By s.EmployeeID
                                Let g = s.FirstName + " " + s.LastName
                                Select s.EmployeeID, g).ToList
            Return querysection

        ElseIf Home.UserType = "BPC" Then

            Dim querysection = (From s In db.tblEmployees
                                Where (s.BranchID = Home.BranchID And s.DepartmentID = Home.DepartmentID And s.SectionID <> "2021") And (s.FirstName.Contains(search) Or s.LastName.Contains(search) Or (s.FirstName + " " + s.LastName).Contains(search))
                                Order By s.EmployeeID
                                Let g = s.FirstName + " " + s.LastName
                                Select s.EmployeeID, g).ToList
            Return querysection


        End If

    End Function

    'View Employee in Employee setup
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


    'View Procurement Detail
    Public Shared Function ViewProcureDetails(ByVal TransId As Integer) As Object

        Dim querysection = (From s In db.tblProcureDetails
                            Join g In db.tblEmployees On s.Requestfor Equals g.EmployeeID
                            Where s.TransID = TransId
                            Let c = g.FirstName + " " + g.LastName
                            Select s.AssetCode, s.Class, c, s.Quantity, s.Remarks, s.State, s.id, s.Requestfor, s.PropertyCode, s.Description, s.Reference, s.ReferenceNo)
        Return querysection

    End Function

End Class



'Dim result = (From ai In context.tblAssetInventory
'              Order By ai.InvID Descending
'              Select PropertyCodeOrChildSeries = If(ai.isChildSeries = 0 OrElse ai.isChildSeries Is Nothing,
'                                                           ai.PropertyCode,
'                                                           ai.PropertyCode & "-" & ai.isChildSeries.ToString())).ToList()

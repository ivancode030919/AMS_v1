Public Class ViewClass

    '------------------------------------------------------------------------------------
    'Display in Detail In Request Register
    '------------------------------------------------------------------------------------
    Public Shared Sub FetchRegisterDetail1(ByVal HeaderID As Integer, ByVal RequestType As String)

        If RequestType = "Procure" Then
            With Rqregister
                .dgv.DataSource = db.ShowAssetAvailability(HeaderID)
            End With
        ElseIf RequestType = "Borrow" Then
        ElseIf RequestType = "Transfer Ownership" Then
        End If

    End Sub

    '------------------------------------------------------------------------------------
    'Display in Assignmet1 form for datagridview
    '------------------------------------------------------------------------------------
    Public Shared Function FetchRegisterDetail(ByVal headerid As Integer) As Object
        With Assignment1
            .dgv.DataSource = db.ShowAssetAvailability2(headerid)
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
        Dim query = (From q In db.tblAssetInventories
                     Join y In db.tblEmployees On q.Keeper Equals y.EmployeeID
                     Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                     Join r In db.tblBranches On y.BranchID Equals r.BranchID
                     Join t In db.tblSections On y.SectionID Equals t.SectionID
                     Let m = y.LastName + ", " + y.FirstName
                     Where q.Owner = 0 And q.AssetCode = ac
                     Select q.PropertyCode, q.Des, q.Qty, m, e.DepartmentDescription, r.BranchDescription, t.SectionDecription)
        Return query
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
    Public Shared Function ViewInventoryDetails(ByVal AssetCode As Integer) As Object

        Dim vinv = (From p In db.tblAssetInventories
                    Group Join y In db.tblEmployees On p.Keeper Equals y.EmployeeID Into KeeperGroup = Group
                    From y In KeeperGroup.DefaultIfEmpty()
                    Group Join t In db.tblEmployees On p.Owner Equals t.EmployeeID Into OwnerGroup = Group
                    From t In OwnerGroup.DefaultIfEmpty()
                    Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                    Join h In db.tblBranches On y.BranchID Equals h.BranchID
                    Join l In db.tblSections On y.SectionID Equals l.SectionID
                    Where p.AssetCode = AssetCode
                    Let f = y.LastName + ", " + y.FirstName Let q = t.LastName + ", " + t.FirstName
                    Select p.PropertyCode, p.Des, p.Qty, e.DepartmentDescription, h.BranchDescription, l.SectionDecription, f, q).ToList
        Return vinv

    End Function
    '------------------------------------------------------------------------------------
    'Display Request Register(For Approval) Details in 
    '------------------------------------------------------------------------------------
    Public Shared Function FetchsRequstRegister() As Object

        Dim query = (From s In db.tblRequestHeaders
                     Join k In db.tblEmployees On s.RequestBy Equals k.EmployeeID
                     Join f In db.tblDepartments On k.DepartmentID Equals f.DepartmentID
                     Join h In db.tblBranches On k.BranchID Equals h.BranchID
                     Join q In db.tblSections On k.SectionID Equals q.SectionID
                     Where s.Stat = "Open"
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
                            Where f.AssetDescription.Contains(Search)
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
End Class

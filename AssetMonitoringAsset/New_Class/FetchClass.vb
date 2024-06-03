Public Class FetchClass

    'Fetch Last Item Code in New Asset Class
    Public Shared Function FetchLastItemcode() As String
        Try
            Dim querysection = (From s In db.tblmasterlistdetails
                                Order By Convert.ToInt32(s.ItemCode) Descending
                                Select s.ItemCode).FirstOrDefault
            Return querysection
        Catch ex As Exception

            MsgBox("Error.F-3")
        End Try

    End Function


    'Fetch HeaderID in BUild Assdet Header
    Public Shared Function FetcHeaderID() As String
        Try
            Dim querysection As String = (From s In db.tblBuildHeaders
                                          Order By s.id Descending
                                          Select s.id).FirstOrDefault()
            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-4")
        End Try

    End Function


    'display Last save Entry Number
    Public Shared Function FetchEntryn1() As String
        Try
            Dim querysection As String = (From s In db.tblBuildHeaders
                                          Order By s.id Descending
                                          Where s.EntryNumber <> ""
                                          Select s.EntryNumber).FirstOrDefault()
            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-5")
        End Try

    End Function


    'Fetch AssetList
    Public Shared Sub ViewInventory(ByVal Search As String, ByVal Depcode As String, ByVal cat As String, ByVal type As String)
        'Try
        With InventoryList
            ''soure for viewing
            .dgv.DataSource = db.spViewInventory(Depcode, Search, cat, type)
            ''set column name
            .dgv.Columns(0).HeaderText = "Asset Code"
            .dgv.Columns(1).HeaderText = "Description"
            .dgv.Columns(2).HeaderText = "Quantity"
        End With
        'Catch ex As Exception
        '    MsgBox("Error.F-6")
        'End Try
    End Sub


    'Fetch Last Entry Number then Plus 1 in series for new entry Number
    Public Shared Function FetchEntryno() As String
        Try
            Dim querysection As String = (From s In db.tblBuildHeaders
                                          Order By s.id Descending
                                          Where s.EntryNumber <> ""
                                          Select s.EntryNumber).FirstOrDefault()

            If IsNothing(querysection) Then
                Dim newEntryID As String = "BA" + "-" + Home.Department + "-" + Home.Branch + "-" + Home.Section + "-" + "000001"
                Return newEntryID
            Else
                Dim parts As String() = querysection.Split("-"c)
                Dim lastPart As String = parts(parts.Length - 1)
                Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

                ' Assuming you want the format "000001" for all values, you can use the following format.
                Dim formattedNextNumber As String = nextNumber.ToString("D6")
                Dim newEntryID As String = $"{"BA"}-{Home.Department}-{Home.Branch}-{Home.Section}-{formattedNextNumber}"

                Return newEntryID
            End If
        Catch ex As Exception
            MsgBox("Error.F-7")
        End Try


    End Function


    'Fetch ID in New Asset Class
    Public Shared Function FetchEntryID() As String
        Try
            Dim querysection As String = (From s In db.tblmasterlisheaders
                                          Order By s.AssetHeaderID Descending
                                          Where s.EntryNumber <> ""
                                          Select s.EntryNumber).FirstOrDefault()
            If IsNothing(querysection) Then
                Dim newEntryID As String = "NAM" + "-" + Home.Department + "-" + Home.Branch + "-" + Home.Section + "-" + "000001"
                Return newEntryID
            Else
                Dim parts As String() = querysection.Split("-"c)
                Dim lastPart As String = parts(parts.Length - 1)
                Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

                ' Assuming you want the format "000001" for all values, you can use the following format.
                Dim formattedNextNumber As String = nextNumber.ToString("D6")
                Dim newEntryID As String = $"{"NAM"}-{Home.Department}-{Home.Branch}-{Home.Section}-{formattedNextNumber}"

                ' Update the last part in the database, if requireds.
                ' db.tblAssetHeaders.Single().EntryNumber = newEntryIDs
                ' db.SaveChanges()

                Return newEntryID
            End If
        Catch ex As Exception
            MsgBox("Error.F-8")
        End Try
    End Function


    'Fetch Transheader id in New Asset Class
    Public Shared Function FetchTransHeaderID() As Integer
        Try
            Dim querysection As Integer = (From s In db.tblmasterlisheaders
                                           Order By s.AssetHeaderID Descending
                                           Select s.AssetHeaderID).FirstOrDefault()
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-9")
        End Try
    End Function


    'Fetch Combox Category
    Public Shared Function ViewCboxCat() As List(Of String)
        Try
            Dim querysection = (From s In db.tblCategories
                                Order By s.CategoryID
                                Select s.CategoryDescription).ToList
            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-10")
        End Try
    End Function

    'Fetch Count in Asset Category Add and Update
    Public Shared Function FetchCCount(ByVal code As String) As Integer
        Try
            Dim count As Integer = (From s In db.tblCategories
                                    Where (s.CategoryCode.Contains(code))
                                    Select s.CategoryCode).Count()
            Return count
        Catch ex As Exception
            Return MsgBox("Error.F-11")
        End Try
    End Function


    'Fetch Allocation Ebtry NUmber
    Public Shared Function FetchAllocationEntry() As String
        Try
            Dim querysection As String = (From s In db.tblAllocationHeaders
                                          Order By s.ID Descending
                                          Where s.EntryNumber <> ""
                                          Select s.EntryNumber).FirstOrDefault()

            If IsNothing(querysection) Then
                Dim newEntryID As String = "000001"
                Return newEntryID
            Else
                Dim parts As String() = querysection.Split("-"c)
                Dim lastPart As String = parts(parts.Length - 1)
                Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

                ' Assuming you want the format "000001" for all values, you can use the following format.
                Dim formattedNextNumber As String = nextNumber.ToString("D6")
                Dim newEntryID As String = $"{formattedNextNumber}"

                Return newEntryID
            End If
        Catch ex As Exception
            MsgBox("Error.F-12")
        End Try

    End Function


    'Check Employee if existing
    Public Shared Function FetchEmployeeCount(ByVal fname As String, ByVal lname As String) As Integer
        Try
            Dim count As Integer = (From s In db.tblEmployees
                                    Where (s.FirstName.Contains(fname) And s.LastName.Contains(lname))
                                    Select s).Count()
            Return count
        Catch ex As Exception
            Return MsgBox("Error.F-13")
        End Try

    End Function


    'Check list ui
    Public Shared Function Fetchrlist1(ByVal Search As String) As Object
        Try
            Dim querysection = (From f In db.tblmasterlistdetails
                                Join d In db.tblCategories On f.CategoryID Equals d.CategoryID
                                Join g In db.tblAssetTypes On f.AssetTypeID Equals g.AssetTypeID
                                Where f.AssetDescription.Contains(Search)
                                Order By f.AssetDescription Ascending
                                Select f.ItemCode, f.AssetDescription, f.ItemID, d.CategoryCode, g.AssetTypeCode)

            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-14")
        End Try

    End Function


    'Check Asset Availability Quantity
    Public Shared Function FetchAssetWithoutOwner(ByVal ItemCode As String) As Object
        Try
            If Home.UserType = "ADMIN" Then
                Dim querysection = (From f In db.tblAssetInventories
                                    Where f.AssetCode = ItemCode And f.Owner = 0
                                    Select f.Qty).Sum.ToString
                Return querysection
            Else
                Dim querysection = (From f In db.tblAssetInventories
                                    Join t In db.tblEmployees On f.Keeper Equals t.EmployeeID
                                    Where f.AssetCode = ItemCode And f.Owner = 0 And t.DepartmentID = Home.DepartmentID
                                    Select f.Qty).Sum.ToString
                Return querysection
            End If
        Catch ex As Exception
            MsgBox("Error.F-1")
        End Try

    End Function


    'Check If Cosumable
    Public Shared Function CheckifCosumable(ByVal ItemCodes As String) As Object
        Try
            Dim querysection = (From f In db.tblmasterlistdetails
                                Join g In db.tblCategories On f.CategoryID Equals g.CategoryID
                                Where (g.CategoryID <> 5002 AndAlso g.CategoryID <> 5003) And f.ItemCode = ItemCodes
                                Select f.ItemCode).FirstOrDefault

            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-2")
        End Try

    End Function


    'Fetch Last Assignment Entry Number
    Public Shared Function FetchAssignmentEntryNumber() As String
        Try
            Dim querysection As String = (From s In db.tblAllocationHeaders
                                          Order By s.ID Descending
                                          Where s.EntryNumber <> ""
                                          Select s.EntryNumber).FirstOrDefault()

            If IsNothing(querysection) Then
                Dim newEntryID As String = "000001"
                Return newEntryID
            Else
                Dim parts As String() = querysection.Split("-"c)
                Dim lastPart As String = parts(parts.Length - 1)
                Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

                ' Assuming you want the format "000001" for all values, you can use the following format.
                Dim formattedNextNumber As String = nextNumber.ToString("D6")
                Dim newEntryID As String = $"{formattedNextNumber}"

                Return newEntryID
            End If
        Catch ex As Exception
            MsgBox("Error.F-15")
        End Try
    End Function

    'Fetch Employee Name(Requestor in Request)
    Public Shared Function fetchRequestor(ByVal emplID As Integer) As Object
        Try
            Dim querysection = (From s In db.tblEmployees
                                Where s.EmployeeID = emplID
                                Let c = s.LastName + ", " + s.FirstName
                                Select c).FirstOrDefault
            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-16")
        End Try

    End Function

    'Fetch transheader id in Request
    Public Shared Function FetchTransHeaderIDRequest() As Object
        Try
            Dim querysection = (From s In db.tblRequestHeaders
                                Order By s.HeaderId Descending
                                Select s.HeaderId).FirstOrDefault()

            Return querysection

        Catch ex As Exception
            MsgBox("Error.F-18")
        End Try


    End Function

    'Fetch transheader id in For Approval
    Public Shared Function FetchTransIdForApproval() As Object
        Try
            Dim querysection = (From s In db.tblProcureHeaders
                                Order By s.id Descending
                                Select s.id).FirstOrDefault()

            Return querysection

        Catch ex As Exception
            MsgBox("Error.F-34")
        End Try
    End Function

    'Fetch transheader id in For Approval
    Public Shared Function FetchTransIdForApprovalBorrow() As Object
        Try
            Dim querysection = (From s In db.tblBorrowHeaders
                                Order By s.HeaderId Descending
                                Select s.HeaderId).FirstOrDefault()

            Return querysection

        Catch ex As Exception
            MsgBox("Error.F-17")
        End Try


    End Function
    'Fetch transheader id in Assignment

    Public Shared Function FetchTransHeaderIDAssignment() As Object
        Try
            Dim querysection = (From s In db.tblAllocationHeaders
                                Order By s.ID Descending
                                Select s.ID).FirstOrDefault()

            Return querysection

        Catch ex As Exception
            MsgBox("Error.F-19")
        End Try

    End Function


    'Fetch Last Request Number

    Public Shared Function FetchEntryID2() As String
        Try
            Dim querysection As String = (From s In db.tblRequestHeaders
                                          Order By s.HeaderId Descending
                                          Where s.RequestNo <> ""
                                          Select s.RequestNo).FirstOrDefault()

            If IsNothing(querysection) Then
                Dim newEntryID As String = "000001"
                Return newEntryID
            Else
                Dim parts As String() = querysection.Split("-"c)
                Dim lastPart As String = parts(parts.Length - 1)
                Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

                ' Assuming you want the format "000001" for all values, you can use the following format.
                Dim formattedNextNumber As String = nextNumber.ToString("D6")
                Dim newEntryID As String = $"{formattedNextNumber}"

                Return newEntryID
            End If
        Catch ex As Exception
            MsgBox("Error.F-20")
        End Try

    End Function
    'Check for Employee if Existing
    Public Shared Function CountUserEmployee(ByVal EID As Integer) As Integer
        Try
            Dim queryBook = (From p In db.tblUsers
                             Where (p.EmployeeID = EID)
                             Select p.EmployeeID).Count

            Return queryBook
        Catch ex As Exception
            Return MsgBox("Error.F-21")
        End Try
    End Function

    'Check if Username Is Existing 
    Public Shared Function CountUsername(ByVal uname As String) As Integer
        Try
            Dim queryBook = (From p In db.tblUsers
                             Where (p.Username = uname)
                             Select p.Username).Count
            Return queryBook
        Catch ex As Exception
            Return MsgBox("Error.F-22")
        End Try
    End Function

    'Fetch Login Credentials if Correct
    Public Shared Function FetchLogin(ByVal uname As String, ByVal pass As String) As Integer
        Try
            Dim queryBook = (From p In db.tblUsers
                             Where (p.Username = uname And p.Password = pass)
                             Select p.Username, p.Password).Count
            Return queryBook
        Catch ex As Exception
            Return MsgBox("Error.F-23")
        End Try
    End Function

    'Fetch Branch Code
    Public Shared Function FetcBranch(ByVal uname As String, ByVal pass As String) As String
        Try
            Dim querydetail = (From p In db.tblUsers
                               Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                               Join b In db.tblBranches On b.BranchID Equals e.BranchID
                               Where (p.Username = uname And p.Password = pass)
                               Select b.BranchCode).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-24")
        End Try
    End Function

    'Fetch Branch ID
    Public Shared Function FetcBranchID(ByVal BranchCode As String) As Integer
        Try
            Dim querydetail = (From p In db.tblBranches
                               Where (p.BranchCode = BranchCode)
                               Select p.BranchID).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-25")
        End Try
    End Function

    'Fetch Department Code
    Public Shared Function FetcDepartment1(ByVal uname As String, ByVal pass As String) As String
        Try
            Dim querydetail = (From p In db.tblUsers
                               Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                               Join d In db.tblDepartments On d.DepartmentID Equals e.DepartmentID
                               Where (p.Username = uname And p.Password = pass)
                               Select d.DepartmentCode).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-26")
        End Try
    End Function

    'Fetch User Type
    Public Shared Function FetcUserType(ByVal Emplid As Integer) As Object
        Try
            Dim querydetail = (From p In db.tblUsers
                               Where (p.EmployeeID = Emplid)
                               Select p.UserType).FirstOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-27")
        End Try
    End Function

    'Employee ID
    Public Shared Function FetcEmployeeID(ByVal UserID As Integer) As Integer
        Try
            Dim querydetail = (From p In db.tblUsers
                               Where (p.UserID = UserID)
                               Select p.EmployeeID).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-28")
        End Try
    End Function

    'Fetch User ID
    Public Shared Function FetcUserID(ByVal uname As String, ByVal pass As String) As Integer
        Try
            Dim querydetail = (From p In db.tblUsers
                               Where (p.Username = uname And p.Password = pass)
                               Select p.UserID).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-29")
        End Try


    End Function

    'Fetch Section Code
    Public Shared Function FetcSection(ByVal uname As String, ByVal pass As String) As String
        Try
            Dim querydetail = (From p In db.tblUsers
                               Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                               Join s In db.tblSections On s.SectionID Equals e.SectionID
                               Where (p.Username = uname And p.Password = pass)
                               Select s.SectionCode).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-30")
        End Try
    End Function

    'Fetch Departement Code
    Public Shared Function FetcDepartment(ByVal uname As String, ByVal pass As String) As String
        Try
            Dim querydetail = (From p In db.tblUsers
                               Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                               Join d In db.tblDepartments On d.DepartmentID Equals e.DepartmentID
                               Where (p.Username = uname And p.Password = pass)
                               Select d.DepartmentCode).SingleOrDefault

            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-31")
        End Try
    End Function

    'Fetch Department ID
    Public Shared Function FetcDepartmentID(ByVal DepartmentCode As String) As Integer
        Try
            Dim querydetail = (From p In db.tblDepartments
                               Where (p.DepartmentCode = DepartmentCode)
                               Select p.DepartmentID).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-32")
        End Try
    End Function

    'Fetch Section ID
    Public Shared Function FetcSectionID(ByVal SectionCode As String) As Integer
        Try
            Dim querydetail = (From p In db.tblSections
                               Where (p.SectionCode = SectionCode)
                               Select p.SectionID).SingleOrDefault
            Return querydetail
        Catch ex As Exception
            Return MsgBox("Error.F-33")
        End Try
    End Function

    'Fetch Asset Type Description
    Public Shared Function ViewCboxtype() As Object
        Try
            Dim querysection = (From s In db.tblAssetTypes
                                Order By s.AssetTypeID
                                Select s.AssetTypeDescription).ToList
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-34")
        End Try
    End Function

    'Fetch Asset Category Id
    Public Shared Function FetchCategoryId(ByVal categorydes As String) As Object
        Try
            Dim querysection = (From s In db.tblCategories
                                Where s.CategoryDescription = categorydes
                                Select s.CategoryID).SingleOrDefault
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-35")
        End Try
    End Function

    'Fetch Asset Type Id
    Public Shared Function FetchTypeId(ByVal Type As String) As Object
        Try
            Dim querysection = (From s In db.tblAssetTypes
                                Where s.AssetTypeDescription = Type
                                Select s.AssetTypeID).SingleOrDefault
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-36")
        End Try
    End Function



    Public Shared Function FetchLastProteryCode(ByVal ItemCodes As Integer) As Object
        Try
            'Dim consumable = (From s In db.tblmasterlistdetails
            '                  Where s.ItemCode = ItemCodes
            '                  Select s.CategoryID).SingleOrDefault

            'If consumable = 5004 Or consumable = 5005 Then

            '    Dim result = (From k In db.tblAssetInventories
            '                  Where k.AssetCode = ItemCodes
            '                  Select k.PropertyCode).SingleOrDefault

            '    If result IsNot Nothing Then

            '        Return result
            '    Else
            '        Dim querysection = (From s In db.tblmasterlistdetails
            '                            Join k In db.tblCategories On s.CategoryID Equals k.CategoryID
            '                            Join i In db.tblAssetTypes On s.AssetTypeID Equals i.AssetTypeID
            '                            Where s.ItemCode = ItemCodes
            '                            Let c = k.CategoryCode + "-" + i.AssetTypeCode + "-00001"
            '                            Select c).SingleOrDefault
            '        Return querysection

            '    End If

            'Else

            Dim result = db.spGetLastPropertyCode(ItemCodes).SingleOrDefault()
                If result IsNot Nothing Then

                    Dim propertyCode As String = result.PropertyCode
                    Dim parts As String() = propertyCode.Split("-"c)
                    Dim lastPart As String = parts(parts.Length - 1)
                    Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

                    ' Assuming you want the format "000001" for all values, you can use the following format.
                    Dim formattedNextNumber As String = nextNumber.ToString("D5")

                    ' Reconstruct the new entry ID by joining the parts with a dash (-).
                    Dim newEntryID As String = String.Join("-", parts.Take(parts.Length - 1).ToArray()) & "-" & formattedNextNumber

                    Return newEntryID

                Else

                    Dim querysection = (From s In db.tblmasterlistdetails
                                        Join k In db.tblCategories On s.CategoryID Equals k.CategoryID
                                        Join i In db.tblAssetTypes On s.AssetTypeID Equals i.AssetTypeID
                                        Where s.ItemCode = ItemCodes
                                        Let c = k.CategoryCode + "-" + i.AssetTypeCode + "00001"
                                        Select c).SingleOrDefault
                    Return querysection

                End If

            'End If

        Catch ex As Exception
            Return MsgBox("Error.F-37")
        End Try
    End Function

    'Check in Asset Inventory if the Item is cosumable
    Public Shared Function CheckIsConsumable(ByVal itemcodes As String) As Object
        Try

            Dim querysection = (From s In db.tblmasterlistdetails
                                Join i In db.tblCategories On s.CategoryID Equals i.CategoryID
                                Where s.ItemCode = itemcodes And (i.CategoryID = 5004 Or i.CategoryID = 5005)
                                Select s.ItemCode).FirstOrDefault()

            Return querysection


        Catch ex As Exception
            Return MsgBox("Error.F-38")
        End Try
    End Function

    'Get Consumable Property Code
    Public Shared Function FetchConsumablePropertyCode(ByVal itemcode As String) As Object
        Try
            Dim querysection = (From s In db.tblAssetInventories
                                Join k In db.tblmasterlistdetails On s.AssetCode Equals k.ItemCode
                                Join i In db.tblCategories On k.CategoryID Equals i.CategoryID
                                Where s.AssetCode = itemcode And i.CategoryID = 5004 And i.CategoryID = 5005
                                Select s.PropertyCode).SingleOrDefault


            If querysection Is Nothing Then

                Dim getpp = (From s In db.tblmasterlistdetails
                             Join k In db.tblCategories On s.CategoryID Equals k.CategoryID
                             Join i In db.tblAssetTypes On s.AssetTypeID Equals i.AssetTypeID
                             Where s.ItemCode = itemcode
                             Let c = k.CategoryCode + "-" + i.AssetTypeCode + "-00001"
                             Select c).SingleOrDefault
                Return getpp

            Else
                Return querysection

            End If




        Catch ex As Exception
            Return MsgBox("Error.F-38")
        End Try
    End Function

    'Check Request Status
    Public Shared Function FetchRequestStatus(ByVal reqno As String) As Object
        Try
            Dim querysection = (From s In db.tblRequestHeaders
                                Where s.RequestNo = reqno
                                Select s.Stat).SingleOrDefault
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-38")
        End Try
    End Function

    'Check Procure State
    Public Shared Function FetchRequestStatus(ByVal ID As Integer) As Object
        Try
            Dim querysection = (From s In db.tblProcureDetails
                                Where s.id = ID
                                Select s.State).SingleOrDefault
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-39")
        End Try
    End Function

    'Check PropertyCode
    Public Shared Function FetchPropertyCode(ByVal PropertyC As String) As Integer
        Try
            Dim querysection = (From s In db.tblAssetInventories
                                Where s.PropertyCode = PropertyC
                                Select s.PropertyCode).Count
            Return querysection
        Catch ex As Exception
            Return MsgBox("Error.F-40")
        End Try
    End Function

    'Check Item Category
    Public Shared Function FetchItemCategory(ByVal ItemCodes As Integer) As Integer
        Try

            Dim consumable = (From s In db.tblmasterlistdetails
                              Where s.ItemCode = ItemCodes
                              Select s.CategoryID).SingleOrDefault
            Return consumable

        Catch ex As Exception
            Return MsgBox("Error.F-41")
        End Try
    End Function


    'Check for Asset Qty For Consumable Assignment
    Public Shared Function FetchAssetQty(ByVal PC As String) As Object
        Try

            Dim consumable = (From s In db.tblAssetInventories
                              Where s.PropertyCode = PC
                              Select s.Qty).SingleOrDefault
            Return consumable

        Catch ex As Exception
            Return MsgBox("Error.F-41")
        End Try
    End Function



End Class

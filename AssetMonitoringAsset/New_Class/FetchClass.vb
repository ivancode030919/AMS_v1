Public Class FetchClass
    '--------------------------------------------------------------------------------------------
    'Fetch Last Item Code in New Asset Class
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Fetch HeaderID in BUild Assdet Header
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'display Last save Entry Number
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Fetch AssetList
    '--------------------------------------------------------------------------------------------
    Public Shared Sub ViewInventory()
        Try
            With InventoryList
                ''soure for viewing
                .dgv.DataSource = db.spViewInventory.ToList

                ''set column name
                .dgv.Columns(0).HeaderText = "Asset Code"
                .dgv.Columns(1).HeaderText = "Description"
                .dgv.Columns(2).HeaderText = "Quantity"

            End With
        Catch ex As Exception
            MsgBox("Error.F-6")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Fetch Last Entry Number then Plus 1 in series for new entry Number
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Fetch ID in New Asset Class
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Fetch Transheader id in New Asset Class
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchTransHeaderID() As Integer
        Try
            Dim querysection As Integer = (From s In db.tblmasterlisheaders
                                           Order By s.AssetHeaderID Descending
                                           Select s.AssetHeaderID).FirstOrDefault()
            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-9")
        End Try

    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Combox Category
    '--------------------------------------------------------------------------------------------
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
    '--------------------------------------------------------------------------------------------
    'Fetch Count in Asset Category Add and Update
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchCCount(ByVal code As String) As Integer
        Try
            Dim count As Integer = (From s In db.tblCategories
                                    Where (s.CategoryCode.Contains(code))
                                    Select s.CategoryCode).Count()
            Return count
        Catch ex As Exception
            MsgBox("Error.F-11")
        End Try

    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Allocation Ebtry NUmber
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Check Employee if existing
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEmployeeCount(ByVal fname As String, ByVal lname As String) As Integer
        Try
            Dim count As Integer = (From s In db.tblEmployees
                                    Where (s.FirstName.Contains(fname) And s.LastName.Contains(lname))
                                    Select s).Count()
            Return count
        Catch ex As Exception
            MsgBox("Error.F-13")
        End Try

    End Function

    '--------------------------------------------------------------------------------------------
    'Check list ui
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Check For Assets Without Ownser
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchAssetWithoutOwner(ByVal ItemCode As String) As Object
        Try
            Dim querysection = (From f In db.tblAssetInventories
                                Where f.AssetCode = ItemCode And f.Owner = 0
                                Select f.Qty).Sum.ToString
            Return querysection
        Catch ex As Exception

            MsgBox("Error.F-1")
        End Try

    End Function

    '--------------------------------------------------------------------------------------------
    'Check If Cosumable
    '--------------------------------------------------------------------------------------------
    Public Shared Function CheckifCosumable(ByVal ItemCodes As String) As Object
        Try
            Dim querysection = (From f In db.tblmasterlistdetails
                                Join g In db.tblCategories On f.CategoryID Equals g.CategoryID
                                Where g.CategoryCode <> "NCND" And g.CategoryCode <> "CR" And f.ItemCode = ItemCodes
                                Select f.ItemCode).FirstOrDefault
            Return querysection
        Catch ex As Exception
            MsgBox("Error.F-2")
        End Try

    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Last Assignment Entry Number
    '--------------------------------------------------------------------------------------------
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
    '--------------------------------------------------------------------------------------------
    'Fetch Requestor
    '--------------------------------------------------------------------------------------------
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
    '--------------------------------------------------------------------------------------------
    'Fetch transheader id in Request
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Fetch transheader id in For Approval
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchTransIdForApproval() As Object
        Try
            Dim querysection = (From s In db.tblProcureHeaders
                                Order By s.id Descending
                                Select s.id).FirstOrDefault()

            Return querysection

        Catch ex As Exception
            MsgBox("Error.F-17")
        End Try


    End Function
    '--------------------------------------------------------------------------------------------
    'Fetch transheader id in Assignment
    '--------------------------------------------------------------------------------------------
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

    '--------------------------------------------------------------------------------------------
    'Fetch Last Request Number
    '--------------------------------------------------------------------------------------------
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
End Class

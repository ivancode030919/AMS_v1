Public Class FetchClass
    '--------------------------------------------------------------------------------------------
    'Fetch Last Item Code in New Asset Class
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchLastItemcode() As String
        Dim querysection = (From s In db.tblmasterlistdetails
                            Order By Convert.ToInt32(s.ItemCode) Descending
                            Select s.ItemCode).FirstOrDefault
        Return querysection
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch HeaderID in BUild Assdet Header
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetcHeaderID() As String
        Dim querysection As String = (From s In db.tblBuildHeaders
                                      Order By s.id Descending
                                      Select s.id).FirstOrDefault()
        Return querysection
    End Function

    '--------------------------------------------------------------------------------------------
    'display Last save Entry Number
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEntryn1() As String
        Dim querysection As String = (From s In db.tblBuildHeaders
                                      Order By s.id Descending
                                      Where s.EntryNumber <> ""
                                      Select s.EntryNumber).FirstOrDefault()
        Return querysection
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
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Fetch Last Entry Number then Plus 1 in series for new entry Number
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEntryno() As String
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

    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch ID in New Asset Class
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEntryID() As String


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
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Transheader in New Asset Class
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchTransHeaderID() As Integer
        Dim querysection As Integer = (From s In db.tblmasterlisheaders
                                       Order By s.AssetHeaderID Descending
                                       Select s.AssetHeaderID).FirstOrDefault()
        Return querysection
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Combox Category
    '--------------------------------------------------------------------------------------------
    Public Shared Function ViewCboxCat() As List(Of String)

        Dim querysection = (From s In db.tblCategories
                            Order By s.CategoryID
                            Select s.CategoryDescription).ToList
        Return querysection
    End Function
    '--------------------------------------------------------------------------------------------
    'Fetch Count in Asset Category Add and Update
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchCCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblCategories
                                Where (s.CategoryCode.Contains(code))
                                Select s.CategoryCode).Count()
        Return count
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Allocation Ebtry NUmber
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchAllocationEntry() As String
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
    End Function

    '--------------------------------------------------------------------------------------------
    'Check Employee if existing
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEmployeeCount(ByVal fname As String, ByVal lname As String) As Integer
        Dim count As Integer = (From s In db.tblEmployees
                                Where (s.FirstName.Contains(fname) And s.LastName.Contains(lname))
                                Select s).Count()
        Return count
    End Function

End Class

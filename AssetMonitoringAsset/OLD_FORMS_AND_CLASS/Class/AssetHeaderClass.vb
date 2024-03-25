Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class AssetHeaderClass

    Public Shared Function GetAssetHeader() As System.Data.Linq.Table(Of tblAssetHeader)
        Return db.GetTable(Of tblAssetHeader)()
    End Function

    Public Shared Sub SaveAsset(ByVal entry As String, ByVal remarks As String, ByVal date1 As Date, ByVal Docno As String, ByVal DocId As Integer, ByVal vendorId As Integer, ByVal mod1 As Integer)
        Try

            Dim user As Integer = Home.UserID
            Dim post As Table(Of tblAssetHeader) = AssetHeaderClass.GetAssetHeader

            Dim p As New tblAssetHeader With
                {
                  .UserID = user,
                  .EntryNumber = entry,
                  .TransDate = date1,
                  .Remarks = remarks,
                  .VendorID = vendorId,
                  .Docno = Docno,
                  .DocTypeID = DocId,
                  .module1 = mod1
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function FetchEntryID() As String
        Dim querysection As String = (From s In db.tblAssetHeaders
                                      Order By s.AssetHeaderID Descending
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



    Public Shared Function FetchEntryID2() As String
        Dim querysection As String = (From s In db.tblAssetHeaders
                                      Order By s.AssetHeaderID Descending
                                      Where s.EntryNumber <> ""
                                      Select s.EntryNumber).FirstOrDefault()

        If IsNothing(querysection) Then
            Dim newEntryID As String = "RECV" + "-" + Home.Department + "-" + Home.Branch + "-" + Home.Section + "-" + "000001"
            Return newEntryID
        Else
            Dim parts As String() = querysection.Split("-"c)
            Dim lastPart As String = parts(parts.Length - 1)
            Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

            ' Assuming you want the format "000001" for all values, you can use the following format.
            Dim formattedNextNumber As String = nextNumber.ToString("D6")
            Dim newEntryID As String = $"{"RECV"}-{Home.Department}-{Home.Branch}-{Home.Section}-{formattedNextNumber}"

            Return newEntryID
        End If
    End Function



    Public Shared Function FetchAssetMasterData(ByVal Search As String) As Object
        'Dim querysection = (From s In db.tblAssetDetailMasterlists
        '                    Join p In db.tblCategories On s.CategoryID Equals p.CategoryID
        '                    Join t In db.tblAssetTypes On s.AssetTypeID Equals t.AssetTypeID
        '                    Join h In db.tblAssetConditions On s.AssetConditionID Equals h.AssetConditionID
        '                    Where s.AssetCode.Contains(Search) Or s.AssetDescription.Contains(Search)
        '                    Select s.AssetCode, s.AssetDescription, p.CategoryDescription, t.AssetTypeDescription, h.AssetConditionDescription, s.CategoryID, s.AssetTypeID, s.AssetConditionID, s.AssetID).ToList
        'Return querysection
    End Function


    Public Shared Function FetchTransHeaderID() As Integer
        Dim querysection As Integer = (From s In db.tblAssetHeaders
                                       Order By s.AssetHeaderID Descending
                                       Select s.AssetHeaderID).FirstOrDefault()

        Return querysection
    End Function

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





    'Public Shared Function FetchDataFetchAllocation(ByVal Search As String, ByVal date1 As Date, ByVal date2 As Date) As Object
    '    Dim querysection = (From s In db.tblAllocationHeaders
    '                        Join j In db.tblUsers On s.UserID Equals j.UserID
    '                        Join h In db.tblEmployees On j.EmployeeID Equals h.EmployeeID
    '                        Where (s.EntryNumber.Contains(Search)) And (s.Date >= date1 AndAlso s.Date <= date2)
    '                        Let name = h.FirstName + " " + h.LastName
    '                        Select s.Date, s.EntryNumber, name, s.Allocationheaderid).ToList()
    '    Return querysection
    'End Function

End Class

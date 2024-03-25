Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class MasterdataHeaderClass

    Public Shared Function FetchDatatoDGV(ByVal entryno As String, ByVal date1 As Date, ByVal date2 As Date) As Object
        Dim querysection = (From s In db.tblmasterlisheaders
                            Join u In db.tblUsers On s.UserID Equals u.UserID
                            Join j In db.tblEmployees On u.EmployeeID Equals j.EmployeeID
                            Where (s.EntryNumber = entryno Or entryno = "") And (s.TransDate >= date1 AndAlso s.TransDate <= date2)
                            Order By s.AssetHeaderID Ascending
                            Let fl = j.FirstName + " " + j.LastName
                            Select New With {s.TransDate, s.EntryNumber, s.Remarks, fl}).ToList()
        Return querysection
    End Function

    Public Shared Function Fetchregister(ByVal entryno As String) As Object
        'Dim querysection = (From s In db.tblAssetHeaderMasterlists
        '                    Join f In db.tblAssetDetailMasterlists On s.AssetHeaderID Equals f.AssetHeaderID
        '                    Join c In db.tblCategories On f.CategoryID Equals c.CategoryID
        '                    Join k In db.tblAssetTypes On f.AssetTypeID Equals k.AssetTypeID
        '                    Join e In db.tblAssetConditions On f.AssetConditionID Equals e.AssetConditionID
        '                    Where s.EntryNumber.Contains(entryno)
        '                    Select f.AssetCode, f.AssetDescription, c.CategoryDescription, k.AssetTypeDescription, e.AssetConditionDescription).ToList()
        'Return querysection
    End Function

End Class

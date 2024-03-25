Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class AssetDetailClass
    Public Shared Function GetAssetDetail() As System.Data.Linq.Table(Of tblAssetDetail)
        Return db.GetTable(Of tblAssetDetail)()
    End Function


    Public Shared Sub SaveAssetDetail(ByVal assetID As Integer, ByVal assetCode As String, ByVal ref As String, ByVal refno As String, ByVal qty As Double, ByVal Transheader As Integer, ByVal vendor As Integer, ByVal mod1 As Integer)
        'Try
        Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            Dim post As Table(Of tblAssetDetail) = AssetDetailClass.GetAssetDetail

            Dim p As New tblAssetDetail With
                {
                  .assetID = assetID,
                  .AssetCode = assetCode,
                  .Reference = ref,
                  .Refno = refno,
                  .Quantity = qty,
                  .DateCreated = currentdate,
                  .UserID = user,
                  .TransHeaderID = Transheader,
                  .VendorID = vendor,
                  .module1 = mod1
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            'After Insert Load View
        'Catch ex As Exception
        '    MsgBox("Invalid Data...")
        'End Try
    End Sub




End Class

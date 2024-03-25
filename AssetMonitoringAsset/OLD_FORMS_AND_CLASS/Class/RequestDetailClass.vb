
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class RequestDetailClass
    Public Shared Function GetAquisitionRequest() As System.Data.Linq.Table(Of tblRequestDetail)
        Return db.GetTable(Of tblRequestDetail)()
    End Function

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
            Dim post As Table(Of tblRequestDetail) = RequestDetailClass.GetAquisitionRequest
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
    'Save Borrow Procurement
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
            Dim post As Table(Of tblRequestDetail) = RequestDetailClass.GetAquisitionRequest
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
    'Save Transfer Procurement
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
            Dim post As Table(Of tblRequestDetail) = RequestDetailClass.GetAquisitionRequest
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


    '------------------------------------------------------------------------------------
    'Display in Detail In Approval
    '------------------------------------------------------------------------------------

    Public Shared Function FetchAprrovalDetail(ByVal HeaderID As Integer, ByVal RequestType As String) As Object

        If RequestType = "Procure" Then
            Dim query1 = (From s In db.tblRequestDetails
                          Where s.HeaderID = HeaderID
                          Select s.AssetCode, s.Class, s.Owner, s.Qty, s.Remarks).ToList
            Return query1
        End If

    End Function
    '------------------------------------------------------------------------------------
    'Display in Detail In Request Register
    '------------------------------------------------------------------------------------
    Public Shared Function FetchRegisterDetail(ByVal HeaderID As Integer, ByVal RequestType As String) As Object

        If RequestType = "Procure" Then

            Dim query1 = (From s In db.tblRequestDetails
                          Where s.HeaderID = HeaderID And s.Status = "OPEN" And (s.State = "OPEN" Or s.State = "PARTIAL")
                          Select s.AssetCode, s.Class, s.Owner, s.Qty, s.Remarks).ToList
            Return query1

        ElseIf RequestType = "Borrow" Then

        ElseIf RequestType = "Transfer Ownership" Then

        End If

    End Function
End Class

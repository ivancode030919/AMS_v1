Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class TransferHeaderClass
    Public Shared Function GetTransferHeader() As System.Data.Linq.Table(Of tblTransferHeader)
        Return db.GetTable(Of tblTransferHeader)()
    End Function


    Public Shared Sub SaveTransfer(ByVal RequestType As String, ByVal requestby As Integer, ByVal requestFor As Integer, ByVal Date1 As Date, ByVal Status As String)
        Try
            Dim post As Table(Of tblTransferHeader) = TransferHeaderClass.GetTransferHeader
            Dim p As New tblTransferHeader With
                {
               .RequaestType = RequestType,
               .RequestBy = requestby,
               .RequestFor = requestFor,
               .[Date] = Date1,
               .Status = Status
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
End Class

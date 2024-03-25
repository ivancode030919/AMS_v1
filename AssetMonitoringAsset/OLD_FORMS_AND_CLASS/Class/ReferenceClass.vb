Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class ReferenceClass

    Public Shared Function GetRef() As System.Data.Linq.Table(Of tblReference)
        Return db.GetTable(Of tblReference)()
    End Function

    Public Shared Sub SaveReference(ByVal Des As String)
        Try

            Dim post As Table(Of tblReference) = ReferenceClass.GetRef
            Dim p As New tblReference With
                {
                   .Reference = StrConv(Des, VbStrConv.ProperCase)
                }

            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            MessageBox.Show("Reference Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            With Reference
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .TextBox3.Text = String.Empty
                .display()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub



    Public Shared Function ViewRef(ByVal search As String) As Object

        Dim querysection = (From s In db.tblReferences
                            Where ((s.Reference.Contains(search)) Or search = "")
                            Order By s.Refid Ascending
                            Select s.Refid, s.Reference).ToList
        Return querysection
    End Function

    Public Shared Sub UpdateReference(ByVal Stat As String, ByVal UID As Integer)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblReference)()
                              Where p.Refid = UID
                              Select p).SingleOrDefault()
            updateStat.Reference = StrConv(Stat, VbStrConv.ProperCase)
            db.SubmitChanges()
            MessageBox.Show("Reference Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With Reference
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .TextBox3.Text = String.Empty
                .display()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
End Class

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class BranchClass
    Public Shared Function GetAssetBranch() As System.Data.Linq.Table(Of tblBranch)
        Return db.GetTable(Of tblBranch)()
    End Function

    Public Shared Sub SaveBranch(ByVal Code As String, ByVal Des As String)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spNewBranch(Code.ToUpper, StrConv(Des, VbStrConv.ProperCase), currentdate, currentdate, user, user)
            MessageBox.Show("Branch Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetBranch.ViewBranch()

            With AssetBranchAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewBranch(ByVal Search As String)
        Try

            With AssetBranch

                'soure for viewing
                .dgview.DataSource = db.spViewBranch(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Branch Code"
                .dgview.Columns(2).HeaderText = "Description"
                .dgview.Columns(3).HeaderText = "Date Modified"

                'set column Width
                '.dgview.Columns(1).Width = 100
                '.dgview.Columns(3).Width = 125

                'datagrid text alignment
                .dgview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try


    End Sub

    Public Shared Sub UpdateBranch(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateBranch(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Branch Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View


            With AssetBranch
                .ViewBranch()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetBranchAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function ViewCboxBranch() As List(Of String)

        Dim querysection = (From s In db.tblBranches
                            Order By s.BranchID
                            Select s.BranchDescription).ToList
        Return querysection
    End Function


    Public Shared Function FetchBranchID(ByVal Des As String) As Object
        Dim querysection = (From s In db.tblBranches
                            Where s.BranchDescription.Contains(Des)
                            Select s.BranchID).FirstOrDefault

        Return querysection
    End Function


    Public Shared Function FetchBCCount(ByVal Bcode As String) As Integer
        Dim count As Integer = (From s In db.tblBranches
                                Where (s.BranchCode.Contains(Bcode))
                                Select s.BranchCode).Count()
        Return count
    End Function
End Class

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class VendorClass

    Public Shared Function GetVendor() As System.Data.Linq.Table(Of tblVendor)
        Return db.GetTable(Of tblVendor)()
    End Function

    Public Shared Sub SaveVendor(ByVal Code As String, ByVal Des As String)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()

            Dim post As Table(Of tblVendor) = VendorClass.GetVendor
            Dim p As New tblVendor With
                {
                    .VendorCode = Code.ToUpper,
                    .VendorDescription = StrConv(Des, VbStrConv.ProperCase),
                    .DateCreated = currentdate,
                    .DateModified = currentdate,
                    .UserID = user,
                    .UserIDModified = user
                }

            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            MessageBox.Show("Vendor Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            Vendor.ViewVendor()

            With VendorAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewVendor(ByVal Search As String)
        Try

            With Vendor

                'soure for viewing
                .dgview.DataSource = db.spViewVendor(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Document Type Code"
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

    Public Shared Sub UpdateVendor(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateVendor(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Vendor Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetBranch.ViewBranch()

            With Vendor
                .ViewVendor()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With VendorAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub



    Public Shared Function ViewCboxVen() As List(Of String)

        Dim querysection = (From s In db.tblVendors
                            Order By s.VendorID
                            Select s.VendorDescription).ToList
        Return querysection
    End Function


    Public Shared Function FetchVEndorID(ByVal Des As String) As Integer
        Dim querysection = (From s In db.tblVendors
                            Where s.VendorDescription.Contains(Des)
                            Select s.VendorID).Single
        Return querysection
    End Function

    Public Shared Function FetchVenCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblVendors
                                Where (s.VendorCode.Contains(code))
                                Select s.VendorCode).Count()
        Return count
    End Function

End Class

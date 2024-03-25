Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class TypeClass

    Public Shared Function GetAssetType() As System.Data.Linq.Table(Of tblAssetType)
        Return db.GetTable(Of tblAssetType)()
    End Function

    Public Shared Sub SaveAssetType(ByVal ATC As String, ByVal ATD As String)
        'Try
        'temporary value sa user
        Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spNewType(ATC.ToUpper, StrConv(ATD, VbStrConv.ProperCase), currentdate, currentdate, user, user)
        MessageBox.Show("Asset Type Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'After Insert Load View
        AssetType.ViewType()

            With AssetTypeAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        'Catch ex As Exception
        '    MsgBox("Invalid Data...")
        'End Try
    End Sub

    Public Shared Sub ViewAssetType(ByVal Search As String)
        Try

            With AssetType
                'soure for viewing
                .dgview.DataSource = db.spViewType(Search).ToList

                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Type Code"
                .dgview.Columns(2).HeaderText = "Description"
                .dgview.Columns(3).HeaderText = "Date Modified"

                'set column Width
                '.dgview.Columns(1).Width = 100
                '.dgview.Columns(2).Width = 100
                '.dgview.Columns(3).Width = 125

                'datagrid text alignment
                .dgview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data... here")
        End Try


    End Sub

    Public Shared Sub UpdateAssetType(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try
            'temporary value sa user
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateType(typeid, ATC.ToUpper, StrConv(ATD, VbStrConv.ProperCase), currentdate, user)
            MessageBox.Show("Asset Type Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            With AssetType
                .ViewType()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetTypeAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function ViewCboxtype() As List(Of String)

        Dim querysection = (From s In db.tblAssetTypes
                            Order By s.AssetTypeID
                            Select s.AssetTypeDescription).ToList
        Return querysection
    End Function

    Public Shared Function FetchTCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblAssetTypes
                                Where (s.AssetTypeCode.Contains(code))
                                Select s.AssetTypeCode).Count()
        Return count
    End Function

End Class

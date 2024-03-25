Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class CategoryClass

    Public Shared Sub ViewCategory(ByVal Search As String)
        Try

            With AssetCategory

                'soure for viewing
                .dgview.DataSource = db.spViewCategory(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Category Code"
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

    Public Shared Function FetchCCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblCategories
                                Where (s.CategoryCode.Contains(code))
                                Select s.CategoryCode).Count()
        Return count
    End Function

End Class

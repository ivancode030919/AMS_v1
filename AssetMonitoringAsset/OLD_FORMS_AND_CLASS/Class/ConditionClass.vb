Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class ConditionClass

    Public Shared Function GetAssetCondition() As System.Data.Linq.Table(Of tblAssetCondition)
        Return db.GetTable(Of tblAssetCondition)()
    End Function

    Public Shared Sub SaveCondition(ByVal ATC As String, ByVal ATD As String)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spNewCondition(ATC.ToUpper, StrConv(ATD, VbStrConv.ProperCase), currentdate, currentdate, user, user)
            MessageBox.Show("Asset Condition Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetCondition.ViewCondition()

            With AssetConditionAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewCondition(ByVal Search As String)
        Try
            With AssetCondition
                'soure for viewing
                .dgview.DataSource = db.spViewCondition(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Condition Code"
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

    Public Shared Sub UpdateCondition(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try
            '
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateCondition(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Asset Condition Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            With AssetCondition
                .ViewCondition()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetConditionAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function ViewNaCondition(ByVal search As String) As Object

        Dim querysection = (From s In db.tblAssetConditions
                            Where ((s.AssetConditionCode.Contains(search) Or s.AssetConditionDescription.Contains(search)) Or search = "")
                            Order By s.AssetConditionID
                            Select s.AssetConditionID, s.AssetConditionCode, s.AssetConditionDescription).ToList
        Return querysection
    End Function


    Public Shared Function ViewCboxCon() As List(Of String)

        Dim querysection = (From s In db.tblAssetConditions
                            Order By s.AssetConditionID
                            Select s.AssetConditionDescription).ToList
        Return querysection
    End Function

    Public Shared Function FetchConCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblAssetConditions
                                Where (s.AssetConditionCode.Contains(code))
                                Select s.AssetConditionCode).Count()
        Return count
    End Function

End Class

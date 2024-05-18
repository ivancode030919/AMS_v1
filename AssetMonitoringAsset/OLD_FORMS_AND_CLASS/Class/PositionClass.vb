Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class PositionClass
    Public Shared Function GetAssetPosition() As System.Data.Linq.Table(Of tblPosition)
        Return db.GetTable(Of tblPosition)()
    End Function

    Public Shared Sub SavePosition(ByVal Code As String, ByVal Des As String)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()

            Dim post As Table(Of tblPosition) = PositionClass.GetAssetPosition
            Dim p As New tblPosition With
                {
                    .PositionCode = Code.ToUpper,
                    .PositionDescription = StrConv(Des, VbStrConv.ProperCase),
                    .DateCreated = currentdate,
                    .DateModified = currentdate,
                    .UserID = user,
                    .UserIDModified = user
                }

            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            MessageBox.Show("Position Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetPosition.ViewPosition()

            With AssetPositionAddandUpdate
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

            With AssetPosition

                'soure for viewing
                .dgview.DataSource = db.spViewPosition(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Position Code"
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

    Public Shared Sub UpdatePosition(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdatePosition(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Position Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetBranch.ViewBranch()

            With AssetPosition
                .ViewPosition()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetPositionAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function ViewCboxPosition() As List(Of String)

        Dim querysection = (From s In db.tblPositions
                            Order By s.PositionID
                            Select s.PositionDescription).ToList
        Return querysection
    End Function

    Public Shared Function ViewCboxManager() As Object
        Dim querysection = (From s In db.tblEmployees
                            Order By s.EmployeeID
                            Where s.PositionID = 1 Or s.PositionID = 2
                            Let x = s.EmployeeID.ToString + "-" + s.FirstName + " " + s.LastName
                            Select x).ToList()
        Return querysection


    End Function

    Public Shared Function FetchPositionID(ByVal Des As String) As Object
        Dim querysection = (From s In db.tblPositions
                            Where s.PositionDescription.Contains(Des)
                            Select s.PositionID).FirstOrDefault

        Return querysection
    End Function

    Public Shared Function FetPosCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblPositions
                                Where (s.PositionCode.Contains(code))
                                Select s.PositionCode).Count()
        Return count
    End Function


End Class

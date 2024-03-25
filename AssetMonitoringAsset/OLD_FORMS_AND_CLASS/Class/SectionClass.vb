Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class SectionClass

    Public Shared Function GetAssetSection() As System.Data.Linq.Table(Of tblSection)
        Return db.GetTable(Of tblSection)()
    End Function

    Public Shared Sub SaveSection(ByVal code As String, ByVal des As String)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            ''Insert Asset in DB
            db.spNewSection(code.ToUpper, StrConv(des, VbStrConv.ProperCase), currentdate, currentdate, user, user)
            MessageBox.Show("Section Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''After Insert Load View
            AssetSection.ViewSection()

            With AssetSectionAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewSection(ByVal Search As String)
        Try
            With AssetSection
                ''soure for viewing
                .dgview.DataSource = db.spViewSection(Search).ToList
                ''hide column 0
                .dgview.Columns(0).Visible = False

                ''set column name
                .dgview.Columns(1).HeaderText = "Asset Section Code"
                .dgview.Columns(2).HeaderText = "Description"
                .dgview.Columns(3).HeaderText = "Date Modified"

                ''set column Width
                ''.dgview.Columns(1).Width = 100
                ''.dgview.Columns(3).Width = 125

                ''datagrid text alignment
                .dgview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try


    End Sub

    Public Shared Sub UpdateSection(ByVal typeid As Integer, ByVal Code As String, ByVal Des As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            ''Insert Asset in DB
            db.spUpdateSection(typeid, StrConv(Des, VbStrConv.ProperCase), currentdate, user, Code.ToUpper)
            MessageBox.Show("Section Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''After Insert Load View


            With AssetSection
                .ViewSection()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetSectionAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function ViewCboxSection() As List(Of String)

        Dim querysection = (From s In db.tblSections
                            Order By s.SectionID
                            Select s.SectionDecription).ToList
        Return querysection
    End Function

    Public Shared Function FetchSectionID(ByVal Des As String) As Object
        Dim querysection = (From s In db.tblSections
                            Where s.SectionDecription.Contains(Des)
                            Select s.SectionID).FirstOrDefault

        Return querysection
    End Function

    Public Shared Function FetchSecCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblSections
                                Where (s.SectionCode.Contains(code))
                                Select s.SectionCode).Count()
        Return count
    End Function
End Class

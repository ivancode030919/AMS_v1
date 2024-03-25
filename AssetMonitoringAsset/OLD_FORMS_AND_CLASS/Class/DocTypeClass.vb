Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class DocTypeClass

    Public Shared Function GetDocType() As System.Data.Linq.Table(Of tblDocumentType)
        Return db.GetTable(Of tblDocumentType)()
    End Function

    Public Shared Sub SaveDocType(ByVal Code As String, ByVal Des As String)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()

            Dim post As Table(Of tblDocumentType) = DocTypeClass.GetDocType
            Dim p As New tblDocumentType With
                {
                    .DocumentCode = Code.ToUpper,
                    .DocumentDescription = StrConv(Des, VbStrConv.ProperCase),
                    .DateCreated = currentdate,
                    .DateModified = currentdate,
                    .UserID = user,
                    .UserIDModified = user
                }

            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            MessageBox.Show("Document Type Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetDocumentType.ViewDocType()

            With AssetDocTypeAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewDocType(ByVal Search As String)
        Try

            With AssetDocumentType

                'soure for viewing
                .dgview.DataSource = db.spViewDocumentType(Search).ToList
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

    Public Shared Sub UpdateDocType(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateDocType(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Document Type Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetBranch.ViewBranch()

            With AssetDocumentType
                .ViewDocType()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetDocTypeAddandUpdate
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function ViewCboxDoc() As List(Of String)

        Dim querysection = (From s In db.tblDocumentTypes
                            Order By s.DocumentID
                            Select s.DocumentDescription).ToList
        Return querysection
    End Function


    Public Shared Function FetchDocTypeID(ByVal Des As String) As Integer
        Dim querysection = (From s In db.tblDocumentTypes
                            Where s.DocumentDescription.Contains(Des)
                            Select s.DocumentID).Single
        Return querysection
    End Function

    Public Shared Function FetchDTCount(ByVal code As String) As Integer
        Dim count As Integer = (From s In db.tblDocumentTypes
                                Where (s.DocumentCode.Contains(code))
                                Select s.DocumentCode).Count()
        Return count
    End Function

End Class

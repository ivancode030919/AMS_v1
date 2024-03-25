Public Class AssetList3
    Public rowToEdit As Integer
    Public modty As Integer
    Public mode1 As Integer
    Public ac As Integer
    Private Sub AssetList3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()
        If mode1 = 1 Then
            Try
                dgv.DataSource = ViewClass.Fetchrlist1(TextBox1.Text)

                dgv.Columns(0).HeaderText = "Asset Code"
                dgv.Columns(1).HeaderText = "Description"

                dgv.Columns(2).Visible = False
                dgv.Columns(3).Visible = False
                dgv.Columns(4).Visible = False

                'dgv.Columns(0).Width = 200
                'dgv.Columns(1).Width = 500
            Catch ex As Exception

            End Try
        ElseIf mode1 = 2 Then
            dgv.DataSource = ViewClass.ViewInventoryDetails1

            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Department"
                .Columns(4).HeaderText = "Branch"
                .Columns(5).HeaderText = "Section"
                .Columns(6).HeaderText = "Keeper"
                .Columns(7).HeaderText = "Owner"
            End With
        ElseIf mode1 = 3 Then
            dgv.DataSource = ViewClass.ViewAvailableAssets(ac)

            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Keeper"
                .Columns(4).HeaderText = "Department"
                .Columns(5).HeaderText = "Branch"
                .Columns(6).HeaderText = "Section"
            End With

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = dgv.Rows(index)

        If modty = 1 Then

            With BuildAsset.dgview
                .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(14).Value = selectedrow.Cells(3).Value.ToString
                .Rows(rowToEdit).Cells(15).Value = selectedrow.Cells(4).Value.ToString
                .Rows(rowToEdit).Cells(17).Value = "0"
                .Rows(rowToEdit).Cells(18).Value = "0"
            End With


        ElseIf modty = 2 Then

            With Request.dgv
                .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(6).Value = selectedrow.Cells(3).Value.ToString
                .AllowUserToAddRows = True
            End With
            Request.checkqtybycat()

        ElseIf modty = 3 Then

            With Request.dgv
                .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(2).Value.ToString
                .AllowUserToAddRows = True
            End With
            Request.checkqtybycat()

        ElseIf modty = 4 Then
            With Assignment1.dgv
                .Rows(rowToEdit).Cells(9).Value = selectedrow.Cells(0).Value.ToString
            End With


        ElseIf modty = 5 Then
            With Assignment1.dgv
                .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(1).Value.ToString
            End With

        End If

        Me.Close()
    End Sub
End Class
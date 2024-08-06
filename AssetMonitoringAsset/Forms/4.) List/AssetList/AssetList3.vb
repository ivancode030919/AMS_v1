﻿Public Class AssetList3
    Public rowToEdit As Integer
    Public modty As Integer = 0
    Public mode1 As Integer = 0
    Public ac As Integer
    Public AssignQty As Double
    Public NewOwner As Integer
    Public ItemClass As String
    Public ReqId As Integer
    Public fromrq As Boolean = True
    Private Sub AssetList3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()

        If mode1 = 1 Then

            'Procure
            dgv.DataSource = ViewClass.Fetchrlist1(TextBox1.Text)

            dgv.Columns(0).HeaderText = "Asset Code"
            dgv.Columns(1).HeaderText = "Description"

            dgv.Columns(2).Visible = False
            dgv.Columns(3).Visible = False
            dgv.Columns(4).Visible = False

        ElseIf mode1 = 2 Then

            'Borrow
            dgv.DataSource = ViewClass.ViewInventoryDetails1(TextBox1.Text)
            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Department"
                .Columns(4).HeaderText = "Branch"
                .Columns(5).HeaderText = "Section"
                .Columns(6).HeaderText = "Keeper"
                .Columns(7).HeaderText = "Owner"


                .Columns(2).Visible = False
                .Columns(7).Visible = False

            End With

        ElseIf mode1 = 3 Then

            '
            dgv.DataSource = ViewClass.ViewAvailableAssets(ac)
            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Keeper"
                .Columns(4).HeaderText = "Department"
                .Columns(5).HeaderText = "Branch"
                .Columns(6).HeaderText = "Section"
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
            End With

        ElseIf mode1 = 4 Then

            'Borrow
            dgv.DataSource = ViewClass.ViewInventoryDetails4(TextBox1.Text)
            With dgv
                .Columns(0).HeaderText = "Property Code"
                .Columns(1).HeaderText = "Description"
                .Columns(2).HeaderText = "Quantity"
                .Columns(3).HeaderText = "Department"
                .Columns(4).HeaderText = "Branch"
                .Columns(5).HeaderText = "Section"
                .Columns(6).HeaderText = "Keeper"
                .Columns(7).HeaderText = "Owner"


                .Columns(2).Visible = False
                .Columns(7).Visible = False

            End With

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex
        If modty = 1 Then

            With BuildAsset.dgview
                .Rows(rowToEdit).Cells(0).Value = dgv.Rows(row).Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = dgv.Rows(row).Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(14).Value = dgv.Rows(row).Cells(3).Value.ToString
                .Rows(rowToEdit).Cells(15).Value = dgv.Rows(row).Cells(4).Value.ToString
                .Rows(rowToEdit).Cells(17).Value = "0"
                .Rows(rowToEdit).Cells(18).Value = "0"
            End With
            Me.Dispose()

        ElseIf modty = 2 Then

            With Request.dgv
                .Rows(rowToEdit).Cells(0).Value = dgv.Rows(row).Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = dgv.Rows(row).Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(6).Value = dgv.Rows(row).Cells(3).Value.ToString
                .AllowUserToAddRows = True
            End With
            Request.Checkqtybycat()
            Me.Dispose()

        ElseIf modty = 3 Then

            Dim BorrowStat As String = dgv.Rows(row).Cells(8).Value.ToString

            If BorrowStat = "Not Allowed" Then
                MessageBox.Show("This Item is not Allowed to be Borrowed, Please Conatct the Assigned Owner", "Validation")
            Else
                With Request.dgv
                    .Rows(rowToEdit).Cells(0).Value = dgv.Rows(row).Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(1).Value = dgv.Rows(row).Cells(1).Value.ToString
                    .Rows(rowToEdit).Cells(2).Value = dgv.Rows(row).Cells(2).Value.ToString
                    .AllowUserToAddRows = True
                End With
                Request.Checkqtybycat()
            End If

            Me.Dispose()

        ElseIf modty = 4 Then

            Dim CatID As Integer = FetchClass.FetchItemCategory(ac)
            Dim Propertycode As String

            If CatID = 5002 Or CatID = 5003 Then

                Dim msg As DialogResult = MessageBox.Show("Please confirm if this is the correct asset.", "Confirmation", MessageBoxButtons.YesNo)

                If msg = DialogResult.Yes Then

                    Propertycode = dgv.Rows(row).Cells(0).Value.ToString()
                    UpdateClass.UpdateAssignProperty(Propertycode, NewOwner)
                    With Assignment1.dgv
                        .Rows(rowToEdit).Cells(9).Value = Propertycode
                    End With
                    Me.Dispose()
                Else

                End If

            Else

                Dim msg As DialogResult = MessageBox.Show("Does all quantity need to be assigned ?", "Confirmation", MessageBoxButtons.YesNo)

                If msg = DialogResult.Yes Then

                    Propertycode = dgv.Rows(row).Cells(0).Value.ToString()


                    If fromrq = False Then
                        UpdateClass.UpdateReqstQuantity(ReqId, AssignQty, Propertycode)
                    Else

                    End If

                    UpdateClass.UpdateAssignProperty(Propertycode, NewOwner)

                    With Assignment1.dgv
                        .Rows(rowToEdit).Cells(9).Value = Propertycode
                    End With
                    Me.Dispose()

                Else

                    With ConsumableQty

                        .PropertyCode = dgv.Rows(row).Cells(0).Value.ToString
                        .ItemDescription = dgv.Rows(row).Cells(1).Value.ToString
                        .Reference = dgv.Rows(row).Cells(7).Value.ToString
                        .referenceno = dgv.Rows(row).Cells(8).Value.ToString
                        .InvId = Integer.Parse(dgv.Rows(row).Cells(9).Value.ToString)
                        .ReqId = ReqId
                        .IsFromReq = fromrq
                        .ItemClass = ItemClass
                        .AQty = AssignQty
                        .rowToEdit = rowToEdit
                        .NewOwner = NewOwner
                        .ItemCode = ac
                        .ShowDialog()

                    End With

                End If

            End If

        ElseIf modty = 5 Then

            With Assignment1.dgv
                .Rows(rowToEdit).Cells(1).Value = dgv.Rows(row).Cells(0).Value
                .Rows(rowToEdit).Cells(2).Value = dgv.Rows(row).Cells(1).Value
            End With
            Me.Dispose()

        ElseIf modty = 6 Then


            With Request.dgv
                .Rows(rowToEdit).Cells(0).Value = dgv.Rows(row).Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = dgv.Rows(row).Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(2).Value = dgv.Rows(row).Cells(2).Value.ToString
                .AllowUserToAddRows = True
            End With
            Request.Checkqtybycat()


            Me.Dispose()

        End If


    End Sub

    Private Sub AssetList3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        modty = 0
        mode1 = 0
        Me.Dispose()
    End Sub
End Class
﻿Public Class AssetCategory
    Public CatID As Integer

    Private Sub AssetCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewCategory()
    End Sub

    Public Sub ViewCategory()
        CategoryClass.ViewCategory(TextBox3.Text)
    End Sub

    Private Sub Dgview_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)
            TextBox1.Text = selectedrow.Cells(1).Value.ToString
            TextBox2.Text = selectedrow.Cells(2).Value.ToString
            CatID = CInt(selectedrow.Cells(0).Value)
            SimpleButton1.Text = "Update Category"

            With AssetCategoryAddandUpdate1
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = selectedrow.Cells(2).Value.ToString
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Text = "Add"
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If SimpleButton1.Text = "Add" Then


            AssetCategoryAddandUpdate1.TextBox1.Text = String.Empty
            AssetCategoryAddandUpdate1.TextBox2.Text = String.Empty
            AssetCategoryAddandUpdate1.SimpleButton2.Text = "Record"
            AssetCategoryAddandUpdate1.ShowDialog()

        ElseIf SimpleButton1.Text = "Update Category" Then

            AssetCategoryAddandUpdate1.Text = "Update"
            AssetCategoryAddandUpdate1.SimpleButton2.Text = "Save"
            AssetCategoryAddandUpdate1.ShowDialog()

        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ViewCategory()
    End Sub

    Private Sub AssetCategory_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        SimpleButton1.Text = "Add"
    End Sub

    Private Sub AssetCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub
End Class
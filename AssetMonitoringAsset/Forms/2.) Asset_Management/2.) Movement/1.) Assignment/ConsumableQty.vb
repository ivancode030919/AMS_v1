Public Class ConsumableQty
    Public rowToEdit, ItemCode, NewOwner As Integer
    Public QtyToDeduct, QtyResult, QtyInDb, AQty As Double
    Public ItemClass, referenceno, ItemDescription, Reference, PropertyCode As String


    Private Sub QtyCalication()

        QtyInDb = FetchClass.FetchAssetQty(PropertyCode)
        QtyToDeduct = Qtytxt.Text

        If QtyInDb < QtyToDeduct Then
            MessageBox.Show("This item cannot be deducted greater than: " & QtyInDb, "Validation", MessageBoxButtons.OK)
            Qtytxt.Text = 0
        Else
            QtyResult = QtyInDb - Double.Parse(QtyToDeduct)

        End If

    End Sub

    Private Sub Qtytxt_TextChanged(sender As Object, e As EventArgs) Handles Qtytxt.TextChanged

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        If Qtytxt.Text = "" Then
            MessageBox.Show("Quantity must be greater than 0", "Validation", MessageBoxButtons.OK)
        ElseIf ComboBox1.Text = "" Then
            MessageBox.Show("Asset condition is invalid...,", "Validation", MessageBoxButtons.OK)
        Else
            QtyCalication()

            If QtyInDb < QtyToDeduct Then
                Qtytxt.Text = 0

            ElseIf Qtytxt.Text = 0 Then
                MessageBox.Show("Quantity must be greater than 0", "Validation", MessageBoxButtons.OK)
            Else
                Dim NewPropertyCode As String = FetchClass.FetchLastProteryCode(ItemCode)
                UpdateClass.UpdateAssetQty(PropertyCode, QtyResult)
                InsertionClass.SaveAssetInventory(ItemCode, ItemClass, NewPropertyCode, ItemDescription, Double.Parse(Qtytxt.Text), NewOwner, NewOwner, 0, Reference, referenceno, "Not Allowed", 0, 0, ComboBox1.Text)

                With Assignment1.dgv
                    .Rows(rowToEdit).Cells(4).Value = Qtytxt.Text
                    .Rows(rowToEdit).Cells(9).Value = NewPropertyCode
                End With
                MessageBox.Show("Successfully Assigned...", "Confrimation", MessageBoxButtons.OK)
                Me.Dispose()
            End If

        End If

    End Sub

    Private Sub ConsumableQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Qtytxt.Text = AQty
        QtyCalication()
    End Sub

End Class
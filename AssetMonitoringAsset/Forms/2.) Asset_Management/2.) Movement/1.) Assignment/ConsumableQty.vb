Public Class ConsumableQty
    Public rowToEdit, ItemCode, NewOwner, InvId, ReqId As Integer
    Public QtyToDeduct, QtyResult, QtyInDb, AQty As Double
    Public ItemClass, referenceno, ItemDescription, Reference, PropertyCode As String
    Public IsFromReq As Boolean = False

    Private Sub QtyCalication()



        QtyInDb = FetchClass.FetchAssetQty(InvId)

        QtyToDeduct = Qtytxt.Text

        If QtyInDb < QtyToDeduct Then
            MessageBox.Show("This item cannot be deducted greater than: " & QtyInDb, "Validation", MessageBoxButtons.OK)
            Qtytxt.Text = 0
        Else
            QtyResult = QtyInDb - Double.Parse(QtyToDeduct)

        End If

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        If Qtytxt.Text = "" Then
            MessageBox.Show("Quantity must be greater than 0", "Validation", MessageBoxButtons.OK)
        ElseIf ComboBox1.Text = "" Then
            MessageBox.Show("Invali Input in Asset Condition", "Validation", MessageBoxButtons.OK)
        Else

            QtyCalication()

            If QtyInDb < QtyToDeduct Then

                Qtytxt.Text = 0

            ElseIf Qtytxt.Text = 0 Then

                MessageBox.Show("Quantity must be greater than 0", "Validation", MessageBoxButtons.OK)

            Else

                Dim lastChildSeries As Integer = FetchClass.IsLastChild(PropertyCode)

                If lastChildSeries = 0 Then

                    lastChildSeries = 1
                Else

                    lastChildSeries = lastChildSeries + 1

                End If

                UpdateClass.UpdateAssetQty(InvId, QtyResult)

                If IsFromReq = False Then
                    UpdateClass.UpdateReqstQuantity(ReqId, AQty - Qtytxt.Text, PropertyCode + "-" + lastChildSeries.ToString)
                Else

                End If

                InsertionClass.SaveAssetInventory(ItemCode, ItemClass, PropertyCode, ItemDescription, Double.Parse(Qtytxt.Text), NewOwner, NewOwner, 0, Reference, referenceno, "Not Allowed", 0, 0, ComboBox1.Text, lastChildSeries, True, False)

                With Assignment1.dgv
                    .Rows(rowToEdit).Cells(4).Value = Qtytxt.Text
                    .Rows(rowToEdit).Cells(9).Value = PropertyCode + "-" + lastChildSeries.ToString
                End With
                MessageBox.Show("Successfully Assigned...", "Confrimation", MessageBoxButtons.OK)
                Me.Dispose()
                AssetList3.Dispose()
                Assignment1.display()
                Rqregister.display()

            End If

        End If

    End Sub

    Private Sub ConsumableQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Qtytxt.Text = AQty
        QtyCalication()
    End Sub


    Private Sub Request()

        'FetchClass.RequestQty()



    End Sub



End Class
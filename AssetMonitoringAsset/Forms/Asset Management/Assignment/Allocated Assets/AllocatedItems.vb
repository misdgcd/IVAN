Public Class AllocatedItems
    Private Sub AllocatedItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Public Sub display()
        InventoryClass.ViewAllocatedAsset(TextBox1.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub


    Private Sub dgview2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview2.CellDoubleClick
        Dim row As Integer = dgview2.CurrentCell.RowIndex
        If e.ColumnIndex = 1 Then
            AllocatedAssetDetails.emplid = Integer.Parse(dgview2.Rows(row).Cells(0).Value.ToString)
            AllocatedAssetDetails.TextBox1.Text = dgview2.Rows(row).Cells(1).Value.ToString
            AllocatedAssetDetails.TextBox3.Text = dgview2.Rows(row).Cells(0).Value.ToString
            AllocatedAssetDetails.TextBox2.Text = dgview2.Rows(row).Cells(3).Value.ToString
            AllocatedAssetDetails.TextBox4.Text = dgview2.Rows(row).Cells(4).Value.ToString
            AllocatedAssetDetails.TextBox5.Text = dgview2.Rows(row).Cells(5).Value.ToString
            AllocatedAssetDetails.ShowDialog()
        ElseIf e.ColumnIndex = 2 Then
            AllocatedAssetDetails.emplid = Integer.Parse(dgview2.Rows(row).Cells(0).Value.ToString)
            AllocatedAssetDetails.TextBox1.Text = dgview2.Rows(row).Cells(1).Value.ToString
            AllocatedAssetDetails.TextBox3.Text = dgview2.Rows(row).Cells(0).Value.ToString
            AllocatedAssetDetails.TextBox2.Text = dgview2.Rows(row).Cells(3).Value.ToString
            AllocatedAssetDetails.TextBox4.Text = dgview2.Rows(row).Cells(4).Value.ToString
            AllocatedAssetDetails.TextBox5.Text = dgview2.Rows(row).Cells(5).Value.ToString
            AllocatedAssetDetails.ShowDialog()
        End If
    End Sub


End Class
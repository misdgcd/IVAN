Public Class AssetList3
    Public rowToEdit As Integer


    Private Sub AssetList3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()
        dgv.DataSource = MasterdataDetailsClass.Fetchrlist1(TextBox1.Text)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = dgv.Rows(index)

        With AcquisitionRequest.dgv

            .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
            .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
            .Rows(rowToEdit).Cells(2).Value = "0"
            .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(2).Value.ToString
        End With

        Me.Close()
    End Sub
End Class
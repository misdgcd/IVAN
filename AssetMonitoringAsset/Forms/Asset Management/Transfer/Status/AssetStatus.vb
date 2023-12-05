Public Class AssetStatus


    Private invID As Integer

    Private Sub AssetStatus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        disply()
    End Sub


    Public Sub disply()
        dgv.DataSource = InventoryClass.FetchAssetMasterData4(TextBox1.Text, ComboBox1.Text)

        With dgv
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Reference"
            .Columns(3).HeaderText = "Reference No."
            .Columns(4).HeaderText = "Status"

            .Columns(5).Visible = False
        End With

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        disply()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        disply()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        SimpleButton2.Enabled = True
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim row As Integer = dgv.CurrentCell.RowIndex

        AllocationUpdate.TextBox1.Text = dgv.Rows(row).Cells(0).Value.ToString
        AllocationUpdate.TextBox2.Text = dgv.Rows(row).Cells(1).Value.ToString
        AllocationUpdate.TextBox3.Text = dgv.Rows(row).Cells(2).Value.ToString
        AllocationUpdate.TextBox4.Text = dgv.Rows(row).Cells(3).Value.ToString
        AllocationUpdate.ComboBox1.Text = dgv.Rows(row).Cells(4).Value.ToString
        AllocationUpdate.InvID = Integer.Parse(dgv.Rows(row).Cells(5).Value.ToString)
        AllocationUpdate.ShowDialog()

    End Sub
End Class
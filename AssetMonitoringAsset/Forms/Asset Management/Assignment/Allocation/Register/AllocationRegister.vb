Public Class AllocationRegister
    Private Sub AllocationRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub display()
        dgv.DataSource = AssetHeaderClass.FetchDataFetchAllocation(TextBox2.Text, DateTimePicker1.Value, DateTimePicker2.Value)

        With dgv

            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "Entry Number"
            .Columns(2).HeaderText = "Encoder"

            .Columns(3).Visible = False

        End With
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        display()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        display()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        display()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex

        RegisterDetail.entryno = Integer.Parse(dgv.Rows(row).Cells(3).Value.ToString)
        RegisterDetail.ShowDialog()
    End Sub
End Class
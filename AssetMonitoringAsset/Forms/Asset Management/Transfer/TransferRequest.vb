Public Class TransferRequest
    Private Sub TransferRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()
        TextBox3.Text = UserClass.FetcUserfandlname(Home.UserID)
        dgv.Columns.Add("0", "Asset Code")
        dgv.Columns.Add("1", "Asset Description")
        dgv.Columns.Add("2", "Reference")
        dgv.Columns.Add("3", "Reference No.")
        dgv.Columns.Add("4", "Quantity")
        dgv.Columns.Add("5", "Transfer To")
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex

        If e.ColumnIndex = 0 Then
            Assets1.check = 2
            Assets1.ShowDialog()
        End If



    End Sub
End Class
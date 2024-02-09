Public Class RequestRegister
    Private Sub RequestRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub display()
        dgv.DataSource = RequestHeaderClass.FetchsRequstRegister

        With dgv
            .Columns(0).HeaderText = "Date"
            .Columns(1).HeaderText = "Request No."
            .Columns(2).HeaderText = "Transaction Type"
            .Columns(3).HeaderText = "Company"
            .Columns(4).HeaderText = "Department"
            .Columns(5).HeaderText = "Branch"
            .Columns(6).HeaderText = "Section"
            .Columns(7).HeaderText = "Encoder"
            .Columns(8).HeaderText = "Status"
        End With

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex

        Rqregister.headerid = Integer.Parse(dgv.Rows(row).Cells(9).Value.ToString)
        Rqregister.Rtype = dgv.Rows(row).Cells(2).Value.ToString
        Rqregister.TextBox3.Text = dgv.Rows(row).Cells(2).Value.ToString
        Rqregister.TextBox1.Text = dgv.Rows(row).Cells(1).Value.ToString
        Rqregister.TextBox2.Text = dgv.Rows(row).Cells(7).Value.ToString
        Rqregister.ShowDialog()

    End Sub
End Class
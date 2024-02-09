Public Class RequestForApproval
    Private Sub RequestForApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()

        dgv.DataSource = RequestHeaderClass.fetchRequesttoapprove(Home.UserType)
        dgv.Columns(0).HeaderText = "Subject"
        dgv.Columns(1).HeaderText = "Date"
        dgv.Columns(2).HeaderText = "Request By"
        dgv.Columns(3).HeaderText = "Status"
        dgv.Columns(4).HeaderText = "headerid"
        dgv.Columns(5).HeaderText = "Rtype"
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex

        Approval.headerid = Integer.Parse(dgv.Rows(row).Cells(4).Value.ToString)
        Approval.ReqType = dgv.Rows(row).Cells(5).Value.ToString
        Approval.ShowDialog()

    End Sub
End Class
Public Class Request2

    
    Private Sub Request2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()

    End Sub

    Private Sub display()

        'dgv.DataSource = RequestHeaderClass.fetchreq1(TextBox1.Text)

        With dgv
            .Columns(0).HeaderText = "Request Number"
            .Columns(1).HeaderText = "Request By"
            .Columns(2).HeaderText = "Request For"
            '.Columns(3).Visible = False
        End With
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedrow As DataGridViewRow
        selectedrow = dgv.Rows(index)

        With AssetAcquisition
            '.fordgvclearing()
            .emplid2 = Integer.Parse(selectedrow.Cells(5).Value.ToString)
            .reqid = Integer.Parse(selectedrow.Cells(4).Value.ToString)
            .reqst = True
            .Displaydg()
            .dgview.AllowUserToAddRows = True
            .dgview.AllowUserToDeleteRows = True
        End With

        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub
End Class
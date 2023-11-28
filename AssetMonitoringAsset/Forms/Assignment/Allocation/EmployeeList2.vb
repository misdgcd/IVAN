Public Class EmployeeList2
    Private Sub EmployeeList2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Private Sub display()
        dgv.DataSource = EmployeeClass.ViewEmployeeList2(TextBox1.Text)
        dgv.Columns(0).Visible = False
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)


            With Allocation
                .TextBox1.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                .TextBox3.Text = selectedrow.Cells(3).Value.ToString
                .TextBox2.Text = selectedrow.Cells(4).Value.ToString
                .TextBox5.Text = selectedrow.Cells(5).Value.ToString
            End With


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class EmployeeList
    Private Sub EmployeeList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdg()
    End Sub

    Private Sub viewdg()
        dgview.DataSource = EmployeeClass.ViewEmployeeList(TextBox1.Text)
    End Sub

    Private Sub Dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)


            With UserAdd
                .Label3.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                .EmpID = Integer.Parse(selectedrow.Cells(0).Value.ToString)
                .TextBox1.Enabled = True
                .TextBox2.Enabled = True
            End With

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        viewdg()
    End Sub

    Private Sub EmployeeList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class
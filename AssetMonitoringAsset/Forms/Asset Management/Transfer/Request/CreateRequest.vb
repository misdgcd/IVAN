Public Class CreateRequest


    Public branID As Integer
    Public depID As Integer
    Public SecID As Integer
    Public EmpID As Integer
    Public requestby As Integer

    Private Sub CreateRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 1
        display()
    End Sub



    Private Sub display()

        If ComboBox1.Text = "Borrow Asset" Then
            dgv.Rows.Clear()
            dgv.Columns.Clear()

            With dgv
                dgv.Columns.Add("0", "Asset Code")
                dgv.Columns.Add("1", "Asset Description")
                dgv.Columns.Add("2", "Category")
                dgv.Columns.Add("3", "Asset Type")

                .Columns(0).ReadOnly = True
                .Columns(1).ReadOnly = True
                .Columns(2).ReadOnly = True
                .Columns(3).ReadOnly = True

                .Columns(0).Width = 150
                .Columns(1).Width = 400
                .Columns(2).Width = 150
                .Columns(3).Width = 150

            End With

        ElseIf ComboBox1.Text = "Transfer Ownership" Then
            dgv.Rows.Clear()
            dgv.Columns.Clear()
            With dgv

                dgv.Columns.Add("0", "Asset Code")
                dgv.Columns.Add("1", "Asset Description")
                dgv.Columns.Add("2", "Reference")
                dgv.Columns.Add("3", "Reference No.")
                dgv.Columns.Add("4", "Owner")
                dgv.Columns.Add("5", "Borrow Status")

                .Columns(0).ReadOnly = True
                .Columns(1).ReadOnly = True
                .Columns(2).ReadOnly = True
                .Columns(3).ReadOnly = True
                .Columns(4).ReadOnly = True
                .Columns(5).ReadOnly = True

                .Columns(0).Width = 150
                .Columns(1).Width = 400
                .Columns(2).Width = 150
                .Columns(3).Width = 150
                .Columns(4).Width = 200
                .Columns(5).Width = 150

            End With
        End If

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then

            If ComboBox1.Text = "Borrow Asset" Then
                Assets1.rowToEdit = row
                Assets1.check = 1
                Assets1.ShowDialog()
            ElseIf ComboBox1.Text = "Transfer Ownership" Then
                Assets1.rowToEdit = row
                Assets1.check = 3
                Assets1.ShowDialog()
            End If

        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        EmployeeList2.mods = 1
        EmployeeList2.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        EmployeeList2.mods = 3
        EmployeeList2.ShowDialog()
    End Sub

    Private Sub CreateRequest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim Stat As String = "Pending"
        TransferHeaderClass.SaveTransfer(ComboBox1.Text, requestby, EmpID, DateTimePicker1.Value, Stat)
    End Sub
End Class
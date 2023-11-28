Public Class Allocation
    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        EmployeeList2.ShowDialog()
    End Sub

    Private Sub Allocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Displaydg()
    End Sub


    Public Sub Displaydg()

        Try
            DateTimePicker1.Value = DateTime.Now.Date()
            dgv.Columns.Add("0", "Asset Code")
            dgv.Columns.Add("1", "Asset Description")
            dgv.Columns.Add("2", "Reference")
            dgv.Columns.Add("3", "Reference No.")
            dgv.Columns.Add("4", "Quantity")
            'GETS THE VALUE ID'
            dgv.Columns.Add("5", "CatID")
            dgv.Columns.Add("6", "AssTypeID")
            dgv.Columns.Add("7", "ConID")
            dgv.Columns.Add("8", "AssetID")

            dgv.Columns(5).Visible = False
            dgv.Columns(6).Visible = False
            dgv.Columns(7).Visible = False
            dgv.Columns(8).Visible = False

            dgv.Columns(0).ReadOnly = True
            dgv.Columns(1).ReadOnly = True
            dgv.Columns(2).ReadOnly = True
            dgv.Columns(3).ReadOnly = True
            dgv.Columns(4).ReadOnly = False
            dgv.Columns(6).ReadOnly = True
            dgv.Columns(7).ReadOnly = True
            dgv.Rows.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then
            AssetList2.rowToEdit = row
            AssetList2.ShowDialog()
        End If
    End Sub
End Class
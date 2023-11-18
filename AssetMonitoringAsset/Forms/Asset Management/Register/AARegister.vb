﻿Public Class AARegister
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdgv()
    End Sub

    Private Sub viewdgv()
        Dim mods As Integer = 1
        dgv.DataSource = AssetHeaderClass.FetchDatatoDGV1(TextBox2.Text, DateTimePicker1.Value, DateTimePicker2.Value, mods)

        dgv.Columns(0).HeaderText = "Date"
        dgv.Columns(1).HeaderText = "Entry No."
        dgv.Columns(2).HeaderText = "Remarks"
        dgv.Columns(3).HeaderText = "User"
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        viewdgv()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        viewdgv()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        viewdgv()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)


            With AAdetail
                .entry = selectedrow.Cells(1).Value.ToString

                .TextBox1.Text = selectedrow.Cells(1).Value.ToString
                .TextBox2.Text = Format(CDate(selectedrow.Cells(0).Value.ToString), "dd/MM/yyyy")
                .TextBox3.Text = selectedrow.Cells(2).Value.ToString
                .ShowDialog()
            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AARegister_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox2.Text = ""
        End If
    End Sub
End Class
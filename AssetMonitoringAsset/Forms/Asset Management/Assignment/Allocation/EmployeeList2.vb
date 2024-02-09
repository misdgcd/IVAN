Public Class EmployeeList4

    Public mods As Integer
    Private Sub EmployeeList2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Private Sub display()
        dgv.DataSource = EmployeeClass.ViewEmployeeList2(TextBox1.Text)
        dgv.Columns(0).Visible = False
        dgv.Columns(6).Visible = False
        dgv.Columns(7).Visible = False
        dgv.Columns(8).Visible = False


    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgv.Rows(index)


            If mods = 1 Then

                With CreateRequest

                    .TextBox1.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                    .TextBox2.Text = selectedrow.Cells(3).Value.ToString
                    .TextBox6.Text = selectedrow.Cells(4).Value.ToString
                    .TextBox4.Text = selectedrow.Cells(5).Value.ToString

                    .branID = Integer.Parse(selectedrow.Cells(6).Value.ToString)
                    .depID = Integer.Parse(selectedrow.Cells(7).Value.ToString)
                    .SecID = Integer.Parse(selectedrow.Cells(8).Value.ToString)
                    .EmpID = Integer.Parse(selectedrow.Cells(0).Value.ToString)

                End With

            ElseIf mods = 2 Then

                With Allocation

                    .TextBox1.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                    '.TextBox3.Text = selectedrow.Cells(3).Value.ToString
                    '.TextBox2.Text = selectedrow.Cells(4).Value.ToString
                    '.TextBox5.Text = selectedrow.Cells(5).Value.ToString

                    .branID = Integer.Parse(selectedrow.Cells(6).Value.ToString)
                    .depID = Integer.Parse(selectedrow.Cells(7).Value.ToString)
                    .SecID = Integer.Parse(selectedrow.Cells(8).Value.ToString)
                    .EmpID = Integer.Parse(selectedrow.Cells(0).Value.ToString)

                End With


            ElseIf mods = 3 Then
                With CreateRequest

                    .TextBox3.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                    .requestby = Integer.Parse(selectedrow.Cells(0).Value.ToString)

                End With



            ElseIf mods = 4 Then

                'With Request

                '    .TextBox4.Text = selectedrow.Cells(1).Value.ToString + " " + selectedrow.Cells(2).Value.ToString
                '    .TextBox5.Text = selectedrow.Cells(3).Value.ToString
                '    .TextBox6.Text = selectedrow.Cells(4).Value.ToString
                '    .TextBox7.Text = selectedrow.Cells(5).Value.ToString

                '    .branID = Integer.Parse(selectedrow.Cells(6).Value.ToString)
                '    .depID = Integer.Parse(selectedrow.Cells(7).Value.ToString)
                '    .SecID = Integer.Parse(selectedrow.Cells(8).Value.ToString)
                '    .EmpID = Integer.Parse(selectedrow.Cells(0).Value.ToString)

                'End With

            End If

            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
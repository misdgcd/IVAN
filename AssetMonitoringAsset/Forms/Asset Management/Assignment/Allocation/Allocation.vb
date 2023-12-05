Public Class Allocation


    Public branID As Integer
    Public depID As Integer
    Public SecID As Integer
    Public EmpID As Integer

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        EmployeeList2.mods = 2
        EmployeeList2.ShowDialog()
    End Sub

    Private Sub Allocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Displaydg()
    End Sub


    Public Sub Displaydg()

        Try
            TextBox4.Text = AllocationHeaderClass.FetchEntryID
            DateTimePicker1.Value = DateTime.Now.Date()
            dgv.Columns.Add("0", "Asset Code")
            dgv.Columns.Add("1", "Asset Description")
            dgv.Columns.Add("2", "Reference")
            dgv.Columns.Add("3", "Reference No.")
            dgv.Columns.Add("4", "Quantity")
            'GETS THE VALUE ID'

            dgv.Columns.Add("5", "AssetID")
            dgv.Columns.Add("6", "InvID")

            dgv.Columns(5).Visible = False
            dgv.Columns(6).Visible = False

            dgv.Columns(0).ReadOnly = True
            dgv.Columns(1).ReadOnly = True
            dgv.Columns(2).ReadOnly = True
            dgv.Columns(3).ReadOnly = True
            dgv.Columns(4).ReadOnly = False

            dgv.Rows.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If TextBox1.Text = "" Then
            MessageBox.Show("Please Select Employee First", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim row As Integer = dgv.CurrentCell.RowIndex
            If e.ColumnIndex = 0 Then
                AssetList2.rowToEdit = row
                AssetList2.ShowDialog()

            End If
            dgv.Columns(4).ReadOnly = False
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try

            If SimpleButton1.Text = "Record" Then

                Dim rows1 As Integer = dgv.CurrentCell.RowIndex


                If TextBox1.Text = "" Then
                    MessageBox.Show("Please Select Employee", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf dgv.Rows(rows1).Cells(4).Value.ToString = "0" Then
                    MessageBox.Show("Invalid Quantity", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    AllocationHeaderClass.SaveAssetAllocation(depID, branID, SecID, DateTimePicker1.Value, TextBox4.Text, EmpID, Home.UserID)
                    For Each row As DataGridViewRow In dgv.Rows
                        If Not row.IsNewRow Then
                            Dim AssetCode As String = row.Cells(0).Value.ToString
                            Dim Des As String = row.Cells(1).Value.ToString
                            Dim ref As String = row.Cells(2).Value.ToString
                            Dim refno As String = row.Cells(3).Value.ToString
                            Dim qty As String = row.Cells(4).Value.ToString
                            Dim AssetId As String = row.Cells(5).Value.ToString
                            Dim InvId As String = row.Cells(6).Value.ToString
                            Dim TransHeaderID As Integer = AllocationHeaderClass.FetchTransHeaderID
                            Dim owner As Integer = EmpID
                            Dim Stat As Integer

                            If ref = "N/A" Then
                                Stat = 2
                            Else
                                Stat = 1
                            End If

                            If InventoryClass.Checkqty(Integer.Parse(InvId), Double.Parse(qty)) > 0 Then
                                AllocationDetailClass.SaveAssetAllocation(Integer.Parse(AssetId), Integer.Parse(InvId), Double.Parse(qty), TransHeaderID)
                                InventoryClass.UpdateInventoryStatandQty(Integer.Parse(InvId), Double.Parse(qty), Stat, owner)
                            Else
                                MessageBox.Show("Not Sufficient Stock", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    Next
                End If

            ElseIf SimpleButton1.Text = "New Allocation" Then
                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
                TextBox3.Text = String.Empty
                TextBox4.Text = String.Empty
                TextBox5.Text = String.Empty

                fordgvclearing()
                Displaydg()
                SimpleButton3.Visible = False
                SimpleButton1.Text = "Record"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub fordgvclearing()
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub

    Private Sub Allocation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        fordgvclearing()
    End Sub

    Private Sub dgv_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValidated
        'If dgv.Rows(e.RowIndex).Cells(4).Value.ToString = "0" Then
        '    MessageBox.Show("Invalid Quantity", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub dgv_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating

    End Sub
End Class
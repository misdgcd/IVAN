Public Class Allocation


    Public branID As Integer
    Public depID As Integer
    Public SecID As Integer
    Public EmpID As Integer
    Private noti2 As Integer
    Public reqid As Integer
    Public reqst As Boolean = False

    Public emplid2 As Integer

    Private Sub PanelControl1_Paint(sender As Object, e As PaintEventArgs) Handles PanelControl1.Paint

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        EmployeeList4.mods = 2
        EmployeeList4.ShowDialog()
    End Sub

    Private Sub Allocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub Displaydg()

        Try
            If reqst = True Then
                dgv.Columns.Clear()
                TextBox4.Text = AllocationHeaderClass.FetchEntryID

                RequestHeaderClass.ViewRequest2(reqid)
                dgv.AllowUserToAddRows = True


            ElseIf reqst = False Then
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
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick


        If TextBox1.Text = "" Then
            MessageBox.Show("Please Select Employee First", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If reqst = True Then
                Dim row As Integer = dgv.CurrentCell.RowIndex
                If e.ColumnIndex = 2 Then
                    AssetList2.reqt2 = True
                    AssetList2.rowToEdit = row
                    AssetList2.ShowDialog()
                End If

            ElseIf reqst = False Then
                Dim row As Integer = dgv.CurrentCell.RowIndex
                If e.ColumnIndex = 0 Then
                    AssetList2.reqt2 = False
                    AssetList2.rowToEdit = row
                    AssetList2.ShowDialog()

                End If
            End If

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
                'TextBox2.Text = String.Empty
                'TextBox3.Text = String.Empty
                'TextBox4.Text = String.Empty
                'TextBox5.Text = String.Empty

                fordgvclearing()
                Displaydg()
                SimpleButton3.Visible = False
                SimpleButton1.Text = "Record"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub fordgvclearing()
        reqst = False
        dgv.DataSource = Nothing
            dgv.Rows.Clear()
            dgv.Columns.Clear()
        TextBox1.Text = String.Empty
        'TextBox2.Text = String.Empty
        'TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        'TextBox5.Text = String.Empty

    End Sub

    Private Sub Allocation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        fordgvclearing()
    End Sub

    Private Sub dgv_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellValidated

        If e.ColumnIndex = 2 Then
            For Each row As DataGridViewRow In dgv.Rows
                For Each otherRow As DataGridViewRow In dgv.Rows
                    If row.Index <> otherRow.Index Then ' Avoid comparing the same row with itself
                        Dim areRowsEqual As Boolean = True

                        ' Compare values in columns 4 and 5
                        Dim columnIndex1 As Integer = 2 ' Adjust as needed
                        Dim columnIndex2 As Integer = 3 ' Adjust as needed
                        Dim columnIndex3 As Integer = 0 ' Adjust as needed

                        If Not row.Cells(columnIndex1).Value.Equals(otherRow.Cells(columnIndex1).Value) OrElse
                            Not row.Cells(columnIndex2).Value.Equals(otherRow.Cells(columnIndex2).Value) OrElse
                             Not row.Cells(columnIndex3).Value.Equals(otherRow.Cells(columnIndex3).Value) Then
                            areRowsEqual = False
                        End If

                        ' If values in columns 4 and 5 are equal, show an error message or take appropriate action
                        If areRowsEqual Then
                            MessageBox.Show("Duplicate are Invalid", "Duplicate Rows", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            dgv.AllowUserToAddRows = False

                            For Each cell As DataGridViewCell In row.Cells
                                cell.Style.BackColor = Color.Red
                            Next

                            For Each cell As DataGridViewCell In otherRow.Cells
                                cell.Style.BackColor = Color.Red
                            Next
                            SimpleButton1.Enabled = False
                            Exit Sub

                        Else
                            dgv.AllowUserToAddRows = True
                            For Each cell As DataGridViewCell In row.Cells
                                cell.Style.BackColor = Color.White
                            Next

                            For Each cell As DataGridViewCell In otherRow.Cells
                                cell.Style.BackColor = Color.White
                            Next
                            SimpleButton1.Enabled = True
                        End If
                    End If
                Next
            Next
        End If

    End Sub

    Private Sub dgv_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgv.CellValidating

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Request2.ShowDialog()
    End Sub
End Class
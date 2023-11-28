Public Class AssetAcquisition

    Public vendorID As Integer
    Public DocId As Integer
    Private Sub AssetAcquisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fordgvclearing()
        Displaydg()
    End Sub

    Public Sub Displaydg()

        Try
            ComboBox1.DataSource = VendorClass.ViewCboxVen
            ComboBox2.DataSource = DocTypeClass.ViewCboxDoc
            dgview.AllowUserToAddRows = True
            DateTimePicker1.Value = DateTime.Now.Date()
            Label2.Text = AssetHeaderClass.FetchEntryID2
            dgview.Columns.Add("0", "Asset Code")
            dgview.Columns.Add("1", "Asset Description")
            dgview.Columns.Add("2", "Categories")
            dgview.Columns.Add("3", "Asset Type")
            dgview.Columns.Add("4", "Reference")
            dgview.Columns.Add("5", "Reference No.")
            dgview.Columns.Add("6", "Condition")
            dgview.Columns.Add("7", "Quantity")
            'GETS THE VALUE ID'
            dgview.Columns.Add("8", "CatID")
            dgview.Columns.Add("9", "AssTypeID")
            dgview.Columns.Add("10", "ConID")
            dgview.Columns.Add("11", "AssetID")

            dgview.Columns(8).Visible = False
            dgview.Columns(9).Visible = False
            dgview.Columns(10).Visible = False
            dgview.Columns(11).Visible = False

            dgview.Columns(0).ReadOnly = True
            dgview.Columns(1).ReadOnly = True
            dgview.Columns(2).ReadOnly = True
            dgview.Columns(3).ReadOnly = True
            dgview.Columns(4).ReadOnly = True
            dgview.Columns(6).ReadOnly = True
            dgview.Columns(7).ReadOnly = True
            dgview.Rows.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then
            AssetList.modty = 2
            AssetList.rowToEdit = row
            AssetList.ShowDialog()
        ElseIf e.ColumnIndex = 4 Then
            ReferenceList.modty = 2
            ReferenceList.rowToEdit = row
            ReferenceList.ShowDialog()
        End If
    End Sub

    Private Sub AssetAcquisition_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            fordgvclearing()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub fordgvclearing()
        dgview.Rows.Clear()
        dgview.Columns.Clear()
    End Sub

    Private Sub AssetAcquisition_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
            TextBox2.Text = String.Empty
        End If
    End Sub

    Private Sub dgview_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgview.CellValidating
        Dim repeatingId As Boolean = False
        If e.ColumnIndex = 0 Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                MessageBox.Show("Please Select Asset", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf e.ColumnIndex = 4 Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                MessageBox.Show("Please Select Reference", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf e.ColumnIndex = 5 Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                MessageBox.Show("Please Input Reference Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf e.ColumnIndex = 7 Then
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                MessageBox.Show("Invalid Quantity", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim check As Boolean = False
        Dim rows As Integer = dgview.CurrentCell.RowIndex

        If dgview.Rows(rows).Cells(0).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(0).Value.ToString()) Then
            MessageBox.Show("Invalid Asset", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf dgview.Rows(rows).Cells(5).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(5).Value.ToString()) Then
            MessageBox.Show("Invalid Reference Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf dgview.Rows(rows).Cells(4).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(4).Value.ToString()) Then
            MessageBox.Show("Invalid Reference", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf dgview.Rows(rows).Cells(7).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(7).Value.ToString()) Then
            MessageBox.Show("Invalid Quantity", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Else
            Try
                Dim venid As Integer = vendorID
                Dim mod2 As Integer = 1
                Dim bstat As String = "Not Allowed"
                Dim brw As Integer = 0
                Dim Stat As Integer
                AssetHeaderClass.SaveAsset(Label2.Text, TextBox1.Text, DateTimePicker1.Value, TextBox2.Text, DocId, vendorID, mod2)
                For Each row As DataGridViewRow In dgview.Rows
                    If Not row.IsNewRow Then
                        Dim mod1 As Integer = 1

                        Dim AssetCode As String = row.Cells(0).Value.ToString
                        Dim Des As String = row.Cells(1).Value.ToString
                        Dim ref As String = row.Cells(4).Value.ToString
                        Dim refno As String = row.Cells(5).Value.ToString
                        Dim qty As String = row.Cells(7).Value.ToString
                        Dim CatId As String = row.Cells(8).Value.ToString
                        Dim TypeId As String = row.Cells(9).Value.ToString
                        Dim ConId As String = row.Cells(10).Value.ToString
                        Dim assetID As String = row.Cells(11).Value.ToString


                        If ref = "N/A" Then
                            Stat = 2
                        Else
                            Stat = 0
                        End If


                        If AssetDetailClass.FetchRefnoCount(AssetCode, refno, ref) > 0 Then
                            MessageBox.Show("Please Use Unique Serial Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            check = True
                        Else

                            If row.Cells(4).Value.ToString = "Serial Number" Or row.Cells(4).Value.ToString = "Plate #" Then

                                Dim TransHeaderID As Integer = AssetHeaderClass.FetchTransHeaderID
                                AssetDetailClass.SaveAssetDetail(AssetCode, Des, Integer.Parse(CatId), Integer.Parse(TypeId), Integer.Parse(ConId), TransHeaderID, ref, refno, Double.Parse(qty), Integer.Parse(assetID), mod1, venid)
                                InventoryClass.SaveAssetInventory(Integer.Parse(assetID), AssetCode, Double.Parse(qty), ref, refno, Home.UserID, bstat, brw, Stat)

                            ElseIf row.Cells(4).Value.ToString = "N/A" Then

                                If AssetDetailClass.FetchNACount(AssetCode, refno, ref) > 0 Then
                                    Dim TransHeaderID As Integer = AssetHeaderClass.FetchTransHeaderID
                                    AssetDetailClass.SaveAssetDetail(AssetCode, Des, Integer.Parse(CatId), Integer.Parse(TypeId), Integer.Parse(ConId), TransHeaderID, ref, refno, Double.Parse(qty), Integer.Parse(assetID), mod1, venid)
                                    InventoryClass.UpdateInventory(Integer.Parse(assetID), Double.Parse(qty), ref)
                                Else
                                    Dim TransHeaderID As Integer = AssetHeaderClass.FetchTransHeaderID
                                    AssetDetailClass.SaveAssetDetail(AssetCode, Des, Integer.Parse(CatId), Integer.Parse(TypeId), Integer.Parse(ConId), TransHeaderID, ref, refno, Double.Parse(qty), Integer.Parse(assetID), mod1, venid)
                                    InventoryClass.SaveAssetInventory(Integer.Parse(assetID), AssetCode, Double.Parse(qty), ref, refno, Home.UserID, bstat, brw, Stat)

                                End If
                            End If
                        End If
                    End If
                Next

                If check = False Then
                    TextBox1.Text = String.Empty
                    TextBox2.Text = String.Empty
                    Label2.Text = String.Empty
                    fordgvclearing()
                    Displaydg()
                    MessageBox.Show("Successfully Recorded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else

                End If

            Catch ex As Exception
                MessageBox.Show("Error in Asset Acquisition Record.. Pls Contact SPU-Programmer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        vendorID = VendorClass.FetchVEndorID(ComboBox1.Text)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        DocId = DocTypeClass.FetchDocTypeID(ComboBox2.Text)
    End Sub

    Private Sub dgview_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellValidated
        ValidateCell(e.RowIndex, e.ColumnIndex)

    End Sub


    Private Sub ValidateCell(ByVal rowIndex As Integer, ByVal columnIndex As Integer)
        Try

            Dim cellValue As String = dgview.Rows(rowIndex).Cells(columnIndex).Value.ToString
            If columnIndex = 5 Then

                If dgview.Rows(rowIndex).Cells(4).Value.ToString = "Serial Number" Then

                    If AssetDetailClass.FetchRefnoCount(dgview.Rows(rowIndex).Cells(0).Value.ToString, dgview.Rows(rowIndex).Cells(5).Value.ToString, dgview.Rows(rowIndex).Cells(4).Value.ToString) > 0 Then
                        MessageBox.Show("Serial Number Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgview.Rows(rowIndex).Cells(5).Value = String.Empty
                        dgview.AllowUserToAddRows = False
                    Else
                        dgview.AllowUserToAddRows = True

                    End If

                ElseIf dgview.Rows(rowIndex).Cells(4).Value.ToString = "Plate #" Then
                    If AssetDetailClass.FetchRefnoCount(dgview.Rows(rowIndex).Cells(0).Value.ToString, dgview.Rows(rowIndex).Cells(5).Value.ToString, dgview.Rows(rowIndex).Cells(4).Value.ToString) > 0 Then
                        MessageBox.Show("Plate # Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgview.Rows(rowIndex).Cells(5).Value = String.Empty
                        dgview.AllowUserToAddRows = False

                    Else
                        dgview.AllowUserToAddRows = True

                    End If
                End If

                For Each row As DataGridViewRow In dgview.Rows
                    For Each otherRow As DataGridViewRow In dgview.Rows
                        If row.Index <> otherRow.Index Then ' Avoid comparing the same row with itself
                            Dim areRowsEqual As Boolean = True

                            ' Compare values in columns 4 and 5
                            Dim columnIndex1 As Integer = 4 ' Adjust as needed
                            Dim columnIndex2 As Integer = 5 ' Adjust as needed

                            If Not row.Cells(columnIndex1).Value.Equals(otherRow.Cells(columnIndex1).Value) OrElse
                                Not row.Cells(columnIndex2).Value.Equals(otherRow.Cells(columnIndex2).Value) Then
                                areRowsEqual = False
                            End If

                            ' If values in columns 4 and 5 are equal, show an error message or take appropriate action
                            If areRowsEqual Then
                                MessageBox.Show("Duplicate are Invalid", "Duplicate Rows", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                dgview.AllowUserToAddRows = False

                                For Each cell As DataGridViewCell In row.Cells
                                    cell.Style.BackColor = Color.Red
                                Next

                                For Each cell As DataGridViewCell In otherRow.Cells
                                    cell.Style.BackColor = Color.Red
                                Next
                                SimpleButton1.Enabled = False
                                Exit Sub

                            Else
                                dgview.AllowUserToAddRows = True
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

            ElseIf columnIndex = 4 Then
                If dgview.Rows(rowIndex).Cells(columnIndex).Value.ToString = "N/A" Then
                    dgview.Rows(rowIndex).Cells(5).Value = "N/A"
                    dgview.Rows(rowIndex).Cells(5).ReadOnly = True
                    dgview.Rows(rowIndex).Cells(7).ReadOnly = False
                    dgview.Rows(rowIndex).Cells(7).Value = ""
                Else
                    dgview.Rows(rowIndex).Cells(5).Value = ""
                    dgview.Rows(rowIndex).Cells(5).ReadOnly = False
                    dgview.Rows(rowIndex).Cells(7).Value = "1"
                    dgview.Rows(rowIndex).Cells(7).ReadOnly = True
                End If

            ElseIf dgview.Rows(rowIndex).Cells(4).Value.ToString = "Serial Number" Then

                If dgview.Rows(rowIndex).Cells(columnIndex).Value.ToString = "0" Then
                    MessageBox.Show("Invalid Quantity", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    'dgview.AllowUserToAddRows = True
                    'SimpleButton1.Enabled = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgview_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgview.RowValidating



    End Sub

    Private Sub dgview_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.RowValidated

    End Sub
End Class
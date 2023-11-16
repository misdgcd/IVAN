Public Class BuildAsset
    Private Sub BuildAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Displaydg()
    End Sub

    Public Sub Displaydg()

        dgview.AllowUserToAddRows = True
        DateTimePicker1.Value = DateTime.Now.Date()
        Label2.Text = AssetHeaderClass.FetchEntryID

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

        dgview.Rows.Clear()
    End Sub

    Private Sub Dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then
            AssetList.modty = 1
            AssetList.rowToEdit = row
            AssetList.ShowDialog()
        ElseIf e.ColumnIndex = 4 Then
            ReferenceList.modty = 1
            ReferenceList.rowToEdit = row
            ReferenceList.ShowDialog()
        End If
    End Sub

    Private Sub Dgview_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgview.CellValidating
        Try
            Dim row As Integer = dgview.CurrentCell.RowIndex

            If e.ColumnIndex = 4 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
                MessageBox.Show("Invalid Reference", "Invalid Input", MessageBoxButtons.OK)
            ElseIf e.ColumnIndex = 4 Then

                If dgview.Rows(row).Cells(4).Value.ToString = "N/A" Then
                    dgview.Rows(row).Cells(5).Value = "N/A"
                    dgview.Rows(row).Cells(5).ReadOnly = True
                Else
                    dgview.Rows(row).Cells(5).ReadOnly = False
                    dgview.Rows(row).Cells(7).Value = "1"
                    dgview.Rows(row).Cells(7).ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgview_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgview.RowValidating

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Dim rows As Integer = dgview.CurrentCell.RowIndex

        If dgview.Rows(rows).Cells(4).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(4).Value.ToString()) Then
            MessageBox.Show("Invalid Reference", "Validation")
        ElseIf dgview.Rows(rows).Cells(7).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(7).Value.ToString()) Then
            MessageBox.Show("Invalid Quantity", "Validation")
        ElseIf dgview.Rows(rows).Cells(5).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(5).Value.ToString()) Then
            MessageBox.Show("Invalid Reference Number", "Validation")
        ElseIf dgview.Rows(rows).Cells(0).Value Is Nothing OrElse String.IsNullOrWhiteSpace(dgview.Rows(rows).Cells(5).Value.ToString()) Then
            MessageBox.Show("Invalid Asset", "Validation")
        Else
            Try
                Dim Docno As String = "N/A"
                Dim DocId As Integer = 0
                Dim VenID As Integer = 0
                Dim mod2 As Integer = 2
                For Each row As DataGridViewRow In dgview.Rows
                    If Not row.IsNewRow Then
                        Dim mod1 As Integer = 1
                        Dim TransHeaderID As Integer = AssetHeaderClass.FetchTransHeaderID
                        Dim AssetCode As String = row.Cells(0).Value.ToString
                        Dim Des As String = row.Cells(1).Value.ToString
                        Dim ref As String = row.Cells(4).Value.ToString
                        Dim refno As String = row.Cells(5).Value.ToString
                        Dim qty As String = row.Cells(7).Value.ToString
                        Dim CatId As String = row.Cells(8).Value.ToString
                        Dim TypeId As String = row.Cells(9).Value.ToString
                        Dim ConId As String = row.Cells(10).Value.ToString
                        Dim assetID As String = row.Cells(11).Value.ToString

                        If AssetDetailClass.FetchAssetCount(Integer.Parse(assetID), refno) > 0 Then

                            If AssetDetailClass.FetchRefnoCount(refno) > 0 Then
                                MessageBox.Show("Please Use Unique Serial Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                AssetHeaderClass.SaveAsset(Label2.Text, TextBox1.Text, DateTimePicker1.Value, Docno, DocId, VenID, mod2)
                                AssetDetailClass.SaveAssetDetail(AssetCode, Des, Integer.Parse(CatId), Integer.Parse(TypeId), Integer.Parse(ConId), TransHeaderID, ref, refno, Double.Parse(qty), Integer.Parse(assetID), mod1)

                                InventoryClass.UpdateInventory(Integer.Parse(assetID), Double.Parse(qty), ref)

                                TextBox1.Text = String.Empty

                                Label2.Text = String.Empty
                                fordgvclearing()
                                Displaydg()
                                MessageBox.Show("Successfully Recorded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Else
                            AssetHeaderClass.SaveAsset(Label2.Text, TextBox1.Text, DateTimePicker1.Value, Docno, DocId, VenID, mod2)
                            AssetDetailClass.SaveAssetDetail(AssetCode, Des, Integer.Parse(CatId), Integer.Parse(TypeId), Integer.Parse(ConId), TransHeaderID, ref, refno, Double.Parse(qty), Integer.Parse(assetID), mod1)
                            InventoryClass.SaveAssetInventory(Integer.Parse(assetID), AssetCode, Double.Parse(qty), ref, refno)
                            TextBox1.Text = String.Empty

                            Label2.Text = String.Empty
                            fordgvclearing()
                            Displaydg()
                            MessageBox.Show("Successfully Recorded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show("Invalid Entry, Please Check blank Cells...", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If







    End Sub

    Private Sub BuildAsset_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            dgview.Rows.Clear()
            dgview.Columns.Clear()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub fordgvclearing()
        dgview.Rows.Clear()
        dgview.Columns.Clear()
    End Sub

    Private Sub BuildAsset_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub
End Class
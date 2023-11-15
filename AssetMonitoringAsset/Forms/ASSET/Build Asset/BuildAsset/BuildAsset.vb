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
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 7 Then

            Dim input As String = e.FormattedValue.ToString()
            Dim result As Double
            If Not Double.TryParse(input, result) Then
                ' Display an error message or handle the invalid input as per your requirement
                MessageBox.Show("Please Enter Valid Quantity...")
                'dgview.AllowUserToAddRows = False
                e.Cancel = True
            Else
                dgview.AllowUserToAddRows = True
            End If

        ElseIf e.ColumnIndex = 4 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MessageBox.Show("Invalid Reference", "Invalid Input", MessageBoxButtons.OK)
        ElseIf e.ColumnIndex = 4 Then

            If dgview.Rows(row).Cells(4).Value.ToString = "N/A" Then
                dgview.Rows(row).Cells(5).ReadOnly = True
            Else
                dgview.Rows(row).Cells(5).ReadOnly = False
            End If
        End If
    End Sub

    Private Sub Dgview_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgview.RowValidating
        Dim row As Integer = dgview.CurrentCell.RowIndex

        If e.ColumnIndex = 4 AndAlso String.IsNullOrWhiteSpace(dgview.Rows(row).Cells(4).Value.ToString()) Then
            MessageBox.Show("Column 4 cannot be empty. Please enter a valid value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' Set the cell to ReadOnly to disable editing
            dgview.Rows(row).Cells(4).ReadOnly = True

            e.Cancel = True
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click




        Try
            AssetHeaderClass.SaveAsset(Label2.Text, TextBox1.Text, DateTimePicker1.Value)

            For Each row As DataGridViewRow In dgview.Rows

                If Not row.IsNewRow Then

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
                    AssetDetailClass.SaveAssetDetail(AssetCode, Des, Integer.Parse(CatId), Integer.Parse(TypeId), Integer.Parse(ConId), TransHeaderID, ref, refno, Double.Parse(qty), Integer.Parse(assetID))
                End If

            Next


            TextBox1.Text = String.Empty
            Label2.Text = String.Empty
            fordgvclearing()
            Displaydg()
            MsgBox("Successfully Recorded...")

        Catch ex As Exception
            MessageBox.Show("Invalid Entry, Please Check blank Cells...", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try



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
Public Class AssetAcquisition


    Public vendorID As Integer
    Public DocId As Integer
    Private Sub AssetAcquisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Displaydg()
    End Sub

    Public Sub Displaydg()
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

        dgview.Rows.Clear()
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
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 7 Then

            Dim input As String = e.FormattedValue.ToString()
            Dim result As Double
            If Not Double.TryParse(input, result) Then
                ' Display an error message or handle the invalid input as per your requirement
                MessageBox.Show("Invalid Quantity", "Invalid Input", MessageBoxButtons.OK)
                'dgview.AllowUserToAddRows = False
                e.Cancel = True
            Else
                dgview.AllowUserToAddRows = True
            End If

        ElseIf e.ColumnIndex = 4 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MessageBox.Show("Invalid Reference", "Invalid Input", MessageBoxButtons.OK)
        ElseIf e.ColumnIndex = 4 Then

            If dgview.Rows(row).Cells(4).Value.ToString = "N/A" Then
                dgview.Rows(row).Cells(5).Value = "N/A"
                dgview.Rows(row).Cells(5).ReadOnly = True
            Else
                dgview.Rows(row).Cells(5).ReadOnly = False
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox2.Text = String.Empty Then
            MessageBox.Show("Invalid Doc Number", "Validation")
        Else

            AssetHeaderClass.SaveAsset(Label2.Text, TextBox1.Text, DateTimePicker1.Value, TextBox2.Text, DocId, vendorID)

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        vendorID = VendorClass.FetchVEndorID(ComboBox1.Text)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        DocId = DocTypeClass.FetchDocTypeID(ComboBox2.Text)
    End Sub
End Class
Public Class AssetList
    Public rowToEdit As Integer
    Public modty As Integer
    Private Sub AssetList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Private Sub display()
        dgview2.DataSource = AssetHeaderClass.FetchAssetMasterData(TextBox1.Text)


        With dgview2
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Asset Description"
            .Columns(2).HeaderText = "Category"
            .Columns(3).HeaderText = "Asset Type"
            .Columns(4).HeaderText = "Asset Condition"

            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
        End With
    End Sub

    Private Sub TextB()


    End Sub

    Private Sub Dgview2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview2.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview2.Rows(index)

            If modty = 1 Then
                With BuildAsset.dgview
                    .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                    .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(2).Value.ToString
                    .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(3).Value.ToString
                    .Rows(rowToEdit).Cells(6).Value = selectedrow.Cells(4).Value.ToString
                    .Rows(rowToEdit).Cells(8).Value = selectedrow.Cells(5).Value.ToString
                    .Rows(rowToEdit).Cells(9).Value = selectedrow.Cells(6).Value.ToString
                    .Rows(rowToEdit).Cells(10).Value = selectedrow.Cells(7).Value.ToString
                    .Rows(rowToEdit).Cells(11).Value = selectedrow.Cells(8).Value.ToString
                End With
            ElseIf modty = 2 Then
                With AssetAcquisition.dgview
                    .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                    .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(2).Value.ToString
                    .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(3).Value.ToString
                    .Rows(rowToEdit).Cells(6).Value = selectedrow.Cells(4).Value.ToString
                    .Rows(rowToEdit).Cells(8).Value = selectedrow.Cells(5).Value.ToString
                    .Rows(rowToEdit).Cells(9).Value = selectedrow.Cells(6).Value.ToString
                    .Rows(rowToEdit).Cells(10).Value = selectedrow.Cells(7).Value.ToString
                    .Rows(rowToEdit).Cells(11).Value = selectedrow.Cells(8).Value.ToString
                End With
            End If


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub AssetList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = String.Empty
        End If
    End Sub
End Class
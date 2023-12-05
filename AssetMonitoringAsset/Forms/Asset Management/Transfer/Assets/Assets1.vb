Public Class Assets1

    Public check As Integer
    Public rowToEdit As Integer
    Private Sub Assets1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub display()

        If check = 1 Then
            dgview2.DataSource = AssetHeaderClass.FetchAssetMasterData(TextBox1.Text)

            With dgview2
                .Columns(0).HeaderText = "Asset Code"
                .Columns(1).HeaderText = "Asset Description"
                .Columns(2).HeaderText = "Category"
                .Columns(3).HeaderText = "Asset Type"

                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
            End With



        ElseIf check = 2 Then
            dgview2.DataSource = InventoryClass.FetchAssetMasterData5(TextBox1.Text)

        ElseIf check = 3 Then

            dgview2.DataSource = InventoryClass.FetchAssetMasterData6(TextBox1.Text)

        End If


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub dgview2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview2.CellDoubleClick
        Try
            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview2.Rows(index)

            If check = 1 Then
                With CreateRequest.dgv
                    .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                    .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(2).Value.ToString
                    .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(3).Value.ToString

                End With


            ElseIf check = 2 Then

            ElseIf check = 3 Then

                With CreateRequest.dgv
                    .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                    .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                    .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(2).Value.ToString
                    .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(3).Value.ToString
                    .Rows(rowToEdit).Cells(4).Value = selectedrow.Cells(4).Value.ToString
                    .Rows(rowToEdit).Cells(5).Value = selectedrow.Cells(5).Value.ToString

                End With
            End If


            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class
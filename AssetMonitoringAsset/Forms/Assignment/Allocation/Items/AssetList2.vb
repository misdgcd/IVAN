Public Class AssetList2

    Public rowToEdit As Integer
    Public validate1 As Boolean = False
    Public check As Boolean = False
    Private pd As String = ""

    Private Sub AssetList2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display1()
    End Sub


    Private Sub display1()
        dgview.DataSource = InventoryClass.FetchAssetMasterData2(TextBox1.Text)
        With dgview
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Asset Description"
            .Columns(0).Width = 350
            .Columns(1).Width = 700
        End With
    End Sub


    Private Sub display2()
        Dim code As String = pd
        dgview.DataSource = InventoryClass.ViewInventoryDetails1(code, TextBox1.Text)
        With dgview
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Available Quantity"
            .Columns(3).HeaderText = "Reference"
            .Columns(4).HeaderText = "Number"

            .Columns(0).Width = 150
            .Columns(1).Width = 400
            .Columns(2).Width = 100
            .Columns(3).Width = 120
            .Columns(4).Width = 200

        End With


    End Sub

    Private Sub dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        If check = False Then
            Dim row As Integer = dgview.SelectedCells(0).RowIndex
            If e.ColumnIndex = 0 Then
                pd = dgview.Rows(row).Cells(0).Value.ToString
                check = True
                validate1 = True
                display2()
                SimpleButton1.Enabled = True
            ElseIf e.ColumnIndex = 1 Then
                pd = dgview.Rows(row).Cells(0).Value.ToString
                check = True
                validate1 = True
                display2()
                SimpleButton1.Enabled = True
            End If
        ElseIf check = True Then

            Dim index As Integer
            index = e.RowIndex
            Dim selectedrow As DataGridViewRow
            selectedrow = dgview.Rows(index)

            With Allocation.dgv
                .Rows(rowToEdit).Cells(0).Value = selectedrow.Cells(0).Value.ToString
                .Rows(rowToEdit).Cells(1).Value = selectedrow.Cells(1).Value.ToString
                .Rows(rowToEdit).Cells(2).Value = selectedrow.Cells(3).Value.ToString
                .Rows(rowToEdit).Cells(3).Value = selectedrow.Cells(4).Value.ToString
            End With
            check = False
            Me.Close()
        End If


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        check = False
        validate1 = False
        display1()
        SimpleButton1.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If validate1 = False Then

            display1()

        Else
            display2()
        End If


    End Sub
End Class
Public Class InventoryList
    Private Sub InventoryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub



    Public Sub Display()
        dgv.DataSource = InventoryClass.ViewInventoryList(TextBox1.Text)



        With dgv
            .Columns(0).HeaderText = "Asset Code"
            .Columns(1).HeaderText = "Description"
            .Columns(2).HeaderText = "Available"
            .Columns(3).HeaderText = "Used"
            .Columns(4).HeaderText = "Total Quantity"
            .Columns(5).HeaderText = "Reference"
            .Columns(6).HeaderText = "Number"

        End With
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Display()
    End Sub
End Class
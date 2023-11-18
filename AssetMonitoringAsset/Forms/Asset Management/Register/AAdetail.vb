Public Class AAdetail
    Public entry As String = String.Empty
    Private Sub AAdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdgv()
    End Sub

    Private Sub viewdgv()
        dgv.DataSource = AssetHeaderClass.Fetchregister1(entry)

        dgv.Columns(0).HeaderText = "Asset Code"
        dgv.Columns(1).HeaderText = "Description"
        dgv.Columns(2).HeaderText = "Category"
        dgv.Columns(3).HeaderText = "Asset Type"
        dgv.Columns(4).HeaderText = "Condition"

    End Sub

    Private Sub AAdetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox2.Text = ""
            TextBox1.Text = ""
            TextBox3.Text = ""
        End If
    End Sub
End Class
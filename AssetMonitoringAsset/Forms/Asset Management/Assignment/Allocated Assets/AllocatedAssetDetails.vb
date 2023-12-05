Public Class AllocatedAssetDetails


    Public emplid As Integer

    Private Sub AllocatedAssetDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Private Sub display()
        dgv.DataSource = InventoryClass.FetchAssetMasterData3(emplid)
    End Sub
End Class
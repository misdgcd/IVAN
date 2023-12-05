Public Class RegisterDetail
    Public entryno As Integer
    Private Sub RegisterDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub

    Private Sub display()
        dgv.DataSource = AllocationDetailClass.Fetchregister1(entryno)
    End Sub
End Class
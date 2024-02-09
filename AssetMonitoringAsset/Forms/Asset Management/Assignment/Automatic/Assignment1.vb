Public Class Assignment1

    Public headerid As Integer
    Private Sub Assignment1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub


    Public Sub display()
        ViewClass.FetchRegisterDetail(headerid)
    End Sub

    Private Sub Assignment1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class
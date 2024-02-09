Public Class Approval

    Public headerid As Integer
    Public ReqType As String = ""

    Private Sub Approval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
        MsgBox(headerid)
    End Sub

    Private Sub display()
        dgv.DataSource = RequestDetailClass.FetchAprrovalDetail(headerid, ReqType)
    End Sub
End Class
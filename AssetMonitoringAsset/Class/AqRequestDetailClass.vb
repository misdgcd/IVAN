
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class AqRequestDetailClass
    Public Shared Function GetAquisitionRequest() As System.Data.Linq.Table(Of tblARequestDetail)
        Return db.GetTable(Of tblARequestDetail)()
    End Function

    Public Shared Sub Save(ByVal assetCode As String, ByVal assetId As Integer, ByVal qty As Double, ByVal headerId As Integer, ByVal status As String)
        Try
            Dim post As Table(Of tblARequestDetail) = AqRequestDetailClass.GetAquisitionRequest
            Dim p As New tblARequestDetail With
                {
                  .AssetId = assetId,
                  .AssetCode = assetCode,
                  .qty = qty,
                  .HeaderId = headerId,
                  .Status = status
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub



End Class

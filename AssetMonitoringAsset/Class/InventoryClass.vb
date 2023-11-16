Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class InventoryClass
    Public Shared Function GetInventory() As System.Data.Linq.Table(Of tblAssetInventory)
        Return db.GetTable(Of tblAssetInventory)()
    End Function

    Public Shared Sub SaveAssetInventory(ByVal AssetId As Integer, ByVal AssetCode As String, ByVal Qty As Double, ByVal ref As String, ByVal refno As String)
        Try
            Dim post As Table(Of tblAssetInventory) = InventoryClass.GetInventory
            Dim p As New tblAssetInventory With
                {
                 .AssetId = AssetId,
                 .AssetCode = AssetCode,
                 .AvailableQuantity = Qty,
                 .UsedQuantity = 0,
                 .TotalQuantity = Qty,
                 .Reference = ref,
                 .ReferenceNUmber = refno
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("ADD Invalid Data...")
        End Try
    End Sub

    Public Shared Sub UpdateInventory(ByVal AssetId As Integer, ByVal Qty As Double, ByVal ref As String)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where (p.AssetId = AssetId) And (p.Reference.Contains(ref))
                              Select p).Single()
            updateStat.AvailableQuantity = updateStat.AvailableQuantity + Qty
        updateStat.TotalQuantity = updateStat.TotalQuantity + Qty
        db.SubmitChanges()

        Catch ex As Exception
        MsgBox("UPDATE Invalid Data...")
        End Try
    End Sub
End Class

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
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub UpdateInventory(ByVal AssetId As Integer, ByVal Qty As Double, ByVal ref As String)
        'Try
        Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                          Where (p.AssetId = AssetId) And (p.Reference.Contains(ref))
                          Select p).Single()
        updateStat.AvailableQuantity = updateStat.AvailableQuantity + Qty
            updateStat.TotalQuantity = updateStat.TotalQuantity + Qty
            db.SubmitChanges()

        'Catch ex As Exception
        '    MsgBox("Invalid Data...2222")
        'End Try
    End Sub


    Public Shared Function ViewInventoryList(ByVal Search As String) As Object

        Dim updateStat = (From p In db.tblAssetInventories
                          Join s In db.tblAssetDetailMasterlists On p.AssetId Equals s.AssetID
                          Where (p.AssetCode.Contains(Search)) Or (s.AssetDescription.Contains(Search) Or (p.ReferenceNUmber.Contains(Search)))
                          Select p.AssetCode, s.AssetDescription, p.AvailableQuantity, p.UsedQuantity, p.TotalQuantity, p.Reference, p.ReferenceNUmber).ToList

        Return updateStat
    End Function




End Class

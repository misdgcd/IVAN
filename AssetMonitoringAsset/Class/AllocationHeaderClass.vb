Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class AllocationHeaderClass
    Public Shared Function GetAllocationHeader() As System.Data.Linq.Table(Of tblAllocationHeader)
        Return db.GetTable(Of tblAllocationHeader)()
    End Function

    Public Shared Sub SaveAssetInventory(ByVal AssetId As Integer, ByVal AssetCode As String, ByVal Qty As Double, ByVal ref As String, ByVal refno As String, ByVal Owner As Integer, ByVal BorrowerStat As String, ByVal Borrower As Integer, ByVal stat As Integer)
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
                 .ReferenceNUmber = refno,
                 .Owner = Owner,
                 .borrowerStat = BorrowerStat,
                 .borrower = Borrower,
                 .Status = stat
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


End Class

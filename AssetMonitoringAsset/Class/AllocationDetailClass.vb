
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class AllocationDetailClass

    Public Shared Function GetAllocationDetail() As System.Data.Linq.Table(Of tblAllocationDetail)
        Return db.GetTable(Of tblAllocationDetail)()
    End Function


    Public Shared Sub SaveAssetAllocation(ByVal AssetID As Integer, ByVal InvID As Integer, ByVal qty As Double, ByVal allocationheaderID As Integer)
        Try
            Dim post As Table(Of tblAllocationDetail) = AllocationDetailClass.GetAllocationDetail
            Dim p As New tblAllocationDetail With
                {
                    .AssetId = AssetID,
                    .InvID = InvID,
                    .qty = qty,
                    .Allocationheaderid = allocationheaderID
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function Fetchregister1(ByVal entryno As Integer) As Object
        Dim querysection = (From s In db.tblAllocationDetails
                            Join g In db.tblAssetDetailMasterlists On s.AssetId Equals g.AssetID
                            Join h In db.tblAssetInventories On s.InvID Equals h.InvID
                            Where s.Allocationheaderid = entryno
                            Select g.AssetCode, g.AssetDescription, h.Reference, h.ReferenceNUmber, s.qty).ToList
        Return querysection
    End Function




End Class

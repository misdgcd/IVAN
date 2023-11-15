﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class AssetDetailClass
    Public Shared Function GetAssetDetail() As System.Data.Linq.Table(Of tblAssetDetail)
        Return db.GetTable(Of tblAssetDetail)()
    End Function


    Public Shared Sub SaveAssetDetail(ByVal assetcode As String, ByVal des As String, ByVal catId As Integer, ByVal typeID As Integer, ByVal ConId As Integer, ByVal TransHeaderId As Integer, ByVal ref As String, ByVal refno As String, ByVal qty As Double, ByVal assetID As Integer)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            Dim post As Table(Of tblAssetDetail) = AssetDetailClass.GetAssetDetail

            Dim p As New tblAssetDetail With
                {
                  .AssetCode = assetcode,
                  .description = des,
                  .categoryID = catId,
                  .assetTypeID = typeID,
                  .AssetConditionID = ConId,
                  .DateCreated = currentdate,
                  .UserID = user,
                  .TransHeaderID = TransHeaderId,
                  .Quantity = qty,
                  .Reference = ref,
                  .Refno = refno,
                  .VendorID = 0,
                  .assetID = assetID
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            'After Insert Load View


        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


End Class

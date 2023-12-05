Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class InventoryClass
    Public Shared Function GetInventory() As System.Data.Linq.Table(Of tblAssetInventory)
        Return db.GetTable(Of tblAssetInventory)()
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

    Public Shared Sub UpdateInventory(ByVal AssetId As Integer, ByVal Qty As Double, ByVal ref As String)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where (p.AssetId = AssetId) And (p.Reference.Contains(ref))
                              Select p).Single()
            updateStat.AvailableQuantity = updateStat.AvailableQuantity + Qty
            updateStat.TotalQuantity = updateStat.TotalQuantity + Qty
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data.")
        End Try
    End Sub


    Public Shared Function ViewInventoryDetails(ByVal Code As String, ByVal search As String, ByVal fltr As String, ByVal fltr1 As String) As Object

        Dim checkeStat = (From p In db.tblAssetInventories
                          Join s In db.tblAssetDetailMasterlists On p.AssetId Equals s.AssetID
                          Join c In db.tblCategories On s.CategoryID Equals c.CategoryID
                          Join i In db.tblAssetTypes On s.AssetTypeID Equals i.AssetTypeID
                          Where (p.AssetCode = Code) And (p.ReferenceNUmber.Contains(search) And (c.CategoryDescription.Contains(fltr) And i.AssetTypeDescription.Contains(fltr1)))
                          Select p.AssetCode, s.AssetDescription, c.CategoryDescription, i.AssetTypeDescription, p.AvailableQuantity, p.UsedQuantity, p.TotalQuantity, p.Reference, p.ReferenceNUmber).ToList
        Return checkeStat
    End Function


    Public Shared Sub ViewInventory(ByVal Search As String, ByVal fltr1 As Integer)
        Try
            With InventoryList
                ''soure for viewing
                .dgv.DataSource = db.spViewInventory(Search, fltr1).ToList

                ''set column name
                .dgv.Columns(0).HeaderText = "Asset Code"
                .dgv.Columns(1).HeaderText = "Description"
                .dgv.Columns(2).HeaderText = "Available Quantity"
                .dgv.Columns(3).HeaderText = "Used Quantity"
                .dgv.Columns(4).HeaderText = "Total Quantity"

                ''set column Width
                ''.dgview.Columns(1).Width = 100
                ''.dgview.Columns(3).Width = 125

                ''datagrid text alignment
                '.dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try


    End Sub


    Public Shared Function FetchAssetMasterData2(ByVal Search As String) As Object
        Dim querysection = (From s In db.tblAssetDetailMasterlists
                            Join p In db.tblCategories On s.CategoryID Equals p.CategoryID
                            Join t In db.tblAssetTypes On s.AssetTypeID Equals t.AssetTypeID
                            Join h In db.tblAssetConditions On s.AssetConditionID Equals h.AssetConditionID
                            Where s.AssetCode.Contains(Search) Or s.AssetDescription.Contains(Search)
                            Select s.AssetCode, s.AssetDescription).ToList
        Return querysection
    End Function


    Public Shared Function ViewInventoryDetails1(ByVal Code As String, ByVal search As String) As Object

        Dim checkeStat = (From p In db.tblAssetInventories
                          Join s In db.tblAssetDetailMasterlists On p.AssetId Equals s.AssetID
                          Join c In db.tblCategories On s.CategoryID Equals c.CategoryID
                          Join i In db.tblAssetTypes On s.AssetTypeID Equals i.AssetTypeID
                          Where ((p.AssetCode = Code) And (p.ReferenceNUmber = search Or search = "") And (p.AvailableQuantity <> 0))
                          Select p.AssetCode, s.AssetDescription, p.AvailableQuantity, p.Reference, p.ReferenceNUmber, p.AssetId, p.InvID).ToList
        Return checkeStat
    End Function


    Public Shared Sub UpdateInventoryStatandQty(ByVal InvID As Integer, ByVal Qty As Double, ByVal Stat As Integer, ByVal owner As Integer)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where (p.InvID = InvID)
                              Select p).Single()

            updateStat.AvailableQuantity = updateStat.AvailableQuantity - Qty
            updateStat.UsedQuantity = updateStat.UsedQuantity + Qty
            updateStat.Status = Stat
            updateStat.Owner = owner
            db.SubmitChanges()

            With Allocation
                MessageBox.Show("Successfully Recorded", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
                .SimpleButton1.Text = "New Allocation"
                .SimpleButton3.Visible = True
            End With

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try
    End Sub


    Public Shared Function Checkqty(ByVal InvID As Integer, ByVal Qty As Double) As Integer
        Dim count As Integer = (From s In db.tblAssetInventories
                                Where s.InvID = InvID And s.AvailableQuantity >= Qty
                                Select s).Count()
        Return count
    End Function


    Public Shared Sub ViewAllocatedAsset(ByVal Search As String)
        Try
            With AllocatedItems
                ''soure for viewing
                .dgview2.DataSource = db.spViewAllocatedItems(Search).ToList

                ''set column name
                .dgview2.Columns(1).HeaderText = "Employee"
                .dgview2.Columns(2).HeaderText = "Allocated Assets"


                '''set column Width
                '.dgview2.Columns(1).Width = 100
                '.dgview2.Columns(2).Width = 125

                .dgview2.Columns(0).Visible = False
                .dgview2.Columns(3).Visible = False
                .dgview2.Columns(4).Visible = False
                .dgview2.Columns(5).Visible = False

                ''datagrid text alignment
                .dgview2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try

    End Sub


    Public Shared Function FetchAssetMasterData3(ByVal EmpID As Integer) As Object
        Dim querysection = (From s In db.tblAssetInventories
                            Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
                            Where s.Owner = EmpID
                            Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, s.borrowerStat).ToList
        Return querysection
    End Function

    Public Shared Function FetchAssetMasterData4(ByVal Search As String, ByVal Stat As String) As Object
        Dim querysection = (From s In db.tblAssetInventories
                            Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
                            Where s.Reference <> "N/A" And (s.borrowerStat = Stat Or Stat = "") And ((s.AssetCode = Search Or Search = "") Or (j.AssetDescription.Contains(Search) Or (s.ReferenceNUmber = Search Or Search = "")))
                            Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, s.borrowerStat, s.InvID).ToList
        Return querysection
    End Function

    Public Shared Function FetchAssetMasterData5(ByVal Search As String) As Object
        Dim querysection = (From s In db.tblAssetInventories
                            Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
                            Where s.borrowerStat <> "Not Allowed" And ((s.AssetCode = Search Or Search = "") Or (s.ReferenceNUmber = Search Or Search = "") Or (j.AssetDescription = Search Or Search = ""))
                            Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, s.borrowerStat).ToList
        Return querysection

    End Function

    Public Shared Function FetchAssetMasterData6(ByVal Search As String) As Object
        Dim querysection = (From s In db.tblAssetInventories
                            Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
                            Join g In db.tblEmployees On s.Owner Equals g.EmployeeID
                            Where ((s.AssetCode = Search Or Search = "") Or (s.ReferenceNUmber = Search Or Search = "") Or (j.AssetDescription = Search Or Search = "")) And (s.Reference <> "N/A")
                            Let em = g.FirstName + " " + g.LastName
                            Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, em, s.borrowerStat).ToList
        Return querysection
    End Function

    Public Shared Sub UpdateBorrower(ByVal InvID As Integer, ByVal BrowerStat As String)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
                              Where (p.InvID = InvID)
                              Select p).Single()
            updateStat.borrowerStat = BrowerStat
            db.SubmitChanges()
        Catch ex As Exception
            MsgBox("Invalid Data.")
        End Try
    End Sub



End Class

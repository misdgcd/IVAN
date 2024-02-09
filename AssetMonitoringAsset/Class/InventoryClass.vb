Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class InventoryClass

    '--------------------------------------------------------------------------------------------
    'Save in tblAssetInventory
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetInventory() As System.Data.Linq.Table(Of tblAssetInventory)
        Return db.GetTable(Of tblAssetInventory)()
    End Function

    Public Shared Sub SaveAssetInventory(ByVal AssetCode As Integer,
                                         ByVal Class1 As String,
                                         ByVal PropertyCode As String,
                                         ByVal Des As String,
                                         ByVal Qty As Double,
                                         ByVal Keeper As Integer,
                                         ByVal Owner As Integer,
                                         ByVal Borrower As Integer,
                                         ByVal Reference As String,
                                         ByVal ReferenceNo As String,
                                         ByVal BorrowerStat As String,
                                         ByVal Status1 As String,
                                         ByVal Status2 As String,
                                         ByVal con As String)
        Try
            Dim post As Table(Of tblAssetInventory) = InventoryClass.GetInventory
            Dim p As New tblAssetInventory With
                {
                .AssetCode = AssetCode,
                .[Class] = Class1,
                .PropertyCode = PropertyCode,
                .Des = Des,
                .Qty = Qty,
                .Keeper = Keeper,
                .Owner = Owner,
                .Borrower = Borrower,
                .Reference = Reference,
                .Referenceno = ReferenceNo,
                .borrowerStat = BorrowerStat,
                .Status1 = Status1,
                .Status2 = Status2,
                .Condition = con
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub



    Public Shared Function ViewInventoryDetails(ByVal AssetCode As Integer) As Object

        Dim vinv = (From p In db.tblAssetInventories
                    Group Join y In db.tblEmployees On p.Keeper Equals y.EmployeeID Into KeeperGroup = Group
                    From y In KeeperGroup.DefaultIfEmpty()
                    Group Join t In db.tblEmployees On p.Owner Equals t.EmployeeID Into OwnerGroup = Group
                    From t In OwnerGroup.DefaultIfEmpty()
                    Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
                    Join h In db.tblBranches On y.BranchID Equals h.BranchID
                    Join l In db.tblSections On y.SectionID Equals l.SectionID
                    Where p.AssetCode = AssetCode
                    Let f = y.LastName + ", " + y.FirstName Let q = t.LastName + ", " + t.FirstName
                    Select p.PropertyCode, p.Des, p.Qty, e.DepartmentDescription, h.BranchDescription, l.SectionDecription, f, q).ToList
        Return vinv

    End Function

    Public Shared Function ViewInventoryDetails1() As Object
        'Dont Delete This Query For Reference
        'Dim vinv = (From p In db.tblAssetInventories
        '            Group Join y In db.tblEmployees On p.Keeper Equals y.EmployeeID Into KeeperGroup = Group
        '            From y In KeeperGroup.DefaultIfEmpty()
        '            Group Join t In db.tblEmployees On p.Owner Equals t.EmployeeID Into OwnerGroup = Group
        '            From t In OwnerGroup.DefaultIfEmpty()
        '            Join e In db.tblDepartments On y.DepartmentID Equals e.DepartmentID
        '            Join h In db.tblBranches On y.BranchID Equals h.BranchID
        '            Join l In db.tblSections On y.SectionID Equals l.SectionID
        '            Join x In db.tblmasterlists On p.AssetCode Equals x.ItemCode
        '            Where (x.CategoryID = "5003") Or (x.CategoryID = "5002")
        '            Let f = y.LastName + ", " + y.FirstName Let q = t.LastName + ", " + t.FirstName
        '            Select p.PropertyCode, p.Des, p.Qty, e.DepartmentDescription, h.BranchDescription, l.SectionDecription, f, q).ToList
        ' vinv
        Dim query = (From q In db.tblAssetInventories
                     Join w In db.tblEmployees On q.Owner Equals w.EmployeeID
                     Join e In db.tblDepartments On w.DepartmentID Equals e.DepartmentID
                     Join r In db.tblBranches On w.BranchID Equals r.BranchID
                     Join t In db.tblSections On w.SectionID Equals t.SectionID
                     Join y In db.tblEmployees On q.Keeper Equals y.EmployeeID
                     Let n = w.FirstName + ", " + w.LastName Let m = y.LastName + ", " + y.FirstName
                     Select q.PropertyCode, q.Des, q.Qty, e.DepartmentDescription, r.BranchDescription, t.SectionDecription, n, m)
        Return query
    End Function


    Public Shared Function FetchAssetMasterData2(ByVal Search As String) As Object
        'Dim querysection = (From s In db.tblAssetDetailMasterlists
        '                    Join p In db.tblCategories On s.CategoryID Equals p.CategoryID
        '                    Join t In db.tblAssetTypes On s.AssetTypeID Equals t.AssetTypeID
        '                    Join h In db.tblAssetConditions On s.AssetConditionID Equals h.AssetConditionID
        '                    Where s.AssetCode.Contains(Search) Or s.AssetDescription.Contains(Search)
        '                    Select s.AssetCode, s.AssetDescription).ToList
        'Return querysection
    End Function


    Public Shared Function ViewInventoryDetails1(ByVal Code As String, ByVal search As String) As Object

        'Dim checkeStat = (From p In db.tblAssetInventories
        '                  Join s In db.tblAssetDetailMasterlists On p.AssetId Equals s.AssetID
        '                  Join c In db.tblCategories On s.CategoryID Equals c.CategoryID
        '                  Join i In db.tblAssetTypes On s.AssetTypeID Equals i.AssetTypeID
        '                  Where ((p.AssetCode = Code) And (p.ReferenceNUmber = search Or search = "") And (p.AvailableQuantity <> 0))
        '                  Select p.AssetCode, s.AssetDescription, p.AvailableQuantity, p.Reference, p.ReferenceNUmber, p.AssetId, p.InvID).ToList
        'Return checkeStat
    End Function


    Public Shared Sub UpdateInventoryStatandQty(ByVal InvID As Integer, ByVal Qty As Double, ByVal Stat As Integer, ByVal owner As Integer)
        'Try
        '    Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
        '                      Where (p.InvID = InvID)
        '                      Select p).Single()

        '    updateStat.AvailableQuantity = updateStat.AvailableQuantity - Qty
        '    updateStat.UsedQuantity = updateStat.UsedQuantity + Qty
        '    updateStat.Status = Stat
        '    updateStat.Owner = owner
        '    db.SubmitChanges()

        '    With Allocation
        '        MessageBox.Show("Successfully Recorded", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        .SimpleButton1.Text = "New Allocation"
        '        .SimpleButton3.Visible = True
        '    End With

        'Catch ex As Exception
        '    MsgBox("Invalid Data. update")
        'End Try
    End Sub


    Public Shared Function Checkqty(ByVal InvID As Integer, ByVal Qty As Double) As Integer
        'Dim count As Integer = (From s In db.tblAssetInventories
        '                        Where s.InvID = InvID And s.AvailableQuantity >= Qty
        '                        Select s).Count()
        'Return count
    End Function


    Public Shared Sub ViewAllocatedAsset(ByVal Search As String)
        'Try
        '    With AllocatedItems
        '        ''soure for viewing
        '        .dgview2.DataSource = db.spViewAllocatedItems(Search).ToList

        '        ''set column name
        '        .dgview2.Columns(1).HeaderText = "Employee"
        '        .dgview2.Columns(2).HeaderText = "Allocated Assets"


        '        '''set column Width
        '        '.dgview2.Columns(1).Width = 100
        '        '.dgview2.Columns(2).Width = 125

        '        .dgview2.Columns(0).Visible = False
        '        .dgview2.Columns(3).Visible = False
        '        .dgview2.Columns(4).Visible = False
        '        .dgview2.Columns(5).Visible = False

        '        ''datagrid text alignment
        '        .dgview2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '    End With
        'Catch ex As Exception
        '    MsgBox("Invalid Data...")
        'End Try

    End Sub


    Public Shared Function FetchAssetMasterData3(ByVal EmpID As Integer) As Object
        'Dim querysection = (From s In db.tblAssetInventories
        '                    Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
        '                    Where s.Owner = EmpID
        '                    Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, s.borrowerStat).ToList
        'Return querysection
    End Function

    Public Shared Function FetchAssetMasterData4(ByVal Search As String, ByVal Stat As String) As Object
        'Dim querysection = (From s In db.tblAssetInventories
        '                    Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
        '                    Where s.Reference <> "N/A" And (s.borrowerStat = Stat Or Stat = "") And ((s.AssetCode = Search Or Search = "") Or (j.AssetDescription.Contains(Search) Or (s.ReferenceNUmber = Search Or Search = "")))
        '                    Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, s.borrowerStat, s.InvID).ToList
        'Return querysection
    End Function

    Public Shared Function FetchAssetMasterData5(ByVal Search As String) As Object
        'Dim querysection = (From s In db.tblAssetInventories
        '                    Join j In db.tblAssetDetailMasterlists On s.AssetId Equals j.AssetID
        '                    Where s.borrowerStat <> "Not Allowed" And ((s.AssetCode = Search Or Search = "") Or (s.ReferenceNUmber = Search Or Search = "") Or (j.AssetDescription = Search Or Search = ""))
        '                    Select s.AssetCode, j.AssetDescription, s.Reference, s.ReferenceNUmber, s.borrowerStat).ToList
        'Return querysection

    End Function


    Public Shared Sub UpdateBorrower(ByVal InvID As Integer, ByVal BrowerStat As String)
        'Try
        '    Dim updateStat = (From p In db.GetTable(Of tblAssetInventory)()
        '                      Where (p.InvID = InvID)
        '                      Select p).Single()
        '    updateStat.borrowerStat = BrowerStat
        '    db.SubmitChanges()
        'Catch ex As Exception
        '    MsgBox("Invalid Data.")
        'End Try
    End Sub




    '--------------------------------------------------------------------------------------------
    'Generate Code then Save in tblPropertyCodeSeries
    '--------------------------------------------------------------------------------------------

    Public Shared Function GetPropertyCode() As System.Data.Linq.Table(Of tblPropertyCodeSery)
        Return db.GetTable(Of tblPropertyCodeSery)()
    End Function

    Public Shared Sub SavePropertyCode(ByVal Cat1 As String,
                                       ByVal Type As String,
                                       ByVal series1 As String)

        Try

            Dim post As Table(Of tblPropertyCodeSery) = InventoryClass.GetPropertyCode
            Dim p As New tblPropertyCodeSery With
                {
             .cat = Cat1,
             .type = Type,
             .series = series1
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try

    End Sub

    '--------------------------------------------------------------------------------------------
    'Fetch Last PropertyCode By Asset Category and Type
    '--------------------------------------------------------------------------------------------

    Public Shared Function FetchPropertyCode(ByVal cat As String, ByVal type As String) As Object
        Dim querysection = (From s In db.tblPropertyCodeSeries
                            Where s.cat = cat And s.type = type
                            Order By s.id Descending
                            Select s.series).FirstOrDefault

        If Not String.IsNullOrEmpty(querysection) Then

            Dim numericalPart As Integer = Integer.Parse(querysection)
            numericalPart += 1
            Dim newAssetNumber As String = numericalPart.ToString("D5")
            Return newAssetNumber

        Else
            Dim ac As String = "00001"
            Return ac
        End If

    End Function

    '--------------------------------------------------------------------------------------------
    'Save To Records in tblBuildDetail
    '--------------------------------------------------------------------------------------------

    Public Shared Function GetBuildDetail() As System.Data.Linq.Table(Of tblBuildDetail)
        Return db.GetTable(Of tblBuildDetail)()
    End Function
    Public Shared Sub SaveBuildDetail(ByVal AssetCode As Integer,
                                        ByVal Class1 As String,
                                        ByVal PropertyCode As String,
                                        ByVal Des As String,
                                        ByVal Qty As Double,
                                        ByVal Keeper As Integer,
                                        ByVal Owner As Integer,
                                        ByVal Borrower As Integer,
                                        ByVal Reference As String,
                                        ByVal ReferenceNo As String,
                                        ByVal BorrowerStat As String,
                                        ByVal Status1 As String,
                                        ByVal Status2 As String,
                                        ByVal con As String,
                                        ByVal HeaderID As Integer)
        Try
            Dim post As Table(Of tblBuildDetail) = InventoryClass.GetBuildDetail
            Dim p As New tblBuildDetail With
                {
                .AssetCode = AssetCode,
                .[Class] = Class1,
                .PropertyCode = PropertyCode,
                .Des = Des,
                .Qty = Qty,
                .Keeper = Keeper,
                .Owner = Owner,
                .Borrower = Borrower,
                .Reference = Reference,
                .Referenceno = ReferenceNo,
                .borrowerStat = BorrowerStat,
                .Status1 = Status1,
                .Status2 = Status2,
                .Condition = con,
                .headerid = HeaderID
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Save To Records in tblBuildHeader
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetBuildHeader() As System.Data.Linq.Table(Of tblBuildHeader)
        Return db.GetTable(Of tblBuildHeader)()
    End Function
    Public Shared Sub SaveBuildHeader(ByVal Entryno As String,
                                      ByVal TransDate As Date,
                                      ByVal Remarks As String,
                                      ByVal Emplyid As Integer)
        Try
            Dim post As Table(Of tblBuildHeader) = InventoryClass.GetBuildHeader
            Dim p As New tblBuildHeader With
                {
            .EntryNumber = Entryno,
            .TransDate = TransDate,
            .Remarks = Remarks,
            .UserID = Emplyid
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Fetch Last Entry Number then Plus 1 in series for new entry Number
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEntryno() As String
        Dim querysection As String = (From s In db.tblBuildHeaders
                                      Order By s.id Descending
                                      Where s.EntryNumber <> ""
                                      Select s.EntryNumber).FirstOrDefault()


        If IsNothing(querysection) Then
            Dim newEntryID As String = "BA" + "-" + Home.Department + "-" + Home.Branch + "-" + Home.Section + "-" + "000001"
            Return newEntryID
        Else
            Dim parts As String() = querysection.Split("-"c)
            Dim lastPart As String = parts(parts.Length - 1)
            Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

            ' Assuming you want the format "000001" for all values, you can use the following format.
            Dim formattedNextNumber As String = nextNumber.ToString("D6")
            Dim newEntryID As String = $"{"BA"}-{Home.Department}-{Home.Branch}-{Home.Section}-{formattedNextNumber}"

            Return newEntryID
        End If
    End Function
    '--------------------------------------------------------------------------------------------
    'display Last save Entry Number
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEntryn1() As String
        Dim querysection As String = (From s In db.tblBuildHeaders
                                      Order By s.id Descending
                                      Where s.EntryNumber <> ""
                                      Select s.EntryNumber).FirstOrDefault()
        Return querysection
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch HeaderID in BUild Assdet Header
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetcHeaderID() As String
        Dim querysection As String = (From s In db.tblBuildHeaders
                                      Order By s.id Descending
                                      Select s.id).FirstOrDefault()
        Return querysection
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch AssetList
    '--------------------------------------------------------------------------------------------
    Public Shared Sub ViewInventory()
        Try
            With InventoryList
                ''soure for viewing
                .dgv.DataSource = db.spViewInventory.ToList

                ''set column name
                .dgv.Columns(0).HeaderText = "Asset Code"
                .dgv.Columns(1).HeaderText = "Description"
                .dgv.Columns(2).HeaderText = "Quantity"

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub
End Class

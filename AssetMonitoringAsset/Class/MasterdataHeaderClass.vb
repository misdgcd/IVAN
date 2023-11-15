Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class MasterdataHeaderClass

    Public Shared Function GetAssetBuildHeader() As System.Data.Linq.Table(Of tblAssetHeaderMasterlist)
        Return db.GetTable(Of tblAssetHeaderMasterlist)()
    End Function


    Public Shared Sub SaveAsset(ByVal entry As String, ByVal remarks As String, ByVal date1 As Date)
        Try

            Dim user As Integer = Home.UserID
            Dim post As Table(Of tblAssetHeaderMasterlist) = MasterdataHeaderClass.GetAssetBuildHeader

            Dim p As New tblAssetHeaderMasterlist With
                {
                  .UserID = user,
                  .EntryNumber = entry,
                  .TransDate = date1,
                  .Remarks = remarks,
                  .VendorID = 1
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            'After Insert Load View

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function FetchEntryID() As String


        Dim querysection As String = (From s In db.tblAssetHeaderMasterlists
                                      Order By s.AssetHeaderID Descending
                                      Where s.EntryNumber <> ""
                                      Select s.EntryNumber).FirstOrDefault()
        If IsNothing(querysection) Then
            Dim newEntryID As String = "NAM" + "-" + Home.Department + "-" + Home.Branch + "-" + Home.Section + "-" + "000001"
            Return newEntryID
        Else
            Dim parts As String() = querysection.Split("-"c)
            Dim lastPart As String = parts(parts.Length - 1)
            Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

            ' Assuming you want the format "000001" for all values, you can use the following format.
            Dim formattedNextNumber As String = nextNumber.ToString("D6")
            Dim newEntryID As String = $"{"NAM"}-{Home.Department}-{Home.Branch}-{Home.Section}-{formattedNextNumber}"

            ' Update the last part in the database, if requireds.
            ' db.tblAssetHeaders.Single().EntryNumber = newEntryIDs
            ' db.SaveChanges()

            Return newEntryID
        End If


        'Dim querysection As String = (From s In db.tblAssetHeaders
        '                              Order By s.AssetHeaderID Descending
        '                              Select s.EntryNumber.Substring(s.EntryNumber.LastIndexOf("-") + 1)).FirstOrDefault()
        'Dim entry As Integer = Integer.Parse(querysection) + 1
        'Dim formattedNextNumber As String = entry.ToString("D6")
        'Dim entryno As String = "N/A" + "-" + Home.Department + "-" + Home.Branch + "-" + Home.Section + "-" + querysection

        'Return entryno
    End Function

    Public Shared Function FetchTransHeaderID() As Integer
        Dim querysection As Integer = (From s In db.tblAssetHeaderMasterlists
                                       Order By s.AssetHeaderID Descending
                                       Select s.AssetHeaderID).FirstOrDefault()
        Return querysection
    End Function


    Public Shared Function FetchDatatoDGV(ByVal entryno As String, ByVal date1 As Date, ByVal date2 As Date) As Object
        Dim querysection = (From s In db.tblAssetHeaderMasterlists
                            Join u In db.tblUsers On s.UserID Equals u.UserID
                            Join j In db.tblEmployees On u.EmployeeID Equals j.EmployeeID
                            Where (s.EntryNumber = entryno Or entryno = "") And (s.TransDate >= date1 AndAlso s.TransDate <= date2)
                            Order By s.AssetHeaderID Ascending
                            Let fl = j.FirstName + " " + j.LastName
                            Select New With {s.TransDate, s.EntryNumber, s.Remarks, fl}).ToList()
        Return querysection
    End Function

    Public Shared Function Fetchregister(ByVal entryno As String) As Object
        Dim querysection = (From s In db.tblAssetHeaderMasterlists
                            Join f In db.tblAssetDetailMasterlists On s.AssetHeaderID Equals f.AssetHeaderID
                            Join c In db.tblCategories On f.CategoryID Equals c.CategoryID
                            Join k In db.tblAssetTypes On f.AssetTypeID Equals k.AssetTypeID
                            Join e In db.tblAssetConditions On f.AssetConditionID Equals e.AssetConditionID
                            Where s.EntryNumber.Contains(entryno)
                            Select f.AssetCode, f.AssetDescription, c.CategoryDescription, k.AssetTypeDescription, e.AssetConditionDescription).ToList()
        Return querysection
    End Function




End Class

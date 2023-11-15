Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class MasterdataDetailsClass

    Public Shared Function GetAssetBuildDetail() As System.Data.Linq.Table(Of tblAssetDetailMasterlist)
        Return db.GetTable(Of tblAssetDetailMasterlist)()
    End Function
    Public Shared Sub SaveAssetDetail(ByVal Ac As String, ByVal Ad As String, ByVal C As Integer, ByVal A As Integer, ByVal Asc As Integer, ByVal TransHeaderId As Integer)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            Dim post As Table(Of tblAssetDetailMasterlist) = MasterdataDetailsClass.GetAssetBuildDetail

            Dim p As New tblAssetDetailMasterlist With
                {
                  .AssetCode = Ac,
                  .AssetDescription = Ad,
                  .CategoryID = C,
                  .AssetTypeID = A,
                  .AssetConditionID = Asc,
                  .DateCreated = currentdate,
                  .DateModified = currentdate,
                  .UserID = user,
                  .UserIDModified = user,
                  .AssetHeaderID = TransHeaderId
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            'After Insert Load View


        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub





    Public Shared Function FetchAc() As Object
        Dim querysection = (From s In db.tblAssetDetailMasterlists
                            Order By s.AssetID Descending
                            Select s.AssetCode).FirstOrDefault()

        If Not String.IsNullOrEmpty(querysection) Then
            Dim codeParts As String() = querysection.Split("-"c)
            If codeParts.Length = 3 AndAlso codeParts(2).Length = 6 AndAlso Integer.TryParse(codeParts(2), Nothing) Then
                Dim numericalPart As Integer = Integer.Parse(codeParts(2))
                numericalPart += 1
                Dim newAssetNumber As String = numericalPart.ToString("D6")
                Return newAssetNumber
            End If

        Else
            Dim ac As String = "000001"
            Return ac
        End If

        ' Return a default value if the above conditions are not met
        Return Nothing
    End Function


    Public Shared Function FetchCatcode(ByVal id As Integer) As String
        Dim querysection = (From s In db.tblCategories
                            Where s.CategoryID = id
                            Select s.CategoryCode).SingleOrDefault
        Return querysection
    End Function

    Public Shared Function FetchTypecode(ByVal id As Integer) As String
        Dim querysection = (From s In db.tblAssetTypes
                            Where s.AssetTypeID = id
                            Select s.AssetTypeCode).SingleOrDefault
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


    Public Shared Function Fetchregister1(ByVal entryno As String) As Object
        Dim querysection = (From s In db.tblAssetHeaderMasterlists
                            Join f In db.tblAssetDetailMasterlists On s.AssetHeaderID Equals f.AssetHeaderID
                            Join c In db.tblCategories On f.CategoryID Equals c.CategoryID
                            Join k In db.tblAssetTypes On f.AssetTypeID Equals k.AssetTypeID
                            Join e In db.tblAssetConditions On f.AssetConditionID Equals e.AssetConditionID
                            Where s.EntryNumber.Contains(entryno)
                            Select f.AssetCode, f.AssetDescription, c.CategoryDescription, k.AssetTypeDescription, e.AssetConditionDescription).ToList()
        Return querysection
    End Function



    Public Shared Function Fetchrlist(ByVal Search As String, ByVal Cat As String, ByVal type As String, ByVal con As String) As Object
        Dim querysection = (From s In db.tblAssetHeaderMasterlists
                            Join f In db.tblAssetDetailMasterlists On s.AssetHeaderID Equals f.AssetHeaderID
                            Join c In db.tblCategories On f.CategoryID Equals c.CategoryID
                            Join k In db.tblAssetTypes On f.AssetTypeID Equals k.AssetTypeID
                            Join e In db.tblAssetConditions On f.AssetConditionID Equals e.AssetConditionID
                            Where (f.AssetDescription.Contains(Search) Or f.AssetCode.Contains(Search)) And (c.CategoryDescription.Contains(Cat)) And (k.AssetTypeDescription.Contains(type)) And (e.AssetConditionDescription.Contains(con))
                            Select f.AssetCode, f.AssetDescription, c.CategoryDescription, k.AssetTypeDescription, e.AssetConditionDescription).ToList()
        Return querysection
    End Function
End Class

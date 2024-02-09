Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class MasterdataDetailsClass

    Public Shared Function GetAssetBuildDetail() As System.Data.Linq.Table(Of tblmasterlist)
        Return db.GetTable(Of tblmasterlist)()
    End Function
    Public Shared Sub SaveAssetDetail(ByVal Ac As String, ByVal Ad As String, ByVal C As Integer, ByVal A As Integer, ByVal Asc As Integer, ByVal TransHeaderId As Integer)
        'Try
        '    Dim user As Integer = Home.UserID
        '    Dim currentdate As Date = DateTime.Now.Date()
        '    Dim post As Table(Of tblAssetDetailMasterlist) = MasterdataDetailsClass.GetAssetBuildDetail

        '    Dim p As New tblAssetDetailMasterlist With
        '        {
        '          .AssetCode = Ac,
        '          .AssetDescription = Ad,
        '          .CategoryID = C,
        '          .AssetTypeID = A,
        '          .AssetConditionID = Asc,
        '          .DateCreated = currentdate,
        '          .DateModified = currentdate,
        '          .UserID = user,
        '          .UserIDModified = user,
        '          .AssetHeaderID = TransHeaderId
        '        }
        '    post.InsertOnSubmit(p)
        '    post.Context.SubmitChanges()
        '    'After Insert Load View


        'Catch ex As Exception
        '    MsgBox("Invalid Data...")
        'End Try
    End Sub

    Public Shared Sub SaveAssetDetail2(ByVal itemcode As String, ByVal des As String, ByVal catid As Integer, ByVal typeid As Integer, ByVal date1 As Date, ByVal date2 As Date, ByVal user1 As Integer, ByVal user2 As Integer, ByVal AH As Integer)
        Try
            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            Dim post As Table(Of tblmasterlist) = MasterdataDetailsClass.GetAssetBuildDetail

            Dim p As New tblmasterlist With
                {
                 .ItemCode = itemcode,
                 .AssetDescription = des,
                 .CategoryID = catid,
                 .AssetTypeID = typeid,
                 .DateCreated = date1,
                 .DateModified = date2,
                 .UserID = user1,
                 .UserIDModified = user2,
                 .AssetHeaderID = AH
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            'After Insert Load View


        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub




    Public Shared Function FetchAc() As Object
        'Dim querysection = (From s In db.tblAssetDetailMasterlists
        '                    Order By s.AssetID Descending
        '                    Select s.AssetCode).FirstOrDefault()

        'If Not String.IsNullOrEmpty(querysection) Then
        '    Dim codeParts As String() = querysection.Split("-"c)
        '    If codeParts.Length = 3 AndAlso codeParts(2).Length = 6 AndAlso Integer.TryParse(codeParts(2), Nothing) Then
        '        Dim numericalPart As Integer = Integer.Parse(codeParts(2))
        '        numericalPart += 1
        '        Dim newAssetNumber As String = numericalPart.ToString("D6")
        '        Return newAssetNumber
        '    End If

        'Else
        '    Dim ac As String = "000001"
        '    Return ac
        'End If

        '' Return a default value if the above conditions are not met
        'Return Nothing
    End Function


    Public Shared Function FetchCatcode(ByVal id As Integer) As String
        'Dim querysection = (From s In db.tblCategories
        '                    Where s.CategoryID = id
        '                    Select s.CategoryCode).SingleOrDefault
        'Return querysection
    End Function

    Public Shared Function FetchTypecode(ByVal id As Integer) As String
        'Dim querysection = (From s In db.tblAssetTypes
        '                    Where s.AssetTypeID = id
        '                    Select s.AssetTypeCode).SingleOrDefault
        'Return querysection
    End Function






    Public Shared Function Fetchmasterdata(ByVal Search As String, ByVal Cat As String, ByVal type As String) As Object
        Dim querysection = (From f In db.tblmasterlists
                            Join c In db.tblCategories On f.CategoryID Equals c.CategoryID
                            Join k In db.tblAssetTypes On f.AssetTypeID Equals k.AssetTypeID
                            Where (f.AssetDescription.Contains(Search) Or f.ItemCode = Search) And (c.CategoryDescription = Cat Or Cat = "") And (k.AssetTypeDescription = type Or type = "")
                            Order By f.AssetDescription Ascending
                            Select f.ItemCode, f.AssetDescription, c.CategoryDescription, k.AssetTypeDescription).ToList()
        Return querysection
    End Function




    Public Shared Function Fetchrlist1(ByVal Search As String) As Object
        Dim querysection = (From f In db.tblmasterlists
                            Join d In db.tblCategories On f.CategoryID Equals d.CategoryID
                            Join g In db.tblAssetTypes On f.AssetTypeID Equals g.AssetTypeID
                            Where f.AssetDescription.Contains(Search)
                            Order By f.AssetDescription Ascending
                            Select f.ItemCode, f.AssetDescription, f.ItemID, d.CategoryCode, g.AssetTypeCode)
        Return querysection
    End Function

End Class

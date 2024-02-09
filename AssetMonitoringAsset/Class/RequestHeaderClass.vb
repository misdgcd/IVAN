Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class RequestHeaderClass

    '--------------------------------------------------------------------------------------------
    'Save in tblRequestHeader
    '--------------------------------------------------------------------------------------------
    Public Shared Function GetAqRequestHeader() As System.Data.Linq.Table(Of tblRequestHeader)
        Return db.GetTable(Of tblRequestHeader)()
    End Function
    Public Shared Sub Save(ByVal reqno As String, ByVal reqby As Integer, ByVal date1 As Date, ByVal stat As String, ByVal rtype As String)
        Try
            Dim post As Table(Of tblRequestHeader) = RequestHeaderClass.GetAqRequestHeader

            Dim p As New tblRequestHeader With
                {
                  .RequestNo = reqno,
                  .RequestBy = reqby,
                  .[Date] = date1,
                  .Stat = stat,
                  .RequestType = rtype,
                  .Stat1 = 0,
                  .Stat2 = 0,
                  .Stat3 = 0,
                  .Stat4 = 0
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    '--------------------------------------------------------------------------------------------
    'Fetch Last Request Number
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchEntryID2() As String
        Dim querysection As String = (From s In db.tblRequestHeaders
                                      Order By s.HeaderId Descending
                                      Where s.RequestNo <> ""
                                      Select s.RequestNo).FirstOrDefault()

        If IsNothing(querysection) Then
            Dim newEntryID As String = "000001"
            Return newEntryID
        Else
            Dim parts As String() = querysection.Split("-"c)
            Dim lastPart As String = parts(parts.Length - 1)
            Dim nextNumber As Integer = Integer.Parse(lastPart) + 1

            ' Assuming you want the format "000001" for all values, you can use the following format.
            Dim formattedNextNumber As String = nextNumber.ToString("D6")
            Dim newEntryID As String = $"{formattedNextNumber}"

            Return newEntryID
        End If
    End Function
    '--------------------------------------------------------------------------------------------
    'Fetch Last HeaderID For Detail in Request
    '--------------------------------------------------------------------------------------------
    Public Shared Function FetchTransHeaderID() As Integer
        Dim querysection As Integer = (From s In db.tblRequestHeaders
                                       Order By s.HeaderId Descending
                                       Select s.HeaderId).FirstOrDefault()

        Return querysection
    End Function
    '--------------------------------------------------------------------------------------------
    'Fetch Requestor
    '--------------------------------------------------------------------------------------------
    Public Shared Function fetchRequestor(ByVal emplID As Integer) As Object
        Dim querysection = (From s In db.tblEmployees
                            Where s.EmployeeID = emplID
                            Let c = s.LastName + ", " + s.FirstName
                            Select c).FirstOrDefault
        Return querysection
    End Function

    '--------------------------------------------------------------------------------------------
    'Fetch Request
    '--------------------------------------------------------------------------------------------
    Public Shared Function fetchRequesttoapprove(ByVal usertype As String) As Object
        If usertype = "ADMIN" Then

            Dim query = (From s In db.tblRequestHeaders
                         Join k In db.tblEmployees On s.RequestBy Equals k.EmployeeID
                         Let c = "Request for " + s.RequestType + " Approval" Let y = k.LastName + ", " + k.FirstName
                         Select c, s.Date, y, s.Stat, s.HeaderId, s.RequestType).ToList
            Return query

        ElseIf usertype = "BPC" Then

            Dim query1 = (From s In db.tblRequestHeaders
                          Join k In db.tblEmployees On s.RequestBy Equals k.EmployeeID
                          Join D In db.tblEmployees On s.RequestBy Equals D.EmployeeID
                          Where (D.BranchID <> "4") And (D.SectionID <> "1026") And (s.RequestType = "Procure")
                          Let c = "Request for " + s.RequestType + " Approval" Let y = k.LastName + ", " + k.FirstName
                          Select c, s.Date, y, s.Stat, s.HeaderId, s.RequestType).ToList
            Return query1

        ElseIf usertype = "DPC" Then

            Dim query1 = (From s In db.tblRequestHeaders
                          Join k In db.tblEmployees On s.RequestBy Equals k.EmployeeID
                          Join D In db.tblEmployees On s.RequestBy Equals D.EmployeeID
                          Where D.SectionID = "4" And D.SectionID = "1026"
                          Let c = "Request for " + s.RequestType + " Approval" Let y = k.LastName + ", " + k.FirstName
                          Select c, s.Date, y, s.Stat, s.HeaderId, s.RequestType).ToList
            Return query1

        ElseIf usertype = "SPC" Then

        ElseIf usertype = "DM" Then

        ElseIf usertype = "BM" Then

        End If


    End Function

    Public Shared Function FetchsRequstRegister() As Object

        Dim query = (From s In db.tblRequestHeaders
                     Join k In db.tblEmployees On s.RequestBy Equals k.EmployeeID
                     Join f In db.tblDepartments On k.DepartmentID Equals f.DepartmentID
                     Join h In db.tblBranches On k.BranchID Equals h.BranchID
                     Join q In db.tblSections On k.SectionID Equals q.SectionID
                     Let y = k.LastName + ", " + k.FirstName
                     Select s.Date, s.RequestNo, s.RequestType, k.Company, f.DepartmentDescription, h.BranchDescription, q.SectionDecription, y, s.Stat, s.HeaderId).ToList
        Return query

    End Function










    Public Shared Sub ViewEmployeeList5(ByVal id As Integer)
        'Dim querysection = (From u In db.tblRequestHeaders
        '                    Join s In db.tblEmployees On u.RequestFor Equals s.EmployeeID
        '                    Join p In db.tblBranches On s.BranchID Equals p.BranchID
        '                    Join l In db.tblDepartments On s.DepartmentID Equals l.DepartmentID
        '                    Join g In db.tblSections On s.SectionID Equals g.SectionID
        '                    Where u.HeaderId = id
        '                    Order By s.EmployeeID
        '                    Select s.EmployeeID, s.FirstName, s.LastName, p.BranchDescription, l.DepartmentDescription, g.SectionDecription, p.BranchID, l.DepartmentID, g.SectionID).FirstOrDefault()


        'With Allocation
        '    .TextBox1.Text = querysection.FirstName + " " + querysection.LastName
        '    '.TextBox2.Text = querysection.DepartmentDescription
        '    '.TextBox3.Text = querysection.BranchDescription
        '    '.TextBox5.Text = querysection.SectionDecription

        '    .branID = querysection.BranchID
        '    .depID = querysection.DepartmentID
        '    .SecID = querysection.SectionID
        '    .EmpID = querysection.EmployeeID

        'End With


    End Sub


    Public Shared Sub ViewRequest2(ByVal HeaderID As Integer)

        With AssetAcquisition

            .dgview.DataSource = db.spViewArequest(HeaderID).ToList

            .dgview.Columns(0).HeaderText = "Asset Code"
            .dgview.Columns(1).HeaderText = "Description"
            .dgview.Columns(2).HeaderText = "Reference"
            .dgview.Columns(3).HeaderText = "Reference No."
            .dgview.Columns(4).HeaderText = "Quantity"

            .dgview.Columns(2).ReadOnly = True
            .dgview.Columns(3).ReadOnly = False

            .dgview.Columns(5).Visible = True


        End With



    End Sub


End Class

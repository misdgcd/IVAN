Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class AllocationHeaderClass
    Public Shared Function GetAllocationHeader() As System.Data.Linq.Table(Of tblAllocationHeader)
        Return db.GetTable(Of tblAllocationHeader)()
    End Function

    Public Shared Sub SaveAssetAllocation(ByVal dep As Integer, ByVal bra As Integer, ByVal sec As Integer, ByVal Date1 As Date, ByVal Entryno As String, ByVal EmpID As Integer, ByVal user As Integer)
        Try
            Dim post As Table(Of tblAllocationHeader) = AllocationHeaderClass.GetAllocationHeader
            Dim p As New tblAllocationHeader With
                {
               .DepartmentId = dep,
               .BranchId = bra,
               .SectionId = sec,
               .Date = Date1,
               .Entrynumber = Entryno,
               .EmployeeID = EmpID,
               .UserID = user
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function FetchEntryID() As String
        Dim querysection As String = (From s In db.tblAllocationHeaders
                                      Order By s.Allocationheaderid Descending
                                      Where s.Entrynumber <> ""
                                      Select s.Entrynumber).FirstOrDefault()

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


    Public Shared Function FetchTransHeaderID() As Integer
        Dim querysection As Integer = (From s In db.tblAllocationHeaders
                                       Order By s.Allocationheaderid Descending
                                       Select s.Allocationheaderid).FirstOrDefault()

        Return querysection
    End Function

    'Public Shared Function FetchOwnder() As Object
    '    Dim querysection = (From s In db.tblAllocationHeaders
    '                        Order By s.Allocationheaderid Descending
    '                        Select s.EmployeeID).SingleOrDefault

    '    Return querysection
    'End Function
End Class

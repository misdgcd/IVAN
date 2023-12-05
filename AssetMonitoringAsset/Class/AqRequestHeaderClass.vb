Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class AqRequestHeaderClass
    Public Shared Function GetAqRequestHeader() As System.Data.Linq.Table(Of tblARequestHeader)
        Return db.GetTable(Of tblARequestHeader)()
    End Function

    Public Shared Sub Save(ByVal reqno As String, ByVal reqby As Integer, ByVal reqfor As Integer, ByVal date1 As Date)
        Try
            Dim post As Table(Of tblARequestHeader) = AqRequestHeaderClass.GetAqRequestHeader

            Dim p As New tblARequestHeader With
                {
                  .RequestNo = reqno,
                  .RequestBy = reqby,
                  .RequestFor = reqfor,
                  .[Date] = date1
                }
            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Function FetchEntryID2() As String
        Dim querysection As String = (From s In db.tblARequestHeaders
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


    Public Shared Function FetchTransHeaderID() As Integer
        Dim querysection As Integer = (From s In db.tblARequestHeaders
                                       Order By s.HeaderId Descending
                                       Select s.HeaderId).FirstOrDefault()

        Return querysection
    End Function


End Class

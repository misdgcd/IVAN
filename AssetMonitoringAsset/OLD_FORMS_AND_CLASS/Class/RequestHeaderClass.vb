﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq
Public Class RequestHeaderClass




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







End Class

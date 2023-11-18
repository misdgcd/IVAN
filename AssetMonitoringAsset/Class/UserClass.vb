﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class UserClass

    Public Shared Function GetUser() As System.Data.Linq.Table(Of tblUser)
        Return db.GetTable(Of tblUser)()
    End Function

    Public Shared Sub SaveUser(ByVal uname As String, ByVal pass As String, ByVal empID As Integer)

        Dim Status As String = "Active"
        Try
            Dim post As Table(Of tblUser) = UserClass.GetUser
            Dim p As New tblUser With
                {
                    .Username = uname,
                    .Password = pass,
                    .EmployeeID = empID,
                    .Status = Status
                }

            post.InsertOnSubmit(p)
            post.Context.SubmitChanges()
            MessageBox.Show("User Account Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            User.viewdg()

            With UserAdd
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Label3.Text = "*"
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub


    Public Shared Sub UpdateUserPass(ByVal id As Integer, ByVal pass As String)

        Try


            'Insert Asset in DB
            db.spUpdateUser(id, pass)
            MessageBox.Show("User Password Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            User.Viewdg()

            With UserChangePass
                .TextBox2.Text = ""
                .Label3.Text = "*"
                .Close()
            End With




        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function FetchUser(ByVal stat As String, Optional ByVal des As String = "", Optional ByVal search As String = "") As Object

        Dim querysection = (From s In db.tblUsers
                            Join d In db.tblEmployees On s.EmployeeID Equals d.EmployeeID
                            Join f In db.tblPositions On d.PositionID Equals f.PositionID
                            Where (s.Status = stat) And f.PositionDescription.Contains(des) And (d.FirstName.Contains(search) Or d.LastName.Contains(search))
                            Order By s.UserID
                            Select s.UserID, d.FirstName, d.LastName, f.PositionDescription, s.Status).ToList()
        Return querysection
    End Function


    Public Shared Sub UpdateUserStat(ByVal Stat As String, ByVal UID As Integer)
        Try
            Dim updateStat = (From p In db.GetTable(Of tblUser)()
                              Where p.UserID = UID
                              Select p).SingleOrDefault()
            updateStat.Status = Stat
            db.SubmitChanges()
            MessageBox.Show("User Status Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            With UserUpdate
                .Label3.Text = "*"
                .Close()
            End With
            With User
                .Viewdg()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function CountUsername(ByVal uname As String) As Integer
        Dim queryBook = (From p In db.tblUsers
                         Where (p.Username = uname)
                         Select p.Username).Count

        Return queryBook
    End Function

    Public Shared Function CountUserEmployee(ByVal EID As Integer) As Integer
        Dim queryBook = (From p In db.tblUsers
                         Where (p.EmployeeID = EID)
                         Select p.EmployeeID).Count

        Return queryBook
    End Function


    Public Shared Function FetchLogin(ByVal uname As String, ByVal pass As String) As Integer
        Dim queryBook = (From p In db.tblUsers
                         Where (p.Username = uname And p.Password = pass)
                         Select p.Username, p.Password).Count
        Return queryBook
    End Function


    Public Shared Function FetcBranch(ByVal uname As String, ByVal pass As String) As String
        Dim querydetail = (From p In db.tblUsers
                           Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                           Join b In db.tblBranches On b.BranchID Equals e.BranchID
                           Where (p.Username = uname And p.Password = pass)
                           Select b.BranchCode).Single


        Return querydetail

    End Function

    Public Shared Function FetcDepartment(ByVal uname As String, ByVal pass As String) As String
        Dim querydetail = (From p In db.tblUsers
                           Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                           Join d In db.tblDepartments On d.DepartmentID Equals e.DepartmentID
                           Where (p.Username = uname And p.Password = pass)
                           Select d.DepartmentCode).Single

        Return querydetail

    End Function


    Public Shared Function FetcSection(ByVal uname As String, ByVal pass As String) As String
        Dim querydetail = (From p In db.tblUsers
                           Join e In db.tblEmployees On e.EmployeeID Equals p.EmployeeID
                           Join s In db.tblSections On s.SectionID Equals e.SectionID
                           Where (p.Username = uname And p.Password = pass)
                           Select s.SectionCode).Single
        Return querydetail

    End Function

    Public Shared Function FetcUserID(ByVal uname As String, ByVal pass As String) As Integer
        Dim querydetail = (From p In db.tblUsers
                           Where (p.Username = uname And p.Password = pass)
                           Select p.UserID).Single
        Return querydetail

    End Function

End Class

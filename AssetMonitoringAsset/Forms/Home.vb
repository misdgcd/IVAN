﻿Public Class Home

    Public UserID As Integer
    Public Branch As String = ""
    Public Department As String = ""
    Public Section As String = ""
    Public noti1 As Integer
    Public UserType As String = ""

    Public EmployeeID As Integer
    Public DepartmentID As Integer
    Public BranchID As Integer
    Public SectionID As Integer


    Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
        AssetType.ShowDialog()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AccordionControlElement5_Click(sender As Object, e As EventArgs) Handles AccordionControlElement5.Click
        AssetCategory.ShowDialog()
    End Sub

    Private Sub AccordionControlElement6_Click(sender As Object, e As EventArgs) Handles AccordionControlElement6.Click
        AssetCondition.ShowDialog()
    End Sub

    Private Sub AccordionControlElement7_Click(sender As Object, e As EventArgs) Handles AccordionControlElement7.Click
        AssetSection.ShowDialog()
    End Sub

    Private Sub AccordionControlElement8_Click(sender As Object, e As EventArgs) Handles AccordionControlElement8.Click
        AssetBranch.ShowDialog()
    End Sub

    Private Sub AccordionControlElement9_Click(sender As Object, e As EventArgs) Handles AccordionControlElement9.Click
        AssetDepartment.ShowDialog()
    End Sub

    Private Sub AccordionControlElement10_Click(sender As Object, e As EventArgs) Handles AccordionControlElement10.Click
        AssetPosition.ShowDialog()
    End Sub

    Private Sub AccordionControlElement11_Click(sender As Object, e As EventArgs) Handles AccordionControlElement11.Click
        AssetDocumentType.ShowDialog()
    End Sub

    Private Sub AccordionControlElement12_Click(sender As Object, e As EventArgs) Handles AccordionControlElement12.Click
        Vendor.ShowDialog()
    End Sub

    Private Sub AccordionControlElement13_Click(sender As Object, e As EventArgs) Handles AccordionControlElement13.Click
        Employee.ShowDialog()
    End Sub

    Private Sub AccordionControlElement14_Click(sender As Object, e As EventArgs) Handles AccordionControlElement14.Click
        User.ShowDialog()
    End Sub

    Private Sub AccordionControlElement25_Click(sender As Object, e As EventArgs) Handles AccordionControlElement25.Click
          NewAsset.ShowDialog()
    End Sub

    Private Sub AccordionControlElement17_Click(sender As Object, e As EventArgs) Handles AccordionControlElement17.Click
        BuildAsset.ShowDialog()
    End Sub

    Private Sub AccordionControlElement28_Click(sender As Object, e As EventArgs) Handles AccordionControlElement28.Click
        NewAssetRegister.ShowDialog()
    End Sub

    Private Sub AccordionControlElement29_Click(sender As Object, e As EventArgs) Handles AccordionControlElement29.Click
        MasterDataList.ShowDialog()
    End Sub

    Private Sub AccordionControlElement30_Click(sender As Object, e As EventArgs) Handles AccordionControlElement30.Click
        Reference.ShowDialog()
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Show()
    End Sub

    Private Sub AccordionControlElement39_Click(sender As Object, e As EventArgs) Handles AccordionControlElement39.Click
        InventoryList.ShowDialog()
    End Sub

    Private Sub AccordionControlElement35_Click(sender As Object, e As EventArgs) Handles e.Click
        With Assignment1
            .allowtoaddrow = "Y"
        End With

        Assignment1.ShowDialog()
    End Sub

    Private Sub AccordionControlElement45_Click(sender As Object, e As EventArgs) Handles AccordionControlElement45.Click
        importmasterlist.ShowDialog()
    End Sub

    Private Sub AccordionControlElement38_Click(sender As Object, e As EventArgs) Handles AccordionControlElement38.Click
        Request.ShowDialog()
    End Sub

    Private Sub AccordionControlElement46_Click(sender As Object, e As EventArgs) Handles AccordionControlElement46.Click
        RequestRegister.ShowDialog()
    End Sub
End Class
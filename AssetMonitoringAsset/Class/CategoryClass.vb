Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.Linq

Public Class CategoryClass

    Public Shared Function GetAssetCategory() As System.Data.Linq.Table(Of tblCategory)
        Return db.GetTable(Of tblCategory)()
    End Function

    Public Shared Sub SaveCategory(ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spNewCategory(ATC.ToUpper, StrConv(ATD, VbStrConv.ProperCase), currentdate, currentdate, user, user)
            MessageBox.Show("Asset Category Successfully Recorded.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View
            AssetCategory.ViewCategory()

            With AssetCategoryAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Sub ViewCategory(ByVal Search As String)
        Try

            With AssetCategory

                'soure for viewing
                .dgview.DataSource = db.spViewCategory(Search).ToList
                'hide column 0
                .dgview.Columns(0).Visible = False

                'set column name
                .dgview.Columns(1).HeaderText = "Asset Category Code"
                .dgview.Columns(2).HeaderText = "Description"
                .dgview.Columns(3).HeaderText = "Date Modified"

                'set column Width
                '.dgview.Columns(1).Width = 100
                '.dgview.Columns(3).Width = 125

                'datagrid text alignment
                .dgview.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            End With
        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try


    End Sub

    Public Shared Sub UpdateCategory(ByVal typeid As Integer, ByVal ATC As String, ByVal ATD As String)
        Try

            Dim user As Integer = Home.UserID
            Dim currentdate As Date = DateTime.Now.Date()
            'Insert Asset in DB
            db.spUpdateCategory(typeid, StrConv(ATD, VbStrConv.ProperCase), currentdate, user, ATC.ToUpper)
            MessageBox.Show("Asset Category Successfully Updated.", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'After Insert Load View



            With AssetCategory
                .ViewCategory()
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
            End With

            With AssetCategoryAddandUpdate1
                .TextBox1.Text = String.Empty
                .TextBox2.Text = String.Empty
                .Close()
            End With

        Catch ex As Exception
            MsgBox("Invalid Data...")
        End Try
    End Sub

    Public Shared Function ViewNaCategory(ByVal search As String) As Object

        Dim querysection = (From s In db.tblCategories
                            Where ((s.CategoryCode.Contains(search) Or s.CategoryDescription.Contains(search)) Or search = "")
                            Order By s.CategoryID
                            Select s.CategoryID, s.CategoryCode, s.CategoryDescription).ToList
        Return querysection
    End Function

    Public Shared Function ViewCboxCat() As List(Of String)

        Dim querysection = (From s In db.tblCategories
                            Order By s.CategoryID
                            Select s.CategoryDescription).ToList
        Return querysection
    End Function

End Class

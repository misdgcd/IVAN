Public Class AcquisitionRequest


    Public branID As Integer
    Public depID As Integer
    Public SecID As Integer
    Public EmpID As Integer

    Private Sub AcquisitionRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        display()

    End Sub


    Public Sub display()
        TextBox1.Text = AqRequestHeaderClass.FetchEntryID2
        TextBox2.Text = UserClass.FetcUserfandlname(Home.UserID)

        dgv.Columns.Add("0", "Asset Code")
        dgv.Columns.Add("1", "Asset Description")
        dgv.Columns.Add("2", "Quantity")
        dgv.Columns.Add("3", "assetID")
        'GETS THE VALUE ID'

        dgv.Columns(0).ReadOnly = True
        dgv.Columns(1).ReadOnly = True
        dgv.Columns(2).ReadOnly = False

        dgv.Columns(0).Width = 250
        dgv.Columns(1).Width = 525
        dgv.Columns(2).Width = 200

        dgv.Columns(3).Visible = False

        dgv.Rows.Clear()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        Dim row As Integer = dgv.CurrentCell.RowIndex
        If e.ColumnIndex = 0 Then
            AssetList3.rowToEdit = row
            AssetList3.ShowDialog()
        End If

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        EmployeeList2.mods = 4
        EmployeeList2.ShowDialog()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click


        AqRequestHeaderClass.Save(TextBox1.Text, Home.UserID, EmpID, DateTimePicker1.Value)
        Dim Stat As String = "Pending"


        For Each row As DataGridViewRow In dgv.Rows

            If Not row.IsNewRow Then

                Dim headid As Integer = AqRequestHeaderClass.FetchTransHeaderID

                Dim AssetCode As String = row.Cells(0).Value.ToString
                Dim Des As String = row.Cells(1).Value.ToString
                Dim qty As String = row.Cells(2).Value.ToString
                Dim assetid As String = row.Cells(3).Value.ToString

                AqRequestDetailClass.Save(AssetCode, Integer.Parse(assetid), Double.Parse(qty), headid, Stat)

            End If
        Next

        TextBox2.Text = String.Empty
        TextBox4.Text = String.Empty
        TextBox5.Text = String.Empty
        TextBox6.Text = String.Empty
        TextBox7.Text = String.Empty
        DateTimePicker1.Value = Date.Now
        dgv.Rows.Clear()
        MessageBox.Show("Successfully Recorded", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AcquisitionRequest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub
End Class
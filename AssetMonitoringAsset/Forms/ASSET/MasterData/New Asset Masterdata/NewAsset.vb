Public Class NewAsset
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        NAcategory.Show()
    End Sub

    Private Sub NewAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Displaydg()

    End Sub

    Public Sub Displaydg()

        dgview.AllowUserToAddRows = True
        DateTimePicker1.Value = DateTime.Now.Date()
        Label2.Text = MasterdataHeaderClass.FetchEntryID

        dgview.Columns.Add("0", "Asset Code")
        dgview.Columns.Add("1", "Asset Description")
        dgview.Columns.Add("2", "Categories")
        dgview.Columns.Add("3", "Asset Type")
        dgview.Columns.Add("4", "Condition")

        'GETS THE VALUE ID'
        dgview.Columns.Add("5", "CatID")
        dgview.Columns.Add("6", "AssTypeID")
        dgview.Columns.Add("7", "ConID")


        dgview.Columns(5).Visible = False
        dgview.Columns(6).Visible = False
        dgview.Columns(7).Visible = False

        dgview.Columns(0).ReadOnly = True
        dgview.Columns(2).ReadOnly = True
        dgview.Columns(3).ReadOnly = True
        dgview.Columns(4).ReadOnly = True

        dgview.Rows.Clear()
    End Sub

    Private Sub Dgview_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgview.CellDoubleClick
        Dim row As Integer = dgview.CurrentCell.RowIndex
        If e.ColumnIndex = 2 Then
            NAcategory.rowToEdit = row
            NAcategory.ShowDialog()

        ElseIf e.ColumnIndex = 3 Then
            NATypeh.rowToEdit = row
            NATypeh.ShowDialog()

        ElseIf e.ColumnIndex = 4 Then
            NACondition.rowToEdit = row
            NACondition.ShowDialog()

        End If
    End Sub

    Private Sub NewAsset_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            dgview.Rows.Clear()
            dgview.Columns.Clear()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Try
            MasterdataHeaderClass.SaveAsset(Label2.Text, TextBox1.Text, DateTimePicker1.Value)

            For Each row As DataGridViewRow In dgview.Rows

                If Not row.IsNewRow Then

                    Dim TransHeaderID As Integer = MasterdataHeaderClass.FetchTransHeaderID
                    Dim sc As String = row.Cells(0).Value.ToString
                    Dim ad As String = row.Cells(1).Value.ToString
                    Dim ci As String = row.Cells(5).Value.ToString
                    Dim ti As String = row.Cells(6).Value.ToString
                    Dim c As String = row.Cells(7).Value.ToString
                    MasterdataDetailsClass.SaveAssetDetail(sc, ad, Integer.Parse(ci), Integer.Parse(ti), Integer.Parse(c), TransHeaderID)
                End If
            Next
            TextBox1.Text = String.Empty
            Label2.Text = String.Empty
            fordgvclearing()
            Displaydg()
            MsgBox("Successfully Recorded...")

        Catch ex As Exception
            MessageBox.Show("Invalid Entry, Please Check blank Cells...", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub fordgvclearing()
        dgview.Rows.Clear()
        dgview.Columns.Clear()
    End Sub

    Private Sub Dgview_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgview.RowValidating

        If e.ColumnIndex = 4 Then
            Try

                Dim row As Integer = dgview.CurrentCell.RowIndex


                Dim catcode As String = ""
                Dim typecode As String = ""

                If dgview.Rows(row).Cells(5).Value IsNot Nothing Then
                    catcode = MasterdataDetailsClass.FetchCatcode(Integer.Parse(dgview.Rows(row).Cells(5).Value.ToString))
                End If

                If dgview.Rows(row).Cells(6).Value IsNot Nothing Then
                    typecode = MasterdataDetailsClass.FetchTypecode(Integer.Parse(dgview.Rows(row).Cells(6).Value.ToString))
                End If
                Dim ac As String = MasterdataDetailsClass.FetchAc.ToString

                If e.RowIndex = 0 Then

                    dgview.Rows(e.RowIndex).Cells(0).Value = catcode + "-" + typecode + "-" + ac
                Else


                    Dim previousValue As String = dgview.Rows(e.RowIndex - 1).Cells(0).Value.ToString()

                    Dim numericPart As String = previousValue.Substring(previousValue.LastIndexOf("-"c) + 1)

                    Dim numericValue As Integer = Integer.Parse(numericPart) + 1

                    Dim result As String = numericValue.ToString("D6") ' This will ensure the format is preserved

                    dgview.Rows(e.RowIndex).Cells(0).Value = catcode + "-" + typecode + "-" + result


                End If




            Catch ex As Exception

            End Try
        End If


    End Sub


    Private Sub NewAsset_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub dgview_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgview.CellValidating

        If e.ColumnIndex = 1 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Description")
            SimpleButton1.Enabled = False
        ElseIf e.ColumnIndex = 2 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Category")
            SimpleButton1.Enabled = False
        ElseIf e.ColumnIndex = 3 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Asset Type")
            SimpleButton1.Enabled = False
        ElseIf e.ColumnIndex = 4 AndAlso String.IsNullOrWhiteSpace(e.FormattedValue.ToString()) Then
            MsgBox("Invalid Condition")
            SimpleButton1.Enabled = False
        Else
            SimpleButton1.Enabled = True
        End If
    End Sub
End Class
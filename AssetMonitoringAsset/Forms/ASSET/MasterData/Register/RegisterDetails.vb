Imports Microsoft.Reporting.WinForms

Public Class RegisterDetails

    Public entry As String = String.Empty
    Private Sub RegisterDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewdgv()
    End Sub
    Public Shared Property selectedrow2 As DataGridViewRow
    Public Sub viewdgv()
        dgv.DataSource = MasterdataHeaderClass.Fetchregister(entry)

        dgv.Columns(0).HeaderText = "Asset Code"
        dgv.Columns(1).HeaderText = "Description"
        dgv.Columns(2).HeaderText = "Category"
        dgv.Columns(3).HeaderText = "Asset Type"
        dgv.Columns(4).HeaderText = "Condition"

    End Sub

    Private Sub RegisterDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            TextBox2.Text = ""
            TextBox1.Text = ""
            TextBox3.Text = ""
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim datatable1 As DataTable
        Dim dataset As New DataSet("Dataset")

        datatable1 = New DataTable("Mydatatable")
        datatable1.Columns.Add("AssetCode")
        datatable1.Columns.Add("AssetDescription")
        datatable1.Columns.Add("CategoryDescription")
        datatable1.Columns.Add("AssetTypeDescription")
        datatable1.Columns.Add("AssetConditionDescription")

        dataset.Tables.Add(datatable1)
        For Each row As DataGridViewRow In dgv.Rows
            If Not row.IsNewRow Then
                Dim datarow2 As DataRow = datatable1.NewRow
                datarow2("AssetCode") = row.Cells(0).Value.ToString
                datarow2("AssetDescription") = row.Cells(1).Value.ToString
                datarow2("CategoryDescription") = row.Cells(2).Value.ToString
                datarow2("AssetTypeDescription") = row.Cells(3).Value.ToString
                datarow2("AssetConditionDescription") = row.Cells(4).Value.ToString

                datatable1.Rows.Add(datarow2)
            End If
        Next

        Dim reportDataSource As New ReportDataSource("DataSet1", datatable1)
        view.ReportViewer1.LocalReport.DataSources.Clear()
        view.ReportViewer1.LocalReport.DataSources.Add(reportDataSource)
        view.ReportViewer1.LocalReport.ReportPath = "C:\Users\HSDP_SYS_DEV\source\repos\AssetMonitoringAsset\AssetMonitoringAsset\Forms\ASSET\MasterData\Register\Report1.rdlc"

        Dim par As New ReportParameter("Entryno", "Entry Number: " + TextBox1.Text)
        view.ReportViewer1.LocalReport.SetParameters(par)

        view.ReportViewer1.RefreshReport()

        view.ShowDialog()
    End Sub
End Class
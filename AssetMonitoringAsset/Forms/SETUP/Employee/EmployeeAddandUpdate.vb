Public Class EmployeeAddandUpdate

    Public branID As String = ""
    Public SecID As String = ""
    Public DepID As String = ""
    Public PosID As String = ""
    Public updateID As Integer
    Private Sub EmployeeAddandUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Sectioncb()
        Poscb()
        Depcb()
        Brcb()
    End Sub

    Private Sub Sectioncb()
        ComboBox3.DataSource = SectionClass.ViewCboxSection
    End Sub

    Private Sub Depcb()
        ComboBox2.DataSource = DepartmentClass.ViewCboxDepartment
    End Sub

    Private Sub Poscb()
        ComboBox4.DataSource = PositionClass.ViewCboxPosition
    End Sub

    Private Sub Brcb()
        ComboBox1.DataSource = BranchClass.ViewCboxBranch
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid First Name...")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Last Name...")
        Else
            If SimpleButton1.Text = "Record" Then
                If EmployeeClass.FetchEmCount(TextBox1.Text, TextBox2.Text) > 0 Then
                    MessageBox.Show("Employee Already Exist", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    EmployeeClass.SaveEmployee(TextBox1.Text, TextBox2.Text, Integer.Parse(branID), Integer.Parse(DepID), Integer.Parse(PosID), Integer.Parse(SecID))
                End If

            ElseIf SimpleButton1.Text = "Save" Then
                EmployeeClass.UpdateEmployee(updateID, TextBox1.Text, TextBox2.Text, Integer.Parse(branID), Integer.Parse(DepID), Integer.Parse(PosID), Integer.Parse(SecID))
            End If
        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        branID = BranchClass.FetchBranchID(ComboBox1.Text).ToString()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        DepID = DepartmentClass.FetchDepartmentID(ComboBox2.Text).ToString()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        PosID = PositionClass.FetchPositionID(ComboBox4.Text).ToString()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        SecID = SectionClass.FetchSectionID(ComboBox3.Text).ToString()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

    End Sub

    Private Sub EmployeeAddandUpdate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            If SimpleButton2.Text = "Save" Then
            Else
                TextBox1.Text = String.Empty
                TextBox2.Text = String.Empty
            End If

        End If
    End Sub
End Class
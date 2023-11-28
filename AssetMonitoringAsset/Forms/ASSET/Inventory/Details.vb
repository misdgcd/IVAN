Public Class Details

    Public code As String = ""
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        display()
    End Sub



    Public Sub display()
        dgv.DataSource = InventoryClass.ViewInventoryDetails(code, TextBox1.Text, ComboBox1.Text, ComboBox2.Text)
    End Sub

    Private Sub Details_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If RadioButton6.Checked = True Then
            ComboBox1.DataSource = Nothing
            ComboBox1.Enabled = False
            RadioButton5.Checked = False
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            ComboBox1.DataSource = CategoryClass.ViewCboxCat()
            RadioButton6.Checked = False
            ComboBox1.Enabled = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ComboBox2.DataSource = Nothing
            ComboBox2.Enabled = False
            RadioButton1.Checked = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ComboBox2.DataSource = TypeClass.ViewCboxtype()
            RadioButton2.Checked = False
            ComboBox2.Enabled = True
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        display()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        display()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        display()
    End Sub

    Private Sub Details_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        RadioButton6.Checked = True
        RadioButton2.Checked = True
        TextBox1.Text = String.Empty
    End Sub
End Class
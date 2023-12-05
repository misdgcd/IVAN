Public Class AllocationUpdate
    Public InvID As Integer
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click

        If ComboBox1.Text = String.Empty Then
            MessageBox.Show("Invalid Status", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            InventoryClass.UpdateBorrower(InvID, ComboBox1.Text)
        End If

        MessageBox.Show("Successfully Updated", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information)
        With AssetStatus
            .disply()
        End With

        TextBox1.Text = String.Empty
        TextBox2.Text = String.Empty
        TextBox3.Text = String.Empty
        TextBox4.Text = String.Empty
        Me.Close()
    End Sub
End Class
Public Class AssetSectionAddandUpdate1
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Asset Section Code")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Asset Section Description")
        Else
            If SimpleButton2.Text = "Record" Then
                SectionClass.SaveSection(TextBox1.Text, TextBox2.Text)
            ElseIf SimpleButton2.Text = "Save" Then
                SectionClass.UpdateSection(AssetSection.SecID, TextBox1.Text, TextBox2.Text)
            End If

        End If
    End Sub
End Class
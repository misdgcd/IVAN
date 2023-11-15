Public Class Login
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click




        If TextBox1.Text = String.Empty Then
            MsgBox("Invalid Username...")
        ElseIf TextBox2.Text = String.Empty Then
            MsgBox("Invalid Password...")
        Else
            If UserClass.FetchLogin(TextBox1.Text, TextBox2.Text) = 0 Then
                MsgBox("Invalid User Account...")
            ElseIf UserClass.FetchLogin(TextBox1.Text, TextBox2.Text) = 1 Then
                loaddetails()
                Home.Show()
            Else
                MsgBox("Multiple Account is Not Permitted...Please Contact SPU")
            End If
        End If

        Me.Hide()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Public Sub loaddetails()
        With Home
            .Branch = UserClass.FetcBranch(TextBox1.Text, TextBox2.Text)
            .Department = UserClass.FetcDepartment(TextBox1.Text, TextBox2.Text)
            .Section = UserClass.FetcSection(TextBox1.Text, TextBox2.Text)
            .UserID = UserClass.FetcUserID(TextBox1.Text, TextBox2.Text)
        End With
    End Sub
End Class
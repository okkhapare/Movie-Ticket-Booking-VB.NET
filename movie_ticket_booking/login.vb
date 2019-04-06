Imports System.Data.OleDb

Public Class login

    Private Sub login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conn()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TextBox1.Text = "" Then
            MsgBox("Enter Username", MsgBoxStyle.Critical)
        ElseIf TextBox2.Text = "" Then
            MsgBox("Enter Password", MsgBoxStyle.Critical)
        ElseIf ComboBox1.SelectedItem = "" Then
            MsgBox("Select Administrator/Employee", MsgBoxStyle.Critical)
        Else
            Dim str As String
            str = "select * from emp_table where emp_name='" + TextBox1.Text + "' and pass='" + TextBox2.Text + "'and emp_type='" + ComboBox1.SelectedItem + "'"
            cmd = New OleDbCommand(str, cn)
            da = New OleDbDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("Login Failed - Enter Valid ID and Password", MsgBoxStyle.Critical)
            ElseIf ComboBox1.SelectedItem = "Administrator" Then
                Me.Hide()
                MessageBox.Show("Admin Logged In")
                cn.Close()
                Home.Show()
                TextBox2.Clear()
            ElseIf ComboBox1.SelectedItem = "Employee" Then
                Me.Hide()
                MessageBox.Show("Employee Logged In")
                cn.Close()
                Home.Show()
                Home.AddMovieToolStripMenuItem.Visible = False
                Home.RemoveMovieToolStripMenuItem.Visible = False
                Home.ReportToolStripMenuItem.Visible = False
                TextBox2.Clear()
            End If
        End If
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If TextBox3.Text = "" Then
            MsgBox("Enter Username", MsgBoxStyle.Critical)
        ElseIf TextBox4.Text = "" Then
            MsgBox("Enter Password", MsgBoxStyle.Critical)
        ElseIf ComboBox2.SelectedItem = "" Then
            MsgBox("Select Administrator/Employee", MsgBoxStyle.Critical)
        ElseIf TextBox5.Text = "" Then
            MsgBox("Confirm Password", MsgBoxStyle.Critical)
        ElseIf TextBox4.Text = TextBox5.Text Then

            str = "Insert into emp_table([emp_name],[pass],[confirm_pass],[emp_type]) Values (?,?,?,?)"
            cmd = New OleDbCommand(str, cn)
            cmd.Parameters.Add(New OleDbParameter("emp_name", CType(TextBox3.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("pass", CType(TextBox4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("confirm_pass", CType(TextBox5.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("emp_type", ComboBox2.SelectedItem))

            Try
                cmd.ExecuteNonQuery()
                MessageBox.Show("Successfully Registered", "System")
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                ComboBox2.SelectedItem = ""
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            TextBox4.Clear()
            TextBox5.Clear()
        Else
            MessageBox.Show("Password does not match", "Error")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

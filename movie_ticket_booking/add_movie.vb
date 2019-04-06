Imports System.Data.OleDb

Public Class add_movie

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Enter Movie Name", MsgBoxStyle.Critical)
        ElseIf TextBox5.Text = "" Then
            MsgBox("Enter Basic Rate", MsgBoxStyle.Critical)
        ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False Then
            MsgBox("At least select one slot to book", MsgBoxStyle.Critical)
        End If

        Dim mov_id_temp As Integer

        If DateTimePicker1.Value.Date <= DateTimePicker2.Value.Date And DateTimePicker2.Value.Date <= DateTimePicker3.Value.Date Then
            str = "Insert into movie([movie_id],[movie_name],[actor],[actress],[director],[release_date],[start_show_date],[end_show_date],[basic_rate]) Values (?,?,?,?,?,?,?,?,?)"
            cmd = New OleDbCommand(str, cn)
            cmd.Parameters.Add(New OleDbParameter("movie_id", CType(TextBox6.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("movie_name", CType(TextBox1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("actor", CType(TextBox2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("actress", CType(TextBox3.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("director", CType(TextBox4.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("release_date", CType(DateTimePicker1.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("start_show_date", CType(DateTimePicker2.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("end_show_date", CType(DateTimePicker3.Text, String)))
            cmd.Parameters.Add(New OleDbParameter("basic_rate", CType(TextBox5.Text, String)))
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            If CheckBox1.Checked = True Then
                mov_id_temp = TextBox6.Text
                cmd1 = New OleDbCommand("Insert into show values (1,'07:00 am - 9:30 am','" & mov_id_temp & "')", cn)
                cmd1.ExecuteNonQuery()
            End If

            If CheckBox2.Checked = True Then
                mov_id_temp = TextBox6.Text
                cmd1 = New OleDbCommand("Insert into show values (2,'10:00 am - 12:30 pm','" & mov_id_temp & "')", cn)
                cmd1.ExecuteNonQuery()
            End If

            If CheckBox3.Checked = True Then
                mov_id_temp = TextBox6.Text
                cmd1 = New OleDbCommand("Insert into show values (3,'01:00 pm - 3:30 pm','" & mov_id_temp & "')", cn)
                cmd1.ExecuteNonQuery()
            End If

            If CheckBox4.Checked = True Then
                mov_id_temp = TextBox6.Text
                cmd1 = New OleDbCommand("Insert into show values (4,'04:00 pm - 6:30 pm','" & mov_id_temp & "')", cn)
                cmd1.ExecuteNonQuery()
            End If

            If CheckBox5.Checked = True Then
                mov_id_temp = TextBox6.Text
                cmd1 = New OleDbCommand("Insert into show values (5,'07:00 pm - 9:30 pm','" & mov_id_temp & "')", cn)
                cmd1.ExecuteNonQuery()
            End If

            If CheckBox6.Checked = True Then
                mov_id_temp = TextBox6.Text
                cmd1 = New OleDbCommand("Insert into show values (6,'10:00 pm - 12:30 am','" & mov_id_temp & "')", cn)
                cmd1.ExecuteNonQuery()
            End If

            MessageBox.Show("ok")

        Else
            MsgBox("Start Date is always greater than Release Date, also Last Date cannot be before Start Date")
        End If

        Try
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            DateTimePicker1.Value = System.DateTime.Today
            DateTimePicker2.Value = System.DateTime.Today
            DateTimePicker3.Value = System.DateTime.Today
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim daTemp1 As New OleDbDataAdapter
        Dim dsTemp1 As New DataSet
        Dim sql

        sql = "select max(movie_id) from movie"
        daTemp1 = New OleDbDataAdapter(sql, cn)
        dsTemp1.Clear()
        daTemp1.Fill(dsTemp1)
        If IsDBNull(dsTemp1.Tables(0).Rows(0).Item(0)) Then
            TextBox6.Text = 1
        Else
            TextBox6.Text = dsTemp1.Tables(0).Rows(0).Item(0) + 1
        End If
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged

        Dim dt As New DataTable
        Dim dt1 As New DataTable

        Dim r As DataRow
        Dim r1 As DataRow

        da.SelectCommand = New OleDbCommand("SELECT * FROM movie", cn)
        da.Fill(dt)

        da1.SelectCommand = New OleDbCommand("SELECT * FROM show", cn)
        da1.Fill(dt1)

        Dim i As Integer = 0
        Dim j As Integer = 0

        For Each r In dt.Rows
            i = i + 1
            For Each r1 In dt1.Rows
                j = j + 1
                If DateTimePicker2.Value.Date <= r("start_show_date") And DateTimePicker3.Value.Date >= r("end_show_date") Then

                    If r1("movie_id") = j And r1("show_id") = 1 Then
                        CheckBox1.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 2 Then
                        CheckBox2.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 3 Then
                        CheckBox3.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 4 Then
                        CheckBox4.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 5 Then
                        CheckBox5.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 6 Then
                        CheckBox6.Hide()
                    End If

                End If

                If DateTimePicker2.Value.Date <= r("start_show_date") And DateTimePicker3.Value.Date >= r("start_show_date") And DateTimePicker3.Value.Date < r("end_show_date") Then

                    If r1("movie_id") = j And r1("show_id") = 1 Then
                        CheckBox1.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 2 Then
                        CheckBox2.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 3 Then
                        CheckBox3.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 4 Then
                        CheckBox4.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 5 Then
                        CheckBox5.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 6 Then
                        CheckBox6.Hide()
                    End If
                End If

                If DateTimePicker2.Value.Date >= r("start_show_date") And DateTimePicker2.Value.Date <= r("end_show_date") And DateTimePicker3.Value.Date > r("end_show_date") Then
                    If r1("movie_id") = j And r1("show_id") = 1 Then
                        CheckBox1.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 2 Then
                        CheckBox2.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 3 Then
                        CheckBox3.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 4 Then
                        CheckBox4.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 5 Then
                        CheckBox5.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 6 Then
                        CheckBox6.Hide()
                    End If
                End If

                If DateTimePicker2.Value.Date >= r("start_show_date") And DateTimePicker3.Value.Date <= r("end_show_date") Then
                    If r1("movie_id") = j And r1("show_id") = 1 Then
                        CheckBox1.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 2 Then
                        CheckBox2.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 3 Then
                        CheckBox3.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 4 Then
                        CheckBox4.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 5 Then
                        CheckBox5.Hide()
                    End If

                    If r1("movie_id") = j And r1("show_id") = 6 Then
                        CheckBox6.Hide()
                    End If
                End If

                If DateTimePicker2.Value.Date <= r("start_show_date") And DateTimePicker3.Value.Date <= r("start_show_date") Then
                    CheckBox1.Visible = True
                    CheckBox2.Visible = True
                    CheckBox3.Visible = True
                    CheckBox4.Visible = True
                    CheckBox5.Visible = True
                    CheckBox6.Visible = True
                End If

                If DateTimePicker2.Value.Date >= r("end_show_date") And DateTimePicker3.Value.Date >= r("end_show_date") Then
                    CheckBox1.Visible = True
                    CheckBox2.Visible = True
                    CheckBox3.Visible = True
                    CheckBox4.Visible = True
                    CheckBox5.Visible = True
                    CheckBox6.Visible = True
                End If
            Next
        Next
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        DateTimePicker1.Value = System.DateTime.Today
        DateTimePicker2.Value = System.DateTime.Today
        DateTimePicker3.Value = System.DateTime.Today
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox1.Show()
        CheckBox2.Show()
        CheckBox3.Show()
        CheckBox4.Show()
        CheckBox5.Show()
        CheckBox6.Show()
    End Sub

    Private Sub add_movie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conn()
    End Sub
End Class
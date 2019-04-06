Imports System.Data.OleDb

Public Class book_ticket

    Private Sub book_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call conn()
        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter("select movie_name from movie", cn)
        Dim ds As New DataSet
        da.Fill(ds, "1")

        'adding movie in combobox1
        For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
            Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
        Next

    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click

        If ComboBox1.SelectedItem <> "" And ListBox1.Text <> "" Then
            Try
                payment.TextBox1.Text = TextBox1.Text
                payment.TextBox2.Text = ComboBox1.SelectedItem
                payment.TextBox4.Text = DateTimePicker1.Value.Date
                payment.TextBox5.Text = ListBox1.SelectedItem

                Dim daTemp1 As New OleDbDataAdapter
                Dim dsTemp1 As New DataSet
                Dim sql

                sql = "select max(ticket_id) from ticket"
                daTemp1 = New OleDbDataAdapter(sql, cn)
                dsTemp1.Clear()
                daTemp1.Fill(dsTemp1)
                If IsDBNull(dsTemp1.Tables(0).Rows(0).Item(0)) Then
                    payment.TextBox7.Text = 1
                Else
                    payment.TextBox7.Text = dsTemp1.Tables(0).Rows(0).Item(0) + 1
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            payment.TextBox6.Text = count
            payment.TextBox6.Visible = False
            payment.Show()
            count = 0

        Else
            MsgBox("Please select all the values", MsgBoxStyle.Critical)
        End If

    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        Me.Close()
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        count = 0
        ListBox1.Items.Clear()
        ComboBox1.Text = ""
        TextBox1.Text = ""
        Button1.BackColor = DefaultBackColor()
        Button2.BackColor = DefaultBackColor()
        Button3.BackColor = DefaultBackColor()
        Button4.BackColor = DefaultBackColor()
        Button5.BackColor = DefaultBackColor()
        Button6.BackColor = DefaultBackColor()
        Button7.BackColor = DefaultBackColor()
        Button8.BackColor = DefaultBackColor()
        Button9.BackColor = DefaultBackColor()
        Button10.BackColor = DefaultBackColor()
        Button11.BackColor = DefaultBackColor()
        Button12.BackColor = DefaultBackColor()
        Button13.BackColor = DefaultBackColor()
        Button14.BackColor = DefaultBackColor()
        Button15.BackColor = DefaultBackColor()
        Button16.BackColor = DefaultBackColor()
        Button17.BackColor = DefaultBackColor()
        Button18.BackColor = DefaultBackColor()
        Button19.BackColor = DefaultBackColor()
        Button20.BackColor = DefaultBackColor()
        Button21.BackColor = DefaultBackColor()
        Button22.BackColor = DefaultBackColor()
        Button23.BackColor = DefaultBackColor()
        Button24.BackColor = DefaultBackColor()
        Button25.BackColor = DefaultBackColor()
        Button26.BackColor = DefaultBackColor()
        Button27.BackColor = DefaultBackColor()
        Button28.BackColor = DefaultBackColor()
        Button29.BackColor = DefaultBackColor()
        Button30.BackColor = DefaultBackColor()
        Button31.BackColor = DefaultBackColor()
        Button32.BackColor = DefaultBackColor()
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        Button10.Enabled = True
        Button11.Enabled = True
        Button12.Enabled = True
        Button13.Enabled = True
        Button14.Enabled = True
        Button15.Enabled = True
        Button16.Enabled = True
        Button17.Enabled = True
        Button18.Enabled = True
        Button19.Enabled = True
        Button20.Enabled = True
        Button21.Enabled = True
        Button22.Enabled = True
        Button23.Enabled = True
        Button24.Enabled = True
        Button25.Enabled = True
        Button26.Enabled = True
        Button27.Enabled = True
        Button28.Enabled = True
        Button29.Enabled = True
        Button30.Enabled = True
        Button31.Enabled = True
        Button32.Enabled = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.Items.Clear()

        Dim da, da1, da2 As New OleDbDataAdapter
        Dim dt, dt1, dt2 As New DataTable

        da = New OleDbDataAdapter("select * from movie ", cn)
        da.Fill(dt)
        For Each r In dt.Rows
            If r("movie_name") = ComboBox1.Text Then
                TextBox1.Text = r("movie_id")
            End If
        Next

        da1 = New OleDbDataAdapter("select * from show ", cn)
        da1.Fill(dt1)
        For Each r1 In dt1.Rows
            If r1("movie_id") = TextBox1.Text Then
                ListBox1.Items.Add(r1("show_id"))
            End If
        Next

        da2 = New OleDbDataAdapter("select * from movie ", cn)
        da2.Fill(dt2)
        For Each r In dt.Rows
            If r("movie_id") = TextBox1.Text Then
                DateTimePicker1.MinDate = r("start_show_date")
                DateTimePicker1.MaxDate = r("end_show_date")
            End If
        Next

    End Sub

    Dim count As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 1 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A1"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A1"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A1"
        End If

        Button1.BackColor = Color.Green

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 2 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A2"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A2"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A2"
        End If

        Button2.BackColor = Color.Green
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 3 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A3"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A3"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A3"
        End If

        Button3.BackColor = Color.Green
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 4 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A4"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A4"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A4"
        End If

        Button4.BackColor = Color.Green
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 5 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A5"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A5"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A5"
        End If

        Button5.BackColor = Color.Green
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 6 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A6"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A6"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A6"
        End If

        Button6.BackColor = Color.Green
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 7 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A7"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A7"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A7"
        End If

        Button7.BackColor = Color.Green
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 8 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "A8"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "A"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "A8"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", A8"
        End If

        Button8.BackColor = Color.Green
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 9 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B1"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B1"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B1"
        End If

        Button9.BackColor = Color.Green
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 10 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B2"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B2"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B2"
        End If

        Button10.BackColor = Color.Green
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 11 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B3"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B3"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B3"
        End If

        Button11.BackColor = Color.Green
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 12 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B4"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B4"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B4"
        End If

        Button12.BackColor = Color.Green
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 13 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B5"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B5"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B5"
        End If

        Button13.BackColor = Color.Green

    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 14 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B6"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B6"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B6"
        End If

        Button14.BackColor = Color.Green
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 15 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B7"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B7"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B7"
        End If

        Button15.BackColor = Color.Green
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 16 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "B8"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "B"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "B8"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", B8"
        End If

        Button16.BackColor = Color.Green
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 17 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C1"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C1"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C1"
        End If

        Button17.BackColor = Color.Green
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 18 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C2"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C2"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C2"
        End If

        Button18.BackColor = Color.Green
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 19 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C3"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C3"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C3"
        End If

        Button19.BackColor = Color.Green
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 20 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C4"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C4"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C4"
        End If

        Button20.BackColor = Color.Green
    End Sub
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 21 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C5"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C5"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C5"
        End If

        Button21.BackColor = Color.Green
    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 22 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C6"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C6"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C6"
        End If

        Button22.BackColor = Color.Green
    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 23 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C7"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C7"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C7"
        End If

        Button23.BackColor = Color.Green
    End Sub
    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 24 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "C8"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "C"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "C8"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", C8"
        End If

        Button24.BackColor = Color.Green
    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 25 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D1"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D1"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D1"
        End If

        Button25.BackColor = Color.Green
    End Sub
    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 26 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D2"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D2"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D2"
        End If

        Button26.BackColor = Color.Green
    End Sub
    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 27 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D3"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D3"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D3"
        End If

        Button27.BackColor = Color.Green
    End Sub
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 28 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D4"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D4"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D4"
        End If

        Button28.BackColor = Color.Green
    End Sub
    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 29 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D5"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D5"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D5"
        End If

        Button29.BackColor = Color.Green
    End Sub
    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 30 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D6"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D6"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D6"
        End If

        Button30.BackColor = Color.Green
    End Sub
    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 31 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D7"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D7"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D7"
        End If

        Button31.BackColor = Color.Green
    End Sub
    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click

        Dim r2 As DataRow
        Dim dt2 As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM seat", cn)
        da.Fill(dt2)

        For Each r2 In dt2.Rows
            If r2("seat_id") = 32 And r2("booked_seat") = 0 Then
                str = "Insert into seat([seat_id],[seat_name],[seat_row],[booked_date],[booked_seat],[show_id],[movie_id]) Values (?,?,?,?,?,?,?)"
                cmd = New OleDbCommand(str, cn)
                cmd.Parameters.Add(New OleDbParameter("seat_id", r2("seat_id")))
                cmd.Parameters.Add(New OleDbParameter("seat_name", "D8"))
                cmd.Parameters.Add(New OleDbParameter("seat_row", "D"))
                cmd.Parameters.Add(New OleDbParameter("booked_date", DateTimePicker1.Text))
                cmd.Parameters.Add(New OleDbParameter("booked_seat", 1))
                cmd.Parameters.Add(New OleDbParameter("show_id", ListBox1.SelectedItem))
                cmd.Parameters.Add(New OleDbParameter("movie_id", TextBox1.Text))
                cmd.ExecuteNonQuery()
                count = count + 1
            End If
        Next

        If payment.TextBox3.Text = "" Then
            payment.TextBox3.Text = "D8"
        Else
            payment.TextBox3.Text = payment.TextBox3.Text + ", D8"
        End If

        Button32.BackColor = Color.Green
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim da As New OleDbDataAdapter("select * from seat", cn)
        Dim dt3 As New DataTable
        da.Fill(dt3)

        For Each r3 In dt3.Rows
            If ListBox1.SelectedItem = "1" Then
                If r3("seat_id") = 1 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button1.BackColor = Color.Green
                    Button1.Enabled = False
                End If

                If r3("seat_id") = 2 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button2.BackColor = Color.Green
                    Button2.Enabled = False
                End If
                If r3("seat_id") = 3 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button3.BackColor = Color.Green
                    Button3.Enabled = False
                End If
                If r3("seat_id") = 4 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button4.BackColor = Color.Green
                    Button4.Enabled = False
                End If
                If r3("seat_id") = 5 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button5.BackColor = Color.Green
                    Button5.Enabled = False
                End If
                If r3("seat_id") = 6 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button6.BackColor = Color.Green
                    Button6.Enabled = False
                End If
                If r3("seat_id") = 7 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button7.BackColor = Color.Green
                    Button7.Enabled = False
                End If
                If r3("seat_id") = 8 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button8.BackColor = Color.Green
                    Button8.Enabled = False
                End If
                If r3("seat_id") = 9 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button9.BackColor = Color.Green
                    Button9.Enabled = False
                End If
                If r3("seat_id") = 10 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button10.BackColor = Color.Green
                    Button10.Enabled = False
                End If
                If r3("seat_id") = 11 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button11.BackColor = Color.Green
                    Button11.Enabled = False
                End If
                If r3("seat_id") = 12 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button12.BackColor = Color.Green
                    Button12.Enabled = False
                End If
                If r3("seat_id") = 13 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button13.BackColor = Color.Green
                    Button13.Enabled = False
                End If
                If r3("seat_id") = 14 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button14.BackColor = Color.Green
                    Button14.Enabled = False
                End If
                If r3("seat_id") = 15 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button15.BackColor = Color.Green
                    Button15.Enabled = False
                End If
                If r3("seat_id") = 16 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = (TextBox1.Text) Then
                    Button16.BackColor = Color.Green
                    Button16.Enabled = False
                End If
                If r3("seat_id") = 17 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button17.BackColor = Color.Green
                    Button17.Enabled = False
                End If
                If r3("seat_id") = 18 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button18.BackColor = Color.Green
                    Button18.Enabled = False
                End If
                If r3("seat_id") = 19 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button19.BackColor = Color.Green
                    Button19.Enabled = False
                End If
                If r3("seat_id") = 20 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button20.BackColor = Color.Green
                    Button20.Enabled = False
                End If
                If r3("seat_id") = 21 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button21.BackColor = Color.Green
                    Button21.Enabled = False
                End If
                If r3("seat_id") = 22 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button22.BackColor = Color.Green
                    Button22.Enabled = False
                End If
                If r3("seat_id") = 23 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button23.BackColor = Color.Green
                    Button23.Enabled = False
                End If
                If r3("seat_id") = 24 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button24.BackColor = Color.Green
                    Button24.Enabled = False
                End If
                If r3("seat_id") = 25 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button25.BackColor = Color.Green
                    Button25.Enabled = False
                End If
                If r3("seat_id") = 26 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button26.BackColor = Color.Green
                    Button26.Enabled = False
                End If
                If r3("seat_id") = 27 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button27.BackColor = Color.Green
                    Button27.Enabled = False
                End If
                If r3("seat_id") = 28 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button28.BackColor = Color.Green
                    Button28.Enabled = False
                End If
                If r3("seat_id") = 29 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button29.BackColor = Color.Green
                    Button29.Enabled = False
                End If
                If r3("seat_id") = 30 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button30.BackColor = Color.Green
                    Button30.Enabled = False
                End If
                If r3("seat_id") = 31 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button31.BackColor = Color.Green
                    Button31.Enabled = False
                End If
                If r3("seat_id") = 32 And r3("booked_seat") = 1 And r3("show_id") = 1 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button32.BackColor = Color.Green
                    Button32.Enabled = False
                End If
            End If

            If ListBox1.SelectedItem = "2" Then
                If r3("seat_id") = 1 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button1.BackColor = Color.Green
                    Button1.Enabled = False
                End If

                If r3("seat_id") = 2 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button2.BackColor = Color.Green
                    Button2.Enabled = False
                End If
                If r3("seat_id") = 3 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button3.BackColor = Color.Green
                    Button3.Enabled = False
                End If
                If r3("seat_id") = 4 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button4.BackColor = Color.Green
                    Button4.Enabled = False
                End If
                If r3("seat_id") = 5 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button5.BackColor = Color.Green
                    Button5.Enabled = False
                End If
                If r3("seat_id") = 6 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button6.BackColor = Color.Green
                    Button6.Enabled = False
                End If
                If r3("seat_id") = 7 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button7.BackColor = Color.Green
                    Button7.Enabled = False
                End If
                If r3("seat_id") = 8 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button8.BackColor = Color.Green
                    Button8.Enabled = False
                End If
                If r3("seat_id") = 9 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button9.BackColor = Color.Green
                    Button9.Enabled = False
                End If
                If r3("seat_id") = 10 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button10.BackColor = Color.Green
                    Button10.Enabled = False
                End If
                If r3("seat_id") = 11 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button11.BackColor = Color.Green
                    Button11.Enabled = False
                End If
                If r3("seat_id") = 12 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button12.BackColor = Color.Green
                    Button12.Enabled = False
                End If
                If r3("seat_id") = 13 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button13.BackColor = Color.Green
                    Button13.Enabled = False
                End If
                If r3("seat_id") = 14 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button14.BackColor = Color.Green
                    Button14.Enabled = False
                End If
                If r3("seat_id") = 15 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button15.BackColor = Color.Green
                    Button15.Enabled = False
                End If
                If r3("seat_id") = 16 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button16.BackColor = Color.Green
                    Button16.Enabled = False
                End If
                If r3("seat_id") = 17 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button17.BackColor = Color.Green
                    Button17.Enabled = False
                End If
                If r3("seat_id") = 18 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button18.BackColor = Color.Green
                    Button18.Enabled = False
                End If
                If r3("seat_id") = 19 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button19.BackColor = Color.Green
                    Button19.Enabled = False
                End If
                If r3("seat_id") = 20 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button20.BackColor = Color.Green
                    Button20.Enabled = False
                End If
                If r3("seat_id") = 21 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button21.BackColor = Color.Green
                    Button21.Enabled = False
                End If
                If r3("seat_id") = 22 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button22.BackColor = Color.Green
                    Button22.Enabled = False
                End If
                If r3("seat_id") = 23 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button23.BackColor = Color.Green
                    Button23.Enabled = False
                End If
                If r3("seat_id") = 24 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button24.BackColor = Color.Green
                    Button24.Enabled = False
                End If
                If r3("seat_id") = 25 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button25.BackColor = Color.Green
                    Button25.Enabled = False
                End If
                If r3("seat_id") = 26 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button26.BackColor = Color.Green
                    Button26.Enabled = False
                End If
                If r3("seat_id") = 27 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button27.BackColor = Color.Green
                    Button27.Enabled = False
                End If
                If r3("seat_id") = 28 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button28.BackColor = Color.Green
                    Button28.Enabled = False
                End If
                If r3("seat_id") = 29 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button29.BackColor = Color.Green
                    Button29.Enabled = False
                End If
                If r3("seat_id") = 30 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button30.BackColor = Color.Green
                    Button30.Enabled = False
                End If
                If r3("seat_id") = 31 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button31.BackColor = Color.Green
                    Button31.Enabled = False
                End If
                If r3("seat_id") = 32 And r3("booked_seat") = 1 And r3("show_id") = 2 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button32.BackColor = Color.Green
                    Button32.Enabled = False
                End If
            End If

            If ListBox1.SelectedItem = "3" Then
                If r3("seat_id") = 1 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button1.BackColor = Color.Green
                    Button1.Enabled = False
                End If

                If r3("seat_id") = 2 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button2.BackColor = Color.Green
                    Button2.Enabled = False
                End If
                If r3("seat_id") = 3 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button3.BackColor = Color.Green
                    Button3.Enabled = False
                End If
                If r3("seat_id") = 4 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button4.BackColor = Color.Green
                    Button4.Enabled = False
                End If
                If r3("seat_id") = 5 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button5.BackColor = Color.Green
                    Button5.Enabled = False
                End If
                If r3("seat_id") = 6 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button6.BackColor = Color.Green
                    Button6.Enabled = False
                End If
                If r3("seat_id") = 7 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button7.BackColor = Color.Green
                    Button7.Enabled = False
                End If
                If r3("seat_id") = 8 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button8.BackColor = Color.Green
                    Button8.Enabled = False
                End If
                If r3("seat_id") = 9 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button9.BackColor = Color.Green
                    Button9.Enabled = False
                End If
                If r3("seat_id") = 10 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button10.BackColor = Color.Green
                    Button10.Enabled = False
                End If
                If r3("seat_id") = 11 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button11.BackColor = Color.Green
                    Button11.Enabled = False
                End If
                If r3("seat_id") = 12 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button12.BackColor = Color.Green
                    Button12.Enabled = False
                End If
                If r3("seat_id") = 13 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button13.BackColor = Color.Green
                    Button13.Enabled = False
                End If
                If r3("seat_id") = 14 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button14.BackColor = Color.Green
                    Button14.Enabled = False
                End If
                If r3("seat_id") = 15 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button15.BackColor = Color.Green
                    Button15.Enabled = False
                End If
                If r3("seat_id") = 16 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button16.BackColor = Color.Green
                    Button16.Enabled = False
                End If
                If r3("seat_id") = 17 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button17.BackColor = Color.Green
                    Button17.Enabled = False
                End If
                If r3("seat_id") = 18 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button18.BackColor = Color.Green
                    Button18.Enabled = False
                End If
                If r3("seat_id") = 19 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button19.BackColor = Color.Green
                    Button19.Enabled = False
                End If
                If r3("seat_id") = 20 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button20.BackColor = Color.Green
                    Button20.Enabled = False
                End If
                If r3("seat_id") = 21 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button21.BackColor = Color.Green
                    Button21.Enabled = False
                End If
                If r3("seat_id") = 22 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button22.BackColor = Color.Green
                    Button22.Enabled = False
                End If
                If r3("seat_id") = 23 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button23.BackColor = Color.Green
                    Button23.Enabled = False
                End If
                If r3("seat_id") = 24 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button24.BackColor = Color.Green
                    Button24.Enabled = False
                End If
                If r3("seat_id") = 25 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button25.BackColor = Color.Green
                    Button25.Enabled = False
                End If
                If r3("seat_id") = 26 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button26.BackColor = Color.Green
                    Button26.Enabled = False
                End If
                If r3("seat_id") = 27 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button27.BackColor = Color.Green
                    Button27.Enabled = False
                End If
                If r3("seat_id") = 28 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button28.BackColor = Color.Green
                    Button28.Enabled = False
                End If
                If r3("seat_id") = 29 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button29.BackColor = Color.Green
                    Button29.Enabled = False
                End If
                If r3("seat_id") = 30 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button30.BackColor = Color.Green
                    Button30.Enabled = False
                End If
                If r3("seat_id") = 31 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button31.BackColor = Color.Green
                    Button31.Enabled = False
                End If
                If r3("seat_id") = 32 And r3("booked_seat") = 1 And r3("show_id") = 3 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button32.BackColor = Color.Green
                    Button32.Enabled = False
                End If
            End If

            If ListBox1.SelectedItem = "4" Then
                If r3("seat_id") = 1 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button1.BackColor = Color.Green
                    Button1.Enabled = False
                End If

                If r3("seat_id") = 2 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button2.BackColor = Color.Green
                    Button2.Enabled = False
                End If
                If r3("seat_id") = 3 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button3.BackColor = Color.Green
                    Button3.Enabled = False
                End If
                If r3("seat_id") = 4 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button4.BackColor = Color.Green
                    Button4.Enabled = False
                End If
                If r3("seat_id") = 5 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button5.BackColor = Color.Green
                    Button5.Enabled = False
                End If
                If r3("seat_id") = 6 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button6.BackColor = Color.Green
                    Button6.Enabled = False
                End If
                If r3("seat_id") = 7 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button7.BackColor = Color.Green
                    Button7.Enabled = False
                End If
                If r3("seat_id") = 8 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button8.BackColor = Color.Green
                    Button8.Enabled = False
                End If
                If r3("seat_id") = 9 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button9.BackColor = Color.Green
                    Button9.Enabled = False
                End If
                If r3("seat_id") = 10 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button10.BackColor = Color.Green
                    Button10.Enabled = False
                End If
                If r3("seat_id") = 11 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button11.BackColor = Color.Green
                    Button11.Enabled = False
                End If
                If r3("seat_id") = 12 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button12.BackColor = Color.Green
                    Button12.Enabled = False
                End If
                If r3("seat_id") = 13 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button13.BackColor = Color.Green
                    Button13.Enabled = False
                End If
                If r3("seat_id") = 14 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button14.BackColor = Color.Green
                    Button14.Enabled = False
                End If
                If r3("seat_id") = 15 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button15.BackColor = Color.Green
                    Button15.Enabled = False
                End If
                If r3("seat_id") = 16 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button16.BackColor = Color.Green
                    Button16.Enabled = False
                End If
                If r3("seat_id") = 17 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button17.BackColor = Color.Green
                    Button17.Enabled = False
                End If
                If r3("seat_id") = 18 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button18.BackColor = Color.Green
                    Button18.Enabled = False
                End If
                If r3("seat_id") = 19 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button19.BackColor = Color.Green
                    Button19.Enabled = False
                End If
                If r3("seat_id") = 20 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button20.BackColor = Color.Green
                    Button20.Enabled = False
                End If
                If r3("seat_id") = 21 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button21.BackColor = Color.Green
                    Button21.Enabled = False
                End If
                If r3("seat_id") = 22 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button22.BackColor = Color.Green
                    Button22.Enabled = False
                End If
                If r3("seat_id") = 23 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button23.BackColor = Color.Green
                    Button23.Enabled = False
                End If
                If r3("seat_id") = 24 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button24.BackColor = Color.Green
                    Button24.Enabled = False
                End If
                If r3("seat_id") = 25 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button25.BackColor = Color.Green
                    Button25.Enabled = False
                End If
                If r3("seat_id") = 26 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button26.BackColor = Color.Green
                    Button26.Enabled = False
                End If
                If r3("seat_id") = 27 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button27.BackColor = Color.Green
                    Button27.Enabled = False
                End If
                If r3("seat_id") = 28 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button28.BackColor = Color.Green
                    Button28.Enabled = False
                End If
                If r3("seat_id") = 29 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button29.BackColor = Color.Green
                    Button29.Enabled = False
                End If
                If r3("seat_id") = 30 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button30.BackColor = Color.Green
                    Button30.Enabled = False
                End If
                If r3("seat_id") = 31 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button31.BackColor = Color.Green
                    Button31.Enabled = False
                End If
                If r3("seat_id") = 32 And r3("booked_seat") = 1 And r3("show_id") = 4 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button32.BackColor = Color.Green
                    Button32.Enabled = False
                End If
            End If

            If ListBox1.SelectedItem = "5" Then
                If r3("seat_id") = 1 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button1.BackColor = Color.Green
                    Button1.Enabled = False
                End If

                If r3("seat_id") = 2 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button2.BackColor = Color.Green
                    Button2.Enabled = False
                End If
                If r3("seat_id") = 3 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button3.BackColor = Color.Green
                    Button3.Enabled = False
                End If
                If r3("seat_id") = 4 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button4.BackColor = Color.Green
                    Button4.Enabled = False
                End If
                If r3("seat_id") = 5 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button5.BackColor = Color.Green
                    Button5.Enabled = False
                End If
                If r3("seat_id") = 6 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button6.BackColor = Color.Green
                    Button6.Enabled = False
                End If
                If r3("seat_id") = 7 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button7.BackColor = Color.Green
                    Button7.Enabled = False
                End If
                If r3("seat_id") = 8 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button8.BackColor = Color.Green
                    Button8.Enabled = False
                End If
                If r3("seat_id") = 9 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button9.BackColor = Color.Green
                    Button9.Enabled = False
                End If
                If r3("seat_id") = 10 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button10.BackColor = Color.Green
                    Button10.Enabled = False
                End If
                If r3("seat_id") = 11 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button11.BackColor = Color.Green
                    Button11.Enabled = False
                End If
                If r3("seat_id") = 12 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button12.BackColor = Color.Green
                    Button12.Enabled = False
                End If
                If r3("seat_id") = 13 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button13.BackColor = Color.Green
                    Button13.Enabled = False
                End If
                If r3("seat_id") = 14 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button14.BackColor = Color.Green
                    Button14.Enabled = False
                End If
                If r3("seat_id") = 15 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button15.BackColor = Color.Green
                    Button15.Enabled = False
                End If
                If r3("seat_id") = 16 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button16.BackColor = Color.Green
                    Button16.Enabled = False
                End If
                If r3("seat_id") = 17 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button17.BackColor = Color.Green
                    Button17.Enabled = False
                End If
                If r3("seat_id") = 18 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button18.BackColor = Color.Green
                    Button18.Enabled = False
                End If
                If r3("seat_id") = 19 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button19.BackColor = Color.Green
                    Button19.Enabled = False
                End If
                If r3("seat_id") = 20 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button20.BackColor = Color.Green
                    Button20.Enabled = False
                End If
                If r3("seat_id") = 21 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button21.BackColor = Color.Green
                    Button21.Enabled = False
                End If
                If r3("seat_id") = 22 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button22.BackColor = Color.Green
                    Button22.Enabled = False
                End If
                If r3("seat_id") = 23 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button23.BackColor = Color.Green
                    Button23.Enabled = False
                End If
                If r3("seat_id") = 24 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button24.BackColor = Color.Green
                    Button24.Enabled = False
                End If
                If r3("seat_id") = 25 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button25.BackColor = Color.Green
                    Button25.Enabled = False
                End If
                If r3("seat_id") = 26 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button26.BackColor = Color.Green
                    Button26.Enabled = False
                End If
                If r3("seat_id") = 27 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button27.BackColor = Color.Green
                    Button27.Enabled = False
                End If
                If r3("seat_id") = 28 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button28.BackColor = Color.Green
                    Button28.Enabled = False
                End If
                If r3("seat_id") = 29 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button29.BackColor = Color.Green
                    Button29.Enabled = False
                End If
                If r3("seat_id") = 30 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button30.BackColor = Color.Green
                    Button30.Enabled = False
                End If
                If r3("seat_id") = 31 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button31.BackColor = Color.Green
                    Button31.Enabled = False
                End If
                If r3("seat_id") = 32 And r3("booked_seat") = 1 And r3("show_id") = 5 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button32.BackColor = Color.Green
                    Button32.Enabled = False
                End If
            End If

            If ListBox1.SelectedItem = "6" Then
                If r3("seat_id") = 1 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button1.BackColor = Color.Green
                    Button1.Enabled = False
                End If

                If r3("seat_id") = 2 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button2.BackColor = Color.Green
                    Button2.Enabled = False
                End If
                If r3("seat_id") = 3 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button3.BackColor = Color.Green
                    Button3.Enabled = False
                End If
                If r3("seat_id") = 4 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button4.BackColor = Color.Green
                    Button4.Enabled = False
                End If
                If r3("seat_id") = 5 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button5.BackColor = Color.Green
                    Button5.Enabled = False
                End If
                If r3("seat_id") = 6 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button6.BackColor = Color.Green
                    Button6.Enabled = False
                End If
                If r3("seat_id") = 7 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button7.BackColor = Color.Green
                    Button7.Enabled = False
                End If
                If r3("seat_id") = 8 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button8.BackColor = Color.Green
                    Button8.Enabled = False
                End If
                If r3("seat_id") = 9 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button9.BackColor = Color.Green
                    Button9.Enabled = False
                End If
                If r3("seat_id") = 10 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button10.BackColor = Color.Green
                    Button10.Enabled = False
                End If
                If r3("seat_id") = 11 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button11.BackColor = Color.Green
                    Button11.Enabled = False
                End If
                If r3("seat_id") = 12 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button12.BackColor = Color.Green
                    Button12.Enabled = False
                End If
                If r3("seat_id") = 13 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button13.BackColor = Color.Green
                    Button13.Enabled = False
                End If
                If r3("seat_id") = 14 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button14.BackColor = Color.Green
                    Button14.Enabled = False
                End If
                If r3("seat_id") = 15 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button15.BackColor = Color.Green
                    Button15.Enabled = False
                End If
                If r3("seat_id") = 16 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button16.BackColor = Color.Green
                    Button16.Enabled = False
                End If
                If r3("seat_id") = 17 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button17.BackColor = Color.Green
                    Button17.Enabled = False
                End If
                If r3("seat_id") = 18 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button18.BackColor = Color.Green
                    Button18.Enabled = False
                End If
                If r3("seat_id") = 19 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button19.BackColor = Color.Green
                    Button19.Enabled = False
                End If
                If r3("seat_id") = 20 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button20.BackColor = Color.Green
                    Button20.Enabled = False
                End If
                If r3("seat_id") = 21 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button21.BackColor = Color.Green
                    Button21.Enabled = False
                End If
                If r3("seat_id") = 22 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button22.BackColor = Color.Green
                    Button22.Enabled = False
                End If
                If r3("seat_id") = 23 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button23.BackColor = Color.Green
                    Button23.Enabled = False
                End If
                If r3("seat_id") = 24 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button24.BackColor = Color.Green
                    Button24.Enabled = False
                End If
                If r3("seat_id") = 25 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button25.BackColor = Color.Green
                    Button25.Enabled = False
                End If
                If r3("seat_id") = 26 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button26.BackColor = Color.Green
                    Button26.Enabled = False
                End If
                If r3("seat_id") = 27 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button27.BackColor = Color.Green
                    Button27.Enabled = False
                End If
                If r3("seat_id") = 28 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button28.BackColor = Color.Green
                    Button28.Enabled = False
                End If
                If r3("seat_id") = 29 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button29.BackColor = Color.Green
                    Button29.Enabled = False
                End If
                If r3("seat_id") = 30 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button30.BackColor = Color.Green
                    Button30.Enabled = False
                End If
                If r3("seat_id") = 31 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button31.BackColor = Color.Green
                    Button31.Enabled = False
                End If
                If r3("seat_id") = 32 And r3("booked_seat") = 1 And r3("show_id") = 6 And DateTimePicker1.Value.Date = r3("booked_date") And r3("movie_id") = TextBox1.Text Then
                    Button32.BackColor = Color.Green
                    Button32.Enabled = False
                End If
            End If
        Next
    End Sub

End Class
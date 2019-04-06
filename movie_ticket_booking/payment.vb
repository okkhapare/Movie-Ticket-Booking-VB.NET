Imports System.Data.OleDb

Public Class payment

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        TextBox6.Clear()
    End Sub

    Private Sub payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim dt As New DataTable
        Dim temp As Integer

        da.SelectCommand = New OleDbCommand("SELECT * FROM movie", cn)
        da.Fill(dt)

        For Each r In dt.Rows
            If r("movie_name") = TextBox2.Text Then
                temp = r("basic_rate")
            End If
        Next

        If TextBox5.Text = "1" Then
            TextBox6.Visible = True
            TextBox6.Text = TextBox6.Text * temp
            Button1.Visible = False
        End If

        If TextBox5.Text = "2" Then
            TextBox6.Visible = True
            TextBox6.Text = TextBox6.Text * temp
            Button1.Visible = False
        End If

        If TextBox5.Text = "3" Then
            TextBox6.Visible = True
            TextBox6.Text = TextBox6.Text * temp * 1.2
            Button1.Visible = False
        End If

        If TextBox5.Text = "4" Then
            TextBox6.Visible = True
            TextBox6.Text = TextBox6.Text * temp * 1.2
            Button1.Visible = False
        End If

        If TextBox5.Text = "5" Then
            TextBox6.Visible = True
            TextBox6.Text = TextBox6.Text * temp * 1.3
            Button1.Visible = False
        End If

        If TextBox5.Text = "6" Then
            TextBox6.Visible = True
            TextBox6.Text = TextBox6.Text * temp * 1.3
            Button1.Visible = False
        End If

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim da2 As New OleDbDataAdapter
        Dim dt2 As New DataTable

        da2.SelectCommand = New OleDbCommand("SELECT * FROM ticket", cn)
        da2.Fill(dt2)

        str = "Insert into ticket([ticket_id],[ticket_date],[seat_booked],[show_time],[movie_id],[total_cost]) Values (?,?,?,?,?,?)"
        cmd = New OleDbCommand(str, cn)
        cmd.Parameters.Add(New OleDbParameter("ticket_id", CInt(TextBox7.Text)))
        cmd.Parameters.Add(New OleDbParameter("ticket_date", TextBox4.Text))
        cmd.Parameters.Add(New OleDbParameter("seat_booked", TextBox3.Text))
        cmd.Parameters.Add(New OleDbParameter("show_time", TextBox5.Text))
        cmd.Parameters.Add(New OleDbParameter("movie_id", CInt(TextBox1.Text)))
        cmd.Parameters.Add(New OleDbParameter("total_cost", CInt(TextBox6.Text)))
        cmd.ExecuteNonQuery()

        MsgBox("Amount Received and Ticket Generated")

    End Sub

End Class
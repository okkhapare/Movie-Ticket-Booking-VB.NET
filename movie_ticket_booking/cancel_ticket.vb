Imports System.Data.OleDb

Public Class cancel_ticket

    Private Sub cancel_ticket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call conn()
        Dim da As New OleDbDataAdapter("select ticket_id from ticket", cn)
        Dim ds As New DataSet
        da.Fill(ds, "1")

        For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
            Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
        Next

        Dim str As String = "select * from ticket"
        Dim ds1 As New DataSet
        Dim da1 As New OleDbDataAdapter(str, cn)

        da1.Fill(ds1, "ticket")

        DataGridView1.DataSource = ds1.Tables("ticket")

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim cmd As New OleDbCommand
        Dim cmd1 As New OleDbCommand

        Dim x As Integer
        Dim x1 As Integer

        Dim sql1 = "delete from ticket where ticket_id=?"
        Dim sql2 = "delete from seat where booked_date=? and show_id=? and movie_id=? and booked_seat=?"

        cmd = New OleDbCommand(sql1, cn)
        cmd.Parameters.AddWithValue("@ticket_id", ComboBox1.Text)

        cmd1 = New OleDbCommand(sql2, cn)
        cmd1.Parameters.AddWithValue("@booked_date", TextBox1.Text)
        cmd1.Parameters.AddWithValue("@show_id", TextBox2.Text)
        cmd1.Parameters.AddWithValue("@movie_id", TextBox3.Text)
        cmd1.Parameters.AddWithValue("@booked_seat", 1)

        x = cmd.ExecuteNonQuery()
        x1 = cmd1.ExecuteNonQuery

        If x > 0 Then

            MsgBox("Ticket Succesfully Cancelled")
            ComboBox1.Text = ""
            ComboBox1.Items.Clear()

            Dim da As New OleDbDataAdapter("select ticket_id from ticket", cn)
            Dim ds As New DataSet
            da.Fill(ds, "1")

            For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
            Next

            Dim str As String = "select * from ticket"
            Dim ds1 As New DataSet
            Dim da1 As New OleDbDataAdapter(str, cn)

            da1.Fill(ds1, "ticket")

            DataGridView1.DataSource = ds1.Tables("ticket")

        Else
            MsgBox("Failed")
        End If

        ComboBox1.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ComboBox1.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim r As DataRow

        Dim dt As New DataTable
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        'ticket_date
        da.SelectCommand = New OleDbCommand("SELECT * FROM ticket", cn)
        da.Fill(dt)

        For Each r In dt.Rows
            If r("ticket_id") = ComboBox1.SelectedItem Then
                TextBox1.Text = r("ticket_date")
            End If
        Next

        'show_time
        da.SelectCommand = New OleDbCommand("SELECT * FROM ticket", cn)
        da.Fill(dt)

        For Each r In dt.Rows
            If r("ticket_id") = ComboBox1.SelectedItem Then
                TextBox2.Text = r("show_time")
            End If
        Next

        'movie_id
        da.SelectCommand = New OleDbCommand("SELECT * FROM ticket", cn)
        da.Fill(dt)

        For Each r In dt.Rows
            If r("ticket_id") = ComboBox1.SelectedItem Then
                TextBox3.Text = r("movie_id")
            End If
        Next
    End Sub

End Class
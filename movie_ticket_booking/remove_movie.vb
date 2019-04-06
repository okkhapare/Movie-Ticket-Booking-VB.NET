Imports System.Data.OleDb

Public Class remove_movie

    Private Sub remove_movie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call conn()
        Try
            Dim da As New OleDbDataAdapter("select movie_name from movie", cn)
            Dim ds As New DataSet
            da.Fill(ds, "1")

            For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
            Next
        Catch ex As Exception
            MsgBox("Error : " + ex.Message)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim r As DataRow
        Dim dt As New DataTable

        da.SelectCommand = New OleDbCommand("SELECT * FROM movie", cn)
        da.Fill(dt)

        For Each r In dt.Rows
            If r("movie_name") = ComboBox1.SelectedItem Then
                TextBox1.Text = r("movie_id")
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As New OleDbCommand
        Dim cmd1 As New OleDbCommand
        Dim cmd2 As New OleDbCommand
        Dim cmd3 As New OleDbCommand

        Dim x As Integer
        Dim x1 As Integer
        Dim x2 As Integer
        Dim x3 As Integer

        Dim sql1 = "delete from movie where movie_id=?"
        Dim sql2 = "delete from show where movie_id=?"
        Dim sql3 = "delete from ticket where movie_id=?"
        Dim sql4 = "delete from seat where movie_id=?"

        cmd = New OleDbCommand(sql1, cn)
        cmd.Parameters.AddWithValue("@movie_id", TextBox1.Text)

        cmd1 = New OleDbCommand(sql2, cn)
        cmd1.Parameters.AddWithValue("@movie_id", TextBox1.Text)

        cmd2 = New OleDbCommand(sql3, cn)
        cmd2.Parameters.AddWithValue("@movie_id", TextBox1.Text)

        cmd3 = New OleDbCommand(sql4, cn)
        cmd3.Parameters.AddWithValue("@movie_id", TextBox1.Text)

        x = cmd.ExecuteNonQuery
        x1 = cmd1.ExecuteNonQuery
        x2 = cmd2.ExecuteNonQuery
        x3 = cmd3.ExecuteNonQuery

        If x > 0 Then
            MsgBox("Succesfully Removed")
            ComboBox1.Text = ""
            ComboBox1.Items.Clear()
            TextBox1.Clear()
            Dim da As New OleDbDataAdapter("select movie_name from movie", cn)
            Dim ds As New DataSet
            da.Fill(ds, "1")

            For i As Integer = 0 To ds.Tables("1").Rows.Count - 1
                Me.ComboBox1.Items.Add(ds.Tables("1").Rows(i)(0))
            Next
        Else
            MsgBox("Failed")
        End If
    End Sub

End Class
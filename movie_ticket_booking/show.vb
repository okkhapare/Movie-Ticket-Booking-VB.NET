Imports System.Data.OleDb

Public Class show

    Dim temp_da As New OleDbDataAdapter
    Dim temp_ds As New DataSet

    Private Sub show_rates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call conn()
        ComboBox1.Items.Clear()
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

        da.SelectCommand = New OleDbCommand("SELECT * FROM movie,show where movie.movie_id=show.movie_id", cn)
        da.Fill(dt)

        For Each r In dt.Rows
            If r("movie_name") = ComboBox1.SelectedItem Then
                TextBox1.Text = r("basic_rate")
            End If
        Next

        ListBox1.Items.Clear()

        For Each r In dt.Rows
            If r("movie_name") = ComboBox1.SelectedItem Then
                ListBox1.Items.Add(r("show_time"))
            End If
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "07:00 am - 9:30 am" Then
            TextBox2.Text = TextBox1.Text
        End If

        If ListBox1.SelectedItem = "10:00 am - 12:30 pm" Then
            TextBox2.Text = TextBox1.Text
        End If

        If ListBox1.SelectedItem = "01:00 pm - 3:30 pm" Then
            TextBox2.Text = TextBox1.Text * 1.2
        End If

        If ListBox1.SelectedItem = "04:00 pm - 6:30 pm" Then
            TextBox2.Text = TextBox1.Text * 1.2
        End If

        If ListBox1.SelectedItem = "07:00 pm - 9:30 pm" Then
            TextBox2.Text = TextBox1.Text * 1.3
        End If

        If ListBox1.SelectedItem = "10:00 pm - 12:30 am" Then
            TextBox2.Text = TextBox1.Text * 1.3
        End If

    End Sub

End Class
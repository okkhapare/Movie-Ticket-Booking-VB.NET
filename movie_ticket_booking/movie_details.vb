Imports System.Data.OleDb

Public Class movie_details

    Private Sub movie_details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call conn()
        Dim dt As New DataTable
        ds.Tables.Add(dt)
        da = New OleDbDataAdapter("Select * from movie", cn)
        da.Fill(dt)
        DataGridView1.DataSource = dt.DefaultView

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        On Error Resume Next
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value


        Dim StartTime As DateTime = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        Dim EndTime As DateTime = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        Dim TimeDiff As TimeSpan = EndTime.Subtract(StartTime)
        Dim Days As Integer = TimeDiff.TotalDays
        'calculate Value of Days Component
        Dim Minutes As Integer = TimeDiff.TotalMinutes
        'calculate Value of Minutes Component
        Dim Seconds As Integer = TimeDiff.TotalSeconds
        'calculate Value of Seconds Component
        Dim TotalDays As Integer = TimeDiff.TotalDays
        'calculate Value of Total Days

        TextBox8.Text = Days

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
    End Sub

End Class
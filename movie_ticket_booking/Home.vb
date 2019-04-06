Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.OleDb

Public Class Home

    Private Sub AddMovieToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddMovieToolStripMenuItem1.Click
        Dim window As New add_movie
        window.MdiParent = Me
        window.Show()
    End Sub

    Private Sub RemoveMovieToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveMovieToolStripMenuItem.Click
        Dim window As New remove_movie
        window.MdiParent = Me
        window.Show()
    End Sub

    Private Sub MovieDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovieDetailsToolStripMenuItem.Click
        Dim window As New movie_details
        window.MdiParent = Me
        window.Show()
    End Sub

    Private Sub BookTicketToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookTicketToolStripMenuItem1.Click
        Dim window As New book_ticket
        window.MdiParent = Me
        window.Show()
    End Sub

    Private Sub CancelTicketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelTicketToolStripMenuItem.Click
        Dim window As New cancel_ticket
        window.MdiParent = Me
        window.Show()
    End Sub

    Private Sub MovieDetailsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovieDetailsReportToolStripMenuItem.Click
        Dim window As New movie_details_report
        window.MdiParent = Me
        window.Show()

        Dim rptDoc As New ReportDocument
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim ds As New MovieDataSet1
        Dim s As New DataSet
        Dim sql

        dt.TableName = "movie"
        sql = "select * from movie"
        da = New OleDbDataAdapter(sql, cn)
        da.Fill(s)

        ds.Tables(0).Merge(s.Tables(0))
        rptDoc = New MovieCrystalReport1
        rptDoc.SetDataSource(ds)

        movie_details_report.MovieCrystalReportViewer1.ReportSource = rptDoc
        movie_details_report.Show()

    End Sub

    Private Sub SchedulingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SchedulingReportToolStripMenuItem.Click
        Dim window As New show_report
        window.MdiParent = Me
        window.Show()

        Dim rptDoc As New ReportDocument
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim ds As New ShowDataSet1
        Dim s As New DataSet
        Dim sql

        dt.TableName = "show"
        sql = "select * from show"
        da = New OleDbDataAdapter(sql, cn)
        da.Fill(s)

        ds.Tables(0).Merge(s.Tables(0))
        rptDoc = New ShowCrystalReport1
        rptDoc.SetDataSource(ds)

        show_report.ShowCrystalReportViewer1.ReportSource = rptDoc
        show_report.Show()
    End Sub

    Private Sub Home_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        login.Show()
    End Sub

    Private Sub ShowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowsToolStripMenuItem.Click
        Dim window As New show
        window.MdiParent = Me
        window.Show()
    End Sub

    Private Sub Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call conn()
    End Sub

    Private Sub PaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentReportToolStripMenuItem.Click
        Dim window As New payment_report
        window.MdiParent = Me
        window.Show()

        Dim rptDoc As New ReportDocument
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim ds As New PaymentDataSet1
        Dim s As New DataSet
        Dim sql

        dt.TableName = "ticket"
        sql = "select * from ticket"
        da = New OleDbDataAdapter(sql, cn)
        da.Fill(s)

        ds.Tables(0).Merge(s.Tables(0))
        rptDoc = New PaymentCrystalReport1
        rptDoc.SetDataSource(ds)

        payment_report.PaymentCrystalReportViewer1.ReportSource = rptDoc
        payment_report.Show()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        Dim window As New payment
        window.MdiParent = Me
        window.Show()
    End Sub

End Class

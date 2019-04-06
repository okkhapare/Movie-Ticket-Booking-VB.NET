<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.AddMovieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddMovieToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveMovieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MovieDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BookTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BookTicketToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CancelTicketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ShowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MovieDetailsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SchedulingReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PaymentReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMovieToolStripMenuItem, Me.BookTicketToolStripMenuItem, Me.ShowsToolStripMenuItem, Me.PaymentToolStripMenuItem, Me.ReportToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(824, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'AddMovieToolStripMenuItem
        '
        Me.AddMovieToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddMovieToolStripMenuItem1, Me.RemoveMovieToolStripMenuItem, Me.MovieDetailsToolStripMenuItem})
        Me.AddMovieToolStripMenuItem.Name = "AddMovieToolStripMenuItem"
        Me.AddMovieToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AddMovieToolStripMenuItem.Text = "Movie"
        '
        'AddMovieToolStripMenuItem1
        '
        Me.AddMovieToolStripMenuItem1.Name = "AddMovieToolStripMenuItem1"
        Me.AddMovieToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.AddMovieToolStripMenuItem1.Text = "Add Movie"
        '
        'RemoveMovieToolStripMenuItem
        '
        Me.RemoveMovieToolStripMenuItem.Name = "RemoveMovieToolStripMenuItem"
        Me.RemoveMovieToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.RemoveMovieToolStripMenuItem.Text = "Remove Movie"
        '
        'MovieDetailsToolStripMenuItem
        '
        Me.MovieDetailsToolStripMenuItem.Name = "MovieDetailsToolStripMenuItem"
        Me.MovieDetailsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.MovieDetailsToolStripMenuItem.Text = "Movie Details"
        '
        'BookTicketToolStripMenuItem
        '
        Me.BookTicketToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BookTicketToolStripMenuItem1, Me.CancelTicketToolStripMenuItem})
        Me.BookTicketToolStripMenuItem.Name = "BookTicketToolStripMenuItem"
        Me.BookTicketToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.BookTicketToolStripMenuItem.Text = "Ticket"
        '
        'BookTicketToolStripMenuItem1
        '
        Me.BookTicketToolStripMenuItem1.Name = "BookTicketToolStripMenuItem1"
        Me.BookTicketToolStripMenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.BookTicketToolStripMenuItem1.Text = "Book Ticket"
        '
        'CancelTicketToolStripMenuItem
        '
        Me.CancelTicketToolStripMenuItem.Name = "CancelTicketToolStripMenuItem"
        Me.CancelTicketToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.CancelTicketToolStripMenuItem.Text = "Cancel Ticket"
        '
        'ShowsToolStripMenuItem
        '
        Me.ShowsToolStripMenuItem.Name = "ShowsToolStripMenuItem"
        Me.ShowsToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.ShowsToolStripMenuItem.Text = "Show "
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovieDetailsReportToolStripMenuItem, Me.SchedulingReportToolStripMenuItem, Me.PaymentReportToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'MovieDetailsReportToolStripMenuItem
        '
        Me.MovieDetailsReportToolStripMenuItem.Name = "MovieDetailsReportToolStripMenuItem"
        Me.MovieDetailsReportToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MovieDetailsReportToolStripMenuItem.Text = "Movie Details Report"
        '
        'SchedulingReportToolStripMenuItem
        '
        Me.SchedulingReportToolStripMenuItem.Name = "SchedulingReportToolStripMenuItem"
        Me.SchedulingReportToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SchedulingReportToolStripMenuItem.Text = "Show Report"
        '
        'PaymentReportToolStripMenuItem
        '
        Me.PaymentReportToolStripMenuItem.Name = "PaymentReportToolStripMenuItem"
        Me.PaymentReportToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.PaymentReportToolStripMenuItem.Text = "Payment Report"
        '
        'PaymentToolStripMenuItem
        '
        Me.PaymentToolStripMenuItem.Name = "PaymentToolStripMenuItem"
        Me.PaymentToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.PaymentToolStripMenuItem.Text = "Payment"
        Me.PaymentToolStripMenuItem.Visible = False
        '
        'Home
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(824, 481)
        Me.Controls.Add(Me.MenuStrip)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movie Ticket Booking"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents AddMovieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddMovieToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveMovieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovieDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BookTicketToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelTicketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MovieDetailsReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SchedulingReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class

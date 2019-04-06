<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class movie_details_report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(movie_details_report))
        Me.MovieCrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'MovieCrystalReportViewer1
        '
        Me.MovieCrystalReportViewer1.ActiveViewIndex = -1
        Me.MovieCrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MovieCrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MovieCrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.MovieCrystalReportViewer1.Name = "MovieCrystalReportViewer1"
        Me.MovieCrystalReportViewer1.SelectionFormula = ""
        Me.MovieCrystalReportViewer1.Size = New System.Drawing.Size(284, 261)
        Me.MovieCrystalReportViewer1.TabIndex = 0
        Me.MovieCrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'movie_details_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.MovieCrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "movie_details_report"
        Me.Text = "movie_details_report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MovieCrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

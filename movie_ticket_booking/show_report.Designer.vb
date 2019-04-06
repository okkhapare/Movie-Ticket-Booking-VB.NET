<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class show_report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(show_report))
        Me.ShowCrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'ShowCrystalReportViewer1
        '
        Me.ShowCrystalReportViewer1.ActiveViewIndex = -1
        Me.ShowCrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShowCrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShowCrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ShowCrystalReportViewer1.Name = "ShowCrystalReportViewer1"
        Me.ShowCrystalReportViewer1.SelectionFormula = ""
        Me.ShowCrystalReportViewer1.Size = New System.Drawing.Size(824, 481)
        Me.ShowCrystalReportViewer1.TabIndex = 0
        Me.ShowCrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'show_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 481)
        Me.Controls.Add(Me.ShowCrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "show_report"
        Me.Text = "Show Report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ShowCrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

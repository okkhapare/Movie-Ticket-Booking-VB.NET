<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payment_report
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payment_report))
        Me.PaymentCrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'PaymentCrystalReportViewer1
        '
        Me.PaymentCrystalReportViewer1.ActiveViewIndex = -1
        Me.PaymentCrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PaymentCrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PaymentCrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.PaymentCrystalReportViewer1.Name = "PaymentCrystalReportViewer1"
        Me.PaymentCrystalReportViewer1.SelectionFormula = ""
        Me.PaymentCrystalReportViewer1.Size = New System.Drawing.Size(653, 345)
        Me.PaymentCrystalReportViewer1.TabIndex = 0
        Me.PaymentCrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'payment_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(653, 345)
        Me.Controls.Add(Me.PaymentCrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "payment_report"
        Me.Text = "payment_report"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PaymentCrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class

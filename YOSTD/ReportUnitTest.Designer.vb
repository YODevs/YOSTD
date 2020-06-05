<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportUnitTest
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
        Me.dtReport = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.real_result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ideal_Result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Operation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.response = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.PassLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FailedLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dtReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtReport
        '
        Me.dtReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtReport.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dtReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.real_result, Me.ideal_Result, Me.Operation, Me.response})
        Me.dtReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtReport.Location = New System.Drawing.Point(0, 0)
        Me.dtReport.Name = "dtReport"
        Me.dtReport.Size = New System.Drawing.Size(560, 395)
        Me.dtReport.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "ID Test"
        Me.id.Name = "id"
        '
        'real_result
        '
        Me.real_result.HeaderText = "Real Result"
        Me.real_result.Name = "real_result"
        '
        'ideal_Result
        '
        Me.ideal_Result.HeaderText = "Ideal Result"
        Me.ideal_Result.Name = "ideal_Result"
        '
        'Operation
        '
        Me.Operation.HeaderText = "Operation"
        Me.Operation.Name = "Operation"
        Me.Operation.ReadOnly = True
        '
        'response
        '
        Me.response.HeaderText = "Response"
        Me.response.Name = "response"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PassLabelStatus, Me.FailedLabelStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 373)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(560, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'PassLabelStatus
        '
        Me.PassLabelStatus.BackColor = System.Drawing.Color.DarkGreen
        Me.PassLabelStatus.ForeColor = System.Drawing.Color.Snow
        Me.PassLabelStatus.Name = "PassLabelStatus"
        Me.PassLabelStatus.Size = New System.Drawing.Size(52, 17)
        Me.PassLabelStatus.Text = "0 Passed"
        '
        'FailedLabelStatus
        '
        Me.FailedLabelStatus.BackColor = System.Drawing.Color.DarkRed
        Me.FailedLabelStatus.ForeColor = System.Drawing.Color.Snow
        Me.FailedLabelStatus.Name = "FailedLabelStatus"
        Me.FailedLabelStatus.Size = New System.Drawing.Size(47, 17)
        Me.FailedLabelStatus.Text = "0 Failed"
        '
        'ReportUnitTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 395)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dtReport)
        Me.Name = "ReportUnitTest"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report UnitTest"
        CType(Me.dtReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtReport As Windows.Forms.DataGridView
    Friend WithEvents id As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents real_result As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ideal_Result As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Operation As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents response As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents FailedLabelStatus As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PassLabelStatus As Windows.Forms.ToolStripStatusLabel
End Class

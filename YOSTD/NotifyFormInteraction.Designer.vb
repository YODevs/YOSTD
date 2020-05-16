<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotifyFormInteraction
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.caption = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'caption
        '
        Me.caption.Cursor = System.Windows.Forms.Cursors.PanNorth
        Me.caption.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.caption.Location = New System.Drawing.Point(7, 7)
        Me.caption.Name = "caption"
        Me.caption.Size = New System.Drawing.Size(299, 61)
        Me.caption.TabIndex = 0
        Me.caption.Text = "TEXT"
        '
        'NotifyFormInteraction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(315, 74)
        Me.Controls.Add(Me.caption)
        Me.Cursor = System.Windows.Forms.Cursors.UpArrow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "NotifyFormInteraction"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Notify Form"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents caption As Windows.Forms.Label
End Class

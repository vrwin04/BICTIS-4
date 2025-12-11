<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReportConcern
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pnlLine2 = New System.Windows.Forms.Panel()
        Me.txtNarrative = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlLine1 = New System.Windows.Forms.Panel()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.btnSubmit)
        Me.pnlContent.Controls.Add(Me.pnlLine2)
        Me.pnlContent.Controls.Add(Me.txtNarrative)
        Me.pnlContent.Controls.Add(Me.Label2)
        Me.pnlContent.Controls.Add(Me.pnlLine1)
        Me.pnlContent.Controls.Add(Me.cbType)
        Me.pnlContent.Controls.Add(Me.Label1)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 0)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(40)
        Me.pnlContent.Size = New System.Drawing.Size(900, 600)
        Me.pnlContent.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(46, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type of Concern:"
        '
        'cbType
        '
        Me.cbType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbType.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cbType.FormattingEnabled = True
        Me.cbType.Location = New System.Drawing.Point(50, 80)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(800, 29)
        Me.cbType.TabIndex = 1
        '
        'pnlLine1
        '
        Me.pnlLine1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLine1.BackColor = System.Drawing.Color.LightGray
        Me.pnlLine1.Location = New System.Drawing.Point(50, 115)
        Me.pnlLine1.Name = "pnlLine1"
        Me.pnlLine1.Size = New System.Drawing.Size(800, 2)
        Me.pnlLine1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(46, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Narrative / Details :"
        '
        'txtNarrative
        '
        Me.txtNarrative.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNarrative.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtNarrative.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNarrative.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtNarrative.Location = New System.Drawing.Point(50, 190)
        Me.txtNarrative.Multiline = True
        Me.txtNarrative.Name = "txtNarrative"
        Me.txtNarrative.Size = New System.Drawing.Size(800, 150)
        Me.txtNarrative.TabIndex = 4
        '
        'pnlLine2
        '
        Me.pnlLine2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLine2.BackColor = System.Drawing.Color.LightGray
        Me.pnlLine2.Location = New System.Drawing.Point(50, 345)
        Me.pnlLine2.Name = "pnlLine2"
        Me.pnlLine2.Size = New System.Drawing.Size(800, 2)
        Me.pnlLine2.TabIndex = 5
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(50, 400)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(800, 50)
        Me.btnSubmit.TabIndex = 6
        Me.btnSubmit.Text = "SUBMIT REPORT"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'frmReportConcern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.pnlContent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReportConcern"
        Me.Text = "Report Concern"
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContent As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbType As ComboBox
    Friend WithEvents pnlLine1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNarrative As TextBox
    Friend WithEvents pnlLine2 As Panel
    Friend WithEvents btnSubmit As Button
End Class
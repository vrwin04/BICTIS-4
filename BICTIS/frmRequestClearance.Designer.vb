<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRequestClearance
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.pnlLine1 = New System.Windows.Forms.Panel()
        Me.cbPurpose = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCertType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpNeeded = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(900, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(20, 18)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(206, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "REQUEST CLEARANCE"
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.White
        Me.pnlContent.Controls.Add(Me.dtpNeeded)
        Me.pnlContent.Controls.Add(Me.Label4)
        Me.pnlContent.Controls.Add(Me.cbCertType)
        Me.pnlContent.Controls.Add(Me.Label3)
        Me.pnlContent.Controls.Add(Me.btnSubmit)
        Me.pnlContent.Controls.Add(Me.pnlLine1)
        Me.pnlContent.Controls.Add(Me.cbPurpose)
        Me.pnlContent.Controls.Add(Me.Label1)
        Me.pnlContent.Controls.Add(Me.Label2)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 60)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(40)
        Me.pnlContent.Size = New System.Drawing.Size(900, 540)
        Me.pnlContent.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(46, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Certificate Type:"
        '
        'cbCertType
        '
        Me.cbCertType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.cbCertType.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbCertType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCertType.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cbCertType.FormattingEnabled = True
        Me.cbCertType.Location = New System.Drawing.Point(50, 65)
        Me.cbCertType.Name = "cbCertType"
        Me.cbCertType.Size = New System.Drawing.Size(500, 29)
        Me.cbCertType.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(46, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Purpose of Clearance :"
        '
        'cbPurpose
        '
        Me.cbPurpose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.cbPurpose.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbPurpose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPurpose.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cbPurpose.FormattingEnabled = True
        Me.cbPurpose.Location = New System.Drawing.Point(50, 145)
        Me.cbPurpose.Name = "cbPurpose"
        Me.cbPurpose.Size = New System.Drawing.Size(500, 29)
        Me.cbPurpose.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(46, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 19)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Date Needed:"
        '
        'dtpNeeded
        '
        Me.dtpNeeded.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.dtpNeeded.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtpNeeded.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNeeded.Location = New System.Drawing.Point(50, 225)
        Me.dtpNeeded.Name = "dtpNeeded"
        Me.dtpNeeded.Size = New System.Drawing.Size(500, 29)
        Me.dtpNeeded.TabIndex = 8
        '
        'pnlLine1
        '
        Me.pnlLine1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.pnlLine1.BackColor = System.Drawing.Color.LightGray
        Me.pnlLine1.Location = New System.Drawing.Point(50, 280)
        Me.pnlLine1.Name = "pnlLine1"
        Me.pnlLine1.Size = New System.Drawing.Size(500, 2)
        Me.pnlLine1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(50, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(280, 45)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Note: Admin will set the schedule for pickup."
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right, System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.BackColor = System.Drawing.Color.FromArgb(0, 150, 136)
        Me.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSubmit.FlatAppearance.BorderSize = 0
        Me.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSubmit.ForeColor = System.Drawing.Color.White
        Me.btnSubmit.Location = New System.Drawing.Point(50, 360)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(500, 50)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "SUBMIT REQUEST"
        Me.btnSubmit.UseVisualStyleBackColor = False
        '
        'frmRequestClearance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRequestClearance"
        Me.Text = "Request Clearance"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbPurpose As ComboBox
    Friend WithEvents pnlLine1 As Panel
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCertType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpNeeded As DateTimePicker
    Friend WithEvents Label4 As Label
End Class
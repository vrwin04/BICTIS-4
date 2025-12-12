<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClearanceStatus
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblDateNeeded = New System.Windows.Forms.Label()
        Me.lblPurpose = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me.btnClose)
        Me.pnlCard.Controls.Add(Me.lblDateNeeded)
        Me.pnlCard.Controls.Add(Me.lblPurpose)
        Me.pnlCard.Controls.Add(Me.lblType)
        Me.pnlCard.Controls.Add(Me.lblStatus)
        Me.pnlCard.Controls.Add(Me.lblHeader)
        Me.pnlCard.Location = New System.Drawing.Point(12, 12)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Size = New System.Drawing.Size(376, 426)
        Me.pnlCard.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(30, 350)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(316, 50)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblDateNeeded
        '
        Me.lblDateNeeded.AutoSize = True
        Me.lblDateNeeded.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblDateNeeded.ForeColor = System.Drawing.Color.DimGray
        Me.lblDateNeeded.Location = New System.Drawing.Point(30, 240)
        Me.lblDateNeeded.Name = "lblDateNeeded"
        Me.lblDateNeeded.Size = New System.Drawing.Size(100, 20)
        Me.lblDateNeeded.TabIndex = 4
        Me.lblDateNeeded.Text = "Date Needed:"
        '
        'lblPurpose
        '
        Me.lblPurpose.AutoSize = True
        Me.lblPurpose.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblPurpose.ForeColor = System.Drawing.Color.DimGray
        Me.lblPurpose.Location = New System.Drawing.Point(30, 200)
        Me.lblPurpose.Name = "lblPurpose"
        Me.lblPurpose.Size = New System.Drawing.Size(64, 20)
        Me.lblPurpose.TabIndex = 3
        Me.lblPurpose.Text = "Purpose:"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblType.ForeColor = System.Drawing.Color.DimGray
        Me.lblType.Location = New System.Drawing.Point(30, 160)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(43, 20)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Type:"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.Orange
        Me.lblStatus.Location = New System.Drawing.Point(20, 70)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(336, 60)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "LOADING..."
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.DimGray
        Me.lblHeader.Location = New System.Drawing.Point(20, 20)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(165, 25)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "REQUEST STATUS"
        '
        'frmClearanceStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(400, 450)
        Me.Controls.Add(Me.pnlCard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmClearanceStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Clearance Status"
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblPurpose As System.Windows.Forms.Label
    Friend WithEvents lblDateNeeded As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
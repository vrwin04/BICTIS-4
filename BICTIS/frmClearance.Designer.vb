<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClearance
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlControls = New Panel()
        btnReject = New Button()
        btnPrint = New Button()
        dgvRequests = New DataGridView()
        pnlControls.SuspendLayout()
        CType(dgvRequests, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlControls
        ' 
        pnlControls.BackColor = Color.White
        pnlControls.Controls.Add(btnReject)
        pnlControls.Controls.Add(btnPrint)
        pnlControls.Dock = DockStyle.Bottom
        pnlControls.Location = New Point(0, 693)
        pnlControls.Margin = New Padding(3, 4, 3, 4)
        pnlControls.Name = "pnlControls"
        pnlControls.Size = New Size(1029, 107)
        pnlControls.TabIndex = 1
        ' 
        ' btnReject
        ' 
        btnReject.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnReject.BackColor = Color.IndianRed
        btnReject.FlatAppearance.BorderSize = 0
        btnReject.FlatStyle = FlatStyle.Flat
        btnReject.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnReject.ForeColor = Color.White
        btnReject.Location = New Point(629, 27)
        btnReject.Margin = New Padding(3, 4, 3, 4)
        btnReject.Name = "btnReject"
        btnReject.Size = New Size(171, 53)
        btnReject.TabIndex = 1
        btnReject.Text = "REJECT"
        btnReject.UseVisualStyleBackColor = False
        ' 
        ' btnPrint
        ' 
        btnPrint.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnPrint.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        btnPrint.FlatAppearance.BorderSize = 0
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(823, 27)
        btnPrint.Margin = New Padding(3, 4, 3, 4)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(171, 53)
        btnPrint.TabIndex = 0
        btnPrint.Text = "APPROVE / PRINT"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' dgvRequests
        ' 
        dgvRequests.AllowUserToAddRows = False
        dgvRequests.AllowUserToDeleteRows = False
        dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRequests.BackgroundColor = Color.WhiteSmoke
        dgvRequests.BorderStyle = BorderStyle.None
        dgvRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvRequests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvRequests.ColumnHeadersHeight = 40
        dgvRequests.Dock = DockStyle.Fill
        dgvRequests.EnableHeadersVisualStyles = False
        dgvRequests.Location = New Point(0, 0)
        dgvRequests.Margin = New Padding(3, 4, 3, 4)
        dgvRequests.Name = "dgvRequests"
        dgvRequests.ReadOnly = True
        dgvRequests.RowHeadersVisible = False
        dgvRequests.RowHeadersWidth = 51
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.ForeColor = Color.Black
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(200), CByte(230), CByte(225))
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        dgvRequests.RowsDefaultCellStyle = DataGridViewCellStyle2
        dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvRequests.Size = New Size(1029, 693)
        dgvRequests.TabIndex = 2
        ' 
        ' frmClearance
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1029, 800)
        Controls.Add(dgvRequests)
        Controls.Add(pnlControls)
        Font = New Font("Segoe UI", 9F)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "frmClearance"
        Text = "Clearance Management"
        pnlControls.ResumeLayout(False)
        CType(dgvRequests, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlControls As Panel
    Friend WithEvents dgvRequests As DataGridView
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnReject As Button
End Class
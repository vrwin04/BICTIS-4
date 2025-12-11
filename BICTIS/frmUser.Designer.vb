<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUser
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
        pnlBorder = New Panel()
        pnlContainer = New Panel()
        pnlHistoryCard = New Panel()
        dgvHistory = New DataGridView()
        lblHistoryTitle = New Label()
        pnlHeader = New Panel()
        lblWelcome = New Label()
        pnlSidebar = New Panel()
        btnLogout = New Button()
        btnRefresh = New Button()
        btnRequestClearance = New Button()
        btnReport = New Button()
        pnlLogo = New Panel()
        Label1 = New Label()
        pnlBorder.SuspendLayout()
        pnlContainer.SuspendLayout()
        pnlHistoryCard.SuspendLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).BeginInit()
        pnlHeader.SuspendLayout()
        pnlSidebar.SuspendLayout()
        pnlLogo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlBorder
        ' 
        pnlBorder.BackColor = Color.FromArgb(CByte(240), CByte(242), CByte(245))
        pnlBorder.Controls.Add(pnlContainer)
        pnlBorder.Controls.Add(pnlHeader)
        pnlBorder.Controls.Add(pnlSidebar)
        pnlBorder.Dock = DockStyle.Fill
        pnlBorder.Location = New Point(0, 0)
        pnlBorder.Margin = New Padding(4, 5, 4, 5)
        pnlBorder.Name = "pnlBorder"
        pnlBorder.Size = New Size(1600, 900)
        pnlBorder.TabIndex = 0
        ' 
        ' pnlContainer
        ' 
        pnlContainer.BackColor = Color.Transparent
        pnlContainer.Controls.Add(pnlHistoryCard)
        pnlContainer.Dock = DockStyle.Fill
        pnlContainer.Location = New Point(400, 123)
        pnlContainer.Margin = New Padding(4, 5, 4, 5)
        pnlContainer.Name = "pnlContainer"
        pnlContainer.Padding = New Padding(40, 46, 40, 46)
        pnlContainer.Size = New Size(1200, 777)
        pnlContainer.TabIndex = 2
        ' 
        ' pnlHistoryCard
        ' 
        pnlHistoryCard.BackColor = Color.White
        pnlHistoryCard.Controls.Add(dgvHistory)
        pnlHistoryCard.Controls.Add(lblHistoryTitle)
        pnlHistoryCard.Dock = DockStyle.Fill
        pnlHistoryCard.Location = New Point(40, 46)
        pnlHistoryCard.Margin = New Padding(4, 5, 4, 5)
        pnlHistoryCard.Name = "pnlHistoryCard"
        pnlHistoryCard.Padding = New Padding(27, 31, 27, 31)
        pnlHistoryCard.Size = New Size(1120, 685)
        pnlHistoryCard.TabIndex = 0
        ' 
        ' dgvHistory
        ' 
        dgvHistory.AllowUserToAddRows = False
        dgvHistory.AllowUserToDeleteRows = False
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvHistory.BackgroundColor = Color.White
        dgvHistory.BorderStyle = BorderStyle.None
        dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvHistory.ColumnHeadersHeight = 50
        dgvHistory.Dock = DockStyle.Fill
        dgvHistory.EnableHeadersVisualStyles = False
        dgvHistory.Location = New Point(27, 86)
        dgvHistory.Margin = New Padding(4, 5, 4, 5)
        dgvHistory.Name = "dgvHistory"
        dgvHistory.ReadOnly = True
        dgvHistory.RowHeadersVisible = False
        dgvHistory.RowHeadersWidth = 51
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(224), CByte(242), CByte(241))
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        dgvHistory.RowsDefaultCellStyle = DataGridViewCellStyle2
        dgvHistory.RowTemplate.Height = 40
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHistory.Size = New Size(1066, 568)
        dgvHistory.TabIndex = 1
        ' 
        ' lblHistoryTitle
        ' 
        lblHistoryTitle.AutoSize = True
        lblHistoryTitle.Dock = DockStyle.Top
        lblHistoryTitle.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblHistoryTitle.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        lblHistoryTitle.Location = New Point(27, 31)
        lblHistoryTitle.Margin = New Padding(4, 0, 4, 0)
        lblHistoryTitle.Name = "lblHistoryTitle"
        lblHistoryTitle.Padding = New Padding(0, 0, 0, 23)
        lblHistoryTitle.Size = New Size(280, 55)
        lblHistoryTitle.TabIndex = 0
        lblHistoryTitle.Text = "My Transaction History"
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.White
        pnlHeader.Controls.Add(lblWelcome)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(400, 0)
        pnlHeader.Margin = New Padding(4, 5, 4, 5)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1200, 123)
        pnlHeader.TabIndex = 1
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        lblWelcome.Location = New Point(40, 38)
        lblWelcome.Margin = New Padding(4, 0, 4, 0)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(277, 41)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "Welcome Resident"
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.FromArgb(CByte(0), CByte(150), CByte(136))
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Controls.Add(btnRefresh)
        pnlSidebar.Controls.Add(btnRequestClearance)
        pnlSidebar.Controls.Add(btnReport)
        pnlSidebar.Controls.Add(pnlLogo)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Margin = New Padding(4, 5, 4, 5)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(400, 900)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnLogout
        ' 
        btnLogout.Dock = DockStyle.Bottom
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(121), CByte(107))
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.FromArgb(CByte(255), CByte(235), CByte(238))
        btnLogout.Location = New Point(0, 792)
        btnLogout.Margin = New Padding(4, 5, 4, 5)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(400, 108)
        btnLogout.TabIndex = 5
        btnLogout.Text = "Sign Out"
        btnLogout.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Dock = DockStyle.Top
        btnRefresh.FlatAppearance.BorderSize = 0
        btnRefresh.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(121), CByte(107))
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Font = New Font("Segoe UI", 11.0F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(0, 401)
        btnRefresh.Margin = New Padding(4, 5, 4, 5)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Padding = New Padding(40, 0, 0, 0)
        btnRefresh.Size = New Size(400, 108)
        btnRefresh.TabIndex = 3
        btnRefresh.Text = "History / Home"
        btnRefresh.TextAlign = ContentAlignment.MiddleLeft
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' btnRequestClearance
        ' 
        btnRequestClearance.Dock = DockStyle.Top
        btnRequestClearance.FlatAppearance.BorderSize = 0
        btnRequestClearance.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(121), CByte(107))
        btnRequestClearance.FlatStyle = FlatStyle.Flat
        btnRequestClearance.Font = New Font("Segoe UI", 11.0F)
        btnRequestClearance.ForeColor = Color.White
        btnRequestClearance.Location = New Point(0, 293)
        btnRequestClearance.Margin = New Padding(4, 5, 4, 5)
        btnRequestClearance.Name = "btnRequestClearance"
        btnRequestClearance.Padding = New Padding(40, 0, 0, 0)
        btnRequestClearance.Size = New Size(400, 108)
        btnRequestClearance.TabIndex = 6
        btnRequestClearance.Text = "Request Clearance"
        btnRequestClearance.TextAlign = ContentAlignment.MiddleLeft
        btnRequestClearance.UseVisualStyleBackColor = True
        ' 
        ' btnReport
        ' 
        btnReport.Dock = DockStyle.Top
        btnReport.FlatAppearance.BorderSize = 0
        btnReport.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(121), CByte(107))
        btnReport.FlatStyle = FlatStyle.Flat
        btnReport.Font = New Font("Segoe UI", 11.0F)
        btnReport.ForeColor = Color.White
        btnReport.Location = New Point(0, 185)
        btnReport.Margin = New Padding(4, 5, 4, 5)
        btnReport.Name = "btnReport"
        btnReport.Padding = New Padding(40, 0, 0, 0)
        btnReport.Size = New Size(400, 108)
        btnReport.TabIndex = 1
        btnReport.Text = "Report a Concern"
        btnReport.TextAlign = ContentAlignment.MiddleLeft
        btnReport.UseVisualStyleBackColor = True
        ' 
        ' pnlLogo
        ' 
        pnlLogo.BackColor = Color.FromArgb(CByte(0), CByte(121), CByte(107))
        pnlLogo.Controls.Add(Label1)
        pnlLogo.Dock = DockStyle.Top
        pnlLogo.Location = New Point(0, 0)
        pnlLogo.Margin = New Padding(4, 5, 4, 5)
        pnlLogo.Name = "pnlLogo"
        pnlLogo.Size = New Size(400, 185)
        pnlLogo.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(40, 62)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(180, 46)
        Label1.TabIndex = 0
        Label1.Text = "RESIDENT"
        ' 
        ' frmUser
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1600, 900)
        Controls.Add(pnlBorder)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmUser"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User Dashboard"
        pnlBorder.ResumeLayout(False)
        pnlContainer.ResumeLayout(False)
        pnlHistoryCard.ResumeLayout(False)
        pnlHistoryCard.PerformLayout()
        CType(dgvHistory, ComponentModel.ISupportInitialize).EndInit()
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlSidebar.ResumeLayout(False)
        pnlLogo.ResumeLayout(False)
        pnlLogo.PerformLayout()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBorder As Panel
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlLogo As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnReport As Button
    Friend WithEvents btnRequestClearance As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblWelcome As Label
    Friend WithEvents pnlContainer As Panel
    Friend WithEvents pnlHistoryCard As Panel
    Friend WithEvents lblHistoryTitle As Label
    Friend WithEvents dgvHistory As DataGridView
End Class
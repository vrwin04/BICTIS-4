<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmManageResidents
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
        pnlHeader = New Panel()
        btnClose = New Button()
        lblTitle = New Label()
        pnlControls = New Panel()
        btnDelete = New Button()
        Label1 = New Label()
        txtSearch = New TextBox()
        dgvResidents = New DataGridView()
        pnlHeader.SuspendLayout()
        pnlControls.SuspendLayout()
        CType(dgvResidents, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        pnlHeader.Controls.Add(btnClose)
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(3, 4, 3, 4)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1029, 80)
        pnlHeader.TabIndex = 0
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(971, 13)
        btnClose.Margin = New Padding(3, 4, 3, 4)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(46, 53)
        btnClose.TabIndex = 1
        btnClose.Text = "X"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(23, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(284, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "MANAGE RESIDENTS"
        ' 
        ' pnlControls
        ' 
        pnlControls.BackColor = Color.White
        pnlControls.Controls.Add(btnDelete)
        pnlControls.Controls.Add(Label1)
        pnlControls.Controls.Add(txtSearch)
        pnlControls.Dock = DockStyle.Top
        pnlControls.Location = New Point(0, 80)
        pnlControls.Margin = New Padding(3, 4, 3, 4)
        pnlControls.Name = "pnlControls"
        pnlControls.Size = New Size(1029, 93)
        pnlControls.TabIndex = 1
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.IndianRed
        btnDelete.FlatAppearance.BorderSize = 0
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(788, 20)
        btnDelete.Margin = New Padding(3, 4, 3, 4)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(206, 53)
        btnDelete.TabIndex = 2
        btnDelete.Text = "DEACTATIVATE USER"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.0F)
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(25, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(135, 23)
        Label1.TabIndex = 1
        Label1.Text = "Search Resident:"
        ' 
        ' txtSearch
        ' 
        txtSearch.BackColor = Color.WhiteSmoke
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Font = New Font("Segoe UI", 12.0F)
        txtSearch.Location = New Point(160, 31)
        txtSearch.Margin = New Padding(3, 4, 3, 4)
        txtSearch.Multiline = True
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(343, 33)
        txtSearch.TabIndex = 0
        ' 
        ' dgvResidents
        ' 
        dgvResidents.AllowUserToAddRows = False
        dgvResidents.AllowUserToDeleteRows = False
        dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvResidents.BackgroundColor = Color.WhiteSmoke
        dgvResidents.BorderStyle = BorderStyle.None
        dgvResidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgvResidents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle1.ForeColor = Color.White
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvResidents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvResidents.ColumnHeadersHeight = 40
        dgvResidents.Dock = DockStyle.Fill
        dgvResidents.EnableHeadersVisualStyles = False
        dgvResidents.Location = New Point(0, 173)
        dgvResidents.Margin = New Padding(3, 4, 3, 4)
        dgvResidents.Name = "dgvResidents"
        dgvResidents.ReadOnly = True
        dgvResidents.RowHeadersVisible = False
        dgvResidents.RowHeadersWidth = 51
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.ForeColor = Color.DimGray
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(230), CByte(240), CByte(250))
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        dgvResidents.RowsDefaultCellStyle = DataGridViewCellStyle2
        dgvResidents.RowTemplate.Height = 35
        dgvResidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvResidents.Size = New Size(1029, 627)
        dgvResidents.TabIndex = 2
        ' 
        ' frmManageResidents
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1029, 800)
        Controls.Add(dgvResidents)
        Controls.Add(pnlControls)
        Controls.Add(pnlHeader)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 4, 3, 4)
        Name = "frmManageResidents"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Residents"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlControls.ResumeLayout(False)
        pnlControls.PerformLayout()
        CType(dgvResidents, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlControls As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents dgvResidents As DataGridView
End Class
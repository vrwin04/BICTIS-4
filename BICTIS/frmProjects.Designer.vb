<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProjects
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
        lblTitle = New Label()
        pnlEditor = New Panel()
        Label6 = New Label()
        btnUpdate = New Button()
        btnAdd = New Button()
        cbStatus = New ComboBox()
        Label5 = New Label()
        txtDescription = New TextBox()
        Label4 = New Label()
        txtExpenses = New TextBox()
        Label3 = New Label()
        txtBudget = New TextBox()
        Label2 = New Label()
        txtProjectName = New TextBox()
        Label1 = New Label()
        pnlGrid = New Panel()
        dgvProjects = New DataGridView()
        pnlHeader.SuspendLayout()
        pnlEditor.SuspendLayout()
        pnlGrid.SuspendLayout()
        CType(dgvProjects, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Margin = New Padding(4, 5, 4, 5)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(1333, 108)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 16F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(27, 31)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(316, 37)
        lblTitle.TabIndex = 0
        lblTitle.Text = "PROJECT MONITORING"
        ' 
        ' pnlEditor
        ' 
        pnlEditor.BackColor = Color.White
        pnlEditor.Controls.Add(Label6)
        pnlEditor.Controls.Add(btnUpdate)
        pnlEditor.Controls.Add(btnAdd)
        pnlEditor.Controls.Add(cbStatus)
        pnlEditor.Controls.Add(Label5)
        pnlEditor.Controls.Add(txtDescription)
        pnlEditor.Controls.Add(Label4)
        pnlEditor.Controls.Add(txtExpenses)
        pnlEditor.Controls.Add(Label3)
        pnlEditor.Controls.Add(txtBudget)
        pnlEditor.Controls.Add(Label2)
        pnlEditor.Controls.Add(txtProjectName)
        pnlEditor.Controls.Add(Label1)
        pnlEditor.Dock = DockStyle.Right
        pnlEditor.Location = New Point(800, 108)
        pnlEditor.Margin = New Padding(4, 5, 4, 5)
        pnlEditor.Name = "pnlEditor"
        pnlEditor.Padding = New Padding(27, 31, 27, 31)
        pnlEditor.Size = New Size(533, 815)
        pnlEditor.TabIndex = 1
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label6.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        Label6.Location = New Point(27, 31)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(180, 32)
        Label6.TabIndex = 12
        Label6.Text = "Project Details"
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnUpdate.BackColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        btnUpdate.FlatAppearance.BorderSize = 0
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(34, 732)
        btnUpdate.Margin = New Padding(4, 5, 4, 5)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(467, 69)
        btnUpdate.TabIndex = 11
        btnUpdate.Text = "UPDATE SELECTED"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnAdd.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnAdd.FlatAppearance.BorderSize = 0
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(34, 646)
        btnAdd.Margin = New Padding(4, 5, 4, 5)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(467, 69)
        btnAdd.TabIndex = 10
        btnAdd.Text = "ADD NEW PROJECT"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' cbStatus
        ' 
        cbStatus.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        cbStatus.BackColor = Color.WhiteSmoke
        cbStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cbStatus.FlatStyle = FlatStyle.Flat
        cbStatus.Font = New Font("Segoe UI", 11F)
        cbStatus.FormattingEnabled = True
        cbStatus.Location = New Point(33, 342)
        cbStatus.Margin = New Padding(4, 5, 4, 5)
        cbStatus.Name = "cbStatus"
        cbStatus.Size = New Size(468, 33)
        cbStatus.TabIndex = 9
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F)
        Label5.ForeColor = Color.Gray
        Label5.Location = New Point(29, 303)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(114, 23)
        Label5.TabIndex = 8
        Label5.Text = "Project Status"
        ' 
        ' txtDescription
        ' 
        txtDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtDescription.BackColor = Color.WhiteSmoke
        txtDescription.BorderStyle = BorderStyle.None
        txtDescription.Font = New Font("Segoe UI", 11F)
        txtDescription.Location = New Point(33, 429)
        txtDescription.Margin = New Padding(4, 5, 4, 5)
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(467, 72)
        txtDescription.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10F)
        Label4.ForeColor = Color.Gray
        Label4.Location = New Point(29, 393)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(154, 23)
        Label4.TabIndex = 6
        Label4.Text = "Project Description"
        ' 
        ' txtExpenses
        ' 
        txtExpenses.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtExpenses.BackColor = Color.WhiteSmoke
        txtExpenses.BorderStyle = BorderStyle.None
        txtExpenses.Font = New Font("Segoe UI", 11F)
        txtExpenses.Location = New Point(33, 255)
        txtExpenses.Margin = New Padding(4, 5, 4, 5)
        txtExpenses.Name = "txtExpenses"
        txtExpenses.Size = New Size(469, 25)
        txtExpenses.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10F)
        Label3.ForeColor = Color.Gray
        Label3.Location = New Point(29, 216)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 23)
        Label3.TabIndex = 4
        Label3.Text = "Total Expenses"
        ' 
        ' txtBudget
        ' 
        txtBudget.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtBudget.BackColor = Color.WhiteSmoke
        txtBudget.BorderStyle = BorderStyle.None
        txtBudget.Font = New Font("Segoe UI", 11F)
        txtBudget.Location = New Point(33, 165)
        txtBudget.Margin = New Padding(4, 5, 4, 5)
        txtBudget.Name = "txtBudget"
        txtBudget.Size = New Size(469, 25)
        txtBudget.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(29, 127)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(146, 23)
        Label2.TabIndex = 2
        Label2.Text = "Budget Allocation"
        ' 
        ' txtProjectName
        ' 
        txtProjectName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtProjectName.BackColor = Color.WhiteSmoke
        txtProjectName.BorderStyle = BorderStyle.None
        txtProjectName.Font = New Font("Segoe UI", 11F)
        txtProjectName.Location = New Point(33, 77)
        txtProjectName.Margin = New Padding(4, 5, 4, 5)
        txtProjectName.Name = "txtProjectName"
        txtProjectName.Size = New Size(469, 25)
        txtProjectName.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(29, 38)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(114, 23)
        Label1.TabIndex = 0
        Label1.Text = "Project Name"
        ' 
        ' pnlGrid
        ' 
        pnlGrid.BackColor = Color.WhiteSmoke
        pnlGrid.Controls.Add(dgvProjects)
        pnlGrid.Dock = DockStyle.Fill
        pnlGrid.Location = New Point(0, 108)
        pnlGrid.Margin = New Padding(4, 5, 4, 5)
        pnlGrid.Name = "pnlGrid"
        pnlGrid.Padding = New Padding(27, 31, 27, 31)
        pnlGrid.Size = New Size(800, 815)
        pnlGrid.TabIndex = 2
        ' 
        ' dgvProjects
        ' 
        dgvProjects.AllowUserToAddRows = False
        dgvProjects.AllowUserToDeleteRows = False
        dgvProjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvProjects.BackgroundColor = Color.White
        dgvProjects.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = Color.White
        dgvProjects.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgvProjects.ColumnHeadersHeight = 40
        dgvProjects.Dock = DockStyle.Fill
        dgvProjects.EnableHeadersVisualStyles = False
        dgvProjects.Location = New Point(27, 31)
        dgvProjects.Margin = New Padding(4, 5, 4, 5)
        dgvProjects.Name = "dgvProjects"
        dgvProjects.ReadOnly = True
        dgvProjects.RowHeadersVisible = False
        dgvProjects.RowHeadersWidth = 51
        DataGridViewCellStyle2.BackColor = Color.White
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle2.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        DataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(CByte(235), CByte(245), CByte(251))
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        dgvProjects.RowsDefaultCellStyle = DataGridViewCellStyle2
        dgvProjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProjects.Size = New Size(746, 753)
        dgvProjects.TabIndex = 0
        ' 
        ' frmProjects
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1333, 923)
        Controls.Add(pnlGrid)
        Controls.Add(pnlEditor)
        Controls.Add(pnlHeader)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmProjects"
        Text = "frmProjects"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        pnlEditor.ResumeLayout(False)
        pnlEditor.PerformLayout()
        pnlGrid.ResumeLayout(False)
        CType(dgvProjects, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlEditor As Panel
    Friend WithEvents pnlGrid As Panel
    Friend WithEvents dgvProjects As DataGridView
    Friend WithEvents txtProjectName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBudget As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtExpenses As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Label6 As Label
End Class
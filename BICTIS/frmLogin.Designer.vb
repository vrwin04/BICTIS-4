<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
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
        pnlLeft = New Panel()
        Label6 = New Label()
        lblBrand = New Label()
        pnlRight = New Panel()
        chkShowPass = New CheckBox()
        btnClose = New Button()
        lblRegisterLink = New Label()
        Label5 = New Label()
        btnLogin = New Button()
        pnlPassLine = New Panel()
        txtPassword = New TextBox()
        Label2 = New Label()
        pnlUserLine = New Panel()
        txtUsername = New TextBox()
        Label1 = New Label()
        lblTitle = New Label()
        pnlLeft.SuspendLayout()
        pnlRight.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        pnlLeft.Controls.Add(Label6)
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Margin = New Padding(4, 5, 4, 5)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(400, 769)
        pnlLeft.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.Font = New Font("Segoe UI Light", 14F)
        Label6.ForeColor = Color.WhiteSmoke
        Label6.Location = New Point(58, 327)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(236, 74)
        Label6.TabIndex = 1
        Label6.Text = "Barangay Information Management System"
        ' 
        ' lblBrand
        ' 
        lblBrand.AutoSize = True
        lblBrand.Font = New Font("Segoe UI", 36F, FontStyle.Bold)
        lblBrand.ForeColor = Color.White
        lblBrand.Location = New Point(47, 246)
        lblBrand.Margin = New Padding(4, 0, 4, 0)
        lblBrand.Name = "lblBrand"
        lblBrand.Size = New Size(183, 81)
        lblBrand.TabIndex = 0
        lblBrand.Text = "BIMS"
        ' 
        ' pnlRight
        ' 
        pnlRight.BackColor = Color.White
        pnlRight.Controls.Add(chkShowPass)
        pnlRight.Controls.Add(btnClose)
        pnlRight.Controls.Add(lblRegisterLink)
        pnlRight.Controls.Add(Label5)
        pnlRight.Controls.Add(btnLogin)
        pnlRight.Controls.Add(pnlPassLine)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(Label2)
        pnlRight.Controls.Add(pnlUserLine)
        pnlRight.Controls.Add(txtUsername)
        pnlRight.Controls.Add(Label1)
        pnlRight.Controls.Add(lblTitle)
        pnlRight.Dock = DockStyle.Fill
        pnlRight.Location = New Point(400, 0)
        pnlRight.Margin = New Padding(4, 5, 4, 5)
        pnlRight.Name = "pnlRight"
        pnlRight.Size = New Size(600, 769)
        pnlRight.TabIndex = 1
        ' 
        ' chkShowPass
        ' 
        chkShowPass.AutoSize = True
        chkShowPass.Cursor = Cursors.Hand
        chkShowPass.Font = New Font("Segoe UI", 9F)
        chkShowPass.ForeColor = Color.Gray
        chkShowPass.Location = New Point(67, 469)
        chkShowPass.Margin = New Padding(4, 5, 4, 5)
        chkShowPass.Name = "chkShowPass"
        chkShowPass.Size = New Size(132, 24)
        chkShowPass.TabIndex = 3
        chkShowPass.Text = "Show Password"
        chkShowPass.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        btnClose.ForeColor = Color.Gray
        btnClose.Location = New Point(547, 0)
        btnClose.Margin = New Padding(4, 5, 4, 5)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(53, 62)
        btnClose.TabIndex = 10
        btnClose.Text = "×"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblRegisterLink
        ' 
        lblRegisterLink.AutoSize = True
        lblRegisterLink.Cursor = Cursors.Hand
        lblRegisterLink.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblRegisterLink.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblRegisterLink.Location = New Point(353, 662)
        lblRegisterLink.Margin = New Padding(4, 0, 4, 0)
        lblRegisterLink.Name = "lblRegisterLink"
        lblRegisterLink.Size = New Size(74, 23)
        lblRegisterLink.TabIndex = 5
        lblRegisterLink.Text = "Sign Up"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 10F)
        Label5.ForeColor = Color.Gray
        Label5.Location = New Point(153, 662)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(191, 23)
        Label5.TabIndex = 8
        Label5.Text = "Don't have an account?"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        btnLogin.Cursor = Cursors.Hand
        btnLogin.FlatAppearance.BorderSize = 0
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(67, 538)
        btnLogin.Margin = New Padding(4, 5, 4, 5)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(467, 77)
        btnLogin.TabIndex = 3
        btnLogin.Text = "LOGIN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' pnlPassLine
        ' 
        pnlPassLine.BackColor = Color.Silver
        pnlPassLine.Location = New Point(67, 446)
        pnlPassLine.Margin = New Padding(4, 5, 4, 5)
        pnlPassLine.Name = "pnlPassLine"
        pnlPassLine.Size = New Size(467, 3)
        pnlPassLine.TabIndex = 6
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.White
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 14F)
        txtPassword.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        txtPassword.Location = New Point(67, 400)
        txtPassword.Margin = New Padding(4, 5, 4, 5)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "•"c
        txtPassword.Size = New Size(467, 32)
        txtPassword.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(61, 362)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 23)
        Label2.TabIndex = 4
        Label2.Text = "Password"
        ' 
        ' pnlUserLine
        ' 
        pnlUserLine.BackColor = Color.Silver
        pnlUserLine.Location = New Point(67, 308)
        pnlUserLine.Margin = New Padding(4, 5, 4, 5)
        pnlUserLine.Name = "pnlUserLine"
        pnlUserLine.Size = New Size(467, 3)
        pnlUserLine.TabIndex = 3
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.White
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 14F)
        txtUsername.ForeColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        txtUsername.Location = New Point(67, 262)
        txtUsername.Margin = New Padding(4, 5, 4, 5)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(467, 32)
        txtUsername.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(61, 223)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(87, 23)
        Label1.TabIndex = 1
        Label1.Text = "Username"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24F, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
        lblTitle.Location = New Point(56, 92)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(297, 54)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Welcome Back"
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1000, 769)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        pnlRight.ResumeLayout(False)
        pnlRight.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents pnlRight As Panel
    Friend WithEvents lblBrand As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblRegisterLink As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlUserLine As Panel
    Friend WithEvents pnlPassLine As Panel
    Friend WithEvents chkShowPass As CheckBox
End Class
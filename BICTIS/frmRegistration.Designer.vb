<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRegistration
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
        lblWelcome = New Label()
        lblBrand = New Label()
        pnlRight = New Panel()
        chkShowPass = New CheckBox()
        btnClose = New Button()
        lblLoginLink = New Label()
        Label5 = New Label()
        btnRegister = New Button()
        pnlLine4 = New Panel()
        txtFullName = New TextBox()
        Label4 = New Label()
        pnlLine3 = New Panel()
        txtConfirmPass = New TextBox()
        Label3 = New Label()
        pnlLine2 = New Panel()
        txtPassword = New TextBox()
        Label2 = New Label()
        pnlLine1 = New Panel()
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
        pnlLeft.Controls.Add(lblWelcome)
        pnlLeft.Controls.Add(lblBrand)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Margin = New Padding(4, 5, 4, 5)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(400, 769)
        pnlLeft.TabIndex = 0
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI Light", 14.0F)
        lblWelcome.ForeColor = Color.WhiteSmoke
        lblWelcome.Location = New Point(59, 343)
        lblWelcome.Margin = New Padding(4, 0, 4, 0)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(278, 32)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Join the community today."
        ' 
        ' lblBrand
        ' 
        lblBrand.AutoSize = True
        lblBrand.Font = New Font("Segoe UI", 36.0F, FontStyle.Bold)
        lblBrand.ForeColor = Color.White
        lblBrand.Location = New Point(47, 262)
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
        pnlRight.Controls.Add(lblLoginLink)
        pnlRight.Controls.Add(Label5)
        pnlRight.Controls.Add(btnRegister)
        pnlRight.Controls.Add(pnlLine4)
        pnlRight.Controls.Add(txtFullName)
        pnlRight.Controls.Add(Label4)
        pnlRight.Controls.Add(pnlLine3)
        pnlRight.Controls.Add(txtConfirmPass)
        pnlRight.Controls.Add(Label3)
        pnlRight.Controls.Add(pnlLine2)
        pnlRight.Controls.Add(txtPassword)
        pnlRight.Controls.Add(Label2)
        pnlRight.Controls.Add(pnlLine1)
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
        chkShowPass.Font = New Font("Segoe UI", 9.0F)
        chkShowPass.ForeColor = Color.Gray
        chkShowPass.Location = New Point(67, 531)
        chkShowPass.Margin = New Padding(4, 5, 4, 5)
        chkShowPass.Name = "chkShowPass"
        chkShowPass.Size = New Size(132, 24)
        chkShowPass.TabIndex = 16
        chkShowPass.Text = "Show Password"
        chkShowPass.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        btnClose.ForeColor = Color.Gray
        btnClose.Location = New Point(547, 0)
        btnClose.Margin = New Padding(4, 5, 4, 5)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(53, 62)
        btnClose.TabIndex = 12
        btnClose.Text = "×"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblLoginLink
        ' 
        lblLoginLink.AutoSize = True
        lblLoginLink.Cursor = Cursors.Hand
        lblLoginLink.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        lblLoginLink.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lblLoginLink.Location = New Point(353, 685)
        lblLoginLink.Margin = New Padding(4, 0, 4, 0)
        lblLoginLink.Name = "lblLoginLink"
        lblLoginLink.Size = New Size(98, 23)
        lblLoginLink.TabIndex = 15
        lblLoginLink.Text = "Login Here"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F)
        Label5.ForeColor = Color.Gray
        Label5.Location = New Point(133, 685)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(206, 23)
        Label5.TabIndex = 14
        Label5.Text = "Already have an account?"
        ' 
        ' btnRegister
        ' 
        btnRegister.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnRegister.Cursor = Cursors.Hand
        btnRegister.FlatAppearance.BorderSize = 0
        btnRegister.FlatStyle = FlatStyle.Flat
        btnRegister.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnRegister.ForeColor = Color.White
        btnRegister.Location = New Point(67, 592)
        btnRegister.Margin = New Padding(4, 5, 4, 5)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(467, 69)
        btnRegister.TabIndex = 5
        btnRegister.Text = "REGISTER"
        btnRegister.UseVisualStyleBackColor = False
        ' 
        ' pnlLine4
        ' 
        pnlLine4.BackColor = Color.Silver
        pnlLine4.Location = New Point(67, 508)
        pnlLine4.Margin = New Padding(4, 5, 4, 5)
        pnlLine4.Name = "pnlLine4"
        pnlLine4.Size = New Size(467, 3)
        pnlLine4.TabIndex = 12
        ' 
        ' txtFullName
        ' 
        txtFullName.BackColor = Color.White
        txtFullName.BorderStyle = BorderStyle.None
        txtFullName.Font = New Font("Segoe UI", 12.0F)
        txtFullName.Location = New Point(67, 469)
        txtFullName.Margin = New Padding(4, 5, 4, 5)
        txtFullName.Name = "txtFullName"
        txtFullName.Size = New Size(467, 27)
        txtFullName.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.0F)
        Label4.ForeColor = Color.Gray
        Label4.Location = New Point(61, 431)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 23)
        Label4.TabIndex = 10
        Label4.Text = "Full Name"
        ' 
        ' pnlLine3
        ' 
        pnlLine3.BackColor = Color.Silver
        pnlLine3.Location = New Point(67, 408)
        pnlLine3.Margin = New Padding(4, 5, 4, 5)
        pnlLine3.Name = "pnlLine3"
        pnlLine3.Size = New Size(467, 3)
        pnlLine3.TabIndex = 9
        ' 
        ' txtConfirmPass
        ' 
        txtConfirmPass.BackColor = Color.White
        txtConfirmPass.BorderStyle = BorderStyle.None
        txtConfirmPass.Font = New Font("Segoe UI", 12.0F)
        txtConfirmPass.Location = New Point(67, 369)
        txtConfirmPass.Margin = New Padding(4, 5, 4, 5)
        txtConfirmPass.Name = "txtConfirmPass"
        txtConfirmPass.PasswordChar = "•"c
        txtConfirmPass.Size = New Size(467, 27)
        txtConfirmPass.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 10.0F)
        Label3.ForeColor = Color.Gray
        Label3.Location = New Point(61, 331)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(146, 23)
        Label3.TabIndex = 7
        Label3.Text = "Confirm Password"
        ' 
        ' pnlLine2
        ' 
        pnlLine2.BackColor = Color.Silver
        pnlLine2.Location = New Point(67, 308)
        pnlLine2.Margin = New Padding(4, 5, 4, 5)
        pnlLine2.Name = "pnlLine2"
        pnlLine2.Size = New Size(467, 3)
        pnlLine2.TabIndex = 6
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.White
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 12.0F)
        txtPassword.Location = New Point(67, 269)
        txtPassword.Margin = New Padding(4, 5, 4, 5)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "•"c
        txtPassword.Size = New Size(467, 27)
        txtPassword.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F)
        Label2.ForeColor = Color.Gray
        Label2.Location = New Point(61, 231)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 23)
        Label2.TabIndex = 4
        Label2.Text = "Password"
        ' 
        ' pnlLine1
        ' 
        pnlLine1.BackColor = Color.Silver
        pnlLine1.Location = New Point(67, 208)
        pnlLine1.Margin = New Padding(4, 5, 4, 5)
        pnlLine1.Name = "pnlLine1"
        pnlLine1.Size = New Size(467, 3)
        pnlLine1.TabIndex = 3
        ' 
        ' txtUsername
        ' 
        txtUsername.BackColor = Color.White
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 12.0F)
        txtUsername.Location = New Point(67, 169)
        txtUsername.Margin = New Padding(4, 5, 4, 5)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(467, 27)
        txtUsername.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.0F)
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(61, 131)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(87, 23)
        Label1.TabIndex = 1
        Label1.Text = "Username"
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lblTitle.Location = New Point(56, 31)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(294, 54)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Create Account"
        ' 
        ' frmRegistration
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1000, 769)
        Controls.Add(pnlRight)
        Controls.Add(pnlLeft)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 5, 4, 5)
        Name = "frmRegistration"
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
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFullName As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblLoginLink As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlLine1 As Panel
    Friend WithEvents pnlLine2 As Panel
    Friend WithEvents pnlLine3 As Panel
    Friend WithEvents pnlLine4 As Panel
    Friend WithEvents chkShowPass As CheckBox
End Class
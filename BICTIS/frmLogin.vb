Imports System.Collections.Generic

Public Class frmLogin
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' VALIDATION CONDITION
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter both Username and Password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' NO HASHING - Plain Text Check
        Dim query As String = "SELECT * FROM tblResidents WHERE Username=@user AND [Password]=@pass"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", txtUsername.Text)
        params.Add("@pass", txtPassword.Text)

        Dim dt As DataTable = Session.GetDataTable(query, params)

        If dt.Rows.Count > 0 Then
            ' FIX: Check if Account is Active (Soft Delete support)
            Dim isActive As Boolean = True
            If dt.Rows(0).Table.Columns.Contains("IsActive") AndAlso Not IsDBNull(dt.Rows(0)("IsActive")) Then
                isActive = Convert.ToBoolean(dt.Rows(0)("IsActive"))
            End If

            If Not isActive Then
                MessageBox.Show("This account has been deactivated. Please contact the Admin.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Session.CurrentResidentID = Convert.ToInt32(dt.Rows(0)("ResidentID"))
            Session.CurrentUserRole = dt.Rows(0)("Role").ToString()
            Session.CurrentUserName = dt.Rows(0)("Username").ToString()
            Session.CurrentFullName = dt.Rows(0)("FullName").ToString()

            MessageBox.Show("Welcome, " & Session.CurrentFullName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            If Session.CurrentUserRole = "Admin" Or Session.CurrentUserRole = "Secretary" Then
                Dim dash As New adminDashboard()
                dash.Show()
            Else
                Dim userDash As New frmUser()
                userDash.Show()
            End If
            Me.Hide()
        Else
            MessageBox.Show("Invalid Username or Password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "•"c
        End If
    End Sub

    Private Sub lblRegisterLink_Click(sender As Object, e As EventArgs) Handles lblRegisterLink.Click
        Dim reg As New frmRegistration()
        reg.Show()
        Me.Hide()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class
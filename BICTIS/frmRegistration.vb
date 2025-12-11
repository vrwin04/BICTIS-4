Imports System.Collections.Generic

Public Class frmRegistration
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' VALIDATION: Ensure all fields are filled
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
           String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
           String.IsNullOrWhiteSpace(txtFullName.Text) Then

            MessageBox.Show("All fields are required. Please complete the form.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' VALIDATION: Password Confirmation
        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' VALIDATION: Check for Duplicate Username
        Dim checkParams As New Dictionary(Of String, Object)
        checkParams.Add("@user", txtUsername.Text)
        If Session.GetCount("SELECT COUNT(*) FROM tblResidents WHERE Username=@user", checkParams) > 0 Then
            MessageBox.Show("Username is already taken.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' SECURITY UPDATE: Hash the password before saving to database
        Dim hashedPassword As String = Session.ComputeHash(txtPassword.Text)

        ' INSERT NEW USER
        Dim query As String = "INSERT INTO tblResidents (Username, [Password], Role, FullName, IsActive) VALUES (@user, @pass, 'User', @full, True)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", txtUsername.Text)
        params.Add("@pass", hashedPassword) ' Saving encrypted password
        params.Add("@full", txtFullName.Text)

        If Session.ExecuteQuery(query, params) Then
            ' AUDIT LOG
            Session.LogActivity("New User Registration: " & txtUsername.Text)

            MessageBox.Show("Account Created! Please Login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub chkShowPass_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPass.CheckedChanged
        If chkShowPass.Checked Then
            txtPassword.PasswordChar = ControlChars.NullChar
            txtConfirmPass.PasswordChar = ControlChars.NullChar
        Else
            txtPassword.PasswordChar = "•"c
            txtConfirmPass.PasswordChar = "•"c
        End If
    End Sub

    Private Sub lblLoginLink_Click(sender As Object, e As EventArgs) Handles lblLoginLink.Click
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
End Class
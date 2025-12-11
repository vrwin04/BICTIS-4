Imports System.Collections.Generic

Public Class frmManageResidents
    Private Async Sub frmManageResidents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadResidentsAsync("")
    End Sub

    Private Async Function LoadResidentsAsync(search As String) As Task
        ' FIX: Only show Active users (IsActive=True)
        Dim query As String = "SELECT ResidentID, Username, FullName, Role FROM tblResidents WHERE Role='User' AND IsActive=True"
        Dim params As New Dictionary(Of String, Object)

        If Not String.IsNullOrWhiteSpace(search) Then
            query &= " AND (FullName LIKE @search OR Username LIKE @search)"
            params.Add("@search", "%" & search & "%")
        End If

        Dim dt As DataTable = Await Session.GetDataTableAsync(query, params)
        dgvResidents.DataSource = dt
    End Function

    ' Async Search on Text Change
    Private Async Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Await LoadResidentsAsync(txtSearch.Text)
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvResidents.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim uid As Integer = Convert.ToInt32(dgvResidents.SelectedRows(0).Cells("ResidentID").Value)

        ' FIX: Changed to "Deactivate" and used UPDATE instead of DELETE to prevent crashes
        If MessageBox.Show("Are you sure you want to deactivate this user? They will no longer be able to login.", "Confirm Deactivation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Session.ExecuteQuery("UPDATE tblResidents SET IsActive=False WHERE ResidentID=" & uid)
            MessageBox.Show("User Deactivated.", "Success")
            Await LoadResidentsAsync(txtSearch.Text)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
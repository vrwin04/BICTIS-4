Imports System.Collections.Generic

Public Class frmRequestClearance
    Private Sub frmRequestClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbPurpose.Items.Clear()
        cbPurpose.Items.AddRange(New String() {
            "Employment",
            "Business Permit",
            "Scholarship",
            "Residency Proof",
            "Postal ID",
            "Bank Requirement",
            "Other"
        })
        cbPurpose.SelectedIndex = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If String.IsNullOrWhiteSpace(cbPurpose.Text) Then
            MessageBox.Show("Please select a purpose.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "INSERT INTO tblClearances (ResidentID, Purpose, Status, DateIssued) VALUES (@uid, @purp, 'Pending', @date)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentResidentID)
        params.Add("@purp", cbPurpose.Text)
        params.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Request submitted successfully." & vbCrLf & "Please wait for approval.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
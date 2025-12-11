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

        ' 1. CHECK VALIDATION FOR INPUT
        If String.IsNullOrWhiteSpace(cbPurpose.Text) Then
            MessageBox.Show("Please select a purpose.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 2. CHECK FOR PENDING CASES [NEW LOGIC]
        ' Tinitignan nito kung ang user (ComplainantID) o kung siya ang inireklamo (RespondentID) ay may pending na kaso.
        ' Note: Sa current system niyo, ComplainantID lang ang tiyak na naka-link, pero sinama ko na ang RespondentID para future-proof.
        Dim checkQuery As String = "SELECT COUNT(*) FROM tblIncidents WHERE (ComplainantID = @uid OR RespondentID = @uid) AND Status = 'Pending' AND Category='Blotter'"
        Dim checkParams As New Dictionary(Of String, Object)
        checkParams.Add("@uid", Session.CurrentResidentID)

        Dim pendingCount As Integer = Session.GetCount(checkQuery, checkParams)

        If pendingCount > 0 Then
            MessageBox.Show("ACCESS DENIED: You can't request a clearance because you have a pending case.", "Clearance Blocked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' 3. PROCEED TO SUBMIT IF NO PENDING CASE
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


End Class
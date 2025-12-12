Imports System.Collections.Generic

Public Class frmRequestClearance
    ' Delegate/Event para mag-refresh ang User Dashboard pagkatapos mag-submit
    Public Delegate Sub RefreshDashboardDelegate()
    Public Event DashboardNeedsRefresh As RefreshDashboardDelegate

    Private Sub frmRequestClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' POPULATE PURPOSE
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
        If cbPurpose.Items.Count > 0 Then cbPurpose.SelectedIndex = 0

        ' POPULATE CERTIFICATE TYPE
        cbCertType.Items.Clear()
        cbCertType.Items.AddRange(New String() {
            "Barangay Clearance",
            "Certificate of Residency",
            "Certificate of Indigency",
            "First Time Job Seeker"
        })
        If cbCertType.Items.Count > 0 Then cbCertType.SelectedIndex = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        ' 1. CHECK VALIDATION FOR INPUT
        If String.IsNullOrWhiteSpace(cbCertType.Text) OrElse String.IsNullOrWhiteSpace(cbPurpose.Text) Then
            MessageBox.Show("Please select Certificate Type and Purpose.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' --- TINANGGAL NA ANG BLOCKING LOGIC DITO ---
        ' Wala nang checking sa tblIncidents. Submit agad.

        ' 2. PROCEED TO SUBMIT
        Dim query As String = "INSERT INTO tblClearances (ResidentID, CertificateType, Purpose, Status, DateIssued, DateNeeded) VALUES (@uid, @type, @purp, 'Pending', @date, @need)"

        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentResidentID)
        params.Add("@type", cbCertType.Text)
        params.Add("@purp", cbPurpose.Text)
        params.Add("@date", DateTime.Now.ToString())
        params.Add("@need", dtpNeeded.Value.ToShortDateString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Request submitted successfully. Please wait for Admin to schedule your pickup.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Trigger the dashboard refresh event
            RaiseEvent DashboardNeedsRefresh()

            Me.Close()
        End If
    End Sub
End Class
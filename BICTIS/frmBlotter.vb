Imports System.Collections.Generic

Public Class frmBlotter
    Private Sub frmBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "BLOTTER CASES (Admin)"
        LoadDropdowns()
        LoadIncidents() ' Load all initially
    End Sub

    Private Sub LoadDropdowns()
        ' 1. Status Dropdown
        cbStatus.Items.Clear()
        cbStatus.Items.AddRange(New String() {"Resolved", "Dismissed", "Escalated"})
        cbStatus.SelectedIndex = 0

        ' 2. Complainant Dropdown (Residents)
        Dim dt As DataTable = Session.GetDataTable("SELECT ResidentID, FullName FROM tblResidents WHERE Role='User'")
        cbComplainant.DataSource = dt
        cbComplainant.DisplayMember = "FullName"
        cbComplainant.ValueMember = "ResidentID"
        cbComplainant.SelectedIndex = -1

        ' 3. Respondent Dropdown (Departments)
        cbRespondent.DataSource = Nothing
        cbRespondent.Items.Clear()
        cbRespondent.Items.Add("All Incidents")
        cbRespondent.Items.AddRange(New String() {
            "Peace and Order Committee",
            "Lupon Tagapamayapa",
            "Barangay Health Office",
            "Resident (See Narrative)"
        })
        cbRespondent.SelectedIndex = 0
    End Sub

    ' IMPROVED: LoadIncidents now supports Search
    Private Sub LoadIncidents(Optional filterByRespondent As String = "", Optional searchTerm As String = "")
        Dim sql As String = "SELECT i.IncidentID, i.IncidentType, u.FullName AS Complainant, i.Status, i.IncidentDate, i.Narrative " &
                            "FROM tblIncidents i " &
                            "LEFT JOIN tblResidents u ON i.ComplainantID = u.ResidentID " &
                            "WHERE i.Category='Blotter' "

        Dim params As New Dictionary(Of String, Object)

        ' Filter by Respondent/Department
        If Not String.IsNullOrEmpty(filterByRespondent) AndAlso filterByRespondent <> "All Incidents" Then
            sql &= "AND i.Narrative LIKE @resp "
            params.Add("@resp", "%[Respondent: " & filterByRespondent & "]%")
        End If

        ' SEARCH FUNCTIONALITY (Addresses Retrieval Gap)
        If Not String.IsNullOrEmpty(searchTerm) Then
            sql &= "AND (u.FullName LIKE @search OR i.IncidentType LIKE @search OR i.Narrative LIKE @search) "
            params.Add("@search", "%" & searchTerm & "%")
        End If

        sql &= "ORDER BY i.IncidentID DESC"

        dgvCases.DataSource = Session.GetDataTable(sql, params)
    End Sub

    ' Search Box Event Handler
    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        LoadIncidents(cbRespondent.Text, txtSearch.Text)
    End Sub

    Private Sub cbRespondent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRespondent.SelectedIndexChanged
        If cbRespondent.SelectedItem Is Nothing Then Exit Sub

        Dim selectedRespondent As String = cbRespondent.Text

        ' Update Grid Filter
        LoadIncidents(selectedRespondent, txtSearch.Text)

        ' Update Incident Types dynamically
        cbIncidentType.Items.Clear()
        Select Case selectedRespondent
            Case "Peace and Order Committee"
                cbIncidentType.Items.AddRange(New String() {"Physical Injury", "Theft / Robbery", "Harassment / Threats", "Curfew Violation", "Public Disturbance", "Suspicious Activity", "Malicious Mischief"})
            Case "Lupon Tagapamayapa"
                cbIncidentType.Items.AddRange(New String() {"Property / Land Dispute", "Unjust Vexation", "Estafa / Swindling", "Libel / Slander", "Collection of Debt", "Other Civil Dispute"})
            Case "Barangay Health Office"
                cbIncidentType.Items.AddRange(New String() {"Waste Disposal / Trash", "Animal Control / Stray Pets", "Noise Complaint", "Sanitation Issue"})
            Case "Resident (See Narrative)", "All Incidents"
                cbIncidentType.Items.AddRange(New String() {"Physical Injury", "Theft / Robbery", "Property / Land Dispute", "Harassment / Threats", "Unjust Vexation", "Malicious Mischief", "Estafa / Swindling", "Libel / Slander", "Noise Complaint", "Curfew Violation", "Other"})
        End Select

        If cbIncidentType.Items.Count > 0 Then cbIncidentType.SelectedIndex = 0
    End Sub

    ' --- ITO ANG FUNCTION KAPAG NAG-FILE NG BLOTTER ---
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If cbComplainant.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Complainant.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If cbRespondent.Text = "All Incidents" Or String.IsNullOrWhiteSpace(cbRespondent.Text) Then
            MessageBox.Show("Please select a specific Department/Respondent to file this case.", "Invalid Respondent", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(cbIncidentType.Text) OrElse String.IsNullOrWhiteSpace(txtNarrative.Text) Then
            MessageBox.Show("Please complete all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim respondentName As String = cbRespondent.Text
        Dim finalNarrative As String = "[Respondent: " & respondentName & "] " & txtNarrative.Text

        Dim query As String = "INSERT INTO tblIncidents (ComplainantID, RespondentID, IncidentType, Narrative, Status, IncidentDate, Category) " &
                              "VALUES (@comp, 0, @type, @narr, 'Pending', @date, 'Blotter')"

        Dim params As New Dictionary(Of String, Object)
        params.Add("@comp", cbComplainant.SelectedValue)
        params.Add("@type", cbIncidentType.Text)
        params.Add("@narr", finalNarrative)
        params.Add("@date", DateTime.Now.ToString())

        If Session.ExecuteQuery(query, params) Then
            ' AUDIT LOG
            Session.LogActivity("Filed Blotter Case. Complainant ID: " & cbComplainant.SelectedValue.ToString())

            MessageBox.Show("Blotter case filed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNarrative.Clear()
            LoadIncidents(cbRespondent.Text)
        End If
    End Sub

    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click
        If dgvCases.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a case to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim id As Integer = Convert.ToInt32(dgvCases.SelectedRows(0).Cells("IncidentID").Value)
        Dim currentStatus As String = dgvCases.SelectedRows(0).Cells("Status").Value.ToString()
        Dim newStatus As String = cbStatus.Text

        If currentStatus <> "Pending" Then
            MessageBox.Show("This case is already closed (" & currentStatus & ").", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("Mark case as " & newStatus & "?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Session.ExecuteQuery("UPDATE tblIncidents SET Status='" & newStatus & "' WHERE IncidentID=" & id)

            ' AUDIT LOG
            Session.LogActivity("Updated Case #" & id & " to " & newStatus)

            LoadIncidents(cbRespondent.Text)
            MessageBox.Show("Case updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub dgvCases_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCases.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim id As Integer = Convert.ToInt32(dgvCases.Rows(e.RowIndex).Cells("IncidentID").Value)
            Dim detailsForm As New frmCaseDetails()
            detailsForm.LoadData(id)
            detailsForm.ShowDialog()
        End If
    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStatus.SelectedIndexChanged
        If cbStatus.Text <> "" Then
            btnResolve.Text = "SET STATUS TO " & cbStatus.Text.ToUpper()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
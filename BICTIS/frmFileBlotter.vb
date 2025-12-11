Imports System.Collections.Generic

Public Class frmFileBlotter
    Private Sub frmFileBlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load Departments/Jurisdictions
        cbRespondent.Items.Clear()
        cbRespondent.Items.AddRange(New String() {
            "Peace and Order Committee",
            "Lupon Tagapamayapa",
            "Barangay Health Office",
            "Resident (Specific Person)"
        })
        ' Default Select
        cbRespondent.SelectedIndex = 0
    End Sub

    ' *** Change Incident Options based on Jurisdiction ***
    Private Sub cbRespondent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRespondent.SelectedIndexChanged
        cbType.Items.Clear()

        Select Case cbRespondent.Text
            Case "Peace and Order Committee"
                cbType.Items.AddRange(New String() {
                    "Physical Injury", "Theft / Robbery", "Harassment / Threats",
                    "Curfew Violation", "Public Disturbance", "Malicious Mischief"
                })

            Case "Lupon Tagapamayapa"
                cbType.Items.AddRange(New String() {
                    "Property / Land Dispute", "Unjust Vexation", "Estafa / Swindling",
                    "Libel / Slander", "Collection of Debt", "Civil Dispute"
                })

            Case "Barangay Health Office"
                cbType.Items.AddRange(New String() {
                    "Waste Disposal / Trash", "Animal Control / Stray Pets",
                    "Noise Complaint", "Sanitation Issue"
                })

            Case "Resident (Specific Person)"
                ' General list for personal conflicts
                cbType.Items.AddRange(New String() {
                    "Physical Injury", "Theft", "Threats", "Gossip / Slander",
                    "Property Damage", "Other"
                })
        End Select

        If cbType.Items.Count > 0 Then cbType.SelectedIndex = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' VALIDATION
        If String.IsNullOrWhiteSpace(cbRespondent.Text) OrElse
           String.IsNullOrWhiteSpace(cbType.Text) OrElse
           String.IsNullOrWhiteSpace(txtNarrative.Text) Then

            MessageBox.Show("Please complete all details.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim respondentName As String = cbRespondent.Text

        ' FIX: Changed "Target" to "Respondent" to match Admin Search logic
        Dim finalNarrative As String = "[Respondent: " & respondentName & "] " & txtNarrative.Text

        ' Determine Category: "Concern" if Health, "Blotter" otherwise
        Dim cat As String = "Blotter"
        If respondentName = "Barangay Health Office" Then cat = "Concern"

        Dim query As String = "INSERT INTO tblIncidents (ComplainantID, RespondentID, IncidentType, Narrative, Status, IncidentDate, Category) " &
                              "VALUES (@uid, 0, @type, @narr, 'Pending', @date, @cat)"

        Dim params As New Dictionary(Of String, Object)
        params.Add("@uid", Session.CurrentResidentID)
        params.Add("@type", cbType.Text)
        params.Add("@narr", finalNarrative)
        params.Add("@date", DateTime.Now.ToString())
        params.Add("@cat", cat)

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Case filed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
Imports System.Collections.Generic

Public Class frmReportConcern
    ' ** NEW: Delegate and Event Declaration **
    Public Delegate Sub RefreshDashboardDelegate()
    Public Event DashboardNeedsRefresh As RefreshDashboardDelegate
    ' ***************************************

    Private Sub frmReportConcern_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' POPULATE DROPDOWN WITH COMMUNITY CONCERNS ONLY
        cbType.Items.Clear()
        cbType.Items.AddRange(New String() {
            "Noise Complaint",
            "Waste Disposal / Trash",
            "Suspicious Activity",
            "Public Disturbance",
            "Broken Street Light / Infrastructure",
            "Animal Control / Stray Pets",
            "Curfew Violation",
            "Other"
        })
        If cbType.Items.Count > 0 Then cbType.SelectedIndex = 0
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' VALIDATION
        If String.IsNullOrWhiteSpace(cbType.Text) OrElse String.IsNullOrWhiteSpace(txtNarrative.Text) Then
            MessageBox.Show("Please select a category and enter the details of your concern.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' FIX: Save with Category = 'Concern'
            Dim query As String = "INSERT INTO tblIncidents (ComplainantID, IncidentType, Narrative, Status, IncidentDate, Category) " &
                                  "VALUES (@uid, @type, @narr, 'Pending', @date, 'Concern')"

            Dim params As New Dictionary(Of String, Object)
            params.Add("@uid", Session.CurrentResidentID)
            params.Add("@type", cbType.Text)
            params.Add("@narr", txtNarrative.Text)
            params.Add("@date", DateTime.Now.ToString())

            If Session.ExecuteQuery(query, params) Then
                MessageBox.Show("Concern reported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' ** NEW: Trigger the Event to Refresh Dashboard **
                RaiseEvent DashboardNeedsRefresh()

                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Submission Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
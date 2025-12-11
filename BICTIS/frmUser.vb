Imports System.Collections.Generic

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
        LoadHistory()
    End Sub

    Private Sub LoadHistory()
        ' Load both Blotters and Concerns for this user
        Dim sql As String = "SELECT IncidentID, Category, IncidentType, Status, IncidentDate FROM tblIncidents " &
                            "WHERE ComplainantID=" & Session.CurrentResidentID & " ORDER BY IncidentID DESC"

        ' Use generic GetDataTable
        Dim dt As DataTable = Session.GetDataTable(sql)
        dgvHistory.DataSource = dt
    End Sub

    ' --- ACTION BUTTONS ---

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        ' OPEN CONCERN FORM
        Dim frm As New frmReportConcern()
        frm.ShowDialog()
        LoadHistory() ' Refresh after closing
    End Sub

    Private Sub btnFileBlotter_Click(sender As Object, e As EventArgs) Handles btnFileBlotter.Click
        ' OPEN BLOTTER FORM
        Dim frm As New frmFileBlotter()
        frm.ShowDialog()
        LoadHistory() ' Refresh after closing
    End Sub

    ' *** ADDED BACK: REQUEST CLEARANCE ***
    Private Sub btnRequestClearance_Click(sender As Object, e As EventArgs) Handles btnRequestClearance.Click
        Dim frm As New frmRequestClearance()
        frm.ShowDialog()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadHistory()
    End Sub

    ' --- VIEW DETAILS ---

    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim id As Integer = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("IncidentID").Value)
            Dim detailsForm As New frmCaseDetails()
            detailsForm.LoadData(id)
            detailsForm.ShowDialog()
        End If
    End Sub

    ' --- LOGOUT ---

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentResidentID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class
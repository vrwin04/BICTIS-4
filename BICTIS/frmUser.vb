Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
        LoadHistory()
    End Sub

    ' --- SWITCH PANEL FUNCTION ---
    Public Sub LoadForm(ByVal form As Object)
        pnlContainer.Controls.Clear()

        Dim f As Form = TryCast(form, Form)
        If f IsNot Nothing Then
            f.TopLevel = False
            f.Dock = DockStyle.Fill
            f.FormBorderStyle = FormBorderStyle.None

            ' ** EVENT HANDLING SETUP **
            If TypeOf f Is frmReportConcern Then
                Dim concernForm = CType(f, frmReportConcern)
                AddHandler concernForm.DashboardNeedsRefresh, AddressOf RefreshUserDashboard
            ElseIf TypeOf f Is frmRequestClearance Then
                Dim clearanceForm = CType(f, frmRequestClearance)
                AddHandler clearanceForm.DashboardNeedsRefresh, AddressOf RefreshUserDashboard
            End If

            pnlContainer.Controls.Add(f)
            pnlContainer.Tag = f
            f.Show()
        End If
    End Sub

    Private Sub RefreshUserDashboard()
        LoadHistory()
    End Sub

    ' --- RELOAD HISTORY (HOME BUTTON) ---
    Private Sub LoadHistory()
        pnlContainer.Controls.Clear()
        pnlContainer.Controls.Add(pnlHistoryCard)

        Dim sql As String = "SELECT IncidentID, IncidentType, Status, IncidentDate, 'Incident' AS Category FROM tblIncidents " &
                            "WHERE ComplainantID=" & Session.CurrentResidentID &
                            " UNION ALL " &
                            "SELECT ClearanceID AS IncidentID, CertificateType AS IncidentType, Status, DateIssued AS IncidentDate, 'Clearance' AS Category FROM tblClearances " &
                            "WHERE ResidentID=" & Session.CurrentResidentID &
                            " ORDER BY IncidentDate DESC"

        Dim dt As DataTable = Session.GetDataTable(sql)
        dgvHistory.DataSource = dt

        If dgvHistory.Columns.Contains("Category") Then dgvHistory.Columns("Category").Visible = False

        If dgvHistory.Columns.Contains("IncidentID") Then dgvHistory.Columns("IncidentID").HeaderText = "Ref #"
        If dgvHistory.Columns.Contains("IncidentType") Then dgvHistory.Columns("IncidentType").HeaderText = "Type / Request"
        If dgvHistory.Columns.Contains("IncidentDate") Then dgvHistory.Columns("IncidentDate").HeaderText = "Date Filed"

        ' VISUAL UPDATE: Color Coding
        For Each row As DataGridViewRow In dgvHistory.Rows
            Dim status As String = row.Cells("Status").Value.ToString()
            If status = "Approved" Or status = "Completed" Or status = "Resolved" Then
                row.DefaultCellStyle.ForeColor = Color.DarkGreen
                row.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                row.DefaultCellStyle.SelectionForeColor = Color.Black
            ElseIf status = "Rejected" Or status = "Invalid" Then
                row.DefaultCellStyle.ForeColor = Color.Red
            Else
                row.DefaultCellStyle.ForeColor = Color.DarkOrange
            End If
        Next
    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        LoadForm(New frmReportConcern())
    End Sub

    Private Sub btnRequestClearance_Click(sender As Object, e As EventArgs) Handles btnRequestClearance.Click
        LoadForm(New frmRequestClearance())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadHistory()
    End Sub

    ' --- VIEW DETAILS ---
    ' --- VIEW DETAILS ---
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Kumuha ng category upang matukoy kung ito ay Clearance o Incident
            Dim category As String = "Incident" ' Default
            If dgvHistory.Columns.Contains("Category") Then
                category = dgvHistory.Rows(e.RowIndex).Cells("Category").Value.ToString()
            End If

            Dim id As Integer = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("IncidentID").Value)

            If category = "Clearance" Then
                ' MODIFIED: Buksan ang NEW separate form para sa Clearance Status
                Dim statusForm As New frmClearanceStatus()
                statusForm.LoadStatus(id)
                statusForm.ShowDialog()
                Exit Sub
            End If

            ' Kung hindi Clearance (Incident/Blotter), buksan ang dating details form
            Dim detailsForm As New frmCaseDetails()
            detailsForm.LoadData(id)
            detailsForm.ShowDialog()
        End If
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentResidentID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class
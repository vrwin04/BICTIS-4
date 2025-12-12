Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing ' Kinakailangan para sa Color

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
        LoadHistory() ' Default view
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
            ' ******************************

            pnlContainer.Controls.Add(f)
            pnlContainer.Tag = f
            f.Show()
        End If
    End Sub

    ' ** Handler na tatawagin kapag nag-submit para mag-refresh ang listahan **
    Private Sub RefreshUserDashboard()
        LoadHistory()
    End Sub

    ' --- RELOAD HISTORY (HOME BUTTON) ---
    Private Sub LoadHistory()
        pnlContainer.Controls.Clear()
        pnlContainer.Controls.Add(pnlHistoryCard)

        ' Load Data - Pagsamahin ang Incidents at Clearances
        Dim sql As String = "SELECT IncidentID, IncidentType, Status, IncidentDate, 'Incident' AS Category FROM tblIncidents " &
                            "WHERE ComplainantID=" & Session.CurrentResidentID &
                            " UNION ALL " &
                            "SELECT ClearanceID AS IncidentID, CertificateType AS IncidentType, Status, DateIssued AS IncidentDate, 'Clearance' AS Category FROM tblClearances " &
                            "WHERE ResidentID=" & Session.CurrentResidentID &
                            " ORDER BY IncidentDate DESC"

        Dim dt As DataTable = Session.GetDataTable(sql)
        dgvHistory.DataSource = dt

        ' Tiyakin na ang bagong column na 'Category' ay hindi nakikita
        If dgvHistory.Columns.Contains("Category") Then dgvHistory.Columns("Category").Visible = False

        ' Ayusin ang header names
        If dgvHistory.Columns.Contains("IncidentID") Then dgvHistory.Columns("IncidentID").HeaderText = "Ref #"
        If dgvHistory.Columns.Contains("IncidentType") Then dgvHistory.Columns("IncidentType").HeaderText = "Type / Request"
        If dgvHistory.Columns.Contains("IncidentDate") Then dgvHistory.Columns("IncidentDate").HeaderText = "Date Filed"

        ' *** VISUAL UPDATE: Kulayan ang row base sa Status ***
        For Each row As DataGridViewRow In dgvHistory.Rows
            Dim status As String = row.Cells("Status").Value.ToString()

            ' Kung Approved o Completed (Green)
            If status = "Approved" Or status = "Completed" Or status = "Resolved" Then
                row.DefaultCellStyle.ForeColor = Color.DarkGreen
                row.DefaultCellStyle.SelectionBackColor = Color.LightGreen
                row.DefaultCellStyle.SelectionForeColor = Color.Black

                ' Kung Rejected o Invalid (Red)
            ElseIf status = "Rejected" Or status = "Invalid" Then
                row.DefaultCellStyle.ForeColor = Color.Red
                row.DefaultCellStyle.SelectionBackColor = Color.Salmon
                row.DefaultCellStyle.SelectionForeColor = Color.White

                ' Kung Pending (Orange)
            Else
                row.DefaultCellStyle.ForeColor = Color.DarkOrange
            End If
        Next
    End Sub

    ' --- SIDEBAR BUTTONS ---
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
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Kumuha ng category (Incident o Clearance)
            Dim category As String = "Incident"
            If dgvHistory.Columns.Contains("Category") Then
                category = dgvHistory.Rows(e.RowIndex).Cells("Category").Value.ToString()
            End If

            Dim id As Integer = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("IncidentID").Value)
            Dim type As String = dgvHistory.Rows(e.RowIndex).Cells("IncidentType").Value.ToString()
            Dim status As String = dgvHistory.Rows(e.RowIndex).Cells("Status").Value.ToString()

            If category = "Clearance" Then
                ' Show Approval Message
                Dim msg As String = ""
                Dim icon As MessageBoxIcon

                If status = "Approved" Or status = "Completed" Then
                    msg = "GREAT NEWS!" & vbCrLf & vbCrLf &
                          "Your request for " & type.ToUpper() & " is APPROVED." & vbCrLf &
                          "Please proceed to the Barangay Hall to claim your document."
                    icon = MessageBoxIcon.Information
                ElseIf status = "Rejected" Then
                    msg = "We are sorry." & vbCrLf & vbCrLf &
                          "Your request for " & type.ToUpper() & " was REJECTED." & vbCrLf &
                          "Please contact the Barangay Secretary for more info."
                    icon = MessageBoxIcon.Error
                Else
                    msg = "Your request is still PENDING." & vbCrLf &
                          "Please wait for admin approval."
                    icon = MessageBoxIcon.Warning
                End If

                MessageBox.Show(msg, "Clearance Status", MessageBoxButtons.OK, icon)
                Exit Sub
            End If

            ' Kung Incident/Blotter, buksan ang dating details form
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
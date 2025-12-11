Imports System.Collections.Generic

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
        LoadHistory()
    End Sub

    ' --- SWITCH PANEL FUNCTION ---
    Public Sub LoadForm(ByVal form As Object)
        ' Linisin ang panel bago magload ng bago
        pnlContainer.Controls.Clear()

        Dim f As Form = TryCast(form, Form)
        If f IsNot Nothing Then
            f.TopLevel = False
            f.Dock = DockStyle.Fill
            f.FormBorderStyle = FormBorderStyle.None
            pnlContainer.Controls.Add(f)
            pnlContainer.Tag = f
            f.Show()
        End If
    End Sub

    ' --- RELOAD HISTORY (HOME) ---
    Private Sub LoadHistory()
        ' Ibalik ang History Card sa container
        pnlContainer.Controls.Clear()
        pnlContainer.Controls.Add(pnlHistoryCard)

        ' Fetch Data
        Dim sql As String = "SELECT IncidentID, Category, IncidentType, Status, IncidentDate FROM tblIncidents " &
                            "WHERE ComplainantID=" & Session.CurrentResidentID & " ORDER BY IncidentID DESC"
        Dim dt As DataTable = Session.GetDataTable(sql)
        dgvHistory.DataSource = dt
    End Sub

    ' --- BUTTONS ---

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        LoadForm(New frmReportConcern())
    End Sub

    Private Sub btnRequestClearance_Click(sender As Object, e As EventArgs) Handles btnRequestClearance.Click
        LoadForm(New frmRequestClearance())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadHistory()
    End Sub

    ' --- DETAILS VIEW ---
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim id As Integer = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("IncidentID").Value)
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
Imports System.Collections.Generic

Public Class frmUser
    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblWelcome.Text = "Welcome, " & Session.CurrentFullName
        LoadHistory() ' Default view
    End Sub

    ' --- ITO ANG LOGIC NA GINAGAYA MO SA ADMIN DASHBOARD ---
    Public Sub LoadForm(ByVal form As Object)
        ' Linisin ang container panel
        pnlContainer.Controls.Clear()

        Dim f As Form = TryCast(form, Form)
        If f IsNot Nothing Then
            f.TopLevel = False
            f.Dock = DockStyle.Fill ' Mag-aadjust sa size ng panel
            f.FormBorderStyle = FormBorderStyle.None ' Walang border para malinis
            pnlContainer.Controls.Add(f)
            pnlContainer.Tag = f
            f.Show()
        End If
    End Sub

    ' --- RELOAD HISTORY (HOME BUTTON) ---
    Private Sub LoadHistory()
        ' Ibalik ang original na History view
        pnlContainer.Controls.Clear()
        pnlContainer.Controls.Add(pnlHistoryCard) ' Siguraduhing may pnlHistoryCard sa Designer

        ' Load Data
        Dim sql As String = "SELECT IncidentID, Category, IncidentType, Status, IncidentDate FROM tblIncidents " &
                            "WHERE ComplainantID=" & Session.CurrentResidentID & " ORDER BY IncidentID DESC"
        Dim dt As DataTable = Session.GetDataTable(sql)
        dgvHistory.DataSource = dt
    End Sub

    ' --- SIDEBAR BUTTONS ---

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        ' Buksan ang Report Concern form sa loob ng panel
        LoadForm(New frmReportConcern())
    End Sub

    Private Sub btnRequestClearance_Click(sender As Object, e As EventArgs) Handles btnRequestClearance.Click
        ' Buksan ang Request Clearance form sa loob ng panel
        LoadForm(New frmRequestClearance())
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ' Bumalik sa Home / History view
        LoadHistory()
    End Sub

    ' --- VIEW DETAILS ---
    Private Sub dgvHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHistory.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim id As Integer = Convert.ToInt32(dgvHistory.Rows(e.RowIndex).Cells("IncidentID").Value)
            ' Ang Details ay pop-up pa rin para mas madaling basahin ang mahabang kwento
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
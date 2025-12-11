Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Drawing
Imports SysChart = System.Windows.Forms.DataVisualization.Charting

Public Class adminDashboard
    Private Async Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole
        Try
            ' Remove handler temporarily to avoid triggering during load
            RemoveHandler cbIncidentType.SelectedIndexChanged, AddressOf cbIncidentType_SelectedIndexChanged

            LoadFilterOptions()

            ' Re-attach handler
            AddHandler cbIncidentType.SelectedIndexChanged, AddressOf cbIncidentType_SelectedIndexChanged

            Await LoadStatsAsync()
            Await LoadChartAsync()
        Catch ex As Exception
            MessageBox.Show("Error loading dashboard: " & ex.Message)
        End Try
    End Sub

    ' --- PANEL SWITCH LOGIC ---
    Public Sub LoadForm(ByVal form As Object)
        ' Linisin ang laman ng Main Content
        pnlMainContent.Controls.Clear()

        Dim f As Form = TryCast(form, Form)
        If f IsNot Nothing Then
            f.TopLevel = False
            f.Dock = DockStyle.Fill
            f.FormBorderStyle = FormBorderStyle.None
            pnlMainContent.Controls.Add(f)
            pnlMainContent.Tag = f
            f.Show()
        End If
    End Sub

    ' --- MENU BUTTONS ---
    Private Async Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        pnlMainContent.Controls.Clear()
        pnlMainContent.Controls.Add(pnlDashboardView) ' Ibalik ang dashboard stats
        Await LoadStatsAsync() ' Reload stats properly
    End Sub

    Private Sub btnProjects_Click(sender As Object, e As EventArgs) Handles btnProjects.Click
        LoadForm(New frmProjects())
    End Sub

    Private Sub btnConcerns_Click(sender As Object, e As EventArgs) Handles btnConcerns.Click
        LoadForm(New frmConcerns())
    End Sub

    Private Sub btnClearance_Click(sender As Object, e As EventArgs) Handles btnClearance.Click
        LoadForm(New frmClearance())
    End Sub

    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        MessageBox.Show("Reports module coming soon.", "Info")
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentResidentID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    ' --- DASHBOARD LOGIC ---
    Private Async Function LoadStatsAsync() As Task
        Dim taskUserCount = Session.GetCountAsync("SELECT COUNT(*) FROM tblResidents WHERE Role='User'")
        Dim taskPending = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Status='Pending'")
        Dim taskProjects = Session.GetCountAsync("SELECT COUNT(*) FROM tblProjects")
        Dim taskConcerns = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Category='Concern'")

        Dim userCount As Integer = Await taskUserCount
        Dim pending As Integer = Await taskPending
        Dim projects As Integer = Await taskProjects
        Dim concerns As Integer = Await taskConcerns

        lblTotalUsers.Text = userCount.ToString()
        lblPendingCases.Text = pending.ToString()
        lblTotalProjects.Text = projects.ToString()
        lblTotalConcerns.Text = concerns.ToString()

        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If
    End Function

    Private Sub LoadFilterOptions()
        cbIncidentType.Items.Clear()
        cbIncidentType.Items.Add("All Incidents")
        cbIncidentType.Items.AddRange(New String() {"Noise Complaint", "Waste Disposal", "Suspicious Activity", "Others"})
        If cbIncidentType.Items.Count > 0 Then cbIncidentType.SelectedIndex = 0
    End Sub

    Private Async Sub cbIncidentType_SelectedIndexChanged(sender As Object, e As EventArgs)
        Await LoadChartAsync()
    End Sub

    Private Async Function LoadChartAsync() As Task
        If chartIncidents Is Nothing Then Exit Function

        Dim selection As String = cbIncidentType.Text
        If String.IsNullOrWhiteSpace(selection) Then selection = "All Incidents"

        Dim query As String
        Dim params As New Dictionary(Of String, Object)
        Dim isAll As Boolean = (selection = "All Incidents")

        If isAll Then
            query = "SELECT IncidentType, COUNT(*) as [Count] FROM tblIncidents GROUP BY IncidentType"
        Else
            query = "SELECT Status, COUNT(*) as [Count] FROM tblIncidents WHERE IncidentType=@type GROUP BY Status"
            params.Add("@type", selection)
        End If

        Dim dt As DataTable = Await Session.GetDataTableAsync(query, params)
        chartIncidents.Series.Clear()
        chartIncidents.Titles.Clear()

        Dim s As New SysChart.Series(If(isAll, "Incidents", "Status"))
        s.ChartType = If(isAll, SysChart.SeriesChartType.Column, SysChart.SeriesChartType.Pie)
        s.ChartArea = "ChartArea1"
        s.IsValueShownAsLabel = True

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim xVal As String = row(0).ToString()
                Dim yVal As Integer = Convert.ToInt32(row("Count"))
                s.Points.AddXY(xVal, yVal)
            Next
        Else
            s.Points.AddXY("No Data", 0)
        End If
        chartIncidents.Series.Add(s)
    End Function
End Class
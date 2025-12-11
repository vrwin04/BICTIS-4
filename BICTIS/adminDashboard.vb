' ALIAS TO FIX CHART ERRORS
Imports SysChart = System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System.Threading.Tasks ' Required for Async
Imports System.Drawing ' Required for Color

Public Class adminDashboard
    Private Async Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole

        Try
            ' 1. Load Filters FIRST.
            RemoveHandler cbIncidentType.SelectedIndexChanged, AddressOf cbIncidentType_SelectedIndexChanged
            LoadFilterOptions()
            AddHandler cbIncidentType.SelectedIndexChanged, AddressOf cbIncidentType_SelectedIndexChanged

            ' 2. Load Stats
            Await LoadStatsAsync()

            ' 3. Force the Chart to load now that everything is ready
            Await LoadChartAsync()

        Catch ex As Exception
            MessageBox.Show("Error loading dashboard: " & ex.Message)
        End Try
    End Sub

    Private Async Function LoadStatsAsync() As Task
        ' Fetch all counts in parallel for speed
        Dim taskUserCount = Session.GetCountAsync("SELECT COUNT(*) FROM tblResidents WHERE Role='User'")
        Dim taskPending = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Status='Pending'")
        Dim taskBlotter = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Category='Blotter'")
        Dim taskConcerns = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Category='Concern'")

        ' Wait for all
        Dim userCount As Integer = Await taskUserCount
        Dim pending As Integer = Await taskPending
        Dim blotter As Integer = Await taskBlotter
        Dim concerns As Integer = Await taskConcerns

        ' Update UI
        lblTotalUsers.Text = userCount.ToString()
        lblPendingCases.Text = pending.ToString()
        lblTotalBlotter.Text = blotter.ToString()
        lblTotalConcerns.Text = concerns.ToString()

        ' Pending Cases Color Logic
        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If

        ' FIX: Ensure Text Colors match the Graph Colors
        lblTotalBlotter.ForeColor = Color.FromArgb(41, 128, 185) ' Blue
        lblTotalConcerns.ForeColor = Color.FromArgb(192, 57, 43) ' Red
    End Function

    Private Sub LoadFilterOptions()
        cbIncidentType.Items.Clear()
        cbIncidentType.Items.Add("All Incidents")

        ' --- BLOTTER CASES ---
        cbIncidentType.Items.Add("Physical Injury")
        cbIncidentType.Items.Add("Theft / Robbery")
        cbIncidentType.Items.Add("Property / Land Dispute")
        cbIncidentType.Items.Add("Harassment / Threats")
        cbIncidentType.Items.Add("Unjust Vexation")
        cbIncidentType.Items.Add("Malicious Mischief")
        cbIncidentType.Items.Add("Estafa / Swindling")
        cbIncidentType.Items.Add("Libel / Slander")

        ' --- COMMUNITY CONCERNS ---
        cbIncidentType.Items.Add("Noise Complaint")
        cbIncidentType.Items.Add("Waste Disposal / Trash")
        cbIncidentType.Items.Add("Suspicious Activity")
        cbIncidentType.Items.Add("Public Disturbance")
        cbIncidentType.Items.Add("Broken Street Light / Infrastructure")
        cbIncidentType.Items.Add("Animal Control / Stray Pets")
        cbIncidentType.Items.Add("Curfew Violation")

        cbIncidentType.Items.Add("Other")

        ' Default Selection
        If cbIncidentType.Items.Count > 0 Then
            cbIncidentType.SelectedIndex = 0
        End If
    End Sub

    Private Async Sub cbIncidentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIncidentType.SelectedIndexChanged
        Await LoadChartAsync()
    End Sub

    Private Async Function LoadChartAsync() As Task
        If chartIncidents Is Nothing Then Exit Function

        Dim selection As String = cbIncidentType.Text
        ' Safety check
        If String.IsNullOrWhiteSpace(selection) Then selection = "All Incidents"

        Dim query As String
        Dim params As New Dictionary(Of String, Object)
        Dim isAllIncidents As Boolean = (selection = "All Incidents")

        If isAllIncidents Then
            ' FIX: Group by Category as well so we can check it for coloring
            query = "SELECT IncidentType, Category, COUNT(*) as [Count] FROM tblIncidents GROUP BY IncidentType, Category"
        Else
            query = "SELECT Status, COUNT(*) as [Count] FROM tblIncidents WHERE IncidentType=@type GROUP BY Status"
            params.Add("@type", selection)
        End If

        ' Fetch Data Background
        Dim dt As DataTable = Await Session.GetDataTableAsync(query, params)

        ' Update UI
        chartIncidents.Series.Clear()
        chartIncidents.Titles.Clear()

        Dim seriesName As String = If(isAllIncidents, "Incidents", "Status")
        Dim series As New SysChart.Series(seriesName)

        ' *** CRITICAL FIX: Assign the Series to the ChartArea ***
        series.ChartArea = "ChartArea1"

        If isAllIncidents Then
            series.ChartType = SysChart.SeriesChartType.Column
            chartIncidents.Titles.Add("All Incidents Overview")
        Else
            series.ChartType = SysChart.SeriesChartType.Pie
            chartIncidents.Palette = SysChart.ChartColorPalette.SeaGreen
            chartIncidents.Titles.Add("Status Breakdown: " & selection)
        End If

        series.IsValueShownAsLabel = True

        ' Define Colors
        Dim blotterColor As Color = Color.FromArgb(41, 128, 185) ' Blue
        Dim concernColor As Color = Color.FromArgb(192, 57, 43) ' Red
        Dim neutralColor As Color = Color.Gray

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim xVal As String = ""
                Dim category As String = ""

                If isAllIncidents Then
                    xVal = row("IncidentType").ToString()
                    category = row("Category").ToString() ' Get Category for Coloring
                Else
                    xVal = row("Status").ToString()
                End If

                ' Handle nulls
                If String.IsNullOrEmpty(xVal) Then xVal = "Unknown"

                Dim yVal As Integer = Convert.ToInt32(row("Count"))

                ' Add Point
                Dim pIndex As Integer = series.Points.AddXY(xVal, yVal)
                Dim p As SysChart.DataPoint = series.Points(pIndex)

                ' --- COLOR LOGIC BASED ON DATABASE CATEGORY ---
                If isAllIncidents Then
                    If category = "Blotter" Then
                        p.Color = blotterColor
                    ElseIf category = "Concern" Then
                        p.Color = concernColor
                    Else
                        p.Color = neutralColor
                    End If
                End If
            Next
        Else
            ' Handle empty data gracefully so chart isn't blank
            series.Points.AddXY("No Data", 0)
        End If

        chartIncidents.Series.Add(series)
    End Function

    ' --- NAVIGATION BUTTONS ---

    Private Async Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ' Reload stats and reset chart to "All Incidents"
        Await LoadStatsAsync()
        If cbIncidentType.Items.Count > 0 Then
            cbIncidentType.SelectedIndex = 0
            ' Force load if index didn't change (e.g. was already 0)
            Await LoadChartAsync()
        End If
    End Sub

    Private Async Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        Dim frm As New frmManageResidents()
        frm.ShowDialog()
        Await LoadStatsAsync()
    End Sub

    Private Async Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        Dim frm As New frmProjects()
        frm.ShowDialog()
        Await LoadStatsAsync()
        Await LoadChartAsync()
    End Sub

    Private Async Sub btnConcerns_Click(sender As Object, e As EventArgs) Handles btnConcerns.Click
        Dim frm As New frmConcerns()
        frm.ShowDialog()
        Await LoadStatsAsync()
        Await LoadChartAsync()
    End Sub

    Private Sub btnClearance_Click(sender As Object, e As EventArgs) Handles btnClearance.Click
        Dim frm As New frmClearance()
        frm.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Sign out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.CurrentResidentID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class
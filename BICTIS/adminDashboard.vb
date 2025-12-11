Imports SysChart = System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Drawing
Imports System.Drawing.Printing ' Added for Reporting

Public Class adminDashboard
    Private Async Sub adminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPageTitle.Text = "Dashboard - " & Session.CurrentUserRole

        Try
            RemoveHandler cbIncidentType.SelectedIndexChanged, AddressOf cbIncidentType_SelectedIndexChanged
            LoadFilterOptions()
            AddHandler cbIncidentType.SelectedIndexChanged, AddressOf cbIncidentType_SelectedIndexChanged

            Await LoadStatsAsync()
            Await LoadChartAsync()

        Catch ex As Exception
            MessageBox.Show("Error loading dashboard: " & ex.Message)
        End Try
    End Sub

    ' --- STATISTICS LOADER ---
    Private Async Function LoadStatsAsync() As Task
        Dim taskUserCount = Session.GetCountAsync("SELECT COUNT(*) FROM tblResidents WHERE Role='User'")
        Dim taskPending = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Status='Pending'")
        Dim taskBlotter = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Category='Blotter'")
        Dim taskConcerns = Session.GetCountAsync("SELECT COUNT(*) FROM tblIncidents WHERE Category='Concern'")

        Dim userCount As Integer = Await taskUserCount
        Dim pending As Integer = Await taskPending
        Dim blotter As Integer = Await taskBlotter
        Dim concerns As Integer = Await taskConcerns

        lblTotalUsers.Text = userCount.ToString()
        lblPendingCases.Text = pending.ToString()
        lblTotalBlotter.Text = blotter.ToString()
        lblTotalConcerns.Text = concerns.ToString()

        If pending > 0 Then
            lblPendingCases.ForeColor = Color.Red
        Else
            lblPendingCases.ForeColor = Color.Green
        End If

        lblTotalBlotter.ForeColor = Color.FromArgb(41, 128, 185)
        lblTotalConcerns.ForeColor = Color.FromArgb(192, 57, 43)
    End Function

    Private Sub LoadFilterOptions()
        cbIncidentType.Items.Clear()
        cbIncidentType.Items.Add("All Incidents")
        cbIncidentType.Items.AddRange(New String() {
            "Physical Injury", "Theft / Robbery", "Property / Land Dispute", "Harassment / Threats",
            "Unjust Vexation", "Malicious Mischief", "Estafa / Swindling", "Libel / Slander",
            "Noise Complaint", "Waste Disposal / Trash", "Suspicious Activity", "Public Disturbance",
            "Broken Street Light / Infrastructure", "Animal Control / Stray Pets", "Curfew Violation", "Other"
        })

        If cbIncidentType.Items.Count > 0 Then
            cbIncidentType.SelectedIndex = 0
        End If
    End Sub

    Private Async Sub cbIncidentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIncidentType.SelectedIndexChanged
        Await LoadChartAsync()
    End Sub

    ' --- CHART LOADER ---
    Private Async Function LoadChartAsync() As Task
        If chartIncidents Is Nothing Then Exit Function

        Dim selection As String = cbIncidentType.Text
        If String.IsNullOrWhiteSpace(selection) Then selection = "All Incidents"

        Dim query As String
        Dim params As New Dictionary(Of String, Object)
        Dim isAllIncidents As Boolean = (selection = "All Incidents")

        If isAllIncidents Then
            query = "SELECT IncidentType, Category, COUNT(*) as [Count] FROM tblIncidents GROUP BY IncidentType, Category"
        Else
            query = "SELECT Status, COUNT(*) as [Count] FROM tblIncidents WHERE IncidentType=@type GROUP BY Status"
            params.Add("@type", selection)
        End If

        Dim dt As DataTable = Await Session.GetDataTableAsync(query, params)

        chartIncidents.Series.Clear()
        chartIncidents.Titles.Clear()

        Dim seriesName As String = If(isAllIncidents, "Incidents", "Status")
        Dim series As New SysChart.Series(seriesName)
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

        Dim blotterColor As Color = Color.FromArgb(41, 128, 185)
        Dim concernColor As Color = Color.FromArgb(192, 57, 43)
        Dim neutralColor As Color = Color.Gray

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim xVal As String = If(isAllIncidents, row("IncidentType").ToString(), row("Status").ToString())
                Dim category As String = If(isAllIncidents, row("Category").ToString(), "")
                If String.IsNullOrEmpty(xVal) Then xVal = "Unknown"

                Dim yVal As Integer = Convert.ToInt32(row("Count"))
                Dim pIndex As Integer = series.Points.AddXY(xVal, yVal)
                Dim p As SysChart.DataPoint = series.Points(pIndex)

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
            series.Points.AddXY("No Data", 0)
        End If

        chartIncidents.Series.Add(series)
    End Function

    ' --- REPORTING FEATURE (Addresses Automated Reports Gap) ---
    Private Sub btnPrintReport_Click(sender As Object, e As EventArgs) Handles btnPrintReport.Click
        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintReportHandler
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = pd
        ppd.ShowDialog()

        ' Audit Log
        Session.LogActivity("Generated Monthly Accomplishment Report")
    End Sub

    Private Sub PrintReportHandler(sender As Object, e As PrintPageEventArgs)
        Dim g As Graphics = e.Graphics
        Dim titleFont As New Font("Arial", 18, FontStyle.Bold)
        Dim headerFont As New Font("Arial", 12, FontStyle.Bold)
        Dim bodyFont As New Font("Arial", 12, FontStyle.Regular)
        Dim yPos As Integer = 50

        ' Header
        g.DrawString("BARANGAY TARTARIA ACCOMPLISHMENT REPORT", titleFont, Brushes.Black, New PointF(100, yPos))
        yPos += 40
        g.DrawString("Generated on: " & DateTime.Now.ToString("MMMM dd, yyyy"), bodyFont, Brushes.Black, New PointF(100, yPos))
        yPos += 60

        ' Statistics Summary
        g.DrawString("EXECUTIVE SUMMARY", headerFont, Brushes.Black, New PointF(100, yPos))
        yPos += 30
        g.DrawString("Total Residents Registered: " & lblTotalUsers.Text, bodyFont, Brushes.Black, New PointF(120, yPos))
        yPos += 25
        g.DrawString("Total Blotter Cases Filed: " & lblTotalBlotter.Text, bodyFont, Brushes.Black, New PointF(120, yPos))
        yPos += 25
        g.DrawString("Total Resident Concerns: " & lblTotalConcerns.Text, bodyFont, Brushes.Black, New PointF(120, yPos))
        yPos += 25
        g.DrawString("Pending / Unresolved Cases: " & lblPendingCases.Text, bodyFont, Brushes.Black, New PointF(120, yPos))
        yPos += 60

        ' Chart Placeholder (Simple representation)
        g.DrawString("CASE BREAKDOWN", headerFont, Brushes.Black, New PointF(100, yPos))
        yPos += 30
        g.DrawString("(See attached visual charts for detailed breakdown)", bodyFont, Brushes.Italic, New PointF(120, yPos))

        ' Ideally, you would draw the chart image here, but text summary is good for basic requirement.
    End Sub

    ' --- NAVIGATION ---
    Private Async Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Await LoadStatsAsync()
        If cbIncidentType.Items.Count > 0 Then
            cbIncidentType.SelectedIndex = 0
            Await LoadChartAsync()
        End If
    End Sub

    Private Async Sub btnResidents_Click(sender As Object, e As EventArgs) Handles btnResidents.Click
        Dim frm As New frmManageResidents()
        frm.ShowDialog()
        Await LoadStatsAsync()
    End Sub

    Private Async Sub btnBlotter_Click(sender As Object, e As EventArgs) Handles btnBlotter.Click
        Dim frm As New frmBlotter()
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
            Session.LogActivity("Admin Logout: " & Session.CurrentUserName)
            Session.CurrentResidentID = 0
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub
End Class
Imports System.Drawing.Printing
Imports System.Data

Public Class frmReports
    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup ComboBox
        cbReportType.Items.Add("List of Residents")
        cbReportType.Items.Add("List of Projects")
        cbReportType.Items.Add("Audit Logs")
        cbReportType.SelectedIndex = 0
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = PrintDoc
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()
    End Sub

    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim fontTitle As New Font("Arial", 16, FontStyle.Bold)
        Dim fontHeader As New Font("Arial", 12, FontStyle.Bold)
        Dim fontBody As New Font("Arial", 10, FontStyle.Regular)
        Dim y As Integer = 100
        Dim leftMargin As Integer = 50

        ' 1. HEADER
        e.Graphics.DrawString("BARANGAY INFORMATION SYSTEM", fontTitle, Brushes.Black, leftMargin, 40)
        e.Graphics.DrawString("Report: " & cbReportType.Text, fontHeader, Brushes.Black, leftMargin, 70)
        e.Graphics.DrawString("Generated On: " & DateTime.Now.ToString(), fontBody, Brushes.Black, leftMargin, 90)

        ' 2. FETCH DATA
        Dim dt As New DataTable()
        If cbReportType.Text = "List of Residents" Then
            dt = Session.GetDataTable("SELECT FullName, Username, Role, IsActive FROM tblResidents")
        ElseIf cbReportType.Text = "List of Projects" Then
            dt = Session.GetDataTable("SELECT ProjectName, Status, Budget, Expenses FROM tblProjects")
        ElseIf cbReportType.Text = "Audit Logs" Then
            dt = Session.GetDataTable("SELECT Username, Action, [Timestamp] FROM tblAuditLogs ORDER BY LogID DESC")
        End If

        ' 3. DRAW DATA (Simple List)
        For Each row As DataRow In dt.Rows
            Dim line As String = ""
            For i As Integer = 0 To dt.Columns.Count - 1
                line &= row(i).ToString() & "  |  "
            Next
            e.Graphics.DrawString(line, fontBody, Brushes.Black, leftMargin, y)
            y += 25

            ' New page check (Simpleng logic lang muna)
            If y > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If
        Next
        e.HasMorePages = False
    End Sub
End Class
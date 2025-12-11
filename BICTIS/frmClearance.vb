Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class frmClearance
    ' I-DECLARE ITO SA TAAS: Member variable for printing
    Private WithEvents PrintDoc As New PrintDocument()

    ' Variables to hold data for printing
    Private SelectedClearanceID As Integer = 0
    Private SelectedResidentName As String = ""
    Private SelectedPurpose As String = ""

    Private Sub frmClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequests()
    End Sub

    Private Sub LoadRequests()
        ' Join on ResidentID to get Full Name
        Dim sql As String = "SELECT c.ClearanceID, c.ResidentID, u.FullName, c.Purpose, c.DateIssued, c.PickupDate, c.Status " &
                            "FROM tblClearances c " &
                            "INNER JOIN tblResidents u ON c.ResidentID = u.ResidentID " &
                            "ORDER BY c.Status ASC, c.DateIssued ASC"
        dgvRequests.DataSource = Session.GetDataTable(sql)

        ' Hide ID columns if they exist
        If dgvRequests.Columns.Contains("ResidentID") Then dgvRequests.Columns("ResidentID").Visible = False
        If dgvRequests.Columns.Contains("ClearanceID") Then dgvRequests.Columns("ClearanceID").Visible = False
    End Sub

    ' --- SCHEDULING LOGIC ---
    Private Sub btnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click
        If dgvRequests.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request first.", "Select Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim id As Integer = Convert.ToInt32(dgvRequests.SelectedRows(0).Cells("ClearanceID").Value)
        Dim pickupDate As String = dtpPickup.Value.ToString("MM/dd/yyyy")

        ' Update Status to 'Scheduled'
        Dim query As String = "UPDATE tblClearances SET Status='Scheduled', PickupDate=@pick WHERE ClearanceID=@id"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@pick", pickupDate)
        params.Add("@id", id)

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Pickup scheduled on " & pickupDate, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadRequests()
        End If
    End Sub

    ' --- PRINTING LOGIC ---
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvRequests.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to print.", "Select Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim status As String = row.Cells("Status").Value.ToString()
        Dim residentID As Integer = Convert.ToInt32(row.Cells("ResidentID").Value)

        ' 1. CHECK: Schedule First
        If status = "Pending" Then
            MessageBox.Show("Please set a Pickup Schedule first before printing.", "Schedule Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' 2. CHECK: Pending Cases (Blocker)
        Dim checkQuery As String = "SELECT COUNT(*) FROM tblIncidents WHERE (ComplainantID = @uid) AND Status = 'Pending'"
        Dim checkParams As New Dictionary(Of String, Object)
        checkParams.Add("@uid", residentID)

        If Session.GetCount(checkQuery, checkParams) > 0 Then
            MessageBox.Show("CANNOT PRINT: This resident has a PENDING case/blotter record.", "Restriction", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        ' 3. PREPARE DATA
        SelectedClearanceID = Convert.ToInt32(row.Cells("ClearanceID").Value)
        SelectedResidentName = row.Cells("FullName").Value.ToString()
        SelectedPurpose = row.Cells("Purpose").Value.ToString()

        ' 4. SHOW PREVIEW
        Dim ppd As New PrintPreviewDialog()
        ppd.Document = PrintDoc
        ppd.WindowState = FormWindowState.Maximized
        ppd.ShowDialog()

        ' 5. UPDATE STATUS TO COMPLETED
        Dim updateQuery As String = "UPDATE tblClearances SET Status='Completed' WHERE ClearanceID=" & SelectedClearanceID
        Session.ExecuteQuery(updateQuery)
        LoadRequests()
    End Sub

    ' --- LAYOUT DESIGN ---
    ' Ito ang PrintPage event handler na inaayos natin. Gumagana ito dahil sa "WithEvents PrintDoc" declaration sa taas.
    Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
        ' FONTS
        Dim fontHeader As New Font("Times New Roman", 18, FontStyle.Bold)
        Dim fontSub As New Font("Arial", 12, FontStyle.Regular)
        Dim fontTitle As New Font("Arial", 24, FontStyle.Bold Or FontStyle.Underline)
        Dim fontBody As New Font("Arial", 14, FontStyle.Regular)

        Dim center As New StringFormat()
        center.Alignment = StringAlignment.Center

        ' HEADER (FIXED: Gumamit ng CSng() para i-convert ang Double result sa Single)
        e.Graphics.DrawString("REPUBLIC OF THE PHILIPPINES", fontSub, Brushes.Black, CSng(e.PageBounds.Width / 2), 50, center)
        e.Graphics.DrawString("BARANGAY BICTIS", fontHeader, Brushes.Black, CSng(e.PageBounds.Width / 2), 80, center)
        e.Graphics.DrawString("OFFICE OF THE PUNONG BARANGAY", fontSub, Brushes.Black, CSng(e.PageBounds.Width / 2), 110, center)

        ' TITLE
        e.Graphics.DrawString("BARANGAY CLEARANCE", fontTitle, Brushes.Black, CSng(e.PageBounds.Width / 2), 180, center)

        ' BODY TEXT (Rectangles are Float/Single so this section is usually fine)
        Dim bodyText As String = vbCrLf & vbCrLf & "TO WHOM IT MAY CONCERN:" & vbCrLf & vbCrLf &
                                 "This is to certify that " & SelectedResidentName.ToUpper() & ", of legal age, is a resident of this Barangay." & vbCrLf & vbCrLf &
                                 "This certification is issued upon request for the purpose of: " & SelectedPurpose.ToUpper() & "." & vbCrLf & vbCrLf &
                                 "Given this " & DateTime.Now.ToString("MMMM dd, yyyy") & "."

        Dim rect As New RectangleF(100, 250, e.PageBounds.Width - 200, 400)
        e.Graphics.DrawString(bodyText, fontBody, Brushes.Black, rect)

        ' FOOTER (FIXED: Added CSng() for the X-coordinates)
        e.Graphics.DrawString("Hon. Captain Name", fontHeader, Brushes.Black, CSng(e.PageBounds.Width - 250), 700)
        e.Graphics.DrawString("Punong Barangay", fontSub, Brushes.Black, CSng(e.PageBounds.Width - 230), 725)
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvRequests.SelectedRows.Count = 0 Then Exit Sub

        Dim id As Integer = Convert.ToInt32(dgvRequests.SelectedRows(0).Cells("ClearanceID").Value)

        If MessageBox.Show("Reject this request?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Session.ExecuteQuery("UPDATE tblClearances SET Status='Rejected' WHERE ClearanceID=" & id)
            LoadRequests()
        End If
    End Sub
End Class
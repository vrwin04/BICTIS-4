Imports System.Collections.Generic
Imports System.Drawing.Printing ' NEW: Required for printing

Public Class frmClearance
    ' Variables to hold data for printing
    Private printName As String = ""
    Private printPurpose As String = ""
    Private printDate As String = ""

    Private Sub frmClearance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRequests()
    End Sub

    Private Sub LoadRequests()
        ' Join on ResidentID to get Full Name
        Dim sql As String = "SELECT c.ClearanceID, u.FullName, c.Purpose, c.DateIssued, c.Status FROM tblClearances c INNER JOIN tblResidents u ON c.ResidentID = u.ResidentID ORDER BY c.DateIssued DESC"
        dgvRequests.DataSource = Session.GetDataTable(sql)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvRequests.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a request to print.", "Select Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As DataGridViewRow = dgvRequests.SelectedRows(0)
        Dim cid As Integer = Convert.ToInt32(row.Cells("ClearanceID").Value)

        ' Store data for the print document
        printName = row.Cells("FullName").Value.ToString()
        printPurpose = row.Cells("Purpose").Value.ToString()
        printDate = DateTime.Now.ToString("MMMM dd, yyyy")

        ' Update status in DB
        Session.ExecuteQuery("UPDATE tblClearances SET Status='Approved' WHERE ClearanceID=" & cid)

        ' Launch Print Preview
        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf PrintPageHandler

        Dim ppd As New PrintPreviewDialog()
        ppd.Document = pd
        ppd.ShowDialog()

        LoadRequests()
    End Sub

    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        ' Define Fonts
        Dim titleFont As New Font("Arial", 24, FontStyle.Bold)
        Dim headerFont As New Font("Arial", 14, FontStyle.Regular)
        Dim bodyFont As New Font("Arial", 12, FontStyle.Regular)

        Dim g As Graphics = e.Graphics
        Dim margin As Integer = 50
        Dim yPos As Integer = 100

        ' Draw Header
        g.DrawString("BARANGAY CLEARANCE", titleFont, Brushes.Black, New PointF(180, yPos))
        yPos += 80

        g.DrawString("TO WHOM IT MAY CONCERN:", headerFont, Brushes.Black, New PointF(margin, yPos))
        yPos += 60

        ' Draw Body
        Dim bodyText As String = "This is to certify that " & printName.ToUpper() & ", a resident of this Barangay, " &
                                 "has no derogatory record on file as of this date." & vbCrLf & vbCrLf &
                                 "This clearance is issued for the purpose of: " & printPurpose.ToUpper() & "."

        Dim rect As New RectangleF(margin, yPos, e.PageBounds.Width - (margin * 2), 300)
        g.DrawString(bodyText, bodyFont, Brushes.Black, rect)

        ' Draw Footer
        yPos += 250
        g.DrawString("Issued this " & printDate, bodyFont, Brushes.Black, New PointF(margin, yPos))

        yPos += 100
        g.DrawString("_______________________", bodyFont, Brushes.Black, New PointF(450, yPos))
        g.DrawString("Barangay Captain", bodyFont, Brushes.Black, New PointF(480, yPos + 30))
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvRequests.SelectedRows.Count = 0 Then Exit Sub
        Dim cid As Integer = Convert.ToInt32(dgvRequests.SelectedRows(0).Cells("ClearanceID").Value)

        If MessageBox.Show("Reject this request?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Session.ExecuteQuery("UPDATE tblClearances SET Status='Rejected' WHERE ClearanceID=" & cid)
            LoadRequests()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
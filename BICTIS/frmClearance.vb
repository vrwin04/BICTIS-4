Imports System.Drawing.Printing ' Huwag kalimutan i-import ito sa pinakataas

' Sa loob ng Class frmClearance
Private WithEvents PrintDoc As New PrintDocument()
Private SelectedClearanceID As Integer = 0
Private SelectedResidentName As String = ""
Private SelectedPurpose As String = ""

Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
    If dgvRequests.SelectedRows.Count = 0 Then
        MessageBox.Show("Please select a request first.", "Select Request", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
    End If

    ' Kunin ang details ng pipiliin
    SelectedClearanceID = dgvRequests.SelectedRows(0).Cells("ClearanceID").Value
    ' Assumes column name in Grid is 'FullName' or similar (adjust based on your grid columns)
    SelectedResidentName = dgvRequests.SelectedRows(0).Cells(1).Value.ToString()
    SelectedPurpose = dgvRequests.SelectedRows(0).Cells("Purpose").Value.ToString()

    ' Ipakita ang Print Preview
    Dim ppd As New PrintPreviewDialog()
    ppd.Document = PrintDoc
    ppd.WindowState = FormWindowState.Maximized
    ppd.ShowDialog()

    ' Update Status to Completed after printing
    Dim query As String = "UPDATE tblClearances SET Status='Completed' WHERE ClearanceID=" & SelectedClearanceID
    Session.ExecuteQuery(query)
    ' ReloadRequests() ' Call your load function here if it exists
End Sub

Private Sub PrintDoc_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDoc.PrintPage
    ' LAYOUT NG CERTIFICATE
    Dim fontHeader As New Font("Times New Roman", 18, FontStyle.Bold)
    Dim fontSub As New Font("Arial", 12, FontStyle.Regular)
    Dim fontBody As New Font("Arial", 14, FontStyle.Regular)

    Dim center As New StringFormat()
    center.Alignment = StringAlignment.Center

    ' Header
    e.Graphics.DrawString("REPUBLIC OF THE PHILIPPINES", fontSub, Brushes.Black, e.PageBounds.Width / 2, 50, center)
    e.Graphics.DrawString("BARANGAY BICTIS", fontHeader, Brushes.Black, e.PageBounds.Width / 2, 80, center)
    e.Graphics.DrawString("OFFICE OF THE PUNONG BARANGAY", fontSub, Brushes.Black, e.PageBounds.Width / 2, 110, center)

    ' Title
    e.Graphics.DrawString("BARANGAY CLEARANCE", New Font("Arial", 24, FontStyle.Bold Or FontStyle.Underline), Brushes.Black, e.PageBounds.Width / 2, 180, center)

    ' Body
    Dim bodyText As String = vbCrLf & vbCrLf & "TO WHOM IT MAY CONCERN:" & vbCrLf & vbCrLf &
                             "This is to certify that " & SelectedResidentName.ToUpper() & ", of legal age, is a resident of this Barangay." & vbCrLf & vbCrLf &
                             "This certification is issued upon request for the purpose of: " & SelectedPurpose.ToUpper() & "." & vbCrLf & vbCrLf &
                             "Given this " & DateTime.Now.ToString("MMMM dd, yyyy") & "."

    Dim rect As New RectangleF(100, 250, e.PageBounds.Width - 200, 400)
    e.Graphics.DrawString(bodyText, fontBody, Brushes.Black, rect)

    ' Footer / Signature
    e.Graphics.DrawString("Hon. Captain Name", fontHeader, Brushes.Black, e.PageBounds.Width - 250, 700)
    e.Graphics.DrawString("Punong Barangay", fontSub, Brushes.Black, e.PageBounds.Width - 230, 725)
End Sub
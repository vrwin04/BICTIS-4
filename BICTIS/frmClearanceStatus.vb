Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data

Public Class frmClearanceStatus

    ' --- LOADER LOGIC ---
    Public Sub LoadStatus(id As Integer)
        ' Kunin ang details pati ang DateNeeded
        Dim query As String = "SELECT CertificateType, Purpose, Status, DateNeeded FROM tblClearances WHERE ClearanceID=@id"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@id", id)

        Dim dt As DataTable = Session.GetDataTable(query, params)
        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)

            lblType.Text = "Type: " & row("CertificateType").ToString()
            lblPurpose.Text = "Purpose: " & row("Purpose").ToString()

            ' Format Date Needed (Para malinaw sa user)
            Dim dNeeded As String = row("DateNeeded").ToString()
            Try
                If Not String.IsNullOrWhiteSpace(dNeeded) Then
                    lblDateNeeded.Text = "Date Needed: " & Convert.ToDateTime(dNeeded).ToString("MMMM dd, yyyy")
                Else
                    lblDateNeeded.Text = "Date Needed: N/A"
                End If
            Catch ex As Exception
                lblDateNeeded.Text = "Date Needed: " & dNeeded
            End Try

            ' Color Coding ng Status
            Dim status As String = row("Status").ToString().ToUpper()

            If status = "COMPLETED" Or status = "APPROVED" Then
                lblStatus.Text = "APPROVED"
                lblStatus.ForeColor = Color.Green
            ElseIf status = "REJECTED" Then
                lblStatus.Text = "REJECTED"
                lblStatus.ForeColor = Color.Red
            Else
                lblStatus.Text = "PENDING"
                lblStatus.ForeColor = Color.Orange
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
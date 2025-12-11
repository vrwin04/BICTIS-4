Public Class frmAuditLogs
    Private Sub frmAuditLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogs()
    End Sub

    Private Sub LoadLogs()
        Dim query As String = "SELECT LogID, Username, Action, [Timestamp] FROM tblAuditLogs ORDER BY LogID DESC"
        dgvLogs.DataSource = Session.GetDataTable(query)
    End Sub
End Class
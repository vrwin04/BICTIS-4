Imports System.Collections.Generic

Public Class frmProjects
    Private Sub frmProjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = "PROJECT MONITORING"
        LoadProjects()
        cbStatus.Items.Clear()
        cbStatus.Items.AddRange(New String() {"Planning", "Ongoing", "Completed"})
    End Sub

    Private Sub LoadProjects()
        Dim query As String = "SELECT * FROM tblProjects ORDER BY ProjectID DESC"
        dgvProjects.DataSource = Session.GetDataTable(query)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtProjectName.Text) Then
            MessageBox.Show("Project Name required.", "Error")
            Exit Sub
        End If

        Dim query As String = "INSERT INTO tblProjects (ProjectName, [Description], Status, Budget, Expenses, DateStarted) VALUES (@name, @desc, @stat, @budg, @exp, @date)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@name", txtProjectName.Text)
        params.Add("@desc", txtDescription.Text)
        params.Add("@stat", cbStatus.Text)
        params.Add("@budg", Val(txtBudget.Text))
        params.Add("@exp", Val(txtExpenses.Text))
        params.Add("@date", DateTime.Now.ToShortDateString())

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Project Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProjects()
            ClearFields()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvProjects.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a project first.", "Error")
            Exit Sub
        End If

        Dim id As Integer = Convert.ToInt32(dgvProjects.SelectedRows(0).Cells("ProjectID").Value)

        Dim query As String = "UPDATE tblProjects SET ProjectName=@name, [Description]=@desc, Status=@stat, Budget=@budg, Expenses=@exp WHERE ProjectID=@id"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@name", txtProjectName.Text)
        params.Add("@desc", txtDescription.Text)
        params.Add("@stat", cbStatus.Text)
        params.Add("@budg", Val(txtBudget.Text))
        params.Add("@exp", Val(txtExpenses.Text))
        params.Add("@id", id)

        If Session.ExecuteQuery(query, params) Then
            MessageBox.Show("Project Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProjects()
            ClearFields()
        End If
    End Sub

    Private Sub dgvProjects_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjects.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProjects.Rows(e.RowIndex)
            txtProjectName.Text = row.Cells("ProjectName").Value.ToString()
            txtDescription.Text = row.Cells("Description").Value.ToString()
            cbStatus.Text = row.Cells("Status").Value.ToString()
            txtBudget.Text = row.Cells("Budget").Value.ToString()
            txtExpenses.Text = row.Cells("Expenses").Value.ToString()
        End If
    End Sub

    Private Sub ClearFields()
        txtProjectName.Clear()
        txtDescription.Clear()
        txtBudget.Clear()
        txtExpenses.Clear()
        cbStatus.SelectedIndex = -1
    End Sub


End Class
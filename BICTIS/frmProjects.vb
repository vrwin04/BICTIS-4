Imports System.Collections.Generic

Public Class frmProjects
    Private Sub frmProjects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tinanggal na ang lblTitle.Text = ... dahil naka-set na ito sa Designer.
        ' Ito ang solusyon sa "lblTitle is not declared" error.

        cbStatus.Items.Clear()
        cbStatus.Items.AddRange(New String() {"Planning", "Ongoing", "Completed"})

        LoadProjects()
    End Sub

    Private Sub LoadProjects()
        Try
            Dim query As String = "SELECT * FROM tblProjects ORDER BY ProjectID DESC"
            Dim dt As DataTable = Session.GetDataTable(query)
            dgvProjects.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Database Error (Load): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtProjectName.Text) Then
            MessageBox.Show("Project Name required.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            ' Insert Query
            Dim query As String = "INSERT INTO tblProjects ([ProjectName], [Description], [Status], [Budget], [Expenses], [DateStarted]) VALUES (@name, @desc, @stat, @budg, @exp, @date)"

            Dim params As New Dictionary(Of String, Object)
            params.Add("@name", txtProjectName.Text)
            params.Add("@desc", txtDescription.Text)
            params.Add("@stat", cbStatus.Text)
            params.Add("@budg", Val(txtBudget.Text))   ' Converts text to number safely
            params.Add("@exp", Val(txtExpenses.Text))  ' Converts text to number safely
            params.Add("@date", DateTime.Now.ToString()) ' Converts date to string compatible with Access

            If Session.ExecuteQuery(query, params) Then
                MessageBox.Show("Project Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProjects()
                ClearFields()
            End If

        Catch ex As Exception
            MessageBox.Show("Database Error (Add): " & ex.Message & vbCrLf & "Check if table 'tblProjects' exists and columns are correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvProjects.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a project from the list first.", "Select Project", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Dim id As Integer = Convert.ToInt32(dgvProjects.SelectedRows(0).Cells("ProjectID").Value)

            Dim query As String = "UPDATE tblProjects SET [ProjectName]=@name, [Description]=@desc, [Status]=@stat, [Budget]=@budg, [Expenses]=@exp WHERE [ProjectID]=@id"

            Dim params As New Dictionary(Of String, Object)
            params.Add("@name", txtProjectName.Text)
            params.Add("@desc", txtDescription.Text)
            params.Add("@stat", cbStatus.Text)
            params.Add("@budg", Val(txtBudget.Text))
            params.Add("@exp", Val(txtExpenses.Text))
            params.Add("@id", id)

            If Session.ExecuteQuery(query, params) Then
                MessageBox.Show("Project Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadProjects()
                ClearFields()
            End If

        Catch ex As Exception
            MessageBox.Show("Database Error (Update): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvProjects_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProjects.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProjects.Rows(e.RowIndex)
            ' Error handling just in case columns are missing in grid
            Try
                txtProjectName.Text = row.Cells("ProjectName").Value.ToString()
                txtDescription.Text = row.Cells("Description").Value.ToString()
                cbStatus.Text = row.Cells("Status").Value.ToString()
                txtBudget.Text = row.Cells("Budget").Value.ToString()
                txtExpenses.Text = row.Cells("Expenses").Value.ToString()
            Catch ex As Exception
                ' Silent fail or log if column names don't match
            End Try
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
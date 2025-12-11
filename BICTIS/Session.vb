Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Security.Cryptography ' Added for Encryption
Imports System.Text ' Added for Text processing

Public Module Session
    ' CONFIGURATION
    Public dbFile As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestDB.accdb")
    Private ReadOnly connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbFile & ";Persist Security Info=False;"

    ' USER STATE
    Public CurrentResidentID As Integer = 0
    Public CurrentUserRole As String = ""
    Public CurrentUserName As String = ""
    Public CurrentFullName As String = ""

    ' --- SECURITY: HASHING FUNCTION (SHA256) ---
    ' This converts plain text passwords into a secure hash string.
    Public Function ComputeHash(rawData As String) As String
        Using sha256Hash As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()
        End Using
    End Function

    ' --- AUDIT TRAIL FUNCTION ---
    ' Logs user actions into the database for accountability.
    Public Sub LogActivity(action As String)
        Dim query As String = "INSERT INTO tblAuditLogs (Username, [Action], [Timestamp]) VALUES (@user, @act, @time)"
        Dim params As New Dictionary(Of String, Object)
        params.Add("@user", If(String.IsNullOrEmpty(CurrentUserName), "Guest", CurrentUserName))
        params.Add("@act", action)
        params.Add("@time", DateTime.Now.ToString())
        ExecuteQuery(query, params)
    End Sub

    ' --- DATABASE METHODS ---
    Public Function GetDataTable(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                    Next
                End If
                Try
                    conn.Open()
                    Dim adapter As New OleDbDataAdapter(cmd)
                    adapter.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("DB Error: " & ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function

    Public Function ExecuteQuery(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Boolean
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                    Next
                End If
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    MessageBox.Show("DB Error: " & ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Function GetCount(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Integer
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                    Next
                End If
                Try
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        Return Convert.ToInt32(result)
                    Else
                        Return 0
                    End If
                Catch ex As Exception
                    Return 0
                End Try
            End Using
        End Using
    End Function

    ' --- ASYNCHRONOUS METHODS ---
    Public Async Function GetDataTableAsync(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Task(Of DataTable)
        Dim dt As New DataTable()
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                    Next
                End If
                Try
                    Await conn.OpenAsync()
                    Await Task.Run(Sub()
                                       Dim adapter As New OleDbDataAdapter(cmd)
                                       adapter.Fill(dt)
                                   End Sub)
                Catch ex As Exception
                    MessageBox.Show("DB Async Error: " & ex.Message)
                End Try
            End Using
        End Using
        Return dt
    End Function

    Public Async Function GetCountAsync(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Task(Of Integer)
        Using conn As New OleDbConnection(connectionString)
            Using cmd As New OleDbCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, If(param.Value, DBNull.Value))
                    Next
                End If
                Try
                    Await conn.OpenAsync()
                    Dim result = Await cmd.ExecuteScalarAsync()
                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        Return Convert.ToInt32(result)
                    Else
                        Return 0
                    End If
                Catch ex As Exception
                    Return 0
                End Try
            End Using
        End Using
    End Function
End Module
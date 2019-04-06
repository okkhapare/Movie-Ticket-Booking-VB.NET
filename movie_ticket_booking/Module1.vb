Imports System.Data.OleDb


Module Module1
    Public cn As New OleDb.OleDbConnection
    Public cmd As New OleDbCommand
    Public cmd1 As New OleDbCommand
    Public da As New OleDbDataAdapter
    Public da1 As New OleDbDataAdapter
    Public ds As New DataSet
    Public ds1 As New DataSet
    Public ds2 As New DataSet
    Public str As String
    Public str1 As String

    Public Sub conn()

        If cn.State = ConnectionState.Closed Then
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Farha\Documents\Visual Studio 2008\Projects\movie_ticket_booking\movie_ticket_booking\movie_ticket.mdb"
            cn.Open()
        End If

    End Sub

End Module

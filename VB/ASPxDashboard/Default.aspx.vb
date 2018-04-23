Imports DevExpress.DataAccess.ConnectionParameters
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ASPxDashboard
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub ASPxDashboard1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs)
            Dim cp As MsSqlConnectionParameters = TryCast(e.ConnectionParameters, MsSqlConnectionParameters)
            If cp IsNot Nothing AndAlso cp.DatabaseName = "Northwind" Then
                cp.AuthorizationType = MsSqlAuthorizationType.SqlServer
                cp.ServerName = ".\sql2016"
                cp.UserName = "Semicolon"
                cp.Password = "semicolon;"

                Dim connString As String = "Server=.\sql2016;Database=Northwind;User Id=Semicolon;Password=""semicolon;"";"
                Dim query As String = "select * from Invoices"

                Dim conn As New SqlConnection(connString)
                Dim cmd As New SqlCommand(query, conn)
                conn.Open()

                Dim da As New SqlDataAdapter(cmd)
                Dim dataTable As New DataTable()
                da.Fill(dataTable)
                conn.Close()
                da.Dispose()
            End If
        End Sub

        Protected Sub ASPxDashboard1_ConfigureItemDataCalculation(ByVal sender As Object, ByVal e As DevExpress.DashboardWeb.ConfigureItemDataCalculationWebEventArgs)
            e.CalculateAllTotals = True
        End Sub
    End Class
End Namespace
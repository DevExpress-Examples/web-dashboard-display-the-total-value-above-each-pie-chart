Imports System
Imports DevExpress.DashboardWeb

Namespace ASPxDashboard
	Partial Public Class [Default]
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ASPxDashboard1_ConfigureItemDataCalculation(ByVal sender As Object, ByVal e As ConfigureItemDataCalculationWebEventArgs)
			e.CalculateAllTotals = True
		End Sub
	End Class
End Namespace
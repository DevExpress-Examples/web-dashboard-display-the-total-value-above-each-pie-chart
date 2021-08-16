using System;
using DevExpress.DashboardWeb;

namespace ASPxDashboard {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxDashboard1_ConfigureItemDataCalculation(object sender, ConfigureItemDataCalculationWebEventArgs e) {
            e.CalculateAllTotals = true;
        }
    }
}
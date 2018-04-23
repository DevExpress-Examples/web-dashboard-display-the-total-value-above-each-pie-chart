using DevExpress.DataAccess.ConnectionParameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPxDashboard {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void ASPxDashboard1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e) {
            MsSqlConnectionParameters cp = e.ConnectionParameters as MsSqlConnectionParameters;
            if (cp != null && cp.DatabaseName == "Northwind") {
                cp.AuthorizationType = MsSqlAuthorizationType.SqlServer;
                cp.ServerName = ".\\sql2016";
                cp.UserName = "Semicolon";
                cp.Password = "semicolon;";

                string connString = "Server=.\\sql2016;Database=Northwind;User Id=Semicolon;Password=\"semicolon;\";";
                string query = "select * from Invoices";

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                conn.Close();
                da.Dispose();
            }
        }

        protected void ASPxDashboard1_ConfigureItemDataCalculation(object sender, DevExpress.DashboardWeb.ConfigureItemDataCalculationWebEventArgs e) {
            e.CalculateAllTotals = true;
        }
    }
}
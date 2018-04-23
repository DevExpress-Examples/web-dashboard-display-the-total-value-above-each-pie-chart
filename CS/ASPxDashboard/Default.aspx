<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPxDashboard.Default" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.1.Web, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <script type="text/javascript">
        function UpdateWidget(s, e) {
            if (e.ItemName == 'pieDashboardItem1') {
                var pies = e.GetWidget();
                var data = s.GetItemData(e.ItemName);
                var measure = data.GetMeasures()[0];
                $.each(pies, function (_, pie) {
                    var axisPoint = pie.option('tag').axisPoint;
                    var total = data.GetSlice(axisPoint).GetMeasureValue(measure.Id).GetDisplayText();
                    var title = pie.option('title')
                    if (!title.hasTotal) {
                        title.text += ' ' + total;
                        title.hasTotal = true;
                        pie.option('title', title);
                    }
                });
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" DashboardStorageFolder="~/App_Data/Dashboards/"  WorkingMode="ViewerOnly" LimitVisibleDataMode="Designer"
                OnConfigureDataConnection="ASPxDashboard1_ConfigureDataConnection" OnConfigureItemDataCalculation="ASPxDashboard1_ConfigureItemDataCalculation">
                <ClientSideEvents ItemWidgetCreated="UpdateWidget" ItemWidgetUpdated="UpdateWidget" />
            </dx:ASPxDashboard>

        </div>
    </form>
</body>
</html>

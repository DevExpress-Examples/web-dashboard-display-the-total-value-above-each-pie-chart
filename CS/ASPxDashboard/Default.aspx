<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPxDashboard.Default" %>

<!DOCTYPE html>

<html>
<head runat="server"> 
    <title></title>
    <style type="text/css">
        html, body, form {  
            height: 100%;  
            margin: 0;  
            padding: 0;  
            overflow: hidden;  
        }
    </style>
    <script type="text/javascript">
        function onBeforeRender(s, e) {
            var dashboardControl = s.GetDashboardControl();
            var viewerApiExtension = dashboardControl.findExtension('viewer-api');

            if (viewerApiExtension)
                viewerApiExtension.on('itemWidgetOptionsPrepared', onItemWidgetOptionsPrepared);
        }

        function onItemWidgetOptionsPrepared(args) {
            if (args.dashboardItem instanceof DevExpress.Dashboard.Model.PieItem) {
                var measure = args.itemData.getMeasures()[0];
                var axisPoint = args.options.tag.axisPoint;
                var total = args.itemData.getSlice(axisPoint).getMeasureValue(measure.id).getDisplayText();
                var title = args.options.title;
                if (!title.hasTotal) {
                    title.text += ' ' + total;
                    title.hasTotal = true;
                    args.options.title = title;
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" DashboardStorageFolder="~/App_Data/Dashboards/" 
            WorkingMode="ViewerOnly" LimitVisibleDataMode="Designer" Height="100%"
            OnConfigureItemDataCalculation="ASPxDashboard1_ConfigureItemDataCalculation">
            <ClientSideEvents BeforeRender="onBeforeRender" />
        </dx:ASPxDashboard>
    </form>
</body>
</html>

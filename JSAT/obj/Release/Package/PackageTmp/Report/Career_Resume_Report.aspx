<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Career_Resume_Report.aspx.cs" Inherits="JSATVer1.Report.Career_Resume_Report" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<style type="text/css">
body:nth-of-type(1) img[src*="Blank.gif"]{display:none;}
    #form1
    {
        height: 1042px;
        width: 1187px;
    }
</style>
    <title></title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script language="javascript">
        function PrintReport() {
            var viewerReference = $find("ReportViewer1");
            var stillonLoadState = viewerReference.get_isLoading();
            if (!stillonLoadState) {
                var reportArea = viewerReference.get_reportAreaContentType();
                if (reportArea == Microsoft.Reporting.WebFormsClient.ReportAreaContent.ReportPage) {
                    $find("ReportViewer1").invokePrintDialog();
                }
            }
        } 
     </script>
</head>
<body style="height: 1044px; width: 2385px">
    <form id="form1" runat="server">   
    &nbsp; 
    <div style="height: 965px; width: 1141px" >
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="210mm" Height="297mm" ConsumeContainerWhitespace="true"
      ShowRefreshButton="False" ShowPrintButton="true" ShowToolBar="true" PageCountMode="Actual" BorderStyle="Solid">
    </rsweb:ReportViewer>   
                    </div>
             <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
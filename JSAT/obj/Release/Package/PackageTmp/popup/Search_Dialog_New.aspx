<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="Search_Dialog_New.aspx.cs" Inherits="JSAT.popup.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/JSAT_logo.ico" style="corner" />
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.css" rel="stylesheet">
    <link href="../css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=gvCompany.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
    </script>

    <script type="text/javascript">
        function CloseWindow() {
            var Name = '<%= txtName.ClientID %>';
            var id = '<%= txtID.ClientID %>';
            if (window.opener) {
                window.opener.returnValue = document.getElementById(Name).value + "$" + document.getElementById(id).value;
            }
            window.returnValue = document.getElementById(Name).value + "$" + document.getElementById(id).value;
            window.opener.updateCompanyName(document.getElementById(Name).value + "$" + document.getElementById(id).value);
            window.close();
        }
    </script>
</head>
<body class="panel panel-body">
    <form id="form1" align="center" runat="server">
        <br />
        <fieldset>
            <table align="center" class="style1" cellpadding="10px">
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblSearchName" runat="server" Text="Company Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchName" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Search" Width="81px" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <%--  <div style="float: left; margin-left: 40%">
                <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" Width="81px" OnClick="btnSearch_Click" />
            </div>--%>
        <br />
        <br />

        <asp:GridView ID="gvCompany" runat="server" AllowPaging="True" Font-Size="Medium"
            EmptyDataText="No Data To Display" GridLines="None" class="table"
            AutoGenerateColumns="True" OnPageIndexChanging="gvCompany_PageIndexChanging"
            PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rdoSearch" runat="server" onclick="RadioCheck(this)"
                            AutoPostBack="True" OnCheckedChanged="rdoSearch_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="white" />
            <HeaderStyle BackColor="#007aff" Font-Bold="true" ForeColor="white" Height="50px" />
            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Height="0px" Enabled="false" Width="0px" style="background-color:transparent;border-color:transparent;"></asp:TextBox>
        <asp:TextBox ID="txtID" runat="server" Height="0px" CssClass="form-control" Enabled="false" Style="margin-top: 0px" Width="0px" style1="background-color:transparent;border-color:transparent;"></asp:TextBox>
        <div style="float: left; margin-left: 40%; margin-bottom: 30px;">
            <asp:Button ID="Button1" runat="server" Text="OK" Width="96px" CssClass="btn btn-primary"
                OnClientClick="CloseWindow()" Height="34px" />
        </div>

    </form>
</body>
</html>


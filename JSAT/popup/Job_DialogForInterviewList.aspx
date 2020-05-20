<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job_DialogForInterviewList.aspx.cs" Inherits="JSAT.Job_DialogForInterviewList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

            var Name = '<%= txtNo.ClientID %>';
            //close the dialog window
            if (window.opener) {
                window.opener.returnValue = document.getElementById(Name).value;
            }
            window.returnValue = document.getElementById(Name).value;
            window.opener.updateJobNo(document.getElementById(Name).value);
            window.close();
        }
    </script>
</head>
<body class="panel panel-body">
    <br />
    <br />
    <form id="form1" runat="server">
        <center>           
                 <table class="style1" cellpadding="10px">
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblJobNo" runat="server" Text="Job No:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtJobNo" CssClass="form-control" Height="30px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="81px" OnClick="btnSearch_Click" CssClass="btn btn-primary" />
                    </td>
                </tr>
            </table>                
        </center>
        <br />
        <br />
        <br />
        <center>
            <asp:GridView ID="gvCompany" runat="server" AllowPaging="True" Font-Size="Medium"
                EmptyDataText="No Data To Display" Width="700px" EmptyDataRowStyle-HorizontalAlign="Center"
                AutoGenerateColumns="True" AllowSorting="true" class="table" GridLines="None"
                OnRowCommand="gvCompany_RowCommand"
                PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvCompany_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:RadioButton ID="rdoSearch" runat="server" onclick="RadioCheck(this)"
                                AutoPostBack="True" OnCheckedChanged="rdoSearch_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <Columns>
                    <asp:TemplateField HeaderStyle-Width="100px" HeaderText="">
                        <HeaderStyle Width="100px" />
                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDetail" runat="server" CssClass="btn btn-link" CommandName="DataDetail" CommandArgument='<%# Eval("Job_No") %>'>Details</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
            </asp:GridView>
        </center>
        <br />
        <br />
        <asp:TextBox ID="txtNo" runat="server" Enabled="False" Height="0px" Width="1px" style="background-color:transparent;border-color:transparent;"></asp:TextBox>
        <div style="float: left; margin-left: 45%">
            <asp:Button ID="Button1" runat="server" Text="OK" Width="96px" CssClass="btn btn-primary"
                OnClientClick="CloseWindow()" Height="34px" />
        </div>
    </form>
</body>
</html>

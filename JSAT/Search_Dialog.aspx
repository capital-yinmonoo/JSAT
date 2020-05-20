<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search_Dialog.aspx.cs" Inherits="JSAT.Search_Dialog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=dgvClientProfile.ClientID%>");
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
            var data = '<%= txtData.ClientID %>';
            if (window.opener) {
                window.opener.returnValue = document.getElementById(Name).value + "$" + document.getElementById(id).value + '$' + document.getElementById(data).value;
            }
            window.returnValue = document.getElementById(Name).value + "$" + document.getElementById(id).value + '$' + document.getElementById(data).value;
            window.opener.updateValue(document.getElementById(Name).value + "$" + document.getElementById(id).value + '$' + document.getElementById(data).value);
            window.close();
        }
    </script>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.css" rel="stylesheet">
    <link href="../css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />
</head>
<body class="panel panel-body">
    <form id="form1" align="center" runat="server">
        <br />
        <fieldset>
            <table align="center" class="style1" cellpadding="10px">
                <tr>
                    <td style="width: 120px">
                        <asp:Label ID="lblSearch" runat="server" Text="会社名:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server" Width="150px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCode" runat="server" Text="クライアントNo:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCode" runat="server" CssClass="form-control" Visible="False" Width="90px" Height="30px">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>AC</asp:ListItem>
                            <asp:ListItem>EN</asp:ListItem>
                            <asp:ListItem>GN</asp:ListItem>
                            <asp:ListItem>IT</asp:ListItem>
                            <asp:ListItem>JP</asp:ListItem>
                            <asp:ListItem>SL</asp:ListItem>
                            <asp:ListItem>JPN</asp:ListItem>
                            <asp:ListItem>CAD</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblCode1" runat="server" Text=" - " Visible="False"></asp:Label>
                        <asp:TextBox ID="txtCode" CssClass="form-control" runat="server" Width="90px" Height="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th style="text-align: center;" colspan="2">
                        <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Search" OnClick="btnSearch_Click" align="center" />
                    </th>
                </tr>
            </table>
        </fieldset>
        <br />
        <br />
        <br />

        <asp:GridView ID="dgvClientProfile" runat="server" AllowPaging="True" Font-Size="Medium"
            EmptyDataText="No Data To Display"
            AutoGenerateColumns="True" AllowSorting="true" Width="1000px" GridLines="None"
            PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True"
            OnPageIndexChanging="dgvClientProfile_PageIndexChanging"
            OnSorting="dgvClientProfile_Sorting" Align="center" class="table" BackColor="white">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rdoSearch" runat="server" onclick="RadioCheck(this)"
                            AutoPostBack="True" OnCheckedChanged="rdoSearch_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <table style="Width: 85%">
            <tr align="center">
                <td>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Enabled="False" Height="0px" style="background-color:transparent;border-color:transparent;"
                        Width="1px"></asp:TextBox>
                    <asp:TextBox ID="txtID" runat="server" Enabled="False" CssClass="form-control" Height="0px" style="background-color:transparent;border-color:transparent;"
                        Style1="margin-top: 0px" Width="1px"></asp:TextBox>
                    <asp:TextBox ID="txtData" runat="server" CssClass="form-control" Enabled="False" Height="0px" style="background-color:transparent;border-color:transparent;"
                        Style1="margin-top: 0px" Width="1px"></asp:TextBox>
                    <asp:Button ID="btnOk" runat="server" Text="OK" Width="96px" Height="37px" CssClass="btn btn-primary" Align="center"
                        OnClientClick="CloseWindow()" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>


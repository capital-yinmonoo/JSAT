<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="All_Group_Dialog.aspx.cs" Inherits="JSAT.All_Group_Dialog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    function RadioCheck(rb) {
        var gv = document.getElementById("<%=gvGroup.ClientID%>");
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
<script type = "text/javascript">
    function CloseWindow() {
        var Name = '<%= txtGroupName.ClientID %>';
        var id = '<%= txtGroupID.ClientID %>';
        //close the dialog window
        if (window.opener) {
            window.opener.returnValue = document.getElementById(Name).value + "$" + document.getElementById(id).value;
        }
        window.returnValue = document.getElementById(Name).value + "$" + document.getElementById(id).value;
        window.close();
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
        <table>
            <tr>
                <td style="width:120px">
                    <asp:Label ID="lblSearchGroupName" runat="server" Text="Group Name:"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtSearchGroupName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchGroupID" runat="server" Text="GroupID:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchGroupID" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table> 
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="81px" onclick="btnSearch_Click" 
           />
        &nbsp;
        &nbsp;
        <br />
        <br />
    <div>
    
    <asp:GridView ID="gvGroup" runat="server" AllowPaging="True" Font-Size="Medium"
            EmptyDataText="No Data To Display"
            AutoGenerateColumns="True" AllowSorting="true"
            PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True" OnPageIndexChanging="gvGroup_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rdoSearch" runat="server" onclick= "RadioCheck(this)" 
                            AutoPostBack="True" oncheckedchanged="rdoSearch_CheckedChanged"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

       
         <br />
         <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:TextBox ID="txtGroupName" runat="server" Enabled="False" Height="0px"
            Width="1px"></asp:TextBox>
        <asp:TextBox ID="txtGroupID" runat="server" Enabled="False" Height="0px" 
            style="margin-top: 0px" Width="1px"></asp:TextBox> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="OK" Width="96px" 
            OnClientClick="CloseWindow()" Height="37px" />
    </div>
    </div>
    </form>
</body>
</html>
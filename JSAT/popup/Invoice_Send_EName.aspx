<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice_Send_EName.aspx.cs" Inherits="JSAT.Invoice_Send_EName" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function RadioCheck(rb) {
             var gv = document.getElementById("<%=gvEmployee.ClientID%>");
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

        var Name = '<%= txtEmployeeName.ClientID %>';
        var id = '<%= txtEID.ClientID %>';
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
       <br />
        <table>
            <tr>
                <td style="width:120px">
                    <asp:Label ID="lblSearchEName" runat="server" Text="Employee Name:"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txtSearchEName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSearchECode" runat="server" Text="Employee Code:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchECode" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table> 
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="Search" Width="81px" onclick="btnSearch_Click" />
        &nbsp;
        &nbsp;
        <br />
        <br />
    <div>
    <asp:GridView ID="gvEmployee" runat="server" AllowPaging="True" Font-Size="Medium"
            EmptyDataText="No Data To Display"
            AutoGenerateColumns="True" AllowSorting="true"
            PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True">
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

        <asp:TextBox ID="txtEmployeeName" runat="server" Enabled="False" Height="0px"
            Width="1px"></asp:TextBox>
                <asp:TextBox ID="txtEID" runat="server" Enabled="False" Height="0px" 
            style="margin-top: 0px" Width="1px"></asp:TextBox> 
        <asp:Button ID="btnok" runat="server" Text="OK" Width="96px"
            OnClientClick="CloseWindow()" Height="37px"   onclick="btnok_Click" />
    </div>
    </form>
</body>
</html>

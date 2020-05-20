<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterviewList.aspx.cs" Inherits="JSAT.Employee.InterviewList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
        .style1
        {
            width: 150px;
        }

        .style2
        {
            width: 147px;
        }

        .style4
        {
            width: 437px;
            height: 50px;
        }

        .style5
        {
            width: 257px;
        }

        .style6
        {
            width: 437px;
        }

        .style7
        {
            width: 97px;
        }
    </style>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.css" rel="stylesheet">
    <link href="../css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />
</head>
<body class="panel panel-body">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="aa" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <fieldset style="width: 1000; border-style: solid; margin-left: 0px;">
                        <h3><u>InterviewList</u></h3>
                        <table>
                            <tr>
                                <td style="width:130px;">
                                    <asp:Label ID="interviewdate" runat="server" Text="Interview Date"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblinterviewdate" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:130px;">
                                    <asp:Label ID="jobno" runat="server" Text="Job No"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbljobno" runat="server" Text=""></asp:Label></td>
                                <td style="width:130px;">
                                    <asp:Label ID="hpaddress" runat="server" Text="HP Address"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblhpaddress" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Companyname" runat="server" Text="Company Name"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblcompanyname" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="position" runat="server" Text="Position"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblposition" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="interviewplace" runat="server" Text="Interview Place"></asp:Label></td>
                                <td class="style5">
                                    <asp:Label ID="lblinterviewplace" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="conntactperson" runat="server" Text="Contact Person"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblcontactperson" runat="server" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="contactno" runat="server" Text="Contact No"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblcontactno" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </fieldset>
                    <br />
            <br />
            <br />
                    <asp:GridView ID="gvinterview" runat="server" AllowPaging="True" Font-Size="Small"
                        EmptyDataText="No Data To Display" GridLines="None"
                        AutoGenerateColumns="False" AllowSorting="True" PageSize="10" OnPageIndexChanging="gvinterviewpageindexchanging"
                        PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True">
                        <%-- <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />  --%>
                        <Columns>
                            <asp:TemplateField HeaderText="Time" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lbltime" runat="server" Text='<%# Eval("Time")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="No" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lblno" runat="server" Text='<%# Eval("No")%>' Width="100px"></asp:Label>
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("Name")%>' Width="100px"></asp:Label>
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Phon No" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:Label ID="lblphoneno" runat="server" Text='<%# Eval("PhoneNo")%>' Width="100px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <%--  <asp:TemplateField HeaderText="Phon No"  HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label ID="lblphoneno" runat="server"  Text='<%# Eval("PhoneNo")%>' Width="50px"></asp:Label>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:TemplateField>--%>


                            <asp:TemplateField HeaderText="Before" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbefore" runat="server" AutoPostBack="true" />
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="The day" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chktheday" runat="server" AutoPostBack="true" />
                                </ItemTemplate>
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-Width="150px" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("CareerID")%>' Width="50px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <center>
                <asp:Label ID="lblcareerid" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" class="btn btn-primary" /></center>
        </div>
    </form>

    <p>
    </p>

</body>
</html>


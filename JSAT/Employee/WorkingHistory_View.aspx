<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WorkingHistory_View.aspx.cs" Inherits="JSAT.Employee.WorkingHistory_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height:50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">Interviewer</h1>
                   
                </div>
                <!-- /.col-lg-12 --> 
            </div>
            <!-- /.row -->
            <div class="row"> 
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                             <asp:Label ID="Label1" runat="server" Text="Career's Working History" Font-Size="15px"></asp:Label>   
                             
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">

                                <fieldset style="width: 1000; border-style: solid; margin-left: 0px;">
                                    <table>
                                        <tr>
                                           <td>
                                               <asp:Label ID="lblcode" runat="server" Text="Employee Code" CssClass="style3"></asp:Label>
                                           </td>                                                
                                            <td>
                                                <asp:DropDownList ID="ddlcode" CssClass="form-control" runat="server" Height="30px" Width="80px">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>AC</asp:ListItem>
                                                    <asp:ListItem>EN</asp:ListItem>
                                                    <asp:ListItem>GN</asp:ListItem>
                                                    <asp:ListItem>IT</asp:ListItem>
                                                    <asp:ListItem>JP</asp:ListItem>
                                                    <asp:ListItem>SL</asp:ListItem>
                                                    <asp:ListItem>JPN</asp:ListItem>
                                                    <asp:ListItem>CAD</asp:ListItem>
                                                </asp:DropDownList>-
                   <asp:TextBox ID="txtcode" Height="30px" Width="180px" CssClass="form-control" runat="server"></asp:TextBox></td>
                                            <td>
                                                <asp:Label ID="Lable1" runat="server" Text="Name"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Height="30px" Width="180px"></asp:TextBox></td>
                                            <td style="width:20px"></td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" Width="100px" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnaddWorkingHistory" class="btn btn-primary" runat="server" Text=" Add New Working History" Width="270px" OnClick="btnaddWorkingHistory_Click" /><br /><br />
                                            </td>
                                        </tr>
                                    </table>  
                                </fieldset>
                               
                                <asp:ScriptManager ID="ScriptManager1" OnNavigate="ScriptManager1_Navigate" runat="server" EnableHistory="true"></asp:ScriptManager>
                                <%--<asp:ScriptManager ID="aa" runat="server"></asp:ScriptManager>--%>
                                <asp:UpdatePanel runat="server" ID="udtPanel">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvworkinghistoryview" AutoGenerateColumns="False" ForeColor="#333333" EmptyDataText="There is no data to display."
                                            Style="margin-left: 0px" AllowPaging="True" GridLines="None" OnPageIndexChanging="gvOnPageIndexChainging" PageSize="20" DataSourceID="objdatasource1"
                                            OnRowCommand="gv_RowCommand" AllowSorting="True" float="left" CellPadding="10" class="table">
                                           
                                            <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-Width="100px" HeaderText="" HeaderStyle-HorizontalAlign="Left" Visible="true">
                                                    <HeaderStyle Width="100px" />
                                                    <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnDetail" runat="server" CssClass="btn btn-primary" CommandName="DataDetail" CommandArgument='<%# Eval("Career_ID") %>'>Details</asp:LinkButton>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Career_Code" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text='<%# Bind("Career_Code") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCareerCode" runat="server" Text='<%# Eval("Career_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Age" HeaderText=" Age" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText=" Gender" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Text='<%# Bind("Gender") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Address" HeaderText="Address" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Salary" HeaderText="Expected Salary" DataFormatString="{0:#,###0}" HeaderStyle-Width="100px" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Career_Status" HeaderText="Career Status" HeaderStyle-Width="100px" Visible="True" HeaderStyle-ForeColor="White">
                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                </asp:BoundField>
                                            </Columns>
                                                <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White"/>
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:ObjectDataSource ID="objdatasource1" runat="server" EnablePaging="True"
                                    MaximumRowsParameterName="pageSize" OnSelecting="odsUM_Selecting"
                                    SelectCountMethod="TotalRowCount" SelectMethod="Paging"
                                    SortParameterName="sort" StartRowIndexParameterName="startIndex"
                                    TypeName="JSAT_BL.Working_History_BL">
                                    <SelectParameters>
                                        <asp:Parameter Name="search" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <!-- /.table-responsive -->
                            </div>
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-6 -->
                </div>
                <!-- /.row -->
        </section>
        <!-- /#page-wrapper -->
    </section>
  <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>   
    <script src="../js/scripts.js"></script>   
	<script src="../js/jquery.autosize.min.js"></script>
</asp:Content>

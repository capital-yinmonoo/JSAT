<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="IntroductionListForCareer_GoDetail.aspx.cs" Inherits="JSAT.IntroductionListForCareer_GoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height:50px">
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
                            <asp:Label ID="Label1" runat="server" Text="Introduction List ForCareer" Font-Size="15px"></asp:Label>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">

                                <fieldset style="width: 1000; border-style: solid; margin-left: 0px;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcode" runat="server" Text="Employee Code"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlcode" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem>AC</asp:ListItem>
                                                    <asp:ListItem>EN</asp:ListItem>
                                                    <asp:ListItem>GN</asp:ListItem>
                                                    <asp:ListItem>IT</asp:ListItem>
                                                    <asp:ListItem>JP</asp:ListItem>
                                                    <asp:ListItem>SL</asp:ListItem>
                                                    <asp:ListItem>JPN</asp:ListItem>
                                                    <asp:ListItem>CAD</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td>-</td><td>
                                                <asp:TextBox ID="txtcode" CssClass="form-control" runat="server"  Height="30px" Width="80px"></asp:TextBox></td>
                                            <td>
                                                <asp:Label ID="Lable1" runat="server" Text="Name"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" Width="194px"></asp:TextBox></td>
                                            <td>
                                                <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="Search" Height="34px" Width="150px" OnClick="btnSearch_Click" /></td>
                                        </tr>
                                    </table>
                                </fieldset>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnaddnewIntorduction" CssClass="btn btn-primary" runat="server" Text=" Add New IntorudctionForCareer" Width="270px" Height="35px" OnClick="btnaddnewIntorduction_Click" /></td>
                                    </tr>
                                </table>
                                <br />
                                <asp:ScriptManager ID="aa" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel runat="server" ID="udtPanel">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvsuccessworkerdetail" AutoGenerateColumns="False" ForeColor="#333333" DataKeyNames="ID"
                                            EmptyDataText="There is no data to display." DataSourceID="objdatasource2" GridLines="None" Width="1000px" class="table"
                                            Style="margin-left: 0px" AllowPaging="True" OnPageIndexChanging="gvpageindexchage" PageSize="10" OnRowCommand="gvrowcommand" OnRowDeleting="grid1_OnRowDeleting">

                                            <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Career_Code" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcareercode" runat="server" Text='<%# Eval("Carrer_Code")%>' Width="100px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("Career_Name")%>' Width="200px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Salary" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsalary" runat="server" Text='<%# Eval("Expected_Salary")%>' Width="100px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Start Working Date" HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblstartworkingdate" runat="server" Text='<%# Eval("StartWorkingDate")%>' Width="100px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Sign" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblsign" runat="server" Text='<%# Eval("Sign_ID")%>' Width="100px"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="70px" HeaderText="" HeaderStyle-ForeColor="White">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />

                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkedit" runat="server" CssClass="btn btn-primary" CommandName="DataEdit" CommandArgument='<%# Eval("ID") %>'>Edit</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="70px" HeaderText="" HeaderStyle-ForeColor="White">
                                                    <HeaderStyle Width="70px" />
                                                    <ItemStyle Width="70px" HorizontalAlign="Center" />

                                                    <ItemTemplate>

                                                        <asp:LinkButton ID="lnkdelete" runat="server" CssClass="btn btn-danger" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'>Delete</asp:LinkButton>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%--<asp:CommandField ShowDeleteButton="True" HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ControlStyle-Width="65px" ControlStyle-Height="33px" ControlStyle-CssClass="btn btn-danger" ItemStyle-HorizontalAlign="Center" />--%>
                                            </Columns>
                                            <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:ObjectDataSource ID="objdatasource2" runat="server" EnablePaging="True"
                                    MaximumRowsParameterName="pageSize" OnSelecting="odsUM_Selecting" DeleteMethod="DeleteSuccessWorkerInfo"
                                    SelectCountMethod="TotalRowCount" SelectMethod="Paging"
                                    SortParameterName="sort" StartRowIndexParameterName="startIndex"
                                    TypeName="JSAT_BL.IntroductionListForCareer_BL">
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
    <!-- javascripts -->
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
	<script src="../js/jquery.autosize.min.js"></script>
</asp:Content>


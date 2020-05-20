<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ability.aspx.cs" Inherits="JSAT_Ver1.Ability" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <%-- <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.css" rel="stylesheet">
    <link href="../css/style.css" rel="stylesheet">--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <style type="text/css">
        #MainContent_gvAbility tbody tr th {
            text-align: center;
        }
        
    </style>
   <section id="main-content">
          <section class="wrapper">
            <div class="row" style="height:50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">Reference</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Ability
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                            <label>Enter Ability:</label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data" ></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Height="34px" class="btn btn-primary btn-outline btn-sm" Text="検索する(Search)" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnViewAll" runat="server" Height="34px" class="btn btn-primary" Text="すべてを表示(View All)" onclick="btnViewAll_Click" /><br /><br />
                            <label>Select Ability Title:</label>
                            <asp:DropDownList runat="server" ID="ddlAbilityTitle" CssClass="form-control" Height="30px" Width="227px" OnSelectedIndexChanged="ddlAbilityTitle_SelectedIndexChange" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <asp:GridView ID="gvAbility" runat="server" CellPadding="10" ForeColor="#333333" DataKeyNames="ID" ShowFooter="True" class="table"
                                GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Height="213px" Width="900px" onrowdeleting="gvAbility_RowDeleting" OnRowDataBound="gvAbility_RowDataBound"
                                onrowediting="gvAbility_RowEditing" OnRowCommand="gv_RowCommand" OnPageIndexChanging ="onPaging" PageSize="20">
                                <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />    
                                <Columns>
                                     <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server"  Text='<%# Eval("ID")%>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Ability" HeaderStyle-ForeColor="White" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server"  Text='<%# Eval("Description")%>' ></asp:Label>
                                            </ItemTemplate>                   
                                             <FooterTemplate >
                                                   <asp:Label ID ="lblName" runat="server" Text="Enter New Ability: " />
                                                   <br/>
                                                   <asp:TextBox ID="txtDescriptionSave" runat="server" CssClass="form-control" Height="30px" Width="500px" MaxLength="200" ></asp:TextBox> 
                                                   <asp:Button  ID="btnSave" runat="server" class="btn btn-default" Text="登録する(Save)" onclick="btnSave_Click"/>
                                                   <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" Height="34px" OnClick="btncancel_Click" Visible="false"/>
                                           </FooterTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderStyle-Width="58px">
                                         <ItemTemplate>
                                            <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="Edit" CommandArgument="ID" class="btn btn-outline btn-primary btn-sm"/>
                                        </ItemTemplate>
                                       </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument="ID" class="btn btn-outline btn-danger btn-sm"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    </Columns>         
                                    <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                              </asp:GridView>
                          <asp:HiddenField runat="server" ID="hdfID" />
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
	<script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>   
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>    
    <script src="../js/scripts.js"></script>
</asp:Content>

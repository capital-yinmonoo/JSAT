<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company_Type_Details.aspx.cs" Inherits="JSAT_Ver1.Company_Type_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/favicon.png">
    <title></title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #MainContent_gvCompany tbody tr th {
            text-align: center;           
        }        
    </style>
    <section id="main-content">
          <section class="wrapper">
            <div class="row" style="height:50px">
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
                          Company Type Details
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display:normal;">
                            <label>Enter Type of Company:</label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data" ></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="検索する(Search)" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnViewAll" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" onclick="btnViewAll_Click" /><br /><br />
                            </div>
                            <asp:GridView ID="gvCompany" runat="server" CellPadding="10" ForeColor="#333333" DataKeyNames="ID" class="table"
                            GridLines="None" AutoGenerateColumns="False" AllowPaging="True" onrowdatabound="gvCompany_RowDataBound" 
                            OnRowDeleting="gvCompany_RowDeleting" Height="213px" Width="900px" onpageindexchanging="onPaging" PageSize="20" float="left">
                             <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                 <Columns>
                                  <asp:TemplateField Visible="false">
                                     <ItemTemplate>                   
                                    <asp:Label ID="lblID" runat="server"  Text='<%# Eval("ID")%>'></asp:Label>                        
                                     </ItemTemplate>
                                      </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Company Type" FooterStyle-Width="600px" HeaderStyle-ForeColor="White">                  
                                     <ItemTemplate>                 
                                      <asp:Label ID="lblcompany" runat="server"  Text='<%# Eval("Company_Type")%>'></asp:Label>               
                                     </ItemTemplate>
                                     </asp:TemplateField>         
                                      <asp:TemplateField HeaderText="Company Type Country" FooterStyle-Width="300px" HeaderStyle-ForeColor="White">      
                                     <ItemTemplate>                   
                                      <asp:Label ID="lblcountry" runat="server"  Text='<%# Eval("Country")%>'></asp:Label>               
                                     </ItemTemplate>       
                                 </asp:TemplateField>
                                 <asp:TemplateField>
                                     <ItemTemplate>
                                          <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-outline btn-sm"/>
                                     </ItemTemplate>
                                 </asp:TemplateField>
                             </Columns>               
                                    <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                            </asp:GridView>
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

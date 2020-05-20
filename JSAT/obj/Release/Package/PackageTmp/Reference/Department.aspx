<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="JSAT_Ver1.Department" %>
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
        #MainContent_gvDepartment tbody tr th {
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
                            職種(大分類)(Department)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display:normal;">
                            <label>Enter Search Department : </label>
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data" ></asp:TextBox>
                            <asp:Button ID="search" runat="server" class="btn btn-primary" Text="検索する(Search)" OnClick="search_Click" />
                            <asp:Button ID="ViewAll" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" onclick="ViewAll_Click" /><br /><br />
                            </div>
                              <asp:GridView ID="gvDepartment" runat="server"  CellPadding="10" ForeColor="#333333" GridLines="None" DataKeyNames="ID" AllowPaging="True" 
                              ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound = "gvDepartment_RowDataBound" OnRowUpdating="gvDepartment_RowUpdating"
                              onrowediting="gvDepartment_RowEditing" onrowcancelingedit="gvDepartment_RowCancelingEdit" onpageindexchanging="onPaging"
                              Height="213px"  Width="900px" float="left" PageSize="20" OnRowDeleting="gvDepartment_RowDeleting" class="table">
                              <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                  <Columns>
                                <asp:TemplateField HeaderText="ID"  Visible="false">
                                     <ItemTemplate>
                                        <asp:Label ID="lblID" runat ="server" Text='<%#Eval("ID") %>'></asp:Label>
                                     </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="職種(Department)" FooterStyle-Width="900px" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat ="server" Text='<%#Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID= "txtDescriptionEdit" runat="server" Text='<%# Eval("Description")%>' CssClass="form-control" Width="500px" MaxLength="200"></asp:TextBox>
                                    </EditItemTemplate>
                                <FooterTemplate >
                                    <asp:Label ID="lbldep"  Text="Enter New Department Type:" runat="server" ></asp:Label><br />
                                    <asp:TextBox ID="txtDescription" runat="server" Width="500px" CssClass="form-control" Height="30px" MaxLength="200"> </asp:TextBox>
                                    <asp:Button ID= "btnAdd" runat="server" Text="登録する(Save)" class="btn btn-default" OnClick ="btnAdd_Click" />
                                </FooterTemplate>
                                <FooterStyle Width="900px"></FooterStyle>
                                </asp:TemplateField>
                                       <asp:TemplateField ShowHeader="false" HeaderStyle-Width="204px">
                                   <EditItemTemplate>
                                        <asp:LinkButton ID="lnkupdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="btn btn-primary btn-primary btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger btn-primary btn-sm"></asp:LinkButton>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-primary btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-primary btn-sm"/> 
                                   </ItemTemplate>
                                </asp:TemplateField> 
                               <%-- <asp:CommandField ShowEditButton="true" ShowDeleteButton="true"/>--%>
                            </Columns>
                             <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                             <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                            </asp:GridView>
                            <asp:HiddenField runat="server" ID="hdfsearch" />
                               <asp:HiddenField ID="hdfupdate" runat="server" />
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

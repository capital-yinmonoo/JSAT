<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Company_Type.aspx.cs" Inherits="JSAT_Ver1.Company_Type" %>
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
        #MainContent_gvCompany_Type tbody tr th {
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
                            Large _Company _Type
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                            <label>Enter Company Type : </label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Width="484px" placeholder="Enter Search Data" ></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary"  Text="検索する(Search)" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnViewAll" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" onclick="btnViewAll_Click" /><br /><br />
                            </div>
                            <asp:GridView ID="gvCompany_Type" runat="server" CellPadding="20" ForeColor="#333333"  DataKeyNames="ID" ShowFooter="True"
                             GridLines="None" AutoGenerateColumns="False" AllowPaging="True" onrowupdating="gvCompany_Type_RowUpdating" class="table"
                             onrowdatabound="gvCompany_Type_RowDataBound" onrowdeleting="gvCompany_Type_RowDeleting" onrowediting="gvCompany_Type_RowEditing" Height="213px" Width="900px"
                             onrowcancelingedit="gvCompany_Type_RowCancelingEdit" onpageindexchanging="onPaging" OnDataBound = "OnDataBound" PageSize="20" float="left">
                             <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                <Columns>
                                <asp:TemplateField Visible="false">
                                       <ItemTemplate>
                                               <asp:Label ID="lblID" runat="server"  Text='<%# Eval("ID")%>' ></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="会社の種類 (Company_Type)" FooterStyle-Width="900px" HeaderStyle-ForeColor="White">
                                       <ItemTemplate>
                                           <asp:Label ID="lblDescription" runat="server"  Text='<%# Eval("Description")%>' ></asp:Label>
                                       </ItemTemplate>
                                       <EditItemTemplate>
                                              <asp:TextBox ID="txtDescriptionEdit"  runat="server" Text='<%# Eval("Description")%>' Width="500px" MaxLength="200"  CssClass="form-control"></asp:TextBox>
                                       </EditItemTemplate>
                                        <FooterTemplate >
                                           <asp:Label ID ="lblName" runat="server" Text="会社の種類 入力(New Company Type): "/><br/>
                                           <asp:TextBox ID="txtDescriptionSave" CssClass="form-control" runat="server" Width="500px" MaxLength="200" ></asp:TextBox> 
                                           <asp:Button ID="btnSave" runat="server" Text="登録する(Save)" class="btn btn-default" onclick="btnSave_Click"/><br/><br />
                                           <asp:Label ID ="lblCompanyType" runat="server" Text="Choose Company Type:" />
                                           <asp:DropDownList ID="ddlCompanyType" runat="server" CssClass="form-control" Height="30px" Width="300px"></asp:DropDownList>
                                           <asp:Label ID ="lblArea" runat="server" Text="Choose Country: " />
                                           <asp:DropDownList ID="ddlCountry" runat="server" Width="150px" Height="30px" CssClass="form-control"></asp:DropDownList><br/><br />
                                           <asp:Button ID="btnAdd" runat="server" class="btn btn-default" Text="Add Company Type with Country"  onclick="btnAdd_Click"/>
                                           <asp:Button ID="btnDetails" runat="server" class="btn btn-default" Text="Show Details"  onclick="btnDetails_Click"/>
                                      </FooterTemplate>
                                   <FooterStyle Width="900px"></FooterStyle>
                                   </asp:TemplateField>
                                  <%-- <asp:CommandField ShowEditButton="True" ShowDeleteButton="True"/>--%>
                                    <asp:TemplateField ShowHeader="false" HeaderStyle-Width="204px">
                                   <EditItemTemplate>
                                        <asp:LinkButton ID="lnkupdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="btn btn-primary btn-outline btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger btn-outline btn-sm"></asp:LinkButton>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-outline btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-outline btn-sm"/> 
                                   </ItemTemplate>
                                </asp:TemplateField> 
                               </Columns>
                                <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                            </asp:GridView>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instituation.aspx.cs" Inherits="JSAT_Ver1.Instituation" %>
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
        #MainContent_gvInstituation tbody tr th {
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
                           学校名(Instituation)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display:normal;">
                            <label>Enter Search Instituation : </label>
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data" ></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="検索する(Search)" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnViewAll" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" onclick="btnViewAll_Click" /><br /><br />
                            </div>
                            <asp:GridView ID="gvInstituation" runat="server" ForeColor="#333333" CellPadding="10" DataKeyNames="ID" ShowFooter="True" class="table"
                             GridLines="None" AutoGenerateColumns="False" AllowPaging="True" Height="213px" Width="900px" onrowdeleting="gvInstituation_RowDeleting"
                             onrowediting="gvInstituation_RowEditing" onrowupdating="gvInstituation_RowUpdating" onrowcancelingedit="gvInstituation_RowCancelingEdit" 
                             onrowdatabound="gvInstituation_RowDataBound" onpageindexchanging="onPaging" OnDataBound = "OnDataBound" PageSize="20" float="left">
                              <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                <Columns>
                                 <asp:TemplateField Visible="false">
                                     <ItemTemplate>                   
                                    <asp:Label ID="lblID" runat="server"  Text='<%# Eval("ID")%>'  ></asp:Label>                        
                                     </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Instituation" FooterStyle-Width="900px" HeaderStyle-ForeColor="White">                  
                                     <ItemTemplate>                 
                                      <asp:Label ID="lblDescription" runat="server"  Text='<%# Eval("Description")%>'></asp:Label>               
                                     </ItemTemplate>             
                                     <EditItemTemplate>                   
                                     <asp:TextBox ID="txtDescriptionEdit" CssClass="form-control"  runat="server" Text='<%# Eval("Description")%>' Width="500px" MaxLength="200"   ></asp:TextBox>
                                      </EditItemTemplate>
                                   <FooterTemplate >
                                         <asp:Label ID ="lblName" runat="server" Text="Enter New Instituation: " /><br/><br/>
                                         <asp:TextBox ID="txtDescriptionSave"  runat="server" CssClass="form-control" Height="30px" Width="500px" MaxLength="200" ></asp:TextBox> 
                                         <asp:Button  ID="btnSave" runat="server" Text="登録する(Save)" class="btn btn-default"  onclick="btnSave_Click"/><br/><br/>
                                         <asp:Label ID ="lblInstitution" runat="server" Text="Choose Instituation: " />
                                         <asp:DropDownList ID="ddlInstitute" runat="server" Width="300px" CssClass="form-control" Height="30px"></asp:DropDownList>
                                         <asp:Label ID ="lblArea" runat="server" Text="Choose Area: " /> 
                                         <asp:DropDownList ID="ddlArea" runat="server" Width="200px" float="left" CssClass="form-control" Height="30px"></asp:DropDownList><br/><br/>
                                         <asp:Button  ID="btnAdd" runat="server" class="btn btn-default" Text="Add Institution with Area"  onclick="btnAdd_Click"/>
                                         <asp:Button  ID="btnDetails" runat="server" Text="Show Details" class="btn btn-default" onclick="btnDetails_Click"/>
                                    </FooterTemplate>
                              <FooterStyle Width="900px"></FooterStyle>
                                 </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="false" HeaderStyle-Width="204px">
                                   <EditItemTemplate>
                                        <asp:LinkButton ID="lnkupdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="btn btn-primary btn-outline btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger btn-outlie btn-sm"></asp:LinkButton>
                                   </EditItemTemplate>
                                   <ItemTemplate>
                                        <asp:LinkButton ID="lnkedit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-outline btn-sm"></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-outline btn-sm"/> 
                                   </ItemTemplate>
                                </asp:TemplateField> 
                                     
                               <%--  <asp:CommandField ShowEditButton="True" ShowDeleteButton="true"/>          --%> 
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

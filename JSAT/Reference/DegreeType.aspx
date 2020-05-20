﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DegreeType.aspx.cs" Inherits="JSAT_Ver1.DegreeType" %>
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
        #MainContent_GVdegree tbody tr th {
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
                            Degree Type
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display:normal;">
                            <label>Enter Degree Type:</label>
                            <asp:TextBox ID="TxtsearchDegree" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data" ></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" class="btn btn-primary"  Text="検索する(Search)" OnClick="BtnSearch_Click" />
                            <asp:Button ID="btnViewAll" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" onclick="BtnView_Click" /><br /><br />
                            <label>Select Institution:</label>
                            <asp:DropDownList ID="ddlDegree" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDegree_SelectedIndexChanged" CssClass="form-control" Height="30px" Width="400px"></asp:DropDownList>
                            </div>
                            <asp:GridView ID="GVdegree" runat="server" AutoGenerateColumns="false" ShowFooter="true" CellPadding="10"
                            ForeColor="#333333" DataKeyNames="Degree_ID" GridLines="None" AllowPaging="True" OnRowDeleting="GVdegree_RowDeleting"
                            OnRowEditing="GVdegree_RowEditing" OnRowDataBound="GVdegree_RowDataBound" class="table"
                            OnPageIndexChanging="onPaging" OnRowCommand="gv_RowCommand" PageSize="20" float="left" Height="213px" Width="900px">
                            <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Degree_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Degree" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="LbldegreeEdit" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblSave" runat="server" Text="Enter New Degree: " />
                                        <br />
                                        <asp:TextBox ID="txtDegreeSave" runat="server" Width="500px" CssClass="form-control" Height="30px" MaxLength="200"></asp:TextBox>
                                        <asp:Button ID="btnSave" runat="server" Text="登録する(Save)" class="btn btn-default" OnClick="btnSave_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btncancel_Click" Visible="false" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="58px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="Edit" CommandArgument="ID" class="btn btn-outline btn-primary btn-sm" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument="ID" class="btn btn-outline btn-danger btn-sm" />
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
     <!-- javascripts -->
     <script src="../js/jquery.js"></script>
	
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
   
    <script src="../js/scripts.js"></script>
   
	<script src="../js/jquery.autosize.min.js"></script>
</asp:Content>

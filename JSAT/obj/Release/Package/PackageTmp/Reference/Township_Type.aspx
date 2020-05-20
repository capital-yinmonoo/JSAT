<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Township_Type.aspx.cs" Inherits="JSAT_Ver1.Township_Type" %>

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
        #MainContent_GVTownship tbody tr th
        {
            text-align: center;
        }
    </style>
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px">
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
                            Township
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display: normal;">
                                <label>Enter Search Township:</label>
                                <asp:TextBox ID="TxtsearchTS" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data"></asp:TextBox>
                                <asp:Button ID="BtnSearch" runat="server" class="btn btn-primary" Text="検索する(Search)" OnClick="BtnSearch_Click" />
                                <asp:Button ID="BtnView" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" OnClick="BtnView_Click" /><br />
                                <br />
                            </div>
                            <asp:GridView ID="GVTownship" runat="server" AutoGenerateColumns="false" ShowFooter="true" CellPadding="10" class="table"
                                ForeColor="#333333" DataKeyNames="Township_ID" GridLines="None" AllowPaging="True" Height="213px" Width="900px" OnRowDeleting="GVTownship_RowDeleting"
                                OnRowEditing="GVTownship_RowEditing" OnRowUpdating="GVTownship_RowUpdating" OnRowCancelingEdit="GVTownship_RowCancelingEdit"
                                OnRowDataBound="GVTownship_RowDataBound" OnPageIndexChanging="onPaging" PageSize="20" float="left">
                                <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Township_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Township" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTownship" runat="server" Text='<%#Eval("Township_Description") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TxtTownship" runat="server" CssClass="form-control" Text='<%#Eval("Township_Description") %>' Width="500px" MaxLength="200"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblName" runat="server" Text="Enter New Township: " /><br />
                                            <br />
                                            <asp:TextBox ID="txtNewTownship" runat="server" Width="500px" CssClass="form-control" Height="30px" MaxLength="200"></asp:TextBox>
                                            <asp:Button ID="btnSave" runat="server" Text="登録する(Save)" class="btn btn-default" OnClick="btnSave_Click" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="false" HeaderStyle-Width="204px">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkupdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="btn btn-primary btn-outline btn-sm"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkcancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger btn-outline btn-sm"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkedit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="btn btn-primary btn-outline btn-sm"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger btn-outline btn-sm" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                            </asp:GridView>
                            <asp:HiddenField runat="server" ID="hdfID" />
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

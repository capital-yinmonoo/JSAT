<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Interviewer.aspx.cs" Inherits="JSAT_Ver1.Interviewer" %>

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
        #MainContent_gvInterviewer tbody tr th
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
                            Interviewer
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display: normal;">
                                <label>Enter Search Interviewer : </label>
                                <asp:TextBox ID="txtSearchInterviewer" runat="server" CssClass="form-control" Height="30px" Width="484px" placeholder="Enter Search Data"></asp:TextBox>
                                <asp:Button ID="BtnSearch" runat="server" class="btn btn-primary" Text="検索する(Search)" OnClick="BtnSearch_Click" />
                                <asp:Button ID="BtnView" runat="server" class="btn btn-primary" Text="すべてを表示(View All)" OnClick="BtnView_Click" /><br />
                                <br />
                            </div>
                            <asp:GridView ID="gvInterviewer" runat="server" AutoGenerateColumns="false" ShowFooter="true" CellPadding="10" class="table"
                                ForeColor="#333333" DataKeyNames="ID" GridLines="None" AllowPaging="True" Height="213px" Width="900px" OnRowDeleting="gvInterviewer_RowDeleting"
                                OnRowEditing="gvInterviewer_RowEditing" OnRowUpdating="gvInterviewer_RowUpdating" OnRowCancelingEdit="gvInterviewer_RowCancelingEdit"
                                OnRowDataBound="gvInterviewer_RowDataBound" OnPageIndexChanging="onPaging" PageSize="20" float="left">
                                <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interviewer Name" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Interviewer_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtInterviewerName" runat="server" CssClass="form-control" Text='<%#Eval("Interviewer_Name") %>' Width="500px" MaxLength="200"></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblName" runat="server" Text="Enter New Interviewer: " /><br />
                                            <asp:TextBox ID="txtNewInterviewer" runat="server" CssClass="form-control" Height="30px" Width="500px" MaxLength="200"></asp:TextBox>
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-default" Text="登録する(Save)" OnClick="btnSave_Click" />
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

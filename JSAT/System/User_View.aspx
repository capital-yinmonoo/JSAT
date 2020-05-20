<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_View.aspx.cs" Inherits="JSAT_Ver1.User_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function GetDeletedUser() {
            var counter = 0;
            $("#<%=gvUser.ClientID%> input[id*='chkStatus']:checkbox").each(function (index) {
                if ($(this).is(':checked'))
                    counter++;
            });
            if (counter > 1) {
                alert('Not allowed to select multiple records  for Delete!');
                return false;
            }
            else if (counter <= 0) {
                alert('Please select one record for Delete!');
                return false;
            }
            else
                return confirm('Are you sure you want to delete');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">User</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            User View
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group" style="display: normal;">
                                <label>入力　ユーザー名(Enter Search UserName)</label>
                                <asp:TextBox ID="txtSearch" runat="server" class="form-control" Width="484px" placeholder="Enter Search Data"></asp:TextBox>
                                <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="検索する(Search)" OnClick="btnSearch_Click" /><br />
                                <br />
                            </div>
                            <p>
                                <asp:Button ID="btnEdit" runat="server" class="btn btn-primary" Text="編集(Edit)" Width="90px" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" runat="server" class="btn btn-danger" Text="削除(Delete)" OnClick="btnDelete_Click" OnClientClick="return GetDeletedUser();" />
                                <asp:Button ID="btnAddUser" runat="server" class="btn btn-primary" Text="新しいユーザー(New User)" OnClick="btnAddUser_Click" />
                                <asp:Button ID="btnAddRole" runat="server" class="btn btn-primary" Text="ロールの追加(Add Role)" OnClick="btnAddRole_Click" /><br />
                                <br />
                            </p>
                            <asp:GridView ID="gvUser" runat="server" CellPadding="4" Width="100%" DataKeyNames="ID" GridLines="None" AutoGenerateColumns="False" class="table"
                                AllowPaging="True" OnRowDataBound="gvUser_RowDataBound" OnPageIndexChanging="onPaging">
                                <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkStatus" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ユーザー名(User Name)" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="lalUserName" runat="server" Text='<%# Eval("User_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ユーザーID(User ID)" HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="lalLoginID" runat="server" Text='<%# Eval("LogIn_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <span class="profile-ava img-rounded" style="color:white">
                                                <asp:Image ID="imgPicture" runat="server" BorderColor="White" ImageUrl='<%# Eval("Image_FileName", "~/img/{0}") %>' />
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
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
    <script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <!-- bootstrap -->
    <script src="../js/bootstrap.min.js"></script>
    <!-- nice scroll -->
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <!--custome script for all page-->
    <script src="../js/scripts.js"></script>
</asp:Content>

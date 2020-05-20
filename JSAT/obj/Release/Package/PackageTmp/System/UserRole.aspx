<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="JSAT_Ver1.UserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section id="main-content">
          <section class="wrapper">
            <div class="row" style="height:50px;">
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
                            User Role
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <asp:Label ID="lblName" runat="server"></asp:Label><br />
                            <asp:GridView ID="gvUserRole" runat="server" AutoGenerateColumns="False" onrowdatabound="gvUserRole_RowDataBound" class="table" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Menu ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMenuID" Text='<%# Eval("ID")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Master ID"  Visible="false">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblMasterID" Text='<%# Eval("MasterItem_ID")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Width="500px" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Can Read" HeaderStyle-ForeColor="White">
                                <HeaderTemplate>
                                      <asp:CheckBox ID="chkAllRead" runat="server"  Text="Can Read" AutoPostBack="True" OnCheckedChanged="chkReadSelectAll_CheckedChanged"/>
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbRead" runat="server"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Can Edit" HeaderStyle-ForeColor="White">
                                <HeaderTemplate>
                                      <asp:CheckBox ID="chkAllEdit" runat="server"  Text="Can Edit" AutoPostBack="True" OnCheckedChanged="chkEditSelectAll_CheckedChanged"/>
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbEdit" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Can Delete" HeaderStyle-ForeColor="White">
                                <HeaderTemplate>
                                      <asp:CheckBox ID="chkAllDelete" runat="server"  Text="Can Delete" AutoPostBack="True" OnCheckedChanged="chkDeleteSelectAll_CheckedChanged"/>
                                </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbDelete" runat="server" />
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                               <HeaderStyle BackColor="#007aff" ForeColor="White" Font-Bold="True"/>
                           </asp:GridView><br/>
                                 
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                     <footer>
                                <div class="wrap" style="margin-right:213px;">
                                    <ul class="nav navbar-nav social">
                                          <asp:Button ID="btnAddRole" class="btn btn-primary" Text="ロールの追加(Add Role)" runat="server" onclick="btnAddRole_Click"/>
                                    </ul>
                                </div>
                            </footer>       
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

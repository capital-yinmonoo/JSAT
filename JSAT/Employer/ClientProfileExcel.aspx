<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ClientProfileExcel.aspx.cs" Inherits="JSAT_Ver1.Employer.ClientProfileExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height:50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">Employer</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Excel Reader
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <table height="60px">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Choose File"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="up1" runat="server" CssClass="form-control"/>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnRead" runat="server" class="btn btn-primary" Text="Read" OnClick="btnRead_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="gvdata" runat="server" class="table">
                             <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                             <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
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

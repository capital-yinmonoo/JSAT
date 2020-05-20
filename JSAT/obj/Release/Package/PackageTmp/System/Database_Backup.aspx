<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Database_Backup.aspx.cs" Inherits="JSAT_Ver1.Database_Backup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <section id="main-content">
          <section class="wrapper">
            <div class="row" style="height:50px;">
                <div class="col-lg-12"> 
                    <h1 class="page-header">System</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Database Backup
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                   <form id="Form1" role="form">
                                        <div class="form-group">
                                            <label>バックアップ(Database Backup)</label>
                                            <asp:LinkButton runat="server" ID="lnkDownload" onclick="lnkDownload_Click"></asp:LinkButton>
                                        </div>
                                       <asp:Button runat="server" ID="btnBackup" class="btn btn-primary" Text="バックアップ(Backup)" onclick="btnBackup_Click" />
                                       </form>
                                </div>
                                <!-- /.col-lg-6 (nested) -->
                                <!-- /.col-lg-6 (nested) -->
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                 </div>
                <!-- /.col-lg-12 -->
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

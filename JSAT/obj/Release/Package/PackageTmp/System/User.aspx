<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="User.aspx.cs" Inherits="JSAT_Ver1.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="js/bootstrap-show-password.js"></script>


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
                            User Registration
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <form id="Form1" role="form">
                                        <div class="form-group">
                                            <label>ユーザー名(User Name)</label>
                                            <asp:RequiredFieldValidator ID="rvfName" runat="server" ErrorMessage="*" ForeColor="#FF3300" ControlToValidate="txtUserName" ValidationGroup="save"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Enter LoginID"></asp:TextBox>
                                            <p class="help-block">Example Full Name text here.</p>
                                        </div>
                                        <div class="form-group">
                                            <label>ログインID(LogIn_ID)</label>
                                            <asp:RequiredFieldValidator ID="rvfLogIn" runat="server" ControlToValidate="txtLogInID" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtLogInID" runat="server" class="form-control" PlaceHolder="Enter LoginID"></asp:TextBox>
                                        </div>

                                        <div class="form-group">

                                            <label>パスワード (Password)</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="save"></asp:RequiredFieldValidator>

                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Enter Password"></asp:TextBox>
                                        </div>

                                        <div>
                                            <p class="help-block">プロフィール画像 (Profile Image)</p>
                                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="if (confirm('Upload ' + this.value + '?')) this.form.submit();" class="style1" Style="display: inline;" />
                                            <div class="col-lm-4 pull-right">
                                                <section class="panel">
                                                    <asp:Image runat="server" ID="Image2" class="img-thumbnail" Height="30px" Width="30px" />
                                                </section>
                                            </div>
                                        </div>
                                        <br />
                                        <br />

                                        <asp:Button ID="btnSave" class="btn btn-primary" Text="Submit" OnClick="btnSave_Click" runat="server" ValidationGroup="save" Width="100px" />
                                        <asp:Button ID="btnNew" class="btn btn-primary" Text="Reset" OnClick="btnCancel_Click" runat="server" Width="100px" />
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
    <%-- <script src="../js/jquery-1.8.3.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <!-- bootstrap -->
    <%--   <script src="../js/bootstrap.min.js"></script>--%>
    <%-- <script src="../js/bootstrap-show-password.js"></script>--%>

    <!-- nice scroll -->
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <!--custome script for all page-->
    <script src="../js/scripts.js"></script>

    <%--<script type="text/javascript">
         $(document).ready(function () {
             $("#showhide").click(function () {
                 if ($(this).data('val') == "1") {
                     $("#txtPassword").attr('type', 'text');
                     $("#eye").attr("class", "glyphicon glyphicon-eye-close");
                     $(this).data('val', '0');
                 }
                 else {
                     $("#txtPassword").attr('type', 'password');
                     $("#eye").attr("class", "glyphicon glyphicon-eye-open");
                     $(this).data('val', '1');
                 }
             });
         });

    </script>--%>
</asp:Content>

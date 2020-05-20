<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="My_Profile.aspx.cs" Inherits="JSAT_Ver1.My_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/favicon.png">
    <title>Basic Table | Creative - Bootstrap 3 Responsive Admin Template</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.css" rel="stylesheet">
    <link href="../css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
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
                                            <asp:TextBox ID="txtLogInID" runat="server" class="form-control" PlaceHolder="Enter LoginID" ReadOnly="true" hover=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>パスワード (Password)</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300" ValidationGroup="save"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" placeholder="Enter Password"></asp:TextBox>
                                        </div>
                                        <div>
                                            <p class="help-block">プロフィール画像 (Profile Image)</p>

                                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="if (confirm('Upload ' + this.value + '?')) this.form.submit();" class="style1" Style="display:inline;" display="dynamic"/>
                                          <%--  <div class="col-lg-2 pull-right">
                                                <section class="panel">--%>
                                                    <asp:Image runat="server" ID="Image1" class="img-thumbnail" Height="40px" Width="40px" />
                                                <%--</section>
                                            </div>--%>
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
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <!-- bootstrap -->
    <script src="../js/bootstrap.min.js"></script>
    <!-- nice scroll -->
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <!-- charts scripts -->
    <script src="../assets/jquery-knob/js/jquery.knob.js"></script>
    <script src="../js/jquery.sparkline.js" type="text/javascript"></script>
    <script src="../assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js"></script>
    <script src="../js/owl.carousel.js"></script>
    <!-- jQuery full calendar -->
    <<script src="../js/fullcalendar.min.js"></script>
    <!-- Full Google Calendar - Calendar -->
    <script src="../assets/fullcalendar/fullcalendar/fullcalendar.js"></script>
    <!--script for this page only-->
    <script src="../js/calendar-custom.js"></script>
    <script src="../js/jquery.rateit.min.js"></script>
    <!-- custom select -->
    <script src="../js/jquery.customSelect.min.js"></script>
    <script src="../assets/chart-master/Chart.js"></script>

    <!--custome script for all page-->
    <script src="../js/scripts.js"></script>
    <!-- custom script for this page-->
    <script src="../js/sparkline-chart.js"></script>
    <script src="../js/easy-pie-chart.js"></script>
    <script src="../js/jquery-jvectormap-1.2.2.min.js"></script>
    <script src="../js/jquery-jvectormap-world-mill-en.js"></script>
    <script src="../js/xcharts.min.js"></script>
    <script src="../js/jquery.autosize.min.js"></script>
    <script src="../js/jquery.placeholder.min.js"></script>
    <script src="../js/gdp-data.js"></script>
    <script src="../js/morris.min.js"></script>
    <script src="../js/sparklines.js"></script>
    <script src="../js/charts.js"></script>
    <script src="../js/jquery.slimscroll.min.js"></script>
    <script>

        //knob
        $(function () {
            $(".knob").knob({
                'draw': function () {
                    $(this.i).val(this.cv + '%')
                }
            })
        });

        //carousel
        $(document).ready(function () {
            $("#owl-slider").owlCarousel({
                navigation: true,
                slideSpeed: 300,
                paginationSpeed: 400,
                singleItem: true

            });
        });

        //custom select box

        $(function () {
            $('select.styled').customSelect();
        });

        /* ---------- Map ---------- */
        $(function () {
            $('#map').vectorMap({
                map: 'world_mill_en',
                series: {
                    regions: [{
                        values: gdpData,
                        scale: ['#000', '#000'],
                        normalizeFunction: 'polynomial'
                    }]
                },
                backgroundColor: '#eef3f7',
                onLabelShow: function (e, el, code) {
                    el.html(el.html() + ' (GDP - ' + gdpData[code] + ')');
                }
            });
        });

    </script>
</asp:Content>

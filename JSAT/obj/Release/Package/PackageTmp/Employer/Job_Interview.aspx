<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Job_Interview.aspx.cs" Inherits="JSAT_Ver1.Employer.Job_Interview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
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
    <script type="text/javascript">
        $(function () {
            addDatePicker($("#InterviewDate"));
        });

        function addDatePicker(jQueryObject) {
            jQueryObject.datepicker({
                showOn: "button",
                buttonImage: "/Styles/calendar.gif",
                buttonImageOnly: true,
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                yearRange: "c-10:c+10",
                showButtonPanel: false
            });
        }
    </script>

    <script type="text/javascript">
        $(function () {
            addDatePicker2($("#InterviewResultDate"));
        });

        function addDatePicker2(jQueryObject) {
            jQueryObject.datepicker({
                showOn: "button",
                buttonImage: "/Styles/calendar.gif",
                buttonImageOnly: true,
                dateFormat: 'dd-mm-yy',
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                yearRange: "c-10:c+10",
                showButtonPanel: false
            });
        }
    </script>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
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
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <div>
                                    <b>CV送付履歴登録<asp:HiddenField ID="hfID" runat="server" />
                                    </b>
                                    &nbsp;<table>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label5" Text="Interview : " />
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" CssClass="search" ID="ddlInterview">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label1" Text="Interview Date : " />
                                            </td>
                                            <td>
                                                <input type="text" cssclass="search" id="InterviewDate" name="InterviewDate" readonly="readonly" value="<%= this.InputValue1 %>" runat="server" /><asp:Label ID="lblInterviewDate" runat="server" Text="" ForeColor="Red" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label2" Text="Interview Result :" />
                                            </td>
                                            <td>
                                                <asp:DropDownList CssClass="search" runat="server" ID="ddlInterviewResult">
                                                    <asp:ListItem>True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label3" Text="Interview Result Date :" />
                                            </td>
                                            <td>
                                                <input type="text" cssclass="search" id="InterviewResultDate" name="InterviewResultDate" readonly="readonly" runat="server" value="<%= this.InputValue2%>" /><asp:Label ID="lblInterviewResultDate" runat="server" Text="" ForeColor="Red" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label4" Text="Comment : " />
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" CssClass="search" ID="txtComment" TextMode="MultiLine" Width="200px" Height="100px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Button runat="server" class="btn btn-primary" ID="btnSave" Text="Save" OnClick="btnSave_Click" /></td>
                                        </tr>
                                    </table>
                                </div>
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

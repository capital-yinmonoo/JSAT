<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessCheck.aspx.cs" Inherits="JSAT.AccessCheck" %>
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
     <style type="text/css">

.border {
	
	background-color: #f1f1f1;
}

.SectionHeader
{
	color: Black;
	background-color: #CCCCCC;
	font-weight: bold;
	font-size: 12;
	text-align: center;
	height:20px
	}
td {
	font-family: Verdana, Arial, Helvetica, sans-serif,Meiryo,Meiryob;
	font-size: 11px;
}
    </style>
    <section id="main-content">
        <section class="wrapper">
    <table width="50%" border="0" align="Center" cellpadding="3" cellspacing="0" bgcolor="#f4f4f4"
                        class="border">
        <tr class="SectionHeader">
            <td height="20" class="SectionHeader">
                <strong><font>Access Denied</font></strong>
            </td>
        </tr>
        <tr>
            <td>
                <p align="center">
                    <br><span class="setup"><strong><font color="#FF0000">Oops, Error has occured</font></strong></span>
                </p>
                <p align="center">
                                    Please contact the System Administrator.
                                </p>
                <p align="center">
                                    Please click <a href="javascript:history.back(1)"><strong>BACK</strong></a> to previous
                                    screen.<br>
                    <br>
                </p>
            </td>
        </tr>
    </table>
            </section>
        </section>
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
    <script src="../js/owl.carousel.js" ></script>
    <!-- jQuery full calendar -->
    <<script src="../js/fullcalendar.min.js"></script> <!-- Full Google Calendar - Calendar -->
	<script src="../assets/fullcalendar/fullcalendar/fullcalendar.js"></script>
    <!--script for this page only-->
    <script src="../js/calendar-custom.js"></script>
	<script src="../js/jquery.rateit.min.js"></script>
    <!-- custom select -->
    <script src="../js/jquery.customSelect.min.js" ></script>
   
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

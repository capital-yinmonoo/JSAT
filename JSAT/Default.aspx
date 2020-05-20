<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JSAT_Ver1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/favicon.png">
    <title>Basic Table | Creative - Bootstrap 3 Responsive Admin Template</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    <link href="css/elegant-icons-style.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet" />    
</asp:Content>
<asp:Content ID="Content2" class="page-scroll" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <!--overview start-->
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="page-header"><i class="fa fa-laptop"></i>Dashboard</h3>
                    <ol class="breadcrumb">
                        <li><i class="fa fa-home"></i><a href="Default.aspx">Home</a></li>
                        <li><i class="fa fa-laptop"></i>Dashboard</li>
                    </ol>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-md-6" style="width: 220px;">
                    <div class="panel panel-red">
                        <div class="panel-heading">
                            <div class="row">
                                <img src="img/JSAT logo.jpg" width="200px" height="200px" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6">
                    <table class="table table-striped" style="width: 600px;">
                        <tr>
                            <td style="width: 100px; vertical-align: top;">Name</td>
                            <td>:&nbsp;</td>
                            <td><b>J-SAT General Services Co. , Ltd.</b></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">Address</td>
                            <td>:&nbsp;</td>
                            <td><b>Room 1210, 12-A Floor, Sakura Tower, No.339, Bogyoke Aung San Road, Kyauktada T/S</b></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">Phone</td>
                            <td>:&nbsp;</td>
                            <td><b>09-421140290,09-453890835,09-453890836</b></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">Open Time</td>
                            <td>:&nbsp;</td>
                            <td><b>9:00 a.m - 6:00 p.m</b></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">HP</td>
                            <td>:&nbsp;</td>
                            <td>
                                <asp:HyperLink runat="server" Target="_blank" ID="hlWebsite" NavigateUrl="http://jobmyanmar.jp">http://jobmyanmar.jp</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">Email</td>
                            <td>:&nbsp;</td>
                            <td><b>amm@j-sat.jp</b> </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top;">Facebook</td>
                            <td>:&nbsp;</td>
                            <td>
                                <asp:HyperLink runat="server" Target="_blank" ID="HyperLink1" NavigateUrl="http://www.facebook.com/jsat.mm">http://www.facebook.com/jsat.mm</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <p style="border: 0px solid #000; text-align: justify;"></p>
                                <p>Local Job Agency for Japanese Companies</p>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-lg-2 pull-left">
                    <div class="panel panel-default" style="width: 265px; margin-left: 50px;">
                        <div class="panel-heading"><font size="2">Registered Candidates for Each Day</font></div>
                        <asp:GridView runat="server" ID="gvDateUser" AutoGenerateColumns="False" ForeColor="#333333" EmptyDataText="There is no data to display."
                            Style="margin-left: 0px;" AllowPaging="True" GridLines="None" OnPageIndexChanging="gvOnPageIndexChainging" PageSize="5" DataSourceID="objdatasource1"
                            AllowSorting="True" float="left" CellPadding="10" class="table-hvover bootstrap-datatable" Width="265px" AlternatingRowStyle-BackColor="#ffcccc" CellSpacing="5">
                            <PagerSettings Mode="NumericFirstLast" NextPageText="Next" PageButtonCount="2" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                            <Columns>
                                <asp:BoundField DataField="Created_Date" HeaderText="Date" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="#000000" DataFormatString="{0:dd/MM/yyyy}">
                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumberOfUser" ControlStyle-Font-Size="XX-Small" HeaderText="No. of Registered Candidates" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Left" HeaderStyle-ForeColor="#000000">
                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="#dddddd" Font-Bold="True" ForeColor="#7E8C7E" />
                            <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#BBCED1" />
                            <PagerStyle CssClass="pagination-ys" Width="0.5px" HorizontalAlign="left" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <asp:ObjectDataSource ID="objdatasource1" runat="server" EnablePaging="True"
                MaximumRowsParameterName="pageSize" OnSelecting="odsUM_Selecting"
                SelectCountMethod="TotalRowCount" SelectMethod="Paging"
                SortParameterName="sort" StartRowIndexParameterName="startIndex"
                TypeName="JSAT_BL.Date_UserBL">
                <SelectParameters>
                    <asp:Parameter Name="search" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>


        </section>
        <script src="js/jquery.js"></script>
        <script src="js/jquery-ui-1.10.4.min.js"></script>
        <script src="js/jquery-1.8.3.min.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
        <!-- bootstrap -->
        <script src="js/bootstrap.min.js"></script>
        <!-- nice scroll -->
        <script src="js/jquery.scrollTo.min.js"></script>
        <script src="js/jquery.nicescroll.js" type="text/javascript"></script>
        <!--custome script for all page-->
        <script src="js/scripts.js"></script>
        <!-- custom script for this page-->
</asp:Content>

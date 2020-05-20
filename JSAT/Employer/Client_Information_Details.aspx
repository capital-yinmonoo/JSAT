<%@ Page Title="クライアント情報詳細" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Client_Information_Details.aspx.cs" Inherits="JSAT_Ver1.Employer.Client_Information_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px;">
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
                            クライアント情報詳細(Client Information Details)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <fieldset>
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="lblUpdater" runat="server" Text="更新者ID：" Visible="False"></asp:Label>
                                                &nbsp
                                                <asp:Label runat="server" ID="lblUpdatedBy" Visible="False"></asp:Label>
                                                &nbsp
                                                <asp:Label ID="lblUpdateTime" runat="server" Text="更新日(Update Date)：" Visible="False"></asp:Label>
                                                &nbsp
                                                <asp:Label runat="server" ID="lblUpdatedDate" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    &nbsp;
                                                <asp:Button runat="server" ID="btnEditClient" Text="Edit Client Information" Width="200px" OnClick="btnEditClient_Click" class="btn btn-primary" /> <%--クライアント情報を編集する--%>

                                    <br />
                                    <br />
                                    <table class="table">

                                        <tr>
                                            <td style="width: 500px;">クライアントNo.(Client No.)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblClientNo">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>会社名(Company Name)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCompanyName">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>電話番号(Phone Number)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPhoneNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>FAX
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblFax"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ホームページ(Home Page)
                                            </td>
                                            <td>
                                                <asp:HyperLink runat="server" Target="_blank" ID="hlWebsite"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>所在地(location)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblLocation"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>業種(大分類)(Major Classification of Industry)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblIndustry"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>業種(小分類)(Small Classification of Industry)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblBuisness"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>総社員数(Total Number of Employees)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblNoOfEmployees"></asp:Label>&nbsp;名
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>社内日本人数(In-house Japanese Number)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblJapHouseNo"></asp:Label>&nbsp;名
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>設立年月日(Date of Establishment)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEstablishmentDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>備考(Remarks)
                                            </td>
                                            <td valign="top">
                                                <asp:TextBox runat="server" ID="lblRemark" CssClass="search" BorderStyle="None" TextMode="MultiLine"
                                                    BorderColor="Transparent" Height="180px" Width="585px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>同意書(Consent)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblConsent"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>同意書データ(Agreement Form Data)
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkAgreementData"
                                                    OnClick="lnkAgreementData_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <table>
                                        <tr>
                                            <td>
                                                <b>人材紹介申込一覧(Recruitment Application List)</b>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button runat="server" ID="btnRegisterRecruitmentApplication" Width="300px"
                                                    Text="Register Recruitment Application" OnClick="btnRegisterRecruitmentApplication_Click" class="btn btn-primary" />    <%--人材紹介申込を登録する--%>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td colspan="2">
                                                
                                            </td>
                                        </tr>--%>
                                    </table>
                                    <asp:GridView runat="server" ID="gvClientRecruitment" AutoGenerateColumns="False"
                                                    DataKeyNames="ID" EmptyDataText="There is no data to display." AllowPaging="True"
                                                    ShowHeaderWhenEmpty="True" Width="100%" ForeColor="#333333"
                                                    OnRowEditing="gvClientRecruitment_RowEditing" GridLines="None"
                                                    OnRowDeleting="gvClientRecruitment_RowDeleting"
                                                    OnRowDataBound="gvClientRecruitment_RowDataBound"
                                                    OnPageIndexChanging="gvClientRecruitment_PageIndexChanging" class="table">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:CommandField ButtonType="Button" HeaderText="Option" ShowDeleteButton="True"
                                                            ShowEditButton="True"
                                                            DeleteText="Edit" EditText="Details" ControlStyle-CssClass="btn btn-primary" HeaderStyle-ForeColor="White">    <%--操作=Option--%> <%--編集=Edit--%> <%--詳細=Details--%>
                                                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        </asp:CommandField>
                                                        <asp:BoundField DataField="ID" HeaderText="Staffing_Application_No." HeaderStyle-Wrap="false" HeaderStyle-ForeColor="White">   <%--人材紹介申込No.--%>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DivitionOrDepartment" HeaderText="Wanted_Jobs" HeaderStyle-Wrap="false" HeaderStyle-ForeColor="White">   <%--募集職種--%>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Person_Name" HeaderText="Contact_Person" HeaderStyle-Wrap="false" HeaderStyle-ForeColor="White"> <%--担当者名--%>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SubDate" HeaderText="Date_of_Application" DataFormatString="{0:dd/MMM/yyyy}" HeaderStyle-Wrap="false" HeaderStyle-ForeColor="White"> <%--申込日--%>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Wanted" HeaderText="Recruitment" SortExpression="Wanted" HeaderStyle-Wrap="false" HeaderStyle-ForeColor="White"> <%--募集中--%>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#999999" />
                                                    <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                </asp:GridView>
                                </fieldset>
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

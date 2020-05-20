<%@ Page Title="人材紹介申込詳細" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Client_Recruitment_Detail.aspx.cs" Inherits="JSAT_Ver1.Employer.Client_Recruitment_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="Scriptmanger1" runat="server"></asp:ScriptManager>
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
                            人材紹介申込詳細(Recruitment Application Details)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <fieldset>
                                    <table align="right">
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="更新者ID："></asp:Label>
                                                &nbsp
                                                <asp:Label runat="server" ID="lblUpdater"></asp:Label>
                                                &nbsp
                                                <asp:Label runat="server" Text="更新日："></asp:Label>
                                                &nbsp
                                                <asp:Label runat="server" ID="lblUpdateTime"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <asp:Button runat="server" Text="Edit Recruitment Application" ID="btnRecruitment" class="btn btn-primary" OnClick="btnRecruitment_Click" Width="300px" />  <%--人材紹介申込を編集する--%>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnMatching" runat="server" class="btn btn-primary" Text="Matching" Width="170px"
                                    OnClick="btnMatching_Click" />
                                    <br />
                                    <br />
                                    <table class="table" style="width:1100px;">
                                        <tr>
                                            <td>クライアントNo.(Client No.)
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblClientNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>会社名(Company Name)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblName"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Jobno</td>
                                            <td>
                                                <asp:Label ID="lbljobno" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>電話番号(Phone Number)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPhoneNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>所在地(Location)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblLocation"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>人材紹介No.(Recruitment No)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblRecruitmentNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>担当者(Incharge Person)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPersonInCharge"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>部署(Department)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDutyPost"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>担当者電話番号(Incharge Person Phone Number)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPersonInChargePhoneNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>担当者メールアドレス(Incharge Person Mail Address)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPersonInChargeEmail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>業種(大分類)Large Business</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblMajorIndustry"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>業種(小分類)Small Business</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSmallIndustry"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>申込日(Submission Date)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSubmissionDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>職種(大分類)(Large Classification of Job Category)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblMajorOccupation"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>職種(小分類)(Small Classification of Job Category)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSmallOcupation"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>役職(Position)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPost"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>上記以外の役職(Other Position)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblOtherPost"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>性別(Gender)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblGender"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>給料(Salary)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSalary"></asp:Label>
                                               <asp:Label runat="server" ID="lblSalaryFormat"></asp:Label>&nbsp;&nbsp;
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>上記以外の給料(Other Salary)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblOtherSalary"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>勤務地(Work Location)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblWorkableArea"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>上記以外の勤務地(Other Work Location)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblOtherWorkableArea"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>土曜日勤務(Saturday Work)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDayService"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>始業時間(Opening Time)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblStartTime"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>終業時間(Closing Time)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCloseTime"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Entering Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEnterDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ASAP1</td>
                                            <td>
                                                <asp:Label ID="lblASAP1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Interview Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblInterviewDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ASAP2</td>
                                            <td>
                                                <asp:Label ID="lblASAP2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>日本語:(Japanese)
                                            </td>
                                            <td>読み書き(LISTENING)&nbsp; 
                                            <asp:Label runat="server" ID="lbljapanlanguagelisten"></asp:Label>&nbsp;&nbsp; 
                                             会話(SPEAKING)&nbsp; 
                                            <asp:Label runat="server" ID="lbljapanlanguagespeak"></asp:Label>&nbsp; 
                                             <asp:Label runat="server" ID="lbljapanlanguagelistenTo" Visible="false"></asp:Label>&nbsp; 
                                             <asp:Label runat="server" ID="lbljapanlanguagespeakTo" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style2">英語:(English)
                                            </td>
                                            <td class="style2">読み書き(LISTENING) &nbsp; 
                                        <asp:Label runat="server" ID="lblEnglishlanguagelisten"></asp:Label>&nbsp;&nbsp;
                                         会話(SPEAKING)&nbsp; 
                                         <asp:Label runat="server" ID="lblEnglishlanguagespeak"></asp:Label>&nbsp; 
                                         <asp:Label runat="server" ID="lblEnglishlanguageto" Visible="false"></asp:Label>&nbsp; 
                                         <asp:Label runat="server" ID="lblEnglishlanguagespeakto" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ミャンマー語:(Myanmar)
                                            </td>
                                            <td>読み書き(LISTENING) &nbsp; 
                                             <asp:Label runat="server" ID="lblMyanmarlanguagelisten"></asp:Label>&nbsp;&nbsp; 
                                             会話(SPEAKING)&nbsp; 
                                            <asp:Label runat="server" ID="lblMyanmarlanguagespeak"></asp:Label>&nbsp;         
                                            <asp:Label runat="server" ID="lblMyanmarlanguageto" Visible="false"></asp:Label>&nbsp; 
                                            <asp:Label runat="server" ID="lblMyanmarlanguagespeakto" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>年齢(Age)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAge"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>備考(Remarks)</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="lblRemark" BorderColor="Transparent"
                                                    BorderStyle="None" TextMode="MultiLine" ReadOnly="true" Height="130px"
                                                    Width="500px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>募集中(During Recruitment)</td>
                                            <td>
                                                <asp:Label ID="lblWanted" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label runat="server" ID="lblLanguage" Visible="false"></asp:Label>
                                    <br />
                                    <b>CV送付履歴(CV Sending History)</b>
                                    <br />
                                    <br />
                                    <asp:Button ID="btnJobCareerInterview" class="btn btn-primary" runat="server" Text="Edit CV Sending History" OnClick="btnJobCareerInterview_Click" Width="300px" /> <%--CV送付履歴を一括編集する--%>
                                    <br />
                                    <br />
                                    <asp:UpdatePanel ID="Updatepanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgvCareerInterview" runat="server" ShowHeaderWhenEmpty="true"
                                                AutoGenerateColumns="False" OnRowCommand="dgvCareerInterview_RowCommand"
                                                EmptyDataText="No Data to Display" GridLines="None"
                                                OnRowDataBound="dgvCareerInterview_RowDataBound" class="table">
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-ForeColor="White">
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                        <HeaderTemplate>
                                                            <asp:Label runat="server" Text="Options"></asp:Label>    <%--操作--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:Button class="btn btn-primary" ID="btnDetail" runat="server" Text="Details" CommandName="DataDetail" CommandArgument='<%# Eval("ID") %>' /> <%--詳細--%>
                                                            <asp:Button class="btn btn-danger" ID="btnEdit" runat="server" Text="Delete" CommandName="DataDelete" CommandArgument='<%# Eval("ID") %>' />    <%--削除--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="	Career_ID" DataField="Career_ID" Visible="false" HeaderStyle-ForeColor="White" />
                                                    <asp:BoundField HeaderText="	Registration_Number" DataField="Career_Code" HeaderStyle-ForeColor="White">    <%--登録番号--%>
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Name" DataField="Name" HeaderStyle-ForeColor="White">   <%--名前--%>
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Interview" HeaderText="Document_Selection" HeaderStyle-ForeColor="White" />    <%--書類選考--%>
                                                    <asp:BoundField HeaderText="Interview_Date" DataField="Interview_Date" DataFormatString="{0:dd / MMM /yyyy}" HeaderStyle-ForeColor="White">   <%--面接日--%>
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Interview_Result" HeaderText="Interview_Result" HeaderStyle-ForeColor="White" /> <%--合否結果--%>
                                                    <asp:BoundField HeaderText="Interview_Result_Date" DataField="Interview_Result_Date" DataFormatString="{0:dd / MMM /yyyy}" HeaderStyle-ForeColor="White">    <%--採用決定日--%>
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
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
            </div>
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

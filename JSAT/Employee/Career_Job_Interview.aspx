<%@ Page Title="CV送付履歴編集" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Career_Job_Interview.aspx.cs" Inherits="JSAT_Ver1.Employee.Career_Job_Interview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../date/bootstrap.min.css" rel="stylesheet" />
    <link href="../date/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    
    <script type="text/javascript">
        function NotType(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 8)
                return true;
            return false;
        }
    </script>
    <script type="text/javascript">
        function RadioCheck(rb) {
            var gv = document.getElementById("<%=dgvRecruitment.ClientID%>");
            var rbs = gv.getElementsByTagName("input");
            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }
    </script>

    <script type="text/javascript">
        function ShowDialog() {
        var width = 750;
        var height = 750;
        var left = (screen.width - width) / 2;
        var top = (screen.height - height) / 2;
        var params = 'width=' + 950 + ', height=' + 650;
        params += ', top=' + top + ', left=' + left;
        params += ', toolbar=no';
        params += ', menubar=no';
        params += ', resizable=yes';
        params += ', directories=no';
        params += ', scrollbars=yes';
        params += ', status=no';
        params += ', location=no';
        window.open('../Search_Dialog.aspx?Type=1', window, params);
        //retval = window.showModalDialog
        //('../Search_Dialog.aspx?Type=1', window);
        }

        function updateValue(value) {
            // this gets called from the popup window and updates the field with a new value
            var Name = '<%= txtValue.ClientID %>';
        document.getElementById(Name).value = value;
        __doPostBack('<%= imgSearch.ClientID  %>', '');
        }
    </script>
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#<%=txtInterviewDate.ClientID %>").datepicker(
	    {
	        showOn: 'button',
	        dateFormat: 'dd/M/yy',
	        buttonImageOnly: true,
	        buttonImage: '../Styles/calendar.gif',
	        changeMonth: true,
	        changeYear: true,
	        yearRange: "2013:2030",
	    }
	   );

                $("#<%=txtInterviewResultDate.ClientID %>").datepicker(
                 {
                     showOn: 'button',
                     dateFormat: 'dd/M/yy',
                     buttonImageOnly: true,
                     buttonImage: '../Styles/calendar.gif',
                     changeMonth: true,
                     changeYear: true,
                     yearRange: "2013:2030",
                 }
                );

                $(".ui-datepicker-trigger").mouseover(function () {
                    $(this).css('cursor', 'pointer');
                });
            });
        }
    </script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 46)
                return true;
            else return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="Scriptmanger1" runat="server"></asp:ScriptManager>
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Employeer</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            CV送付履歴登録(CV Sending History Registration)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <fieldset>                                    
                                    <div align="right">
                                        <asp:Label ID="lblUpdater" runat="server" Text="更新者ID(Updater_ID) :" Visible="False"></asp:Label>
                                        &nbsp;
                                        <asp:Label runat="server" ID="lblUpdaterData" Visible="False"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblUpdateTime" runat="server" Text="更新日(Update_Date) :" Visible="False"></asp:Label>
                                        &nbsp;
                                        <asp:Label runat="server" ID="lblUpdateTimeData" Visible="False"></asp:Label>
                                    </div>
                                    <table class="style1" align="center" cellpadding="15px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblName" Text="会社名(Company Name)" runat="server"></asp:Label>
                                                <asp:TextBox ID="txtName" runat="server" Width="150px" Height="30px" CssClass="form-control"></asp:TextBox>
                                                &nbsp;<asp:ImageButton ID="imgSearch" runat="server" Height="28px"
                                                    Width="28px" ImageUrl="~/img/search.png" OnClientClick="ShowDialog()" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblClientNo" Text="クライアントNo.(Client No.)" runat="server"></asp:Label>
                                                <asp:TextBox ID="txtClientNo" runat="server" Width="58px" Height="30px" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRecruitmentNo" Text="人材紹介No.(Recruitment No.)" runat="server"></asp:Label>
                                                <asp:TextBox ID="txtRecruitmentNo" runat="server" Width="47px" Height="30px" CssClass="form-control"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="txtValue" Width="0px" Height="0px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                <br />
                                                <asp:Button ID="btnSearchData" runat="server" Height="30px"
                                                    Text="Search" Width="200px" OnClick="btnSearchData_Click" class="btn btn-primary" />
                                                <%--検索する--%>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <asp:GridView ID="dgvRecruitment" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                        EmptyDataText="No Data To Display" ShowHeaderWhenEmpty="true"
                                        OnPageIndexChanging="dgvRecruitment_PageIndexChanging" ForeColor="#333333" GridLines="None"
                                        OnRowDataBound="dgvRecruitment_RowDataBound"
                                        OnRowCommand="dgvRecruitment_RowCommand" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-ForeColor="White">
                                                <HeaderTemplate>
                                                    <asp:Label runat="server" Text="Object"></asp:Label>
                                                    <%--対象--%>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:RadioButton runat="server" ID="rdoRecruitment" onclick="RadioCheck(this)" />
                                                    <asp:Button ID="btnRecruitment" runat="server" Text="1.Details" class="btn btn-primary" CommandArgument='<%# Eval("ID") %>' CommandName="DataDetail" />
                                                    <%--詳細--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="Recruitment No." HeaderStyle-ForeColor="White"><%--人材紹介No.--%>
                                                <HeaderStyle BorderStyle="Solid" />
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Client_ID" HeaderText="Client_ID" Visible="False" HeaderStyle-ForeColor="White">
                                                <HeaderStyle BorderStyle="Solid" />
                                                <ItemStyle HorizontalAlign="Center" Wrap="true" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Client Name" SortExpression="Name" HeaderStyle-ForeColor="White"><%--クライアント名前--%>
                                                <HeaderStyle BorderStyle="Solid" />
                                                <ItemStyle HorizontalAlign="Center" Wrap="true" Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DivitionOrDepartment" Visible="false"
                                                HeaderText="職種(大分類)" SortExpression="DivitionOrDepartment">
                                                <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Position" HeaderText="Wanted Jobs" SortExpression="Position" HeaderStyle-ForeColor="White"><%--募集職種--%>
                                                <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Languages" HeaderText="Language" HeaderStyle-ForeColor="White"><%--言語--%>
                                                <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CompleteSalary" HeaderText="Salary" HeaderStyle-ForeColor="White"><%--給料--%>
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gender" HeaderText="Gender" Visible="false"><%--性別--%>
                                                <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ContactPerson" HeaderText="Contact Person" HeaderStyle-ForeColor="White"><%--担当者名--%>
                                                <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                <ItemStyle HorizontalAlign="Center" Width="200px" />
                                            </asp:BoundField>
                                        </Columns>
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
                                    <br />
                                    <br />
                                    <table cellpadding="6" align="center" width="80%">
                                        <tr>
                                            <td width="250px">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                    HeaderText="You must enter a value in the following fields:"
                                                    EnableClientScript="true"
                                                    ForeColor="Red"
                                                    ValidationGroup="check"
                                                    ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Document Selection" ID="lblInterview"></asp:Label>
                                                <%--書類選考--%>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlInterview" Width="80px" Height="30px" CssClass="form-control">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="1">○</asp:ListItem>
                                                    <asp:ListItem Value="2">×</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Interview Date" ID="lblInterviewDate"></asp:Label>
                                                <%--面接日--%>
                                            </td>
                                            <td>
                                                <%--<asp:UpdatePanel runat="server">
                                                    <ContentTemplate>--%>
                                                        <div class="control-group" style="float: left">
                                                            <div class="controls input-append date form_date" style="width: 100px" data-date="" data-date-format="dd/MM/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                                <asp:TextBox ID="txtInterviewDate" runat="server" Width="180px" Height="30px" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                                                <span class="add-on" style="float: left; margin-left: 180px; margin-top: -30px; height: 30.5px"><i class="icon-th"></i></span>
                                                            </div>
                                                        </div>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" class="calendar" Visible="false" Width="16px" Height="19px" ImageUrl="~/img/clear.png" OnClick="ImageButton1_Click" />
                                                    <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Interview Result" ID="lblInterviewResult"></asp:Label>
                                                <%--合否結果--%>
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" Width="80px" Height="30px" ID="ddlInterviewResult" CssClass="form-control">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="1">○</asp:ListItem>
                                                    <asp:ListItem Value="2">×</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Working Day" ID="Label3"></asp:Label>
                                                <%--勤務開始日--%>
                                            </td>
                                            <td>
                                                <%--<asp:UpdatePanel runat="server">
                                                    <ContentTemplate>--%>
                                                        <div class="control-group" style="float: left">
                                                            <div class="controls input-append date form_date" style="width: 100px" data-date="" data-date-format="dd/MM/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                                <asp:TextBox ID="txtInterviewResultDate" runat="server" Width="180px" Height="30px" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                                                                <span class="add-on" style="float: left; margin-left: 180px; margin-top: -30px; height: 30.5px"><i class="icon-th"></i></span>
                                                            </div>
                                                        </div>
                                                        <asp:ImageButton ID="ImageButton2" runat="server" class="calendar" Visible="false" Width="16px" Height="19px" ImageUrl="~/img/clear.png" OnClick="ImageButton2_Click" />
                                                   <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Salary" ID="lblSalary"></asp:Label>
                                                <%--給料--%>
                                            </td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtSalary" onkeypress="return isNumberKey(event)" Width="86px" MaxLength="9" CssClass="form-control" Height="30px" ValidationGroup="check"></asp:TextBox>
                                                <asp:DropDownList runat="server" ID="ddlSalaryType" Height="30px" Width="80px" CssClass="form-control"></asp:DropDownList>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator4"
                                                    runat="server"
                                                    ValidationExpression="\d+"
                                                    ControlToValidate="txtSalary"
                                                    Text="*"
                                                    ErrorMessage="You Must Only number in 給料"
                                                    ValidationGroup="check"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
                                                <%--コメント--%>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Height="180px" CssClass="form-control" ValidationGroup="check"
                                                    Width="585px" MaxLength="400"></asp:TextBox>
                                                <asp:CustomValidator ID="CustomValidator2" runat="server"
                                                    OnServerValidate="cusCustom_ServerValidate"
                                                    ForeColor="Red"
                                                    ControlToValidate="txtComment"
                                                    Text="*"
                                                    ErrorMessage="コメント allow only 400 characters.Your comment is more than maximum length.">
                                                </asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <br />
                                                <asp:HiddenField ID="hfMode" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width:75%";>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="200px" class="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete?');"
                                                    OnClick="btnDelete_Click" />    <%--削除する--%>
                                                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Register"
                                                    Width="200px" OnClick="btnSave_Click" ValidationGroup="check" />    <%--登録する--%>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
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

    
    <script type="text/javascript" src="../date/jquery-1.8.3.min.js" charset="UTF-8"></script>
    <script src="../date/bootstrap-datetimepicker.js" charset="UTF-8"></script>
    <script src="../date/bootstrap-datetimepicker.fr.js" charset="UTF-8"></script>
    <script type="text/javascript">

        $('.form_date').datetimepicker({
            //language: 'fr',            
            weekStart: 1,
            //todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            clearBtn: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });

        $('.form-date-time').datetimepicker({
            //language: 'fr',            
            weekStart: 1,
            //todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            clearBtn: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });

        $('.form-date-time-date').datetimepicker({
            //language: 'fr',            
            weekStart: 1,
            //todayBtn: 1,
            autoclose: 1,
            todayHighlight: 1,
            clearBtn: 1,
            startView: 2,
            minView: 2,
            forceParse: 0
        });
    </script>
    <script src="../js/jquery.js"></script>
	<script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>   
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>    
    <script src="../js/scripts.js"></script>
</asp:Content>

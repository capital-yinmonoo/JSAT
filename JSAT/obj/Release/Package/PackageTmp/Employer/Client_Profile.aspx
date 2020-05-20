<%@ Page Title="クライアント情報" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Client_Profile.aspx.cs" Inherits="JSAT_Ver1.Employer.Client_Profile" %>

<%@ Register Src="~/Usercontrol/ClientControlLink.ascx" TagName="ClientControlLink" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script language="javascript" type="text/javascript">
        function CheckNumeric(e) {
            if (window.event) // IE 
            {
                if ((e.keyCode < 48 || e.keyCode > 57) & e.keyCode != 8) {
                    event.returnValue = false;
                    return false;
                }
            }
            else { // Fire Fox
                if ((e.which < 48 || e.which > 57) & e.which != 8) {
                    e.preventDefault();
                    return false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            addDatePicker($("#datepicker"));
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
                            <asp:Label runat="server" ID="lblHeader" Font-Bold="true" Font-Size="medium" Width="400px"></asp:Label>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <div>
                                    <fieldset>
                                        <asp:UpdatePanel runat="server" ID="updPnl">
                                            <ContentTemplate>
                                                <table align="right">
                                                    <tr>
                                                        <td>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <asp:HiddenField ID="hdfFileName" runat="server" />
                                                            <asp:HiddenField ID="hfValue" runat="server" />
                                                            <asp:HiddenField ID="hdfClient_ProfileID" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td align="right">
                                                            <asp:Label ID="lblUpdater" runat="server" Text="更新者ID：" Visible="False"></asp:Label>
                                                            &nbsp
                                                            <asp:Label runat="server" ID="lblUpdaterData" Visible="False"></asp:Label>
                                                            &nbsp
                                                            <asp:Label ID="lblUpdateTime" runat="server" Text="更新日(Update Date)：" Visible="False"></asp:Label>
                                                            &nbsp
                                                            <asp:Label runat="server" ID="lblUpdateTimeData" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <br />

                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                                HeaderText="You must enter a value in the following fields:"
                                                                EnableClientScript="true"
                                                                ForeColor="Red"
                                                                ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true"
                                                                ValidationGroup="check" />
                                                        </td>
                                                    </tr>
                                                </table>

                                                <table>

                                                    <tr>
                                                        <td rowspan="15">
                                                            <uc3:ClientControlLink ID="ClientControlLink1" runat="server" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label></td>
                                                    </tr>

                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label" runat="server" Text="クライアントNo.(Client No.)" Visible="false"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblClientCode" Visible="False"
                                                                ToolTip=" Client No."></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label1" runat="server" Text="会社名(Comapny Name)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtCompany" MaxLength="100" Width="500px"
                                                                ToolTip="Company name" CssClass="form-control"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="txtCompany" ErrorMessage="会社名" Text="*"
                                                                ForeColor="Red" ValidationGroup="check"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label4" runat="server" Text="電話番号(Phone Number)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtTelephoneNumber" ValidationGroup="check"
                                                                MaxLength="14" Width="500px" ToolTip="Phone number" CssClass="form-control"></asp:TextBox>
                                                            <asp:RegularExpressionValidator
                                                                ID="regPhone"
                                                                runat="server"
                                                                ControlToValidate="txtTelephoneNumber"
                                                                ForeColor="Red"
                                                                Text="*"
                                                                ErrorMessage="Invalid 電話番号 Eg.095118746"
                                                                ValidationExpression="([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$"
                                                                ValidationGroup="check" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label5" runat="server" Text="FAX"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" CssClass="form-control" Width="500px" ID="txtFax" ToolTip="Fax"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label6" runat="server" Text="ホームページ(Home Page)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtWebsite" Width="500px" CssClass="form-control" ToolTip="Website Name"></asp:TextBox>
                                                            <asp:RegularExpressionValidator
                                                                ID="RegularExpressionValidator1"
                                                                runat="server"
                                                                ValidationExpression="((?:https?\:\/\/|www\.|ftp?:\/\/)(?:[-a-z0-9]+\.)*[-a-z0-9]+.*)"
                                                                ControlToValidate="txtWebsite"
                                                                Text="*"
                                                                ErrorMessage="Invalid ホームページ. Eg. www.google.com"
                                                                ValidationGroup="check"
                                                                ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label7" runat="server" Text="所在地(Location)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtLoaction" CssClass="form-control" Width="500px" ToolTip="Location"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label15" runat="server" Text="業種(大分類)(Major Classification of Industry)"></asp:Label>
                                                            <br />
                                                            <br />
                                                            業種(小分類)(Small Classification of Industry)</td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlIndustry" runat="server" Width="300px" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlIndustry_SelectedIndexChanged" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    &nbsp; 
                                                                    <asp:Button runat="server" ID="btnRefresh" Text="Refresh"
                                                                        OnClick="btnRefresh_Click" class="btn btn-primary" />
                                                                    &nbsp;&nbsp;           
                                                                     <br />
                                                                    <br />
                                                                    <asp:DropDownList ID="ddlTypeOfBusiness" runat="server" Width="500px" CssClass="form-control"></asp:DropDownList>
                                                                    <br />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label9" runat="server" Text="総社員数(Total Number of Employees)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtNoOfEmployees" Width="100px"
                                                                onkeypress="CheckNumeric(event);" MaxLength="9"
                                                                ToolTip="Total number of employees" CssClass="form-control"></asp:TextBox>名
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator2"
                                    runat="server"
                                    ValidationExpression="\d+"
                                    ControlToValidate="txtNoOfEmployees"
                                    Text="*"
                                    ErrorMessage="You Must Only number in 総社員数"
                                    ValidationGroup="check"
                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label10" runat="server" Text="社内日本人数(In-house Japanese Number)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtHouseNumber" onkeypress="CheckNumeric(event);"
                                                                Width="100px" MaxLength="9" CssClass="form-control" ToolTip="Japanese house number "></asp:TextBox>名
                                <asp:RegularExpressionValidator
                                    ID="RegularExpressionValidator3"
                                    runat="server"
                                    ValidationExpression="\d+"
                                    ControlToValidate="txtHouseNumber"
                                    Text="*"
                                    ErrorMessage="You Must Only number in 社内日本人数"
                                    ValidationGroup="check"
                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label11" runat="server" Text="設立年月日(Date of Establishment)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlMonth" runat="server" Width="225px" CssClass="search">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem>Jan</asp:ListItem>
                                                                <asp:ListItem>Feb</asp:ListItem>
                                                                <asp:ListItem>Mar</asp:ListItem>
                                                                <asp:ListItem>Apr</asp:ListItem>
                                                                <asp:ListItem>May</asp:ListItem>
                                                                <asp:ListItem>Jun</asp:ListItem>
                                                                <asp:ListItem>Jul</asp:ListItem>
                                                                <asp:ListItem>Aug</asp:ListItem>
                                                                <asp:ListItem>Sep</asp:ListItem>
                                                                <asp:ListItem>Oct</asp:ListItem>
                                                                <asp:ListItem>Nov</asp:ListItem>
                                                                <asp:ListItem>Dec</asp:ListItem>
                                                            </asp:DropDownList>月 (MONTH)

                                <asp:DropDownList ID="ddlYear" runat="server" Width="225px" CssClass="search">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>1980</asp:ListItem>
                                    <asp:ListItem>1981</asp:ListItem>
                                    <asp:ListItem>1982</asp:ListItem>
                                    <asp:ListItem>1983</asp:ListItem>
                                    <asp:ListItem>1984</asp:ListItem>
                                    <asp:ListItem>1985</asp:ListItem>
                                    <asp:ListItem>1986</asp:ListItem>
                                    <asp:ListItem>1987</asp:ListItem>
                                    <asp:ListItem>1988</asp:ListItem>
                                    <asp:ListItem>1989</asp:ListItem>
                                    <asp:ListItem>1990</asp:ListItem>
                                    <asp:ListItem>1991</asp:ListItem>
                                    <asp:ListItem>1992</asp:ListItem>
                                    <asp:ListItem>1993</asp:ListItem>
                                    <asp:ListItem>1994</asp:ListItem>
                                    <asp:ListItem>1995</asp:ListItem>
                                    <asp:ListItem>1996</asp:ListItem>
                                    <asp:ListItem>1997</asp:ListItem>
                                    <asp:ListItem>1998</asp:ListItem>
                                    <asp:ListItem>1999</asp:ListItem>
                                    <asp:ListItem>2000</asp:ListItem>
                                    <asp:ListItem>2001</asp:ListItem>
                                    <asp:ListItem>2002</asp:ListItem>
                                    <asp:ListItem>2003</asp:ListItem>
                                    <asp:ListItem>2004</asp:ListItem>
                                    <asp:ListItem>2005</asp:ListItem>
                                    <asp:ListItem>2006</asp:ListItem>
                                    <asp:ListItem>2007</asp:ListItem>
                                    <asp:ListItem>2008</asp:ListItem>
                                    <asp:ListItem>2009</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2011</asp:ListItem>
                                    <asp:ListItem>2012</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                </asp:DropDownList>年 (YEAR)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">
                                                            <asp:Label ID="Label12" runat="server" Text="備考(Remarks)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtRemarks" Height="180px" TextMode="MultiLine" ValidationGroup="check"
                                                                Width="585px" ToolTip="Remarks" CssClass="form-control"></asp:TextBox>
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server"
                                                                OnServerValidate="cusCustom_ServerValidate"
                                                                ControlToValidate="txtRemarks"
                                                                Text="*"
                                                                ForeColor="Red"
                                                                ValidationGroup="check"
                                                                ErrorMessage="備考 allow only 400 characters.Your comment is more than maximum length.">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label13" runat="server" Text="同意書(Consent)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox runat="server" ID="chkConsent" ToolTip="Consent form" />有 (YES)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label14" runat="server" Text="同意書データ(Agreement Form Data)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:LinkButton runat="server" ID="lnkDownload" OnClick="lnkDownload_Click"></asp:LinkButton>
                                                            <asp:Button runat="server" class="btn btn-primary" ID="btnImageDelete" Text="削除する" OnClick="btnImageDelete_Click" Visible="False" />
                                                            <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                                                            <br />
                                                            <br />
                                                            <asp:FileUpload runat="server" ID="fileUpload" CssClass="form-control" Width="300px" />
                                                            <br />
                                                            <asp:Label runat="server" ID="lblfileUpload" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <table>
                                            <tr>
                                                <td colspan="3" align="right">
                                                    <br />
                                                    <br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnDelete" Text="Delete" Enabled="false" Width="200px" OnClientClick="return confirm('Are you sure you want to delete?');"
                            OnClick="btnDelete_Click" class="btn btn-primary" CssClass="btn btn-danger" Visible="False" />  <%--削除する--%>
                                                    &nbsp; &nbsp;
                        <asp:Button runat="server" ID="btnSubmit" Text="Register" OnClick="btnSubmit_Click" Width="200px"
                            EnableTheming="False" ValidationGroup="check" CssClass="btn btn-primary" /> <%--登録する--%>

                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                                <!-- preview image-->

                                <div id="divBackground" class="modal">
                                </div>
                                <div id="divImage">
                                    <table style="height: 100%; width: 100%">
                                        <tr>
                                            <td valign="middle" align="center">
                                                <img id="imgLoader" alt=""
                                                    src="images/loader.gif" />

                                                <img id="imgFull" alt="" src=""
                                                    style="display: none; height: 500px; width: 590px" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td align="center" valign="bottom">
                                                <input id="btnClose" type="button" value="close"
                                                    onclick="HideDiv()" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <style type="text/css">
                                    body
                                    {
                                        margin: 0;
                                        padding: 0;
                                        height: 100%;
                                    }

                                    .modal
                                    {
                                        display: none;
                                        position: absolute;
                                        top: 0px;
                                        left: 0px;
                                        background-color: black;
                                        z-index: 100;
                                        opacity: 0.8;
                                        filter: alpha(opacity=60);
                                        -moz-opacity: 0.8;
                                        min-height: 100%;
                                    }

                                    #divImage
                                    {
                                        display: none;
                                        z-index: 1000;
                                        position: fixed;
                                        top: 0;
                                        left: 0;
                                        background-color: White;
                                        height: 550px;
                                        width: 600px;
                                        padding: 3px;
                                        border: solid 1px black;
                                    }

                                    .style1
                                    {
                                        width: 680px;
                                    }

                                    .style2
                                    {
                                        width: 207px;
                                    }

                                    .style3
                                    {
                                        width: 280px;
                                    }
                                </style>

                                <script type="text/javascript">

                                    function LoadDiv(url) {
                                        var img = new Image();

                                        var bcgDiv = document.getElementById("divBackground");

                                        var imgDiv = document.getElementById("divImage");

                                        var imgFull = document.getElementById("imgFull");

                                        var imgLoader = document.getElementById("imgLoader");

                                        imgLoader.style.display = "block";

                                        img.onload = function () {

                                            imgFull.src = img.src;

                                            imgFull.style.display = "block";

                                            imgLoader.style.display = "none";

                                        };

                                        img.src = url;

                                        var width = document.body.clientWidth;

                                        if (document.body.clientHeight > document.body.scrollHeight) {

                                            bcgDiv.style.height = document.body.clientHeight + "px";

                                        }

                                        else {

                                            bcgDiv.style.height = document.body.scrollHeight + "px";

                                        }

                                        imgDiv.style.left = (width - 650) / 2 + "px";

                                        imgDiv.style.top = "20px";

                                        bcgDiv.style.width = "100%";

                                        bcgDiv.style.display = "block";

                                        imgDiv.style.display = "block";

                                        return false;
                                    }

                                    function HideDiv() {

                                        var bcgDiv = document.getElementById("divBackground");
                                        var imgDiv = document.getElementById("divImage");
                                        var imgFull = document.getElementById("imgFull");
                                        if (bcgDiv != null) {

                                            bcgDiv.style.display = "none";
                                            imgDiv.style.display = "none";
                                            imgFull.style.display = "none";
                                        }
                                    }

                                </script>
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
    <script src="../js/jquery.js"></script>
	<script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>   
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>    
    <script src="../js/scripts.js"></script>
</asp:Content>

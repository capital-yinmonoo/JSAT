<%@ Page Title="人材紹介申込" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Client_Recruitment.aspx.cs" Inherits="JSAT_Ver1.Employer.Client_Recruitment" %>

<%@ Register Src="~/Usercontrol/ClientControlLink.ascx" TagName="ClientControlLink" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../date/bootstrap.min.css" rel="stylesheet" />
    <link href="../date/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 46)
                return true;
            else return false;
        }
    </script>
    <script type="text/javascript">
        // Let's use a lowercase function name to keep with JavaScript conventions
        function selectAll(invoker) {
            var inputElements = document.getElementsByTagName('input');
            for (var i = 0; i < inputElements.length; i++) {
                var myElement = inputElements[i];
                var row = inputElements[i].parentNode.parentNode;
                if (myElement.type === "checkbox") {
                    if (invoker.checked == true) {
                        row.style.backgroundColor = "aqua";
                        select = "true";
                    }
                    else {
                        row.style.backgroundColor = "white";
                        select = "false";
                    }
                    myElement.checked = invoker.checked;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function selectRow(invoker) {
            var row = invoker.parentNode.parentNode;
            if (invoker.checked) {
                row.style.backgroundColor = "aqua";
                select = "Yes";
            }
            else {
                select = "No";
                if (row.rowIndex % 2 == 0) {
                    row.style.backgroundColor = "White";
                }
                else {
                    row.style.backgroundColor = "#F7F6F3";
                    row.style.foreColor = "#333333";
                }
            }
        }
    </script>
    <script type="text/javascript">
        function NotType(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            return false;
        }

        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57) && iKeyCode != 45 && iKeyCode != 43)
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        function checkEmail(ctrl) {
            var id = ctrl.id;
            if (id == "MainContent_txtEmailConfirm")
            {
                var email = document.getElementById('MainContent_txtEmail');
                var email_confirm = document.getElementById('MainContent_txtEmailConfirm');
                if (email.value.trim() != email_confirm.value.trim())
                {
                    email_confirm.value = '';
                    email_confirm.focus();
                }
            }
            else if (id == "MainContent_txtEmailConfirm1") {
                var email1 = document.getElementById('MainContent_txtEmail1');
                var email_confirm1 = document.getElementById('MainContent_txtEmailConfirm1');
                if (email1.value.trim() != email_confirm1.value.trim()) {
                    email_confirm1.value = '';
                    email_confirm1.focus();
                }
            }
            else if (id == "MainContent_txtEmailConfirm2") {
                var email2 = document.getElementById('MainContent_txtEmail2');
                var email_confirm2 = document.getElementById('MainContent_txtEmailConfirm2');
                if (email2.value.trim() != email_confirm2.value.trim()) {
                    email_confirm2.value = '';
                    email_confirm2.focus();
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                            <asp:Label runat="server" ID="lblTitle" Font-Bold="true" Font-Size="medium"></asp:Label>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <div>
                                    <fieldset>
                                        <%--<asp:UpdatePanel runat="server" ID="updPnl">
                                            <ContentTemplate>--%>
                                                <table align="right">
                                                    <tr>
                                                        <td></td>
                                                        <td> 
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

                                                <table cellpadding="3px">
                                                    <tr>
                                                        <td rowspan="37">
                                                            <uc1:ClientControlLink ID="ClientControlLink1" runat="server" Visible="False" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                                HeaderText="You must enter a value in the following fields:"
                                                                EnableClientScript="true"
                                                                ForeColor="Red"
                                                                ValidationGroup="check"
                                                                ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="3px">
                                                    <tr>
                                                        <td class="style3">クライアントNo.(Client No.)</td>
                                                        <td>
                                                            <asp:Label ID="lblClientNo" runat="server" ToolTip="Client No."></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">会社名(Company Name)</td>
                                                        <td>
                                                            <asp:Label ID="lblName" runat="server" ToolTip="Company name"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">JobNo </td>
                                                        <td>
                                                            <asp:TextBox ID="txtjobno" class="form-control" runat="server" onkeypress="return isNumberKey(event)" Width="180px" Height="30px"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                                ControlToValidate="txtjobno"
                                                                ValidationExpression="\d+" Text="*"
                                                                Display="Static" ForeColor="Red"
                                                                EnableClientScript="true" ValidationGroup="check"
                                                                ErrorMessage="Please enter numbers only"
                                                                runat="server" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required" ForeColor="Red" ControlToValidate="txtJobNo" ValidationGroup="check"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">電話番号(Phone Number)</td>
                                                        <td>
                                                            <asp:Label ID="lblPhoneNo" runat="server" ToolTip="Phone number"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblRecruitment" Visible="false" Text="人材紹介No.(Recruitment No.)"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblRecruitmentNo" Enabled="False" Visible="False"
                                                                ToolTip="Recruitment No."></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">所在地(Location)</td>
                                                        <td>
                                                            <asp:Label ID="lblLocation" runat="server" ToolTip="Location"
                                                                ViewStateMode="Enabled"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>担当者(Incharge Person)</td>
                                                        <td>
                                                            <asp:DropDownList CssClass="form-control" ID="ddlPersonInCharge" runat="server" Height="30px"
                                                                Width="70px" Style="display: inline;">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtPersonInCharge" CssClass="form-control" runat="server" MaxLength="50" Height="30px" Width="70px"
                                                                ToolTip="Person in charge" style="display: inline;margin-top:10px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="check"
                                                                ControlToValidate="txtPersonInCharge" ErrorMessage="Please Fill 担当者 !" Text="*"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                                            <asp:DropDownList CssClass="form-control" ID="ddlPersonInCharge1" runat="server" Height="30px"
                                                                Width="70px" Style="display: inline;">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtPersonInCharge1" CssClass="form-control" runat="server" MaxLength="50" Height="30px" Width="70px"
                                                                ToolTip="Person in charge" style="display: inline;margin-top:10px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="check"
                                                                ControlToValidate="txtPersonInCharge" ErrorMessage="Please Fill 担当者 !" Text="*"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>

                                                            <asp:DropDownList CssClass="form-control" ID="ddlPersonInCharge2" runat="server" Height="30px"
                                                                Width="70px" Style="display: inline;">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtPersonInCharge2" CssClass="form-control" runat="server" MaxLength="50" Height="30px" Width="70px"
                                                                ToolTip="Person in charge" style="display: inline;margin-top:10px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="check"
                                                                ControlToValidate="txtPersonInCharge" ErrorMessage="Please Fill 担当者 !" Text="*"
                                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="style3">部署(Department)</td>
                                                        <td>
                                                            <asp:TextBox ID="txtUnit" CssClass="form-control" runat="server" Width="350px" ToolTip="Unit" Height="30px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>担当者電話番号(Incharge Person Phone No.)</td>
                                                        <td>
                                                            <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server" Width="180px"
                                                                ToolTip="Personnel phone number" Height="30px"  onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="regPhone" runat="server"
                                                                ControlToValidate="txtPhoneNo" ForeColor="Red" Text="*" ErrorMessage="Invalid 電話番号 Eg.095118746"
                                                                ValidationExpression="([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$" ValidationGroup="check" />
                                                            
                                                            <asp:TextBox ID="txtPhoneNo1" CssClass="form-control" runat="server" Width="180px"
                                                                ToolTip="Personnel phone number" Height="30px"  onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ControlToValidate="txtPhoneNo1" ForeColor="Red" Text="*" ErrorMessage="Invalid 電話番号 Eg.095118746"
                                                                ValidationExpression="([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$" ValidationGroup="check" />
                                                            
                                                            <asp:TextBox ID="txtPhoneNo2" CssClass="form-control" runat="server" Width="180px"
                                                                ToolTip="Personnel phone number" Height="30px"  onkeypress="javascript:return isNumber(event)"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                                ControlToValidate="txtPhoneNo2" ForeColor="Red" Text="*" ErrorMessage="Invalid 電話番号 Eg.095118746"
                                                                ValidationExpression="([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$" ValidationGroup="check" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">担当者メールアドレス(Incharge Person Mail Address)</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="180px" Height="30px"
                                                                ToolTip="Email the consultant"></asp:TextBox>
                                                            
                                                            <asp:TextBox ID="txtEmail1" runat="server" CssClass="form-control" Width="180px" Height="30px"
                                                                ToolTip="Email1 the consultant" style="margin-left: 8px;"></asp:TextBox>
                                                            
                                                            <asp:TextBox ID="txtEmail2" runat="server" CssClass="form-control" Width="180px" Height="30px"
                                                                ToolTip="Email2 the consultant" style="margin-left: 8px;"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">担当者メールアドレス（確認用)(Incharge Person Mail Address Confirmation)</td>
                                                        <td>
                                                            <asp:TextBox ID="txtEmailConfirm" CssClass="form-control" runat="server" Width="180px"
                                                                ToolTip="Email the consultant (for confirmation)" Height="30px" onchange="checkEmail(this);"></asp:TextBox>
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="cusCustom_ServerValidate" ControlToValidate="txtEmailConfirm"
                                                                Text="*" ForeColor="Red" ValidationGroup="check" ErrorMessage="担当者メールアドレス And 担当者メールアドレス（確認用）must be same">
                                                            </asp:CustomValidator>

                                                            <asp:TextBox ID="txtEmailConfirm1" CssClass="form-control" runat="server" Width="180px"
                                                                ToolTip="Email1 the consultant (for confirmation)" Height="30px" onchange="checkEmail(this);"></asp:TextBox>
                                                            <asp:CustomValidator ID="CustomValidator4" runat="server" OnServerValidate="cusCustom_ServerValidate1" ControlToValidate="txtEmailConfirm1"
                                                                Text="*" ForeColor="Red" ValidationGroup="check" ErrorMessage="担当者メールアドレス And 担当者メールアドレス（確認用）must be same">
                                                            </asp:CustomValidator>
                                                            
                                                            <asp:TextBox ID="txtEmailConfirm2" CssClass="form-control" runat="server" Width="180px"
                                                                ToolTip="Email2 the consultant (for confirmation)" Height="30px" onchange="checkEmail(this);"></asp:TextBox>
                                                            <asp:CustomValidator ID="CustomValidator5" runat="server" OnServerValidate="cusCustom_ServerValidate2" ControlToValidate="txtEmailConfirm2"
                                                                Text="*" ForeColor="Red" ValidationGroup="check" ErrorMessage="担当者メールアドレス And 担当者メールアドレス（確認用）must be same">
                                                            </asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">業種(大分類)(Major Classification of Industry)</td>
                                                        <td>
                                                            <asp:Label ID="lblMajorDivision" runat="server"
                                                                ToolTip="Industry (major division)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">業種(小分類)(Small Classification of Industry)</td>
                                                        <td>
                                                            <asp:Label ID="lblMajorSmall" runat="server"
                                                                ToolTip="Industry (small classification)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>申込日(Submission Date)</td>
                                                        <td>
                                                            <%--<asp:UpdatePanel runat="server">
                                                                <ContentTemplate>--%>
                                                                 
                                                                    <div class="control-group" style="float:left">
                                                                        <div class="controls input-append date form_date" style="width:100px" data-date="" data-date-format="dd/MM/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                                        <asp:TextBox ID="txtSubDate" CssClass="form-control" runat="server" Width="180px" Height="30px"></asp:TextBox>
					                                                     <span class="add-on" style="float:left;margin-left:180px;margin-top:-30px;height:30px"><i class="icon-th"></i></span>
                                                                    </div>
                                                                </div>   
                                                                   
                                                               <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style3">職種(大分類)(Large Job Category)
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UPanelMajorIndustry" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMajorIndustry" CssClass="form-control" runat="server" AutoPostBack="True"
                                                                        OnSelectedIndexChanged="ddlMajorIndustry_SelectedIndexChanged" Width="350px" Height="30px" Style="display: inline;">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="check"
                                                                        ControlToValidate="ddlMajorIndustry" ErrorMessage="職種(大分類)" Text="*"
                                                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:Button runat="server" ID="btnRefresh" class="btn btn-primary" Text="Refresh" OnClick="btnRefresh_Click" />
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="ddlMajorIndustry" />
                                                                    <asp:PostBackTrigger ControlID="btnRefresh" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>職種(小分類)(Small Job Category)</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSmallIndustry" CssClass="form-control" runat="server" Width="350px" Height="30px">
                                                            </asp:DropDownList></td>
                                                    </tr>

                                                        <%--<td>

                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>

                                                                    
                                                                    <br />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>--%>
                                                        <%-- </tr>--%>
                                                        <tr>
                                                            <td class="style3">上記以外の職種(Other Industry)</td>
                                                            <td>
                                                                <asp:TextBox ID="txtOtherIndustry" CssClass="form-control" runat="server" Width="250px" Height="30px"
                                                                    ToolTip="Occupations other than the above"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">役職(Postion)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPost" CssClass="form-control" runat="server" Width="250px" Height="30px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">上記以外の役職(Other Position)</td>
                                                            <td class="style5">
                                                                <asp:TextBox ID="txtOtherPost" CssClass="form-control" runat="server" MaxLength="100" Width="250px" Height="30px"
                                                                    ToolTip="Officers other than the above"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">性別(Gender)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlGender" CssClass="form-control" Width="150" Height="30px" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">給料(Salary)</td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtSalaryFrom" runat="server" ValidationGroup="check"
                                                                    onkeypress="return isNumberKey(event)" Width="91px" Height="30px" MaxLength="9"
                                                                    ToolTip="Salary From" CssClass="search"></asp:TextBox>
                                                                &nbsp; ~&nbsp;
                                                         <asp:TextBox ID="txtSalaryTo" runat="server" ValidationGroup="check"
                                                             onkeypress="return isNumberKey(event)" Width="91px" MaxLength="9"
                                                             ToolTip="Salary To" CssClass="search" Height="30px"></asp:TextBox>
                                                                &nbsp;&nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlSalaryType" runat="server" ValidationGroup="check" Style="display: inline;" Width="100px" Height="30px" CssClass="form-control">
                                                            </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlSalaryFormat" runat="server" ValidationGroup="check" Style="display: inline;" width="100px" Height="30px" CssClass="form-control">
                                                                    <asp:ListItem Value="0">--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Up to</asp:ListItem>
                                                                    <asp:ListItem Value="2">Nego</asp:ListItem>
                                                                    <asp:ListItem Value="3">Max</asp:ListItem>
                                                                    <asp:ListItem Value="4">Min</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RegularExpressionValidator
                                                                    ID="RegularExpressionValidator3"
                                                                    runat="server"
                                                                    ValidationExpression="\d+"
                                                                    ControlToValidate="txtSalaryFrom"
                                                                    Text="*"
                                                                    ErrorMessage="You Must Only number in 給料"
                                                                    ValidationGroup="check"
                                                                    ForeColor="Red"></asp:RegularExpressionValidator>

                                                                <asp:RegularExpressionValidator
                                                                    ID="RegularExpressionValidator4"
                                                                    runat="server"
                                                                    ValidationExpression="\d+"
                                                                    ControlToValidate="txtSalaryTo"
                                                                    Text="*"
                                                                    ErrorMessage="You Must Only number in 給料"
                                                                    ValidationGroup="check"
                                                                    ForeColor="Red"></asp:RegularExpressionValidator>

                                                                <asp:CustomValidator ID="CustomValidator2" runat="server"
                                                                    OnServerValidate="cusCustom_ServerValidateSalary"
                                                                    ControlToValidate="txtSalaryTo"
                                                                    Text="*"
                                                                    ForeColor="Red"
                                                                    ValidationGroup="check"
                                                                    ErrorMessage="Invalid 給料">
                                                                </asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">上記以外の給料(Other Salary)</td>
                                                            <td>
                                                                <asp:TextBox ID="txtOtherSalary" runat="server" MaxLength="9" Width="250px" Height="30px"
                                                                    onkeypress="return isNumberKey(event)"
                                                                    ToolTip="Salary other than the above" CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">勤務地(Work Location)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlWorkingPlace" runat="server" CssClass="form-control" Width="250px" Height="30px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">上記以外の勤務地(Other Location)</td>
                                                            <td>
                                                                <asp:TextBox ID="txtOtherWorkingPlace" runat="server" MaxLength="100"
                                                                    Width="250px" ToolTip="Location other than the above" CssClass="form-control" Height="30px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">土曜日勤務(Saturday Work)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDayService" runat="server" CssClass="form-control" Width="200px" Height="30px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">始業時間(Working Start Hours)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlStartHours" CssClass="form-control" runat="server" Height="30px" Width="90px">
                                                                    <asp:ListItem>00:00</asp:ListItem>
                                                                    <asp:ListItem>00:30</asp:ListItem>
                                                                    <asp:ListItem>1:00</asp:ListItem>
                                                                    <asp:ListItem>1:30</asp:ListItem>
                                                                    <asp:ListItem>2:00</asp:ListItem>
                                                                    <asp:ListItem>2:30</asp:ListItem>
                                                                    <asp:ListItem>3:00</asp:ListItem>
                                                                    <asp:ListItem>3:30</asp:ListItem>
                                                                    <asp:ListItem>4:00</asp:ListItem>
                                                                    <asp:ListItem>4:30</asp:ListItem>
                                                                    <asp:ListItem>5:00</asp:ListItem>
                                                                    <asp:ListItem>5:30</asp:ListItem>
                                                                    <asp:ListItem>6:00</asp:ListItem>
                                                                    <asp:ListItem>6:30</asp:ListItem>
                                                                    <asp:ListItem>7:00</asp:ListItem>
                                                                    <asp:ListItem>7:30</asp:ListItem>
                                                                    <asp:ListItem>8:00</asp:ListItem>
                                                                    <asp:ListItem>8:30</asp:ListItem>
                                                                    <asp:ListItem>9:00</asp:ListItem>
                                                                    <asp:ListItem>9:30</asp:ListItem>
                                                                    <asp:ListItem>10:00</asp:ListItem>
                                                                    <asp:ListItem>10:30</asp:ListItem>
                                                                    <asp:ListItem>11:00</asp:ListItem>
                                                                    <asp:ListItem>11:30</asp:ListItem>
                                                                    <asp:ListItem>12:00</asp:ListItem>
                                                                    <asp:ListItem>12:30</asp:ListItem>
                                                                    <asp:ListItem>13:00</asp:ListItem>
                                                                    <asp:ListItem>13:30</asp:ListItem>
                                                                    <asp:ListItem>14:00</asp:ListItem>
                                                                    <asp:ListItem>14:30</asp:ListItem>
                                                                    <asp:ListItem>15:00</asp:ListItem>
                                                                    <asp:ListItem>15:30</asp:ListItem>
                                                                    <asp:ListItem>16:00</asp:ListItem>
                                                                    <asp:ListItem>16:30</asp:ListItem>
                                                                    <asp:ListItem>17:00</asp:ListItem>
                                                                    <asp:ListItem>17:30</asp:ListItem>
                                                                    <asp:ListItem>18:00</asp:ListItem>
                                                                    <asp:ListItem>18:30</asp:ListItem>
                                                                    <asp:ListItem>19:00</asp:ListItem>
                                                                    <asp:ListItem>19:30</asp:ListItem>
                                                                    <asp:ListItem>20:00</asp:ListItem>
                                                                    <asp:ListItem>20:30</asp:ListItem>
                                                                    <asp:ListItem>21:00</asp:ListItem>
                                                                    <asp:ListItem>21:30</asp:ListItem>
                                                                    <asp:ListItem>22:00</asp:ListItem>
                                                                    <asp:ListItem>22:30</asp:ListItem>
                                                                    <asp:ListItem>23:00</asp:ListItem>
                                                                    <asp:ListItem>23:30</asp:ListItem>
                                                                    <asp:ListItem></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">就業時間(Working End Hours)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCloseHours" CssClass="form-control" runat="server" Height="30px" Width="90px">
                                                                    <asp:ListItem>00:00</asp:ListItem>
                                                                    <asp:ListItem>00:30</asp:ListItem>
                                                                    <asp:ListItem>1:00</asp:ListItem>
                                                                    <asp:ListItem>1:30</asp:ListItem>
                                                                    <asp:ListItem>2:00</asp:ListItem>
                                                                    <asp:ListItem>2:30</asp:ListItem>
                                                                    <asp:ListItem>3:00</asp:ListItem>
                                                                    <asp:ListItem>3:30</asp:ListItem>
                                                                    <asp:ListItem>4:00</asp:ListItem>
                                                                    <asp:ListItem>4:30</asp:ListItem>
                                                                    <asp:ListItem>5:00</asp:ListItem>
                                                                    <asp:ListItem>5:30</asp:ListItem>
                                                                    <asp:ListItem>6:00</asp:ListItem>
                                                                    <asp:ListItem>6:30</asp:ListItem>
                                                                    <asp:ListItem>7:00</asp:ListItem>
                                                                    <asp:ListItem>7:30</asp:ListItem>
                                                                    <asp:ListItem>8:00</asp:ListItem>
                                                                    <asp:ListItem>8:30</asp:ListItem>
                                                                    <asp:ListItem>9:00</asp:ListItem>
                                                                    <asp:ListItem>9:30</asp:ListItem>
                                                                    <asp:ListItem>10:00</asp:ListItem>
                                                                    <asp:ListItem>10:30</asp:ListItem>
                                                                    <asp:ListItem>11:00</asp:ListItem>
                                                                    <asp:ListItem>11:30</asp:ListItem>
                                                                    <asp:ListItem>12:00</asp:ListItem>
                                                                    <asp:ListItem>12:30</asp:ListItem>
                                                                    <asp:ListItem>13:00</asp:ListItem>
                                                                    <asp:ListItem>13:30</asp:ListItem>
                                                                    <asp:ListItem>14:00</asp:ListItem>
                                                                    <asp:ListItem>14:30</asp:ListItem>
                                                                    <asp:ListItem>15:00</asp:ListItem>
                                                                    <asp:ListItem>15:30</asp:ListItem>
                                                                    <asp:ListItem>16:00</asp:ListItem>
                                                                    <asp:ListItem>16:30</asp:ListItem>
                                                                    <asp:ListItem>17:00</asp:ListItem>
                                                                    <asp:ListItem>17:30</asp:ListItem>
                                                                    <asp:ListItem>18:00</asp:ListItem>
                                                                    <asp:ListItem>18:30</asp:ListItem>
                                                                    <asp:ListItem>19:00</asp:ListItem>
                                                                    <asp:ListItem>19:30</asp:ListItem>
                                                                    <asp:ListItem>20:00</asp:ListItem>
                                                                    <asp:ListItem>20:30</asp:ListItem>
                                                                    <asp:ListItem>21:00</asp:ListItem>
                                                                    <asp:ListItem>21:30</asp:ListItem>
                                                                    <asp:ListItem>22:00</asp:ListItem>
                                                                    <asp:ListItem>22:30</asp:ListItem>
                                                                    <asp:ListItem>23:00</asp:ListItem>
                                                                    <asp:ListItem>23:30</asp:ListItem>
                                                                </asp:DropDownList>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">
                                                                <asp:DropDownList ID="ddlLanguage" CssClass="search" runat="server" Visible="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">
                                                                <asp:Label runat="server" Text="Language Ability" Font-Bold="true" Font-Underline="true" Font-Size="Small"></asp:Label> <%--語学能力--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">日本語(Japanese):</td>
                                                            <td>読み書き(Read and Write) &nbsp;
                                                            <asp:DropDownList ID="ddlJapaneselisting" CssClass="form-control" runat="server" Height="30px" Width="80px"></asp:DropDownList>
                                                                &nbsp;&nbsp; 会話(Speaking)&nbsp;
                                                        <asp:DropDownList ID="ddlJapansepeaking" CssClass="form-control" runat="server" Height="30px" Width="80px">
                                                        </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlJapaneselistingto" CssClass="form-control" runat="server" Height="16px" Width="50px" Visible="false"></asp:DropDownList>
                                                                <asp:DropDownList ID="ddlJapansepeakingto" CssClass="form-control" runat="server" Height="16px" Width="50px" Visible="false"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">英語(English):</td>
                                                            <td>読み書き(Read and Write) &nbsp;
                                                        <asp:DropDownList ID="ddlLanguageLevel1" runat="server" CssClass="form-control" Height="30px" Width="80px">
                                                        </asp:DropDownList>
                                                                &nbsp;&nbsp; 会話(Speaking)&nbsp;
                                                           <asp:DropDownList ID="ddlLanguageLevel2" runat="server" CssClass="form-control" Height="30px" Width="80px">
                                                           </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlenglishlistiningto" CssClass="form-control" runat="server" Height="30px"
                                                                    Width="50px" Visible="false">
                                                                </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlenglishspeakingto" CssClass="form-control" runat="server" Height="30px"
                                                                    Width="50px" Visible="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">ミャンマー語(Burmese):</td>
                                                            <td>読み書き(Read and Write) &nbsp;
                                                        <asp:DropDownList ID="ddlmyanmarlistening" CssClass="form-control" runat="server" Height="30px" Width="80px"></asp:DropDownList>
                                                                &nbsp;&nbsp; 会話(Speaking)&nbsp;
                                                        <asp:DropDownList ID="ddlmyanmarspeaking" CssClass="form-control" runat="server" Height="30px" Width="80px">
                                                        </asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmyanmarlisteningto" CssClass="form-control" runat="server" Height="30px" Width="50px" Visible="false"></asp:DropDownList>
                                                                <asp:DropDownList ID="ddlmyanmarspeakingto" CssClass="form-control" runat="server" Height="30px"
                                                                    Width="50px" Visible="false">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">年齢(Age From)</td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlAgeFrom" CssClass="form-control" runat="server" Height="30px" Width="80px">
                                                                    <asp:ListItem> -- </asp:ListItem>
                                                                    <asp:ListItem>17</asp:ListItem>
                                                                    <asp:ListItem>18</asp:ListItem>
                                                                    <asp:ListItem>19</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                    <asp:ListItem>21</asp:ListItem>
                                                                    <asp:ListItem>22</asp:ListItem>
                                                                    <asp:ListItem>23</asp:ListItem>
                                                                    <asp:ListItem>24</asp:ListItem>
                                                                    <asp:ListItem>25</asp:ListItem>
                                                                    <asp:ListItem>26</asp:ListItem>
                                                                    <asp:ListItem>27</asp:ListItem>
                                                                    <asp:ListItem>28</asp:ListItem>
                                                                    <asp:ListItem>29</asp:ListItem>
                                                                    <asp:ListItem>30</asp:ListItem>
                                                                    <asp:ListItem>31</asp:ListItem>
                                                                    <asp:ListItem>32</asp:ListItem>
                                                                    <asp:ListItem>33</asp:ListItem>
                                                                    <asp:ListItem>34</asp:ListItem>
                                                                    <asp:ListItem>35</asp:ListItem>
                                                                    <asp:ListItem>36</asp:ListItem>
                                                                    <asp:ListItem>37</asp:ListItem>
                                                                    <asp:ListItem>38</asp:ListItem>
                                                                    <asp:ListItem>39</asp:ListItem>
                                                                    <asp:ListItem>40</asp:ListItem>
                                                                    <asp:ListItem>41</asp:ListItem>
                                                                    <asp:ListItem>42</asp:ListItem>
                                                                    <asp:ListItem>43</asp:ListItem>
                                                                    <asp:ListItem>44</asp:ListItem>
                                                                    <asp:ListItem>45</asp:ListItem>
                                                                    <asp:ListItem>46</asp:ListItem>
                                                                    <asp:ListItem>47</asp:ListItem>
                                                                    <asp:ListItem>48</asp:ListItem>
                                                                    <asp:ListItem>49</asp:ListItem>
                                                                    <asp:ListItem>50</asp:ListItem>
                                                                    <asp:ListItem>51</asp:ListItem>
                                                                    <asp:ListItem>52</asp:ListItem>
                                                                    <asp:ListItem>53</asp:ListItem>
                                                                    <asp:ListItem>54</asp:ListItem>
                                                                    <asp:ListItem>55</asp:ListItem>
                                                                    <asp:ListItem>56</asp:ListItem>
                                                                    <asp:ListItem>57</asp:ListItem>
                                                                    <asp:ListItem>58</asp:ListItem>
                                                                    <asp:ListItem>59</asp:ListItem>
                                                                    <asp:ListItem>60</asp:ListItem>
                                                                    <asp:ListItem>61</asp:ListItem>
                                                                    <asp:ListItem>62</asp:ListItem>
                                                                    <asp:ListItem>63</asp:ListItem>
                                                                    <asp:ListItem>64</asp:ListItem>
                                                                    <asp:ListItem>65</asp:ListItem>
                                                                    <asp:ListItem>66</asp:ListItem>
                                                                    <asp:ListItem>67</asp:ListItem>
                                                                    <asp:ListItem>68</asp:ListItem>
                                                                    <asp:ListItem>69</asp:ListItem>
                                                                    <asp:ListItem>70</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <label>
                                                                    歳(Age To)　～
                                                                </label>
                                                                <asp:DropDownList ID="ddlAgeTo" CssClass="form-control" runat="server" Height="30px" Width="80px">
                                                                    <asp:ListItem> -- </asp:ListItem>
                                                                    <asp:ListItem>18</asp:ListItem>
                                                                    <asp:ListItem>19</asp:ListItem>
                                                                    <asp:ListItem>20</asp:ListItem>
                                                                    <asp:ListItem>21</asp:ListItem>
                                                                    <asp:ListItem>22</asp:ListItem>
                                                                    <asp:ListItem>23</asp:ListItem>
                                                                    <asp:ListItem>24</asp:ListItem>
                                                                    <asp:ListItem>25</asp:ListItem>
                                                                    <asp:ListItem>26</asp:ListItem>
                                                                    <asp:ListItem>27</asp:ListItem>
                                                                    <asp:ListItem>28</asp:ListItem>
                                                                    <asp:ListItem>29</asp:ListItem>
                                                                    <asp:ListItem>30</asp:ListItem>
                                                                    <asp:ListItem>31</asp:ListItem>
                                                                    <asp:ListItem>32</asp:ListItem>
                                                                    <asp:ListItem>33</asp:ListItem>
                                                                    <asp:ListItem>34</asp:ListItem>
                                                                    <asp:ListItem>35</asp:ListItem>
                                                                    <asp:ListItem>36</asp:ListItem>
                                                                    <asp:ListItem>37</asp:ListItem>
                                                                    <asp:ListItem>38</asp:ListItem>
                                                                    <asp:ListItem>39</asp:ListItem>
                                                                    <asp:ListItem>40</asp:ListItem>
                                                                    <asp:ListItem>41</asp:ListItem>
                                                                    <asp:ListItem>42</asp:ListItem>
                                                                    <asp:ListItem>43</asp:ListItem>
                                                                    <asp:ListItem>44</asp:ListItem>
                                                                    <asp:ListItem>45</asp:ListItem>
                                                                    <asp:ListItem>46</asp:ListItem>
                                                                    <asp:ListItem>47</asp:ListItem>
                                                                    <asp:ListItem>48</asp:ListItem>
                                                                    <asp:ListItem>49</asp:ListItem>
                                                                    <asp:ListItem>50</asp:ListItem>
                                                                    <asp:ListItem>51</asp:ListItem>
                                                                    <asp:ListItem>52</asp:ListItem>
                                                                    <asp:ListItem>53</asp:ListItem>
                                                                    <asp:ListItem>54</asp:ListItem>
                                                                    <asp:ListItem>55</asp:ListItem>
                                                                    <asp:ListItem>56</asp:ListItem>
                                                                    <asp:ListItem>57</asp:ListItem>
                                                                    <asp:ListItem>58</asp:ListItem>
                                                                    <asp:ListItem>59</asp:ListItem>
                                                                    <asp:ListItem>60</asp:ListItem>
                                                                    <asp:ListItem>61</asp:ListItem>
                                                                    <asp:ListItem>62</asp:ListItem>
                                                                    <asp:ListItem>63</asp:ListItem>
                                                                    <asp:ListItem>64</asp:ListItem>
                                                                    <asp:ListItem>65</asp:ListItem>
                                                                    <asp:ListItem>66</asp:ListItem>
                                                                    <asp:ListItem>67</asp:ListItem>
                                                                    <asp:ListItem>68</asp:ListItem>
                                                                    <asp:ListItem>69</asp:ListItem>
                                                                    <asp:ListItem>70</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <label>
                                                                    歳
                                                                </label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">Entering Day
                                                            </td>
                                                            <td>
                                                                <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server" style="display: inline; width: 400px;">
                                                                    <ContentTemplate>
                                                                       --%>

                                                                        <div class="control-group" style="float:left">
                                                                    <div class="controls input-append date form-date-time" style="width:100px" data-date="" data-date-format="dd/mm/yyyy" data-link-field="'dtp_input2" data-link-format="yyyy-mm-dd">
                                                                        <asp:TextBox ID="txtEnterDate" CssClass="form-control" runat="server" Width="180px" Height="30px" Style="display: inline;"></asp:TextBox>
                                                                        <span class="add-on" style="float:left;margin-left:180px;margin-top:-30px;height:30px"><i class="icon-th"></i></span>
                                                                    </div><div style="float:left;margin-top:-30px;margin-left:250px">  (or)    ASAP<asp:CheckBox ID="chkASAP1" runat="server" /></div>
                                                                </div>
                                                                    <%--</ContentTemplate>
                                                                </asp:UpdatePanel>--%>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td class="style3">面接の日(Interview Day)
                                                            </td>
                                                            <td>
                                                                <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server" style="display: inline; width: 400px;">
                                                                    <ContentTemplate>--%>
                                                                        <%--<asp:TextBox ID="txtInterviewDay" CssClass="search" runat="server" ReadOnly="True" Width="180px" Height="30px"></asp:TextBox>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton3" runat="server"
                                                                            Width="180px" Height="30px"
                                                                            ImageUrl="~/Styles/clear.png" OnClick="ImageButton3_Click" />
                                                                        (or)    ASAP<asp:CheckBox ID="chkASAP2" runat="server" />--%>

                                                                        <%--<div class="form-group">
                                                                            <div class='input-group date' id='Div_interviewDay' style="width: 300px;">
                                                                                <asp:TextBox ID="txtInterviewDay" CssClass="form-control" runat="server" Width="180px" Height="30px" Style="display: inline;"></asp:TextBox>
                                                                                <span class="input-group-addon" style="width: 40px; height: 30px; float: left;">
                                                                                    <span class="glyphicon glyphicon-calendar"></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(or) ASAP<asp:CheckBox ID="chkASAP2" runat="server" />
                                                                                </span>
                                                                              
                                                                            </div>
                                                                        </div>
                                                                        <asp:ImageButton ID="ImageButton3" class="calendar" runat="server"
                                                                            Width="16px" Height="19px"
                                                                            ImageUrl="~/img/clear.png" OnClick="ImageButton3_Click" Visible="false" />--%>
                                                                        <div class="control-group">
                                                                    <div class="controls input-append date form-date-time-date" style="width:100px" data-date="" data-date-format="dd/MM/yyyy" data-link-field="'dtp_input2" data-link-format="yyyy-mm-dd">
                                                                        <asp:TextBox ID="txtInterviewDay" CssClass="form-control" runat="server" Width="180px" Height="30px" Style="display: inline;"></asp:TextBox>
                                                                        <span class="add-on" style="float:left;margin-left:180px;margin-top:-30px;height:30px"><i class="icon-th"></i></span>
                                                                    </div><div style="float:left;margin-top:-30px;margin-left:250px">  (or) ASAP<asp:CheckBox ID="chkASAP2" runat="server" /></div>
                                                                </div> 

                                                                   <%-- </ContentTemplate>
                                                                </asp:UpdatePanel>--%>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style3">備考(Remarks)</td>
                                                            <td>
                                                                <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Height="180px" MaxLength="400"
                                                                    TextMode="MultiLine" Width="585px" ToolTip="Remarks"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator3" runat="server"
                                                                    OnServerValidate="cusCustom_ServerValidateRemark"
                                                                    ControlToValidate="txtRemarks"
                                                                    Text="*"
                                                                    ForeColor="Red"
                                                                    ValidationGroup="check"
                                                                    ErrorMessage="備考 allow only 400 characters.Your comment is more than maximum length.">
                                                                </asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style4">募集中(During Recruitment)</td>
                                                            <td>
                                                                <asp:CheckBox ID="chkWanted" runat="server" ToolTip="Wanted" Width="50px" Height="50px" />
                                                            </td>
                                                        </tr>
                                                </table>
                                            <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                        <center>
                                        <asp:Button ID="btnNew" runat="server" Text="登録 (New)" onclick="btnNew_Click" Visible="False"/>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnDelete" class="btn btn-danger" runat="server" OnClick="btnDelete_Click" Text="Delete" 
                                          Width="200px" 
                                          OnClientClick="return confirm('Are you sure you want to delete?');" 
                                          Visible="False"/> <%--削除する--%>
                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                          <asp:Button ID="btnSave_Update" runat="server" class="btn btn-primary" onclick="btnSave_Update_Click" Width="200px" Text="Register" ValidationGroup="check"/> <%--登録する--%>
                                     </center>
                                    </fieldset>
                                </div>

                                <br />
                                <asp:GridView ID="dgvClientRecruitment" runat="server" CellPadding="4" ForeColor="#333333"
                                    GridLines="None" HeaderStyle-Wrap="false"
                                    ShowFooter="True"
                                    OnRowDataBound="dgvClientRecruitment_RowDataBound"
                                    Width="155px" OnRowCommand="dgvClientRecruitment_RowCommand"
                                    AutoGenerateColumns="False" Visible="False" class="table">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server"
                                                    CommandName="DataEdit"
                                                    CommandArgument='<%# Eval("ID") %>' class="btn btn-primary">編集(Edit)</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Linkbutton1" class="btn btn-primary" runat="server"
                                                    CommandName="DataDelete" OnClientClick="return Confirm() "
                                                    CommandArgument='<%# Eval("ID") %>'>削除(Delete)</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                        <asp:BoundField DataField="Client_ID" HeaderText="Client_ID"
                                            SortExpression="Client_ID" />
                                        <asp:BoundField DataField="DivitionOrDepartment"
                                            HeaderText="職種(大分類)(Major Industry)" SortExpression="DivitionOrDepartment" />
                                        <asp:BoundField DataField="Position" HeaderText="職種(小分類)(Secondary Industry)"
                                            SortExpression="Position" />
                                        <asp:BoundField DataField="Post" HeaderText="(役職)Position"
                                            SortExpression="Post" />
                                        <asp:BoundField DataField="Gender" HeaderText="性別(GENDER)"
                                            SortExpression="Gender" />
                                        <asp:CheckBoxField DataField="Wanted" HeaderText="Wanted"
                                            SortExpression="Wanted" />
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                                <br />
                                <asp:HiddenField ID="hfMode" runat="server" />
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

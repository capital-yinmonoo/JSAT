<%@ Page Title="CV送付履歴一括編集" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Job_Career_Interview.aspx.cs" Inherits="JSAT_Ver1.Employer.Job_Career_Interview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../date/bootstrap.min.css" rel="stylesheet" />
    <link href="../date/bootstrap-datetimepicker.min.css" rel="stylesheet" />
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
            window.open('../Search_Dialog.aspx?Type=2', window, params);
            //window.open('../Search_Dialog.aspx?Type=2', window, 'dialogHeight:750px; dialogWidth:750px; dialogLeft:300px; dialogRight :750px; dialogTop:750px; help:no; unadorned:no; resizable:no; status:no; scroll:yes; minimize:no; maximize:yes;modal=yes;center=yes;');
            
        }

        function updateValue(value) {
            // this gets called from the popup window and updates the field with a new value
            var Name = '<%= txtName.ClientID %>';
            document.getElementById(Name).value = value;
            __doPostBack('<%= imgSearch.ClientID  %>', '');
        }
    </script>
    <script type="text/javascript">
        function NotType(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode != 8)
                return true;
            return false;
        }
    </script>
    <style type="text/css">
        .style2
        {
            width: 763px;
        }
    </style>
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
                            CV送付履歴一括編集(CV Sending History Collective Editing)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <fieldset>
                                    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
                                    <table>
                                        <tr>
                                            <td  class="style2">
                                                <asp:Label ID="lblUpdater" runat="server" Text="更新者ID：" Visible="false"></asp:Label>
                                                &nbsp
                                            <asp:Label runat="server" ID="lblUpdaterData" Visible="false"></asp:Label>
                                                &nbsp
                                            <asp:Label ID="lblUpdateTime" runat="server" Text="更新日：" Visible="false"></asp:Label>
                                                &nbsp
                                            <asp:Label runat="server" ID="lblUpdateTimeData" Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="table" style="width:1100px;">
                                        <tr>
                                            <td class="style3">
                                                <asp:Label runat="server" Text="クライアントNo.(Client_No.)" Width="300px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblClientNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text="人材紹介No.(Recruitment_No.)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblRecruitmentNo"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text="会社名(Company Name)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCompany"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text="電話番号(Phone Number)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblProfileTelephone" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text="所在地(Location)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblLocation" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text="業種（大分類）(Major Classification of Industry)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblIndustry" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label7" runat="server" Text="業種（小分類）(Small Classification of Industry)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblTypeOfBusiness"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label8" Text="申込日(Application Date)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSubmittedDate"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label9" Text="職種(大分類)(Major Classification of Job Category)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPosition"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label10" Text="職種(小分類)(Small Classification of Job Category)  "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDepartment"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label11" Text="役職(Position)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPost"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label12" Text="上記以外の役職(Other Position)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblOtherPosition"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label13" Text="性別(Gender)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblGender"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label14" Text="給料(Salary)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblSalary"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label15" Text="上記以外の給料(Other Salary)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblOtherSalary"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label16" Text="勤務地(Work Location)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblWorkingPlace"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label17" Text="上記以外の勤務地(Other Work Location)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblOtherWorkingPlace"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label18" Text="土曜日勤務(Working On Saturday)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDayService"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label19" Text="始業時間(Start Time)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblStarting"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label20" Text="終業時間(Closing Time)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblClosing"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label21" Text="言語(Language)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblLanguage"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label22" Text="言語レベル(Language Level)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblLanguageLevel"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label23" Text="年齢(Age)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAge"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label24" Text="担当者(Person In Charge)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPersonInCharge"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label25" Text="部署(Department)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblUnit"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label26" Text="担当者電話番号(Person In Charge Phone No.)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblRecruitmentTelephone"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label27" Text="担当者メールアドレス(Person In Charge E-mail Address)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label28" Text="備考(Remarks)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblRemarks"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="Label29" Text="募集中(Wanted)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblWanted"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <b>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <asp:Label runat="server" ID="Label30" Text="CV送付履歴(CV Sending History)"></asp:Label>
                                    </b>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                    HeaderText="You must enter a value in the following fields:"
                                                    EnableClientScript="true"
                                                    ForeColor="Red"
                                                    ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td style="width: 120px;">
                                                <asp:Label ID="lblNew" runat="server" Text="登録番号" Style="display: inline;"></asp:Label></td>
                                            <td style="width: 170px;">
                                                <asp:Label ID="lblName" runat="server" Text="名前" Style="display: inline;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInterview" runat="server" Text="書類選考" Width="130px" Style="display: inline;"></asp:Label>
                                            </td>
                                            <td style="width:215px;">
                                                <asp:Label ID="lblIntdate" runat="server" Text="面接日" Width="130px" Style="display: inline;"></asp:Label>
                                            </td>
                                            <td style="width:75px;" >
                                                <asp:Label ID="lblresult" runat="server" Text="	合否結果" Width="80px" Style="display: inline;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblresultdate" runat="server" Text="採用決定日" Width="130px" Style="display: inline;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Salary" runat="server" Text="給料" Style="display: inline;"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblsalarytype" runat="server" Style="display: inline;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="width: 150px;">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox runat="server" ID="txtCareerCode" ReadOnly="true" CssClass="form-control" Style="display: inline; flex-align: center;" Width="90px" Height="30px"></asp:TextBox>
                                                        <asp:ImageButton ID="imgSearch" runat="server" Height="28px"
                                                            Width="28px" ImageUrl="~/img/search.png" OnClientClick="ShowDialog()" />
                                                        <asp:TextBox runat="server" ID="txtCareerName" Style="display: inline;" ReadOnly="true"
                                                            Width="150px" CssClass="form-control" Height="30px"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td style="width:80px;">
                                                 <div class="control-group" style="float:left">
                                                <asp:DropDownList runat="server" ID="ddlInterview" Style="display:inline;" CssClass="form-control" Width="60px" Height="30px">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="1">○</asp:ListItem>
                                                    <asp:ListItem Value="2">×</asp:ListItem>
                                                </asp:DropDownList>
                                                     </div>
                                            </td>
                                            <td style="width: 210px;">                                               
                                                        <div class="control-group" style="float:left">
                                                                        <div class="controls input-append date form_date" style="width:100px" data-date="" data-date-format="dd/MM/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                                        <asp:TextBox ID="txtInterviewDate" CssClass="form-control" runat="server" Width="180px" Height="30px" ReadOnly="true"></asp:TextBox>
					                                                     <span class="add-on" style="float:left;margin-left:180px;margin-top:-30px;height:30px"><i class="icon-th"></i></span>
                                                                    </div>
                                                                </div> 
                                                        <asp:ImageButton ID="ImageButton1" class="calendar" runat="server"
                                                            Width="16px" Height="19px"
                                                            ImageUrl="~/img/clear.png" OnClick="ImageButton1_Click1" Visible="false" />                                                    
                                            </td>
                                            <td>
                                                 <div class="control-group" style="float:left">
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlIntresult" Width="60px" Height="30px" Style="display: inline;">
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="1">○</asp:ListItem>
                                                    <asp:ListItem Value="2">×</asp:ListItem>
                                                </asp:DropDownList>
                                                     </div>
                                            </td>
                                            <td style="width: 210px;">
                                                        <div class="control-group" style="float:left">
                                                                        <div class="controls input-append date form_date" style="width:100px" data-date="" data-date-format="dd/MM/yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                                        <asp:TextBox ID="txtInterviewResultDate" CssClass="form-control" runat="server" Width="180px" Height="30px" ReadOnly="true"></asp:TextBox>
					                                                     <span class="add-on" style="float:left;margin-left:180px;margin-top:-30px;height:30px"><i class="icon-th"></i></span>
                                                                    </div>
                                                                </div> 
                                                        <asp:ImageButton ID="ImageButton2" class="calendar" runat="server"
                                                            Width="16px" Height="19px"
                                                            ImageUrl="~/img/clear.png" OnClick="ImageButton2_Click" Visible="false" />
                                                    
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtsalary" CssClass="form-control" runat="server" Width="90px" Height="30px"></asp:TextBox>
                                            </td>
                                            <td>
                                                 <div class="control-group" style="float:left">
                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlsalarytype" Width="90px" Height="30px"></asp:DropDownList>
                                            </div>
                                                     </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td align="right" colspan="4">
                                                <br />
                                                <asp:Button runat="server" class="btn btn-primary" ID="btnSave" Text="Register" OnClick="btnSave_Click" Width="200px" style="background-image: linear-gradient(to bottom, rgb(0, 136, 204), rgb(0, 122, 255));"/>   <%--登録する--%>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="search" runat="server" ID="txtName" Height="0px" Width="0px"></asp:TextBox>
                                                <asp:TextBox CssClass="search" runat="server" ID="txtID" Height="0px" Width="0px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <div>
                                        <asp:GridView ID="gvJobCareerInterview1" runat="server" CellPadding="4" ForeColor="#333333"
                                            GridLines="None" DataKeyNames="ID" AllowPaging="True" ShowFooter="False" AutoGenerateColumns="False"
                                            OnPageIndexChanging="OnPaging" OnRowEditing="EditJobCareer" EmptyDataText="There is no data to display"
                                            OnRowUpdating="UpdateJobCareer" OnRowCancelingEdit="CancelEdit" OnRowDataBound="OnRowDataBound"
                                            Width="100%" ShowHeaderWhenEmpty="True" class="table">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                            <PagerSettings Mode="NumericFirstLast" NextPageText="Next" FirstPageText="First" LastPageText="Last" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Registration_Number" HeaderStyle-ForeColor="White">  <%--登録番号--%>
                                                    <FooterStyle HorizontalAlign="Center" Width="200px" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="CarrerCode" Text='<%#Eval("Career_Code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name" HeaderStyle-ForeColor="White"> <%--名前--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCareerName" runat="server" Text='<%#Eval("Career_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Document_Selection" HeaderStyle-ForeColor="White">   <%--書類選考--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label31" runat="server" Text='<%#Eval("InterviewString") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlInterviewEdit" Width="60px" Height="35px">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Value="1">○</asp:ListItem>
                                                            <asp:ListItem Value="2">×</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Interview_Date" HeaderStyle-ForeColor="White">   <%--面接日--%>
                                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInterview_Date" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Interview_Date", "{0:d / MMM / yyyy }") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%--<input type="text" id="dtpInterviewDateEdit" name="dtpInterviewDateEdit" readonly="readonly" value="<%= this.dtpInterviewDateEdit %>" runat="server" />--%>
                                                        <asp:TextBox ID="dtpInterviewDateEdit" runat="server" ReadOnly="true" Text='<%#  DataBinder.Eval(Container.DataItem, "Interview_Date", "{0:d / MMM / yyyy }")  %>' Height="35px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="	Interview_Result" HeaderStyle-ForeColor="White">    <%--合否結果--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblInterview_Result" runat="server" Text='<%#Eval("InterviewResultString") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" CssClass="search" ID="ddlInterview_ResultEdit" Width="60px" Height="35px">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Value="1">○</asp:ListItem>
                                                            <asp:ListItem Value="2">×</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Interview_Result_Date" HeaderStyle-ForeColor="White">    <%--採用決定日--%>
                                                    <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    <FooterStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblInterview_Result_Date" Text='<%# DataBinder.Eval(Container.DataItem, "Interview_Result_Date", "{0:d / MMM / yyyy }") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <%--<input type="text" id="dtpInterviewResultDateEdit" name="dtpInterviewResultDateEdit" readonly="readonly" value="<%= this.dtpInterviewResultDateEdit %>" runat="server" />--%>
                                                        <asp:TextBox ID="dtpInterviewResultDateEdit" runat="server" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "Interview_Result_Date", "{0:d / MMM / yyyy }") %>' Height="35px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Salary" HeaderStyle-ForeColor="White">   <%--給料--%>
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label32" runat="server" Text='<%#Eval("Salary") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox runat="server" ID="txtSalaryEdit" MaxLength="9" Width="100px" Height="35px"></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-ForeColor="White">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbISalaryType" runat="server" Text='<%#Eval("Salary_Type") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlSalaryTypeEdit" Width="60px" Height="35px"></asp:DropDownList>

                                                    </EditItemTemplate>
                                                </asp:TemplateField>

                                                <asp:CommandField ShowEditButton="true" />
                                            </Columns>
                                            <EditRowStyle BackColor="#999999" />

                                            <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />

                                        </asp:GridView>
                                    </div>
                                    <asp:HiddenField ID="hfInterviewDate" runat="server" />
                                    <asp:HiddenField ID="hfInterviewResultDate" runat="server" />

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

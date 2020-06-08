<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Career_Resume.aspx.cs" Inherits="JSAT_Ver1.Employee.Career_Resume" %>
<%@ Register Src="../Usercontrol/Career_InterviewControl.ascx" TagName="Career_InterviewControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">   
    <title></title>
    <link href="../date/bootstrap.min.css" rel="stylesheet" />
    <link href="../date/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('.imgCls').click(function () {
                return true;
            });
        });
    </script>
    <script type="text/javascript">
        function SelectAll(ID) {
            var chk = document.getElementById(ID);
            var chks = document.form1.elements;
            for (i = 0; i < chks.length; i++) {
                var type = chks[i].type;
                if (type == "checkbox")
                    if (chk.checked) {
                        chks[i].checked = true;
                    }
                    else chks[i].checked = false;
            }
        }
    </script>
    <script type="text/javascript">
        function change(ctrl, e) {
            var hfvalue = document.getElementById("<%=hfcontrolforchrome.ClientID%>").value;
            if (hfvalue != "1") {
                var objval = ctrl.value;
                var objvalue = ctrl.id;
                var iKeyCode = 0;
                if (window.event) iKeyCode = window.event.keyCode
                else if (e) iKeyCode = e.which;
                if (typeof (iKeyCode) == "undefined") {
                    document.getElementById("<%=hfControl.ClientID%>").value = objvalue;
                    __doPostBack('', '');
                }
                document.getElementById("<%=hfcontrolforchrome.ClientID%>").value = "";
            }
        }
        function trapReturn(ctrl, e) {
            if (e.shiftKey && e.keyCode == 9) {
                //shift was down when tab was pressed
            }
            else {
                document.getElementById("<%=hfcontrolforchrome.ClientID%>").value = "1";
                var objval = ctrl.value;
                var objvalue = ctrl.id;
                var iKeyCode = 0;
                if (window.event) iKeyCode = window.event.keyCode
                else if (e) iKeyCode = e.which;
                if (iKeyCode == 9) {
                    {
                        document.getElementById("<%=hfControl.ClientID%>").value = objvalue;
                    __doPostBack('', '');
                }
                return true;
            }
            return;
        }
    }
    </script>
    <script type="text/javascript">
        function CheckBoxCheck(rb) {
            debugger;
            var gv = document.getElementById("<%=gvsalary.ClientID%>");
            var chk = gv.getElementsByTagName("input");
            var row = rb.parentNode.parentNode;
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].type == "checkbox") {
                    if (chk[i].checked && chk[i] != rb) {
                        chk[i].checked = false;
                        break;
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8)
                return true;
            else return false;
        }
    </script>
    <script type="text/javascript">
        function NotType(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode == 8)
                return true;
            return false;
        }
    </script>
    <script type="text/javascript">
        function MutExChkList(chk) {
            var chkList = chk.parentNode.parentNode.parentNode;
            var chks = chkList.getElementsByTagName("input");
            for (var i = 0; i < chks.length; i++) {
                if (chks[i] != chk && chk.checked) {
                    chks[i].checked = false;
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <section id="main-content">
          <section class="wrapper">
            <div class="row" style="height:50px;">
            <div class="col-lg-12">
                <h1 class="page-header">Employee</h1>
            </div><!-- /.col-lg-12 -->
      </div>
            <!-- /.row -->
            <div class="row" style="height: 50px;">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            人材基本情報(INFORMATION OF CANDIDATE)
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                         <asp:HiddenField ID="hfcontrolforchrome" runat="server" />
                         <asp:HiddenField ID="hfControl" runat="server" />
                         <asp:HiddenField ID="hfShift" runat="server" />
                             <div style="text-align: right;">
                                 <asp:Label runat="server" ID="lblID" Text=" 更新者ID:" Visible="False"></asp:Label>
                                 <asp:Label runat="server" ID="lblUpdatedBy" Visible="False"></asp:Label>
                                 <asp:Label runat="server" ID="lbldate" Text="更新日：" Visible="False"></asp:Label>
                                 <asp:Label runat="server" ID="lblUpdatedDate" Visible="False"></asp:Label>
                             </div>
                             <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"></asp:ScriptManager>
                             <table>
                                 <tr>
                                     <td colspan="2">
                                         <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="You must enter a value in the following fields:" EnableClientScript="true" ForeColor="Red"
                                             ValidationGroup="check" ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" />
                                         <asp:HiddenField ID="HiddenField1" runat="server" />
                                         <asp:HiddenField ID="HiddenField2" runat="server" />
                                         <br />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="vertical-align: top">
                                         <br/>
                                         <uc1:Career_InterviewControl ID="Career_InterviewControl2" runat="server" Visible="False" />
                                     </td>
                                 </tr>
                             </table>
                             <table>
                                 <tr>
                                     <td>登録形態(Type)</td>
                                     <td> <asp:CheckBox ID="chkdomestic" runat="server" Text="国内(Domestic)" /></td>
                                     <td> <asp:CheckBox ID="chkoversea" runat="server" Text="海外(Oversea)"/></td>
                                 </tr>
                                 <tr>
                                     <td style="width:325px;">登録番号(No.)</td>
                                     <td>
                                         <asp:DropDownList ID="ddlCode" runat="server" Width="70px" Height="30px" CssClass="form-control" >
                                             <asp:ListItem></asp:ListItem>
                                             <asp:ListItem>AC</asp:ListItem>
                                             <asp:ListItem>EN</asp:ListItem>
                                             <asp:ListItem>GN</asp:ListItem>
                                             <asp:ListItem>IT</asp:ListItem>
                                             <asp:ListItem>JP</asp:ListItem>
                                            <%-- <asp:ListItem>SL</asp:ListItem>--%>
                                             <asp:ListItem>JPN</asp:ListItem>
                                             <%--<asp:ListItem>CAD</asp:ListItem>--%>
                                             <asp:ListItem>Y</asp:ListItem>
                                             <asp:ListItem>C</asp:ListItem>
                                         </asp:DropDownList>
                                         -  
	                     				 <asp:TextBox ID="txtCode" style="margin-top:10px" CssClass="form-control" Height="30px" runat="server" MaxLength="7" Width="100px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" ErrorMessage="登録番号(No.)" Text="*" ValidationGroup="check" ForeColor="Red"></asp:RequiredFieldValidator>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtCode" ValidationExpression="\d+"
                                             Display="Static" ForeColor="Red" EnableClientScript="true" ValidationGroup="check" Text="*" ErrorMessage="Please enter numbers only" runat="server" />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>性別(Gender):</td>
                                     <td>
                                         <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" Width="125px" Height="30px">
                                             <asp:ListItem></asp:ListItem>
                                             <asp:ListItem Value="1">男(Male)</asp:ListItem>
                                             <asp:ListItem Value="2">女(Female)</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>名前(Name):</td>
                                     <td>
                                         <asp:TextBox ID="txtName" runat="server" MaxLength="50" Width="200px" CssClass="form-control" Height="30px"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="名前(Name):" Text="*" ValidationGroup="check" ForeColor="Red"></asp:RequiredFieldValidator>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>年齢(Age):</td>
                                     <td>
                                          <asp:TextBox ID="txtAge" runat="server" MaxLength="50" Width="200px" CssClass="form-control" Height="30px"></asp:TextBox>
                                     </td>
                                 </tr>
                                 </table>
                                <table>
                                 <tr>
                                     <td style="width:325px;">生年月日(DATE OF BIRTH):</td>
                                     <td>                                         
                                        <div class="control-group" style="float:left;">
                                            <div class="controls input-append date form-date-time" data-date="" data-date-format="dd/MM/yyyy" data-link-field="'dtp_input1" data-link-format="yyyy-mm-dd">
                                                 <asp:TextBox runat="server" ID="txtDateofBirth" CssClass="form-control" Width="150px" Height="30px" ReadOnly="True"></asp:TextBox>
                                                 <span class="add-on" style="margin-top:11px;position:absolute;height:30px;"><i class="icon-th"></i></span>
                                            </div>  
                                       </div>
                                     </td>
                                 </tr>
                                </table>
                                <table>
                                 <tr>
                                     <td style="width:325px;">宗教(RELIGION):</td>
                                     <td>
                                         <asp:DropDownList ID="ddlReligion" runat="server" Width="150px" CssClass="form-control" Height="30px">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>現住所(ADDRESS):</td>
                                     <td>
                                         <asp:DropDownList ID="ddlAddress" runat="server" Width="250px" CssClass="form-control" Height="30px">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>電話番号1(PHONE NO_1)</td>
                                     <td>
                                         <asp:TextBox ID="txtph1" runat="server" Width="150px" CssClass="form-control" Height="30px" ToolTip="Telephone number 1 "></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>電話番号2(PHONE NO_2)</td>
                                     <td>
                                         <asp:TextBox ID="txtph2" runat="server" Width="150px" CssClass="form-control" Height="30px" ToolTip="Telephone number 2"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>メールアドレス(EMAIL)</td>
                                     <td>
                                         <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" Height="30px" Width="200px" ToolTip="E-mail address "></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>緊急連絡番号(EMERGENCY PHONE NUMBER) </td>
                                     <td>
                                         <asp:TextBox ID="txtemph" runat="server" CssClass="form-control" Height="30px" Width="150px" ToolTip="Emergency contact number 	"></asp:TextBox></td>
                                 </tr>
                                 <tr>
                                     <td>緊急連絡名(EMERGENCY CONTACT NAME)</td>
                                     <td>
                                         <asp:TextBox ID="txtemperson" runat="server" CssClass="form-control" Height="30px" Width="150px" ToolTip="Emergency contact name"></asp:TextBox></td>
                                 </tr>
                             </table>
                             <table>
                                <tr><td><asp:Button ID="addnew" CssClass="btn btn-primary" runat="server" Text="Add New Salary" OnClick="addnew_Click" style="background-image: linear-gradient(to bottom, rgb(0, 136, 204), rgb(0, 122, 255));"/></td></tr>
                             </table>
                             <asp:UpdatePanel ID="eerer" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                                 <asp:GridView ID="gvsalary" runat="server" AutoGenerateColumns="false" GridLines="None" OnRowDataBound="gvsalary_RowDataBound">
                                                     <Columns>
                                                         <asp:TemplateField>
                                                             <HeaderStyle HorizontalAlign="center" VerticalAlign="Top" />
                                                             <HeaderTemplate>
                                                                 <asp:LinkButton ID="LinkButton1" Visible="false" CssClass="btn btn-danger" runat="server" OnClick="Remove_Click">Remove</asp:LinkButton>
                                                             </HeaderTemplate>
                                                             <ItemTemplate>
                                                             <table>
                                                                 <tr>
                                                                     <td style="width:325px;">
                                                                         <asp:Label ID="lblsalary1" runat="server" Text="希望給与(EXPECTED SALARY):"></asp:Label>
                                                                     </td>
                                                                     <td>
                                                                         <asp:TextBox ID="txtExpSalary1" Width="150px"  style="margin-top:10px" CssClass="form-control" Height="30px" runat="server" onkeypress="return isNumberKey(event)" MaxLength="9"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidatorgv" ControlToValidate="txtExpSalary1" ValidationExpression="\d+" Text="*" Display="Static" ForeColor="Red" EnableClientScript="true" ValidationGroup="check" ErrorMessage="Please enter numbers only" runat="server" />
                                                                         <asp:DropDownList ID="ddlsalarytype1" runat="server" Width="70px" CssClass="form-control" Height="30px"></asp:DropDownList>
                                                                         <asp:DropDownList ID="ddlsalaryformat" runat="server" Width="80px" CssClass="form-control" Height="30px">
                                                                              <asp:ListItem Value="0">--</asp:ListItem>
                                                                              <asp:ListItem Value="1">Up to</asp:ListItem>
                                                                              <asp:ListItem Value="2">Nego</asp:ListItem>
                                                                              <asp:ListItem Value="3">Max</asp:ListItem>
                                                                              <asp:ListItem Value="4">Min</asp:ListItem>
                                                                         </asp:DropDownList>        
                                                                         <asp:CheckBox ID="chkselectsalary" runat="server" onclick="CheckBoxCheck(this);" />
                                                                     </td>
                                                                 </tr>
                                                             </table>
                                                                 </ItemTemplate>
                                                         </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
        <table>
            <tr>
                <td style="width:325px;">希望勤務地(WORKABLE AREA):</td>
                <td>
                    <asp:CheckBoxList ID="chkWorkableArea" runat="server" Width="500px" RepeatColumns="4" RepeatDirection="Vertical">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>希望職種1(POSITION REQUESTED)</td>
            </tr>
            <tr>
                <td>職種(大分類)</td>
                <td>
                    <asp:DropDownList ID="ddlDivision1" runat="server" Height="30px" Width="400px" CssClass="form-control" onkeydown="return trapReturn(this, event);" onchange="change(this,event);" OnSelectedIndexChanged="ddlDivision1_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>職種(小分類)</td>
                <td>
                    <asp:DropDownList ID="ddlPosition1" runat="server" Width="500px" Height="30px" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPositionLevel1" runat="server" CssClass="form-control" Width="150px" Height="30px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>希望職種2(POSITION REQUESTED)</td>
            </tr>
            <tr>
                <td>職種(大分類)</td>
                <td>
                    <asp:DropDownList ID="ddlDivision2" runat="server" CssClass="form-control" Width="400px" Height="30px" onkeydown="return trapReturn(this, event);" onchange="change(this,event);" OnSelectedIndexChanged="ddlDivision2_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>職種(小分類)</td>
                <td>
                    <asp:DropDownList ID="ddlPosition2" runat="server" CssClass="form-control" Width="500px" Height="30px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPositionLevel2" runat="server" CssClass="form-control" Width="150px" Height="30px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>希望職種3(POSITION REQUESTED)</td>
            </tr>
            <tr>
                <td>職種(大分類)</td>
                <td>
                    <asp:DropDownList ID="ddlDivision3" runat="server" CssClass="form-control" Width="400px" Height="30px" onkeydown="return trapReturn(this, event);" onchange="change(this,event);" OnSelectedIndexChanged="ddlDivision3_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>職種(小分類)</td>
                <td>
                    <asp:DropDownList ID="ddlPosition3" runat="server" CssClass="form-control" Width="500px" Height="30px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlPositionLevel3" runat="server" CssClass="form-control" Width="150px" Height="30px"></asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td>現在の状況(CURRENT CAREER CONDITION):</td>
                <td>
                    <asp:DropDownList ID="ddlCurrentCareerCondition" runat="server" CssClass="form-control" Width="150px" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Career Status</td>
                <td>
                    <asp:DropDownList ID="ddlCareerStatus" runat="server" CssClass="form-control" Width="150px" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Notice Type</td>
                <td>
                    <asp:Label ID="lblnoticttype" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>TotalMark</td>
                <td>
                    <asp:Label ID="bindTotalMark" runat="server" Text="" CssClass="form-control" ReadOnly="true" Width="100px" Height="30px"></asp:Label>
                </td>
            </tr>
            <hr />
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl" Text="Education" Font-Size="X-Large" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width:100%">
            <tr>
                <td>EDUCATIONAL BACKGROUND</td>
                <td>
                    <asp:DropDownList ID="ddlEduBackground" runat="server" CssClass="form-control" Width="200px" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Degree</td>
                <td>
                    <asp:DropDownList ID="ddldegree" runat="server" CssClass="form-control" Width="400px" Height="30px">
                    </asp:DropDownList>
                </td>
                <td>Degree</td>
                <td>
                    <asp:DropDownList ID="ddldegree2" runat="server" CssClass="form-control" Width="400px" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>University</td>
                <td>
                    <asp:DropDownList ID="ddlUniversityName" runat="server" CssClass="form-control" Width="400px" OnSelectedIndexChanged="Selected_Township" AutoPostBack="true" Height="30px"> 
                    </asp:DropDownList>
                </td>
                <td>University</td>
                <td>
                    <asp:DropDownList ID="ddlUniversityName2" runat="server" CssClass="form-control" Width="400px" OnSelectedIndexChanged="Selected_Township2" AutoPostBack="true" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>University Location</td>
                <td>
                    <asp:DropDownList ID="ddlUniversityArea" runat="server" CssClass="form-control" Width="200px" Height="30px">
                    </asp:DropDownList>
                </td>
                <td>University Location</td>
                <td>
                    <asp:DropDownList ID="ddlUniversityArea2" runat="server" CssClass="form-control" Width="200px" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>MAJOR</td>
                <td>
                    <asp:DropDownList ID="ddlMajor" runat="server" CssClass="form-control" Width="400px" Height="30px">
                    </asp:DropDownList>
                </td>
                <td>MAJOR</td>
                <td>
                    <asp:DropDownList ID="ddlMajor2" runat="server" CssClass="form-control" Width="400px" Height="30px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Year:</td>
                <td>
                    <asp:TextBox ID="txtYear" runat="server" Width="150px" CssClass="form-control" Height="30px"></asp:TextBox>
                </td>
                <td>Year:</td>
                <td>
                    <asp:TextBox ID="txtYear2" runat="server" Width="150px" CssClass="form-control" Height="30px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Graduation Date</td>
                <td>
                    <div class="control-group" style="float:left">
                      <div class="controls input-append date form_date" style="width:100px" data-date="" data-date-format="MM-yyyy" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                          <asp:TextBox runat="server" ID="txtGraduationDate" ReadOnly="True" CssClass="form-control" Width="150px" Height="30px"></asp:TextBox><br />
					      <span class="add-on" style="float:left;margin-left:150px;margin-top:-30px;height:30px"><i class="icon-th"></i></span>
                      </div>
                   </div>
                </td>
            </tr>
             <tr>
                <td style="width:150px;">その他専攻(OTHERS):</td>
                <td colspan="3">
                    <asp:TextBox ID="txtOtherMajor" runat="server" Width="400px" MaxLength="50" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
        </table>
        <hr />
        <table>
            <tr>
                <td>資格(QUALIFICATION):</td>
                <td>
                    <asp:DataList ID="outerDataList" CellPadding="5" runat="server" OnItemDataBound="outerRep_ItemDataBound" RepeatColumns="1" RepeatDirection="vertical">
                        <ItemTemplate>
                            <asp:Label Font-Size="Medium" Font-Bold="true" ID="lblCategoryName" runat="server" Text='<%# Eval("Description") %>' />
                            <asp:DataList ID="innerDataList" runat="server" RepeatDirection="horizontal" RepeatColumns="5">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkQ" runat="server" Text='<%# Eval("Description")%>'></asp:CheckBox>
                                    <asp:Label ID="lblQ_id" runat="server" Text='<%# Eval("Qualification_ID") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:DataList>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td class="style11">能力(Ability):</td>
                <td>
                    <asp:DataList ID="outerDataList1" CellPadding="5" runat="server" OnItemDataBound="outerRep_ItemDataBound1" RepeatColumns="1" RepeatDirection="vertical">
                        <ItemTemplate>
                            <asp:Label Font-Size="Medium" Font-Bold="true" ID="lblAbilityName" runat="server" Text='<%# Eval("Description") %>' />
                            <asp:DataList ID="innerDataList1" runat="server" RepeatDirection="horizontal" RepeatColumns="3">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAbl" runat="server" Text='<%# Eval("Description")%>'></asp:CheckBox>
                                    <asp:Label ID="lblAbl_id" runat="server" Text='<%# Eval("Ability_id") %>' Visible="false" />
                                </ItemTemplate>
                            </asp:DataList>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="otherqualification" runat="server" Text=" その他の資格(Other Qualification)"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" ID="bindotherqualification" CssClass="form-control" TextMode="MultiLine" BorderColor="Transparent" BorderStyle="None" ReadOnly="true" Height="88px" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:325px;">PCスキル(PC Skill):</td>
                <td>
                    <asp:CheckBoxList ID="chkPcSkill" runat="server" RepeatColumns="6" Width="800px" RepeatDirection="Vertical">
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblWorkingHistory" runat="server"  Text="" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePaneltt" runat="server">
            <ContentTemplate>
                <asp:DataList ID="datalistsalary" runat="server" CellSpacing="3" RepeatLayout="Table" Style="margin-right: 0px">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td style="width:325px;">Company Name</td>
                                <td>
                                    <asp:Label ID="lblcompnayname" runat="server" Text='<%# Eval("Company_Name") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Company Address</td>
                                <td>
                                    <asp:Label ID="lblcompanyaddress" runat="server" Text='<%# Eval("Company_Address") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">IndustryType</td>
                                <td>
                                    <asp:Label ID="lblindustrytype" runat="server" Text='<%# Eval("Industry") %>'></asp:Label>
                                    <asp:Label ID="lblindustrytypeID" runat="server" Text='<%# Eval("IndustryID") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Business Type</td>
                                <td>
                                    <asp:Label ID="lblbusinesstype" runat="server" Text='<%# Eval("Business_Type") %>'></asp:Label>
                                    <asp:Label ID="lblbusinesstypeID" runat="server" Text='<%# Eval("Business_TypeID") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Duration</td>
                                <td>
                                    <asp:Label ID="lbldurationfrom" runat="server" Text='<%# Eval("Duration_From") %>'></asp:Label>-
                                       <asp:Label ID="lbldurationto" runat="server" Text='<%# Eval("Duration_To") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Department</td>
                                <td>
                                    <asp:Label ID="lbldepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                    <asp:Label ID="lbldepartmentID" runat="server" Text='<%# Eval("DepartmentID") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Position</td>
                                <td>
                                    <asp:Label ID="lblposition" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                    <asp:Label ID="lblpositionID" runat="server" Visible="false" Text='<%# Eval("PositionID") %>'></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Position Level</td>
                                <td>
                                    <asp:Label ID="lblpositionlevel" runat="server" Text='<%# Eval("PositionLevel") %>'></asp:Label>
                                    <asp:Label ID="lblpositionlevelID" runat="server" Text='<%# Eval("PositionLevelID") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="style3">Job Description</td>
                                <td>
                                    <asp:Label ID="lbljobdescripition" runat="server" Text='<%# Eval("Job_Description") %>'></asp:Label>
                                    <asp:Label ID="lbljobdescripitionID" runat="server" Text='<%# Eval("Job_Description_ID") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblother" runat="server" Text='<%# Eval("Other") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblreason" runat="server" Text='<%# Eval("Reason_For_Leaving") %>' Visible="false"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Other</td>
                                <td>
                                    <asp:TextBox ID="txtother" runat="server" TextMode="MultiLine" Height="88px" CssClass="form-control" Width="400px" Text='<%# Eval("Other") %>' ReadOnly="true"></asp:TextBox></td>
                                <td>Other(Japan)</td>
                                <td>
                                    <asp:TextBox ID="txtotherjp" runat="server" TextMode="MultiLine" Height="88px" CssClass="form-control" Width="400px" Text='<%# Eval("Other_Japan") %>' ></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>Reason For Leaving</td>
                                <td>
                                    <asp:TextBox ID="txtreasonforleaving" runat="server" CssClass="form-control" Width="400px" TextMode="MultiLine" Height="88px" Text='<%# Eval("Reason_For_Leaving") %>' ReadOnly="true"></asp:TextBox></td>
                                <td>Reason For Leaving(Japan)</td>
                                <td>
                                    <asp:TextBox ID="txtreasongfroleavingjp" CssClass="form-control" Width="400px" runat="server" TextMode="MultiLine" Height="88px" Text='<%# Eval("Reason_For_Leaving_Japan") %>'></asp:TextBox></td>
                            </tr>
                        </table>
                        <hr />
                    </ItemTemplate>
                </asp:DataList>
            </ContentTemplate>
        </asp:UpdatePanel>
                                <hr />
         <asp:Label ID="lblLanguage" Text="Language" runat="server" Font-Size="X-Large"></asp:Label>
        <table>
            <tr>
                <td style="width:325px;">日本語(JAPANESE):</td>
                <td>読み書き<asp:DropDownList ID="ddlJapListening" runat="server" CssClass="form-control" Height="30px" Width="70px"></asp:DropDownList>
                    &nbsp;&nbsp; 会話<asp:DropDownList ID="ddlJapSpeaking" runat="server" CssClass="form-control" Height="30px" Width="70px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>英語(ENGLISH):</td>
                <td>読み書き<asp:DropDownList ID="ddlEngListening" runat="server" CssClass="form-control" Height="30px" Width="70px"></asp:DropDownList>
                    &nbsp;&nbsp; 会話<asp:DropDownList ID="ddlEngSpeaking" runat="server" CssClass="form-control" Height="30px" Width="70px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>ミャンマー語(MYANMAR):</td>
                <td>読み書き<asp:DropDownList ID="ddlMnListening" runat="server" CssClass="form-control" Height="30px" Width="70px">
                    <asp:ListItem Value="16">★</asp:ListItem>
                </asp:DropDownList>
                    &nbsp;&nbsp; 会話<asp:DropDownList ID="ddlMnSpeaking" runat="server" CssClass="form-control" Height="30px" Width="70px">
                        <asp:ListItem Value="16">★</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            </table>
            <table>
            <tr>
                <td style="width:325px;">※レベルの説明:(Language Level)</td>
                <td style="width:400px;">Ａ：ネイティブ並に話せる。<br />
                    Ｂ+：多様なビジネス場面で英語で話すことができる。<br />
                    Ｂ：ビジネス場面で適切な英語を話すことができる。<br />
                    Ｂ-：限られたビジネス場面で英語を話すことができる。<br />
                    Ｃ+：社内の多様な場面で英語で話すことができる。<br />
                    Ｃ：社内会話可能。<br />
                    Ｃ-：限られた場面での社内会話可能。<br />
                    Ｄ：簡単な質問に対応可能。<br />
                    Ｅ：英語は話せない。<br />
                </td>
                 <td>
                    Ａ  ：Native (or) Can deal business with foreigner<br />
                    Ｂ+ ：Can explain very well in various situations<br />
                    Ｂ  ：Can explain properly in business<br />
                    Ｂ- ：Can explain in limited situations<br />
                    Ｃ+ ：Can communicate by conversation within various workplace<br />
                    Ｃ  ：Can communicate by conversation within workplace<br />
                    Ｃ- ：Can communicate by conversation within limited workplace<br />
                    Ｄ  ：Can speak daily usage conversation<br />
                    Ｅ  ：Can't speak<br />
                </td>
            </tr>
        </table>
        <hr />
        <asp:Label runat="server" Text="Check & Comments" ID="Label1" Font-Size="X-Large"></asp:Label>
        <div style="text-align: right;">
            <asp:Label runat="server" ID="Label2" Text=" 更新者ID:" Visible="False"></asp:Label>
            <asp:Label runat="server" ID="Label3" Visible="False"></asp:Label>
            <asp:Label runat="server" ID="Label4" Text="更新日：" Visible="False"></asp:Label>
            <asp:Label runat="server" ID="Label5" Visible="False"></asp:Label>
        </div>
        <table style="visibility:hidden;">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" DataKeyNames="Interview_Question_Title_ID" Visible="false">
                                <Columns>
                                    <asp:BoundField DataField="Interview_Question_Title_ID" HeaderText="Interview Question Title ID" Visible="false" />
                                    <asp:BoundField DataField="Interview_Question_Title" HeaderText="Interview Question Title" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:ImageButton ID="imgOrdersShow" runat="server" OnClick="Show_Hide_OrdersGrid"
                                                        ImageUrl="~/img/2plus.png" CommandArgument="Show" />
                                                    <asp:Panel ID="pnlOrders" runat="server" Visible="false">
                                                        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false"
                                                            DataKeyNames="ID">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="chk" Checked="false" AutoPostBack="false" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Description" HeaderText="Interview Question" />
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInterviewQ3ID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label7" Text="COMMENTS FROM INTERVIEWER" runat="server"></asp:Label><br />
                    <asp:Label ID="Label8" Text="(ADVANTAGES)" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:ImageButton ID="imgshowhide2" runat="server" OnClick="Show_Hide_textbox2" ImageUrl="~/img/2plus.png" CommandArgument="Show" />
                            <asp:TextBox ID="txtJCommentAdvantages" runat="server" TextMode="MultiLine" Height="180px" Width="585px" Visible="false"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator5" runat="server" OnServerValidate="cusCustom_ServerValidate"
                                ControlToValidate="txtJCommentAdvantages" Text="*" ForeColor="Red" ErrorMessage="弊社日本人・面接担当者コメント(COMMENTS FROM JAPANESE INTERVIEWER)(ADVANTAGES) allow only 400 characters.">
                            </asp:CustomValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <asp:Label ID="LblMyanmar" Text="弊社ミャンマー人・面接担当者コメント" runat="server" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="LblMyanmar1" Text="(COMMENTS FROM MYANMAR INTERVIEWER)" runat="server" Visible="false"></asp:Label>
            <br />
            <asp:Label ID="LblMyanmar2" Text="(DISADVANTAGES)" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtMCommentdisadvantage" runat="server" TextMode="MultiLine" Height="180px" Width="585px" Visible="false"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator3" runat="server"
                OnServerValidate="cusCustom_ServerValidate"
                ControlToValidate="txtMCommentdisadvantage"
                Text="*"
                ForeColor="Red"
                ErrorMessage="弊社ミャンマー人・面接担当者コメント(COMMENTS FROM MYANMAR INTERVIEWER)(DISADVANTAGES) allow only 400 characters." Visible="false"> </asp:CustomValidator>
            <tr>
                <td style="width:325px;">
                    <br />
                    <asp:Label ID="Lbljapan1" Text="COMMENTS FROM INTERVIEWER" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Lbljapan2" Text="(DISADVANTAGES)" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:ImageButton ID="imgshowhide3" runat="server" OnClick="Show_Hide_textbox3" ImageUrl="~/img/2plus.png" CommandArgument="Show" />
                            <asp:TextBox ID="txtJCommentDisadvantage" runat="server" Visible="false" TextMode="MultiLine" Height="180px" Width="585px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator4" runat="server" OnServerValidate="cusCustom_ServerValidate"
                                ControlToValidate="txtJCommentDisadvantage" Text="*" ForeColor="Red"
                                ErrorMessage="弊社日本人・面接担当者コメント(COMMENTS FROM JAPANESE INTERVIEWER)(DISADVANTAGES) allow only 400 characters.">
                            </asp:CustomValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="lblimpression" runat="server" Text="Impression"></asp:Label>
                </td>
                <td style="width:450px; height:200px;" >
                    <asp:TextBox runat="server" ID="bindimpression" TextMode="MultiLine" CssClass="font"
                        BorderColor="Transparent" BorderStyle="None" ReadOnly="true" Height="300px"
                        Width="760px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Label ID="lblimpressionjapan" runat="server" Text="Impression for Comment sheet in Japanese"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:ImageButton ID="imgbuttonimp" runat="server" OnClick="Show_Hide_textboxim" ImageUrl="~/img/2plus.png" CommandArgument="Show" />
                            <asp:TextBox ID="txtimpressionjp" runat="server" Visible="false" TextMode="MultiLine" Height="300px" Width="760px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="cusCustom_ServerValidate"
                                ControlToValidate="txtimpressionjp" Text="*" ForeColor="Red" ErrorMessage="">
                            </asp:CustomValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
          <hr />
          <asp:Label runat="server" Text="Data & Photo" ID="Label11" Font-Size="X-Large"></asp:Label>
        <table>
            <tr>
                <td style="width:350px;">
                    <asp:Label ID="Datasheet_Data" runat="server" Text="DATA SHEET & EMPLOYMENT RECORD"></asp:Label>
                </td>
                <td><asp:FileUpload runat="server" ID="uplDatasheetData" onClientClick="ShowText()" CssClass="form-control" style="color:black;"/></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkDatasheetData" OnClick="lnkDatasheetData_Click" CssClass="btn-link"></asp:LinkButton>
                    <asp:Button runat="server" ID="btnDatasheetDataDelete" Text="削除する" CssClass="btn btn-primary"  OnClientClick="ClearFileUpload()" Visible="false" OnClick="btnDatasheetDataDelete_Click" Style="height: 26px" />
                </td>
                <td style="width:300px;">
                    <asp:ImageButton ID="imgDatasheetData" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="uplDatasheetData"
                     ErrorMessage="Only PDF" ForeColor="Red" ValidationExpression="^.*\.(pdf|PDF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:350px;">
                    <asp:Label ID="Label16" runat="server" Text="CV"></asp:Label>
                </td>
                <td><asp:FileUpload runat="server" ID="uplCredentialData" CssClass="form-control" /></td>
                <td style="width:300px;">
                    <asp:LinkButton runat="server" ID="lnkCredentialData" OnClick="lnkCredentialData_Click" CssClass="btn-link"></asp:LinkButton>&nbsp;
                    <asp:Button runat="server" ID="btnCredentialData" Text="削除する" Visible="false" CssClass="btn btn-primary"  OnClick="btnCredentialData_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="imgCredentialData" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="uplCredentialData"
                    ErrorMessage="Only PDF" ForeColor="Red" ValidationExpression="^.*\.(pdf|PDF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:350px;">
                    <asp:Label ID="Photo" runat="server" Text="Photo"></asp:Label>
                </td>
                <td><asp:FileUpload runat="server" ID="uplPhotoData" CssClass="form-control"/></td>
                <td style="width:300px;">
                    <asp:LinkButton runat="server" ID="lnkPhoto" OnClick="lnkPhoto_Click" CssClass="btn-link"></asp:LinkButton>&nbsp;
                    <asp:Button runat="server" ID="btnPhoto" Text="削除する" Visible="false" OnClick="btnPhoto_Click" CssClass="btn btn-primary" />
                </td>
                <td>
                    <asp:ImageButton ID="imgPhoto" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator44" runat="server" ControlToValidate="uplPhotoData"
                    ErrorMessage="Only PDF, JPG, GIF, DOC, PNG" ForeColor="Red" ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|gif|GIF|doc|DOC|docx|DOCX|pdf|PDF|png|PNG)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:350px;"> 
                    <asp:Label ID="Label17" runat="server" Text="Certificate & Qualification"></asp:Label>
                </td>
                <td><asp:FileUpload runat="server" ID="uplGraduationData" CssClass="form-control" /></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkGraduationData" OnClick="lnkGraduationData_Click" CssClass="btn-link"></asp:LinkButton>&nbsp;
                    <asp:Button runat="server" ID="btnGraduationData" Text="削除する" Visible="false" OnClick="btnGraduationData_Click" CssClass="btn btn-primary" />
                </td>
                <td style="width:300px;">
                    <asp:ImageButton ID="imgGraduationData" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="uplGraduationData"
                     ErrorMessage="Only PDF" ForeColor="Red" ValidationExpression="^.*\.(pdf|PDF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:350px;">
                    <asp:Label ID="Label19" runat="server" Text="Others1"></asp:Label>
                </td>
                <td><asp:FileUpload runat="server" ID="uplCardData" CssClass="form-control" /></td>
                <td style="width:300px;">
                    <asp:LinkButton runat="server" ID="lnkCardData" OnClick="lnkCardData_Click" CssClass="btn-link"></asp:LinkButton>&nbsp;
                    <asp:Button runat="server" ID="btnCardData" Text="削除する" Visible="false" CssClass="btn btn-primary" OnClick="btnCardData_Click" />
                </td> 
                <td> 
                    <asp:ImageButton ID="imgCardData" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="uplCardData"
                    ErrorMessage="Only PDF" ForeColor="Red" ValidationExpression="^.*\.(pdf|PDF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:350px;">
                    <asp:Label ID="Label20" runat="server" Text="Others2"></asp:Label>
                </td>
                <td><asp:FileUpload runat="server" ID="uplLabourCard" CssClass="form-control"/></td>
                <td style="width:300px;">
                    <asp:LinkButton runat="server" ID="lnkLabourCard" OnClick="lnkLabourCard_Click" CssClass="btn-link"></asp:LinkButton>&nbsp;
                    <asp:Button runat="server" ID="btnLabourCard" Text="削除する" Visible="false" CssClass="btn btn-primary" OnClick="btnLabourCard_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="imgLabourCard" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="False" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="uplLabourCard"
                    ErrorMessage="Only PDF" ForeColor="Red" ValidationExpression="^.*\.(pdf|PDF)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
 <footer>
        <div class="wrap" style="margin-right:213px;">
            <ul class="nav navbar-nav social" style="width:426px;">
                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Width="200px" CssClass="btn btn-danger" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete?');" Visible="false" />
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="200px" CssClass="btn btn-primary" ValidationGroup="check"/>              
            </ul>
        </div>
    </footer>
</div>

                    <div>
                        <br />
                        <asp:HiddenField ID="hfCareerID" runat="server" />
                        <asp:HiddenField ID="hfMode" runat="server" />
                        <asp:HiddenField ID="hfctrl" Value="" runat="server" />
                        <asp:HiddenField ID="hfCareerCode" runat="server" />
                        <br />
                    </div>
                    </div>
                     </div>
                        <!-- /.panel-body -->
                </div>
                    <!-- /.panel -->
             </div>
                <!-- /.panel -->
       </section>
        <!-- /#page-wrapper -->
     </section>
 <!-- javascripts -->    
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
    </script> 
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
    <script src="../js/jquery.js"></script>
	<script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>   
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>    
    <script src="../js/scripts.js"></script>
</asp:Content>

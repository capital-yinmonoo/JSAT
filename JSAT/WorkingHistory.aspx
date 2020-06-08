<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="WorkingHistory.aspx.cs" Inherits="JSAT.Employee.WorkingHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

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
    <script type="text/javascript">
        function ValidateCheckBox(source, args) {
            var chkcontrolID = source.id;
            var chkListModules = document.getElementById(chkcontrolID);
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
    <script type="text/javascript">
        function ValidateLocationCheck(sender, args) {
            var checkBoxList = document.getElementById("<%=chkthilawa.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
    <script type="text/javascript">
        function ValidateHistory(sender, args) {
            var checkBoxList = document.getElementById("<%=chkhty.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
    <script type="text/javascript">
        function ValidateOversea(sender, args) {
            var checkBoxList = document.getElementById("<%=chkoversea.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
    <script type="text/javascript">
        function ValidateTraining(sender, args) {
            var checkBoxList = document.getElementById("<%=chkoverseatraining.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
    <script type="text/javascript">
        function ValidateLocationRequest(sender, args) {
            var checkBoxList = document.getElementById("<%=chklocationrequested.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
    <style type="text/css">
        @supports(-webkit-appearance:none)
        {
                 .cc;

        {
            border: solid 1px green !important;
            margin-right:58px;
            margin-top: 11px;
            height: 30px;
            float: left;
                
        }

        }
        
        /*.cc
       {
           border:solid 1px green !important;
       }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px">
                <div class="col-lg-12">
                    <h1 class="page-header">Interviewer</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Interview Sheet
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblemployeecode" runat="server" Text="Employee Code"></asp:Label></td>
                                        <td>
                                            <asp:DropDownList ID="ddlemployeecode" CssClass="form-control" runat="server" Enabled="false" Height="30px" Width="100px">
                                                <asp:ListItem></asp:ListItem>
                                                <asp:ListItem>AC</asp:ListItem>
                                                <asp:ListItem>EN</asp:ListItem>
                                                <asp:ListItem>GN</asp:ListItem>
                                                <asp:ListItem>IT</asp:ListItem>
                                                <asp:ListItem>JP</asp:ListItem>
                                                <asp:ListItem>SL</asp:ListItem>
                                                <asp:ListItem>JPN</asp:ListItem>
                                                <asp:ListItem>CAD</asp:ListItem>
                                            </asp:DropDownList></td>
                                        <td style="Width: 5px;">-</td>
                                        <td>
                                            <asp:TextBox ID="txtempcode" runat="server" CssClass="form-control" Enabled="false" Width="100px" Height="30px"></asp:TextBox></td>

                                     <%--   <td>
                                            <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-primary" Width="90px" OnClick="btnserach_Click" />
                                        </td>--%>
                                    </tr>

                                </table>
                                <br />
                                <table>
                                    <tr>
                                        <td style="width: 100px">1st Interviewer</td>
                                        <td>
                                            <asp:DropDownList ID="ddlfirsint" CssClass="form-control" Width="200px" Height="30px" runat="server">
                                            </asp:DropDownList></td>
                                        <td style="width: 20px"></td>
                                        <td style="width: 120px">2nd Interviewer</td>
                                        <td>
                                            <asp:DropDownList ID="ddlsecondint" CssClass="form-control" Width="200px" Height="30px" runat="server">
                                            </asp:DropDownList></td>
                                        <td style="width: 20px"></td>
                                        <td style="width: 160px">Japanese Interviewer</td>
                                        <td>
                                            <asp:DropDownList ID="ddljapan" CssClass="form-control" Width="200px" Height="30px" runat="server">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtname" Height="30px" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td style="width: 20px;"></td>
                                        <td>
                                            <asp:Label ID="lblage" runat="server" Text="Age"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtage" runat="server" CssClass="form-control" Height="30px" Width="50px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
                                        </td>
                                        <td>
                                            <%--<asp:RadioButton ID="male" runat="server" Text="Male" GroupName="rdoGender"  />&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton ID="female" runat="server" Text="Female" GroupName="rdoGender" />&nbsp;&nbsp;&nbsp;--%>
                                            <asp:DropDownList ID="ddlGender" runat="server" Width="130px" Height="30px" CssClass="select-field">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbldate" runat="server" Text="Registration Date"></asp:Label>
                                        </td>
                                        <td class="col-sm-1" >
                                            <asp:TextBox ID="txtdate" Height="30px" runat="server" CssClass="form-control" Width="127px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblupdatedate" runat="server" Text="Update Date"></asp:Label>
                                        </td>
                                        <td class="col-sm-1">
                                            <asp:TextBox ID="txtupdatedate" runat="server" CssClass="form-control" Width="127px" Height="30px" ReadOnly="true"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>                                                                               
                                        <td>
                                            <asp:Label ID="lbladdress" runat="server" Text="Address" Style="margin-right:20px;"></asp:Label>
                                     <asp:DropDownListChosen ID="ddlAddress" runat="server" Width="200px" CssClass="form-control" Height="30px" DataPlaceHolder="Select Here" AllowSingleDeselect="true" onchange="Check_Address()">
                                    </asp:DropDownListChosen>
                                       </td>
                                        <td>
                                             <asp:Label ID="lblPhone" runat="server" Text="Phone" style="margin-left:40px;"></asp:Label>
                                            <asp:TextBox ID="txtPhone" runat="server" style="margin-left:10px;" Width="180px" Height="30px" CssClass="input-field" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtPhone" ValidationGroup="Date"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblReligion" runat="server" Text="Religion" style="margin-left:40px;"></asp:Label>
                                           <asp:DropDownList ID="ddlReligion" runat="server" Width="180px" Height="30px" CssClass="select-field" style="margin-left:10px;">
                                           </asp:DropDownList>
                                           <asp:CompareValidator ID="val14" runat="server" ControlToValidate="ddlReligion" ErrorMessage="***Required***" Operator="NotEqual" ValueToCompare="--Select--" ForeColor="Red" SetFocusOnError="true" ValidationGroup="MyValidation" />
                                        </td>

                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td>
                                          <asp:Label ID="lblEName" runat="server" Text="Emergency Contant Person" Style="margin-right:10px;"></asp:Label>
                                          <asp:TextBox ID="txtEName" Height="30px" Width="180px" runat="server" CssClass="input-field"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="***Required" ForeColor="Red" ControlToValidate="txtEName" ValidationGroup="Date"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                         <asp:Label ID="lblEPhone" runat="server" Text="Emergency Phone Number" Style="margin-right:10px;"></asp:Label>
                                         <asp:TextBox ID="txtEPhone" Height="30px" Width="180px" runat="server" CssClass="input-field" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtEPhone" ValidationGroup="Date"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        <asp:Label ID="lblEmail" runat="server" Text="Email" Style="margin-right:10px;"></asp:Label>
                                         <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field" Height="30px" Width="180px"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="Date"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                            <td style="width: 130px;">
                                            <asp:Label ID="lbldrivinglicense" runat="server" Text="Driving License"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdoAvaliable" runat="server" GroupName="rdoLicense" Width="20px" />
                                            <asp:Label ID="lblavilable" runat="server" Width="70px" Text="Available"></asp:Label>
                                            <asp:RadioButton ID="rdoNot" runat="server" Width="20px" GroupName="rdoLicense" />
                                            <asp:Label ID="lblnot" runat="server" Text="Not" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <asp:Label ID="lbleduback" runat="server" Text="Education Hisotroy" Font-Bold="true" Font-Size="15px"></asp:Label>
                                    </tr>
                                    <tr style="height: 50px">
                                        <td style="width: 80px">
                                            <asp:Label ID="lbldegree1" runat="server" Text="Degree"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:DropDownList ID="ddldegree1" CssClass="form-control" runat="server" Height="30px" Width="150px"></asp:DropDownList>
                                        </td>
                                        <td style="width: 80px">
                                            <asp:Label ID="lbldegree2" runat="server" Text="Degree"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:DropDownList ID="ddldegree2" CssClass="form-control" Height="30px" runat="server" Width="150px"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 50px">
                                            <asp:Label ID="lbluniversity1" runat="server" Text="University"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:DropDownList ID="ddluniversity1" Width="300px" Height="30px" CssClass="form-control" runat="server" OnSelectedIndexChanged="Selected_Township" AutoPostBack="true"></asp:DropDownList>
                                            <asp:DropDownList ID="ddltownship1" Width="150px" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbluniversity2" runat="server" Text="University"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:DropDownList ID="ddluniversity2" Width="300px" Height="30px" CssClass="form-control" runat="server" OnSelectedIndexChanged="Selected_Township2" AutoPostBack="true"></asp:DropDownList>
                                            <asp:DropDownList ID="ddltownship2" Width="150px" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="height: 50px">
                                        <td>
                                            <asp:Label ID="lblmajor1" runat="server" Text="Major"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:DropDownList ID="ddlmajor1" Width="300px" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblmajor2" runat="server" Text="Major"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:DropDownList ID="ddlmajor2" Width="300px" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblyear1" runat="server" Text="Year"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:TextBox ID="txtyear1" Width="300px" Height="30px" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblyear2" runat="server" Text="Year"></asp:Label>
                                        </td>
                                        <td style="width: 500px">
                                            <asp:TextBox ID="txtyear2" Width="300px" Height="30px" CssClass="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblworkexp" runat="server" Text="Working Experience"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdoexperience" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                <asp:ListItem Value="0">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ValidationGroup="Date" ForeColor="Red" ControlToValidate="rdoexperience" ErrorMessage="*Required" />
                                        </td>
                                        <td style="width: 130px;"></td>
                                        <td style="width: 130px;">
                                            <asp:Label ID="lblstatus" runat="server" Text="Status"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:RadioButtonList ID="rdostatus" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="ReqiredFieldValidator2" runat="server" Display="Dynamic" ValidationGroup="Date" ForeColor="Red" ControlToValidate="rdostatus" ErrorMessage="*Required" />
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button class="btn btn-primary" ID="addnewtext" runat="server" Text="Add" Width="76px" OnClick="addnewtext_Click" ValidationGroup="myadd" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false" GridLines="None" OnRowDataBound="Gridview1_On_Row_DataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle BackColor="White" />
                                            <HeaderTemplate>
                                                <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" OnClick="Remove_Click" CssClass="btn btn-danger">Remove</asp:LinkButton>
                                                </FooterTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td colspan="8">
                                                            <asp:Label ID="lblcompanyname" runat="server" Text="Company Name" Width="114px"></asp:Label>
                                                            <asp:TextBox ID="txtcompanyname" CssClass="form-control" runat="server" Width="400px" Height="30px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="***" Width="50px" ForeColor="Red" ControlToValidate="txtcompanyname" ValidationGroup="myadd"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="lblcompanytype" Width="110px" runat="server" Text="Type of Company"></asp:Label>
                                                        </td>
                                                        <td style="width: 440px">
                                                            <asp:DropDownList ID="ddlcompanytype" Width="230px" Height="30px" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlcompanytype_selectedindexchange" AutoPostBack="true"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:DropDownList ID="ddlcountry" Width="110px" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </td>
                                                        <td style="width: 100px">
                                                            <asp:Label ID="lblindustrytype" runat="server" Text="Industry Type"></asp:Label>
                                                        </td>
                                                        <td style="width: 200px">
                                                            <asp:DropDownList ID="ddlindustrytype" Height="30px" Width="350px" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlindustrytype_selectedindexchange" AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblcompanyaddress" Width="115px" runat="server" Text="Company Address"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtcomapnyaddress" runat="server" TextMode="MultiLine" Width="360px" CssClass="form-control" Height="70px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbltypeofbussiness" Width="110px" runat="server" Text="Type of Business"></asp:Label><br />
                                                            <br />
                                                            <asp:Label ID="lbldepartment" Width="110px" runat="server" Text="Department"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddltypeofbusiness" Height="30px" CssClass="form-control" runat="server" Width="350px"></asp:DropDownList>
                                                            <br />
                                                            <asp:DropDownList ID="ddldepartment" Width="350px" Height="30px" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddldepartment_selectedindexchange" AutoPostBack="true"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblduration" Width="110px" runat="server" Text="Duration"></asp:Label>
                                                        </td>
                                                        <td style="width: 350px">
                                                            <div class="control-group" style="float: left;">
                                                                <div class="controls input-append date form_date" style="width: 100px" data-date="" data-date-format="yyyy/mm/dd" data-link-field="dtp_input2" data-link-format="yyyy-mm-dd">
                                                                    <asp:TextBox ID="txtFromDate" Width="130px" Height="30px" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    <span class="add-on" style="float: left; margin-left: 130px; margin-top: -30px; height: 30px;"><i class="icon-th"></i></span>
                                                                </div>
                                                            </div>
                                                            <div class="control-group" style="float: left; margin-left: 80px;">
                                                                <div class="controls input-append date form-date-time" data-date="" data-date-format="yyyy/mm/dd" data-link-field="'dtp_input1" data-link-format="yyyy-mm-dd">
                                                                    <asp:TextBox ID="txtToDate" CssClass="form-control" Width="130px" Height="30px" runat="server" ReadOnly="true"></asp:TextBox>
                                                                    <span class="add-on cc" style="margin-top: 11px; position: absolute; height: 30px;"><i class="icon-th"></i></span>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblposition" Width="110px" runat="server" Text="Position"></asp:Label>
                                                        </td>
                                                        <td style="width: 500px;">
                                                            <asp:DropDownList ID="ddlPosition" Height="30px" CssClass="form-control" runat="server" Width="300px" OnSelectedIndexChanged="ddlposition_selectedindexchange" AutoPostBack="true"></asp:DropDownList>
                                                            <asp:DropDownList ID="ddlpositionlevel" Height="30px" Width="100px" CssClass="form-control" runat="server"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 1000px;">
                                                        <td>
                                                            <asp:Label ID="lbljobdescription" Width="110px" runat="server" Text="Job Description"></asp:Label>
                                                        </td>
                                                        <td colspan="5">
                                                            <asp:CheckBoxList ID="chkjobdescription" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" Style="width: 1000px;"></asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblother" Width="110px" runat="server" Text="Other"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtother" CssClass="form-control" runat="server" TextMode="MultiLine" Height="53px" Width="360px"></asp:TextBox>
                                                            <asp:Label ID="lblotherjp" runat="server" Text="" Visible="false"></asp:Label>
                                                        </td>
                                                        <td style="width: 115px">
                                                            <asp:Label ID="lblreasonforleaving" Width="115px" runat="server" Text="Reason for leaving"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtreasonforleaving" CssClass="form-control" runat="server" TextMode="MultiLine" Height="53px" Width="360px"></asp:TextBox>
                                                            <asp:Label ID="lblreasonforleavingjp" runat="server" Text="" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <hr />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                </asp:GridView>
                                <table>
                                    <tr style="height: 40px">
                                        <td>
                                            <asp:Label ID="lblpositionrequested" runat="server" Text="Position Requested1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlpositionrequsted" Width="500px" Height="30px" CssClass="form-control" runat="server"></asp:DropDownList></td>
                                        <asp:RequiredFieldValidator ID="Req_ID" Display="Dynamic" ValidationGroup="Date" runat="server" ControlToValidate="ddlpositionrequsted" ForeColor="Red" ErrorMessage="*Required"></asp:RequiredFieldValidator>
                                        <td>
                                            <asp:DropDownList ID="ddlpositionlevel1" CssClass="form-control" Height="30px" Width="125px" runat="server"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblexpectedsalary" runat="server" Text="Expected Salary(At Least)"></asp:Label>
                                            <%--</td>
                                        <td>--%>
                                            <asp:TextBox ID="txtexpectedsalary" Style="margin-top: 10px" runat="server" Height="30px" Width="100px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtexpectedsalary" ValidationExpression="\d+" Text="*" Display="Static" ForeColor="Red" EnableClientScript="true" ValidationGroup="check" ErrorMessage="Please enter numbers only" runat="server" />
                                            <asp:DropDownList ID="ddlsalarytype" CssClass="form-control" Height="30px" runat="server" Width="70px"></asp:DropDownList>
                                            <asp:Label ID="salaryID" runat="server" Text="" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px">
                                        <td>
                                            <asp:Label ID="lblpositionrequested1" runat="server" Text="Position Requested2"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlpositionrequested1" CssClass="form-control" Width="500px" Height="30px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlpositionlevel2" Width="125px" CssClass="form-control" Height="30px" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr style="height: 40px">
                                        <td>
                                            <asp:Label ID="lblpositionrequested2" runat="server" Text="Position Requested3"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlpositionrequested2" CssClass="form-control" Width="500px" Height="30px" runat="server"></asp:DropDownList></td>
                                        <td>
                                            <asp:DropDownList ID="ddlpositionlevel3" CssClass="form-control" Width="125px" Height="30px" runat="server"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td valign="middle">
                                            <asp:Label ID="lbllocationrequested" runat="server" Text="Location Request"> </asp:Label>
                                        </td>
                                        <td style="height: 50px;">
                                            <asp:CheckBoxList ID="chklocationrequested" runat="server" class="nav nav-list" RepeatColumns="4" RepeatDirection="Horizontal" Style="margin-left: 33px">
                                            </asp:CheckBoxList>
                                            <asp:CustomValidator ID="CustomValidator6" runat="server" ErrorMessage="*Required" ForeColor="Red" ClientValidationFunction="ValidateLocationRequest" ValidationGroup="Date" align="center"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblsaturady" runat="server" Text="Working on Saturday"></asp:Label>
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:RadioButton ID="rdosatyes" runat="server" Width="20px" GroupName="rdoSat" AutoPostBack="true" OnCheckedChanged="rdosatyes_oncheckchanged" />
                                            <asp:Label runat="server" ID="lblyes" Text="Yes"></asp:Label>

                                            <asp:DropDownList ID="ddlsatdaycondition" runat="server" CssClass="form-control" Width="100px" Height="30px" Visible="false">
                                                <asp:ListItem Text="Full Day" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Half Day" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Biweekly" Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RadioButton ID="rdosatno" Width="20px" runat="server" GroupName="rdoSat" AutoPostBack="true" OnCheckedChanged="rdosatyes_oncheckchanged" />
                                            <asp:Label ID="lblno" runat="server" Width="30px" Text="No"></asp:Label>
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblnotice" runat="server" Text="Notice Type"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdocheckm" runat="server" Width="20px" GroupName="click" AutoPostBack="true" OnCheckedChanged="rdocheckchange" />&nbsp;
                                            <asp:Label ID="lblother" runat="server" Text="Other"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtnoticeday" runat="server" Height="30px" Width="50px" onkeypress="return isNumberKey(event)" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ValidationGroup="Date" ForeColor="Red" ControlToValidate="txtnoticeday" ErrorMessage="*Required" />
                                            <asp:DropDownList ID="ddlnoticetype" runat="server" Height="30px" Width="100px" Visible="false">
                                                <asp:ListItem Value="1" Text="Months"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Weeks"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:RadioButton ID="rdocheckimmediate" runat="server" Width="20px" GroupName="click" AutoPostBack="true" OnCheckedChanged="rdocheckchange" />
                                            <asp:Label ID="lblimmediate" runat="server" Text="Immediate"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>

                                        <td style="width: 200px;">
                                            <asp:Label ID="lbloversea" runat="server" Text="Over Sea"></asp:Label>
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:CheckBoxList ID="chkoversea" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Yes" Value="1" onclick="MutExChkList(this);"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2" onclick="MutExChkList(this);"></asp:ListItem>
                                            </asp:CheckBoxList>
                                            <asp:CustomValidator ID="CustomValidator4" runat="server" ForeColor="Red" ErrorMessage="*Required" ClientValidationFunction="ValidateOversea" ValidationGroup="Date" Display="Dynamic"></asp:CustomValidator>
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lbloverseatraining" runat="server" Text="Oversea Training "></asp:Label>
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="chkoverseatraining" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Yes" Value="1" onclick="MutExChkList(this);"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2" onclick="MutExChkList(this);"></asp:ListItem>
                                            </asp:CheckBoxList>
                                            <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="*Required" ForeColor="Red" ClientValidationFunction="ValidateTraining" ValidationGroup="Date" Display="Dynamic"></asp:CustomValidator>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblthilawa" runat="server" Text="Thilawa" Visible="false"></asp:Label>
                                        </td>
                                        <td align="left" visible="false">
                                            <asp:CheckBoxList ID="chkthilawa" runat="server" RepeatDirection="Horizontal" Height="30px" Width="150px" Style="clear: both; float: left;" Visible="false">
                                                <asp:ListItem Text="Yes" Value="1" onclick="MutExChkList(this);" visible="false"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2" onclick="MutExChkList(this);" visible="false"></asp:ListItem>
                                                <asp:ListItem Text="Ferry" Value="3" onclick="MutExChkList(this);" visible="false"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                        <td align="center" visible="false">
                                            <asp:Label ID="lblhty" runat="server" Text="Hlaing Thar Yar" Visible="false"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:CheckBoxList ID="chkhty" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                <asp:ListItem Text="Yes" Value="1" onclick="MutExChkList(this);"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2" onclick="MutExChkList(this);"></asp:ListItem>
                                                <asp:ListItem Text="Ferry" Value="3" onclick="MutExChkList(this);"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>


                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td style="width: 140px">
                                            <asp:Label ID="lblpcskill" Width="100px" runat="server" Text="PC Skill"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:CheckBoxList ID="chkPcSkill" runat="server" RepeatColumns="5" RepeatDirection="Vertical"
                                                        AutoPostBack="true">
                                                    </asp:CheckBoxList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td style="width: 140px">QUALIFICATION
                                        </td>

                                        <td style="margin-top: 0px">
                                            <asp:DataList ID="outerDataList" CellPadding="5" runat="server" OnItemDataBound="outerRep_ItemDataBound" RepeatColumns="1" RepeatDirection="vertical">
                                                <ItemTemplate>
                                                    <asp:Label Font-Size="Medium" Font-Bold="true" ID="lblCategoryName" runat="server"
                                                        Text='<%# Eval("Description") %>' />


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
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td style="width: 140px">Ability</td>
                                        <td style="margin-top: 0px">
                                            <asp:DataList ID="outerDataList1" CellPadding="5" runat="server" OnItemDataBound="outerRep_ItemDataBound1" RepeatColumns="1" RepeatDirection="vertical">
                                                <ItemTemplate>

                                                    <asp:Label Font-Size="Medium" Font-Bold="true" ID="lblAbilityName" runat="server"
                                                        Text='<%# Eval("Description") %>' />


                                                    <asp:DataList ID="innerDataList1" runat="server" RepeatDirection="horizontal" RepeatColumns="2">
                                                        <ItemTemplate>

                                                            <asp:CheckBox ID="chkAbl" runat="server" Text='<%# Eval("Description")%>'></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:Label ID="lblAbl_id" runat="server" Text='<%# Eval("Ability_id") %>' Visible="false" />

                                                        </ItemTemplate>

                                                    </asp:DataList>

                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>

                                <table class="table table-striped">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:Label ID="lblqualification" runat="server" Text="Other Qualification"></asp:Label>
                                            <asp:TextBox ID="txtqualification" runat="server" TextMode="MultiLine" CssClass="text" Height="48px" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-striped">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:Label ID="lblimpression" runat="server" Text="Impression/others"></asp:Label>
                                            <asp:TextBox ID="txtimpression" runat="server" TextMode="MultiLine" Width="100%" CssClass="text" Height="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table class="table table-striped">
                                    <tr>
                                        <td style="width:100%">
                                            <asp:Label ID="LblUpdatingInfo" runat="server" Text="Updating Information"></asp:Label>
                                            <asp:TextBox ID="txtupdateinfo" runat="server" TextMode="MultiLine" Width="100%" CssClass="text" Height="120px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbleng" runat="server" Font-Size="16px" Font-Bold="true" Text="English"></asp:Label>
                                        </td>
                                        <td style="width: 20px"></td>
                                        <td>Reading And Writing </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEngreadwrite" CssClass="form-control" runat="server" Height="28px" Width="60px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>Speaking </td>
                                        <td>
                                            <asp:DropDownList ID="ddlEngspeaking" CssClass="form-control" runat="server" Height="30px" Width="60px">
                                            </asp:DropDownList> 
                                        </td>
                                        <td class="col-sm-1"></td>
                                        <td>
                                            <asp:Label ID="lbljp" Font-Bold="true" Font-Size="16px" runat="server" Text="Japanese"></asp:Label>
                                        </td>
                                        <td style="width: 20px"></td>
                                        <td>Reading And Writing</td>
                                        <td>
                                            <asp:DropDownList ID="ddljpreadwrite" CssClass="form-control" runat="server" Height="30px" Width="60px">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 30px"></td>
                                        <td>Speaking</td>
                                        <td>
                                            <asp:DropDownList ID="ddljpspeaking" CssClass="form-control" runat="server" Height="30px" Width="60px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table>
                                    <tr>
                                        <td class="col-sm-4">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 300px">Cleanliness
                                                            </td>
                                                            <td style="width: 300px">Respect
                                                            </td>
                                                            <td style="width: 300px">Positiveness
                                                            </td>
                                                            <td style="width: 300px">Presentation
                                                            </td>
                                                            <td style="width: 300px">Impression
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:CheckBoxList ID="chkpersonalskill" runat="server" Width="100%" RepeatColumns="5" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="chkpersonalskill_OnCheck_Changed">
                                                    </asp:CheckBoxList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div style="float: right">
                                            <asp:Label ID="lbltotalMark" runat="server">Total Marks</asp:Label>
                                            <asp:TextBox ID="txtTotalMark" CssClass="form-control" runat="server" Height="30px" Width="40px" MaxLength="2" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="chkpersonalskill" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>

                                <%--<asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Save" Width="90px" Height="34px" OnClick="Button1_Click" ValidationGroup="Date" Enabled="false"/>--%>
                               <%--<asp:Button ID="btndelete" runat="server" class="btn btn-danger" Text="Delete" Width="90px" Height="34px" Visible="false" OnClick="btndelete_Click" />--%>
                                <footer>
                                    <center>
          <div class="wrap" style="margin-right:213px;">
            
            <ul class="nav navbar-nav social" style="width:426px;">
                <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Save" Width="200px" OnClick="Button1_Click" ValidationGroup="Date" Enabled="true"/>
                <asp:Button ID="btndelete" runat="server" CssClass="btn btn-danger" Text="Delete" Width="200px" OnClick="btndelete_Click" Visible="false" />
                <asp:HiddenField ID="hfCareerID" runat="server" /> 
                <asp:Label ID="lblAutoNo" runat="server"></asp:Label>
            </ul>
          </div>
     </center>
                                </footer>

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
    <%--<script type="text/javascript" src="../date/bootstrap.min.js"></script>--%>
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
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
    <script src="../js/jquery.autosize.min.js"></script>

</asp:Content>

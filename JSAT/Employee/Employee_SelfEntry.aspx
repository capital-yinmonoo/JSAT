<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee_SelfEntry.aspx.cs" Inherits="JSAT_Ver1.Employee.Employee_SelfEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-theme.css" rel="stylesheet">
    <link href="../css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.scrollTo.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
    <script src="../js/jquery.autosize.min.js"></script>
    <title>Employee Register</title>
    <link rel="stylesheet" href="../css/style.css" />
    <script language="javascript" type="text/javascript">
        function PreviewImg(imgFile) {
            var newPreview = document.getElementById("newPreview");
            newPreview.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = imgFile.value;
            newPreview.style.width = "80px";
            newPreview.style.height = "60px";
        }
    </script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if ((charCode >= 48 && charCode <= 57) || charCode == 8 || charCode == 46)
                return true;
            else return false;
        }

        function Check_Address() {
            var ddl = document.getElementById('<%= ddlAddress.ClientID %>');
            var ddlvalue = ddl.options[ddl.selectedIndex].value;
            if (ddlvalue != 38) {
                document.getElementById('<%= txtAddress.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%= txtAddress.ClientID %>').style.display = "block";
            }
            if (ddlvalue) {
                document.getElementById('<%= lblAddrequire.ClientID %>').style.display = "none";
            }
            else {
                document.getElementById('<%= lblAddrequire.ClientID %>').style.display = "block";
            }
        }

        $(document).ready(function () {
            $('#txtAddress').hide();
        });
    </script>
</head>
<body style="background-color: #F8F8F8;">
    <div class="container">
        <div class="form-style-10">
            <h1>Sign Up Now!<span>Please Register Your Information!</span></h1>
            <form id="Form1" runat="server">
                <table align="right">
                    <tr>
                        <td>
                            <label>
                                <asp:Label ID="lbldate" runat="server">Date</asp:Label></label></td>
                        <td>
                            <asp:TextBox ID="currentdate" runat="server" Width="150px" Height="30px"></asp:TextBox></td>
                    </tr>
                </table>
                <div class="inner-wrap">
                    <label>
                        <asp:Label ID="lblAutoNo" runat="server"></asp:Label></label>
                    <label>
                        <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="input-field"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtName" ValidationGroup="MyValidation"></asp:RequiredFieldValidator></label>
                    <label>
                        <span>
                            <asp:Label ID="Label1" runat="server" Text="Date Of Birth"></asp:Label></span>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtday" runat="server" onkeypress="return isNumberKey(event)" MaxLength="2" PlaceHolder="Day"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtday" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtmonth" runat="server" onkeypress="return isNumberKey(event)" MaxLength="2" ToolTip="Month" PlaceHolder="Month"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtmonth" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtyear" runat="server" onkeypress="return isNumberKey(event)" MaxLength="4" ToolTip="Year" MininumLength="4" PlaceHolder="Year"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtyear" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter valid day!" MaximumValue="31" MinimumValue="1" Type="Integer" ControlToValidate="txtday" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Please enter valid month!" MinimumValue="1" MaximumValue="12" Type="Integer" ControlToValidate="txtmonth" ForeColor="Red"></asp:RangeValidator>
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="Please enter valid year!" Type="Integer" ControlToValidate="txtyear" MinimumValue="1950" MaximumValue="2090" ForeColor="Red"></asp:RangeValidator></label>
                    <label>
                        <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                        <asp:DropDownList ID="ddlGender" runat="server" Width="130px" CssClass="select-field">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator InitialValue="0" ID="Req_ID" Display="Dynamic" ValidationGroup="MyValidation" runat="server" ControlToValidate="ddlGender" ErrorMessage="***Required***" ForeColor="Red"></asp:RequiredFieldValidator>
                    </label>
                    <label>
                        <asp:Label ID="Label2" runat="server" Text="Religion"></asp:Label>
                        <asp:DropDownList ID="ddlReligion" runat="server" Width="180px" CssClass="select-field">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="val14" runat="server" ControlToValidate="ddlReligion" ErrorMessage="***Required***" Operator="NotEqual" ValueToCompare="--Select--" ForeColor="Red" SetFocusOnError="true" ValidationGroup="MyValidation" />
                    </label>
                    <label>
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:DropDownListChosen ID="ddlAddress" runat="server" Width="200px" CssClass="form-control" Height="180px" DataPlaceHolder="Select Here" AllowSingleDeselect="true" onchange="Check_Address()">
                                    </asp:DropDownListChosen>
                                    <%-- <asp:DropDownList ID="ddlAddress" runat="server" Width="200px" CssClass="select-field">
                                    </asp:DropDownList>--%>
                                </td>
                                <td>
                                    <asp:Label ID="lblAddrequire" runat="server" Text="***Required***" ForeColor="Red" style="display: none;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlAddress" ErrorMessage="***Required***" Operator="NotEqual" ValueToCompare="" ForeColor="Red" SetFocusOnError="true" ValidationGroup="MyValidation" />
                    </label>
                    <label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Your Native Town Name"></asp:TextBox>
                    </label>
                </div>

                <label>
                    <asp:Label ID="lblPhone" runat="server" Text="Phone"></asp:Label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="input-field" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtPhone" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                </label>
                <label>
                    <asp:Label ID="lblEName" runat="server" Text="Emergency Contant Person"></asp:Label>
                    <asp:TextBox ID="txtEName" runat="server" CssClass="input-field"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="***Required" ForeColor="Red" ControlToValidate="txtEName" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                </label>
                <label>
                    <asp:Label ID="lblEPhone" runat="server" Text="Emergency Phone Number"></asp:Label>
                    <asp:TextBox ID="txtEPhone" runat="server" CssClass="input-field" onkeypress="return isNumberKey(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtEPhone" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                </label>
                <label>
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="***Required***" ForeColor="Red" ControlToValidate="txtEmail" ValidationGroup="MyValidation"></asp:RequiredFieldValidator>
                </label>
                <label>
                    <asp:Label ID="lblPhoto" runat="server" Text="Photo"></asp:Label>
                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="PreviewImg(this)" />
                    <asp:Button runat="server" ID="btnPhotoPreview" Text="Preview" OnClick="btnPreview_Click" />
                    <asp:Image runat="server" ID="ImagePreview" Height="164px" Width="125px" Visible="false" />
                    <asp:Label ID="lblimage" runat="server"></asp:Label>
                    <div id="newPreview">
                    </div>
                </label>
                <label>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="124px" ValidationGroup="MyValidation" CssClass="btn" />
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" Width="124px" OnClick="BtnCancel_Click" CssClass="btn" /></label>
                <asp:HiddenField ID="hfCareerID" runat="server" />                
            </form>
        </div>
    </div>
</body>
</html>

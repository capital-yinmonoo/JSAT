<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkingHistory_Detail.aspx.cs" Inherits="JSAT.WorkingHistory_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="Creative - Bootstrap 3 Responsive Admin Template">
    <meta name="author" content="GeeksLabs">
    <meta name="keyword" content="Creative, Dashboard, Admin, Template, Theme, Bootstrap, Responsive, Retina, Minimal">
    <link rel="shortcut icon" href="img/favicon.png">
    <title></title>
    <%-- <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-theme.css" rel="stylesheet" />
    <link href="../css/elegant-icons-style.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" /> 
    <link href="../css/style-responsive.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Interviewer</h1>

                </div>
                <!-- /.col-lg-12 -->
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Working History Detail
                             <%--<asp:Label ID="lblcode" runat="server" Text="Employee Working Detail"></asp:Label>--%>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="tab-content">
                                    <div class="tab-pane fade in active" id="home">
                                        <asp:Button ID="btnedit" runat="server" class="btn btn-primary" Text="Edit Selected Employee" Height="35px" Width="259px" OnClick="btnedit_Click" /><br /><br />
                                        <asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>

                                        <asp:Label ID="lbl1" runat="server" Text="" Visible="false"></asp:Label>
                                        <table class="table">

                                            <tr>
                                                <td style="width: 275px">
                                                    <asp:Label ID="lblcareer_Code" runat="server" Text="Career_Code"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblcode" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareername" runat="server" Text="Name"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerage" runat="server" Text="Age"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblage" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareergender" runat="server" Text="Gender"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblgender" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="First Interviewer"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblfirstinterviewer" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="Second Interviewer"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblsecondinterviewer" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label ID="Label21" runat="server" Text="Japanese Interviewer"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbljapaneseinterviewer" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label23" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerinterviewdate" runat="server" Text="Registration Date"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblinterviewdate" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerupdatedate" runat="server" Text="Update Date"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblupdatedate" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label10" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerdrivinglicences" runat="server" Text="Driving License"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbldrivinglicense" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareeraddress" runat="server" Text="Address"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerdegree" runat="server" Text="Degree1"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbldegree1" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareeruniversity" runat="server" Text="University1"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbluniversity1" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbltownship1" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareermajor" runat="server" Text="Major1"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblmajor1" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareeryear" runat="server" Text="Year1"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblyear1" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label15" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerdegree2" runat="server" Text="Degree2"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbldegree2" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label16" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareeruniversity2" runat="server" Text="University2"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbluniversity2" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lbltownship2" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareermajor2" runat="server" Text="Major2"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblmajor2" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label17" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareeryear2" runat="server" Text="Year2"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblyear2" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label18" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerworkingexp" runat="server" Text="Working Experience"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblworkingexp" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblcareerstatus" runat="server" Text="Status"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label20" runat="server" Text="" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <asp:DataList ID="dljobhistory" runat="server" Width="100%">
                                    <ItemTemplate>
                                        <table cellpadding="6" class="table">
                                            <tr>
                                                <td style="width: 275px;">Company Name</td>
                                                <td>
                                                    <asp:Label ID="lblcompnayname" runat="server" Text='<%# Eval("Company_Name") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 270px;">Company Address</td>
                                                <td>
                                                    <asp:Label ID="lblcompanyaddress" runat="server" Text='<%# Eval("Company_Address") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Company Type</td>
                                                <td>
                                                    <asp:Label ID="lblcompanytype" runat="server" Text='<%# Eval("Company_Type") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Company Type Country</td>
                                                <td>
                                                    <asp:Label ID="lblcountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>IndustryType</td>
                                                <td>
                                                    <asp:Label ID="lblindustrytype" runat="server" Text='<%# Eval("Industry") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Business Type</td>
                                                <td>
                                                    <asp:Label ID="lblbusinesstype" runat="server" Text='<%# Eval("Business_Type") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Duration</td>
                                                <td>
                                                    <asp:Label ID="lbldurationfrom" runat="server" Text='<%# Eval("Duration_From") %>'></asp:Label>-
                           <asp:Label ID="lbldurationto" runat="server" Text='<%# Eval("Duration_To") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Department</td>
                                                <td>
                                                    <asp:Label ID="lbldepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Position</td>
                                                <td>
                                                    <asp:Label ID="lblposition" runat="server" Text='<%# Eval("Position") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Position Level</td>
                                                <td>
                                                    <asp:Label ID="lblpositionlevel" runat="server" Text='<%# Eval("PositionLevel") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Job Description</td>
                                                <td>
                                                    <asp:Label ID="lbljobdescripition" runat="server" Text='<%# Eval("Job_Description") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Other</td>
                                                <td>
                                                    <asp:TextBox ID="lblother" runat="server" Text='<%# Eval("Other") %>' TextMode="Multiline" ReadOnly="true" BorderColor="Transparent" Height="70px" Width="600px" CssClass="font"></asp:TextBox>
                                                    <asp:Label ID="lblotherjp" runat="server" Text='<%# Eval("Other_Japan") %>' Visible="false"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Reason For Leaving</td>
                                                <td>
                                                    <asp:TextBox ID="lblreason" runat="server" Text='<%# Eval("Reason_For_Leaving") %>' TextMode="Multiline" ReadOnly="true" BorderColor="Transparent" Height="70px" Width="600px" CssClass="font"></asp:TextBox>
                                                    <asp:Label ID="lblreasonforleavingjp" runat="server" Text='<%# Eval("Reason_For_Leaving_Japan") %>' Visible="false"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                                <table cellpadding="6" class="table border-top-0">
                                    <tr>
                                        <td style="width: 275px">
                                            <asp:Label ID="lblpositionrequested" Width="100px" runat="server" Text="Position Requested1"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="positionrequested" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpostionlevel1" runat="server" Text="Position Level1"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="postionlevel1" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpositionrequested1" runat="server" Text="Position Requested2"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="positionrequested1" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpostionlevel2" runat="server" Text="Position Level2"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="postionlevel2" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpositionrequested2" runat="server" Text="Position Requested3"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="positionrequested2" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpostionlevel3" runat="server" Text="Position Level3"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="postionlevel3" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblexpectedsalary" runat="server" Text="Expected Salary"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="expectedsalry" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="salarytype" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbllocationrequested" runat="server" Text="Location Requested"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="locationrequested" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblworkingonsatday" runat="server" Text="Working On Saturday"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="workonsatday" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblsatdaycondition" runat="server" Text="Saturday Condition"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="satdaycondition" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbldesireddate" runat="server" Text="Desired Date" Visible="false"></asp:Label>
                                            <asp:Label ID="lblNotictytype" runat="server" Text="Notice"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="desireddate" runat="server" Text="" Visible="false"></asp:Label>
                                            <asp:Label ID="NoticeDay" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="NoticeType" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblworkarea" runat="server" Text="Workable Area"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="workarea" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpcskill" runat="server" Text="PC Skill"></asp:Label></td>
                                        <td>
                                            <asp:Label ID="pcskill" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblqual" runat="server" Text="Qualification"></asp:Label></td>
                                        <td>
                                            <%--<asp:Label ID="qual" runat="server" Text=""></asp:Label>--%>
                                            <span class="border-top-0">
                                            <asp:DataList ID="DLQualification" runat="server" class="table" RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="None" OnItemDataBound="DLQualification_ItemDataBound" CssClass="border-0" Style="border-top:none;">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltitle" runat="server" Font-Bold="true" Width="200px" Text='<%#DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                                    <%-- <asp:ListBox SelectionMode="Multiple" ID="LBQualification" CssClass="form-control" runat="server" Width="250px"></asp:ListBox>--%>

                                                    <asp:DataList ID="innerDataList" runat="server" RepeatDirection="horizontal" RepeatColumns="1" CssClass="border-0">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQualification" runat="server" Text='<%# Eval("Description") %>' />
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </ItemTemplate>
                                            </asp:DataList>
                                                </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblabl" runat="server" Text="Ability"></asp:Label></td>
                                        <td>
                                            <%-- <asp:Label ID="abl" runat="server" Text=""></asp:Label>--%>
                                            <asp:DataList ID="DLAbility" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" BorderStyle="None" OnItemDataBound="DLAbility_ItemDataBound" Style="border-top: none;">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltitle" runat="server" Font-Bold="true" Width="200px" Text='<%#DataBinder.Eval(Container.DataItem,"Description") %>' Style="border-top: none;"></asp:Label>

                                                    <asp:DataList ID="innerDataList1" runat="server" RepeatDirection="horizontal" RepeatColumns="1" Style="border-top: none;">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAbility" runat="server" Text='<%# Eval("Description") %>' Style="border-top: none;" />
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblqualification" runat="server" Text="Other Qualification"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="qualification" runat="server" TextMode="Multiline" ReadOnly="true" BorderColor="Transparent" Height="70px" Width="600px" CssClass="font"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblother" runat="server" Text="Impression/Other"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="other" runat="server" TextMode="Multiline" ReadOnly="true" BorderColor="Transparent" Height="70px" Width="600px" CssClass="font"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblupdatinginfo" runat="server" Text="Updating Information"></asp:Label></td>
                                        <td>
                                            <asp:TextBox ID="updatett" runat="server" TextMode="MultiLine" ReadOnly="true" BorderColor="Transparent" Height="70px" Width="600px" CssClass="font"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblenglanguange" runat="server" Text="English Language"></asp:Label></td>
                                        <td>(Reading And Writing) &nbsp;<asp:Label ID="engreadwrite" runat="server" Text=""></asp:Label>
                                            &nbsp;
                          (Speaking) &nbsp;<asp:Label ID="engspeak" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbljplanguage" runat="server" Text="Japanese Language"></asp:Label></td>
                                        <td>(Reading And Writing) &nbsp;<asp:Label ID="jpreadwrite" runat="server" Text=""></asp:Label>
                                            &nbsp;&nbsp;&nbsp; (Speaking) &nbsp;              
                          <asp:Label ID="jpspeak" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblpersonalskill" runat="server" Text="Personal Skill"></asp:Label></td>
                                        <td>
                                            <table style="border: none">
                                                <tr>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="personalskill1" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="personalskill2" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="personalskill3" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="personalskill4" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="personalskill5" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="total" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="mark1" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="mark2" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="mark3" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="mark4" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="mark5" runat="server" Text=""></asp:Label></td>
                                                    <td style="text-align: center; width: 200px; border: none">
                                                        <asp:Label ID="totalmarks" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </section>
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
</asp:Content>

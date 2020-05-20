<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Career_Resume_Detail.aspx.cs" Inherits="JSAT_Ver1.Employee.Career_Resume_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <div class="row" style="height: 50px;">
                <div class="col-lg-12">
                    <h1 class="page-header">Employee</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading tab-bg-primary ">
                            人材基本情報(INFORMATION OF CANDIDATE)
                        </div>
                        <!-- /.panel-heading -->
                        <br />
                        <table align="right" class="form-control" style="width: 350px; height: 30px;border:0;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="作成日："></asp:Label>
                                    <asp:Label runat="server" ID="lblCreatedDate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="更新日："></asp:Label>
                                    <asp:Label runat="server" ID="lblUpdatedDate"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <center>
                        <asp:Button runat="server" ID="btnExport" class="btn btn-primary" Text="Export To PDF" OnClick="btnExport_Click"/>&nbsp; &nbsp;
                        <asp:Button runat="server" ID="btnEdit" class="btn btn-primary" Text="To Edit Selected Employee" OnClick="btnEdit_Click" /></center>
                        <br />
                        <div class="panel-body">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#home" data-toggle="tab">Profile</a>
                                </li>
                                <li><a href="#profile" data-toggle="tab">Education & Career</a>
                                </li>
                                <li><a href="#messages" data-toggle="tab">Impression And Comments</a>
                                </li>
                                <li><a href="#settings" data-toggle="tab">Data & Photo</a>
                                </li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="home">
                                    <table class="table">
                                        <tr>
                                            <td style="width: 500px;"> 登録形態(Type)</td>
                                            <td><asp:Label runat="server" ID="lbldomestic"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>登録番号(No.)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCareerCode"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>性別(GENDER)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblGender"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>名前(NAME)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblName"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>生年月日(DATE OF BIRTH)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblBirth"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>年齢(AGE)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAge"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>宗教(RELIGION)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblReligion"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>現住所(ADDRESS)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblAddress"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>電話番号1(PHONE NO_1)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPh1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>電話番号2(PHONE NO_2)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPh2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>メールアドレス(EMAIL)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEmail"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>緊急連絡番号(EMERGENCY PHONE NUMBER) </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEmgNo"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>緊急連絡名(EMERGENCY CONTACT NAME)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEmgName"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <asp:DataList ID="dlsalary" runat="server" CellSpacing="3" RepeatLayout="Table">         <%--OnItemDataBound="dlsalary_ItemDataBound"--%>
                                        <ItemTemplate>
                                            <table class="table">
                                                <tr>
                                                    <td style="width: 498px;">希望給与(EXPECTED SALARY)
                                                    </td>
                                                    <td style="width: 622px;">
                                                        <asp:Label ID="lblsalary" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                                                        <%--<asp:Label ID="lblsalarytype" runat="server" Text='<%# Eval("Salary_Type") %>'></asp:Label>
                                                        <asp:Label ID="lblsalaryformat" runat="server" Text='<%# Eval("Salary_Format") %>'></asp:Label>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <table class="table">
                                        <tr>
                                            <td style="width: 499px;">希望勤務地(WORKABLE AREA)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblWorkArea"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">希望職種①(POSITION REQUESTED)</td>
                                        </tr>
                                        <tr>
                                            <td>職種(大分類)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDivision1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>職種(小分類)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPosition1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Position Level</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPositionLevel1"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">希望職種②(POSITION REQUESTED)</td>
                                        </tr>
                                        <tr>
                                            <td>職種(大分類)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDivision2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>職種(小分類)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPosition2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Position Level</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPositionLevel2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">希望職種③(POSITION REQUESTED)</td>
                                        </tr>
                                        <tr>
                                            <td>職種(大分類)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDivision3"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>職種(小分類)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPosition3"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Position Level</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPositionLevel3"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>現在の状況(CURRENT CAREER CONDITION)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCondition"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Career Status</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCareerStatus"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Notice Type</td>
                                            <td>
                                                <asp:Label ID="lblnoticttype" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTotalMark" runat="server" Text="TotalMark"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="bindTotalMark" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="tab-pane fade" id="profile">
                                    <table class="table">
                                        <tr>
                                            <td style="width: 413px;">学歴(EDUCATIONAL BACKGROUND)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblEducation"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>First Degree</td>
                                            <td>
                                                <asp:Label runat="server" ID="lbldegree"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>学校名(First INSTITUTION's NAME)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblInstitutionName"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>学校名(First INSTITUTION's AREA)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblInstitutionArea"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>専攻(First MAJOR)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblMajor"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>年度(YEAR)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblyear"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Second Degree</td>
                                            <td>
                                                <asp:Label runat="server" ID="lbldegree2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>学校名(Second INSTITUTION's NAME)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblInstitutionName2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>学校名(Second INSTITUTION's AREA)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblInstitutionArea2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>専攻(Second MAJOR)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblMajor2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>年度(YEAR)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblyear2"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Graduation Date</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblgdate"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>その他専攻(OTHERS)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblMajorOthers"></asp:Label></td>
                                        </tr>
                                        </table>
                                    <hr />
                                    <table>
                                        <tr>
                                            <td style="width:418px;">資格(QUALIFICATION)</td>
                                            <td>
                                                <%--<asp:Label runat="server" ID="lblQualification"></asp:Label>--%>
                                                <asp:DataList ID="DLQualification" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="None" OnItemDataBound="DLQualification_ItemDataBound" Style="border-top: none;">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltitle" runat="server" Font-Bold="true" Width="300px" Text='<%#DataBinder.Eval(Container.DataItem,"Description") %>'></asp:Label>
                                                        <%-- <asp:ListBox SelectionMode="Multiple" ID="LBQualification" CssClass="form-control" runat="server" Width="250px"></asp:ListBox>--%>

                                                        <asp:DataList ID="innerDataList" runat="server" RepeatDirection="horizontal" RepeatColumns="1" Style="border-top: none;">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblQualification" runat="server" Text='<%# Eval("Description") %>' />
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <hr />
                                        <tr>
                                            <td Style="border-top: none;">能力(Ability)</td>
                                            <td Style="border-top: none;">
                                                <%-- <asp:Label runat="server" ID="lblAbility"></asp:Label>--%>
                                                <asp:DataList ID="DLAbility" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="None" OnItemDataBound="DLAbility_ItemDataBound" Style="border-top: none;">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltitle" runat="server" Font-Bold="true" Width="300px" Text='<%#DataBinder.Eval(Container.DataItem,"Description") %>'  Style="border-top: none;"></asp:Label>

                                                        <asp:DataList ID="innerDataList1" runat="server" RepeatDirection="horizontal" RepeatColumns="1" Style="border-top: none;">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAbility" runat="server" Text='<%# Eval("Description") %>' Style="border-top: none;"/>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="otherqualification" runat="server" Text="その他の資格(Other Qualification)"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="bindotherqualification" runat="server" TextMode="Multiline" ReadOnly="true" BorderColor="Transparent" Height="88px" Width="400px" CssClass="font"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>その他PCスキル(OTHERS)</td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPCSkillOthers"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <asp:DataList ID="datalistsalary" runat="server" Width="100%">
                                        <ItemTemplate>
                                            <table class="table">
                                                <tr>
                                                    <td style="width: 413px">Company Name
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcompnayname" runat="server" Text='<%# Eval("Company_Name") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>Company Address</td>
                                                    <td>
                                                        <asp:Label ID="lblcompanyaddress" runat="server" Text='<%# Eval("Company_Address") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>IndustryType</td>
                                                    <td>
                                                        <asp:Label ID="lblindustrytype" runat="server" Text='<%# Eval("Industry") %>'></asp:Label>
                                                        <asp:Label ID="lblindustrytypeID" runat="server" Visible="false" Text='<%# Eval("IndustryID") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Business Type
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblbusinesstype" runat="server" Text='<%# Eval("Business_Type") %>'></asp:Label>
                                                        <asp:Label ID="lblbusinesstypeID" runat="server" Text='<%# Eval("Business_TypeID") %>' Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Duration 
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbldurationfrom" runat="server" Text='<%# Eval("Duration_From") %>'></asp:Label>-
                                                   <asp:Label ID="lbldurationto" runat="server" Text='<%# Eval("Duration_To") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>Department
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbldepartment" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                                        <asp:Label ID="lbldepartmentID" runat="server" Text='<%# Eval("DepartmentID") %>' Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Position</td>
                                                    <td>
                                                        <asp:Label ID="lblposition" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                                        <asp:Label ID="lblpositionID" runat="server" Text='<%# Eval("PositionID") %>' Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Position Level
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblpositionlevel" runat="server" Text='<%# Eval("PositionLevel") %>'></asp:Label>
                                                        <asp:Label ID="lblpositionlevelID" runat="server" Text='<%# Eval("PositionLevelID") %>' Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Job Description 
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbljobdescripition" runat="server" Text='<%# Eval("Job_Description") %>'></asp:Label>
                                                        <asp:Label ID="lbljobdescripitionID" runat="server" Text='<%# Eval("Job_Description_ID") %>' Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Other</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="lblother" TextMode="MultiLine" Text='<%# Eval("Other") %>' BorderColor="Transparent" BorderStyle="None" ReadOnly="true" Height="88px" Width="400px" CssClass="font"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Reason For Leaving</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="lblreason" TextMode="MultiLine" Text='<%# Eval("Reason_For_Leaving") %>' BorderColor="Transparent" BorderStyle="None" ReadOnly="true" Height="88px" Width="400px" CssClass="font"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Other(Japan)</td>
                                                    <td>
                                                        <asp:Label ID="txtotherjp" runat="server" Text='<%# Eval("Other_Japan") %>'></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>Reason For Leaving(Japan)</td>
                                                    <td>
                                                        <asp:Label ID="txtreasongfroleavingjp" runat="server" Text='<%# Eval("Reason_For_Leaving_Japan") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <table class="table">
                                        <tr>
                                            <td colspan="2">語学能力(ABILITY OF LANGUAGE)</td>
                                        </tr>
                                        <tr>
                                            <td>日本語(JAPANESE)</td>
                                            <td>読み書き(LISTENING) &nbsp;
                                        <asp:Label runat="server" ID="lblJapaneseRW"></asp:Label>
                                                &nbsp; 
                                会話(SPEAKING) &nbsp;
                                        <asp:Label runat="server" ID="lblJapaneseSpeak"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>英語(ENGLISH)</td>
                                            <td>読み書き(LISTENING) &nbsp;
                                        <asp:Label runat="server" ID="lblEnglishRW"></asp:Label>
                                                &nbsp; 
                                        会話(SPEAKING) &nbsp;
                                                    <asp:Label runat="server" ID="lblEnglishSpeak"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>ミャンマー語(MYANMAR)</td>
                                            <td>読み書き(LISTENING) &nbsp;
                                        <asp:Label runat="server" ID="lblMyanmarRW"></asp:Label>
                                                &nbsp;
                                        会話(SPEAKING) &nbsp;
                                        <asp:Label runat="server" ID="lblMyanmarSpeak"></asp:Label>
                                            </td>
                                        </tr>
                                        </table>
                                    <table>
                                        <tr>
                                            <td style="width:300px;">※レベルの説明(Language Level)</td>
                                            <td>Ａ  ：ネイティブ並に話せる。<br />
                                                Ｂ+ ：多様なビジネス場面で英語で話すことができる。<br />
                                                Ｂ  ：ビジネス場面で適切な英語を話すことができる。<br />
                                                Ｂ- ：限られたビジネス場面で英語を話すことができる。<br />
                                                Ｃ+ ：社内の多様な場面で英語で話すことができる。<br />
                                                Ｃ  ：社内会話可能。<br />
                                                Ｃ- ：限られた場面での社内会話可能。<br />
                                                Ｄ  ：簡単な質問に対応可能。<br />
                                                Ｅ  ：英語は話せない。<br />
                                            </td>
                                            <td>Ａ  ：Native (or) Can deal business with foreigner<br />
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
                                </div>
                                <div class="tab-pane fade" id="messages">
                                    <asp:Label runat="server" ID="lblInterviewQuestion3" Font-Names="Zawgyi-One"></asp:Label>
                                    <table class="table">
                                        <tr>
                                            <td valign="top" style="width:400px;">(COMMENTS FROM  INTERVIEWER)</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="lblJapaneseInterviewer" TextMode="MultiLine"
                                                    BorderColor="Transparent" BorderStyle="None" ReadOnly="true" Height="150px" Width="700px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="width:400px;">(Impression)</td>
                                            <td valign="top">
                                                <asp:TextBox ID="lblimpression" runat="server" TextMode="Multiline"  BorderStyle="None"
                                                    ReadOnly="true" BorderColor="Transparent" Height="150px" Width="700px" CssClass="font"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="width:400px;">Impression for Comment sheet in Japanese</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtimpressionjp" TextMode="MultiLine"
                                                    BorderColor="Transparent" BorderStyle="None" ReadOnly="true" Height="150px" Width="700px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="width:400px;">Updated Informations</td>
                                            <td>
                                                <asp:TextBox runat="server" ID="txtUpdatedInfo" TextMode="MultiLine"
                                                    BorderColor ="Transparent" BorderStyle="None" ReadOnly="true" Height="150px" Width="700px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="tab-pane fade" id="settings">
                                    <table class="table">
                                        <tr>
                                            <td style="width: 600px;">DATA SHEET & EMPLOYMENT RECORD</td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkDatasheetData" OnClick="lnkDatasheetData_Click"></asp:LinkButton>
                                                <asp:ImageButton ID="imgDataSheet" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="false" />
                                                <asp:CheckBox ID="chkDatasheetData" runat="server" Visible="false" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>CV</td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkCredentialData" OnClick="lnkCredentialData_Click"></asp:LinkButton>
                                                <asp:ImageButton ID="imgCredential" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="false" />
                                                <asp:CheckBox ID="chkCredentialData" runat="server" Visible="false" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Photo</td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkPhoto" OnClick="lnkPhoto_Click"></asp:LinkButton>
                                                <asp:ImageButton ID="imgPhoto" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="false" />
                                                <asp:CheckBox ID="chkPhoto" runat="server" Visible="false" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Certificate & Qualification</td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkGraduationData" OnClick="lnkGraduationData_Click"></asp:LinkButton>
                                                <asp:ImageButton ID="imgGraduation" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="false" />
                                                <asp:CheckBox ID="chkGraduationData" runat="server" Visible="false" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Others1</td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkCardData" OnClick="lnkCardData_Click"></asp:LinkButton>
                                                <asp:ImageButton ID="imgCard" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="false" />
                                                <asp:CheckBox ID="chkCardData" runat="server" Visible="false" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Others2</td>
                                            <td>
                                                <asp:LinkButton runat="server" ID="lnkCard" OnClick="lnkCard_Click"></asp:LinkButton>
                                                <asp:ImageButton ID="ImgLabour" runat="server" OnClientClick="return LoadDiv(this.src);" Height="50px" Width="50px" Visible="false" />
                                                <asp:CheckBox ID="chkCard" runat="server" Visible="false" />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
        </section>
        <!-- /#page-wrapper -->
    </section>
    <!-- javascripts -->
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery-ui-1.10.4.min.js"></script>
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.9.2.custom.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="../js/scripts.js"></script>
</asp:Content>

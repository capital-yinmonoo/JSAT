<%@ Page Title="人材紹介申込一覧" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Client_Recruitment_View.aspx.cs" Inherits="JSAT_Ver1.Employer.Client_Recruitment_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
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
        }
        
        function updateValue(value) {
            // this gets called from the popup window and updates the field with a new value
            var Name = '<%= hfValue.ClientID %>';
            document.getElementById(Name).value = value;
            __doPostBack('<%= imgSearch.ClientID  %>', '');
        }
    </script>
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
                            人材紹介申込一覧(Recruitment List)
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="form-group">

                                <asp:HiddenField ID="HiddenField1" runat="server" />

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <fieldset>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                                                            HeaderText="You must enter a value in the following fields:"
                                                            EnableClientScript="true"
                                                            ForeColor="Red"
                                                            ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true"
                                                            ValidationGroup="check" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblName" Text="会社名(Company Name)" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtName" runat="server" Width="150px" Height="30px" CssClass="form-control"></asp:TextBox>
                                                        &nbsp;<asp:ImageButton ID="imgSearch" runat="server" Height="28px" Width="28px" ImageUrl="~/img/search.png" OnClientClick="ShowDialog()" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblClientNo" Text="クライアントNo.(Client No.)" runat="server" Width="220px"></asp:Label>
                                                        <asp:TextBox ID="txtClientNo" CssClass="form-control" runat="server" Width="150px" Height="30px" onkeypress="CheckNumeric(event);" ValidationGroup="check"></asp:TextBox>
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator2"
                                                            runat="server"
                                                            ValidationExpression="\d+"
                                                            ControlToValidate="txtClientNo"
                                                            Text="*"
                                                            ErrorMessage="You Must Only number in クライアントNo."
                                                            ValidationGroup="check"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRecruitmentNo" Text="人材紹介No.(Recruitment No.)" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtRecruitmentNo" runat="server" Width="150px" Height="30px" CssClass="form-control"></asp:TextBox>
                                                        <asp:RegularExpressionValidator
                                                            ID="RegularExpressionValidator1"
                                                            runat="server"
                                                            ValidationExpression="\d+"
                                                            ControlToValidate="txtRecruitmentNo"
                                                            Text="*"
                                                            ErrorMessage="You Must Only number in 人材紹介No."
                                                            ValidationGroup="check"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPersonInCharge" Text="担当者名(Contact Person)" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtPersonInCharge" CssClass="form-control" Width="150px" Height="30px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblContactPhoneNo" Text="担当者電話番号(Contact Phone No.)" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtContactPhoneNo" CssClass="form-control" Width="150px" Height="30px" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                         <asp:Label ID="lblPosition" Text="職種(Postion)" runat="server" Width="158px"></asp:Label>
                                                          <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control" Height="30px" Width="500px"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td width="190px">
                                                        <asp:Label ID="lblJapanLanguage" runat="server" Text="日本語(Japanese):"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblJPRW" runat="server" Text="読み書き(Read and Write)"></asp:Label>
                                                        <asp:DropDownList ID="ddlJPRW" CssClass="form-control" runat="server" Width="59px" Height="30px"></asp:DropDownList>
                                                        <asp:CheckBox ID="chkJPRW" runat="server" Text="以上(Up To)" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblJPSpeaking" runat="server" Text="会話(Speaking):"></asp:Label>
                                                        <asp:DropDownList ID="ddlJPSpeaking" CssClass="form-control" runat="server" Width="59px" Height="30px"></asp:DropDownList>
                                                        <asp:CheckBox ID="chkJPSpeaking" runat="server" Text="以上(Up To)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEnglish" runat="server" Text="英語(English):"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEngRW" runat="server" Text="読み書き(Read and Write)"></asp:Label>
                                                        <asp:DropDownList ID="ddlEngRW" CssClass="form-control" runat="server" Width="59px" Height="30px"></asp:DropDownList>
                                                        <asp:CheckBox ID="chkEngRW" runat="server" Text="以上(Up To)" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblEngSpeaking" runat="server" Text="会話(Speaking):"></asp:Label>
                                                        <asp:DropDownList ID="ddlEngSpeaking" CssClass="form-control" runat="server" Width="59px" Height="30px"></asp:DropDownList>
                                                        <asp:CheckBox ID="chkEngSpeaking" runat="server" Text="以上(Up To)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="ミャンマー語(Burmese):"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMnRW" runat="server" Text="読み書き(Read and Write)"></asp:Label>
                                                        <asp:DropDownList ID="ddlMnRW" CssClass="form-control" runat="server" Width="59px" Height="30px"></asp:DropDownList>
                                                        <asp:CheckBox ID="chkMnRW" runat="server" Text="以上(Up To)" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblMnSpeaking" runat="server" Text="会話(Speaking):"></asp:Label>
                                                        <asp:DropDownList ID="ddlMnSpeaking" CssClass="form-control" runat="server" Width="59px" Height="30px"></asp:DropDownList>
                                                        <asp:CheckBox ID="chkMnSpeaking" runat="server" Text="以上(Up To)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label runat="server" ID="lblWanted" Text="募集中(During Recruitment)"></asp:Label>
                                                        <asp:CheckBox ID="chkWanted" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <center>
                                                <asp:Button ID="btnSearchData" runat="server" Height="43px" class="btn btn-primary" ValidationGroup="check"
                                                Text="検索する(Search)" Width="200px" onclick="btnSearchData_Click" />
                                                <asp:HiddenField ID="hfValue" runat="server" />
                                                </center>
                                            <br />
                                            <br />
                                            <asp:GridView ID="dgvClientRecruitment" runat="server" AllowPaging="True"
                                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
                                                DataKeyNames="ID"
                                                EmptyDataText="There is no data to display." ForeColor="#333333"
                                                GridLines="None" HeaderStyle-Wrap="false"
                                                OnPageIndexChanging="dgvClientRecruitment_PageIndexChanging"
                                                OnRowCommand="dgvClientRecruitment_RowCommand"
                                                OnRowDataBound="dgvClientRecruitment_RowDataBound"
                                                PagerSettings-PageButtonCount="10" ShowHeaderWhenEmpty="True"
                                                OnSorting="dgvClientRecruitment_Sorting" class="table">
                                                <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Options" HeaderStyle-ForeColor="White"> <%--操作--%>
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDetail" class="btn btn-primary" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Details"
                                                                CommandName="DataDetail"></asp:LinkButton> <%--Text="詳細"--%>
                                                            <asp:LinkButton ID="btnEdit" class="btn btn-primary" runat="server" CommandArgument='<%# Eval("ID") %>' Text="Edit"
                                                                CommandName="DataEdit"></asp:LinkButton> <%--Text="編集"--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ID" HeaderText="Recruitment_No." SortExpression="ID" HeaderStyle-ForeColor="White"> <%--人材紹介No.--%>
                                                        <HeaderStyle BorderStyle="Solid" />
                                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Client_ID" HeaderText="Client_ID" Visible="False" HeaderStyle-ForeColor="White">
                                                        <HeaderStyle BorderStyle="Solid" />
                                                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Name" HeaderText="Company_Name" SortExpression="Name" HeaderStyle-ForeColor="White"> <%--会社名--%>
                                                        <HeaderStyle BorderStyle="Solid" />
                                                        <ItemStyle HorizontalAlign="Center" Wrap="true" Width="300px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DivitionOrDepartment" Visible="false"
                                                        HeaderText="Job_Category(Major_Classification)" SortExpression="DivitionOrDepartment" HeaderStyle-ForeColor="White">    <%--職種(大分類)--%>
                                                        <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Position" HeaderText="Wanted_Jobs" SortExpression="Position" HeaderStyle-ForeColor="White"> <%--募集職種--%>
                                                        <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                        <ItemStyle HorizontalAlign="Center" Width="500px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Language" ControlStyle-Width="100px" HeaderStyle-ForeColor="White">  <%--言語--%>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblJapanese" Text="Japanese"></asp:Label>     <%--日本語--%>
                                                            <asp:Label runat="server" ID="Label2" Text="English"></asp:Label>      <%--英語--%>
                                                            <asp:Label runat="server" ID="lblBurmese" Text="Myanmar"></asp:Label>      <%--ミャンマー語--%>
                                                        </ItemTemplate>
                                                        <ControlStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Language_Level(Reading & Writing)" HeaderStyle-ForeColor="White"> <%--言語レベル(読み書き)--%>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblJapaneseRWData" Text='<%#Eval("JpRW") %>'></asp:Label><br />
                                                            <asp:Label runat="server" ID="lblEnglishRWData" Text='<%#Eval("EngRW") %>'></asp:Label><br />
                                                            <asp:Label runat="server" ID="lblBurmeseRWData" Text='<%#Eval("MnRW") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Language_Level(Conversation)" HeaderStyle-ForeColor="White"> <%--言語レベル(会話)--%>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="lblJapaneseSpeakingData" Text='<%#Eval("JpSpeaking") %>'></asp:Label><br />
                                                            <asp:Label runat="server" ID="lblEnglishSpeakingData" Text='<%#Eval("EngSpeaking") %>'></asp:Label><br />
                                                            <asp:Label runat="server" ID="lblBurmeseSpeakingData" Text='<%#Eval("MnSpeaking") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CompleteSalary" HeaderText="Salary" HeaderStyle-ForeColor="White" />   <%--給料--%>
                                                    <asp:BoundField DataField="Gender" HeaderText="Gender" Visible="false">   <%--性別--%>
                                                        <HeaderStyle BorderStyle="Solid" Wrap="true" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ContactPerson" HeaderText="Contact_Person" HeaderStyle-ForeColor="White">  <%--担当者名--%>
                                                        <ItemStyle HorizontalAlign="Center" Width="200px" />
                                                    </asp:BoundField>
                                                </Columns>
                                                 <HeaderStyle BackColor="#007aff" Font-Bold="True" ForeColor="White" />
                                                 <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                            </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div>
                                    <table>
                                        <tr>
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"></td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hfSort" runat="server" />

                                </div>
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
    <!--custome script for all page-->
    <script src="../js/scripts.js"></script>
</asp:Content>
